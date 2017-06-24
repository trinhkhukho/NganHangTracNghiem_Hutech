Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument("c:\test\input.docx")

        Dim elements As IList(Of IContentElement) = doc.GetContentElements()

        For Each element As IContentElement In elements
            If TypeOf element Is Hyperlink Then

                Dim link As Hyperlink = DirectCast(element, Hyperlink)
                Console.WriteLine("Target = " + link.Target)

            End If
        Next

        Console.Read()

    End Sub
End Module