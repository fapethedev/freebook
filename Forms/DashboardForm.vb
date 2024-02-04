Public Class DashboardForm

    Private actualUser As ActualUser

    Public Sub New(actualUser As ActualUser)

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

        Me.actualUser = actualUser

    End Sub

    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LocalTime.Interval = 1000
        LocalTime.Start()

        DashUsername.Text = actualUser.getUsername

    End Sub

    Private Sub LocalTime_Tick(sender As Object, e As EventArgs) Handles LocalTime.Tick

        LocalTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss")
        LocalDateLabel.Text = DateTime.Now.ToString("dd/MM/yyyy")

    End Sub

    Private Sub BookTabButton_Click(sender As Object, e As EventArgs) Handles BookTabButton.Click

    End Sub
End Class