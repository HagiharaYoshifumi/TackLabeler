Public Class FrmSetting

    Private Sub GetData()
        ChkAutoZipConvert.Checked = My.Settings.AutoZipConvert
        TxtLicenseCode.Text = My.Settings.LicenseCode
        ChkPreviewIsWide.Checked = My.Settings.PreviewIsWide
    End Sub
    Private Sub SetData()
        My.Settings.AutoZipConvert = ChkAutoZipConvert.Checked
        My.Settings.LicenseCode = TxtLicenseCode.Text
        My.Settings.PreviewIsWide = ChkPreviewIsWide.Checked
        My.Settings.Save()
    End Sub

    Private Sub FrmSetting_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GetData()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If LicenseCheck(TxtLicenseCode.Text) Then
            Call SetData()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("入力されたライセンスコードは正しくありません。", 48, "エラー")
        End If

    End Sub

 
End Class