Public Class Loan

    Private id, cost As Integer
    Private lstart, lend As DateTime
    Private user As ActualUser
    Private book As Book
    Private client As Client

    Public Sub New()
    End Sub

    Public Sub New(id As Integer, lstart As Date, lend As Date, cost As Integer)
        Me.id = id
        Me.cost = cost
        Me.lstart = lstart
        Me.lend = lend
    End Sub

    Public Sub New(id As Integer, cost As Integer, lstart As Date, lend As Date, user As ActualUser, book As Book, client As Client)
        Me.id = id
        Me.cost = cost
        Me.lstart = lstart
        Me.lend = lend
        Me.user = user
        Me.book = book
        Me.client = client
    End Sub

    ReadOnly Property GetId As Integer
        Get
            Return id
        End Get
    End Property

    ReadOnly Property GetCost As Integer
        Get
            Return cost
        End Get
    End Property

    ReadOnly Property GetStartDate As DateTime
        Get
            Return lstart
        End Get
    End Property

    ReadOnly Property GetEndDate As DateTime
        Get
            Return lend
        End Get
    End Property

    ReadOnly Property GetUser As ActualUser
        Get
            Return user
        End Get
    End Property

    ReadOnly Property GetBook As Book
        Get
            Return book
        End Get
    End Property

    ReadOnly Property GetClient As Client
        Get
            Return client
        End Get
    End Property

    WriteOnly Property SetUser As ActualUser
        Set(ByVal user As ActualUser)
            Me.user = user
        End Set
    End Property

    WriteOnly Property SetClient As Client
        Set(ByVal client As Client)
            Me.client = client
        End Set
    End Property

    WriteOnly Property SetBook As Book
        Set(ByVal book As Book)
            Me.book = book
        End Set
    End Property

End Class
