Imports MySql.Data.MySqlClient

Public Class DBLoan

    Dim connector As New DBConnector()
    Dim misc As New DBMisc()
    Dim clientDB As New DBClient()
    Dim bookDB As New DBBook()

    'Obtenir la liste de tous les prêts
    Public Function GetLoans() As List(Of Loan)

        Dim listOfLoan As New List(Of Loan)

        Dim query = "SELECT * FROM loans"

        Dim loanDataTable As DataTable = connector.GetData(query, Nothing)

        For Each row As DataRow In loanDataTable.Rows
            Dim loan As Loan

            loan = New Loan(
                Convert.ToInt32(row("id")),
                Convert.ToDateTime(row("loanstart")),
                Convert.ToDateTime(row("loansend")),
                Convert.ToInt32(row("cost"))
                ) With {
                .SetUser = misc.GetUserById(Convert.ToInt32(row("id"))),
                .SetBook = bookDB.GetBookById(Convert.ToInt32(row("book_id"))),
                .SetClient = clientDB.GetClientById(Convert.ToInt32(row("client_id")))
            }

            listOfLoan.Add(loan)
        Next

        Return listOfLoan

    End Function

    'Ajoutez un prêt
    Public Function AddLoan(ByVal loan As Loan) As Boolean

        Try

            Dim query As String = "
                               INSERT INTO 
                                    loans (loanstart, loanend, cost, user_id, book_id, client_id)
                               VALUES(@val0, @val1, @val2, @val3, @val4, @val5)
                              "

            Dim params(5) As MySqlParameter

            params(0) = New MySqlParameter("@val0", MySqlDbType.DateTime) With {.Value = loan.GetStartDate}
            params(1) = New MySqlParameter("@val1", MySqlDbType.DateTime) With {.Value = loan.GetEndDate}
            params(2) = New MySqlParameter("@val2", MySqlDbType.Int32) With {.Value = loan.GetCost}
            params(3) = New MySqlParameter("@val3", MySqlDbType.Int32) With {.Value = loan.GetUser.GetId}
            params(4) = New MySqlParameter("@val4", MySqlDbType.Int32) With {.Value = loan.GetBook.GetId}
            params(5) = New MySqlParameter("@val5", MySqlDbType.Int32) With {.Value = loan.GetClient.GetId}

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
    Public Function ModLoan(ByVal loan As Loan) As Boolean

        Try

            Dim query As String = "UPDATE loans
                                SET loanstart=@val0, loanend=@val1, cost=@val2, user_id=@val3, book_id=@val4,
                                    client_id=@val5
                               WHERE id = @id"

            Dim params(5) As MySqlParameter

            params(0) = New MySqlParameter("@val0", MySqlDbType.DateTime) With {.Value = loan.GetStartDate}
            params(1) = New MySqlParameter("@val1", MySqlDbType.DateTime) With {.Value = loan.GetEndDate}
            params(2) = New MySqlParameter("@val2", MySqlDbType.Int32) With {.Value = loan.GetCost}
            params(3) = New MySqlParameter("@val3", MySqlDbType.Int32) With {.Value = loan.GetUser.GetId}
            params(4) = New MySqlParameter("@val4", MySqlDbType.Int32) With {.Value = loan.GetBook.GetId}
            params(5) = New MySqlParameter("@val5", MySqlDbType.Int32) With {.Value = loan.GetClient.GetId}

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

    'Supprimez un prêt
    Public Function DelLoan(ByVal loan As Loan) As Boolean

        Try

            Dim query As String = "DELETE FROM loans WHERE id = @id"

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("@id", MySqlDbType.Int32) With {.Value = loan.GetId}

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