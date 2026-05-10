Imports System.Data.SqlClient

Public Class UserRepository
    Public Function Login(
        username As String,
        passwordHash As String
    ) As DataTable
        Dim dt As New DataTable()

        Using conn = DbHelper.GetConnection()

            Using cmd As New SqlCommand(
                "sp_User_Login",
                conn
            )

                cmd.CommandType =
                    CommandType.StoredProcedure

                cmd.Parameters.AddWithValue(
                    "@Username",
                    username
                )

                cmd.Parameters.AddWithValue(
                    "@PasswordHash",
                    passwordHash
                )

                Using adapter As New SqlDataAdapter(cmd)

                    conn.Open()

                    adapter.Fill(dt)

                End Using

            End Using

        End Using

        Return dt
    End Function
End Class
