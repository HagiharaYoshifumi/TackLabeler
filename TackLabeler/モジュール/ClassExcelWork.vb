Imports System
Imports System.IO

Imports NPOI.HSSF.UserModel
Imports NPOI.XSSF.UserModel
Imports NPOI.SS.UserModel


''' <summary>
''' Excel操作クラス(NPOI版)
''' </summary>
''' <remarks>
''' https://www.nuget.org/packages/NPOI/ を開いて、右上のInfoの中にある「Download package」を開き
''' ダウンロードしたファイルの拡張子をZIPに変更して解凍する
''' </remarks>
Public Class ClassExcelWork

    ''' <summary>
    ''' ブックのシート数
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <returns>シート数</returns>
    ''' <remarks></remarks>
    Public Function SheetCount(Book As IWorkbook) As Integer
        Dim _Ret As Integer = -1
        Try
            For i As Integer = 0 To 100
                Book.GetSheetAt(i)
                _Ret = i
            Next
        Catch ex As Exception

        End Try
        If _Ret > -1 Then
            Return _Ret + 1
        Else
            Return _Ret
        End If
    End Function
    ''' <summary>
    ''' シートを探す
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <param name="SheetName">検索シート名</param>
    ''' <returns>-1：対象シートなし　0以上：見つかったシートインデックス</returns>
    ''' <remarks></remarks>
    Public Function FindSheet(Book As IWorkbook, SheetName As String) As Integer
        If SheetName <> "" Then
            Dim _Count As Integer = SheetCount(Book)
            For Index As Integer = 0 To _Count - 1
                If SheetName = Book.GetSheetName(Index) Then
                    Return Index
                End If
            Next
        End If
        Return -1
    End Function
    ''' <summary>
    ''' シート名一覧
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SheetList(Book As IWorkbook) As ArrayList
        Dim _List As New ArrayList
        Dim _Count As Integer = SheetCount(Book)
        For Index As Integer = 0 To _Count - 1
            _List.Add(Book.GetSheetName(Index))
        Next
        Return _List
    End Function
    ''' <summary>
    ''' シートの選択
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <param name="SheetIndex">シートインデックス</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectSheet(Book As IWorkbook, SheetIndex As Integer) As ISheet
        Return Book.GetSheetAt(SheetIndex)
    End Function
    ''' <summary>
    ''' シートの選択
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <param name="SheetName">選択シート名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectSheet(Book As IWorkbook, SheetName As String) As ISheet
        Return Book.GetSheet(SheetName)
    End Function
    ''' <summary>
    ''' セルのクリア
    ''' </summary>
    ''' <param name="Obj">対象シート</param>
    ''' <param name="Row">行番号</param>
    ''' <param name="Col">列番号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ClearCell(Obj As ISheet, Row As Integer, Col As Integer) As Boolean
        Try
            Dim Cell As ICell = Obj.CreateRow(Row).CreateCell(Col)
            Cell.SetCellValue("")
            Cell.SetCellType(CellType.Blank)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
