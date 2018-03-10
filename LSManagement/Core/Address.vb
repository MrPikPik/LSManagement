Namespace Core
    ''' <summary>
    ''' A Class handling all address related data like street adress and coutries. 
    ''' </summary>
    Public Class Address
        Private _StreetName As String
        Private _HouseNumber As String
        Private _ZIPCode As String
        Private _CityName As String
        Private _State As String
        Private _Country As CountryName

        ''' <summary>
        ''' Gets or sets the streetname.
        ''' </summary>
        ''' <returns>Returns the streetname.</returns>
        Public Property Streetname As String
            Get
                Return _StreetName
            End Get
            Set(value As String)
                _StreetName = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the house number.
        ''' </summary>
        ''' <returns>Returns the house number.</returns>
        Public Property HouseNumber As String
            Get
                Return _HouseNumber
            End Get
            Set(value As String)
                _HouseNumber = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the zip code.
        ''' </summary>
        ''' <returns>Returns zip code.</returns>
        Public Property ZIP As String
            Get
                Return _ZIPCode
            End Get
            Set(value As String)
                _ZIPCode = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the city.
        ''' </summary>
        ''' <returns>Returns the city.</returns>
        Public Property City As String
            Get
                Return _CityName
            End Get
            Set(value As String)
                _CityName = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the state.
        ''' </summary>
        ''' <returns>Returns the state.</returns>
        Public Property State As String
            Get
                Return _State
            End Get
            Set(value As String)
                _State = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the country.
        ''' </summary>
        ''' <returns>Returns the country.</returns>
        Public Property Country As CountryName
            Get
                Return _Country
            End Get
            Set(value As CountryName)
                _Country = value
            End Set
        End Property


        Public Overrides Function ToString() As String
            Return Streetname & " " & HouseNumber & vbNewLine &
               ZIP & " " & City & vbNewLine &
               State & " " & Country.ToString()
        End Function

        ''' <summary>
        ''' Enum with different country names. Definitly incomplete lol.
        ''' </summary>
        Public Enum CountryName
            none = 0
            Germany = 1
            France = 2
            Belgium = 3
            Denmark = 4
            Finland = 5
            Greece = 6
            Luxembourg = 7
            Norway = 8
            Sweden = 9
            Switzerland = 10
            Netherlands = 11
            Austria = 12
            Italy = 13
            Spain = 14
            Poland = 14
            Czech_Republic = 15
            Other = 999
        End Enum
    End Class
End Namespace