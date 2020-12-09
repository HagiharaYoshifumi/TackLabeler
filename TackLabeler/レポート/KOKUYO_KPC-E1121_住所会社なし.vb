Imports GrapeCity.ActiveReports 
Imports GrapeCity.ActiveReports.Document 

Public Class KOKUYO_KPC_E1121_住所会社なし 
    Private Sub Detail_Format(sender As Object, e As EventArgs)
        Shape1.Visible = (txt枠表示1.Text <> "")

    End Sub

    Private Sub Detail_Format_1(sender As Object, e As EventArgs) Handles Detail.Format

    End Sub
End Class
