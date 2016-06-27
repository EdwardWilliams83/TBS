<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyBookings
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
        Me.lblMyBookings = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPerformance = New System.Windows.Forms.ComboBox()
        Me.lblSeatNumber = New System.Windows.Forms.Label()
        Me.lblTotalCost = New System.Windows.Forms.Label()
        Me.lstSeatNumber = New System.Windows.Forms.ListBox()
        Me.lstCost = New System.Windows.Forms.ListBox()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblMyBookings
        '
        Me.lblMyBookings.AutoSize = True
        Me.lblMyBookings.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMyBookings.Location = New System.Drawing.Point(184, 12)
        Me.lblMyBookings.Name = "lblMyBookings"
        Me.lblMyBookings.Size = New System.Drawing.Size(113, 24)
        Me.lblMyBookings.TabIndex = 0
        Me.lblMyBookings.Text = "MyBookings"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(208, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Performance:"
        '
        'cboPerformance
        '
        Me.cboPerformance.FormattingEnabled = True
        Me.cboPerformance.Location = New System.Drawing.Point(169, 62)
        Me.cboPerformance.Name = "cboPerformance"
        Me.cboPerformance.Size = New System.Drawing.Size(152, 21)
        Me.cboPerformance.TabIndex = 2
        '
        'lblSeatNumber
        '
        Me.lblSeatNumber.AutoSize = True
        Me.lblSeatNumber.Location = New System.Drawing.Point(148, 120)
        Me.lblSeatNumber.Name = "lblSeatNumber"
        Me.lblSeatNumber.Size = New System.Drawing.Size(72, 13)
        Me.lblSeatNumber.TabIndex = 3
        Me.lblSeatNumber.Text = "Seat Number:"
        '
        'lblTotalCost
        '
        Me.lblTotalCost.AutoSize = True
        Me.lblTotalCost.Location = New System.Drawing.Point(297, 119)
        Me.lblTotalCost.Name = "lblTotalCost"
        Me.lblTotalCost.Size = New System.Drawing.Size(31, 13)
        Me.lblTotalCost.TabIndex = 4
        Me.lblTotalCost.Text = "Cost:"
        '
        'lstSeatNumber
        '
        Me.lstSeatNumber.FormattingEnabled = True
        Me.lstSeatNumber.Location = New System.Drawing.Point(122, 136)
        Me.lstSeatNumber.Name = "lstSeatNumber"
        Me.lstSeatNumber.Size = New System.Drawing.Size(120, 95)
        Me.lstSeatNumber.TabIndex = 5
        '
        'lstCost
        '
        Me.lstCost.FormattingEnabled = True
        Me.lstCost.Location = New System.Drawing.Point(252, 136)
        Me.lstCost.Name = "lstCost"
        Me.lstCost.Size = New System.Drawing.Size(120, 95)
        Me.lstCost.TabIndex = 6
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(418, 12)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(75, 23)
        Me.btnLogout.TabIndex = 7
        Me.btnLogout.Text = "Log out"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(122, 238)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(250, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.Location = New System.Drawing.Point(418, 42)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(75, 23)
        Me.btnHome.TabIndex = 9
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(178, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Select a seat to view cost:"
        '
        'MyBookings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 284)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.lstCost)
        Me.Controls.Add(Me.lstSeatNumber)
        Me.Controls.Add(Me.lblTotalCost)
        Me.Controls.Add(Me.lblSeatNumber)
        Me.Controls.Add(Me.cboPerformance)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMyBookings)
        Me.Name = "MyBookings"
        Me.Text = "MyBookings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMyBookings As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPerformance As System.Windows.Forms.ComboBox
    Friend WithEvents lblSeatNumber As System.Windows.Forms.Label
    Friend WithEvents lblTotalCost As System.Windows.Forms.Label
    Friend WithEvents lstSeatNumber As System.Windows.Forms.ListBox
    Friend WithEvents lstCost As System.Windows.Forms.ListBox
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
