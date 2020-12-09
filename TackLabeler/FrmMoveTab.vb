Public Class FrmMoveTab
    Dim Sql As String = ""
    Private Sub GetData()
        Try
            Sql = "SELECT * FROM TabData ORDER BY IndexNo"
            With SS.ActiveSheet
                .RowCount = 0
                Using CMD As New OleDb.OleDbCommand(Sql, CN)
                    Using DR As OleDb.OleDbDataReader = CMD.ExecuteReader
                        Do While DR.Read
                            Dim Row As Integer = SPREAD_InsertRow(SS, , 20)
                            .Cells(Row, 0).Value = FG(DR("TabName"))
                            .Cells(Row, 1).Value = FG(DR("IndexNo"), enum_FG.FG_Numeric)
                        Loop
                    End Using
                End Using
            End With
        Catch ex As Exception
            'MsgBox(ex.Message)
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")
            BtnOK.Enabled = False
        End Try
      
    End Sub
    Private Function SetData() As Boolean
        Try
            Sql = "UPDATE TabData SET IndexNo=0-IndexNo-100"
            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                CMD.ExecuteNonQuery()
            End Using
            Sql = "UPDATE AddressData SET TabIndexNo=0-TabIndexNo-100"
            Using CMD As New OleDb.OleDbCommand(Sql, CN)
                CMD.ExecuteNonQuery()
            End Using

            With SS.ActiveSheet
                For Row As Integer = 0 To .RowCount - 1
                    Dim _FromNo As Integer = .Cells(Row, 1).Value

                    Sql = String.Format("UPDATE TabData SET IndexNo={0} WHERE IndexNo=0-{1}-100", Row, _FromNo)
                    Using CMD As New OleDb.OleDbCommand(Sql, CN)
                        CMD.ExecuteNonQuery()
                    End Using
                    Sql = String.Format("UPDATE AddressData SET TabIndexNo={0} WHERE TabIndexNo=0-{1}-100", Row, _FromNo)
                    Using CMD As New OleDb.OleDbCommand(Sql, CN)
                        CMD.ExecuteNonQuery()
                    End Using
                Next
            End With
            Return True
        Catch ex As Exception
            'MsgBox(ex.Message)
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")
            Return False
        End Try
    End Function

    Private Sub FrmMoveTab_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmMoveTab_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call SPREAD_Initial(SS)
        Call GetData()
        Call SPREAD_FitColWidth(SS, New Integer() {0})

    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If SetData() Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub SS_Resize(sender As Object, e As EventArgs) Handles SS.Resize
        Call SPREAD_FitColWidth(SS, New Integer() {0})
    End Sub
End Class