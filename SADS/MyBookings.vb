Imports System.Data.OleDb
Public Class MyBookings
    Private Sub MyBookings_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub MyBookings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lstCost.Enabled = False
        cboPerformance.Items.Add("Friday")
        cboPerformance.Items.Add("Saturday")
        cboPerformance.Text = "Friday"
        fridayBooked()
        lstSeatNumber.MultiColumn = True
        lstCost.MultiColumn = True
    End Sub

    Private Sub cboPerformance_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboPerformance.KeyPress
        If Asc(e.KeyChar) = 2 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cboPerformance_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPerformance.SelectedIndexChanged
        If cboPerformance.Text = "Friday" Then
            fridayBooked()
        ElseIf cboPerformance.Text = "Saturday" Then
            saturdayBooked()
        End If
    End Sub
    Function fridayBooked()
        lstSeatNumber.Items.Clear()
        lstCost.Items.Clear()
        Dim conn As New OleDbConnection 'set up connection to database
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\SADS.mdb;" 'this tells the computer where to find the database
        Dim command As New OleDbCommand 'set up command
        command.CommandText = "SELECT seatNumber, CostOfTicket FROM tblSoldTickets WHERE MemberID  ='" & globalVariables.memberId & "' AND DayOfPerformance = ""Friday"";"  'retrieving information from my database"
        command.Connection = conn 'connect to database
        Dim dr As OleDbDataReader 'declaring data`reader 

        Try

            conn.Open()
            dr = command.ExecuteReader
            While dr.Read
                Dim seatFridayArray() As String
                seatFridayArray = Split(dr.GetValue(0), ",")
                For Each seat As String In seatFridayArray
                    lstSeatNumber.Items.Add(seat)
                Next
                Dim costFridayArray() As String
                costFridayArray = Split(dr.GetValue(1), ",")
                For Each cost As String In costFridayArray
                    Dim cost1 As Double
                    cost1 = Convert.ToDouble(cost)

                    lstCost.Items.Add("£" & Format(cost1, "##.00"))
                Next
                'dr.GetValue(0)
            End While
            conn.Close() 'closing connection with database

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'if something goes wrong display error message with error icon 
        End Try
        Return Nothing
    End Function
    Function saturdayBooked()
        lstSeatNumber.Items.Clear()
        lstCost.Items.Clear()
        Dim conn As New OleDbConnection 'set up connection to database
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\SADS.mdb;" 'this tells the computer where to find the database
        Dim command As New OleDbCommand 'set up command
        command.CommandText = "SELECT seatNumber, CostOfTicket FROM tblSoldTickets WHERE MemberID  ='" & globalVariables.memberId & "' AND DayOfPerformance = ""Saturday"";"  'retrieving information from my database"
        command.Connection = conn 'connect to database
        Dim dr As OleDbDataReader 'declaring data`reader 

        Try

            conn.Open() 'open connection
            dr = command.ExecuteReader 'read information from databse
            While dr.Read 'this basically reads what is in the databse
                Dim seatSaturdayArray() As String
                seatSaturdayArray = Split(dr.GetValue(0), ",")
                For Each seat As String In seatSaturdayArray
                    lstSeatNumber.Items.Add(seat)
                Next
                Dim costSaturdayArray() As String
                costSaturdayArray = Split(dr.GetValue(1), ",")
                For Each cost As String In costSaturdayArray
                    Dim cost1 As Double
                    cost1 = Convert.ToDouble(cost)
                    lstCost.Items.Add("£" & Format(cost1, "##.00"))
                Next

            End While
            conn.Close() 'closing connection with database

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'if something goes wrong display error message with error icon 
        End Try

        Return Nothing
    End Function

    Private Sub btnLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim seatNumber As String = lstSeatNumber.SelectedItem
        Dim dater As String = cboPerformance.Text
        Dim conn As New OleDbConnection 'set up connection to database
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\SADS.mdb;" 'this tells the computer where to find the database
        Dim conn2 As New OleDbConnection
        conn2.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\SADS.mdb;"
        Dim command As New OleDbCommand 'set up command
        command.CommandText = "DELETE * FROM tblSoldTickets WHERE [SeatNumber] ='" & seatNumber & "' AND [DayOfPerformance] =" & """" & dater & """" & ";"  'retrieving information from my database"
        Dim command2 As New OleDbCommand
        ' command2.CommandText = "UP"
        If cboPerformance.Text = "Saturday" Then
            command2.CommandText = "UPDATE tblSeatsAvailable SET availableSaturday = Yes WHERE seatNumber = " & """" & seatNumber & """" & ";"
        ElseIf cboPerformance.Text = "Friday" Then
            command2.CommandText = "UPDATE tblSeatsAvailable SET availableFriday = Yes WHERE seatNumber = " & """" & seatNumber & """" & ";"
        End If
        command.Connection = conn 'connect to database
        command2.Connection = conn2
        conn.Open() 'open connection
        conn2.Open()

        Try
        command.ExecuteNonQuery()
        command2.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'if something goes wrong display error message with error icon 
        End Try
        conn.Close() 'closing connection with database
        MsgBox("You have canceled your booking for seat " & seatNumber)
        If cboPerformance.Text = "Friday" Then
            fridayBooked()
        ElseIf cboPerformance.Text = "Saturday" Then
            saturdayBooked()
        End If
    End Sub


    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        Me.Hide()
        Homepage.Show()
    End Sub

    Private Sub lstSeatNumber_RegionChanged(sender As Object, e As System.EventArgs) Handles lstSeatNumber.RegionChanged
        lstSeatNumber.Region = lstCost.Region
    End Sub

    Private Sub lstSeatNumber_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstSeatNumber.SelectedIndexChanged
        Dim listNo As Integer = lstSeatNumber.SelectedIndex()
        lstCost.SelectedIndex = listNo


     
    End Sub


End Class