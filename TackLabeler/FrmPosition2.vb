Public Class FrmPosition2
    Dim _V As Decimal = 0
    Property Mode As Integer = 0

    Public Property Posi2Value As Decimal
        Get
            Return _V
        End Get
        Set(value As Decimal)
            TxtValue.Value = value
        End Set
    End Property
    Public WriteOnly Property HeadStr As String
        Set(value As String)
            Label1.Text = value
        End Set
    End Property
    
    Private Sub FrmPosition2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        _V = TxtValue.Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmPosition2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtValue_ValueChanged(sender As Object, e As EventArgs) Handles TxtValue.ValueChanged
        If Mode = 0 Then
            FrmEditPaper.TxtFieldWidth.Value = TxtValue.Value - FrmEditPaper.TxtFieldLeft.Value
        Else
            FrmEditPaper.TxtFieldHeight.Value = TxtValue.Value - FrmEditPaper.TxtFieldTop.Value
        End If
    End Sub
End Class