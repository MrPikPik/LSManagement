Public Class TestForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim kundeAnlegen As New Kunde_anlegen
        kundeAnlegen.ShowDialog()

    End Sub
End Class