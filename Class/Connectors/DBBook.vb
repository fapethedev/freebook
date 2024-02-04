Imports MySql.Data.MySqlClient

Public Class DBBook

    Dim connector As New DBConnector()
    Dim authorDB As DBAuthor = New DBAuthor()
    Dim editorDB As DBEditor = New DBEditor()

    'Obtenir un livre par son id
    Public Function GetBookById(id As Integer) As Book

        Dim query = "SELECT * FROM books WHERE id = @id"

        Dim params(0) As MySqlParameter

        params(0) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = id}

        Dim table As DataTable = connector.GetData(query, params)

        For Each row As DataRow In table.Rows

            Dim book As Book = New Book(
                Convert.ToInt32(row("id")),
                row("cover").ToString(),
                row("title").ToString(),
                row("isbn").ToString(),
                Convert.ToDateTime(row("published")),
                Convert.ToInt32(row("total_quantity")),
                Convert.ToBoolean(row("isAvailable"))
                ) With {
                .SetAuthor = authorDB.GetAuthorById(Convert.ToInt32(row("author_id"))),
                .SetEditor = editorDB.GetEditorById(Convert.ToInt32(row("editor_id")))
                }

            Return book

        Next

        Return Nothing

    End Function

    'Obtenir la liste de tous les livres
    Public Function GetBooks() As List(Of Book)

        Dim listOfBook As New List(Of Book)

        Dim query = "SELECT * FROM books"

        Dim bookDataTable As DataTable = connector.GetData(query, Nothing)

        For Each row As DataRow In bookDataTable.Rows

            Dim book As Book = New Book(
                Convert.ToInt32(row("id")),
                row("cover").ToString(),
                row("title").ToString(),
                row("isbn").ToString(),
                Convert.ToDateTime(row("published")),
                Convert.ToInt32(row("total_quantity")),
                Convert.ToBoolean(row("isAvailable"))
                ) With {
                .SetAuthor = authorDB.GetAuthorById(Convert.ToInt32(row("author_id"))),
                .SetEditor = editorDB.GetEditorById(Convert.ToInt32(row("editor_id")))
                }

            listOfBook.Add(book)

        Next

        Return listOfBook

    End Function

    'Ajoutez un livre
    Public Function AddBook(ByVal book As Book) As Boolean

        Try

            Dim query As String = "
                               INSERT INTO 
                                    books (cover, title, isbn, published, total_quantity, available_quantity, isAvailable, author_id, editor_id)
                               VALUES(@val0, @val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8)
                              "

            Dim params(8) As MySqlParameter

            params(0) = New MySqlParameter("@val0", MySqlDbType.VarChar) With {.Value = book.GetCover}
            params(1) = New MySqlParameter("@val1", MySqlDbType.VarChar) With {.Value = book.GetTitle}
            params(2) = New MySqlParameter("@val2", MySqlDbType.VarChar) With {.Value = book.GetIsbn}
            params(3) = New MySqlParameter("@val3", MySqlDbType.DateTime) With {.Value = book.GetPublished}
            params(4) = New MySqlParameter("@val4", MySqlDbType.Int32) With {.Value = book.GetQte}
            params(5) = New MySqlParameter("@val5", MySqlDbType.Int32) With {.Value = book.GetQte}
            params(6) = New MySqlParameter("@val6", MySqlDbType.Byte) With {.Value = book.GetAvailabilty}
            params(7) = New MySqlParameter("@val7", MySqlDbType.Int32) With {.Value = book.GetAuthor.GetId}
            params(8) = New MySqlParameter("@val8", MySqlDbType.Int32) With {.Value = book.GetEditor.GetId}

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

    'Modifier un livre
    Public Function ModBook(ByVal book As Book) As Boolean

        Try

            Dim query As String = "UPDATE books 
                                SET cover=@val0, title=@val1, isbn=@val2, published=@val3, total_quantity=@val4,
                                    available_quantity=@val5, isAvailable=@val6, author_id=@val7, editor_id=@val8
                               WHERE id = @id"

            Dim params(9) As MySqlParameter

            params(0) = New MySqlParameter("@val0", MySqlDbType.VarChar) With {.Value = book.GetCover}
            params(1) = New MySqlParameter("@val1", MySqlDbType.VarChar) With {.Value = book.GetTitle}
            params(2) = New MySqlParameter("@val2", MySqlDbType.VarChar) With {.Value = book.GetIsbn}
            params(3) = New MySqlParameter("@val3", MySqlDbType.DateTime) With {.Value = book.GetPublished}
            params(4) = New MySqlParameter("@val4", MySqlDbType.Int32) With {.Value = book.GetQte}
            params(5) = New MySqlParameter("@val5", MySqlDbType.Int32) With {.Value = book.GetQte}
            params(6) = New MySqlParameter("@val6", MySqlDbType.Byte) With {.Value = book.GetAvailabilty}
            params(7) = New MySqlParameter("@val7", MySqlDbType.Int32) With {.Value = book.GetAuthor.GetId}
            params(8) = New MySqlParameter("@val8", MySqlDbType.Int32) With {.Value = book.GetEditor.GetId}
            params(9) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = book.GetId}

            If connector.SetData(query, params).Equals(1) Then

                Return True

            Else

                Return False

            End If

        Catch ex As Exception

            Return False

        End Try

    End Function

    'Supprimez un livre
    Public Function DelBook(ByVal book As Book) As Boolean

        Try

            Dim query As String = "
                                DELETE FROM books WHERE id = @id
                              "
            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = book.GetId}

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
