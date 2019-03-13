Public Class AudioDevice
    Public name As String
    Public deviceControllerInformation As String
    Public ID As String

    Public Property DeviceName() As String
        Get
            Return name
        End Get
        Set(value As String)
            name = value
        End Set
    End Property
    Public Property DeviceID() As String
        Get
            Return ID
        End Get
        Set(value As String)
            ID = value
        End Set
    End Property
End Class
