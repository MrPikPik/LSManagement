Namespace Core
    Public Class Customer
        Protected Friend _FirstName As String
        Protected Friend _Address As Address
        Protected Friend _Phone As String
        Protected Friend _Mobile As String
        Protected Friend _Fax As String

        Protected Friend _CustomerNo As Integer
        Protected Friend _DateJoined As Date

        Public Property FirstName As String
            Get
                Return _FirstName
            End Get
            Set(value As String)
                _FirstName = value
            End Set
        End Property

        Public Property Address As Address
            Get
                Return _Address
            End Get
            Set(value As Address)
                _Address = value
            End Set
        End Property

        Public Property Phone As String
            Get
                Return _Phone
            End Get
            Set(value As String)
                _Phone = value
            End Set
        End Property

        Public Property Mobile As String
            Get
                Return _Mobile
            End Get
            Set(value As String)
                _Mobile = value
            End Set
        End Property

        Public Property Fax As String
            Get
                Return _Fax
            End Get
            Set(value As String)
                _Fax = value
            End Set
        End Property

        Public ReadOnly Property CustomerNo As Integer
            Get
                Return _CustomerNo
            End Get
        End Property

        Public ReadOnly Property CustomerSince As Date
            Get
                Return _DateJoined
            End Get
        End Property

        Public Function GetAddress() As String
            Return _Address.ToString()
        End Function



    End Class
End Namespace