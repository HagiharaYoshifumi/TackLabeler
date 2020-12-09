Module ModuleRPX
    Public ReadRPXData As New ArrayList
    Public RPX_ReportsLayout As New RPX_ReportsLayoutCollection
    Public RPX_Section As New RPX_SectionCollection
    Public RPX_FieldControl() As RPX_FieldControlCollection
    Public RPX_ShapeControl As New RPX_ShapeControlCollection
    Public RPX_PageSettings As New RPX_PageSettingsCollection
    Dim _XShift As Decimal = 11906 / 210.1
    Dim _YShift As Decimal = 16838 / 296.9
    Public Enum enumCalcType
        H
        V
    End Enum
    Public Function RPX2MM(ByVal value As String, CalcType As enumCalcType) As Decimal
        If CalcType = enumCalcType.H Then
            Return value / _XShift
        Else
            Return value / _YShift
        End If
    End Function
    Public Function MM2RPX(ByVal value As Decimal, CalcType As enumCalcType) As String
        If CalcType = enumCalcType.H Then
            Return value * _XShift
        Else
            Return value * _YShift
        End If
    End Function
    Private Sub InitialDimmention()
        ReadRPXData.Clear()
        RPX_Section = New RPX_SectionCollection
        ReDim RPX_FieldControl(7)
        For i As Integer = 0 To 7
            RPX_FieldControl(i) = New RPX_FieldControlCollection
        Next
        RPX_ShapeControl = New RPX_ShapeControlCollection
        RPX_PageSettings = New RPX_PageSettingsCollection
    End Sub
    Public Function ReadRPXFile(FileName As String) As Boolean
        Call InitialDimmention()
        Using sr As New System.IO.StreamReader(FileName, System.Text.Encoding.GetEncoding("shift_jis"))
            While sr.Peek() > -1
                ReadRPXData.Add(sr.ReadLine())
            End While
        End Using
        If ReadRPXData.Count > 0 Then
            For Each _Itm As String In ReadRPXData
                Select Case True
                    Case _Itm.Trim.StartsWith("<ActiveReportsLayout")
                        Call GetDataReportsLayout(_Itm)
                    Case _Itm.Trim.StartsWith("<Section Type=")
                        Call GetDataSection(_Itm)
                    Case _Itm.Trim.StartsWith("<Control Type=""AR.Shape""")
                        Call GetDataShape(_Itm)
                    Case _Itm.Trim.StartsWith("<Control Type=""AR.Field""")
                        Call GetDataFieldControl(_Itm)
                    Case _Itm.Trim.StartsWith("<Control Type=""AR.Label""")
                        Call GetDataLabelControl(_Itm)
                    Case _Itm.Trim.StartsWith("<PageSettings")
                        Call GetDataPageSettings(_Itm)
                End Select
            Next
        End If

        Return True
    End Function
    Public Function SaveRPXFile(FileName As String) As Boolean
        Dim _MF As String = AppFullPath("ReportMaster.txt")
        Dim _Master As String = ""
        Using sr As New System.IO.StreamReader(_MF, System.Text.Encoding.GetEncoding("shift_jis"))
            _Master = sr.ReadToEnd()
        End Using

        _Master = _Master.Replace("{RPX_ReportsLayout}", SetDataReportsLayout)
        _Master = _Master.Replace("{RPX_Section}", SetDataSection)
        _Master = _Master.Replace("{RPX_ShapeControl}", SetDataShape)
        _Master = _Master.Replace("{RPX_FieldControl0}", SetDataFieldControl(0))
        _Master = _Master.Replace("{RPX_FieldControl1}", SetDataFieldControl(1))
        _Master = _Master.Replace("{RPX_FieldControl2}", SetDataFieldControl(2))
        _Master = _Master.Replace("{RPX_FieldControl3}", SetDataFieldControl(3))
        _Master = _Master.Replace("{RPX_FieldControl4}", SetDataFieldControl(4))
        _Master = _Master.Replace("{RPX_FieldControl5}", SetDataFieldControl(5))
        _Master = _Master.Replace("{RPX_FieldControl6}", SetDataFieldControl(6))
        _Master = _Master.Replace("{RPX_FieldControl7}", SetDataFieldControl(7))
        _Master = _Master.Replace("{RPX_PageSettings}", SetDataPageSettings)

        Using sw As New System.IO.StreamWriter(FileName, False, System.Text.Encoding.GetEncoding("utf-8"))
            sw.Write(_Master)
        End Using

        Return True
    End Function
