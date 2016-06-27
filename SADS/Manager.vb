Imports System.Data.OleDb
Public Class Manager

    Private Sub Manager_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        reading()
    End Sub

    Private Sub Manager_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub Manager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        reading()
    End Sub

    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        Me.Hide()
        Homepage.Show()
    End Sub
    Function reading()
        Dim conn As New OleDbConnection 'set up connection to database
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\SADS.mdb;" 'this tells the computer where to find the database
        Dim command As New OleDbCommand 'set up command
        command.CommandText = "SELECT SUM(CostOfTicket) FROM tblSoldTickets WHERE DayOfPerformance = ""friday"";"  'retrieving information from my database"
        Dim command2 As New OleDbCommand
        command2.CommandText = "SELECT SUM(CostOfTicket) FROM tblSoldTickets WHERE DayOfPerformance = ""saturday"";"
        Dim command3 As New OleDbCommand
        command3.CommandText = "SELECT SUM(CostOfTicket) FROM tblSoldTickets;"
        command2.Connection = conn
        command3.Connection = conn
        command.Connection = conn 'connect to database
        Dim costFriday As Double
        Dim costSaturday As Double
        Dim costTotal As Double
        Dim dr As OleDbDataReader 'declaring data`reader 
        Dim dr2 As OleDbDataReader
        Dim dr3 As OleDbDataReader
        Try

            conn.Open() 'open connection
            dr = command.ExecuteReader 'read information from databse
            dr2 = command2.ExecuteReader
            dr3 = command3.ExecuteReader
            While dr.Read 'this basically reads what is in the databse
                If Not dr(0).Equals(DBNull.Value) Then
                    costFriday = dr.GetValue(0)
                    Convert.ToString(costFriday)
                    lblFriday.Text = "Total Sales Friday: " & "£" & costFriday
                Else
                    lblFriday.Text = "Total Sales Friday: " & "£0.00"
                End If
            End While
            While dr2.Read 'this basically reads what is in the databse
                If Not dr2(0).Equals(DBNull.Value) Then
                    costSaturday = dr2.GetValue(0)
                    Convert.ToString(costSaturday)
                    lblSaturday.Text = "Total Sales Saturday: " & "£" & costSaturday
                Else
                    lblSaturday.Text = "Total Sales Saturday: " & "£0.00"
                End If
            End While
            While dr3.Read 'this basically reads what is in the databse
                If Not dr3(0).Equals(DBNull.Value) Then
                    costTotal = dr3.GetValue(0)
                    Convert.ToString(costTotal)
                    lblTotal.Text = "Total Sales: " & "£" & costTotal
                Else
                    lblTotal.Text = "Total Sales: " & "£0.00"
                End If
            End While
            conn.Close() 'closing connection with database

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'if something goes wrong display error message with error icon 
        End Try
        Return Nothing
    End Function
End Class