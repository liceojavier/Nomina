Public Class frm_Emp_doctos_actualizdos
    Dim cadena As String = ""
    Dim tbDatos As New DataTable("datos")
    Dim v As New Listado_emp_doc_actualizados

    Private Sub frm_Emp_doctos_actualizdos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        busqEmpleado.id_empresa = empresa
        Dim tbtipodoc As New DataTable()

        cadena = "select id_tipo,nombre from emplegen_documento_tipo"
        llenaTabla(cadena, tbtipodoc)
        Dim nfila = tbtipodoc.NewRow
        nfila("id_tipo") = -1
        nfila("nombre") = ""
        cmbTipodoc.DataSource = tbtipodoc
        tbtipodoc.Rows.InsertAt(nfila, 0)
        cmbTipodoc.DisplayMember = "Nombre"
        cmbTipodoc.ValueMember = "Id_tipo"
        cmbTipodoc.SelectedIndex = -1

    End Sub

    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click

        Dim lpara As New Dictionary(Of String, Object)

        lpara("empresa") = empresa


        cadena = "SELECT
                        ROW_NUMBER() OVER (ORDER BY b.apellido1, b.apellido2, b.nombre1) AS Correlativo,
                        b.empleado,b.apellido1+' '+b.apellido2+' '+b.nombre1+' '+b.nombre2+' '+b.nombre3 AS NombreCompleto,
                        d.nombre as tipo,count(d.nombre) as total_doctos
                        
                    FROM emplegen_documentos a
                    INNER JOIN emplegen b ON a.empleado=b.empleado AND a.empresa=b.empresa
                    INNER JOIN emplegen_documento_tipo d ON a.tipo=d.id_tipo
                    WHERE a.empresa=@empresa"

        If busqEmpleado.Empleado > 0 Then
            lpara("empleado") = busqEmpleado.Empleado
            cadena = cadena + " and a.empleado=@empleado"
        End If

        If cmbTipodoc.Text <> "" Then
            lpara("tipo") = cmbTipodoc.SelectedValue
            cadena = cadena + " and a.tipo=@tipo"
        End If

        If dpfechaf.Value.Date >= dpfechai.Value.Date Then
            lpara("fechai") = dpfechai.Value.Date
            lpara("fechaf") = dpfechaf.Value.Date
            cadena = cadena + " and a.fecha_upload between @fechai and @fechaf"
        Else
            MsgBox("la fecha inicial debe ser menor que la fecha final", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If

        cadena = cadena + " group by b.empleado,nombre1,nombre2,nombre3,apellido1,apellido2,d.nombre"

        If llenaTabla(cadena, tbDatos, ListaParametros(lpara)) > 0 Then

            v.SetDataSource(tbDatos)
            v.SetParameterValue("fechai", dpfechai.Value.Date)
            v.SetParameterValue("fechaf", dpfechaf.Value.Date)

            crv.ReportSource = v
            crv.Refresh()
        Else
            MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
    Private Sub limpiar()
        busqEmpleado.EraserForm()
        cmbTipodoc.SelectedIndex = -1
        dpfechai.Value = Now.Date
        dpfechaf.Value = Now.Date
        crv.ReportSource = Nothing
    End Sub
End Class