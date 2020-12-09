Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TxtPCName.Text = "" Then
            MsgBox("ＰＣ名入力なし")
            Return
        End If
        If TxtFile.Text = "" Then
            MsgBox("ファイル名なし")
            Return
        End If

        TxtCode.Text = SQLEncode(String.Format("{0}|{1}|{2}", TxtPCName.Text.ToUpper, TxtFile.Text.ToUpper, Now.ToString))


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TxtData.Text = SQLDecode(TxtCode.Text)
        'MsgBox(CountChar(TxtData.Text, "|"))
    End Sub
    Private Function CountChar(ByVal s As String, ByVal c As Char) As Integer
        Return s.Length - s.Replace(c.ToString(), "").Length
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
