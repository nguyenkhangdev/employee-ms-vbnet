Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblCurrentUser.Text = "Welcome, " &
            CurrentUser.FullName & " (" &
            CurrentUser.RoleName & ")"

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

        CurrentUser.Clear()
        Application.Restart()
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
End Class