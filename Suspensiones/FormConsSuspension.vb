'Imports planillas.DsVistasTableAdapters
'Imports planillas.DsVistas
Imports ControllersERP.Nominas

Public Class formConsSuspension
    Dim tbDatos As New DataTable
    Dim fila As DataRow
    Dim cadena As String = ""
    Dim lpara As New Dictionary(Of String, Object)
    Dim tbContratos As New DataTable()
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim filaTemp As DataRow
    Dim ctrSusp As New SuspensionController()

    Dim consulta As String = "SELECT a.id_suspension, a.empresa, a.numero, a.empleado, a.contrato, f.apellido1 + ' ' + f.apellido2 + ' ' + f.nombre1 + ' ' + f.nombre2 AS nombre_empleado, 
                              a.tiposus, c.nombre AS nombre_tipo, a.fechai, 
                              a.fechaf, a.cantidad, a.valor, a.observa, b.estado, b.nombre AS nombre_estado, a.fechae, a.usuario, a.grado, a.tipoal
                              FROM   suspensiones AS a INNER JOIN
                              suspensiones_estado AS b ON a.estado = b.estado INNER JOIN
                              tiposuspensiones AS c ON a.tiposus = c.tiposus INNER JOIN
                              emplegen AS f ON f.empleado = a.empleado
                              WHERE  a.empresa = @empresa"





    Private Sub define_vistadgv(ByRef dgv As DataGridView)
        With dgv
            .Columns("empresa").Visible = False
            .Columns("id_suspension").Visible = False
            .Columns("tiposus").Visible = False
            .Columns("estado").Visible = False
            .Columns("fechae").Visible = False
            .Columns("usuario").Visible = False
            .Columns("contrato").Visible = False
            .Columns("tipoal").Visible = False
            .Columns("grado").Visible = False
            .Columns("numero").HeaderText = "Número"
            .Columns("numero").FillWeight = 8
            .Columns("empleado").HeaderText = "Código"
            .Columns("empleado").FillWeight = 8
            .Columns("nombre_empleado").HeaderText = "Empleado"
            .Columns("nombre_empleado").FillWeight = 20
            .Columns("fechai").HeaderText = "Fecha I."
            .Columns("fechai").FillWeight = 8
            .Columns("fechaf").HeaderText = "Fecha F."
            .Columns("fechaf").FillWeight = 8
            .Columns("observa").HeaderText = "Observa"
            .Columns("observa").FillWeight = 20
            .Columns("cantidad").HeaderText = "Cantidad"
            .Columns("cantidad").FillWeight = 5
            .Columns("valor").HeaderText = "Valor"
            .Columns("valor").FillWeight = 7
            .Columns("valor").DefaultCellStyle.Format = "N2"
            .Columns("nombre_tipo").HeaderText = "Tipo"
            .Columns("nombre_tipo").FillWeight = 8
            .Columns("nombre_estado").HeaderText = "Estado"
            .Columns("nombre_estado").FillWeight = 8
        End With

    End Sub



    Private Sub FormConsultaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ctrSusp.FillComboTipoSuspension(cmbTipo, True)
        ctrSusp.FillComboEstado(cmbEstado, True)
        busqEmpleado.id_empresa = empresa

        limpia_forma()
    End Sub

    Private Sub limpia_forma()
        borra_Mejorado(pnInfo, ep1)
        'busqEmpleado.Clear()
        busqEmpleado.EraserForm()
        axFechaI.reiniciaControl()

        bsData.Filter = ""
    End Sub

    Private Sub tsbLimpiar_Click(sender As Object, e As EventArgs)
        limpia_forma()
    End Sub

    Private Sub DarDeAltaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ctxAlta.Click
        If dgvDatosConsulta.SelectedRows.Count > 0 Then
            Dim dr = CType(dgvDatosConsulta.SelectedRows(0).DataBoundItem, DataRowView).Row
            If dr("estado") <> 0 Then
                MsgBox($"No se puede dar de alta a la fila número {dr("numero")}")
            Else
                Dim fAlta As New FormAltaSuspension()
                fAlta.Inicializa(dr("id_suspension"), dr("empleado"), dr("contrato"), dr("fechai"), dr("numero"), dr("nombre_empleado"), dr)
                fAlta.TopLevel = True
                fAlta.ShowDialog()

            End If

        End If
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ctxAnular.Click
        If dgvDatosConsulta.SelectedRows.Count > 0 Then
            'Dim dr As ViewSuspensionesRow = CType(dgvDatosConsulta.SelectedRows(0).DataBoundItem, DataRowView).Row
            fila = CType(dgvDatosConsulta.SelectedRows(0).DataBoundItem, DataRowView).Row
            If fila("id_estado") <> 0 Then
                MsgBox($"No se puede anular la suspensión número {fila("numero")} ")
            Else
                If (ctrSusp.SetEstado(fila("id_suspension"), 1, Now, _usuario)) Then
                    MsgBox("Operación realizada con éxito")
                    fila("id_estado") = 1
                    fila("nombre_estado") = "Anulado"
                End If


            End If
        End If
    End Sub

    Private Sub dgvDatosConsulta_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatosConsulta.DoubleClick
        If dgvDatosConsulta.SelectedRows.Count > 0 Then
            fila = CType(dgvDatosConsulta.SelectedRows(0).DataBoundItem, DataRowView).Row
            llama_forma(fila("id_suspension"), fila)
        End If
    End Sub

    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs)
        llama_forma(0, Nothing)
    End Sub

    Private Sub llama_forma(id As Int32, dr As DataRow)
        Dim frm As New FormIngresoSuspension
        frm.id_suspension = id
        If (Not dr Is Nothing) Then
            frm.drMaestro = dr
        End If
        frm.NuevoSuspension = False
        frm.TopLevel = True
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
    End Sub

    Private Sub GeneraLicenciaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ctxDeshacerAlta_Click(sender As Object, e As EventArgs) Handles ctxDeshacerAlta.Click
        If dgvDatosConsulta.SelectedRows.Count > 0 Then
            fila = CType(dgvDatosConsulta.SelectedRows(0).DataBoundItem, DataRowView).Row
            If fila("estado") <> 2 Then
                MsgBox($"No se puede deshacer el alta número {fila("numero")} porque su estado no está en alta")
            Else
                If (ctrSusp.AnularAlta(fila("id_suspension"), _usuario)) Then
                    MsgBox("Operación realizada con éxito")
                    fila("cantidad") = 0 'dr.cantidad = 0
                    fila("valor") = 0 'dr.valor = 0
                    fila("fechaf") = New DateTime(1900, 1, 1)  'dr.fechaf = New DateTime(1900, 1, 1)
                    fila("estado") = 0 'dr.id_estado = 0
                    fila("nombre_estado") = "Activo" 'dr.nombre_estado = "Activo"
                End If


            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpia_forma()
        dgvDatosConsulta.DataSource = Nothing
    End Sub

    Private Sub btnNueva_Click(sender As Object, e As EventArgs) 
        llama_forma(0, Nothing)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim filtro As String = " "
        lpara("empresa") = empresa

        If busqEmpleado.Empleado > 0 Then
            lpara("empleado") = busqEmpleado.Empleado
            filtro += " and f.empleado = @empleado"
        End If
        Dim numero As Int32 = 0
        If (Int32.TryParse(txtNumero.Text, numero)) Then
            lpara("numero") = numero
            filtro += " and a.numero = @numero"
        End If

        If (cmbTipo.Text <> "") Then
            lpara("tiposus") = empresa
            filtro += " and a.tiposus = @tiposus"
        End If

        If (cmbEstado.Text <> "") Then
            lpara("estado") = cmbEstado.SelectedValue
            filtro += "  and a.estado = @estado"
        End If

        Dim fechaFiltro As String = ""
        filtro = axFechaI.devuelveConsulta(filtro)
        'filtro += " and a.fechai between '01/01/2025' and '24/04/2025'"

        cadena = consulta + filtro
        cadena += " order by a.numero asc"

        llenaTabla(cadena, tbDatos, ListaParametros(lpara))
        dgvDatosConsulta.DataSource = tbDatos
        define_vistadgv(dgvDatosConsulta)

        'bsData.Filter = filtro

    End Sub

    Private Sub btnContrato_Click(sender As Object, e As EventArgs) Handles btnContrato.Click
        Dim lpara As New Dictionary(Of String, Object)

        lpara.Clear()
        Dim Num As Int16
        If busqEmpleado.Empleado > 0 Then
            lpara("empresa") = empresa
            lpara("empleado") = busqEmpleado.Empleado 'textEmpleado.Text
            cadena = "select contrato, pu.nombre " &
                     "from contratos1 c1 " &
                     "inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                     "where e.activo='S' and c1.empresa=@empresa and empleado=@empleado"
            Num = llenaTabla(cadena, tbContratos, ListaParametros(lpara))
            If Num = 1 Then
                TextConxContrato.Text = tbContratos.Rows(0).Item(0)
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 0)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContrato
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()
                cmbTipo.Focus()

            ElseIf Num = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            MsgBox("INGRESO PRIMERO EL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub
    Private Sub ActualizacionDatosContrato(ByVal sender As Object, ByVal e As clsActValorREvento)
        filaTemp = tbContratos.Rows(e.va2)
        TextConxContrato.Text() = filaTemp.Item(0)
        ExistenciaSusp()
    End Sub
    Private Sub ExistenciaSusp()
        Dim lpara As New Dictionary(Of String, Object)
        lpara("empresa") = empresa
        lpara("empleado") = busqEmpleado.Empleado
        lpara("contrato") = TextConxContrato.Text
        If BuscaEscalar("select count(*) from suspensiones where empresa=@empresa and empleado=@empleado and contrato=@contrato and estado=0", ListaParametros(lpara)) > 0 Then
            MsgBox("ESTE EMPLEADO TIENE SUSPENSION ACTIVA", MsgBoxStyle.Information, "Mensaje del Sistema")
            TextConxContrato.Clear()
        Else
            cmbTipo.Focus()
        End If
    End Sub
End Class