Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Tables

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument("c:\test\input.docx")

        Dim tables As IList(Of Table) = doc.GetTables()

        Dim table1 As Table = tables(0) 'first table
        Dim rowCount As Integer = 0

        For i As Integer = 0 To table1.Content.Count - 1
            If TypeOf table1.Content(i) Is Row Then
                Dim currentRow As Row = DirectCast(table1.Content(i), Row)
                rowCount += 1

                If rowCount = 3 Then 'remove third row
                    table1.Content.Remove(currentRow)
                    Exit For
                End If
            End If
        Next

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module