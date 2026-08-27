Public Class ListItem

    Dim _text As String = ""
    Dim _item As String = ""

    Sub New(ByVal _textArg As String, ByVal _itemArg As String)
        _text = _textArg
        _item = _itemArg
    End Sub

    Public Property text()
        Get
            Return _text
        End Get
        Set(ByVal value)
            _text = value
        End Set
    End Property

    Public Property item()
        Get
            Return _item
        End Get
        Set(ByVal value)
            _item = value
        End Set
    End Property



End Class
