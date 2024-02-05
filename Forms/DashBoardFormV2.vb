Imports Guna.UI2.WinForms

Public Class DashBoardFormV2

    Private actualUser As ActualUser
    Dim dbClient As New DBClient()
    Dim dbAuthor As New DBAuthor()
    Dim dbBook As New DBBook()
    Dim dbEditor As New DBEditor()
    Dim dbLoan As New DBLoan()
    Dim idModCli As Integer
    Dim idModAuthor As Integer
    Dim idModBook As Integer


    Public Sub New(actualUser As ActualUser)

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

        Me.actualUser = actualUser

    End Sub

    'Charge du formulaire
    Private Sub DashBoardFormV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LocalTime.Interval = 1000
        LocalTime.Start()

        DashUsernameLabel.Text = actualUser.getUsername

        RefreshBookAuthors()
        RefreshBookEditors()
        RefreshLoanBook()

        GridConfiguration()


        Label41.Text = CliDataGridView.RowCount
        Label42.Text = AuthorDataGridView.RowCount
        Label44.Text = BookDataGridView.RowCount
        Label46.Text = LoanDataGridView.RowCount

    End Sub

    Private Sub LocalTime_Tick(sender As Object, e As EventArgs) Handles LocalTime.Tick

        DashTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss")
        DashDateLabel.Text = DateTime.Now.ToString("dd/MM/yyyy")

    End Sub

    Private Sub SomGrid()

        Label41.Text = CliDataGridView.RowCount
        Label42.Text = AuthorDataGridView.RowCount
        Label44.Text = BookDataGridView.RowCount
        Label46.Text = LoanDataGridView.RowCount

    End Sub

    Private Sub SetPicture(box As Guna2PictureBox)

        Dim imageFileDialog As New OpenFileDialog With {
            .Filter = "IMAGES|*.bmp;*.jpg;*.jpeg;*.png",
            .Title = "Choisir une image"
        }

        If imageFileDialog.ShowDialog() = DialogResult.OK Then

            box.ImageLocation = imageFileDialog.FileName

        Else

            MessageBox.Show("Oops !")

        End If

    End Sub

    Private Sub RefreshBookEditors()
        BookAddEditorBox.Items.AddRange(dbEditor.GetEditors.ToArray)
        BookModEditorBox.Items.AddRange(dbEditor.GetEditors.ToArray)
    End Sub

    Private Sub RefreshBookAuthors()
        BookAddAuthorBox.Items.AddRange(dbAuthor.GetAuthors.ToArray)
        BookModAuthorBox.Items.AddRange(dbAuthor.GetAuthors.ToArray)
    End Sub

    Private Sub RefreshLoanBook()
        LoanBookBox.Items.AddRange(dbBook.GetBooks.ToArray)
        LoanCliBox.Items.AddRange(dbClient.GetClients.ToArray)
        'BookModAuthorBox.Items.AddRange(dbAuthor.GetAuthors.ToArray)
    End Sub

    Private Sub RefreshLoanCli()
        'LoanBookBox.Items.AddRange(dbBook.GetBooks.ToArray)
        'BookModAuthorBox.Items.AddRange(dbAuthor.GetAuthors.ToArray)
    End Sub

    Private Sub GridConfiguration()

        CliDataGridConfiguration()
        AuthorDataGridConfiguration()
        EditorDataGridConfiguration()
        BookDataGridConfiguration()
        LoanDataGridConfiguration()

    End Sub


    '------------------------------------------Debut Client
    Private Sub CliDataGridConfiguration()
        CliDataGridView.DataSource = dbClient.GetClients()

        CliDataGridView.Columns("GetId").Visible = False
        CliDataGridView.Columns("GetProfilePicture").Visible = False

        CliDataGridView.Columns("GetLastName").HeaderText = "Nom"
        CliDataGridView.Columns("GetFirstName").HeaderText = "Prénom(s)"
        CliDataGridView.Columns("GetAddress").HeaderText = "Adresse"
        CliDataGridView.Columns("GetContact").HeaderText = "Contact"
        CliDataGridView.Columns("GetSex").HeaderText = "Sexe"

    End Sub

    Private Sub ClearAllCliAddFields()

        CliPicBox.ImageLocation = ""
        CliLastNameBox.Text = ""
        CliFirstNameBox.Text = ""
        CliAdressBox.Text = ""
        CliContactBox.Text = ""
        CliSexBox.SelectedIndex = -1

    End Sub

    Private Sub ClearAllCliModFields()

        CliModPicBox.ImageLocation = ""
        CliModLastNameBox.Text = ""
        CliModFirstNameBox.Text = ""
        CliModAdressBox.Text = ""
        CliModContactBox.Text = ""
        CliModSexBox.SelectedIndex = -1

    End Sub

    'Ajoutez la pp du lecteur
    Private Async Sub CliAddPicButton_Click(sender As Object, e As EventArgs) Handles CliAddPicButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         SetPicture(CliPicBox)

                                     End Sub)

                       End Sub)

    End Sub

    'Modifier la pp du lecteur
    Private Async Sub CliModAddPicButton_Click(sender As Object, e As EventArgs) Handles CliModAddPicButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         SetPicture(CliModPicBox)

                                     End Sub)

                       End Sub)

    End Sub

    'Ajoutez un lecteur
    Private Async Sub AddCliButton_Click(sender As Object, e As EventArgs) Handles AddCliButton.Click

        Await Task.Run(Sub()
                           Me.Invoke(Sub()
                                         Dim clientpp As String = CliPicBox.ImageLocation
                                         Dim clientLastname As String = CliLastNameBox.Text.Trim()
                                         Dim clientFirstname As String = CliFirstNameBox.Text.Trim()
                                         Dim clientContact As String = CliContactBox.Text.Trim()
                                         Dim clientAdress As String = CliAdressBox.Text.Trim()
                                         Dim clientSex As String

                                         If (
                                 clientpp.Equals("") Or clientLastname.Equals("") Or clientFirstname.Equals("") Or clientContact.Equals("") Or clientAdress.Equals("") Or CliSexBox.SelectedIndex() = -1
                                 ) Then

                                             MessageBox.Show("Veuillez remplir tous les champs et choisir une photo", "Toutes les informations requises ne sont pas présentes", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                         Else

                                             clientSex = CliSexBox.SelectedItem.ToString

                                             Dim client As New Client(0, clientpp, clientLastname, clientFirstname, clientAdress, clientContact, clientSex)

                                             If dbClient.AddClient(client) Then

                                                 MessageBox.Show("Vous venez de proceder à l'ajout d'un nouveau lecteur avec succes", "Ajout d'un nouveau lecteur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                 CliDataGridConfiguration()
                                                 ClearAllCliAddFields()

                                                 SomGrid()

                                             Else

                                                 MessageBox.Show("Une erreur inconnu est survenu lors de l'ajout de lecteur.
Nous vous prions de bien vouloir recommencer.
Toutes les informations que vous avez inserer seront reinitialiser.",
                                                                  "Ajout d'un nouveau lecteur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                 ClearAllCliAddFields()

                                             End If

                                         End If

                                     End Sub)
                       End Sub)

    End Sub

    'Modifier un lecteur
    Private Async Sub CliModButton_Click(sender As Object, e As EventArgs) Handles CliModButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()
                                         If CliDataGridView.SelectedRows.Count > 0 Then

                                             Dim resultat = MessageBox.Show("Vous êtes sur le point de proceder à la modification du lecteur !
Faites oui si vous êtes sure de votre choix dans le cas contraire faites non ou annuler",
                                                                            "Modifier un lecteur", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                                             If resultat = DialogResult.Yes Then

                                                 Dim clientIndex As Integer = CliDataGridView.SelectedRows(0).Index

                                                 Dim client As Client = CType(CliDataGridView.Rows(clientIndex).DataBoundItem, Client)

                                                 idModCli = client.GetId
                                                 CliModPicBox.ImageLocation = client.GetProfilePicture
                                                 CliModLastNameBox.Text = client.GetLastName
                                                 CliModFirstNameBox.Text = client.GetFirstName
                                                 CliModAdressBox.Text = client.GetAddress
                                                 CliModContactBox.Text = client.GetContact
                                                 CliModSexBox.SelectedIndex = CliModSexBox.FindString(client.GetSex)

                                                 CliAddModButton.Enabled = True

                                                 CliTabControl.SelectedIndex = 1

                                             End If

                                         Else

                                             MessageBox.Show("Veuillez d'abord sélectionnez un lecteur avant de vouloir modifier ses informations",
                                                         "Modifier un lecteur", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                         End If

                                     End Sub)

                       End Sub)

    End Sub

    'Valider la modification d'un lecteur
    Private Async Sub CliAddModButton_Click(sender As Object, e As EventArgs) Handles CliAddModButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         If (
                                 CliModPicBox.ImageLocation.Equals("") Or CliModLastNameBox.Text.Equals("") Or CliModFirstNameBox.Text.Equals("") Or CliModAdressBox.Text.Equals("") Or CliModContactBox.Text.Equals("") Or CliModSexBox.SelectedIndex() = -1
                                 ) Then
                                             MessageBox.Show("Veuillez d'abord remplir tous les champs et choisir une nouvelle photo",
                                                     "Appliquez des modifications à un lecteur", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                         Else

                                             Dim resultat = MessageBox.Show("Vous êtes sur le point d'appliquer des modifications au lecteur !
Faites oui si vous êtes sure de votre choix dans le cas contraire faites non ou annuler",
                                                                            "Appliquez ldes modifications à un lecteur", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                                             If resultat = DialogResult.Yes Then

                                                 Dim client As New Client(idModCli, CliModPicBox.ImageLocation, CliModLastNameBox.Text,
     CliModFirstNameBox.Text, CliModAdressBox.Text, CliModContactBox.Text, CliModSexBox.SelectedItem)

                                                 If dbClient.ModClient(client:=client) Then

                                                     idModCli = 0
                                                     CliDataGridConfiguration()
                                                     CliTabControl.SelectedIndex = 2
                                                     ClearAllCliModFields()
                                                     CliAddModButton.Enabled = False

                                                 Else

                                                     MessageBox.Show("Une erreur inconnu est survenu lors de l'application du lecteur.
Nous vous prions de bien vouloir recommencer.
Toutes les informations que vous avez inserer seront reinitialiser.", "Erreur de modifications du lecteur", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                                 End If

                                             End If

                                         End If

                                     End Sub)

                       End Sub)

    End Sub

    'Supprimez un lecteur
    Private Async Sub CliDelButton_Click(sender As Object, e As EventArgs) Handles CliDelButton.Click

        Await Task.Run(Sub()
                           Me.Invoke(Sub()
                                         If CliDataGridView.SelectedRows.Count > 0 Then

                                             Dim resultat = MessageBox.Show("Vous êtes sur le point de supprimez un lecteur !
Faites oui si vous êtes sur de votre choix dans le cas contraire faites non ou annuler",
                                                         "Supprimer un lecteur", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                                             If resultat = DialogResult.Yes Then

                                                 Dim rowIndex As Integer = CliDataGridView.SelectedRows(0).Index

                                                 Dim client As Client = CType(CliDataGridView.Rows(rowIndex).DataBoundItem, Client)

                                                 dbClient.DelClient(client:=client)

                                                 CliDataGridConfiguration()

                                                 SomGrid()

                                             End If

                                         Else

                                             Dim resultat = MessageBox.Show("Veuillez d'abord sélectionnez un lecteur avant de vouloir proceder à sa suppression",
                                                         "Supprimer un lecteur", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                         End If

                                     End Sub)

                       End Sub)

    End Sub

    '----------------------------------------------Fin Client








    '------------------------------------------Debut Auteur
    Private Sub AuthorDataGridConfiguration()
        AuthorDataGridView.DataSource = dbAuthor.GetAuthors


        AuthorDataGridView.Columns("GetId").Visible = False
        AuthorDataGridView.Columns("GetBio").Visible = False

        AuthorDataGridView.Columns("GetLastName").HeaderText = "Nom"
        AuthorDataGridView.Columns("GetFirstName").HeaderText = "Prénom(s)"
        AuthorDataGridView.Columns("GetNationality").HeaderText = "Nationalité"
        AuthorDataGridView.Columns("GetCitation").HeaderText = "Citation"

    End Sub

    Private Sub ClearAllAuthorAddFields()

        AuthorAddLastNameBox.Text = ""
        AuthorAddFirstNameBox.Text = ""
        AuthorAddNatBox.Text = ""
        AuthorAddBioBox.Text = ""
        AuthorAddCitBox.Text = ""

    End Sub

    Private Sub ClearAllAuthorModFields()

        AuthorModLastNameBox.Text = ""
        AuthorModFirstNameBox.Text = ""
        AuthorModNatBox.Text = ""
        AuthorModBioBox.Text = ""
        AuthorModCitBox.Text = ""

    End Sub

    'Ajouter un auteur
    Private Async Sub AuthorAddButton_Click(sender As Object, e As EventArgs) Handles AuthorAddButton.Click

        Await Task.Run(Sub()
                           Me.Invoke(Sub()
                                         Dim authorLastname As String = AuthorAddLastNameBox.Text.Trim()
                                         Dim authorFirstname As String = AuthorAddFirstNameBox.Text.Trim()
                                         Dim authorNat As String = AuthorAddNatBox.Text.Trim()
                                         Dim authorBio As String = AuthorAddBioBox.Text.Trim()
                                         Dim authorCit As String = AuthorAddCitBox.Text.Trim()


                                         If (authorLastname.Equals("") Or authorFirstname.Equals("") Or authorNat.Equals("") Or authorBio.Equals("") Or authorCit.Equals("")) Then

                                             MessageBox.Show("Veuillez remplir tous les champs", "Toutes les informations requises ne sont pas présentes", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                         Else

                                             Dim author As New Author(0, authorLastname, authorFirstname, authorNat, authorBio, authorCit)

                                             If dbAuthor.AddAuthor(author) Then

                                                 MessageBox.Show("Vous venez de proceder à l'ajout d'un nouvel auteur avec succes", "Ajout d'un nouvel auteur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                 AuthorDataGridConfiguration()
                                                 RefreshBookAuthors()
                                                 ClearAllAuthorAddFields()

                                                 SomGrid()

                                             Else

                                                 MessageBox.Show("Une erreur inconnu est survenu lors de l'ajout de l'auteur.
Nous vous prions de bien vouloir recommencer.
Toutes les informations que vous avez inserer seront reinitialiser.",
                                                                  "Ajout d'un nouvel auteur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                 ClearAllAuthorAddFields()

                                             End If

                                         End If

                                     End Sub)
                       End Sub)

    End Sub

    'Valider les modifications d'un auteur
    Private Async Sub AuhtorAddModButton_Click(sender As Object, e As EventArgs) Handles AuthorAddModButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         If (AuthorModLastNameBox.Text.Equals("") Or AuthorModFirstNameBox.Text.Equals("") Or AuthorModNatBox.Text.Equals("") Or AuthorModBioBox.Text.Equals("") Or AuthorModCitBox.Equals("")) Then

                                             MessageBox.Show("Veuillez d'abord remplir tous les champs avant d'appliquez les modifications",
                                                             "Appliquez des modifications à un auteur", MessageBoxButtons.OK, MessageBoxIcon.Warning)


                                         Else

                                             Dim resultat = MessageBox.Show("Vous êtes sur le point d'appliquer des modifications à l'auteur !
Faites oui si vous êtes sure de votre choix dans le cas contraire faites non ou annuler",
                                                                            "Appliquez des modifications à un auteur", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                                             If resultat = DialogResult.Yes Then

                                                 Dim author As New Author(idModAuthor, AuthorModLastNameBox.Text, AuthorModFirstNameBox.Text,
                                                                          AuthorModNatBox.Text, AuthorModBioBox.Text, AuthorModCitBox.Text)


                                                 If dbAuthor.ModAuthor(author:=author) Then

                                                     idModAuthor = 0
                                                     AuthorDataGridConfiguration()
                                                     RefreshBookAuthors()
                                                     AuthorTabControl.SelectedIndex = 2
                                                     ClearAllAuthorModFields()
                                                     AuthorAddModButton.Enabled = False

                                                 Else

                                                     MessageBox.Show("Une erreur inconnu est survenu lors de l'application des modifications à l'auteur.
Nous vous prions de bien vouloir recommencer.
Toutes les informations que vous avez inserer seront reinitialiser.", "Appliquez les modifications à un auteur", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                                 End If

                                             End If

                                         End If

                                     End Sub)

                       End Sub)

    End Sub

    'Modifier un auteur
    Private Async Sub AuthorModButton_Click(sender As Object, e As EventArgs) Handles AuthorModButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()
                                         If AuthorDataGridView.SelectedRows.Count > 0 Then

                                             Dim resultat = MessageBox.Show("Vous êtes sur le point de proceder à la modification d'un auteur !
Faites oui si vous êtes sûre de votre choix dans le cas contraire faites non ou annuler",
                                                                            "Modifier un auteur", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                                             If resultat = DialogResult.Yes Then

                                                 Dim authorIndex As Integer = AuthorDataGridView.SelectedRows(0).Index

                                                 Dim author As Author = CType(AuthorDataGridView.Rows(authorIndex).DataBoundItem, Author)

                                                 idModAuthor = author.GetId
                                                 AuthorModLastNameBox.Text = author.GetLastName
                                                 AuthorModFirstNameBox.Text = author.GetFirstName
                                                 AuthorModNatBox.Text = author.GetNationality
                                                 AuthorModBioBox.Text = author.GetBio
                                                 AuthorModCitBox.Text = author.GetCitation
                                                 AuthorAddModButton.Enabled = True

                                                 AuthorTabControl.SelectedIndex = 1

                                             End If

                                         Else

                                             MessageBox.Show("Veuillez d'abord sélectionnez un auteur avant de vouloir modifier ses informations",
                                                         "Modifier un auteur", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                         End If

                                     End Sub)

                       End Sub)

    End Sub

    'Supprimez un auteur
    Private Async Sub AuthorDelButton_Click(sender As Object, e As EventArgs) Handles AuthorDelButton.Click

        Await Task.Run(Sub()
                           Me.Invoke(Sub()
                                         If AuthorDataGridView.SelectedRows.Count > 0 Then

                                             Dim resultat = MessageBox.Show("Vous êtes sur le point de supprimez un auteur !
Faites oui si vous êtes sûre de votre choix dans le cas contraire faites non ou annuler",
                                                         "Supprimer un auteur", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                                             If resultat = DialogResult.Yes Then

                                                 Dim authorIndex As Integer = AuthorDataGridView.SelectedRows(0).Index

                                                 Dim author As Author = CType(AuthorDataGridView.Rows(authorIndex).DataBoundItem, Author)

                                                 dbAuthor.DelAuthor(author:=author)

                                                 AuthorDataGridConfiguration()
                                                 RefreshBookAuthors()

                                                 SomGrid()

                                             End If

                                         Else

                                             Dim resultat = MessageBox.Show("Veuillez d'abord sélectionnez un auteur avant de vouloir proceder à sa suppression",
                                                         "Supprimer un auteur", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                         End If

                                     End Sub)

                       End Sub)

    End Sub

    '------------------------------------------Fin Auteur








    '-----------------------------------------Debut livre
    Private Sub BookDataGridConfiguration()
        BookDataGridView.DataSource = dbBook.GetBooks()

        BookDataGridView.Columns("GetId").Visible = False
        BookDataGridView.Columns("GetCover").Visible = False
        BookDataGridView.Columns("GetQte").Visible = False
        BookDataGridView.Columns("GetPublished").Visible = False
        BookDataGridView.Columns("GetAvailabilty").Visible = False
        BookDataGridView.Columns("GetTitle").HeaderText = "Titre"
        BookDataGridView.Columns("GetIsbn").HeaderText = "Isbn"
        BookDataGridView.Columns("GetAuthor").HeaderText = "Auteur"
        BookDataGridView.Columns("GetEditor").HeaderText = "Editeur"


    End Sub

    Private Sub ClearAllBookAddFields()

        BookAddCoverBox.ImageLocation = ""
        BookAddTitleBox.Text = ""
        BookAddISBNBox.Text = ""
        'BookAddPubBox.Value = New Date()
        BookAddQteBox.Value = 0
        BookAddAuthorBox.SelectedIndex = -1
        BookAddEditorBox.SelectedIndex = -1

    End Sub

    Private Sub ClearAllBookModFields()

        BookModCoverPicBox.ImageLocation = ""
        BookModTitleBox.Text = ""
        BookModISBNBox.Text = ""
        'BookModPubBox.Value = New Date()
        BookModQteBox.Value = 0
        BookModAuthorBox.SelectedIndex = -1
        BookModEditorBox.SelectedIndex = -1

    End Sub

    'Ajouter un livre
    Private Async Sub BookAddButton_Click(sender As Object, e As EventArgs) Handles BookAddButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         Dim bookCover As String = BookAddCoverBox.ImageLocation
                                         Dim bookTitle As String = BookAddTitleBox.Text
                                         Dim bookIsbn As String = BookAddISBNBox.Text
                                         Dim bookPub As Date = BookAddPubBox.Value
                                         Dim bookQte As Integer = BookAddQteBox.Value
                                         Dim bookAuthor As Author = BookAddAuthorBox.SelectedItem
                                         Dim bookEditor As Editor = BookAddEditorBox.SelectedItem

                                         If (bookCover.Equals("") Or bookTitle.Equals("") Or bookIsbn.Equals("") Or bookQte = 0 Or BookAddAuthorBox.SelectedIndex = -1 Or BookAddEditorBox.SelectedIndex = -1) Then

                                             MessageBox.Show("Veuillez remplir tous les champs et choisir une image de couverture", "Toutes les informations requises ne sont pas présentes", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                         Else

                                             Dim book As New Book(0, bookCover, bookTitle, bookIsbn, bookPub, bookQte, True, bookAuthor, bookEditor)

                                             If dbBook.AddBook(book) Then

                                                 MessageBox.Show("Vous venez de proceder à l'ajout d'un nouveau livre avec succes", "Ajout d'un nouveau livre", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                 BookDataGridConfiguration()
                                                 ClearAllBookAddFields()

                                             Else

                                                 MessageBox.Show("Une erreur inconnu est survenu lors de l'ajout du livre.
Nous vous prions de bien vouloir recommencer.
Toutes les informations que vous avez inserer seront reinitialiser.",
                                                                 "Ajout d'un nouveau livre", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                 ClearAllBookAddFields()

                                             End If

                                         End If

                                     End Sub)

                       End Sub)

    End Sub

    'Valider les modifications d'un livre
    Private Async Sub BookAddModButton_Click(sender As Object, e As EventArgs) Handles BookAddModButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         If (BookModCoverPicBox.ImageLocation.Equals("") Or BookModTitleBox.Text.Equals("") Or BookModISBNBox.Text.Equals("") Or BookModQteBox.Value < 0 Or BookModAuthorBox.SelectedIndex = -1 Or BookModEditorBox.SelectedIndex = -1) Then

                                             MessageBox.Show("Veuillez d'abord remplir tous les champs et choisir une image de couverture avant d'appliquez les modifications",
                                                             "Appliquez des modifications à un livre", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                         Else

                                             Dim resultat = MessageBox.Show("Vous êtes sur le point d'appliquer des modifications à un livre !
Faites oui si vous êtes sure de votre choix dans le cas contraire faites non ou annuler",
                                                                            "Appliquez des modifications à un livre", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                                             If resultat = DialogResult.Yes Then

                                                 Dim isAvailable = (BookModQteBox.Visible > 0)
                                                 Dim bookAuthor As Author = BookModAuthorBox.SelectedItem
                                                 Dim bookEditor As Editor = BookModEditorBox.SelectedItem

                                                 Console.WriteLine(isAvailable)

                                                 Dim book As New Book(idModBook, BookModCoverPicBox.ImageLocation, BookModTitleBox.Text,
                                                                          BookModISBNBox.Text, BookModPubBox.Value, BookModQteBox.Value, isAvailable, bookAuthor, bookEditor)

                                                 If dbBook.ModBook(book:=book) Then

                                                     idModBook = 0
                                                     BookDataGridConfiguration()
                                                     BookTabControl.SelectedIndex = 3
                                                     ClearAllBookModFields()
                                                     BookAddModButton.Enabled = False

                                                 Else

                                                     MessageBox.Show("Une erreur inconnu est survenu lors de l'application des modifications à un livre.
Nous vous prions de bien vouloir recommencer.
Toutes les informations que vous avez inserer seront reinitialiser.", "Appliquez les modifications à un livre", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                                     ClearAllBookModFields()
                                                 End If

                                             End If

                                         End If

                                     End Sub)

                       End Sub)

    End Sub

    'Modifier un livre
    Private Async Sub BookModButton_Click(sender As Object, e As EventArgs) Handles BookModButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()
                                         If BookDataGridView.SelectedRows.Count > 0 Then

                                             Dim resultat = MessageBox.Show("Vous êtes sur le point de proceder à la modification d'un livre !
Faites oui si vous êtes sûre de votre choix dans le cas contraire faites non ou annuler",
                                                                            "Modifier un livre", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                                             If resultat = DialogResult.Yes Then

                                                 Dim bookIndex As Integer = BookDataGridView.SelectedRows(0).Index

                                                 Dim book As Book = CType(BookDataGridView.Rows(bookIndex).DataBoundItem, Book)

                                                 idModBook = book.GetId
                                                 BookModCoverPicBox.ImageLocation = book.GetCover
                                                 BookModTitleBox.Text = book.GetTitle
                                                 BookModISBNBox.Text = book.GetIsbn
                                                 BookModPubBox.Value = book.GetPublished
                                                 BookModQteBox.Value = book.GetQte
                                                 BookModAuthorBox.SelectedIndex = BookModAuthorBox.FindString(book.GetAuthor.ToString)
                                                 BookModEditorBox.SelectedIndex = BookModEditorBox.FindString(book.GetEditor.ToString)

                                                 BookAddModButton.Enabled = True

                                                 BookTabControl.SelectedIndex = 2

                                             End If

                                         Else

                                             MessageBox.Show("Veuillez d'abord sélectionnez un livre avant de vouloir modifier ses informations",
                                                         "Modifier un livre", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                         End If

                                     End Sub)

                       End Sub)

    End Sub

    'Supprimez un livre
    Private Async Sub BookDelButton_Click(sender As Object, e As EventArgs) Handles BookDelButton.Click

        Await Task.Run(Sub()
                           Me.Invoke(Sub()
                                         If BookDataGridView.SelectedRows.Count > 0 Then

                                             Dim resultat = MessageBox.Show("Vous êtes sur le point de supprimez un livre !
Faites oui si vous êtes sûre de votre choix dans le cas contraire faites non ou annuler",
                                                         "Supprimer un livre", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                                             If resultat = DialogResult.Yes Then

                                                 Dim bookIndex As Integer = BookDataGridView.SelectedRows(0).Index

                                                 Dim book As Book = CType(BookDataGridView.Rows(bookIndex).DataBoundItem, Book)

                                                 dbBook.DelBook(book:=book)

                                                 BookDataGridConfiguration()

                                                 SomGrid()

                                             End If

                                         Else

                                             Dim resultat = MessageBox.Show("Veuillez d'abord sélectionnez un livre avant de vouloir proceder à sa suppression",
                                                         "Supprimer un livre", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                         End If

                                     End Sub)

                       End Sub)

    End Sub

    'Ajoutez une couverture
    Private Async Sub BookAddCoverButton_Click(sender As Object, e As EventArgs) Handles BookAddCoverButton.Click
        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         SetPicture(BookAddCoverBox)

                                     End Sub)

                       End Sub)
    End Sub

    'Modifiez une couverture
    Private Async Sub BookModPicButton_Click(sender As Object, e As EventArgs) Handles BookModPicButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         SetPicture(BookModCoverPicBox)

                                     End Sub)

                       End Sub)

    End Sub






    '--------------------------------Editeur
    Private Sub EditorDataGridConfiguration()
        EditorDataGridView.DataSource = dbEditor.GetEditors

        EditorDataGridView.Columns("GetId").Visible = False
        EditorDataGridView.Columns("GetLabel").HeaderText = "Label"
        EditorDataGridView.Columns("GetLocation").HeaderText = "Local"


    End Sub

    Private Sub ClearAllEditorFields()

        EditorAddLabelBox.Text = ""
        EditorAddLocationBox.Text = ""

    End Sub


    'ajoutez un editeur
    Private Async Sub EditorAddButton_Click(sender As Object, e As EventArgs) Handles EditorAddButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         Dim label As String = EditorAddLabelBox.Text
                                         Dim location As String = EditorAddLocationBox.Text

                                         If (label.Equals("") Or location.Equals("")) Then

                                             MessageBox.Show("Veuillez remplir tous les champs", "Toutes les informations requises ne sont pas présentes", MessageBoxButtons.OK, MessageBoxIcon.Warning)


                                         Else

                                             Dim editor As New Editor(0, label, location)

                                             If dbEditor.AddEditor(editor:=editor) Then

                                                 MessageBox.Show("Vous venez de proceder à l'ajout d'un nouvel éditeur avec succes", "Ajout d'un nouvel editeur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                 EditorDataGridConfiguration()
                                                 RefreshBookEditors()
                                                 ClearAllEditorFields()

                                             Else

                                                 MessageBox.Show("Une erreur inconnu est survenu lors de l'ajout du nouvel éditeur.
Nous vous prions de bien vouloir recommencer.
Toutes les informations que vous avez inserer seront reinitialiser.",
                                                                 "Ajout d'un nouvel éditeur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                 ClearAllEditorFields()
                                             End If

                                         End If

                                     End Sub)
                       End Sub)

    End Sub


    'supprimez un editeur
    Private Async Sub EditorDelButton_Click(sender As Object, e As EventArgs) Handles EditorDelButton.Click

        Await Task.Run(Sub()
                           Me.Invoke(Sub()
                                         If EditorDataGridView.SelectedRows.Count > 0 Then

                                             Dim resultat = MessageBox.Show("Vous êtes sur le point de supprimez un éditeur !
Faites oui si vous êtes sûre de votre choix dans le cas contraire faites non ou annuler",
                                                         "Supprimer un éditeur", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                                             If resultat = DialogResult.Yes Then

                                                 Dim editorIndex As Integer = BookDataGridView.SelectedRows(0).Index

                                                 Dim editor As Editor = CType(BookDataGridView.Rows(editorIndex).DataBoundItem, Editor)

                                                 dbEditor.DelEditor(editor)

                                                 EditorDataGridConfiguration()
                                                 RefreshBookEditors()

                                             End If

                                         Else

                                             Dim resultat = MessageBox.Show("Veuillez d'abord sélectionnez un éditeur avant de vouloir proceder à sa suppression",
                                                         "Supprimer un éditeur", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                         End If

                                     End Sub)

                       End Sub)

    End Sub

    '-----------------------------------------Fin livre







    '-----------------------------------------Debut Prêt

    Private Sub LoanDataGridConfiguration()

        LoanDataGridView.DataSource = DBLoan.GetLoans

        LoanDataGridView.Columns("GetId").Visible = False
        LoanDataGridView.Columns("GetCost").Visible = False
        LoanDataGridView.Columns("GetStartDate").HeaderText = "Début"
        LoanDataGridView.Columns("GetEndDate").HeaderText = "Fin"
        LoanDataGridView.Columns("GetUser").HeaderText = "Caissier"
        LoanDataGridView.Columns("GetBook").HeaderText = "Livre"
        LoanDataGridView.Columns("GetClient").HeaderText = "Lecteur"

    End Sub

    Private Sub ClearAllLoanAddFields()

        'LoanStartBox.Value = New Date
        'LoanEndBox.Value = New Date
        LoanBookBox.SelectedIndex = -1
        LoanCliBox.SelectedIndex = -1
        LoanCostBox.Value = 0

    End Sub

    Private Sub LoanCliBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LoanCliBox.SelectedIndexChanged
        Dim cli As Client = LoanCliBox.SelectedItem

        LoanCliName.Text = cli.GetLastName
        LoanCliName2.Text = cli.GetFirstName
        LoanCliPicBox.ImageLocation = cli.GetProfilePicture
        LoanCliInfo.Text = cli.GetAddress + " " + cli.GetContact


    End Sub

    Private Sub LoanBookBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LoanBookBox.SelectedIndexChanged
        Dim book As Book = LoanBookBox.SelectedItem

        LoanBookCoverBox.ImageLocation = book.GetCover
        LoanBookTitleLabel.Text = book.GetTitle
        LoanBookAuthorLabel.Text = book.GetAuthor.GetLastName + " " + book.GetAuthor.GetFirstName
        LoanBookDateLabel.Text = book.GetPublished
        LoanBookEditorLabel.Text = book.GetEditor.GetLabel

    End Sub

    Private Async Sub LoanAddButton_Click(sender As Object, e As EventArgs) Handles LoanAddButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         If (LoanBookBox.SelectedIndex < 0 Or LoanCliBox.SelectedIndex < 0 Or LoanCostBox.Value < 0 Or LoanStartBox.Value > LoanEndBox.Value) Then

                                             MessageBox.Show("Veuillez selectionnez une periode valide et un livre et un lecteur et des frais de location superieur ou égale à zero", "Toutes les informations requises ne sont pas présentes/conformes", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                         Else
                                             Dim startDate = LoanStartBox.Value
                                             Dim endDate = LoanEndBox.Value
                                             Dim book As Book = LoanBookBox.SelectedItem
                                             Dim cli As Client = LoanCliBox.SelectedItem
                                             Dim cost = LoanCostBox.Value

                                             Dim loan As New Loan(0, cost, startDate, endDate, actualUser, book, cli)

                                             If dbLoan.AddLoan(loan) Then

                                                 MessageBox.Show("Vous venez de proceder à la souscription d'un nouveau prêt", "Nouveau Prêt", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                 LoanDataGridConfiguration()
                                                 'ClearAllLoanAddFields()

                                             Else

                                                 MessageBox.Show("Une erreur inconnu est survenu lors de la souscription du nouveau prêt
                                             Nous vous prions de bien vouloir recommencer.
                                             Toutes les informations que vous spécifiées seront reinitialiser.",
                                                                "Echec du Prêt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                 'ClearAllLoanAddFields()

                                             End If

                                         End If



                                     End Sub)
                       End Sub)

    End Sub

    Private Async Sub LoanAddModButton_Click(sender As Object, e As EventArgs) Handles LoanAddModButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         If (LoanBookBox.SelectedIndex < 0 Or LoanCliBox.SelectedIndex < 0 Or LoanCostBox.Value < 0 Or LoanStartBox.Value > LoanEndBox.Value) Then

                                             MessageBox.Show("Veuillez selectionnez une periode valide et un livre et un lecteur et des frais de location superieur ou égale à zero", "Toutes les informations requises ne sont pas présentes/conformes", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                         Else
                                             Dim startDate = LoanStartBox.Value
                                             Dim endDate = LoanEndBox.Value
                                             Dim book As Book = LoanBookBox.SelectedItem
                                             Dim cli As Client = LoanCliBox.SelectedItem
                                             Dim cost = LoanCostBox.Value

                                             Dim loan As New Loan(0, cost, startDate, endDate, actualUser, book, cli)

                                             If dbLoan.AddLoan(loan) Then

                                                 MessageBox.Show("Vous venez de proceder à la souscription d'un nouveau prêt", "Nouveau Prêt", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                 LoanDataGridConfiguration()
                                                 ClearAllLoanAddFields()

                                             Else

                                                 MessageBox.Show("Une erreur inconnu est survenu lors de la souscription du nouveau prêt
Nous vous prions de bien vouloir recommencer.
Toutes les informations que vous spécifiées seront reinitialiser.",
                                                                 "Echec du Prêt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                 ClearAllLoanAddFields()

                                             End If

                                         End If



                                     End Sub)
                       End Sub)

    End Sub


    '-----------------------------------------Fin prêt

End Class