Imports System.Data.SqlClient

Public Class DepartmentRepository
    Public Function GetDepartments() As DataTable

        Dim dt As New DataTable()

        Using conn = DbHelper.GetConnection()

            Using cmd As New SqlCommand("sp_Department_GetAll", conn)

                cmd.CommandType = CommandType.StoredProcedure

                Using adapter As New SqlDataAdapter(cmd)

                    conn.Open()
                    adapter.Fill(dt)

                End Using
            End Using
        End Using

        Return dt

    End Function
End Class
