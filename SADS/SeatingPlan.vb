Imports System.Data.OleDb
Public Class SeatingPlan

    Dim seatUnavailableArray() As String = {""}
    Dim seatSelectedArray(0) As String
    Dim seatSelecterPostion As Integer = 0
    Dim cost As Double = 0
    Dim seatCounter As Integer = 0

    Private Sub SeatingPlan_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        cost = 0
        If cboPerformanceDate.Text = "Saturday" Then
            saturday()
        End If
        If cboPerformanceDate.Text = "Friday" Then
            friday()
        End If
    End Sub
    Private Sub SeatingPlan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
    Private Sub SeatingPlan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' friday()
        cboPerformanceDate.Items.Add("Friday")
        cboPerformanceDate.Items.Add("Saturday")
        cboPerformanceDate.Text = "Friday"
        friday()
        'saturday()

    End Sub
    Function seatsAvailable(ByVal buttonNO As Button)  'Handles System.Windows.controls
        Dim x As Integer = 0
        If seatUnavailableArray.Contains(buttonNO.Name) Then
            buttonNO.Enabled = False
            buttonNO.BackColor = Color.Red
        End If
        x += 1
        Return Nothing
    End Function

    Private Sub cboPerformanceDate_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboPerformanceDate.KeyPress
        If Asc(e.KeyChar) = 2 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub cboPerformanceDate_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPerformanceDate.SelectedIndexChanged
        If cboPerformanceDate.Text = "Friday" Then
            friday()
        End If
        If cboPerformanceDate.Text = "Saturday" Then
            saturday()
        End If
    End Sub
    Function friday()
        seatUnavailableArray = {""}
        '     txtSeatsAvailable.Clear()
        clearsSeatsChecked()
        Dim i As Int16 = 0
        Dim y As Integer = 0
        Dim conn As New OleDbConnection 'set up connection to database
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\SADS.mdb;" 'this tells the computer where to find the database
        Dim command As New OleDbCommand 'set up command
        command.CommandText = "SELECT seatNumber FROM tblSeatsAvailable WHERE availableFriday  = No;"  'retrieving information from my database"
        command.Connection = conn 'connect to database
        Dim dr As OleDbDataReader 'declaring data`reader 
        Try
            conn.Open() 'open connection
            dr = command.ExecuteReader 'read information from databse
            While dr.Read 'this basically reads what is in the databse

                ' txtSeatsAvailable.Text += dr.GetValue(0) & vbCrLf
                seatUnavailableArray = Split(dr.GetValue(0), ",") '& vbCrLf
                seatsAvailable(DirectCast(Controls.Find(seatUnavailableArray(i), True)(0), Button))
            End While
            conn.Close() 'closing connection with database
            '  MsgBox("Invalid Username")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'if something goes wrong display error message with error icon 
        End Try
        Return Nothing
    End Function
    Function saturday()
        seatUnavailableArray = {""}
        clearsSeatsChecked()
        ' txtSeatsAvailable.Clear()
        Dim i As Int16 = 0
        Dim y As Integer = 0
        Dim conn As New OleDbConnection 'set up connection to database
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\SADS.mdb;" 'this tells the computer where to find the database
        Dim command As New OleDbCommand 'set up command
        command.CommandText = "SELECT seatNumber FROM tblSeatsAvailable WHERE availableSaturday  = No;"  'retrieving information from my database"
        command.Connection = conn 'connect to database
        Dim dr As OleDbDataReader 'declaring data`reader 
        Try
            conn.Open() 'open connection
            dr = command.ExecuteReader 'read information from databse
            While dr.Read 'this basically reads what is in the databse
                seatUnavailableArray = Split(dr.GetValue(0)) '& vbCrLf
                seatsAvailable(DirectCast(Controls.Find(seatUnavailableArray(i), True)(0), Button))
            End While
            conn.Close() 'closing connection with database
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'if something goes wrong display error message with error icon 
        End Try

        Return Nothing
    End Function
    Function seatsSelectedSaturday(ByVal dater As String)
        Dim conn As New OleDbConnection
        Dim command As New OleDbCommand
        Dim command2 As New OleDbCommand
        Dim seatCounter As Integer = 0
        Dim seat As String
        Dim cost As String = ""
        Dim Total As Double
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\SADS.mdb;"

        command.Connection = conn
        command2.Connection = conn
        For seatCounter = seatCounter To (seatSelectedArray.Length - 2)
            seat = seatSelectedArray(seatCounter)
            If seat.Contains("A") Or seat.Contains("B") Or seat.Contains("C") Then
                cost = "10"
            End If
            If seat.Contains("D") Or seat.Contains("E") Or seat.Contains("F") Then
                cost = "12.50"
            End If
            If seat.Contains("G") Or seat.Contains("H") Or seat.Contains("J") Or seat.Contains("K") Or seat.Contains("L") Then
                cost = "7.25"
            End If
            Total += Convert.ToDouble(cost)
            command.CommandText = "INSERT INTO tblSoldTickets([MemberID], [SeatNumber], [DayOfPerformance], [CostOfTicket] ) VALUES('" & globalVariables.memberId & "', '" & seat & "', '" & dater & "', '" & cost & "');"
            command2.CommandText = "UPDATE tblSeatsAvailable SET availableSaturday = No WHERE seatNumber= """ & seat & """;"

            Try
                conn.Open()
                command.ExecuteNonQuery()
                command2.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            conn.Close()
        Next

        MessageBox.Show("You have sucessfully booked these tickets" & vbCrLf & "The total cost of your purchase is: £" & Format(Total, "####.00"))
        Return Nothing
    End Function
    Function seatsSelectedFriday(ByVal dater As String)
        Dim conn As New OleDbConnection
        Dim command As New OleDbCommand
        Dim command2 As New OleDbCommand

        Dim seat As String
        Dim cost As String = ""
        Dim total As Double
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\SADS.mdb;"

        command.Connection = conn
        command2.Connection = conn

        For seatCounter = seatCounter To (seatSelectedArray.Length - 2)
            seat = seatSelectedArray(seatCounter)
            If seat.Contains("A") Or seat.Contains("B") Or seat.Contains("C") Then
                cost = "10"
            End If
            If seat.Contains("D") Or seat.Contains("E") Or seat.Contains("F") Then
                cost = "12.50"
            End If
            If seat.Contains("G") Or seat.Contains("H") Or seat.Contains("J") Or seat.Contains("K") Or seat.Contains("L") Then
                cost = "7.25"
            End If

            total += Convert.ToDouble(cost)


            command.CommandText = "INSERT INTO tblSoldTickets([MemberID], [SeatNumber], [DayOfPerformance], [CostOfTicket] ) VALUES('" & globalVariables.memberId & "', '" & seat & "', '" & dater & "', '" & cost & "');"
            command2.CommandText = "UPDATE tblSeatsAvailable SET availableFriday = No WHERE seatNumber= """ & seat & """;"

            Try
                conn.Open()
                command.ExecuteNonQuery()
                command2.ExecuteNonQuery()


            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            conn.Close()
        Next
        MessageBox.Show("You have sucessfully booked these tickets" & vbCrLf & "The total cost of your purchase is: £" & Format(total, "####.00"))
        Return Nothing
    End Function
    Function clearsSeatsChecked()
        For Each button As Control In Me.Controls
            If Not (button.Name = btnConfirm.Name Or button.Name = lblA.Name Or button.Name = lblB.Name Or button.Name = lblC.Name Or button.Name = lblD.Name Or button.Name = lblE.Name Or button.Name = lblF.Name Or button.Name = lblG.Name Or button.Name = lblH.Name Or button.Name = lblJ.Name Or button.Name = lblK.Name Or button.Name = lblL.Name Or button.Name = PictureBox1.Name Or button.Name = PictureBox2.Name Or button.Name = PictureBox3.Name Or button.Name = lblStage.Name Or button.Name = lblSeatingPlan.Name Or button.Name = cboPerformanceDate.Name Or button.Name = lblPerformance.Name Or button.Name = btnLogOut.Name Or button.Name = btnHome.Name Or button.Name = lblBasketTotal.Name Or button.Name = btnClear.Name Or button.Name = Label1.Name) Then 'Or button.Name = txtSeatsAvailable.Name) Then
                button.BackColor = Color.LimeGreen
                button.Enabled = True
                lblBasketTotal.Text = "Basket Total: £0.00"
                For Each item In seatSelectedArray
                    item = ""
                Next
                ReDim seatSelectedArray(0)
                seatSelecterPostion = 0
                cost = 0
                seatCounter = 0
            End If
        Next
        Return Nothing
    End Function

    Function disableButton(ByVal buttonName As Button)
  
        buttonName.Enabled = False
        buttonName.BackColor = Color.Blue
        Return Nothing
    End Function
    Function EveryButton(ByVal seatName As String, ByVal seatButton As Button)
        Array.Resize(seatSelectedArray, seatSelectedArray.Length + 1)
        seatSelectedArray(seatSelecterPostion) = seatName
        disableButton(seatButton)
        seatSelecterPostion += 1

        If seatName.Contains("A") Or seatName.Contains("B") Or seatName.Contains("C") Then
            cost += 10
            lblBasketTotal.Text = "Basket Total: £" & Format(cost, "####.00")
        ElseIf seatName.Contains("D") Or seatName.Contains("E") Or seatName.Contains("F") Then

            cost += 12.5
            lblBasketTotal.Text = "Basket Total: £" & Format(cost, "####.00")
        ElseIf seatName.Contains("G") Or seatName.Contains("H") Or seatName.Contains("J") Or seatName.Contains("K") Or seatName.Contains("L") Then
            cost += 7.25
            '  MsgBox(cost)
            lblBasketTotal.Text = "Basket Total: £" & Format(cost, "####.00")
        End If
        Return Nothing
    End Function
    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If seatSelectedArray.Length = 1 Then
            MsgBox("Please select a seat!")
            Exit Sub
        End If
        If cboPerformanceDate.Text = "Friday" Then
            seatsSelectedFriday("Friday")
            Array.Resize(seatSelectedArray, 1)
            seatSelecterPostion = 0
            friday()
        ElseIf cboPerformanceDate.Text = "Saturday" Then
            seatsSelectedSaturday("Saturday")
            Array.Resize(seatSelectedArray, 1)
            seatSelecterPostion = 0
            saturday()
        ElseIf cboPerformanceDate.Text = "" Then
            MsgBox("Please select a performance date.")
        End If


    End Sub
    Private Sub btnLogOut_Click(sender As System.Object, e As System.EventArgs) Handles btnLogOut.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub L15_Click(sender As System.Object, e As System.EventArgs) Handles L15.Click
        EveryButton("L15", L15)
    End Sub
    Private Sub L14_Click(sender As System.Object, e As System.EventArgs) Handles L14.Click
        EveryButton("L14", L14)
    End Sub
    Private Sub L13_Click(sender As System.Object, e As System.EventArgs) Handles L13.Click
        EveryButton("L13", L13)
    End Sub
    Private Sub L12_Click(sender As System.Object, e As System.EventArgs) Handles L12.Click
        EveryButton("L12", L12)
    End Sub
    Private Sub L11_Click(sender As System.Object, e As System.EventArgs) Handles L11.Click
        EveryButton("L11", L11)
    End Sub
    Private Sub L10_Click(sender As System.Object, e As System.EventArgs) Handles L10.Click
        EveryButton("L10", L10)
    End Sub
    Private Sub L9_Click(sender As System.Object, e As System.EventArgs) Handles L9.Click
        EveryButton("L9", L9)
    End Sub
    Private Sub L8_Click(sender As System.Object, e As System.EventArgs) Handles L8.Click
        EveryButton("L8", L8)
    End Sub
    Private Sub L7_Click(sender As System.Object, e As System.EventArgs) Handles L7.Click
        EveryButton("L7", L7)
    End Sub
    Private Sub L6_Click(sender As System.Object, e As System.EventArgs) Handles L6.Click
        EveryButton("L6", L6)
    End Sub
    Private Sub L5_Click(sender As System.Object, e As System.EventArgs) Handles L5.Click
        EveryButton("L5", L5)
    End Sub
    Private Sub L4_Click(sender As System.Object, e As System.EventArgs) Handles L4.Click
        EveryButton("L4", L4)
    End Sub
    Private Sub L3_Click(sender As System.Object, e As System.EventArgs) Handles L3.Click
        EveryButton("L3", L3)
    End Sub
    Private Sub L2_Click(sender As System.Object, e As System.EventArgs) Handles L2.Click
        EveryButton("L2", L2)
    End Sub
    Private Sub L1_Click(sender As System.Object, e As System.EventArgs) Handles L1.Click
        EveryButton("L1", L1)
    End Sub
    Private Sub K19_Click(sender As System.Object, e As System.EventArgs) Handles K19.Click
        EveryButton("K19", K19)
    End Sub
    Private Sub K18_Click(sender As System.Object, e As System.EventArgs) Handles K18.Click
        EveryButton("K18", K18)
    End Sub
    Private Sub K17_Click(sender As System.Object, e As System.EventArgs) Handles K17.Click
        EveryButton("K17", K17)
    End Sub
    Private Sub K16_Click(sender As System.Object, e As System.EventArgs) Handles K16.Click
        EveryButton("K16", K16)
    End Sub
    Private Sub K15_Click(sender As System.Object, e As System.EventArgs) Handles K15.Click
        EveryButton("K15", K15)
    End Sub
    Private Sub K14_Click(sender As System.Object, e As System.EventArgs) Handles K14.Click
        EveryButton("K14", K14)
    End Sub
    Private Sub K13_Click(sender As System.Object, e As System.EventArgs) Handles K13.Click
        EveryButton("K13", K13)
    End Sub
    Private Sub K12_Click(sender As System.Object, e As System.EventArgs) Handles K12.Click
        EveryButton("K12", K12)
    End Sub
    Private Sub K11_Click(sender As System.Object, e As System.EventArgs) Handles K11.Click
        EveryButton("K11", K11)
    End Sub
    Private Sub K10_Click(sender As System.Object, e As System.EventArgs) Handles K10.Click
        EveryButton("K10", K10)
    End Sub
    Private Sub K9_Click(sender As System.Object, e As System.EventArgs) Handles K9.Click
        EveryButton("K9", K9)
    End Sub
    Private Sub K8_Click(sender As System.Object, e As System.EventArgs) Handles K8.Click
        EveryButton("K8", K8)
    End Sub
    Private Sub K7_Click(sender As System.Object, e As System.EventArgs) Handles K7.Click
        EveryButton("K7", K7)
    End Sub
    Private Sub K6_Click(sender As System.Object, e As System.EventArgs) Handles K6.Click
        EveryButton("K6", K6)
    End Sub
    Private Sub K5_Click(sender As System.Object, e As System.EventArgs) Handles K5.Click
        EveryButton("K5", K5)
    End Sub
    Private Sub K4_Click(sender As System.Object, e As System.EventArgs) Handles K4.Click
        EveryButton("K4", K4)
    End Sub
    Private Sub K3_Click(sender As System.Object, e As System.EventArgs) Handles K3.Click
        EveryButton("K3", K3)
    End Sub
    Private Sub K2_Click(sender As System.Object, e As System.EventArgs) Handles K2.Click
        EveryButton("K2", K2)
    End Sub
    Private Sub K1_Click(sender As System.Object, e As System.EventArgs) Handles K1.Click
        EveryButton("K1", K1)
    End Sub
    Private Sub J19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J19.Click
        EveryButton("J19", J19)
    End Sub
    Private Sub J18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J18.Click
        EveryButton("J18", J18)
    End Sub
    Private Sub J17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J17.Click
        EveryButton("J17", J17)
    End Sub
    Private Sub J16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J16.Click
        EveryButton("J16", J16)
    End Sub
    Private Sub J15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J15.Click
        EveryButton("J15", J15)
    End Sub
    Private Sub J14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J14.Click
        EveryButton("J14", J14)
    End Sub
    Private Sub J13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J13.Click
        EveryButton("J13", J13)
    End Sub
    Private Sub J12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J12.Click
        EveryButton("J12", J12)
    End Sub
    Private Sub J11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J11.Click
        EveryButton("J11", J11)
    End Sub
    Private Sub J10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J10.Click
        EveryButton("J10", J10)
    End Sub
    Private Sub J9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J9.Click
        EveryButton("J9", J9)
    End Sub
    Private Sub J8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J8.Click
        EveryButton("J8", J8)
    End Sub
    Private Sub J7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J7.Click
        EveryButton("J7", J7)
    End Sub
    Private Sub J6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J6.Click
        EveryButton("J6", J6)
    End Sub
    Private Sub J5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J5.Click
        EveryButton("J5", J5)
    End Sub
    Private Sub J4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J4.Click
        EveryButton("J4", J4)
    End Sub
    Private Sub J3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J3.Click
        EveryButton("J3", J3)
    End Sub
    Private Sub J2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J2.Click
        EveryButton("J2", J2)
    End Sub
    Private Sub J1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles J1.Click
        EveryButton("J1", J1)
    End Sub
    Private Sub H19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H19.Click
        EveryButton("H19", H19)
    End Sub
    Private Sub H18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H18.Click
        EveryButton("H18", H18)
    End Sub
    Private Sub H17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H17.Click
        EveryButton("H17", H17)
    End Sub
    Private Sub H16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H16.Click
        EveryButton("H16", H16)
    End Sub
    Private Sub H15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H15.Click
        EveryButton("H15", H15)
    End Sub
    Private Sub H14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H14.Click
        EveryButton("H14", H14)
    End Sub
    Private Sub H13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H13.Click
        EveryButton("H13", H13)
    End Sub
    Private Sub H12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H12.Click
        EveryButton("H12", H12)
    End Sub
    Private Sub H11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H11.Click
        EveryButton("H11", H11)
    End Sub
    Private Sub H10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H10.Click
        EveryButton("H10", H10)
    End Sub
    Private Sub H9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H9.Click
        EveryButton("H9", H9)
    End Sub
    Private Sub H8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H8.Click
        EveryButton("H8", H8)
    End Sub
    Private Sub H7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H7.Click
        EveryButton("H7", H7)
    End Sub
    Private Sub H6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H6.Click
        EveryButton("H6", H6)
    End Sub
    Private Sub H5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H5.Click
        EveryButton("H5", H5)
    End Sub
    Private Sub H4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H4.Click
        EveryButton("H4", H4)
    End Sub
    Private Sub H3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H3.Click
        EveryButton("H3", H3)
    End Sub
    Private Sub H2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H2.Click
        EveryButton("H2", H2)
    End Sub
    Private Sub H1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H1.Click
        EveryButton("H1", H1)
    End Sub
    Private Sub G19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G19.Click
        EveryButton("G19", G19)
    End Sub
    Private Sub G18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G18.Click
        EveryButton("G18", G18)
    End Sub
    Private Sub G17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G17.Click
        EveryButton("G17", G17)
    End Sub
    Private Sub G16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G16.Click
        EveryButton("G16", G16)
    End Sub
    Private Sub G15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G15.Click
        EveryButton("G15", G15)
    End Sub
    Private Sub G14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G14.Click
        EveryButton("G14", G14)
    End Sub
    Private Sub G13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G13.Click
        EveryButton("G13", G13)
    End Sub
    Private Sub G12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G12.Click
        EveryButton("G12", G12)
    End Sub
    Private Sub G11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G11.Click
        EveryButton("G11", G11)
    End Sub
    Private Sub G10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G10.Click
        EveryButton("G10", G10)
    End Sub
    Private Sub G9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G9.Click
        EveryButton("G9", G9)
    End Sub
    Private Sub G8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G8.Click
        EveryButton("G8", G8)
    End Sub
    Private Sub G7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G7.Click
        EveryButton("G7", G7)
    End Sub
    Private Sub G6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G6.Click
        EveryButton("G6", G6)
    End Sub
    Private Sub G5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G5.Click
        EveryButton("G5", G5)
    End Sub
    Private Sub G4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G4.Click
        EveryButton("G4", G4)
    End Sub
    Private Sub G3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G3.Click
        EveryButton("G3", G3)
    End Sub
    Private Sub G2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G2.Click
        EveryButton("G2", G2)
    End Sub
    Private Sub G1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G1.Click
        EveryButton("G1", G1)
    End Sub
    Private Sub F20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F20.Click
        EveryButton("F20", F20)
    End Sub
    Private Sub F19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F19.Click
        EveryButton("F19", F19)
    End Sub
    Private Sub F18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F18.Click
        EveryButton("F18", F18)
    End Sub
    Private Sub F17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F17.Click
        EveryButton("F17", F17)
    End Sub
    Private Sub F16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F16.Click
        EveryButton("F16", F16)
    End Sub
    Private Sub F15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F15.Click
        EveryButton("F15", F15)
    End Sub
    Private Sub F14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F14.Click
        EveryButton("F14", F14)
    End Sub
    Private Sub F13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F13.Click
        EveryButton("F13", F13)
    End Sub
    Private Sub F12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F12.Click
        EveryButton("F12", F12)
    End Sub
    Private Sub F11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F11.Click
        EveryButton("F11", F11)
    End Sub
    Private Sub F10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F10.Click
        EveryButton("F10", F10)
    End Sub
    Private Sub F9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F9.Click
        EveryButton("F9", F9)
    End Sub
    Private Sub F8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F8.Click
        EveryButton("F8", F8)
    End Sub
    Private Sub F7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F7.Click
        EveryButton("F7", F7)
    End Sub
    Private Sub F6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F6.Click
        EveryButton("F6", F6)
    End Sub
    Private Sub F5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F5.Click
        EveryButton("F5", F5)
    End Sub
    Private Sub F4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F4.Click
        EveryButton("F4", F4)
    End Sub
    Private Sub F3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F3.Click
        EveryButton("F3", F3)
    End Sub
    Private Sub F2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F2.Click
        EveryButton("F2", F2)
    End Sub
    Private Sub F1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F1.Click
        EveryButton("F1", F1)
    End Sub
    Private Sub E20_Click(sender As System.Object, e As System.EventArgs) Handles E20.Click
        EveryButton("E20", E20)
    End Sub
    Private Sub E19_Click(sender As System.Object, e As System.EventArgs) Handles E19.Click
        EveryButton("E19", E19)
    End Sub
    Private Sub E18_Click(sender As System.Object, e As System.EventArgs) Handles E18.Click
        EveryButton("E18", E18)
    End Sub
    Private Sub E17_Click(sender As System.Object, e As System.EventArgs) Handles E17.Click
        EveryButton("E17", E17)
    End Sub
    Private Sub E16_Click(sender As System.Object, e As System.EventArgs) Handles E16.Click
        EveryButton("E16", E16)
    End Sub
    Private Sub E15_Click(sender As System.Object, e As System.EventArgs) Handles E15.Click
        EveryButton("E15", E15)
    End Sub
    Private Sub E14_Click(sender As System.Object, e As System.EventArgs) Handles E14.Click
        EveryButton("E14", E14)
    End Sub
    Private Sub E13_Click(sender As System.Object, e As System.EventArgs) Handles E13.Click
        EveryButton("E13", E13)
    End Sub
    Private Sub E12_Click(sender As System.Object, e As System.EventArgs) Handles E12.Click
        EveryButton("E12", E12)
    End Sub
    Private Sub E11_Click(sender As System.Object, e As System.EventArgs) Handles E11.Click
        EveryButton("E11", E11)
    End Sub
    Private Sub E10_Click(sender As System.Object, e As System.EventArgs) Handles E10.Click
        EveryButton("E10", E10)
    End Sub
    Private Sub E9_Click(sender As System.Object, e As System.EventArgs) Handles E9.Click
        EveryButton("E9", E9)
    End Sub
    Private Sub E8_Click(sender As System.Object, e As System.EventArgs) Handles E8.Click
        EveryButton("E8", E8)
    End Sub
    Private Sub E7_Click(sender As System.Object, e As System.EventArgs) Handles E7.Click
        EveryButton("E7", E7)
    End Sub
    Private Sub E6_Click(sender As System.Object, e As System.EventArgs) Handles E6.Click
        EveryButton("E6", E6)
    End Sub
    Private Sub E5_Click(sender As System.Object, e As System.EventArgs) Handles E5.Click
        EveryButton("E5", E5)
    End Sub
    Private Sub E4_Click(sender As System.Object, e As System.EventArgs) Handles E4.Click
        EveryButton("E4", E4)
    End Sub
    Private Sub E3_Click(sender As System.Object, e As System.EventArgs) Handles E3.Click
        EveryButton("E3", E3)
    End Sub
    Private Sub E2_Click(sender As System.Object, e As System.EventArgs) Handles E2.Click
        EveryButton("E2", E2)
    End Sub
    Private Sub E1_Click(sender As System.Object, e As System.EventArgs) Handles E1.Click
        EveryButton("E1", E1)
    End Sub
    Private Sub D19_Click(sender As System.Object, e As System.EventArgs) Handles D19.Click
        EveryButton("D19", D19)
    End Sub
    Private Sub D18_Click(sender As System.Object, e As System.EventArgs) Handles D18.Click
        EveryButton("D18", D18)
    End Sub
    Private Sub D17_Click(sender As System.Object, e As System.EventArgs) Handles D17.Click
        EveryButton("D17", D17)
    End Sub
    Private Sub D16_Click(sender As System.Object, e As System.EventArgs) Handles D16.Click
        EveryButton("D16", D16)
    End Sub
    Private Sub D15_Click(sender As System.Object, e As System.EventArgs) Handles D15.Click
        EveryButton("D15", D15)
    End Sub
    Private Sub D14_Click(sender As System.Object, e As System.EventArgs) Handles D14.Click
        EveryButton("D14", D14)
    End Sub
    Private Sub D13_Click(sender As System.Object, e As System.EventArgs) Handles D13.Click
        EveryButton("D13", D13)
    End Sub
    Private Sub D12_Click(sender As System.Object, e As System.EventArgs) Handles D12.Click
        EveryButton("D12", D12)
    End Sub
    Private Sub D11_Click(sender As System.Object, e As System.EventArgs) Handles D11.Click
        EveryButton("D11", D11)
    End Sub
    Private Sub D10_Click(sender As System.Object, e As System.EventArgs) Handles D10.Click
        EveryButton("D10", D10)
    End Sub
    Private Sub D9_Click(sender As System.Object, e As System.EventArgs) Handles D9.Click
        EveryButton("D9", D9)
    End Sub
    Private Sub D8_Click(sender As System.Object, e As System.EventArgs) Handles D8.Click
        EveryButton("D8", D8)
    End Sub
    Private Sub D7_Click(sender As System.Object, e As System.EventArgs) Handles D7.Click
        EveryButton("D7", D7)
    End Sub
    Private Sub D6_Click(sender As System.Object, e As System.EventArgs) Handles D6.Click
        EveryButton("D6", D6)
    End Sub
    Private Sub D5_Click(sender As System.Object, e As System.EventArgs) Handles D5.Click
        EveryButton("D5", D5)
    End Sub
    Private Sub D4_Click(sender As System.Object, e As System.EventArgs) Handles D4.Click
        EveryButton("D4", D4)
    End Sub
    Private Sub D3_Click(sender As System.Object, e As System.EventArgs) Handles D3.Click
        EveryButton("D3", D3)
    End Sub
    Private Sub D2_Click(sender As System.Object, e As System.EventArgs) Handles D2.Click
        EveryButton("D2", D2)
    End Sub
    Private Sub D1_Click(sender As System.Object, e As System.EventArgs) Handles D1.Click
        EveryButton("D1", D1)
    End Sub
    Private Sub C17_Click(sender As System.Object, e As System.EventArgs) Handles C17.Click
        EveryButton("C17", C17)
    End Sub
    Private Sub C16_Click(sender As System.Object, e As System.EventArgs) Handles C16.Click
        EveryButton("C16", C16)
    End Sub
    Private Sub C15_Click(sender As System.Object, e As System.EventArgs) Handles C15.Click
        EveryButton("C15", C15)
    End Sub
    Private Sub C14_Click(sender As System.Object, e As System.EventArgs) Handles C14.Click
        EveryButton("C14", C14)
    End Sub
    Private Sub C13_Click(sender As System.Object, e As System.EventArgs) Handles C13.Click
        EveryButton("C13", C13)
    End Sub
    Private Sub C12_Click(sender As System.Object, e As System.EventArgs) Handles C12.Click
        EveryButton("C12", C12)
    End Sub
    Private Sub C11_Click(sender As System.Object, e As System.EventArgs) Handles C11.Click
        EveryButton("C11", C11)
    End Sub
    Private Sub C10_Click(sender As System.Object, e As System.EventArgs) Handles C10.Click
        EveryButton("C10", C10)
    End Sub
    Private Sub C9_Click(sender As System.Object, e As System.EventArgs) Handles C9.Click
        EveryButton("C9", C9)
    End Sub
    Private Sub C8_Click(sender As System.Object, e As System.EventArgs) Handles C8.Click
        EveryButton("C8", C8)
    End Sub
    Private Sub C7_Click(sender As System.Object, e As System.EventArgs) Handles C7.Click
        EveryButton("C7", C7)
    End Sub
    Private Sub C6_Click(sender As System.Object, e As System.EventArgs) Handles C6.Click
        EveryButton("C6", C6)
    End Sub
    Private Sub C5_Click(sender As System.Object, e As System.EventArgs) Handles C5.Click
        EveryButton("C5", C5)
    End Sub
    Private Sub C4_Click(sender As System.Object, e As System.EventArgs) Handles C4.Click
        EveryButton("C4", C4)
    End Sub
    Private Sub C3_Click(sender As System.Object, e As System.EventArgs) Handles C3.Click
        EveryButton("C3", C3)
    End Sub
    Private Sub C2_Click(sender As System.Object, e As System.EventArgs) Handles C2.Click
        EveryButton("C2", C2)
    End Sub
    Private Sub C1_Click(sender As System.Object, e As System.EventArgs) Handles C1.Click
        EveryButton("C1", C1)
    End Sub
    Private Sub B16_Click(sender As System.Object, e As System.EventArgs) Handles B16.Click
        EveryButton("B16", B16)
    End Sub
    Private Sub B15_Click(sender As System.Object, e As System.EventArgs) Handles B15.Click
        EveryButton("B15", B15)
    End Sub
    Private Sub B14_Click(sender As System.Object, e As System.EventArgs) Handles B14.Click
        EveryButton("B14", B14)
    End Sub
    Private Sub B13_Click(sender As System.Object, e As System.EventArgs) Handles B13.Click
        EveryButton("B13", B13)
    End Sub
    Private Sub B12_Click(sender As System.Object, e As System.EventArgs) Handles B12.Click
        EveryButton("B12", B12)
    End Sub
    Private Sub B11_Click(sender As System.Object, e As System.EventArgs) Handles B11.Click
        EveryButton("B11", B11)
    End Sub
    Private Sub B10_Click(sender As System.Object, e As System.EventArgs) Handles B10.Click
        EveryButton("B10", B10)
    End Sub
    Private Sub B9_Click(sender As System.Object, e As System.EventArgs) Handles B9.Click
        EveryButton("B9", B9)
    End Sub
    Private Sub B8_Click(sender As System.Object, e As System.EventArgs) Handles B8.Click
        EveryButton("B8", B8)
    End Sub
    Private Sub B7_Click(sender As System.Object, e As System.EventArgs) Handles B7.Click
        EveryButton("B7", B7)
    End Sub
    Private Sub B6_Click(sender As System.Object, e As System.EventArgs) Handles B6.Click
        EveryButton("B6", B6)
    End Sub
    Private Sub B5_Click(sender As System.Object, e As System.EventArgs) Handles B5.Click
        EveryButton("B5", B5)
    End Sub
    Private Sub B4_Click(sender As System.Object, e As System.EventArgs) Handles B4.Click
        EveryButton("B4", B4)
    End Sub
    Private Sub B3_Click(sender As System.Object, e As System.EventArgs) Handles B3.Click
        EveryButton("B3", B3)
    End Sub
    Private Sub B2_Click(sender As System.Object, e As System.EventArgs) Handles B2.Click
        EveryButton("B2", B2)
    End Sub
    Private Sub B1_Click(sender As System.Object, e As System.EventArgs) Handles B1.Click
        EveryButton("B1", B1)
    End Sub
    Private Sub A14_Click(sender As System.Object, e As System.EventArgs) Handles A14.Click
        EveryButton("A14", A14)
    End Sub
    Private Sub A13_Click(sender As System.Object, e As System.EventArgs) Handles A13.Click
        EveryButton("A13", A13)
    End Sub
    Private Sub A12_Click(sender As System.Object, e As System.EventArgs) Handles A12.Click
        EveryButton("A12", A12)
    End Sub
    Private Sub A11_Click(sender As System.Object, e As System.EventArgs) Handles A11.Click
        EveryButton("A11", A11)
    End Sub
    Private Sub A10_Click(sender As System.Object, e As System.EventArgs) Handles A10.Click
        EveryButton("A10", A10)
    End Sub
    Private Sub A9_Click(sender As System.Object, e As System.EventArgs) Handles A9.Click
        EveryButton("A9", A9)
    End Sub
    Private Sub A8_Click(sender As System.Object, e As System.EventArgs) Handles A8.Click
        EveryButton("A8", A8)
    End Sub
    Private Sub A7_Click(sender As System.Object, e As System.EventArgs) Handles A7.Click
        EveryButton("A7", A7)
    End Sub
    Private Sub A6_Click(sender As System.Object, e As System.EventArgs) Handles A6.Click
        EveryButton("A6", A6)
    End Sub
    Private Sub A5_Click(sender As System.Object, e As System.EventArgs) Handles A5.Click
        EveryButton("A5", A5)
    End Sub
    Private Sub A4_Click(sender As System.Object, e As System.EventArgs) Handles A4.Click
        EveryButton("A4", A4)
    End Sub
    Private Sub A3_Click(sender As System.Object, e As System.EventArgs) Handles A3.Click
        EveryButton("A3", A3)
    End Sub
    Private Sub A2_Click(sender As System.Object, e As System.EventArgs) Handles A2.Click
        EveryButton("A2", A2)
    End Sub
    Private Sub A1_Click(sender As System.Object, e As System.EventArgs) Handles A1.Click
        EveryButton("A1", A1)
    End Sub


    Private Sub btnHome_Click(sender As System.Object, e As System.EventArgs) Handles btnHome.Click
        Me.Hide()
        Homepage.Show()
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        clearsSeatsChecked()
        If cboPerformanceDate.Text = "Friday" Then
            friday()
        End If
        If cboPerformanceDate.Text = "Saturday" Then
            saturday()
        End If
    End Sub
End Class