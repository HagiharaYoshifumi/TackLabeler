Imports GrapeCity.ActiveReports 
Imports GrapeCity.ActiveReports.Document 

Public Class KOKUYO_KPC_E1121_名前 

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        Shape1.Visible = (txt枠表示1.Text <> "")

    End Sub
End Class
