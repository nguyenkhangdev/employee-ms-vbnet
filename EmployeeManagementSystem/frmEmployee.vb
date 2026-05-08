Public Class frmEmployee
    Private ReadOnly service As New EmployeeService()
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        dgvEmployees.DataSource = service.GetEmployees()
    End Sub
End Class
