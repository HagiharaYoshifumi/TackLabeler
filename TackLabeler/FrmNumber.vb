Public Class FrmNumber
    Dim _StartNo As Integer
    Dim _AddZero As Integer
    Dim _TackGoto As Boolean
    Property StartNo As Integer
        Get
            Return _StartNo
        End Get
        Set(value As Integer)
            _StartNo = value
        End Set
    End Property
    Property AddZero As Integer
        Get
            Return _AddZero
        End Get
        Set(value As Integer)
            _AddZero = value
        End Set
    End Property
    Property TackGoto As Boolean
        Get
            Return _TackGoto
        End Get
        Set(value As Boolean)
            _TackGoto = value
        End Set
    End Property
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmNumber_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
  
    Private Sub BtnGO_Click(sender As Object, e As EventArgs) Handles BtnGO.Click
        _StartNo = TxtStartNo.Value
        If ChkFront0.Checked Then
            _AddZero = TxtZero.Value
        Else
            _AddZero = -1
        End If
        _TackGoto = ChkTackGoto.Checked
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ChkFront0_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFront0.CheckedChanged
        TxtZero.Enabled = ChkFront0.Checked
    End Sub

    Private Sub FrmNumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class