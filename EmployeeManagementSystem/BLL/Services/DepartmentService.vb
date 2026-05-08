Public Class DepartmentService
    Private ReadOnly repository As New DepartmentRepository()

    Public Function GetDepartments() As DataTable

        Return repository.GetDepartments()

    End Function
End Class
