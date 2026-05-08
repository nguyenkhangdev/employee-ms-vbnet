Public Class frmEmployee
    Private ReadOnly service As New EmployeeService()
    Private ReadOnly departmentService As New DepartmentService()

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        dgvEmployees.DataSource = service.GetEmployees()
    End Sub

    Private Sub LoadDepartments()

        Dim dt As DataTable =
            departmentService.GetDepartments()

        cmbDepartment.DataSource = dt

        cmbDepartment.DisplayMember =
            "DepartmentName"

        cmbDepartment.ValueMember =
            "DepartmentId"

    End Sub

    Private Sub frmEmployee_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        LoadDepartments()

    End Sub
End Class
