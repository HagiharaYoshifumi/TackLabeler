'---SPREADに値を高速で入れる方法
'Dim SSDataModel As FarPoint.Win.Spread.Model.DefaultSheetDataModel = CType(SS.ActiveSheet.Models.Data, FarPoint.Win.Spread.Model.DefaultSheetDataModel)
'With SS.ActiveSheet
'  SS.SuspendLayout()
'  SSDataModel.SetValue(Row, AAAA ,FFFF)
'  SS.ResumeLayout(True)
'End With
Imports FarPoint.Win.Spread.CellType
Module ModuleNSPREAD
    ''' <summary>
    ''' SPREADを初期化する
    ''' </summary>
    ''' <param name="SSObj">作業するSPREADオブジェクト</param>
    ''' <remarks></remarks>
    Public Sub SPREAD_Initial(ByVal SSObj As FarPoint.Win.Spread.FpSpread)

        With SSObj
            .ActiveSheet.RowCount = 0
            .SetCursor(FarPoint.Win.Spread.CursorType.Normal, System.Windows.Forms.Cursors.Arrow)
            .SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, System.Windows.Forms.Cursors.Arrow)

            'ソートアイコンの設定
            Dim sv As FarPoint.Win.Spread.SpreadView = .GetRootWorkbook()
            sv.SetImage(FarPoint.Win.Spread.SpreadView.SortUnsortedImage, My.Resources.sort_switch)
            sv.SetImage(FarPoint.Win.Spread.SpreadView.SortAscendingImage, My.Resources.sort_ascending)
            sv.SetImage(FarPoint.Win.Spread.SpreadView.SortDescendingImage, My.Resources.sort_descending)

            sv.SetImage(FarPoint.Win.Spread.SpreadView.SortUnsortedImageDisabled, My.Resources.sort_switch)
            sv.SetImage(FarPoint.Win.Spread.SpreadView.SortAscendingImageDisabled, My.Resources.sort_ascending)
            sv.SetImage(FarPoint.Win.Spread.SpreadView.SortDescendingImageDisabled, My.Resources.sort_descending)

            sv.SetImage(FarPoint.Win.Spread.SpreadView.FilterActive, My.Resources.filter_clear)
            sv.SetImage(FarPoint.Win.Spread.SpreadView.FilterInactive, My.Resources.filter)

            'With .ActiveSheet
            '    With .AlternatingRows(0)
            '        .BackColor = RowOddBackColor : .ForeColor = RowOddForeColor
            '    End With
            '    With .AlternatingRows(1)
            '        .BackColor = RowEvenBackColor : .ForeColor = RowEvenForeColor
            '    End With
            'End With

            'フォーカス枠の線幅を１にする
            .FocusRenderer = New FarPoint.Win.Spread.SolidFocusIndicatorRenderer(Color.Black, 1)
            .ActiveSheet.AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu
        End With
    End Sub

    ''' <summary>
    ''' SPREADを初期化する
    ''' </summary>
    ''' <param name="SSObj">作業するSPREADオブジェクト</param>
    ''' <remarks>偶数行、奇数行で背景色を変更しない（白固定）</remarks>
    Public Sub SPREAD_Initial_BackColorWhite(ByVal SSObj As FarPoint.Win.Spread.FpSpread)
        With SSObj
            .ActiveSheet.RowCount = 0
            .SetCursor(FarPoint.Win.Spread.CursorType.Normal, System.Windows.Forms.Cursors.Arrow)
            .SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, System.Windows.Forms.Cursors.Arrow)

            'ソートアイコンの設定
            'Dim sv As FarPoint.Win.Spread.SpreadView = .GetRootWorkbook()
            'sv.SetImage(FarPoint.Win.Spread.SpreadView.SortUnsortedImage, My.Resources.sort_switch)
            'sv.SetImage(FarPoint.Win.Spread.SpreadView.SortAscendingImage, My.Resources.sort_ascending)
            'sv.SetImage(FarPoint.Win.Spread.SpreadView.SortDescendingImage, My.Resources.sort_descending)

            'sv.SetImage(FarPoint.Win.Spread.SpreadView.SortUnsortedImageDisabled, My.Resources.sort_switch)
            'sv.SetImage(FarPoint.Win.Spread.SpreadView.SortAscendingImageDisabled, My.Resources.sort_ascending)
            'sv.SetImage(FarPoint.Win.Spread.SpreadView.SortDescendingImageDisabled, My.Resources.sort_descending)

            'フォーカス枠の線幅を１にする
            .FocusRenderer = New FarPoint.Win.Spread.SolidFocusIndicatorRenderer(Color.Black, 1)
            .ActiveSheet.AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu
        End With
    End Sub
    Public Function SPREAD_InsertRow(ByVal SSObj As FarPoint.Win.Spread.FpSpread, Optional ByVal InsPosi As Integer = -1, Optional ByVal RowHeight As Integer = -1) As Integer
        Dim _RetRow As Integer = 0
        With SSObj.ActiveSheet
            If InsPosi = -1 Then
                .RowCount += 1
                _RetRow = .RowCount - 1
            Else
                .Rows.Add(InsPosi + 1, 1)
                _RetRow = InsPosi + 1
            End If

            If RowHeight = -1 Then
                .Rows(_RetRow).Height = 30
            Else
                .Rows(_RetRow).Height = RowHeight
            End If
            .Rows(_RetRow).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        End With
        Return _RetRow
    End Function
    'Enum enumSS_SerchSelectRow
    '    Simplicity
    '    Strictness
    'End Enum
    ''' <summary>
    ''' 選択されている行を検索します(SelectionChangedイベントにて使用する事)
    ''' </summary>
    ''' <param name="SSObj">対象SPREAD</param>
    ''' <param name="SelectRow">選択されている列</param>
    ''' <returns>選択されている行数</returns>
    ''' <remarks></remarks>
    Public Function SPREAD_SerchSelectRow(ByVal SSObj As FarPoint.Win.Spread.FpSpread, ByRef SelectRow() As Integer) As Integer
        Dim Rows As New List(Of Integer)
        With SSObj.ActiveSheet
            If .RowCount > 0 Then
                With .Models.Selection
                    If .SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Cell Then
                        For Row As Integer = .AnchorRow To .LeadRow
                            Rows.Add(Row)
                        Next
                    Else
                        If .Count > 0 Then
                            For ItemRow As Integer = 0 To .Count - 1
                                With .Item(ItemRow)
                                    For Row As Integer = .Row To .Row + .RowCount - 1
                                        Rows.Add(Row)
                                    Next
                                End With
                            Next
                        End If
                    End If
                End With
            End If
        End With
        If Rows.Count > 0 Then SelectRow = Rows.ToArray
        Return Rows.Count
    End Function
    ''' <summary>
    ''' 目的の文字をSPREADから探す
    ''' </summary>
    ''' <param name="SSObj">対象SPREAD</param>
    ''' <param name="TargetCol">検索する列番号</param>
    ''' <param name="SerchText">検索する文字列</param>
    ''' <param name="TargetRows">合致する文字列がある行番号列</param>
    ''' <returns>発見した行番号数</returns>
    ''' <remarks></remarks>
    Public Function SPREAD_SerchRow(ByVal SSObj As FarPoint.Win.Spread.FpSpread, ByVal TargetCol As Integer, ByVal SerchText As String, ByRef TargetRows() As Integer) As Integer
        Dim RowCount As Integer = -1
        Dim Rows As New List(Of Integer)
        With SSObj.ActiveSheet
            If .RowCount > 0 Then
                For Row As Integer = 0 To .RowCount - 1
                    Dim Moji As String = FG(.GetValue(Row, TargetCol))
                    If Moji.ToUpper = SerchText.ToUpper Then
                        Rows.Add(Row)
                    End If
                Next
                If Rows.Count > 0 Then
                    TargetRows = Rows.ToArray
                    RowCount = Rows.Count
                End If
            End If
        End With
        Return RowCount
    End Function
    Public Function SPREAD_SerchCol(ByVal SSObj As FarPoint.Win.Spread.FpSpread, ByVal TargetRow As Integer, ByVal SerchText As String, ByRef TargetCols() As Integer) As Integer
        Dim RowCount As Integer = -1
        Dim Cols As New List(Of Integer)
        With SSObj.ActiveSheet
            If .RowCount > 0 Then
                For Col As Integer = 0 To .ColumnCount - 1
                    Dim Moji As String = FG(.GetValue(TargetRow, Col))
                    If Moji.ToUpper.IndexOf(SerchText.ToUpper) > -1 Then
                        Cols.Add(Col)
                    End If
                    'If Moji.ToUpper = SerchText.ToUpper Then
                    '    Cols.Add(Col)
                    'End If
                Next
                If Cols.Count > 0 Then
                    TargetCols = Cols.ToArray
                    RowCount = Cols.Count
                End If
            End If
        End With
        Return RowCount
    End Function
    Public Function SPREAD_Serch(ByVal SSObj As FarPoint.Win.Spread.FpSpread, ByVal SerchText As String, ByRef TargetCell() As Point) As Integer
        Dim RowCount As Integer = -1
        Dim Rows As New List(Of Point)
        With SSObj.ActiveSheet
            If .RowCount > 0 Then
                For Row As Integer = 0 To .RowCount - 1
                    For Col As Integer = 0 To .ColumnCount - 1
                        Dim Moji As String = FG(.GetValue(Row, Col))
                        If Moji.ToUpper = SerchText.ToUpper Then
                            Rows.Add(New Point(Row, Col))
                        End If

                    Next
                Next
                If Rows.Count > 0 Then
                    TargetCell = Rows.ToArray
                    RowCount = Rows.Count
                End If
            End If
        End With
        Return RowCount
    End Function
    ''' <summary>
    ''' SPREADの特定列を伸ばして画面にフィットさせる
    ''' </summary>
    ''' <param name="SSObj"></param>
    ''' <param name="ResizeCol"></param>
    ''' <remarks></remarks>
    Public Sub SPREAD_FitColWidth(ByVal SSObj As FarPoint.Win.Spread.FpSpread, ByVal ResizeCol() As Integer)
        With SSObj
            Dim _RowHeader As Integer = 0
            Dim _Scroll As Integer = 17
            Dim _border As Integer = 4
            Dim _SumColW As Integer = 0
            Try
                .VerticalScrollBarWidth = _Scroll
                If .ActiveSheet.RowHeader.Visible Then
                    For i As Integer = 0 To .ActiveSheet.RowHeader.Columns.Count - 1
                        _RowHeader += .ActiveSheet.RowHeader.Columns(i).Width
                    Next
                Else
                    _RowHeader = 0
                End If

                With .ActiveSheet
                    For i As Integer = 0 To .ColumnCount - 1
                        If .Columns(i).Visible Then
                            Dim Posi As Integer = Array.IndexOf(ResizeCol, i)
                            If Posi = -1 Then
                                _SumColW += .Columns(i).Width
                            End If
                        End If
                    Next
                End With

                Dim ReSize As Integer = .Width - _RowHeader - _Scroll - _border - _SumColW
                If ReSize > 0 Then
                    For i As Integer = 0 To ResizeCol.Length - 1
                        With .ActiveSheet
                            .Columns(ResizeCol(i)).Width = ReSize / ResizeCol.Length
                        End With
                    Next
                End If
            Catch ex As Exception

            End Try

        End With
    End Sub
    ''' <summary>
    ''' 新しい行を最下段に追加する
    ''' </summary>
    ''' <param name="SSObj">対象SPREAD</param>
    ''' <returns>追加した行番号</returns>
    ''' <remarks></remarks>
    Public Function SPREAD_AddRow(ByVal SSObj As FarPoint.Win.Spread.FpSpread) As Integer
        With SSObj.ActiveSheet
            .RowCount += 1
            Return .RowCount - 1
        End With
    End Function
    ''' <summary>
    ''' 指定した行を選択状態にする
    ''' </summary>
    ''' <param name="SSObj">対象SPREAD</param>
    ''' <param name="Row">対象行番号</param>
    ''' <remarks></remarks>
    Public Sub SPREAD_DoSelectRow(ByVal SSObj As FarPoint.Win.Spread.FpSpread, Optional ByVal Row As Integer = 0)
        With SSObj.ActiveSheet
            If .RowCount > 0 Then
                .SetActiveCell(Row, 0)
                SSObj.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Left)
                .AddSelection(Row, -1, 1, -1)
            End If
        End With
    End Sub
    ''' <summary>
    ''' ソートインジケータのリセット
    ''' </summary>
    ''' <param name="SSObj">対象SPREAD</param>
    ''' <remarks>Call SPREAD_SortIndicatorReset(SS)</remarks>
    Public Sub SPREAD_SortIndicatorReset(ByVal SSObj As FarPoint.Win.Spread.FpSpread)
        With SSObj.ActiveSheet
            .Models.ResetViewRowIndexes()
            For Each Col As FarPoint.Win.Spread.Column In .Columns
                Col.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None
            Next
        End With
    End Sub
    Enum enumSPREADCellType
        BaseCell
        ButtonCell
        CheckBoxCell
        ColumnHeaderRenderer
        ComboBox
        Currency
        DateTime
        EditBase
        Empty
        General
        HyperLink
        Image
        Mask
        MultiOption
        Number
        Percent
        Progress
        RegularExpression
        RichText
        Slider
        Text
        Non
    End Enum
    ''' <summary>
    ''' 指定セルの型を判別する
    ''' </summary>
    ''' <param name="SSObj">SPREAD</param>
    ''' <param name="Row">行番号</param>
    ''' <param name="Col">列番号</param>
    ''' <returns>enumSPREADCellType</returns>
    ''' <remarks></remarks>
    Public Function SPREAD_GetCellType(ByVal SSObj As FarPoint.Win.Spread.FpSpread, ByVal Row As Integer, ByVal Col As Integer) As enumSPREADCellType
        With SSObj.ActiveSheet
            If TypeOf (.GetCellType(Row, Col)) Is ButtonCellType Then
                Return enumSPREADCellType.ButtonCell
            ElseIf TypeOf (.GetCellType(Row, Col)) Is ButtonCellType Then
                Return enumSPREADCellType.ButtonCell
            ElseIf TypeOf (.GetCellType(Row, Col)) Is CheckBoxCellType Then
                Return enumSPREADCellType.CheckBoxCell
            ElseIf TypeOf (.GetCellType(Row, Col)) Is ColumnHeaderRenderer Then
                Return enumSPREADCellType.ColumnHeaderRenderer
            ElseIf TypeOf (.GetCellType(Row, Col)) Is ComboBoxCellType Then
                Return enumSPREADCellType.ComboBox
            ElseIf TypeOf (.GetCellType(Row, Col)) Is MaskCellType Then
                Return enumSPREADCellType.Mask
            ElseIf TypeOf (.GetCellType(Row, Col)) Is EditBaseCellType Then
                Return enumSPREADCellType.EditBase
            ElseIf TypeOf (.GetCellType(Row, Col)) Is EmptyCellType Then
                Return enumSPREADCellType.Empty
            ElseIf TypeOf (.GetCellType(Row, Col)) Is GeneralCellType Then
                Return enumSPREADCellType.General
            ElseIf TypeOf (.GetCellType(Row, Col)) Is HyperLinkCellType Then
                Return enumSPREADCellType.Image

            ElseIf TypeOf (.GetCellType(Row, Col)) Is MultiOptionCellType Then
                Return enumSPREADCellType.MultiOption
            ElseIf TypeOf (.GetCellType(Row, Col)) Is NumberCellType Then
                Return enumSPREADCellType.Number
            ElseIf TypeOf (.GetCellType(Row, Col)) Is PercentCellType Then
                Return enumSPREADCellType.Percent
            ElseIf TypeOf (.GetCellType(Row, Col)) Is ProgressCellType Then
                Return enumSPREADCellType.Progress
            ElseIf TypeOf (.GetCellType(Row, Col)) Is RegularExpressionCellType Then
                Return enumSPREADCellType.RegularExpression
            ElseIf TypeOf (.GetCellType(Row, Col)) Is RichTextCellType Then
                Return enumSPREADCellType.RichText
            ElseIf TypeOf (.GetCellType(Row, Col)) Is SliderCellType Then
                Return enumSPREADCellType.Slider
            ElseIf TypeOf (.GetCellType(Row, Col)) Is TextCellType Then
                Return enumSPREADCellType.Text
            Else
                Return enumSPREADCellType.Non
            End If
        End With

    End Function
    'Public Sub SPREAD2CSV2(ByVal SPREADObj As FarPoint.Win.Spread.FpSpread, ByVal DefaltFileName As String)
    '    Dim FileName As String = ""
    '    Using SFD As New SaveFileDialog
    '        With SFD
    '            .AddExtension = True
    '            .CheckPathExists = True
    '            .DefaultExt = "csv"
    '            .FileName = DefaltFileName
    '            .Filter = "CSVファイル(*.csv)|*.csv|全てのファイル(*.*)|*.*"
    '            .FilterIndex = 0
    '            .OverwritePrompt = True
    '            .RestoreDirectory = True
    '            .Title = "CSV形式ファイル保存"
    '            If .ShowDialog = DialogResult.OK Then
    '                FileName = .FileName
    '            End If
    '        End With
    '    End Using
    '    If Not String.IsNullOrEmpty(FileName) Then
    '        SPREADObj.ActiveSheet.SaveTextFile(FileName, True, FarPoint.Win.Spread.Model.IncludeHeaders.None, vbCrLf, ",", "")
    '    End If

    'End Sub
    ''' <summary>
    ''' SPREAD内データをCSVファイルに出力する
    ''' </summary>
    ''' <param name="SPREADObj">対象SPREADオブジェクト</param>
    ''' <param name="DefaltFileName">規定のファイル名</param>
    ''' <param name="WithHeader">ヘッダを出力（TRUE:出力する）</param>
    ''' <returns>出力したファイルフルパス</returns>
    ''' <remarks></remarks>
    Public Function SPREAD2CSV(ByVal SPREADObj As FarPoint.Win.Spread.FpSpread, ByVal DefaltFileName As String, Optional ByVal WithHeader As Boolean = True, Optional ByVal SkipCol() As Integer = Nothing) As String
        Dim FileName As String = ""
        Try
            Using SFD As New SaveFileDialog
                With SFD
                    .AddExtension = True
                    .CheckPathExists = True
                    .DefaultExt = "csv"
                    .FileName = DefaltFileName
                    .Filter = "CSVファイル(*.csv)|*.csv|全てのファイル(*.*)|*.*"
                    .FilterIndex = 0
                    .OverwritePrompt = True
                    .RestoreDirectory = True
                    .Title = "CSV形式ファイル保存"
                    If .ShowDialog = DialogResult.OK Then
                        FileName = .FileName
                    End If
                End With
            End Using
            If FileName <> "" Then
                With SPREADObj.ActiveSheet
                    If .RowCount > 0 AndAlso .Columns.Count > 0 Then
                        Using SR As New System.IO.StreamWriter(FileName, False, System.Text.Encoding.GetEncoding("Shift_JIS"))
                            If WithHeader Then
                                For Col As Integer = 0 To .Columns.Count - 1
                                    Dim Data As String = .Columns(Col).Label.ToString
                                    Data = Data.Replace("""", """""")
                                    Data = """" + Data + """"
                                    SR.Write(Data)
                                    If Col = .Columns.Count - 1 Then
                                        SR.Write(vbCrLf)
                                    Else
                                        SR.Write(","c)
                                    End If
                                Next
                            End If

                            For Row As Integer = 0 To .RowCount - 1
                                For Col As Integer = 0 To .Columns.Count - 1
                                    Dim _SkipFlg As Boolean = False
                                    If SkipCol.Length > 0 Then
                                        If Array.IndexOf(SkipCol, Col) > -1 Then
                                            _SkipFlg = True
                                        End If
                                    End If

                                    If Not _SkipFlg Then
                                        'Dim Data As Object = .Cells(Row, Col).Value
                                        Dim Data As String = Replace(.Cells(Row, Col).Value, vbCrLf, "<BR>")
                                        Select Case SPREAD_GetCellType(SPREADObj, Row, Col)
                                            Case enumSPREADCellType.Currency, enumSPREADCellType.Percent, enumSPREADCellType.Number
                                                Select Case True
                                                    Case IsNothing(Data)
                                                        SR.Write(0)
                                                    Case IsNumeric(Data)
                                                        SR.Write(Data)
                                                    Case Else
                                                        SR.Write(0)
                                                End Select
                                            Case enumSPREADCellType.Text
                                                Data.Replace(vbCrLf, "")
                                                Data.Replace(vbTab, "")
                                                If Data = Nothing Then
                                                    SR.Write("")
                                                Else
                                                    Data = Data.Replace("""", """""")
                                                    Data = """" + Data + """"
                                                    SR.Write(Data)
                                                End If
                                            Case enumSPREADCellType.CheckBoxCell
                                                Select Case True
                                                    Case IsNothing(Data)
                                                        SR.Write(0)
                                                    Case Data
                                                        SR.Write(1)
                                                    Case Else
                                                        SR.Write(0)
                                                End Select
                                            Case enumSPREADCellType.DateTime
                                                Select Case True
                                                    Case IsNothing(Data)
                                                        SR.Write("")
                                                    Case IsDate(Data)
                                                        SR.Write(Data)
                                                    Case Else
                                                        SR.Write("")
                                                End Select
                                            Case Else
                                                Select Case True
                                                    Case IsNothing(Data)
                                                        SR.Write("")
                                                    Case IsDate(Data)
                                                        SR.Write(Data)
                                                    Case IsNumeric(Data)
                                                        SR.Write(Data)
                                                    Case Else
                                                        Data = Data.Replace("""", """""")
                                                        Data = """" + Data + """"
                                                        SR.Write(Data)
                                                End Select
                                        End Select
                                        If Col = .Columns.Count - 1 Then
                                            SR.Write(vbCrLf)
                                        Else
                                            SR.Write(","c)
                                        End If
                                    End If


                                Next
                            Next
                        End Using
                    End If
                End With
                'If NFuncReadReg("General", "ExecuteExcel", enum_Type.er_Boolean) Then
                '    System.Diagnostics.Process.Start(FileName)
                'End If
            End If

        Catch ex As Exception
            FileName = ""
            'MsgBox(fncFormatError(ex.Message, ex.StackTrace), MsgBoxStyle.Exclamation, "エラー")
        End Try

        Return FileName
    End Function
    ''' <summary>
    ''' チェックされたデータのみを出力する
    ''' </summary>
    ''' <param name="SPREADObj"></param>
    ''' <param name="DefaltFileName"></param>
    ''' <param name="WithHeader"></param>
    ''' <param name="SkipCol"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SPREAD2CSV_Part(ByVal SPREADObj As FarPoint.Win.Spread.FpSpread, ByVal DefaltFileName As String, Optional ByVal WithHeader As Boolean = True, Optional ByVal SkipCol() As Integer = Nothing) As String
        Dim FileName As String = ""
        Try
            Using SFD As New SaveFileDialog
                With SFD
                    .AddExtension = True
                    .CheckPathExists = True
                    .DefaultExt = "csv"
                    .FileName = DefaltFileName
                    .Filter = "CSVファイル(*.csv)|*.csv|全てのファイル(*.*)|*.*"
                    .FilterIndex = 0
                    .OverwritePrompt = True
                    .RestoreDirectory = True
                    .Title = "CSV形式ファイル保存"
                    If .ShowDialog = DialogResult.OK Then
                        FileName = .FileName
                    End If
                End With
            End Using
            If FileName <> "" Then
                With SPREADObj.ActiveSheet
                    If .RowCount > 0 AndAlso .Columns.Count > 0 Then
                        Using SR As New System.IO.StreamWriter(FileName, False, System.Text.Encoding.GetEncoding("Shift_JIS"))
                            If WithHeader Then
                                For Col As Integer = 0 To .Columns.Count - 1
                                    Dim Data As String = .Columns(Col).Label.ToString
                                    Data = Data.Replace("""", """""")
                                    Data = """" + Data + """"
                                    SR.Write(Data)
                                    If Col = .Columns.Count - 1 Then
                                        SR.Write(vbCrLf)
                                    Else
                                        SR.Write(","c)
                                    End If
                                Next
                            End If

                            For Row As Integer = 0 To .RowCount - 1
                                If FG(SPREADObj.ActiveSheet.Cells(Row, 0).Value, enum_FG.FG_Boolean) = True Then
                                    For Col As Integer = 0 To .Columns.Count - 1
                                        Dim _SkipFlg As Boolean = False
                                        If SkipCol.Length > 0 Then
                                            If Array.IndexOf(SkipCol, Col) > -1 Then
                                                _SkipFlg = True
                                            End If
                                        End If

                                        If Not _SkipFlg Then
                                            'Dim Data As Object = .Cells(Row, Col).Value
                                            Dim Data As String = Replace(.Cells(Row, Col).Value, vbCrLf, "<BR>")
                                            Select Case SPREAD_GetCellType(SPREADObj, Row, Col)
                                                Case enumSPREADCellType.Currency, enumSPREADCellType.Percent, enumSPREADCellType.Number
                                                    Select Case True
                                                        Case IsNothing(Data)
                                                            SR.Write(0)
                                                        Case IsNumeric(Data)
                                                            SR.Write(Data)
                                                        Case Else
                                                            SR.Write(0)
                                                    End Select
                                                Case enumSPREADCellType.Text
                                                    Data.Replace(vbCrLf, "")
                                                    Data.Replace(vbTab, "")
                                                    If Data = Nothing Then
                                                        SR.Write("")
                                                    Else
                                                        Data = Data.Replace("""", """""")
                                                        Data = """" + Data + """"
                                                        SR.Write(Data)
                                                    End If
                                                Case enumSPREADCellType.CheckBoxCell
                                                    Select Case True
                                                        Case IsNothing(Data)
                                                            SR.Write(0)
                                                        Case Data
                                                            SR.Write(1)
                                                        Case Else
                                                            SR.Write(0)
                                                    End Select
                                                Case enumSPREADCellType.DateTime
                                                    Select Case True
                                                        Case IsNothing(Data)
                                                            SR.Write("")
                                                        Case IsDate(Data)
                                                            SR.Write(Data)
                                                        Case Else
                                                            SR.Write("")
                                                    End Select
                                                Case Else
                                                    Select Case True
                                                        Case IsNothing(Data)
                                                            SR.Write("")
                                                        Case IsDate(Data)
                                                            SR.Write(Data)
                                                        Case IsNumeric(Data)
                                                            SR.Write(Data)
                                                        Case Else
                                                            Data = Data.Replace("""", """""")
                                                            Data = """" + Data + """"
                                                            SR.Write(Data)
                                                    End Select
                                            End Select
                                            If Col = .Columns.Count - 1 Then
                                                SR.Write(vbCrLf)
                                            Else
                                                SR.Write(","c)
                                            End If
                                        End If
                                    Next
                                End If

                            Next
                        End Using
                    End If
                End With
                'If NFuncReadReg("General", "ExecuteExcel", enum_Type.er_Boolean) Then
                '    System.Diagnostics.Process.Start(FileName)
                'End If
            End If

        Catch ex As Exception
            FileName = ""
            'MsgBox(fncFormatError(ex.Message, ex.StackTrace), MsgBoxStyle.Exclamation, "エラー")
        End Try

        Return FileName
    End Function
    ''' <summary>
    ''' SPREADデータをExcel形式で保存する
    ''' </summary>
    ''' <param name="SPREADObj"></param>
    ''' <param name="DefaltFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
   
    Public Function SPREAD2Excel(ByVal SPREADObj As FarPoint.Win.Spread.FpSpread, ByVal DefaltFileName As String) As Boolean

        Dim FileName As String = ""
        Using SFD As New SaveFileDialog
            With SFD
                .AddExtension = True
                .CheckPathExists = True
                .FileName = DefaltFileName
                '.DefaultExt = "xls"
                '.Filter = "Excelファイル(*.xls)|*.xls|全てのファイル(*.*)|*.*"
                .DefaultExt = "xlsx"
                .Filter = "Excelファイル(*.xlsx)|*.xlsx|全てのファイル(*.*)|*.*"
                .FilterIndex = 0
                .OverwritePrompt = True
                .RestoreDirectory = True
                .Title = "Excel形式ファイル保存"
                If .ShowDialog = DialogResult.OK Then
                    FileName = .FileName
                Else
                    Return True
                End If
            End With
        End Using

        Try
            Dim _DelSplace As Boolean = False
            Dim _DelCR As Boolean = False
            Dim _OutHeader As Boolean = False
            With FrmSelectExcelOption
                If .ShowDialog = DialogResult.OK Then
                    _DelSplace = .DelSpace
                    _DelCR = .DelCR
                    _OutHeader = .OutputHeader
                Else
                    Return True
                End If
            End With

            Dim XMLString As String = FarPoint.Win.Serializer.GetObjectXml(CType(SPREADObj.ActiveSheet, FarPoint.Win.ISerializeSupport), "Sheet1")
            Using sv As New FarPoint.Win.Spread.SheetView
                FarPoint.Win.Serializer.SetObjectXml(CType(sv, FarPoint.Win.ISerializeSupport), XMLString, "Sheet1")
                Using temp As New FarPoint.Win.Spread.FpSpread
                    temp.Sheets.Add(sv)

                    '非表示行、列を削除
                    With temp.Sheets(0)
                        .RemoveColumns(0, 1) 'チェック列は出力から除外する

                        For i As Integer = .ColumnCount - 1 To 0 Step -1
                            If (.Columns(i).Visible = False) Then
                                .RemoveColumns(i, 1)
                            End If
                        Next i
                        For i As Integer = .RowCount - 1 To 0 Step -1
                            If (.Rows(i).Visible = False) Then
                                .RemoveRows(i, 1)
                            End If
                        Next

                        If _DelSplace AndAlso _DelCR Then
                            For Row As Integer = 0 To .RowCount - 1
                                For Col As Integer = 0 To .ColumnCount - 1
                                    Dim _WorkString As String = .Cells(Row, Col).Value
                                    If _DelSplace Then
                                        _WorkString = Replace(_WorkString, "　", "")
                                        _WorkString = Replace(_WorkString, " ", "")
                                    End If
                                    If _DelCR Then
                                        _WorkString = Replace(_WorkString, vbCrLf, " ")
                                    End If
                                    .Cells(Row, Col).Value = _WorkString
                                Next
                            Next
                        End If
                    End With

                    'ヘッダは、保存しない
                    temp.ActiveSheet.Protect = False
                    If _OutHeader Then
                        temp.SaveExcel(FileName, FarPoint.Excel.ExcelSaveFlags.UseOOXMLFormat Or FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders)
                    Else
                        temp.SaveExcel(FileName, FarPoint.Excel.ExcelSaveFlags.UseOOXMLFormat)
                    End If
                    temp.ActiveSheet.Protect = True

                    'SaveCustomRowHeaders                           カスタム行ヘッダをExcel互換ファイルに保存します。 
                    'SaveCustomColumnHeaders                        カスタム列ヘッダをExcel互換ファイルに保存します。 
                    'FarPoint.Excel.ExcelSaveFlags.UseOOXMLFormat   Excel 2007（OfficeOpen XML）形式

                    MsgBox("出力を完了しました。", MsgBoxStyle.Information, "情報")

                    Return True
                End Using
            End Using
        Catch ex As Exception
            MsgBox("出力に失敗しました。", MsgBoxStyle.Exclamation, "エラー")
            Return False
        End Try

    End Function
    ''' <summary>
    ''' SPREADに設定されているファンクションキーを無効にします
    ''' </summary>
    ''' <param name="SPREADObj"></param>
    ''' <remarks></remarks>
    Public Sub SPREADClearFunctionKey(ByVal SPREADObj As FarPoint.Win.Spread.FpSpread)
        Dim IpMap As New FarPoint.Win.Spread.InputMap
        IpMap = SPREADObj.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        IpMap.Put(New FarPoint.Win.Spread.Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
        IpMap.Put(New FarPoint.Win.Spread.Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
        IpMap.Put(New FarPoint.Win.Spread.Keystroke(Keys.F4, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
    End Sub
    ''' <summary>
    ''' ソートインジケータのリセット
    ''' </summary>
    ''' <param name="SPREADObj"></param>
    ''' <remarks></remarks>
    Public Sub SPREAD_ResetSortIndicator(ByVal SPREADObj As FarPoint.Win.Spread.FpSpread)
        With SPREADObj.ActiveSheet
            For Col As Integer = 0 To .Columns.Count - 1
                With .Columns(Col)
                    If .Visible = True And .AllowAutoSort = True Then
                        .ResetSortIndicator() 'ソートインジケータのリセット
                    End If
                End With
                .AutoFilterReset(Col) 'フィルタインジケータのリセット
            Next
        End With
    End Sub

End Module

