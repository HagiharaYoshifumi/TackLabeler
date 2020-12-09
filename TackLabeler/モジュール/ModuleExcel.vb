Imports System.IO
Imports NPOI.HSSF.UserModel
Imports NPOI.XSSF.UserModel
Imports NPOI.SS.UserModel
Module ModuleExcel
    Dim EX As New ClassExcelWork
    ''' <summary>
    ''' 既存EXCEL文書を編集し別名ファイルにする
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <param name="Data"></param>
    ''' <param name="MasterDoc"></param>
    ''' <param name="SaveFileName"></param>
    ''' <param name="SheetName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateExcel2Excel(Field As ArrayList, Data As ArrayList, MasterDoc As String, SaveFileName As String, SheetName As String) As String
        Try
            If MasterDoc <> "" AndAlso File.Exists(MasterDoc) Then
                'マスタ文書からコピーを作成する
                File.Copy(MasterDoc, SaveFileName)

                Dim book As IWorkbook = EX.OpenExcelFile(SaveFileName)
                If EX.FindSheet(book, SheetName) > -1 Then
                    Dim Sheet As ISheet = EX.SelectSheet(book, SheetName)
                    For i As Integer = 0 To Field.Count - 1
                        Dim Fld As String = String.Format("<{0}>", Field(i))
                        Dim p As List(Of Point) = EX.SearchText(Sheet, Fld)
                        If p.Count > 0 Then
                            For Each PP As Point In p
                                Call EX.SetValueEX(Sheet, PP.Y, PP.X, Data(i))
                            Next

                        End If
                    Next
                    Call EX.SaveExcelFile(SaveFileName, book)
                    Return SaveFileName.ToString
                Else
                    Return ""
                End If
            Else
                Return ""
            End If

        Catch ex As Exception
            Return ""

        End Try

    End Function
End Module
