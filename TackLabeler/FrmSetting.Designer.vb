<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSetting
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
        Me.ChkAutoZipConvert = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtLicenseCode = New System.Windows.Forms.TextBox()
        Me.ChkPreviewIsWide = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(329, 131)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(86, 26)
        Me.BtnOK.TabIndex = 4
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(421, 131)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(86, 26)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'ChkAutoZipConvert
        '
        Me.ChkAutoZipConvert.AutoSize = True
        Me.ChkAutoZipConvert.Location = New System.Drawing.Point(12, 12)
        Me.ChkAutoZipConvert.Name = "ChkAutoZipConvert"
        Me.ChkAutoZipConvert.Size = New System.Drawing.Size(139, 16)
        Me.ChkAutoZipConvert.TabIndex = 0
        Me.ChkAutoZipConvert.Text = "郵便番号検索を行う(&Z)"
        Me.ChkAutoZipConvert.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "アクティベーションコード(&A)"
        '
        'TxtLicenseCode
        '
        Me.TxtLicenseCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtLicenseCode.Location = New System.Drawing.Point(12, 78)
        Me.TxtLicenseCode.Multiline = True
        Me.TxtLicenseCode.Name = "TxtLicenseCode"
        Me.TxtLicenseCode.ReadOnly = True
        Me.TxtLicenseCode.Size = New System.Drawing.Size(495, 47)
        Me.TxtLicenseCode.TabIndex = 3
        '
        'ChkPreviewIsWide
        '
        Me.ChkPreviewIsWide.AutoSize = True
        Me.ChkPreviewIsWide.Location = New System.Drawing.Point(12, 34)
        Me.ChkPreviewIsWide.Name = "ChkPreviewIsWide"
        Me.ChkPreviewIsWide.Size = New System.Drawing.Size(263, 16)
        Me.ChkPreviewIsWide.TabIndex = 1
        Me.ChkPreviewIsWide.Text = "印刷プレビュー作成時に「用紙幅」を基準にする(&W)"
        Me.ChkPreviewIsWide.UseVisualStyleBackColor = True
        '
        'FrmSetting
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(519, 165)
        Me.Controls.Add(Me.ChkPreviewIsWide)
        Me.Controls.Add(Me.TxtLicenseCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChkAutoZipConvert)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents ChkAutoZipConvert As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtLicenseCode As System.Windows.Forms.TextBox
    Friend WithEvents ChkPreviewIsWide As System.Windows.Forms.CheckBox
End Class
