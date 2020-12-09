<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPaperList
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
        Dim NumberCellType1 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim GcTextBoxCellType1 As GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType = New GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType()
        Dim NumberCellType2 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType3 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAddRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDelRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuGetPrinterPaper = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SS = New FarPoint.Win.Spread.FpSpread()
        Me.SS_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SS_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuSave, Me.MenuAddRow, Me.MenuDelRow, Me.MenuGetPrinterPaper})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(589, 26)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuSave
        '
        Me.MenuSave.Name = "MenuSave"
        Me.MenuSave.Size = New System.Drawing.Size(86, 22)
        Me.MenuSave.Text = "設定保存(&S)"
        '
        'MenuAddRow
        '
        Me.MenuAddRow.Name = "MenuAddRow"
        Me.MenuAddRow.Size = New System.Drawing.Size(71, 22)
        Me.MenuAddRow.Text = "行追加(&I)"
        '
        'MenuDelRow
        '
        Me.MenuDelRow.Name = "MenuDelRow"
        Me.MenuDelRow.Size = New System.Drawing.Size(74, 22)
        Me.MenuDelRow.Text = "行削除(&R)"
        '
        'MenuGetPrinterPaper
        '
        Me.MenuGetPrinterPaper.Name = "MenuGetPrinterPaper"
        Me.MenuGetPrinterPaper.Size = New System.Drawing.Size(145, 22)
        Me.MenuGetPrinterPaper.Text = "プリンター用紙取得(&P)"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 519)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(589, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'SS
        '
        Me.SS.AccessibleDescription = "SS, Sheet1, Row 0, Column 0, "
        Me.SS.AllowRowMove = True
        Me.SS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SS.Location = New System.Drawing.Point(0, 26)
        Me.SS.Name = "SS"
        Me.SS.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.SS_Sheet1})
        Me.SS.Size = New System.Drawing.Size(589, 493)
        Me.SS.TabIndex = 2
        '
        'SS_Sheet1
        '
        Me.SS_Sheet1.Reset()
        Me.SS_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.SS_Sheet1.ColumnCount = 4
        Me.SS_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "RawKind"
        Me.SS_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "用紙名"
        Me.SS_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "紙幅(mm)"
        Me.SS_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "紙高(mm)"
        NumberCellType1.DecimalPlaces = 0
        NumberCellType1.MaximumValue = 9999.0R
        NumberCellType1.MinimumValue = 0.0R
        Me.SS_Sheet1.Columns.Get(0).CellType = NumberCellType1
        Me.SS_Sheet1.Columns.Get(0).Label = "RawKind"
        GcTextBoxCellType1.BackgroundImage = New FarPoint.Win.Picture(Nothing, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Left, FarPoint.Win.VerticalAlignment.Top)
        GcTextBoxCellType1.ClearCollection = True
        GcTextBoxCellType1.RecommendedValue = Nothing
        GcTextBoxCellType1.ShortcutKeys.AddRange(New GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry() {New GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")})
        Me.SS_Sheet1.Columns.Get(1).CellType = GcTextBoxCellType1
        Me.SS_Sheet1.Columns.Get(1).Label = "用紙名"
        Me.SS_Sheet1.Columns.Get(1).Width = 109.0!
        NumberCellType2.DecimalPlaces = 0
        NumberCellType2.MaximumValue = 10000000.0R
        NumberCellType2.MinimumValue = 0.0R
        Me.SS_Sheet1.Columns.Get(2).CellType = NumberCellType2
        Me.SS_Sheet1.Columns.Get(2).Label = "紙幅(mm)"
        Me.SS_Sheet1.Columns.Get(2).Width = 119.0!
        NumberCellType3.DecimalPlaces = 0
        NumberCellType3.MaximumValue = 10000000.0R
        NumberCellType3.MinimumValue = 0.0R
        Me.SS_Sheet1.Columns.Get(3).CellType = NumberCellType3
        Me.SS_Sheet1.Columns.Get(3).Label = "紙高(mm)"
        Me.SS_Sheet1.Columns.Get(3).Width = 119.0!
        Me.SS_Sheet1.GrayAreaBackColor = System.Drawing.Color.Gray
        Me.SS_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'FrmPaperList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 541)
        Me.Controls.Add(Me.SS)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmPaperList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JIS用紙設定"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.SS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SS_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents SS As FarPoint.Win.Spread.FpSpread
    Friend WithEvents SS_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents MenuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAddRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuDelRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuGetPrinterPaper As System.Windows.Forms.ToolStripMenuItem
End Class
