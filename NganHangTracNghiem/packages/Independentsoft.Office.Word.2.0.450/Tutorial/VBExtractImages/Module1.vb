Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument("c:\test\input.docx")

        Dim pictures As IList(Of IPicture) = doc.GetPictures()

        For Each picture As IPicture In pictures
            picture.Save("c:\test\" + picture.FileName, True)
        Next

    End Sub
End Module