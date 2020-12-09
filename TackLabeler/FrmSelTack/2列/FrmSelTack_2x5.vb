Public Class FrmSelTack_2x5
    Const Col As Integer = 2
    Const Row As Integer = 5

    Dim _TackSpace As Integer = 0
    Dim _LblArray As New List(Of Label)
    Property TackSpace As Integer
        Get
            Return _TackSpace
        End Get
        Set(value As Integer)
            _TackSpace = value
        End Set
    End Property
    Private Sub LblSw_Click(sender As Object, e As EventArgs)
        Dim Itm As Label = CType(sender, Label)
        For i As Integer = 0 To _LblArray.Count - 1
            If _LblArray(i).Name = Itm.Name Then
                If _LblArray(i).BackColor = Color.LightGray Then
                    _TackSpace = i
                Else
                    _TackSpace = i + 1
                End If
                Call LblMode()
                Return
            End If
        Next
    End Sub

    Private Sub Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        For i As Integer = 0 To 50
            Dim obj As Object = FindControlByFieldName(Me, String.Format("LblSw{0}", i)) 'コントロールを探す
            If TypeOf obj Is Label Then 'コントロールがラベルなら
                Dim Lbl As Label = CType(obj, Label)
                Lbl.Text = LbelNo(Row, Col, i) & "印刷する"
                _LblArray.Add(Lbl)
                AddHandler Lbl.Click, AddressOf LblSw_Click 'イベント設定
            End If
        Next
        Call LblMode()
    End Sub
    Private Sub LblMode()
        For i As Integer = 0 To _LblArray.Count - 1
            If i + 1 > _TackSpace Then
                Call LblSet(i, True)
            Else
                Call LblSet(i, False)
            End If
        Next
    End Sub
    Private Sub LblSet(Index As Integer, Mode As Boolean)
        If Index >= 0 AndAlso Index <= _LblArray.Count - 1 Then
            If Mode Then
                _LblArray(Index).BackColor = Color.White
                _LblArray(Index).Text = LbelNo(Row, Col, Index) & "印刷する"
            Else
                _LblArray(Index).BackColor = Color.LightGray
                _LblArray(Index).Text = LbelNo(Row, Col, Index) & "印刷しない"
            End If
        End If
    End Sub

    Private Sub BtnAllUnCheck_Click(sender As Object, e As EventArgs) Handles BtnAllUnCheck.Click
        _TackSpace = _LblArray.Count
        Call LblMode()
    End Sub

    Private Sub BtnAllCehck_Click(sender As Object, e As EventArgs) Handles BtnAllCehck.Click
        _TackSpace = 0
        Call LblMode()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class