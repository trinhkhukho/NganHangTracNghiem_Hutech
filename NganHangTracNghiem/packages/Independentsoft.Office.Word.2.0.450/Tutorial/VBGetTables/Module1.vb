Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Tables

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument("c:\\test\\input.docx")

        Dim tables As IList(Of Table) = doc.GetTables()

        For Each table As Table In tables
            table.TopBorder = New TopBorder(StandardBorderStyle.DoubleLine)
            table.BottomBorder = New BottomBorder(StandardBorderStyle.DoubleLine)
            table.LeftBorder = New LeftBorder(StandardBorderStyle.DoubleLine)
            table.RightBorder = New RightBorder(StandardBorderStyle.DoubleLine)
            table.HorizontalInsideBorder = New HorizontalInsideBorder(StandardBorderStyle.DoubleLine)
            table.VerticalInsideBorder = New VerticalInsideBorder(StandardBorderStyle.DoubleLine)
        Next

        doc.Save("c:\\test\\output.docx", True)

    End Sub
End Module