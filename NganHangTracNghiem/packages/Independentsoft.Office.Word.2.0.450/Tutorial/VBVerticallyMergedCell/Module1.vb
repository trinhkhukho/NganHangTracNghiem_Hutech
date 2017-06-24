Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Tables

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument()

        Dim tableGrid As TableGrid = New TableGrid()
        tableGrid.Columns.Add(New TableGridColumn(498))
        tableGrid.Columns.Add(New TableGridColumn(2392))
        tableGrid.Columns.Add(New TableGridColumn(3600))
        tableGrid.Columns.Add(New TableGridColumn(1800))
        tableGrid.Columns.Add(New TableGridColumn(1186))

        Dim cell11 As Cell = New Cell()
        cell11.VerticallyMergedCell = New VerticallyMergedCell()
        cell11.VerticallyMergedCell.Type = MergeCellType.Restart
        cell11.Width = New Width(TableWidthUnit.Point, 498)

        Dim cell12 As Cell = New Cell()
        cell12.Width = New Width(TableWidthUnit.Point, 2392)

        Dim cell13 As Cell = New Cell()
        cell13.Width = New Width(TableWidthUnit.Point, 3600)

        Dim cell14 As Cell = New Cell()
        cell14.Width = New Width(TableWidthUnit.Point, 1800)

        Dim cell15 As Cell = New Cell()
        cell15.Width = New Width(TableWidthUnit.Point, 1186)

        Dim row1 As Row = New Row()
        row1.Add(cell11)
        row1.Add(cell12)
        row1.Add(cell13)
        row1.Add(cell14)
        row1.Add(cell15)

        Dim cell21 As Cell = New Cell()
        cell21.VerticallyMergedCell = New VerticallyMergedCell()
        cell21.Width = New Width(TableWidthUnit.Point, 498)

        Dim cell22 As Cell = New Cell()
        cell22.GridSpan = 4
        cell22.Width = New Width(TableWidthUnit.Point, 8978)

        Dim row2 As Row = New Row()
        row2.Add(cell21)
        row2.Add(cell22)

        Dim table1 As Table = New Table(StandardBorderStyle.SingleLine)
        table1.Grid = tableGrid
        table1.Add(row1)
        table1.Add(row2)

        doc.Body.Add(table1)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module