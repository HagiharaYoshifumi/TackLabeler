'【マスタフォームの作り方】
'①普通にレポートを完成させる
'②［レポート］の［レイアウトファイルの保存］を選択してrpxファイルを保存する
'③実行ファイルフォルダの［FormData］の作成したrpxファイルを移動する
'④実行ファイルフォルダの［FormData］のPaperFormatList.xmlに新しいデータを追記してPaperFileNameにファイル名を記載する
'⑤後は実行の時に読み出してくれる
'INDEXはあまり左右されないはず
Public Class FrmMain
    Dim _IsEdit As Boolean = False
    Dim _Starting As Boolean = True
    Dim Sql As String = ""
    Dim TabSelectedIndex As Integer = -1 '選択タブインデックス
    Dim PaperSelectedIndex As Integer = -1 '選択タブインデックス

    Dim _NoSave As Boolean = False
    Dim _NoLoad As Boolean = False

    Dim _NumberString As String = "{NO}"
    Dim _NumberStartNo As Integer '連番開始番号
    Dim _NumberFrontZero As Integer '連番前ゼロ桁数（0:前ゼロなし）
    Dim _NumberTackGoto As Boolean 'True:シールごとの採番
    ''' <summary>
    ''' タブ情報読込
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadTab()
        Try
            GcTabControl1.TabPages.Clear()
            Sql = "SELECT * FROM TabData ORDER BY IndexNo"
            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                Using DR As OleDb.OleDbDataReader = CMD.ExecuteReader
                    Do While DR.Read
                        Dim Index As Integer = FG(DR("IndexNo"), enum_FG.FG_Numeric)
                        Dim Txt As String = FG(DR("TabName"))
                        Dim PN As Integer = FG(DR("UsePaperIndex"), enum_FG.FG_Numeric)
                        Dim LT As String = FG(DR("LabelText"))
                        Dim MR As String = FG(DR("MR"))
                        Dim _T As New LocalTabCollection
                        _T.Index = Index
                        _T.UsePaperIndex = PN
                        _T.LabelText = LT
                        _T.MR = MR

                        'Dim TB As New System.Windows.Forms.TabPage
                        Dim TB As New GrapeCity.Win.Containers.GcTabPage
                        TB.Text = Txt
                        TB.Tag = _T
                        GcTabControl1.TabPages.Add(TB)
                    Loop
                End Using
            End Using

            If GcTabControl1.TabPages.Count = 0 Then
                Call ZeroTab()
            End If
            GcTabControl1.SelectedIndex = 0
            TabSelectedIndex = 0
            Call LoadTabData()

        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "タブデータ読出エラー")
        End Try
    End Sub
    ''' <summary>
    ''' タブデータ更新
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateTabData()
        Try
            Dim TD As LocalTabCollection = GcTabControl1.TabPages(TabSelectedIndex).Tag
            Dim No As Integer = TD.Index
            Sql = "UPDATE TabData SET TabName=@TabName,UsePaperIndex=@UsePaperIndex,LabelText=@LabelText,MR=@MR WHERE IndexNo=@IndexNo"
            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                CMD.Parameters.Add(New OleDb.OleDbParameter("@TabName", OleDb.OleDbType.Char))
                CMD.Parameters.Add(New OleDb.OleDbParameter("@UsePaperIndex", OleDb.OleDbType.Integer))
                CMD.Parameters.Add(New OleDb.OleDbParameter("@LabelText", OleDb.OleDbType.Char))
                CMD.Parameters.Add(New OleDb.OleDbParameter("@MR", OleDb.OleDbType.Char))
                CMD.Parameters.Add(New OleDb.OleDbParameter("@IndexNo", OleDb.OleDbType.Integer))
                CMD.Parameters("@TabName").Value = GcTabControl1.TabPages(TabSelectedIndex).Text
                CMD.Parameters("@UsePaperIndex").Value = TD.UsePaperIndex
                CMD.Parameters("@LabelText").Value = TxtNote.Text
                CMD.Parameters("@MR").Value = CmbBackText.Text
                CMD.Parameters("@IndexNo").Value = No
                CMD.ExecuteNonQuery()
            End Using

            'TD.UsePaperIndex = CmbFormatPaper.SelectedIndex
            'TabControl1.TabPages(TabSelectedIndex).Tag = TD
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "タブデータ更新エラー")
        End Try
    End Sub
    ''' <summary>
    ''' タブなし時に空タブを追加する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ZeroTab()
        Try
            Sql = "INSERT INTO TabData(IndexNo,TabName,UsePaperIndex) VALUES (@IndexNo,@TabName,@UsePaperIndex)"
            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                CMD.Parameters.Add(New OleDb.OleDbParameter("@IndexNo", OleDb.OleDbType.Integer))
                CMD.Parameters.Add(New OleDb.OleDbParameter("@TabName", OleDb.OleDbType.Char))
                CMD.Parameters.Add(New OleDb.OleDbParameter("@UsePaperIndex", OleDb.OleDbType.Integer))
                CMD.Parameters("@IndexNo").Value = 0
                CMD.Parameters("@TabName").Value = "新しいタブ"
                CMD.Parameters("@UsePaperIndex").Value = 0
                CMD.ExecuteNonQuery()
            End Using
            Dim TB As New GrapeCity.Win.Containers.GcTabPage

            Dim _T As New LocalTabCollection
            _T.Index = 0
            _T.UsePaperIndex = 0
            TB.Text = "新しいタブ"
            TB.Tag = _T
            GcTabControl1.TabPages.Add(TB)
            _IsEdit = True
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "新規タブ作成エラー")
        End Try
    End Sub
    ''' <summary>
    ''' TODO:データ書込
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveTab()
        If TabSelectedIndex > -1 AndAlso GcTabControl1.TabPages.Count > 0 Then
            Try
                Dim No As Integer = DirectCast(GcTabControl1.TabPages(TabSelectedIndex).Tag, LocalTabCollection).Index
                Call UpdateTabData()

                Sql = String.Format("DELETE FROM AddressData WHERE TabIndexNo={0}", No)
                Using CMD As New OleDb.OleDbCommand(Sql, CN)
                    CMD.ExecuteNonQuery()
                End Using
                With SS.ActiveSheet
                    If .RowCount > 0 Then
                        Sql = "INSERT INTO AddressData(TabIndexNo,RowNo,Field1,Field2,Field3,Field4,Field5,Field6,Field7,Field8,Field9,Field10,Field11,Field12,Field13,Field14,Field15,Field16,Field17,Field18,Field19,Field20) VALUES (@TabIndexNo,@RowNo,@Field1,@Field2,@Field3,@Field4,@Field5,@Field6,@Field7,@Field8,@Field9,@Field10,@Field11,@Field12,@Field13,@Field14,@Field15,@Field16,@Field17,@Field18,@Field19,@Field20)"
                        Using CMD As New OleDb.OleDbCommand(Sql, CN)
                            CMD.Parameters.Add(New OleDb.OleDbParameter("@TabIndexNo", OleDb.OleDbType.Integer))
                            CMD.Parameters.Add(New OleDb.OleDbParameter("@RowNo", OleDb.OleDbType.Integer))
                            For i As Integer = 1 To 20
                                CMD.Parameters.Add(New OleDb.OleDbParameter("@Field" & i.ToString, OleDb.OleDbType.Char))
                            Next

                            For Row As Integer = 0 To .RowCount - 1
                                CMD.Parameters("@TabIndexNo").Value = No
                                CMD.Parameters("@RowNo").Value = Row
                                For i As Integer = 1 To 20
                                    CMD.Parameters("@Field" & i.ToString).Value = FG(.Cells(Row, i).Value)
                                Next
                                CMD.ExecuteNonQuery()
                            Next
                        End Using
                    End If
                End With
            Catch ex As Exception
                MsgBox(ExMessCreater(GetStack(ex)), 48, "データ保存エラー")
            End Try
        End If
    End Sub
    Dim _DataLoding As Boolean = False
    ''' <summary>
    ''' TODO:データ読込
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadTabData()

        If TabSelectedIndex > -1 Then
            _DataLoding = True
            Call SPREAD_ResetSortIndicator(SS)
            SS.SuspendLayout()
            Try
                SS.ActiveSheet.RowCount = 0
                Call SSColSetting()

                Dim _TabTag As LocalTabCollection = GcTabControl1.TabPages(TabSelectedIndex).Tag
                Dim No As Integer = _TabTag.Index
                Dim PIndex As Integer = _TabTag.UsePaperIndex

                Sql = String.Format("SELECT * FROM TabData WHERE IndexNo={0}", TabSelectedIndex)
                Using CMD As New OleDb.OleDbCommand(Sql, CN)
                    Using DR As OleDb.OleDbDataReader = CMD.ExecuteReader
                        Do While DR.Read
                            TxtNote.Text = FG(DR("LabelText"))
                            CmbBackText.Text = FG(DR("MR"))
                        Loop
                    End Using
                End Using

                Dim _P As ClassPaperCollection = PaperArray(PIndex)
                Call StatPaperInfoSet(_P) '用紙情報表示更新
                With SS.ActiveSheet
                    .RowCount = 0
                    Sql = String.Format("SELECT * FROM AddressData WHERE TabIndexNo={0} ORDER BY RowNo", No)
                    Using CMD As New OleDb.OleDbCommand(Sql, CN)
                        Using DR As OleDb.OleDbDataReader = CMD.ExecuteReader
                            Do While DR.Read
                                Dim Row As Integer = SPREAD_InsertRow(SS)
                                For Col As Integer = 1 To 20
                                    .Cells(Row, Col).Value = FG(DR("Field" & Col.ToString))
                                Next
                            Loop
                        End Using
                    End Using
                End With

                Label1.Visible = False : CmbBackText.Visible = False
                Label2.Visible = False : TxtNote.Visible = False
                Dim OnLabel As Boolean = False
                For Each Itm As ClassFieldCollection In _P.Section.FieldData
                    Select Case Itm.FieldType
                        Case enumFieldType.Field
                            Select Case Itm.FieldUseType
                                Case 3 '名前フィールド
                                    Label1.Visible = True
                                    CmbBackText.Visible = True
                                    OnLabel = True
                                Case 4 '固定ラベルフィールド
                                    If Itm.MultiLine Then
                                        TxtNote.Multiline = True
                                        TxtNote.ContentAlignment = ContentAlignment.TopLeft
                                        TxtNote.RecommendedValue = "固定ラベル（複数行）が利用可能です。"
                                        C1Sizer2.Grid.Rows(0).IsSplitter = True
                                        Label2.Text = "固定ラベル(複)"
                                    Else
                                        TxtNote.Multiline = False
                                        TxtNote.ContentAlignment = ContentAlignment.MiddleLeft
                                        TxtNote.RecommendedValue = "固定ラベル（単行）が利用可能です。"
                                        C1Sizer2.Grid.Rows(0).IsSplitter = False
                                        C1Sizer2.Grid.Rows(1).Size = 28
                                        Label2.Text = "固定ラベル(単)"
                                    End If

                                    Label2.Visible = True
                                    TxtNote.Visible = True
                                    OnLabel = True
                                Case 5 'メモフィールド
                                    TxtNote.Multiline = True
                                    TxtNote.ContentAlignment = ContentAlignment.TopLeft
                                    TxtNote.RecommendedValue = "メモラベル（複数行）が利用可能です。"
                                    C1Sizer2.Grid.Rows(0).IsSplitter = True
                                    Label2.Text = "メモ固定ラベル(複)"
                                    Label2.Visible = True
                                    TxtNote.Visible = True
                                    OnLabel = True
                            End Select
                        Case enumFieldType.Barcode39

                    End Select
                Next
                If Not OnLabel Then
                    C1Sizer2.Grid.Rows(0).IsSplitter = False
                    C1Sizer2.Grid.Rows(1).Size = 28
                Else
                    C1Sizer2.Grid.Rows(0).IsSplitter = True
                End If
            Catch ex As Exception
                MsgBox(ExMessCreater(GetStack(ex)), 48, "データ読込エラー")
            End Try

            SS.ResumeLayout(True)
            Call CheckRowCount()
            _ColHerderChecked = False
            _DataLoding = False
        End If
    End Sub
#Region "フォーム"
    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If _IsEdit = True Then
            Dim _Ret As Integer = 0
            With FrmCloseDialog
                .ShowDialog(Me)
                _Ret = .RetCode
            End With

            Select Case _Ret
                Case -1
                    e.Cancel = True
                    Return
                Case 1
                    Call SaveTab()
                    If TxtMaergin_Top.ValueIsNull Then
                        My.Settings.Maergin_Top = 0
                    Else
                        My.Settings.Maergin_Top = TxtMaergin_Top.Value
                    End If

                    If TxtMaergin_Left.ValueIsNull Then
                        My.Settings.Maergin_Left = 0
                    Else
                        My.Settings.Maergin_Left = TxtMaergin_Left.Value
                    End If
                    My.Settings.Save()
            End Select
        Else
            If MsgBox("タックラベラーを終了してもいいですか？", 4 + 32, "終了確認") = MsgBoxResult.No Then
                e.Cancel = True
                Return
            End If
        End If

    End Sub

    Private Sub FrmMain_Leave(sender As Object, e As EventArgs) Handles Me.Leave

    End Sub
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = String.Format("{0} ( {1} )", Me.Text, My.Application.Info.Version.ToString)
        Call ScreenInitial()
        With SS.ActiveSheet
            For Col As Integer = 1 To .ColumnCount - 1
                .Columns(Col).Visible = False
                .Columns(Col).Tag = Nothing
            Next
        End With
        Call LoadTab()
        C1Sizer1.Grid.Columns(0).Size = 0
    End Sub

    ''' <summary>
    ''' フォームSHOWN
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        _Starting = False
        Call SSColSetting()
        _IsEdit = False
    End Sub
