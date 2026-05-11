Imports System.Data.SqlClient



Public Class AuditLogRepository
    Public Function Log(
    Action As String,
    tableName As String,
    recordId As Integer,
    oldValue As String,
    newValue As String
) As DataTable

        Dim dt As New DataTable()

        Using conn = DbHelper.GetConnection()

            Using cmd As New SqlCommand("sp_AuditLog_Log", conn)

                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserId", CurrentUser.UserId)
                cmd.Parameters.AddWithValue("@Action", Action)
                cmd.Parameters.AddWithValue("@TableName", tableName)

                If recordId > 0 Then
                    cmd.Parameters.AddWithValue("@RecordId", recordId)
                End If

                If Not String.IsNullOrWhiteSpace(oldValue) Then
                    cmd.Parameters.AddWithValue("@OldValue", oldValue)
                Else
                    cmd.Parameters.AddWithValue("@OldValue", DBNull.Value)
                End If

                If Not String.IsNullOrWhiteSpace(newValue) Then
                    cmd.Parameters.AddWithValue("@NewValue", newValue)
                Else
                    cmd.Parameters.AddWithValue("@NewValue", DBNull.Value)
                End If

                Using adapter As New SqlDataAdapter(cmd)

                    conn.Open()
                    adapter.Fill(dt)

                End Using

            End Using

        End Using

        Return dt

    End Function
End Class
