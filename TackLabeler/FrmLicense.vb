Public Class FrmLicense
    Public Enum enumScreenMode
        ModeStart
        ModeEdit
    End Enum
    Dim _ScreenMode As enumScreenMode = enumScreenMode.ModeStart
 

    Public Property ScrrenMode As enumScreenMode
        Get
            Return _ScreenMode
        End Get
        Set(value As enumScreenMode)
            _ScreenMode = value
        End Set
    End Property
    Private Sub FrmLicense_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmLicense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtPCName.Text = My.Computer.Name
        TxtExeFile.Text = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        If _ScreenMode Then
            TxtCode.Text = My.Settings.LicenseCode
        End If
    End Sub

    Private Sub BtbCancel_Click(sender As Object, e As EventArgs) Handles BtbCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If TxtCode.Text = "" Then
            MsgBox("アクティベートコードが入力されていません。", 48, "エラー")
        Else
            If LicenseCheck(TxtCode.Text) Then
                MsgBox("ライセンス承認確認", 64, "情報")
                MsgBox("アクティベーションコードはバージョンアップ時にも必要です。" & vbCrLf & "大事に保管をお願いします。", 64, "情報")
                My.Settings.LicenseCode = TxtCode.Text
                My.Settings.Save()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("アクティベーションコードが正しくありません", 48, "エラー")
            End If
        End If

    End Sub
End Class