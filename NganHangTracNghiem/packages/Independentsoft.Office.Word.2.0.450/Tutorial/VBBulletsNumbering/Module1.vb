Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Numbering

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument

        Dim level0 As New NumberingLevel()
        level0.Level = 0
        level0.Start = 1
        level0.Justification = HorizontalAlignmentType.Left
        level0.Format = NumberingFormat.Bullet
        level0.RunProperties.Fonts.AsciiFont = "Wingdings"
        level0.RunProperties.Fonts.HighAnsiFont = "Wingdings"

        Dim bulletBuffer As Byte() = New Byte(2) {}
        bulletBuffer(0) = CByte(239)
        bulletBuffer(1) = CByte(130)
        bulletBuffer(2) = CByte(167)

        level0.Text = New NumberingLevelText(System.Text.Encoding.UTF8.GetString(bulletBuffer))

        Dim abstractNumbering As New AbstractNumbering()
        abstractNumbering.ID = 1
        abstractNumbering.Levels.Add(level0)

        Dim numbering1 As New NumberingReference(2)
        numbering1.NumberingLevelID = 0
        numbering1.NumberingID = 1

        Dim numberingInstance As New NumberingDefinitionInstance()
        numberingInstance.ID = 1
        numberingInstance.AbstractNumberingID = 1

        Dim numberingDefinitions As New NumberingDefinitions()
        numberingDefinitions.Numberings.Add(numberingInstance)
        numberingDefinitions.AbstractNumberings.Add(abstractNumbering)

        doc.NumberingDefinitions = numberingDefinitions

        Dim run1 As New Run()
        run1.AddText("First")

        Dim run2 As New Run()
        run2.AddText("Second")

        Dim run3 As New Run()
        run3.AddText("Third")

        Dim paragraph1 As New Paragraph()
        paragraph1.Add(run1)
        paragraph1.NumberingReference = numbering1

        Dim paragraph2 As New Paragraph()
        paragraph2.Add(run2)
        paragraph2.NumberingReference = numbering1

        Dim paragraph3 As New Paragraph()
        paragraph3.Add(run3)
        paragraph3.NumberingReference = numbering1

        doc.Body.Add(paragraph1)
        doc.Body.Add(paragraph2)
        doc.Body.Add(paragraph3)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module
