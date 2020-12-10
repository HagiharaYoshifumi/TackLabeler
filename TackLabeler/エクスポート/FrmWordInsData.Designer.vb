<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWordInsData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWordInsData))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtMasterWord = New System.Windows.Forms.TextBox()
        Me.TxtOutputFolder = New System.Windows.Forms.TextBox()
        Me.OptSelectWork0 = New System.Windows.Forms.RadioButton()
        Me.OptSelectWork1 = New System.Windows.Forms.RadioButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.BtnSelWord = New System.Windows.Forms.Button()
        Me.BtnSelFolder = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuFieldName = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuFieldName_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuExecute = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnExecute = New GrapeCity.Win.Buttons.GcButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column3, Me.Column2})
        Me.DataGridView1.Location = New System.Drawing.Point(14, 83)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(512, 209)
        Me.DataGridView1.TabIndex = 0
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
        'TxtMasterWord
        '
        Me.TxtMasterWord.AllowDrop = True
        Me.TxtMasterWord.Location = New System.Drawing.Point(108, 9)
        Me.TxtMasterWord.Name = "TxtMasterWord"
        Me.TxtMasterWord.Size = New System.Drawing.Size(314, 19)
        Me.TxtMasterWord.TabIndex = 1
        '
        'TxtOutputFolder
        '
        Me.TxtOutputFolder.AllowDrop = True
        Me.TxtOutputFolder.Location = New System.Drawing.Point(108, 36)
        Me.TxtOutputFolder.Name = "TxtOutputFolder"
        Me.TxtOutputFolder.Size = New System.Drawing.Size(314, 19)
        Me.TxtOutputFolder.TabIndex = 1
        '
        'OptSelectWork0
        '
        Me.OptSelectWork0.AutoSize = True
        Me.OptSelectWork0.Checked = True
        Me.OptSelectWork0.Location = New System.Drawing.Point(108, 61)
        Me.OptSelectWork0.Name = "OptSelectWork0"
        Me.OptSelectWork0.Size = New System.Drawing.Size(112, 16)
        Me.OptSelectWork0.TabIndex = 2
        Me.OptSelectWork0.TabStop = True
        Me.OptSelectWork0.Text = "PDFファイルを作成"
        Me.OptSelectWork0.UseVisualStyleBackColor = True
        '
        'OptSelectWork1
        '
        Me.OptSelectWork1.AutoSize = True
        Me.OptSelectWork1.Location = New System.Drawing.Point(226, 61)
        Me.OptSelectWork1.Name = "OptSelectWork1"
        Me.OptSelectWork1.Size = New System.Drawing.Size(105, 16)
        Me.OptSelectWork1.TabIndex = 2
        Me.OptSelectWork1.Text = "Word文書を作成"
        Me.OptSelectWork1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblMessage, Me.Progress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 349)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(542, 23)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblMessage
        '
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(425, 18)
        Me.LblMessage.Spring = True
        Me.LblMessage.Text = "."
        Me.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Progress
        '
        Me.Progress.Name = "Progress"
        Me.Progress.Size = New System.Drawing.Size(100, 17)
        Me.Progress.Step = 1
        '
        'BtnSelWord
        '
        Me.BtnSelWord.Location = New System.Drawing.Point(428, 7)
        Me.BtnSelWord.Name = "BtnSelWord"
        Me.BtnSelWord.Size = New System.Drawing.Size(36, 23)
        Me.BtnSelWord.TabIndex = 6
        Me.BtnSelWord.Text = "..."
        Me.BtnSelWord.UseVisualStyleBackColor = True
        '
        'BtnSelFolder
        '
        Me.BtnSelFolder.Location = New System.Drawing.Point(428, 36)
        Me.BtnSelFolder.Name = "BtnSelFolder"
        Me.BtnSelFolder.Size = New System.Drawing.Size(36, 23)
        Me.BtnSelFolder.TabIndex = 6
        Me.BtnSelFolder.Text = "..."
        Me.BtnSelFolder.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 12)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(90, 12)
        Me.LinkLabel1.TabIndex = 7
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "マスターWord文書"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(12, 39)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(76, 12)
        Me.LinkLabel2.TabIndex = 7
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "出力先フォルダ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "作業内容"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 298)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(350, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "ファイル名フィールドが無指定の場合は、出力ファイル名は番号となります。"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnExecute)
        Me.Panel1.Controls.Add(Me.BtnSelWord)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TxtMasterWord)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.TxtOutputFolder)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.OptSelectWork0)
        Me.Panel1.Controls.Add(Me.BtnSelFolder)
        Me.Panel1.Controls.Add(Me.OptSelectWork1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(542, 323)
        Me.Panel1.TabIndex = 10
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFieldName, Me.ToolStripSeparator1, Me.MenuFieldName_All})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(221, 54)
        '
        'MenuFieldName
        '
        Me.MenuFieldName.Name = "MenuFieldName"
        Me.MenuFieldName.Size = New System.Drawing.Size(220, 22)
        Me.MenuFieldName.Text = "フィールド名コピー"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(217, 6)
        '
        'MenuFieldName_All
        '
        Me.MenuFieldName_All.Name = "MenuFieldName_All"
        Me.MenuFieldName_All.Size = New System.Drawing.Size(220, 22)
        Me.MenuFieldName_All.Text = "全てのフィールド名コピー"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuClose, Me.MenuExecute, Me.MenuCancel})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(542, 26)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuClose
        '
        Me.MenuClose.Name = "MenuClose"
        Me.MenuClose.Size = New System.Drawing.Size(74, 22)
        Me.MenuClose.Text = "閉じる(&X)"
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
        'BtnExecute
        '
        Me.BtnExecute.Image = CType(resources.GetObject("BtnExecute.Image"), System.Drawing.Image)
        Me.BtnExecute.Location = New System.Drawing.Point(470, 9)
        Me.BtnExecute.Name = "BtnExecute"
        Me.BtnExecute.Size = New System.Drawing.Size(56, 47)
        Me.BtnExecute.TabIndex = 11
        Me.BtnExecute.UseVisualStyleBackColor = True
        '
        'FrmWordInsData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 372)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmWordInsData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "差し込み文書作成(Word文書)"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TxtMasterWord As System.Windows.Forms.TextBox
    Friend WithEvents TxtOutputFolder As System.Windows.Forms.TextBox
    Friend WithEvents OptSelectWork0 As System.Windows.Forms.RadioButton
    Friend WithEvents OptSelectWork1 As System.Windows.Forms.RadioButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LblMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnSelWord As System.Windows.Forms.Button
    Friend WithEvents BtnSelFolder As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuFieldName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuFieldName_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuExecute As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Progress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents BtnExecute As GrapeCity.Win.Buttons.GcButton
End Class
