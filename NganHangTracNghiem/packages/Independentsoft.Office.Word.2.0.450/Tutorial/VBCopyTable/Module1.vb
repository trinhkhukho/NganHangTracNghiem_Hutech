Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Tables
Imports Independentsoft.Office.Word.Styles

Module Module1
    Sub Main(ByVal args As String())

        Dim input As New WordDocument("c:\test\input.docx")
        Dim output As New WordDocument()

        Dim tables As IList(Of Table) = input.GetTables()

        If tables.Count > 0 Then
            output.Body.Add(tables(0))

            If tables(0).StyleName IsNot Nothing Then
                Dim tableStyle As Style = Nothing

                For Each s As Style In input.StyleDefinitions.Styles
                    If s.ID = tables(0).StyleName Then
                        tableStyle = s
                    End If
                Next

                If tableStyle IsNot Nothing Then
                    If output.StyleDefinitions Is Nothing Then
                        output.StyleDefinitions = New StyleDefinitions()
                    End If

                    output.StyleDefinitions.Styles.Add(tableStyle)
                End If
            End If
        End If

        output.Save("c:\test\output.docx", True)

    End Sub
End Module
