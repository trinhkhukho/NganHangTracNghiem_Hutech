using System;
using Independentsoft.Office.Vml;
using Independentsoft.Office.Word;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Run textBoxRun = new Run();
            textBoxRun.AddText("Simple text inside a textbox");

            Paragraph textBoxParagraph = new Paragraph();
            textBoxParagraph.Add(textBoxRun);

            TextBox textBox = new TextBox();
            textBox.Content.Add(textBoxParagraph);

            ShapeTemplate shapeTemplate = new ShapeTemplate();
            shapeTemplate.CoordinateSpaceSize = "21600,21600";
            shapeTemplate.EdgePath = "m,l,21600r21600,l21600,xe";
            shapeTemplate.PreferRelativeResize = true;

            Stroke stroke = new Stroke();
            stroke.JoinStyle = StrokeJoinStyle.Miter;

            ShapePath path = new ShapePath();
            path.EnableGradient = true;
            path.ConnectionPointType = ConnectType.Four;
            
            shapeTemplate.Content.Add(stroke);
            shapeTemplate.Content.Add(path);

            Independentsoft.Office.Vml.Shape shape = new Independentsoft.Office.Vml.Shape();
            shape.Style = new Independentsoft.Office.Vml.ShapeStyle();
            shape.Style.Position = Position.Absolute;
            shape.Style.LeftMargin = "0";
            shape.Style.TopMargin = "0";
            shape.Style.Width = "200pt";
            shape.Style.Height = "195pt";
            shape.Style.HorizontalPosition = HorizontalPosition.Center;
            shape.Style.RelativeHorizontalPosition = RelativeHorizontalPosition.Margin;
            shape.Style.VerticalPosition = VerticalPosition.Center;
            shape.Style.RelativeVerticalPosition = RelativeVerticalPosition.Margin;
            shape.FillColor = "yellow";
            shape.Content.Add(textBox);
            
            VmlObject vmlObject = new VmlObject();
            vmlObject.Content.Add(shapeTemplate);
            vmlObject.Content.Add(shape);

            Run run1 = new Run();
            run1.Add(vmlObject);

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);

            doc.Body.Add(paragraph1);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
