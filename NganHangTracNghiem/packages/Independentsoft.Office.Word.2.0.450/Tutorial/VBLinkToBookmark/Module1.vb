Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Tables

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New WordDocument()

        Dim startBookmark1 As New BookmarkStart()
        startBookmark1.Name = "bookmark1"
        startBookmark1.ID = 1

        Dim endBookmark1 As New BookmarkEnd()
        endBookmark1.ID = 1

        Dim bookmarkParagraph As New Paragraph()
        bookmarkParagraph.Add(startBookmark1)
        bookmarkParagraph.Add(endBookmark1)
        bookmarkParagraph.Add(New Run("Just test"))


        Dim run As New Run()
        run.AddText("ClickMeLink")
        run.Underline = New Underline(UnderlinePattern.[Single])
        run.Color = New Independentsoft.Office.Word.RunContentColor("#008000")

        Dim link As New Hyperlink()
        link.Add(run)
        link.Anchor = "bookmark1"

        Dim paragraph As New Paragraph()
        paragraph.Add(link)

        doc.Body.Add(paragraph)
        doc.Body.Add(New Paragraph()) 'empty paragraph
        doc.Body.Add(New Paragraph()) 'empty paragraph
        doc.Body.Add(New Paragraph()) 'empty paragraph
        doc.Body.Add(New Paragraph()) 'empty paragraph
        doc.Body.Add(New Paragraph()) 'empty paragraph
        doc.Body.Add(bookmarkParagraph)

        doc.Save("c:\test\output.docx", True)
    End Sub
End Module
