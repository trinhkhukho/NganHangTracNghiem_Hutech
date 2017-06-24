Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Tables

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument

        Dim run1 As Run = New Run
        run1.AddText("Below is one table with 5 rows and 3 columns.")

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add(run1)

        Dim cell1 As Cell = New Cell

        Dim row1 As Row = New Row
        row1.Add(cell1)
        row1.Add(cell1)
        row1.Add(cell1)

        Dim table1 As Table = New Table(StandardBorderStyle.SingleLine)
        table1.Width = New Width(TableWidthUnit.Percent, 100)

        table1.Add(row1)
        table1.Add(row1)
        table1.Add(row1)
        table1.Add(row1)
        table1.Add(row1)

        doc.Body.Add(paragraph1)
        doc.Body.Add(table1)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module
