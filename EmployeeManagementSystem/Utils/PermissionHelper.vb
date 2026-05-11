Public Class PermissionHelper

    Public Shared Function HasPermission(
        permissionCode As String
    ) As Boolean

        Return CurrentUser.Permissions.Contains(
            permissionCode
        )

    End Function

End Class