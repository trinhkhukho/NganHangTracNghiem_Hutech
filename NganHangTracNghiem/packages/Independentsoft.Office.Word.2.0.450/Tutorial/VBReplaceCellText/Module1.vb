Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Tables

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New WordDocument("c:\test\input.docx")

        Dim tables As IList(Of Table) = doc.GetTables()

        Dim firstTable As Table = tables(0)

        Dim rowCount As Integer = 0
        Dim cellCount As Integer = 0

        For i As Integer = 0 To firstTable.Content.Count - 1
            If TypeOf firstTable.Content(i) Is Row Then
                Dim row As Row = DirectCast(firstTable.Content(i), Row)
                rowCount += 1
                cellCount = 0

                For j As Integer = 0 To row.Content.Count - 1
                    If TypeOf row.Content(j) Is Cell Then
                        Dim cell As Cell = DirectCast(row.Content(j), Cell)
                        cellCount += 1

                        If rowCount = 3 AndAlso cellCount = 1 Then
                            Dim cellText As String = ""
                            Dim firstParagraph As Paragraph = Nothing
                            Dim firstRun As Run = Nothing

                            For Each cellContent As IBlockElement In cell.Content
                                If TypeOf cellContent Is Paragraph Then
                                    Dim paragraph As Paragraph = DirectCast(cellContent, Paragraph)

                                    If firstParagraph Is Nothing Then
                                        firstParagraph = paragraph
                                    End If

                                    For Each paragraphContent As IParagraphContent In paragraph.Content
                                        If TypeOf paragraphContent Is Run Then
                                            Dim run As Run = DirectCast(paragraphContent, Run)

                                            If firstRun Is Nothing Then
                                                firstRun = run
                                            End If

                                            For Each runContent As IRunContent In run.Content
                                                If TypeOf runContent Is Text Then
                                                    Dim text As Text = DirectCast(runContent, Text)

                                                    If text.Value IsNot Nothing AndAlso text.Value.Length > 0 Then
                                                        cellText += text.Value
                                                    End If
                                                End If
                                            Next
                                        End If
                                    Next
                                End If
                            Next

                            cellText = cellText.Replace("oldText", "newText")

                            firstParagraph.Content.Clear()
                            firstRun.Content.Clear()

                            firstRun.Add(New Text(cellText))
                            firstParagraph.Add(firstRun)

                            cell.Content.Clear()
                            cell.Content.Add(firstParagraph)
                        End If
                    End If
                Next
            End If
        Next


        doc.Save("c:\test\output.docx", True)
    End Sub
End Module
