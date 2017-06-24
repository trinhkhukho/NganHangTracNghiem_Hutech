Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As New WordDocument("c:\test\input.docx")

        Dim text As String = doc.ToText()

        Dim separator As String() = New String() {" ", "" & Chr(13) & "" & Chr(10) & "", "" & Chr(9) & ""}

        Dim words As String() = text.Split(separator, StringSplitOptions.RemoveEmptyEntries)

        Console.WriteLine("Word count = " & words.Length)
        Console.Read()

    End Sub
End Module