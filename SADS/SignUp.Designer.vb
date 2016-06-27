<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignUp
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
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.lblSurname = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblComfirmPassword = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblusername = New System.Windows.Forms.Label()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.txtEnterPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(205, 280)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(122, 23)
        Me.btnCreate.TabIndex = 33
        Me.btnCreate.Text = "Create Account"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(173, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Register"
        '
        'lblDOB
        '
        Me.lblDOB.AutoSize = True
        Me.lblDOB.Location = New System.Drawing.Point(40, 247)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(68, 13)
        Me.lblDOB.TabIndex = 31
        Me.lblDOB.Text = "Date of birth:"
        '
        'lblSurname
        '
        Me.lblSurname.AutoSize = True
        Me.lblSurname.Location = New System.Drawing.Point(40, 209)
        Me.lblSurname.Name = "lblSurname"
        Me.lblSurname.Size = New System.Drawing.Size(52, 13)
        Me.lblSurname.TabIndex = 30
        Me.lblSurname.Text = "Surname:"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(40, 183)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(60, 13)
        Me.lblFirstName.TabIndex = 29
        Me.lblFirstName.Text = "First Name:"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(40, 157)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(35, 13)
        Me.lblEmail.TabIndex = 28
        Me.lblEmail.Text = "Email:"
        '
        'lblComfirmPassword
        '
        Me.lblComfirmPassword.AutoSize = True
        Me.lblComfirmPassword.Location = New System.Drawing.Point(40, 131)
        Me.lblComfirmPassword.Name = "lblComfirmPassword"
        Me.lblComfirmPassword.Size = New System.Drawing.Size(94, 13)
        Me.lblComfirmPassword.TabIndex = 27
        Me.lblComfirmPassword.Text = "Confirm Password:"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(40, 105)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 13)
        Me.lblPassword.TabIndex = 26
        Me.lblPassword.Text = "Password:"
        '
        'lblusername
        '
        Me.lblusername.AutoSize = True
        Me.lblusername.Location = New System.Drawing.Point(40, 79)
        Me.lblusername.Name = "lblusername"
        Me.lblusername.Size = New System.Drawing.Size(58, 13)
        Me.lblusername.TabIndex = 25
        Me.lblusername.Text = "Username:"
        '
        'txtSurname
        '
        Me.txtSurname.Location = New System.Drawing.Point(141, 206)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(186, 20)
        Me.txtSurname.TabIndex = 23
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(141, 180)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(186, 20)
        Me.txtFirstName.TabIndex = 22
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(141, 154)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(186, 20)
        Me.txtEmail.TabIndex = 21
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(141, 128)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(186, 20)
        Me.txtConfirmPassword.TabIndex = 20
        Me.txtConfirmPassword.UseSystemPasswordChar = True
        '
        'txtEnterPassword
        '
        Me.txtEnterPassword.Location = New System.Drawing.Point(141, 102)
        Me.txtEnterPassword.Name = "txtEnterPassword"
        Me.txtEnterPassword.Size = New System.Drawing.Size(186, 20)
        Me.txtEnterPassword.TabIndex = 19
        Me.txtEnterPassword.UseSystemPasswordChar = True
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(141, 76)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(186, 20)
        Me.txtUserName.TabIndex = 18
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(25, 12)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 17
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'cboDay
        '
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Location = New System.Drawing.Point(141, 253)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(58, 21)
        Me.cboDay.TabIndex = 34
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(205, 253)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(58, 21)
        Me.cboMonth.TabIndex = 35
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(269, 253)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(58, 21)
        Me.cboYear.TabIndex = 36
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(155, 235)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(29, 13)
        Me.lblDay.TabIndex = 37
        Me.lblDay.Text = "Day:"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(214, 235)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(40, 13)
        Me.lblMonth.TabIndex = 38
        Me.lblMonth.Text = "Month:"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(278, 235)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(32, 13)
        Me.lblYear.TabIndex = 39
        Me.lblYear.Text = "Year:"
        '
        'SignUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 343)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDOB)
        Me.Controls.Add(Me.lblSurname)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblComfirmPassword)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblusername)
        Me.Controls.Add(Me.txtSurname)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.txtEnterPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.btnBack)
        Me.Name = "SignUp"
        Me.Text = "SignUp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDOB As System.Windows.Forms.Label
    Friend WithEvents lblSurname As System.Windows.Forms.Label
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblComfirmPassword As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblusername As System.Windows.Forms.Label
    Friend WithEvents txtSurname As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtEnterPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents cboDay As System.Windows.Forms.ComboBox
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
End Class
