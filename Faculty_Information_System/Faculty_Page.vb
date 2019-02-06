﻿Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Imports System.Data

Public Class Faculty_Page
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Faculty_database.accdb;Jet OLEDB:Database Password=group11"
    Public Property EmailPass As String

    Private Sub Faculty_Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim name As String
        Dim dept As String
        Dim email As String
        Dim research As String
        Dim query As String = "SELECT * FROM faculty_info where Email= '" & EmailPass & "';"
        Dim conn = New OleDbConnection(connectionString)
        conn.Open()
        Dim cmd As New OleDbCommand(query, conn)
        Dim Reader As OleDbDataReader = cmd.ExecuteReader()
        Try

            While (Reader.Read())
                name = Reader.GetValue(1)
                dept = Reader.GetValue(2)
                email = Reader.GetValue(3)

                Dim id As String = Reader.GetValue(4)
                'The below line is the path of the image, could be different for different PCs
                Dim folder As String = "C:\Users\Aryan Agrawal\Desktop\CS243Lab\Lab2\Faculty_Information_System\Faculty_Information_System\My Project"
                Dim filename As String = System.IO.Path.Combine(folder, id & ".jpeg")
                PictureBox2.Image = Image.FromFile(filename)
                research = Reader.GetValue(6)

                'PictureBox2.Image = Image.FromFile(Reader.GetValue(4))
            End While
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning")
        End Try

        Label_Details.Text = name & vbNewLine & dept & vbNewLine & email
    End Sub
End Class