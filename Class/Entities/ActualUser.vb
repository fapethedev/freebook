Public Class ActualUser

    Private id As Integer
    Private username As String

    Public Sub New(id As Integer, username As String)
        Me.id = id
        Me.username = username
    End Sub

    Public Overrides Function ToString() As String
        Return username
    End Function

    Public Sub New(username As String)

        Me.username = username

    End Sub

    ReadOnly Property getUsername As String
        Get
            Return username
        End Get
    End Property

    ReadOnly Property GetId As Integer
        Get
            Return id
        End Get
    End Property



End Class
