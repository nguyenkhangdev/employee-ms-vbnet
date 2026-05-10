Public Class CurrentUser

    Public Shared UserId As Integer

    Public Shared Username As String

    Public Shared FullName As String

    Public Shared RoleName As String

    Public Shared Sub Clear()

        UserId = 0

        Username = String.Empty

        FullName = String.Empty

        RoleName = String.Empty

    End Sub

End Class