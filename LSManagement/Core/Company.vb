Namespace Core
    Public Class Company : Inherits Customer
        Protected Friend _contact As Person

        Public Property ContactPerson As Person
            Get
                Return _contact
            End Get
            Set(value As Person)
                _contact = value
            End Set
        End Property
    End Class
End Namespace