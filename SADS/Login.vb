Imports System.Data.OleDb
'**********************************************************************
'* Developer:   Edward Williams                                       *
'* Version:     1.0                                                   *
'* Project:     Starshine Amature Dramatic Society                    *
'* Description: A system that allows for bookings for shows on friday *
'* and saturday of a given month. User may create an account by using *
'* sign up. Once logged in they may book tickets for either day, view *
'* previous bookings or if they are a system manager log in and view  *
'* the total sales value of a show. A user may cancel a ticket on     *
'* booking form.                                                      *
'* 1437 lines of code.                                                *
'**********************************************************************
Public Class Login

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        globalVariables.usernam = txtUserName.Text
        Dim conn As New OleDbConnection 'set up connection to database
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\SADS.mdb;" 'this tells the computer where to find the database
        Dim command As New OleDbCommand 'set up command
        command.CommandText = "SELECT * FROM tblCustomerData WHERE Username  ='" & globalVariables.usernam & "';"  'retrieving information from my database"
        command.Connection = conn 'connect to database
        Dim dr As OleDbDataReader 'declaring data`reader 
        Dim userBool As Boolean
        Try

            conn.Open() 'open connection
            dr = command.ExecuteReader 'read information from databse
            While dr.Read 'this basically reads what is in the databse
                globalVariables.memberId = dr.GetValue(0)
                If txtPassword.Text = dr.GetValue(2) Then
                    Homepage.Show()
                    Me.Hide()
                    userBool = True
                Else
                    MessageBox.Show("Invaild Username or password")
                    userBool = True
                End If
            End While
            conn.Close() 'closing connection with database

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'if something goes wrong display error message with error icon 
        End Try
        If userBool = False Then
            MsgBox("Invalid username or password")
            userBool = False
        End If

        txtUserName.Clear()
        txtPassword.Clear()
    End Sub

    Private Sub lblReg_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblReg.LinkClicked
        Me.Hide()
        SignUp.Show()
    End Sub

End Class