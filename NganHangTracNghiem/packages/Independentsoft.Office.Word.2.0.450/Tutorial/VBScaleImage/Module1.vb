Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Drawing
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Drawing

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument

        Dim picture As New Picture("c:\test\image1.png")

        Dim pictureWidth As New Unit(180, UnitType.Pixel)
        Dim pictureHeight As New Unit(240, UnitType.Pixel)

        Dim offset As New Offset(0, 0)
        Dim extents As New Extents(pictureWidth, pictureHeight)

        picture.ShapeProperties.PresetGeometry = New PresetGeometry(ShapeType.Rectangle)
        picture.ShapeProperties.Transform2D = New Transform2D(offset, extents)
        picture.ID = "1"
        picture.Name = "image1.png"

        Dim stretch As New Stretch()
        'important to scale image
        stretch.FillRectangle = New FillRectangle()
        picture.Stretch = stretch

        Dim inline As New Inline(picture)
        inline.Size = New DrawingObjectSize(pictureWidth, pictureHeight)
        inline.ID = "1"
        inline.Name = "Picture 1"
        inline.Description = "image1.png"

        Dim drawingObject As New DrawingObject(inline)

        Dim imageRun As New Run()
        imageRun.Add(drawingObject)

        Dim imageParagraph As New Paragraph()
        imageParagraph.Add(imageRun)

        doc.Body.Add(imageParagraph)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module
