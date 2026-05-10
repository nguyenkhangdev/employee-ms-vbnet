Public Class frmLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private ReadOnly authService As New AuthService()

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try

            Dim isSuccess As Boolean =
                AuthService.Login(
                    txtUsername.Text.Trim(),
                    txtPassword.Text
                )

            If Not isSuccess Then

                txtPassword.Clear()

                txtPassword.Focus()

                Return

            End If
            txtPassword.Clear()
            Dim frm As New frmMain()

            frm.Show()

            Me.Hide()


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class
