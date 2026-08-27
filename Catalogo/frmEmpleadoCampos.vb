Public Class frmEmpleadoCampos
    Private tbDatos, tbTipo As New DataTable
    Private IdCampo As Integer = 0
    Public cadena As String = ""
    Dim lpara As New Dictionary(Of String, Object)
    Private Sub frmEmpleadoCampos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cadena = "select nombre,tipo_campo from emplegen_campos_tipo order by tipo_campo"
        llenaTabla(cadena, tbTipo)
        Dim nfila As DataRow = tbTipo.NewRow
        nfila("tipo_campo") = ""
        nfila("nombre") = ""
        tbTipo.Rows.InsertAt(nfila, 0)
        cmbTipoCampo.DisplayMember = "nombre"
        cmbTipoCampo.ValueMember = "tipo_campo"
        cmbTipoCampo.DataSource = tbTipo

        CargarDatos()
        Limpiar()
    End Sub

    Private Sub CargarDatos()

        tbDatos.Clear()

        llenaTabla("SELECT id_campo,nombre_campo,titulo_campo,longitud,tipo_campo,activo,origenlista,valordefecto FROM emplegen_campos ORDER BY id_campo", tbDatos)

        dgvCampos.DataSource = tbDatos

        dgvCampos.Columns("id_campo").Visible = False

    End Sub

    Private Sub Limpiar()

        IdCampo = 0

        txtNombreCampo.Text = ""
        txtTituloCampo.Text = ""
        chkActivo.Checked = True
        txtLongitud.Text = "0"
        TxtOrigen.Text = ""
        txtDefecto.Text = ""

        txtNombreCampo.Focus()

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        Limpiar()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not validetError(cmbTipoCampo, ep1) Then
            MsgBox("Debe Seleccionar el Tipo de Dato", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        If txtNombreCampo.Text.Trim = "" Then

            MessageBox.Show("Debe ingresar el nombre del campo.")

            Exit Sub

        End If

        lpara.Clear()
        lpara("nombre") = txtNombreCampo.Text.Replace("'", "''")
        lpara("titulo") = txtTituloCampo.Text.Replace("'", "''")
        lpara("longitud") = txtLongitud.text.Replace("'", "''")
        lpara("tipo") = cmbTipoCampo.SelectedValue
        lpara("activo") = IIf(chkActivo.Checked, 1, 0)
        lpara("origen") = txtOrigen.text.Replace("'", "''")
        lpara("defecto") = txtDefecto.text.Replace("'", "''")
        lpara("id") = IdCampo
        lpara("empresa") = empresa


        If IdCampo = 0 Then

            cadena = "INSERT INTO emplegen_campos
                  (nombre_campo,titulo_campo,longitud,tipo_campo,activo,origenlista,valordefecto,empresa) 
                  VALUES (@nombre,@titulo,@longitud,@tipo,@activo,@origen,@defecto,@empresa)"

        Else

            cadena = "UPDATE emplegen_campos SET nombre_campo=@nombre,titulo_campo=@titulo,Activo=@activo WHERE id_campo=@id"

        End If

        EjecutarQuery(cadena, ListaParametros(lpara))

        CargarDatos()

        Limpiar()

    End Sub

    Private Sub dgvCampos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCampos.CellClick
        If e.RowIndex < 0 Then Exit Sub

        IdCampo = dgvCampos.Rows(e.RowIndex).Cells("id_campo").Value
        txtNombreCampo.Text = dgvCampos.Rows(e.RowIndex).Cells("nombre_campo").Value.ToString()
        txtTituloCampo.Text = dgvCampos.Rows(e.RowIndex).Cells("titulo_campo").Value.ToString()
        txtLongitud.Text = dgvCampos.Rows(e.RowIndex).Cells("longitud").Value.ToString()
        cmbTipoCampo.SelectedValue = dgvCampos.Rows(e.RowIndex).Cells("tipo_campo").Value.ToString()
        chkActivo.Checked = dgvCampos.Rows(e.RowIndex).Cells("activo").Value
        TxtOrigen.Text = dgvCampos.Rows(e.RowIndex).Cells("origenlista").Value.ToString()
        txtDefecto.Text = dgvCampos.Rows(e.RowIndex).Cells("valordefecto").Value.ToString()

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If IdCampo = 0 Then
            MsgBox("Seleccione un campo a eliminar", MsgBoxStyle.Information, "Mensaje del sistema")
            Exit Sub
        End If


        If MessageBox.Show("¿Desea eliminar este campo?",
                           "Confirmar",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        EjecutarQuery("DELETE FROM emplegen_campos WHERE id_campo=" & IdCampo)

        CargarDatos()

        Limpiar()

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub txtLongitud_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLongitud.KeyPress
        If Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


End Class