<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNumber
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNumber))
        Me.BtnGO = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TxtStartNo = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtZero = New System.Windows.Forms.NumericUpDown()
        Me.ChkFront0 = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ChkTackGoto = New System.Windows.Forms.CheckBox()
        CType(Me.TxtStartNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtZero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnGO
        '
        Me.BtnGO.Location = New System.Drawing.Point(186, 12)
        Me.BtnGO.Name = "BtnGO"
        Me.BtnGO.Size = New System.Drawing.Size(89, 26)
        Me.BtnGO.TabIndex = 6
        Me.BtnGO.Text = "続行(&O)"
        Me.BtnGO.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(186, 46)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 26)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TxtStartNo
        '
        Me.TxtStartNo.Location = New System.Drawing.Point(86, 12)
        Me.TxtStartNo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtStartNo.Name = "TxtStartNo"
        Me.TxtStartNo.Size = New System.Drawing.Size(91, 19)
        Me.TxtStartNo.TabIndex = 1
        Me.TxtStartNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtStartNo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 12)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "付帯ゼロ桁数(&F)"
        '
        'TxtZero
        '
        Me.TxtZero.Enabled = False
        Me.TxtZero.Location = New System.Drawing.Point(105, 59)
        Me.TxtZero.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtZero.Name = "TxtZero"
        Me.TxtZero.Size = New System.Drawing.Size(72, 19)
        Me.TxtZero.TabIndex = 4
        Me.TxtZero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtZero.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ChkFront0
        '
        Me.ChkFront0.AutoSize = True
        Me.ChkFront0.Location = New System.Drawing.Point(12, 37)
        Me.ChkFront0.Name = "ChkFront0"
        Me.ChkFront0.Size = New System.Drawing.Size(153, 16)
        Me.ChkFront0.TabIndex = 2
        Me.ChkFront0.Text = "番号の前にゼロを付ける(&Z)"
        Me.ChkFront0.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "開始番号(&S)"
        '
        'ChkTackGoto
        '
        Me.ChkTackGoto.AutoSize = True
        Me.ChkTackGoto.Location = New System.Drawing.Point(14, 84)
        Me.ChkTackGoto.Name = "ChkTackGoto"
        Me.ChkTackGoto.Size = New System.Drawing.Size(139, 16)
        Me.ChkTackGoto.TabIndex = 5
        Me.ChkTackGoto.Text = "シールごとに採番する(&G)"
        Me.ChkTackGoto.UseVisualStyleBackColor = True
        '
        'FrmNumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(285, 108)
        Me.Controls.Add(Me.ChkTackGoto)
        Me.Controls.Add(Me.TxtZero)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.ChkFront0)
        Me.Controls.Add(Me.BtnGO)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtStartNo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNumber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ナンバリング印刷"
        CType(Me.TxtStartNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtZero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnGO As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents TxtStartNo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkFront0 As System.Windows.Forms.CheckBox
    Friend WithEvents TxtZero As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ChkTackGoto As System.Windows.Forms.CheckBox
End Class
