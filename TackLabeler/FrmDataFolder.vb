Imports System.IO
Public Class FrmDataFolder

    Private Sub FrmDataFolder_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmDataFolder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = PaperInfoArrayFileName
        TextBox2.Text = PaperArrayFile
        TextBox3.Text = AppFullPath("UserData.mdb")
        TextBox4.Text = AppFullPath("ZipData.mdb")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call OpenFolder(TextBox1.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call OpenFolder(TextBox2.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call OpenFolder(TextBox3.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call OpenFolder(TextBox4.Text)
    End Sub
    Private Sub OpenFolder(value As String)
        If value <> "" Then
            Dim Fl As String = Path.GetDirectoryName(value)
            If Fl <> "" Then
                If Directory.Exists(Fl) Then
                    System.Diagnostics.Process.Start(Fl)
                End If
            End If
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub BtnSaveData_Click(sender As Object, e As EventArgs) Handles BtnSaveData.Click
        Dim ToFolder As String = ""
        Dim FromFile As String = ""
        Dim ToFile As String = ""
        Using FD As New Ookii.Dialogs.VistaFolderBrowserDialog
            With FD
                .ShowNewFolderButton = True
                .UseDescriptionForTitle = True
                .Description = "データ保存先"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    ToFolder = .SelectedPath
                End If
            End With

        End Using

        If ToFolder <> "" Then
            If MsgBox("ユーザデータを保存してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                Try
                    Dim _FN As String = ""

                    FromFile = TextBox1.Text
                    If FromFile <> "" Then
                        If File.Exists(FromFile) Then
                            ToFile = String.Format("{0}_{1:yyMMdd}{2}", Path.GetFileNameWithoutExtension(FromFile), Now, Path.GetExtension(FromFile))
                            ToFile = My.Computer.FileSystem.CombinePath(ToFolder, ToFile)
                            File.Copy(FromFile, ToFile, True)
                        End If
                    End If

                    FromFile = TextBox2.Text
                    If FromFile <> "" Then
                        If File.Exists(FromFile) Then
                            ToFile = String.Format("{0}_{1:yyMMdd}{2}", Path.GetFileNameWithoutExtension(FromFile), Now, Path.GetExtension(FromFile))
                            ToFile = My.Computer.FileSystem.CombinePath(ToFolder, ToFile)
                            File.Copy(FromFile, ToFile, True)
                        End If
                    End If

                    FromFile = TextBox3.Text
                    If FromFile <> "" Then
                        If File.Exists(FromFile) Then
                            ToFile = String.Format("{0}_{1:yyMMdd}{2}", Path.GetFileNameWithoutExtension(FromFile), Now, Path.GetExtension(FromFile))
                            ToFile = My.Computer.FileSystem.CombinePath(ToFolder, ToFile)
                            File.Copy(FromFile, ToFile, True)
                        End If
                    End If

                    MsgBox("データ保存完了", 64, "情報")
                Catch ex As Exception
                    MsgBox(ExMessCreater(GetStack(ex)), 48, "データ保存エラー")
                End Try
              
            End If
        End If
    End Sub
End Class