#Region "GetRPX"
    Private Sub GetDataReportsLayout(Value As String)
        Dim UUU() As String = Value.Split(" ")
        For Each _T As String In UUU
            If Not _T.Trim = "" AndAlso _T.IndexOf("=") > -1 Then
                Dim _D() As String = _T.Replace("""", "").Split("=")
                Select Case _D(0)
                    Case "Version" : RPX_ReportsLayout.Version = _D(1)
                    Case "PrintWidth" : RPX_ReportsLayout.PrintWidth = RPX2MM(_D(1), enumCalcType.H)
                    Case "DocumentName" : RPX_ReportsLayout.DocumentName = _D(1)
                    Case "ScriptLang" : RPX_ReportsLayout.ScriptLang = _D(1)
                    Case "UserData" : RPX_ReportsLayout.UserData = _D(1)
                    Case "MasterReport" : RPX_ReportsLayout.MasterReport = _D(1)
                End Select
            End If
        Next
    End Sub

    Private Sub GetDataSection(Value As String)
        Dim UUU() As String = Value.Split(" ")
        For Each _T As String In UUU
            If Not _T.Trim = "" AndAlso _T.IndexOf("=") > -1 Then
                Dim _D() As String = _T.Replace("""", "").Split("=")
                Select Case _D(0)
                    Case "Name" : RPX_Section.Name = _D(1)
                    Case "Height" : RPX_Section.Height = RPX2MM(_D(1), enumCalcType.V)
                    Case "ColumnCount" : RPX_Section.ColumnCount = _D(1)
                    Case "ColumnDirection" : RPX_Section.ColumnDirection = _D(1)
                    Case "ColumnSpacing" : RPX_Section.ColumnSpacing = RPX2MM(_D(1), enumCalcType.H)
                    Case "BackColor" : RPX_Section.BackColor = _D(1)
                    Case "KeepTogether" : RPX_Section.KeepTogether = _D(1).Replace(">", "")
                End Select
            End If
        Next
    End Sub
    Private Sub GetDataShape(Value As String)
        Dim UUU() As String = Value.Split(" ")
        For Each _T As String In UUU
            If Not _T.Trim = "" AndAlso _T.IndexOf("=") > -1 Then
                Dim _D() As String = _T.Replace("""", "").Split("=")
                Select Case _D(0)
                    Case "Name" : RPX_ShapeControl.Name = _D(1)
                    Case "Left" : RPX_ShapeControl.Left = RPX2MM(_D(1), enumCalcType.H)
                    Case "Top" : RPX_ShapeControl.Top = RPX2MM(_D(1), enumCalcType.V)
                    Case "Width" : RPX_ShapeControl.Width = RPX2MM(_D(1), enumCalcType.H)
                    Case "Height" : RPX_ShapeControl.Height = RPX2MM(_D(1), enumCalcType.V)
                    Case "BackColor" : RPX_ShapeControl.BackColor = _D(1)
                    Case "LineColor" : RPX_ShapeControl.LineColor = _D(1)
                    Case "LineStyle" : RPX_ShapeControl.LineStyle = _D(1)
                    Case "RoundingRadius" : RPX_ShapeControl.RoundingRadius = _D(1)
                End Select
            End If
        Next
    End Sub
    Private Sub GetDataFieldControl(Value As String)
        Dim _Step1 As String = Replace(Value.Trim, """", "'")
        Dim _Step2 As String = Replace(_Step1, " ", "|")
        Dim _Step3 As String = Replace(_Step2, "'|", "' ")

        Dim UUU() As String = _Step3.Split(" ")
        Dim _FD As New RPX_FieldControlCollection

        For Each _T As String In UUU
            If Not _T.Trim = "" AndAlso _T.IndexOf("=") > -1 Then

                Dim _D() As String = _T.Replace("'", "").Split("=")
                Select Case _D(0)
                    Case "Name" : _FD.Name = _D(1)
                    Case "DataField" : _FD.DataField = _D(1)
                    Case "Visible" : _FD.Use = _D(1)
                    Case "Left" : _FD.Left = RPX2MM(_D(1), enumCalcType.H)
                    Case "Top" : _FD.Top = RPX2MM(_D(1), enumCalcType.V)
                    Case "Width" : _FD.Width = RPX2MM(_D(1), enumCalcType.H)
                    Case "Height" : _FD.Height = RPX2MM(_D(1), enumCalcType.V)
                    Case "Text" : _FD.Text = _D(1)
                    Case "Style" : _FD.Style = _D(1).Replace("|", " ")
                End Select
            End If
        Next
        Select Case _FD.DataField
            Case "郵便番号" : RPX_FieldControl(0) = _FD
            Case "住所" : RPX_FieldControl(1) = _FD
            Case "会社名" : RPX_FieldControl(2) = _FD
            Case "部署名" : RPX_FieldControl(3) = _FD
            Case "名前" : RPX_FieldControl(4) = _FD
            Case "注意書き" : RPX_FieldControl(5) = _FD
            Case "備考" : RPX_FieldControl(6) = _FD
            Case "枠表示" : RPX_FieldControl(7) = _FD
        End Select
    End Sub
    Private Sub GetDataLabelControl(Value As String)
        Dim _Step1 As String = Replace(Value.Trim, """", "'")
        Dim _Step2 As String = Replace(_Step1, " ", "|")
        Dim _Step3 As String = Replace(_Step2, "'|", "' ")

        Dim UUU() As String = _Step3.Split(" ")
        Dim _FD As New RPX_FieldControlCollection

        For Each _T As String In UUU
            If Not _T.Trim = "" AndAlso _T.IndexOf("=") > -1 Then

                Dim _D() As String = _T.Replace("'", "").Split("=")
                Select Case _D(0)
                    Case "Name" : _FD.Name = _D(1)
                    Case "DataField" : _FD.DataField = _D(1)
                    Case "Visible" : _FD.Use = _D(1)
                    Case "Left" : _FD.Left = RPX2MM(_D(1), enumCalcType.H)
                    Case "Top" : _FD.Top = RPX2MM(_D(1), enumCalcType.V)
                    Case "Width" : _FD.Width = RPX2MM(_D(1), enumCalcType.H)
                    Case "Height" : _FD.Height = RPX2MM(_D(1), enumCalcType.V)
                    Case "Text" : _FD.Text = _D(1)
                    Case "Style" : _FD.Style = _D(1).Replace("|", " ")
                End Select
            End If
        Next
        Select Case _FD.DataField
            Case "郵便番号" : RPX_FieldControl(0) = _FD
            Case "住所" : RPX_FieldControl(1) = _FD
            Case "会社名" : RPX_FieldControl(2) = _FD
            Case "部署名" : RPX_FieldControl(3) = _FD
            Case "名前" : RPX_FieldControl(4) = _FD
            Case "注意書き" : RPX_FieldControl(5) = _FD
            Case "備考" : RPX_FieldControl(6) = _FD
            Case "枠表示" : RPX_FieldControl(7) = _FD
        End Select
    End Sub
    Private Sub GetDataPageSettings(Value As String)
        Dim UUU() As String = Value.Split(" ")
        For Each _T As String In UUU
            If Not _T.Trim = "" AndAlso _T.IndexOf("=") > -1 Then
                Dim _D() As String = _T.Replace("""", "").Split("=")
                Select Case _D(0)
                    Case "LeftMargin" : RPX_PageSettings.LeftMargin = RPX2MM(_D(1), enumCalcType.H)
                    Case "RightMargin" : RPX_PageSettings.RightMargin = RPX2MM(_D(1), enumCalcType.H)
                    Case "TopMargin" : RPX_PageSettings.TopMargin = RPX2MM(_D(1), enumCalcType.V)
                    Case "BottomMargin" : RPX_PageSettings.BottomMargin = RPX2MM(_D(1), enumCalcType.V)
                    Case "PaperSize" : RPX_PageSettings.PaperSize = _D(1)
                    Case "PaperWidth" : RPX_PageSettings.PaperWidth = RPX2MM(_D(1), enumCalcType.H)
                    Case "PaperHeight" : RPX_PageSettings.PaperHeight = RPX2MM(_D(1), enumCalcType.V)
                    Case "PaperName" : RPX_PageSettings.PaperName = _D(1)
                    Case "Orientation" : RPX_PageSettings.Orientation = _D(1)
                End Select
            End If
        Next
    End Sub
#End Region
#Region "SetRPX"
    Private Function SetDataReportsLayout() As String
        Dim _T As String = "<ActiveReportsLayout Version='{Version}' PrintWidth='{PrintWidth}' DocumentName='{DocumentName}' ScriptLang='{ScriptLang}' UserData='{UserData}' MasterReport='{MasterReport}'>"
        _T = _T.Replace("{Version}", RPX_ReportsLayout.Version)
        _T = _T.Replace("{PrintWidth}", MM2RPX(RPX_ReportsLayout.PrintWidth, enumCalcType.H))
        _T = _T.Replace("{DocumentName}", RPX_ReportsLayout.DocumentName)
        _T = _T.Replace("{ScriptLang}", RPX_ReportsLayout.ScriptLang)
        _T = _T.Replace("{UserData}", RPX_ReportsLayout.UserData)
        _T = _T.Replace("{MasterReport}", RPX_ReportsLayout.MasterReport)

        Return _T.Replace("'", """")
    End Function

    Private Function SetDataSection() As String
        Dim _T As String = "<Section Type='Detail' Name='{Name}' Height='{Height}' ColumnCount='{ColumnCount}' ColumnDirection='{ColumnDirection}' ColumnSpacing='{ColumnSpacing}' BackColor='{BackColor}' KeepTogether='{KeepTogether}'>"
        _T = _T.Replace("{Name}", RPX_Section.Name)
        _T = _T.Replace("{Height}", MM2RPX(RPX_Section.Height, enumCalcType.V))
        _T = _T.Replace("{ColumnCount}", RPX_Section.ColumnCount)
        _T = _T.Replace("{ColumnDirection}", RPX_Section.ColumnDirection)
        _T = _T.Replace("{ColumnSpacing}", MM2RPX(RPX_Section.ColumnSpacing, enumCalcType.H))
        _T = _T.Replace("{BackColor}", RPX_Section.BackColor)
        _T = _T.Replace("{KeepTogether}", RPX_Section.KeepTogether)

        Return _T.Replace("'", """")
    End Function
    Private Function SetDataShape() As String
        Dim _T As String = "<Control Type='AR.Shape' Name='{Name}' Left='{Left}' Top='{Top}' Width='{Width}' Height='{Height}' BackColor='{BackColor}' LineColor='{LineColor}' LineStyle='{LineStyle}' RoundingRadius='{RoundingRadius}' />"
        _T = _T.Replace("{Name}", RPX_ShapeControl.Name)
        _T = _T.Replace("{Left}", MM2RPX(RPX_ShapeControl.Left, enumCalcType.H))
        _T = _T.Replace("{Top}", MM2RPX(RPX_ShapeControl.Top, enumCalcType.V))
        _T = _T.Replace("{Width}", MM2RPX(RPX_ShapeControl.Width, enumCalcType.H))
        _T = _T.Replace("{Height}", MM2RPX(RPX_ShapeControl.Height, enumCalcType.V))
        _T = _T.Replace("{BackColor}", RPX_ShapeControl.BackColor)
        _T = _T.Replace("{LineColor}", RPX_ShapeControl.LineColor)
        _T = _T.Replace("{LineStyle}", RPX_ShapeControl.LineStyle)
        _T = _T.Replace("{RoundingRadius}", RPX_ShapeControl.RoundingRadius)

        Return _T.Replace("'", """")
    End Function
    Private Function SetDataFieldControl(index As Integer) As String
        Dim _T As String = "<Control Type='AR.Field' Name='{Name}' DataField='{DataField}' Visible='{Use}' Left='{Left}' Top='{Top}' Width='{Width}' Height='{Height}' Text='{Text}' Style='{Style}' />"
        _T = _T.Replace("{Name}", RPX_FieldControl(index).Name)
        _T = _T.Replace("{DataField}", RPX_FieldControl(index).DataField)
        _T = _T.Replace("{Use}", IIf(RPX_FieldControl(index).Use, "1", "0"))
        _T = _T.Replace("{Left}", MM2RPX(RPX_FieldControl(index).Left, enumCalcType.H))
        _T = _T.Replace("{Top}", MM2RPX(RPX_FieldControl(index).Top, enumCalcType.V))
        _T = _T.Replace("{Width}", MM2RPX(RPX_FieldControl(index).Width, enumCalcType.H))
        _T = _T.Replace("{Height}", MM2RPX(RPX_FieldControl(index).Height, enumCalcType.V))
        _T = _T.Replace("{Text}", RPX_FieldControl(index).Text)
        _T = _T.Replace("{Style}", RPX_FieldControl(index).Style)

        Return _T.Replace("'", """")
    End Function
    Private Function SetDataPageSettings() As String
        Dim _T As String = "<PageSettings LeftMargin='{LeftMargin}' RightMargin='{RightMargin}' TopMargin='{TopMargin}' BottomMargin='{BottomMargin}' PaperSize='{PaperSize}' PaperWidth='{PaperWidth}' PaperHeight='{PaperHeight}' PaperName='{PaperName}' Orientation='{Orientation}' />"
        _T = _T.Replace("{LeftMargin}", Int(MM2RPX(RPX_PageSettings.LeftMargin, enumCalcType.H)))
        _T = _T.Replace("{RightMargin}", Int(MM2RPX(RPX_PageSettings.RightMargin, enumCalcType.H)))
        _T = _T.Replace("{TopMargin}", Int(MM2RPX(RPX_PageSettings.TopMargin, enumCalcType.V)))
        _T = _T.Replace("{BottomMargin}", Int(MM2RPX(RPX_PageSettings.BottomMargin, enumCalcType.V)))
        _T = _T.Replace("{PaperSize}", RPX_PageSettings.PaperSize)
        _T = _T.Replace("{PaperWidth}", Int(MM2RPX(RPX_PageSettings.PaperWidth, enumCalcType.H)))
        _T = _T.Replace("{PaperHeight}", Int(MM2RPX(RPX_PageSettings.PaperHeight, enumCalcType.V)))
        _T = _T.Replace("{PaperName}", RPX_PageSettings.PaperName)
        _T = _T.Replace("{Orientation}", RPX_PageSettings.Orientation)

        Return _T.Replace("'", """")
    End Function
#End Region

End Module
Public Class RPX_ReportsLayoutCollection
    '<ActiveReportsLayout Version="3.2" PrintWidth="9796.536" DocumentName="ActiveReports Document" ScriptLang="VB.NET" UserData="" MasterReport="0">
    Public Version As String
    Public PrintWidth As Decimal
    Public DocumentName As String
    Public ScriptLang As String
    Public UserData As String
    Public MasterReport As String
    Sub New()
        Me.Version = "3.2"
        Me.PrintWidth = 0
        Me.DocumentName = ""
        Me.ScriptLang = "VB.NET"
        Me.UserData = ""
        Me.MasterReport = "0"
    End Sub
End Class
Public Class RPX_SectionCollection
    '    <Section Type="Detail" Name="Detail" Height="2420.787" ColumnCount="2" ColumnDirection="1" ColumnSpacing="566" BackColor="16777215" KeepTogether="1">
    Public Name As String
    Public Height As Decimal
    Public ColumnCount As Decimal
    Public ColumnDirection As Decimal
    Public ColumnSpacing As Decimal
    Public BackColor As String
    Public KeepTogether As String
    Sub New()
        Me.Name = ""
        Me.Height = 0
        Me.ColumnCount = 0
        Me.ColumnDirection = 0
        Me.ColumnSpacing = 0
        Me.BackColor = "16777215"
        Me.KeepTogether = "1"
    End Sub
End Class
Public Class RPX_FieldControlCollection
    '<Control Type="AR.Field" Name="txt郵便番号1" DataField="郵便番号" Left="113.3858" Top="113.3858" Width="1360.63" Height="288" Text="txt郵便番号1" Style="font-family: ＭＳ Ｐ明朝; vertical-align: middle; ddo-char-set: 1; ddo-font-vertical: none" />
    Public Use As Boolean
    Public Type As String
    Public Name As String
    Public DataField As String
    Public Left As Decimal
    Public Top As Decimal
    Public Width As Decimal
    Public Height As Decimal
    Public Text As String
    Public Style As String
    Sub New()
        Me.Use = True
        Me.Type = "AR.Field"
        Me.Name = ""
        Me.DataField = ""
        Me.Left = 0
        Me.Top = 0
        Me.Width = 0
        Me.Height = 0
        Me.Text = "aaaa"
        Me.Style = "font-family: ＭＳ Ｐ明朝; ddo-char-set: 1; ddo-shrink-to-fit: true"
    End Sub
End Class
Public Class RPX_ShapeControlCollection
    '<Control Type="AR.Shape" Name="Shape1" Left="0" Top="0" Width="4898.268" Height="2398.11" BackColor="16777215" LineColor="8421504" LineStyle="2" RoundingRadius="9.999999" />
    Public Type As String
    Public Name As String
    Public Left As Decimal
    Public Top As Decimal
    Public Width As Decimal
    Public Height As Decimal
    Public BackColor As String
    Public LineColor As String
    Public LineStyle As String
    Public RoundingRadius As String
    Sub New()
        Me.Type = "AR.Shape"
        Me.Name = "Shape1"
        Me.Left = 0
        Me.Top = 0
        Me.Width = 0
        Me.Height = 0
        Me.BackColor = "16777215"
        Me.LineColor = "8421504"
        Me.LineStyle = "2"
        Me.RoundingRadius = "9.999999"
    End Sub
End Class
Public Class RPX_PageSettingsCollection
    '<PageSettings LeftMargin="1054" RightMargin="0" TopMargin="1202" BottomMargin="0" PaperSize="9" PaperWidth="11906" PaperHeight="16838" PaperName="" Orientation="1" />
    Public LeftMargin As Decimal
    Public RightMargin As Decimal
    Public TopMargin As Decimal
    Public BottomMargin As Decimal
    Public PaperSize As Decimal
    Public PaperWidth As Decimal
    Public PaperHeight As Decimal
    Public PaperName As String
    Public Orientation As Decimal
    Sub New()
        Me.LeftMargin = 0
        Me.RightMargin = 0
        Me.TopMargin = 0
        Me.BottomMargin = 0
        Me.PaperSize = 0
        Me.PaperWidth = 0
        Me.PaperHeight = 0
        Me.PaperName = ""
        Me.Orientation = 0
    End Sub
End Class
