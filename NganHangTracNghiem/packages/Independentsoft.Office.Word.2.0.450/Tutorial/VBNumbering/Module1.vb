Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Numbering

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim numbering1 As NumberingReference = New NumberingReference(1)

        Dim numbering2 As NumberingReference = New NumberingReference(1)
        numbering2.NumberingLevelID = 2

        Dim run1 As Run = New Run()
        run1.AddText("First")

        Dim run2 As Run = New Run()
        run2.AddText("Second")

        Dim run3 As Run = New Run()
        run3.AddText("Third")

        Dim paragraph1 As Paragraph = New Paragraph()
        paragraph1.Add(run1)
        paragraph1.NumberingReference = numbering1

        Dim paragraph2 As Paragraph = New Paragraph()
        paragraph2.Add(run2)
        paragraph2.NumberingReference = numbering1

        Dim paragraph3 As Paragraph = New Paragraph()
        paragraph3.Add(run3)
        paragraph3.NumberingReference = numbering1

        Dim paragraph4 As Paragraph = New Paragraph()
        paragraph4.Add(run1)
        paragraph4.NumberingReference = numbering2

        Dim paragraph5 As Paragraph = New Paragraph()
        paragraph5.Add(run2)
        paragraph5.NumberingReference = numbering2

        Dim paragraph6 As Paragraph = New Paragraph()
        paragraph6.Add(run3)
        paragraph6.NumberingReference = numbering2

        doc.Body.Add(paragraph1)
        doc.Body.Add(paragraph2)
        doc.Body.Add(paragraph3)
        doc.Body.Add(paragraph4)
        doc.Body.Add(paragraph5)
        doc.Body.Add(paragraph6)

        doc.Save("c:\test\input.docx", True)

    End Sub
End Module