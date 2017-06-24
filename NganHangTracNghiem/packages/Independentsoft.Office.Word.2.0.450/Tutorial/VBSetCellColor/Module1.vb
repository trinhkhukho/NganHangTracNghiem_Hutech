Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Tables

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New WordDocument()

        Dim run1 As New Run("Quantity")
        run1.Bold = ExtendedBoolean.[True]

        Dim paragraph1 As New Paragraph()
        paragraph1.Add(run1)

        Dim run2 As New Run("Item #")
        run2.Bold = ExtendedBoolean.[True]

        Dim paragraph2 As New Paragraph()
        paragraph2.Add(run2)

        Dim run3 As New Run("Description")
        run3.Bold = ExtendedBoolean.[True]

        Dim paragraph3 As New Paragraph()
        paragraph3.Add(run3)

        Dim run4 As New Run("Unit Price")
        run4.Bold = ExtendedBoolean.[True]

        Dim paragraph4 As New Paragraph()
        paragraph4.Add(run4)

        Dim run5 As New Run("Line Total")
        run5.Bold = ExtendedBoolean.[True]

        Dim paragraph5 As New Paragraph()
        paragraph5.Add(run5)

        Dim cell1Shading As New Shading(ShadingPattern.Percent10)
        cell1Shading.BackgroundColor = "#FF0000"
        'red color
        Dim cell1 As New Cell()
        cell1.Width = New Width(TableWidthUnit.Point, 1260)
        cell1.Shading = cell1Shading
        cell1.Add(paragraph1)

        Dim cell2 As New Cell()
        cell2.Width = New Width(TableWidthUnit.Point, 1440)
        cell2.Shading = New Shading(ShadingPattern.Percent10)
        cell2.Add(paragraph2)

        Dim cell3 As New Cell()
        cell3.Width = New Width(TableWidthUnit.Point, 4140)
        cell3.Shading = New Shading(ShadingPattern.Percent10)
        cell3.Add(paragraph3)

        Dim cell4 As New Cell()
        cell4.Width = New Width(TableWidthUnit.Point, 1620)
        cell4.Shading = New Shading(ShadingPattern.Percent10)
        cell4.Add(paragraph4)

        Dim cell5 As New Cell()
        cell5.Width = New Width(TableWidthUnit.Point, 1620)
        cell5.Shading = New Shading(ShadingPattern.Percent10)
        cell5.Add(paragraph5)

        Dim firstRow As New Row()
        firstRow.Add(cell1)
        firstRow.Add(cell2)
        firstRow.Add(cell3)
        firstRow.Add(cell4)
        firstRow.Add(cell5)

        Dim row1 As New Row()
        row1.Add(New Cell())
        row1.Add(New Cell())
        row1.Add(New Cell())
        row1.Add(New Cell())
        row1.Add(New Cell())

        Dim table1 As New Table(StandardBorderStyle.SingleLine)

        table1.Add(firstRow)
        table1.Add(row1)
        table1.Add(row1)
        table1.Add(row1)
        table1.Add(row1)
        table1.Add(row1)
        table1.Add(row1)
        table1.Add(row1)
        table1.Add(row1)
        table1.Add(row1)
        table1.Add(row1)

        doc.Body.Add(table1)

        doc.Save("c:\test\output.docx", True)
    End Sub
End Module
