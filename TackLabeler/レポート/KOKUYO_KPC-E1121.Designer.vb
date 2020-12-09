<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class KOKUYO_KPC_E1121 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KOKUYO_KPC_E1121))
        Dim XmlDataSource1 As GrapeCity.ActiveReports.Data.XMLDataSource = New GrapeCity.ActiveReports.Data.XMLDataSource()
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
        Me.Detail.ColumnCount = 2
        Me.Detail.ColumnDirection = GrapeCity.ActiveReports.SectionReportModel.ColumnDirection.AcrossDown
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape1, Me.txt郵便番号, Me.txt住所, Me.txt会社名, Me.txt部署名, Me.txt名前, Me.txt注意書き, Me.txt備考, Me.txt枠表示})
        Me.Detail.Height = 1.681102!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'Shape1
        '
        Me.Shape1.Height = 1.665354!
        Me.Shape1.Left = 0.0!
        Me.Shape1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape1.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Dash
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 3.401575!
        '
        'txt郵便番号
        '
        Me.txt郵便番号.DataField = "郵便番号"
        Me.txt郵便番号.Height = 0.2!
        Me.txt郵便番号.Left = 0.07874014!
        Me.txt郵便番号.Name = "txt郵便番号"
        Me.txt郵便番号.Style = "font-family: ＭＳ Ｐ明朝; vertical-align: middle; ddo-char-set: 1; ddo-font-vertical: " & _
    "none"
        Me.txt郵便番号.Text = "郵便番号"
        Me.txt郵便番号.Top = 0.07874014!
        Me.txt郵便番号.Width = 0.944882!
        '
        'txt住所
        '
        Me.txt住所.CanShrink = True
        Me.txt住所.DataField = "住所"
        Me.txt住所.Height = 0.2362205!
        Me.txt住所.Left = 0.07874014!
        Me.txt住所.Name = "txt住所"
        Me.txt住所.Style = "font-family: ＭＳ Ｐ明朝; ddo-char-set: 1"
        Me.txt住所.Text = "住所"
        Me.txt住所.Top = 0.3149607!
        Me.txt住所.Width = 3.149606!
        '
        'txt会社名
        '
        Me.txt会社名.CanShrink = True
        Me.txt会社名.DataField = "会社名"
        Me.txt会社名.Height = 0.2362205!
        Me.txt会社名.Left = 0.07874014!
        Me.txt会社名.Name = "txt会社名"
        Me.txt会社名.Style = "font-family: ＭＳ Ｐ明朝; font-size: 14pt; font-weight: normal; vertical-align: middle" & _
    "; ddo-char-set: 1"
        Me.txt会社名.Text = "会社名"
        Me.txt会社名.Top = 0.551181!
        Me.txt会社名.Width = 3.149606!
        '
        'txt部署名
        '
        Me.txt部署名.CanShrink = True
        Me.txt部署名.DataField = "部署名"
        Me.txt部署名.Height = 0.2!
        Me.txt部署名.Left = 0.1472441!
        Me.txt部署名.Name = "txt部署名"
        Me.txt部署名.Style = "font-family: ＭＳ Ｐ明朝; ddo-char-set: 1; ddo-shrink-to-fit: none"
        Me.txt部署名.Text = "部署名"
        Me.txt部署名.Top = 0.7874014!
        Me.txt部署名.Width = 3.081102!
        '
        'txt名前
        '
        Me.txt名前.CanShrink = True
        Me.txt名前.DataField = "名前"
        Me.txt名前.Height = 0.27874!
        Me.txt名前.Left = 0.1574803!
        Me.txt名前.Name = "txt名前"
        Me.txt名前.ShrinkToFit = True
        Me.txt名前.Style = "font-family: ＭＳ Ｐ明朝; font-size: 14pt; font-weight: bold; text-align: right; ddo-c" & _
    "har-set: 1; ddo-shrink-to-fit: true"
        Me.txt名前.Text = "名前"
        Me.txt名前.Top = 0.9874021!
        Me.txt名前.Width = 3.070866!
        '
        'txt注意書き
        '
        Me.txt注意書き.DataField = "注意書き"
        Me.txt注意書き.Height = 0.2!
        Me.txt注意書き.Left = 1.181102!
        Me.txt注意書き.MultiLine = False
        Me.txt注意書き.Name = "txt注意書き"
        Me.txt注意書き.ShrinkToFit = True
        Me.txt注意書き.Style = "font-family: ＭＳ Ｐ明朝; font-weight: bold; text-align: right; vertical-align: middle" & _
    "; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txt注意書き.Text = "注意書き"
        Me.txt注意書き.Top = 0.1149606!
        Me.txt注意書き.Width = 2.047244!
        '
        'txt備考
        '
        Me.txt備考.DataField = "備考"
        Me.txt備考.Height = 0.4724409!
        Me.txt備考.Left = 0.07874014!
        Me.txt備考.Name = "txt備考"
        Me.txt備考.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; ddo-char-set: 1"
        Me.txt備考.Text = "備考"
        Me.txt備考.Top = 1.102362!
        Me.txt備考.Width = 2.125984!
        '
        'txt枠表示
        '
        Me.txt枠表示.DataField = "枠表示"
        Me.txt枠表示.Height = 0.2!
        Me.txt枠表示.Left = 2.354331!
        Me.txt枠表示.Name = "txt枠表示"
        Me.txt枠表示.Style = "font-family: ＭＳ Ｐ明朝; ddo-char-set: 1"
        Me.txt枠表示.Text = "枠表示"
        Me.txt枠表示.Top = 1.417323!
        Me.txt枠表示.Visible = False
        Me.txt枠表示.Width = 0.5590553!
        '
        'KOKUYO_KPC_E1121
        '
        Me.MasterReport = False
        XmlDataSource1.FileURL = "C:\Users\yhagihara\AppData\Roaming\NKS\TackLabeler\RepData.xml"
        XmlDataSource1.RecordsetPattern = "//RepDataCollection"
        Me.DataSource = XmlDataSource1
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.7319444!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.8347222!
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait
        Me.PageSettings.PaperHeight = 11.69291!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PageSettings.PaperWidth = 8.268056!
        Me.PrintWidth = 6.80315!
        Me.Script = "Sub Detail_Format" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(9) & "Shape1.Visible = (txt枠表示.Text <> """")" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "End Sub" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
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
