Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Tables

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New WordDocument("c:\test\input.docx")

        For i As Integer = 0 To doc.Body.Content.Count - 1
            If TypeOf doc.Body.Content(i) Is Paragraph Then
                Dim paragraph As Paragraph = DirectCast(doc.Body.Content(i), Paragraph)

                For j As Integer = 0 To paragraph.Content.Count - 1
                    If TypeOf paragraph.Content(j) Is BookmarkStart Then
                        Dim bookmarkStart As BookmarkStart = DirectCast(paragraph.Content(j), BookmarkStart)

                        If bookmarkStart.Name = "mybookmark" Then
                            Dim run1 As New Run()
                            run1.AddText("some text")
                            run1.Bold = ExtendedBoolean.[True]

                            paragraph.Content.Insert(j, run1)
                            Exit For
                        End If
                    End If
                Next
            End If
        Next

        doc.Save("c:\test\output.docx", True)
    End Sub
End Module
