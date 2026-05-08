Imports System.Data.SqlClient

Public Class DbHelper

    Private Shared ReadOnly connectionString As String =
            "Server=localhost\SQLEXPRESS;Database=EmployeeManagementDB;Trusted_Connection=True;"

    Public Shared Function GetConnection() As SqlConnection
            Return New SqlConnection(connectionString)
        End Function

End Class
