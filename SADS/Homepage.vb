Public Class Homepage


    Private Sub btnMyBookings_Click(sender As System.Object, e As System.EventArgs) Handles btnMyBookings.Click
        MyBookings.Show()
        Me.Hide()
    End Sub

    Private Sub Homepage_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        lblWelcome.Text = "Welcome" & " " & globalVariables.usernam & vbCrLf & "MemberID: " & globalVariables.memberId
    End Sub

    Private Sub Homepage_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub btnBookTickets_Click(sender As System.Object, e As System.EventArgs) Handles btnBookTickets.Click
        Me.Hide()
        SeatingPlan.Show()
    End Sub

    Private Sub btnLogout_Click(sender As System.Object, e As System.EventArgs) Handles btnLogout.Click
        Me.Hide()
        Login.Show()

    End Sub

    Private Sub btnManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManager.Click
        Me.Hide()
        ManagerPassword.Show()
    End Sub

    Private Sub Homepage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class