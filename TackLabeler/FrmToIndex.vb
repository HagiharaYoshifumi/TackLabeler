Public Class FrmToIndex
    Dim Sql As String = ""
    Dim _MyIndex As Integer = 0
    Dim _SelIndex As Integer = 0
    Dim _IsCopy As Boolean = False
    Property MyIndex As Integer
        Get
            Return _MyIndex
        End Get
        Set(value As Integer)
            _MyIndex = value
        End Set
    End Property
    Property SelIndex As Integer
        Get
            Return _SelIndex
        End Get
        Set(value As Integer)
            _SelIndex = value
        End Set
    End Property
    Property IsCopy As Boolean
        Get
            Return _IsCopy
        End Get
        Set(value As Boolean)
            _IsCopy = value
        End Set
    End Property

    Private Sub GetIndex()
        ListBox1.Items.Clear()
        ListBox1.DisplayMember = "Value"
        ListBox1.ValueMember = "Key"
        Try
            Dim _PIndex As Integer = 0
            Sql = String.Format("SELECT * FROM TabData WHERE IndexNo={0}", _MyIndex)
            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                Using Dr As OleDb.OleDbDataReader = CMD.ExecuteReader
                    If Dr.Read Then
                        _PIndex = FG(Dr("UsePaperIndex"), enum_FG.FG_Numeric)
                    End If
                End Using
            End Using
            Sql = String.Format("SELECT * FROM TabData WHERE IndexNo<>{0} AND UsePaperIndex={1} ORDER BY IndexNo", _MyIndex, _PIndex)
            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                Using DR As OleDb.OleDbDataReader = CMD.ExecuteReader
                    Do While DR.Read
                        Dim Index As Integer = FG(DR("IndexNo"), enum_FG.FG_Numeric)
                        Dim Txt As String = FG(DR("TabName"))
                        ListBox1.Items.Add(New DictionaryEntry(Index, Txt))
                    Loop
                End Using
            End Using

            If ListBox1.Items.Count > 0 Then
                ListBox1.SelectedIndex = 0
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")
            Button1.Enabled = False
        End Try

    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmToIndex_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmToIndex_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call GetIndex()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Item As DictionaryEntry = ListBox1.SelectedItem
        _SelIndex = CInt(Item.Key)
        _IsCopy = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Item As DictionaryEntry = ListBox1.SelectedItem
        _SelIndex = CInt(Item.Key)
        _IsCopy = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class