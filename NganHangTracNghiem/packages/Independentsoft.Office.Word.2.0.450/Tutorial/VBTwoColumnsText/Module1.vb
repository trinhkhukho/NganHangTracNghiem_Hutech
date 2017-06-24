Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Fields
Imports Independentsoft.Office.Word.Sections
Imports Independentsoft.Office.Word.HeaderFooter

''' <summary>
''' Set two columns on the section1 with space 720. Set own header/footer for the section and assign page numbers
''' </summary>
''' <remarks></remarks>
Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument()

        ''section
        Dim section1 As Section = New Section()
        section1.PageNumberingSettings.FirstPageNumber = 1

        section1.Columns = New ColumnDefinitions()
        section1.Columns.Space = 720
        section1.Columns.EqualWidthColumnsCount = 2

        ''page numbers in footer
        Dim pageNumber1 As Page = New Page()
        Dim simpleField1 As SimpleField = New SimpleField(pageNumber1)

        Dim footerParagraph1 As Paragraph = New Paragraph()
        footerParagraph1.Add(simpleField1)
        footerParagraph1.HorizontalTextAlignment = HorizontalAlignmentType.Center

        Dim footer1 As Footer = New Footer()
        footer1.Add(footerParagraph1)

        section1.Footer = footer1
        ''end page numbers

        Dim run1 As Run = New Run()
        run1.AddText("Some text ...")

        Dim run2 As Run = New Run()
        run2.AddText("Additional text ...")

        Dim paragraph1 As Paragraph = New Paragraph()
        paragraph1.Add(run1)

        Dim paragraph2 As Paragraph = New Paragraph()
        paragraph2.Add(run2)
        paragraph2.PageBreakBefore = ExtendedBoolean.True

        Dim paragraph3 As Paragraph = New Paragraph()
        paragraph3.Add(run1)
        paragraph3.Section = section1 ''last paragraph in this section

        doc.Body.Add(paragraph1)
        doc.Body.Add(paragraph2)
        doc.Body.Add(paragraph3)

        Dim paragraph4 As Paragraph = New Paragraph()
        paragraph4.Add(run2)

        doc.Body.Add(paragraph4)

        ''new section, new footer
        Dim section2 As Section = New Section()
        section2.PageNumberingSettings.FirstPageNumber = 2

        ''page numbers in footer
        Dim pageNumber2 As Page = New Page()
        Dim simpleField2 As SimpleField = New SimpleField(pageNumber2)

        Dim footerParagraph2 As Paragraph = New Paragraph()
        footerParagraph2.Add(simpleField2)
        footerParagraph2.HorizontalTextAlignment = HorizontalAlignmentType.Center

        Dim footer2 As Footer = New Footer()
        footer2.Add(footerParagraph2)

        section2.Footer = footer2

        Dim run21 As Run = New Run()
        run21.AddText("New section text ...")

        Dim run22 As Run = New Run()
        run22.AddText("Additional text in new section ...")

        Dim paragraph21 As Paragraph = New Paragraph()
        paragraph21.Add(run21)

        Dim paragraph22 As Paragraph = New Paragraph()
        paragraph22.Add(run22)
        paragraph22.PageBreakBefore = ExtendedBoolean.True

        Dim paragraph23 As Paragraph = New Paragraph()
        paragraph23.Add(run21)
        paragraph23.Section = section2 ''last paragraph in new section

        doc.Body.Add(paragraph21)
        doc.Body.Add(paragraph22)
        doc.Body.Add(paragraph23)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module