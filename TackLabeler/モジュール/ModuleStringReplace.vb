Module ModuleStringReplace
    ''' <summary>
    ''' 指定した文字列内の指定した文字列を別の文字列に置換する。
    ''' </summary>
    ''' <param name="input">置換する文字列のある文字列。</param>
    ''' <param name="oldValue">検索文字列。</param>
    ''' <param name="newValue">置換文字列。</param>
    ''' <param name="count">置換する回数。負の数が指定されたときは、すべて置換する。</param>
    ''' <param name="compInfo">文字列の検索に使用するCompareInfo。</param>
    ''' <param name="compOptions">文字列の検索に使用するCompareOptions。</param>
    ''' <returns>置換された結果の文字列。</returns>
    Public Function StringReplace(ByVal input As String, ByVal oldValue As String, _
        ByVal newValue As String, ByVal count As Integer, _
        ByVal compInfo As System.Globalization.CompareInfo, _
        ByVal compOptions As System.Globalization.CompareOptions) As String

        If input Is Nothing OrElse input.Length = 0 OrElse _
            oldValue Is Nothing OrElse oldValue.Length = 0 OrElse _
            count = 0 Then

            Return input
        End If

        If compInfo Is Nothing Then
            compInfo = System.Globalization.CultureInfo.InvariantCulture.CompareInfo
            compOptions = System.Globalization.CompareOptions.Ordinal
        End If

        Dim inputLen As Integer = input.Length
        Dim oldValueLen As Integer = oldValue.Length
        Dim buf As New System.Text.StringBuilder(inputLen)

        Dim currentPoint As Integer = 0
        Dim foundPoint As Integer = -1
        Dim currentCount As Integer = 0

        Do
            '文字列を検索する
            foundPoint = compInfo.IndexOf(input, oldValue, currentPoint, compOptions)
            If foundPoint < 0 Then
                buf.Append(input.Substring(currentPoint))
                Exit Do
            End If

            '見つかった文字列を新しい文字列に換える
            buf.Append(input.Substring(currentPoint, foundPoint - currentPoint))
            buf.Append(newValue)

            '次の検索開始位置を取得
            currentPoint = foundPoint + oldValueLen

            '指定回数置換したか調べる
            currentCount += 1
            If currentCount = count Then
                buf.Append(input.Substring(currentPoint))
                Exit Do
            End If
        Loop While currentPoint < inputLen

        Return buf.ToString()
    End Function

    ''' <summary>
    ''' 指定した文字列内の指定した文字列を別の文字列に置換する。
    ''' </summary>
    ''' <param name="input">置換する文字列のある文字列。</param>
    ''' <param name="oldValue">検索文字列。</param>
    ''' <param name="newValue">置換文字列。</param>
    ''' <param name="count">置換する回数。負の数が指定されたときは、すべて置換する。</param>
    ''' <param name="ignoreCase">大文字と小文字を区別しない時はTrue。</param>
    ''' <returns>置換された結果の文字列。</returns>
    Public Function StringReplace(ByVal input As String, ByVal oldValue As String, _
        ByVal newValue As String, ByVal count As Integer, _
        ByVal ignoreCase As Boolean) As String

        If ignoreCase Then
            Return StringReplace(input, oldValue, newValue, count, _
                System.Globalization.CultureInfo.InvariantCulture.CompareInfo, _
                System.Globalization.CompareOptions.OrdinalIgnoreCase)
        Else
            Return StringReplace(input, oldValue, newValue, count, _
                System.Globalization.CultureInfo.InvariantCulture.CompareInfo, _
                System.Globalization.CompareOptions.Ordinal)
        End If
    End Function

    ''' <summary>
    ''' 指定した文字列内の指定した文字列を別の文字列に置換する。
    ''' </summary>
    ''' <param name="input">置換する文字列のある文字列。</param>
    ''' <param name="oldValue">検索文字列。</param>
    ''' <param name="newValue">置換文字列。</param>
    ''' <param name="count">置換する回数。負の数が指定されたときは、すべて置換する。</param>
    ''' <returns>置換された結果の文字列。</returns>
    Public Function StringReplace(ByVal input As String, ByVal oldValue As String, _
        ByVal newValue As String, ByVal count As Integer) As String

        Return StringReplace(input, oldValue, newValue, count, _
            System.Globalization.CultureInfo.InvariantCulture.CompareInfo, _
            System.Globalization.CompareOptions.Ordinal)
    End Function
End Module
