Module ModulePaperData
    ''' <summary>
    ''' ユーザ作成用紙ファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public PaperArrayFile As String = AppFullPath("LabelUserData.xml")
    ''' <summary>
    ''' 用紙情報内部ジェネリックコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public PaperArray As New List(Of ClassPaperCollection)

    ''' <summary>
    ''' ＲＰＸファイル生成用マスターファイル
    ''' </summary>
    ''' <remarks></remarks>
    Public ReportFileMaster As String = AppFullPath("ReportMaster.txt")
    ''' <summary>
    ''' 生成ＲＰＸファイル名
    ''' </summary>
    ''' <remarks></remarks>
    '''Public ReportRPXFile As String = AppFullPath("RepTackFile.rpx")
    Public ReportRPXFile As String = NFuncSystemFullPath(Environment.SpecialFolder.CommonApplicationData, "RepTackFile.rpx")
    Dim _XShift As Decimal = 11906 / 210.1
    Dim _YShift As Decimal = 16838 / 296.9
#Region "Create RPX File"
    ''' <summary>
    ''' ＲＰＸファイル（ActiveReportフォーマットファイル）の作成
    ''' </summary>
    ''' <param name="Dat">出力用紙情報コレクション</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateReport(Dat As ClassPaperCollection) As Boolean
        Dim _Master As String = ""
        Using sr As New System.IO.StreamReader(ReportFileMaster, System.Text.Encoding.GetEncoding("shift_jis"))
            _Master = sr.ReadToEnd()
        End Using

        _Master = _Master.Replace("{RPX_ReportsLayout}", CreateLayOut(Dat))
        _Master = _Master.Replace("{RPX_Section}", CreateSection(Dat))
        _Master = _Master.Replace("{RPX_Field}", CreateField(Dat))
        _Master = _Master.Replace("{RPX_PageSettings}", CreatePageSetting(Dat))

        Using sw As New System.IO.StreamWriter(ReportRPXFile, False, System.Text.Encoding.GetEncoding("utf-8"))
            sw.Write(_Master)
        End Using
        Return True
    End Function
    ''' <summary>
    ''' レイアウト部分の生成
    ''' </summary>
    ''' <param name="Dat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateLayOut(Dat As ClassPaperCollection) As String
        Dim _T As String = "<ActiveReportsLayout Version='{Version}' PrintWidth='{PrintWidth}' DocumentName='{DocumentName}' ScriptLang='{ScriptLang}' UserData='{UserData}' MasterReport='{MasterReport}'>"

        _T = _T.Replace("{Version}", Dat.Layout.Version)
        _T = _T.Replace("{PrintWidth}", MM2RPX(Dat.Layout.PrintWidth, enumCalcType.H))
        _T = _T.Replace("{DocumentName}", Dat.Layout.DocumentName)
        _T = _T.Replace("{ScriptLang}", Dat.Layout.ScriptLang)
        _T = _T.Replace("{UserData}", Dat.Layout.UserData)
        _T = _T.Replace("{MasterReport}", Dat.Layout.MasterReport)
        _T = _T.Replace("{Version}", Dat.Layout.Version)
        _T = _T.Replace("{Version}", Dat.Layout.Version)
        Return _T.Replace("'", """")

    End Function
    ''' <summary>
    ''' セクション部分の生成
    ''' </summary>
    ''' <param name="Dat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateSection(Dat As ClassPaperCollection) As String
        Dim _T As String = " <Section Type='{Type}' Name='{Name}' Height='{Height}' ColumnCount='{ColumnCount}' ColumnDirection='{ColumnDirection}' ColumnSpacing='{ColumnSpacing}' BackColor='{BackColor}' KeepTogether='{KeepTogether}'>"

        _T = _T.Replace("{Type}", Dat.Section.Type)
        _T = _T.Replace("{Name}", Dat.Section.Name)
        _T = _T.Replace("{Height}", MM2RPX(Dat.Section.Height + Dat.Section.RowSpacing, enumCalcType.V))
        _T = _T.Replace("{ColumnCount}", Dat.Section.ColumnCount)
        _T = _T.Replace("{ColumnDirection}", Dat.Section.ColumnDirection)
        _T = _T.Replace("{ColumnSpacing}", MM2RPX(Dat.Section.ColumnSpacing, enumCalcType.H))
        _T = _T.Replace("{BackColor}", Dat.Section.BackColor)
        _T = _T.Replace("{KeepTogether}", Dat.Section.KeepTogether)
        Return _T.Replace("'", """")
    End Function
    ''' <summary>
    ''' フィールド部分の生成
    ''' </summary>
    ''' <param name="Dat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateField(Dat As ClassPaperCollection) As String
        Dim _R As String = ""
        For Each DD As ClassFieldCollection In Dat.Section.FieldData
            Dim _T As String = ""

            Select Case DD.FieldType
                Case enumFieldType.Shape
                    _T = "<Control Type='AR.Shape' Name='{Name}' Visible='{Visible}' Left='{Left}' Top='{Top}' Width='{Width}' Height='{Height}' BackColor='{BackColor}' LineColor='{LineColor}' LineStyle='{LineStyle}' RoundingRadius='{RoundingRadius}'/>"
                    ' <Control Type="AR.Label" Name="Label1" Left="907.0867" Top="2040.945" Width="1440" Height="288" Caption="Label1" />
                    _T = _T.Replace("{Name}", DD.Name)
                    _T = _T.Replace("{DataField}", DD.DataField)
                    _T = _T.Replace("{Visible}", IIf(DD.Visible, "1", "0"))
                    _T = _T.Replace("{Left}", MM2RPX(DD.Left, enumCalcType.H))
                    _T = _T.Replace("{Top}", MM2RPX(DD.Top, enumCalcType.V))
                    _T = _T.Replace("{Width}", MM2RPX(DD.Width, enumCalcType.H))
                    _T = _T.Replace("{Height}", MM2RPX(DD.Height, enumCalcType.V))
                    _T = _T.Replace("{Multiline}", IIf(DD.MultiLine, "1", "0"))
                    _T = _T.Replace("{CanShrink}", IIf(DD.CanShrink, "1", "0"))
                    _T = _T.Replace("{BackColor}", DD.BackColor)
                    _T = _T.Replace("{LineColor}", DD.LineColor)
                    _T = _T.Replace("{LineStyle}", DD.LineStyle)
                    _T = _T.Replace("{RoundingRadius}", DD.RoundingRadius)
                    _T = _T.Replace("{Style}", CreateStyle(DD))
                    _R = _R & _T & vbCrLf
                Case enumFieldType.Field
                    _T = "<Control Type='AR.Label' Name='{Name}' DataField='{DataField}' Visible='{Visible}' Angle='{Angle}' Left='{Left}' Top='{Top}' Width='{Width}' Height='{Height}' Text='STRING' Multiline='{Multiline}' CanShrink='{CanShrink}' Style='{Style}' BorderLeftStyle='{BorderLeftStyle}' BorderTopStyle='{BorderTopStyle}' BorderRightStyle='{BorderRightStyle}' BorderBottomStyle='{BorderRightStyle}' BorderLeftColor='8421504' />"
                    ' <Control Type="AR.Label" Name="Label1" Left="907.0867" Top="2040.945" Width="1440" Height="288" Caption="Label1" />
                    _T = _T.Replace("{Name}", DD.Name)
                    _T = _T.Replace("{DataField}", DD.DataField)
                    _T = _T.Replace("{Visible}", IIf(DD.Visible, "1", "0"))

                    _T = _T.Replace("{Angle}", DD.Angle * 10)

                    _T = _T.Replace("{Left}", MM2RPX(DD.Left, enumCalcType.H))
                    _T = _T.Replace("{Top}", MM2RPX(DD.Top, enumCalcType.V))
                    _T = _T.Replace("{Width}", MM2RPX(DD.Width, enumCalcType.H))
                    _T = _T.Replace("{Height}", MM2RPX(DD.Height, enumCalcType.V))
                    _T = _T.Replace("{Multiline}", IIf(DD.MultiLine, "1", "0"))
                    _T = _T.Replace("{CanShrink}", IIf(DD.CanShrink, "1", "0"))
                    _T = _T.Replace("{BackColor}", DD.BackColor)
                    _T = _T.Replace("{LineColor}", DD.LineColor)
                    _T = _T.Replace("{LineStyle}", DD.LineStyle)
                    _T = _T.Replace("{RoundingRadius}", DD.RoundingRadius)
                    _T = _T.Replace("{Style}", CreateStyle(DD))

                    If FrmMain.ChkPreviewFrame2.Checked Then
                        _T = _T.Replace("{BorderLeftStyle}", "3")
                        _T = _T.Replace("{BorderTopStyle}", "3")
                        _T = _T.Replace("{BorderRightStyle}", "3")
                        _T = _T.Replace("{BorderRightStyle}", "3")
                    Else
                        _T = _T.Replace("{BorderLeftStyle}", "0")
                        _T = _T.Replace("{BorderTopStyle}", "0")
                        _T = _T.Replace("{BorderRightStyle}", "0")
                        _T = _T.Replace("{BorderRightStyle}", "0")
                    End If
                    _R = _R & _T & vbCrLf
                Case enumFieldType.Label
                    _T = "<Control Type='AR.Label' Name='{Name}' Visible='{Visible}' Left='{Left}' Top='{Top}' Width='{Width}' Height='{Height}' Angle='{Angle}' Caption='{Caption}' Text='STRING' Multiline='{Multiline}' CanShrink='{CanShrink}' Style='{Style}' />"
                    ' <Control Type="AR.Label" Name="Label2" Left="540" Top="540" Width="1440" Height="288" Caption="SSS" Style="font-family: ＭＳ ゴシック; font-size: 9.75pt; font-style: italic; font-weight: bold; text-align: right" />
                    _T = _T.Replace("{Name}", DD.Name)
                    _T = _T.Replace("{Visible}", IIf(DD.Visible, "1", "0"))
                    _T = _T.Replace("{Left}", MM2RPX(DD.Left, enumCalcType.H))
                    _T = _T.Replace("{Top}", MM2RPX(DD.Top, enumCalcType.V))
                    _T = _T.Replace("{Width}", MM2RPX(DD.Width, enumCalcType.H))
                    _T = _T.Replace("{Height}", MM2RPX(DD.Height, enumCalcType.V))
                    _T = _T.Replace("{Caption}", DD.LabelText)
                    _T = _T.Replace("{Angle}", DD.Angle * 10)
                    _T = _T.Replace("{Multiline}", IIf(DD.MultiLine, "1", "0"))
                    _T = _T.Replace("{CanShrink}", IIf(DD.CanShrink, "1", "0"))
                    _T = _T.Replace("{BackColor}", DD.BackColor)
                    _T = _T.Replace("{LineColor}", DD.LineColor)
                    _T = _T.Replace("{LineStyle}", DD.LineStyle)
                    _T = _T.Replace("{RoundingRadius}", DD.RoundingRadius)
                    _T = _T.Replace("{Style}", CreateStyle(DD))
                    _R = _R & _T & vbCrLf
                Case enumFieldType.Line
                    _T = "<Control Type='AR.Line' Name='{Name}' Visible='{Visible}' X1='{Left}' Y1='{Top}' X2='{Width}' Y2='{Height}' LineStyle='{LineStyle}' LineWeight='{LineWeight}' />"
                    ' <Control Type="AR.Line" Name="Line1" X1="720" Y1="1980" X2="2160" Y2="1980" LineWeight="5" />
                    _T = _T.Replace("{Name}", DD.Name)
                    _T = _T.Replace("{Left}", MM2RPX(DD.Left, enumCalcType.H))
                    _T = _T.Replace("{Top}", MM2RPX(DD.Top, enumCalcType.V))
                    '_T = _T.Replace("{Width}", MM2RPX(DD.Width, enumCalcType.H))
                    '_T = _T.Replace("{Height}", MM2RPX(DD.Height, enumCalcType.V))
                    _T = _T.Replace("{Width}", MM2RPX(DD.Width + DD.Left, enumCalcType.H))
                    _T = _T.Replace("{Height}", MM2RPX(DD.Height + DD.Top, enumCalcType.V))
                    _T = _T.Replace("{Visible}", IIf(DD.Visible, "1", "0"))
                    _T = _T.Replace("{LineWeight}", DD.LineWidth)
                    _T = _T.Replace("{LineStyle}", DD.LineStyle + 1)
                    _R = _R & _T & vbCrLf
                Case enumFieldType.Box
                    '<Control Type="AR.Shape" Name="Shape1" Visible="1" Left="0" Top="0" Width="100" Height="100" BackColor="16777215" LineColor="8421504" LineStyle="2" RoundingRadius="9.999999"/>
                    _T = "<Control Type='AR.Shape' Name='{Name}' Visible='{Visible}' Left='{Left}' Top='{Top}' Width='{Width}' Height='{Height}' BackColor='{BackColor}' LineColor='{LineColor}' LineStyle='{LineStyle}' RoundingRadius='{RoundingRadius}' LineWeight='{LineWeight}'/>"

                    _T = _T.Replace("{Name}", DD.Name)
                    _T = _T.Replace("{Visible}", IIf(DD.Visible, "1", "0"))
                    _T = _T.Replace("{Left}", MM2RPX(DD.Left, enumCalcType.H))
                    _T = _T.Replace("{Top}", MM2RPX(DD.Top, enumCalcType.V))
                    _T = _T.Replace("{Width}", MM2RPX(DD.Width, enumCalcType.H))
                    _T = _T.Replace("{Height}", MM2RPX(DD.Height, enumCalcType.V))
                    _T = _T.Replace("{BackColor}", DD.BackColor)
                    _T = _T.Replace("{LineColor}", DD.LineColor)
                    _T = _T.Replace("{LineStyle}", DD.LineStyle + 1)
                    _T = _T.Replace("{RoundingRadius}", DD.RoundingRadius)
                    _T = _T.Replace("{LineWeight}", DD.LineWidth)
                    _T = _T.Replace("{LineStyle}", DD.LineStyle + 1)
                    _R = _R & _T & vbCrLf
                Case enumFieldType.Barcode39
                    ' <Control Type="AR.Barcode" Name="Barcode1" DataField="6770053" Left="113.76" Top="2070.72" Width="4533" Height="198" BarStyle="6" Text="nikkekikai" Font="Courier New" FontSize="8" QRCode="EncodingCodePage=932" PDF417="EncodingCodePage=932" MicroPDF417="EncodingCodePage=932" CODE128="0;0;0" DataMatrix="EncodingCodePage=932" />
                    _T = "<Control Type='AR.Barcode' Name='{Name}' DataField='{DataField}' Left='{Left}' Top='{Top}' Width='{Width}' Height='{Height}' BarStyle='6' Text='STRING' Font='Courier New' FontSize='8' CaptionPos='{CaptionPos}' QRCode='EncodingCodePage=932' PDF417='EncodingCodePage=932' MicroPDF417='EncodingCodePage=932' CODE128='0;0;0' DataMatrix='EncodingCodePage=932' />"

                    _T = _T.Replace("{Name}", DD.Name)
                    _T = _T.Replace("{DataField}", DD.DataField)
                    _T = _T.Replace("{Visible}", IIf(DD.Visible, "1", "0"))
                    _T = _T.Replace("{Left}", MM2RPX(DD.Left, enumCalcType.H))
                    _T = _T.Replace("{Top}", MM2RPX(DD.Top, enumCalcType.V))
                    _T = _T.Replace("{Width}", MM2RPX(DD.Width, enumCalcType.H))
                    _T = _T.Replace("{Height}", MM2RPX(DD.Height, enumCalcType.V))
                    _T = _T.Replace("{Multiline}", IIf(DD.MultiLine, "1", "0"))
                    _T = _T.Replace("{CanShrink}", IIf(DD.CanShrink, "1", "0"))
                    _T = _T.Replace("{CaptionPos}", IIf(DD.BarcodeCaption, "2", "0"))
                    _T = _T.Replace("{BackColor}", DD.BackColor)
                    _T = _T.Replace("{LineColor}", DD.LineColor)
                    _T = _T.Replace("{LineStyle}", DD.LineStyle)
                    _T = _T.Replace("{RoundingRadius}", DD.RoundingRadius)
                    _T = _T.Replace("{Style}", CreateStyle(DD))
                    _R = _R & _T & vbCrLf
                Case enumFieldType.BarcodeQR
                    ' <Control Type="AR.Barcode" Name="Barcode1" DataField="6770053" Left="113.76" Top="2070.72" Width="4533" Height="198" BarStyle="6" Text="nikkekikai" Font="Courier New" FontSize="8" QRCode="EncodingCodePage=932" PDF417="EncodingCodePage=932" MicroPDF417="EncodingCodePage=932" CODE128="0;0;0" DataMatrix="EncodingCodePage=932" />
                    _T = "<Control Type='AR.Barcode' Name='{Name}' DataField='{DataField}' Left='{Left}' Top='{Top}' Width='{Width}' Height='{Height}' BarStyle='24' Text='STRING' Font='Courier New' FontSize='8' QRCode='EncodingCodePage=932' PDF417='EncodingCodePage=932' MicroPDF417='EncodingCodePage=932' CODE128='0;0;0' DataMatrix='EncodingCodePage=932' />"

                    _T = _T.Replace("{Name}", DD.Name)
                    _T = _T.Replace("{DataField}", DD.DataField)
                    _T = _T.Replace("{Visible}", IIf(DD.Visible, "1", "0"))
                    _T = _T.Replace("{Left}", MM2RPX(DD.Left, enumCalcType.H))
                    _T = _T.Replace("{Top}", MM2RPX(DD.Top, enumCalcType.V))
                    _T = _T.Replace("{Width}", MM2RPX(DD.Width, enumCalcType.H))
                    _T = _T.Replace("{Height}", MM2RPX(DD.Height, enumCalcType.V))
                    _T = _T.Replace("{Multiline}", IIf(DD.MultiLine, "1", "0"))
                    _T = _T.Replace("{CanShrink}", IIf(DD.CanShrink, "1", "0"))
                    _T = _T.Replace("{BackColor}", DD.BackColor)
                    _T = _T.Replace("{LineColor}", DD.LineColor)
                    _T = _T.Replace("{LineStyle}", DD.LineStyle)
                    _T = _T.Replace("{RoundingRadius}", DD.RoundingRadius)
                    _T = _T.Replace("{Style}", CreateStyle(DD))
                    _R = _R & _T & vbCrLf
                Case enumFieldType.Memo
                    '何もしない
            End Select
        Next
        Return _R.Replace("'", """")
    End Function
    ''' <summary>
    ''' スタイル部分の生成
    ''' </summary>
    ''' <param name="Dat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateStyle(Dat As ClassFieldCollection) As String
        'Dim _T As String = "font-family: {font_family}; font-size: {font_size}; font-weight: {font_weight}; white-space: {white-space}; text-align: {text_align}; vertical-align: {vertical_align}; ddo-font-vertical: {ddo_font_vertical}; ddo-char-set: {ddo_char_set}; text-justify: {text_justify}; ddo-shrink-to-fit: {ddo_shrink_to_fit}; ddo-wrap-mode: {white-space}"
        'Dim _T As String = "background-color: {BackColor}; color: {ForeColor}; font-family: {font_family}; font-size: {font_size}; font-weight: {font_weight}; white-space: {white-space}; text-align: {text_align}; vertical-align: {vertical_align}; ddo-font-vertical: {ddo_font_vertical}; ddo-char-set: {ddo_char_set}; text-justify: {text_justify}; ddo-shrink-to-fit: {ddo_shrink_to_fit}; ddo-wrap-mode: {white-space}"
        Dim _T As String = ""

        If Not Dat.ColorReverse Then
            '通常の場合はBackColorとForeColorの指定はしない
            _T = "font-family: {font_family}; font-size: {font_size}; font-weight: {font_weight}; white-space: {white-space}; text-align: {text_align}; vertical-align: {vertical_align}; ddo-font-vertical: {ddo_font_vertical}; ddo-char-set: {ddo_char_set}; text-justify: {text_justify}; ddo-shrink-to-fit: {ddo_shrink_to_fit}; ddo-wrap-mode: {white-space}"
            '_T = _T.Replace("{BackColor}", "#FFFFFF")
            '_T = _T.Replace("{ForeColor}", "#000000")
        Else
            '白黒反転時にはBackColorとForeColorの指定する
            _T = "background-color: {BackColor}; color: {ForeColor}; font-family: {font_family}; font-size: {font_size}; font-weight: {font_weight}; white-space: {white-space}; text-align: {text_align}; vertical-align: {vertical_align}; ddo-font-vertical: {ddo_font_vertical}; ddo-char-set: {ddo_char_set}; text-justify: {text_justify}; ddo-shrink-to-fit: {ddo_shrink_to_fit}; ddo-wrap-mode: {white-space}"
            _T = _T.Replace("{BackColor}", "#000000")
            _T = _T.Replace("{ForeColor}", "#FFFFFF")
        End If

        _T = _T.Replace("{font_family}", Dat.Style.font_family)
        _T = _T.Replace("{font_size}", Dat.Style.font_size)
        _T = _T.Replace("{font_weight}", Dat.Style.font_weight)
        _T = _T.Replace("{white-space}", Dat.Style.white_space)
        _T = _T.Replace("{text_align}", Dat.Style.text_align)
        _T = _T.Replace("{vertical_align}", Dat.Style.vertical_align)
        _T = _T.Replace("{ddo_font_vertical}", Dat.Style.ddo_font_vertical)
        _T = _T.Replace("{ddo_char_set}", Dat.Style.ddo_char_set)
        _T = _T.Replace("{text_justify}", Dat.Style.text_justify)
        _T = _T.Replace("{ddo_shrink_to_fit}", Dat.Style.ddo_shrink_to_fit)
        Return _T
    End Function
    ''' <summary>
    ''' 用紙設定部分の生成
    ''' </summary>
    ''' <param name="Dat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreatePageSetting(Dat As ClassPaperCollection) As String
        Dim _T As String = "<PageSettings LeftMargin='{LeftMargin}' RightMargin='{RightMargin}' TopMargin='{TopMargin}' BottomMargin='{BottomMargin}' PaperSize='{PaperSize}' PaperWidth='{PaperWidth}' PaperHeight='{PaperHeight}' PaperName='{PaperName}' Orientation='{Orientation}' />"

        _T = _T.Replace("{LeftMargin}", Int(MM2RPX(Dat.LeftMargin, enumCalcType.H)))
        _T = _T.Replace("{RightMargin}", Int(MM2RPX(Dat.RightMargin, enumCalcType.H)))
        _T = _T.Replace("{TopMargin}", Int(MM2RPX(Dat.TopMargin, enumCalcType.V)))
        _T = _T.Replace("{BottomMargin}", Int(MM2RPX(Dat.BottomMargin - Dat.Section.RowSpacing, enumCalcType.V)))

        _T = _T.Replace("{PaperWidth}", Int(MM2RPX(Dat.PaperWidth, enumCalcType.H)))
        _T = _T.Replace("{PaperHeight}", Int(MM2RPX(Dat.PaperHeight, enumCalcType.V)))
        _T = _T.Replace("{PaperSize}", FindPaperDataID(Dat.PaperSize))
        _T = _T.Replace("{PaperName}", Dat.PaperName)
        _T = _T.Replace("{Orientation}", Dat.Orientation)
        Return _T.Replace("'", """")
    End Function
#End Region
    Public Function FindPaperDataID(PaperDataID As Integer) As String
        If PaperInfoArray.Count > 0 Then
            For Each Item As ClassPaperInfo In PaperInfoArray
                If Item.DataID = PaperDataID Then
                    Return Item.PaperID
                End If
            Next
        End If
        Return ""
    End Function
    ''' <summary>
    ''' 用紙情報読込
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadPaperArray() As Boolean
        Try
            If System.IO.File.Exists(PaperArrayFile) Then
                PaperArray.Clear()
                Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(ClassPaperCollection()))
                Using FS As New IO.FileStream(PaperArrayFile, IO.FileMode.Open)
                    Dim LocalClass() As ClassPaperCollection
                    LocalClass = SRZ.Deserialize(FS)

                    For Each LoopClass As ClassPaperCollection In LocalClass
                        If LoopClass.PaperID = "" Then
                            LoopClass.PaperID = CreateGUID()
                        End If
                        PaperArray.Add(LoopClass)
                    Next
                End Using
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
    ''' <summary>
    ''' 用紙情報書き込み
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SavePaperArray() As Boolean
        Try
            If Not String.IsNullOrEmpty(PaperArrayFile) Then
                If System.IO.File.Exists(PaperArrayFile) Then System.IO.File.Delete(PaperArrayFile)

                Dim LocalClass() As ClassPaperCollection = TryCast(PaperArray.ToArray, ClassPaperCollection())

                If Not LocalClass Is Nothing Then
                    Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(ClassPaperCollection()))
                    Using FS As New IO.FileStream(PaperArrayFile, IO.FileMode.Create)
                        SRZ.Serialize(FS, LocalClass)
                    End Using
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
    Public Enum enumCalcType
        H
        V
    End Enum
    ''' <summary>
    ''' 用紙単位数字をｍｍ単位に変換
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="CalcType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RPX2MM(ByVal value As String, CalcType As enumCalcType) As Decimal
        If CalcType = enumCalcType.H Then
            Return value / _XShift
        Else
            Return value / _YShift
        End If
    End Function
    ''' <summary>
    ''' ｍｍ単位数字を用紙単位数字に変換
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="CalcType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MM2RPX(ByVal value As Decimal, CalcType As enumCalcType) As String
        If CalcType = enumCalcType.H Then
            Return value * _XShift
        Else
            Return value * _YShift
        End If
    End Function
    Public Function FieldClone(FromField As ClassFieldCollection) As ClassFieldCollection
        Dim _ToS As New ClassStyleCollection
        Dim _FromS As ClassStyleCollection = FromField.Style
        _ToS.ddo_char_set = _FromS.ddo_char_set
        _ToS.ddo_font_vertical = _FromS.ddo_font_vertical
        _ToS.ddo_shrink_to_fit = _FromS.ddo_shrink_to_fit
        _ToS.font_family = _FromS.font_family
        _ToS.font_size = _FromS.font_size
        _ToS.font_weight = _FromS.font_weight
        _ToS.text_align = _FromS.text_align
        _ToS.text_justify = _FromS.text_justify
        _ToS.vertical_align = _FromS.vertical_align
        _ToS.white_space = _FromS.white_space


        Dim _To As New ClassFieldCollection
        Dim _From As ClassFieldCollection = FromField
        _To.ARType = _From.ARType
        _To.BackColor = _From.BackColor
        _To.CanShrink = _From.CanShrink
        _To.DataField = _From.DataField
        _To.FieldType = _From.FieldType
        _To.FieldUseType = _From.FieldUseType
        _To.Height = _From.Height
        _To.IsSystem = _From.IsSystem
        _To.Left = _From.Left
        _To.LineColor = _From.LineColor
        _To.LineStyle = _From.LineStyle
        _To.MultiLine = _From.MultiLine
        _To.Name = _From.Name
        _To.RoundingRadius = _From.RoundingRadius
        _To.Style = _ToS
        _To.Text = _From.Text
        _To.Top = _From.Top
        _To.Visible = _From.Visible
        _To.Width = _From.Width
        _To.AddStr1 = _From.AddStr1
        _To.DisplayWidth = _From.DisplayWidth
        _To.LabelIsMask = _From.LabelIsMask
        _To.Angle = _From.Angle
        _To.BarcodeCaption = _From.BarcodeCaption
        _To.ColorReverse = _From.ColorReverse
        _To.UseIME = _From.UseIME
        _To.AddString_Front = _From.AddString_Front
        _To.AddString_Back = _From.AddString_Back
        Return _To

    End Function
    Private Sub FieldSwap(PaperData As ClassPaperCollection, Index1 As Integer, Index2 As Integer)
        'データ待避
        Dim _MemStyle As New ClassStyleCollection
        Dim _Style1 As ClassStyleCollection = PaperData.Section.FieldData(Index1 + 2).Style
        _MemStyle.ddo_char_set = _Style1.ddo_char_set
        _MemStyle.ddo_font_vertical = _Style1.ddo_font_vertical
        _MemStyle.ddo_shrink_to_fit = _Style1.ddo_shrink_to_fit
        _MemStyle.font_family = _Style1.font_family
        _MemStyle.font_size = _Style1.font_size
        _MemStyle.font_weight = _Style1.font_weight
        _MemStyle.text_align = _Style1.text_align
        _MemStyle.text_justify = _Style1.text_justify
        _MemStyle.vertical_align = _Style1.vertical_align
        _MemStyle.white_space = _Style1.white_space

        Dim _MemField As New ClassFieldCollection
        Dim _Field1 As ClassFieldCollection = PaperData.Section.FieldData(Index1 + 2)
        _MemField.ARType = _Field1.ARType
        _MemField.BackColor = _Field1.BackColor
        _MemField.CanShrink = _Field1.CanShrink
        _MemField.DataField = _Field1.DataField
        _MemField.FieldType = _Field1.FieldType
        _MemField.FieldUseType = _Field1.FieldUseType
        _MemField.Height = _Field1.Height
        _MemField.IsSystem = _Field1.IsSystem
        _MemField.Left = _Field1.Left
        _MemField.LineColor = _Field1.LineColor
        _MemField.LineStyle = _Field1.LineStyle
        _MemField.MultiLine = _Field1.MultiLine
        _MemField.Name = _Field1.Name
        _MemField.RoundingRadius = _Field1.RoundingRadius
        _MemField.Style = _MemStyle
        _MemField.Text = _Field1.Text
        _MemField.Top = _Field1.Top
        _MemField.Visible = _Field1.Visible
        _MemField.Width = _Field1.Width
        _MemField.LabelText = _Field1.Width
        _MemField.AddStr1 = _Field1.AddStr1
        _MemField.LabelIsMask = _Field1.LabelIsMask
        _MemField.DisplayWidth = _Field1.DisplayWidth
        _MemField.Angle = _Field1.Angle
        _MemField.BarcodeCaption = _Field1.BarcodeCaption
        _MemField.ColorReverse = _Field1.ColorReverse
        _MemField.UseIME = _Field1.UseIME
        _MemField.AddString_Front = _Field1.AddString_Front
        _MemField.AddString_Back = _Field1.AddString_Back

        '２から１へコピー
        Dim _Style2 As ClassStyleCollection = PaperData.Section.FieldData(Index2 + 2).Style
        _Style1.ddo_char_set = _Style2.ddo_char_set
        _Style1.ddo_font_vertical = _Style2.ddo_font_vertical
        _Style1.ddo_shrink_to_fit = _Style2.ddo_shrink_to_fit
        _Style1.font_family = _Style2.font_family
        _Style1.font_size = _Style2.font_size
        _Style1.font_weight = _Style2.font_weight
        _Style1.text_align = _Style2.text_align
        _Style1.text_justify = _Style2.text_justify
        _Style1.vertical_align = _Style2.vertical_align
        _Style1.white_space = _Style2.white_space

        Dim _Field2 As ClassFieldCollection = PaperData.Section.FieldData(Index2 + 2)
        _Field1.ARType = _Field2.ARType
        _Field1.BackColor = _Field2.BackColor
        _Field1.CanShrink = _Field2.CanShrink
        _Field1.DataField = _Field2.DataField
        _Field1.FieldType = _Field2.FieldType
        _Field1.FieldUseType = _Field2.FieldUseType
        _Field1.Height = _Field2.Height
        _Field1.IsSystem = _Field2.IsSystem
        _Field1.Left = _Field2.Left
        _Field1.LineColor = _Field2.LineColor
        _Field1.LineStyle = _Field2.LineStyle
        _Field1.MultiLine = _Field2.MultiLine
        _Field1.Name = _Field2.Name
        _Field1.RoundingRadius = _Field2.RoundingRadius
        _Field1.Style = _Style1
        _Field1.Text = _Field2.Text
        _Field1.Top = _Field2.Top
        _Field1.Visible = _Field2.Visible
        _Field1.Width = _Field2.Width
        _Field1.LabelText = _Field2.LabelText
        _Field1.LabelIsMask = _Field2.LabelIsMask
        _Field1.DisplayWidth = _Field2.DisplayWidth
        _Field1.AddStr1 = _Field2.AddStr1
        _Field1.Angle = _Field2.Angle
        _Field1.BarcodeCaption = _Field2.BarcodeCaption
        _Field1.ColorReverse = _Field2.ColorReverse
        _Field1.UseIME = _Field2.UseIME
        _Field1.AddString_Front = _Field2.AddString_Front
        _Field1.AddString_Back = _Field2.AddString_Back

        '記憶から２へコピー
        _Style2.ddo_char_set = _MemStyle.ddo_char_set
        _Style2.ddo_font_vertical = _MemStyle.ddo_font_vertical
        _Style2.ddo_shrink_to_fit = _MemStyle.ddo_shrink_to_fit
        _Style2.font_family = _MemStyle.font_family
        _Style2.font_size = _MemStyle.font_size
        _Style2.font_weight = _MemStyle.font_weight
        _Style2.text_align = _MemStyle.text_align
        _Style2.text_justify = _MemStyle.text_justify
        _Style2.vertical_align = _MemStyle.vertical_align
        _Style2.white_space = _MemStyle.white_space

        _Field2.ARType = _MemField.ARType
        _Field2.BackColor = _MemField.BackColor
        _Field2.CanShrink = _MemField.CanShrink
        _Field2.DataField = _MemField.DataField
        _Field2.FieldType = _MemField.FieldType
        _Field2.FieldUseType = _MemField.FieldUseType
        _Field2.Height = _MemField.Height
        _Field2.IsSystem = _MemField.IsSystem
        _Field2.Left = _MemField.Left
        _Field2.LineColor = _MemField.LineColor
        _Field2.LineStyle = _MemField.LineStyle
        _Field2.MultiLine = _MemField.MultiLine
        _Field2.Name = _MemField.Name
        _Field2.RoundingRadius = _MemField.RoundingRadius
        _Field2.Style = _Style2
        _Field2.Text = _MemField.Text
        _Field2.Top = _MemField.Top
        _Field2.Visible = _MemField.Visible
        _Field2.Width = _MemField.Width
        _Field2.LabelText = _MemField.LabelText
        _Field2.LabelIsMask = _MemField.LabelIsMask
        _Field2.DisplayWidth = _MemField.DisplayWidth
        _Field2.AddStr1 = _MemField.AddStr1
        _Field2.Angle = _MemField.Angle
        _Field2.BarcodeCaption = _MemField.BarcodeCaption
        _Field2.ColorReverse = _MemField.ColorReverse
        _Field2.UseIME = _MemField.UseIME
        _Field2.AddString_Front = _MemField.AddString_Front
        _Field2.AddString_Back = _MemField.AddString_Back
    End Sub
    Private Sub PaperCopy(PaperIndex As Integer)

        Dim _ToField As New List(Of ClassFieldCollection)
        For Each _FromField As ClassFieldCollection In PaperArray(PaperIndex).Section.FieldData
            Dim _TF As New ClassFieldCollection
            _TF.ARType = _FromField.ARType
            _TF.BackColor = _FromField.BackColor
            _TF.CanShrink = _FromField.CanShrink
            _TF.DataField = _FromField.DataField
            _TF.FieldType = _FromField.FieldType
            _TF.FieldUseType = _FromField.FieldUseType
            _TF.Height = _FromField.Height
            _TF.IsSystem = _FromField.IsSystem
            _TF.Left = _FromField.Left
            _TF.LineColor = _FromField.LineColor
            _TF.LineStyle = _FromField.LineStyle
            _TF.MultiLine = _FromField.MultiLine
            _TF.Name = _FromField.Name
            _TF.RoundingRadius = _FromField.RoundingRadius
            _TF.Text = _FromField.Text
            _TF.Top = _FromField.Top
            _TF.Visible = _FromField.Visible
            _TF.Width = _FromField.Width
            _TF.AddStr1 = _FromField.AddStr1
            _TF.DisplayWidth = _FromField.DisplayWidth
            _TF.LabelIsMask = _FromField.LabelIsMask
            _TF.Angle = _FromField.Angle
            _TF.BarcodeCaption = _FromField.BarcodeCaption
            _TF.ColorReverse = _FromField.ColorReverse
            _TF.UseIME = _FromField.UseIME
            _TF.AddString_Front = _FromField.AddString_Front
            _TF.AddString_Back = _FromField.AddString_Back

            Dim _FromStyle As ClassStyleCollection = _FromField.Style
            Dim _ToStyle As New ClassStyleCollection
            _ToStyle.ddo_char_set = _FromStyle.ddo_char_set
            _ToStyle.ddo_font_vertical = _FromStyle.ddo_font_vertical
            _ToStyle.ddo_shrink_to_fit = _FromStyle.ddo_shrink_to_fit
            _ToStyle.font_family = _FromStyle.font_family
            _ToStyle.font_size = _FromStyle.font_size
            _ToStyle.font_weight = _FromStyle.font_weight
            _ToStyle.text_align = _FromStyle.text_align
            _ToStyle.text_justify = _FromStyle.text_justify
            _ToStyle.vertical_align = _FromStyle.vertical_align
            _ToStyle.white_space = _FromStyle.white_space
            _TF.Style = _ToStyle

            _ToField.Add(_TF)

        Next

        Dim _FromSection As ClassSectionCollection = PaperArray(PaperIndex).Section
        Dim _ToSection As New ClassSectionCollection
        _ToSection.BackColor = _FromSection.BackColor
        _ToSection.ColumnCount = _FromSection.ColumnCount
        _ToSection.ColumnDirection = _FromSection.ColumnDirection
        _ToSection.ColumnSpacing = _FromSection.ColumnSpacing
        _ToSection.FieldData = _ToField
        _ToSection.Height = _FromSection.Height
        _ToSection.KeepTogether = _FromSection.KeepTogether
        _ToSection.Name = _FromSection.Name
        _ToSection.RowSpacing = _FromSection.RowSpacing
        _ToSection.Type = _FromSection.Type


        Dim _FromLayout As ClassLayoutCollection = PaperArray(PaperIndex).Layout
        Dim _ToLayout As New ClassLayoutCollection
        _ToLayout.DocumentName = _FromLayout.DocumentName
        _ToLayout.MasterReport = _FromLayout.MasterReport
        _ToLayout.PrintWidth = _FromLayout.PrintWidth
        _ToLayout.ScriptLang = _FromLayout.ScriptLang
        _ToLayout.UserData = _FromLayout.UserData
        _ToLayout.Version = _FromLayout.Version

        Dim _FromData As ClassPaperCollection = PaperArray(PaperIndex)
        Dim _ToData As New ClassPaperCollection

        _ToData.BottomMargin = _FromData.BottomMargin
        _ToData.Caption = _FromData.Caption
        _ToData.Layout = _ToLayout
        _ToData.LeftMargin = _FromData.LeftMargin
        _ToData.MakerName = _FromData.MakerName
        _ToData.Name = _FromData.Name
        _ToData.Orientation = _FromData.Orientation
        _ToData.PaperHeight = _FromData.PaperHeight
        _ToData.PaperName = _FromData.PaperName
        _ToData.PaperSize = _FromData.PaperSize
        _ToData.PaperWidth = _FromData.PaperWidth
        _ToData.RightMargin = _FromData.RightMargin
        _ToData.PaperID = CreateGUID()
        _ToData.Section = _ToSection
        _ToData.Text = _FromData.Text
        _ToData.TopMargin = _FromData.TopMargin
        PaperArray.Add(_ToData)
    End Sub
   
End Module
''' <summary>
''' フィールドスタイルコレクション
''' </summary>
''' <remarks></remarks>
Public Class ClassStyleCollection
    ''' <summary>
    ''' フォント名
    ''' </summary>
    ''' <remarks></remarks>
    Public font_family As String
    ''' <summary>
    ''' フォントサイズ
    ''' </summary>
    ''' <remarks></remarks>
    Public font_size As String
    ''' <summary>
    ''' ボールド
    ''' </summary>
    ''' <remarks></remarks>
    Public font_weight As String
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public white_space As String 'inherit; nowrap; 
    ''' <summary>
    ''' 文字横配置
    ''' </summary>
    ''' <remarks></remarks>
    Public text_align As String
    ''' <summary>
    ''' 文字縦配置
    ''' </summary>
    ''' <remarks></remarks>
    Public vertical_align As String
    ''' <summary>
    ''' 縦書き（noneで固定）
    ''' </summary>
    ''' <remarks></remarks>
    Public ddo_font_vertical As String
    ''' <summary>
    ''' キャラクタ（１２８（日本語）で固定）
    ''' </summary>
    ''' <remarks></remarks>
    Public ddo_char_set As String
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public text_justify As String
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public ddo_shrink_to_fit As String

    Sub New()
        Me.font_family = "ＭＳ Ｐ明朝"
        Me.font_size = "10pt"
        Me.font_weight = "none"
        Me.white_space = "inherit"
        Me.text_align = "center"
        Me.vertical_align = "middle"
        Me.ddo_font_vertical = "none" '縦書き
        Me.ddo_char_set = "128"
        Me.text_justify = "auto"
        Me.ddo_shrink_to_fit = "none"
    End Sub
End Class
Public Enum enumFieldType
    Shape
    Field
    Label
    Line
    Box 'Shapeは外枠で使用するので、矩形はBOXとする
    Barcode39
    BarcodeQR
    Memo
End Enum
''' <summary>
''' フィールド情報コレクション
''' </summary>
''' <remarks></remarks>
Public Class ClassFieldCollection
    ''' <summary>
    ''' フィールドタイプ
    ''' </summary>
    ''' <remarks></remarks>
    Public FieldType As enumFieldType
    ''' <summary>
    ''' ARのオブジェクト名
    ''' </summary>
    ''' <remarks></remarks>
    Public ARType As String
    ''' <summary>
    ''' システムフィールド（TRUE：システム用）
    ''' </summary>
    ''' <remarks></remarks>
    Public IsSystem As Boolean
    ''' <summary>
    ''' 表示文字
    ''' </summary>
    ''' <remarks></remarks>
    Public Text As String
    ''' <summary>
    ''' 〒文字を付加
    ''' </summary>
    ''' <remarks></remarks>
    Public AddStr1 As Boolean
    Public Overrides Function ToString() As String
        Return Text
    End Function
    ''' <summary>
    ''' フィールド名
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String
    ''' <summary>
    ''' データフィールド名
    ''' </summary>
    ''' <remarks></remarks>
    Public DataField As String
    ''' <summary>
    ''' 表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Visible As Boolean
    ''' <summary>
    ''' 複数行
    ''' </summary>
    ''' <remarks></remarks>
    Public MultiLine As Boolean
    ''' <summary>
    ''' フィールド使用用途
    ''' </summary>
    ''' <remarks>
    '''一般フィールド0
    '''郵便番号フィールド1
    '''住所フィールド2
    '''名前フィールド3
    '''注意書きフィールド4
    '''</remarks>
    Public FieldUseType As Integer
    ''' <summary>
    ''' 左位置
    ''' </summary>
    ''' <remarks></remarks>
    Public Left As Decimal
    ''' <summary>
    ''' 上位置
    ''' </summary>
    ''' <remarks></remarks>
    Public Top As Decimal
    ''' <summary>
    ''' フィールド幅
    ''' </summary>
    ''' <remarks></remarks>
    Public Width As Decimal
    ''' <summary>
    ''' フィールド高さ
    ''' </summary>
    ''' <remarks></remarks>
    Public Height As Decimal
    ''' <summary>
    ''' フィールド高さ自動縮小
    ''' </summary>
    ''' <remarks></remarks>
    Public CanShrink As Boolean
    ''' <summary>
    ''' 背景色（固定）
    ''' </summary>
    ''' <remarks></remarks>
    Public BackColor As Decimal
    ''' <summary>
    ''' ライン色（SHAPEのみ）固定
    ''' </summary>
    ''' <remarks></remarks>
    Public LineColor As Decimal
    ''' <summary>
    ''' ライン種類（SHAPEのみ）固定
    ''' </summary>
    ''' <remarks></remarks>
    Public LineStyle As Integer
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public RoundingRadius As Decimal
    ''' <summary>
    ''' フィールドスタイル
    ''' </summary>
    ''' <remarks></remarks>
    Public Style As ClassStyleCollection
    ''' <summary>
    ''' ライン幅(SHAPEのみ）
    ''' </summary>
    ''' <remarks></remarks>
    Public LineWidth As Integer
    ''' <summary>
    ''' ラベルフィールド表示文字
    ''' </summary>
    ''' <remarks></remarks>
    Public LabelText As String
    ''' <summary>
    ''' ラベル文字がマスク文字？？
    ''' </summary>
    ''' <remarks></remarks>
    Public LabelIsMask As Boolean
    ''' <summary>
    ''' 入力表幅
    ''' </summary>
    ''' <remarks></remarks>
    Public DisplayWidth As Integer
    ''' <summary>
    ''' 文字表示角度（度）
    ''' </summary>
    ''' <remarks></remarks>
    Public Angle As Integer
    ''' <summary>
    ''' バーコード文字付帯
    ''' </summary>
    ''' <remarks></remarks>
    Public BarcodeCaption As Boolean
    ''' <summary>
    ''' 白黒反転
    ''' </summary>
    ''' <remarks></remarks>
    Public ColorReverse As Boolean
    ''' <summary>
    ''' 漢字入力
    ''' </summary>
    ''' <remarks></remarks>
    Public UseIME As Boolean
    ''' <summary>
    ''' フィールドの前に付ける文字
    ''' </summary>
    ''' <remarks></remarks>
    Public AddString_Front As String
    ''' <summary>
    ''' フィールドの後ろに付ける文字
    ''' </summary>
    ''' <remarks></remarks>
    Public AddString_Back As String
    Sub New()
        Me.FieldType = enumFieldType.Field
        Me.ARType = "AR.Field"
        Me.IsSystem = False
        Me.Text = "テキスト"
        Me.Name = "TxtField1"
        Me.DataField = "Field1"
        Me.Visible = True
        Me.MultiLine = False
        Me.FieldUseType = 0
        Me.Left = 0
        Me.Top = 0
        Me.Width = 10
        Me.Height = 10
        Me.CanShrink = False
        Me.BackColor = 16777215
        Me.LineColor = 8421504
        Me.LineStyle = 2
        Me.RoundingRadius = 9.999999
        Me.Style = New ClassStyleCollection
        Me.LineWidth = 1
        Me.LabelText = ""
        Me.AddStr1 = False
        Me.LabelIsMask = False
        Me.DisplayWidth = 0
        Me.Angle = 0
        Me.BarcodeCaption = False
        Me.ColorReverse = False
        Me.UseIME = False
        Me.AddString_Front = ""
        Me.AddString_Back = ""
    End Sub
    'ClassFieldCollection
    Sub New(Value As ClassFieldCollection)
        Me.FieldType = Value.FieldType
        Me.ARType = Value.ARType
        Me.IsSystem = Value.IsSystem
        Me.Text = Value.Text
        Me.Name = Value.Name
        Me.DataField = Value.DataField
        Me.Visible = Value.Visible
        Me.MultiLine = Value.MultiLine
        Me.FieldUseType = Value.FieldUseType
        Me.Left = Value.Left
        Me.Top = Value.Top
        Me.Width = Value.Width
        Me.Height = Value.Height
        Me.CanShrink = Value.CanShrink
        Me.BackColor = Value.BackColor
        Me.LineColor = Value.LineColor
        Me.LineStyle = Value.LineStyle
        Me.RoundingRadius = Value.RoundingRadius
        Me.Style = Value.Style
        Me.LineWidth = Value.LineWidth
        Me.LabelText = Value.LabelText
        Me.AddStr1 = Value.AddStr1
        Me.LabelIsMask = Value.LabelIsMask
        Me.DisplayWidth = Value.DisplayWidth
        Me.Angle = Value.Angle
        Me.BarcodeCaption = Value.BarcodeCaption
        Me.ColorReverse = Value.ColorReverse
        Me.UseIME = Value.UseIME
        Me.AddString_Front = Value.AddString_Front
        Me.AddString_Back = Value.AddString_Back

    End Sub
End Class
''' <summary>
''' セクション項目コレクション
''' </summary>
''' <remarks></remarks>
Public Class ClassSectionCollection
    ''' <summary>
    ''' ARオブジェクト名（固定）
    ''' </summary>
    ''' <remarks></remarks>
    Public Type As String
    ''' <summary>
    ''' ARオブジェクトタイプ名(固定）
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String
    ''' <summary>
    ''' セクション高さ
    ''' </summary>
    ''' <remarks></remarks>
    Public Height As Decimal
    ''' <summary>
    ''' 列数
    ''' </summary>
    ''' <remarks></remarks>
    Public ColumnCount As Integer
    ''' <summary>
    ''' 行数
    ''' </summary>
    ''' <remarks></remarks>
    Public RowCount As Integer
    ''' <summary>
    ''' 印字順序（１：横→下）
    ''' </summary>
    ''' <remarks></remarks>
    Public ColumnDirection As Integer
    ''' <summary>
    ''' 列間隔
    ''' </summary>
    ''' <remarks></remarks>
    Public ColumnSpacing As Integer
    ''' <summary>
    ''' 行間隔
    ''' </summary>
    ''' <remarks></remarks>
    Public RowSpacing As Integer
    ''' <summary>
    ''' 背景色（固定）
    ''' </summary>
    ''' <remarks></remarks>
    Public BackColor As Decimal
    ''' <summary>
    ''' キープトゥギャザ（固定）
    ''' </summary>
    ''' <remarks></remarks>
    Public KeepTogether As Integer
    ''' <summary>
    ''' 保有フィールドデータアレイ
    ''' </summary>
    ''' <remarks></remarks>
    Public FieldData As New List(Of ClassFieldCollection)
    Sub New()
        Me.Type = "Detail"
        Me.Name = "Detail"
        Me.Height = 0
        Me.ColumnCount = 1
        Me.RowCount = 1
        Me.ColumnDirection = 1 '印刷順序
        Me.ColumnSpacing = 0
        Me.RowSpacing = 0
        Me.BackColor = 16777215
        Me.KeepTogether = 1

    End Sub
End Class
''' <summary>
''' レイアウト項目コレクション
''' </summary>
''' <remarks></remarks>
Public Class ClassLayoutCollection
    ''' <summary>
    ''' バージョン（固定）
    ''' </summary>
    ''' <remarks></remarks>
    Public Version As String
    ''' <summary>
    ''' 印字幅（用紙幅－左右余白）
    ''' </summary>
    ''' <remarks></remarks>
    Public PrintWidth As Decimal
    ''' <summary>
    ''' ドキュメント名（固定）
    ''' </summary>
    ''' <remarks></remarks>
    Public DocumentName As String
    ''' <summary>
    ''' スクリプト言語（固定）
    ''' </summary>
    ''' <remarks></remarks>
    Public ScriptLang As String
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public UserData As String
    ''' <summary>
    ''' マスタレポート使用？（固定）
    ''' </summary>
    ''' <remarks></remarks>
    Public MasterReport As String
    '<ActiveReportsLayout Version="3.2" PrintWidth="9796.536" DocumentName="ActiveReports Document" ScriptLang="VB.NET" UserData="" MasterReport="0">
    Sub New()
        Me.Version = "3.2"
        Me.PrintWidth = RPX2MM(9796.536, enumCalcType.H)
        Me.DocumentName = "ActiveReports Document"
        Me.ScriptLang = "VB.NET"
        Me.UserData = ""
        Me.MasterReport = "0"
    End Sub
End Class
''' <summary>
''' 用紙情報コレクション
''' </summary>
''' <remarks></remarks>
Public Class ClassPaperCollection
    ''' <summary>
    ''' 用紙メーカー名
    ''' </summary>
    ''' <remarks></remarks>
    Public MakerName As String
    ''' <summary>
    ''' 用紙名
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String
    ''' <summary>
    ''' 用紙表示名
    ''' </summary>
    ''' <remarks></remarks>
    Public Text As String
    ''' <summary>
    ''' 用紙備考
    ''' </summary>
    ''' <remarks></remarks>
    Public Caption As String
    ''' <summary>
    ''' 用紙サイズ
    ''' </summary>
    ''' <remarks>
    '''  https://support.hos.co.jp/support/CR/reference/Manual/V10/ViewControl/property/CrPrinter/PaperSize.html
    ''' 8	A3シート	297 × 420mm
    ''' 9	A4シート	210 × 297mm
    ''' 11	A5シート	148 × 210mm
    ''' 43	はがき		100 × 148mm
    '''</remarks>
    Public PaperSize As Integer
    ''' <summary>
    ''' 左余白
    ''' </summary>
    ''' <remarks></remarks>
    Public LeftMargin As Decimal
    ''' <summary>
    ''' 右余白
    ''' </summary>
    ''' <remarks></remarks>
    Public RightMargin As Decimal
    ''' <summary>
    ''' 上余白
    ''' </summary>
    ''' <remarks></remarks>
    Public TopMargin As Decimal
    ''' <summary>
    ''' 下余白
    ''' </summary>
    ''' <remarks></remarks>
    Public BottomMargin As Decimal
    ''' <summary>
    ''' 用紙幅
    ''' </summary>
    ''' <remarks></remarks>
    Public PaperWidth As Integer
    ''' <summary>
    ''' 用紙高さ
    ''' </summary>
    ''' <remarks></remarks>
    Public PaperHeight As Integer
    ''' <summary>
    ''' 用紙名（なしで固定）
    ''' </summary>
    ''' <remarks></remarks>
    Public PaperName As String
    ''' <summary>
    ''' 用紙向き（１：縦）
    ''' </summary>
    ''' <remarks></remarks>
    Public Orientation As Integer
    ''' <summary>
    ''' 用紙画像
    ''' </summary>
    ''' <remarks></remarks>
    Public GroundPicture As String
    ''' <summary>
    ''' 用紙GUID
    ''' </summary>
    ''' <remarks></remarks>
    Public PaperID As String
    ''' <summary>
    ''' レイアウトコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public Layout As New ClassLayoutCollection
    ''' <summary>
    ''' セクションコレクション
    ''' </summary>
    ''' <remarks></remarks>
    Public Section As New ClassSectionCollection
    Sub New()
        Me.MakerName = "新しいメーカ"
        Me.Name = "新しい用紙"
        Me.Text = "新しいタックシート"
        Me.Caption = "新しいタックシート"
        Me.PaperSize = 9
        Me.LeftMargin = 0
        Me.RightMargin = 0
        Me.TopMargin = 0
        Me.BottomMargin = 0
        Me.PaperWidth = 11906
        Me.PaperHeight = 16838
        Me.PaperName = ""
        Me.Orientation = "1"
        Me.GroundPicture = ""
    End Sub

End Class
''' <summary>
''' 印刷プレビュー作成用コレクション
''' </summary>
''' <remarks></remarks>
Public Class ClassPreviewFieldCollection
    Public FieldShape As String
    Public Field1 As String
    Public Field2 As String
    Public Field3 As String
    Public Field4 As String
    Public Field5 As String
    Public Field6 As String
    Public Field7 As String
    Public Field8 As String
    Public Field9 As String
    Public Field10 As String
    Public Field11 As String
    Public Field12 As String
    Public Field13 As String
    Public Field14 As String
    Public Field15 As String
    Public Field16 As String
    Public Field17 As String
    Public Field18 As String
    Public Field19 As String
    Public Field20 As String
    Sub New()
        Me.FieldShape = ""
        Me.Field1 = ""
        Me.Field2 = ""
        Me.Field3 = ""
        Me.Field4 = ""
        Me.Field5 = ""
        Me.Field6 = ""
        Me.Field7 = ""
        Me.Field8 = ""
        Me.Field9 = ""
        Me.Field10 = ""
        Me.Field11 = ""
        Me.Field12 = ""
        Me.Field13 = ""
        Me.Field14 = ""
        Me.Field15 = ""
        Me.Field16 = ""
        Me.Field17 = ""
        Me.Field18 = ""
        Me.Field19 = ""
        Me.Field20 = ""
    End Sub
End Class
