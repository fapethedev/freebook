Imports MySql.Data.MySqlClient

Public Class DBConnector

    Private connection As New MySqlConnection("Server=localhost;Port=3307;User=root;Password=lordson2076;Database=freebook_database")

    ReadOnly Property getConnection As MySqlConnection
        Get
            Return connection
        End Get
    End Property


    Sub OpenConnection()
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
    End Sub

    Sub CloseConnection()
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub


    Public Function GetData(ByVal query As String, ByVal params() As MySqlParameter) As DataTable

        Dim command As New MySqlCommand(query, connection)

        If params IsNot Nothing Then

            command.Parameters.AddRange(params)

        End If

        Dim table As New DataTable
        Dim adapter As New MySqlDataAdapter With {
            .SelectCommand = command
        }
        adapter.Fill(table)

        Return table

    End Function

    Public Function SetData(ByVal query As String, ByVal params As MySqlParameter()) As Integer

        Dim command As New MySqlCommand(query, connection)

        If params IsNot Nothing Then

            command.Parameters.AddRange(params)

        End If

        OpenConnection()

        Dim commandState As Integer = command.ExecuteNonQuery()

        CloseConnection()

        Return commandState

    End Function

End Class