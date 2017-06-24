Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument("c:\test\input.docx")

        Dim text As String = doc.ToText()

        Console.WriteLine(Text)
        Console.Read()

    End Sub
End Module