Imports MySql.Data.MySqlClient

Public Class LoginForm

    Private profileDefault = True
    Private eyeDefault = True

    Private dashBoard As DashBoardFormV2

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        UsernameField.Focus()

    End Sub

    Private Sub UserProfileBox_Click(sender As Object, e As EventArgs) Handles UserProfileBox.Click

        If profileDefault Then

            UserProfileBox.ImageLocation = "C:\Users\hp\Documents\Docker\FREEBOOK\Projet Gestion de Bibliotheque\Freebook\Images\icon\profile_woman_blank.png"
            profileDefault = False

        Else

            UserProfileBox.ImageLocation = "C:\Users\hp\Documents\Docker\FREEBOOK\Projet Gestion de Bibliotheque\Freebook\Images\icon\profile_blank.png"
            profileDefault = True

        End If

    End Sub

    Private Sub ShowPassButton_Click(sender As Object, e As EventArgs) Handles ShowPassButton.Click

        If eyeDefault Then

            ShowPassButton.BackgroundImage = Image.FromFile("C:\Users\hp\Documents\Docker\FREEBOOK\Projet Gestion de Bibliotheque\Freebook\Images\icon\low-vision.png")
            PasswordField.PasswordChar = ""
            eyeDefault = False

        Else

            ShowPassButton.BackgroundImage = Image.FromFile("C:\Users\hp\Documents\Docker\FREEBOOK\Projet Gestion de Bibliotheque\Freebook\Images\icon\eye.png")
            PasswordField.PasswordChar = "¤"
            eyeDefault = True

        End If

    End Sub

    Private Async Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click

        Await Task.Run(Sub()

                           Dim username As String = UsernameField.Text.Trim()
                           Dim password As String = PasswordField.Text.Trim()

                           Dim connector As New DBConnector()
                           Dim adapter As New MySqlDataAdapter()
                           Dim table As New DataTable()
                           Dim command As New MySqlCommand("SELECT * FROM users WHERE username=@username", connector.getConnection)

                           If username = "" And password = "" Then

                               Me.Invoke(Sub()

                                             MessageBox.Show("Veuillez remplir tous les champs", "Aucun champs remplis", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                             UsernameField.Focus()

                                         End Sub)

                           ElseIf username = "" Then

                               Me.Invoke(Sub()

                                             MessageBox.Show("Veuillez entrer un nom d'utilisateur", "Nom d'utilisateur manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                             UsernameField.Focus()

                                         End Sub)

                           ElseIf password = "" Then

                               Me.Invoke(Sub()

                                             MessageBox.Show("Veuillez entrez un mot de passe", "Mot de passe manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                             PasswordField.Focus()

                                         End Sub)

                           Else

                               command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username

                               adapter.SelectCommand = command
                               adapter.Fill(table)

                               If table.Rows.Count > 0 Then

                                   For Each row As DataRow In table.Rows

                                       Dim dbpass = row("password").ToString

                                       If dbpass.Equals(password) Then

                                           Me.Invoke(Sub()

                                                         MessageBox.Show("Bienvenu " + username, "Authentification réussi", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                                         UsernameField.Text = ""
                                                         PasswordField.Text = ""

                                                         Me.Visible = False

                                                         Dim actualUser As New ActualUser(id:=Convert.ToInt32(row("id")), username:=username)

                                                         dashBoard = New DashBoardFormV2(actualUser:=actualUser) With {.Visible = True}

                                                     End Sub)

                                       Else

                                           Me.Invoke(Sub()

                                                         MessageBox.Show("Mot de passe incorrect", "Echec de l'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                                     End Sub)

                                       End If

                                   Next

                               Else

                                   Me.Invoke(Sub()

                                                 MessageBox.Show("Nom d'utilisateur incorrect", "Echec de l'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                             End Sub)

                               End If

                           End If

                       End Sub)

    End Sub

    Private Async Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         UsernameField.Text = ""
                                         PasswordField.Text = ""

                                     End Sub)

                       End Sub)

    End Sub

    Private Async Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click

        Await Task.Run(Sub()

                           Me.Invoke(Sub()

                                         Dim message = MessageBox.Show("Voulez Vous vraiment quittez ?", "Fermez l'application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                                         If message = DialogResult.Yes Then

                                             Me.Close()

                                         End If

                                     End Sub)

                       End Sub)

    End Sub

End Class