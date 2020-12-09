Module Module1
    Public FormFolder As String = AppFullPath("FormData")
    Public PaperList As String = PathConcat(FormFolder, "PaperFormatList.xml")
    Enum NextNoMode
        TabNo
        FileNo
    End Enum
    Public Function NextNo(ByVal Mode As NextNoMode, Optional ByVal TargetTab As Integer = -1) As Integer
        Dim Sql As String = ""
        Dim No As Integer = 1
        If Mode = NextNoMode.TabNo Then
            Sql = "SELECT MAX(IndexNo)+1 AS NEXTNO FROM TabData"
        Else
            Sql = String.Format("SELECT MAX(FileIndexNo)+1 AS NEXTNO FROM FileData WHERE TabIndexNo={0}", TargetTab)
        End If
        Using CMD As New OleDb.OleDbCommand(Sql, CN)
            Using DR As OleDb.OleDbDataReader = CMD.ExecuteReader
                If DR.Read Then
                    If Not IsDBNull(DR("NEXTNO")) Then
                        No = DR("NEXTNO")
                    End If
                End If
            End Using
        End Using
        Return No
    End Function

    ''' <summary>
    ''' 特殊フォルダパスを検索する
    ''' </summary>
    ''' <param name="TargetFolder">対象となる特殊フォルダ</param>
    ''' <param name="FileName">ファイル名</param>
    ''' <returns>ファイル名を含むフルパス</returns>
    ''' <remarks>ファイル名指定時
    ''' ファイル名指定時はファイル名を含むフルパスを返します。(特殊フォルダ名＋固定フォルダ名＋ファイル名)またその特殊フォルダが無い場合は自動的に作成されます。
    ''' ファイル名が未指定の場合は特殊フォルダのパスを返します。(特殊フォルダ名＋固定フォルダ）但しこのフォルダの自動作成は行われません
    ''' 　　また、特殊フォルダ自体が存在しない場合は””が帰ります。
    ''' </remarks>
    Public Function NFuncSystemFullPath(TargetFolder As System.Environment.SpecialFolder, Optional FileName As String = "") As String
        'http://dobon.net/vb/dotnet/file/getfolderpath.html
        Dim _Folder As System.Environment.SpecialFolder = Environment.SpecialFolder.ApplicationData
        Dim _LocalApricationName As String = "NKS\TackLabeler" '←アプリケーションによって変更してください。

        Try
            If FileName = "" Then
                'フォルダが存在しない時は空の文字列を返す（既定）
                Dim _SysPath As String = Environment.GetFolderPath(TargetFolder, Environment.SpecialFolderOption.None)
                If _SysPath = "" Then
                    Return ""
                Else
                    Return My.Computer.FileSystem.CombinePath(_SysPath, _LocalApricationName)
                End If
            Else
                'フォルダが存在しない時は作成して、パスを返す
                Dim _SysPath As String = Environment.GetFolderPath(TargetFolder, Environment.SpecialFolderOption.Create)
                Dim _Path2 As String = My.Computer.FileSystem.CombinePath(_SysPath, _LocalApricationName)
                If Not System.IO.Directory.Exists(_Path2) Then
                    System.IO.Directory.CreateDirectory(_Path2)
                End If
                Return My.Computer.FileSystem.CombinePath(_Path2, FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try

    End Function
    ''' <summary>
    ''' CSVをArrayListに変換
    ''' </summary>
    ''' <param name="csvText">CSVの内容が入ったString</param>
    ''' <returns>変換結果のArrayList</returns>
    Public Function CsvToArrayList2(ByVal csvText As String) As System.Collections.ArrayList
        '前後の改行を削除しておく
        csvText = csvText.Trim( _
            New Char() {ControlChars.Cr, ControlChars.Lf})

        Dim csvRecords As New System.Collections.ArrayList
        Dim csvFields As New System.Collections.ArrayList

        Dim csvTextLength As Integer = csvText.Length
        Dim startPos As Integer = 0
        Dim endPos As Integer = 0
        Dim field As String = ""

        While True
            '空白を飛ばす
            While startPos < csvTextLength _
                AndAlso (csvText.Chars(startPos) = " "c _
                OrElse csvText.Chars(startPos) = ControlChars.Tab)
                startPos += 1
            End While

            'データの最後の位置を取得
            If startPos < csvTextLength _
                AndAlso csvText.Chars(startPos) = ControlChars.Quote Then
                '"で囲まれているとき
                '最後の"を探す
                endPos = startPos
                While True
                    endPos = csvText.IndexOf(ControlChars.Quote, endPos + 1)
                    If endPos < 0 Then
                        Throw New ApplicationException("""が不正")
                    End If
                    '"が2つ続かない時は終了
                    If endPos + 1 = csvTextLength OrElse _
                        csvText.Chars((endPos + 1)) <> ControlChars.Quote Then
                        Exit While
                    End If
                    '"が2つ続く
                    endPos += 1
                End While

                '一つのフィールドを取り出す
                field = csvText.Substring(startPos, endPos - startPos + 1)
                '""を"にする
                field = field.Substring(1, field.Length - 2). _
                    Replace("""""", """")

                endPos += 1
                '空白を飛ばす
                While endPos < csvTextLength AndAlso _
                    csvText.Chars(endPos) <> ","c AndAlso _
                    csvText.Chars(endPos) <> ControlChars.Lf
                    endPos += 1
                End While
            Else
                '"で囲まれていない
                'カンマか改行の位置
                endPos = startPos
                While endPos < csvTextLength AndAlso _
                    csvText.Chars(endPos) <> ","c AndAlso _
                    csvText.Chars(endPos) <> ControlChars.Lf
                    endPos += 1
                End While

                '一つのフィールドを取り出す
                field = csvText.Substring(startPos, endPos - startPos)
                '後の空白を削除
                field = field.TrimEnd()
            End If

            'フィールドの追加
            csvFields.Add(field)

            '行の終了か調べる
            If endPos >= csvTextLength OrElse _
                csvText.Chars(endPos) = ControlChars.Lf Then
                '行の終了
                'レコードの追加
                csvFields.TrimToSize()
                csvRecords.Add(csvFields)
                csvFields = New System.Collections.ArrayList( _
                    csvFields.Count)

                If endPos >= csvTextLength Then
                    '終了
                    Exit While
                End If
            End If

            '次のデータの開始位置
            startPos = endPos + 1
        End While

        csvRecords.TrimToSize()
        Return csvRecords
    End Function
    ''' <summary>
    ''' ライセンスコードの確認
    ''' </summary>
    ''' <param name="Code">確認するライセンス文字列</param>
    ''' <returns>True:ライセンスOK</returns>
    ''' <remarks>
    ''' ライセンスコード内容：［PC名］|［TACKLABELER.EXE(固定値)］|［コード生成タイムスタンプ］
    ''' </remarks>
    Public Function LicenseCheck(Code As String) As Boolean
        Try
            Dim _PCName = My.Computer.Name
            Dim _ExeName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            If Code = "" Then
                Return False
            Else
                Dim _DisCode As String = SQLDecode(Code)
                If _DisCode = "" Then
                    'デコード出来なければNG
                    Return False
                Else
                    If CountChar(_DisCode, "|") <> 2 Then
                        '分割して文字列が２つでなければNG
                        Return False
                    Else
                        Dim _Dat() As String = _DisCode.Split("|")
                        If _Dat.Length <> 3 Then
                            '分割して３つのパートで無ければNG
                            Return False
                        Else
                            If _PCName.ToUpper = _Dat(0).ToUpper AndAlso _ExeName.ToUpper = _Dat(1).ToUpper Then
                                '１つ目がPC名、２つ目がExe名で無ければNG（３つ目はコード生成日が入っているので無視）
                                Return True
                            Else
                                Return False
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "ライセンス確認エラー")
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 特定文字数を数える
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="c"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CountChar(ByVal s As String, ByVal c As Char) As Integer
        Return s.Length - s.Replace(c.ToString(), "").Length
    End Function
    ''' <summary>
    ''' GUIDを作成する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateGUID() As String
        Dim guidValue As Guid = Guid.NewGuid()
        Return guidValue.ToString
    End Function
End Module
