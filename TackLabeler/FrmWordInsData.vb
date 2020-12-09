Imports System.IO
Public Class FrmWordInsData
#Region "Col"
    Dim ColFileNameCheck As Integer = 0
    Dim ColFieldName As Integer = 1
    Dim ColSampleData As Integer = 2
    Dim ColSystemFieldName As Integer = 3

#End Region
    Dim Sql As String = ""
    Dim _TabIndex As Integer = 0
    Dim _PaperIndex As Integer = 0
    Dim _T As LocalTabCollection = Nothing
    Dim _P As ClassPaperCollection = Nothing
    Dim _WorkCancel As Boolean = False
    Property SelectTabIndex As Integer
        Get
            Return _TabIndex
        End Get
        Set(value As Integer)
            _TabIndex = value
        End Set
    End Property
    Property SelectPaperIndex As Integer
        Get
            Return _PaperIndex
        End Get
        Set(value As Integer)
            _PaperIndex = value
        End Set
    End Property
    Property TabCollection As LocalTabCollection
        Get
            Return _T
        End Get
        Set(value As LocalTabCollection)
            _T = value
        End Set
    End Property
    Property PaperCollection As ClassPaperCollection
        Get
            Return _P
        End Get
        Set(value As ClassPaperCollection)
            _P = value
        End Set
    End Property

    Private Sub FrmWordInsData_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmWordInsData_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _IsWork Then
            MsgBox("作業中は終了する事が出来ません", 48, "エラー")
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmWordInsData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IsNothing(_P) Then
            If _P.Section.FieldData.Count > 0 Then
                DataGridView1.RowCount = 0
                For Each DAT As ClassFieldCollection In _P.Section.FieldData
                    If DAT.DataField <> "" AndAlso DAT.DataField <> "FieldShape" AndAlso DAT.FieldUseType <> 4 Then

                        DataGridView1.RowCount += 1
                        Dim Row As Integer = DataGridView1.RowCount - 1
                        DataGridView1.Rows(Row).Cells(ColFieldName).Value = DAT.Text
                        DataGridView1.Rows(Row).Cells(ColSystemFieldName).Value = DAT.DataField
                    End If
                Next
            End If

        End If

        If DataGridView1.RowCount > 0 Then
            Sql = String.Format("SELECT * FROM AddressData WHERE TabIndexNo={0} ORDER BY RowNo", _TabIndex)
            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                Using DR As OleDb.OleDbDataReader = CMD.ExecuteReader
                    If DR.Read Then
                        For Row As Integer = 0 To DataGridView1.RowCount - 1
                            Dim FD As String = DataGridView1.Rows(Row).Cells(ColSystemFieldName).Value
                            DataGridView1.Rows(Row).Cells(ColSampleData).Value = FG(DR(FD))
                        Next
                    End If

                End Using
            End Using
        End If

    End Sub
    Private Sub TxtMasterWord_DragDrop(sender As Object, e As DragEventArgs) Handles TxtMasterWord.DragDrop
        Dim fileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        If fileName.Length > 0 Then
            Dim FL As String = fileName(0)
            If Path.GetExtension(FL).ToUpper = ".DOC" OrElse Path.GetExtension(FL).ToUpper = ".DOCX" Then
                TxtMasterWord.Text = FL
            End If
        End If
    End Sub

    Private Sub TxtMasterWord_DragEnter(sender As Object, e As DragEventArgs) Handles TxtMasterWord.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub TxtOutputFolder_DragDrop(sender As Object, e As DragEventArgs) Handles TxtOutputFolder.DragDrop
        Dim fileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        If fileName.Length > 0 Then
            Dim FL As String = fileName(0)
            If Directory.Exists(FL) Then
                TxtOutputFolder.Text = FL
            End If
        End If
    End Sub

    Private Sub TxtOutputFolder_DragEnter(sender As Object, e As DragEventArgs) Handles TxtOutputFolder.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Public Function ConcatPath(DirName As String, ByVal FileName As String) As String

        Return My.Computer.FileSystem.CombinePath(DirName, FileName)

    End Function
   
    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
        Me.Close()
    End Sub

    Private Sub BtnSelFolder_Click(sender As Object, e As EventArgs) Handles BtnSelFolder.Click
        Using VistaFolderBrowserDialog1 As New Ookii.Dialogs.VistaFolderBrowserDialog
            With VistaFolderBrowserDialog1
                .ShowNewFolderButton = True
                .UseDescriptionForTitle = True
                .Description = "文書出力先選択"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    TxtOutputFolder.Text = .SelectedPath
                End If
            End With
        End Using
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If TxtMasterWord.Text <> "" Then
            If File.Exists(TxtMasterWord.Text) Then
                Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(TxtMasterWord.Text)
            Else
                If Directory.Exists(Path.GetDirectoryName(TxtMasterWord.Text)) Then
                    System.Diagnostics.Process.Start("EXPLORER.EXE", "/n, " & Path.GetDirectoryName(TxtMasterWord.Text))
                End If
            End If
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If TxtOutputFolder.Text <> "" Then
            If Directory.Exists(TxtOutputFolder.Text) Then
                System.Diagnostics.Process.Start("EXPLORER.EXE", "/n, " & TxtOutputFolder.Text)
            End If
        End If
    End Sub

    Private Sub BtnSelWord_Click(sender As Object, e As EventArgs) Handles BtnSelWord.Click
        Dim FL As String = ""
        Using OFD As New OpenFileDialog
            With OFD
                .AddExtension = True
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = ".docx"
                .Filter = "WORD文書(*.doc,*.docx)|*.doc;*.docx|全てのファイル(*.*)|*.*"
                .FilterIndex = 0
                .Multiselect = False
                .RestoreDirectory = True
                .Title = "マスター文書選択"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    FL = .FileName
                End If
            End With
        End Using
        If FL <> "" Then
            TxtMasterWord.Text = FL
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'チェック出来るのは１行だけ
        If e.ColumnIndex = ColFileNameCheck Then
            Dim Index As Integer = e.RowIndex
            For Row As Integer = 0 To DataGridView1.RowCount - 1
                If Row <> Index Then
                    DataGridView1.Rows(Row).Cells(ColFileNameCheck).Value = False
                End If
            Next
        End If
    End Sub

    Private Sub ScreenChange(Value As Boolean)
        MenuClose.Enabled = Value
        MenuExecute.Enabled = Value
        MenuCancel.Enabled = Not Value
        Panel1.Enabled = Value
    End Sub
    Dim _IsWork As Boolean = False

    Private Sub MenuExecute_Click(sender As Object, e As EventArgs) Handles MenuExecute.Click
        DataGridView1.EndEdit()

        Select Case True
            Case String.IsNullOrWhiteSpace(TxtMasterWord.Text)
                MsgBox("マスター文書が設定されていません", 48, "エラー")
                Return
            Case Not File.Exists(TxtMasterWord.Text)
                MsgBox("設定されているマスター文書が存在しません", 48, "エラー")
                Return
            Case String.IsNullOrWhiteSpace(TxtOutputFolder.Text)
                MsgBox("出力先フォルダが設定されていません", 48, "エラー")
                Return
            Case Not Directory.Exists(TxtOutputFolder.Text)
                MsgBox("マスター文書が設定されていません", 48, "エラー")
                Return

        End Select

        If OptSelectWork0.Checked Then
            If MsgBox("差し込みPDFファイルを作成していいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
                Return
            End If
        Else
            If MsgBox("差し込みWORDファイルを作成していいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
                Return
            End If
        End If

        Call ScreenChange(False)
        Application.DoEvents()
        _WorkCancel = False
        _IsWork = True
        With FrmMain.SS.ActiveSheet
            For Row As Integer = 0 To .RowCount - 1
                If FG(.Cells(Row, 0).Value, enum_FG.FG_Boolean) = True Then
                    If OptSelectWork0.Checked Then
                        LblMessage.Text = String.Format("{0}行目 PDF作成中です...", Row + 1)
                    Else
                        LblMessage.Text = String.Format("{0}行目 WORD作成中です...", Row + 1)
                    End If
                    Application.DoEvents()

                    Dim Title As String = ""
                    Dim FDArray As New ArrayList
                    Dim DTArray As New ArrayList

                    For RowD As Integer = 0 To DataGridView1.RowCount - 1
                        Dim FD As String = DataGridView1.Rows(RowD).Cells(ColFieldName).Value
                        Dim SSInsex As Integer = CInt(Replace(DataGridView1.Rows(RowD).Cells(ColSystemFieldName).Value.ToString, "Field", ""))
                        Dim DT As String = FG(.Cells(Row, SSInsex).Value)
                        If DataGridView1.Rows(RowD).Cells(ColFileNameCheck).Value = True Then
                            Title = DT
                        End If
                        FDArray.Add(FD)
                        DTArray.Add(DT)
                    Next


                    Dim OutFile As String = ""
                    If OptSelectWork0.Checked Then
                        'PDFファイル作成
                        If Title = "" Then
                            OutFile = ConcatPath(TxtOutputFolder.Text, String.Format("{0}.pdf", Row + 1))
                        Else
                            OutFile = ConcatPath(TxtOutputFolder.Text, String.Format("{0}.pdf", Title))
                        End If

                        Call CreateWord2PDF(FDArray, DTArray, TxtMasterWord.Text, OutFile)
                    Else
                        'WORD文書作成
                        Dim Extension As String = Path.GetExtension(TxtMasterWord.Text)
                        If Title = "" Then
                            OutFile = ConcatPath(TxtOutputFolder.Text, String.Format("{0}{1}", Row + 1, Extension))
                        Else
                            OutFile = ConcatPath(TxtOutputFolder.Text, String.Format("{0}{1}", Title, Extension))

                        End If

                        Call CreateWord2Word(FDArray, DTArray, TxtMasterWord.Text, OutFile)

                    End If
                End If
                If _WorkCancel Then
                    Exit For
                End If
            Next
        End With
        _IsWork = False
        Call ScreenChange(True)

        If _WorkCancel Then
            LblMessage.Text = "ユーザによりキャンセルされました"
        Else
            If OptSelectWork0.Checked Then
                LblMessage.Text = "PDF作成完了しました"
            Else
                LblMessage.Text = "WORD作成完了しました"
            End If
        End If
    End Sub

    Private Sub MenuCancel_Click(sender As Object, e As EventArgs) Handles MenuCancel.Click
        _WorkCancel = True
        LblMessage.Text = "キャンセル中です。しばらくお待ちください"
        Application.DoEvents()
    End Sub

    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If DataGridView1.RowCount > 0 Then
                ContextMenuStrip1.Show(DataGridView1, e.Location)
            End If
        End If
    End Sub

    Private Sub MenuFieldName_Click(sender As Object, e As EventArgs) Handles MenuFieldName.Click
        If DataGridView1.RowCount > 0 Then
            If DataGridView1.SelectedCells.Count > 0 Then
                Dim Row As Integer = DataGridView1.SelectedCells(0).RowIndex
                Dim FName As String = DataGridView1.Rows(Row).Cells(ColFieldName).Value
                Try
                    Clipboard.SetText(String.Format("<{0}>", FName))
                    MsgBox("クリップボードへ送信しました", 64, "情報")
                Catch ex As Exception
                    MsgBox("クリップボードへ送信失敗しました", 48, "エラー")
                End Try
            End If

        End If
    End Sub

    Private Sub MenuFieldName_All_Click(sender As Object, e As EventArgs) Handles MenuFieldName_All.Click
        If DataGridView1.RowCount > 0 Then
            If DataGridView1.SelectedCells.Count > 0 Then
                Dim Dat As String = ""
                For Row As Integer = 0 To DataGridView1.RowCount - 1
                    Dim FName As String = DataGridView1.Rows(Row).Cells(ColFieldName).Value
                    Dat &= String.Format("<{0}>", FName) & vbCrLf
                Next
              
                Try
                    Clipboard.SetText(Dat)
                    MsgBox("クリップボードへ送信しました", 64, "情報")
                Catch ex As Exception
                    MsgBox("クリップボードへ送信失敗しました", 48, "エラー")
                End Try
            End If

        End If
    End Sub
End Class