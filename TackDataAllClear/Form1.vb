Public Class Form1
    Dim Sql As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("全てのデータを削除してもいいですか？？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            If MsgBox("本当に削除してもいいですか？？", 4 + 32, "再確認") = MsgBoxResult.Yes Then
                Try
                    Sql = "DELETE FROM TabData"
                    Using CMD As New OleDb.OleDbCommand(Sql, CN)
                        CMD.ExecuteNonQuery()
                    End Using
                    Sql = "DELETE FROM AddressData"
                    Using CMD As New OleDb.OleDbCommand(Sql, CN)
                        CMD.ExecuteNonQuery()
                    End Using

                    MsgBox("全てのデータを削除しました。")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim FL As String = AppFullPath("UserData.mdb")
        If System.IO.File.Exists(FL) Then
            If Not ConnectMDB(FL, CN) Then
                MsgBox("印字データファイル読み込みに失敗しました", 48, "エラー")
                Return
            End If
        Else
            MsgBox("印字データファイルがありません", 48, "エラー")
            Return
        End If
    End Sub
End Class
