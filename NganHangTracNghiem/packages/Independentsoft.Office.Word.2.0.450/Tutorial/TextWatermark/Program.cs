using System;
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
            shapeTemplate.EdgePath = "m@7,l@8,m@5,21600l@6,21600e";
            shapeTemplate.AdjustmentParameters = "10800";

            Formula formula1 = new Formula();
            formula1.Equation = "sum #0 0 10800";

            Formula formula2 = new Formula();
            formula2.Equation = "prod #0 2 1";

            Formula formula3 = new Formula();
            formula3.Equation = "sum 21600 0 @1";

            Formula formula4 = new Formula();
            formula4.Equation = "sum 0 0 @2";

            Formula formula5 = new Formula();
            formula5.Equation = "sum 21600 0 @3";

            Formula formula6 = new Formula();
            formula6.Equation = "if @0 @3 0";

            Formula formula7 = new Formula();
            formula7.Equation = "if @0 21600 @1";

            Formula formula8 = new Formula();
            formula8.Equation = "if @0 0 @2";

            Formula formula9 = new Formula();
            formula9.Equation = "if @0 @4 21600";

            Formula formula10 = new Formula();
            formula10.Equation = "mid @5 @6";

            Formula formula11 = new Formula();
            formula11.Equation = "mid @8 @5";

            Formula formula12 = new Formula();
            formula12.Equation = "mid @7 @8";

            Formula formula13 = new Formula();
            formula13.Equation = "mid @6 @7";

            Formula formula14 = new Formula();
            formula14.Equation = "sum @6 0 @5";

            FormulaSet formulas = new FormulaSet();
            formulas.Formulas.Add(formula1);
            formulas.Formulas.Add(formula2);
            formulas.Formulas.Add(formula3);
            formulas.Formulas.Add(formula4);
            formulas.Formulas.Add(formula5);
            formulas.Formulas.Add(formula6);
            formulas.Formulas.Add(formula7);
            formulas.Formulas.Add(formula8);
            formulas.Formulas.Add(formula9);
            formulas.Formulas.Add(formula10);
            formulas.Formulas.Add(formula11);
            formulas.Formulas.Add(formula12);
            formulas.Formulas.Add(formula13);
            formulas.Formulas.Add(formula14);

            shapeTemplate.Content.Add(formulas);

            ShapePath path = new ShapePath();
            path.EnableGradient = true;
            path.ConnectionPointType = ConnectType.Custom;
            path.ConnectionPointConnectAngles = "270,180,90,0";
            path.ConnectionPoint = "@9,0;@10,10800;@11,21600;@12,10800";
            path.DisplayTextPath = true;


            TextPath textPath = new TextPath();
            textPath.FitPath = true;
            textPath.Display = true;

            Lock locking = new Lock();
            locking.AutoShapeType = true;
            locking.Text = true;
            locking.ExtensionHandlingBehavior = ExtensionHandlingBehavior.Editable;

            shapeTemplate.Content.Add(path);
            shapeTemplate.Content.Add(textPath);
            shapeTemplate.Content.Add(locking);

            ShapeStyle style = new ShapeStyle();
            style.Position = Position.Absolute;
            style.LeftMargin = "0";
            style.TopMargin = "0";
            style.Width = "412pt";
            style.Height = "247pt";
            style.Rotation = "315";
            style.HorizontalPosition = HorizontalPosition.Center;
            style.RelativeHorizontalPosition = RelativeHorizontalPosition.Margin;
            style.VerticalPosition = VerticalPosition.Center;
            style.RelativeVerticalPosition =RelativeVerticalPosition.Margin;

            Shape shape = new Shape();
            shape.ID = "Object123";
            shape.Style = style;

            ShapeStyle textStyle = new ShapeStyle();
            textStyle.FontFamily = "Calibri";
            textStyle.FontSize = "1pt";

            TextPath textPath2 = new TextPath();
            textPath2.Text = "DRAFT";
            textPath2.Style = textStyle;
            shape.Content.Add(textPath2);

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
