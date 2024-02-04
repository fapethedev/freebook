Public Class Author

    Private id As Integer
    Private lastname, firstname, nationality, bio, citation As String

    Public Sub New(id As Integer, lastname As String, firstname As String, nationality As String, bio As String, citation As String)

        Me.id = id
        Me.lastname = lastname
        Me.firstname = firstname
        Me.nationality = nationality
        Me.bio = bio
        Me.citation = citation

    End Sub

    ReadOnly Property GetId As Integer
        Get
            Return id
        End Get
    End Property

    ReadOnly Property GetLastName As String
        Get
            Return lastname
        End Get
    End Property

    ReadOnly Property GetFirstName As String
        Get
            Return firstname
        End Get
    End Property

    ReadOnly Property GetNationality As String
        Get
            Return nationality
        End Get
    End Property

    ReadOnly Property GetBio As String
        Get
            Return bio
        End Get
    End Property

    ReadOnly Property GetCitation As String
        Get
            Return citation
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return lastname + " " + firstname
    End Function
End Class
