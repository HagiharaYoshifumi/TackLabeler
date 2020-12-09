Public Class FrmSelectExcelOption

    ReadOnly Property DelSpace As Boolean
        Get
            Return ChkDelSpace.Checked
        End Get
    End Property
    ReadOnly Property DelCR As Boolean
        Get
            Return ChkDelCR.Checked
        End Get
    End Property
    ReadOnly Property OutputHeader
        Get
            Return ChkOutHeader.Checked
        End Get
    End Property


    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmSelectExcelOption_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class