Public Class ManagerPassword

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Dim pword As String

        pword = txtPassword.Text

        If pword = "Admin123" Then
            Manager.Show()
            Me.Hide()
        ElseIf pword = "" Then
            MsgBox("Please enter a Password")
        Else
            MsgBox("Incorrect Password")
        End If

        txtPassword.Clear()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
        Homepage.Show()
    End Sub

    Private Sub ManagerPassword_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub ManagerPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class