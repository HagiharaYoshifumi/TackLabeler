Imports Microsoft.Office.Interop.Word
Imports Word = Microsoft.Office.Interop.Word
Imports System.IO
''' <summary>
''' WORD操作モジュール
''' </summary>
''' <remarks></remarks>
Module ModuleWord
    ''' <summary>
    ''' 既存WORD文書を編集しPDFファイルにする
    ''' </summary>
    ''' <param name="Data"></param>
    ''' <param name="MasterDoc"></param>
    ''' <param name="SaveFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateWord2PDF(Field As ArrayList, Data As ArrayList, MasterDoc As String, SaveFileName As String) As String

        If MasterDoc <> "" AndAlso File.Exists(MasterDoc) Then
            Dim word As Word.Application = New Word.Application()
            '{DATE}{POST}　{ADDRESS}{COMPANY} {POSITION} {NAME}様{TEL}{FAX}
            'Word の GUI を起動しないようにする
            word.Visible = False

            ' 既存文書を開く
            Dim document As Document = word.Documents.Open(MasterDoc)
            Dim Ex As String = Path.GetExtension(MasterDoc)

            'Dim C As Integer = 1
            'For Each Itm As String In Data
            '    Call SelectionFind(document, String.Format("<FIELD{0}>", C), Itm)
            '    C += 1
            'Next

            For i As Integer = 0 To Field.Count - 1
                Call SelectionFind(document, String.Format("<{0}>", Field(i)), Data(i))
            Next

            'Dim outputFilename As String = System.IO.Path.ChangeExtension(MasterDoc, "pdf")
            'https://social.msdn.microsoft.com/Forums/vstudio/en-US/f135b6de-64cf-4c1d-ba17-b26358caba01/word-to-pdf-converter-using-vbnet?forum=vbgeneral
            If Not document Is Nothing Then
                document.ExportAsFixedFormat(SaveFileName, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF, False, Microsoft.Office.Interop.Word.WdExportOptimizeFor.wdExportOptimizeForOnScreen, Microsoft.Office.Interop.Word.WdExportRange.wdExportAllDocument, 0, 0, Microsoft.Office.Interop.Word.WdExportItem.wdExportDocumentContent, True, True, Microsoft.Office.Interop.Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks, True, True, False)
            End If

            ' 文書を閉じる
            'https://blog.goo.ne.jp/goosyun/e/7a57f2c9f52707009b907731b72197de
            document.Close(False) 'マスタデータは変更しない
            document = Nothing
            word.Quit()
            word = Nothing

            Return SaveFileName.ToString
        Else
            Return ""
        End If

    End Function
    ''' <summary>
    ''' 既存WORD文書を編集し別名ファイルにする
    ''' </summary>
    ''' <param name="Data"></param>
    ''' <param name="MasterDoc"></param>
    ''' <param name="SaveFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateWord2Word(Field As ArrayList, Data As ArrayList, MasterDoc As String, SaveFileName As String) As String
        Try
            If MasterDoc <> "" AndAlso File.Exists(MasterDoc) Then
                'マスタ文書からコピーを作成する
                File.Copy(MasterDoc, SaveFileName)

                Dim word As Word.Application = New Word.Application()
                '{DATE}{POST}　{ADDRESS}{COMPANY} {POSITION} {NAME}様{TEL}{FAX}
                'Word の GUI を起動しないようにする
                word.Visible = False

                ' 既存文書を開く
                Dim document As Document = word.Documents.Open(SaveFileName)
                Dim Ex As String = Path.GetExtension(SaveFileName)

                'Dim C As Integer = 1
                'For Each Itm As String In Data
                '    Call SelectionFind(document, String.Format("<FIELD{0}>", C), Itm)
                '    C += 1
                'Next

                For i As Integer = 0 To Field.Count - 1
                    Call SelectionFind(document, String.Format("<{0}>", Field(i)), Data(i))
                Next
                document.Close()
                document = Nothing
                word.Quit()
                word = Nothing

                Return SaveFileName.ToString
            Else
                Return ""
            End If

        Catch ex As Exception
            Return ""
        End Try

    End Function
    ''' <summary>
    ''' 所定文字列を置き換える
    ''' </summary>
    ''' <param name="document">対象DOCUMENTオブジェクト</param>
    ''' <param name="MasterText">置き換え対象文字列</param>
    ''' <param name="RepText">置き換える文字列</param>
    ''' <remarks></remarks>
    Private Sub SelectionFind(document As Document, MasterText As String, RepText As String)
        Try
            For Each section As Section In document.Sections
                Dim FindObject As Word.Find = section.Range.Find
                With FindObject
                    .ClearFormatting()
                    .Text = MasterText
                    .Replacement.ClearFormatting()
                    .Replacement.Text = RepText
                    .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                End With
            Next

        Catch ex As Exception

        End Try
    End Sub
End Module
