Imports GrapeCity.ActiveReports 
Imports GrapeCity.ActiveReports.Document 

Public Class AOne_29320 
    Public iSkipLabels As Integer = 3
    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If iSkipLabels > 0 Then
            iSkipLabels = iSkipLabels - 1
            Me.LayoutAction = LayoutAction.MoveLayout
        End If
    End Sub

End Class
