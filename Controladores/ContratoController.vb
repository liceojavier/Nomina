
Imports System.Data

Public Class ContratoController

    Dim cadena As String = ""
    Dim dpara As New Dictionary(Of String, Object)

    Sub New()

    End Sub


    Public Function GetEmpleado(ByVal empresa As Int16, ByVal empleado As Int32) As DataTable
        Return Nothing
    End Function


    Public Function GetJornadas() As DataTable
        dpara.Clear()
        Dim tbData As New DataTable()
        cadena = "select jornada, nombre from contratos_jornada a
                 order by jornada"
        llenaTabla(cadena, tbData)
        Return tbData

    End Function

    Public Function GetTiposContratos() As DataTable
        dpara.Clear()
        Dim tbData As New DataTable()
        cadena = "select id_tipo_contrato, nombre from contratos_tipo a order by id_tipo_contrato"
        llenaTabla(cadena, tbData)
        Return tbData

    End Function

    Public Function GetTemporalidad() As DataTable
        dpara.Clear()
        Dim tbData As New DataTable()
        cadena = "select id_temporalidad, nombre from contratos_temporalidad a order by id_temporalidad"
        llenaTabla(cadena, tbData)
        Return tbData

    End Function

    Public Sub FillComboJornada(ByRef cmb As ComboBox, Optional blank As Boolean = True)
        Dim tb As DataTable = Me.GetJornadas()
        If blank Then
            Dim fila As DataRow = tb.NewRow()
            fila("jornada") = 0
            fila("nombre") = ""
            tb.Rows.Add(fila)
        End If
        If Not tb Is Nothing Then
            cmb.DataSource = tb
            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "jornada"
        End If

    End Sub

    Public Sub FillComboTipoContrato(ByRef cmb As ComboBox, Optional blank As Boolean = True)
        Dim tb As DataTable = Me.GetTiposContratos()
        If blank Then
            Dim fila As DataRow = tb.NewRow()
            fila("id_tipo_contrato") = 0
            fila("nombre") = ""
            tb.Rows.Add(fila)
        End If
        If Not tb Is Nothing Then
            cmb.DataSource = tb
            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "id_tipo_contrato"
        End If

    End Sub

    Public Sub FillComboTemporalidad(ByRef cmb As ComboBox, Optional blank As Boolean = True)
        Dim tb As DataTable = Me.GetTemporalidad()
        If blank Then
            Dim fila As DataRow = tb.NewRow()
            fila("id_temporalidad") = 0
            fila("nombre") = ""
            tb.Rows.Add(fila)
        End If
        If Not tb Is Nothing Then
            cmb.DataSource = tb
            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "id_temporalidad"
        End If

    End Sub

    Public Function GetViewSueldos(ByVal empleado As Int32, empresa As Short) As DataTable
        Dim tbData As New DataTable
        dpara.Clear()
        dpara("empleado") = empleado
        dpara("empresa") = empresa
        cadena = "select id_sueldo,empresa,empleado,contrato,transac,afecta,valor,fechae from sueldos where empleado=@empleado and empresa=@empresa"
        llenaTabla(cadena, tbData, ListaParametros(dpara))

        Return tbData
    End Function
    Public Function GetSueldosbyEmpleado(empleado As Int32, contrato As Short, empresa As Short) As DataTable
        dpara.Clear()
        dpara("empleado") = empleado
        dpara("empresa") = empresa
        dpara("contrato") = contrato
        Dim tbData As New DataTable()
        cadena = "Select id_sueldo,empleado, empresa, transac, afecta, valor, fechae from sueldos where empleado=@empleado and contrato=@contrato and empresa=@empresa order by transac"
        llenaTabla(cadena, tbData, ListaParametros(dpara))
        Return tbData
    End Function


    Public Function GetSueldos(empleado As Int32, transac As Short, empresa As Short) As DataTable
        dpara.Clear()
        dpara("empleado") = empleado
        dpara("transac") = transac
        dpara("empresa") = empresa
        Dim tbData As New DataTable()
        cadena = "Select id_sueldo,empleado, empresa, transac, afecta, valor, fechae from sueldos where empleado=@empleado and 
                  empresa=@empresa and transac=@transac order by transac"
        llenaTabla(cadena, tbData, ListaParametros(dpara))
        Return tbData
    End Function

    Public Function GetContratoInfo(ByVal empresa As Int16, ByVal empleado As Int32, contrato As Short) As DataTable
        dpara.Clear()
        dpara("empresa") = empresa
        dpara("empleado") = empleado
        dpara("contrato") = contrato
        Dim tbData As New DataTable()
        cadena = "SELECT a.[empresa],a.[empleado],[contrato],[fecha],[tiposeguro],a.[tipoper],a.[puesto],[mpago],[anticipo],[fpago]
                  ,[cuentaban],[fechai],[fechaf],[base],[jornada],[horaini],[horafin],[horas],[semanahoras]
                  ,a.[observa],a.[estado],[fechae],[tipoempleado],[id_tipo_contrato], d.cantvaca, d.basevaca
                  ,[id_temporalidad],  b.nombre as nombre_puesto, c.nombre as nombre_estado
              FROM [dbo].[contratos1] a
              inner join puestosper b on a.puesto=b.puesto and a.empresa=b.empresa
              inner join empestados c on a.empresa=c.empresa and a.estado=c.estado
              inner join tipopersonal d on a.empresa=d.empresa and a.tipoper=d.tipoper
            where a.empresa=@empresa and a.empleado=@empleado and a.contrato=@contrato order by a.empleado"
        llenaTabla(cadena, tbData, ListaParametros(dpara))
        Return tbData
    End Function

End Class
