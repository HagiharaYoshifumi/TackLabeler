Module Module2
    ''' <summary>
    ''' エラースタックの取得
    ''' </summary>
    ''' <param name="exd">エラーException</param>
    ''' <returns>エラー発生状況のStackDataCollection</returns>
    ''' <remarks>
    ''' 使用例：MsgBox( String.Format("Location:[{0}]-[{1}](Line:{2})", ST.ClassName, ST.MetodName, ST.LineNo))
    ''' </remarks>
    Public Function GetStack(exd As Exception) As StackDataCollection
        Dim lineNumber As Integer = 0
        Dim _LocalStacData As New StackDataCollection
        Try
            Dim stackTrace As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace(exd, True)
            If stackTrace.GetFrames.Count > 0 Then
                lineNumber = stackTrace.GetFrame(0).GetFileLineNumber()
            End If

            Dim StFrame As New StackFrame(1)
            _LocalStacData.Message = exd.Message
            _LocalStacData.ClassName = StFrame.GetMethod.DeclaringType.Name.ToString
            _LocalStacData.MetodName = StFrame.GetMethod.Name.ToString
            _LocalStacData.LineNo = lineNumber
        Catch ex As Exception
        End Try

        Return _LocalStacData
    End Function
    ''' <summary>
    ''' スタック付きメッセージの作成
    ''' </summary>
    ''' <param name="ST"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExMessCreater(ST As StackDataCollection, Optional UserMessage As String = "") As String
        If UserMessage = "" Then
            If IsNothing(ST) Then
                Return (ST.Message)
            Else
                Return (ST.Message & vbCrLf & String.Format("Location:{0}", ST.ClassName)) & vbCrLf & String.Format("Metod   :{0}", ST.MetodName) & vbCrLf & String.Format("Line      :{0}", ST.LineNo)
            End If
        Else
            If IsNothing(ST) Then
                Return (UserMessage)
            Else
                Return (UserMessage & vbCrLf & ST.Message & vbCrLf & String.Format("Location:{0}", ST.ClassName)) & vbCrLf & String.Format("Metod   :{0}", ST.MetodName) & vbCrLf & String.Format("Line      :{0}", ST.LineNo)
            End If
        End If
    End Function
End Module
''' <summary>
''' エラースタックコレクション
''' </summary>
''' <remarks></remarks>
Public Class StackDataCollection
    ''' <summary>
    ''' エラーメッセージ
    ''' </summary>
    ''' <remarks></remarks>
    Public Message As String
    ''' <summary>
    ''' スタッククラス名
    ''' </summary>
    ''' <remarks></remarks>
    Public ClassName As String
    ''' <summary>
    ''' スタックメソッド名
    ''' </summary>
    ''' <remarks></remarks>
    Public MetodName As String
    ''' <summary>
    ''' スタック行番号
    ''' </summary>
    ''' <remarks></remarks>
    Public LineNo As Integer
End Class
