Imports System.Data.SqlClient
Imports System.Data

Public Class EmployeeRepository

    Public Function GetEmployees() As DataTable

        Dim dt As New DataTable()

        Using conn = DbHelper.GetConnection()

            Dim query As String =
                "SELECT * FROM Employees WHERE IsDeleted = 0"

            Using cmd As New SqlCommand(query, conn)

                Using adapter As New SqlDataAdapter(cmd)

                    conn.Open()
                    adapter.Fill(dt)

                End Using
            End Using
        End Using

        Return dt

    End Function

End Class