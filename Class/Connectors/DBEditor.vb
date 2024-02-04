Imports MySql.Data.MySqlClient


Public Class DBEditor

    Dim connector As New DBConnector()

    'Obtenir un éditeur par son id
    Public Function GetEditorById(id As Integer) As Editor

        Dim query = "SELECT * FROM editors WHERE id = @id"

        Dim params(0) As MySqlParameter

        params(0) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = id}

        Dim table As DataTable = connector.GetData(query, params)

        For Each row As DataRow In table.Rows

            Dim editor = New Editor(
                Convert.ToInt32(row("id")),
                row("label").ToString(),
                row("location").ToString())

            Return editor
        Next

        Return Nothing

    End Function

    'Obtenir la liste des éditeur
    Public Function GetEditors() As List(Of Editor)

        Dim listOfEditor As New List(Of Editor)

        Dim query = "SELECT * FROM editors"

        Dim editorDataTable As DataTable = connector.GetData(query, Nothing)

        For Each row As DataRow In editorDataTable.Rows

            Dim editor As New Editor(
                Convert.ToInt32(row("id")),
                row("label").ToString(),
                row("location").ToString())

            listOfEditor.Add(editor)

        Next

        Return listOfEditor

    End Function

    'Ajoutez un éditeur
    Public Function AddEditor(ByVal editor As Editor) As Boolean

        Try

            Dim query As String = "INSERT INTO editors (label, location) VALUES(@val0, @val1)"

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("@val0", MySqlDbType.VarChar) With {.Value = editor.GetLabel}
            params(1) = New MySqlParameter("@val1", MySqlDbType.VarChar) With {.Value = editor.GetLocation}

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

    'Modifier un éditeur
    Public Function ModEditor(ByVal editor As Editor) As Boolean

        Try

            Dim query As String = "UPDATE editors SET label=@val0, location=@val1 WHERE id = @id"

            Dim params(2) As MySqlParameter

            params(0) = New MySqlParameter("@val0", MySqlDbType.VarChar) With {.Value = editor.GetLabel}
            params(1) = New MySqlParameter("@val1", MySqlDbType.VarChar) With {.Value = editor.GetLocation}
            params(2) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = editor.GetId}

            If connector.SetData(query, params).Equals(1) Then

                Return True

            Else

                Return False

            End If

        Catch ex As Exception

            Return False

        End Try

    End Function

    'Supprimez un éditeur
    Public Function DelEditor(ByVal editor As Editor) As Boolean

        Try

            Dim query As String = "DELETE FROM editors WHERE id = @id
                              "
            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = editor.GetId}

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
