
Imports System.Data

Namespace controller
    Public Class EmpleadoController

        Dim cadena As String = ""
        Dim dpara As New Dictionary(Of String, Object)

        Sub New()

        End Sub


        Public Function GetEmpleado(ByVal empresa As Int16, ByVal empleado As Int32) As DataTable
            Return Nothing
        End Function


        Public Function GetEmpleados(ByVal empresa As Int16) As DataTable
            dpara.Clear()
            dpara("empresa") = empresa
            Dim tbData As New DataTable()
            cadena = "select empleado, apellido1 + ' ' + apellido2 + ' ' + nombre1 + ' ' + nombre2 as nombre from emplegen a
                 where empresa = @empresa And empleado In (Select empleado from contratos1 b where a.empresa=b.empresa And b.estado In (0, 4))"
            llenaTabla(cadena, tbData, ListaParametros(dpara))
            Return tbData

        End Function

        Public Function GetMaxContratoEmpleado(ByVal empleado As Int32, ByVal empresa As Int16) As Int32
            dpara.Clear()
            dpara("empresa") = empresa
            dpara("empleado") = empleado
            cadena = "select isnull(max(contrato),0) from contratos1 where estado in (0,4) and empresa=@empresa and empleado=@empleado "
            Dim objeto As Object = BuscaEscalar(cadena, ListaParametros(dpara))
            Dim contrato As Int32 = 0
            If (objeto IsNot Nothing AndAlso Int32.TryParse(objeto.ToString(), contrato)) Then
                Return contrato
            Else
                Return 0
            End If
        End Function


        Public Function GetIdentificaEmpleado(ByVal empleado As Int32, ByVal empresa As Int16) As Tuple(Of String, String)
            dpara.Clear()
            dpara("empresa") = empresa
            dpara("empleado") = empleado
            Dim tbData As New DataTable
            cadena = "select a.numidentica, b.nombre from emplegen a
                     inner join tiidentifica b on a.tipoiden=b.tipoiden 
                     where empresa=@empresa and empleado=@empleado "
            If llenaTabla(cadena, tbData, ListaParametros(dpara)) > 0 Then
                Return New Tuple(Of String, String)(tbData.Rows(0)("nombre"), tbData.Rows(0)("numidentica"))
            Else
                Return New Tuple(Of String, String)("", "")
            End If

        End Function


        Public Function GetEmpleadosContrato(ByVal empresa As Int16) As DataTable
            dpara.Clear()
            dpara("empresa") = empresa
            Dim tbData As New DataTable()
            cadena = "select a.empleado, a.apellido1 + ' ' + a.apellido2 + ' ' + a.nombre1 + ' ' + a.nombre2 as nombre, 
                      b.contrato,  c.nombre as nombre_puesto, b.tipoper
                      from emplegen a 
                      inner join contratos1 b on a.empresa=b.empresa and a.empleado=b.empleado 
                      inner join puestosper c on a.empresa=c.empresa and b.puesto=c.puesto
                      where a.empresa = @empresa And  b.estado In (0, 4) order by nombre, b.contrato"
            llenaTabla(cadena, tbData, ListaParametros(dpara))
            Return tbData
        End Function

        Public Function GetEmpleadosContrato(ByVal empresa As Int16, ltipopersonal As List(Of Int16)) As DataTable
            dpara.Clear()
            dpara("empresa") = empresa
            Dim tbData As New DataTable()
            Dim condi As String = ""
            Dim i As Int16 = 1
            For Each ele As Int16 In ltipopersonal
                condi &= $" or b.tipoper= @{i}"
                dpara($"@{i}") = ele
                i += 1
            Next
            If condi.Length > 0 Then
                condi = condi.Substring(3)
                condi = $" and ({condi})"
            Else
                condi = "and 0=1"
            End If


            cadena = $"select a.empleado, a.apellido1 + ' ' + a.apellido2 + ' ' + a.nombre1 + ' ' + a.nombre2 as nombre, 
                      b.contrato,  c.nombre as nombre_puesto
                      from emplegen a 
                      inner join contratos1 b on a.empresa=b.empresa and a.empleado=b.empleado 
                      inner join puestosper c on a.empresa=c.empresa and b.puesto=c.puesto
                      where a.empresa = @empresa And  b.estado In (0, 4) {condi} order by nombre, b.contrato"
            llenaTabla(cadena, tbData, ListaParametros(dpara))
            Return tbData
        End Function


        Public Function GetEmpleadosContratoAño(ByVal empresa As Int16, año As Short) As DataTable
            dpara.Clear()
            dpara("empresa") = empresa
            dpara("año") = año
            Dim tbData As New DataTable()
            Dim condi As String = ""
            Dim i As Int16 = 1

            cadena = $"select a.empleado, a.apellido1 + ' ' + a.apellido2 + ' ' + a.nombre1 + ' ' + a.nombre2 as nombre, 
                      b.contrato,  c.nombre as nombre_puesto
                      from emplegen a 
                      inner join contratos1 b on a.empresa=b.empresa and a.empleado=b.empleado 
                      inner join puestosper c on a.empresa=c.empresa and b.puesto=c.puesto
                      where a.empresa = @empresa And  ( b.estado In (0, 4) or year(b.fechaf) =@año  order by nombre, b.contrato"
            llenaTabla(cadena, tbData, ListaParametros(dpara))
            Return tbData
        End Function


        Public Function GetNivelEducativo() As DataTable

            Dim tbData As New DataTable()
            cadena = "select id_nivel_educativo,  nombre from emplegen_nivel_educativo a
                 order by id_nivel_educativo"
            llenaTabla(cadena, tbData)
            Return tbData
        End Function

        Public Sub FillComboNivelEducativo(ByRef cmb As ComboBox, Optional blank As Boolean = True)
            Dim tb As DataTable = Me.GetNivelEducativo
            If blank Then
                tb.Rows.Add(0, "")
            End If
            If Not tb Is Nothing Then
                cmb.DataSource = tb
                cmb.DisplayMember = "nombre"
                cmb.ValueMember = "id_nivel_educativo"
            End If

        End Sub

        Public Function GetComLing() As DataTable

            Dim tbData As New DataTable()
            cadena = "select id_comunidad_ling,  nombre from emplegen_comunidad_linguistica a
                 order by nombre"
            llenaTabla(cadena, tbData)
            Return tbData
        End Function

        Public Sub FillComboComunidadLing(ByRef cmb As ComboBox, Optional blank As Boolean = True)
            Dim tb As DataTable = Me.GetComLing
            If blank Then
                tb.Rows.Add(0, "")
            End If
            If Not tb Is Nothing Then
                cmb.DataSource = tb
                cmb.DisplayMember = "nombre"
                cmb.ValueMember = "id_comunidad_ling"
            End If

        End Sub
        Public Function GetPuebloPert() As DataTable

            Dim tbData As New DataTable()
            cadena = "select id_pueblo_pertenencia,  nombre from emplegen_pueblo_pertenencia a
                 order by id_pueblo_pertenencia"
            llenaTabla(cadena, tbData)
            Return tbData
        End Function

        Public Sub FillComboPuebloPert(ByRef cmb As ComboBox, Optional blank As Boolean = True)
            Dim tb As DataTable = Me.GetPuebloPert
            If blank Then
                tb.Rows.Add(0, "")
            End If
            If Not tb Is Nothing Then
                cmb.DataSource = tb
                cmb.DisplayMember = "nombre"
                cmb.ValueMember = "id_pueblo_pertenencia"
            End If

        End Sub

        Public Function GetTipoDiscapacidad() As DataTable

            Dim tbData As New DataTable()
            cadena = "select id_tipo_discapacidad,  nombre from emplegen_tipo_discapacidad a
                 order by id_tipo_discapacidad"
            llenaTabla(cadena, tbData)
            Return tbData
        End Function

        Public Sub FillComboTipoDiscapacidad(ByRef cmb As ComboBox, Optional blank As Boolean = True)
            Dim tb As DataTable = Me.GetTipoDiscapacidad
            If blank Then
                tb.Rows.Add(0, "")
            End If
            If Not tb Is Nothing Then

                cmb.DisplayMember = "nombre"
                cmb.ValueMember = "id_tipo_discapacidad"
                cmb.DataSource = tb
            End If

        End Sub

        Public Function GetEmpleadoSueldo(ByVal empresa As Int16, empleado As Int32, contrato As Short) As Decimal
            dpara.Clear()
            dpara("empresa") = empresa
            dpara("empleado") = empleado
            dpara("contrato") = contrato
            Dim valor As Decimal = 0
            cadena = $"select sum(valor)
                      from sueldos
                      where a.empresa = @empresa And contrato=@contrato and empleado=@empleado "
            valor = BuscaEscalar(cadena, ListaParametros(dpara))
            Return valor
        End Function


    End Class



End Namespace


