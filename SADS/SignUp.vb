Imports System.Data.OleDb

Public Class SignUp
    Dim backClicked As Boolean = False
    Dim month1 As Integer = 31
    Dim correctVal As Boolean = True
    Dim correctEm As Boolean = True
    Private Sub btnCreate_Click(sender As System.Object, e As System.EventArgs) Handles btnCreate.Click
        Dim user As String = txtUserName.Text
        Dim pass As String = txtEnterPassword.Text
        Dim email As String = txtEmail.Text
        Dim forename As String = txtFirstName.Text
        Dim surname As String = txtSurname.Text
        Dim DateofBirth As String
        DateofBirth = cboDay.Text & "/" & cboMonth.Text & "/" & cboYear.Text
        Dim conn As New OleDbConnection
        Dim command As New OleDbCommand
        Dim dr As OleDbDataReader
        Dim command2 As New OleDbCommand
        Dim userArray() As String
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\SADS.mdb;"
        command2.CommandText = "SELECT Username FROM tblCustomerData"
        command2.Connection = conn
        If txtConfirmPassword.Text = "" Or txtEmail.Text = "" Or txtEnterPassword.Text = "" Or txtFirstName.Text = "" Or txtSurname.Text = "" Or txtUserName.Text = "" Then
            MessageBox.Show("Please complete empty boxes!")
        Else
            Try
                conn.Open()
                dr = command2.ExecuteReader()
                While dr.Read()
                    userArray = Split(dr.GetValue(0), ",")
                    If userArray.Contains(user) Then
                        MsgBox("Username already taken please try new username")
                        txtUserName.Clear()
                        Exit Sub
                    End If
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If emailValidation() = True Then
                correctEm = True
                Exit Sub
            End If
            If dateValidation() = False Then
                correctVal = True
                Exit Sub
            End If

            command.CommandText = "INSERT INTO tblCustomerData([Username], [Password], [Email], [FirstName], [Surname], [DOB]) VALUES('" & user & "', '" & pass & "', '" & email & "', '" & forename & "', '" & surname & "', '" & DateofBirth & "');"
            command.Connection = conn

            If txtEnterPassword.TextLength >= 8 And txtEnterPassword.TextLength <= 16 Then
                If txtEnterPassword.Text = txtConfirmPassword.Text Then
                    Try
                        conn.Open()
                        command.ExecuteNonQuery()
                        MessageBox.Show("You have sucessfully created an account")
                        conn.Close()
                        txtConfirmPassword.Clear()
                        txtEmail.Clear()
                        txtEnterPassword.Clear()
                        txtFirstName.Clear()
                        txtSurname.Clear()
                        txtUserName.Clear()
                        cboDay.Text = ""
                        cboMonth.Text = ""
                        cboYear.Text = ""
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Else
                    MessageBox.Show("Passwords did not match, please try again")
                End If
            Else
                MessageBox.Show("Password is " & txtEnterPassword.TextLength & " characters long. It needs to be between 8-16 charcters long!")
            End If
        End If
    End Sub
    Function dateValidation()
        If Not (cboDay.Text = "" Or cboMonth.Text = "" Or cboYear.Text = "") Then
            
            If (cboMonth.Text = "04" Or cboMonth.Text = "06" Or cboMonth.Text = "09" Or cboMonth.Text = "11") And (Convert.ToInt16(cboDay.Text) > 30) Then
                MsgBox("There is no 31st of this month!")
                correctVal = False
            End If
            If cboMonth.Text = Date.Today.Month And cboYear.Text = Date.Today.Year Then
                If cboDay.Text > Date.Today.Day Then
                    MsgBox("You are not born!!!!!!!!!")
                End If
                correctVal = False
            End If
            If cboMonth.Text = "02" And (Convert.ToInt16(cboDay.Text) > 28) Then
                If (Convert.ToInt16(cboDay.Text) = 29) Then
                    MsgBox("Haha unlucky! Since your birthday only happens once every four years our system prefers to congratulate you every year so please select either February 28th or March 1st. We are sorry for any inconveince caused!")
                    correctVal = False
                Else
                    MsgBox("Feburary " & cboDay.Text & " does not exist")
                    cboDay.Text = ""
                    correctVal = False
                End If
            End If
        Else
            MsgBox("Please Fill empty boxes date boxes")
        End If

        Return correctVal
    End Function
    Function emailValidation()
        Dim emailEndings() As String = {".ac", ".ad", ".ae", ".af", ".ag", ".ai", ".al", ".am", ".an", ".ao", ".aq", ".ar", ".as", ".at", ".au", ".aw", ".ax", ".az", ".ba", ".bb", ".bd", ".be", ".bf", ".bg", ".bh", ".bi", ".bj", ".bm", ".bn", ".bo", ".bq", ".br", ".bs", ".bt", ".bv", ".bw", ".by", ".bz", ".ca", ".cc", ".cd", ".cf", ".cg", ".ch", ".ci", ".ck", ".cl", ".cm", ".cn", ".co", ".cr", ".cu", ".cv", ".cw", ".cx", ".cy", ".cz", ".de", ".dj", ".dk", ".dm", ".do", ".dz", ".ec", ".ee", ".eg", ".eh", ".er", ".es", ".et", ".eu", ".fi", ".fj", ".fk", ".fm", ".fo", ".fr", ".ga", ".gb", ".gd", ".ge", ".gf", ".gg", ".gh", ".gi", ".gl", ".gm", ".gn", ".gp", ".gq", ".gr", ".gs", ".gt", ".gu", ".gw", ".gy", ".hk", ".hm", ".hn", ".hr", ".ht", ".hu", ".id", ".ie", ".il", ".im", ".in", ".io", ".iq", ".ir", ".is", ".it", ".je", ".jm", ".jo", ".jp", ".ke", ".kg", ".kh", ".ki", ".km", ".kn", ".kp", ".kr", ".krd", ".kw", ".ky", ".kz", ".la", ".lb", ".lc", ".li", ".lk", ".lr", ".ls", ".lt", ".lu", ".lv", ".ly", ".ma", ".mc", ".md", ".me", ".mg", ".mh", ".mk", ".ml", ".mm", ".mn", ".mo", ".mp", ".mq", ".mr", ".ms", ".mt", ".mu", ".mv", ".mw", ".mx", ".my", ".mz", ".na", ".nc", ".ne", ".nf", ".ng", ".ni", ".nl", ".no", ".np", ".nr", ".nu", ".nz", ".om", ".pa", ".pe", ".pf", ".pg", ".ph", ".pk", ".pl", ".pm", ".pn", ".pr", ".ps", ".pt", ".pw", ".py", ".qa", ".re", ".ro", ".rs", ".ru", ".rw", ".sa", ".sb", ".sc", ".sd", ".se", ".sg", ".sh", ".si", ".sj", ".sk", ".sl", ".sm", ".sn", ".so", ".sr", ".ss", ".st", ".su", ".sv", ".sx", ".sy", ".sz", ".tc", ".td", ".tf", ".tg", ".th", ".tj", ".tk", ".tl", ".tm", ".tn", ".to", ".tp", ".tr", ".tt", ".tv", ".tw", ".tz", ".ua", ".ug", ".uk", ".us", ".uy", ".uz", ".va", ".vc", ".ve", ".vg", ".vi", ".vn", ".vu", ".wf", ".ws", ".ye", ".yt", ".za", ".zm", ".zw", ".com", ".org", ".net", ".int", ".edu", ".gov", ".mil"}
        For Each ending As String In emailEndings
            If txtEmail.Text.Contains(ending) And txtEmail.Text.Contains("@") Then
                correctEm = False
                Return Nothing
                Exit Function
            End If
        Next
        MsgBox("Invalid email")
        Return correctEm
    End Function
    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Me.Hide()
        Login.Show()
        backClicked = True
    End Sub

    Private Sub SignUp_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        dateSetup()
    End Sub

    Private Sub SignUp_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub SignUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dateSetup()
    End Sub

    Private Sub txtUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
    End Sub

    Function dateSetup()
        cboDay.Items.Clear()
        cboMonth.Items.Clear()
        cboYear.Items.Clear()
        Dim yearcount As Integer = 1910
        Dim currentYear As Integer = Date.Today.Year()
        For yearcount = yearcount To currentYear
            cboYear.Items.Add(yearcount)
        Next
        Dim month As Integer = 1
        For month = month To 12
            cboMonth.Items.Add(Format(month, "0#"))
        Next
        Dim dayofMonth As Integer = 1
        For dayofMonth = dayofMonth To month1
            cboDay.Items.Add(Format(dayofMonth, "0#"))
        Next
        Return Nothing
    End Function

    Private Sub cboMonth_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboMonth.KeyPress
        If Asc(e.KeyChar) = 2 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cboDay_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboDay.KeyPress
        If Asc(e.KeyChar) = 2 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cboYear_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboYear.KeyPress
        If Asc(e.KeyChar) = 2 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cboDay_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDay.SelectedIndexChanged

    End Sub
End Class