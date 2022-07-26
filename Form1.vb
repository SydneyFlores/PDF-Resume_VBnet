﻿Imports System.IO
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
        Dim age As Paragraph = New Paragraph(output.Age)
        Dim address As Paragraph = New Paragraph(output.Address)
        Dim contactnumber As Paragraph = New Paragraph(output.ContactNumber)
        Dim emailaddress As Paragraph = New Paragraph(output.EmailAddress & vbLf & vbLf & vbLf)
        Dim objective As Paragraph = New Paragraph("OBJECTIVE" & vbLf & vbTab & output.Objective)
        Dim skills As Paragraph = New Paragraph("SKILLS" & vbLf & output.Skills)
        Dim workexperience As Paragraph = New Paragraph("EXPERIENCE" & vbLf & output.WorkExperience)
        Dim education As Paragraph = New Paragraph("EDUCATION" & vbLf & output.Education)
        Dim certification As Paragraph = New Paragraph("CERTIFICATION" & vbLf & output.Certification)
        Dim signature As Paragraph = New Paragraph(vbLf & vbLf & vbLf & output.Signature)


        name.Font.Size = 20
        name.Alignment = Element.ALIGN_CENTER
        age.Alignment = Element.ALIGN_CENTER
        address.Alignment = Element.ALIGN_CENTER
        contactnumber.Alignment = Element.ALIGN_CENTER
        emailaddress.Alignment = Element.ALIGN_CENTER
        signature.Alignment = Element.ALIGN_RIGHT

        mypdfresume.Add(name)
        mypdfresume.Add(age)
        mypdfresume.Add(address)
        mypdfresume.Add(contactnumber)
        mypdfresume.Add(emailaddress)
        mypdfresume.Add(objective)
        mypdfresume.Add(skills)
        mypdfresume.Add(workexperience)
        mypdfresume.Add(education)
        mypdfresume.Add(certification)
        mypdfresume.Add(signature)
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
