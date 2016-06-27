<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Homepage
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
        Me.btnMyBookings = New System.Windows.Forms.Button()
        Me.btnBookTickets = New System.Windows.Forms.Button()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnManager = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnMyBookings
        '
        Me.btnMyBookings.Location = New System.Drawing.Point(74, 68)
        Me.btnMyBookings.Name = "btnMyBookings"
        Me.btnMyBookings.Size = New System.Drawing.Size(129, 57)
        Me.btnMyBookings.TabIndex = 0
        Me.btnMyBookings.Text = "MyBookings"
        Me.btnMyBookings.UseVisualStyleBackColor = True
        '
        'btnBookTickets
        '
        Me.btnBookTickets.Location = New System.Drawing.Point(74, 131)
        Me.btnBookTickets.Name = "btnBookTickets"
        Me.btnBookTickets.Size = New System.Drawing.Size(129, 55)
        Me.btnBookTickets.TabIndex = 1
        Me.btnBookTickets.Text = "Book Tickets"
        Me.btnBookTickets.UseVisualStyleBackColor = True
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Location = New System.Drawing.Point(33, 13)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(52, 13)
        Me.lblWelcome.TabIndex = 2
        Me.lblWelcome.Text = "Welcome"
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(197, 13)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(75, 23)
        Me.btnLogout.TabIndex = 3
        Me.btnLogout.Text = "Log out"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnManager
        '
        Me.btnManager.Location = New System.Drawing.Point(74, 192)
        Me.btnManager.Name = "btnManager"
        Me.btnManager.Size = New System.Drawing.Size(129, 41)
        Me.btnManager.TabIndex = 401
        Me.btnManager.Text = "Manager"
        Me.btnManager.UseVisualStyleBackColor = True
        '
        'Homepage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnManager)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.btnBookTickets)
        Me.Controls.Add(Me.btnMyBookings)
        Me.Name = "Homepage"
        Me.Text = "Homepage"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMyBookings As System.Windows.Forms.Button
    Friend WithEvents btnBookTickets As System.Windows.Forms.Button
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents btnManager As System.Windows.Forms.Button
End Class
