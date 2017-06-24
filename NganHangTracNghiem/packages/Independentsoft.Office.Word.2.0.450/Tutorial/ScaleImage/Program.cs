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

            Picture picture = new Picture("c:\\test\\image1.png");

            Unit pictureWidth = new Unit(180, UnitType.Pixel);
            Unit pictureHeight = new Unit(240, UnitType.Pixel);

            Offset offset = new Offset(0, 0);
            Extents extents = new Extents(pictureWidth, pictureHeight);

            picture.ShapeProperties.PresetGeometry = new PresetGeometry(ShapeType.Rectangle);
            picture.ShapeProperties.Transform2D = new Transform2D(offset, extents);
            picture.ID = "1";
            picture.Name = "image1.png";

            Stretch stretch = new Stretch(); //important to scale image
            stretch.FillRectangle = new FillRectangle();
            picture.Stretch = stretch;

            Inline inline = new Inline(picture);
            inline.Size = new DrawingObjectSize(pictureWidth, pictureHeight);
            inline.ID = "1";
            inline.Name = "Picture 1";
            inline.Description = "image1.png";

            DrawingObject drawingObject = new DrawingObject(inline);

            Run imageRun = new Run();
            imageRun.Add(drawingObject);

            Paragraph imageParagraph = new Paragraph();
            imageParagraph.Add(imageRun);

            doc.Body.Add(imageParagraph);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
