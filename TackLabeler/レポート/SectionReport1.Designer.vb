<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SectionReport1 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SectionReport1))
        Dim XmlDataSource1 As GrapeCity.ActiveReports.Data.XMLDataSource = New GrapeCity.ActiveReports.Data.XMLDataSource()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnCount = 2
        Me.Detail.ColumnDirection = GrapeCity.ActiveReports.SectionReportModel.ColumnDirection.AcrossDown
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.TextBox1, Me.TextBox2})
        Me.Detail.Height = 2.562!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 0.7500001!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Text = "TextBox1"
        Me.TextBox1.Top = 0.687!
        Me.TextBox1.Width = 1.0!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.2!
        Me.TextBox2.Left = 0.7500001!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "background-color: White"
        Me.TextBox2.Text = "TextBox2"
        Me.TextBox2.Top = 1.312!
        Me.TextBox2.Width = 1.0!
        '
        'SectionReport1
        '
        Me.MasterReport = False
        XmlDataSource1.FileURL = "C:\Users\yhagihara\AppData\Roaming\NKS\TackLabeler\RepData.xml"
        XmlDataSource1.RecordsetPattern = "//ClassPreviewFieldCollection"
        Me.DataSource = XmlDataSource1
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.8347222!
        Me.PageSettings.Margins.Left = 0.7319444!
        Me.PageSettings.Margins.Right = 0.7319444!
        Me.PageSettings.Margins.Top = 0.8347222!
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait
        Me.PageSettings.PaperHeight = 11.69291!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PageSettings.PaperWidth = 8.263889!
        Me.PrintWidth = 6.80019!
        Me.Script = "Sub Detail_Format" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(9) & "  Shape1.Visible = (TxtFieldShape.Text <> """")" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "End Sub" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
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
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents Detail As GrapeCity.ActiveReports.SectionReportModel.Detail
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
