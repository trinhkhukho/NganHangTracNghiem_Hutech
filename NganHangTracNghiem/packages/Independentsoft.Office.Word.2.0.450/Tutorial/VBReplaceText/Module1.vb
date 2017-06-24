Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument("c:\test\input.docx")

        doc.Replace("[CustomerID]", "12345")
        doc.Replace("[CustomerName]", "John Smith")

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module