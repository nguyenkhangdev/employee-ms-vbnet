Imports System.Security.Cryptography
Imports System.Text

Public Class PasswordHelper

    Public Shared Function HashPassword(
        password As String
    ) As String

        Using sha256 As SHA256 =
            SHA256.Create()

            Dim bytes =
                Encoding.UTF8.GetBytes(password)

            Dim hash =
                sha256.ComputeHash(bytes)

            Return Convert.ToBase64String(hash)

        End Using

    End Function

End Class