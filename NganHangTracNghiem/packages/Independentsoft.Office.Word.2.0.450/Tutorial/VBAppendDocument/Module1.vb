Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim first As New WordDocument("c:\test\first.docx")
        Dim second As New WordDocument("c:\test\second.docx")

        For Each element As IBlockElement In second.Body.Content
            first.Body.Add(element)
        Next

        first.Save("c:\test\output.docx", True)

    End Sub
End Module