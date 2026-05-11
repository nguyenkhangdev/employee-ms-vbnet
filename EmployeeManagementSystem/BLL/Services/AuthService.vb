Imports System.Data
Imports EmployeeManagementSystem.AuditEnums
Imports Microsoft.VisualBasic.ApplicationServices

Public Class AuthService

    Private ReadOnly repository As New UserRepository()
    Private ReadOnly auditService As New AuditLogService()

    Public Function Login(
        username As String,
        password As String
    ) As Boolean

        If String.IsNullOrWhiteSpace(username) Then

            Throw New Exception(
                "Username is required."
            )

        End If

        If String.IsNullOrWhiteSpace(password) Then

            Throw New Exception(
                "Password is required."
            )

        End If

        Dim passwordHash As String =
            PasswordHelper.HashPassword(password)

        Dim dt As DataTable =
            repository.Login(
                username,
                passwordHash
            )

        If dt.Rows.Count = 0 Then

            Return False

        End If

        Dim row As DataRow =
            dt.Rows(0)

        CurrentUser.UserId =
            Convert.ToInt32(row("UserId"))

        CurrentUser.Username =
            row("Username").ToString()

        CurrentUser.FullName =
            row("FullName").ToString()

        CurrentUser.RoleName =
            row("RoleName").ToString()

        Dim permissionRepo As New PermissionRepository()

        CurrentUser.Permissions = permissionRepo.GetPermissionsByUser(
            CurrentUser.UserId
        )

        auditService.Log(
            AuditAction.Login.ToString(),
            AuditTable.Users.ToString(),
            Convert.ToInt32(row("UserId")),
            "",
            ""
        )

        Return True

    End Function

    Public Function Logout() As Boolean

        auditService.Log(
            AuditAction.Logout.ToString(),
            AuditTable.Users.ToString(),
            CurrentUser.UserId,
            "",
            ""
        )
        Return True
    End Function

End Class