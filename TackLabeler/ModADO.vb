Imports System.Data
Module ModADO
    Public Enum enum_FG
        FG_String
        FG_Numeric
        FG_Date
        FG_Boolean
        FG_Decimal
    End Enum
    <DebuggerStepThrough()> _
    Public Function FG(ByVal Value As Object, Optional ByVal OutType As enum_FG = enum_FG.FG_String) As Object
        Dim Ret As Object = Nothing
        If IsNothing(Value) OrElse IsDBNull(Value) Then
            Select Case OutType
                Case enum_FG.FG_String : Ret = ""
                Case enum_FG.FG_Numeric : Ret = 0
                Case enum_FG.FG_Decimal : Ret = 0
                Case enum_FG.FG_Date : Ret = Nothing
                Case enum_FG.FG_Boolean : Ret = False
            End Select
        Else
            Select Case OutType
                Case enum_FG.FG_String : Ret = CStr(Value)
                Case enum_FG.FG_Numeric
                    Dim tRet As Integer = 0
                    If Integer.TryParse(Value, tRet) Then
                        Ret = tRet
                    Else
                        Ret = 0
                    End If
                Case enum_FG.FG_Decimal
                    Dim tRet As Decimal = 0
                    If Decimal.TryParse(Value, tRet) Then
                        Ret = tRet
                    Else
                        Ret = 0
                    End If
                Case enum_FG.FG_Date
                    If IsDate(Value) Then
                        Ret = CDate(Value)
                    Else
                        Ret = Nothing
                    End If
                Case enum_FG.FG_Boolean
                    Ret = Value
            End Select
        End If
        Return Ret
    End Function
    Public Function RowCount(ByVal Sql As String, ByVal CNT As SqlClient.SqlConnection) As Integer
        Dim RetCount As Integer = -1
        Using CMD As New SqlClient.SqlCommand(Sql, CNT)
            Using DR As SqlClient.SqlDataReader = CMD.ExecuteReader
                Do While DR.Read
                    RetCount += 1
                Loop
            End Using
        End Using
        Return RetCount
    End Function
    'Public CN As New SqlClient.SqlConnection
    Public CN As New OleDb.OleDbConnection
    Public CN_Zip As New OleDb.OleDbConnection
    Public DBFileName As String = ""
    Const MDBPass As String = "passtank"
    Public Function ConnectMDB(ByVal MDBFile As String, ByVal CNObj As OleDb.OleDbConnection) As Boolean

        If MDBFile = "" Then
            Return False : Exit Function
        End If
        If Not System.IO.File.Exists(MDBFile) Then
            Return False : Exit Function
        End If
        With CNObj
            Dim ConStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;" _
                & String.Format("Data Source={0};", MDBFile) _
                '& String.Format("Jet OLEDB:Database Password ={0}", MDBPass)
            .ConnectionString = ConStr
            Try
                .Open()
                DBFileName = MDBFile
                Return True
            Catch ex As OleDb.OleDbException
                Debug.Print(ex.Message)
                Return False
            End Try
        End With

    End Function
    Public Function ConnectSQL(ByVal Server As String, ByVal Source As String, ByVal ID As String, ByVal Password As String, ByVal CNObj As SqlClient.SqlConnection) As Boolean
        Dim ConStr As String = "Server=" & Server & _
            ";DataBase=" & Source & _
            ";Integrated Security=False;User ID=" & ID & _
            ";Password=" & Password & _
            ";Pooling=false;MultipleActiveResultSets=true;Asynchronous Processing=true;Connection Timeout=180" '接続プーリングの無効

        With CNObj
            .ConnectionString = ConStr
            Try
                .Open()
                Return True
            Catch ex As SqlClient.SqlException
                'EL.LogAddException(ex, ConStr)
                Return False
            End Try
        End With

    End Function


    Public Function AppFullPath(ByVal FileName As String) As String

        AppFullPath = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, FileName)

    End Function
    Public Function PathConcat(Value1 As String, ByVal Value2 As String) As String

        Return My.Computer.FileSystem.CombinePath(Value1, Value2)

    End Function
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
#Region "簡易文字変換関係"

    Dim CharArray() As Integer = {34, 39, 44}
    Public Function SQLTinyEncode(ByVal ValueStr As String) As String
        Dim Moji As String = ValueStr
        If Moji.Length = 0 Then Return ""
        For Each i As Integer In CharArray
            Moji = Replace(Moji, Chr(i).ToString, StrConv(Chr(i).ToString, VbStrConv.Wide))
        Next
        Return Moji
    End Function

    Public Function SQLTinyDecode(ByVal ValueStr As String) As String
        Dim Moji As String = ValueStr
        If Moji.Length = 0 Then Return ""
        For Each i As Integer In CharArray
            Moji = Replace(Moji, StrConv(Chr(i).ToString, VbStrConv.Wide), Chr(i).ToString)
        Next
        Return Moji
    End Function
#End Region


End Module
