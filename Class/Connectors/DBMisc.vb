﻿Imports MySql.Data.MySqlClient

Public Class DBMisc

    Dim connector As New DBConnector()

    Public Function GetUserById(id As Integer) As ActualUser

        Dim user As ActualUser

        Dim query = "SELECT * FROM users WHERE id = @id"

        Dim params(0) As MySqlParameter

        params(0) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = id}

        Dim table As DataTable = connector.GetData(query, params)

        For Each row As DataRow In table.Rows

            user = New ActualUser(Convert.ToInt32(row("id")), row("username"))

            'Return user
        Next

        Return user
        'Return Nothing

    End Function

End Class
