Namespace My

    ' 次のイベントは MyApplication に対して利用できます:
    ' 
    ' Startup: アプリケーションが開始されたとき、スタートアップ フォームが作成される前に発生します。
    ' Shutdown: アプリケーション フォームがすべて閉じられた後に発生します。このイベントは、通常の終了以外の方法でアプリケーションが終了されたときには発生しません。
    ' UnhandledException: ハンドルされていない例外がアプリケーションで発生したときに発生するイベントです。
    ' StartupNextInstance: 単一インスタンス アプリケーションが起動され、それが既にアクティブであるときに発生します。
    ' NetworkAvailabilityChanged: ネットワーク接続が接続されたとき、または切断されたときに発生します。
    Partial Friend Class MyApplication
        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            Call SavePaperArray()

            If CN_Zip.State <> ConnectionState.Closed Then CN_Zip.Close()
            If CN.State <> ConnectionState.Closed Then CN.Close()

            End
        End Sub

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            'バージョンアップしても設定内容を引き継ぐ
            If My.Settings.UpdateRequired = False Then
                My.Settings.Upgrade()
                My.Settings.UpdateRequired = True
                My.Settings.Save()
            End If

            'ライセンス確認
            Dim _LicenseOK As Boolean = False
            Dim _LicenseCode As String = My.Settings.LicenseCode
            If _LicenseCode <> "" Then
                If LicenseCheck(_LicenseCode) Then
                    _LicenseOK = True
                End If
            End If
            If Not _LicenseOK Then
                With FrmLicense
                    If .ShowDialog = DialogResult.OK Then
                    Else
                        e.Cancel = True
                        Return
                    End If
                End With
            End If

            'JIS用紙情報読込
            If LoadPaperInfoArray() Then
                If PaperInfoArray.Count = 0 Then
                    MsgBox("JIS用紙設定がされていません。" & vbCrLf & "先にJIS用紙設定を行ってください。", 48, "エラー")
                    With FrmPaperList
                        .StartMode = FrmPaperList.enumFrmPaperListStartMode.FromApplicationEvent
                        .ShowDialog()
                    End With
                    e.Cancel = True
                    Return
                End If
            Else
                MsgBox("JIS用紙情報読込に失敗しました", 48, "エラー")
                e.Cancel = True
                Return
            End If

            'タック情報読込
            If LoadPaperArray() Then
                If PaperArray.Count = 0 Then
                    MsgBox("タックシート設定がされていません。" & vbCrLf & "先にシートの設定を行ってください。", 48, "エラー")
                    With FrmEditPaper
                        .StartMode = FrmEditPaper.enumFrmEditPaperStartMode.FromApplicationEvent
                        .ShowDialog()
                    End With
                    e.Cancel = True
                    Return
                End If
            Else
                MsgBox("タックシート情報読込に失敗しました", 48, "エラー")
                MsgBox("使用前にシート情報をを行ってください。", 48, "エラー")
                With FrmEditPaper
                    .StartMode = FrmEditPaper.enumFrmEditPaperStartMode.FromApplicationEvent
                    .ShowDialog()
                End With
                e.Cancel = True
                Return
            End If

            '印字データ読込
            Dim FL As String = AppFullPath("UserData.mdb")
            If System.IO.File.Exists(FL) Then
                If Not ConnectMDB(FL, CN) Then
                    MsgBox("印字データ読み込みに失敗しました", 48, "エラー")
                    e.Cancel = True
                    Return
                End If
            Else
                MsgBox("印字データファイルがありません", 48, "エラー")
                e.Cancel = True
                Return
            End If

            '郵便番号データ読込
            Dim FL_Zip As String = AppFullPath("ZipData.mdb")
            If System.IO.File.Exists(FL_Zip) Then
                If Not ConnectMDB(FL_Zip, CN_Zip) Then
                    MsgBox("郵便番号データファイル読込に失敗しました", 48, "エラー")
                    e.Cancel = True
                    Return
                End If
            Else
                MsgBox("郵便番号データファイルがありません", 48, "エラー")
                e.Cancel = True
                Return
            End If

        End Sub
    End Class


End Namespace

