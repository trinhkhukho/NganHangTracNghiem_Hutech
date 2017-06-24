Imports System
Imports Independentsoft.Office.Vml
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New WordDocument()

        Dim textBoxRun As New Run()
        textBoxRun.AddText("Simple text inside a textbox")

        Dim textBoxParagraph As New Paragraph()
        textBoxParagraph.Add(textBoxRun)

        Dim textBox As New TextBox()
        textBox.Content.Add(textBoxParagraph)

        Dim shapeTemplate As New ShapeTemplate()
        shapeTemplate.CoordinateSpaceSize = "21600,21600"
        shapeTemplate.EdgePath = "m,l,21600r21600,l21600,xe"
        shapeTemplate.PreferRelativeResize = True

        Dim stroke As New Stroke()
        stroke.JoinStyle = StrokeJoinStyle.Miter

        Dim path As New ShapePath()
        path.EnableGradient = True
        path.ConnectionPointType = ConnectType.Four

        shapeTemplate.Content.Add(stroke)
        shapeTemplate.Content.Add(path)

        Dim shape As New Independentsoft.Office.Vml.Shape()
        shape.Style = New Independentsoft.Office.Vml.ShapeStyle()
        shape.Style.Position = Position.Absolute
        shape.Style.LeftMargin = "0"
        shape.Style.TopMargin = "0"
        shape.Style.Width = "200pt"
        shape.Style.Height = "195pt"
        shape.Style.HorizontalPosition = HorizontalPosition.Center
        shape.Style.RelativeHorizontalPosition = RelativeHorizontalPosition.Margin
        shape.Style.VerticalPosition = VerticalPosition.Center
        shape.Style.RelativeVerticalPosition = RelativeVerticalPosition.Margin
        shape.FillColor = "yellow"
        shape.Content.Add(textBox)

        Dim vmlObject As New VmlObject()
        vmlObject.Content.Add(shapeTemplate)
        vmlObject.Content.Add(shape)

        Dim run1 As New Run()
        run1.Add(vmlObject)

        Dim paragraph1 As New Paragraph()
        paragraph1.Add(run1)

        doc.Body.Add(paragraph1)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module
