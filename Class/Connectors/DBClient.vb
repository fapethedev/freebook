Imports MySql.Data.MySqlClient


Public Class DBClient

    'Les requêtes
    'select -> SELECT * FROM clients;
    'insert -> INSERT INTO clients (profile_picture, lastname, firstname, address, contact, sexe) VALUES([v1], ... [v6])
    'update -> UPDATE clients SET profile_picture, lastname, firstname, address, contact, sexe WHERE id = [v1]
    'delete -> DELETE FROM clients WHERE id = [v1]

    Dim connector As New DBConnector()

    'Obtenir un client par son id
    Public Function GetClientById(id As Integer) As Client

        Dim query = "SELECT * FROM clients WHERE id = @id"

        Dim params(0) As MySqlParameter

        params(0) = New MySqlParameter("@id", MySqlDbType.DateTime) With {.Value = id}

        Dim table As DataTable = connector.GetData(query, params)

        For Each row As DataRow In table.Rows

            Dim client As New Client(
                Convert.ToInt32(row("id")),
                row("profile_picture").ToString(),
                row("lastname").ToString(),
                row("firstname").ToString(),
                row("contact").ToString(),
                row("adress").ToString(),
                row("sexe").ToString()
                )

            Return client
        Next

        Return Nothing

    End Function

    'Obtenir la liste des clients
    Public Function GetClients() As List(Of Client)

        Dim listOfClients As New List(Of Client)

        Dim query = "SELECT * FROM clients"

        Dim clientDataTable As DataTable = connector.GetData(query, Nothing)

        For Each row As DataRow In clientDataTable.Rows

            Dim client As New Client(
                Convert.ToInt32(row("id")),
                row("profile_picture").ToString(),
                row("lastname").ToString(),
                row("firstname").ToString(),
                row("contact").ToString(),
                row("adress").ToString(),
                row("sexe").ToString()
                )

            listOfClients.Add(client)

        Next

        Return listOfClients

    End Function

    'Ajoutez un client
    Public Function AddClient(ByVal client As Client) As Boolean

        Try

            Dim query As String = "
                               INSERT INTO 
                                    clients (profile_picture, lastname, firstname, adress, contact, sexe)
                               VALUES(@val0, @val1, @val2, @val3, @val4, @val5)
                              "

            Dim params(5) As MySqlParameter

            params(0) = New MySqlParameter("@val0", MySqlDbType.VarChar) With {.Value = client.GetProfilePicture}
            params(1) = New MySqlParameter("@val1", MySqlDbType.VarChar) With {.Value = client.GetLastName}
            params(2) = New MySqlParameter("@val2", MySqlDbType.VarChar) With {.Value = client.GetFirstName}
            params(3) = New MySqlParameter("@val3", MySqlDbType.VarChar) With {.Value = client.GetAddress}
            params(4) = New MySqlParameter("@val4", MySqlDbType.VarChar) With {.Value = client.GetContact}
            params(5) = New MySqlParameter("@val5", MySqlDbType.Enum) With {.Value = client.GetSex}

            If connector.SetData(query, params).Equals(1) Then

                Return True

            Else

                Return False

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)
            Return False

        End Try

    End Function

    'Modifier un client
    Public Function ModClient(ByVal client As Client) As Boolean

        Try

            Dim query As String = "UPDATE clients
                                   SET profile_picture=@val0, lastname=@val1, firstname=@val2, adress=@val3, contact=@val4, sexe=@val5 
                                   WHERE id = @id"

            Dim params(6) As MySqlParameter

            params(0) = New MySqlParameter("@val0", MySqlDbType.VarChar) With {.Value = client.GetProfilePicture}
            params(1) = New MySqlParameter("@val1", MySqlDbType.VarChar) With {.Value = client.GetLastName}
            params(2) = New MySqlParameter("@val2", MySqlDbType.VarChar) With {.Value = client.GetFirstName}
            params(3) = New MySqlParameter("@val3", MySqlDbType.VarChar) With {.Value = client.GetAddress}
            params(4) = New MySqlParameter("@val4", MySqlDbType.VarChar) With {.Value = client.GetContact}
            params(5) = New MySqlParameter("@val5", MySqlDbType.VarChar) With {.Value = client.GetSex}
            params(6) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = client.GetId}

            If connector.SetData(query, params).Equals(1) Then

                Return True

            Else

                Return False

            End If

        Catch ex As Exception

            Return False

        End Try

    End Function

    'Supprimez un client
    Public Function DelClient(ByVal client As Client) As Boolean

        Try

            Dim query As String = "DELETE FROM clients WHERE id = @id"

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = client.GetId}

            If connector.SetData(query, params).Equals(1) Then

                Return True

            Else

                Return False

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)


            Return False

        End Try

    End Function

End Class
