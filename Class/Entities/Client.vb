Public Class Client

    Private id As Integer
    Private profile_picture, lastname, firstname, address, contact, sex As String

    Public Sub New(id As Integer, profile_picture As String, lastname As String, firstname As String, address As String, contact As String, sex As String)

        Me.id = id
        Me.profile_picture = profile_picture
        Me.lastname = lastname
        Me.firstname = firstname
        Me.address = address
        Me.contact = contact
        Me.sex = sex

    End Sub

    Public Overrides Function ToString() As String
        Return lastname + " " + firstname
    End Function

    ReadOnly Property GetId As Integer
        Get
            Return id
        End Get
    End Property

    ReadOnly Property GetProfilePicture As String
        Get
            Return profile_picture
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

    ReadOnly Property GetAddress As String
        Get
            Return address
        End Get
    End Property

    ReadOnly Property GetContact As String
        Get
            Return contact
        End Get
    End Property

    ReadOnly Property GetSex As String
        Get
            Return sex
        End Get
    End Property

End Class