#Region "SETVALUE"
    ''' <summary>
    ''' セルに値を設定する（拡張）
    ''' </summary>
    ''' <param name="Obj">対象シート</param>
    ''' <param name="Row">行番号(0始まり)</param>
    ''' <param name="Col">列番号(0始まり)</param>
    ''' <param name="Value">設定値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetValueEX(Obj As ISheet, Row As Integer, Col As Integer, Value As Object) As Boolean
        Dim _Ret As Boolean = False
        Select Case True
            Case IsDate(Value)
                Dim V As Date = Value
                _Ret = SetValue(Obj, Row, Col, V)
            Case IsNumeric(Value)
                Dim V As Decimal = Value
                _Ret = SetValue(Obj, Row, Col, V)
            Case Else
                Dim V As String = Value
                _Ret = SetValue(Obj, Row, Col, V)
        End Select
        Return _Ret
    End Function
    ''' <summary>
    ''' セルに値を設定する（拡張）
    ''' </summary>
    ''' <param name="Obj">対象シート</param>
    ''' <param name="A1">セル番号</param>
    ''' <param name="Value">設定値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetValueEX(Obj As ISheet, A1 As String, Value As Object) As Boolean
        Dim _Ret As Boolean = False
        Dim _Point As Point = A1ToR1(A1)
        Select Case True
            Case IsDate(Value)
                Dim V As Date = Value
                _Ret = SetValue(Obj, _Point.Y - 1, _Point.X - 1, V)
            Case IsNumeric(Value)
                Dim V As Decimal = Value
                _Ret = SetValue(Obj, _Point.Y - 1, _Point.X - 1, V)
            Case Else
                Dim V As String = Value
                _Ret = SetValue(Obj, _Point.Y - 1, _Point.X - 1, V)
        End Select
        Return _Ret
    End Function
    ''' <summary>
    ''' セルに値を設定する
    ''' </summary>
    ''' <param name="Obj">対象シート</param>
    ''' <param name="Row">行番号</param>
    ''' <param name="Col">列番号</param>
    ''' <param name="Value">設定値（String）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetValue(Obj As ISheet, Row As Integer, Col As Integer, Value As String) As Boolean
        Try
            If IsNothing(Obj.GetRow(Row)) Then
                Obj.CreateRow(Row).CreateCell(Col).SetCellValue(Value)
            Else
                If IsNothing(Obj.GetRow(Row).GetCell(Col)) Then
                    Obj.GetRow(Row).CreateCell(Col).SetCellValue(Value)
                Else
                    Obj.GetRow(Row).GetCell(Col).SetCellValue(Value)
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' セルに値を設定する
    ''' </summary>
    ''' <param name="Obj">対象シート</param>
    ''' <param name="Row">行番号</param>
    ''' <param name="Col">列番号</param>
    ''' <param name="Value">設定値（Integer）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetValue(Obj As ISheet, Row As Integer, Col As Integer, Value As Integer) As Boolean
        Try
            If IsNothing(Obj.GetRow(Row)) Then
                Obj.CreateRow(Row).CreateCell(Col).SetCellValue(Value)
            Else
                If IsNothing(Obj.GetRow(Row).GetCell(Col)) Then
                    Obj.GetRow(Row).CreateCell(Col).SetCellValue(Value)
                Else
                    Obj.GetRow(Row).GetCell(Col).SetCellValue(Value)
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' セルに値を設定する
    ''' </summary>
    ''' <param name="Obj">対象シート</param>
    ''' <param name="Row">行番号</param>
    ''' <param name="Col">列番号</param>
    ''' <param name="Value">設定値（Decimal）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetValue(Obj As ISheet, Row As Integer, Col As Integer, Value As Decimal) As Boolean
        Try
            If IsNothing(Obj.GetRow(Row)) Then
                Obj.CreateRow(Row).CreateCell(Col).SetCellValue(Value)
            Else
                If IsNothing(Obj.GetRow(Row).GetCell(Col)) Then
                    Obj.GetRow(Row).CreateCell(Col).SetCellValue(Value)
                Else
                    Obj.GetRow(Row).GetCell(Col).SetCellValue(Value)
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' セルに値を設定する
    ''' </summary>
    ''' <param name="Obj">対象シート</param>
    ''' <param name="Row">行番号</param>
    ''' <param name="Col">列番号</param>
    ''' <param name="Value">設定値（Date）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetValue(Obj As ISheet, Row As Integer, Col As Integer, Value As Date) As Boolean
        Try
            Dim Cell As ICell = Nothing
            If IsNothing(Obj.GetRow(Row)) Then
                Cell = Obj.CreateRow(Row).CreateCell(Col)

            Else
                If IsNothing(Obj.GetRow(Row).GetCell(Col)) Then
                    Cell = Obj.GetRow(Row).CreateCell(Col)
                Else
                    Cell = Obj.GetRow(Row).GetCell(Col)
                End If
            End If
            Cell.SetCellType(CellType.Numeric)
            Cell.SetCellValue(Value)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region
#Region "GETVALUE"

    ''' <summary>
    ''' セルの値を読み込む
    ''' </summary>
    ''' <param name="Obj">対象シート</param>
    ''' <param name="Row">行番号(0始まり)</param>
    ''' <param name="Col">列番号(0始まり)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetValue(Obj As ISheet, Row As Integer, Col As Integer) As String
        Dim _Ret As String = ""
        Try
            Dim CL As ICell = Obj.GetRow(Row).GetCell(Col)
            Select Case CL.CellType
                Case CellType.Blank
                    _Ret = CL.ToString()
                Case CellType.Boolean
                    _Ret = CL.BooleanCellValue.ToString()
                Case CellType.Error
                    _Ret = CL.ErrorCellValue.ToString()
                Case CellType.Formula
                    Select Case CL.CachedFormulaResultType
                        Case CellType.Blank
                        Case CellType.Boolean
                            _Ret = CL.BooleanCellValue.ToString()
                        Case CellType.Error
                            _Ret = CL.ErrorCellValue.ToString()
                        Case CellType.Formula
                        Case CellType.Numeric
                            If (DateUtil.IsCellDateFormatted(CL)) Then
                                _Ret = CL.DateCellValue.ToString("yyyy/MM/dd HH:mm:ss")
                            Else
                                _Ret = CL.NumericCellValue.ToString()
                            End If
                        Case CellType.String
                            _Ret = CL.StringCellValue
                        Case CellType.Unknown
                    End Select
                Case CellType.Numeric
                    If (DateUtil.IsCellDateFormatted(CL)) Then
                        _Ret = CL.DateCellValue.ToString("yyyy/MM/dd HH:mm:ss")
                    Else
                        _Ret = CL.NumericCellValue.ToString()
                    End If

                Case CellType.String
                    _Ret = CL.StringCellValue
                Case Else
            End Select
            Return _Ret
        Catch ex As Exception
            Return _Ret
        End Try
    End Function
    ''' <summary>
    ''' セルの値を読み込む
    ''' </summary>
    ''' <param name="Obj">対象シート</param>
    ''' <param name="A1">セル番号（例：A1）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetValue(Obj As ISheet, A1 As String) As String
        Dim _Ret As String = ""
        Try
            Dim _Point As Point = A1ToR1(A1)
            Dim CL As ICell = Obj.GetRow(_Point.Y - 1).GetCell(_Point.X - 1)
            Select Case CL.CellType
                Case CellType.Blank
                    _Ret = CL.ToString()
                Case CellType.Boolean
                    _Ret = CL.BooleanCellValue.ToString()
                Case CellType.Error
                    _Ret = CL.ErrorCellValue.ToString()
                Case CellType.Formula
                    Select Case CL.CachedFormulaResultType
                        Case CellType.Blank
                        Case CellType.Boolean
                            _Ret = CL.BooleanCellValue.ToString()
                        Case CellType.Error
                            _Ret = CL.ErrorCellValue.ToString()
                        Case CellType.Formula
                        Case CellType.Numeric
                            If (DateUtil.IsCellDateFormatted(CL)) Then
                                _Ret = CL.DateCellValue.ToString("yyyy/MM/dd HH:mm:ss")
                            Else
                                _Ret = CL.NumericCellValue.ToString()
                            End If
                        Case CellType.String
                            _Ret = CL.StringCellValue
                        Case CellType.Unknown
                    End Select
                Case CellType.Numeric
                    If (DateUtil.IsCellDateFormatted(CL)) Then
                        _Ret = CL.DateCellValue.ToString("yyyy/MM/dd HH:mm:ss")
                    Else
                        _Ret = CL.NumericCellValue.ToString()
                    End If

                Case CellType.String
                    _Ret = CL.StringCellValue
                Case Else
            End Select
            Return _Ret
        Catch ex As Exception
            Return _Ret
        End Try
    End Function
