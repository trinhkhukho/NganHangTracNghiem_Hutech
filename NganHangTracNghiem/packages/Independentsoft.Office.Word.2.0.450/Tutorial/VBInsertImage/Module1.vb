Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Drawing
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Drawing

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim picture As Picture = New Picture("c:\\test\\image.gif")
        Dim pictureWidth As Unit = New Unit(640, UnitType.Pixel)
        Dim pictureHeight As Unit = New Unit(480, UnitType.Pixel)

        Dim offset As Offset = New Offset(0, 0)
        Dim extents As Extents = New Extents(pictureWidth, pictureHeight)

        picture.ShapeProperties.PresetGeometry = New PresetGeometry(ShapeType.Rectangle)
        picture.ShapeProperties.Transform2D = New Transform2D(offset, extents)
        picture.ID = "1"
        picture.Name = "image.gif"

        Dim inline As Inline = New Inline(picture)
        inline.Size = New DrawingObjectSize(pictureWidth, pictureHeight)
        inline.ID = "1"
        inline.Name = "Picture 1"
        inline.Description = "image.gif"

        Dim drawingObject As DrawingObject = New DrawingObject(inline)

        Dim run1 As Run = New Run
        run1.AddText("Below is an image:")

        Dim run2 As Run = New Run
        run2.Add(drawingObject)

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add(run1)
        paragraph1.Add(run2)

        doc.Body.Add(paragraph1)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module