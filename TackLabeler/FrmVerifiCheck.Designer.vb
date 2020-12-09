<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVerifiCheck
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.OptViriMode2 = New System.Windows.Forms.RadioButton()
        Me.OptViriMode0 = New System.Windows.Forms.RadioButton()
        Me.BtnVerify = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblNGCount = New System.Windows.Forms.Label()
        Me.LblOKCount = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.OptViriMode1 = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.BtnVerify)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.BtnCancel)
        Me.Panel1.Controls.Add(Me.BtnOK)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 261)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(380, 145)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OptViriMode1)
        Me.GroupBox2.Controls.Add(Me.OptViriMode2)
        Me.GroupBox2.Controls.Add(Me.OptViriMode0)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(245, 43)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "照合方法"
        '
        'OptViriMode2
        '
        Me.OptViriMode2.AutoSize = True
        Me.OptViriMode2.Location = New System.Drawing.Point(164, 18)
        Me.OptViriMode2.Name = "OptViriMode2"
        Me.OptViriMode2.Size = New System.Drawing.Size(71, 16)
        Me.OptViriMode2.TabIndex = 0
        Me.OptViriMode2.Text = "曖昧一致"
        Me.OptViriMode2.UseVisualStyleBackColor = True
        '
        'OptViriMode0
        '
        Me.OptViriMode0.AutoSize = True
        Me.OptViriMode0.Checked = True
        Me.OptViriMode0.Location = New System.Drawing.Point(6, 18)
        Me.OptViriMode0.Name = "OptViriMode0"
        Me.OptViriMode0.Size = New System.Drawing.Size(71, 16)
        Me.OptViriMode0.TabIndex = 0
        Me.OptViriMode0.TabStop = True
        Me.OptViriMode0.Text = "完全一致"
        Me.OptViriMode0.UseVisualStyleBackColor = True
        '
        'BtnVerify
        '
        Me.BtnVerify.Location = New System.Drawing.Point(183, 111)
        Me.BtnVerify.Name = "BtnVerify"
        Me.BtnVerify.Size = New System.Drawing.Size(79, 26)
        Me.BtnVerify.TabIndex = 2
        Me.BtnVerify.Text = "照合確認"
        Me.BtnVerify.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(185, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "１行ごとに検索データを入れてください。"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(289, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "選択タブの１列目のデータに一致する行にチェックを入れます。"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblNGCount)
        Me.GroupBox1.Controls.Add(Me.LblOKCount)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 99)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 39)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "照合確認"
        '
        'LblNGCount
        '
        Me.LblNGCount.AutoSize = True
        Me.LblNGCount.Location = New System.Drawing.Point(86, 19)
        Me.LblNGCount.Name = "LblNGCount"
        Me.LblNGCount.Size = New System.Drawing.Size(58, 12)
        Me.LblNGCount.TabIndex = 1
        Me.LblNGCount.Text = "データなし："
        '
        'LblOKCount
        '
        Me.LblOKCount.AutoSize = True
        Me.LblOKCount.Location = New System.Drawing.Point(6, 19)
        Me.LblOKCount.Name = "LblOKCount"
        Me.LblOKCount.Size = New System.Drawing.Size(57, 12)
        Me.LblOKCount.TabIndex = 0
        Me.LblOKCount.Text = "データあり："
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(279, 111)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 26)
        Me.BtnCancel.TabIndex = 0
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(279, 79)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(89, 26)
        Me.BtnOK.TabIndex = 0
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(380, 261)
        Me.TextBox1.TabIndex = 1
        '
        'OptViriMode1
        '
        Me.OptViriMode1.AutoSize = True
        Me.OptViriMode1.Location = New System.Drawing.Point(85, 18)
        Me.OptViriMode1.Name = "OptViriMode1"
        Me.OptViriMode1.Size = New System.Drawing.Size(71, 16)
        Me.OptViriMode1.TabIndex = 1
        Me.OptViriMode1.Text = "先頭一致"
        Me.OptViriMode1.UseVisualStyleBackColor = True
        '
        'FrmVerifiCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 406)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVerifiCheck"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "データ照合チェック"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnVerify As System.Windows.Forms.Button
    Friend WithEvents LblNGCount As System.Windows.Forms.Label
    Friend WithEvents LblOKCount As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OptViriMode2 As System.Windows.Forms.RadioButton
    Friend WithEvents OptViriMode0 As System.Windows.Forms.RadioButton
    Friend WithEvents OptViriMode1 As System.Windows.Forms.RadioButton
End Class
