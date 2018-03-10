Imports LSManagement.Core

Public Class Person
    Private _FirstName As String
    Private _MiddleName As String
    Private _LastName As String

    Private _Gender As GenderName

    Private _Address As Address


    Public Property FirstName As String
        Get
            Return _FirstName
        End Get
        Set(value As String)
            _FirstName = value
        End Set
    End Property

    Public Property MiddleName As String
        Get
            Return _MiddleName
        End Get
        Set(value As String)
            _MiddleName = value
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _LastName
        End Get
        Set(value As String)
            _LastName = value
        End Set
    End Property

    Public Property Gender As GenderName
        Get
            Return _Gender
        End Get
        Set(value As GenderName)
            _Gender = value
        End Set
    End Property


    Public ReadOnly Property Name(ByVal Optional fullName As Boolean = False) As String
        Get
            If fullName Then
                Return _FirstName & " " & _MiddleName & " " & _LastName
            Else
                Return _FirstName & " " & _LastName
            End If
        End Get
    End Property

    Public Property Address As Address
        Get
            Return _Address
        End Get
        Set(value As Address)
            _Address = value
        End Set
    End Property



    Public Function GetAddress() As String
        Return _Address.ToString()
    End Function

    ''' <summary>
    ''' Gets the name of the person.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetName() As String
        Dim anrede As String = Nothing
        Select Case _Gender
            Case GenderName.Female
                anrede = "Frau "
            Case GenderName.Male
                anrede = "Herr "
            Case Else
                anrede = ""
        End Select
        Return anrede & _FirstName & " " & _LastName
    End Function

    ''' <summary>
    ''' Enum with different available gender options.
    ''' </summary>
    Public Enum GenderName
        none = 0
        Male = 1
        Female = 2
        Other = 3
        Unpecified = 4
    End Enum
End Class