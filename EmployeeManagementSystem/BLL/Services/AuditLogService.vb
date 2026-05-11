
Public Class AuditLogService


    Private ReadOnly repository As New AuditLogRepository()

    Public Function Log(
        action As String,
        tableName As String,
        recordId As Integer,
        oldValue As String,
        newValue As String
    ) As Boolean

        Dim dt As DataTable =
            repository.Log(action, tableName, recordId, oldValue, newValue)

        If dt.Rows.Count = 0 Then

            Return False

        End If

        Return True

    End Function

End Class