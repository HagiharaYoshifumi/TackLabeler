Module Module1
#Region "BASE64変換関係"
    'Base64は、データを64種類の印字可能な英数字のみを用いて、
    'それ以外の文字を扱うことの出来ない通信環境にてマルチバイト文字や
    'バイナリデータを扱うためのエンコード方式である。
    'MIMEによって規定されていて、7ビットのデータしか扱うことの出来ない
    '電子メールにて広く利用されている。具体的には、A?Z, a?z, 0?9 までの62文字と
    '、記号2つ (+ , /) 、さらにパディング（余った部分を詰める）のための記号として 
    '= が用いられる。この変換によって、データ量は4/3になる。
    'また、MIMEの基準では76文字ごとに改行コードが入るため、この分の2バイトを
    '計算に入れるとデータ量は約138%となる。

    ''' <summary>
    ''' 指定した文字をBASE64形式に変換する
    ''' </summary>
    ''' <param name="Value">変換元文字列</param>
    ''' <returns>変換後(BASE64)文字列</returns>
    ''' <remarks></remarks>
    Public Function SQLEncode(ByVal Value As String) As String
        If IsNothing(Value) OrElse Value.Length = 0 Then Return ""
        'ファイルをbyte型配列としてすべて読み込む
        Dim ByteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(Value)
        'Base64で文字列に変換
        Return System.Convert.ToBase64String(ByteArray)
    End Function
    ''' <summary>
    ''' BASE64に変換された文字列を復号する
    ''' </summary>
    ''' <param name="ValueBASE64">変換元BASE64文字列</param>
    ''' <returns>復号文字列</returns>
    ''' <remarks></remarks>
    Public Function SQLDecode(ByVal ValueBASE64 As String) As String
        If IsNothing(ValueBASE64) OrElse ValueBASE64.Length = 0 Then Return ""
        Try
            Dim ByteArray() As Byte = System.Convert.FromBase64String(ValueBASE64)
            Return System.Text.Encoding.UTF8.GetString(ByteArray)

        Catch ex As Exception

            Return ""
        End Try
    End Function
#End Region
End Module
