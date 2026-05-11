<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.lblCurrentUser = New System.Windows.Forms.Label()
        Me.lblCurrentDateTime = New System.Windows.Forms.Label()
        Me.tmrClock = New System.Windows.Forms.Timer(Me.components)
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnShowEmployeeManagement = New System.Windows.Forms.Button()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblCurrentUser
        '
        Me.lblCurrentUser.AutoSize = True
        Me.lblCurrentUser.Location = New System.Drawing.Point(27, 48)
        Me.lblCurrentUser.Name = "lblCurrentUser"
        Me.lblCurrentUser.Size = New System.Drawing.Size(36, 16)
        Me.lblCurrentUser.TabIndex = 0
        Me.lblCurrentUser.Text = "User"
        '
        'lblCurrentDateTime
        '
        Me.lblCurrentDateTime.AutoSize = True
        Me.lblCurrentDateTime.Location = New System.Drawing.Point(274, 20)
        Me.lblCurrentDateTime.Name = "lblCurrentDateTime"
        Me.lblCurrentDateTime.Size = New System.Drawing.Size(38, 16)
        Me.lblCurrentDateTime.TabIndex = 1
        Me.lblCurrentDateTime.Text = "Time"
        '
        'tmrClock
        '
        Me.tmrClock.Enabled = True
        Me.tmrClock.Interval = 1000
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(513, 16)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(75, 27)
        Me.btnLogout.TabIndex = 2
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnShowEmployeeManagement
        '
        Me.btnShowEmployeeManagement.Location = New System.Drawing.Point(12, 93)
        Me.btnShowEmployeeManagement.Name = "btnShowEmployeeManagement"
        Me.btnShowEmployeeManagement.Size = New System.Drawing.Size(170, 29)
        Me.btnShowEmployeeManagement.TabIndex = 3
        Me.btnShowEmployeeManagement.Text = "Employee management"
        Me.btnShowEmployeeManagement.UseVisualStyleBackColor = True
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(27, 16)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(36, 16)
        Me.lblUser.TabIndex = 4
        Me.lblUser.Text = "User"
        '
        'lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.Location = New System.Drawing.Point(27, 32)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(36, 16)
        Me.lblRole.TabIndex = 5
        Me.lblRole.Text = "User"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 360)
        Me.Controls.Add(Me.lblRole)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.btnShowEmployeeManagement)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.lblCurrentDateTime)
        Me.Controls.Add(Me.lblCurrentUser)
        Me.Name = "frmMain"
        Me.Text = "Main"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCurrentUser As Label
    Friend WithEvents lblCurrentDateTime As Label
    Friend WithEvents tmrClock As Timer
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnShowEmployeeManagement As Button
    Friend WithEvents lblUser As Label
    Friend WithEvents lblRole As Label
End Class
