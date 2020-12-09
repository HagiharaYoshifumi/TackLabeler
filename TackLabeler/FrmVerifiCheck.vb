Public Class FrmVerifiCheck

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Dim Dat As New ArrayList
        If TextBox1.Text <> "" Then
            If TextBox1.Text.LastIndexOf(vbCrLf) > -1 Then
                Dat.AddRange(Split(TextBox1.Text, vbCrLf))
            Else
                Dat.Add(TextBox1.Text)
            End If

            Dim OK As Integer = 0
            Dim NG As Integer = 0
            Dim Mode As Integer = 0
            Select Case True
                Case OptViriMode0.Checked : Mode = 0
                Case OptViriMode1.Checked : Mode = 1
                Case OptViriMode2.Checked : Mode = 2
            End Select

            Call FrmMain.GridVerify(Dat, Mode, OK, NG)
            If NG > 0 Then
                If MsgBox("合致データがない行が存在します。" & vbCrLf & "処理を続行しますか？", 4 + 32, "確認") = MsgBoxResult.No Then
                    Return
                End If
            Else
                If MsgBox("該当データ行にチェックを入れていいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
                    Return
                End If
            End If

            Call FrmMain.GridVerifyCheck(Dat, Mode)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("検索するデータが設定されていません。", 48, "エラー")
        End If
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles BtnVerify.Click
        Dim Dat As New ArrayList
        If TextBox1.Text <> "" Then
            If TextBox1.Text.LastIndexOf(vbCrLf) > -1 Then
                Dat.AddRange(Split(TextBox1.Text, vbCrLf))
            Else
                Dat.Add(TextBox1.Text)
            End If

            Dim OK As Integer = 0
            Dim NG As Integer = 0
            Dim Mode As Integer = 0
            Select Case True
                Case OptViriMode0.Checked : Mode = 0
                Case OptViriMode1.Checked : Mode = 1
                Case OptViriMode2.Checked : Mode = 2
            End Select
            If FrmMain.GridVerify(Dat, Mode, OK, NG) Then
                LblOKCount.Text = String.Format("データあり：{0}件", OK)
                LblNGCount.Text = String.Format("データなし：{0}件", NG)
            End If
        Else
            MsgBox("検索するデータが設定されていません。", 48, "エラー")
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmVerifiCheck_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

End Class