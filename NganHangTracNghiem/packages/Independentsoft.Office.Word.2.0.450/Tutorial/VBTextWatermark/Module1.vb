Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Vml
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Sections
Imports Independentsoft.Office.Word.HeaderFooter

Module Module1
    Sub Main(ByVal args() As String)


        Dim doc As New WordDocument()

        Dim shapeTemplate As New ShapeTemplate()
        shapeTemplate.CoordinateSpaceSize = "21600,21600"
        shapeTemplate.EdgePath = "m@7,l@8,m@5,21600l@6,21600e"
        shapeTemplate.AdjustmentParameters = "10800"

        Dim formula1 As New Formula()
        formula1.Equation = "sum #0 0 10800"

        Dim formula2 As New Formula()
        formula2.Equation = "prod #0 2 1"

        Dim formula3 As New Formula()
        formula3.Equation = "sum 21600 0 @1"

        Dim formula4 As New Formula()
        formula4.Equation = "sum 0 0 @2"

        Dim formula5 As New Formula()
        formula5.Equation = "sum 21600 0 @3"

        Dim formula6 As New Formula()
        formula6.Equation = "if @0 @3 0"

        Dim formula7 As New Formula()
        formula7.Equation = "if @0 21600 @1"

        Dim formula8 As New Formula()
        formula8.Equation = "if @0 0 @2"

        Dim formula9 As New Formula()
        formula9.Equation = "if @0 @4 21600"

        Dim formula10 As New Formula()
        formula10.Equation = "mid @5 @6"

        Dim formula11 As New Formula()
        formula11.Equation = "mid @8 @5"

        Dim formula12 As New Formula()
        formula12.Equation = "mid @7 @8"

        Dim formula13 As New Formula()
        formula13.Equation = "mid @6 @7"

        Dim formula14 As New Formula()
        formula14.Equation = "sum @6 0 @5"

        Dim formulas As New FormulaSet()
        formulas.Formulas.Add(formula1)
        formulas.Formulas.Add(formula2)
        formulas.Formulas.Add(formula3)
        formulas.Formulas.Add(formula4)
        formulas.Formulas.Add(formula5)
        formulas.Formulas.Add(formula6)
        formulas.Formulas.Add(formula7)
        formulas.Formulas.Add(formula8)
        formulas.Formulas.Add(formula9)
        formulas.Formulas.Add(formula10)
        formulas.Formulas.Add(formula11)
        formulas.Formulas.Add(formula12)
        formulas.Formulas.Add(formula13)
        formulas.Formulas.Add(formula14)

        shapeTemplate.Content.Add(formulas)

        Dim path As New ShapePath()
        path.EnableGradient = True
        path.ConnectionPointType = ConnectType.[Custom]
        path.ConnectionPointConnectAngles = "270,180,90,0"
        path.ConnectionPoint = "@9,0;@10,10800;@11,21600;@12,10800"
        path.DisplayTextPath = True


        Dim textPath As New TextPath()
        textPath.FitPath = True
        textPath.Display = True

        Dim locking As New Lock()
        locking.AutoShapeType = True
        locking.Text = True
        locking.ExtensionHandlingBehavior = ExtensionHandlingBehavior.Editable

        shapeTemplate.Content.Add(path)
        shapeTemplate.Content.Add(textPath)
        shapeTemplate.Content.Add(locking)

        Dim style As New ShapeStyle()
        style.Position = Position.Absolute
        style.LeftMargin = "0"
        style.TopMargin = "0"
        style.Width = "412pt"
        style.Height = "247pt"
        style.Rotation = "315"
        style.HorizontalPosition = HorizontalPosition.Center
        style.RelativeHorizontalPosition = RelativeHorizontalPosition.Margin
        style.VerticalPosition = VerticalPosition.Center
        style.RelativeVerticalPosition = RelativeVerticalPosition.Margin

        Dim shape As New Shape()
        shape.ID = "Object123"
        shape.Style = style

        Dim textStyle As New ShapeStyle()
        textStyle.FontFamily = "Calibri"
        textStyle.FontSize = "1pt"

        Dim textPath2 As New TextPath()
        textPath2.Text = "DRAFT"
        textPath2.Style = textStyle
        shape.Content.Add(textPath2)

        Dim vmlObject As New VmlObject()
        vmlObject.Content.Add(shapeTemplate)
        vmlObject.Content.Add(shape)

        Dim headerRun As New Run()
        headerRun.Add(vmlObject)

        Dim headerParagraph As New Paragraph()
        headerParagraph.Add(headerRun)

        Dim header As New Header()
        header.Add(headerParagraph)

        Dim section As New Section()
        section.PageSize = New PageSize(12240, 15840)
        '8.5 x 11 in
        section.Header = header

        doc.Body.Section = section

        Dim run As New Run()
        run.AddText("Hello Word!")

        Dim paragraph As New Paragraph()
        paragraph.Add(run)

        doc.Body.Add(paragraph)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module