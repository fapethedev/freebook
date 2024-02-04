Imports MySql.Data.MySqlClient


Public Class DBAuthor

    'Les requêtes

    Dim connector As New DBConnector()

    'Obtenir un auteur par son id
    Public Function GetAuthorById(id As Integer) As Author

        Dim query = "SELECT * FROM authors WHERE id = @id"

        Dim params(0) As MySqlParameter

        params(0) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = id}

        Dim table As DataTable = connector.GetData(query, params)

        For Each row As DataRow In table.Rows

            Dim author As New Author(
                Convert.ToInt32(row("id")),
                row("lastname").ToString(),
                row("firstname").ToString(),
                row("nationality").ToString(),
                row("bio").ToString(),
                row("citation").ToString()
                )

            Return author
        Next

        Return Nothing

    End Function

    'Liste des auteurs
    Public Function GetAuthors() As List(Of Author)

        Dim listOfAuthors As New List(Of Author)

        Dim query = "SELECT * FROM authors"

        Dim authorDataTable As DataTable = connector.GetData(query, Nothing)

        For Each row As DataRow In authorDataTable.Rows
            Dim author As New Author(
                Convert.ToInt32(row("id")),
                row("lastname").ToString(),
                row("firstname").ToString(),
                row("nationality").ToString(),
                row("bio").ToString(),
                row("citation").ToString()
                )

            listOfAuthors.Add(author)
        Next

        Return listOfAuthors

    End Function

    'Ajoutez un auteur
    Public Function AddAuthor(ByVal author As Author) As Boolean

        Try

            Dim query As String = "
                               INSERT INTO 
                                    authors (lastname, firstname, nationality, bio, citation)
                               VALUES(@val0, @val1, @val2, @val3, @val4)
                              "

            Dim params(4) As MySqlParameter

            params(0) = New MySqlParameter("@val0", MySqlDbType.VarChar) With {.Value = author.GetLastName}
            params(1) = New MySqlParameter("@val1", MySqlDbType.VarChar) With {.Value = author.GetFirstName}
            params(2) = New MySqlParameter("@val2", MySqlDbType.VarChar) With {.Value = author.GetNationality}
            params(3) = New MySqlParameter("@val3", MySqlDbType.VarChar) With {.Value = author.GetBio}
            params(4) = New MySqlParameter("@val4", MySqlDbType.VarChar) With {.Value = author.GetCitation}

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

    'Modifier un auteur
    Public Function ModAuthor(ByVal author As Author) As Boolean

        Try

            Dim query As String = "UPDATE authors
                                   SET lastname=@val0, firstname=@val1, nationality=@val2, bio=@val3, citation=@val4
                                   WHERE id = @id"

            Dim params(5) As MySqlParameter

            params(0) = New MySqlParameter("@val0", MySqlDbType.VarChar) With {.Value = author.GetLastName}
            params(1) = New MySqlParameter("@val1", MySqlDbType.VarChar) With {.Value = author.GetFirstName}
            params(2) = New MySqlParameter("@val2", MySqlDbType.VarChar) With {.Value = author.GetNationality}
            params(3) = New MySqlParameter("@val3", MySqlDbType.VarChar) With {.Value = author.GetBio}
            params(4) = New MySqlParameter("@val4", MySqlDbType.VarChar) With {.Value = author.GetCitation}
            params(5) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = author.GetId}

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

    'Supprimez un auteur
    Public Function DelAuthor(ByVal author As Author) As Boolean

        Try

            Dim query As String = "DELETE FROM authors WHERE id = @id"

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = author.GetId}

            If connector.SetData(query, params).Equals(1) Then

                Return True

            Else

                Return False

            End If

        Catch ex As Exception

            Return False

        End Try

    End Function

End Class
