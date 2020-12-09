Imports System.IO
Imports NPOI.HSSF.UserModel
Imports NPOI.XSSF.UserModel
Imports NPOI.SS.UserModel
Public Class Form1
    Dim EX As New ClassExcelWork
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FL As String = "C:\Makesource\TackLabeler(タックシール印刷)\exceltext\exceltext\bin\Release\Book1.xlsx"
        Dim ST As String = ListBox1.SelectedItem
        Dim book As IWorkbook = EX.OpenExcelFile(FL)
        If Not IsNothing(book) Then
            Dim Sheet As ISheet = EX.SelectSheet(book, ST)
            EX.SetValueEX(Sheet, "B5", "NIKKE")

            EX.SaveExcelFile(FL, book)
            MsgBox("LL")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim FL As String = "C:\Makesource\TackLabeler(タックシール印刷)\exceltext\exceltext\bin\Release\Book1.xlsx"
        Dim book As IWorkbook = EX.OpenExcelFile(FL)
        If Not IsNothing(book) Then
            Dim KK As ArrayList = EX.SheetList(book)
            If KK.Count > 0 Then
                For Each itm As String In KK
                    ListBox1.Items.Add(itm)
                Next

            End If
          
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer = 0
        Dim FL As String = "C:\Makesource\TackLabeler(タックシール印刷)\exceltext\exceltext\bin\Release\Book1.xlsx"
        Dim ST As String = ListBox1.SelectedItem
        Dim book As IWorkbook = EX.OpenExcelFile(FL)
        If Not IsNothing(book) Then
            Dim Sheet As ISheet = EX.SelectSheet(book, ST)
            Try
                For col As Integer = 0 To 100
                    For row As Integer = 0 To 100
                        If (i Mod 5) Then
                            Label1.Text = String.Format("ROW:{0} COL:{1}", row, col)
                            Application.DoEvents()
                        End If
                        i += 1
                        If EX.GetValue(Sheet, row, col) = "<HAGHIARA>" Then
                            MsgBox(String.Format("ROW:{0} COL:{1}", row, col))
                            Exit Try
                        End If
                    Next
                Next
            Catch ex As Exception
            End Try
            MsgBox("LL")
        End If
    End Sub
End Class
