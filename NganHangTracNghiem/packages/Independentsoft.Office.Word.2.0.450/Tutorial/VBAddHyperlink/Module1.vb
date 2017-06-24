Imports System
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim run As Run = New Run()
        run.AddText("Independentsoft")
        run.Underline = New Underline(UnderlinePattern.Single)

        run.Color = New RunContentColor("#0000FF")

        Dim link As Hyperlink = New Hyperlink()
        link.Add(run)
        link.Target = "http://www.independentsoft.com"

        Dim paragraph As Paragraph = New Paragraph()
        paragraph.Add(link)

        doc.Body.Add(paragraph)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module