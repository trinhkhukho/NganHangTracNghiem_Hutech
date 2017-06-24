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

            ShapeStyle shapeStyle = new ShapeStyle();
            shapeStyle.Position = Position.Absolute;
            shapeStyle.Width = "100pt";
            shapeStyle.Height = "75pt";

            Shape shape = new Shape(shapeStyle);
            shape.Content.Add(textBox);

            VmlObject vmlObject = new VmlObject();
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
