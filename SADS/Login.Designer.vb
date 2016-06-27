<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblReg = New System.Windows.Forms.LinkLabel()
        Me.lblSignUp = New System.Windows.Forms.Label()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lblAccess = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblReg
        '
        Me.lblReg.AutoSize = True
        Me.lblReg.Location = New System.Drawing.Point(207, 188)
        Me.lblReg.Name = "lblReg"
        Me.lblReg.Size = New System.Drawing.Size(69, 13)
        Me.lblReg.TabIndex = 15
        Me.lblReg.TabStop = True
        Me.lblReg.Text = "Sign up now!"
        '
        'lblSignUp
        '
        Me.lblSignUp.AutoSize = True
        Me.lblSignUp.Location = New System.Drawing.Point(87, 188)
        Me.lblSignUp.Name = "lblSignUp"
        Me.lblSignUp.Size = New System.Drawing.Size(122, 13)
        Me.lblSignUp.TabIndex = 14
        Me.lblSignUp.Text = "Don't have an account?"
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Location = New System.Drawing.Point(46, 141)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(56, 13)
        Me.lblPass.TabIndex = 12
        Me.lblPass.Text = "Password:"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(46, 111)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(58, 13)
        Me.lblUser.TabIndex = 11
        Me.lblUser.Text = "Username:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(108, 138)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(209, 20)
        Me.txtPassword.TabIndex = 10
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(108, 108)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(209, 20)
        Me.txtUserName.TabIndex = 9
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(353, 121)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 8
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'lblAccess
        '
        Me.lblAccess.AutoSize = True
        Me.lblAccess.Location = New System.Drawing.Point(131, 219)
        Me.lblAccess.Name = "lblAccess"
        Me.lblAccess.Size = New System.Drawing.Size(0, 13)
        Me.lblAccess.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(387, 62)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Welcome to Starshine Amateur" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "          Dramatic Society"
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 253)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblAccess)
        Me.Controls.Add(Me.lblReg)
        Me.Controls.Add(Me.lblSignUp)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.btnLogin)
        Me.Name = "Login"
        Me.Text = "Welcome!"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblReg As System.Windows.Forms.LinkLabel
    Friend WithEvents lblSignUp As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents lblAccess As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
