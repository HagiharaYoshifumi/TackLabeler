Imports GrapeCity.ActiveReports 
Imports GrapeCity.ActiveReports.Document 

Public Class KOKUYO_KPC_E1121_住所 

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        Shape1.Visible = (txt枠表示1.Text <> "")

    End Sub

    Private Sub KOKUYO_KPC_E1121_住所_ReportStart(sender As Object, e As EventArgs) Handles MyBase.ReportStart

    End Sub
End Class
