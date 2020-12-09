Public Class FrmTabRename
    Dim _TabName As String = ""
    Dim _PaperIndex As Integer = -1
    Dim _PaperIDArray As New ArrayList
    Dim _PaperID As String = ""
    Property TabName() As String
        Get
            Return _TabName
        End Get
        Set(ByVal value As String)
            TxtTabName.Text = value
        End Set
    End Property
    Property PaperIndex As Integer
        Get
            Return _PaperIndex
        End Get
        Set(value As Integer)
            _PaperIndex = value
        End Set
    End Property
    Property PaperID As String
        Get
            Return _PaperID
        End Get
        Set(value As String)
            _PaperID = value
        End Set
    End Property

    Private Sub FrmTabRename_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmTabRename_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Public PaperArray As New List(Of ClassPaperCollection)
        CmbPaper.Items.Clear()
        If PaperArray.Count > 0 Then
            For Each Item As ClassPaperCollection In PaperArray
                Dim _Str As String = String.Format("{0}({1} {2})", Item.Text, Item.MakerName, Item.PaperName)
                CmbPaper.Items.Add(_Str)
                _PaperIDArray.Add(Item.PaperID)
            Next

            If CmbPaper.Items.Count > 0 Then
                If _PaperIndex = -1 Then
                    CmbPaper.SelectedIndex = 0
                Else
                    Try
                        CmbPaper.SelectedIndex = _PaperIndex
                    Catch ex As Exception
                        MsgBox("使用用紙の再選択を行ってください", 48, "用紙整合性エラー")
                        CmbPaper.SelectedIndex = 0

                    End Try
                End If
            End If
        End If

        TxtTabName.SelectionStart = 0
        TxtTabName.SelectionLength = 0
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        _TabName = ""
        _PaperIndex = 0
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If TxtTabName.Text = "" Then
            MsgBox("タブ名が入力されていません", 48, "エラー")
            Return
        End If
        If CmbPaper.SelectedIndex = -1 Then
            MsgBox("用紙が選択されていません", 48, "エラー")
            Return
        End If
        _TabName = TxtTabName.Text
        _PaperIndex = CmbPaper.SelectedIndex
        _PaperID = _PaperIDArray(_PaperIndex)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class