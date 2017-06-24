Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Sections

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument

        Dim margins As PageMargins = New PageMargins
        margins.Bottom = 1440 '1 inch
        margins.Left = 1440 '1 inch
        margins.Right = 1440 '1 inch
        margins.Top = 1440 '1 inch
        margins.Footer = 720 '1/2 inch
        margins.Header = 720 '1/2 inch

        Dim section As Section = New Section
        section.PageSize = New PageSize(12240, 15840) '8.5 x 11 in
        section.PageMargins = margins

        doc.Body.Section = section

        Dim run As Run = New Run
        run.AddText("Page size is 8.5 x 11 in (Letter).")

        Dim paragraph As Paragraph = New Paragraph
        paragraph.Add(run)

        doc.Body.Add(paragraph)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module