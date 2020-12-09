<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class KOKUYO_KPC_E1121_名前 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KOKUYO_KPC_E1121_名前))
        Dim XmlDataSource1 As GrapeCity.ActiveReports.Data.XMLDataSource = New GrapeCity.ActiveReports.Data.XMLDataSource()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.txt住所_xFF11_1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt名前1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt注意書き1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt備考1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt枠表示1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        CType(Me.txt住所_xFF11_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt名前1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt注意書き1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt備考1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt枠表示1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnCount = 2
        Me.Detail.ColumnDirection = GrapeCity.ActiveReports.SectionReportModel.ColumnDirection.AcrossDown
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape1, Me.txt住所_xFF11_1, Me.txt名前1, Me.txt注意書き1, Me.txt備考1, Me.txt枠表示1, Me.Label1})
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
        'txt住所_xFF11_1
        '
        Me.txt住所_xFF11_1.DataField = "住所_xFF11_"
        Me.txt住所_xFF11_1.Height = 0.2362205!
        Me.txt住所_xFF11_1.Left = 0.07874014!
        Me.txt住所_xFF11_1.Name = "txt住所_xFF11_1"
        Me.txt住所_xFF11_1.Style = "background-color: #400000; color: #FFC0C0; font-family: ＭＳ Ｐ明朝; font-size: 12pt; " & _
    "ddo-char-set: 1"
        Me.txt住所_xFF11_1.Text = "txt住所_xFF11_1"
        Me.txt住所_xFF11_1.Top = 0.3149607!
        Me.txt住所_xFF11_1.Width = 3.149606!
        '
        'txt名前1
        '
        Me.txt名前1.DataField = "名前"
        Me.txt名前1.Height = 0.3696851!
        Me.txt名前1.Left = 0.1574803!
        Me.txt名前1.MultiLine = False
        Me.txt名前1.Name = "txt名前1"
        Me.txt名前1.ShrinkToFit = True
        Me.txt名前1.Style = "font-family: ＭＳ Ｐ明朝; font-size: 16pt; font-weight: bold; text-align: right; ddo-c" & _
    "har-set: 1; ddo-shrink-to-fit: true"
        Me.txt名前1.Text = "txt名前1"
        Me.txt名前1.Top = 0.653937!
        Me.txt名前1.Width = 3.070866!
        '
        'txt注意書き1
        '
        Me.txt注意書き1.CanShrink = True
        Me.txt注意書き1.DataField = "注意書き"
        Me.txt注意書き1.Height = 0.2!
        Me.txt注意書き1.Left = 0.1574804!
        Me.txt注意書き1.Name = "txt注意書き1"
        Me.txt注意書き1.ShrinkToFit = True
        Me.txt注意書き1.Style = "font-family: ＭＳ Ｐ明朝; font-weight: bold; text-align: right; vertical-align: middle" & _
    "; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txt注意書き1.Text = "txt注意書き1"
        Me.txt注意書き1.Top = 0.1149606!
        Me.txt注意書き1.Width = 3.070866!
        '
        'txt備考1
        '
        Me.txt備考1.DataField = "備考"
        Me.txt備考1.Height = 0.2362208!
        Me.txt備考1.Left = 0.07874014!
        Me.txt備考1.Name = "txt備考1"
        Me.txt備考1.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; ddo-char-set: 1"
        Me.txt備考1.Text = "txt備考1"
        Me.txt備考1.Top = 1.102362!
        Me.txt備考1.Width = 3.149606!
        '
        'txt枠表示1
        '
        Me.txt枠表示1.DataField = "枠表示"
        Me.txt枠表示1.Height = 0.2!
        Me.txt枠表示1.Left = 2.834646!
        Me.txt枠表示1.Name = "txt枠表示1"
        Me.txt枠表示1.Style = "font-family: ＭＳ Ｐ明朝; ddo-char-set: 1"
        Me.txt枠表示1.Text = "txt枠表示1"
        Me.txt枠表示1.Top = 0.5511811!
        Me.txt枠表示1.Visible = False
        Me.txt枠表示1.Width = 0.5590553!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.6299213!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = ""
        Me.Label1.Text = "Label1"
        Me.Label1.Top = 1.417323!
        Me.Label1.Width = 1.0!
        '
        'KOKUYO_KPC_E1121_名前
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
        Me.Script = "Sub Detail_Format" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(9) & "Shape1.Visible = (txt枠表示1.Text <> """")" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "End Sub" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
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
        CType(Me.txt住所_xFF11_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt名前1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt注意書き1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt備考1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt枠表示1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents Detail As GrapeCity.ActiveReports.SectionReportModel.Detail
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents txt住所_xFF11_1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt名前1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt注意書き1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt備考1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt枠表示1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
End Class 
