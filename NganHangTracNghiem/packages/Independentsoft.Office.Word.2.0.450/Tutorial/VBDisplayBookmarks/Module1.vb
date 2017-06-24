Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New WordDocument("c:\test\input.docx")

        For Each blockElement As IBlockElement In doc.Body.Content

            If TypeOf blockElement Is Paragraph Then

                Dim paragraph As Paragraph = DirectCast(blockElement, Paragraph)

                Dim bookmarkID As Long = -1
                Dim bookmarkName As String = Nothing
                Dim bookmarkText As String = Nothing

                For i As Integer = 0 To paragraph.Content.Count - 1

                    If TypeOf paragraph.Content(i) Is BookmarkStart Then

                        Dim bookmarkStart As BookmarkStart = DirectCast(paragraph.Content(i), BookmarkStart)

                        bookmarkID = bookmarkStart.ID
                        bookmarkName = bookmarkStart.Name
                        bookmarkText = ""
                    End If

                    If TypeOf paragraph.Content(i) Is BookmarkEnd Then

                        Dim bookmarkEnd As BookmarkEnd = DirectCast(paragraph.Content(i), BookmarkEnd)

                        If bookmarkEnd.ID = bookmarkID Then
                            Console.WriteLine("Bookmark ID = " & bookmarkID)
                            Console.WriteLine("Bookmark Name = " & bookmarkName)
                            Console.WriteLine("Bookmark Text = " & bookmarkText)
                        End If

                    End If

                    If TypeOf paragraph.Content(i) Is Run Then

                        Dim run As Run = DirectCast(paragraph.Content(i), Run)

                        For j As Integer = 0 To run.Content.Count - 1

                            If TypeOf run.Content(j) Is Text Then
                                Dim text As Text = DirectCast(run.Content(j), Text)
                                bookmarkText += text.Value
                            End If
                        Next

                    End If

                Next

            End If
        Next

        Console.Read()

    End Sub
End Module