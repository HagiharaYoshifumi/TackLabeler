Public Class FrmpaperInfo
    Dim _Dat As ClassPaperCollection
    Property PaperDat As ClassPaperCollection
        Set(value As ClassPaperCollection)
            _Dat = value
        End Set
        Get
            Return _Dat
        End Get
    End Property

    Private Sub FrmpaperInfo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Function CaptionTrim(Value As String) As String
        Return Replace(Value, "<BR>", "")
    End Function

    Private Sub FrmpaperInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With _Dat
            LblMakerName.Text = CaptionTrim(.MakerName)
            LblName.Text = CaptionTrim(.Name)
            LblText.Text = CaptionTrim(.Text)
            LblCaption.Text = CaptionTrim(.Caption)

            Dim _P As Integer = FindPaperDataID(.PaperSize)
            Select Case _P '.PaperSize
                Case 1 : LblPaperSize.Text = "レターサイズ"
                Case 3 : LblPaperSize.Text = "レジャーサイズ"
                Case 5 : LblPaperSize.Text = "リーガルサイズ"
                Case 7 : LblPaperSize.Text = "エグゼクティブサイズ"
                Case 8 : LblPaperSize.Text = "A3サイズ"
                Case 9 : LblPaperSize.Text = "A4サイズ"
                Case 11 : LblPaperSize.Text = "A5サイズ"
                Case 12 : LblPaperSize.Text = "B4サイズ"
                Case 13 : LblPaperSize.Text = "B5サイズ"
                Case 43 : LblPaperSize.Text = "はがきサイズ"
                Case 71 : LblPaperSize.Text = "封筒 角形2号"
                Case 73 : LblPaperSize.Text = "封筒 長形3号"
                Case 82 : LblPaperSize.Text = "往復はがきサイズ"
                Case 256 : LblPaperSize.Text = "ユーザー設定"
                Case 4300 : LblPaperSize.Text = "4面はがきサイズ"
                Case 4620 : LblPaperSize.Text = "封筒 洋形長3号"
                Case Else : LblPaperSize.Text = "カスタムサイズ"

            End Select

            LblLeftMargin.Text = .LeftMargin
            LblRightMargin.Text = .RightMargin
            LblTopMargin.Text = .TopMargin
            LblBottomMargin.Text = .BottomMargin
            LblTackWidth.Text = ((.PaperWidth - ((.Section.ColumnCount - 1) * .Section.RowSpacing) - .LeftMargin - .RightMargin) / .Section.ColumnCount)
            LblTackHeight.Text = .Section.Height
            If .Orientation = 1 Then
                LblOrientation.Text = "縦"
            Else
                LblOrientation.Text = "横"

            End If
            With .Section
                LblColumnCount.Text = .ColumnCount
                LblRowCount.Text = .RowCount
                LblColumnSpacing.Text = .ColumnSpacing
                LblRowSpacing.Text = .RowSpacing
            End With

           
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class