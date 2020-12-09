Public Class FrmPrinterPapers
    Dim _PaperData As New List(Of PrinterPaperCollection)
    Dim _SelectPaperInfo As PrinterPaperCollection
    Public ReadOnly Property SelectPaperInfo As PrinterPaperCollection
        Get
            Return _SelectPaperInfo
        End Get
    End Property
    Private Sub FrmPrinterPapers_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmPrinterPapers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GetData()
    End Sub
    Private Sub GetData()
        _PaperData.Clear()
        ComboBox1.Items.Clear()
        Try
            With FrmMain.Viewer1.Document.Printer.PrinterSettings
                If .PaperSizes.Count > 0 Then
                    For i As Integer = 0 To .PaperSizes.Count - 1
                        With .PaperSizes(i)
                            Dim _T As New PrinterPaperCollection
                            _T.Name = .PaperName
                            _T.RawKind = .RawKind
                            _T.Height = .Height
                            _T.Width = .Width
                            _PaperData.Add(_T)
                        End With
                    Next
                End If
            End With

            If _PaperData.Count > 0 Then
                For Each Itm As PrinterPaperCollection In _PaperData
                    ComboBox1.Items.Add(Itm.Name)
                Next
                If ComboBox1.Items.Count > 0 Then
                    ComboBox1.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "用紙情報取得エラー")
        End Try
      

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim Index As Integer = ComboBox1.SelectedIndex
        With _PaperData(Index)
            LblRawKind.Text = Int(.RawKind * 0.254).ToString
            LblWidth.Text = Int(.Width * 0.254).ToString
            LblHeight.Text = Int(.Height * 0.254).ToString
        End With
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Dim Index As Integer = ComboBox1.SelectedIndex
        _SelectPaperInfo = _PaperData(Index)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
Public Class PrinterPaperCollection
    Public Name As String
    Public RawKind As Integer
    Public Height As Integer
    Public Width As Integer
    Sub New()
        Me.Name = ""
        Me.RawKind = 0
        Me.Height = 0
        Me.Width = 0
    End Sub
End Class