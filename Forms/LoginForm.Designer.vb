<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Panel1 = New Panel()
        Panel4 = New Panel()
        SplitContainer1 = New SplitContainer()
        UserProfileBox = New PictureBox()
        UsernameField = New Guna.UI2.WinForms.Guna2TextBox()
        PasswordField = New Guna.UI2.WinForms.Guna2TextBox()
        ShowPassButton = New Guna.UI2.WinForms.Guna2Button()
        LoginButton = New Guna.UI2.WinForms.Guna2Button()
        ResetButton = New Guna.UI2.WinForms.Guna2Button()
        ExitButton = New Guna.UI2.WinForms.Guna2Button()
        Label2 = New Label()
        Label1 = New Label()
        Panel2 = New Panel()
        PageTitleLabel = New Label()
        Panel1.SuspendLayout()
        Panel4.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(UserProfileBox, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.Controls.Add(Panel4)
        Panel1.Controls.Add(Panel2)
        Panel1.Location = New Point(-1, -2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1266, 683)
        Panel1.TabIndex = 0
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(SplitContainer1)
        Panel4.Location = New Point(0, 98)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1266, 585)
        Panel4.TabIndex = 1
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.BackgroundImage = CType(resources.GetObject("SplitContainer1.Panel1.BackgroundImage"), Image)
        SplitContainer1.Panel1.BackgroundImageLayout = ImageLayout.Stretch
        SplitContainer1.Panel1.Controls.Add(UserProfileBox)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.BackgroundImage = CType(resources.GetObject("SplitContainer1.Panel2.BackgroundImage"), Image)
        SplitContainer1.Panel2.BackgroundImageLayout = ImageLayout.Stretch
        SplitContainer1.Panel2.Controls.Add(UsernameField)
        SplitContainer1.Panel2.Controls.Add(PasswordField)
        SplitContainer1.Panel2.Controls.Add(ShowPassButton)
        SplitContainer1.Panel2.Controls.Add(LoginButton)
        SplitContainer1.Panel2.Controls.Add(ResetButton)
        SplitContainer1.Panel2.Controls.Add(ExitButton)
        SplitContainer1.Panel2.Controls.Add(Label2)
        SplitContainer1.Panel2.Controls.Add(Label1)
        SplitContainer1.Size = New Size(1266, 620)
        SplitContainer1.SplitterDistance = 421
        SplitContainer1.TabIndex = 6
        ' 
        ' UserProfileBox
        ' 
        UserProfileBox.Cursor = Cursors.Hand
        UserProfileBox.ImageLocation = "C:\Users\hp\Documents\Docker\FREEBOOK\Projet Gestion de Bibliotheque\Freebook\Images\icon\profile_blank.png"
        UserProfileBox.Location = New Point(13, 52)
        UserProfileBox.Name = "UserProfileBox"
        UserProfileBox.Size = New Size(400, 400)
        UserProfileBox.SizeMode = PictureBoxSizeMode.StretchImage
        UserProfileBox.TabIndex = 6
        UserProfileBox.TabStop = False
        ' 
        ' UsernameField
        ' 
        UsernameField.AutoCompleteMode = AutoCompleteMode.Suggest
        UsernameField.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList
        UsernameField.BackColor = Color.Transparent
        UsernameField.BorderRadius = 15
        UsernameField.CustomizableEdges = CustomizableEdges1
        UsernameField.DefaultText = ""
        UsernameField.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        UsernameField.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        UsernameField.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        UsernameField.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        UsernameField.FocusedState.BorderColor = Color.DodgerBlue
        UsernameField.Font = New Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point)
        UsernameField.ForeColor = Color.Black
        UsernameField.HoverState.BorderColor = Color.DodgerBlue
        UsernameField.IconLeft = CType(resources.GetObject("UsernameField.IconLeft"), Image)
        UsernameField.IconLeftSize = New Size(32, 32)
        UsernameField.Location = New Point(75, 132)
        UsernameField.Margin = New Padding(7, 7, 7, 7)
        UsernameField.Name = "UsernameField"
        UsernameField.PasswordChar = ChrW(0)
        UsernameField.PlaceholderText = "Entrez votre nom d'utilisateur"
        UsernameField.SelectedText = ""
        UsernameField.ShadowDecoration.BorderRadius = 15
        UsernameField.ShadowDecoration.Color = Color.Silver
        UsernameField.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        UsernameField.ShadowDecoration.Enabled = True
        UsernameField.Size = New Size(600, 48)
        UsernameField.TabIndex = 0
        ' 
        ' PasswordField
        ' 
        PasswordField.AutoCompleteMode = AutoCompleteMode.Suggest
        PasswordField.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList
        PasswordField.BackColor = Color.Transparent
        PasswordField.BorderRadius = 15
        PasswordField.CustomizableEdges = CustomizableEdges3
        PasswordField.DefaultText = ""
        PasswordField.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        PasswordField.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        PasswordField.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        PasswordField.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        PasswordField.FocusedState.BorderColor = Color.DodgerBlue
        PasswordField.Font = New Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point)
        PasswordField.ForeColor = Color.Black
        PasswordField.HoverState.BorderColor = Color.DodgerBlue
        PasswordField.IconLeft = CType(resources.GetObject("PasswordField.IconLeft"), Image)
        PasswordField.IconLeftSize = New Size(32, 32)
        PasswordField.Location = New Point(75, 264)
        PasswordField.Margin = New Padding(7, 7, 7, 7)
        PasswordField.Name = "PasswordField"
        PasswordField.PasswordChar = "¤"c
        PasswordField.PlaceholderText = "Entrez votre mot de passe utilisateur"
        PasswordField.SelectedText = ""
        PasswordField.ShadowDecoration.BorderRadius = 15
        PasswordField.ShadowDecoration.Color = Color.Silver
        PasswordField.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        PasswordField.ShadowDecoration.Enabled = True
        PasswordField.Size = New Size(600, 48)
        PasswordField.TabIndex = 1
        ' 
        ' ShowPassButton
        ' 
        ShowPassButton.Animated = True
        ShowPassButton.BackColor = Color.Transparent
        ShowPassButton.BackgroundImage = CType(resources.GetObject("ShowPassButton.BackgroundImage"), Image)
        ShowPassButton.BackgroundImageLayout = ImageLayout.Stretch
        ShowPassButton.BorderColor = Color.White
        ShowPassButton.BorderRadius = 10
        ShowPassButton.BorderThickness = 1
        ShowPassButton.Cursor = Cursors.Hand
        ShowPassButton.CustomizableEdges = CustomizableEdges5
        ShowPassButton.DisabledState.BorderColor = Color.DarkGray
        ShowPassButton.DisabledState.CustomBorderColor = Color.DarkGray
        ShowPassButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ShowPassButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ShowPassButton.FillColor = Color.Transparent
        ShowPassButton.FocusedColor = Color.Transparent
        ShowPassButton.Font = New Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point)
        ShowPassButton.ForeColor = Color.White
        ShowPassButton.HoverState.FillColor = Color.Transparent
        ShowPassButton.HoverState.Font = New Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point)
        ShowPassButton.HoverState.ForeColor = Color.White
        ShowPassButton.IndicateFocus = True
        ShowPassButton.Location = New Point(681, 264)
        ShowPassButton.Name = "ShowPassButton"
        ShowPassButton.PressedColor = Color.WhiteSmoke
        ShowPassButton.ShadowDecoration.BorderRadius = 10
        ShowPassButton.ShadowDecoration.Color = Color.White
        ShowPassButton.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        ShowPassButton.ShadowDecoration.Enabled = True
        ShowPassButton.Size = New Size(48, 48)
        ShowPassButton.TabIndex = 2
        ' 
        ' LoginButton
        ' 
        LoginButton.Animated = True
        LoginButton.BackColor = Color.Transparent
        LoginButton.BorderRadius = 10
        LoginButton.Cursor = Cursors.Hand
        LoginButton.CustomizableEdges = CustomizableEdges7
        LoginButton.DisabledState.BorderColor = Color.DarkGray
        LoginButton.DisabledState.CustomBorderColor = Color.DarkGray
        LoginButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        LoginButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        LoginButton.FillColor = Color.SkyBlue
        LoginButton.FocusedColor = Color.MidnightBlue
        LoginButton.Font = New Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LoginButton.ForeColor = Color.White
        LoginButton.HoverState.FillColor = Color.DeepSkyBlue
        LoginButton.HoverState.Font = New Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LoginButton.HoverState.ForeColor = Color.White
        LoginButton.Image = CType(resources.GetObject("LoginButton.Image"), Image)
        LoginButton.ImageSize = New Size(32, 32)
        LoginButton.IndicateFocus = True
        LoginButton.Location = New Point(75, 360)
        LoginButton.Name = "LoginButton"
        LoginButton.PressedColor = Color.MidnightBlue
        LoginButton.ShadowDecoration.BorderRadius = 10
        LoginButton.ShadowDecoration.Color = Color.LightSkyBlue
        LoginButton.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        LoginButton.ShadowDecoration.Enabled = True
        LoginButton.Size = New Size(364, 46)
        LoginButton.TabIndex = 3
        LoginButton.Text = "Se Connecter"
        ' 
        ' ResetButton
        ' 
        ResetButton.Animated = True
        ResetButton.BackColor = Color.Transparent
        ResetButton.BorderRadius = 10
        ResetButton.Cursor = Cursors.Hand
        ResetButton.CustomizableEdges = CustomizableEdges9
        ResetButton.DisabledState.BorderColor = Color.DarkGray
        ResetButton.DisabledState.CustomBorderColor = Color.DarkGray
        ResetButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ResetButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ResetButton.FillColor = Color.Salmon
        ResetButton.FocusedColor = Color.Tomato
        ResetButton.Font = New Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point)
        ResetButton.ForeColor = Color.White
        ResetButton.HoverState.FillColor = Color.OrangeRed
        ResetButton.HoverState.Font = New Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point)
        ResetButton.HoverState.ForeColor = Color.White
        ResetButton.Image = CType(resources.GetObject("ResetButton.Image"), Image)
        ResetButton.ImageSize = New Size(32, 32)
        ResetButton.IndicateFocus = True
        ResetButton.Location = New Point(473, 360)
        ResetButton.Name = "ResetButton"
        ResetButton.PressedColor = Color.Tomato
        ResetButton.ShadowDecoration.BorderRadius = 10
        ResetButton.ShadowDecoration.Color = Color.MistyRose
        ResetButton.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        ResetButton.ShadowDecoration.Enabled = True
        ResetButton.Size = New Size(202, 46)
        ResetButton.TabIndex = 4
        ResetButton.Text = "Effacer"
        ' 
        ' ExitButton
        ' 
        ExitButton.Animated = True
        ExitButton.BackColor = Color.Transparent
        ExitButton.BorderRadius = 10
        ExitButton.Cursor = Cursors.Hand
        ExitButton.CustomizableEdges = CustomizableEdges11
        ExitButton.DisabledState.BorderColor = Color.DarkGray
        ExitButton.DisabledState.CustomBorderColor = Color.DarkGray
        ExitButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        ExitButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        ExitButton.FillColor = Color.Red
        ExitButton.FocusedColor = Color.Tomato
        ExitButton.Font = New Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point)
        ExitButton.ForeColor = Color.White
        ExitButton.HoverState.FillColor = Color.Salmon
        ExitButton.HoverState.Font = New Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point)
        ExitButton.HoverState.ForeColor = Color.White
        ExitButton.Image = CType(resources.GetObject("ExitButton.Image"), Image)
        ExitButton.ImageSize = New Size(32, 32)
        ExitButton.IndicateFocus = True
        ExitButton.Location = New Point(710, 534)
        ExitButton.Name = "ExitButton"
        ExitButton.PressedColor = Color.Tomato
        ExitButton.ShadowDecoration.BorderRadius = 10
        ExitButton.ShadowDecoration.Color = Color.Salmon
        ExitButton.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        ExitButton.ShadowDecoration.Enabled = True
        ExitButton.Size = New Size(128, 48)
        ExitButton.TabIndex = 5
        ExitButton.Text = "Quittez"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Times New Roman", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.WhiteSmoke
        Label2.Location = New Point(75, 208)
        Label2.Name = "Label2"
        Label2.Size = New Size(291, 42)
        Label2.TabIndex = 7
        Label2.Text = "MOT DE PASSE"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Times New Roman", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.WhiteSmoke
        Label1.Location = New Point(75, 81)
        Label1.Name = "Label1"
        Label1.Size = New Size(408, 42)
        Label1.TabIndex = 6
        Label1.Text = "NOM D'UTILISATEUR"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.BackgroundImageLayout = ImageLayout.Center
        Panel2.Controls.Add(PageTitleLabel)
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1266, 103)
        Panel2.TabIndex = 0
        ' 
        ' PageTitleLabel
        ' 
        PageTitleLabel.AutoSize = True
        PageTitleLabel.FlatStyle = FlatStyle.Flat
        PageTitleLabel.Font = New Font("Arial Black", 48F, FontStyle.Bold, GraphicsUnit.Point)
        PageTitleLabel.ForeColor = Color.Black
        PageTitleLabel.Location = New Point(162, 5)
        PageTitleLabel.Name = "PageTitleLabel"
        PageTitleLabel.Size = New Size(984, 90)
        PageTitleLabel.TabIndex = 0
        PageTitleLabel.Text = "MyArchive Edition LIMITED"
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.White
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1264, 681)
        Controls.Add(Panel1)
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "MyArchive - Page de Connexion"
        Panel1.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(UserProfileBox, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PageTitleLabel As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents UserProfileBox As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ExitButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ResetButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents LoginButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ShowPassButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents PasswordField As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents UsernameField As Guna.UI2.WinForms.Guna2TextBox
End Class
