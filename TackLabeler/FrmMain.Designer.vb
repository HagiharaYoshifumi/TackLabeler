<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    'Inherits System.Windows.Forms.Form
    Inherits C1.Win.C1Ribbon.C1RibbonForm


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
        Dim SS_InputMapWhenFocusedNormal As FarPoint.Win.Spread.InputMap
        Dim CheckBoxCellType5 As FarPoint.Win.Spread.CellType.CheckBoxCellType = New FarPoint.Win.Spread.CellType.CheckBoxCellType()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LblRetCount = New System.Windows.Forms.Label()
        Me.BtnItemSeek_Next = New System.Windows.Forms.Button()
        Me.BtnItemSeek_Fowerd = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OptSeekAria0 = New System.Windows.Forms.RadioButton()
        Me.OptSeekAria1 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtSeekText = New System.Windows.Forms.TextBox()
        Me.BtnItemSeek = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TxtFromMoji = New System.Windows.Forms.TextBox()
        Me.TxtToMoji = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChkSepCapital = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.OptToNallow = New System.Windows.Forms.RadioButton()
        Me.OptToWide = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.OptWorkAria5 = New System.Windows.Forms.RadioButton()
        Me.OptWorkAria4 = New System.Windows.Forms.RadioButton()
        Me.OptWorkAria3 = New System.Windows.Forms.RadioButton()
        Me.OptWorkAria2 = New System.Windows.Forms.RadioButton()
        Me.OptWorkAria1 = New System.Windows.Forms.RadioButton()
        Me.OptWorkAria0 = New System.Windows.Forms.RadioButton()
        Me.BtnExecuteReplace = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnSeekPanelClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.C1Sizer2 = New C1.Win.C1Sizer.C1Sizer()
        Me.SS = New FarPoint.Win.Spread.FpSpread()
        Me.SS_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.C1Sizer3 = New C1.Win.C1Sizer.C1Sizer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbBackText = New System.Windows.Forms.ComboBox()
        Me.TxtNote = New GrapeCity.Win.Editors.GcTextBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GcTabControl1 = New GrapeCity.Win.Containers.GcTabControl()
        Me.ConMenuTab = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMT_Add = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMT_Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMT_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMT_Move = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMT_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.GcTabPage1 = New GrapeCity.Win.Containers.GcTabPage()
        Me.GcTabPage2 = New GrapeCity.Win.Containers.GcTabPage()
        Me.Viewer1 = New GrapeCity.ActiveReports.Viewer.Win.Viewer()
        Me.ConMenuSS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMSS_CopyRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSS_CopyLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMSS_AddRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSS_InsRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMSS_RowCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSS_RowCopyLast = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMSS_DelRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSS_DelRowCheck = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.LblColWidth = New System.Windows.Forms.ToolStripMenuItem()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.GcFieldStyler1 = New GrapeCity.Win.Editors.GcFieldStyler(Me.components)
        Me.C1Ribbon1 = New C1.Win.C1Ribbon.C1Ribbon()
        Me.RibbonApplicationMenu1 = New C1.Win.C1Ribbon.RibbonApplicationMenu()
        Me.RibbonConfigToolBar1 = New C1.Win.C1Ribbon.RibbonConfigToolBar()
        Me.RibbonQat1 = New C1.Win.C1Ribbon.RibbonQat()
        Me.RibbonTab1 = New C1.Win.C1Ribbon.RibbonTab()
        Me.RibbonGroup1 = New C1.Win.C1Ribbon.RibbonGroup()
        Me.BtnAPPEnd = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnSave = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonGroup2 = New C1.Win.C1Ribbon.RibbonGroup()
        Me.BtnTabAdd = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnTabEdit = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonSeparator1 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.BtnTabMove = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnTabCopy = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnTabDel = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonGroup3 = New C1.Win.C1Ribbon.RibbonGroup()
        Me.BtnCheckSet = New C1.Win.C1Ribbon.RibbonSplitButton()
        Me.BtnCheckSet_All = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnCheckSet_DedRow = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnCheckSet_VirifaiCheck = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnCheckDiset = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonSeparator2 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.BtnAddRow = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnInsRow = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnRowCopy = New C1.Win.C1Ribbon.RibbonSplitButton()
        Me.BtnRowCopyLast = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnDelRow = New C1.Win.C1Ribbon.RibbonSplitButton()
        Me.BtnDelRowCheck = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonSeparator15 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.BtnMoveData = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnDataSeek = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnCopyValue_Right = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnCopyValue_Left = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonGroup4 = New C1.Win.C1Ribbon.RibbonGroup()
        Me.TxtMaergin_Top = New C1.Win.C1Ribbon.RibbonNumericBox()
        Me.TxtMaergin_Left = New C1.Win.C1Ribbon.RibbonNumericBox()
        Me.BtnSamplePreview = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonSeparator5 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.BtnSelTack = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonGroup5 = New C1.Win.C1Ribbon.RibbonGroup()
        Me.TxtBusu = New C1.Win.C1Ribbon.RibbonNumericBox()
        Me.BtnFullPrint = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonSeparator7 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.ChkPreviewFrame = New C1.Win.C1Ribbon.RibbonCheckBox()
        Me.ChkPreviewFrame2 = New C1.Win.C1Ribbon.RibbonCheckBox()
        Me.RibbonSeparator6 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.BtnPreview = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnMovePage_Front = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnMovePage_Next = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonSeparator14 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.BtnPreviewWide = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnPreviewAll = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnReportScan = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnNoPreview = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonSeparator8 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.BtnPrintOut = New C1.Win.C1Ribbon.RibbonSplitButton()
        Me.BtnOutPDF = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonTab3 = New C1.Win.C1Ribbon.RibbonTab()
        Me.RibbonGroup8 = New C1.Win.C1Ribbon.RibbonGroup()
        Me.BtnClipboad_Load = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnCSV_Load = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonGroup81 = New C1.Win.C1Ribbon.RibbonGroup()
        Me.BtnWordInsData = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonSeparator3 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.BtnCSV_Save = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnCSV_SavePart = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnExcel_Save = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonTab2 = New C1.Win.C1Ribbon.RibbonTab()
        Me.RibbonGroup7 = New C1.Win.C1Ribbon.RibbonGroup()
        Me.BtnSetting = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnTackEdit = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnPaperListEdit = New C1.Win.C1Ribbon.RibbonButton()
        Me.BtnDataFile = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonSeparator17 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.BtnDataDelete = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonGroup6 = New C1.Win.C1Ribbon.RibbonGroup()
        Me.BtnHelp = New C1.Win.C1Ribbon.RibbonButton()
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
        Me.LblMessage = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonLabel11 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.LblRowCount = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonLabel7 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.LblSelCount = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator4 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.RibbonLabel6 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.StatLabel_Seet = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonSeparator9 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.RibbonLabel3 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.StatLabel_Maker = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator10 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.RibbonLabel5 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.StatLabel_Model = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator11 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.RibbonLabel1 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.StatLabel_Size = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator12 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.RibbonLabel4 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.StatLabel_Tack = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator13 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.RibbonLabel2 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.StatLabel_Printer = New C1.Win.C1Ribbon.RibbonLabel()
        Me.PdfExport1 = New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport()
        SS_InputMapWhenFocusedNormal = New FarPoint.Win.Spread.InputMap()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.C1Sizer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer2.SuspendLayout()
        CType(Me.SS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SS_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Sizer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer3.SuspendLayout()
        CType(Me.TxtNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GcTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GcTabControl1.SuspendLayout()
        Me.ConMenuTab.SuspendLayout()
        Me.ConMenuSS.SuspendLayout()
        CType(Me.C1Ribbon1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.Panel2)
        Me.C1Sizer1.Controls.Add(Me.Panel1)
        Me.C1Sizer1.Controls.Add(Me.Viewer1)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = "98.501872659176:False:False;" & Global.Microsoft.VisualBasic.ChrW(9) & "0:False:True;54.1935483870968:True:False;44.51612903" & _
    "22581:False:True;"
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 153)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(1240, 534)
        Me.C1Sizer1.TabIndex = 2
        Me.C1Sizer1.Text = "C1Sizer1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Location = New System.Drawing.Point(4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(0, 526)
        Me.Panel2.TabIndex = 3
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(0, 476)
        Me.TabControl1.TabIndex = 14
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.LblRetCount)
        Me.TabPage1.Controls.Add(Me.BtnItemSeek_Next)
        Me.TabPage1.Controls.Add(Me.BtnItemSeek_Fowerd)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.TxtSeekText)
        Me.TabPage1.Controls.Add(Me.BtnItemSeek)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(0, 450)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "検索"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'LblRetCount
        '
        Me.LblRetCount.Location = New System.Drawing.Point(19, 279)
        Me.LblRetCount.Name = "LblRetCount"
        Me.LblRetCount.Size = New System.Drawing.Size(168, 36)
        Me.LblRetCount.TabIndex = 13
        Me.LblRetCount.Text = "."
        Me.LblRetCount.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnItemSeek_Next
        '
        Me.BtnItemSeek_Next.Enabled = False
        Me.BtnItemSeek_Next.Location = New System.Drawing.Point(19, 180)
        Me.BtnItemSeek_Next.Name = "BtnItemSeek_Next"
        Me.BtnItemSeek_Next.Size = New System.Drawing.Size(166, 36)
        Me.BtnItemSeek_Next.TabIndex = 11
        Me.BtnItemSeek_Next.Text = "次検索結果"
        Me.BtnItemSeek_Next.UseVisualStyleBackColor = True
        '
        'BtnItemSeek_Fowerd
        '
        Me.BtnItemSeek_Fowerd.Enabled = False
        Me.BtnItemSeek_Fowerd.Location = New System.Drawing.Point(19, 222)
        Me.BtnItemSeek_Fowerd.Name = "BtnItemSeek_Fowerd"
        Me.BtnItemSeek_Fowerd.Size = New System.Drawing.Size(166, 36)
        Me.BtnItemSeek_Fowerd.TabIndex = 12
        Me.BtnItemSeek_Fowerd.Text = "前検索結果"
        Me.BtnItemSeek_Fowerd.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptSeekAria0)
        Me.GroupBox1.Controls.Add(Me.OptSeekAria1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(192, 67)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "検索範囲"
        '
        'OptSeekAria0
        '
        Me.OptSeekAria0.AutoSize = True
        Me.OptSeekAria0.Checked = True
        Me.OptSeekAria0.Location = New System.Drawing.Point(11, 18)
        Me.OptSeekAria0.Name = "OptSeekAria0"
        Me.OptSeekAria0.Size = New System.Drawing.Size(119, 16)
        Me.OptSeekAria0.TabIndex = 5
        Me.OptSeekAria0.TabStop = True
        Me.OptSeekAria0.Text = "このタブ内で検索(&T)"
        Me.OptSeekAria0.UseVisualStyleBackColor = True
        '
        'OptSeekAria1
        '
        Me.OptSeekAria1.AutoSize = True
        Me.OptSeekAria1.Location = New System.Drawing.Point(11, 40)
        Me.OptSeekAria1.Name = "OptSeekAria1"
        Me.OptSeekAria1.Size = New System.Drawing.Size(133, 16)
        Me.OptSeekAria1.TabIndex = 6
        Me.OptSeekAria1.Text = "全てのタブ内で検索(&A)"
        Me.OptSeekAria1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "検索文字"
        '
        'TxtSeekText
        '
        Me.TxtSeekText.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TxtSeekText.Location = New System.Drawing.Point(7, 27)
        Me.TxtSeekText.Name = "TxtSeekText"
        Me.TxtSeekText.Size = New System.Drawing.Size(193, 19)
        Me.TxtSeekText.TabIndex = 7
        '
        'BtnItemSeek
        '
        Me.BtnItemSeek.Location = New System.Drawing.Point(19, 125)
        Me.BtnItemSeek.Name = "BtnItemSeek"
        Me.BtnItemSeek.Size = New System.Drawing.Size(166, 36)
        Me.BtnItemSeek.TabIndex = 8
        Me.BtnItemSeek.Text = "アイテム検索"
        Me.BtnItemSeek.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TabControl2)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.BtnExecuteReplace)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(0, 450)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "文字置換"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl2.Location = New System.Drawing.Point(3, 3)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(0, 137)
        Me.TabControl2.TabIndex = 11
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TxtFromMoji)
        Me.TabPage3.Controls.Add(Me.TxtToMoji)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.ChkSepCapital)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(0, 111)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "文字置換"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TxtFromMoji
        '
        Me.TxtFromMoji.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TxtFromMoji.Location = New System.Drawing.Point(8, 24)
        Me.TxtFromMoji.Name = "TxtFromMoji"
        Me.TxtFromMoji.Size = New System.Drawing.Size(181, 19)
        Me.TxtFromMoji.TabIndex = 1
        '
        'TxtToMoji
        '
        Me.TxtToMoji.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TxtToMoji.Location = New System.Drawing.Point(8, 61)
        Me.TxtToMoji.Name = "TxtToMoji"
        Me.TxtToMoji.Size = New System.Drawing.Size(181, 19)
        Me.TxtToMoji.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "置換後の文字列(&E)"
        '
        'ChkSepCapital
        '
        Me.ChkSepCapital.AutoSize = True
        Me.ChkSepCapital.Location = New System.Drawing.Point(8, 86)
        Me.ChkSepCapital.Name = "ChkSepCapital"
        Me.ChkSepCapital.Size = New System.Drawing.Size(171, 16)
        Me.ChkSepCapital.TabIndex = 4
        Me.ChkSepCapital.Text = "大文字と小文字を区別する(&K)"
        Me.ChkSepCapital.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "置換する文字列(&N)"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.OptToNallow)
        Me.TabPage4.Controls.Add(Me.OptToWide)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(0, 111)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "全半角置換"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'OptToNallow
        '
        Me.OptToNallow.AutoSize = True
        Me.OptToNallow.Location = New System.Drawing.Point(7, 33)
        Me.OptToNallow.Name = "OptToNallow"
        Me.OptToNallow.Size = New System.Drawing.Size(129, 16)
        Me.OptToNallow.TabIndex = 1
        Me.OptToNallow.Text = "全角を半角に変換(&N)"
        Me.OptToNallow.UseVisualStyleBackColor = True
        '
        'OptToWide
        '
        Me.OptToWide.AutoSize = True
        Me.OptToWide.Checked = True
        Me.OptToWide.Location = New System.Drawing.Point(7, 11)
        Me.OptToWide.Name = "OptToWide"
        Me.OptToWide.Size = New System.Drawing.Size(130, 16)
        Me.OptToWide.TabIndex = 0
        Me.OptToWide.TabStop = True
        Me.OptToWide.Text = "半角を全角に変換(&W)"
        Me.OptToWide.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.OptWorkAria5)
        Me.GroupBox3.Controls.Add(Me.OptWorkAria4)
        Me.GroupBox3.Controls.Add(Me.OptWorkAria3)
        Me.GroupBox3.Controls.Add(Me.OptWorkAria2)
        Me.GroupBox3.Controls.Add(Me.OptWorkAria1)
        Me.GroupBox3.Controls.Add(Me.OptWorkAria0)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 146)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(196, 96)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "適用範囲"
        '
        'OptWorkAria5
        '
        Me.OptWorkAria5.AutoSize = True
        Me.OptWorkAria5.Location = New System.Drawing.Point(102, 62)
        Me.OptWorkAria5.Name = "OptWorkAria5"
        Me.OptWorkAria5.Size = New System.Drawing.Size(71, 16)
        Me.OptWorkAria5.TabIndex = 6
        Me.OptWorkAria5.Text = "選択範囲"
        Me.OptWorkAria5.UseVisualStyleBackColor = True
        '
        'OptWorkAria4
        '
        Me.OptWorkAria4.AutoSize = True
        Me.OptWorkAria4.Location = New System.Drawing.Point(102, 40)
        Me.OptWorkAria4.Name = "OptWorkAria4"
        Me.OptWorkAria4.Size = New System.Drawing.Size(90, 16)
        Me.OptWorkAria4.TabIndex = 5
        Me.OptWorkAria4.Text = "チェック選択行"
        Me.OptWorkAria4.UseVisualStyleBackColor = True
        '
        'OptWorkAria3
        '
        Me.OptWorkAria3.AutoSize = True
        Me.OptWorkAria3.Location = New System.Drawing.Point(102, 18)
        Me.OptWorkAria3.Name = "OptWorkAria3"
        Me.OptWorkAria3.Size = New System.Drawing.Size(75, 16)
        Me.OptWorkAria3.TabIndex = 4
        Me.OptWorkAria3.Text = "シート全体"
        Me.OptWorkAria3.UseVisualStyleBackColor = True
        '
        'OptWorkAria2
        '
        Me.OptWorkAria2.AutoSize = True
        Me.OptWorkAria2.Location = New System.Drawing.Point(10, 62)
        Me.OptWorkAria2.Name = "OptWorkAria2"
        Me.OptWorkAria2.Size = New System.Drawing.Size(80, 16)
        Me.OptWorkAria2.TabIndex = 3
        Me.OptWorkAria2.Text = "選択列のみ"
        Me.OptWorkAria2.UseVisualStyleBackColor = True
        '
        'OptWorkAria1
        '
        Me.OptWorkAria1.AutoSize = True
        Me.OptWorkAria1.Location = New System.Drawing.Point(10, 40)
        Me.OptWorkAria1.Name = "OptWorkAria1"
        Me.OptWorkAria1.Size = New System.Drawing.Size(80, 16)
        Me.OptWorkAria1.TabIndex = 2
        Me.OptWorkAria1.Text = "選択行のみ"
        Me.OptWorkAria1.UseVisualStyleBackColor = True
        '
        'OptWorkAria0
        '
        Me.OptWorkAria0.AutoSize = True
        Me.OptWorkAria0.Checked = True
        Me.OptWorkAria0.Location = New System.Drawing.Point(10, 18)
        Me.OptWorkAria0.Name = "OptWorkAria0"
        Me.OptWorkAria0.Size = New System.Drawing.Size(88, 16)
        Me.OptWorkAria0.TabIndex = 1
        Me.OptWorkAria0.TabStop = True
        Me.OptWorkAria0.Text = "選択セルのみ"
        Me.OptWorkAria0.UseVisualStyleBackColor = True
        '
        'BtnExecuteReplace
        '
        Me.BtnExecuteReplace.Location = New System.Drawing.Point(20, 248)
        Me.BtnExecuteReplace.Name = "BtnExecuteReplace"
        Me.BtnExecuteReplace.Size = New System.Drawing.Size(166, 36)
        Me.BtnExecuteReplace.TabIndex = 8
        Me.BtnExecuteReplace.Text = "置換開始"
        Me.BtnExecuteReplace.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.BtnSeekPanelClose)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 476)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(0, 50)
        Me.Panel3.TabIndex = 15
        '
        'BtnSeekPanelClose
        '
        Me.BtnSeekPanelClose.Location = New System.Drawing.Point(23, 6)
        Me.BtnSeekPanelClose.Name = "BtnSeekPanelClose"
        Me.BtnSeekPanelClose.Size = New System.Drawing.Size(166, 36)
        Me.BtnSeekPanelClose.TabIndex = 13
        Me.BtnSeekPanelClose.Text = "閉じる"
        Me.BtnSeekPanelClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.C1Sizer2)
        Me.Panel1.Controls.Add(Me.GcTabControl1)
        Me.Panel1.Location = New System.Drawing.Point(8, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(672, 526)
        Me.Panel1.TabIndex = 1
        '
        'C1Sizer2
        '
        Me.C1Sizer2.Controls.Add(Me.SS)
        Me.C1Sizer2.Controls.Add(Me.C1Sizer3)
        Me.C1Sizer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer2.GridDefinition = "91.9191919191919:True:False;5.65656565656566:False:True;" & Global.Microsoft.VisualBasic.ChrW(9) & "98.8095238095238:False:F" & _
    "alse;"
        Me.C1Sizer2.Location = New System.Drawing.Point(0, 31)
        Me.C1Sizer2.Name = "C1Sizer2"
        Me.C1Sizer2.Size = New System.Drawing.Size(672, 495)
        Me.C1Sizer2.TabIndex = 3
        Me.C1Sizer2.Text = "C1Sizer2"
        '
        'SS
        '
        Me.SS.AccessibleDescription = "SS, Sheet1, Row 0, Column 0, "
        Me.SS.AllowRowMove = True
        Me.SS.FocusRenderer = New FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer(1)
        Me.SS.Location = New System.Drawing.Point(4, 4)
        Me.SS.Name = "SS"
        Me.SS.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.SS_Sheet1})
        Me.SS.Size = New System.Drawing.Size(664, 455)
        Me.SS.TabIndex = 1
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.StartEditing)
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.[Return], System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.StartEditing)
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(Global.Microsoft.VisualBasic.ChrW(61)), FarPoint.Win.Spread.SpreadActions.StartEditingFormula)
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.C, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)), FarPoint.Win.Spread.SpreadActions.ClipboardCopy)
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.V, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)), FarPoint.Win.Spread.SpreadActions.ClipboardPasteAll)
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.X, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)), FarPoint.Win.Spread.SpreadActions.ClipboardCut)
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Insert, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)), FarPoint.Win.Spread.SpreadActions.ClipboardCopy)
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Delete, CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)), FarPoint.Win.Spread.SpreadActions.ClipboardCut)
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Insert, CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)), FarPoint.Win.Spread.SpreadActions.ClipboardPasteAll)
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Space, CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)), FarPoint.Win.Spread.SpreadActions.SelectRow)
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Z, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)), FarPoint.Win.Spread.SpreadActions.Undo)
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Y, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)), FarPoint.Win.Spread.SpreadActions.Redo)
        SS_InputMapWhenFocusedNormal.Put(New FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ShowSubEditor)
        Me.SS.SetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, FarPoint.Win.Spread.OperationMode.Normal, SS_InputMapWhenFocusedNormal)
        '
        'SS_Sheet1
        '
        Me.SS_Sheet1.Reset()
        Me.SS_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.SS_Sheet1.ColumnCount = 21
        Me.SS_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.Azure
        Me.SS_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "出力"
        Me.SS_Sheet1.Columns.Get(0).CellType = CheckBoxCellType5
        Me.SS_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.SS_Sheet1.Columns.Get(0).Label = "出力"
        Me.SS_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.SS_Sheet1.Columns.Get(0).Width = 42.0!
        Me.SS_Sheet1.Columns.Get(1).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(1).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(2).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(2).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(3).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(3).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(4).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(4).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(5).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(5).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(6).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(6).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(7).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(7).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(8).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(8).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(9).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(9).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(10).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(10).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(11).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(11).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(12).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(12).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(13).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(13).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(14).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(14).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(15).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(15).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(16).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(16).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(17).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(17).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(18).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(18).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(19).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(19).AllowAutoSort = True
        Me.SS_Sheet1.Columns.Get(20).AllowAutoFilter = True
        Me.SS_Sheet1.Columns.Get(20).AllowAutoSort = True
        Me.SS_Sheet1.GrayAreaBackColor = System.Drawing.Color.Gray
        Me.SS_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.SS_Sheet1.Rows.Get(0).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(1).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(2).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(3).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(4).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(5).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(6).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(7).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(8).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(9).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(10).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(11).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(12).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(13).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(14).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(15).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(16).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(17).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(18).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(19).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(20).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(21).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(22).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(23).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(24).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(25).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(26).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(27).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(28).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(29).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(30).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(31).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(32).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(33).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(34).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(35).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(36).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(37).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(38).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(39).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(40).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(41).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(42).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(43).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(44).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(45).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(46).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(47).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(48).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(49).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(50).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(51).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(52).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(53).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(54).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(55).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(56).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(57).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(58).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(59).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(60).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(61).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(62).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(63).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(64).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(65).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(66).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(67).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(68).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(69).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(70).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(71).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(72).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(73).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(74).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(75).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(76).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(77).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(78).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(79).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(80).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(81).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(82).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(83).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(84).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(85).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(86).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(87).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(88).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(89).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(90).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(91).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(92).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(93).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(94).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(95).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(96).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(97).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(98).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(99).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(100).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(101).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(102).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(103).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(104).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(105).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(106).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(107).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(108).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(109).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(110).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(111).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(112).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(113).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(114).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(115).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(116).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(117).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(118).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(119).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(120).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(121).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(122).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(123).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(124).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(125).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(126).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(127).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(128).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(129).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(130).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(131).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(132).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(133).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(134).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(135).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(136).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(137).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(138).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(139).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(140).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(141).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(142).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(143).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(144).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(145).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(146).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(147).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(148).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(149).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(150).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(151).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(152).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(153).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(154).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(155).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(156).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(157).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(158).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(159).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(160).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(161).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(162).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(163).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(164).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(165).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(166).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(167).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(168).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(169).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(170).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(171).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(172).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(173).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(174).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(175).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(176).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(177).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(178).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(179).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(180).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(181).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(182).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(183).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(184).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(185).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(186).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(187).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(188).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(189).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(190).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(191).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(192).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(193).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(194).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(195).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(196).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(197).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(198).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(199).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(200).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(201).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(202).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(203).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(204).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(205).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(206).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(207).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(208).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(209).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(210).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(211).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(212).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(213).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(214).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(215).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(216).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(217).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(218).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(219).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(220).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(221).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(222).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(223).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(224).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(225).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(226).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(227).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(228).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(229).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(230).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(231).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(232).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(233).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(234).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(235).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(236).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(237).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(238).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(239).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(240).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(241).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(242).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(243).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(244).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(245).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(246).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(247).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(248).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(249).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(250).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(251).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(252).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(253).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(254).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(255).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(256).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(257).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(258).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(259).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(260).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(261).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(262).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(263).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(264).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(265).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(266).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(267).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(268).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(269).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(270).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(271).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(272).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(273).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(274).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(275).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(276).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(277).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(278).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(279).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(280).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(281).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(282).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(283).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(284).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(285).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(286).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(287).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(288).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(289).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(290).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(291).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(292).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(293).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(294).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(295).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(296).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(297).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(298).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(299).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(300).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(301).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(302).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(303).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(304).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(305).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(306).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(307).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(308).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(309).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(310).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(311).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(312).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(313).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(314).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(315).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(316).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(317).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(318).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(319).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(320).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(321).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(322).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(323).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(324).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(325).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(326).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(327).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(328).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(329).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(330).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(331).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(332).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(333).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(334).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(335).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(336).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(337).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(338).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(339).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(340).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(341).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(342).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(343).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(344).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(345).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(346).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(347).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(348).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(349).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(350).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(351).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(352).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(353).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(354).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(355).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(356).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(357).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(358).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(359).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(360).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(361).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(362).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(363).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(364).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(365).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(366).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(367).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(368).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(369).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(370).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(371).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(372).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(373).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(374).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(375).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(376).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(377).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(378).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(379).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(380).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(381).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(382).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(383).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(384).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(385).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(386).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(387).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(388).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(389).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(390).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(391).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(392).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(393).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(394).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(395).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(396).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(397).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(398).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(399).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(400).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(401).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(402).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(403).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(404).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(405).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(406).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(407).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(408).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(409).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(410).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(411).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(412).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(413).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(414).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(415).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(416).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(417).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(418).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(419).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(420).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(421).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(422).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(423).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(424).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(425).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(426).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(427).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(428).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(429).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(430).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(431).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(432).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(433).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(434).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(435).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(436).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(437).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(438).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(439).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(440).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(441).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(442).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(443).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(444).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(445).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(446).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(447).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(448).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(449).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(450).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(451).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(452).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(453).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(454).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(455).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(456).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(457).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(458).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(459).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(460).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(461).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(462).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(463).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(464).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(465).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(466).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(467).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(468).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(469).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(470).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(471).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(472).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(473).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(474).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(475).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(476).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(477).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(478).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(479).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(480).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(481).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(482).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(483).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(484).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(485).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(486).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(487).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(488).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(489).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(490).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(491).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(492).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(493).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(494).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(495).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(496).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(497).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(498).Height = 36.0!
        Me.SS_Sheet1.Rows.Get(499).Height = 36.0!
        Me.SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'C1Sizer3
        '
        Me.C1Sizer3.Controls.Add(Me.Label1)
        Me.C1Sizer3.Controls.Add(Me.CmbBackText)
        Me.C1Sizer3.Controls.Add(Me.TxtNote)
        Me.C1Sizer3.Controls.Add(Me.Label2)
        Me.C1Sizer3.GridDefinition = "71.4285714285714:False:False;" & Global.Microsoft.VisualBasic.ChrW(9) & "8.43373493975904:False:True;16.566265060241:False:T" & _
    "rue;12.9518072289157:False:True;59.9397590361446:False:False;"
        Me.C1Sizer3.Location = New System.Drawing.Point(4, 463)
        Me.C1Sizer3.Name = "C1Sizer3"
        Me.C1Sizer3.Size = New System.Drawing.Size(664, 28)
        Me.C1Sizer3.SplitterWidth = 2
        Me.C1Sizer3.TabIndex = 3
        Me.C1Sizer3.Text = "C1Sizer3"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(56, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "敬称名称"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CmbBackText
        '
        Me.CmbBackText.FormattingEnabled = True
        Me.CmbBackText.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.CmbBackText.Items.AddRange(New Object() {"様", "御中"})
        Me.CmbBackText.Location = New System.Drawing.Point(62, 4)
        Me.CmbBackText.Name = "CmbBackText"
        Me.CmbBackText.Size = New System.Drawing.Size(110, 20)
        Me.CmbBackText.TabIndex = 0
        '
        'TxtNote
        '
        Me.TxtNote.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.TxtNote.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TxtNote.Location = New System.Drawing.Point(262, 4)
        Me.TxtNote.Name = "TxtNote"
        Me.TxtNote.RecommendedValue = "ssss"
        Me.TxtNote.ScrollBarMode = GrapeCity.Win.Editors.ScrollBarMode.Automatic
        Me.TxtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GcShortcut1.SetShortcuts(Me.TxtNote, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.TxtNote, Object)}, New String() {"ShortcutClear"}))
        Me.TxtNote.ShowRecommendedValue = True
        Me.TxtNote.Size = New System.Drawing.Size(398, 20)
        Me.TxtNote.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(174, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "固定ラベル(単)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GcTabControl1
        '
        Me.GcTabControl1.AllowDragDrop = True
        Me.GcTabControl1.Appearance = GrapeCity.Win.Containers.TabAppearance.Office2007Blue
        Me.GcTabControl1.ContextMenuStrip = Me.ConMenuTab
        Me.GcTabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GcTabControl1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GcTabControl1.HotTrack = True
        Me.GcTabControl1.HotTrackEffect = GrapeCity.Win.Containers.HotTrackEffect.Highlight
        Me.GcTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.GcTabControl1.Name = "GcTabControl1"
        Me.GcTabControl1.Size = New System.Drawing.Size(672, 31)
        Me.GcTabControl1.TabIndex = 4
        Me.GcTabControl1.TabPages.Add(Me.GcTabPage1)
        Me.GcTabControl1.TabPages.Add(Me.GcTabPage2)
        '
        'ConMenuTab
        '
        Me.ConMenuTab.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMT_Add, Me.CMT_Edit, Me.ToolStripSeparator5, Me.CMT_Copy, Me.CMT_Move, Me.ToolStripSeparator4, Me.CMT_Delete})
        Me.ConMenuTab.Name = "ConMenuTab"
        Me.ConMenuTab.Size = New System.Drawing.Size(137, 126)
        '
        'CMT_Add
        '
        Me.CMT_Add.Image = CType(resources.GetObject("CMT_Add.Image"), System.Drawing.Image)
        Me.CMT_Add.Name = "CMT_Add"
        Me.CMT_Add.Size = New System.Drawing.Size(136, 22)
        Me.CMT_Add.Text = "タブ追加"
        '
        'CMT_Edit
        '
        Me.CMT_Edit.Image = CType(resources.GetObject("CMT_Edit.Image"), System.Drawing.Image)
        Me.CMT_Edit.Name = "CMT_Edit"
        Me.CMT_Edit.Size = New System.Drawing.Size(136, 22)
        Me.CMT_Edit.Text = "タブの編集"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(133, 6)
        '
        'CMT_Copy
        '
        Me.CMT_Copy.Image = CType(resources.GetObject("CMT_Copy.Image"), System.Drawing.Image)
        Me.CMT_Copy.Name = "CMT_Copy"
        Me.CMT_Copy.Size = New System.Drawing.Size(136, 22)
        Me.CMT_Copy.Text = "タブ複写"
        '
        'CMT_Move
        '
        Me.CMT_Move.Image = CType(resources.GetObject("CMT_Move.Image"), System.Drawing.Image)
        Me.CMT_Move.Name = "CMT_Move"
        Me.CMT_Move.Size = New System.Drawing.Size(136, 22)
        Me.CMT_Move.Text = "タブ移動"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(133, 6)
        '
        'CMT_Delete
        '
        Me.CMT_Delete.Image = CType(resources.GetObject("CMT_Delete.Image"), System.Drawing.Image)
        Me.CMT_Delete.Name = "CMT_Delete"
        Me.CMT_Delete.Size = New System.Drawing.Size(136, 22)
        Me.CMT_Delete.Text = "タブ削除"
        '
        'GcTabPage1
        '
        Me.GcTabPage1.Location = New System.Drawing.Point(4, 24)
        Me.GcTabPage1.Name = "GcTabPage1"
        Me.GcTabPage1.Size = New System.Drawing.Size(664, 3)
        Me.GcTabPage1.TabIndex = 0
        Me.GcTabPage1.Text = "GcTabPage1"
        Me.GcTabPage1.UseVisualStyleBackColor = True
        '
        'GcTabPage2
        '
        Me.GcTabPage2.Location = New System.Drawing.Point(4, 24)
        Me.GcTabPage2.Name = "GcTabPage2"
        Me.GcTabPage2.Size = New System.Drawing.Size(664, 3)
        Me.GcTabPage2.TabIndex = 1
        Me.GcTabPage2.Text = "GcTabPage2"
        Me.GcTabPage2.UseVisualStyleBackColor = True
        '
        'Viewer1
        '
        Me.Viewer1.CurrentPage = 0
        Me.Viewer1.Location = New System.Drawing.Point(684, 4)
        Me.Viewer1.Name = "Viewer1"
        Me.Viewer1.PreviewPages = 0
        '
        '
        '
        '
        '
        '
        Me.Viewer1.Sidebar.ParametersPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.ParametersPanel.Text = "パラメータ"
        Me.Viewer1.Sidebar.ParametersPanel.Width = 200
        '
        '
        '
        Me.Viewer1.Sidebar.SearchPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.SearchPanel.Text = "検索"
        Me.Viewer1.Sidebar.SearchPanel.Width = 200
        '
        '
        '
        Me.Viewer1.Sidebar.ThumbnailsPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.ThumbnailsPanel.Text = "サムネイル"
        Me.Viewer1.Sidebar.ThumbnailsPanel.Width = 200
        '
        '
        '
        Me.Viewer1.Sidebar.TocPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.TocPanel.Text = "見出しマップラベル"
        Me.Viewer1.Sidebar.TocPanel.Width = 200
        Me.Viewer1.Sidebar.Width = 200
        Me.Viewer1.Size = New System.Drawing.Size(552, 526)
        Me.Viewer1.TabIndex = 2
        '
        'ConMenuSS
        '
        Me.ConMenuSS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMSS_CopyRight, Me.CMSS_CopyLeft, Me.ToolStripSeparator6, Me.CMSS_AddRow, Me.CMSS_InsRow, Me.ToolStripSeparator1, Me.CMSS_RowCopy, Me.CMSS_RowCopyLast, Me.ToolStripSeparator2, Me.CMSS_DelRow, Me.CMSS_DelRowCheck, Me.ToolStripSeparator3, Me.LblColWidth})
        Me.ConMenuSS.Name = "ConMenuTab"
        Me.ConMenuSS.Size = New System.Drawing.Size(196, 226)
        '
        'CMSS_CopyRight
        '
        Me.CMSS_CopyRight.Image = CType(resources.GetObject("CMSS_CopyRight.Image"), System.Drawing.Image)
        Me.CMSS_CopyRight.Name = "CMSS_CopyRight"
        Me.CMSS_CopyRight.Size = New System.Drawing.Size(195, 22)
        Me.CMSS_CopyRight.Text = "右セルに値をコピー"
        '
        'CMSS_CopyLeft
        '
        Me.CMSS_CopyLeft.Image = CType(resources.GetObject("CMSS_CopyLeft.Image"), System.Drawing.Image)
        Me.CMSS_CopyLeft.Name = "CMSS_CopyLeft"
        Me.CMSS_CopyLeft.Size = New System.Drawing.Size(195, 22)
        Me.CMSS_CopyLeft.Text = "左セルに値をコピー"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(192, 6)
        '
        'CMSS_AddRow
        '
        Me.CMSS_AddRow.Image = CType(resources.GetObject("CMSS_AddRow.Image"), System.Drawing.Image)
        Me.CMSS_AddRow.Name = "CMSS_AddRow"
        Me.CMSS_AddRow.Size = New System.Drawing.Size(195, 22)
        Me.CMSS_AddRow.Text = "行追加(Ctrl+N)"
        '
        'CMSS_InsRow
        '
        Me.CMSS_InsRow.Image = CType(resources.GetObject("CMSS_InsRow.Image"), System.Drawing.Image)
        Me.CMSS_InsRow.Name = "CMSS_InsRow"
        Me.CMSS_InsRow.Size = New System.Drawing.Size(195, 22)
        Me.CMSS_InsRow.Text = "行挿入(Ctrl+I)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(192, 6)
        '
        'CMSS_RowCopy
        '
        Me.CMSS_RowCopy.Image = CType(resources.GetObject("CMSS_RowCopy.Image"), System.Drawing.Image)
        Me.CMSS_RowCopy.Name = "CMSS_RowCopy"
        Me.CMSS_RowCopy.Size = New System.Drawing.Size(195, 22)
        Me.CMSS_RowCopy.Text = "行複写"
        '
        'CMSS_RowCopyLast
        '
        Me.CMSS_RowCopyLast.Image = CType(resources.GetObject("CMSS_RowCopyLast.Image"), System.Drawing.Image)
        Me.CMSS_RowCopyLast.Name = "CMSS_RowCopyLast"
        Me.CMSS_RowCopyLast.Size = New System.Drawing.Size(195, 22)
        Me.CMSS_RowCopyLast.Text = "最下段に行複写"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(192, 6)
        '
        'CMSS_DelRow
        '
        Me.CMSS_DelRow.Image = CType(resources.GetObject("CMSS_DelRow.Image"), System.Drawing.Image)
        Me.CMSS_DelRow.Name = "CMSS_DelRow"
        Me.CMSS_DelRow.Size = New System.Drawing.Size(195, 22)
        Me.CMSS_DelRow.Text = "行削除"
        '
        'CMSS_DelRowCheck
        '
        Me.CMSS_DelRowCheck.Image = CType(resources.GetObject("CMSS_DelRowCheck.Image"), System.Drawing.Image)
        Me.CMSS_DelRowCheck.Name = "CMSS_DelRowCheck"
        Me.CMSS_DelRowCheck.Size = New System.Drawing.Size(195, 22)
        Me.CMSS_DelRowCheck.Text = "チェック行削除"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(192, 6)
        '
        'LblColWidth
        '
        Me.LblColWidth.Name = "LblColWidth"
        Me.LblColWidth.Size = New System.Drawing.Size(195, 22)
        Me.LblColWidth.Text = "ToolStripMenuItem1"
        '
        'C1Ribbon1
        '
        Me.C1Ribbon1.ApplicationMenuHolder = Me.RibbonApplicationMenu1
        Me.C1Ribbon1.ConfigToolBarHolder = Me.RibbonConfigToolBar1
        Me.C1Ribbon1.Location = New System.Drawing.Point(0, 0)
        Me.C1Ribbon1.Name = "C1Ribbon1"
        Me.C1Ribbon1.QatHolder = Me.RibbonQat1
        Me.C1Ribbon1.Size = New System.Drawing.Size(1240, 153)
        Me.C1Ribbon1.Tabs.Add(Me.RibbonTab1)
        Me.C1Ribbon1.Tabs.Add(Me.RibbonTab3)
        Me.C1Ribbon1.Tabs.Add(Me.RibbonTab2)
        Me.C1Ribbon1.ToolTipSettings.Border = True
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("printer.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("arrow-left-icon.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images1"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("arrow-right-icon.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images2"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("page_magnifier.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images3"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("numeric_stepper.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images4"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("column_four.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images5"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("document_margins.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images6"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("textfield.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images7"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("combo_box.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images8"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("find.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images9"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("table_go.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images10"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("table_row_delete.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images11"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("Checkbox-Full-icon.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images12"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("check_box.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images13"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("table_replace.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images14"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("table_insert.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images15"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("table_row_insert.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images16"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("Checkbox-Empty-icon.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images17"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("tab_add.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images18"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("tab_edit.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images19"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("tab_delete.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images20"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("tab_go.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images21"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("gear_in.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images22"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("folder_page.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images23"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("report_edit.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images24"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("book_edit.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images25"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("database_lightning.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images26"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("disk.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images27"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("document_export.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images28"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("document_import.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images29"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("door_in.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images30"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("key_go.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images31"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("database_save.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images32"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("text_width.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images33"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("text_resize.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images34"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("page_find.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images35"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("document_export_CSV.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images36"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("excel_exports.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images37"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("table_select_group.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images38"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("page_tack.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images39"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("document_copies_edit.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images40"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("document_import_CSV.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images41"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("table_select_group_import.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images42"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("database_repeat_entry.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images43"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("database_delete.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images44"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("text_replace.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images45"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("word_exports.png", CType(resources.GetObject("C1Ribbon1.ToolTipSettings.Images46"), System.Drawing.Image)))
        Me.C1Ribbon1.ToolTipSettings.IsBalloon = True
        Me.C1Ribbon1.ToolTipSettings.RoundedCorners = True
        Me.C1Ribbon1.ToolTipSettings.Shadow = True
        '
        'RibbonApplicationMenu1
        '
        Me.RibbonApplicationMenu1.LargeImage = CType(resources.GetObject("RibbonApplicationMenu1.LargeImage"), System.Drawing.Image)
        Me.RibbonApplicationMenu1.Name = "RibbonApplicationMenu1"
        Me.RibbonApplicationMenu1.SmallImage = CType(resources.GetObject("RibbonApplicationMenu1.SmallImage"), System.Drawing.Image)
        '
        'RibbonConfigToolBar1
        '
        Me.RibbonConfigToolBar1.Name = "RibbonConfigToolBar1"
        '
        'RibbonQat1
        '
        Me.RibbonQat1.Name = "RibbonQat1"
        '
        'RibbonTab1
        '
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup1)
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup2)
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup3)
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup4)
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup5)
        Me.RibbonTab1.Name = "RibbonTab1"
        Me.RibbonTab1.Text = "ホーム"
        '
        'RibbonGroup1
        '
        Me.RibbonGroup1.Items.Add(Me.BtnAPPEnd)
        Me.RibbonGroup1.Items.Add(Me.BtnSave)
        Me.RibbonGroup1.Name = "RibbonGroup1"
        Me.RibbonGroup1.Text = "ファイル"
        '
        'BtnAPPEnd
        '
        Me.BtnAPPEnd.LargeImage = CType(resources.GetObject("BtnAPPEnd.LargeImage"), System.Drawing.Image)
        Me.BtnAPPEnd.Name = "BtnAPPEnd"
        Me.BtnAPPEnd.SmallImage = CType(resources.GetObject("BtnAPPEnd.SmallImage"), System.Drawing.Image)
        Me.BtnAPPEnd.Text = "終了"
        Me.BtnAPPEnd.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnAPPEnd.ToolTip = resources.GetString("BtnAPPEnd.ToolTip")
        '
        'BtnSave
        '
        Me.BtnSave.LargeImage = CType(resources.GetObject("BtnSave.LargeImage"), System.Drawing.Image)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.BtnSave.SmallImage = CType(resources.GetObject("BtnSave.SmallImage"), System.Drawing.Image)
        Me.BtnSave.Text = "保存"
        Me.BtnSave.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnSave.ToolTip = resources.GetString("BtnSave.ToolTip")
        '
        'RibbonGroup2
        '
        Me.RibbonGroup2.Items.Add(Me.BtnTabAdd)
        Me.RibbonGroup2.Items.Add(Me.BtnTabEdit)
        Me.RibbonGroup2.Items.Add(Me.RibbonSeparator1)
        Me.RibbonGroup2.Items.Add(Me.BtnTabMove)
        Me.RibbonGroup2.Items.Add(Me.BtnTabCopy)
        Me.RibbonGroup2.Items.Add(Me.BtnTabDel)
        Me.RibbonGroup2.Name = "RibbonGroup2"
        Me.RibbonGroup2.Text = "タブ操作"
        '
        'BtnTabAdd
        '
        Me.BtnTabAdd.LargeImage = CType(resources.GetObject("BtnTabAdd.LargeImage"), System.Drawing.Image)
        Me.BtnTabAdd.Name = "BtnTabAdd"
        Me.BtnTabAdd.SmallImage = CType(resources.GetObject("BtnTabAdd.SmallImage"), System.Drawing.Image)
        Me.BtnTabAdd.Text = "タブ追加"
        Me.BtnTabAdd.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnTabAdd.ToolTip = resources.GetString("BtnTabAdd.ToolTip")
        '
        'BtnTabEdit
        '
        Me.BtnTabEdit.LargeImage = CType(resources.GetObject("BtnTabEdit.LargeImage"), System.Drawing.Image)
        Me.BtnTabEdit.Name = "BtnTabEdit"
        Me.BtnTabEdit.SmallImage = CType(resources.GetObject("BtnTabEdit.SmallImage"), System.Drawing.Image)
        Me.BtnTabEdit.Text = "タブ編集"
        Me.BtnTabEdit.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnTabEdit.ToolTip = resources.GetString("BtnTabEdit.ToolTip")
        '
        'RibbonSeparator1
        '
        Me.RibbonSeparator1.Name = "RibbonSeparator1"
        '
        'BtnTabMove
        '
        Me.BtnTabMove.Name = "BtnTabMove"
        Me.BtnTabMove.SmallImage = CType(resources.GetObject("BtnTabMove.SmallImage"), System.Drawing.Image)
        Me.BtnTabMove.Text = "タブ移動"
        Me.BtnTabMove.ToolTip = resources.GetString("BtnTabMove.ToolTip")
        '
        'BtnTabCopy
        '
        Me.BtnTabCopy.Name = "BtnTabCopy"
        Me.BtnTabCopy.SmallImage = CType(resources.GetObject("BtnTabCopy.SmallImage"), System.Drawing.Image)
        Me.BtnTabCopy.Text = "タブ複写"
        Me.BtnTabCopy.ToolTip = resources.GetString("BtnTabCopy.ToolTip")
        '
        'BtnTabDel
        '
        Me.BtnTabDel.Name = "BtnTabDel"
        Me.BtnTabDel.SmallImage = CType(resources.GetObject("BtnTabDel.SmallImage"), System.Drawing.Image)
        Me.BtnTabDel.Text = "タブ削除"
        Me.BtnTabDel.ToolTip = resources.GetString("BtnTabDel.ToolTip")
        '
        'RibbonGroup3
        '
        Me.RibbonGroup3.Items.Add(Me.BtnCheckSet)
        Me.RibbonGroup3.Items.Add(Me.BtnCheckDiset)
        Me.RibbonGroup3.Items.Add(Me.RibbonSeparator2)
        Me.RibbonGroup3.Items.Add(Me.BtnAddRow)
        Me.RibbonGroup3.Items.Add(Me.BtnInsRow)
        Me.RibbonGroup3.Items.Add(Me.BtnRowCopy)
        Me.RibbonGroup3.Items.Add(Me.BtnDelRow)
        Me.RibbonGroup3.Items.Add(Me.RibbonSeparator15)
        Me.RibbonGroup3.Items.Add(Me.BtnMoveData)
        Me.RibbonGroup3.Items.Add(Me.BtnDataSeek)
        Me.RibbonGroup3.Items.Add(Me.BtnCopyValue_Right)
        Me.RibbonGroup3.Items.Add(Me.BtnCopyValue_Left)
        Me.RibbonGroup3.Name = "RibbonGroup3"
        Me.RibbonGroup3.Text = "データ表操作"
        '
        'BtnCheckSet
        '
        Me.BtnCheckSet.Items.Add(Me.BtnCheckSet_All)
        Me.BtnCheckSet.Items.Add(Me.BtnCheckSet_DedRow)
        Me.BtnCheckSet.Items.Add(Me.BtnCheckSet_VirifaiCheck)
        Me.BtnCheckSet.LargeImage = CType(resources.GetObject("BtnCheckSet.LargeImage"), System.Drawing.Image)
        Me.BtnCheckSet.Name = "BtnCheckSet"
        Me.BtnCheckSet.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.BtnCheckSet.SmallImage = CType(resources.GetObject("BtnCheckSet.SmallImage"), System.Drawing.Image)
        Me.BtnCheckSet.Text = "チェック設定"
        Me.BtnCheckSet.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnCheckSet.ToolTip = resources.GetString("BtnCheckSet.ToolTip")
        '
        'BtnCheckSet_All
        '
        Me.BtnCheckSet_All.Name = "BtnCheckSet_All"
        Me.BtnCheckSet_All.SmallImage = CType(resources.GetObject("BtnCheckSet_All.SmallImage"), System.Drawing.Image)
        Me.BtnCheckSet_All.Text = "全ての行にチェック"
        Me.BtnCheckSet_All.ToolTip = resources.GetString("BtnCheckSet_All.ToolTip")
        '
        'BtnCheckSet_DedRow
        '
        Me.BtnCheckSet_DedRow.Name = "BtnCheckSet_DedRow"
        Me.BtnCheckSet_DedRow.SmallImage = CType(resources.GetObject("BtnCheckSet_DedRow.SmallImage"), System.Drawing.Image)
        Me.BtnCheckSet_DedRow.Text = "全ての空行にチェック"
        Me.BtnCheckSet_DedRow.ToolTip = resources.GetString("BtnCheckSet_DedRow.ToolTip")
        '
        'BtnCheckSet_VirifaiCheck
        '
        Me.BtnCheckSet_VirifaiCheck.Name = "BtnCheckSet_VirifaiCheck"
        Me.BtnCheckSet_VirifaiCheck.SmallImage = CType(resources.GetObject("BtnCheckSet_VirifaiCheck.SmallImage"), System.Drawing.Image)
        Me.BtnCheckSet_VirifaiCheck.Text = "照合チェック"
        Me.BtnCheckSet_VirifaiCheck.ToolTip = resources.GetString("BtnCheckSet_VirifaiCheck.ToolTip")
        '
        'BtnCheckDiset
        '
        Me.BtnCheckDiset.LargeImage = CType(resources.GetObject("BtnCheckDiset.LargeImage"), System.Drawing.Image)
        Me.BtnCheckDiset.Name = "BtnCheckDiset"
        Me.BtnCheckDiset.SmallImage = CType(resources.GetObject("BtnCheckDiset.SmallImage"), System.Drawing.Image)
        Me.BtnCheckDiset.Text = "チェック解除"
        Me.BtnCheckDiset.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnCheckDiset.ToolTip = resources.GetString("BtnCheckDiset.ToolTip")
        '
        'RibbonSeparator2
        '
        Me.RibbonSeparator2.Name = "RibbonSeparator2"
        '
        'BtnAddRow
        '
        Me.BtnAddRow.LargeImage = CType(resources.GetObject("BtnAddRow.LargeImage"), System.Drawing.Image)
        Me.BtnAddRow.Name = "BtnAddRow"
        Me.BtnAddRow.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.BtnAddRow.SmallImage = CType(resources.GetObject("BtnAddRow.SmallImage"), System.Drawing.Image)
        Me.BtnAddRow.Text = "行追加"
        Me.BtnAddRow.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnAddRow.ToolTip = resources.GetString("BtnAddRow.ToolTip")
        '
        'BtnInsRow
        '
        Me.BtnInsRow.LargeImage = CType(resources.GetObject("BtnInsRow.LargeImage"), System.Drawing.Image)
        Me.BtnInsRow.Name = "BtnInsRow"
        Me.BtnInsRow.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.BtnInsRow.SmallImage = CType(resources.GetObject("BtnInsRow.SmallImage"), System.Drawing.Image)
        Me.BtnInsRow.Text = "行挿入"
        Me.BtnInsRow.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnInsRow.ToolTip = resources.GetString("BtnInsRow.ToolTip")
        '
        'BtnRowCopy
        '
        Me.BtnRowCopy.Items.Add(Me.BtnRowCopyLast)
        Me.BtnRowCopy.LargeImage = CType(resources.GetObject("BtnRowCopy.LargeImage"), System.Drawing.Image)
        Me.BtnRowCopy.Name = "BtnRowCopy"
        Me.BtnRowCopy.SmallImage = CType(resources.GetObject("BtnRowCopy.SmallImage"), System.Drawing.Image)
        Me.BtnRowCopy.Text = "行複写"
        Me.BtnRowCopy.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnRowCopy.ToolTip = resources.GetString("BtnRowCopy.ToolTip")
        '
        'BtnRowCopyLast
        '
        Me.BtnRowCopyLast.Name = "BtnRowCopyLast"
        Me.BtnRowCopyLast.SmallImage = CType(resources.GetObject("BtnRowCopyLast.SmallImage"), System.Drawing.Image)
        Me.BtnRowCopyLast.Text = "最下段に複写"
        Me.BtnRowCopyLast.ToolTip = resources.GetString("BtnRowCopyLast.ToolTip")
        '
        'BtnDelRow
        '
        Me.BtnDelRow.Items.Add(Me.BtnDelRowCheck)
        Me.BtnDelRow.LargeImage = CType(resources.GetObject("BtnDelRow.LargeImage"), System.Drawing.Image)
        Me.BtnDelRow.Name = "BtnDelRow"
        Me.BtnDelRow.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.BtnDelRow.SmallImage = CType(resources.GetObject("BtnDelRow.SmallImage"), System.Drawing.Image)
        Me.BtnDelRow.Text = "行削除"
        Me.BtnDelRow.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnDelRow.ToolTip = resources.GetString("BtnDelRow.ToolTip")
        '
        'BtnDelRowCheck
        '
        Me.BtnDelRowCheck.Name = "BtnDelRowCheck"
        Me.BtnDelRowCheck.SmallImage = CType(resources.GetObject("BtnDelRowCheck.SmallImage"), System.Drawing.Image)
        Me.BtnDelRowCheck.Text = "チェック行削除"
        Me.BtnDelRowCheck.ToolTip = resources.GetString("BtnDelRowCheck.ToolTip")
        '
        'RibbonSeparator15
        '
        Me.RibbonSeparator15.Name = "RibbonSeparator15"
        '
        'BtnMoveData
        '
        Me.BtnMoveData.Name = "BtnMoveData"
        Me.BtnMoveData.SmallImage = CType(resources.GetObject("BtnMoveData.SmallImage"), System.Drawing.Image)
        Me.BtnMoveData.Text = "データ移動"
        Me.BtnMoveData.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnMoveData.ToolTip = resources.GetString("BtnMoveData.ToolTip")
        '
        'BtnDataSeek
        '
        Me.BtnDataSeek.Name = "BtnDataSeek"
        Me.BtnDataSeek.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.BtnDataSeek.SmallImage = CType(resources.GetObject("BtnDataSeek.SmallImage"), System.Drawing.Image)
        Me.BtnDataSeek.Text = "検索・置換"
        Me.BtnDataSeek.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnDataSeek.ToolTip = resources.GetString("BtnDataSeek.ToolTip")
        '
        'BtnCopyValue_Right
        '
        Me.BtnCopyValue_Right.Name = "BtnCopyValue_Right"
        Me.BtnCopyValue_Right.SmallImage = CType(resources.GetObject("BtnCopyValue_Right.SmallImage"), System.Drawing.Image)
        Me.BtnCopyValue_Right.Text = "右にコピー"
        Me.BtnCopyValue_Right.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'BtnCopyValue_Left
        '
        Me.BtnCopyValue_Left.Name = "BtnCopyValue_Left"
        Me.BtnCopyValue_Left.SmallImage = CType(resources.GetObject("BtnCopyValue_Left.SmallImage"), System.Drawing.Image)
        Me.BtnCopyValue_Left.Text = "左にコピー"
        Me.BtnCopyValue_Left.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonGroup4
        '
        Me.RibbonGroup4.Items.Add(Me.TxtMaergin_Top)
        Me.RibbonGroup4.Items.Add(Me.TxtMaergin_Left)
        Me.RibbonGroup4.Items.Add(Me.BtnSamplePreview)
        Me.RibbonGroup4.Items.Add(Me.RibbonSeparator5)
        Me.RibbonGroup4.Items.Add(Me.BtnSelTack)
        Me.RibbonGroup4.Name = "RibbonGroup4"
        Me.RibbonGroup4.Text = "用紙"
        '
        'TxtMaergin_Top
        '
        Me.TxtMaergin_Top.Description = "ssss"
        Me.TxtMaergin_Top.Format = "###.##"
        Me.TxtMaergin_Top.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.TxtMaergin_Top.Label = "上補正(mm)"
        Me.TxtMaergin_Top.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.TxtMaergin_Top.Name = "TxtMaergin_Top"
        Me.TxtMaergin_Top.TextAreaWidth = 30
        Me.TxtMaergin_Top.ToolTip = resources.GetString("TxtMaergin_Top.ToolTip")
        '
        'TxtMaergin_Left
        '
        Me.TxtMaergin_Left.Format = "###.##"
        Me.TxtMaergin_Left.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.TxtMaergin_Left.Label = "左補正(mm)"
        Me.TxtMaergin_Left.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.TxtMaergin_Left.Name = "TxtMaergin_Left"
        Me.TxtMaergin_Left.TextAreaWidth = 30
        Me.TxtMaergin_Left.ToolTip = resources.GetString("TxtMaergin_Left.ToolTip")
        '
        'BtnSamplePreview
        '
        Me.BtnSamplePreview.LargeImage = CType(resources.GetObject("BtnSamplePreview.LargeImage"), System.Drawing.Image)
        Me.BtnSamplePreview.Name = "BtnSamplePreview"
        Me.BtnSamplePreview.SmallImage = CType(resources.GetObject("BtnSamplePreview.SmallImage"), System.Drawing.Image)
        Me.BtnSamplePreview.Text = "位置確認"
        Me.BtnSamplePreview.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnSamplePreview.ToolTip = resources.GetString("BtnSamplePreview.ToolTip")
        '
        'RibbonSeparator5
        '
        Me.RibbonSeparator5.Name = "RibbonSeparator5"
        '
        'BtnSelTack
        '
        Me.BtnSelTack.LargeImage = CType(resources.GetObject("BtnSelTack.LargeImage"), System.Drawing.Image)
        Me.BtnSelTack.Name = "BtnSelTack"
        Me.BtnSelTack.SmallImage = CType(resources.GetObject("BtnSelTack.SmallImage"), System.Drawing.Image)
        Me.BtnSelTack.Text = "タック選択"
        Me.BtnSelTack.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnSelTack.ToolTip = resources.GetString("BtnSelTack.ToolTip")
        '
        'RibbonGroup5
        '
        Me.RibbonGroup5.Items.Add(Me.TxtBusu)
        Me.RibbonGroup5.Items.Add(Me.BtnFullPrint)
        Me.RibbonGroup5.Items.Add(Me.RibbonSeparator7)
        Me.RibbonGroup5.Items.Add(Me.ChkPreviewFrame)
        Me.RibbonGroup5.Items.Add(Me.ChkPreviewFrame2)
        Me.RibbonGroup5.Items.Add(Me.RibbonSeparator6)
        Me.RibbonGroup5.Items.Add(Me.BtnPreview)
        Me.RibbonGroup5.Items.Add(Me.BtnMovePage_Front)
        Me.RibbonGroup5.Items.Add(Me.BtnMovePage_Next)
        Me.RibbonGroup5.Items.Add(Me.RibbonSeparator14)
        Me.RibbonGroup5.Items.Add(Me.BtnPreviewWide)
        Me.RibbonGroup5.Items.Add(Me.BtnPreviewAll)
        Me.RibbonGroup5.Items.Add(Me.BtnReportScan)
        Me.RibbonGroup5.Items.Add(Me.BtnNoPreview)
        Me.RibbonGroup5.Items.Add(Me.RibbonSeparator8)
        Me.RibbonGroup5.Items.Add(Me.BtnPrintOut)
        Me.RibbonGroup5.Name = "RibbonGroup5"
        Me.RibbonGroup5.Text = "印刷"
        '
        'TxtBusu
        '
        Me.TxtBusu.Label = "部数"
        Me.TxtBusu.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.TxtBusu.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtBusu.Name = "TxtBusu"
        Me.TxtBusu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtBusu.TextAreaWidth = 30
        Me.TxtBusu.ToolTip = resources.GetString("TxtBusu.ToolTip")
        Me.TxtBusu.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'BtnFullPrint
        '
        Me.BtnFullPrint.Name = "BtnFullPrint"
        Me.BtnFullPrint.SmallImage = CType(resources.GetObject("BtnFullPrint.SmallImage"), System.Drawing.Image)
        Me.BtnFullPrint.Text = "全面数"
        Me.BtnFullPrint.ToolTip = resources.GetString("BtnFullPrint.ToolTip")
        '
        'RibbonSeparator7
        '
        Me.RibbonSeparator7.Name = "RibbonSeparator7"
        '
        'ChkPreviewFrame
        '
        Me.ChkPreviewFrame.Name = "ChkPreviewFrame"
        Me.ChkPreviewFrame.Text = "タック枠表示"
        Me.ChkPreviewFrame.ToolTip = resources.GetString("ChkPreviewFrame.ToolTip")
        '
        'ChkPreviewFrame2
        '
        Me.ChkPreviewFrame2.Name = "ChkPreviewFrame2"
        Me.ChkPreviewFrame2.Text = "フィールド枠表示"
        '
        'RibbonSeparator6
        '
        Me.RibbonSeparator6.Name = "RibbonSeparator6"
        '
        'BtnPreview
        '
        Me.BtnPreview.LargeImage = CType(resources.GetObject("BtnPreview.LargeImage"), System.Drawing.Image)
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F12), System.Windows.Forms.Keys)
        Me.BtnPreview.SmallImage = CType(resources.GetObject("BtnPreview.SmallImage"), System.Drawing.Image)
        Me.BtnPreview.Text = "プレビュー"
        Me.BtnPreview.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnPreview.ToolTip = resources.GetString("BtnPreview.ToolTip")
        '
        'BtnMovePage_Front
        '
        Me.BtnMovePage_Front.LargeImage = CType(resources.GetObject("BtnMovePage_Front.LargeImage"), System.Drawing.Image)
        Me.BtnMovePage_Front.Name = "BtnMovePage_Front"
        Me.BtnMovePage_Front.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)
        Me.BtnMovePage_Front.SmallImage = CType(resources.GetObject("BtnMovePage_Front.SmallImage"), System.Drawing.Image)
        Me.BtnMovePage_Front.Text = "前頁"
        Me.BtnMovePage_Front.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnMovePage_Front.ToolTip = resources.GetString("BtnMovePage_Front.ToolTip")
        '
        'BtnMovePage_Next
        '
        Me.BtnMovePage_Next.LargeImage = CType(resources.GetObject("BtnMovePage_Next.LargeImage"), System.Drawing.Image)
        Me.BtnMovePage_Next.Name = "BtnMovePage_Next"
        Me.BtnMovePage_Next.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)
        Me.BtnMovePage_Next.SmallImage = CType(resources.GetObject("BtnMovePage_Next.SmallImage"), System.Drawing.Image)
        Me.BtnMovePage_Next.Text = "次頁"
        Me.BtnMovePage_Next.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnMovePage_Next.ToolTip = resources.GetString("BtnMovePage_Next.ToolTip")
        '
        'RibbonSeparator14
        '
        Me.RibbonSeparator14.Name = "RibbonSeparator14"
        '
        'BtnPreviewWide
        '
        Me.BtnPreviewWide.LargeImage = CType(resources.GetObject("BtnPreviewWide.LargeImage"), System.Drawing.Image)
        Me.BtnPreviewWide.Name = "BtnPreviewWide"
        Me.BtnPreviewWide.SmallImage = CType(resources.GetObject("BtnPreviewWide.SmallImage"), System.Drawing.Image)
        Me.BtnPreviewWide.Text = "幅基準"
        Me.BtnPreviewWide.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnPreviewWide.ToolTip = resources.GetString("BtnPreviewWide.ToolTip")
        '
        'BtnPreviewAll
        '
        Me.BtnPreviewAll.LargeImage = CType(resources.GetObject("BtnPreviewAll.LargeImage"), System.Drawing.Image)
        Me.BtnPreviewAll.Name = "BtnPreviewAll"
        Me.BtnPreviewAll.SmallImage = CType(resources.GetObject("BtnPreviewAll.SmallImage"), System.Drawing.Image)
        Me.BtnPreviewAll.Text = "全体"
        Me.BtnPreviewAll.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnPreviewAll.ToolTip = resources.GetString("BtnPreviewAll.ToolTip")
        '
        'BtnReportScan
        '
        Me.BtnReportScan.Name = "BtnReportScan"
        Me.BtnReportScan.SmallImage = CType(resources.GetObject("BtnReportScan.SmallImage"), System.Drawing.Image)
        Me.BtnReportScan.Text = "検索"
        Me.BtnReportScan.ToolTip = resources.GetString("BtnReportScan.ToolTip")
        '
        'BtnNoPreview
        '
        Me.BtnNoPreview.Name = "BtnNoPreview"
        Me.BtnNoPreview.SmallImage = CType(resources.GetObject("BtnNoPreview.SmallImage"), System.Drawing.Image)
        Me.BtnNoPreview.Text = "PV非表示"
        Me.BtnNoPreview.ToolTip = resources.GetString("BtnNoPreview.ToolTip")
        '
        'RibbonSeparator8
        '
        Me.RibbonSeparator8.Name = "RibbonSeparator8"
        '
        'BtnPrintOut
        '
        Me.BtnPrintOut.Items.Add(Me.BtnOutPDF)
        Me.BtnPrintOut.LargeImage = CType(resources.GetObject("BtnPrintOut.LargeImage"), System.Drawing.Image)
        Me.BtnPrintOut.Name = "BtnPrintOut"
        Me.BtnPrintOut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.BtnPrintOut.SmallImage = CType(resources.GetObject("BtnPrintOut.SmallImage"), System.Drawing.Image)
        Me.BtnPrintOut.Text = "印刷"
        Me.BtnPrintOut.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'BtnOutPDF
        '
        Me.BtnOutPDF.Name = "BtnOutPDF"
        Me.BtnOutPDF.SmallImage = CType(resources.GetObject("BtnOutPDF.SmallImage"), System.Drawing.Image)
        Me.BtnOutPDF.Text = "PDF出力"
        '
        'RibbonTab3
        '
        Me.RibbonTab3.Groups.Add(Me.RibbonGroup8)
        Me.RibbonTab3.Groups.Add(Me.RibbonGroup81)
        Me.RibbonTab3.Name = "RibbonTab3"
        Me.RibbonTab3.Text = "インポート・エクスポート"
        '
        'RibbonGroup8
        '
        Me.RibbonGroup8.Items.Add(Me.BtnClipboad_Load)
        Me.RibbonGroup8.Items.Add(Me.BtnCSV_Load)
        Me.RibbonGroup8.Name = "RibbonGroup8"
        Me.RibbonGroup8.Text = "インポート"
        '
        'BtnClipboad_Load
        '
        Me.BtnClipboad_Load.LargeImage = CType(resources.GetObject("BtnClipboad_Load.LargeImage"), System.Drawing.Image)
        Me.BtnClipboad_Load.Name = "BtnClipboad_Load"
        Me.BtnClipboad_Load.SmallImage = CType(resources.GetObject("BtnClipboad_Load.SmallImage"), System.Drawing.Image)
        Me.BtnClipboad_Load.Text = "Excelコピーから追加"
        Me.BtnClipboad_Load.ToolTip = resources.GetString("BtnClipboad_Load.ToolTip")
        '
        'BtnCSV_Load
        '
        Me.BtnCSV_Load.LargeImage = CType(resources.GetObject("BtnCSV_Load.LargeImage"), System.Drawing.Image)
        Me.BtnCSV_Load.Name = "BtnCSV_Load"
        Me.BtnCSV_Load.SmallImage = CType(resources.GetObject("BtnCSV_Load.SmallImage"), System.Drawing.Image)
        Me.BtnCSV_Load.Text = "CSVからインポート"
        Me.BtnCSV_Load.ToolTip = resources.GetString("BtnCSV_Load.ToolTip")
        '
        'RibbonGroup81
        '
        Me.RibbonGroup81.Items.Add(Me.BtnWordInsData)
        Me.RibbonGroup81.Items.Add(Me.RibbonSeparator3)
        Me.RibbonGroup81.Items.Add(Me.BtnCSV_Save)
        Me.RibbonGroup81.Items.Add(Me.BtnCSV_SavePart)
        Me.RibbonGroup81.Items.Add(Me.BtnExcel_Save)
        Me.RibbonGroup81.Name = "RibbonGroup81"
        Me.RibbonGroup81.Text = "エクスポート"
        '
        'BtnWordInsData
        '
        Me.BtnWordInsData.LargeImage = CType(resources.GetObject("BtnWordInsData.LargeImage"), System.Drawing.Image)
        Me.BtnWordInsData.Name = "BtnWordInsData"
        Me.BtnWordInsData.SmallImage = CType(resources.GetObject("BtnWordInsData.SmallImage"), System.Drawing.Image)
        Me.BtnWordInsData.Text = "Word差込"
        Me.BtnWordInsData.ToolTip = resources.GetString("BtnWordInsData.ToolTip")
        '
        'RibbonSeparator3
        '
        Me.RibbonSeparator3.Name = "RibbonSeparator3"
        '
        'BtnCSV_Save
        '
        Me.BtnCSV_Save.LargeImage = CType(resources.GetObject("BtnCSV_Save.LargeImage"), System.Drawing.Image)
        Me.BtnCSV_Save.Name = "BtnCSV_Save"
        Me.BtnCSV_Save.SmallImage = CType(resources.GetObject("BtnCSV_Save.SmallImage"), System.Drawing.Image)
        Me.BtnCSV_Save.Text = "CSVへエクスポート"
        Me.BtnCSV_Save.ToolTip = resources.GetString("BtnCSV_Save.ToolTip")
        '
        'BtnCSV_SavePart
        '
        Me.BtnCSV_SavePart.LargeImage = CType(resources.GetObject("BtnCSV_SavePart.LargeImage"), System.Drawing.Image)
        Me.BtnCSV_SavePart.Name = "BtnCSV_SavePart"
        Me.BtnCSV_SavePart.SmallImage = CType(resources.GetObject("BtnCSV_SavePart.SmallImage"), System.Drawing.Image)
        Me.BtnCSV_SavePart.Text = "チェック行CSVエクスポート"
        Me.BtnCSV_SavePart.ToolTip = resources.GetString("BtnCSV_SavePart.ToolTip")
        '
        'BtnExcel_Save
        '
        Me.BtnExcel_Save.LargeImage = CType(resources.GetObject("BtnExcel_Save.LargeImage"), System.Drawing.Image)
        Me.BtnExcel_Save.Name = "BtnExcel_Save"
        Me.BtnExcel_Save.SmallImage = CType(resources.GetObject("BtnExcel_Save.SmallImage"), System.Drawing.Image)
        Me.BtnExcel_Save.Text = "Excelに出力"
        Me.BtnExcel_Save.ToolTip = resources.GetString("BtnExcel_Save.ToolTip")
        '
        'RibbonTab2
        '
        Me.RibbonTab2.Groups.Add(Me.RibbonGroup7)
        Me.RibbonTab2.Groups.Add(Me.RibbonGroup6)
        Me.RibbonTab2.Name = "RibbonTab2"
        Me.RibbonTab2.Text = "設定"
        '
        'RibbonGroup7
        '
        Me.RibbonGroup7.Items.Add(Me.BtnSetting)
        Me.RibbonGroup7.Items.Add(Me.BtnTackEdit)
        Me.RibbonGroup7.Items.Add(Me.BtnPaperListEdit)
        Me.RibbonGroup7.Items.Add(Me.BtnDataFile)
        Me.RibbonGroup7.Items.Add(Me.RibbonSeparator17)
        Me.RibbonGroup7.Items.Add(Me.BtnDataDelete)
        Me.RibbonGroup7.Name = "RibbonGroup7"
        Me.RibbonGroup7.Text = "設定"
        '
        'BtnSetting
        '
        Me.BtnSetting.LargeImage = CType(resources.GetObject("BtnSetting.LargeImage"), System.Drawing.Image)
        Me.BtnSetting.Name = "BtnSetting"
        Me.BtnSetting.SmallImage = CType(resources.GetObject("BtnSetting.SmallImage"), System.Drawing.Image)
        Me.BtnSetting.Text = "一般設定"
        Me.BtnSetting.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnSetting.ToolTip = resources.GetString("BtnSetting.ToolTip")
        '
        'BtnTackEdit
        '
        Me.BtnTackEdit.LargeImage = CType(resources.GetObject("BtnTackEdit.LargeImage"), System.Drawing.Image)
        Me.BtnTackEdit.Name = "BtnTackEdit"
        Me.BtnTackEdit.SmallImage = CType(resources.GetObject("BtnTackEdit.SmallImage"), System.Drawing.Image)
        Me.BtnTackEdit.Text = "タック編集"
        Me.BtnTackEdit.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnTackEdit.ToolTip = resources.GetString("BtnTackEdit.ToolTip")
        '
        'BtnPaperListEdit
        '
        Me.BtnPaperListEdit.LargeImage = CType(resources.GetObject("BtnPaperListEdit.LargeImage"), System.Drawing.Image)
        Me.BtnPaperListEdit.Name = "BtnPaperListEdit"
        Me.BtnPaperListEdit.SmallImage = CType(resources.GetObject("BtnPaperListEdit.SmallImage"), System.Drawing.Image)
        Me.BtnPaperListEdit.Text = "用紙編集"
        Me.BtnPaperListEdit.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnPaperListEdit.ToolTip = resources.GetString("BtnPaperListEdit.ToolTip")
        '
        'BtnDataFile
        '
        Me.BtnDataFile.LargeImage = CType(resources.GetObject("BtnDataFile.LargeImage"), System.Drawing.Image)
        Me.BtnDataFile.Name = "BtnDataFile"
        Me.BtnDataFile.SmallImage = CType(resources.GetObject("BtnDataFile.SmallImage"), System.Drawing.Image)
        Me.BtnDataFile.Text = "データファイル"
        Me.BtnDataFile.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnDataFile.ToolTip = resources.GetString("BtnDataFile.ToolTip")
        '
        'RibbonSeparator17
        '
        Me.RibbonSeparator17.Name = "RibbonSeparator17"
        '
        'BtnDataDelete
        '
        Me.BtnDataDelete.LargeImage = CType(resources.GetObject("BtnDataDelete.LargeImage"), System.Drawing.Image)
        Me.BtnDataDelete.Name = "BtnDataDelete"
        Me.BtnDataDelete.SmallImage = CType(resources.GetObject("BtnDataDelete.SmallImage"), System.Drawing.Image)
        Me.BtnDataDelete.Text = "全データ削除"
        Me.BtnDataDelete.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.BtnDataDelete.ToolTip = resources.GetString("BtnDataDelete.ToolTip")
        '
        'RibbonGroup6
        '
        Me.RibbonGroup6.Items.Add(Me.BtnHelp)
        Me.RibbonGroup6.Name = "RibbonGroup6"
        Me.RibbonGroup6.Text = "その他"
        '
        'BtnHelp
        '
        Me.BtnHelp.LargeImage = CType(resources.GetObject("BtnHelp.LargeImage"), System.Drawing.Image)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.SmallImage = CType(resources.GetObject("BtnHelp.SmallImage"), System.Drawing.Image)
        Me.BtnHelp.Text = "ヘルプ"
        Me.BtnHelp.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.LeftPaneItems.Add(Me.LblMessage)
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 687)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel11)
        Me.C1StatusBar1.RightPaneItems.Add(Me.LblRowCount)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel7)
        Me.C1StatusBar1.RightPaneItems.Add(Me.LblSelCount)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator4)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel6)
        Me.C1StatusBar1.RightPaneItems.Add(Me.StatLabel_Seet)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator9)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel3)
        Me.C1StatusBar1.RightPaneItems.Add(Me.StatLabel_Maker)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator10)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel5)
        Me.C1StatusBar1.RightPaneItems.Add(Me.StatLabel_Model)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator11)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel1)
        Me.C1StatusBar1.RightPaneItems.Add(Me.StatLabel_Size)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator12)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel4)
        Me.C1StatusBar1.RightPaneItems.Add(Me.StatLabel_Tack)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator13)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel2)
        Me.C1StatusBar1.RightPaneItems.Add(Me.StatLabel_Printer)
        Me.C1StatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.C1StatusBar1.Size = New System.Drawing.Size(1240, 23)
        Me.C1StatusBar1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("document_inspector.png", CType(resources.GetObject("C1StatusBar1.ToolTipSettings.Images"), System.Drawing.Image)))
        Me.C1StatusBar1.ToolTipSettings.Images.Add(New C1.Win.C1Ribbon.ImageEntry("information.png", CType(resources.GetObject("C1StatusBar1.ToolTipSettings.Images1"), System.Drawing.Image)))
        Me.C1StatusBar1.ToolTipSettings.IsBalloon = True
        '
        'LblMessage
        '
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Text = "ラベル"
        '
        'RibbonLabel11
        '
        Me.RibbonLabel11.Name = "RibbonLabel11"
        Me.RibbonLabel11.Text = "登録行数："
        Me.RibbonLabel11.ToolTip = resources.GetString("RibbonLabel11.ToolTip")
        '
        'LblRowCount
        '
        Me.LblRowCount.Name = "LblRowCount"
        Me.LblRowCount.Text = "ラベル"
        Me.LblRowCount.ToolTip = resources.GetString("LblRowCount.ToolTip")
        '
        'RibbonLabel7
        '
        Me.RibbonLabel7.Name = "RibbonLabel7"
        Me.RibbonLabel7.Text = "選択行数："
        Me.RibbonLabel7.ToolTip = resources.GetString("RibbonLabel7.ToolTip")
        '
        'LblSelCount
        '
        Me.LblSelCount.Name = "LblSelCount"
        Me.LblSelCount.Text = "ラベル"
        Me.LblSelCount.ToolTip = resources.GetString("LblSelCount.ToolTip")
        '
        'RibbonSeparator4
        '
        Me.RibbonSeparator4.Name = "RibbonSeparator4"
        '
        'RibbonLabel6
        '
        Me.RibbonLabel6.Name = "RibbonLabel6"
        Me.RibbonLabel6.SmallImage = CType(resources.GetObject("RibbonLabel6.SmallImage"), System.Drawing.Image)
        Me.RibbonLabel6.Text = "使用用紙："
        Me.RibbonLabel6.ToolTip = resources.GetString("RibbonLabel6.ToolTip")
        '
        'StatLabel_Seet
        '
        Me.StatLabel_Seet.Name = "StatLabel_Seet"
        Me.StatLabel_Seet.Text = "ボタン"
        Me.StatLabel_Seet.ToolTip = resources.GetString("StatLabel_Seet.ToolTip")
        '
        'RibbonSeparator9
        '
        Me.RibbonSeparator9.Name = "RibbonSeparator9"
        '
        'RibbonLabel3
        '
        Me.RibbonLabel3.Name = "RibbonLabel3"
        Me.RibbonLabel3.SmallImage = CType(resources.GetObject("RibbonLabel3.SmallImage"), System.Drawing.Image)
        Me.RibbonLabel3.Text = "メーカー："
        Me.RibbonLabel3.ToolTip = resources.GetString("RibbonLabel3.ToolTip")
        '
        'StatLabel_Maker
        '
        Me.StatLabel_Maker.Name = "StatLabel_Maker"
        Me.StatLabel_Maker.Text = "ラベルs"
        Me.StatLabel_Maker.ToolTip = resources.GetString("StatLabel_Maker.ToolTip")
        '
        'RibbonSeparator10
        '
        Me.RibbonSeparator10.Name = "RibbonSeparator10"
        '
        'RibbonLabel5
        '
        Me.RibbonLabel5.Name = "RibbonLabel5"
        Me.RibbonLabel5.Text = "型式："
        Me.RibbonLabel5.ToolTip = resources.GetString("RibbonLabel5.ToolTip")
        '
        'StatLabel_Model
        '
        Me.StatLabel_Model.Name = "StatLabel_Model"
        Me.StatLabel_Model.Text = "ラベル"
        Me.StatLabel_Model.ToolTip = resources.GetString("StatLabel_Model.ToolTip")
        '
        'RibbonSeparator11
        '
        Me.RibbonSeparator11.Name = "RibbonSeparator11"
        '
        'RibbonLabel1
        '
        Me.RibbonLabel1.Name = "RibbonLabel1"
        Me.RibbonLabel1.Text = "用紙サイズ"
        Me.RibbonLabel1.ToolTip = resources.GetString("RibbonLabel1.ToolTip")
        '
        'StatLabel_Size
        '
        Me.StatLabel_Size.Name = "StatLabel_Size"
        Me.StatLabel_Size.Text = "ラベル"
        Me.StatLabel_Size.ToolTip = resources.GetString("StatLabel_Size.ToolTip")
        '
        'RibbonSeparator12
        '
        Me.RibbonSeparator12.Name = "RibbonSeparator12"
        '
        'RibbonLabel4
        '
        Me.RibbonLabel4.Name = "RibbonLabel4"
        Me.RibbonLabel4.Text = "タック数"
        Me.RibbonLabel4.ToolTip = resources.GetString("RibbonLabel4.ToolTip")
        '
        'StatLabel_Tack
        '
        Me.StatLabel_Tack.Name = "StatLabel_Tack"
        Me.StatLabel_Tack.Text = "ラベル"
        Me.StatLabel_Tack.ToolTip = resources.GetString("StatLabel_Tack.ToolTip")
        '
        'RibbonSeparator13
        '
        Me.RibbonSeparator13.Name = "RibbonSeparator13"
        '
        'RibbonLabel2
        '
        Me.RibbonLabel2.Name = "RibbonLabel2"
        Me.RibbonLabel2.SmallImage = CType(resources.GetObject("RibbonLabel2.SmallImage"), System.Drawing.Image)
        Me.RibbonLabel2.Text = "出力プリンター："
        Me.RibbonLabel2.ToolTip = resources.GetString("RibbonLabel2.ToolTip")
        '
        'StatLabel_Printer
        '
        Me.StatLabel_Printer.Name = "StatLabel_Printer"
        Me.StatLabel_Printer.Text = "."
        Me.StatLabel_Printer.ToolTip = resources.GetString("StatLabel_Printer.ToolTip")
        '
        'PdfExport1
        '
        Me.PdfExport1.Pagination = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1240, 710)
        Me.Controls.Add(Me.C1Sizer1)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Controls.Add(Me.C1Ribbon1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmMain"
        Me.Text = "タックラベラー"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Blue
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.C1Sizer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer2.ResumeLayout(False)
        CType(Me.SS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SS_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Sizer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer3.ResumeLayout(False)
        CType(Me.TxtNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GcTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GcTabControl1.ResumeLayout(False)
        Me.ConMenuTab.ResumeLayout(False)
        Me.ConMenuSS.ResumeLayout(False)
        CType(Me.C1Ribbon1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents GcFieldStyler1 As GrapeCity.Win.Editors.GcFieldStyler
    Friend WithEvents SS As FarPoint.Win.Spread.FpSpread
    Friend WithEvents SS_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents C1Ribbon1 As C1.Win.C1Ribbon.C1Ribbon
    Friend WithEvents RibbonApplicationMenu1 As C1.Win.C1Ribbon.RibbonApplicationMenu
    Friend WithEvents RibbonConfigToolBar1 As C1.Win.C1Ribbon.RibbonConfigToolBar
    Friend WithEvents RibbonQat1 As C1.Win.C1Ribbon.RibbonQat
    Friend WithEvents RibbonTab1 As C1.Win.C1Ribbon.RibbonTab
    Friend WithEvents RibbonGroup1 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents BtnAPPEnd As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonGroup2 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents BtnTabAdd As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnTabEdit As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonSeparator1 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents BtnTabDel As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonGroup3 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents BtnAddRow As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnInsRow As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonGroup4 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents BtnSelTack As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents Viewer1 As GrapeCity.ActiveReports.Viewer.Win.Viewer
    Friend WithEvents RibbonSeparator2 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents LblMessage As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents TxtMaergin_Top As C1.Win.C1Ribbon.RibbonNumericBox
    Friend WithEvents TxtMaergin_Left As C1.Win.C1Ribbon.RibbonNumericBox
    Friend WithEvents BtnSamplePreview As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonSeparator5 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonGroup5 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents BtnMovePage_Front As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnMovePage_Next As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnMoveData As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnDelRow As C1.Win.C1Ribbon.RibbonSplitButton
    Friend WithEvents BtnDelRowCheck As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnCheckSet As C1.Win.C1Ribbon.RibbonSplitButton
    Friend WithEvents BtnCheckSet_All As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnCheckDiset As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnCheckSet_DedRow As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnTabMove As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnRowCopy As C1.Win.C1Ribbon.RibbonSplitButton
    Friend WithEvents BtnRowCopyLast As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonLabel2 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents StatLabel_Printer As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonLabel3 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents TxtBusu As C1.Win.C1Ribbon.RibbonNumericBox
    Friend WithEvents RibbonLabel6 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonLabel5 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents StatLabel_Model As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator9 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents StatLabel_Maker As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator10 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonSeparator11 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonLabel1 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents StatLabel_Size As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator12 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonLabel4 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents StatLabel_Tack As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator13 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents BtnPreview As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnPreviewWide As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnPreviewAll As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonSeparator8 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonSeparator14 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonSeparator15 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents ChkPreviewFrame As C1.Win.C1Ribbon.RibbonCheckBox
    Friend WithEvents TxtNote As GrapeCity.Win.Editors.GcTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbBackText As System.Windows.Forms.ComboBox
    Friend WithEvents C1Sizer2 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents C1Sizer3 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents RibbonLabel11 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents LblRowCount As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonLabel7 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents LblSelCount As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator4 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents BtnReportScan As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents StatLabel_Seet As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents ConMenuTab As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CMT_Edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMT_Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConMenuSS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CMSS_AddRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSS_InsRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSS_RowCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSS_RowCopyLast As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSS_DelRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSS_DelRowCheck As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnPrintOut As C1.Win.C1Ribbon.RibbonSplitButton
    Friend WithEvents BtnOutPDF As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents PdfExport1 As GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
    Friend WithEvents ChkPreviewFrame2 As C1.Win.C1Ribbon.RibbonCheckBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LblColWidth As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RibbonTab2 As C1.Win.C1Ribbon.RibbonTab
    Friend WithEvents RibbonGroup6 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents BtnHelp As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonGroup7 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents BtnSetting As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnTackEdit As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnPaperListEdit As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnDataFile As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnDataDelete As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonSeparator17 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents BtnSave As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents CMT_Add As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnNoPreview As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnFullPrint As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonSeparator6 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonSeparator7 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents CMT_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMT_Move As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnTabCopy As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents GcTabControl1 As GrapeCity.Win.Containers.GcTabControl
    Friend WithEvents GcTabPage1 As GrapeCity.Win.Containers.GcTabPage
    Friend WithEvents GcTabPage2 As GrapeCity.Win.Containers.GcTabPage
    Friend WithEvents CMSS_CopyRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSS_CopyLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnCopyValue_Left As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnCheckSet_VirifaiCheck As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnItemSeek As System.Windows.Forms.Button
    Friend WithEvents TxtSeekText As System.Windows.Forms.TextBox
    Friend WithEvents OptSeekAria1 As System.Windows.Forms.RadioButton
    Friend WithEvents OptSeekAria0 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnItemSeek_Fowerd As System.Windows.Forms.Button
    Friend WithEvents BtnItemSeek_Next As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDataSeek As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnSeekPanelClose As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TxtFromMoji As System.Windows.Forms.TextBox
    Friend WithEvents TxtToMoji As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkSepCapital As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents OptToNallow As System.Windows.Forms.RadioButton
    Friend WithEvents OptToWide As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents OptWorkAria5 As System.Windows.Forms.RadioButton
    Friend WithEvents OptWorkAria4 As System.Windows.Forms.RadioButton
    Friend WithEvents OptWorkAria3 As System.Windows.Forms.RadioButton
    Friend WithEvents OptWorkAria2 As System.Windows.Forms.RadioButton
    Friend WithEvents OptWorkAria1 As System.Windows.Forms.RadioButton
    Friend WithEvents OptWorkAria0 As System.Windows.Forms.RadioButton
    Friend WithEvents BtnExecuteReplace As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtnCopyValue_Right As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents LblRetCount As System.Windows.Forms.Label
    Friend WithEvents RibbonTab3 As C1.Win.C1Ribbon.RibbonTab
    Friend WithEvents RibbonGroup81 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents BtnWordInsData As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnCSV_Save As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnCSV_SavePart As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnExcel_Save As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonSeparator3 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonGroup8 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents BtnClipboad_Load As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents BtnCSV_Load As C1.Win.C1Ribbon.RibbonButton

End Class