#End Region

    ''' <summary>
    ''' 画面初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScreenInitial()
        Call SPREAD_Initial(SS)
        TxtMaergin_Top.Value = My.Settings.Maergin_Top
        TxtMaergin_Left.Value = My.Settings.Maergin_Left

        If CmbBackText.Items.Count > 0 Then
            CmbBackText.SelectedIndex = 0
        End If
    End Sub
    ''' <summary>
    ''' セルごと表示調整
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <param name="Col"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormatCellValue(Row As Integer, Col As Integer) As String
        Dim _Ret As String = ""
        With SS.ActiveSheet
            Dim _FD As ClassFieldCollection = .Columns(Col).Tag
            Dim _Str As String = FG(.Cells(Row, Col).Value)
            If Not IsNothing(_FD) Then

                Select Case _FD.FieldUseType
                    '一般フィールド0
                    '郵便番号フィールド1
                    '住所フィールド2
                    '名前フィールド3
                    '注意書きフィールド4
                    Case 1
                        _Str = FG(.Cells(Row, Col).Text)
                        If _FD.AddStr1 Then
                            _Ret = String.Format("〒 {0}", _Str)
                        Else
                            _Ret = _Str
                        End If
                    Case 3
                        If _Str = "" Then
                            _Ret = _Str
                        Else
                            'Dim _PaperButton As C1.Win.C1Ribbon.RibbonButton = CmbBackText.Items(CmbBackText.SelectedIndex)

                            'Dim BB As C1.Win.C1Ribbon.RibbonButton = DirectCast(CmbBackText.Items(CmbBackText.SelectedIndex), C1.Win.C1Ribbon.RibbonButton)
                            '_Ret = String.Format("{0} {1}", _Str, _PaperButton.Text)
                            _Ret = String.Format("{0} {1}", _Str, CmbBackText.Text)
                        End If
                    Case Else
                        If _FD.LabelIsMask Then
                            FrmTempForm.MaskedTextBox1.Mask = _FD.LabelText
                            FrmTempForm.MaskedTextBox1.Text = _Str
                            _Ret = FrmTempForm.MaskedTextBox1.Text
                            _Ret = String.Format("{0}{1}{2}", _FD.AddString_Front, _Ret, _FD.AddString_Back)
                        Else
                            '_Ret = _Str
                            _Ret = String.Format("{0}{1}{2}", _FD.AddString_Front, _Str, _FD.AddString_Back)
                        End If
                End Select
            Else
                _Ret = _Str
            End If
        End With
        Return FormatNumberling(_Ret)
    End Function
    ''' <summary>
    ''' 印刷ナンバリング調整
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormatNumberling(Value As String) As String
        Select Case _NumberFrontZero
            'Case 0
            '.Cells(Row, Col).Value = TxtNote.Text
            Case 0, -1
                Return Value.Replace(_NumberString, _NumberStartNo.ToString)
            Case Else
                Dim _Str As String = _NumberStartNo.ToString.PadLeft(_NumberFrontZero + 1, "0")
                Return Value.Replace(_NumberString, _Str)
        End Select
    End Function
    ''' <summary>
    ''' プレビューページの記憶
    ''' </summary>
    ''' <remarks></remarks>
    Dim _CurrentPreviewPage = -1
    ''' <summary>
    ''' プレビュー文書名(選択タブ名)の記憶
    ''' </summary>
    ''' <remarks></remarks>
    Dim _PreviewDocumentName As String = ""
    ''' <summary>
    ''' タックプレビュー作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreatePerview()
        If _DataLoding Then
            Return
        End If

        Dim _Count As Integer = 1
        If Not TxtBusu.ValueIsNull Then
            _Count = TxtBusu.Value
        Else
            TxtBusu.Value = 1
        End If
        Application.UseWaitCursor = Not Application.UseWaitCursor
        LblMessage.Text = "印刷プレビュー作成中・・・"
        Application.DoEvents()

        With Viewer1.ReportViewer
            _CurrentPreviewPage = .CurrentPage
        End With
        SS.EditMode = False
        Viewer1.Document = Nothing

        _PreviewDocumentName = GcTabControl1.TabPages(TabSelectedIndex).Text

        Dim RepFile As String = NFuncSystemFullPath(Environment.SpecialFolder.CommonApplicationData, "RepData.xml")
        Dim RepDataArray As New List(Of ClassPreviewFieldCollection)
        Try

            Dim _TabDat As LocalTabCollection = GcTabControl1.SelectedTab.Tag
            Dim PaperItem As ClassPaperCollection = PaperArray(_TabDat.UsePaperIndex)
            With SS.ActiveSheet
                If .RowCount > 0 Then
                    For Row As Integer = 0 To .RowCount - 1
                        If FG(.Cells(Row, 0).Value, enum_FG.FG_Boolean) Then
                            For C As Integer = 1 To _Count
                                Dim _T As New ClassPreviewFieldCollection

                                If ChkPreviewFrame.Checked Then
                                    _T.FieldShape = "1"
                                Else
                                    _T.FieldShape = ""
                                End If
                                _T.Field1 = FormatCellValue(Row, 1)
                                _T.Field2 = FormatCellValue(Row, 2)
                                _T.Field3 = FormatCellValue(Row, 3)
                                _T.Field4 = FormatCellValue(Row, 4)
                                _T.Field5 = FormatCellValue(Row, 5)
                                _T.Field6 = FormatCellValue(Row, 6)
                                _T.Field7 = FormatCellValue(Row, 7)
                                _T.Field8 = FormatCellValue(Row, 8)
                                _T.Field9 = FormatCellValue(Row, 9)
                                _T.Field10 = FormatCellValue(Row, 10)
                                _T.Field11 = FormatCellValue(Row, 11)
                                _T.Field12 = FormatCellValue(Row, 12)
                                _T.Field13 = FormatCellValue(Row, 13)
                                _T.Field14 = FormatCellValue(Row, 14)
                                _T.Field15 = FormatCellValue(Row, 15)
                                _T.Field16 = FormatCellValue(Row, 16)
                                _T.Field17 = FormatCellValue(Row, 17)
                                _T.Field17 = FormatCellValue(Row, 18)
                                _T.Field19 = FormatCellValue(Row, 19)
                                _T.Field20 = FormatCellValue(Row, 20)

                                RepDataArray.Add(_T)
                                If _NumberTackGoto Then
                                    _NumberStartNo += 1
                                End If

                            Next
                        End If
                        If Not _NumberTackGoto Then
                            _NumberStartNo += 1
                        End If
                    Next
                End If
            End With

            If RepDataArray.Count > 0 Then
                '空タック
                If _TackSpace > 0 Then
                    For i = 1 To _TackSpace
                        Dim _T As New ClassPreviewFieldCollection
                        _T.FieldShape = "2"
                        RepDataArray.Insert(0, _T)
                    Next
                End If

                Dim Data() As ClassPreviewFieldCollection = RepDataArray.ToArray
                Try

                    Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(ClassPreviewFieldCollection()))
                    Using FS As New IO.FileStream(RepFile, IO.FileMode.Create)
                        SRZ.Serialize(FS, Data)
                    End Using

                    Call CreateReport(PaperItem) 'RPX作成

                    Dim Rep As New GrapeCity.ActiveReports.SectionReport()
                    Using xtr As New System.Xml.XmlTextReader(ReportRPXFile)
                        Rep.LoadLayout(xtr)
                    End Using

                    CType(Rep.DataSource, GrapeCity.ActiveReports.Data.XMLDataSource).FileURL = RepFile

                    Rep.PageSettings.Margins.Top = (PaperItem.TopMargin + TxtMaergin_Top.Value) / 25.4
                    Rep.PageSettings.Margins.Left = (PaperItem.LeftMargin + TxtMaergin_Left.Value) / 25.4

                    Rep.Run()
                    Report = Rep.Document

                    If My.Settings.PreviewIsWide Then
                        Call PageZoom(enumPageZoom.PaperWidth)
                    Else
                        Call PageZoom(enumPageZoom.PaperAll)
                    End If
                    LblMessage.Text = ""
                Catch ex As Exception
                    'MsgBox(ex.Message)
                    MsgBox(ExMessCreater(GetStack(ex)), 48, "印刷ファイル作成エラー")
                    LblMessage.Text = "【エラー】印刷用ファイル作成エラー"
                End Try
            Else
                LblMessage.Text = "【エラー】タックを発行する為の宛先が１つも選択されていません"
            End If

        Catch ex As Exception
            'MsgBox(ex.Message, 48, "CreatePerview")
            MsgBox(ExMessCreater(GetStack(ex)), 48, "プレビュー作成エラー")
            LblMessage.Text = "【エラー】印刷プレビュー作成に失敗しました"
        End Try
        Application.UseWaitCursor = Not Application.UseWaitCursor

    End Sub
    ''' <summary>
    ''' タック試し打ち用プレビュー作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateSamplePerview()
        If C1Sizer1.Grid.Columns(1).Size = 0 Then
            Call BtnNoPreview_Click(Nothing, Nothing)
        End If

        Viewer1.Document.Pages.Clear()

        Application.UseWaitCursor = Not Application.UseWaitCursor
        LblMessage.Text = "サンプル印刷プレビュー作成中・・・"
        Application.DoEvents()

        Dim RepFile As String = AppFullPath("RepData.xml")
        Dim RepDataArray As New List(Of ClassPreviewFieldCollection)
        Try
            Dim _TabData As LocalTabCollection = GcTabControl1.SelectedTab.Tag
            Dim PaperItem As ClassPaperCollection = PaperArray(_TabData.UsePaperIndex)

            For i As Integer = 0 To (PaperItem.Section.ColumnCount * PaperItem.Section.RowCount) - 1
                Dim _T As New ClassPreviewFieldCollection

                _T.FieldShape = "1"
                _T.Field1 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(1).Label, i + 1)
                _T.Field2 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(2).Label, i + 1)
                _T.Field3 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(3).Label, i + 1)
                _T.Field4 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(4).Label, i + 1)
                _T.Field5 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(5).Label, i + 1)
                _T.Field6 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(6).Label, i + 1)
                _T.Field7 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(7).Label, i + 1)
                _T.Field8 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(8).Label, i + 1)
                _T.Field9 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(9).Label, i + 1)
                _T.Field10 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(10).Label, i + 1)
                _T.Field11 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(11).Label, i + 1)
                _T.Field12 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(12).Label, i + 1)
                _T.Field13 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(13).Label, i + 1)
                _T.Field14 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(14).Label, i + 1)
                _T.Field15 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(15).Label, i + 1)
                _T.Field16 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(16).Label, i + 1)
                _T.Field17 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(17).Label, i + 1)
                _T.Field18 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(18).Label, i + 1)
                _T.Field19 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(19).Label, i + 1)
                _T.Field20 = String.Format("{0}-{1}", SS.ActiveSheet.Columns(20).Label, i + 1)
                RepDataArray.Add(_T)
            Next

            If RepDataArray.Count > 0 Then
                Dim Data() As ClassPreviewFieldCollection = RepDataArray.ToArray
                Try
                    Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(ClassPreviewFieldCollection()))
                    Using FS As New IO.FileStream(RepFile, IO.FileMode.Create)
                        SRZ.Serialize(FS, Data)
                    End Using

                    Call CreateReport(PaperItem) 'RPX作成

                    Dim Rep As New GrapeCity.ActiveReports.SectionReport()
                    Using xtr As New System.Xml.XmlTextReader(ReportRPXFile)
                        Rep.LoadLayout(xtr)
                    End Using

                    CType(Rep.DataSource, GrapeCity.ActiveReports.Data.XMLDataSource).FileURL = RepFile

                    Rep.PageSettings.Margins.Top = (PaperItem.TopMargin + TxtMaergin_Top.Value) / 25.4
                    Rep.PageSettings.Margins.Left = (PaperItem.LeftMargin + TxtMaergin_Left.Value) / 25.4

                    Rep.Run()
                    Report = Rep.Document

                    Call PageZoom(enumPageZoom.PaperAll)
                    LblMessage.Text = ""
                Catch ex As Exception
                    'MsgBox(ex.Message)
                    MsgBox(ExMessCreater(GetStack(ex)), 48, "印刷ファイル作成エラー")
                    LblMessage.Text = "【エラー】印刷用ファイル作成エラー"
                End Try
            Else
                LblMessage.Text = "【エラー】タックを発行する為の宛先が１つも選択されていません"
            End If

        Catch ex As Exception
            'MsgBox(ex.Message, 48, "CreateSamplePerview")
            MsgBox(ExMessCreater(GetStack(ex)), 48, "サンプルプレビュー作成エラー")
            LblMessage.Text = "【エラー】サンプル印刷プレビュー作成に失敗しました"
        End Try
        Application.UseWaitCursor = Not Application.UseWaitCursor
    End Sub

    Public Property Report() As GrapeCity.ActiveReports.Document.SectionDocument 'Public Property Report() As GrapeCity.ActiveReports.Document.Document
        Get
            Return Viewer1.Document
        End Get
        Set(ByVal Value As GrapeCity.ActiveReports.Document.SectionDocument)
            Me.Viewer1.Document = Value
        End Set
    End Property
    ''' <summary>
    ''' SPREAD行追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnAddRow_Click(sender As Object, e As EventArgs) Handles BtnAddRow.Click, CMSS_AddRow.Click
        Call SPREAD_InsertRow(SS)
        Call CheckRowCount()
        _IsEdit = True

    End Sub
    ''' <summary>
    ''' SPREAD行挿入
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnInsRow_Click(sender As Object, e As EventArgs) Handles BtnInsRow.Click, CMSS_InsRow.Click
        Dim _Row As Integer = SS.ActiveSheet.ActiveRowIndex
        Call SPREAD_InsertRow(SS, _Row)
        Call CheckRowCount()
        _IsEdit = True

    End Sub
    ''' <summary>
    ''' タブ追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnTabAdd_Click(sender As Object, e As EventArgs) Handles BtnTabAdd.Click, CMT_Add.Click
        Try
            Dim No As Integer = NextNo(NextNoMode.TabNo)
            Sql = "INSERT INTO TabData(IndexNo,TabName,UsePaperIndex,LabelText,MR) VALUES (@IndexNo,@TabName,@UsePaperIndex,@LabelText,@MR)"
            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                CMD.Parameters.Add(New OleDb.OleDbParameter("@IndexNo", OleDb.OleDbType.Integer))
                CMD.Parameters.Add(New OleDb.OleDbParameter("@TabName", OleDb.OleDbType.Char))
                CMD.Parameters.Add(New OleDb.OleDbParameter("@UsePaperIndex", OleDb.OleDbType.Integer))
                CMD.Parameters.Add(New OleDb.OleDbParameter("@LabelText", OleDb.OleDbType.Char))
                CMD.Parameters.Add(New OleDb.OleDbParameter("@MR", OleDb.OleDbType.Char))
                CMD.Parameters("@IndexNo").Value = No
                CMD.Parameters("@TabName").Value = "新しいタブ"
                CMD.Parameters("@UsePaperIndex").Value = 0
                CMD.Parameters("@LabelText").Value = ""
                CMD.Parameters("@MR").Value = "様"
                CMD.ExecuteNonQuery()
            End Using
            Dim TB As New GrapeCity.Win.Containers.GcTabPage
            Dim _T As New LocalTabCollection
            _T.Index = No
            _T.UsePaperIndex = 0
            TB.Text = "新しいタブ"
            TB.Tag = _T
            GcTabControl1.TabPages.Add(TB)
            GcTabControl1.SelectedIndex = GcTabControl1.TabPages.Count - 1
            _IsEdit = True
        Catch ex As Exception
            'MsgBox(ex.Message, 48, "BtnTabAdd_Click")
            MsgBox(ExMessCreater(GetStack(ex)), 48, "タブ追加エラー")
        End Try

    End Sub
    ''' <summary>
    ''' タブ複写
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMT_Copy_Click(sender As Object, e As EventArgs) Handles CMT_Copy.Click
        Call BtnTabCopy_Click(Nothing, Nothing)
    End Sub
    ''' <summary>
    ''' タブ編集
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnTabEdit_Click(sender As Object, e As EventArgs) Handles BtnTabEdit.Click, CMT_Edit.Click
        With FrmTabRename
            Dim _T As LocalTabCollection = GcTabControl1.TabPages(TabSelectedIndex).Tag
            .TabName = GcTabControl1.TabPages(TabSelectedIndex).Text
            .PaperIndex = _T.UsePaperIndex
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                GcTabControl1.TabPages(TabSelectedIndex).Text = .TabName
                _T.UsePaperIndex = .PaperIndex
                GcTabControl1.TabPages(TabSelectedIndex).Tag = _T
                Call UpdateTabData()
                Call SSColSetting()
                Call StatPaperInfoSet(PaperArray(.PaperIndex)) '用紙情報表示更新
                _IsEdit = True

            End If
        End With
    End Sub

    ''' <summary>
    ''' タブ削除 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnTabDel_Click(sender As Object, e As EventArgs) Handles BtnTabDel.Click, CMT_Delete.Click
        Try
            If TabSelectedIndex > -1 Then
                If MsgBox("選択タブを削除してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                    If MsgBox("タブを削除すると付随するデータも削除されます。" & vbCrLf & "処理を続行してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                        Try
                            Dim TD As LocalTabCollection = GcTabControl1.TabPages(TabSelectedIndex).Tag
                            Dim No As Integer = TD.Index
                            Sql = String.Format("DELETE FROM AddressData WHERE TabIndexNo={0}", No)
                            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                                CMD.ExecuteNonQuery()
                            End Using
                            Sql = String.Format("DELETE FROM TabData WHERE IndexNo={0}", No)
                            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                                CMD.ExecuteNonQuery()
                            End Using

                            _NoSave = True
                            GcTabControl1.TabPages.RemoveAt(TabSelectedIndex)
                            TabSelectedIndex = -1

                            If GcTabControl1.TabPages.Count = 0 Then
                                Call ZeroTab()
                                SS.ActiveSheet.RowCount = 0
                            End If
                            GcTabControl1.SelectedIndex = 0
                            TabSelectedIndex = 0

                        Catch ex As Exception
                            MsgBox(ExMessCreater(GetStack(ex)), 48, "タブ削除エラー")
                        End Try

                        _NoSave = False
                        _IsEdit = True

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "タブ削除エラー")
        End Try

    End Sub
    ''' <summary>
    ''' APP終了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnAPPEnd_Click(sender As Object, e As EventArgs) Handles BtnAPPEnd.Click
        'Application.Exit()
        Me.Close()
    End Sub
    ''' <summary>
    ''' タック空打ち回数記憶
    ''' </summary>
    ''' <remarks></remarks>
    Dim _TackSpace As Integer = 0
    ''' <summary>
    ''' タック空打ち設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSelTack_Click(sender As Object, e As EventArgs) Handles BtnSelTack.Click
        Dim _NoType As Boolean = False
        Dim _OKFlg As Boolean = False
        Dim _TabData As LocalTabCollection = GcTabControl1.SelectedTab.Tag
        Dim _PaperTag As ClassPaperCollection = PaperArray(_TabData.UsePaperIndex)
        Select Case _PaperTag.Section.ColumnCount
            Case 1
                Select Case _PaperTag.Section.RowCount
                    Case 2
                        With FrmSelTack_1x2
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 12
                        With FrmSelTack_1x12
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case Else
                        _NoType = True
                End Select

            Case 2
                Select Case _PaperTag.Section.RowCount
                    Case 2
                        With FrmSelTack_2x2
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 3
                        With FrmSelTack_2x3
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 4
                        With FrmSelTack_2x4
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 5
                        With FrmSelTack_2x5
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 6
                        With FrmSelTack_2x6
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 7
                        With FrmSelTack_2x7
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 8
                        With FrmSelTack_2x8
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 9
                        With FrmSelTack_2x9
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 10
                        With FrmSelTack_2x10
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 12
                        With FrmSelTack_2x12
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case Else
                        _NoType = True
                End Select
            Case 3
                Select Case _PaperTag.Section.RowCount
                    Case 2
                        With FrmSelTack_3x2
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 3
                        With FrmSelTack_3x3
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 4
                        With FrmSelTack_3x4
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 6
                        With FrmSelTack_3x6
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 5
                        With FrmSelTack_3x5
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 7
                        With FrmSelTack_3x7
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 8
                        With FrmSelTack_3x8
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 9
                        With FrmSelTack_3x9
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 10
                        With FrmSelTack_3x10
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 12
                        With FrmSelTack_3x12
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case Else
                        _NoType = True
                End Select
            Case 4
                Select Case _PaperTag.Section.RowCount

                    Case 8
                        With FrmSelTack_4x8
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 9
                        With FrmSelTack_4x9
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 10
                        With FrmSelTack_4x10
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case 12
                        With FrmSelTack_4x12
                            .TackSpace = _TackSpace
                            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                                _TackSpace = .TackSpace
                                _OKFlg = True
                            End If
                        End With
                    Case Else
                        _NoType = True
                End Select
            Case Else
                _NoType = True
        End Select
        If _NoType Then
            MsgBox(String.Format("対応するタックタイプがありません。({0}x{1})", _PaperTag.Section.ColumnCount, _PaperTag.Section.RowCount) & 48, "タック選択エラー")
        Else
            If _OKFlg Then Call BtnPreview_Click(Nothing, Nothing)
        End If
    End Sub

    Enum enumPageZoom
        ZoomUp '拡大
        ZoomDown '縮小
        Zoom100 '原寸
        PaperWidth '幅基準
        PaperAll '全体
    End Enum
    Dim _Zoomed As Decimal = 0
    ''' <summary>
    ''' ページ拡大縮小関数
    ''' </summary>
    ''' <param name="ZoomMode"></param>
    ''' <remarks></remarks>
    Private Sub PageZoom(ByVal ZoomMode As enumPageZoom)
        Try
            With Viewer1.ReportViewer
                Select Case ZoomMode
                    Case enumPageZoom.PaperAll : .Zoom = -2
                    Case enumPageZoom.PaperWidth : .Zoom = -1
                    Case enumPageZoom.ZoomUp
                        If .Zoom < 0 Then
                            .Zoom = _Zoomed + 0.1
                        Else
                            If .Zoom <= 4 Then
                                .Zoom += 0.1
                            End If
                        End If
                    Case enumPageZoom.ZoomDown
                        If .Zoom < 0 Then
                            .Zoom = _Zoomed - 0.1
                        Else
                            If .Zoom > 0.2 Then
                                .Zoom -= 0.1
                            End If
                        End If
                    Case enumPageZoom.Zoom100
                        .Zoom = 1
                End Select
            End With

        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "拡大縮小エラー")
        End Try
    End Sub
    ''' <summary>
    ''' 印刷開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnPrintOut_Click(sender As Object, e As EventArgs) Handles BtnPrintOut.Click
        If Not Viewer1.Document.Pages.Count = 0 Then
            Dim PrintDialog As New System.Windows.Forms.PrintDialog

            With PrintDialog
                ' 印刷ダイアログを設定します。
                .AllowSomePages = True
                .Document = Viewer1.Document.Printer
                .PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.AllPages
                .PrinterSettings.FromPage = Viewer1.ReportViewer.CurrentPage
                .PrinterSettings.ToPage = Viewer1.Document.Pages.Count

                '.PrinterSettings.DefaultPageSettings.PaperSource = System.Drawing.Printing.PageSetting

                ' OKボタンが押されたら、印刷を実行します。
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Select Case .PrinterSettings.PrintRange
                        Case Printing.PrintRange.AllPages '全て印刷
                            .PrinterSettings.FromPage = 1
                            .PrinterSettings.ToPage = Viewer1.Document.Pages.Count
                        Case Printing.PrintRange.CurrentPage '現在のページ
                            .PrinterSettings.FromPage = Viewer1.ReportViewer.CurrentPage
                            .PrinterSettings.ToPage = Viewer1.ReportViewer.CurrentPage
                        Case Printing.PrintRange.Selection
                        Case Printing.PrintRange.SomePages

                    End Select

                    Try
                        Viewer1.Document.Name = _PreviewDocumentName
                        Viewer1.Print(False, True, False)
                    Catch ex As Exception

                    End Try
                End If
            End With
            LblMessage.Text = ""
        Else
            LblMessage.Text = "【エラー】印刷を開始する前に印刷プレビューを行ってください"
        End If

    End Sub
    ''' <summary>
    ''' 試し打ち開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSamplePreview_Click(sender As Object, e As EventArgs) Handles BtnSamplePreview.Click
        Call CreateSamplePerview()
    End Sub
    Enum enumPageMove
        TopPage '最初のページへ
        ForwardPage '前ページへ
        NextPage '後ページへ
        LastPage '最終ページへ
    End Enum
    ''' <summary>
    ''' ページ移動関数
    ''' </summary>
    ''' <param name="MoveMode"></param>
    ''' <remarks></remarks>
    Private Sub PageMove(ByVal MoveMode As enumPageMove)
        With Viewer1.ReportViewer
            If Viewer1.Document.Pages.Count > 0 Then
                Select Case MoveMode
                    Case enumPageMove.TopPage
                        .CurrentPage = 1
                    Case enumPageMove.ForwardPage
                        If .CurrentPage > 1 Then
                            .CurrentPage -= 1
                        End If
                    Case enumPageMove.NextPage
                        If .CurrentPage < Viewer1.Document.Pages.Count Then
                            .CurrentPage += 1
                        End If
                    Case enumPageMove.LastPage
                        .CurrentPage = Viewer1.Document.Pages.Count
                End Select
            End If
        End With
    End Sub
    ''' <summary>
    ''' プレビュー前頁移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnMovePage_Front_Click(sender As Object, e As EventArgs) Handles BtnMovePage_Front.Click
        Call PageMove(enumPageMove.ForwardPage)
    End Sub
    ''' <summary>
    ''' プレビュー次ページ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnMovePage_Next_Click(sender As Object, e As EventArgs) Handles BtnMovePage_Next.Click
        Call PageMove(enumPageMove.NextPage)
    End Sub
    ''' <summary>
    ''' 印刷プレビュー作成終了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Viewer1_LoadCompleted(sender As Object, e As EventArgs) Handles Viewer1.LoadCompleted
        If _CurrentPreviewPage > 0 Then
            If Viewer1.Document.Pages.Count > 0 Then
                If _CurrentPreviewPage <= Viewer1.Document.Pages.Count Then
                    With Viewer1.ReportViewer
                        .CurrentPage = _CurrentPreviewPage
                    End With
                End If
            End If
        End If

        With Viewer1.Document
            With .Printer
                StatLabel_Printer.Text = .PrinterName
            End With
        End With
    End Sub

    Private Sub CmbFormatPaper_SelectedIndexChanged(sender As Object, e As EventArgs)
        Call SSColSetting()
    End Sub
    ''' <summary>
    ''' SPREADカラム設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SSColSetting()
        'TODO: SPREADカラム設定
        Try
            If Not _Starting Then
                If PaperArray.Count > 0 Then
                    Dim _TabData As LocalTabCollection = GcTabControl1.SelectedTab.Tag
                    Dim _Paper As ClassPaperCollection = PaperArray(_TabData.UsePaperIndex)

                    With SS.ActiveSheet
                        .Models.ResetViewColumnIndexes()

                        For Col As Integer = 1 To .ColumnCount - 1
                            .Columns(Col).Visible = False
                            .Columns(Col).Tag = Nothing
                        Next
                        For i As Integer = 2 To _Paper.Section.FieldData.Count - 1
                            Dim Item As ClassFieldCollection = _Paper.Section.FieldData(i)
                            With .Columns(i - 1)
                                Select Case Item.FieldType
                                    Case enumFieldType.Field
                                        If Not Item.IsSystem AndAlso Item.Visible Then
                                            .Visible = True

                                            If Item.MultiLine Then
                                                .Label = Item.Text & "(複行)"
                                            Else
                                                .Label = Item.Text
                                            End If

                                            Select Case Item.FieldUseType
                                                '一般フィールド0
                                                '郵便番号フィールド1
                                                '住所フィールド2
                                                '名前フィールド3
                                                '注意書きフィールド4
                                                Case 1
                                                    .Width = 100
                                                    .ImeMode = Windows.Forms.ImeMode.Off
                                                    .Locked = False
                                                    Dim C As New FarPoint.Win.Spread.CellType.MaskCellType
                                                    C.Mask = "###-####"
                                                    .CellType = C
                                                    .AllowAutoFilter = False
                                                Case 4
                                                    If Item.DisplayWidth > 0 Then
                                                        .Width = Item.DisplayWidth
                                                    Else
                                                        .Width = 250
                                                    End If
                                                    If Item.UseIME Then
                                                        .ImeMode = Windows.Forms.ImeMode.On
                                                    Else
                                                        .ImeMode = Windows.Forms.ImeMode.Off
                                                    End If
                                                    .Visible = False
                                                    Dim C As New FarPoint.Win.Spread.CellType.TextCellType
                                                    .CellType = C
                                                    .Locked = True
                                                    .AllowAutoFilter = True
                                                Case Else
                                                    If Item.DisplayWidth > 0 Then
                                                        .Width = Item.DisplayWidth
                                                    Else
                                                        .Width = 250
                                                    End If
                                                    If Not Item.LabelIsMask Then
                                                        'マスク設定なし
                                                        If Item.UseIME Then
                                                            .ImeMode = Windows.Forms.ImeMode.On
                                                        Else
                                                            .ImeMode = Windows.Forms.ImeMode.Off
                                                        End If
                                                        .Locked = False
                                                        Dim C As New FarPoint.Win.Spread.CellType.TextCellType
                                                        C.Multiline = Item.MultiLine
                                                        .CellType = C
                                                    Else
                                                        'マスク設定あり
                                                        If Item.UseIME Then
                                                            .ImeMode = Windows.Forms.ImeMode.On
                                                        Else
                                                            .ImeMode = Windows.Forms.ImeMode.Off
                                                        End If
                                                        Dim C As New FarPoint.Win.Spread.CellType.MaskCellType
                                                        C.Mask = Item.LabelText
                                                        .CellType = C
                                                    End If
                                                    .AllowAutoFilter = True
                                            End Select

                                            .Tag = Item
                                        End If
                                    Case enumFieldType.Memo
                                        .Visible = True
                                        .Label = Item.Text & "(複行)"
                                        If Item.UseIME Then
                                            .ImeMode = Windows.Forms.ImeMode.On
                                        Else
                                            .ImeMode = Windows.Forms.ImeMode.Off
                                        End If
                                        If Item.DisplayWidth > 0 Then
                                            .Width = Item.DisplayWidth
                                        Else
                                            .Width = 250
                                        End If
                                        .Locked = False
                                        Dim C As New FarPoint.Win.Spread.CellType.TextCellType
                                        C.Multiline = True
                                        .CellType = C
                                    Case enumFieldType.Barcode39, enumFieldType.BarcodeQR
                                        If Not Item.IsSystem AndAlso Item.Visible Then
                                            .Visible = True
                                            .Label = Item.Text
                                            .ImeMode = Windows.Forms.ImeMode.Off
                                            If Item.DisplayWidth > 0 Then
                                                .Width = Item.DisplayWidth
                                            Else
                                                .Width = 250
                                            End If
                                            .Locked = False
                                            Dim C As New FarPoint.Win.Spread.CellType.TextCellType
                                            C.Multiline = Item.MultiLine
                                            .CellType = C

                                            .Tag = Item
                                        End If
                                End Select

                            End With
                        Next
                    End With

                    'Call CreatePerview()
                End If
            End If
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "カラム設定エラー")
        End Try

    End Sub

    ''' <summary>
    ''' タックフォーム編集
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnTackEdit_Click(sender As Object, e As EventArgs) Handles BtnTackEdit.Click
        FrmEditPaper.ShowDialog()

        If LoadPaperArray() Then
            If PaperArray.Count > 0 Then
                Call SaveTab() '既存データ保存
                Call LoadTabData() '新しいタブのデータ読込
            End If
        End If
    End Sub
    ''' <summary>
    ''' CSV出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCSV_Save_Click(sender As Object, e As EventArgs) Handles BtnCSV_Save.Click

        If SS.ActiveSheet.RowCount > 0 Then
            Dim DIS As String = String.Format("{0}.csv", GcTabControl1.TabPages(TabSelectedIndex).Text)
            Dim _C As New List(Of Integer)
            _C = CheckNoteCol()
            _C.Insert(0, 0)
            Dim FN As String = SPREAD2CSV(SS, DIS, False, _C.ToArray)
            If FN <> "" AndAlso System.IO.File.Exists(FN) Then
                LblMessage.Text = "CSVファイルを出力しました"
            End If
        End If
    End Sub
    ''' <summary>
    ''' チェック行のみCSV出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCSV_SavePart_Click(sender As Object, e As EventArgs) Handles BtnCSV_SavePart.Click
        If SS.ActiveSheet.RowCount > 0 Then
            Dim _Flg As Boolean = False
            For Row As Integer = 0 To SS.ActiveSheet.RowCount - 1
                If FG(SS.ActiveSheet.Cells(Row, 0).Value, enum_FG.FG_Boolean) = True Then
                    _Flg = True : Exit For
                End If
            Next
            If _Flg Then
                Dim DIS As String = String.Format("{0}.csv", GcTabControl1.TabPages(TabSelectedIndex).Text)
                Dim _C As New List(Of Integer)
                _C = CheckNoteCol()
                _C.Insert(0, 0)
                Dim FN As String = SPREAD2CSV_Part(SS, DIS, False, _C.ToArray)
                If FN <> "" AndAlso System.IO.File.Exists(FN) Then
                    LblMessage.Text = "CSVファイルを出力しました"
                End If
            Else
                MsgBox("出力対象のデータが１つも選択されていません。", 48, "エラー")
            End If

        End If
    End Sub
    ''' <summary>
    ''' CSVインポート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCSV_Load_Click(sender As Object, e As EventArgs) Handles BtnCSV_Load.Click
        Dim _FL As String = ""
        Using OFD As New OpenFileDialog
            With OFD
                .AddExtension = True
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = ".csv"
                .Filter = "CSVファイル(*.csv)|*.csv|全てのファイル(*.*)|*.*"
                .FilterIndex = 0
                .Multiselect = False
                .RestoreDirectory = True
                .Title = "CSVインポート"
                If .ShowDialog = DialogResult.OK Then
                    _FL = .FileName
                End If
            End With
        End Using

        If _FL <> "" Then
            If MsgBox("CSVデータを追加してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                Try
                    Dim csvRecords As New System.Collections.ArrayList()
                    Using tfp As New FileIO.TextFieldParser(_FL, System.Text.Encoding.GetEncoding(932))
                        'フィールドが文字で区切られているとする
                        'デフォルトでDelimitedなので、必要なし
                        tfp.TextFieldType = FileIO.FieldType.Delimited
                        '区切り文字を,とする
                        tfp.Delimiters = New String() {","}
                        'フィールドを"で囲み、改行文字、区切り文字を含めることができるか
                        'デフォルトでtrueなので、必要なし
                        tfp.HasFieldsEnclosedInQuotes = True
                        'フィールドの前後からスペースを削除する
                        'デフォルトでtrueなので、必要なし
                        tfp.TrimWhiteSpace = True

                        While Not tfp.EndOfData
                            'フィールドを読み込む
                            Dim fields As String() = tfp.ReadFields()
                            '保存
                            csvRecords.Add(fields)
                        End While

                    End Using
                    If csvRecords.Count > 0 Then
                        For Y As Integer = 0 To csvRecords.Count - 1
                            Dim Row As Integer = SPREAD_InsertRow(SS)
                            'Dim Col As Integer = 1
                            'For X As Integer = 0 To csvRecords(Y).length - 1
                            '    If Col < SS.ActiveSheet.ColumnCount - 1 Then
                            '        SS.ActiveSheet.Cells(Row, Col).Value = Replace(csvRecords(Y)(X), "<BR>", vbCrLf)
                            '        Col += 1
                            '    End If
                            'Next
                            Dim X As Integer = 0
                            For Col As Integer = 1 To SS.ActiveSheet.ColumnCount - 1
                                If SS.ActiveSheet.Columns(Col).Visible Then
                                    If X < csvRecords(Y).Length Then
                                        SS.ActiveSheet.Cells(Row, Col).Value = Replace(csvRecords(Y)(X), "<BR>", vbCrLf)
                                        X += 1
                                    End If
                                End If
                            Next
                        Next
                    End If
                Catch ex As Exception
                    'MsgBox(ex.Message, 48, "BtnCSV_Load_Click")
                    MsgBox(ExMessCreater(GetStack(ex)), 48, "CSVインポートエラー")
                End Try

            End If
        End If
    End Sub
    ''' <summary>
    ''' 他タブへのデータ　移動・コピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnMoveData_Click(sender As Object, e As EventArgs) Handles BtnMoveData.Click
        Try
            Dim _C As Integer = 0
            Sql = String.Format("SELECT count(*) FROM TabData WHERE IndexNo<>{0}", TabSelectedIndex)
            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                _C = CMD.ExecuteScalar
            End Using
            If _C > 0 Then
                Dim _RowFlg As Boolean = False
                If SS.ActiveSheet.RowCount > 0 Then
                    For Row As Integer = 0 To SS.ActiveSheet.RowCount - 1
                        If FG(SS.ActiveSheet.Cells(Row, 0).Value, enum_FG.FG_Boolean) Then
                            _RowFlg = True : Exit For
                        End If
                    Next
                    If Not _RowFlg Then
                        LblMessage.Text = "【エラー】作業対象行が選択されていません。"
                        Return
                    End If
                Else
                    Return
                End If
                Dim _SelIndex As Integer = -1
                Dim _IsCopy As Boolean = False
                With FrmToIndex
                    .MyIndex = TabSelectedIndex
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        _SelIndex = .SelIndex
                        _IsCopy = .IsCopy
                    End If
                End With
                If _SelIndex > -1 Then
                    If _IsCopy Then
                        If MsgBox("チェック行をコピーしてもいいですか？", 4 + 32, "コピー確認") = MsgBoxResult.No Then
                            Return
                        End If
                    Else
                        If MsgBox("チェック行を移動してもいいですか？", 4 + 32, "移動確認") = MsgBoxResult.No Then
                            Return
                        End If
                    End If
                    Call DataMove(TabSelectedIndex, _SelIndex, _IsCopy)
                End If

            Else
                LblMessage.Text = "【エラー】移動・コピー先がありません"
            End If
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "データコピーエラー")
        End Try
    End Sub
    ''' <summary>
    ''' データ移動コピー処理
    ''' </summary>
    ''' <param name="FromIndex"></param>
    ''' <param name="ToIndex"></param>
    ''' <param name="IsCopy"></param>
    ''' <remarks></remarks>
    Private Sub DataMove(FromIndex As Integer, ToIndex As Integer, IsCopy As Boolean)
        With SS.ActiveSheet
            Try
                If .RowCount > 0 Then
                    Sql = "INSERT INTO AddressData(TabIndexNo,RowNo,Field1,Field2,Field3,Field4,Field5,Field6,Field7,Field8,Field9,Field10,Field11,Field12,Field13,Field14,Field15,Field16,Field17,Field18,Field19,Field20) VALUES (@TabIndexNo,@RowNo,@Field1,@Field2,@Field3,@Field4,@Field5,@Field6,@Field7,vField8,@Field9,@Field10,@Field11,@Field12,@Field13,@Field14,@Field15,@Field16,@Field17,@Field18,@Field19,@Field20)"
                    Using CMD As New OleDb.OleDbCommand(Sql, CN)
                        CMD.Parameters.Add(New OleDb.OleDbParameter("@TabIndexNo", OleDb.OleDbType.Integer))
                        CMD.Parameters.Add(New OleDb.OleDbParameter("@RowNo", OleDb.OleDbType.Integer))
                        For i As Integer = 1 To 20
                            CMD.Parameters.Add(New OleDb.OleDbParameter("@Field" & i.ToString, OleDb.OleDbType.Char))
                        Next

                        For Row As Integer = .RowCount - 1 To 0 Step -1
                            If FG(.Cells(Row, 0).Value, enum_FG.FG_Boolean) Then

                                CMD.Parameters("@TabIndexNo").Value = ToIndex
                                CMD.Parameters("@RowNo").Value = DataMaxRow(ToIndex) + 1
                                For Col As Integer = 1 To 20
                                    CMD.Parameters("@Field" & Col.ToString).Value = FG(.Cells(Row, Col).Value)
                                Next
                                CMD.ExecuteNonQuery()
                                If Not IsCopy Then
                                    .Rows(Row).Remove()
                                End If
                            End If
                        Next
                    End Using
                    _IsEdit = True
                    If IsCopy Then
                        LblMessage.Text = "チェック付き行ををコピーしました。"
                    Else
                        LblMessage.Text = "チェック付き行を移動しました。"
                    End If
                End If

            Catch ex As Exception
                MsgBox(ExMessCreater(GetStack(ex)), 48, "データコピーエラー")
            End Try
        End With
    End Sub
    ''' <summary>
    ''' 最大行番号の検索
    ''' </summary>
    ''' <param name="Index">検索するタブインデックス</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DataMaxRow(Index As Integer) As Integer
        Try
            Sql = String.Format("SELECT MAX(ROWNO) AS KAZU FROM AddressData WHERE TabIndexNo={0}", Index)
            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                Return FG(CMD.ExecuteScalar, enum_FG.FG_Numeric)
            End Using
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "番号検索エラー")
        End Try
        Return -1
    End Function
    ''' <summary>
    ''' 行削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDelRow_Click(sender As Object, e As EventArgs) Handles BtnDelRow.Click, CMSS_DelRow.Click

        Dim StartRow As Integer = -1
        Dim EndRow As Integer = -1

        With SS.ActiveSheet
            If .RowCount > 0 Then
                If .Models.Selection.AnchorRow <> .Models.Selection.LeadRow Then
                    If .Models.Selection.AnchorRow > .Models.Selection.LeadRow Then
                        StartRow = .Models.Selection.LeadRow : EndRow = .Models.Selection.AnchorRow
                    Else
                        StartRow = .Models.Selection.AnchorRow : EndRow = .Models.Selection.LeadRow
                    End If
                Else
                    StartRow = .Models.Selection.AnchorRow : EndRow = .Models.Selection.AnchorRow
                End If
            End If
        End With

        If StartRow > -1 AndAlso EndRow > -1 Then
            If StartRow = EndRow Then
                If MsgBox(String.Format("{0}行目を削除してもいいですか？", StartRow + 1), 4 + 32, "行削除確認") = MsgBoxResult.Yes Then
                    SS.ActiveSheet.RemoveRows(StartRow, 1)
                    Call CheckRowCount()
                    _IsEdit = True
                End If
            Else
                With SS.ActiveSheet
                    If MsgBox(String.Format("{0}行目から{1}行目までを削除してもいいですか？", StartRow + 1, EndRow + 1), 4 + 32, "行削除確認") = MsgBoxResult.Yes Then
                        For Row As Integer = EndRow To StartRow Step -1
                            .Rows(Row).Remove()
                        Next
                        _ColHerderChecked = True
                        Call CheckRowCount()
                        _IsEdit = True
                    End If
                End With

            End If
        End If

    End Sub
    ''' <summary>
    ''' チェック行を削除する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDelRowCheck_Click(sender As Object, e As EventArgs) Handles BtnDelRowCheck.Click, CMSS_DelRowCheck.Click
        With SS.ActiveSheet
            If .RowCount > 0 Then
                If MsgBox("チェック付き行を削除してもいいですか？", 4 + 32, "行削除確認") = MsgBoxResult.Yes Then
                    Try
                        For Row As Integer = .RowCount - 1 To 0 Step -1
                            If FG(.Cells(Row, 0).Value, enum_FG.FG_Boolean) Then
                                .Rows(Row).Remove()
                            End If
                        Next
                    Catch ex As Exception
                        MsgBox(ExMessCreater(GetStack(ex)), 48, "行削除エラー")
                    End Try
                    Call CheckRowCount()
                    _IsEdit = True
                End If
            End If
        End With

    End Sub
 
    ''' <summary>
    ''' データ入力行のみにチェックを入れる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCheckSet_Click(sender As Object, e As EventArgs) Handles BtnCheckSet.Click
        With SS.ActiveSheet
            If .RowCount > 0 Then
                Dim _FiltedRowindex As New List(Of Integer) 'フィルタリングされている行インデックス
                'フィルタされている行を調べる
                For i As Integer = 0 To .RowFilter.GetFilteredOutRowList.Count - 1
                    _FiltedRowindex.Add(.RowFilter.GetFilteredOutRowList().Item(i))
                Next

                Dim StartRow As Integer = -1
                Dim EndRow As Integer = -1

                If .Models.Selection.AnchorRow <> .Models.Selection.LeadRow Then
                    If .Models.Selection.AnchorRow > .Models.Selection.LeadRow Then
                        StartRow = .Models.Selection.LeadRow : EndRow = .Models.Selection.AnchorRow
                    Else
                        StartRow = .Models.Selection.AnchorRow : EndRow = .Models.Selection.LeadRow
                    End If
                Else
                    StartRow = 0 : EndRow = .RowCount - 1
                End If

                For Row As Integer = StartRow To EndRow
                    If _FiltedRowindex.IndexOf(Row) = -1 Then
                        Dim _Flg As Boolean = False
                        For Col As Integer = 1 To .ColumnCount - 1
                            If .Columns(Col).Visible AndAlso FG(.Cells(Row, Col).Value) <> "" Then
                                _Flg = True
                                Exit For
                            End If
                        Next
                        .Cells(Row, 0).Value = _Flg
                    End If
                Next
                _ColHerderChecked = True
            End If

        End With
        Call CheckRowCount()
    End Sub
    ''' <summary>
    ''' 全てにチェックを入れる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCheckSet_All_Click(sender As Object, e As EventArgs) Handles BtnCheckSet_All.Click
        With SS.ActiveSheet
            If .RowCount > 0 Then
                For Row As Integer = 0 To .RowCount - 1
                    .Cells(Row, 0).Value = True
                Next
            End If
        End With
        Call CheckRowCount()
    End Sub
    ''' <summary>
    ''' 全てにチェックを外す
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCheckDiset_Click(sender As Object, e As EventArgs) Handles BtnCheckDiset.Click
        With SS.ActiveSheet
            If .RowCount > 0 Then
                Dim _FiltedRowindex As New List(Of Integer) 'フィルタリングされている行インデックス
                'フィルタされている行を調べる
                For i As Integer = 0 To .RowFilter.GetFilteredOutRowList.Count - 1
                    _FiltedRowindex.Add(.RowFilter.GetFilteredOutRowList().Item(i))
                Next

                Dim StartRow As Integer = -1
                Dim EndRow As Integer = -1

                If .Models.Selection.AnchorRow <> .Models.Selection.LeadRow Then
                    If .Models.Selection.AnchorRow > .Models.Selection.LeadRow Then
                        StartRow = .Models.Selection.LeadRow : EndRow = .Models.Selection.AnchorRow
                    Else
                        StartRow = .Models.Selection.AnchorRow : EndRow = .Models.Selection.LeadRow
                    End If
                Else
                    StartRow = 0 : EndRow = .RowCount - 1
                End If

                For Row As Integer = StartRow To EndRow
                    If _FiltedRowindex.IndexOf(Row) = -1 Then
                        Dim _Flg As Boolean = False
                        For Col As Integer = 1 To .ColumnCount - 1
                            If .Columns(Col).Visible AndAlso FG(.Cells(Row, Col).Value) <> "" Then
                                _Flg = True
                                Exit For
                            End If
                        Next
                        .Cells(Row, 0).Value = Not _Flg
                    End If
                Next

                _ColHerderChecked = False
            End If
        End With
        Call CheckRowCount()
    End Sub
    ''' <summary>
    ''' データ未入力行にチェックを入れる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCheckSet_DedRow_Click(sender As Object, e As EventArgs) Handles BtnCheckSet_DedRow.Click
        With SS.ActiveSheet
            If .RowCount > 0 Then
                For Row As Integer = 0 To .RowCount - 1
                    Dim _Flg As Boolean = False
                    For Col As Integer = 1 To .ColumnCount - 1
                        If .Columns(Col).Visible AndAlso FG(.Cells(Row, Col).Value) <> "" Then
                            _Flg = True
                        End If
                    Next
                    .Cells(Row, 0).Value = Not _Flg
                Next
            End If
        End With
        Call CheckRowCount()
    End Sub
    ''' <summary>
    ''' 全データ削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDataDelete_Click(sender As Object, e As EventArgs) Handles BtnDataDelete.Click
        Try
            If MsgBox("全てのデータを削除してもいいですか？？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                If MsgBox("本当に削除してもいいですか？？", 4 + 32, "再確認") = MsgBoxResult.Yes Then
                    Try
                        _Starting = True
                        TabSelectedIndex = -1
                        Sql = "DELETE FROM TabData"
                        Using CMD As New OleDb.OleDbCommand(Sql, CN)
                            CMD.ExecuteNonQuery()
                        End Using
                        Sql = "DELETE FROM AddressData"
                        Using CMD As New OleDb.OleDbCommand(Sql, CN)
                            CMD.ExecuteNonQuery()
                        End Using

                        GcTabControl1.TabPages.Clear()
                        SS.ActiveSheet.RowCount = 0

                        If GcTabControl1.TabPages.Count = 0 Then
                            Call ZeroTab()
                        End If
                        GcTabControl1.SelectedIndex = 0
                        TabSelectedIndex = 0
                        _Starting = False
                        LblMessage.Text = "全てのデータを削除しました。"
                    Catch ex As Exception
                        MsgBox(ExMessCreater(GetStack(ex)), 48, "データ削除エラー")
                    End Try
                    Call CheckRowCount()
                    _IsEdit = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "データ削除エラー")
        End Try

    End Sub
    ''' <summary>
    ''' タブ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnTabMove_Click(sender As Object, e As EventArgs) Handles BtnTabMove.Click
        If GcTabControl1.TabPages.Count > 1 Then
            With FrmMoveTab
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    _Starting = True
                    Call LoadTab()
                    _Starting = False
                    _IsEdit = True
                End If
            End With
        End If
    End Sub
    ''' <summary>
    ''' タブ複写
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnTabCopy_Click(sender As Object, e As EventArgs) Handles BtnTabCopy.Click
        Dim _FromTab As LocalTabCollection = GcTabControl1.TabPages(TabSelectedIndex).Tag
        Dim _FromIndex As Integer = _FromTab.Index
        Dim _ToIndex As Integer = -1

        If MsgBox("このタブを複写してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            Try
                'タブの複写
                Sql = "SELECT * FROM TabData WHERE IndexNo=" & _FromIndex
                Using CMD_M As New OleDb.OleDbCommand(Sql, CN)
                    Using DR As OleDb.OleDbDataReader = CMD_M.ExecuteReader
                        If DR.Read Then
                            _ToIndex = NextNo(NextNoMode.TabNo)

                            Sql = "INSERT INTO TabData(IndexNo,TabName,UsePaperIndex,LabelText,MR) VALUES (@IndexNo,@TabName,@UsePaperIndex,@LabelText,@MR)"
                            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                                CMD.Parameters.Add(New OleDb.OleDbParameter("@IndexNo", OleDb.OleDbType.Integer))
                                CMD.Parameters.Add(New OleDb.OleDbParameter("@TabName", OleDb.OleDbType.Char))
                                CMD.Parameters.Add(New OleDb.OleDbParameter("@UsePaperIndex", OleDb.OleDbType.Integer))
                                CMD.Parameters.Add(New OleDb.OleDbParameter("@LabelText", OleDb.OleDbType.Char))
                                CMD.Parameters.Add(New OleDb.OleDbParameter("@MR", OleDb.OleDbType.Char))
                                CMD.Parameters("@IndexNo").Value = _ToIndex
                                CMD.Parameters("@TabName").Value = FG(DR("TabName")) & "(Copy)"
                                CMD.Parameters("@UsePaperIndex").Value = FG(DR("UsePaperIndex"), enum_FG.FG_Numeric)
                                CMD.Parameters("@LabelText").Value = FG(DR("LabelText"))
                                CMD.Parameters("@MR").Value = FG(DR("MR"))
                                CMD.ExecuteNonQuery()
                            End Using
                            Dim TB As New GrapeCity.Win.Containers.GcTabPage
                            Dim _T As New LocalTabCollection
                            _T.Index = _ToIndex
                            _T.UsePaperIndex = FG(DR("UsePaperIndex"), enum_FG.FG_Numeric)
                            _T.LabelText = FG(DR("LabelText"))
                            _T.MR = FG(DR("MR"))
                            TB.Text = FG(DR("TabName")) & "(Copy)"
                            TB.Tag = _T
                            GcTabControl1.TabPages.Add(TB)
                            GcTabControl1.SelectedIndex = GcTabControl1.TabPages.Count - 1
                        End If
                    End Using
                End Using

                If _ToIndex > -1 Then
                    'データの複写
                    Sql = String.Format("SELECT * FROM AddressData WHERE TabIndexNo={0}", _FromIndex)
                    Using CMD_F As New OleDb.OleDbCommand(Sql, CN)
                        Using DR As OleDb.OleDbDataReader = CMD_F.ExecuteReader
                            Dim Row As Integer = 0
                            Do While DR.Read
                                Sql = "INSERT INTO AddressData(TabIndexNo,RowNo,Field1,Field2,Field3,Field4,Field5,Field6,Field7,Field8,Field9,Field10,Field11,Field12,Field13,Field14,Field15,Field16,Field17,Field18,Field19,Field20) VALUES (@TabIndexNo,@RowNo,@Field1,@Field2,@Field3,@Field4,@Field5,@Field6,@Field7,@Field8,@Field9,@Field10,@Field11,@Field12,@Field13,@Field14,@Field15,@Field16,@Field17,@Field18,@Field19,@Field20)"
                                Using CMD As New OleDb.OleDbCommand(Sql, CN)
                                    CMD.Parameters.Add(New OleDb.OleDbParameter("@TabIndexNo", OleDb.OleDbType.Integer))
                                    CMD.Parameters.Add(New OleDb.OleDbParameter("@RowNo", OleDb.OleDbType.Integer))
                                    For i As Integer = 1 To 20
                                        CMD.Parameters.Add(New OleDb.OleDbParameter("@Field" & i.ToString, OleDb.OleDbType.Char))
                                    Next

                                    CMD.Parameters("@TabIndexNo").Value = _ToIndex
                                    CMD.Parameters("@RowNo").Value = FG(DR("RowNo"), enum_FG.FG_Numeric)
                                    For i As Integer = 1 To 20
                                        CMD.Parameters("@Field" & i.ToString).Value = FG(DR("Field" & i.ToString))
                                    Next
                                    CMD.ExecuteNonQuery()
                                End Using
                            Loop
                        End Using
                    End Using

                    Call LoadTabData()
                    LblMessage.Text = "タブ複写完了"
                    _IsEdit = True

                Else
                    MsgBox("タブ複写に失敗しました", 48, "タブ複写エラー")
                End If

            Catch ex As Exception
                MsgBox(ExMessCreater(GetStack(ex)), 48, "タブ複写エラー")
            End Try
        End If

    End Sub
  
    ''' <summary>
    ''' カーソル移動処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GoSSCursor()
        If GcTabControl1.TabPages.Count > 0 Then
            If _SeekIndex > -1 Then
                If _SeekedData.Count > 0 Then
                    Dim _TabFind As Boolean = False
                    Dim _Tab As Integer = _SeekedData(_SeekIndex).TabIndex
                    For i As Integer = 0 To GcTabControl1.TabPages.Count - 1
                        Dim _TB As LocalTabCollection = GcTabControl1.TabPages(i).Tag
                        If _TB.Index = _Tab Then
                            GcTabControl1.SelectedIndex = i
                            _TabFind = True
                            Exit For
                        End If
                    Next
                    If _TabFind Then
                        Dim Cols() As Integer = Nothing
                        If SPREAD_SerchCol(SS, _SeekedData(_SeekIndex).RowIndex, _SeekStr, Cols) > 0 Then
                            SS.ActiveSheet.SetActiveCell(_SeekedData(_SeekIndex).RowIndex, Cols(0))
                            SS.SetViewportTopRow(0, _SeekedData(_SeekIndex).RowIndex)
                            If SS.ActiveSheet.Columns(Cols(0)).Visible = False Then
                                SS.ActiveSheet.Columns(Cols(0)).Visible = True
                            End If

                            Call FlashExecute(_SeekedData(_SeekIndex).RowIndex, Cols(0)) '該当セルを点滅
                        End If
                    End If
                End If
            End If
        End If
    End Sub
#Region "検索結果該当セルを点滅させる"
    Dim WithEvents _FlashTimer As New Timer
    Dim _FlashPoint As Point
    Dim _FlashCount As Integer = 0
    ''' <summary>
    ''' 指定セルの点滅
    ''' </summary>
    ''' <param name="Row">セルの行番号</param>
    ''' <param name="Col">セルの列番号</param>
    ''' <remarks></remarks>
    Private Sub FlashExecute(Row As Integer, Col As Integer)
        If _FlashTimer.Enabled Then
            Call FlashCellDraw(False)
            _FlashTimer.Enabled = False
        End If
        _FlashTimer.Interval = 500
        _FlashPoint = New Point(Row, Col)
        _FlashCount = 0
        Call FlashCellDraw(True)
        _FlashTimer.Enabled = True
    End Sub
    Private Sub FlashTimer_Tick(sender As Object, e As EventArgs) Handles _FlashTimer.Tick
        Call FlashCellDraw(((_FlashCount Mod 2) = 1))
        _FlashCount += 1
        If _FlashCount > 4 Then
            _FlashTimer.Enabled = False
        End If
    End Sub
    Private Sub FlashCellDraw(Value As Boolean)
        With SS.ActiveSheet.Cells(_FlashPoint.X, _FlashPoint.Y)
            If Value Then
                .BackColor = Color.Blue : .ForeColor = Color.White
            Else
                .BackColor = Nothing : .ForeColor = Nothing
            End If
        End With
    End Sub
#End Region
    ''' <summary>
    ''' SPREAD行コピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRowCopy_Click(sender As Object, e As EventArgs) Handles BtnRowCopy.Click, CMSS_RowCopy.Click
        Dim _Old As Integer = SS.ActiveSheet.ActiveRowIndex
        Dim _New As Integer = SPREAD_InsertRow(SS, _Old)
        If _Old >= 0 AndAlso _New >= 0 Then
            With SS.ActiveSheet
                For Col As Integer = 0 To .ColumnCount - 1
                    .Cells(_New, Col).Value = .Cells(_Old, Col).Value
                Next
            End With
            _IsEdit = True

        End If
        Call CheckRowCount()

    End Sub
    ''' <summary>
    ''' SPREAD最下段にコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRowCopyLast_Click(sender As Object, e As EventArgs) Handles BtnRowCopyLast.Click, CMSS_RowCopyLast.Click
        If Not _DataLoding Then
            Dim _Old As Integer = SS.ActiveSheet.ActiveRowIndex
            Dim _New As Integer = SPREAD_InsertRow(SS)
            If _Old >= 0 AndAlso _New >= 0 Then
                With SS.ActiveSheet
                    For Col As Integer = 0 To .ColumnCount - 1
                        .Cells(_New, Col).Value = .Cells(_Old, Col).Value
                    Next
                End With
            End If
            Call CheckRowCount()
            _IsEdit = True

        End If
    End Sub
    Dim _ColHerderChecked As Boolean = False
    ''' <summary>
    ''' SPREADでソートを実行された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SS_AutoSortedColumn(sender As Object, e As FarPoint.Win.Spread.AutoSortedColumnEventArgs) Handles SS.AutoSortedColumn
        _IsEdit = True
    End Sub
    ''' <summary>
    ''' SPREADでデータが変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SS_EditChange(sender As Object, e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles SS.EditChange
        If e.Column > 0 Then
            _IsEdit = True
        End If
    End Sub
    ''' <summary>
    ''' SPREADで行がドラッグ移動された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SS_RowDragMoveCompleted(sender As Object, e As FarPoint.Win.Spread.DragMoveCompletedEventArgs) Handles SS.RowDragMoveCompleted
        _IsEdit = True
    End Sub
    ''' <summary>
    ''' チェックヘッダーをクリックして、チェックを入れたり・外したりする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SS_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles SS.CellClick
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left
                If e.ColumnHeader Then
                    If e.Column = 0 Then
                        If Not _ColHerderChecked Then
                            Call BtnCheckSet_Click(Nothing, Nothing)
                        Else
                            Call BtnCheckDiset_Click(Nothing, Nothing)
                        End If
                    End If
                Else
                End If
            Case Windows.Forms.MouseButtons.Middle
                SS.ZoomFactor = 1
        End Select
    End Sub
    ''' <summary>
    ''' アクテイブセルの内容を右セルにコピーします
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SS_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles SS.CellDoubleClick
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Middle
                If Not e.ColumnHeader Then
                    If Not e.RowHeader Then
                        Dim Row As Integer = e.Row
                        With SS.ActiveSheet
                            Dim AcRow As Integer = .ActiveRowIndex
                            Dim AcCol As Integer = .ActiveColumnIndex
                            If Row = AcRow Then
                                If AcCol < .ColumnCount - 1 Then
                                    If .Columns(AcCol + 1).Visible Then
                                        .Cells(AcRow, AcCol + 1).Value = .Cells(AcRow, AcCol).Value
                                        _IsEdit = True
                                    Else
                                        MsgBox("コピー先の右列がありません", 48, "エラー")
                                    End If
                                End If
                            Else
                                MsgBox("アクティブ行とダブルクリックされた行が異なります", 48, "コピーキャンセル")
                            End If
                        End With
                    End If
                End If

        End Select
    End Sub
    ''' <summary>
    ''' 入力モードがOFFになった
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SS_EditModeOff(sender As Object, e As EventArgs) Handles SS.EditModeOff
        If Not _DataLoding Then
            Dim chkcell As FarPoint.Win.FpCheckBox
            Dim iRow As Integer = SS.ActiveSheet.ActiveRowIndex
            Dim iCol As Integer = SS.ActiveSheet.ActiveColumnIndex
            If TypeOf (SS.ActiveSheet.GetCellType(iRow, iCol)) Is FarPoint.Win.Spread.CellType.CheckBoxCellType Then
                'イベントハンドラ関連付け解除
                chkcell = CType(SS.EditingControl, FarPoint.Win.FpCheckBox)

                RemoveHandler chkcell.CheckChanged, AddressOf chkcell_CheckChanged
            End If
        End If
    End Sub
    ''' <summary>
    ''' 入力モードがONになった
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SS_EditModeOn(sender As Object, e As EventArgs) Handles SS.EditModeOn
        SS.EditingControl.ContextMenu = New ContextMenu

        Dim chkcell As FarPoint.Win.FpCheckBox
        Dim iRow As Integer = SS.ActiveSheet.ActiveRowIndex
        Dim iCol As Integer = SS.ActiveSheet.ActiveColumnIndex
        If TypeOf (SS.ActiveSheet.GetCellType(iRow, iCol)) Is FarPoint.Win.Spread.CellType.CheckBoxCellType Then
            chkcell = CType(SS.EditingControl, FarPoint.Win.FpCheckBox)
            'イベントハンドラ関連付け
            AddHandler chkcell.CheckChanged, AddressOf chkcell_CheckChanged
        End If
    End Sub
    Private Sub chkcell_CheckChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Call CheckRowCount()
    End Sub

    ''' <summary>
    ''' コンテキストメニューの表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SS_MouseDown(sender As Object, e As MouseEventArgs) Handles SS.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim value As FarPoint.Win.Spread.HitTestInformation = SS.HitTest(e.X, e.Y)
            If IsNothing(value.HeaderInfo) Then
                If IsNothing(value.ViewportInfo) Then
                    LblColWidth.Visible = False
                Else
                    LblColWidth.Visible = True
                    LblColWidth.Text = String.Format("選択列幅：{0}", SS.ActiveSheet.Columns(value.ViewportInfo.Column).Width)
                End If
            Else
                LblColWidth.Visible = True
                LblColWidth.Text = String.Format("選択列幅：{0}", SS.ActiveSheet.Columns(value.HeaderInfo.Column).Width)
            End If

            ConMenuSS.Show(SS, e.Location)
        End If
    End Sub
    ''' <summary>
    ''' 郵便番号検索処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SS_LeaveCell(sender As Object, e As FarPoint.Win.Spread.LeaveCellEventArgs) Handles SS.LeaveCell
        Dim Row As Integer = e.Row
        Try
            If My.Settings.AutoZipConvert Then
                With SS.ActiveSheet
                    If SPREAD_GetCellType(SS, Row, e.Column) = enumSPREADCellType.Mask Then
                        Dim _ColAddress As Integer = -1

                        Dim _TabData As LocalTabCollection = GcTabControl1.SelectedTab.Tag
                        Dim _Paper As ClassPaperCollection = PaperArray(_TabData.UsePaperIndex)
                        For i As Integer = 2 To _Paper.Section.FieldData.Count - 1
                            If _Paper.Section.FieldData(i).FieldUseType = 2 Then
                                _ColAddress = i - 1
                            End If
                        Next
                        If _ColAddress > -1 Then
                            Dim InputZip As String = .Cells(Row, _ColAddress).Value '.ToString.Trim
                            If InputZip = "" Then
                                Dim _Zip As String = Replace(FG(.Cells(Row, e.Column).Value), "-", "")
                                If _Zip <> "" AndAlso _Zip.IndexOf("_") = -1 Then
                                    Try
                                        Sql = String.Format("SELECT Address FROM ZipData WHERE ZipCode='{0}'", _Zip)
                                        Using CMD As New OleDb.OleDbCommand(Sql, CN_Zip)
                                            Using DR As OleDb.OleDbDataReader = CMD.ExecuteReader
                                                If DR.Read Then
                                                    .Cells(Row, _ColAddress).Value = FG(DR("Address"))
                                                    _IsEdit = True
                                                End If
                                            End Using
                                        End Using
                                    Catch ex As Exception
                                        MsgBox(ex.Message, 48, "SS_LeaveCell")
                                    End Try

                                End If
                            End If
                        End If
                    End If
                End With
            End If
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex), "郵便番号検索に失敗しました"), 48, "エラー")
        End Try

    End Sub
    ''' <summary>
    ''' 設定画面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSetting_Click(sender As Object, e As EventArgs) Handles BtnSetting.Click
        With FrmSetting
            If .ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
        End With
    End Sub
    ''' <summary>
    ''' 用紙リスト編集
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnPaperListEdit_Click(sender As Object, e As EventArgs) Handles BtnPaperListEdit.Click
        With FrmPaperList
            If .ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
        End With
    End Sub
    ''' <summary>
    ''' 保存ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        LblMessage.Text = "データ保存中..."
        Application.DoEvents()
        Call SaveTab()
        LblMessage.Text = "データを保存しました"
        _IsEdit = False

    End Sub
    ''' <summary>
    ''' 印刷プレビュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles BtnPreview.Click
        If C1Sizer1.Grid.Columns(2).Size = 0 Then
            Call BtnNoPreview_Click(Nothing, Nothing)
        End If

    '注意書きのコピー
    Dim Cols As New List(Of Integer)

        With SS.ActiveSheet
            Cols = CheckNoteCol()
            If Cols.Count > 0 Then
                If TxtNote.Text <> "" Then
                    For Row As Integer = 0 To .RowCount - 1
                        If FG(.Cells(Row, 0).Value, enum_FG.FG_Boolean) Then
                            For Each Col As Integer In Cols
                                .Cells(Row, Col).Value = TxtNote.Text
                            Next
                        End If
                    Next
                End If
            End If

            If .RowCount = 0 Then
                Return
            End If

    'ナンバー文字({NO})を検索して、ダイアログを表示する
    Dim _PrintChecked As Boolean = False
    Dim _NumberStringFind As Boolean = False
            For Row As Integer = 0 To .RowCount - 1
                If FG(.Cells(Row, 0).Value, enum_FG.FG_Boolean) = True Then
                    _PrintChecked = True
                    For Col As Integer = 1 To .ColumnCount - 1
                        If .Columns(Col).Visible Then
                            If FG(.Cells(Row, Col).Value).ToString.IndexOf(_NumberString) > -1 Then
                                _NumberStringFind = True
                                Exit For
                            End If
                        End If
                    Next
                    If _NumberStringFind Then Exit For
                End If
            Next

            If Not _PrintChecked Then
                LblMessage.Text = "【エラー】タックを発行する為の宛先が１つも選択されていません"
                Return
            End If
            If _NumberStringFind Then
                With FrmNumber
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        _NumberStartNo = .StartNo
                        If .AddZero > 0 Then
                            _NumberFrontZero = .AddZero
                        Else
                            _NumberFrontZero = 0
                        End If
                        _NumberTackGoto = .TackGoto
                    Else
                        Return
                    End If
                End With
            End If

            Call CreatePerview() '印刷プレビューを開始

    '注意書きフィールドのクリア
            For Row As Integer = 0 To .RowCount - 1
                For Each Col As Integer In Cols
                    .Cells(Row, Col).Value = ""
                Next
            Next
            LblMessage.Text = ""
        End With

    End Sub
    ''' <summary>
    ''' 注意書きカラムを探します
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckNoteCol() As List(Of Integer)
        Dim _Ret As New List(Of Integer)
        With SS.ActiveSheet
            If .RowCount > 0 Then
                For Col As Integer = 1 To .ColumnCount - 1
                    'If .Columns(Col).Visible AndAlso .Columns(Col).Locked Then
                    If .Columns(Col).Locked Then
                        _Ret.Add(Col)
                    End If
                Next
            End If
        End With
        Return _Ret
    End Function
    ''' <summary>
    ''' ステータスバーへ情報を書き込む
    ''' </summary>
    ''' <param name="Dat"></param>
    ''' <remarks></remarks>
    Private Sub StatPaperInfoSet(Dat As ClassPaperCollection)
        If Dat.Section.ColumnCount > 1 OrElse Dat.Section.RowCount > 1 Then
            BtnSelTack.Enabled = True
        Else
            BtnSelTack.Enabled = False
        End If
        StatLabel_Seet.Text = Dat.Text
        StatLabel_Maker.Text = Dat.MakerName
        StatLabel_Model.Text = Dat.Name
        StatLabel_Size.Text = PaperInfo_FindPaperName(Dat.PaperSize)
        StatLabel_Tack.Text = String.Format("{0}X{1}", Dat.Section.ColumnCount, Dat.Section.RowCount)
    End Sub
    ''' <summary>
    ''' 幅基準ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnPreviewWide_Click(sender As Object, e As EventArgs) Handles BtnPreviewWide.Click
        Call PageZoom(enumPageZoom.PaperWidth)
    End Sub
    ''' <summary>
    ''' 全体表示ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnPreviewAll_Click(sender As Object, e As EventArgs) Handles BtnPreviewAll.Click
        Call PageZoom(enumPageZoom.PaperAll)
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        C1Sizer2.Grid.Rows(1).Size = 28
    End Sub
    ''' <summary>
    ''' 行数のカウント
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckRowCount()
        Dim SelCount As Integer = 0
        LblRowCount.Text = String.Format("{0} 行", SS.ActiveSheet.RowCount.ToString)
        With SS.ActiveSheet
            If .RowCount > 0 Then
                For Row As Integer = 0 To .RowCount - 1
                    If FG(.Cells(Row, 0).Value, enum_FG.FG_Boolean) = True Then
                        SelCount += 1
                    End If
                Next
            End If
        End With
        LblSelCount.Text = String.Format("{0} 行", SelCount.ToString)
    End Sub
    ''' <summary>
    ''' 印刷プレビュー内検索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnReportScan_Click(sender As Object, e As EventArgs) Handles BtnReportScan.Click
        Viewer1.ShowFindDialog()
    End Sub
    ''' <summary>
    ''' クリップボードデータの展開
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExcel_Load_Click(sender As Object, e As EventArgs) Handles BtnClipboad_Load.Click
        Dim data As IDataObject = Clipboard.GetDataObject()
        If Not data Is Nothing Then
            'DataFormats.Textに関連付けられたデータがあるか調べる
            If data.GetDataPresent(DataFormats.Text) = False Then
                MsgBox("クリップボードに貼り付け可能な文字列データがありません", 48, "エラー")
                Return
            End If
        Else
            MsgBox("クリップボードにデータがありません", 48, "エラー")
            Return
        End If

        Dim _Data As String = Clipboard.GetText()
        If _Data <> "" Then
            Dim _Datas() As String = _Data.Split(vbCrLf)
            If _Datas.Length > 0 Then
                If MsgBox("クリップボードのデータを追加してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                    Try
                        For Y As Integer = 0 To _Datas.Length - 1
                            Dim Row As Integer = SPREAD_InsertRow(SS)
                            Dim X As Integer = 0
                            Dim _Dat() As String = _Datas(Y).Split(vbTab)
                            For Col As Integer = 1 To SS.ActiveSheet.ColumnCount - 1
                                If SS.ActiveSheet.Columns(Col).Visible Then
                                    If X < _Dat.Length Then
                                        Dim _T As String = Replace(Replace(_Dat(X), vbCrLf, ""), vbLf, "")
                                        SS.ActiveSheet.Cells(Row, Col).Value = _T
                                        X += 1
                                    End If
                                End If
                            Next
                        Next
                    Catch ex As Exception
                        'MsgBox(ex.Message, 48, "BtnCSV_Load_Click")
                        MsgBox(ExMessCreater(GetStack(ex)), 48, "クリップボード操作エラー")
                    End Try
                End If
            End If

        End If
    End Sub
    ''' <summary>
    ''' Exxcel形式で保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExcel_Save_Click(sender As Object, e As EventArgs) Handles BtnExcel_Save.Click
        Dim ExcelTitle As String = GcTabControl1.TabPages(TabSelectedIndex).Text

        If ExcelTitle = "" Then
            ExcelTitle = "UnTitle.xlsx"
        Else
            ExcelTitle = String.Format("{0}.xlsx", ExcelTitle)
        End If
        Call SPREAD2Excel(SS, ExcelTitle)
    End Sub
    ''' <summary>
    ''' アクティベーションキー変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnLicence_Click(sender As Object, e As EventArgs)
        If MsgBox("アクティベーションキーを変更すると起動しなくなる場合があります", 4 + 32, "変更しますか？") = MsgBoxResult.Yes Then
            With FrmLicense
                .ScrrenMode = FrmLicense.enumScreenMode.ModeEdit
                If .ShowDialog = DialogResult.OK Then
                Else
                End If
            End With
        End If
    End Sub

    Private Sub BtnDataFile_Click(sender As Object, e As EventArgs) Handles BtnDataFile.Click
        FrmDataFolder.ShowDialog()
    End Sub

    Private Sub StatLabel_Seet_Click(sender As Object, e As EventArgs) Handles StatLabel_Seet.Click
        Dim _TabDat As LocalTabCollection = GcTabControl1.SelectedTab.Tag
        Dim PaperItem As ClassPaperCollection = PaperArray(_TabDat.UsePaperIndex)
        With FrmpaperInfo
            .PaperDat = PaperItem
            .ShowDialog()
        End With
    End Sub

    Private Sub ChkPreviewFrame_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPreviewFrame.CheckedChanged
        Call BtnPreview_Click(Nothing, Nothing)
    End Sub
    Private Sub ChkPreviewFrame2_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPreviewFrame2.CheckedChanged
        Call BtnPreview_Click(Nothing, Nothing)
    End Sub
    Private Sub BtnOutPDF_Click(sender As Object, e As EventArgs) Handles BtnOutPDF.Click
        Dim SFD As New System.Windows.Forms.SaveFileDialog
        With SFD
            .AddExtension = True
            .CheckPathExists = True
            .DefaultExt = ".pdf"
            .FileName = "Untitled.pdf"
            .Filter = "PDFファイル(*.pdf)|*.pdf"
            .FilterIndex = 1
            .OverwritePrompt = True
            .RestoreDirectory = True
            .Title = "PDFファイル保存"
            .ShowHelp = True
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.AppStarting
                Application.DoEvents()
                Try
                    PdfExport1.Export(Viewer1.Document, .FileName)
                    MsgBox("PDFファイルを出力しました。", 64, "情報")
                Catch ex As Exception
                    'MsgBox(ex.Message, 48, "PDFファイル出力エラー")
                    MsgBox(ExMessCreater(GetStack(ex)), 48, "PDFファイル出力エラー")
                End Try
                Me.Cursor = Cursors.Default
            End If
        End With
        SFD.Dispose()
    End Sub
    ''' <summary>
    ''' ヘルプ表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnHelp_Click(sender As Object, e As EventArgs) Handles BtnHelp.Click
        Dim _FL As String = AppFullPath("helptext.txt")
        If System.IO.File.Exists(_FL) Then
            Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(_FL)
        End If
    End Sub

    Dim _PWSize As Integer = 0
    ''' <summary>
    ''' プレビュー表示・非表示切り替え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnNoPreview_Click(sender As Object, e As EventArgs) Handles BtnNoPreview.Click
        If C1Sizer1.Grid.Columns(2).Size = 0 Then
            C1Sizer1.Grid.Columns(2).Size = _PWSize
            BtnNoPreview.Text = "PV非表示"
        Else
            _PWSize = C1Sizer1.Grid.Columns(2).Size
            C1Sizer1.Grid.Columns(2).Size = 0
            BtnNoPreview.Text = "PV表示"
        End If
    End Sub
    ''' <summary>
    ''' 全面印刷用枚数セット
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnFullPrint_Click(sender As Object, e As EventArgs) Handles BtnFullPrint.Click
        Dim _TabTag As LocalTabCollection = GcTabControl1.TabPages(TabSelectedIndex).Tag
        Dim No As Integer = _TabTag.Index
        Dim PIndex As Integer = _TabTag.UsePaperIndex
        Dim _P As ClassPaperCollection = PaperArray(PIndex)
        Dim Su As Integer = _P.Section.ColumnCount * _P.Section.RowCount
        If TxtBusu.Text = Su.ToString Then
            TxtBusu.Text = "1"
        Else
            TxtBusu.Text = _P.Section.ColumnCount * _P.Section.RowCount
        End If

    End Sub
    ''' <summary>
    ''' データ置き換え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    'Private Sub BtnDataReplace_Click(sender As Object, e As EventArgs) Handles BtnDataReplace.Click
    '    If SS.ActiveSheet.RowCount = 0 Then
    '        Return
    '    End If

    '    Dim ARow As Integer = SS.ActiveSheet.ActiveRowIndex
    '    Dim ACol As Integer = SS.ActiveSheet.ActiveColumnIndex

    '    Dim _WorkMode As Boolean = False
    '    Dim _FromText As String = ""
    '    Dim _ToText As String = ""
    '    Dim _Cap As Boolean = False
    '    Dim _ToWide As Boolean = False
    '    Dim _WorkAria As Integer = 0
    '    With FrmDataReplace
    '        If IsSSChecked() Then
    '            'チェックが入っていたらチェック範囲に設定する
    '            .WorkAria = 4
    '        ElseIf SS.ActiveSheet.Models.Selection.AnchorRow <> SS.ActiveSheet.Models.Selection.LeadRow OrElse _
    '                SS.ActiveSheet.Models.Selection.AnchorColumn <> SS.ActiveSheet.Models.Selection.LeadColumn Then
    '            '範囲選択されていたら、オプションを範囲に設定する
    '            .WorkAria = 5
    '        End If

    '        If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '            _FromText = .FromText
    '            _ToText = .ToText
    '            _Cap = .SepCapString
    '            _WorkMode = .IsStringChangeMode
    '            _ToWide = .IsToWide
    '            _WorkAria = .WorkAria
    '        Else
    '            Return
    '        End If
    '    End With

    '    Dim StartRow As Integer = 0 : Dim StartCol As Integer = 0
    '    Dim EndRow As Integer = 0 : Dim EndCol As Integer = 0
    '    Dim CheckRow As Boolean = False

    '    Select Case _WorkAria
    '        Case 1
    '            If MsgBox("選択行の文字列置換を行っていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
    '                Return
    '            End If
    '            StartRow = ARow : EndRow = ARow
    '            StartCol = 1 : EndCol = SS.ActiveSheet.ColumnCount - 1
    '        Case 2
    '            If ACol = 0 Then
    '                MsgBox("選択列の作業は出来ません", 48, "エラー")
    '                Return
    '            End If
    '            If MsgBox("選択列の文字列置換を行っていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
    '                Return
    '            End If
    '            StartRow = 0 : EndRow = SS.ActiveSheet.RowCount - 1
    '            StartCol = ACol : EndCol = ACol
    '        Case 3
    '            If MsgBox("シート全体の文字列置換を行っていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
    '                Return
    '            End If
    '            StartRow = 0 : EndRow = SS.ActiveSheet.RowCount - 1
    '            StartCol = 1 : EndCol = SS.ActiveSheet.ColumnCount - 1
    '        Case 4
    '            If MsgBox("チェック付き行の文字列置換を行っていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
    '                Return
    '            End If
    '            StartRow = 0 : EndRow = SS.ActiveSheet.RowCount - 1
    '            StartCol = 1 : EndCol = SS.ActiveSheet.ColumnCount - 1
    '            CheckRow = True
    '        Case 5
    '            If MsgBox("選択範囲の文字列置換を行っていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
    '                Return
    '            End If

    '            With SS.ActiveSheet.Models.Selection
    '                If .AnchorRow > .LeadRow Then
    '                    StartRow = .LeadRow : EndRow = .AnchorRow
    '                Else
    '                    StartRow = .AnchorRow : EndRow = .LeadRow
    '                End If
    '                If .AnchorColumn > .LeadColumn Then
    '                    StartCol = .LeadColumn : EndCol = .AnchorColumn
    '                Else
    '                    StartCol = .AnchorColumn : EndCol = .LeadColumn
    '                End If
    '            End With

    '        Case Else
    '            If ACol = 0 Then
    '                MsgBox("選択セルの作業は出来ません", 48, "エラー")
    '                Return
    '            End If

    '            If MsgBox("選択セルの文字列置換を行っていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
    '                Return
    '            End If
    '            StartRow = ARow : EndRow = ARow
    '            StartCol = ACol : EndCol = ACol
    '    End Select


    '    For Row As Integer = StartRow To EndRow
    '        For Col As Integer = StartCol To EndCol
    '            Dim _T As String = SS.ActiveSheet.Cells(Row, Col).Value

    '            'チェック行の変換の場合、チェックが入っていなかったら対象文字をクリアにする
    '            If CheckRow Then
    '                If SS.ActiveSheet.Cells(Row, 0).Value = False Then
    '                    _T = ""
    '                End If
    '            End If

    '            If _T <> "" Then
    '                Try
    '                    If _WorkMode Then
    '                        '文字変換
    '                        Dim R2 As String = ""
    '                        If _Cap Then
    '                            '大文字と小文字を区別する
    '                            R2 = Replace(_T, _FromText, _ToText)
    '                        Else
    '                            'Dim r2 As String = StringReplace(_T, _FMoji, _TMoji, -1, True)
    '                            R2 = System.Text.RegularExpressions.Regex.Replace(_T, _FromText, _ToText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    '                        End If
    '                        SS.ActiveSheet.Cells(Row, Col).Value = R2
    '                        _IsEdit = True
    '                    Else
    '                        Dim Flg As Boolean = False
    '                        Select Case GetColType(Col)
    '                            Case 0 '一般フィールド0
    '                                Flg = True
    '                            Case 1 '郵便番号フィールド1
    '                            Case 2 '住所フィールド2
    '                                Flg = True
    '                            Case 3 '名前フィールド3
    '                                Flg = True
    '                            Case Else '注意書きフィールド4
    '                        End Select
    '                        If Flg Then
    '                            '全角・半角の変換
    '                            Dim _W As String = ""
    '                            If _ToWide Then
    '                                _W = StrConv(_T, VbStrConv.Wide)
    '                            Else
    '                                _W = StrConv(_T, VbStrConv.Narrow)
    '                            End If
    '                            SS.ActiveSheet.Cells(Row, Col).Value = _W
    '                            _IsEdit = True
    '                        End If

    '                    End If

    '                Catch ex As Exception

    '                End Try
    '            End If

    '        Next
    '    Next
    '    If _WorkMode Then
    '        LblMessage.Text = "文字置換完了"
    '    Else
    '        LblMessage.Text = "全半角変換完了"
    '    End If

    'End Sub
    ''' <summary>
    ''' SPREADに１つでもチェックが入っているか確認
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsSSChecked() As Boolean
        If SS.ActiveSheet.RowCount > 0 Then
            For Row As Integer = 0 To SS.ActiveSheet.RowCount - 1
                If FG(SS.ActiveSheet.Cells(Row, 0).Value, enum_FG.FG_Boolean) Then
                    Return True
                End If
            Next
            Return False
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' 指定列の使用用途
    ''' </summary>
    ''' <param name="ColIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetColType(ColIndex As Integer) As Integer
        Dim _TabData As LocalTabCollection = GcTabControl1.SelectedTab.Tag
        Dim _Paper As ClassPaperCollection = PaperArray(_TabData.UsePaperIndex)

        Dim Item As ClassFieldCollection = _Paper.Section.FieldData(ColIndex + 1)
        Return Item.FieldUseType
    End Function
    ''' <summary>
    ''' タブ情報編集
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TabControlEx1_DoubleClick(sender As Object, e As EventArgs) Handles GcTabControl1.MouseDoubleClick
        Call BtnTabEdit_Click(Nothing, Nothing)
    End Sub
    Dim _MouseButtonStat As Boolean = False 'タブ操作時のマウス状態

    Private Sub GcTabControl1_MouseDown(sender As Object, e As MouseEventArgs) Handles GcTabControl1.MouseDown
        _MouseButtonStat = True
    End Sub

    Private Sub GcTabControl1_MouseUp(sender As Object, e As MouseEventArgs) Handles GcTabControl1.MouseUp
        _MouseButtonStat = False
    End Sub
    ''' <summary>
    ''' タブが変更された
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GcTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GcTabControl1.SelectedIndexChanged
        If Not _Starting Then
            If _MouseButtonStat Then
                'マウスボタンが押したままSelectedならドラッグ
                Call TabFDrag()
            Else
                Call TabSelect()
            End If
            TabSelectedIndex = GcTabControl1.SelectedIndex
        End If
    End Sub
    ''' <summary>
    ''' タブ選択
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TabSelect()
        If Not _Starting Then
            If Not _NoSave Then
                Call SaveTab() '既存データ保存
            End If
            TxtBusu.Value = 1

            TabSelectedIndex = GcTabControl1.SelectedIndex '選択中タブインデックス更新
            If Not _NoLoad Then
                Call LoadTabData() '新しいタブのデータ読込
            End If
        End If
    End Sub
    ''' <summary>
    ''' タブ移動
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TabFDrag()
        Dim FromIndex As Integer = TabSelectedIndex
        Dim ToIndex As Integer = GcTabControl1.SelectedIndex
        If FromIndex <> ToIndex Then
            Try
                Dim LblName As String = GcTabControl1.TabPages(TabSelectedIndex).Text

                Sql = "UPDATE TabData SET IndexNo=0-IndexNo-100"
                Using CMD As New OleDb.OleDbCommand(Sql, CN)
                    CMD.ExecuteNonQuery()
                End Using
                Sql = "UPDATE AddressData SET TabIndexNo=0-TabIndexNo-100"
                Using CMD As New OleDb.OleDbCommand(Sql, CN)
                    CMD.ExecuteNonQuery()
                End Using

                For i As Integer = 0 To GcTabControl1.TabCount - 1
                    Dim _M As Integer = DirectCast(GcTabControl1.TabPages(i).Tag, LocalTabCollection).Index

                    Sql = String.Format("UPDATE TabData SET IndexNo={0} WHERE IndexNo=0-{1}-100", i, _M)
                    Using CMD As New OleDb.OleDbCommand(Sql, CN)
                        CMD.ExecuteNonQuery()
                    End Using
                    Sql = String.Format("UPDATE AddressData SET TabIndexNo={0} WHERE TabIndexNo=0-{1}-100", i, _M)
                    Using CMD As New OleDb.OleDbCommand(Sql, CN)
                        CMD.ExecuteNonQuery()
                    End Using

                Next

                For i As Integer = 0 To GcTabControl1.TabCount - 1
                    Dim _T As LocalTabCollection = DirectCast(GcTabControl1.TabPages(i).Tag, LocalTabCollection)
                    _T.Index = i
                    GcTabControl1.TabPages(i).Tag = _T
                Next
                '_SelectedTabIndex = -1
                LblMessage.Text = String.Format("[{0}]タブを移動しました", GcTabControl1.SelectedTab.Text)
                _IsEdit = True
            Catch ex As Exception
                MsgBox(ExMessCreater(GetStack(ex)), 48, "タブ移動エラー")
            End Try

        End If
    End Sub

    ''' <summary>
    ''' タブ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMT_Move_Click(sender As Object, e As EventArgs) Handles CMT_Move.Click
        Call BtnTabMove_Click(Nothing, Nothing)
    End Sub


    Private Sub CmbBackText_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBackText.SelectedIndexChanged
        _IsEdit = True
    End Sub

    Private Sub CmbBackText_TextChanged(sender As Object, e As EventArgs) Handles CmbBackText.TextChanged
        _IsEdit = True
    End Sub

    Private Sub TxtNote_TextChanged(sender As Object, e As EventArgs) Handles TxtNote.TextChanged
        _IsEdit = True
    End Sub

    Private Sub C1Sizer1_SplitterMoved(sender As Object, e As C1.Win.C1Sizer.C1SizerEventArgs) Handles C1Sizer1.SplitterMoved
        If _Starting = False Then
            If C1Sizer1.Grid.Columns(1).Size = 0 Then
                BtnNoPreview.Text = "PV表示"
            Else
                BtnNoPreview.Text = "PV非表示"
            End If
        End If
    End Sub
  
    ''' <summary>
    ''' 値を右のセルにコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMSS_CopyRight_Click(sender As Object, e As EventArgs) Handles CMSS_CopyRight.Click, BtnCopyValue_Right.Click
        With SS.ActiveSheet
            If .RowCount > 0 Then
                If .Columns(.ActiveColumnIndex + 1).Visible = False Then
                    MsgBox("最終列が選択されています。", 48, "エラー")
                    Return
                End If
                If .ActiveColumnIndex <= 0 Then
                    MsgBox("選択列が正しくありません", 48, "エラー")
                    Return
                End If

                Dim CheckFLG As Boolean = False
                Dim StartRow, EndRow As Integer
                Dim Col As Integer = .ActiveColumnIndex

                For Row As Integer = 0 To .RowCount - 1
                    Dim FLG As Boolean = .Cells(Row, 0).Value
                    If FLG Then
                        CheckFLG = True
                        Exit For
                    End If
                Next

                If Not CheckFLG Then
                    If .Models.Selection.AnchorRow <> .Models.Selection.LeadRow Then
                        If .Models.Selection.AnchorRow > .Models.Selection.LeadRow Then
                            StartRow = .Models.Selection.LeadRow : EndRow = .Models.Selection.AnchorRow
                        Else
                            StartRow = .Models.Selection.AnchorRow : EndRow = .Models.Selection.LeadRow
                        End If
                    Else
                        StartRow = -1 : EndRow = -1
                    End If
                End If

                If CheckFLG Then
                    If MsgBox("チェック行の選択列値を右列にコピーしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                        For Row As Integer = 0 To .RowCount - 1
                            Dim FLG As Boolean = .Cells(Row, 0).Value
                            If FLG Then
                                .Cells(Row, Col + 1).Value = .Cells(Row, Col).Value
                            End If
                        Next
                    End If
                Else
                    If StartRow = -1 Then
                        If MsgBox("選択セル値を右列にコピーしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                            Dim Row As Integer = .ActiveRowIndex
                            .Cells(Row, Col + 1).Value = .Cells(Row, Col).Value
                        End If
                    Else
                        If MsgBox("選択列値を右列にコピーしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                            For Row As Integer = StartRow To EndRow
                                .Cells(Row, Col + 1).Value = .Cells(Row, Col).Value
                            Next
                        End If

                    End If
                End If

            End If
        End With
    End Sub
    ''' <summary>
    ''' 値を左のセルにコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMSS_CopyLeft_Click(sender As Object, e As EventArgs) Handles CMSS_CopyLeft.Click, BtnCopyValue_Left.Click
        With SS.ActiveSheet
            If .RowCount > 0 Then
                If .ActiveColumnIndex <= 1 Then
                    MsgBox("選択列が正しくありません", 48, "エラー")
                    Return
                End If

                Dim CheckFLG As Boolean = False
                Dim StartRow, EndRow As Integer
                Dim Col As Integer = .ActiveColumnIndex

                For Row As Integer = 0 To .RowCount - 1
                    Dim FLG As Boolean = .Cells(Row, 0).Value
                    If FLG Then
                        CheckFLG = True
                        Exit For
                    End If
                Next

                If Not CheckFLG Then
                    If .Models.Selection.AnchorRow <> .Models.Selection.LeadRow Then
                        If .Models.Selection.AnchorRow > .Models.Selection.LeadRow Then
                            StartRow = .Models.Selection.LeadRow : EndRow = .Models.Selection.AnchorRow
                        Else
                            StartRow = .Models.Selection.AnchorRow : EndRow = .Models.Selection.LeadRow
                        End If
                    Else
                        StartRow = -1 : EndRow = -1
                    End If
                End If

                If CheckFLG Then
                    If MsgBox("チェック行の選択列値を左列にコピーしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                        For Row As Integer = 0 To .RowCount - 1
                            Dim FLG As Boolean = .Cells(Row, 0).Value
                            If FLG Then
                                .Cells(Row, Col - 1).Value = .Cells(Row, Col).Value
                            End If
                        Next
                    End If
                Else
                    If StartRow = -1 Then
                        If MsgBox("選択セル値を左列にコピーしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                            Dim Row As Integer = .ActiveRowIndex
                            .Cells(Row, Col - 1).Value = .Cells(Row, Col).Value
                        End If
                    Else
                        If MsgBox("選択列値を左列にコピーしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                            For Row As Integer = StartRow To EndRow
                                .Cells(Row, Col - 1).Value = .Cells(Row, Col).Value
                            Next
                        End If

                    End If
                End If

            End If
        End With
    End Sub
    ''' <summary>
    ''' DELキーで選択範囲を削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SS_KeyDown(sender As Object, e As KeyEventArgs) Handles SS.KeyDown
        If e.KeyCode = Keys.Delete Then
            With SS.ActiveSheet
                If .RowCount > 0 Then

                    Dim StartRow, EndRow As Integer
                    Dim StartCol, EndCol As Integer

                    If .Models.Selection.AnchorRow <> .Models.Selection.LeadRow Then
                        If .Models.Selection.AnchorRow > .Models.Selection.LeadRow Then
                            StartRow = .Models.Selection.LeadRow : EndRow = .Models.Selection.AnchorRow
                        Else
                            StartRow = .Models.Selection.AnchorRow : EndRow = .Models.Selection.LeadRow
                        End If
                    Else
                        StartRow = .Models.Selection.AnchorRow : EndRow = .Models.Selection.AnchorRow
                    End If

                    If .Models.Selection.AnchorColumn <> .Models.Selection.LeadColumn Then
                        If .Models.Selection.AnchorColumn > .Models.Selection.LeadColumn Then
                            StartCol = .Models.Selection.LeadColumn : EndCol = .Models.Selection.AnchorColumn
                        Else
                            StartCol = .Models.Selection.AnchorColumn : EndCol = .Models.Selection.LeadColumn
                        End If
                    Else
                        StartCol = .Models.Selection.AnchorColumn : EndCol = .Models.Selection.AnchorColumn
                    End If

                    For Row As Integer = StartRow To EndRow
                        For Col As Integer = StartCol To EndCol
                            .Cells(Row, Col).Value = ""
                        Next
                    Next
                End If
            End With
        End If
    End Sub
#Region "データ照合チェック"


    ''' <summary>
    ''' データ照合チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCheckSet_VirifaiCheck_Click(sender As Object, e As EventArgs) Handles BtnCheckSet_VirifaiCheck.Click
        With FrmVerifiCheck
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

            End If
        End With
    End Sub
    ''' <summary>
    ''' 指定されたデータの照合を行います。
    ''' </summary>
    ''' <param name="VerifyData">照合するデータ列</param>
    ''' <param name="OKCount">合致するデータ数</param>
    ''' <param name="NGCount">合致しないデータ数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GridVerify(VerifyData As ArrayList, IsSeekMode As Integer, ByRef OKCount As Integer, ByRef NGCount As Integer) As Boolean
        OKCount = 0 : NGCount = 0
        With SS.ActiveSheet
            If .RowCount > 0 Then
                For i As Integer = 0 To VerifyData.Count - 1
                    Dim Dat As String = VerifyData(i).ToString.ToUpper
                    If Dat <> "" Then
                        Dim Ret As List(Of Integer) = GridVerifyCell(Dat, IsSeekMode)
                        If Ret.Count > 0 Then
                            OKCount += 1
                        Else
                            NGCount += 1
                        End If
                    End If
                Next
                Return True
            Else
                Return False
            End If
        End With

    End Function
    ''' <summary>
    ''' 指定されたデータのチェックを入れます。
    ''' </summary>
    ''' <param name="VerifyData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GridVerifyCheck(VerifyData As ArrayList, IsSeekMode As Integer) As Boolean
        With SS.ActiveSheet
            If .RowCount > 0 Then
                For i As Integer = 0 To VerifyData.Count - 1
                    Dim Dat As String = VerifyData(i).ToString.ToUpper
                    If Dat <> "" Then
                        Dim Rows As List(Of Integer) = GridVerifyCell(Dat, IsSeekMode)
                        If Rows.Count > 0 Then
                            For Each Row As Integer In Rows
                                .Cells(Row, 0).Value = True
                            Next
                        End If
                    End If
                Next
                Return True
            Else
                Return False
            End If
        End With
    End Function
    ''' <summary>
    ''' SPREADデータを検索します。
    ''' </summary>
    ''' <param name="Dat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GridVerifyCell(Dat As String, IsSeekMode As Integer) As List(Of Integer)
        Dim Ret As New List(Of Integer)
        With SS.ActiveSheet
            If .RowCount > 0 Then
                If Dat <> "" Then
                    For Row As Integer = 0 To .RowCount - 1
                        Dim Dat2 As String = .Cells(Row, 1).Value.ToString.ToUpper
                        Select Case IsSeekMode
                            Case 0 '完全一致
                                If Dat = Dat2 Then
                                    Ret.Add(Row)
                                End If
                            Case 1 '先頭一致
                                If Dat2.StartsWith(Dat) Then
                                    Ret.Add(Row)
                                End If
                            Case 2 '曖昧
                                If Dat2.IndexOf(Dat) > -1 Then
                                    Ret.Add(Row)
                                End If
                        End Select
                    Next

                End If
            End If
        End With
        Return Ret

    End Function
#End Region

    Structure SeekPoint
        Dim TabIndex As Integer
        Dim RowIndex As Integer
    End Structure
    Dim _SeekedData As New List(Of SeekPoint) '検索済みデータ
    Dim _SeekIndex As Integer = -1
    Dim _SeekStr As String = "" '検索文字列
    Dim _SeekAll As Boolean = False
    Dim _SeekAriaWidth As Integer = 220

    ''' <summary>
    ''' 検索・置換パッドの表示／非表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDataSeek_Click(sender As Object, e As EventArgs) Handles BtnDataSeek.Click
        If C1Sizer1.Grid.Columns(0).Size = 0 Then
            C1Sizer1.Grid.Columns(0).Size = _SeekAriaWidth
        Else
            '_SeekAriaWidth = C1Sizer1.Grid.Columns(0).Size
            C1Sizer1.Grid.Columns(0).Size = 0
        End If

    End Sub
    ''' <summary>
    ''' アイテム検索ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnItemSeek_Click(sender As Object, e As EventArgs) Handles BtnItemSeek.Click
        _SeekStr = TxtSeekText.Text
        _SeekAll = OptSeekAria1.Checked
        Try
            If _SeekStr <> "" Then
                Try
                    If _SeekAll Then
                        Sql = String.Format("SELECT * FROM AddressData WHERE (Field1 Like '%{0}%') OR (Field2 Like '%{0}%') OR (Field3 Like '%{0}%') OR (Field4 Like '%{0}%') OR (Field5 Like '%{0}%') OR (Field6 Like '%{0}%') OR (Field7 Like '%{0}%') OR (Field8 Like '%{0}%') OR (Field9 Like '%{0}%') OR (Field10 Like '%{0}%') OR (Field11 Like '%{0}%') OR (Field12 Like '%{0}%') OR (Field13 Like '%{0}%') OR (Field14 Like '%{0}%') OR (Field15 Like '%{0}%') OR (Field16 Like '%{0}%') OR (Field17 Like '%{0}%') OR (Field18 Like '%{0}%') OR (Field19 Like '%{0}%') OR (Field20 Like '%{0}%')", _SeekStr)
                    Else
                        Sql = String.Format("SELECT * FROM AddressData WHERE ((Field1 Like '%{0}%') OR (Field2 Like '%{0}%') OR (Field3 Like '%{0}%') OR (Field4 Like '%{0}%') OR (Field5 Like '%{0}%') OR (Field6 Like '%{0}%') OR (Field7 Like '%{0}%') OR (Field8 Like '%{0}%') OR (Field9 Like '%{0}%') OR (Field10 Like '%{0}%') OR (Field11 Like '%{0}%') OR (Field12 Like '%{0}%') OR (Field13 Like '%{0}%') OR (Field14 Like '%{0}%') OR (Field15 Like '%{0}%') OR (Field16 Like '%{0}%') OR (Field17 Like '%{0}%') OR (Field18 Like '%{0}%') OR (Field19 Like '%{0}%') OR (Field20 Like '%{0}%')) AND TabIndexNo={1}", _SeekStr, TabSelectedIndex)
                    End If

                    Using CMD As New OleDb.OleDbCommand(Sql, CN)
                        Using DR As OleDb.OleDbDataReader = CMD.ExecuteReader
                            Do While DR.Read
                                Dim _T As New SeekPoint
                                _T.TabIndex = FG(DR("TabIndexNo"), enum_FG.FG_Numeric)
                                _T.RowIndex = FG(DR("RowNo"), enum_FG.FG_Numeric)
                                _SeekedData.Add(_T)
                            Loop
                        End Using
                    End Using

                    If _SeekedData.Count = 0 Then
                        _SeekIndex = -1
                        LblMessage.Text = "データは見つかりませんでした。"
                        LblRowCount.Text = ""
                    Else
                        _SeekIndex = 0
                        LblRetCount.Text = String.Format("{0}件のデータがあります", _SeekedData.Count)
                        LblMessage.Text = String.Format("{0}件のデータがあります", _SeekedData.Count)
                        BtnItemSeek_Next.Enabled = True
                        BtnItemSeek_Fowerd.Enabled = True
                        Call GoSSCursor()
                    End If
                Catch ex As Exception
                    MsgBox(ExMessCreater(GetStack(ex)), 48, "検索エラー")
                End Try
            End If
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "検索エラー")
        End Try
    End Sub

    ''' <summary>
    ''' 検索　前へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnItemSeek_Fowerd_Click(sender As Object, e As EventArgs) Handles BtnItemSeek_Fowerd.Click
        If _SeekIndex > -1 Then
            If _SeekIndex > 0 Then
                _SeekIndex -= 1
            Else
                _SeekIndex = _SeekedData.Count - 1
            End If
            Call GoSSCursor()
        End If
    End Sub
    ''' <summary>
    ''' 検索　次に移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnItemSeek_Next_Click(sender As Object, e As EventArgs) Handles BtnItemSeek_Next.Click
        If _SeekIndex > -1 Then
            If _SeekIndex < _SeekedData.Count - 1 Then
                _SeekIndex += 1
            Else
                _SeekIndex = 0
            End If
            Call GoSSCursor()
        End If

    End Sub
    ''' <summary>
    ''' 検索パネル閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSeekPanelClose_Click(sender As Object, e As EventArgs) Handles BtnSeekPanelClose.Click
        Call BtnDataSeek_Click(Nothing, Nothing)
    End Sub
    ''' <summary>
    ''' 検索対象文字の変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtSeekText_TextChanged(sender As Object, e As EventArgs) Handles TxtSeekText.TextChanged
        _SeekedData.Clear()
        LblRetCount.Text = ""
        BtnItemSeek_Next.Enabled = False
        BtnItemSeek_Fowerd.Enabled = False
        LblMessage.Text = ""
    End Sub
    ''' <summary>
    ''' 検索範囲の変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OptSeekAria0_CheckedChanged(sender As Object, e As EventArgs) Handles OptSeekAria0.CheckedChanged, OptSeekAria1.CheckedChanged
        _SeekedData.Clear()
        LblRetCount.Text = ""
        BtnItemSeek_Next.Enabled = False
        BtnItemSeek_Fowerd.Enabled = False
        LblMessage.Text = ""
    End Sub
    ''' <summary>
    ''' 文字置換ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExecuteReplace_Click(sender As Object, e As EventArgs) Handles BtnExecuteReplace.Click
        If SS.ActiveSheet.RowCount = 0 Then
            Return
        End If

        Dim ARow As Integer = SS.ActiveSheet.ActiveRowIndex
        Dim ACol As Integer = SS.ActiveSheet.ActiveColumnIndex

        Dim _WorkMode As Boolean = (TabControl2.SelectedIndex = 0)
        Dim _FromText As String = TxtFromMoji.Text
        Dim _ToText As String = TxtToMoji.Text
        Dim _Cap As Boolean = ChkSepCapital.Checked
        Dim _ToWide As Boolean = OptToWide.Checked
        Dim _WorkAria As Integer = 0

        Select Case True
            Case OptWorkAria1.Checked : _WorkAria = 1
            Case OptWorkAria2.Checked : _WorkAria = 2
            Case OptWorkAria3.Checked : _WorkAria = 3
            Case OptWorkAria4.Checked : _WorkAria = 4
            Case OptWorkAria5.Checked : _WorkAria = 5
            Case Else : _WorkAria = 0
        End Select
        _ToWide = OptToWide.Checked

        If _WorkMode Then
            Select Case True
                Case String.IsNullOrWhiteSpace(_FromText)
                    MsgBox("置換対象文字が指定されていません", 48, "エラー")
                    Return
                Case String.IsNullOrWhiteSpace(_ToText)
                    MsgBox("置換文字が指定されていません", 48, "エラー")
                    Return
            End Select
        End If


        Dim StartRow As Integer = 0 : Dim StartCol As Integer = 0
        Dim EndRow As Integer = 0 : Dim EndCol As Integer = 0
        Dim CheckRow As Boolean = False

        Select Case _WorkAria
            Case 1
                If MsgBox("選択行の文字列置換を行っていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
                    Return
                End If
                StartRow = ARow : EndRow = ARow
                StartCol = 1 : EndCol = SS.ActiveSheet.ColumnCount - 1
            Case 2
                If ACol = 0 Then
                    MsgBox("選択列の作業は出来ません", 48, "エラー")
                    Return
                End If
                If MsgBox("選択列の文字列置換を行っていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
                    Return
                End If
                StartRow = 0 : EndRow = SS.ActiveSheet.RowCount - 1
                StartCol = ACol : EndCol = ACol
            Case 3
                If MsgBox("シート全体の文字列置換を行っていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
                    Return
                End If
                StartRow = 0 : EndRow = SS.ActiveSheet.RowCount - 1
                StartCol = 1 : EndCol = SS.ActiveSheet.ColumnCount - 1
            Case 4
                If MsgBox("チェック付き行の文字列置換を行っていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
                    Return
                End If
                StartRow = 0 : EndRow = SS.ActiveSheet.RowCount - 1
                StartCol = 1 : EndCol = SS.ActiveSheet.ColumnCount - 1
                CheckRow = True
            Case 5
                If MsgBox("選択範囲の文字列置換を行っていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
                    Return
                End If

                With SS.ActiveSheet.Models.Selection
                    If .AnchorRow > .LeadRow Then
                        StartRow = .LeadRow : EndRow = .AnchorRow
                    Else
                        StartRow = .AnchorRow : EndRow = .LeadRow
                    End If
                    If .AnchorColumn > .LeadColumn Then
                        StartCol = .LeadColumn : EndCol = .AnchorColumn
                    Else
                        StartCol = .AnchorColumn : EndCol = .LeadColumn
                    End If
                End With

            Case Else
                If ACol = 0 Then
                    MsgBox("選択セルの作業は出来ません", 48, "エラー")
                    Return
                End If

                If MsgBox("選択セルの文字列置換を行っていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
                    Return
                End If
                StartRow = ARow : EndRow = ARow
                StartCol = ACol : EndCol = ACol
        End Select


        For Row As Integer = StartRow To EndRow
            For Col As Integer = StartCol To EndCol
                Dim _T As String = SS.ActiveSheet.Cells(Row, Col).Value

                'チェック行の変換の場合、チェックが入っていなかったら対象文字をクリアにする
                If CheckRow Then
                    If SS.ActiveSheet.Cells(Row, 0).Value = False Then
                        _T = ""
                    End If
                End If

                If _T <> "" Then
                    Try
                        If _WorkMode Then
                            '文字変換
                            Dim R2 As String = ""
                            If _Cap Then
                                '大文字と小文字を区別する
                                R2 = Replace(_T, _FromText, _ToText)
                            Else
                                'Dim r2 As String = StringReplace(_T, _FMoji, _TMoji, -1, True)
                                R2 = System.Text.RegularExpressions.Regex.Replace(_T, _FromText, _ToText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                            End If
                            SS.ActiveSheet.Cells(Row, Col).Value = R2
                            _IsEdit = True
                        Else
                            Dim Flg As Boolean = False
                            Select Case GetColType(Col)
                                Case 0 '一般フィールド0
                                    Flg = True
                                Case 1 '郵便番号フィールド1
                                Case 2 '住所フィールド2
                                    Flg = True
                                Case 3 '名前フィールド3
                                    Flg = True
                                Case Else '注意書きフィールド4
                            End Select
                            If Flg Then
                                '全角・半角の変換
                                'Dim _W As String = ""
                                'If _ToWide Then
                                '    _W = StrConv(_T, VbStrConv.Wide)
                                'Else
                                '    _W = StrConv(_T, VbStrConv.Narrow)
                                'End If
                                'SS.ActiveSheet.Cells(Row, Col).Value = _W
                                SS.ActiveSheet.Cells(Row, Col).Value = StrConv(_T, IIf(_ToWide, VbStrConv.Wide, VbStrConv.Narrow))
                                _IsEdit = True
                            End If

                        End If

                    Catch ex As Exception

                    End Try
                End If

            Next
        Next
        If _WorkMode Then
            LblMessage.Text = "文字置換完了"
        Else
            LblMessage.Text = "全半角変換完了"
        End If
    End Sub

    ''' <summary>
    ''' TODO:WORDへの差し込み
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnWordInsData_Click(sender As Object, e As EventArgs) Handles BtnWordInsData.Click

        Dim _WorkChecked As Boolean = False
        With SS.ActiveSheet
            For Row As Integer = 0 To .RowCount - 1
                If FG(.Cells(Row, 0).Value, enum_FG.FG_Boolean) = True Then
                    _WorkChecked = True
                    Exit For
                End If
            Next
        End With

        If Not _WorkChecked Then
            MsgBox("差し込みデータが選択されていません" & vbCrLf & "先に差し込むデータを選択してから行ってください", 48, "エラー")
            Return
        End If

        Dim _TabTag As LocalTabCollection = GcTabControl1.TabPages(TabSelectedIndex).Tag
        Dim No As Integer = _TabTag.Index
        Dim PIndex As Integer = _TabTag.UsePaperIndex

        With FrmWordInsData
            .SelectTabIndex = No
            .SelectPaperIndex = PIndex
            .TabCollection = _TabTag
            .PaperCollection = PaperArray(PIndex)
            .ShowDialog(Me)
        End With
    End Sub

End Class

Public Class LocalTabCollection
    ''' <summary>
    ''' タブのインデックス番号
    ''' </summary>
    ''' <remarks></remarks>
    Public Index As Integer
    ''' <summary>
    ''' 使用用紙番号
    ''' </summary>
    ''' <remarks></remarks>
    Public UsePaperIndex As Integer
    Public UsePaperID As String
    ''' <summary>
    ''' 名称
    ''' </summary>
    ''' <remarks></remarks>
    Public LabelText As String
    ''' <summary>
    ''' 敬称
    ''' </summary>
    ''' <remarks></remarks>
    Public MR As String
    Sub New()
        Me.Index = 0
        Me.UsePaperIndex = 0
        Me.LabelText = ""
        Me.MR = ""
    End Sub
End Class
