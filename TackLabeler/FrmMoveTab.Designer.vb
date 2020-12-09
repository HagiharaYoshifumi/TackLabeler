<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMoveTab
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
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMoveTab))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.SS = New FarPoint.Win.Spread.FpSpread()
        Me.SS_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.Panel1.SuspendLayout()
        CType(Me.SS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SS_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BtnOK)
        Me.Panel1.Controls.Add(Me.BtnCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 395)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(401, 39)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "※行をドラッグしてください"
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Location = New System.Drawing.Point(209, 6)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(89, 26)
        Me.BtnOK.TabIndex = 1
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(304, 6)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 26)
        Me.BtnCancel.TabIndex = 0
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'SS
        '
        Me.SS.AccessibleDescription = "SS, Sheet1, Row 0, Column 0, "
        Me.SS.AllowRowMove = True
        Me.SS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SS.FocusRenderer = New FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer(1)
        Me.SS.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.SS.Location = New System.Drawing.Point(0, 0)
        Me.SS.Name = "SS"
        Me.SS.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.SS_Sheet1})
        Me.SS.Size = New System.Drawing.Size(401, 395)
        Me.SS.TabIndex = 2
        '
        'SS_Sheet1
        '
        Me.SS_Sheet1.Reset()
        Me.SS_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.SS_Sheet1.ColumnCount = 2
        Me.SS_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.LightCyan
        Me.SS_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "タブ"
        Me.SS_Sheet1.Columns.Get(0).CellType = TextCellType1
        Me.SS_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.SS_Sheet1.Columns.Get(0).Label = "タブ"
        Me.SS_Sheet1.Columns.Get(0).Locked = True
        Me.SS_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.SS_Sheet1.Columns.Get(0).Width = 266.0!
        Me.SS_Sheet1.Columns.Get(1).Visible = False
        Me.SS_Sheet1.GrayAreaBackColor = System.Drawing.Color.Gray
        Me.SS_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Me.SS_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.SS_Sheet1.RowHeader.Rows.Default.Resizable = False
        Me.SS_Sheet1.Rows.Default.Resizable = False
        Me.SS_Sheet1.Rows.Get(0).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(1).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(2).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(3).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(4).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(5).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(6).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(7).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(8).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(9).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(10).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(11).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(12).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(13).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(14).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(15).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(16).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(17).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(18).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(19).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(20).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(21).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(22).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(23).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(24).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(25).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(26).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(27).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(28).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(29).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(30).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(31).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(32).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(33).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(34).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(35).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(36).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(37).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(38).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(39).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(40).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(41).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(42).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(43).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(44).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(45).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(46).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(47).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(48).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(49).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(50).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(51).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(52).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(53).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(54).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(55).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(56).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(57).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(58).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(59).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(60).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(61).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(62).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(63).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(64).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(65).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(66).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(67).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(68).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(69).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(70).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(71).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(72).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(73).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(74).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(75).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(76).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(77).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(78).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(79).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(80).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(81).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(82).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(83).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(84).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(85).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(86).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(87).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(88).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(89).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(90).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(91).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(92).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(93).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(94).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(95).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(96).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(97).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(98).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(99).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(100).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(101).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(102).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(103).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(104).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(105).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(106).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(107).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(108).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(109).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(110).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(111).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(112).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(113).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(114).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(115).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(116).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(117).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(118).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(119).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(120).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(121).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(122).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(123).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(124).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(125).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(126).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(127).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(128).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(129).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(130).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(131).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(132).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(133).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(134).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(135).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(136).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(137).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(138).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(139).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(140).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(141).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(142).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(143).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(144).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(145).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(146).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(147).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(148).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(149).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(150).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(151).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(152).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(153).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(154).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(155).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(156).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(157).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(158).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(159).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(160).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(161).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(162).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(163).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(164).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(165).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(166).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(167).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(168).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(169).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(170).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(171).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(172).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(173).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(174).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(175).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(176).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(177).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(178).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(179).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(180).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(181).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(182).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(183).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(184).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(185).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(186).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(187).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(188).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(189).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(190).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(191).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(192).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(193).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(194).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(195).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(196).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(197).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(198).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(199).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(200).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(201).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(202).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(203).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(204).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(205).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(206).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(207).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(208).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(209).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(210).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(211).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(212).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(213).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(214).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(215).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(216).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(217).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(218).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(219).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(220).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(221).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(222).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(223).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(224).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(225).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(226).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(227).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(228).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(229).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(230).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(231).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(232).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(233).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(234).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(235).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(236).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(237).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(238).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(239).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(240).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(241).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(242).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(243).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(244).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(245).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(246).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(247).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(248).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(249).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(250).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(251).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(252).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(253).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(254).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(255).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(256).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(257).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(258).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(259).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(260).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(261).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(262).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(263).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(264).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(265).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(266).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(267).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(268).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(269).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(270).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(271).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(272).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(273).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(274).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(275).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(276).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(277).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(278).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(279).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(280).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(281).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(282).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(283).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(284).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(285).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(286).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(287).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(288).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(289).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(290).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(291).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(292).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(293).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(294).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(295).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(296).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(297).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(298).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(299).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(300).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(301).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(302).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(303).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(304).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(305).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(306).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(307).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(308).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(309).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(310).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(311).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(312).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(313).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(314).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(315).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(316).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(317).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(318).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(319).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(320).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(321).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(322).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(323).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(324).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(325).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(326).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(327).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(328).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(329).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(330).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(331).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(332).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(333).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(334).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(335).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(336).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(337).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(338).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(339).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(340).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(341).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(342).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(343).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(344).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(345).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(346).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(347).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(348).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(349).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(350).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(351).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(352).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(353).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(354).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(355).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(356).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(357).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(358).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(359).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(360).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(361).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(362).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(363).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(364).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(365).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(366).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(367).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(368).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(369).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(370).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(371).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(372).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(373).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(374).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(375).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(376).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(377).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(378).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(379).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(380).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(381).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(382).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(383).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(384).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(385).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(386).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(387).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(388).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(389).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(390).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(391).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(392).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(393).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(394).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(395).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(396).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(397).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(398).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(399).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(400).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(401).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(402).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(403).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(404).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(405).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(406).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(407).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(408).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(409).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(410).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(411).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(412).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(413).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(414).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(415).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(416).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(417).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(418).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(419).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(420).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(421).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(422).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(423).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(424).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(425).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(426).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(427).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(428).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(429).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(430).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(431).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(432).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(433).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(434).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(435).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(436).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(437).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(438).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(439).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(440).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(441).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(442).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(443).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(444).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(445).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(446).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(447).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(448).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(449).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(450).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(451).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(452).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(453).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(454).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(455).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(456).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(457).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(458).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(459).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(460).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(461).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(462).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(463).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(464).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(465).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(466).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(467).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(468).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(469).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(470).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(471).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(472).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(473).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(474).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(475).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(476).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(477).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(478).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(479).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(480).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(481).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(482).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(483).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(484).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(485).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(486).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(487).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(488).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(489).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(490).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(491).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(492).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(493).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(494).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(495).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(496).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(497).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(498).Height = 21.0!
        Me.SS_Sheet1.Rows.Get(499).Height = 21.0!
        Me.SS_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.[Single]
        Me.SS_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row
        Me.SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'FrmMoveTab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(401, 434)
        Me.Controls.Add(Me.SS)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMoveTab"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "タブ移動"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.SS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SS_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents SS As FarPoint.Win.Spread.FpSpread
    Friend WithEvents SS_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
