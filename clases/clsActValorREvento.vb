Public Delegate Sub ActValorEventHandler(ByVal sender As Object, ByVal e As clsActValorREvento)


Public Class clsActValorREvento
    Inherits System.EventArgs

    'Se declaran las variables que se van a mandar como argumentos 
    Dim val1 As String
    Dim val2 As Int32

    Public Sub New(ByVal value As String, ByVal value2 As Int32)
        MyBase.New()
        val1 = value
        val2 = value2
    End Sub

    ReadOnly Property va1() As String
        Get
            Return val1
        End Get
    End Property

    ReadOnly Property va2() As Int32
        Get
            Return val2
        End Get
    End Property


End Class
