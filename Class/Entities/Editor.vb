Public Class Editor

    Private id As Integer
    Private label, location As String

    Public Sub New(id As Integer, label As String, location As String)

        Me.id = id
        Me.label = label
        Me.location = location

    End Sub

    ReadOnly Property GetId As Integer
        Get
            Return id
        End Get
    End Property

    ReadOnly Property GetLabel As String
        Get
            Return label
        End Get
    End Property

    ReadOnly Property GetLocation As String
        Get
            Return location
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return label
    End Function
End Class
