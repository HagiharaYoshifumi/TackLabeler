Public Class Form2
    Dim _IsSet As Boolean = False
  
    Private Sub PictureBox1_Resize(sender As Object, e As EventArgs) Handles PictureBox1.Resize

        Me.Size = New Size(PictureBox1.Width + _W, PictureBox1.Height + _H)
        'If _IsSet Then
        '    _MemSize = Me.Size
        '    _IsSet = False
        'End If

    End Sub
    Dim _W As Integer = 43
    Dim _H As Integer = 67
    Dim _MemSize As Size
    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

End Class