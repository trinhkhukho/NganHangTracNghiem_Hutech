using System;
using Independentsoft.Office;
using Independentsoft.Office.Drawing;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Drawing;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Picture picture = new Picture("c:\\test\\image.gif");
            Unit pictureWidth = new Unit(640, UnitType.Pixel);
            Unit pictureHeight = new Unit(480, UnitType.Pixel);

            Offset offset = new Offset(0, 0);
            Extents extents = new Extents(pictureWidth, pictureHeight);

            picture.ShapeProperties.PresetGeometry = new PresetGeometry(ShapeType.Rectangle);
            picture.ShapeProperties.Transform2D = new Transform2D(offset, extents);
            picture.ID = "1";
            picture.Name = "image.gif";

            Anchor anchor = new Anchor(picture);
            anchor.Size = new DrawingObjectSize(pictureWidth, pictureHeight); 
            anchor.ID = "1";
            anchor.Name = "Picture 1";
            anchor.Description = "image.gif";
            anchor.WrapType = new WrapSquare(WrapText.BothSides);
            anchor.SimplePositioningCoordinates = new SimplePositioningCoordinates(0, 0);
            anchor.HorizontalPositioning = new HorizontalPositioning(HorizontalRelativePositioning.Column, 0);

            Unit positionOffset = new Unit(1, UnitType.Inch);
            anchor.VerticalPositioning = new VerticalPositioning(VerticalRelativePositioning.Paragraph, positionOffset);

            DrawingObject drawingObject = new DrawingObject(anchor);

            Run run1 = new Run();
            run1.AddText("Below is an image:");

            Run run2 = new Run();
            run2.Add(drawingObject);

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);
            paragraph1.Add(run2);

            doc.Body.Add(paragraph1);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
