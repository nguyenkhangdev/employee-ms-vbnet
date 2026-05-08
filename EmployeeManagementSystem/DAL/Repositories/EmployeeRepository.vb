Imports System.Data.SqlClient
Imports System.Data

Public Class EmployeeRepository

    Public Function GetEmployeeById(
        employeeId As Integer
    ) As DataTable

        Dim dt As New DataTable()

        Using conn = DbHelper.GetConnection()

            Using cmd As New SqlCommand(
                "sp_Employee_GetOneById",
                conn
            )

                cmd.CommandType =
                    CommandType.StoredProcedure

                cmd.Parameters.AddWithValue(
                    "@EmployeeId",
                    employeeId
                )

                Using adapter As New SqlDataAdapter(cmd)

                    conn.Open()

                    adapter.Fill(dt)

                End Using

            End Using

        End Using

        Return dt

    End Function

    Public Function GetEmployees() As DataTable

        Dim dt As New DataTable()

        Using conn = DbHelper.GetConnection()

            Using cmd As New SqlCommand("sp_Employee_GetAll", conn)

                cmd.CommandType = CommandType.StoredProcedure

                Using adapter As New SqlDataAdapter(cmd)

                    conn.Open()
                    adapter.Fill(dt)

                End Using
            End Using
        End Using

        Return dt

    End Function

    Public Sub InsertEmployee(employee As Employee)

        Using conn = DbHelper.GetConnection()

            Using cmd As New SqlCommand(
                "sp_Employee_Insert",
                conn
            )

                cmd.CommandType =
                    CommandType.StoredProcedure

                cmd.Parameters.AddWithValue(
                    "@EmployeeCode",
                    employee.EmployeeCode
                )

                cmd.Parameters.AddWithValue(
                    "@FullName",
                    employee.FullName
                )

                cmd.Parameters.AddWithValue(
                    "@Email",
                    employee.Email
                )

                cmd.Parameters.AddWithValue(
                    "@Phone",
                    employee.Phone
                )

                cmd.Parameters.AddWithValue(
                    "@DepartmentId",
                    employee.DepartmentId
                )

                cmd.Parameters.AddWithValue(
                    "@Position",
                    employee.Position
                )

                cmd.Parameters.AddWithValue(
                    "@Salary",
                    employee.Salary
                )

                conn.Open()

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

    Public Sub updateEmployee(employee As Employee)

        Using conn = DbHelper.GetConnection()

            Using cmd As New SqlCommand(
                "sp_Employee_Update",
                conn
            )

                cmd.CommandType =
                    CommandType.StoredProcedure

                cmd.Parameters.AddWithValue(
                    "@EmployeeId",
                    employee.EmployeeId
                )

                cmd.Parameters.AddWithValue(
                    "@EmployeeCode",
                    employee.EmployeeCode
                )

                cmd.Parameters.AddWithValue(
                    "@FullName",
                    employee.FullName
                )

                cmd.Parameters.AddWithValue(
                    "@Email",
                    employee.Email
                )

                cmd.Parameters.AddWithValue(
                    "@Phone",
                    employee.Phone
                )

                cmd.Parameters.AddWithValue(
                    "@DepartmentId",
                    employee.DepartmentId
                )

                cmd.Parameters.AddWithValue(
                    "@Position",
                    employee.Position
                )

                cmd.Parameters.AddWithValue(
                    "@Salary",
                    employee.Salary
                )

                conn.Open()

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

    Public Sub DeleteEmployee(
    employeeId As Integer
)

        Using conn = DbHelper.GetConnection()

            Using cmd As New SqlCommand(
            "sp_Employee_Delete",
            conn
        )

                cmd.CommandType =
                CommandType.StoredProcedure

                cmd.Parameters.AddWithValue(
                "@EmployeeId",
                employeeId
            )

                conn.Open()

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub
End Class