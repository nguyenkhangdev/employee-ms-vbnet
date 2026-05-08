Imports System.Data

Public Class EmployeeService

    Private ReadOnly repository As New EmployeeRepository()

    Public Function GetEmployees() As DataTable

        Return repository.GetEmployees()

    End Function

End Class