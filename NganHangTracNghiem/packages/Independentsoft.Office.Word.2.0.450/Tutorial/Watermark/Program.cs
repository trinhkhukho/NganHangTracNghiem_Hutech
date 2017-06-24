using System;
using System.IO;
using Independentsoft.Office;
using Independentsoft.Office.Vml;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Sections;
using Independentsoft.Office.Word.HeaderFooter;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            ShapeTemplate shapeTemplate = new ShapeTemplate();
            shapeTemplate.CoordinateSpaceSize = "21600,21600";
            shapeTemplate.EdgePath = "m@4@5l@4@11@9@11@9@5xe";
            shapeTemplate.PreferRelativeResize = true;

            Stroke stroke = new Stroke();
            stroke.JoinStyle = StrokeJoinStyle.Miter;

            ShapePath path = new ShapePath();
            path.EnableGradient = true;
            path.ConnectionPointType = ConnectType.Four;

            Lock locking = new Lock();
            locking.AspectRatio = true;

            shapeTemplate.Content.Add(stroke);
            shapeTemplate.Content.Add(path);
            shapeTemplate.Content.Add(locking);

            Shape shape = new Shape();
            shape.Style = new ShapeStyle();
            shape.Style.Position = Position.Absolute;
            shape.Style.LeftMargin = "0";
            shape.Style.TopMargin = "0";
            shape.Style.Width = "467.5pt";
            shape.Style.Height = "374pt";
            shape.Style.HorizontalPosition = HorizontalPosition.Center;
            shape.Style.RelativeHorizontalPosition = RelativeHorizontalPosition.Margin;
            shape.Style.VerticalPosition = VerticalPosition.Center;
            shape.Style.RelativeVerticalPosition = RelativeVerticalPosition.Margin;

            Image image = new Image("c:\\test\\draft.png");
            shape.Content.Add(image);

            VmlObject vmlObject = new VmlObject();
            vmlObject.Content.Add(shapeTemplate);
            vmlObject.Content.Add(shape);

            Run headerRun = new Run();
            headerRun.Add(vmlObject);

            Paragraph headerParagraph = new Paragraph();
            headerParagraph.Add(headerRun);

            Header header = new Header();
            header.Add(headerParagraph);

            Section section = new Section();
            section.PageSize = new PageSize(12240, 15840); //8.5 x 11 in
            section.Header = header;

            doc.Body.Section = section;

            Run run = new Run();
            run.AddText("Hello Word!");

            Paragraph paragraph = new Paragraph();
            paragraph.Add(run);

            doc.Body.Add(paragraph);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
