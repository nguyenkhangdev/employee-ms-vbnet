Public Class frmEmployee
    Private ReadOnly service As New EmployeeService()
    Private ReadOnly departmentService As New DepartmentService()
    Private selectedEmployeeId As Integer

    Private mainForm As frmMain

    Public Sub New(parent As frmMain)
        InitializeComponent()
        mainForm = parent
    End Sub

    Private Sub ClearForm()

        txtEmployeeCode.Clear()

        txtFullName.Clear()

        txtEmail.Clear()

        txtPhone.Clear()

        txtPosition.Clear()

        txtSalary.Clear()

        cmbDepartment.SelectedIndex = -1

        selectedEmployeeId = 0

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        dgvEmployees.DataSource = service.GetEmployees()
    End Sub

    Private Sub LoadEmployees()
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
        btnAdd.Enabled =
        PermissionHelper.HasPermission(
            "EMPLOYEE_ADD"
        )

            btnUpdate.Enabled =
        PermissionHelper.HasPermission(
            "EMPLOYEE_UPDATE"
        )

            btnDelete.Enabled =
        PermissionHelper.HasPermission(
            "EMPLOYEE_DELETE"
        )

        LoadEmployees()
        LoadDepartments()

    End Sub

    Private Sub btnAdd_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAdd.Click

        Try
            Dim employee As New Employee()

            employee.EmployeeCode =
                    txtEmployeeCode.Text

            employee.FullName =
                    txtFullName.Text

            employee.Email =
                    txtEmail.Text

            employee.Phone =
                    txtPhone.Text

            employee.DepartmentId =
                    CInt(cmbDepartment.SelectedValue)

            employee.Position =
                    txtPosition.Text

            Dim salary As Decimal

            If Not Decimal.TryParse(
                txtSalary.Text,
                salary
            ) Then

                MessageBox.Show(
                    "Invalid salary value."
                )

                Return

            End If
            MessageBox.Show(employee.ToString())

            service.InsertEmployee(employee)

            MessageBox.Show(
                    "Employee added successfully."
                )

            LoadEmployees()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub dgvEmployees_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvEmployees.CellClick

        If e.RowIndex < 0 Then
            Return
        End If

        Dim row =
        dgvEmployees.Rows(e.RowIndex)

        Dim employeeId As Integer =
        CInt(row.Cells("EmployeeId").Value)

        selectedEmployeeId = employeeId

        Dim dt =
        service.GetEmployeeById(employeeId)

        If dt.Rows.Count = 0 Then
            Return
        End If

        Dim employeeRow As DataRow =
        dt.Rows(0)

        txtEmployeeCode.Text =
        employeeRow("EmployeeCode").ToString()

        txtFullName.Text =
        employeeRow("FullName").ToString()

        txtEmail.Text =
        employeeRow("Email").ToString()

        txtPhone.Text =
        employeeRow("Phone").ToString()

        txtPosition.Text =
        employeeRow("Position").ToString()

        txtSalary.Text =
        employeeRow("Salary").ToString()

        cmbDepartment.SelectedValue =
        employeeRow("DepartmentId")

    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try

            Dim employee As New Employee()

            employee.EmployeeId = selectedEmployeeId
            MessageBox.Show(selectedEmployeeId)

            employee.EmployeeCode =
                    txtEmployeeCode.Text

            employee.FullName =
                    txtFullName.Text

            employee.Email =
                    txtEmail.Text

            employee.Phone =
                    txtPhone.Text

            employee.DepartmentId =
                    CInt(cmbDepartment.SelectedValue)

            employee.Position =
                    txtPosition.Text

            employee.Salary =
                    Decimal.Parse(txtSalary.Text)

            service.UpdatetEmployee(employee)

            MessageBox.Show(
                    "Employee added successfully."
                )

            LoadEmployees()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

            If selectedEmployeeId = 0 Then

                MessageBox.Show(
                    "Please select employee."
                )

                Return

            End If

            Dim result As DialogResult =
                MessageBox.Show(
                    "Are you sure to delete?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                )

            If result = DialogResult.No Then
                Return
            End If

            service.DeleteEmployee(
                selectedEmployeeId
            )

            MessageBox.Show(
                "Employee deleted successfully."
            )

            LoadEmployees()

            ClearForm()

            selectedEmployeeId = 0

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub frmEmployee_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        mainForm.Show()

    End Sub
End Class
