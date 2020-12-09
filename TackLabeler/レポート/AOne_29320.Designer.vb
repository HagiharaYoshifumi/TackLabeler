<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class AOne_29320 
    Inherits GrapeCity.ActiveReports.SectionReport

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub
    
    'メモ: 以下のプロシージャは ActiveReports デザイナーで必要です。
    'ActiveReports デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim XmlDataSource1 As GrapeCity.ActiveReports.Data.XMLDataSource = New GrapeCity.ActiveReports.Data.XMLDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AOne_29320))
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.txt郵便番号 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt住所 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt会社名 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt部署名 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt名前 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt注意書き = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt備考 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt枠表示 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.txt郵便番号, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt住所, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt会社名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt部署名, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt名前, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt注意書き, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt備考, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt枠表示, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnCount = 3
        Me.Detail.ColumnDirection = GrapeCity.ActiveReports.SectionReportModel.ColumnDirection.AcrossDown
        Me.Detail.ColumnSpacing = 0.07874016!
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape1, Me.txt郵便番号, Me.txt住所, Me.txt会社名, Me.txt部署名, Me.txt名前, Me.txt注意書き, Me.txt備考, Me.txt枠表示})
        Me.Detail.Height = 1.417323!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'Shape1
        '
        Me.Shape1.Height = 1.338583!
        Me.Shape1.Left = 0.0!
        Me.Shape1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape1.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Dash
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 1.062992!
        '
        'txt郵便番号
        '
        Me.txt郵便番号.DataField = "郵便番号"
        Me.txt郵便番号.Height = 0.1212599!
        Me.txt郵便番号.Left = 0.7086616!
        Me.txt郵便番号.Name = "txt郵便番号"
        Me.txt郵便番号.Style = "font-family: ＭＳ Ｐ明朝; font-size: 8pt; vertical-align: middle; ddo-char-set: 1; ddo" & _
    "-font-vertical: none"
        Me.txt郵便番号.Text = "郵便番号"
        Me.txt郵便番号.Top = 0.5511811!
        Me.txt郵便番号.Visible = False
        Me.txt郵便番号.Width = 0.1574807!
        '
        'txt住所
        '
        Me.txt住所.DataField = "住所"
        Me.txt住所.Height = 0.472441!
        Me.txt住所.Left = 0.0!
        Me.txt住所.Name = "txt住所"
        Me.txt住所.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; text-align: center; text-justify: auto; ve" & _
    "rtical-align: middle; ddo-char-set: 1"
        Me.txt住所.Text = "住所"
        Me.txt住所.Top = 0.1574803!
        Me.txt住所.Width = 1.062992!
        '
        'txt会社名
        '
        Me.txt会社名.DataField = "会社名"
        Me.txt会社名.Height = 0.472441!
        Me.txt会社名.Left = 0.0!
        Me.txt会社名.Name = "txt会社名"
        Me.txt会社名.Style = "font-family: ＭＳ Ｐゴシック; font-size: 8pt; font-weight: normal; text-align: center; v" & _
    "ertical-align: middle; ddo-char-set: 1"
        Me.txt会社名.Text = "会社名"
        Me.txt会社名.Top = 0.7086614!
        Me.txt会社名.Width = 1.062992!
        '
        'txt部署名
        '
        Me.txt部署名.DataField = "部署名"
        Me.txt部署名.Height = 0.1212599!
        Me.txt部署名.Left = 0.1165354!
        Me.txt部署名.Name = "txt部署名"
        Me.txt部署名.ShrinkToFit = True
        Me.txt部署名.Style = "font-family: ＭＳ Ｐ明朝; font-size: 8pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txt部署名.Text = "部署名"
        Me.txt部署名.Top = 0.672441!
        Me.txt部署名.Visible = False
        Me.txt部署名.Width = 0.1574807!
        '
        'txt名前
        '
        Me.txt名前.DataField = "名前"
        Me.txt名前.Height = 0.1212599!
        Me.txt名前.Left = 0.2362205!
        Me.txt名前.Name = "txt名前"
        Me.txt名前.ShrinkToFit = True
        Me.txt名前.Style = "font-family: ＭＳ Ｐ明朝; font-size: 8pt; font-weight: bold; text-align: right; ddo-ch" & _
    "ar-set: 1; ddo-shrink-to-fit: true"
        Me.txt名前.Text = "名前"
        Me.txt名前.Top = 0.5511811!
        Me.txt名前.Visible = False
        Me.txt名前.Width = 0.1574807!
        '
        'txt注意書き
        '
        Me.txt注意書き.DataField = "注意書き"
        Me.txt注意書き.Height = 0.1212599!
        Me.txt注意書き.Left = 0.07874012!
        Me.txt注意書き.Name = "txt注意書き"
        Me.txt注意書き.ShrinkToFit = True
        Me.txt注意書き.Style = "font-family: ＭＳ Ｐ明朝; font-size: 8pt; font-weight: bold; text-align: right; vertic" & _
    "al-align: middle; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txt注意書き.Text = "注意書き"
        Me.txt注意書き.Top = 0.5511811!
        Me.txt注意書き.Visible = False
        Me.txt注意書き.Width = 0.1574807!
        '
        'txt備考
        '
        Me.txt備考.DataField = "備考"
        Me.txt備考.Height = 0.1212599!
        Me.txt備考.Left = 0.3937008!
        Me.txt備考.Name = "txt備考"
        Me.txt備考.Style = "font-family: ＭＳ Ｐ明朝; font-size: 8pt; ddo-char-set: 1"
        Me.txt備考.Text = "備考"
        Me.txt備考.Top = 0.5511811!
        Me.txt備考.Visible = False
        Me.txt備考.Width = 0.1574807!
        '
        'txt枠表示
        '
        Me.txt枠表示.DataField = "枠表示"
        Me.txt枠表示.Height = 0.1212599!
        Me.txt枠表示.Left = 0.5511811!
        Me.txt枠表示.Name = "txt枠表示"
        Me.txt枠表示.Style = "font-family: ＭＳ Ｐ明朝; font-size: 8pt; ddo-char-set: 1"
        Me.txt枠表示.Text = "枠表示"
        Me.txt枠表示.Top = 0.5511811!
        Me.txt枠表示.Visible = False
        Me.txt枠表示.Width = 0.1574807!
        '
        'AOne_29320
        '
        Me.MasterReport = False
        XmlDataSource1.FileURL = "C:\Users\yhagihara\AppData\Roaming\NKS\TackLabeler\RepData.xml"
        XmlDataSource1.RecordsetPattern = "//RepDataCollection"
        Me.DataSource = XmlDataSource1
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.2952756!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.8346456!
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait
        Me.PageSettings.PaperHeight = 5.826772!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.JapanesePostcard
        Me.PageSettings.PaperWidth = 3.937008!
        Me.PrintWidth = 3.346457!
        Me.Script = resources.GetString("$this.Script")
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.Detail)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
            "color: Black; font-family: ""MS UI Gothic""; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; font-family: ""MS UI Gothic""; ddo-char-set: 12" & _
            "8", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; font-style: inherit; font-family: ""MS UI Goth" & _
            "ic""; ddo-char-set: 128", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ddo-char-set: 128", "Heading3", "Normal"))
        Me.UserData = ""
        CType(Me.txt郵便番号, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt住所, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt会社名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt部署名, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt名前, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt注意書き, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt備考, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt枠表示, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents Detail As GrapeCity.ActiveReports.SectionReportModel.Detail
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents txt郵便番号 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt住所 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt会社名 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt部署名 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt名前 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt注意書き As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt備考 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt枠表示 As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class 
