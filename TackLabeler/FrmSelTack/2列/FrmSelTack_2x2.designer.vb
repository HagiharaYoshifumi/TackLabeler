<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelTack_2x2
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnAllUnCheck = New System.Windows.Forms.Button()
        Me.BtnAllCehck = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.LblSw3 = New System.Windows.Forms.Label()
        Me.LblSw2 = New System.Windows.Forms.Label()
        Me.LblSw1 = New System.Windows.Forms.Label()
        Me.LblSw0 = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnOK)
        Me.Panel1.Controls.Add(Me.BtnAllUnCheck)
        Me.Panel1.Controls.Add(Me.BtnAllCehck)
        Me.Panel1.Controls.Add(Me.BtnCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 381)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(443, 40)
        Me.Panel1.TabIndex = 0
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(252, 6)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(89, 26)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnAllUnCheck
        '
        Me.BtnAllUnCheck.Location = New System.Drawing.Point(98, 6)
        Me.BtnAllUnCheck.Name = "BtnAllUnCheck"
        Me.BtnAllUnCheck.Size = New System.Drawing.Size(89, 26)
        Me.BtnAllUnCheck.TabIndex = 2
        Me.BtnAllUnCheck.Text = "全て印刷しない"
        Me.BtnAllUnCheck.UseVisualStyleBackColor = True
        '
        'BtnAllCehck
        '
        Me.BtnAllCehck.Location = New System.Drawing.Point(3, 6)
        Me.BtnAllCehck.Name = "BtnAllCehck"
        Me.BtnAllCehck.Size = New System.Drawing.Size(89, 26)
        Me.BtnAllCehck.TabIndex = 1
        Me.BtnAllCehck.Text = "全て印刷"
        Me.BtnAllCehck.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(347, 6)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 26)
        Me.BtnCancel.TabIndex = 0
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.LblSw3)
        Me.C1Sizer1.Controls.Add(Me.LblSw2)
        Me.C1Sizer1.Controls.Add(Me.LblSw1)
        Me.C1Sizer1.Controls.Add(Me.LblSw0)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = "47.50656167979:False:False;49.3438320209974:False:False;" & Global.Microsoft.VisualBasic.ChrW(9) & "48.7584650112867:False:F" & _
    "alse;48.5327313769752:False:False;"
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(443, 381)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.Text = "C1Sizer1"
        '
        'LblSw3
        '
        Me.LblSw3.BackColor = System.Drawing.Color.White
        Me.LblSw3.Location = New System.Drawing.Point(224, 189)
        Me.LblSw3.Name = "LblSw3"
        Me.LblSw3.Size = New System.Drawing.Size(215, 188)
        Me.LblSw3.TabIndex = 0
        Me.LblSw3.Text = "印刷する"
        Me.LblSw3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSw2
        '
        Me.LblSw2.BackColor = System.Drawing.Color.White
        Me.LblSw2.Location = New System.Drawing.Point(4, 189)
        Me.LblSw2.Name = "LblSw2"
        Me.LblSw2.Size = New System.Drawing.Size(216, 188)
        Me.LblSw2.TabIndex = 0
        Me.LblSw2.Text = "印刷する"
        Me.LblSw2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSw1
        '
        Me.LblSw1.BackColor = System.Drawing.Color.White
        Me.LblSw1.Location = New System.Drawing.Point(224, 4)
        Me.LblSw1.Name = "LblSw1"
        Me.LblSw1.Size = New System.Drawing.Size(215, 181)
        Me.LblSw1.TabIndex = 0
        Me.LblSw1.Text = "印刷する"
        Me.LblSw1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSw0
        '
        Me.LblSw0.BackColor = System.Drawing.Color.White
        Me.LblSw0.Location = New System.Drawing.Point(4, 4)
        Me.LblSw0.Name = "LblSw0"
        Me.LblSw0.Size = New System.Drawing.Size(216, 181)
        Me.LblSw0.TabIndex = 0
        Me.LblSw0.Text = "印刷する"
        Me.LblSw0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmSelTack_2x2
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(443, 421)
        Me.Controls.Add(Me.C1Sizer1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelTack_2x2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "タック選択(2X2=4)"
        Me.Panel1.ResumeLayout(False)
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents LblSw3 As System.Windows.Forms.Label
    Friend WithEvents LblSw2 As System.Windows.Forms.Label
    Friend WithEvents LblSw1 As System.Windows.Forms.Label
    Friend WithEvents LblSw0 As System.Windows.Forms.Label
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnAllUnCheck As System.Windows.Forms.Button
    Friend WithEvents BtnAllCehck As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
End Class
