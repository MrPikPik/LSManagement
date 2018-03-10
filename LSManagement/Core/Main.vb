Imports LSManagement.Core

Public NotInheritable Class Main
    'Singleton
    Public Shared ReadOnly Property Intance As Main
        Get
            Static INST As Main = New Main
            Return INST
        End Get
    End Property
    Public Sub New()
    End Sub


End Class