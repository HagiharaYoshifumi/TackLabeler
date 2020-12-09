Module ModuleXML
    'Public PaperData As New List(Of PaperDataCollection)
    'Public Function LoadPaperData(DataFile As String, SetList As List(Of PaperDataCollection)) As Boolean
    '    Try
    '        If System.IO.File.Exists(DataFile) Then
    '            SetList.Clear()
    '            Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(PaperDataCollection()))
    '            Using FS As New IO.FileStream(DataFile, IO.FileMode.Open)
    '                Dim LocalClass() As PaperDataCollection
    '                LocalClass = SRZ.Deserialize(FS)

    '                For Each LoopClass As PaperDataCollection In LocalClass
    '                    SetList.Add(LoopClass)
    '                Next
    '            End Using
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try

    'End Function
    'Public Function SavePaperData(DataFile As String, _Data As List(Of PaperDataCollection)) As Boolean
    '    Try
    '        If Not String.IsNullOrEmpty(DataFile) Then
    '            If System.IO.File.Exists(DataFile) Then System.IO.File.Delete(DataFile)

    '            Dim LocalClass() As PaperDataCollection = TryCast(_Data.ToArray, PaperDataCollection())

    '            If Not LocalClass Is Nothing Then
    '                Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(PaperDataCollection()))
    '                Using FS As New IO.FileStream(DataFile, IO.FileMode.Create)
    '                    SRZ.Serialize(FS, LocalClass)
    '                End Using
    '            End If
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try

    'End Function

End Module
'Public Class PaperDataCollection
'    Public Index As Integer
'    Public MakerName As String
'    Public PaperName As String
'    Public PaperFileName As String
'    Public PaperTopMargin As Single
'    Public PaperLeftMargin As Single
'    Public TackCol As Integer
'    Public TackRow As Integer
'    Public UseField1 As Integer
'    Public UseField2 As Integer
'    Public UseField3 As Integer
'    Public UseField4 As Integer
'    Public UseField5 As Integer
'    Public UseField6 As Integer
'End Class