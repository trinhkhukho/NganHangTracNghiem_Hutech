Imports System
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim run As Run = New Run()
        run.AddText("Hello Word!")

        Dim paragraph As Paragraph = New Paragraph()
        paragraph.Add(run)

        doc.Body.Add(paragraph)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module