#End Region
    ''' <summary>
    ''' 特定シートから文字を探す
    ''' </summary>
    ''' <param name="Obj">対象シート</param>
    ''' <param name="TargetTxet">検索文字</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SearchText(Obj As ISheet, ByVal TargetTxet As String) As List(Of Point)
        Dim _Ret As New List(Of Point)
        If TargetTxet <> "" Then
            For Each Row As IRow In Obj
                For Each Cell As ICell In Row
                    If Cell.CellType = CellType.String Then
                        If Cell.StringCellValue.ToUpper = TargetTxet.ToUpper Then
                            _Ret.Add(New Point(Cell.ColumnIndex, Cell.RowIndex))
                        End If
                    End If
                Next
            Next
        End If
        Return _Ret
    End Function
    Public Function A1ToR1(ByVal A1 As String) As Point
        'A1形式をR1C1形式に変換する関数(計算式で求める方法)
        Dim R1A1(1) As Integer
        R1A1(0) = 0
        R1A1(1) = 0
        A1.ToUpper()
        Dim nLen As Integer = A1.Length
        Dim strColum As String = ""
        Dim strRow As String = ""

        For i As Integer = 0 To nLen - 1
            Dim wrk As String = A1.Substring(i, 1)
            If AscW(wrk) >= 64 And AscW(wrk) <= 90 Then
                strColum &= wrk
            ElseIf AscW(wrk) >= 48 And AscW(wrk) <= 57 Then
                strRow &= wrk
            Else
                MessageBox.Show("指定が間違っています。")
                Return Nothing
            End If
        Next
        Debug.Print(strColum & " :  " & strRow)
        A1 = strColum
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim B1 As String = A1.ToUpper
        Dim A2 As String = ""
        Dim n As Integer = B1.Length
        If n > 3 Then n = 3
        For i As Integer = 0 To n - 1
            If s.IndexOf(B1.Substring(i, 1)) >= 0 Then
                A2 &= B1.Substring(i, 1)
            End If
        Next
        n = A2.Length
        Dim C1 As Integer = 0
        If n = 1 Then
            C1 = s.IndexOf(A2) + 1
        ElseIf n = 2 Then
            C1 = (s.IndexOf(A2.Substring(0, 1)) + 1) * 26
            C1 += s.IndexOf(A2.Substring(1, 1)) + 1
        Else
            C1 = ((s.IndexOf(A2.Substring(0, 1)) + 1) * 676)
            C1 += (s.IndexOf(A2.Substring(1, 1)) + 1) * 26
            C1 += s.IndexOf(A2.Substring(2, 1)) + 1
        End If
        R1A1(0) = CInt(strRow)
        R1A1(1) = C1
        Return New Point(C1, CInt(strRow))
    End Function
    Public Function R1ToA1(ByVal r1 As Integer, ByVal c1 As Integer) As String
        'R1C1形式のアドレスをA1形式に変換する関数
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim A1 As String = ""
        If c1 < 1 Or c1 > 16384 Then
            MessageBox.Show("指定が間違っています。")
            A1 = "A1"
            Return A1
        End If
        If c1 <= 26 Then
            A1 = s.Chars(c1 - 1) & CStr(r1)
        ElseIf c1 <= 702 Then
            A1 = s.Chars(((c1 - 1) \ 26) - 1) & s.Chars(((c1 - 1) Mod 26)) & CStr(r1)
        Else
            A1 = s.Chars(((c1 - 703) \ 676)) & s.Chars((((c1 - 703) \ 26) Mod 26)) & _
                                               s.Chars(((c1 - 1) Mod 26)) & CStr(r1)
        End If
        Return A1
    End Function
    ''' <summary>
    ''' 行の挿入
    ''' </summary>
    ''' <param name="Sheet">対象シート</param>
    ''' <param name="StartRow">行挿入位置(0始まり)</param>
    ''' <param name="RowCount">挿入行数（省略：1行）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertRow(Sheet As ISheet, StartRow As Integer, Optional RowCount As Integer = 1) As Boolean
        Try
            Dim _Last As Integer = Sheet.LastRowNum
            Sheet.ShiftRows(StartRow, _Last + 1, RowCount)
            Return True

        Catch ex As Exception
        End Try
        Return False
    End Function
    ''' <summary>
    ''' 行の削除
    ''' </summary>
    ''' <param name="Sheet">対象シート</param>
    ''' <param name="DelStartRow">削除開始行</param>
    ''' <param name="RowCount">削除行数（省略：1行）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RemoveRow(Sheet As ISheet, DelStartRow As Integer, Optional RowCount As Integer = 1) As Boolean
        Try
            Dim _Last As Integer = Sheet.LastRowNum
            Sheet.ShiftRows(DelStartRow + RowCount, _Last + 1, -RowCount)
            Return True
        Catch ex As Exception

        End Try
        Return False
    End Function
    ''' <summary>
    ''' シートの追加
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <param name="SheetName">設定シート名</param>
    ''' <returns></returns>
    ''' <remarks>シート名を指定しない場合は「Sheet1」などのデフォルト名になる</remarks>
    Public Function AddSheet(Book As IWorkbook, SheetName As String) As Boolean
        If FindSheet(Book, SheetName) = -1 Then
            Dim _Sheet As ISheet = Book.CreateSheet()
            If SheetName <> "" Then
                Dim _SheetName As String = _Sheet.SheetName
                Dim i As Integer = FindSheet(Book, _SheetName)
                If i > -1 Then
                    Book.SetSheetName(i, SheetName)
                End If
            End If
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' シート名変更
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <param name="OldSheetName">変更前シート名</param>
    ''' <param name="NewSheetName">変更後シート名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EditSheetName(Book As IWorkbook, OldSheetName As String, NewSheetName As String) As Boolean
        If FindSheet(Book, NewSheetName) = -1 Then
            If NewSheetName <> "" Then
                Dim i As Integer = FindSheet(Book, OldSheetName)
                If i > -1 Then
                    Book.SetSheetName(i, NewSheetName)
                End If
            End If
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' シート名変更
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <param name="SheetIndex">変更シートインデックス</param>
    ''' <param name="NewSheetName">変更後シート名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EditSheetName(Book As IWorkbook, SheetIndex As Integer, NewSheetName As String) As Boolean
        If FindSheet(Book, NewSheetName) = -1 Then
            If NewSheetName <> "" Then
                If SheetIndex > -1 Then
                    Book.SetSheetName(SheetIndex, NewSheetName)
                End If
            End If
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' シートの削除
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <param name="SheetName">削除シート名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RemoveSheet(Book As IWorkbook, SheetName As String) As Boolean
        Dim index As Integer = FindSheet(Book, SheetName)
        If index >= -1 Then
            Book.RemoveSheetAt(index)
        End If
        Return True
    End Function
    ''' <summary>
    ''' シートの削除
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <param name="SheetIndex">削除シートインデックス</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RemoveSheet(Book As IWorkbook, SheetIndex As Integer) As Boolean
        If SheetIndex >= -1 Then
            Book.RemoveSheetAt(SheetIndex)
        End If
        Return True
    End Function
    ''' <summary>
    ''' アクティブシートの選択
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <param name="SheetName">対象シート名</param>
    ''' <remarks></remarks>
    Public Sub SheetActive(Book As IWorkbook, SheetName As String)
        If SheetName <> "" Then
            Dim Index As Integer = FindSheet(Book, SheetName)
            If Index > -1 Then
                '単一選択にする為に、全てのシートを一旦非選択にする
                Dim _Count As Integer = SheetCount(Book)
                For C As Integer = 0 To _Count - 1
                    Dim NM As String = Book.GetSheetName(C)
                    Dim s As ISheet = Book.GetSheet(NM)
                    s.SetActive(False)
                Next

                Book.SetActiveSheet(Index)
            End If
        End If
    End Sub
    ''' <summary>
    ''' アクティブシートの選択
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <param name="SheetIndex">対象シートインデックス名</param>
    ''' <remarks></remarks>
    Public Sub SheetActive(Book As IWorkbook, SheetIndex As Integer)
        '単一選択にする為に、全てのシートを一旦非選択にする
        Dim _Count As Integer = SheetCount(Book)
        For Index As Integer = 0 To _Count - 1
            Dim NM As String = Book.GetSheetName(Index)
            Dim s As ISheet = Book.GetSheet(NM)
            s.SetActive(False)
        Next

        Book.SetActiveSheet(SheetIndex)

    End Sub
    Public Function SheetGetPrintAria(Book As IWorkbook, SheetName As String) As String
        If SheetName <> "" Then
            Dim Index As Integer = FindSheet(Book, SheetName)
            If Index > -1 Then
                Return Book.GetPrintArea(Index)
            End If
        End If
        Return ""
    End Function
    ''' <summary>
    ''' 印刷範囲の設定
    ''' </summary>
    ''' <param name="Book">対象ブック</param>
    ''' <param name="SheetName">対象シート名</param>
    ''' <param name="Aria">印刷範囲(例：$A$1:$P$50)</param>
    ''' <remarks></remarks>
    Public Sub SheetSetPrintAria(Book As IWorkbook, SheetName As String, Aria As String)
        If SheetName <> "" Then
            Dim Index As Integer = FindSheet(Book, SheetName)
            If Index > -1 Then
                Book.SetPrintArea(Index, Aria)
            End If
        End If
    End Sub
    Public Enum enumPrintFitMode
        FitWidth = 0
        FitHeight = 1
        FitAll = 2
    End Enum
    ''' <summary>
    ''' 印刷フィット指定
    ''' </summary>
    ''' <param name="Book"></param>
    ''' <param name="SheetName"></param>
    ''' <param name="FitMode"></param>
    ''' <remarks></remarks>
    Public Sub SheetSetPrintFitMode(Book As IWorkbook, SheetName As String, FitMode As enumPrintFitMode)

        If SheetName <> "" Then
            Dim Index As Integer = FindSheet(Book, SheetName)
            If Index > -1 Then
                Dim Sheet As ISheet = Book.GetSheet(SheetName)
                Sheet.FitToPage = False
                Dim PS As IPrintSetup = Sheet.PrintSetup
                Select Case FitMode
                    Case enumPrintFitMode.FitWidth
                        PS.FitWidth = 1 : PS.FitHeight = 0
                    Case enumPrintFitMode.FitHeight
                        PS.FitWidth = 0 : PS.FitHeight = 1
                    Case Else
                        PS.FitWidth = 1 : PS.FitHeight = 1
                End Select
                Sheet.FitToPage = True
            End If
        End If

    End Sub
    ''' <summary>
    ''' 保存
    ''' </summary>
    ''' <param name="FilePath">保存ファイルパス＆ファイル名</param>
    ''' <param name="Book">対象ブック名</param>
    ''' <returns></returns> 
    ''' <remarks></remarks>
    Public Function SaveExcelFile(FilePath As String, Book As IWorkbook) As Boolean
        Try
            Using fs As FileStream = New FileStream(FilePath, FileMode.Create)
                Book.Write(fs)
            End Using
            Return True

        Catch ex As Exception

        End Try
        Return False
    End Function
    'Dim format As IDataFormat = Nothing
    'Dim style As ICellStyle
    ''' <summary>
    ''' エクセルファイルを読み込む
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    ''' <remarks>
    '''  Dim book As IWorkbook = EX.OpenExcelFile(FileName)
    ''' </remarks>
    Public Function OpenExcelFile(filePath As String) As IWorkbook

        If File.Exists(filePath) Then
            '既存のファイルを開く
            Using fs As New FileStream(filePath, FileMode.Open)
                If filePath.EndsWith(".xls") Then
                    Dim Ret As HSSFWorkbook = New HSSFWorkbook(fs)
                    'format = Ret.CreateDataFormat()
                    'style = Ret.CreateCellStyle()
                    Return Ret
                Else
                    Dim Ret As XSSFWorkbook = New XSSFWorkbook(fs)
                    'format = Ret.CreateDataFormat()
                    'style = Ret.CreateCellStyle()
                    Return Ret
                End If
            End Using
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' 新規Excelファイルを作成する
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateExcelFile(filePath As String) As IWorkbook

        If File.Exists(filePath) Then
            Return Nothing
        Else
            '存在しなければ新規作成()
            If filePath.EndsWith(".xls") Then
                Dim Ret As HSSFWorkbook = New HSSFWorkbook
                'format = Ret.CreateDataFormat()
                'style = Ret.CreateCellStyle()
                Return Ret
            Else
                Dim Ret As XSSFWorkbook = New XSSFWorkbook
                'format = Ret.CreateDataFormat()
                'style = Ret.CreateCellStyle()
                Return Ret
            End If
        End If
    End Function
End Class
