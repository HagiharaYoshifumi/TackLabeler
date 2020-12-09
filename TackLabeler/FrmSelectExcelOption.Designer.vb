<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectExcelOption
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
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.ChkDelSpace = New System.Windows.Forms.CheckBox()
        Me.ChkDelCR = New System.Windows.Forms.CheckBox()
        Me.ChkOutHeader = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(176, 12)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(89, 26)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(176, 44)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 26)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'ChkDelSpace
        '
        Me.ChkDelSpace.AutoSize = True
        Me.ChkDelSpace.Location = New System.Drawing.Point(12, 12)
        Me.ChkDelSpace.Name = "ChkDelSpace"
        Me.ChkDelSpace.Size = New System.Drawing.Size(153, 16)
        Me.ChkDelSpace.TabIndex = 4
        Me.ChkDelSpace.Text = "入力スペースを除去する(&S)"
        Me.ChkDelSpace.UseVisualStyleBackColor = True
        '
        'ChkDelCR
        '
        Me.ChkDelCR.AutoSize = True
        Me.ChkDelCR.Location = New System.Drawing.Point(12, 36)
        Me.ChkDelCR.Name = "ChkDelCR"
        Me.ChkDelCR.Size = New System.Drawing.Size(143, 16)
        Me.ChkDelCR.TabIndex = 5
        Me.ChkDelCR.Text = "改行コードを除去する(&C)"
        Me.ChkDelCR.UseVisualStyleBackColor = True
        '
        'ChkOutHeader
        '
        Me.ChkOutHeader.AutoSize = True
        Me.ChkOutHeader.Location = New System.Drawing.Point(12, 60)
        Me.ChkOutHeader.Name = "ChkOutHeader"
        Me.ChkOutHeader.Size = New System.Drawing.Size(128, 16)
        Me.ChkOutHeader.TabIndex = 5
        Me.ChkOutHeader.Text = "ヘッダーを出力する(&H)"
        Me.ChkOutHeader.UseVisualStyleBackColor = True
        '
        'FrmSelectExcelOption
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(271, 90)
        Me.Controls.Add(Me.ChkOutHeader)
        Me.Controls.Add(Me.ChkDelCR)
        Me.Controls.Add(Me.ChkDelSpace)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelectExcelOption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Excel保存オプション"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents ChkDelSpace As System.Windows.Forms.CheckBox
    Friend WithEvents ChkDelCR As System.Windows.Forms.CheckBox
    Friend WithEvents ChkOutHeader As System.Windows.Forms.CheckBox
End Class
