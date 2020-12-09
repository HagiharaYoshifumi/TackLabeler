Module PaperInfo
    'https://support.hos.co.jp/support/CR/reference/Manual/V10/ViewControl/property/CrPrinter/PaperSize.html
    Public PaperInfoArray As New List(Of ClassPaperInfo)
    Public PaperInfoArrayFileName As String = AppFullPath("PaperInfo.XML")
    ''' <summary>
    ''' 用紙情報読込
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadPaperInfoArray() As Boolean
        Try
            If System.IO.File.Exists(PaperInfoArrayFileName) Then
                PaperInfoArray.Clear()
                Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(ClassPaperInfo()))
                Using FS As New IO.FileStream(PaperInfoArrayFileName, IO.FileMode.Open)
                    Dim LocalClass() As ClassPaperInfo
                    LocalClass = SRZ.Deserialize(FS)

                    For Each LoopClass As ClassPaperInfo In LocalClass
                        PaperInfoArray.Add(LoopClass)
                    Next
                End Using
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
    ''' <summary>
    ''' 用紙情報保存
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SavePaperInfoArray() As Boolean
        Try
            If Not String.IsNullOrEmpty(PaperInfoArrayFileName) Then
                If System.IO.File.Exists(PaperInfoArrayFileName) Then System.IO.File.Delete(PaperInfoArrayFileName)

                Dim LocalClass() As ClassPaperInfo = TryCast(PaperInfoArray.ToArray, ClassPaperInfo())

                If Not LocalClass Is Nothing Then
                    Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(ClassPaperInfo()))
                    Using FS As New IO.FileStream(PaperInfoArrayFileName, IO.FileMode.Create)
                        SRZ.Serialize(FS, LocalClass)
                    End Using
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
    ''' <summary>
    ''' 用紙IDから用紙名を検索
    ''' </summary>
    ''' <param name="PaperID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PaperInfo_FindPaperName(PaperID As Integer) As String
        If PaperInfoArray.Count > 0 Then
            For Each Item As ClassPaperInfo In PaperInfoArray
                'If Item.PaperID = PaperID Then
                If Item.DataID = PaperID Then
                    Return Item.Text
                End If
            Next
        End If
        Return ""
    End Function
End Module
Public Class FrmPaperList

    Enum enumFrmPaperListStartMode
        FromApplicationEvent
        FromMainForm
    End Enum
    Dim _StartMode As enumFrmPaperListStartMode = enumFrmPaperListStartMode.FromMainForm
    Property StartMode As enumFrmPaperListStartMode
        Get
            Return _StartMode
        End Get
        Set(value As enumFrmPaperListStartMode)
            _StartMode = value
        End Set
    End Property

    Private Sub FrmPaperList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmPaperList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _StartMode = enumFrmPaperListStartMode.FromApplicationEvent Then
            MsgBox("一旦タックラベラーを終了します。" & vbCrLf & "アプリケーションを再度起動してください。", 48, "情報")

        End If
    End Sub

    Private Sub FrmPaperList_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call SPREAD_Initial(SS)
        If LoadPaperInfoArray() Then
            If PaperInfoArray.Count > 0 Then
                With SS.ActiveSheet
                    For Each Item As ClassPaperInfo In PaperInfoArray
                        Dim Row As Integer = SPREAD_InsertRow(SS, , 20)
                        .Cells(Row, 0).Value = Item.PaperID
                        .Cells(Row, 1).Value = Item.Text
                        .Cells(Row, 2).Value = Item.Width
                        .Cells(Row, 3).Value = Item.Height
                    Next
                End With
            End If
        End If

    End Sub

    Private Sub MenuAddRow_Click(sender As Object, e As EventArgs) Handles MenuAddRow.Click
        Dim Row As Integer = SPREAD_InsertRow(SS, , 20)
    End Sub

    Private Sub MenuDelRow_Click(sender As Object, e As EventArgs) Handles MenuDelRow.Click
        Dim Row As Integer = SS.ActiveSheet.ActiveRowIndex
        If MsgBox("削除してもいいですですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            SS.ActiveSheet.Rows.Remove(Row, 1)
        End If
    End Sub

    Private Sub MenuSave_Click(sender As Object, e As EventArgs) Handles MenuSave.Click
        If SS.ActiveSheet.RowCount > 0 Then
            PaperInfoArray.Clear()
            With SS.ActiveSheet
                For Row As Integer = 0 To .RowCount - 1
                    Dim _T As New ClassPaperInfo
                    _T.DataID = Row
                    _T.PaperID = .Cells(Row, 0).Value
                    _T.Text = .Cells(Row, 1).Value
                    _T.Width = .Cells(Row, 2).Value
                    _T.Height = .Cells(Row, 3).Value
                    PaperInfoArray.Add(_T)
                Next
            End With
            If PaperInfoArray.Count > 0 Then
                If SavePaperInfoArray() Then
                    MsgBox("用紙情報保存完了", 64, "情報")
                Else
                    MsgBox("用紙情報保存失敗", 48, "エラー")
                End If
            End If

        End If
    End Sub

    Private Sub MenuGetPrinterPaper_Click(sender As Object, e As EventArgs) Handles MenuGetPrinterPaper.Click
        Dim _T As PrinterPaperCollection = Nothing
        With FrmPrinterPapers
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                _T = .SelectPaperInfo
            End If
        End With
        If Not IsNothing(_T) Then
            Dim Row As Integer = SPREAD_InsertRow(SS, , 20)
            With SS.ActiveSheet
                .Cells(Row, 0).Value = _T.RawKind
                .Cells(Row, 1).Value = _T.Name
                .Cells(Row, 2).Value = Int(_T.Width * 0.254)
                .Cells(Row, 3).Value = Int(_T.Height * 0.254)
            End With
        End If
    End Sub
End Class
Public Class ClassPaperInfo
    Public DataID As Integer
    Public PaperID As Integer
    Public Text As String
    Public Width As Integer
    Public Height As Integer
    Sub New()
        Me.DataID = 0
        Me.PaperID = 0
        Me.Text = ""
        Me.Width = 0
        Me.Height = 0
    End Sub
End Class