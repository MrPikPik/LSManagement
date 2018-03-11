Public Class Artikel_hinzufügen
    Public ComboBox1Contents As String() = {"Beschläge", "Chemische Produkte"}
    Public ComboBox2Contents As String() = {}
    Public ComboBox3Contents As String()() = {}

    Public LabelType As String = "Default"
    Public LabelTexts As String()() = New String()() {({"Label1", "Label2", "Label3", "Label4", "Label5", "Label6", "Label7", "Label8", "Label9", "Label10", "Label11", "Label12", "Label13", "Label14"}),
                                                      ({"AnderesLabel1", "AnderesLabel2", "AnderesLabel3", "AnderesLabel4", "AnderesLabel5", "AnderesLabel6", "AnderesLabel7", "AnderesLabel8", "AnderesLabel9", "AnderesLabel10", "AnderesLabel11", "AnderesLabel12", "AnderesLabel13", "AnderesLabel14"})}

    Public Sub RefreshCategorySelectors() Handles CategoryComboBox.SelectedIndexChanged, ComboBox2.SelectedIndexChanged, ComboBox3.SelectedIndexChanged
        LabelType = CategoryComboBox.Text
        RefesehLables()
    End Sub

    Public Sub RefesehLables()
        Dim labelIndex As Integer = -1
        Select Case LabelType
            Case "Standard"
                labelIndex = 1
            Case Else
                labelIndex = 0
        End Select

        Label8.Text = LabelTexts(labelIndex)(0)
        Label9.Text = LabelTexts(labelIndex)(1)
        Label10.Text = LabelTexts(labelIndex)(2)
        Label11.Text = LabelTexts(labelIndex)(3)
        Label12.Text = LabelTexts(labelIndex)(4)
        Label13.Text = LabelTexts(labelIndex)(5)
        Label14.Text = LabelTexts(labelIndex)(6)
        Label15.Text = LabelTexts(labelIndex)(7)
        Label16.Text = LabelTexts(labelIndex)(8)
        Label17.Text = LabelTexts(labelIndex)(9)
        Label18.Text = LabelTexts(labelIndex)(10)
        Label19.Text = LabelTexts(labelIndex)(11)
        Label20.Text = LabelTexts(labelIndex)(12)
        Label21.Text = LabelTexts(labelIndex)(13)
    End Sub

    Private Sub Artikel_hinzufügen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CategoryComboBox.Items.Add("Standard")
        CategoryComboBox.Items.Add("Nicht Standard")
    End Sub
End Class