Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmListadoPermisos_Requi
    Dim lpara As New Dictionary(Of String, Object)
    Dim cadena As String = ""
    Dim tbDatos As New DataTable
    'Dim r As New CryListadoPermisosRequi
    Dim r As ReportClass
    Dim nomempresa As String
    Private Sub frmListadoPermisos_Requi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lpara("empresa") = empresa
        Me.crv.RefreshReport()
        CtrlBusqEmp.id_empresa = empresa
        ctrlBusqJefe.id_empresa = empresa
        cadena = "select nombre from empresas where empresa=@empresa"
        nomempresa = BuscaEscalar(cadena, ListaParametros(lpara))
        limpiar()
    End Sub



    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = CtrlBusqEmp.Empleado 'txtEmpleado.Text
        lpara("jefe") = ctrlBusqJefe.Empleado

        Select Case cmbTipo.SelectedIndex
            Case 1
                cadena = "select LL.id, LL.empleado, LL.nombre_empleado, LL.jefe, LL.nombre_jefe1, LL.jefe2, j2.apellido1 + ' ' + j2.apellido2 + ' ' + j2.nombre1 + ' ' + j2.nombre2 as nombre_jefe2  from (
                    select a.id, a.empleado,  b.apellido1 + ' ' + b.apellido2 + ' ' + b.nombre1 + ' ' + b.nombre2 as nombre_empleado,
                    a.jefe ,c.apellido1 + ' ' + c.apellido2 + ' ' + c.nombre1 + ' ' + c.nombre2 as nombre_jefe1,
                    (select MAX(jefe) from requisicion_autorizacion a1 where a1.id_padre=a.id and a1.empresa=a.empresa) as jefe2,a.empresa
	                    from requisicion_autorizacion a
	                    inner join emplegen b on a.empleado=b.empleado and a.empresa=b.empresa
	                    inner join emplegen c on a.jefe=c.empleado and a.empresa=c.empresa
	                    where  a.id_padre =0 and a.empresa=@empresa and b.empleado in  (select empleado from contratos1 c where c.empresa=b.empresa and c.empleado=a.empleado and c.estado in (0,4))
	                    ) as LL left join emplegen j2 ON LL.jefe2=j2.empleado AND j2.empresa=LL.empresa where 1=1 " ', emplegen j2 where LL.jefe2=j2.empleado "

                If CtrlBusqEmp.Empleado > 0 Then
                    cadena = cadena & " and ll.empleado=@empleado"
                End If
                r = New CryListadoPermisosRequi
            Case 2

                cadena = "WITH autorizador(id,id_padre,empleado,jefe,nivel,empresa)
                          AS( SELECT id,0 AS id_padre,empleado,jefe,1 as nivel,empresa FROM requisicion_autorizacion WHERE id_padre =0 
                          UNION ALL 
                          SELECT a.id,a.id_padre,a.empleado,a.jefe,2 as nivel,a.empresa FROM requisicion_autorizacion a
                          INNER JOIN autorizador b  ON a.id_padre = b.id 
                          ) 
                          SELECT b.id,b.id_padre,b.empleado,isnull(d.nombre1,'')+' '+isnull(d.nombre2,'')+' '+isnull(d.apellido1,'')+' '+isnull(d.apellido2,'') as nombremple,
                          b.jefe,isnull(c.nombre1,'')+' '+isnull(c.nombre2,'')+' '+isnull(c.apellido1,'')+' '+isnull(c.apellido2,'') as nombrejefe,nivel,e.contrato
                          FROM autorizador b
                          left join emplegen c on b.jefe=c.empleado and c.empresa=b.empresa
                          left join emplegen d on b.empleado=d.empleado and d.empresa=b.empresa
                          inner join (select max(contrato) as contrato, empleado,empresa,estado from contratos1 where estado in (0,2) group by empleado,empresa,estado) e on e.empleado=b.empleado and c.empresa=e.empresa 
                          where e.estado in (0,4) and b.empresa=@empresa"
                If CtrlBusqEmp.Empleado > 0 Then
                    cadena = cadena & " and b.empleado=@empleado"
                End If
                If ctrlBusqJefe.Empleado > 0 Then
                    cadena = cadena & " and b.jefe=@jefe"
                End If
                If cmbNiveles.SelectedIndex >= 0 Then
                    lpara("nivel") = cmbNiveles.SelectedIndex + 1
                    cadena = cadena & " and b.nivel=@nivel"
                End If
                cadena = cadena + " order by b.empleado"
                r = New CryReportexPermisosxNiveles
            Case Else
                MsgBox("seleccione un tipo de reporte", MsgBoxStyle.Information, "Mensaje del Sistema")
                Return
        End Select

        'cadena = cadena & " order by LL.nombre_empleado"


        If llenaTabla(cadena, tbDatos, ListaParametros(lpara)) > 0 Then

            r.SetDataSource(tbDatos)
            r.SetParameterValue("nomempresa", nomempresa)

            crv.ReportSource = r

            crv.Refresh()
        Else
            MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
            limpiar()
        End If
    End Sub

    Sub limpiar()
        CtrlBusqEmp.EraserForm()
        ctrlBusqJefe.EraserForm()
        crv.ReportSource = Nothing
        gbNivelPermiso.Visible = False
        gbJefe.Visible = False
        cmbTipo.SelectedIndex = 0
        cmbNiveles.SelectedIndex = -1
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        If cmbTipo.SelectedIndex = 2 Then
            gbNivelPermiso.Visible = True
            gbJefe.Visible = True
        Else
            gbNivelPermiso.Visible = False
            gbJefe.Visible = False
            ctrlBusqJefe.EraserForm()
            cmbNiveles.SelectedIndex = -1

        End If
    End Sub
End Class