Public Class frmMain
    Private ReadOnly authService As New AuthService()

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUser.Text =
        "User: " & CurrentUser.Username

        lblRole.Text =
        "Role: " & CurrentUser.RoleName

        lblCurrentUser.Text =
        "Welcome, " & CurrentUser.FullName

        If Not PermissionHelper.HasPermission("EMPLOYEE_VIEW") Then
            btnShowEmployeeManagement.Enabled = False
        End If

    End Sub

    Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
        lblCurrentDateTime.Text = DateTime.Now.ToString(
            "dd/MM/yyyy HH:mm:ss"
        )
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result As DialogResult =
       MessageBox.Show(
           "Are you sure you want to logout?",
           "Logout",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question
       )

        If result = DialogResult.No Then
            Return
        End If

        Dim logout = authService.Logout()
        If logout Then
            Application.Restart()
        End If
        If Not logout Then
            MessageBox.Show(
           "Logout have an error!")
        End If
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub btnShowEmployeeManagement_Click(sender As Object, e As EventArgs) Handles btnShowEmployeeManagement.Click
        If Not PermissionHelper.HasPermission("EMPLOYEE_VIEW") Then
            MessageBox.Show("Access denied")
            Return
        End If

        Dim frm As New frmEmployee(Me)
        frm.Show()
        Me.Hide()
    End Sub

End Class