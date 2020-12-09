<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExcelInsData
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuFieldName_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuFieldName = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSelWord = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.BtnSelFolder = New System.Windows.Forms.Button()
        Me.LblMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TxtMasterExcel = New System.Windows.Forms.TextBox()
        Me.TxtOutputFolder = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbSelectSheet = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuExecute = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuFieldName_All
        '
        Me.MenuFieldName_All.Name = "MenuFieldName_All"
        Me.MenuFieldName_All.Size = New System.Drawing.Size(220, 22)
        Me.MenuFieldName_All.Text = "全てのフィールド名コピー"
        '
        'MenuFieldName
        '
        Me.MenuFieldName.Name = "MenuFieldName"
        Me.MenuFieldName.Size = New System.Drawing.Size(220, 22)
        Me.MenuFieldName.Text = "フィールド名コピー"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFieldName, Me.ToolStripSeparator1, Me.MenuFieldName_All})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(221, 54)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(217, 6)
        '
        'BtnSelWord
        '
        Me.BtnSelWord.Location = New System.Drawing.Point(490, 7)
        Me.BtnSelWord.Name = "BtnSelWord"
        Me.BtnSelWord.Size = New System.Drawing.Size(36, 23)
        Me.BtnSelWord.TabIndex = 2
        Me.BtnSelWord.Text = "..."
        Me.BtnSelWord.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 306)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(350, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "ファイル名フィールドが無指定の場合は、出力ファイル名は番号となります。"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(12, 63)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(76, 12)
        Me.LinkLabel2.TabIndex = 5
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "出力先フォルダ"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 12)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(93, 12)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "マスターExcel文書"
        '
        'BtnSelFolder
        '
        Me.BtnSelFolder.Location = New System.Drawing.Point(490, 60)
        Me.BtnSelFolder.Name = "BtnSelFolder"
        Me.BtnSelFolder.Size = New System.Drawing.Size(36, 23)
        Me.BtnSelFolder.TabIndex = 7
        Me.BtnSelFolder.Text = "..."
        Me.BtnSelFolder.UseVisualStyleBackColor = True
        '
        'LblMessage
        '
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(425, 18)
        Me.LblMessage.Spring = True
        Me.LblMessage.Text = "."
        Me.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblMessage, Me.Progress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 353)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(542, 23)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TxtMasterExcel
        '
        Me.TxtMasterExcel.AllowDrop = True
        Me.TxtMasterExcel.Location = New System.Drawing.Point(108, 9)
        Me.TxtMasterExcel.Name = "TxtMasterExcel"
        Me.TxtMasterExcel.Size = New System.Drawing.Size(376, 19)
        Me.TxtMasterExcel.TabIndex = 1
        '
        'TxtOutputFolder
        '
        Me.TxtOutputFolder.AllowDrop = True
        Me.TxtOutputFolder.Location = New System.Drawing.Point(108, 60)
        Me.TxtOutputFolder.Name = "TxtOutputFolder"
        Me.TxtOutputFolder.Size = New System.Drawing.Size(376, 19)
        Me.TxtOutputFolder.TabIndex = 6
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column3, Me.Column2})
        Me.DataGridView1.Location = New System.Drawing.Point(14, 91)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(512, 209)
        Me.DataGridView1.TabIndex = 11
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "ファイル名"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 57
        '
        'Column1
        '
        Me.Column1.HeaderText = "フィールド名"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "データサンプル"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.CmbSelectSheet)
        Me.Panel1.Controls.Add(Me.BtnSelWord)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.TxtMasterExcel)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.TxtOutputFolder)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.BtnSelFolder)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(542, 327)
        Me.Panel1.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "対象シート名"
        '
        'CmbSelectSheet
        '
        Me.CmbSelectSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSelectSheet.FormattingEnabled = True
        Me.CmbSelectSheet.Location = New System.Drawing.Point(108, 34)
        Me.CmbSelectSheet.Name = "CmbSelectSheet"
        Me.CmbSelectSheet.Size = New System.Drawing.Size(376, 20)
        Me.CmbSelectSheet.TabIndex = 4
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuClose, Me.MenuExecute, Me.MenuCancel})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(542, 26)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuClose
        '
        Me.MenuClose.Name = "MenuClose"
        Me.MenuClose.Size = New System.Drawing.Size(74, 22)
        Me.MenuClose.Text = "閉じる(&C)"
        '
        'MenuExecute
        '
        Me.MenuExecute.Name = "MenuExecute"
        Me.MenuExecute.Size = New System.Drawing.Size(85, 22)
        Me.MenuExecute.Text = "作業実行(&E)"
        '
        'MenuCancel
        '
        Me.MenuCancel.Enabled = False
        Me.MenuCancel.Name = "MenuCancel"
        Me.MenuCancel.Size = New System.Drawing.Size(86, 22)
        Me.MenuCancel.Text = "作業中止(&C)"
        '
        'Progress
        '
        Me.Progress.Name = "Progress"
        Me.Progress.Size = New System.Drawing.Size(100, 17)
        Me.Progress.Step = 1
        '
        'FrmExcelInsData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 376)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmExcelInsData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "差し込み文書作成(Excel文書)"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuFieldName_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuFieldName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSelWord As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents BtnSelFolder As System.Windows.Forms.Button
    Friend WithEvents LblMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TxtMasterExcel As System.Windows.Forms.TextBox
    Friend WithEvents TxtOutputFolder As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmbSelectSheet As System.Windows.Forms.ComboBox
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuExecute As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Progress As System.Windows.Forms.ToolStripProgressBar
End Class
