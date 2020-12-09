Public Class FrmEditPaper
    'Dim WithEvents FR As New ClassFormControl
    Dim _IsStart As Boolean = True
    Dim _NoSave As Boolean = False
    Dim _SelectPaperIndex As Integer = -1
    Dim _SelectFieldIndex As Integer = -1
    Dim _SelectPaper As ClassPaperCollection = Nothing
    Dim _PreviewZoom As Integer = 4
    Enum enumFrmEditPaperStartMode
        FromApplicationEvent
        FromMainForm
    End Enum
    Dim _StartMode As enumFrmEditPaperStartMode = enumFrmEditPaperStartMode.FromMainForm
    Property StartMode As enumFrmEditPaperStartMode
        Get
            Return _StartMode
        End Get
        Set(value As enumFrmEditPaperStartMode)
            _StartMode = value
        End Set
    End Property
    ''' <summary>
    ''' フォームを閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmEditPaper_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームを閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmEditPaper_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _StartMode = enumFrmEditPaperStartMode.FromApplicationEvent Then
            MsgBox("一旦タックラベラーを終了します。" & vbCrLf & "アプリケーションを再度起動してください。", 48, "情報")
        End If
        Call SavePaperArray()

    End Sub
    ''' <summary>
    ''' 矢印キーによるオブジェクト移動とサイズ変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmEditPaper_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim Span As Decimal = 0.1
        Try
            If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
                Span = 0.5
            End If

            If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                Select Case e.KeyCode
                    Case Keys.Right
                        TxtFieldLeft.Value += Span : e.Handled = True
                    Case Keys.Left
                        TxtFieldLeft.Value -= Span : e.Handled = True
                    Case Keys.Up
                        TxtFieldTop.Value -= Span : e.Handled = True
                    Case Keys.Down
                        TxtFieldTop.Value += Span : e.Handled = True
                End Select
            Else
                If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
                    Select Case e.KeyCode
                        Case Keys.Right
                            TxtFieldWidth.Value += Span : e.Handled = True
                        Case Keys.Left
                            TxtFieldWidth.Value -= Span : e.Handled = True
                        Case Keys.Up
                            TxtFieldHeight.Value -= Span : e.Handled = True
                        Case Keys.Down
                            TxtFieldHeight.Value += Span : e.Handled = True
                    End Select
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    'Dim MMM As New Form2
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmEditPaper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With GroupBox2
            .Location = New Point(GroupBox6.Location)
            .Size = New Size(GroupBox6.Size)
            .Visible = False
        End With

        Call Initial()
        If _SelectPaperIndex = 0 Then
            Call GetData()
        Else
            Call ClearField()
        End If
    End Sub
    ''' <summary>
    ''' 画面内容初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Initial()

        CmbType.SelectedIndex = 0

        Try
            With CmbPaperSize
                .Items.Clear()
                .DisplayMember = "Value" : .ValueMember = "Key"
                For Each Item As ClassPaperInfo In PaperInfoArray
                    .Items.Add(New DictionaryEntry(Item.DataID, Item.Text))
                Next
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With

            With CmbPaperArray
                .Items.Clear()
                If PaperArray.Count > 0 Then
                    For Each Item As ClassPaperCollection In PaperArray
                        .Items.Add(Item.Text)
                    Next
                    If .Items.Count > 0 Then
                        .SelectedIndex = 0
                        _SelectPaperIndex = 0
                    End If
                End If
            End With

            With CmbFieldtext_align
                .Items.Clear()
                .DisplayMember = "Value" : .ValueMember = "Key"
                .Items.Add(New DictionaryEntry("left", "左寄せ"))
                .Items.Add(New DictionaryEntry("center", "中央寄せ"))
                .Items.Add(New DictionaryEntry("right", "右寄せ"))
            End With
            With CmbFieldvertical_align
                .Items.Clear()
                .DisplayMember = "Value" : .ValueMember = "Key"
                .Items.Add(New DictionaryEntry("top", "上付き"))
                .Items.Add(New DictionaryEntry("middle", "中央"))
                .Items.Add(New DictionaryEntry("bottom", "下付き"))
            End With

            AddHandler CmbOrientation.SelectedIndexChanged, AddressOf Data_ValueChanged

            AddHandler TxtLeftMargin.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtRightMargin.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtTopMargin.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtBottomMargin.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtSheetHeight.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtSheetColumnCount.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtSheetRowCount.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtSheetColumnSpacing.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtSheetRowSpacing.ValueChanged, AddressOf Data_ValueChanged
            AddHandler ChkGroundPicture.CheckedChanged, AddressOf Data_ValueChanged
            AddHandler TxtGroundPicture.TextChanged, AddressOf Data_ValueChanged

            AddHandler TxtFieldText.TextChanged, AddressOf Data_ValueChanged
            AddHandler TxtFieldLeft.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtFieldTop.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtFieldWidth.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtFieldHeight.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtLineWidth.ValueChanged, AddressOf Data_ValueChanged
            AddHandler TxtAngle.ValueChanged, AddressOf Data_ValueChanged

            AddHandler CmbFieldtext_align.SelectedIndexChanged, AddressOf Data_ValueChanged
            AddHandler CmbFieldvertical_align.SelectedIndexChanged, AddressOf Data_ValueChanged
            AddHandler CmbLineStyle.SelectedIndexChanged, AddressOf Data_ValueChanged

            AddHandler ChkFieldBold.CheckedChanged, AddressOf Data_ValueChanged
            AddHandler LblFieldFontName.TextChanged, AddressOf Data_ValueChanged
            AddHandler LblFieldFontSize.TextChanged, AddressOf Data_ValueChanged
            AddHandler TxtLabelText.TextChanged, AddressOf Data_ValueChanged
            AddHandler ChkAddStr1.CheckedChanged, AddressOf Data_ValueChanged
            AddHandler ChkLabelIsMask.CheckedChanged, AddressOf Data_ValueChanged
            AddHandler ChkBarCaption.CheckedChanged, AddressOf Data_ValueChanged
            AddHandler ChkColorReverse.CheckedChanged, AddressOf Data_ValueChanged
            AddHandler ChkIME.CheckedChanged, AddressOf Data_ValueChanged
            AddHandler TxtAddString_Front.TextChanged, AddressOf Data_ValueChanged
            AddHandler TxtAddString_Back.TextChanged, AddressOf Data_ValueChanged
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "画面初期化エラー")
        End Try
      
    End Sub
    ''' <summary>
    ''' 値変更共通メソッド
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Data_ValueChanged(sender As Object, e As EventArgs)
        Call Calc()
    End Sub
    ''' <summary>
    ''' 入力項目の初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearField()
        _IsStart = True
        PnlData.Enabled = False
        TxtMaker.Text = ""
        TxtName.Text = ""
        TxtText.Text = ""
        TxtCaption.Text = ""

        CmbPaperSize.SelectedIndex = 0
        TxtLeftMargin.Value = 0
        TxtRightMargin.Value = 0
        TxtTopMargin.Value = 0
        TxtBottomMargin.Value = 0
        TxtPaperWidth.Value = 0
        TxtPaperHeight.Value = 0
        CmbOrientation.SelectedIndex = 0
        TxtPrintWidth.Value = 0
        TxtGroundPicture.Text = ""

        TxtSheetHeight.Value = 0
        TxtSheetWidth.Value = 0
        TxtSheetColumnCount.Value = 0
        TxtSheetRowCount.Value = 0
        TxtSheetColumnSpacing.Value = 0
        TxtSheetRowSpacing.Value = 0

        ListBox1.Items.Clear()
        ChkFieldVisible.Checked = False
        TxtFieldText.Text = ""
        TxtFieldLeft.Value = 0
        TxtFieldTop.Value = 0
        TxtFieldWidth.Value = 0
        TxtFieldHeight.Value = 0
        TxtAngle.Value = 0
        LblFieldFontName.Text = ""
        LblFieldFontSize.Text = ""
        ChkFieldBold.Checked = False
        CmbFieldtext_align.SelectedIndex = 0
        CmbFieldvertical_align.SelectedIndex = 0
        ChkFieldMultiLine.Checked = False
        ChkFieldddo_shrink_to_fit.Checked = False
        CmbFieldUseType.SelectedIndex = 0
        ChkCenter.Checked = False
        LblSelFieldName.Text = ""
        ChkAddStr1.Checked = False
        ChkLabelIsMask.Checked = False
        ChkBarCaption.Checked = False
        ChkColorReverse.Checked = False
        ChkIME.Checked = False
        TxtAddString_Front.Text = ""
        TxtAddString_Back.Text = ""
        _IsStart = False
    End Sub
    ''' <summary>
    ''' 入力項目の初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearField_FieldData()
        _IsStart = True : _NoDraw = True
        ChkFieldVisible.Checked = False
        TxtFieldText.Text = ""
        TxtFieldLeft.Value = 0
        TxtFieldTop.Value = 0
        TxtFieldWidth.Value = 0
        TxtFieldHeight.Value = 0
        TxtAngle.Value = 0
        LblFieldFontName.Text = ""
        LblFieldFontSize.Text = ""
        ChkFieldBold.Checked = False
        CmbFieldtext_align.SelectedIndex = 0
        CmbFieldvertical_align.SelectedIndex = 0
        ChkFieldMultiLine.Checked = False
        ChkFieldddo_shrink_to_fit.Checked = False
        CmbFieldUseType.SelectedIndex = 0
        ChkCenter.Checked = False
        LblSelFieldName.Text = ""
        ChkBarCaption.Checked = False
        ChkColorReverse.Checked = False
        ChkIME.Checked = False
        TxtAddString_Front.Text = ""
        TxtAddString_Back.Text = ""

        _IsStart = False : _NoDraw = False
    End Sub
    ''' <summary>
    ''' データ読み込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetData()
        Try
            Call ClearField()

            _SelectPaper = PaperArray(_SelectPaperIndex)

            TxtMaker.Text = _SelectPaper.MakerName
            TxtName.Text = _SelectPaper.Name
            TxtText.Text = _SelectPaper.Text
            TxtCaption.Text = _SelectPaper.Caption.Replace("<BR>", vbCrLf)

            Call AutoComboSel(CmbPaperSize, _SelectPaper.PaperSize)
            TxtLeftMargin.Value = _SelectPaper.LeftMargin
            TxtRightMargin.Value = _SelectPaper.RightMargin
            TxtTopMargin.Value = _SelectPaper.TopMargin
            TxtBottomMargin.Value = _SelectPaper.BottomMargin
            TxtGroundPicture.Text = _SelectPaper.GroundPicture
            If TxtGroundPicture.Text <> "" Then
                ChkGroundPicture.Checked = True
            Else
                ChkGroundPicture.Checked = False
            End If
            CmbOrientation.SelectedIndex = _SelectPaper.Orientation - 1

            TxtGroundPicture.Text = _SelectPaper.GroundPicture

            TxtSheetHeight.Value = _SelectPaper.Section.Height '- _SelectPaper.Section.RowSpacing
            TxtSheetColumnCount.Value = _SelectPaper.Section.ColumnCount
            TxtSheetRowCount.Value = _SelectPaper.Section.RowCount
            TxtSheetColumnSpacing.Value = _SelectPaper.Section.ColumnSpacing
            TxtSheetRowSpacing.Value = _SelectPaper.Section.RowSpacing
            LblSelFieldName.Text = ""

            With ListBox1
                .Items.Clear()
                .DisplayMember = "Value"
                .ValueMember = "Key"
                For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
                    If FD.IsSystem = False Then
                        .Items.Add(New DictionaryEntry(FD.Name, FD.Text))
                    End If
                Next
            End With
            PnlData.Enabled = True
            _NoDraw = False
            Call Calc()
            Call ScreenWork()
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "データ読込エラー")
        End Try

    End Sub
    Private Sub Calc()
        Try
            If CmbOrientation.SelectedIndex = 0 Then
                TxtPrintWidth.Value = TxtPaperWidth.Value - TxtRightMargin.Value - TxtLeftMargin.Value
                TxtSheetWidth.Value = (TxtPrintWidth.Value - (TxtSheetColumnSpacing.Value * (TxtSheetColumnCount.Value - 1))) / TxtSheetColumnCount.Value
            Else
                TxtPrintWidth.Value = TxtPaperHeight.Value - TxtRightMargin.Value - TxtLeftMargin.Value
                TxtSheetWidth.Value = (TxtPrintWidth.Value - (TxtSheetColumnSpacing.Value * (TxtSheetColumnCount.Value - 1))) / TxtSheetColumnCount.Value
            End If
            Call ScreenWork()

        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' 入力データを配列に登録する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetData() As Boolean
        If ListBox1.Items.Count = 0 Then
            MsgBox("出力フィールドが１つも追加されていません")
            Return False
        End If
        _IsStart = True : _NoDraw = True

        If _SelectFieldIndex > -1 AndAlso LblSelFieldName.Text <> "" Then
            Call SetFieldData()
        End If

        Call ShapeSet()

        _SelectPaper.MakerName = TxtMaker.Text
        _SelectPaper.Name = TxtName.Text
        _SelectPaper.Text = TxtText.Text
        _SelectPaper.Caption = TxtCaption.Text.Replace(vbCrLf, "<BR>")

        _SelectPaper.PaperSize = DirectCast(CmbPaperSize.SelectedItem, DictionaryEntry).Key
        _SelectPaper.LeftMargin = TxtLeftMargin.Value
        _SelectPaper.RightMargin = TxtRightMargin.Value
        _SelectPaper.TopMargin = TxtTopMargin.Value
        _SelectPaper.BottomMargin = TxtBottomMargin.Value
        _SelectPaper.Orientation = (CmbOrientation.SelectedIndex + 1).ToString
        _SelectPaper.GroundPicture = TxtGroundPicture.Text
        _SelectPaper.PaperWidth = TxtPaperWidth.Value
        _SelectPaper.PaperHeight = TxtPaperHeight.Value

        _SelectPaper.Layout.PrintWidth = TxtPrintWidth.Value

        _SelectPaper.Section.Height = TxtSheetHeight.Value '+ TxtSheetRowSpacing.Value
        _SelectPaper.Section.ColumnCount = TxtSheetColumnCount.Value
        _SelectPaper.Section.RowCount = TxtSheetRowCount.Value
        _SelectPaper.Section.ColumnSpacing = TxtSheetColumnSpacing.Value
        _SelectPaper.Section.RowSpacing = TxtSheetRowSpacing.Value

        PaperArray(_SelectPaperIndex) = _SelectPaper
        CmbPaperArray.Items(_SelectPaperIndex) = TxtText.Text
        _IsStart = False : _NoDraw = False
        Return True
    End Function
    Private Sub FrmEditPaper_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _IsStart = False
    End Sub
    ''' <summary>
    ''' 用紙コンボ選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbPaperArray_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPaperArray.SelectedIndexChanged
        If Not _IsStart Then
            If Not _NoSave Then
                If Not SetData() Then
                    Return
                    'FR.Edited = False
                End If
            End If
            _SelectPaperIndex = CmbPaperArray.SelectedIndex
            Call GetData()

            _AnchorMaster = ""
            _AnchorChild.Clear()
        End If
    End Sub
    ''' <summary>
    ''' 用紙コンボの選択
    ''' </summary>
    ''' <param name="CMB"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Private Sub AutoComboSel(CMB As ComboBox, Value As String)
        With CMB
            If .Items.Count > 0 Then
                For i As Integer = 0 To .Items.Count - 1
                    Dim Item As DictionaryEntry = .Items(i)
                    If Item.Key = Value Then
                        .SelectedIndex = i
                        Return
                    End If
                Next
            End If
        End With
    End Sub
    ''' <summary>
    ''' 用紙サイズコンボ選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbPaperSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPaperSize.SelectedIndexChanged
        Dim Key As Integer = DirectCast(CmbPaperSize.SelectedItem, System.Collections.DictionaryEntry).Key
        For Each P As ClassPaperInfo In PaperInfoArray
            If Key = P.DataID Then
                TxtPaperWidth.Value = P.Width
                TxtPaperHeight.Value = P.Height
                Call Calc()
                Return
            End If
        Next
        'Public PaperInfoArray As New List(Of ClassPaperInfo)
    End Sub

    Dim _AnchorMaster As String = "" '整列する元のフィールド名
    Dim _AnchorChild As New ArrayList '整列させるフィールド名

    ''' <summary>
    ''' 登録フィールド選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If Not _IsStart Then
            _IsStart = True : _NoDraw = True

            If _SelectFieldIndex > -1 AndAlso LblSelFieldName.Text <> "" AndAlso LblSelFieldName.Text <> "<未選択>" Then
                Call SetFieldData()
                ListBox1.Items(_SelectFieldIndex) = New DictionaryEntry(LblSelFieldName.Text, TxtFieldText.Text)
            End If

            If ListBox1.SelectedIndex > -1 Then
                Dim Item As DictionaryEntry = ListBox1.Items(ListBox1.SelectedIndex) ' ListBox1.SelectedItem
                LblSelFieldName.Text = Item.Key
                _SelectFieldIndex = ListBox1.SelectedIndex
                Call GetFieldData()
                PnlMain.Visible = True

                'アンカーリストの登録
                If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                    If _AnchorMaster = "" Then
                        _AnchorMaster = LblSelFieldName.Text
                        _AnchorChild.Clear()
                    Else
                        If _AnchorMaster <> LblSelFieldName.Text Then
                            _AnchorChild.Add(LblSelFieldName.Text)
                        End If
                    End If
                Else
                    _AnchorMaster = LblSelFieldName.Text
                    _AnchorChild.Clear()
                End If

            Else
                LblSelFieldName.Text = "" '"<未選択>"
                PnlMain.Visible = False

                _AnchorMaster = ""
                _AnchorChild.Clear()
            End If

            _IsStart = False : _NoDraw = False
            Call Calc()
        End If
    End Sub
    ''' <summary>
    ''' 数値用コントロールの値調整
    ''' </summary>
    ''' <param name="Obj"></param>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function NumberSet(Obj As NumericUpDown, Value As Integer) As Integer
        Select Case True
            Case Value < Obj.Minimum
                Return Obj.Minimum
            Case Obj.Maximum < Value
                Return Obj.Maximum
            Case Else
                Return Value
        End Select
    End Function
    ''' <summary>
    ''' フィールド情報を読み込む
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetFieldData()
        ChkCenter.Checked = False
        Dim _T As ClassFieldCollection = Nothing
        For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
            If FD.Name = LblSelFieldName.Text Then
                _T = FD
                Exit For
            End If
        Next
        If Not IsNothing(_T) Then
            TxtFieldText.Text = _T.Text

            Select Case _T.FieldType
                Case enumFieldType.Label
                    CmbType.SelectedIndex = 1
                Case enumFieldType.Line
                    CmbType.SelectedIndex = 2
                Case enumFieldType.Box
                    CmbType.SelectedIndex = 3
                Case enumFieldType.Barcode39
                    CmbType.SelectedIndex = 4
                Case enumFieldType.BarcodeQR
                    CmbType.SelectedIndex = 5
                Case enumFieldType.Memo
                    CmbType.SelectedIndex = 6
                Case Else
                    CmbType.SelectedIndex = 0
            End Select

            ChkFieldVisible.Checked = _T.Visible
            ChkFieldMultiLine.Checked = _T.MultiLine
            CmbFieldUseType.SelectedIndex = _T.FieldUseType
            TxtFieldLeft.Value = _T.Left
            TxtFieldTop.Value = _T.Top
            TxtFieldWidth.Value = _T.Width
            TxtFieldHeight.Value = _T.Height
            TxtAngle.Value = NumberSet(TxtAngle, _T.Angle)

            LblFieldFontName.Text = _T.Style.font_family
            LblFieldFontSize.Text = _T.Style.font_size
            ChkFieldBold.Checked = IIf(_T.Style.font_weight = "bold", True, False)
            ChkFieldCanShrink.Checked = _T.CanShrink
            Call AutoComboSel(CmbFieldtext_align, _T.Style.text_align)
            Call AutoComboSel(CmbFieldvertical_align, _T.Style.vertical_align)

            ChkFieldddo_shrink_to_fit.Checked = IIf(_T.Style.ddo_shrink_to_fit = "true", True, False)
            TxtLineWidth.Value = _T.LineWidth
            TxtLabelText.Text = _T.LabelText
            CmbLineStyle.SelectedIndex = _T.LineStyle
            ChkAddStr1.Checked = _T.AddStr1
            TxtDisplayWidth.Value = _T.DisplayWidth
            ChkLabelIsMask.Checked = _T.LabelIsMask
            ChkBarCaption.Checked = _T.BarcodeCaption
            ChkColorReverse.Checked = _T.ColorReverse
            ChkIME.Checked = _T.UseIME
            TxtAddString_Front.Text = _T.AddString_Front
            TxtAddString_Back.Text = _T.AddString_Back
        End If
    End Sub
    ''' <summary>
    ''' フィールド情報を保存する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetFieldData()
        Try
            For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
                If FD.Name = LblSelFieldName.Text Then
                    If TxtFieldText.Text = "" Then
                        TxtFieldText.Text = "テキスト"
                    End If

                    Select Case CmbType.SelectedIndex
                        Case 1
                            FD.FieldType = enumFieldType.Label
                        Case 2
                            FD.FieldType = enumFieldType.Line
                        Case 3
                            FD.FieldType = enumFieldType.Box
                        Case 4
                            FD.FieldType = enumFieldType.Barcode39
                        Case 5
                            FD.FieldType = enumFieldType.BarcodeQR
                        Case 6
                            FD.FieldType = enumFieldType.Memo
                        Case Else
                            FD.FieldType = enumFieldType.Field
                    End Select

                    FD.Text = TxtFieldText.Text
                    FD.Visible = ChkFieldVisible.Checked
                    FD.MultiLine = ChkFieldMultiLine.Checked
                    FD.FieldUseType = CmbFieldUseType.SelectedIndex
                    FD.Left = TxtFieldLeft.Value
                    FD.Top = TxtFieldTop.Value
                    FD.Width = TxtFieldWidth.Value
                    FD.Height = TxtFieldHeight.Value
                    FD.CanShrink = ChkFieldCanShrink.Checked
                    FD.LineWidth = TxtLineWidth.Value
                    FD.Angle = TxtAngle.Value
                    'If FD.FieldType = enumFieldType.Box Then
                    '    FD.LineStyle = 1
                    'End If
                    FD.LabelText = TxtLabelText.Text

                    FD.Style.font_family = LblFieldFontName.Text
                    FD.Style.font_size = LblFieldFontSize.Text
                    FD.Style.font_weight = IIf(ChkFieldBold.Checked, "bold", "none")
                    FD.Style.text_align = DirectCast(CmbFieldtext_align.SelectedItem, System.Collections.DictionaryEntry).Key
                    FD.Style.vertical_align = DirectCast(CmbFieldvertical_align.SelectedItem, System.Collections.DictionaryEntry).Key
                    FD.Style.ddo_shrink_to_fit = IIf(ChkFieldddo_shrink_to_fit.Checked, "true", "none")
                    FD.LineStyle = CmbLineStyle.SelectedIndex
                    FD.AddStr1 = ChkAddStr1.Checked
                    FD.DisplayWidth = TxtDisplayWidth.Value
                    FD.LabelIsMask = ChkLabelIsMask.Checked
                    FD.LabelText = TxtLabelText.Text
                    FD.BarcodeCaption = ChkBarCaption.Checked
                    FD.ColorReverse = ChkColorReverse.Checked
                    FD.UseIME = ChkIME.Checked
                    If ChkFieldddo_shrink_to_fit.Checked Then
                        '文字自動縮小の場合はnowrpに自動的に設定する
                        FD.Style.white_space = "nowrap"
                    Else
                        FD.Style.white_space = "inherit" '←WordWrap
                    End If
                    FD.AddString_Front = TxtAddString_Front.Text
                    FD.AddString_Back = TxtAddString_Back.Text
                    Return
                End If
            Next
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "フィールド情報保存エラー")
        End Try
      
    End Sub
    ''' <summary>
    ''' フォント選択ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSelFont_Click(sender As Object, e As EventArgs) Handles BtnSelFont.Click

        With FontDialog1
            Dim PT As Single = CSng(LblFieldFontSize.Text.Replace("pt", ""))
            Dim FS As New FontStyle
            If ChkFieldBold.Checked Then
                FS = FontStyle.Bold
            Else
                FS = FontStyle.Regular
            End If
            .Font = New Font(LblFieldFontName.Text, PT, FS)
            Try
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    LblFieldFontName.Text = .Font.Name
                    LblFieldFontSize.Text = .Font.Size.ToString & "pt"
                    ChkFieldBold.Checked = .Font.Bold
                End If
            Catch ex As Exception
                MsgBox(ExMessCreater(GetStack(ex)), 48, "フォント選択エラー")
            End Try
        End With
    End Sub
    ''' <summary>
    ''' フィールド表示チェックボックス
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkFieldVisible_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFieldVisible.CheckedChanged
        If ChkFieldVisible.Checked = False Then
            Dim _Flg As Boolean = False
            For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
                If FD.FieldType = enumFieldType.Field OrElse FD.FieldType = enumFieldType.Label OrElse FD.FieldType = enumFieldType.Barcode39 OrElse FD.FieldType = enumFieldType.BarcodeQR Then
                    If LblSelFieldName.Text <> FD.Name Then
                        If FD.Visible = True Then
                            _Flg = True : Exit For
                        End If
                    End If
                End If
            Next

            If Not _Flg Then
                MsgBox("全てのフィールドを使用しないには設定できません", 48, "エラー")
                ChkFieldVisible.Checked = True
            End If
        End If
        CmbType.Enabled = ChkFieldVisible.Checked
        TxtFieldText.Enabled = ChkFieldVisible.Checked
        GroupBox2.Enabled = ChkFieldVisible.Checked
        GroupBox5.Enabled = ChkFieldVisible.Checked
        GroupBox6.Enabled = ChkFieldVisible.Checked
        GroupBox7.Enabled = ChkFieldVisible.Checked
        GroupBox8.Enabled = ChkFieldVisible.Checked
    End Sub
    ''' <summary>
    ''' 新規フィールド追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnAddField_Click(sender As Object, e As EventArgs) Handles BtnAddField.Click
        If _SelectPaper.Section.FieldData.Count >= 20 Then
            MsgBox("作成フィールドは２０個までです。", 48, "エラー")
        Else
            Dim O As New ClassFieldCollection
            O.FieldType = enumFieldType.Field
            O.ARType = "AR.Field"
            _SelectPaper.Section.FieldData.Add(O)

            Call RSetFieldName() 'フィールド名の再調整

            With ListBox1
                .Items.Clear()
                .DisplayMember = "Value"
                .ValueMember = "Key"
                For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
                    If FD.IsSystem = False Then
                        .Items.Add(New DictionaryEntry(FD.Name, FD.Text))
                    End If
                Next
                _SelectFieldIndex = -1
            End With
            Call ScreenWork()
        End If
    End Sub
    ''' <summary>
    ''' 選択フィールドコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_CopyField_Click(sender As Object, e As EventArgs) Handles CMP_CopyField.Click
        If _SelectPaper.Section.FieldData.Count >= 20 Then
            MsgBox("作成フィールドは２０個までです。", 48, "エラー")
        Else
            If ListBox1.SelectedIndex > -1 Then
                Dim _MasterKey As String = ""
                Dim Item As DictionaryEntry = ListBox1.Items(ListBox1.SelectedIndex) ' ListBox1.SelectedItem
                _MasterKey = Item.Key
                Dim _F As ClassFieldCollection = Nothing
                For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
                    If FD.Name = _MasterKey Then
                        _F = FD
                        Exit For
                    End If
                Next
                If Not IsNothing(_F) Then
                    Dim _T As ClassFieldCollection = New ClassFieldCollection(_F)
                    _T.Top = 0
                    _T.Left = 0
                    _SelectPaper.Section.FieldData.Add(_T)
                    Call RSetFieldName() 'フィールド名の再調整

                    With ListBox1
                        .Items.Clear()
                        .DisplayMember = "Value"
                        .ValueMember = "Key"
                        For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
                            If FD.IsSystem = False Then
                                .Items.Add(New DictionaryEntry(FD.Name, FD.Text))
                            End If
                        Next
                        .SelectedIndex = -1
                        _SelectFieldIndex = -1
                    End With
                    Call ScreenWork()
                    PnlMain.Visible = False
                End If

                Call GetFieldData()
                PnlMain.Visible = True
            End If
        End If
    End Sub
    ''' <summary>
    ''' 選択フィールド削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDelField_Click(sender As Object, e As EventArgs) Handles BtnDelField.Click
        If MsgBox("選択フィールドを削除してもいいですか？？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            For i As Integer = _SelectPaper.Section.FieldData.Count - 1 To 0 Step -1
                Dim Dat As ClassFieldCollection = _SelectPaper.Section.FieldData(i)
                If Not Dat.IsSystem Then
                    If Dat.Name = LblSelFieldName.Text Then
                        _SelectPaper.Section.FieldData.RemoveAt(i)
                    End If
                End If
            Next

            Call RSetFieldName() 'フィールド名の再調整

            With ListBox1
                .Items.Clear()
                .DisplayMember = "Value"
                .ValueMember = "Key"
                For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
                    If FD.IsSystem = False Then
                        .Items.Add(New DictionaryEntry(FD.Name, FD.Text))
                    End If
                Next
                _SelectFieldIndex = -1
                PnlMain.Visible = False
            End With
            Call ClearField_FieldData()
            Call ScreenWork()
        End If

    End Sub
    ''' <summary>
    ''' 削除されたりした時のフィールド名を調整する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RSetFieldName()
        Dim C As Integer = 1
        For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
            If Not FD.IsSystem Then
                FD.Name = String.Format("TxtField{0}", C)
                FD.DataField = String.Format("Field{0}", C)
                C += 1
            End If
        Next
    End Sub
    Dim _NoDraw As Boolean = True
    ''' <summary>
    ''' プレビュー描写
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScreenWork()
        If Not _NoDraw Then
            Call SetFieldData()

            PictureBox1.Size = New Size(TxtSheetWidth.Value * _PreviewZoom, TxtSheetHeight.Value * _PreviewZoom)

            If PictureBox1.Width > 0 AndAlso PictureBox1.Height > 0 Then
                '描画先とするImageオブジェクトを作成する
                Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                'ImageオブジェクトのGraphicsオブジェクトを作成する
                Dim g As Graphics = Graphics.FromImage(canvas)

                '用紙画像の表示
                If ChkGroundPicture.Checked AndAlso TxtGroundPicture.Text <> "" Then
                    If System.IO.File.Exists(TxtGroundPicture.Text) Then
                        Try
                            '画像ファイルを読み込んで、Imageオブジェクトとして取得する
                            Using img As Image = Image.FromFile(TxtGroundPicture.Text)
                                g.DrawImage(img, 0, 0, CInt(img.Width * (PictureBox1.Width / img.Width)), CInt(img.Height * (PictureBox1.Height / img.Height)))
                            End Using
                        Catch ex As Exception
                        End Try
                    End If
                End If

                For Each Item As ClassFieldCollection In _SelectPaper.Section.FieldData
                    If Not Item.IsSystem Then
                        Dim p As Pen
                        Select Case Item.FieldType
                            Case enumFieldType.Field, enumFieldType.Label, enumFieldType.Barcode39, enumFieldType.BarcodeQR
                                If Item.Visible Then
                                    Dim PosiX As Long = 0
                                    Dim PosiY As Long = 0

                                    Dim _Text As String = ""
                                    If Item.FieldType = enumFieldType.Field Then
                                        If Item.LabelText <> "" Then
                                            '_Text = Item.LabelText
                                            _Text = String.Format("{0}{1}{2}", Item.AddString_Front, Item.LabelText, Item.AddString_Back)

                                        Else
                                            '_Text = Item.Text
                                            _Text = String.Format("{0}{1}{2}", Item.AddString_Front, Item.Text, Item.AddString_Back)
                                        End If
                                    Else
                                        _Text = Item.LabelText
                                    End If
                                    Dim Fnt As Font = Nothing


                                    Dim _FZoom As Integer = 1
                                    Select Case _PreviewZoom
                                        Case 5 : _FZoom = 1.2
                                        Case 6 : _FZoom = 1.5
                                        Case Else : _FZoom = 1.0
                                    End Select
                                    If Item.Style.font_weight = "bold" Then
                                        Fnt = New Font(Item.Style.font_family, CInt(Item.Style.font_size.Replace("pt", "") * _FZoom), FontStyle.Bold)
                                    Else
                                        Fnt = New Font(Item.Style.font_family, CInt(Item.Style.font_size.Replace("pt", "") * _FZoom))
                                    End If

                                    Dim StringWidth As Integer = g.MeasureString(_Text, Fnt).Width
                                    Dim StringHeight As Integer = g.MeasureString(_Text, Fnt).Height

                                    Select Case Item.Style.text_align
                                        Case "left"
                                            PosiX = Item.Left * _PreviewZoom
                                        Case "center"
                                            PosiX = (Item.Left * _PreviewZoom) + ((Item.Width * _PreviewZoom) / 2) - (StringWidth / 2)
                                        Case "right"
                                            PosiX = (Item.Left * _PreviewZoom) + (Item.Width * _PreviewZoom) - StringWidth
                                    End Select
                                    Select Case Item.Style.vertical_align
                                        Case "top"
                                            PosiY = Item.Top * _PreviewZoom
                                        Case "middle"
                                            PosiY = (Item.Top * _PreviewZoom) + (Item.Height * _PreviewZoom / 2) - (StringHeight / 2)
                                        Case "bottom"
                                            PosiY = (Item.Top * _PreviewZoom) + (Item.Height * _PreviewZoom) - StringHeight
                                    End Select

                                    'g.TranslateTransform(PosiX, PosiY)

                                    If Item.Angle > 0 Then
                                        '角度がついている時
                                        'http://dobon.net/vb/dotnet/graphics/drawrotatedstring.html

                                        If _Text <> "" Then '文字が入ってなかったら無視
                                            Dim img0 As New Bitmap(1, 1) '大きさを調べるためのダミーのBitmapオブジェクトの作成

                                            Dim bg0 As Graphics = Graphics.FromImage(img0) 'imgのGraphicsオブジェクトを取得

                                            '文字列を描画したときの大きさを計算する
                                            'Dim w As Integer = CInt(bg0.MeasureString(_Text, Fnt).Width)
                                            'Dim h As Integer = CInt(Fnt.GetHeight(bg0))
                                            Dim wHalf As Integer = StringWidth / 2
                                            Dim hHalf As Integer = StringHeight / 2

                                            Dim img As New Bitmap(StringWidth, StringHeight) 'Bitmapオブジェクトを作り直す

                                            'imgに文字列を描画する
                                            Dim bg As Graphics = Graphics.FromImage(img)

                                            If Item.ColorReverse Then '白黒反転
                                                bg.DrawString(_Text, Fnt, Brushes.White, 0, 0)
                                            Else
                                                bg.DrawString(_Text, Fnt, Brushes.Black, 0, 0)
                                            End If

                                            '新しい座標位置を計算する
                                            Dim x As Single = PosiX
                                            Dim y As Single = PosiY
                                            Dim Cx As Single = x + (StringWidth / 2)
                                            Dim Cy As Single = y + (StringHeight / 2)

                                            x = Cx - RotP(wHalf, hHalf, -Item.Angle).X
                                            y = Cy - RotP(wHalf, hHalf, -Item.Angle).Y

                                            Dim PP As Point = RotP(wHalf, hHalf, Item.Angle)
                                            Dim x1 As Single = Cx + PP.X
                                            Dim y1 As Single = Cy - PP.Y
                                            Dim x2 As Single = Cx - PP.X
                                            Dim y2 As Single = Cy + PP.Y

                                            'PointF配列を作成
                                            Dim destinationPoints As PointF() = {New PointF(x, y), New PointF(x1, y1), New PointF(x2, y2)}

                                            If Item.ColorReverse Then '白黒反転
                                                g.FillRectangle(Brushes.Black, Item.Left * _PreviewZoom, Item.Top * _PreviewZoom, Item.Width * _PreviewZoom, Item.Height * _PreviewZoom)
                                            End If
                                            '画像を描画
                                            g.DrawImage(img, destinationPoints)

                                            bg0.Dispose()
                                            img0.Dispose()
                                            img.Dispose()
                                            bg.Dispose()
                                        End If
                                    Else
                                        '角度が０の時
                                        g.RotateTransform(0.0F)

                                        If Item.ColorReverse Then '白黒反転
                                            g.FillRectangle(Brushes.Black, Item.Left * _PreviewZoom, Item.Top * _PreviewZoom, Item.Width * _PreviewZoom, Item.Height * _PreviewZoom)
                                            g.DrawString(_Text, Fnt, New SolidBrush(Color.White), PosiX, PosiY)
                                        Else
                                            g.DrawString(_Text, Fnt, New SolidBrush(Color.Black), PosiX, PosiY)
                                        End If

                                    End If

                                    If (LblSelFieldName.Text = Item.Name) Then
                                        p = New Pen(Color.Red, 2)
                                    Else
                                        p = New Pen(Color.Black, 1)
                                    End If
                                    p.DashStyle = Drawing2D.DashStyle.Dot
                                    g.DrawRectangle(p, Item.Left * _PreviewZoom, Item.Top * _PreviewZoom, Item.Width * _PreviewZoom, Item.Height * _PreviewZoom)

                                    Call DrawAnchor(Item, g, Item.Left * _PreviewZoom, Item.Top * _PreviewZoom) 'アンカーの描写

                                    Select Case Item.FieldType
                                        Case enumFieldType.Barcode39, enumFieldType.BarcodeQR
                                            g.DrawLine(p, Item.Left * _PreviewZoom, Item.Top * _PreviewZoom, (Item.Left + Item.Width) * _PreviewZoom, (Item.Top + Item.Height) * _PreviewZoom)
                                            g.DrawLine(p, Item.Left * _PreviewZoom, (Item.Top + Item.Height) * _PreviewZoom, (Item.Left + Item.Width) * _PreviewZoom, Item.Top * _PreviewZoom)
                                    End Select
                                End If
                            Case enumFieldType.Line
                                '描画先とするImageオブジェクトを作成する
                                '(10, 20)-(100, 200)に、幅1の黒い線を引く
                                If LblSelFieldName.Text = Item.Name Then
                                    p = New Pen(Color.Red, Item.LineWidth)
                                Else
                                    p = New Pen(Color.Black, Item.LineWidth)
                                End If
                                p.DashStyle = Item.LineStyle

                                g.DrawLine(p, Item.Left * _PreviewZoom, Item.Top * _PreviewZoom, (Item.Left * _PreviewZoom) + (Item.Width * _PreviewZoom), (Item.Top * _PreviewZoom) + (Item.Height * _PreviewZoom))
                            Case enumFieldType.Box
                                If LblSelFieldName.Text = Item.Name Then
                                    p = New Pen(Color.Red, Item.LineWidth)
                                Else
                                    p = New Pen(Color.Black, Item.LineWidth)
                                End If
                                p.DashStyle = Item.LineStyle
                                g.DrawRectangle(p, Item.Left * _PreviewZoom, Item.Top * _PreviewZoom, (Item.Width * _PreviewZoom), (Item.Height * _PreviewZoom))
                            Case enumFieldType.Memo
                                '何も表示しない

                        End Select
                    End If

                Next
                PictureBox1.Image = canvas
            End If

            'Call ScreenWork2()
        End If


    End Sub
    ''' <summary>
    ''' フィールドの左上にアンカーを描写する
    ''' </summary>
    ''' <param name="Item"></param>
    ''' <param name="g"></param>
    ''' <param name="X1"></param>
    ''' <param name="Y1"></param>
    ''' <remarks></remarks>
    Private Sub DrawAnchor(Item As ClassFieldCollection, g As Graphics, X1 As Integer, Y1 As Integer)
        If _AnchorMaster <> "" Then
            If _AnchorMaster = Item.Name Then
                g.FillRectangle(Brushes.Black, X1 - 3, Y1 - 3, 6, 6) 'マスタアンカーは■
            Else
                If _AnchorChild.Count > 0 Then
                    If _AnchorChild.IndexOf(Item.Name) > -1 Then
                        Dim P As New Pen(Color.Black, 1)
                        g.DrawRectangle(P, X1 - 3, Y1 - 3, 6, 6) 'その他アンカーは□
                    End If
                End If
            End If

        End If
    End Sub

    ''' <summary>
    ''' 指定座標の回転後の座標を求める
    ''' </summary>
    ''' <param name="Value">回転前座標</param>
    ''' <param name="Rot">回転角（度）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RotP(Value As Point, Rot As Integer) As Point
        '回転前の中心からの距離
        Dim R As Double = Math.Sqrt(((Value.X - 0) ^ 2) + ((Value.Y - 0) ^ 2))
        '回転前の中心からの角度
        Dim Ang_Deg As Double = Math.Atan2(Value.Y, Value.X) * (180 / Math.PI)

        '角度の加算
        Ang_Deg = Ang_Deg + Rot

        'ラジアンに変換
        Dim radian As Double = Ang_Deg * (Math.PI / 180)
        '回転後の半径から座標を求める
        Dim y2 As Double = Math.Sin(radian) * R
        Dim x2 As Double = Math.Cos(radian) * R

        Return New Point(x2, y2)
    End Function
    ''' <summary>
    ''' 指定座標の回転後の座標を求める
    ''' </summary>
    ''' <param name="ValueX">回転前X座標</param>
    ''' <param name="ValueY">回転前Y座標</param>
    ''' <param name="Rot">回転角（度）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RotP(ValueX As Double, ValueY As Double, Rot As Integer) As Point
        Return RotP(New Point(ValueX, ValueY), Rot)

    End Function

    Private Sub ShapeSet()
        For Each Item As ClassFieldCollection In _SelectPaper.Section.FieldData
            If Item.IsSystem AndAlso Item.ARType = "AR.Shape" Then
                Item.Left = 0
                Item.Top = 0
                Item.Width = TxtSheetWidth.Value
                Item.Height = TxtSheetHeight.Value
                Exit For
            End If
        Next
    End Sub
    ''' <summary>
    ''' 保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSaveSheet_Click(sender As Object, e As EventArgs) Handles BtnSaveSheet.Click
        Call SetData()
    End Sub
    ''' <summary>
    ''' 新規用紙作成
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuNewSheet_Click(sender As Object, e As EventArgs) Handles MenuNewSheet.Click
        If MsgBox("新しい用紙を作成してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            Dim P As New ClassPaperCollection
            Dim S As New ClassSectionCollection

            S.Height = RPX2MM(2420.787, enumCalcType.H)
            S.ColumnCount = 1
            S.RowCount = 1

            Dim AddShape As New ClassFieldCollection
            AddShape.FieldType = enumFieldType.Shape
            AddShape.ARType = "AR.Shape"
            AddShape.Name = "Shape1"
            AddShape.DataField = ""
            AddShape.IsSystem = True
            S.FieldData.Add(AddShape)

            Dim AddShapeField As New ClassFieldCollection
            AddShapeField.FieldType = enumFieldType.Field
            AddShapeField.ARType = "AR.Field"
            AddShapeField.Name = "TxtFieldShape"
            AddShapeField.DataField = "FieldShape"
            AddShapeField.Height = 5
            AddShapeField.Width = 10
            AddShapeField.IsSystem = True
            AddShapeField.Visible = False
            S.FieldData.Add(AddShapeField)

            P.Section = S
            P.LeftMargin = 0
            P.RightMargin = 0
            P.TopMargin = 0
            P.BottomMargin = 0
            P.PaperSize = 9
            P.PaperWidth = RPX2MM(11906, enumCalcType.H)
            P.PaperHeight = RPX2MM(16838, enumCalcType.V)
            P.Orientation = 1
            P.GroundPicture = ""
            P.PaperID = CreateGUID()

            With P.Section.FieldData(0)
                .Width = RPX2MM(11906, enumCalcType.H) / P.Section.ColumnCount
                .Height = RPX2MM(2420.787, enumCalcType.H)
            End With

            PaperArray.Add(P)

            With CmbPaperArray
                .Items.Clear()
                If PaperArray.Count > 0 Then
                    For Each Item As ClassPaperCollection In PaperArray
                        .Items.Add(Item.Text)
                    Next
                    _NoSave = True
                    If .Items.Count > 0 Then
                        .SelectedIndex = .Items.Count - 1
                        _SelectPaperIndex = .SelectedIndex
                    End If
                    _NoSave = False
                End If
            End With
        End If

    End Sub
    ''' <summary>
    ''' 選択済み用紙の削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuDelSheet_Click(sender As Object, e As EventArgs) Handles MenuDelSheet.Click

        Dim InUse As Boolean = False
        Dim StartInsex As Integer = _SelectPaperIndex
        Dim Sql As String = String.Format("SELECT * FROM TabData WHERE UsePaperIndex={0}", _SelectPaperIndex)
        Using CMD As New OleDb.OleDbCommand(Sql, CN)
            Using DR As OleDb.OleDbDataReader = CMD.ExecuteReader
                If DR.Read Then
                    InUse = True
                End If
            End Using
        End Using
        If InUse Then
            MsgBox("この用紙は使用中です" & vbCrLf & "使用中の用紙は削除出来ません", 48, "エラー")
        Else
            If MsgBox("選択中の用紙を削除してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                Try
                    _NoSave = True
                    PaperArray.RemoveAt(_SelectPaperIndex)
                    With CmbPaperArray
                        .Items.Clear()
                        If PaperArray.Count > 0 Then
                            For Each Item As ClassPaperCollection In PaperArray
                                .Items.Add(Item.Text)
                            Next
                            If .Items.Count > 0 Then
                                .SelectedIndex = 0
                                _SelectPaperIndex = 0
                            End If

                            '使用用紙番号の切り詰め
                            For i As Integer = StartInsex To 50
                                Sql = String.Format("UPDATE TabData SET UsePaperIndex={0} WHERE UsePaperIndex={1}", i - 1, i)
                                Using CMD As New OleDb.OleDbCommand(Sql, CN)
                                    CMD.ExecuteNonQuery()
                                End Using
                            Next
                        Else
                            Call ClearField()
                        End If
                    End With
                    _NoSave = False

                Catch ex As Exception
                    MsgBox(ExMessCreater(GetStack(ex)), 48, "用紙削除エラー")
                End Try
            End If
        End If

    End Sub
    ''' <summary>
    ''' 用紙コピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuCopySheet_Click(sender As Object, e As EventArgs) Handles MenuCopySheet.Click
        If MsgBox("選択中の用紙をコピーしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            'PaperArray.Add(_SelectPaper)
            Call CopyData(_SelectPaperIndex)
            With CmbPaperArray
                .Items.Clear()
                If PaperArray.Count > 0 Then
                    For Each Item As ClassPaperCollection In PaperArray
                        .Items.Add(Item.Text)
                    Next
                    _IsStart = True
                    If .Items.Count > 0 Then
                        .SelectedIndex = .Items.Count - 1
                        _SelectPaperIndex = .SelectedIndex
                        _SelectPaper = Nothing
                        _SelectPaper = PaperArray(_SelectPaperIndex)
                    End If
                    _IsStart = False
                End If
            End With
        End If
    End Sub
    ''' <summary>
    '''　タック様式コピー
    ''' </summary>
    ''' <param name="PaperIndex"></param>
    ''' <remarks></remarks>
    Private Sub CopyData(PaperIndex As Integer)

        Dim _ToField As New List(Of ClassFieldCollection)
        For Each _FromField As ClassFieldCollection In PaperArray(PaperIndex).Section.FieldData
            Dim _TF As New ClassFieldCollection
            _TF.ARType = _FromField.ARType
            _TF.BackColor = _FromField.BackColor
            _TF.CanShrink = _FromField.CanShrink
            _TF.DataField = _FromField.DataField
            _TF.FieldType = _FromField.FieldType
            _TF.FieldUseType = _FromField.FieldUseType
            _TF.Height = _FromField.Height
            _TF.IsSystem = _FromField.IsSystem
            _TF.Left = _FromField.Left
            _TF.LineColor = _FromField.LineColor
            _TF.LineStyle = _FromField.LineStyle
            _TF.MultiLine = _FromField.MultiLine
            _TF.Name = _FromField.Name
            _TF.RoundingRadius = _FromField.RoundingRadius
            _TF.Text = _FromField.Text
            _TF.Top = _FromField.Top
            _TF.Visible = _FromField.Visible
            _TF.Width = _FromField.Width
            _TF.AddStr1 = _FromField.AddStr1
            _TF.DisplayWidth = _FromField.DisplayWidth
            _TF.LabelIsMask = _FromField.LabelIsMask
            _TF.LabelText = _FromField.LabelText
            _TF.Angle = _FromField.Angle
            _TF.BarcodeCaption = _FromField.BarcodeCaption
            _TF.ColorReverse = _FromField.ColorReverse
            _TF.UseIME = _FromField.UseIME
            _TF.AddString_Front = _FromField.AddString_Front
            _TF.AddString_Back = _FromField.AddString_Back

            Dim _FromStyle As ClassStyleCollection = _FromField.Style
            Dim _ToStyle As New ClassStyleCollection
            _ToStyle.ddo_char_set = _FromStyle.ddo_char_set
            _ToStyle.ddo_font_vertical = _FromStyle.ddo_font_vertical
            _ToStyle.ddo_shrink_to_fit = _FromStyle.ddo_shrink_to_fit
            _ToStyle.font_family = _FromStyle.font_family
            _ToStyle.font_size = _FromStyle.font_size
            _ToStyle.font_weight = _FromStyle.font_weight
            _ToStyle.text_align = _FromStyle.text_align
            _ToStyle.text_justify = _FromStyle.text_justify
            _ToStyle.vertical_align = _FromStyle.vertical_align
            _ToStyle.white_space = _FromStyle.white_space
            _TF.Style = _ToStyle

            _ToField.Add(_TF)
        Next

        Dim _FromSection As ClassSectionCollection = PaperArray(PaperIndex).Section
        Dim _ToSection As New ClassSectionCollection
        _ToSection.BackColor = _FromSection.BackColor
        _ToSection.ColumnCount = _FromSection.ColumnCount
        _ToSection.ColumnDirection = _FromSection.ColumnDirection
        _ToSection.ColumnSpacing = _FromSection.ColumnSpacing
        _ToSection.FieldData = _ToField
        _ToSection.Height = _FromSection.Height
        _ToSection.KeepTogether = _FromSection.KeepTogether
        _ToSection.Name = _FromSection.Name
        _ToSection.RowSpacing = _FromSection.RowSpacing
        _ToSection.Type = _FromSection.Type

        Dim _FromLayout As ClassLayoutCollection = PaperArray(PaperIndex).Layout
        Dim _ToLayout As New ClassLayoutCollection
        _ToLayout.DocumentName = _FromLayout.DocumentName
        _ToLayout.MasterReport = _FromLayout.MasterReport
        _ToLayout.PrintWidth = _FromLayout.PrintWidth
        _ToLayout.ScriptLang = _FromLayout.ScriptLang
        _ToLayout.UserData = _FromLayout.UserData
        _ToLayout.Version = _FromLayout.Version

        Dim _FromData As ClassPaperCollection = PaperArray(PaperIndex)
        Dim _ToData As New ClassPaperCollection
        _ToData.BottomMargin = _FromData.BottomMargin
        _ToData.Caption = _FromData.Caption
        _ToData.Layout = _ToLayout
        _ToData.LeftMargin = _FromData.LeftMargin
        _ToData.MakerName = _FromData.MakerName
        _ToData.Name = _FromData.Name
        _ToData.Orientation = _FromData.Orientation
        _ToData.PaperHeight = _FromData.PaperHeight
        _ToData.PaperName = _FromData.PaperName
        _ToData.PaperSize = _FromData.PaperSize
        _ToData.PaperWidth = _FromData.PaperWidth
        _ToData.RightMargin = _FromData.RightMargin
        _ToData.Section = _ToSection
        _ToData.Text = _FromData.Text
        _ToData.TopMargin = _FromData.TopMargin
        _ToData.GroundPicture = _FromData.GroundPicture
        _ToData.PaperID = CreateGUID()

        PaperArray.Add(_ToData)
    End Sub
    ''' <summary>
    ''' 閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MenuFormClose.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' フィールド上へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnFieldToUp_Click(sender As Object, e As EventArgs) Handles BtnFieldToUp.Click
        If Not _IsStart Then
            _IsStart = True : _NoDraw = True

            If _SelectFieldIndex > -1 AndAlso _SelectFieldIndex > 0 Then
                Call FieldDataSwap(_SelectFieldIndex, _SelectFieldIndex - 1)
                Call RSetFieldName() 'フィールド名
                With ListBox1
                    .Items.Clear()
                    .DisplayMember = "Value"
                    .ValueMember = "Key"
                    For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
                        If FD.IsSystem = False Then
                            .Items.Add(New DictionaryEntry(FD.Name, FD.Text))
                        End If
                    Next
                    .SelectedIndex = _SelectFieldIndex - 1
                    _SelectFieldIndex = _SelectFieldIndex - 1
                End With

                Dim Item As DictionaryEntry = ListBox1.Items(_SelectFieldIndex) ' ListBox1.SelectedItem
                LblSelFieldName.Text = Item.Key
                Call GetFieldData()
                Call ScreenWork()
            End If
            _IsStart = False : _NoDraw = False
            Call Calc()
        End If
    End Sub
    ''' <summary>
    ''' フィールド下へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnFieldToDown_Click(sender As Object, e As EventArgs) Handles BtnFieldToDown.Click
        If Not _IsStart Then
            _IsStart = True : _NoDraw = True

            If _SelectFieldIndex > -1 AndAlso _SelectFieldIndex < ListBox1.Items.Count - 1 Then
                Call FieldDataSwap(_SelectFieldIndex, _SelectFieldIndex + 1)
                Call RSetFieldName() 'フィールド名
                With ListBox1
                    .Items.Clear()
                    .DisplayMember = "Value"
                    .ValueMember = "Key"
                    For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
                        If FD.IsSystem = False Then
                            .Items.Add(New DictionaryEntry(FD.Name, FD.Text))
                        End If
                    Next
                    .SelectedIndex = _SelectFieldIndex + 1
                    _SelectFieldIndex = _SelectFieldIndex + 1
                End With

                Dim Item As DictionaryEntry = ListBox1.Items(_SelectFieldIndex) ' ListBox1.SelectedItem
                LblSelFieldName.Text = Item.Key
                Call GetFieldData()
                Call ScreenWork()
            End If
            _IsStart = False : _NoDraw = False
            Call Calc()
        End If
    End Sub
    ''' <summary>
    ''' フィールドデータコピー
    ''' </summary>
    ''' <param name="Index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FieldDataCopy(Index As Integer) As ClassFieldCollection
        Dim _ToS As New ClassStyleCollection
        Dim _FromS As ClassStyleCollection = _SelectPaper.Section.FieldData(Index).Style
        _ToS.ddo_char_set = _FromS.ddo_char_set
        _ToS.ddo_font_vertical = _FromS.ddo_font_vertical
        _ToS.ddo_shrink_to_fit = _FromS.ddo_shrink_to_fit
        _ToS.font_family = _FromS.font_family
        _ToS.font_size = _FromS.font_size
        _ToS.font_weight = _FromS.font_weight
        _ToS.text_align = _FromS.text_align
        _ToS.text_justify = _FromS.text_justify
        _ToS.vertical_align = _FromS.vertical_align
        _ToS.white_space = _FromS.white_space

        Dim _To As New ClassFieldCollection
        Dim _From As ClassFieldCollection = _SelectPaper.Section.FieldData(Index)
        _To.ARType = _From.ARType
        _To.BackColor = _From.BackColor
        _To.CanShrink = _From.CanShrink
        _To.DataField = _From.DataField
        _To.FieldType = _From.FieldType
        _To.FieldUseType = _From.FieldUseType
        _To.Height = _From.Height
        _To.IsSystem = _From.IsSystem
        _To.Left = _From.Left
        _To.LineColor = _From.LineColor
        _To.LineStyle = _From.LineStyle
        _To.MultiLine = _From.MultiLine
        _To.Name = _From.Name
        _To.RoundingRadius = _From.RoundingRadius
        _To.Style = _ToS
        _To.Text = _From.Text
        _To.Top = _From.Top
        _To.Visible = _From.Visible
        _To.Width = _From.Width
        _To.AddStr1 = _From.AddStr1
        _To.DisplayWidth = _From.DisplayWidth
        _To.LabelIsMask = _From.LabelIsMask
        _To.LabelText = _From.LabelText
        _To.Angle = _From.Angle
        _To.BarcodeCaption = _From.BarcodeCaption
        _To.ColorReverse = _From.ColorReverse
        _To.UseIME = _From.UseIME
        _To.AddString_Front = _From.AddString_Front
        _To.AddString_Back = _From.AddString_Back
        Return _To

    End Function
    ''' <summary>
    ''' フィールドデータスワップ
    ''' </summary>
    ''' <param name="Index1"></param>
    ''' <param name="Index2"></param>
    ''' <remarks></remarks>
    Private Sub FieldDataSwap(Index1 As Integer, Index2 As Integer)
        'データ待避
        Dim _MemStyle As New ClassStyleCollection
        Dim _Style1 As ClassStyleCollection = _SelectPaper.Section.FieldData(Index1 + 2).Style
        _MemStyle.ddo_char_set = _Style1.ddo_char_set
        _MemStyle.ddo_font_vertical = _Style1.ddo_font_vertical
        _MemStyle.ddo_shrink_to_fit = _Style1.ddo_shrink_to_fit
        _MemStyle.font_family = _Style1.font_family
        _MemStyle.font_size = _Style1.font_size
        _MemStyle.font_weight = _Style1.font_weight
        _MemStyle.text_align = _Style1.text_align
        _MemStyle.text_justify = _Style1.text_justify
        _MemStyle.vertical_align = _Style1.vertical_align
        _MemStyle.white_space = _Style1.white_space

        Dim _MemField As New ClassFieldCollection
        Dim _Field1 As ClassFieldCollection = _SelectPaper.Section.FieldData(Index1 + 2)
        _MemField.ARType = _Field1.ARType
        _MemField.BackColor = _Field1.BackColor
        _MemField.CanShrink = _Field1.CanShrink
        _MemField.DataField = _Field1.DataField
        _MemField.FieldType = _Field1.FieldType
        _MemField.FieldUseType = _Field1.FieldUseType
        _MemField.Height = _Field1.Height
        _MemField.IsSystem = _Field1.IsSystem
        _MemField.Left = _Field1.Left
        _MemField.LineColor = _Field1.LineColor
        _MemField.LineStyle = _Field1.LineStyle
        _MemField.MultiLine = _Field1.MultiLine
        _MemField.Name = _Field1.Name
        _MemField.RoundingRadius = _Field1.RoundingRadius
        _MemField.Style = _MemStyle
        _MemField.Text = _Field1.Text
        _MemField.Top = _Field1.Top
        _MemField.Visible = _Field1.Visible
        _MemField.Width = _Field1.Width
        _MemField.AddStr1 = _Field1.AddStr1
        _MemField.LabelIsMask = _Field1.LabelIsMask
        _MemField.LabelText = _Field1.LabelText
        _MemField.DisplayWidth = _Field1.DisplayWidth
        _MemField.Angle = _Field1.Angle
        _MemField.BarcodeCaption = _Field1.BarcodeCaption
        _MemField.ColorReverse = _Field1.ColorReverse
        _MemField.UseIME = _Field1.UseIME
        _MemField.AddString_Front = _Field1.AddString_Front
        _MemField.AddString_Back = _Field1.AddString_Back

        '２から１へコピー
        Dim _Style2 As ClassStyleCollection = _SelectPaper.Section.FieldData(Index2 + 2).Style
        _Style1.ddo_char_set = _Style2.ddo_char_set
        _Style1.ddo_font_vertical = _Style2.ddo_font_vertical
        _Style1.ddo_shrink_to_fit = _Style2.ddo_shrink_to_fit
        _Style1.font_family = _Style2.font_family
        _Style1.font_size = _Style2.font_size
        _Style1.font_weight = _Style2.font_weight
        _Style1.text_align = _Style2.text_align
        _Style1.text_justify = _Style2.text_justify
        _Style1.vertical_align = _Style2.vertical_align
        _Style1.white_space = _Style2.white_space

        Dim _Field2 As ClassFieldCollection = _SelectPaper.Section.FieldData(Index2 + 2)
        _Field1.ARType = _Field2.ARType
        _Field1.BackColor = _Field2.BackColor
        _Field1.CanShrink = _Field2.CanShrink
        _Field1.DataField = _Field2.DataField
        _Field1.FieldType = _Field2.FieldType
        _Field1.FieldUseType = _Field2.FieldUseType
        _Field1.Height = _Field2.Height
        _Field1.IsSystem = _Field2.IsSystem
        _Field1.Left = _Field2.Left
        _Field1.LineColor = _Field2.LineColor
        _Field1.LineStyle = _Field2.LineStyle
        _Field1.MultiLine = _Field2.MultiLine
        _Field1.Name = _Field2.Name
        _Field1.RoundingRadius = _Field2.RoundingRadius
        _Field1.Style = _Style1
        _Field1.Text = _Field2.Text
        _Field1.Top = _Field2.Top
        _Field1.Visible = _Field2.Visible
        _Field1.Width = _Field2.Width
        _Field1.AddStr1 = _Field2.AddStr1
        _Field1.LabelIsMask = _Field2.LabelIsMask
        _Field1.LabelText = _Field2.LabelText
        _Field1.DisplayWidth = _Field2.DisplayWidth
        _Field1.Angle = _Field2.Angle
        _Field1.BarcodeCaption = _Field2.BarcodeCaption
        _Field1.ColorReverse = _Field2.ColorReverse
        _Field1.UseIME = _Field2.UseIME
        _Field1.AddString_Front = _Field2.AddString_Front
        _Field1.AddString_Back = _Field2.AddString_Back

        '記憶から２へコピー
        _Style2.ddo_char_set = _MemStyle.ddo_char_set
        _Style2.ddo_font_vertical = _MemStyle.ddo_font_vertical
        _Style2.ddo_shrink_to_fit = _MemStyle.ddo_shrink_to_fit
        _Style2.font_family = _MemStyle.font_family
        _Style2.font_size = _MemStyle.font_size
        _Style2.font_weight = _MemStyle.font_weight
        _Style2.text_align = _MemStyle.text_align
        _Style2.text_justify = _MemStyle.text_justify
        _Style2.vertical_align = _MemStyle.vertical_align
        _Style2.white_space = _MemStyle.white_space

        _Field2.ARType = _MemField.ARType
        _Field2.BackColor = _MemField.BackColor
        _Field2.CanShrink = _MemField.CanShrink
        _Field2.DataField = _MemField.DataField
        _Field2.FieldType = _MemField.FieldType
        _Field2.FieldUseType = _MemField.FieldUseType
        _Field2.Height = _MemField.Height
        _Field2.IsSystem = _MemField.IsSystem
        _Field2.Left = _MemField.Left
        _Field2.LineColor = _MemField.LineColor
        _Field2.LineStyle = _MemField.LineStyle
        _Field2.MultiLine = _MemField.MultiLine
        _Field2.Name = _MemField.Name
        _Field2.RoundingRadius = _MemField.RoundingRadius
        _Field2.Style = _Style2
        _Field2.Text = _MemField.Text
        _Field2.Top = _MemField.Top
        _Field2.Visible = _MemField.Visible
        _Field2.Width = _MemField.Width
        _Field2.AddStr1 = _MemField.AddStr1
        _Field2.LabelIsMask = _MemField.LabelIsMask
        _Field2.LabelText = _MemField.LabelText
        _Field2.DisplayWidth = _MemField.DisplayWidth
        _Field2.Angle = _MemField.Angle
        _Field2.BarcodeCaption = _MemField.BarcodeCaption
        _Field2.ColorReverse = _MemField.ColorReverse
        _Field2.UseIME = _MemField.UseIME
        _Field2.AddString_Front = _MemField.AddString_Front
        _Field2.AddString_Back = _MemField.AddString_Back

    End Sub

    ''' <summary>
    ''' 自動計算
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim _SZ As String = LblFieldFontSize.Text
        If _SZ.IndexOf("pt") > -1 Then
            _SZ = _SZ.Replace("pt", "")
        End If

        Dim _W As Integer = IIf(ChkFieldMultiLine.Checked, 2, 1)
        Dim _SI As Integer = CDec(_SZ)
        Select Case _SI
            Case Is < 14
                TxtFieldHeight.Value = 4 * _W
            Case Is < 20
                TxtFieldHeight.Value = 6 * _W
            Case Else
                TxtFieldHeight.Value = 8 * _W
        End Select
    End Sub

    ''' <summary>
    ''' 属性選択時の表示切り替え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbType.SelectedIndexChanged
        Select Case CmbType.SelectedIndex
            Case 2 'LINE
                LblX1.Text = "始点X" : LblX2.Text = "終点X"
                LblY1.Text = "始点Y" : LblY2.Text = "終点Y"
                TxtFieldHeight.Minimum = -1000000

                GroupBox5.Visible = True
                GroupBox6.Visible = False
                GroupBox2.Visible = True : GroupBox7.Visible = False
                GroupBox8.Visible = False
                Button2.Visible = False
            Case 3 'BOX
                LblX1.Text = "Ｘ位置" : LblX2.Text = "幅"
                LblY1.Text = "Ｙ位置" : LblY2.Text = "高さ"
                TxtFieldHeight.Minimum = 0
                GroupBox5.Visible = True
                GroupBox6.Visible = False
                GroupBox2.Visible = True : GroupBox7.Visible = False
                GroupBox8.Visible = False
                Button2.Visible = False
            Case 4, 5 'Barcode
                Label16.Text = "サンプル文字"
                LblX1.Text = "Ｘ位置" : LblX2.Text = "幅"
                LblY1.Text = "Ｙ位置" : LblY2.Text = "高さ"
                TxtFieldHeight.Minimum = 0

                GroupBox5.Visible = True
                GroupBox6.Visible = True
                GroupBox2.Visible = False : GroupBox7.Visible = True
                GroupBox8.Visible = True
                Button2.Visible = False
                LblAngle.Visible = False : TxtAngle.Visible = False
                If CmbType.SelectedIndex = 4 Then 'CODE39
                    ChkBarCaption.Visible = True
                Else
                    ChkBarCaption.Visible = False
                End If
                ChkColorReverse.Visible = False
                ChkIME.Visible = False
                TxtAddString_Front.Visible = False : TxtAddString_Back.Visible = False
                LblAddString_Front.Visible = False : LblAddString_Back.Visible = False
            Case 6 'Memo
                Label16.Text = "サンプル文字"
                LblX1.Text = "Ｘ位置" : LblX2.Text = "幅"
                LblY1.Text = "Ｙ位置" : LblY2.Text = "高さ"
                TxtFieldHeight.Minimum = 0

                GroupBox5.Visible = False
                GroupBox6.Visible = False
                GroupBox2.Visible = False : GroupBox7.Visible = False
                GroupBox8.Visible = False
                Button2.Visible = False

            Case Else 'Field OR Label
                If CmbType.SelectedIndex = 1 Then
                    'Label16.Visible = True : TxtLabelText.Visible = True
                    Label16.Text = "ラベル文字"
                    LblFieldUseType.Visible = False : CmbFieldUseType.Visible = False
                    ChkIME.Visible = False
                    TxtAddString_Front.Visible = False : TxtAddString_Back.Visible = False
                    LblAddString_Front.Visible = False : LblAddString_Back.Visible = False
                Else
                    'Label16.Visible = False : TxtLabelText.Visible = False
                    Label16.Text = "サンプル文字"
                    LblFieldUseType.Visible = True : CmbFieldUseType.Visible = True
                    ChkIME.Visible = True
                    TxtAddString_Front.Visible = True : TxtAddString_Back.Visible = True
                    LblAddString_Front.Visible = True : LblAddString_Back.Visible = True
                End If
                LblX1.Text = "Ｘ位置" : LblX2.Text = "幅"
                LblY1.Text = "Ｙ位置" : LblY2.Text = "高さ"
                TxtFieldHeight.Minimum = 0

                GroupBox5.Visible = True
                GroupBox6.Visible = True
                GroupBox2.Visible = False : GroupBox7.Visible = True
                GroupBox8.Visible = True
                Button2.Visible = True
                'If CmbType.SelectedIndex = 5 Then
                '    TxtAngle.Enabled = False
                'Else
                '    TxtAngle.Enabled = True
                'End If
                LblAngle.Visible = True : TxtAngle.Visible = True
                ChkBarCaption.Visible = False
                ChkColorReverse.Visible = True

        End Select

        Call Calc()
    End Sub

    ''' <summary>
    ''' タックエクスポート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click

        If Not IsNothing(_SelectPaper) Then
            If MsgBox("選択タック情報をエクスポートしますか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                Dim _FileName As String = ""
                Using SFD As New SaveFileDialog
                    With SFD
                        .AddExtension = True
                        .CheckPathExists = True
                        .FileName = String.Format("{0}({1}_{2}).tdf", _SelectPaper.Text, _SelectPaper.Name, _SelectPaper.MakerName)
                        .DefaultExt = ".tdl"
                        .Filter = "タックデータファイル(*.tdf)|*.tdf|全てのファイル(*.*)|*.*"
                        .FilterIndex = 0
                        .RestoreDirectory = True
                        .Title = "エクスポート先"
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then
                            _FileName = .FileName
                        End If
                    End With
                End Using
                If _FileName <> "" Then
                    Dim _ExData As New List(Of ClassPaperCollection)
                    _ExData.Add(_SelectPaper)
                    Try
                        If Not String.IsNullOrEmpty(_FileName) Then
                            If System.IO.File.Exists(_FileName) Then System.IO.File.Delete(_FileName)

                            Dim LocalClass() As ClassPaperCollection = TryCast(_ExData.ToArray, ClassPaperCollection())

                            If Not LocalClass Is Nothing Then
                                Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(ClassPaperCollection()))
                                Using FS As New IO.FileStream(_FileName, IO.FileMode.Create)
                                    SRZ.Serialize(FS, LocalClass)
                                End Using
                            End If
                            MsgBox("エクスポート完了", 64, "情報")
                        End If
                    Catch ex As Exception
                        'MsgBox("エクスポート失敗", 48, "エラー")
                        'MsgBox(ex.Message)
                        MsgBox(ExMessCreater(GetStack(ex)), 48, "エクスポートエラー")
                    End Try
                End If
            End If
        End If

    End Sub
    ''' <summary>
    ''' タックインポート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        If MsgBox("タック情報をインポートしますか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            Dim _FileName As String = ""
            Using OFD As New OpenFileDialog
                With OFD
                    .AddExtension = True
                    .CheckFileExists = True
                    .CheckPathExists = True
                    .DefaultExt = ".tdf"
                    .Filter = "タックデータファイル(*.tdf)|*.tdf|全てのファイル(*.*)|*.*"
                    .FilterIndex = 0
                    .RestoreDirectory = True
                    .Title = "インポートファイル選択"
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        _FileName = .FileName
                    End If
                End With
            End Using
            If _FileName <> "" Then
                Try
                    If System.IO.File.Exists(_FileName) Then
                        Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(ClassPaperCollection()))
                        Using FS As New IO.FileStream(_FileName, IO.FileMode.Open)
                            Dim LocalClass() As ClassPaperCollection
                            LocalClass = SRZ.Deserialize(FS)

                            For Each LoopClass As ClassPaperCollection In LocalClass
                                PaperArray.Add(LoopClass)
                            Next
                        End Using

                        With CmbPaperArray
                            .Items.Clear()
                            If PaperArray.Count > 0 Then
                                For Each Item As ClassPaperCollection In PaperArray
                                    .Items.Add(Item.Text)
                                Next
                                _IsStart = True
                                If .Items.Count > 0 Then
                                    .SelectedIndex = .Items.Count - 1
                                    _SelectPaperIndex = .SelectedIndex
                                    _SelectPaper = Nothing
                                    _SelectPaper = PaperArray(_SelectPaperIndex)
                                    _SelectPaper.PaperID = CreateGUID()
                                End If

                                Call GetData()
                                _IsStart = False
                            End If
                        End With

                        MsgBox("インポート完了", 64, "情報")
                    Else
                        MsgBox("選択ファイルが見つかりません", 48, "エラー")
                    End If
                Catch ex As Exception
                    'MsgBox(ex.Message, 48, "エラー")
                    MsgBox(ExMessCreater(GetStack(ex)), 48, "インポートエラー")
                End Try
            End If
        End If
    End Sub
#Region "中央寄せ処理"
    ''' <summary>
    ''' 中央寄せ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkCenter_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCenter.CheckedChanged
        TxtFieldLeft.Enabled = Not ChkCenter.Checked
        If ChkCenter.Checked Then
            TxtFieldLeft.Value = (TxtSheetWidth.Value - TxtFieldWidth.Value) / 2
        End If
    End Sub
    Private Sub TxtFieldWidth_ValueChanged(sender As Object, e As EventArgs) Handles TxtFieldWidth.ValueChanged, TxtDisplayWidth.ValueChanged
        If ChkCenter.Checked Then
            TxtFieldLeft.Value = (TxtSheetWidth.Value - TxtFieldWidth.Value) / 2
        End If
    End Sub
    Private Sub TxtSheetWidth_ValueChanged(sender As Object, e As EventArgs) Handles TxtSheetWidth.ValueChanged
        If ChkCenter.Checked Then
            TxtFieldLeft.Value = (TxtSheetWidth.Value - TxtFieldWidth.Value) / 2
        End If
    End Sub
#End Region
    Dim _NowMouseMode As ContentAlignment = ContentAlignment.MiddleCenter
    ''' <summary>
    ''' フィールド名からフィールドを探す
    ''' </summary>
    ''' <param name="FildName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ScanField(FildName As String) As ClassFieldCollection
        Dim _Ret As ClassFieldCollection = Nothing
        If FildName <> "" Then
            For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
                If FD.Name = FildName Then
                    _Ret = FD
                    Exit For
                End If
            Next
        End If
        Return _Ret
    End Function
    ''' <summary>
    ''' マウスが特定のフィールドに乗っているか？
    ''' </summary>
    ''' <param name="Fld"></param>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function MouseOnField(Fld As ClassFieldCollection, x As Integer, y As Integer) As Boolean
        If Fld.Left < x AndAlso x < (Fld.Left + Fld.Width) Then
            If Fld.Top < y AndAlso y < (Fld.Top + Fld.Height) Then
                Return True
            End If
        End If
        Return False
    End Function
    ''' <summary>
    ''' マウスがフィールドのどの当たりを乗っているか？
    ''' </summary>
    ''' <param name="Fld"></param>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function MouseOnFieldStat(Fld As ClassFieldCollection, x As Integer, y As Integer) As ContentAlignment
        Const _Margin As Integer = 2

        Dim _PosiX As Integer = 0
        Dim _PosiY As Integer = 0

        If x - Fld.Left < _Margin Then
            _PosiX = -1
        ElseIf (Fld.Left + Fld.Width) - x < _Margin Then
            _PosiX = 1
        Else
            _PosiX = 0
        End If

        If y - Fld.Top < _Margin Then
            _PosiY = -1
        ElseIf (Fld.Top + Fld.Height) - y < _Margin Then
            _PosiY = 1
        Else
            _PosiY = 0
        End If

        Select Case _PosiX
            Case -1
                Select Case _PosiY
                    Case -1
                        Return ContentAlignment.TopLeft
                    Case 1
                        Return ContentAlignment.BottomLeft
                    Case Else
                        Return ContentAlignment.MiddleLeft
                End Select
            Case 1
                Select Case _PosiY
                    Case -1
                        Return ContentAlignment.TopRight
                    Case 1
                        Return ContentAlignment.BottomRight
                    Case Else
                        Return ContentAlignment.MiddleRight
                End Select
            Case Else
                Select Case _PosiY
                    Case -1
                        Return ContentAlignment.TopCenter
                    Case 1
                        Return ContentAlignment.BottomCenter
                    Case Else
                        Return ContentAlignment.MiddleCenter
                End Select
        End Select
    End Function


    ''' <summary>
    ''' マウスダウン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown

        Try
            If TabControl1.SelectedIndex = 0 Then
                TabControl1.SelectedIndex = 1
            End If
            If _SelectPaperIndex > -1 Then
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    If _AnchorChild.Count > 0 Then
                        CMP_Anchor.Visible = True
                    Else
                        CMP_Anchor.Visible = False
                    End If
                    ConMenuPaper.Show(PictureBox1, e.Location)

                Else
                    Dim sp As System.Drawing.Point = System.Windows.Forms.Cursor.Position
                    Dim cp As System.Drawing.Point = PictureBox1.PointToClient(sp)
                    Dim x As Integer = cp.X / _PreviewZoom
                    Dim y As Integer = cp.Y / _PreviewZoom

                    Dim _P As ClassPaperCollection = PaperArray(_SelectPaperIndex)

                    Dim _FieldName As String = ""

                    If _SelectFieldIndex > -1 Then 'すでに選択されているオブジェクトがあれば、それを優先
                        Dim Item As DictionaryEntry = ListBox1.Items(_SelectFieldIndex)
                        Dim FieldKey As String = Item.Key
                        Dim _LFD As ClassFieldCollection = ScanField(FieldKey)
                        If Not IsNothing(_LFD) AndAlso _LFD.IsSystem = False Then
                            If MouseOnField(_LFD, x, y) Then
                                _MoveShiftX = x - _LFD.Left
                                _MoveShiftY = y - _LFD.Top
                                _FieldName = _LFD.Name

                                If Not ChkItemLock.Checked Then 'マウス移動が禁止時はカーソルを変えない
                                    Select Case MouseOnFieldStat(_LFD, x, y)
                                        Case ContentAlignment.TopLeft
                                            Me.Cursor = Cursors.SizeNWSE
                                            _NowMouseMode = ContentAlignment.TopLeft
                                        Case ContentAlignment.TopRight
                                            Me.Cursor = Cursors.SizeNESW
                                            _NowMouseMode = ContentAlignment.TopRight
                                        Case ContentAlignment.TopCenter
                                            Me.Cursor = Cursors.SizeNS
                                            _NowMouseMode = ContentAlignment.TopCenter

                                        Case ContentAlignment.BottomLeft
                                            Me.Cursor = Cursors.SizeNESW
                                            _NowMouseMode = ContentAlignment.BottomLeft
                                        Case ContentAlignment.BottomRight
                                            Me.Cursor = Cursors.SizeNWSE
                                            _NowMouseMode = ContentAlignment.BottomRight
                                        Case ContentAlignment.BottomCenter
                                            Me.Cursor = Cursors.SizeNS
                                            _NowMouseMode = ContentAlignment.BottomCenter

                                        Case ContentAlignment.MiddleLeft
                                            Me.Cursor = Cursors.SizeWE
                                            _NowMouseMode = ContentAlignment.MiddleLeft
                                        Case ContentAlignment.MiddleRight
                                            Me.Cursor = Cursors.SizeWE
                                            _NowMouseMode = ContentAlignment.MiddleRight
                                        Case ContentAlignment.MiddleCenter
                                            Me.Cursor = Cursors.SizeAll
                                            _NowMouseMode = ContentAlignment.MiddleCenter

                                    End Select

                                End If
                            End If
                        End If
                    End If

                    If _FieldName = "" Then
                        For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
                            If FD.IsSystem = False Then
                                If MouseOnField(FD, x, y) Then
                                    _MoveShiftX = x - FD.Left
                                    _MoveShiftY = y - FD.Top
                                    _FieldName = FD.Name

                                    If Not ChkItemLock.Checked Then 'マウス移動が禁止時はカーソルを変えない
                                        Select Case MouseOnFieldStat(FD, x, y)
                                            Case ContentAlignment.TopLeft
                                                Me.Cursor = Cursors.SizeNWSE
                                                _NowMouseMode = ContentAlignment.TopLeft
                                            Case ContentAlignment.TopRight
                                                Me.Cursor = Cursors.SizeNESW
                                                _NowMouseMode = ContentAlignment.TopRight
                                            Case ContentAlignment.TopCenter
                                                Me.Cursor = Cursors.SizeNS
                                                _NowMouseMode = ContentAlignment.TopCenter

                                            Case ContentAlignment.BottomLeft
                                                Me.Cursor = Cursors.SizeNESW
                                                _NowMouseMode = ContentAlignment.BottomLeft
                                            Case ContentAlignment.BottomRight
                                                Me.Cursor = Cursors.SizeNWSE
                                                _NowMouseMode = ContentAlignment.BottomRight
                                            Case ContentAlignment.BottomCenter
                                                Me.Cursor = Cursors.SizeNS
                                                _NowMouseMode = ContentAlignment.BottomCenter

                                            Case ContentAlignment.MiddleLeft
                                                Me.Cursor = Cursors.SizeWE
                                                _NowMouseMode = ContentAlignment.MiddleLeft
                                            Case ContentAlignment.MiddleRight
                                                Me.Cursor = Cursors.SizeWE
                                                _NowMouseMode = ContentAlignment.MiddleRight
                                            Case ContentAlignment.MiddleCenter
                                                Me.Cursor = Cursors.SizeAll
                                                _NowMouseMode = ContentAlignment.MiddleCenter

                                        End Select
                                        Exit For
                                    End If

                                End If
                            End If
                        Next
                    End If

                    If _FieldName <> "" Then
                        With ListBox1
                            If .Items.Count > 0 Then
                                For i As Integer = 0 To .Items.Count - 1
                                    Dim Item As DictionaryEntry = ListBox1.Items(i) ' ListBox1.SelectedItem
                                    If _FieldName = Item.Key Then
                                        .SelectedIndex = i

                                        Exit For
                                    End If
                                Next
                            End If
                        End With

                    Else
                        ListBox1.SelectedIndex = -1
                    End If

                End If

            End If
        Catch ex As Exception

        End Try

    End Sub
    'ドラッグ時のマウスとオブジェクトの位置差
    Dim _MoveShiftX As Integer = 0
    Dim _MoveShiftY As Integer = 0
#Region "フィールド位置セット"

    Private Sub Set_FieldLeft(Value As Decimal)
        If Value < 0 Then
            TxtFieldLeft.Value = 1
        Else
            TxtFieldLeft.Value = Value
        End If
    End Sub
    Private Sub Set_FieldWidth(Value As Decimal)
        If Value < _Limit Then
            TxtFieldWidth.Value = _Limit
        Else
            TxtFieldWidth.Value = Value
        End If
    End Sub
    Private Sub Set_FieldTop(Value As Decimal)
        If Value < 0 Then
            TxtFieldTop.Value = 0
        Else
            TxtFieldTop.Value = Value
        End If
    End Sub
    Private Sub Set_FieldHeight(Value As Decimal)
        If Value < _Limit Then
            TxtFieldHeight.Value = _Limit
        Else
            TxtFieldHeight.Value = Value
        End If
    End Sub
    Const _Limit As Integer = 5
#End Region

    ''' <summary>
    ''' マウスムーブ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        'Dim _ZM As Integer = 4
        Try
            If _SelectPaperIndex > -1 Then
                If Not ChkItemLock.Checked Then
                    If e.Button = Windows.Forms.MouseButtons.Left Then
                        'マウスが押されているとき
                        If _SelectFieldIndex > -1 Then

                            Dim _X As Integer = e.X / _PreviewZoom
                            Dim _Y As Integer = e.Y / _PreviewZoom
                            Dim _W As Decimal = TxtFieldWidth.Value + TxtFieldLeft.Value
                            Dim _H As Decimal = TxtFieldHeight.Value + TxtFieldTop.Value
                            Select Case _NowMouseMode
                                Case ContentAlignment.TopLeft
                                    Call Set_FieldLeft(_X)
                                    Call Set_FieldWidth(_W - _X)
                                    Call Set_FieldTop(_Y)
                                    Call Set_FieldHeight(_H - _Y)
                                Case ContentAlignment.TopRight
                                    Call Set_FieldTop(_Y)
                                    Call Set_FieldHeight(_H - _Y)
                                    Call Set_FieldWidth(_X - TxtFieldLeft.Value)
                                Case ContentAlignment.TopCenter
                                    Call Set_FieldTop(_Y)
                                    Call Set_FieldHeight(_H - _Y)
                                Case ContentAlignment.BottomLeft
                                    Call Set_FieldLeft(_X)
                                    Call Set_FieldWidth(_W - _X)
                                    Call Set_FieldHeight(_Y - TxtFieldTop.Value)
                                Case ContentAlignment.BottomRight
                                    Call Set_FieldWidth(_X - TxtFieldLeft.Value)
                                    Call Set_FieldHeight(_Y - TxtFieldTop.Value)
                                Case ContentAlignment.BottomCenter
                                    Call Set_FieldHeight(_Y - TxtFieldTop.Value)
                                Case ContentAlignment.MiddleLeft
                                    Call Set_FieldLeft(_X)
                                    Call Set_FieldWidth(_W - _X)
                                Case ContentAlignment.MiddleRight
                                    Call Set_FieldWidth(_X - TxtFieldLeft.Value)
                                Case ContentAlignment.MiddleCenter
                                    If Not ChkCenter.Checked Then
                                        Call Set_FieldLeft(_X - _MoveShiftX)
                                    Else
                                        Call Set_FieldLeft((TxtSheetWidth.Value - TxtFieldWidth.Value) / 2)
                                    End If
                                    Call Set_FieldTop(_Y - _MoveShiftY)

                            End Select
                        End If
                    Else
                        'マウスが押されていないとき
                        Dim sp As System.Drawing.Point = System.Windows.Forms.Cursor.Position
                        Dim cp As System.Drawing.Point = PictureBox1.PointToClient(sp)
                        Dim x As Integer = cp.X / _PreviewZoom
                        Dim y As Integer = cp.Y / _PreviewZoom
                        For Each FD As ClassFieldCollection In _SelectPaper.Section.FieldData
                            If FD.IsSystem = False Then
                                If MouseOnField(FD, x, y) Then
                                    Select Case MouseOnFieldStat(FD, x, y)
                                        Case ContentAlignment.TopLeft
                                            Me.Cursor = Cursors.SizeNWSE
                                            Return
                                        Case ContentAlignment.TopRight
                                            Me.Cursor = Cursors.SizeNESW
                                            Return
                                        Case ContentAlignment.TopCenter
                                            Me.Cursor = Cursors.SizeNS
                                            Return

                                        Case ContentAlignment.BottomLeft
                                            Me.Cursor = Cursors.SizeNESW
                                            Return
                                        Case ContentAlignment.BottomRight
                                            Me.Cursor = Cursors.SizeNWSE
                                            Return
                                        Case ContentAlignment.BottomCenter
                                            Me.Cursor = Cursors.SizeNS
                                            Return

                                        Case ContentAlignment.MiddleLeft
                                            Me.Cursor = Cursors.SizeWE
                                            Return
                                        Case ContentAlignment.MiddleRight
                                            Me.Cursor = Cursors.SizeWE
                                            Return
                                        Case ContentAlignment.MiddleCenter
                                            Me.Cursor = Cursors.SizeAll
                                            Return

                                    End Select
                                End If
                            End If
                        Next
                        Me.Cursor = Cursors.Default
                    End If
                End If
              
            End If
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' マウスアップ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        Me.Cursor = Cursors.Default
        _NowMouseMode = Nothing
    End Sub
    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        Me.Cursor = Cursors.Default
        _NowMouseMode = Nothing
    End Sub
    ''' <summary>
    ''' 使用フィールドにより変更する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbFieldUseType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFieldUseType.SelectedIndexChanged
        If CmbFieldUseType.SelectedIndex = 1 Then
            ChkAddStr1.Visible = True
            ChkLabelIsMask.Visible = False
            ChkIME.Visible = False
        Else
            ChkAddStr1.Visible = False
            ChkLabelIsMask.Visible = True
            ChkIME.Visible = True
        End If

        If CmbFieldUseType.SelectedIndex = 0 Then
            TxtAddString_Front.Visible = True
            TxtAddString_Back.Visible = True
            LblAddString_Front.Visible = True
            LblAddString_Back.Visible = True
        Else
            TxtAddString_Front.Visible = False
            TxtAddString_Back.Visible = False
            LblAddString_Front.Visible = False
            LblAddString_Back.Visible = False
        End If
    End Sub
    ''' <summary>
    ''' 新規フィールドの作成（コンメニュー）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_AddField_Click(sender As Object, e As EventArgs) Handles CMP_AddField.Click
        Call BtnAddField.PerformClick()
    End Sub
    ''' <summary>
    ''' コンメニュー表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ConMenuPaper_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ConMenuPaper.Opening
        If ListBox1.SelectedIndex = -1 Then
            CMP_DelField.Enabled = False
            CMP_CopyField.Enabled = False
        Else
            CMP_DelField.Enabled = True
            CMP_CopyField.Enabled = True
        End If
    End Sub
    ''' <summary>
    ''' 選択フィールドの削除（コンメニュー）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_DelField_Click(sender As Object, e As EventArgs) Handles CMP_DelField.Click
        Call BtnDelField.PerformClick()
    End Sub
    ''' <summary>
    ''' 絶対寸法の入力（高さ）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblY2_Click(sender As Object, e As EventArgs) Handles LblY2.Click
        With FrmPosition2
            .Mode = 1
            .HeadStr = "下位置(Y2)"
            .Posi2Value = TxtFieldTop.Value + TxtFieldHeight.Value
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                TxtFieldHeight.Value = .Posi2Value - TxtFieldTop.Value
            End If
        End With
    End Sub
    ''' <summary>
    ''' 絶対寸法の入力（幅）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblX2_Click(sender As Object, e As EventArgs) Handles LblX2.Click
        With FrmPosition2
            .Mode = 0
            .HeadStr = "右位置(X2)"
            .Posi2Value = TxtFieldLeft.Value + TxtFieldWidth.Value
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                TxtFieldWidth.Value = .Posi2Value - TxtFieldLeft.Value
            End If
        End With
    End Sub
    ''' <summary>
    ''' 画像選択ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSelectPicture_Click(sender As Object, e As EventArgs) Handles BtnSelectPicture.Click
        Dim _Fl As String = ""
        Using OFD As New OpenFileDialog
            With OFD
                .CheckFileExists = True
                .CheckPathExists = True
                .Multiselect = False
                .Filter = "画像ファイル|*.bmp;*.png;*.jpg|全てのファイル(*.*)|*.*"
                .FilterIndex = 0
                .RestoreDirectory = True
                .Title = "表示画像ファイル選択"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    _Fl = .FileName
                    ChkGroundPicture.Checked = True
                End If
            End With
        End Using
        If _Fl <> "" Then
            TxtGroundPicture.Text = _Fl
            Call Calc()
            Call ScreenWork()
        End If
    End Sub

    Private Sub ChkLabelIsMask_CheckedChanged(sender As Object, e As EventArgs) Handles ChkLabelIsMask.CheckedChanged
        If ChkLabelIsMask.Checked Then
            Label16.Text = "マスク文字"
        Else
            Label16.Text = "ラベル文字"
        End If
    End Sub

    Private Sub TxtFieldHeight_ValueChanged(sender As Object, e As EventArgs) Handles TxtFieldHeight.ValueChanged, TxtAngle.ValueChanged
        ChkFieldddo_shrink_to_fit.Enabled = (TxtAngle.Value = 0)
    End Sub

    Private Sub MenuZoom0_Click(sender As Object, e As EventArgs) Handles MenuZoom0.Click
        Call ZoomUnCheck()
        MenuZoom0.Checked = True
        _PreviewZoom = 4
        Call Calc()
    End Sub

    Private Sub MenuZoom1_Click(sender As Object, e As EventArgs) Handles MenuZoom1.Click
        Call ZoomUnCheck()
        MenuZoom1.Checked = True
        _PreviewZoom = 5
        Call Calc()
    End Sub

    Private Sub MenuZoom2_Click(sender As Object, e As EventArgs) Handles MenuZoom2.Click
        Call ZoomUnCheck()
        MenuZoom2.Checked = True
        _PreviewZoom = 6
        Call Calc()
    End Sub
    Private Sub ZoomUnCheck()
        MenuZoom0.Checked = False
        MenuZoom1.Checked = False
        MenuZoom2.Checked = False
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        'PictureBox以外で右クリックするとメニューが表示する様にする
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim Flg As Boolean = False
            Select Case True
                Case e.X < PictureBox1.Left : Flg = True
                Case e.X > PictureBox1.Left + PictureBox1.Width : Flg = True
                Case e.Y < PictureBox1.Top : Flg = True
                Case e.Y > PictureBox1.Top + PictureBox1.Height : Flg = True
            End Select
            If Flg Then
                ContextMenuStrip1.Show(Panel1, e.Location)
            End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
      
    End Sub
#Region "整列関係"
    ''' <summary>
    ''' 左寄せ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_Anchor_Left_Click(sender As Object, e As EventArgs) Handles CMP_Anchor_Left.Click
        Call AlignPosi(AlignMode1.IsLeft)
    End Sub
    ''' <summary>
    ''' 右寄せ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_Anchor_Right_Click(sender As Object, e As EventArgs) Handles CMP_Anchor_Right.Click
        Call AlignPosi(AlignMode1.IsRight)
    End Sub
    ''' <summary>
    ''' 上寄せ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_Anchor_Top_Click(sender As Object, e As EventArgs) Handles CMP_Anchor_Top.Click
        Call AlignPosi(AlignMode1.IsTop)
    End Sub
    ''' <summary>
    ''' 下寄せ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_Anchor_Bottom_Click(sender As Object, e As EventArgs) Handles CMP_Anchor_Bottom.Click
        Call AlignPosi(AlignMode1.IsBottom)
    End Sub
    ''' <summary>
    ''' 揃えモード１
    ''' </summary>
    ''' <remarks></remarks>
    Enum AlignMode1
        IsLeft
        IsRight
        IsTop
        IsBottom
    End Enum
    ''' <summary>
    ''' 位置合わせ
    ''' </summary>
    ''' <param name="Mode"></param>
    ''' <remarks></remarks>
    Private Sub AlignPosi(Mode As AlignMode1)
        Dim MValue As Decimal = -1

        For i As Integer = 0 To _SelectPaper.Section.FieldData.Count - 1
            If _SelectPaper.Section.FieldData(i).Name = _AnchorMaster Then
                Select Case Mode
                    Case AlignMode1.IsLeft : MValue = _SelectPaper.Section.FieldData(i).Left
                    Case AlignMode1.IsRight : MValue = _SelectPaper.Section.FieldData(i).Left + _SelectPaper.Section.FieldData(i).Width
                    Case AlignMode1.IsTop : MValue = _SelectPaper.Section.FieldData(i).Top
                    Case AlignMode1.IsBottom : MValue = _SelectPaper.Section.FieldData(i).Top + _SelectPaper.Section.FieldData(i).Height
                End Select
                Exit For
            End If
        Next
        If MValue > -1 Then
            Try
                For Each FD As String In _AnchorChild
                    For i As Integer = 0 To _SelectPaper.Section.FieldData.Count - 1
                        If _SelectPaper.Section.FieldData(i).Name = FD Then
                            Select Case Mode
                                Case AlignMode1.IsLeft : _SelectPaper.Section.FieldData(i).Left = MValue
                                Case AlignMode1.IsRight : _SelectPaper.Section.FieldData(i).Left = MValue - _SelectPaper.Section.FieldData(i).Width
                                Case AlignMode1.IsTop : _SelectPaper.Section.FieldData(i).Top = MValue
                                Case AlignMode1.IsBottom : _SelectPaper.Section.FieldData(i).Top = MValue - _SelectPaper.Section.FieldData(i).Height
                            End Select

                            '現在表示されているフィールド情報も更新する
                            If LblSelFieldName.Text = _SelectPaper.Section.FieldData(i).Name Then
                                TxtFieldLeft.Value = _SelectPaper.Section.FieldData(i).Left
                                TxtFieldTop.Value = _SelectPaper.Section.FieldData(i).Top
                            End If
                        End If
                    Next
                Next
            Catch ex As Exception

            End Try
        End If
        Call Calc()
    End Sub
    ''' <summary>
    ''' 幅揃え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_Anchor_Width_Click(sender As Object, e As EventArgs) Handles CMP_Anchor_Width.Click
        Call AlignSize(AlignMode2.IsWidth)
    End Sub
    ''' <summary>
    ''' 高さ揃え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_Anchor_Height_Click(sender As Object, e As EventArgs) Handles CMP_Anchor_Height.Click
        Call AlignSize(AlignMode2.IsHeight)
    End Sub
    ''' <summary>
    ''' 両方
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMP_Anchor_Both_Click(sender As Object, e As EventArgs) Handles CMP_Anchor_Both.Click
        Call AlignSize(AlignMode2.IsBoth)
    End Sub
    ''' <summary>
    ''' フォントを揃える
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAlgnFont_Font_Click(sender As Object, e As EventArgs) Handles MenuAlgnFont_Font.Click
        Dim MFont As String = ""

        For i As Integer = 0 To _SelectPaper.Section.FieldData.Count - 1
            If _SelectPaper.Section.FieldData(i).Name = _AnchorMaster Then
                MFont = _SelectPaper.Section.FieldData(i).Style.font_family
                Exit For
            End If
        Next
        If MFont <> "" Then
            If MsgBox("文字フォントを揃えてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                Try
                    For Each FD As String In _AnchorChild
                        For i As Integer = 0 To _SelectPaper.Section.FieldData.Count - 1
                            If _SelectPaper.Section.FieldData(i).Name = FD Then
                                _SelectPaper.Section.FieldData(i).Style.font_family = MFont

                                '現在表示されているフィールド情報も更新する
                                If LblSelFieldName.Text = _SelectPaper.Section.FieldData(i).Name Then
                                    LblFieldFontName.Text = _SelectPaper.Section.FieldData(i).Style.font_family
                                End If
                            End If
                        Next
                    Next
                Catch ex As Exception

                End Try
         
            End If
        End If
        Call Calc()
    End Sub
    ''' <summary>
    ''' 文字サイズを揃える
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAlgnFont_Size_Click(sender As Object, e As EventArgs) Handles MenuAlgnFont_Size.Click
        Dim MFont As String = ""

        For i As Integer = 0 To _SelectPaper.Section.FieldData.Count - 1
            If _SelectPaper.Section.FieldData(i).Name = _AnchorMaster Then
                MFont = _SelectPaper.Section.FieldData(i).Style.font_size
                Exit For
            End If
        Next
        If MFont <> "" Then
            If MsgBox("文字サイズを揃えてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                Try
                    For Each FD As String In _AnchorChild
                        For i As Integer = 0 To _SelectPaper.Section.FieldData.Count - 1
                            If _SelectPaper.Section.FieldData(i).Name = FD Then
                                _SelectPaper.Section.FieldData(i).Style.font_size = MFont

                                '現在表示されているフィールド情報も更新する
                                If LblSelFieldName.Text = _SelectPaper.Section.FieldData(i).Name Then
                                    LblFieldFontSize.Text = _SelectPaper.Section.FieldData(i).Style.font_size
                                End If
                            End If
                        Next
                    Next
                Catch ex As Exception

                End Try
          
            End If
        End If
        Call Calc()
    End Sub
    ''' <summary>
    ''' 揃えモード２
    ''' </summary>
    ''' <remarks></remarks>
    Enum AlignMode2
        IsWidth
        IsHeight
        IsBoth
    End Enum
    ''' <summary>
    ''' サイズ揃え
    ''' </summary>
    ''' <param name="Mode"></param>
    ''' <remarks></remarks>
    Private Sub AlignSize(Mode As AlignMode2)
        Dim MValueW As Decimal = -1
        Dim MValueH As Decimal = -1

        For i As Integer = 0 To _SelectPaper.Section.FieldData.Count - 1
            If _SelectPaper.Section.FieldData(i).Name = _AnchorMaster Then
                MValueW = _SelectPaper.Section.FieldData(i).Width
                MValueH = _SelectPaper.Section.FieldData(i).Height
                Exit For
            End If
        Next
        If MValueW > -1 OrElse MValueH > -1 Then
            Try
                For Each FD As String In _AnchorChild
                    For i As Integer = 0 To _SelectPaper.Section.FieldData.Count - 1
                        If _SelectPaper.Section.FieldData(i).Name = FD Then
                            Select Case Mode
                                Case AlignMode2.IsWidth
                                    _SelectPaper.Section.FieldData(i).Width = MValueW
                                Case AlignMode2.IsHeight
                                    _SelectPaper.Section.FieldData(i).Height = MValueH
                                Case AlignMode2.IsBoth
                                    _SelectPaper.Section.FieldData(i).Width = MValueW
                                    _SelectPaper.Section.FieldData(i).Height = MValueH
                            End Select

                            '現在表示されているフィールド情報も更新する
                            If LblSelFieldName.Text = _SelectPaper.Section.FieldData(i).Name Then
                                TxtFieldWidth.Value = _SelectPaper.Section.FieldData(i).Width
                                TxtFieldHeight.Value = _SelectPaper.Section.FieldData(i).Height
                            End If
                        End If
                    Next
                Next

            Catch ex As Exception

            End Try
        End If
        Call Calc()
    End Sub
#End Region

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

  
End Class