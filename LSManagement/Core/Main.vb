﻿Imports LSManagement.Core

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

    Private _customers As Customer()

    Public Property Customers As Customer()
        Get
            Return _customers
        End Get
        Set(value As Customer())
            _customers = value
        End Set
    End Property




End Class