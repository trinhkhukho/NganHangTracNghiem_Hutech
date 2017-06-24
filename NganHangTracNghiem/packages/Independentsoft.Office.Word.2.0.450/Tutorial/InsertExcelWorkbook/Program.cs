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
            
            EmbeddedObject embeddedObject = new EmbeddedObject();

            ShapeStyle imageShapeStyle = new ShapeStyle();
            imageShapeStyle.Width = "76pt";
            imageShapeStyle.Height = "48pt";

            Shape imageShape = new Shape();
            imageShape.ID = "Shape1";
            imageShape.Style = imageShapeStyle;

            Image image = new Image("c:\\test\\image1.emf"); //excel icon
            image.Title = "image1"; //important

            imageShape.Content.Add(image);

            EmbeddedOleObject oleObject = new EmbeddedOleObject("c:\\test\\workbook.xlsx");
            oleObject.Type = OleType.EmbeddedObject;
            oleObject.Application = "Excel.Sheet.12";
            oleObject.ShapeID = "Shape1";
            oleObject.DrawAspect = OleDrawAspect.Icon;
            oleObject.ObjectID = "123";

            embeddedObject.Content.Add(imageShape);
            embeddedObject.Content.Add(oleObject);

            Run run1 = new Run();
            run1.Add(embeddedObject);

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);

            doc.Body.Add(paragraph1);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
