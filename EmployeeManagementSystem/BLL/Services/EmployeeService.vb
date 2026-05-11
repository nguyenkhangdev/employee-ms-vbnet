Imports System.Data
Imports System.Text.RegularExpressions
Imports EmployeeManagementSystem.AuditEnums

Public Class EmployeeService

    Private ReadOnly repository As New EmployeeRepository()
    Private ReadOnly auditService As New AuditLogService()

    Public Function GetEmployeeById(Employee As String) As DataTable

        Return repository.GetEmployeeById(Employee)

    End Function

    Public Function GetEmployees() As DataTable

        Return repository.GetEmployees()

    End Function

    Public Sub InsertEmployee(employee As Employee)

        If String.IsNullOrWhiteSpace(
            employee.EmployeeCode
        ) Then

            Throw New Exception(
                "Employee Code is required."
            )

        End If

        If String.IsNullOrWhiteSpace(
            employee.FullName
        ) Then

            Throw New Exception(
                "Full Name is required."
            )

        End If

        If Not String.IsNullOrWhiteSpace(employee.Email) Then
            Dim emailPattern As String =
            "^[^@\s]+@[^@\s]+\.[^@\s]+$"

            If Not Regex.IsMatch(
            employee.Email,
            emailPattern
        ) Then

                Throw New Exception(
            "Invalid email format."
        )

            End If

        End If

        If employee.Salary <= 0 Then

            Throw New Exception(
            "Salary must be greater than 0."
        )
        End If


        repository.InsertEmployee(employee)
        auditService.Log(
            AuditAction.Insert.ToString(),
            AuditTable.Employees.ToString(),
            employee.EmployeeId,
            "",
            ""
        )
    End Sub

    Public Sub UpdatetEmployee(employee As Employee)

        If String.IsNullOrWhiteSpace(
            employee.EmployeeCode
        ) Then

            Throw New Exception(
                "Employee Code is required."
            )

        End If

        If String.IsNullOrWhiteSpace(
            employee.FullName
        ) Then

            Throw New Exception(
                "Full Name is required."
            )

        End If

        If Not String.IsNullOrWhiteSpace(employee.Email) Then
            Dim emailPattern As String =
            "^[^@\s]+@[^@\s]+\.[^@\s]+$"

            If Not Regex.IsMatch(
            employee.Email,
            emailPattern
        ) Then

                Throw New Exception(
            "Invalid email format."
        )

            End If

        End If

        If employee.Salary <= 0 Then

            Throw New Exception(
            "Salary must be greater than 0."
        )
        End If

        repository.updateEmployee(employee)
        auditService.Log(
            AuditAction.Update.ToString(),
            AuditTable.Employees.ToString(),
            employee.EmployeeId,
            "",
            ""
        )
    End Sub

    Public Sub DeleteEmployee(
    employeeId As Integer
)

        If employeeId <= 0 Then

            Throw New Exception(
                "Invalid employee."
            )

        End If

        repository.DeleteEmployee(employeeId)
        auditService.Log(
            AuditAction.Delete.ToString(),
            AuditTable.Employees.ToString(),
            employeeId,
            "",
            ""
        )
    End Sub

End Class