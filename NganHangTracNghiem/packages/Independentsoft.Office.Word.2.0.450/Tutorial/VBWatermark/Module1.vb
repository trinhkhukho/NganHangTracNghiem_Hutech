Imports System
Imports System.IO
Imports Independentsoft.Office
Imports Independentsoft.Office.Vml
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Sections
Imports Independentsoft.Office.Word.HeaderFooter

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As New WordDocument()

        Dim shapeTemplate As New ShapeTemplate()
        shapeTemplate.CoordinateSpaceSize = "21600,21600"
        shapeTemplate.EdgePath = "m@4@5l@4@11@9@11@9@5xe"
        shapeTemplate.PreferRelativeResize = True

        Dim stroke As New Stroke()
        stroke.JoinStyle = StrokeJoinStyle.Miter

        Dim path As New ShapePath()
        path.EnableGradient = True
        path.ConnectionPointType = ConnectType.Four

        Dim locking As New Lock()
        locking.AspectRatio = True

        shapeTemplate.Content.Add(stroke)
        shapeTemplate.Content.Add(path)
        shapeTemplate.Content.Add(locking)

        Dim shape As New Shape()
        shape.Style = New Independentsoft.Office.Vml.ShapeStyle()
        shape.Style.Position = Position.Absolute
        shape.Style.LeftMargin = "0"
        shape.Style.TopMargin = "0"
        shape.Style.Width = "467.5pt"
        shape.Style.Height = "374pt"
        shape.Style.HorizontalPosition = HorizontalPosition.Center
        shape.Style.RelativeHorizontalPosition = RelativeHorizontalPosition.Margin
        shape.Style.VerticalPosition = VerticalPosition.Center
        shape.Style.RelativeVerticalPosition = RelativeVerticalPosition.Margin

        Dim image As New Image("c:\draft.png")
        shape.Content.Add(image)

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
        section.PageSize = New PageSize(12240, 15840) '8.5 x 11 in 
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