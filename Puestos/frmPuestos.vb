Imports System.ComponentModel
Imports NOMINA.dsJavierTableAdapters
Imports NOMINA.dsJavier
Imports System.Data
Imports System.Linq

Public Class frmPuestos

    Dim tbcargosmin As New DataTable
    Dim tbtitulos1 As New DataTable
    Dim tbtitulos2 As New DataTable
    Dim tbpuestosper As New DataTable
    Dim cadena As String = ""
    Dim lpara As New Dictionary(Of String, Object)
    Dim filadet As DataRow
    Dim op As Short = 0
    Dim puesto As Short
    Private _mod As Boolean = False

    Private _fila As puestosperRow
    Private Sub frmPuestos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lpara.Clear()
        lpara("empresa") = empresa

        cadena = "select codigo,ocupacion from cargosministeriales"
        llenaTabla(cadena, tbcargosmin)
        cadena = "SELECT   titulo, nombre, operable, ciuo
                  FROM titulos WHERE operable = 'S'  ORDER BY nombre"
        llenaTabla(cadena, tbtitulos1)
        llenaTabla(cadena, tbtitulos2)

        llenaTabla(cadena, tbpuestosper, ListaParametros(lpara))
        cmbcargo.DataSource = tbcargosmin

        Dim fil As DataRow = tbcargosmin.NewRow
        fil.Item("codigo") = 0
        fil.Item("ocupacion") = ""
        cmbcargo.DisplayMember = "ocupacion"
        cmbcargo.ValueMember = "codigo"

        Dim fil2 As DataRow = tbtitulos1.NewRow
        fil2.Item("titulo") = 0
        fil2.Item("nombre") = ""
        cmbTitulo.DataSource = tbtitulos1
        cmbTitulo.DisplayMember = "nombre"
        cmbTitulo.ValueMember = "titulo"
        limpiar()
        refrescar_dgv()


    End Sub
    Sub limpiar()
        cmbcargo.SelectedValue = 0
        cmbTitulo.SelectedValue = 0
        TextNombre.Clear()
        TextObservaciones.Clear()
        textPuesto.Clear()
        op = 0
        btnAgregar.Text = "Agregar"
        btnAgregar.ImageIndex = 9


    End Sub
    Private Sub VistaGrid(ByVal dgVista As DataGridView)
        With dgVista
            .Columns("empresa").Visible = False
            .Columns("nivel").Visible = False
            .Columns("puesto").HeaderText = "Puesto"
            .Columns("puesto").FillWeight = 10
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").FillWeight = 25
            .Columns("cargo").HeaderText = "Cargo"
            .Columns("cargo").FillWeight = 10
            .Columns("titulo").HeaderText = "Titulo"
            .Columns("titulo").FillWeight = 10
            .Columns("extras").HeaderText = "Extras"
            .Columns("extras").FillWeight = 10
            .Columns("buses").HeaderText = "Buses"
            .Columns("buses").FillWeight = 10
            .Columns("observa").HeaderText = "Observación"
            .Columns("observa").FillWeight = 25

        End With
    End Sub



    Sub refrescar_dgv()
        lpara("empresa") = empresa
        cadena = "SELECT empresa, puesto, nombre, cargo, nivel, titulo, extras, buses, observa
                  FROM puestosper WHERE empresa =@empresa ORDER BY empresa, puesto desc"
        llenaTabla(cadena, tbpuestosper, ListaParametros(lpara))
        tbpuestosper.DefaultView.Sort = "puesto DESC"
        dgvDatos.DataSource = tbpuestosper
        VistaGrid(dgvDatos)
        If (dgvDatos.Rows.Count > 0) Then

            dgvDatos.FirstDisplayedScrollingRowIndex = 0
            dgvDatos.CurrentCell = dgvDatos.Rows(0).Cells(1)


        End If

    End Sub

    Private Sub clean_form()
        _mod = False
        textPuesto.Clear()
        TextNombre.Clear()
        TextObservaciones.Clear()
        textPuesto.Clear()
        btnAgregar.Text = "Agregar"
    End Sub

    Private Sub dgvCodigo_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDatos.DataError
        MsgBox("Error en el ingreso de información", MsgBoxStyle.Critical, "Mensaje del Sistema")
        dgvDatos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = DBNull.Value
        e.Cancel = False
    End Sub

    Private Sub frmPuestos_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        dgvDatos.Columns.Clear()
        dgvDatos.DataSource = Nothing
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If validaError(TextNombre, ep1) AndAlso validaError(cmbcargo, ep1) AndAlso validaError(cmbTitulo, ep1) AndAlso validetError(cmbcargo, ep1) Then
                lpara.Clear()
                lpara("empresa") = empresa
                lpara("nombre") = TextNombre.Text
                lpara("titulo") = cmbTitulo.SelectedValue
                lpara("cargo") = cmbcargo.SelectedValue
                lpara("observa") = TextObservaciones.Text
                If op = 0 Then
                    puesto = BuscaEscalar("select max(puesto)+1 from puestosper where empresa=@empresa", ListaParametros(lpara))
                    lpara("puesto") = puesto

                    cadena = "insert into puestosper(empresa,puesto,nombre,cargo,nivel,titulo,extras,buses,observa) values
                      (@empresa,@puesto,@nombre,@cargo,5,@titulo,'N','N',@observa)"
                    EjecutarQuery(cadena, ListaParametros(lpara))

                Else
                    lpara("puesto") = textPuesto.Text
                    cadena = "update puestosper set nombre=@nombre,titulo=@titulo,cargo=@cargo,observa=@observa where puesto=@puesto and empresa=@empresa"
                    EjecutarQuery(cadena, ListaParametros(lpara))

                End If

            End If
            refrescar_dgv()
            limpiar()

        Catch ex As Exception
            MsgBox("Error:" & ex.Message)
            Return
        End Try

    End Sub

    Private Sub mnuEliminar_Click(sender As Object, e As EventArgs) Handles mnuEliminar.Click
        Try
            If dgvDatos.SelectedRows.Count > 0 Then
                filadet = CType(dgvDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
                lpara("empresa") = empresa
                lpara("puesto") = CShort(filadet("puesto"))
                cadena = "delete puestosper where puesto=@puesto and empresa=@empresa"
                EjecutarQuery(cadena, ListaParametros(lpara))
                refrescar_dgv()
                limpiar()
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Information, "Mensaje del sistema")
            Return
        End Try
    End Sub

    Private Sub mnuModificar_Click(sender As Object, e As EventArgs) Handles mnuModificar.Click
        If dgvDatos.SelectedRows.Count > 0 Then
            op = 1
            filadet = CType(dgvDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            TextObservaciones.Text = filadet("observa")
            cmbTitulo.SelectedValue = filadet("titulo")
            cmbcargo.SelectedValue = filadet("cargo")
            TextNombre.Text = filadet("nombre")
            textPuesto.Text = filadet("puesto")
            btnAgregar.Text = "Modificar"
            btnAgregar.ImageIndex = 10

        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

End Class