Module ModuleFrmSelTack
    ''' <summary>
    ''' フォームに配置されているコントロールを名前で探す
    ''' （フォームクラスのフィールドをフィールド名で探す）
    ''' </summary>
    ''' <param name="frm">コントロールを探すフォーム</param>
    ''' <param name="name">コントロール（フィールド）の名前</param>
    ''' <returns>見つかった時は、コントロールのオブジェクト。
    ''' 見つからなかった時は、null(VB.NETではNothing)。</returns>
    Public Function FindControlByFieldName(ByVal frm As Form, ByVal name As String) As Object
        'まずプロパティ名を探し、見つからなければフィールド名を探す
        Dim t As System.Type = frm.GetType()

        Dim pi As System.Reflection.PropertyInfo = _
            t.GetProperty(name, _
                System.Reflection.BindingFlags.Public Or _
                System.Reflection.BindingFlags.NonPublic Or _
                System.Reflection.BindingFlags.Instance Or _
                System.Reflection.BindingFlags.DeclaredOnly)

        If Not pi Is Nothing Then
            Return pi.GetValue(frm, Nothing)
        End If

        Dim fi As System.Reflection.FieldInfo = _
            t.GetField(name, _
                System.Reflection.BindingFlags.Public Or _
                System.Reflection.BindingFlags.NonPublic Or _
                System.Reflection.BindingFlags.Instance Or _
                System.Reflection.BindingFlags.DeclaredOnly)

        If fi Is Nothing Then
            Return Nothing
        End If

        Return fi.GetValue(frm)
    End Function
    ''' <summary>
    ''' タックの行・列位置を算出
    ''' </summary>
    ''' <param name="Col"></param>
    ''' <param name="Row"></param>
    ''' <param name="Index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LbelNo(Row As Integer, Col As Integer, Index As Integer) As String
        Dim i As Integer = Index + 1
        Dim R As Integer = Math.Ceiling(i / Col)
        Dim C As Integer = (i Mod Col)
        If C = 0 Then C = Col
        Return String.Format("{0}-{1} ", C, R)

    End Function

End Module
