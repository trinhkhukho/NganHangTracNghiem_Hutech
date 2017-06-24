Imports System
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim commentRun As Run = New Run
        commentRun.AddText("Comment text.")

        Dim commentParagraph As Paragraph = New Paragraph
        commentParagraph.Add(commentRun)

        Dim comment1 As Comment = New Comment(1)
        comment1.Author = "Joe Smith"
        comment1.Date = DateTime.Now
        comment1.Initials = "JS"
        comment1.Add(commentParagraph)

        Dim commentStart As CommentRangeStart = New CommentRangeStart(1)
        Dim commentEnd As CommentRangeEnd = New CommentRangeEnd(1)
        Dim commentReference As CommentReference = New CommentReference(1)

        Dim commentReferenceRun As Run = New Run
        commentReferenceRun.Add(commentReference)

        Dim run1 As Run = New Run
        run1.AddText("Hello ")

        Dim run2 As Run = New Run
        run2.AddText("Word")

        Dim run3 As Run = New Run
        run3.AddText(".")

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add(run1)
        paragraph1.Add(commentStart)
        paragraph1.Add(run2)
        paragraph1.Add(commentEnd)
        paragraph1.Add(commentReferenceRun)
        paragraph1.Add(run3)

        doc.Body.Add(paragraph1)
        doc.Comments.Add(comment1)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module