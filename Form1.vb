Imports System.IO
Imports Newtonsoft.Json
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class Form1
    Private Sub btnconvert_Click(sender As Object, e As EventArgs) Handles btnconvert.Click
        Dim output As mypdfInfo = JsonConvert.DeserializeObject(Of mypdfInfo)(File.ReadAllText("Resume.json"))
        Dim mypdfresume As Document = New Document()
        PdfWriter.GetInstance(mypdfresume, New FileStream("FLORES_MHARSYDNEY.pdf", FileMode.Create))
        mypdfresume.Open()
        Dim name As Paragraph = New Paragraph(output.FullName)

        name.Font.Size = 20
        name.Alignment = Element.ALIGN_CENTER

        mypdfresume.Add(name)
        mypdfresume.Close()
        MessageBox.Show("Successfuly")

    End Sub
    Public Class mypdfInfo
        Public Property FullName As String
        Public Property Age As String
        Public Property Address As String
        Public Property ContactNumber As String
        Public Property EmailAddress As String
        Public Property Objective As String
        Public Property Skills As String
        Public Property WorkExperience As String
        Public Property Education As String
        Public Property Certification As String
        Public Property Signature As String
    End Class

End Class
