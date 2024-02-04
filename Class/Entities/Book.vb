
Public Class Book

    Private id, qte As Integer
    Private cover, title, isbn As String
    Private publish As DateTime
    Private isAvailable As Boolean
    Private author As Author
    Private editor As Editor

    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return title
    End Function

    Public Sub New(id As Integer, cover As String, title As String, isbn As String, publish As Date, qte As Integer, isAvailable As Boolean)

        Me.id = id
        Me.cover = cover
        Me.title = title
        Me.isbn = isbn
        Me.publish = publish
        Me.qte = qte
        Me.isAvailable = isAvailable

    End Sub

    Public Sub New(id As Integer, cover As String, title As String, isbn As String, publish As DateTime, qte As Integer, isAvailable As Boolean, author As Author, editor As Editor)

        Me.id = id
        Me.cover = cover
        Me.title = title
        Me.isbn = isbn
        Me.publish = publish
        Me.qte = qte
        Me.isAvailable = isAvailable
        Me.author = author
        Me.editor = editor

    End Sub

    ReadOnly Property GetId As Integer
        Get
            Return id
        End Get
    End Property

    ReadOnly Property GetCover As String
        Get
            Return cover
        End Get
    End Property

    ReadOnly Property GetTitle As String
        Get
            Return title
        End Get
    End Property

    ReadOnly Property GetIsbn As String
        Get
            Return isbn
        End Get
    End Property

    ReadOnly Property GetPublished As DateTime
        Get
            Return publish
        End Get
    End Property

    ReadOnly Property GetQte As Integer
        Get
            Return qte
        End Get
    End Property

    ReadOnly Property GetAvailabilty As Boolean
        Get
            Return isAvailable
        End Get
    End Property

    ReadOnly Property GetAuthor As Author
        Get
            Return author
        End Get
    End Property

    ReadOnly Property GetEditor As Editor
        Get
            Return editor
        End Get
    End Property

    WriteOnly Property SetAuthor As Author
        Set(ByVal author As Author)
            Me.author = author
        End Set
    End Property

    WriteOnly Property SetEditor As Editor
        Set(ByVal editor As Editor)
            Me.editor = editor
        End Set
    End Property




End Class
