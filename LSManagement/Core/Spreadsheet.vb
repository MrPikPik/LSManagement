Namespace Core
    Public Class Spreadsheet
        Private _data As Cell()()
        Private _cols As Integer
        Private _rows As Integer

        ''' <summary>
        ''' Gets the current count of columns in this spreadsheet.
        ''' </summary>
        ''' <returns>Returns the current count of columns in this spreadsheet.</returns>
        Public ReadOnly Property Columns
            Get
                Return _cols
            End Get
        End Property

        ''' <summary>
        ''' Gets the current count of rows in this spreadsheet.
        ''' </summary>
        ''' <returns>Returns the current count of rows in this spreadsheet.</returns>
        Public ReadOnly Property Rows
            Get
                Return _rows
            End Get
        End Property


        Public Function Column(ByVal heading As String) As Cell()
            For i = 0 To _data(0).Length - 1
                If (_data(0)(i).Content = heading) Then
                    Return Column(i)
                End If
            Next
            Throw New HeadingNonExistentException
            Return Nothing
        End Function

        Public Function Column(ByVal index As Integer) As Cell()
            Dim res As Cell() = New Cell(_data.Length - 1) {}
            For i = 0 To _data.Length - 1
                res(i) = _data(i)(index)
            Next
            Return res
        End Function

        Public Function Range(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Cell()()
            'Check if requested data exists
            If (((x1 < 0) Or (x2 < 0) Or (y1 < 0) Or (y2 < 0)) Or ((x1 > _cols) Or (x2 > _cols) Or (y1 > _cols) Or (y2 > _cols)) Or ((x1 > _rows) Or (x2 > _rows) Or (y1 > _rows) Or (y2 > _rows))) Then
                Throw New IndexOutOfRangeException
                Return Nothing
            Else
                'Subtractions to get 0 based array indices
                Dim res As Cell()() = New Cell(x2 - x1)() {}

                'Loop trough all cells
                For x = x1 To x2
                    res(x - x1) = New Cell(y2 - y1) {}
                    For y = y1 To y2
                        res(x - x1)(y - y1) = _data(x)(y)
                    Next
                Next

                Return res
            End If
        End Function

        ''' <summary>
        ''' Creates a spreadsheet from a given CSV file.
        ''' </summary>
        ''' <param name="filepath">The filepath to the csv to be loaded.</param>
        ''' <returns></returns>
        ''' <exception cref="NotACSVFileExcption">The given file was not a csv file.</exception>
        ''' <exception cref="FileNotFoundException">The requested file does not exist.</exception>
        ''' <exception cref="FileContentsInvalid">The contents of the file were invalid.</exception>"
        Public Shared Function LoadFromCSV(ByVal filepath As String) As Spreadsheet
            'File checking
            If IO.File.Exists(filepath) Then
                If (filepath.EndsWith(".csv") Or filepath.EndsWith(".CSV")) Then
                    'Wrap in try block in case something goes wrong during parsing.
                    Try
                        'Split file contents by row and each row by comma (see CSV spec)
                        Dim pRawData As String() = IO.File.ReadAllLines(filepath)
                        Dim pData As String()() = New String(pRawData.Length - 1)() {}
                        For i = 0 To pRawData.Length - 1
                            pData(i) = Split(pRawData(i), ";")
                        Next

                        Dim pCells As Cell()() = New Cell(pData.Length - 1)() {}
                        For x = 0 To pData.Length - 1
                            Dim pCellRow As Cell() = New Cell(pData(x).Length - 1) {}
                            For y = 0 To pData(x).Length - 1
                                pCellRow(y) = New Cell(pData(x)(y))
                            Next
                            pCells(x) = pCellRow
                        Next
                        'Populate new spreadsheet member
                        Dim spsh As New Spreadsheet()
                        spsh._data = pCells
                        spsh._rows = pCells.Length
                        Try
                            spsh._cols = pCells(0).Length
                        Catch
                            spsh._cols = 0
                        End Try

                        Return spsh
                    Catch
                        Throw New FileContentsInvalidException
                        Return Nothing
                    End Try
                Else
                    Throw New NotACSVFileExcption
                    Return Nothing
                End If
            Else
                Throw New FileNotFoundException
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Saves this object as a CSV-Spreadsheet to a given path.
        ''' </summary>
        ''' <param name="filepath">The filepath and name for the file to be saved to.</param>
        ''' <param name="override">Whether to override a possible existing file.</param>
        ''' <returns>If the saving attempt has been successfull.</returns>
        Public Function SaveAsCSV(ByVal filepath As String, ByVal override As Boolean) As Boolean
            If (IO.File.Exists(filepath) And override) Then
                Return False
            Else
                Return False
            End If
        End Function

        'Constructors
        ''' <summary>
        ''' Creates a new instance of a Spreadsheet
        ''' </summary>
        Public Sub New()
            Me._data = Nothing
            Me._rows = 0
            Me._cols = 0
        End Sub

        'Exceptions
        Public Class FileNotFoundException : Inherits Exception
            Public Sub New()
                MyBase.New("File Not found")
            End Sub
            Public Sub New(ByVal message As String)
                MyBase.New(message)
            End Sub
            Public Sub New(ByVal message As String, ByVal inner As Exception)
                MyBase.New(message, inner)
            End Sub
        End Class
        Public Class NotACSVFileExcption : Inherits Exception
            Public Sub New()
                MyBase.New("File is not a csv spreadsheet!")
            End Sub
            Public Sub New(ByVal message As String)
                MyBase.New(message)
            End Sub
            Public Sub New(ByVal message As String, ByVal inner As Exception)
                MyBase.New(message, inner)
            End Sub
        End Class
        Public Class FileContentsInvalidException : Inherits Exception
            Public Sub New()
                MyBase.New("The contents of this file could not be read to specifications. Make sure if the file is correct or not corrupted.")
            End Sub
            Public Sub New(ByVal message As String)
                MyBase.New(message)
            End Sub
            Public Sub New(ByVal message As String, ByVal inner As Exception)
                MyBase.New(message, inner)
            End Sub
        End Class
        Public Class HeadingNonExistentException : Inherits Exception
            Public Sub New()
                MyBase.New("The requested heading can not be found in this spreadsheet.")
            End Sub
            Public Sub New(ByVal message As String)
                MyBase.New(message)
            End Sub
            Public Sub New(ByVal message As String, ByVal inner As Exception)
                MyBase.New(message, inner)
            End Sub
        End Class
    End Class

    ''' <summary>
    ''' Class for Cells used in spreadsheets.
    ''' </summary>
    Public Class Cell
        'Fields
        Private _content As String

        'Properties
        ''' <summary>
        ''' Gets or sets the content of this cell.
        ''' </summary>
        ''' <returns>Returns the current content of this cell.</returns>
        Public Property Content() As String
            Get
                Return Me._content
            End Get
            Set(value As String)
                Me._content = value
            End Set
        End Property

        'Instance Functions
        ''' <summary>
        ''' Empties the cell of its contents.
        ''' </summary>
        Public Sub Clear()
            Me._content = Nothing
        End Sub

        ''' <summary>
        ''' Creates a copy of this cell.
        ''' </summary>
        ''' <returns>Returns a copy of the calling cell.</returns>
        Public Function Copy() As Cell
            Return New Cell(Me._content)
        End Function

        'Shared Functions
        ''' <summary>
        ''' Creates a copy of a given cell.
        ''' </summary>
        ''' <param name="cell">The cell to be cloned.</param>
        ''' <returns>Returns the cloned cell.</returns>
        Public Shared Function Copy(ByRef cell As Cell) As Cell
            Return cell.Copy()
        End Function

        'Constructors
        ''' <summary>
        ''' Generates a new instance with blank contents.
        ''' </summary>
        Public Sub New()
            Me._content = ""
        End Sub

        ''' <summary>
        ''' Generates a new instance with given contents.
        ''' </summary>
        ''' <param name="text">Text for the cell to be filled with.</param>
        Public Sub New(ByVal text As String)
            Me._content = text
        End Sub

        'Overrrides
        ''' <summary>
        ''' Returns Cells contents as String.
        ''' </summary>
        ''' <returns>Returns Cells contents.</returns>
        Public Overrides Function ToString() As String
            Return Me._content
        End Function


        'Operators
        Shared Operator =(ByVal leftCell As Cell, ByVal rightCell As Cell) As Boolean
            Return (leftCell.Content = rightCell.Content)
        End Operator
        Shared Operator <>(ByVal leftCell As Cell, ByVal rightCell As Cell) As Boolean
            Return (leftCell.Content <> rightCell.Content)
        End Operator
    End Class
End Namespace