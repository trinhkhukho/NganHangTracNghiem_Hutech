Imports System
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument

        Dim run1 As Run = New Run
        run1.AddText("[Your Name]")
        run1.AddCarriageReturn()
        run1.AddText("[Street Address]")
        run1.AddCarriageReturn()
        run1.AddText("[City, ST ZIP Code]")
        run1.AddCarriageReturn()
        run1.AddText("September 25, 2006")
        run1.FontSize = 24 '12 points

        Dim run2 As Run = New Run
        run2.AddText("[Recipient Name]")
        run2.AddCarriageReturn()
        run2.AddText("[Title]")
        run2.AddCarriageReturn()
        run2.AddText("[Company Name]")
        run2.AddCarriageReturn()
        run2.AddText("[Street Address]")
        run2.AddCarriageReturn()
        run2.AddText("[City, ST ZIP Code]")
        run2.FontSize = 24 '12 points

        Dim run3 As Run = New Run
        run3.AddText("Dear [Recipient Name]")
        run3.FontSize = 24 '12 points

        Dim run4 As Run = New Run
        run4.AddText("Due to an oversight on our part, this month’s payment, in the amount of $[__] and due on [date], was mailed just today. Our account number is [account number]. Please forgive our inattention. If you have any questions, please contact me at [phone number].")
        run4.FontSize = 24 '12 points

        Dim run5 As Run = New Run
        run5.AddText("Sincerely,")
        run5.FontSize = 24 '12 points

        Dim run6 As Run = New Run
        run6.AddText("[Your Name]")
        run6.AddCarriageReturn()
        run6.AddText("[Title]")
        run6.FontSize = 24 '12 points

        Dim emptyParagraph As Paragraph = New Paragraph

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add(run1)

        Dim paragraph2 As Paragraph = New Paragraph
        paragraph2.Add(run2)

        Dim paragraph3 As Paragraph = New Paragraph
        paragraph3.Add(run3)

        Dim paragraph4 As Paragraph = New Paragraph
        paragraph4.Add(run4)

        Dim paragraph5 As Paragraph = New Paragraph
        paragraph5.Add(run5)

        Dim paragraph6 As Paragraph = New Paragraph
        paragraph6.Add(run6)

        doc.Body.Add(paragraph1)
        doc.Body.Add(emptyParagraph)
        doc.Body.Add(paragraph2)
        doc.Body.Add(emptyParagraph)
        doc.Body.Add(paragraph3)
        doc.Body.Add(paragraph4)
        doc.Body.Add(paragraph5)
        doc.Body.Add(emptyParagraph)
        doc.Body.Add(paragraph6)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module
