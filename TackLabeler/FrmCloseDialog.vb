Public Class FrmCloseDialog
    Dim _RetCode As Integer = 0
    ReadOnly Property RetCode As Integer
        Get
            Return _RetCode
        End Get
    End Property
    Private Sub FrmCloseDialog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmCloseDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        _RetCode = 1
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        _RetCode = 0
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        _RetCode = -1
        Me.Close()
    End Sub
End Class