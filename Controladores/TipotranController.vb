Public Class TipotranController

    Dim cadena As String = ""
    Dim dpara As New Dictionary(Of String, Object)

    Enum transac_tipo_movimiento
        todos
        ingresos
        descuentos
    End Enum
    Sub New()

    End Sub

    Public Function GetTransaccionesNomina(ByVal empresa As Int16, tiponom As String) As DataTable
        dpara.Clear()
        dpara("empresa") = empresa
        dpara("tiponom") = tiponom
        Dim tbData As New DataTable()
        cadena = "select distinct(b.transac) as transac, a.nombre, a.tipomov, a.tipovalor from tipotran a
                  inner join nominas b on a.empresa=b.empresa and a.transac=b.transac
                  where b.empresa=@empresa and b.tiponom=@tiponom  order by b.transac"
        llenaTabla(cadena, tbData, ListaParametros(dpara))
        Return tbData

    End Function



    Public Function InsertTipo_Tran(empresa As Short, transac As Short, nombre As String, tipomov As Char, tipovalor As Char,
                                    afectaseguro As Char, afectaisr As Char, formula As String, es_isr As Boolean, es_seguro As Boolean) As Boolean
        dpara.Clear()

        dpara("empresa") = empresa
        dpara("transac") = transac
        dpara("nombre") = nombre
        dpara("tipomov") = tipomov
        dpara("tipovalor") = tipovalor
        dpara("afectaseguro") = afectaseguro
        dpara("afectaisr") = afectaisr



        cadena = "INSERT INTO tipotran (empresa,transac,nombre,tipomov,tipovalor,afectaseguro,afectaisr)
                VALUES   (@empresa,@transac,@nombre,@tipomov,@tipovalor,@afectaseguro,@afectaisr)"
        Return EjecutarQuery(cadena, ListaParametros(dpara))


    End Function

    Public Function UpdateTipo_Tran(nombre As String, tipomov As Char, tipovalor As Char, afectaseguro As Char,
                                    afectaisr As Char, transac As Short, empresa As Short) As Boolean
        dpara.Clear()
        dpara("nombre") = nombre
        dpara("tipomov") = tipomov
        dpara("tipovalor") = tipovalor
        dpara("afectaseguro") = afectaseguro
        dpara("afectaisr") = afectaisr
        dpara("transac") = transac
        dpara("empresa") = empresa
        cadena = "select count(*) from tipotran where transac=@transac and transac<>@transac and empresa=@empresa"
        Dim existe As Short = BuscaEscalar(cadena, ListaParametros(dpara))
        If (existe = 0) Then
            cadena = "UPDATE       tipotran
                  SET          nombre = @nombre,tipomov=@tipomov,tipovalor=@tipovalor, afectaseguro=@afectaseguro,
                               afectaisr=@afectaisr
                  WHERE        transac = @transac and empresa=@empresa"
            Return EjecutarQuery(cadena, ListaParametros(dpara))
        Else
            Return False
        End If
    End Function

    Public Function GetTipoTran_TipoMov() As DataTable

        Dim tbData As New DataTable()
        cadena = "SELECT tipomov,nombre
                 FROM tipotran_tipomov"
        llenaTabla(cadena, tbData, ListaParametros(dpara))
        Return tbData
    End Function
    Public Function GetTipoTran_TipoValor() As DataTable

        Dim tbData As New DataTable()
        cadena = "SELECT tipovalor,nombre
                 FROM tipotran_tipovalor"
        llenaTabla(cadena, tbData, ListaParametros(dpara))
        Return tbData
    End Function

    Public Sub FillComboTipoTran_TipoMov(ByRef cmb As ComboBox, Optional blank As Boolean = True)
        Dim tb As DataTable = Me.GetTipoTran_TipoMov()
        If blank Then
            tb.Rows.Add("", "")
        End If
        If Not tb Is Nothing Then
            cmb.DataSource = tb
            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "tipomov"
        End If

    End Sub
    Public Sub FillComboTipoTran_TipoValor(ByRef cmb As ComboBox, Optional blank As Boolean = True)
        Dim tb As DataTable = Me.GetTipoTran_TipoValor()
        If blank Then
            tb.Rows.Add("", "")
        End If
        If Not tb Is Nothing Then
            cmb.DataSource = tb
            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "tipovalor"
        End If

    End Sub

    Public Function GetSoloTransac(transac As Short, empresa As Short) As Int32
        dpara.Clear()
        dpara("transac") = transac

        cadena = "select transac FROM tipotran
                  WHERE transac = @transac and empresa=@empresa"
        Return BuscaEscalar(cadena, ListaParametros(dpara))

    End Function


    Public Function GetTransac(ByVal empresa As Int16) As DataTable
        dpara.Clear()
        dpara("empresa") = empresa
        cadena = "SELECT        transac, empresa, nombre, tipomov, tipovalor, afectaseguro, afectaisr, ctacte, cuentanom
                        FROM    tipotran 
                        WHERE  (empresa = @empresa) 
                        ORDER BY transac"
        Dim tbData As New DataTable()
        llenaTabla(cadena, tbData, ListaParametros(dpara))
        Return tbData
    End Function

    Public Function GetTransacIngresos(ByVal empresa As Int16) As DataTable
        dpara.Clear()
        dpara("empresa") = empresa
        cadena = "SELECT        transac, empresa, nombre, tipomov, tipovalor, afectaseguro, afectaisr, ctacte, cuentanom
                        FROM    tipotran 
                        WHERE  empresa = @empresa and tipomov='I'
                        ORDER BY transac"
        Dim tbData As New DataTable()
        llenaTabla(cadena, tbData, ListaParametros(dpara))
        Return tbData
    End Function

    Public Function GetTransacDescuentos(ByVal empresa As Int16) As DataTable
        dpara.Clear()
        dpara("empresa") = empresa
        cadena = "SELECT        transac, empresa, nombre, tipomov, tipovalor, afectaseguro, afectaisr, ctacte, cuentanom
                        FROM    tipotran 
                        WHERE  empresa = @empresa and tipomov='D'
                        ORDER BY transac"
        Dim tbData As New DataTable()
        llenaTabla(cadena, tbData, ListaParametros(dpara))
        Return tbData
    End Function


    Public Sub FillComboTransac(ByRef cmb As ComboBox, empresa As Short, opc As transac_tipo_movimiento, Optional blank As Boolean = True)
        Dim tb As DataTable
        If opc = transac_tipo_movimiento.todos Then
            tb = Me.GetTransac(empresa)
        ElseIf opc = transac_tipo_movimiento.ingresos Then
            tb = Me.GetTransacIngresos(empresa)
        ElseIf opc = transac_tipo_movimiento.descuentos Then
            tb = Me.GetTransacDescuentos(empresa)
        End If
        If blank AndAlso tb IsNot Nothing Then
            Dim dr As DataRow = tb.NewRow
            dr("transac") = 0
            dr("nombre") = ""
            dr("empresa") = empresa
            tb.Rows.Add(dr)
        End If
        If Not tb Is Nothing Then

            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "transac"
            cmb.DataSource = tb
        End If

    End Sub


    Public Function GetTipoMovimiento() As DataTable
        dpara.Clear()

        Dim tbData As New DataTable()
        cadena = "Select tipomov, nombre from tipotran_tipomov order by nombre"
        llenaTabla(cadena, tbData, ListaParametros(dpara))
        Return tbData
    End Function

    Public Sub FillComboTipoMovimiento(ByRef cmb As ComboBox, Optional blank As Boolean = True)
        Dim tb As DataTable = Me.GetTipoMovimiento()
        If blank Then
            tb.Rows.Add(0, "", "")
        End If
        If Not tb Is Nothing Then

            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "tipomov"
            cmb.DataSource = tb
        End If

    End Sub

    Public Function GetCodigoTransacUsuario(ByVal id_transac As Int16, empresa As Short) As Int16
        dpara.Clear()
        dpara("transac") = id_transac
        cadena = "Select transac from tipotran where transac=@transac and empresa=@empresa"
        Dim transac As Int16 = BuscaEscalar(cadena, ListaParametros(dpara))
        Return transac
    End Function


    Public Function GetTransaccion(ByVal transac As Int16, empresa As Short) As DataRow 'TipoTranViewModel

        Dim t1 As New DataTable
        dpara.Clear()
        dpara("transac") = transac
        dpara("empresa") = empresa

        cadena = "Select transac, nombre, tipomov, tipovalor, afectaseguro, afectaisr
                From tipotran where transac=@transac and empresa=@empresa"

        llenaTabla(cadena, t1, ListaParametros(dpara))
        Return t1.Rows(0)

    End Function

    Public Function GetTipoMovimientoNom(tipomov As String) As String
        dpara.Clear()
        dpara("tipomov") = tipomov
        cadena = "select isnull(max(nombre),'') from tipotran_tipomov where tipomov=@tipomov"
        Return BuscaEscalar(cadena, ListaParametros(dpara))
    End Function


End Class
