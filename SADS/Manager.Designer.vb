<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manager
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
        Me.lblFriday = New System.Windows.Forms.Label()
        Me.lblSaturday = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblFriday
        '
        Me.lblFriday.AutoSize = True
        Me.lblFriday.Location = New System.Drawing.Point(22, 28)
        Me.lblFriday.Name = "lblFriday"
        Me.lblFriday.Size = New System.Drawing.Size(97, 13)
        Me.lblFriday.TabIndex = 0
        Me.lblFriday.Text = "Total Sales Friday: "
        '
        'lblSaturday
        '
        Me.lblSaturday.AutoSize = True
        Me.lblSaturday.Location = New System.Drawing.Point(22, 54)
        Me.lblSaturday.Name = "lblSaturday"
        Me.lblSaturday.Size = New System.Drawing.Size(111, 13)
        Me.lblSaturday.TabIndex = 1
        Me.lblSaturday.Text = "Total Sales Saturday: "
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(22, 78)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(34, 13)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.Text = "Total:"
        '
        'btnHome
        '
        Me.btnHome.Location = New System.Drawing.Point(25, 104)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(75, 23)
        Me.btnHome.TabIndex = 3
        Me.btnHome.Text = "Home!"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 142)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblSaturday)
        Me.Controls.Add(Me.lblFriday)
        Me.Name = "Manager"
        Me.Text = "Manager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFriday As System.Windows.Forms.Label
    Friend WithEvents lblSaturday As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents btnHome As System.Windows.Forms.Button
End Class
