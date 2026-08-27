Public Class frmReportePrestamos
    Dim lpara As New Dictionary(Of String, Object)
    Dim cadena As String = ""
    Dim tbDatos As New DataTable
    Dim r As New CryListadoPrestamos
    Dim s As New CryListadoPestamosDetalle




    Private Sub frmReportePrestamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lpara("empresa") = empresa
        Me.crv.RefreshReport()
        rdPrestamo.Checked = True
        CtrlBusqEmp.id_empresa = empresa

        'Empleado.id_empresa = empresa
    End Sub

    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = CtrlBusqEmp.Empleado 'txtEmpleado.Text
        lpara("fechai") = dpFechai.Value
        lpara("fechaf") = dpFechaf.Value
        Dim valor As Int32 = 0

        If rdPrestamo.Checked = True Then
            cadena = "select a.empleado,a.contrato,a.prestamo,d.apellido1+' '+d.apellido2+' '+d.nombre1+' '+d.nombre2 as nomempleado,e.nombre as tipoprestamo,a.meses,a.mesini,a.observa, 
                  case a.estado when 1 then 'anulado' when 0 then 'activo' end as estado,
                  a.fecha,sum(cargos-abonos) as saldo from prestamos1 a
                  inner join prestamos2 b on a.prestamo=b.prestamo and a.empresa=b.empresa
                  inner join contratos1 c on a.empleado=c.empleado and a.empresa=c.empresa and a.contrato=c.contrato
                  inner join emplegen d on a.empleado=d.empleado and a.empresa=d.empresa
                  inner join tiposprestamo e on a.tipopre=e.tipopre and a.empresa=e.empresa where 1=1"
        Else

            cadena = "select a.empleado,a.contrato,a.prestamo,d.apellido1+' '+d.apellido2+' '+d.nombre1+' '+d.nombre2 as nomempleado,e.nombre as tipoprestamo,a.meses,a.mesini,a.observa, 
                      case a.estado when 1 then 'anulado' when 0 then 'activo' end as estado,a.fecha,b.año,b.mes,b.cargos,b.abonos
                      from prestamos1 a
                      inner join prestamos2 b on a.prestamo=b.prestamo and a.empresa=b.empresa
                      inner join contratos1 c on a.empleado=c.empleado and a.empresa=c.empresa and a.contrato=c.contrato
                      inner join emplegen d on a.empleado=d.empleado and a.empresa=d.empresa
                      inner join tiposprestamo e on a.tipopre=e.tipopre and a.empresa=e.empresa where 1=1"
        End If


        If CtrlBusqEmp.Empleado > 0 Then
            cadena = cadena & " and a.empleado=" & CtrlBusqEmp.Empleado
        End If
        If txtPrestamo.Text <> "" Then
            cadena = cadena & " and a.prestamo=" & txtPrestamo.Text
        End If
        If cmbEstado.SelectedIndex > 0 Then
            Select Case cmbEstado.SelectedIndex
                Case 1
                    cadena = cadena & " and a.estado=0"
                Case 2
                    cadena = cadena & " and a.estado=1"
            End Select

        End If
        If dpFechaf.Value > dpFechai.Value Then
            cadena = cadena & " and a.fecha between @fechai and @fechaf"

        End If

        cadena = cadena & " group by a.empleado,a.contrato,a.prestamo,d.nombre1,d.nombre2,d.apellido1,d.apellido2,e.nombre,a.meses,a.mesini,a.observa,a.estado,a.fecha"
        If rdPrestamoDet.Checked Then
            cadena = cadena & ",b.año,b.mes,b.cargos,b.abonos"
        End If

        If chksaldo.Checked And rdPrestamo.Checked Then
            cadena = cadena & " having sum(cargos-abonos)>0"
        End If
        cadena = cadena & " order by a.empleado,a.contrato,a.prestamo,d.apellido1,d.apellido2,d.nombre1,d.nombre2"
        If rdPrestamoDet.Checked Then
            cadena = cadena & ",b.año,b.mes,b.cargos desc,b.abonos asc"
        End If
        If llenaTabla(cadena, tbDatos, ListaParametros(lpara)) > 0 Then

            If rdPrestamo.Checked Then
                r.SetDataSource(tbDatos)
                crv.ReportSource = r
            Else
                s.SetDataSource(tbDatos)
                crv.ReportSource=s
            End If

            crv.Refresh()
        Else
            MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")

        End If
    End Sub

    Sub limpiar()
        dpFechai.Value = Now.Date
        dpFechaf.Value = Now.Date
        cmbEstado.SelectedIndex = 0
        rdPrestamo.Checked = True
        CtrlBusqEmp.EraserForm()
        chksaldo.Checked = False
        crv.ReportSource = Nothing
        txtPrestamo.Clear()

    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
End Class