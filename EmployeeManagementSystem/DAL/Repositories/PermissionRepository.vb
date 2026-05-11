Imports System.Data
Imports System.Data.SqlClient

Public Class PermissionRepository

    Public Function GetPermissionsByUser(
        userId As Integer
    ) As List(Of String)

        Dim permissions As New List(Of String)

        Using conn = DbHelper.GetConnection()

            Using cmd As New SqlCommand(
                "sp_Permission_GetByUser",
                conn
            )

                cmd.CommandType =
                    CommandType.StoredProcedure

                cmd.Parameters.AddWithValue(
                    "@UserId",
                    userId
                )

                conn.Open()

                Using reader =
                    cmd.ExecuteReader()

                    While reader.Read()

                        permissions.Add(
                            reader(
                                "PermissionCode"
                            ).ToString()
                        )

                    End While

                End Using

            End Using

        End Using

        Return permissions

    End Function

End Class