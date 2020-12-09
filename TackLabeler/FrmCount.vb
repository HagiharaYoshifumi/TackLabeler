Public Class FrmCount
    Dim _Count As Integer = 1
    Property Count As Integer
        Get
            Return _Count
        End Get
        Set(value As Integer)
            _Count = value
            TxtCount.Value = value
        End Set
    End Property

    Private Sub FrmCount_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmCount_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        _Count = TxtCount.Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class