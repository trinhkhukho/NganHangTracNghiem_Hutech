using System;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Tables;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            TableGrid tableGrid = new TableGrid();
            tableGrid.Columns.Add(new TableGridColumn(498));
            tableGrid.Columns.Add(new TableGridColumn(2392));
            tableGrid.Columns.Add(new TableGridColumn(3600));
            tableGrid.Columns.Add(new TableGridColumn(1800));
            tableGrid.Columns.Add(new TableGridColumn(1186));

            Cell cell11 = new Cell();
            cell11.VerticallyMergedCell = new VerticallyMergedCell();
            cell11.VerticallyMergedCell.Type = MergeCellType.Restart;
            cell11.Width = new Width(TableWidthUnit.Point, 498);

            Cell cell12 = new Cell();
            cell12.Width = new Width(TableWidthUnit.Point, 2392);

            Cell cell13 = new Cell();
            cell13.Width = new Width(TableWidthUnit.Point, 3600);

            Cell cell14 = new Cell();
            cell14.Width = new Width(TableWidthUnit.Point, 1800);

            Cell cell15 = new Cell();
            cell15.Width = new Width(TableWidthUnit.Point, 1186);

            Row row1 = new Row();
            row1.Add(cell11);
            row1.Add(cell12);
            row1.Add(cell13);
            row1.Add(cell14);
            row1.Add(cell15);

            Cell cell21 = new Cell();
            cell21.VerticallyMergedCell = new VerticallyMergedCell();
            cell21.Width = new Width(TableWidthUnit.Point, 498);

            Cell cell22 = new Cell();
            cell22.GridSpan = 4;
            cell22.Width = new Width(TableWidthUnit.Point, 8978);

            Row row2 = new Row();
            row2.Add(cell21);
            row2.Add(cell22);

            Table table1 = new Table(StandardBorderStyle.SingleLine);
            table1.Grid = tableGrid;
            table1.Add(row1);
            table1.Add(row2);

            doc.Body.Add(table1);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
