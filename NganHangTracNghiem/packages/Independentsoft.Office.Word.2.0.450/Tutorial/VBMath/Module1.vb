Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Math

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim xRun As MathRun = New MathRun("x")
        Dim yRun As MathRun = New MathRun("y")
        Dim zRun As MathRun = New MathRun("z")

        Dim xNumerator As Numerator = New Numerator
        xNumerator.MathElements.Add(xRun)

        Dim yDenominator As Denominator = New Denominator
        yDenominator.MathElements.Add(yRun)

        Dim zDenominator As Denominator = New Denominator
        zDenominator.MathElements.Add(zRun)

        Dim fraction1 As Fraction = New Fraction(xNumerator, yDenominator)
        Dim fraction2 As Fraction = New Fraction(xNumerator, zDenominator)

        Dim plusRun As MathRun = New MathRun("+")
        Dim resultRun As MathRun = New MathRun("=100")

        Dim math As OfficeMath = New OfficeMath
        math.MathElements.Add(fraction1)
        math.MathElements.Add(plusRun)
        math.MathElements.Add(fraction2)
        math.MathElements.Add(resultRun)

        Dim paragraph As Paragraph = New Paragraph
        paragraph.Add(math)

        doc.Body.Add(paragraph)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module