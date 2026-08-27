Public Class TipoNominasController

    Private cdata As cmodelo2
    Dim cadena As String = ""
    Dim lpara As New Dictionary(Of String, Object)

    Sub New()
        cdata = New cmodelo2(_conexion)
    End Sub

    Public Function GetTipoNomina() As DataTable
        Dim tb As New DataTable
        lpara("empresa") = empresa
        cadena = "select empresa, tiponom, nombre, tipago, cuenta, cantidad, cantidadnom, movimientos, desprestamos, por, mes
                 from tiponomina1 where empresa=@empresa order by tiponom"
        tb = cdata.llenaTabla(cadena, ListaParametros(lpara))
        Return tb
    End Function



    Public Sub FillComboTipoNomina(ByRef cmb As ComboBox, Optional blank As Boolean = True)
        Dim tb As DataTable = Me.GetTipoNomina()
        If blank Then
            Dim fila As DataRow = tb.NewRow()
            fila("tiponom") = ""
            fila("nombre") = ""
            tb.Rows.Add(fila)
        End If
        If Not tb Is Nothing Then
            cmb.DataSource = tb
            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "tiponom"
        End If

    End Sub


End Class
