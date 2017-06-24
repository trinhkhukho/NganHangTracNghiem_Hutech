Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Vml
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New WordDocument()

        Dim embeddedObject As New EmbeddedObject()

        Dim imageShapeStyle As New ShapeStyle()
        imageShapeStyle.Width = "76pt"
        imageShapeStyle.Height = "48pt"

        Dim imageShape As New Shape()
        imageShape.ID = "Shape1"
        imageShape.Style = imageShapeStyle

        Dim image As New Image("c:\test\image1.emf") 'excel icon
        image.Title = "image1" 'important

        imageShape.Content.Add(image)

        Dim oleObject As New EmbeddedOleObject("c:\test\workbook.xlsx")
        oleObject.Type = OleType.EmbeddedObject
        oleObject.Application = "Excel.Sheet.12"
        oleObject.ShapeID = "Shape1"
        oleObject.DrawAspect = OleDrawAspect.Icon
        oleObject.ObjectID = "123"

        embeddedObject.Content.Add(imageShape)
        embeddedObject.Content.Add(oleObject)

        Dim run1 As New Run()
        run1.Add(embeddedObject)

        Dim paragraph1 As New Paragraph()
        paragraph1.Add(run1)

        doc.Body.Add(paragraph1)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module
