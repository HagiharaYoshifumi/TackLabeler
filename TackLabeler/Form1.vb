Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        If PaperArray.Count > 0 Then
            For Each PP As ClassPaperCollection In PaperArray
                ComboBox1.Items.Add(String.Format("{0} {1}", PP.MakerName, PP.Name))
            Next
            ComboBox1.SelectedIndex = 0
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PaperArray.Clear()

        Dim P As New ClassPaperCollection
        Dim S As New ClassSectionCollection

        For i As Integer = 1 To 3
            Dim O As New ClassFieldCollection
            O.FieldType = enumFieldType.Field
            O.ARType = "AR.Field"
            O.Name = "TxtField" & i.ToString
            O.DataField = "Field" & i.ToString
            O.Left = 0
            O.Top = 5 * i
            O.Width = 20
            O.Height = 5
            S.FieldData.Add(O)
        Next



        S.Height = RPX2MM(2420.787, enumCalcType.H)
        S.ColumnCount = 2


        P.Section = S
        P.LeftMargin = RPX2MM(1054, enumCalcType.H)
        P.RightMargin = RPX2MM(0, enumCalcType.H)
        P.TopMargin = RPX2MM(1202, enumCalcType.V)
        P.BottomMargin = RPX2MM(0, enumCalcType.V)
        P.PaperSize = 9
        P.PaperWidth = RPX2MM(11906, enumCalcType.H)
        P.PaperHeight = RPX2MM(16838, enumCalcType.V)
        P.Orientation = 1

        With P.Section.FieldData(0)
            .Width = RPX2MM(11906, enumCalcType.H) / P.Section.ColumnCount
            .Height = RPX2MM(2420.787, enumCalcType.H)
        End With

        PaperArray.Add(P)



        For Each PP As ClassPaperCollection In PaperArray
            ComboBox1.Items.Add(String.Format("{0} {1}", PP.MakerName, PP.Name))
        Next
        ComboBox1.SelectedIndex = 0
    End Sub
    Private Property Report() As GrapeCity.ActiveReports.Document.SectionDocument 'Public Property Report() As GrapeCity.ActiveReports.Document.Document
        Get
            Return Viewer1.Document
        End Get
        Set(ByVal Value As GrapeCity.ActiveReports.Document.SectionDocument)
            Me.Viewer1.Document = Value
        End Set
    End Property
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim _Count As Integer = 1

        Viewer1.Document = Nothing
        Dim SelP As ClassPaperCollection = PaperArray(ComboBox1.SelectedIndex)
        Dim RepFile As String = NFuncSystemFullPath(Environment.SpecialFolder.ApplicationData, "RepData.xml")
        Dim RepDataArray As New List(Of ClassPreviewFieldCollection)

        Call CreateReport(SelP)
        'Try
        For Row As Integer = 0 To 5
            Dim _T As New ClassPreviewFieldCollection
            For Col As Integer = 1 To SelP.Section.FieldData.Count - 2
                Select Case Col
                    Case 1 : _T.Field1 = "A" & Row.ToString
                    Case 2 : _T.Field2 = "B" & Row.ToString
                    Case 3 : _T.Field3 = "C" & Row.ToString
                    Case 4 : _T.Field4 = "D" & Row.ToString
                    Case 5 : _T.Field5 = "E" & Row.ToString
                    Case 6 : _T.Field6 = "F" & Row.ToString
                    Case 7 : _T.Field7 = "G" & Row.ToString
                    Case 8 : _T.Field8 = "H" & Row.ToString
                    Case 9 : _T.Field9 = "I" & Row.ToString

                End Select
                RepDataArray.Add(_T)
            Next

        Next
        Dim Data() As ClassPreviewFieldCollection = RepDataArray.ToArray

        Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(ClassPreviewFieldCollection()))
        Using FS As New IO.FileStream(RepFile, IO.FileMode.Create)
            SRZ.Serialize(FS, Data)
        End Using

        Dim Rep As New GrapeCity.ActiveReports.SectionReport()
        Dim PFile As String = AppFullPath("AAA.rpx")
        Using xtr As New System.Xml.XmlTextReader(PFile)
            Rep.LoadLayout(xtr)
        End Using

        CType(Rep.DataSource, GrapeCity.ActiveReports.Data.XMLDataSource).FileURL = RepFile
        Rep.Run()
        Report = Rep.Document

    End Sub

  

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If PaperArray.Count > 0 Then
            Call SavePaperArray()
            MsgBox("SAVED")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Beep()
        'GrapeCity.ActiveReports.Extensibility.Printing.Printer
    End Sub

   
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub
End Class