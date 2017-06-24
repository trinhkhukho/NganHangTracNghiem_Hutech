Imports System
Imports Independentsoft.Office.Vml
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim textBoxRun As New Run()
        textBoxRun.AddText("Simple text inside a textbox")

        Dim textBoxParagraph As New Paragraph()
        textBoxParagraph.Add(textBoxRun)

        Dim textBox As New TextBox()
        textBox.Content.Add(textBoxParagraph)

        Dim shapeTemplate As New ShapeTemplate()

        Dim shapeStyle As New ShapeStyle()
        shapeStyle.Position = Position.Absolute
        shapeStyle.Width = "100pt"
        shapeStyle.Height = "75pt"

        Dim shape As New Shape(shapeStyle)
        shape.Content.Add(textBox)

        Dim vmlObject As New VmlObject()
        vmlObject.Content.Add(shape)

        Dim run1 As New Run()
        run1.Add(vmlObject)

        Dim paragraph1 As New Paragraph()
        paragraph1.Add(run1)

        doc.Body.Add(paragraph1)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module