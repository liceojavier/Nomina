Public Class frmCulturatipotest1
    Dim lpara As New Dictionary(Of String, Object)
    Dim NoEvaluacion As Integer = 0
    Dim esActualizar As Boolean = False
    Dim ciclo As Int32 = DateTime.Now.Year
    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns("ciclo").HeaderText = "Ciclo"
            .Columns("ciclo").ReadOnly = True
            .Columns("ciclo").FillWeight = 15
            .Columns("tipotest").HeaderText = "Número"
            .Columns("tipotest").FillWeight = 35
            .Columns("tipotest").ReadOnly = True
            .Columns("nombretest").HeaderText = "Evaluación"
            .Columns("nombretest").FillWeight = 70
            .Columns("nombretest").ReadOnly = True
            .Columns("congrado").HeaderText = "Con grado"
            .Columns("congrado").FillWeight = 30
            .Columns("congrado").ReadOnly = True
            .Columns("id_tipo").HeaderText = "id_tipo"
            'AltoGridView(18, tbFamiliares, 275, 836, dgVista)
        End With
    End Sub
    Private Sub frmTipoEvualuacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbGrado2.Enabled = False
        txtCiclo.Text = ciclo
        CargarDatos()
        ObtieneNumeroEvaluacion()
        LlenaComboNiveles()
        LlenaComboPara()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim cmodel As New cmodelo(_conexionSociograma)
        Dim cadena As String = ""
        Try

            lpara.Clear()

            If Not esActualizar Then
                cadena = "insert into sg_culturatipotest1 (ciclo, tipotest,nombretest,congrado,id_tipo,colegio,nivel,grado,para)
                               values(@ciclo,@tipotest,@nombretest,@congrado,@id_tipo,@colegio,@nivel,@grado,@para)"
            Else
                cadena = "update sg_culturatipotest1 set
                            ciclo=@ciclo,
                            tipotest=@tipotest,
                            nombretest=@nombretest,
                            congrado=@congrado,
                            id_tipo=@id_tipo,
                            colegio=@colegio,
                            nivel = @nivel,
                            grado = @grado,
                            para=@para
                          where ciclo=@ciclo and tipotest=@tipotest"
            End If

            lpara("ciclo") = txtCiclo.Text
            lpara("tipotest") = txtNumEvaluacion.Text
            lpara("nombretest") = txtNombreEvaluacion.Text
            lpara("congrado") = "S"
            lpara("id_tipo") = 3
            lpara("colegio") = "M"
            lpara("nivel") = cmbNivel.SelectedValue
            lpara("grado") = "" 'cmbGrado.SelectedValue
            lpara("para") = cmbGrado2.SelectedValue

            cmodel.EjecutarNonQuery(cadena, ListaParametros(lpara))

            If cmodel.Commit() Then
                MsgBox("Tipo de evaluación guardada correctamente.", MsgBoxStyle.Information, "Información del Sistema")
                CargarDatos()
                ObtieneNumeroEvaluacion()
                Limpiar()
                LlenaComboPara()
            End If
        Catch ex As Exception
            cmodel.RollBack()
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Información del Sistema")
        End Try
    End Sub

    Private Sub CargarDatos()
        Dim cmodel As New cmodelo(_conexionSociograma)
        Try
            Dim dt As New DataTable
            Dim cadena As String = "select ciclo, tipotest,nombretest,congrado,id_tipo from sg_culturatipotest1"
            cmodel.llenaTabla(cadena, dt)
            dgData.DataSource = dt
            Vista(dgData)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Información del Sistema")
        End Try
    End Sub

    Private Sub ObtieneNumeroEvaluacion()
        Dim cmodel As New cmodelo(_conexionSociograma)
        Try
            Dim cadena As String = "select max(tipotest + 1) from sg_culturatipotest1"
            NoEvaluacion = cmodel.BuscaEscalar(cadena)
            txtNumEvaluacion.Text = NoEvaluacion
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Información del Sistema")
        End Try
    End Sub
    Private Sub Limpiar()
        txtCiclo.Text = ciclo
        ObtieneNumeroEvaluacion()
        txtNombreEvaluacion.Text = ""
        esActualizar = False
    End Sub

    Private Sub mnuModificar_Click(sender As Object, e As EventArgs) Handles mnuModificar.Click
        If dgData.SelectedRows.Count > 0 Then
            esActualizar = True
            txtCiclo.Text = dgData.Item(0, dgData.SelectedRows(0).Index).Value
            txtNumEvaluacion.Text = dgData.Item(1, dgData.SelectedRows(0).Index).Value
            txtNombreEvaluacion.Text = dgData.Item(2, dgData.SelectedRows(0).Index).Value

            txtNombreEvaluacion.Focus()
        End If
    End Sub

    Private Sub mnuEliminar_Click(sender As Object, e As EventArgs) Handles mnuEliminar.Click
        Dim cmodel As New cmodelo(_conexionSociograma)
        Try
            Dim respuesta As Boolean = False
            Dim cadena As String = "delete sg_culturatipotest1 where ciclo=@ciclo and tipotest=@tipotest"
            lpara.Clear()

            If dgData.SelectedRows.Count > 0 Then
                lpara("ciclo") = dgData.Item(0, dgData.SelectedRows(0).Index).Value
                lpara("tipotest") = dgData.Item(1, dgData.SelectedRows(0).Index).Value

                cmodel.EjecutarNonQuery(cadena, ListaParametros(lpara))

                If cmodel.Commit() Then
                    MsgBox("Registro1 eliminado.", MsgBoxStyle.Information, "Mensaje del sistema")
                    CargarDatos()
                End If
            End If
        Catch ex As Exception
            cmodel.RollBack()
            MsgBox(ex.Message, MsgBoxStyle.Information, "Mensaje del sistema")
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbGrado2.Enabled = False
        Limpiar()
        LlenaComboPara()
    End Sub

    Private Sub LlenaComboNiveles()
        Dim cmodel As New cmodelo(_conexionSociograma)
        Dim dt As New DataTable("Nivel")
        Try
            Dim query As String = "select NIVEL,NOMBRE from NIVELES 
                                   where COLEGIO='M' and NIVEL not in('E','Y','Z') order by NIVEL"
            cmodel.llenaTabla(query, dt)
            cmbNivel.DataSource = dt
            cmbNivel.DisplayMember = "NOMBRE"
            cmbNivel.ValueMember = "NIVEL"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del sistema")
        End Try
    End Sub
    Private Sub LlenaComboGrados()
        Dim cmodel As New cmodelo(_conexionSociograma)
        Dim dt As New DataTable("Grado")
        lpara.Clear()
        lpara("nivel") = cmbNivel.SelectedValue
        Try
            Dim query As String = "select GRADO,NOMBRE from GRADOS where COLEGIO ='M' and NIVEL =@nivel"
            cmodel.llenaTabla(query, dt, ListaParametros(lpara))
            cmbGrado.DataSource = dt
            cmbGrado.DisplayMember = "NOMBRE"
            cmbGrado.ValueMember = "GRADO"

            cmbGrado2.DataSource = dt
            cmbGrado2.DisplayMember = "NOMBRE"
            cmbGrado2.ValueMember = "GRADO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del sistema")
        End Try
    End Sub
    Private Sub LlenaComboPara()
        ' Crear un DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(String))
        dt.Columns.Add("Nombre", GetType(String))

        ' Agregar filas
        dt.Rows.Add("", "")
        dt.Rows.Add("PB", "Primaria Baja")
        dt.Rows.Add("PA", "Primaria Alta")

        ' Asignar al ComboBox
        cmbGrado2.DataSource = dt
        cmbGrado2.DisplayMember = "Nombre"
        cmbGrado2.ValueMember = "ID"
    End Sub

    Private Sub cmbNivel_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbNivel.SelectionChangeCommitted
        'LlenaComboGrados()
    End Sub

    Private Sub cmbNivel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNivel.SelectedIndexChanged
        If cmbNivel.SelectedIndex = 1 Then
            cmbGrado2.Enabled = True
        Else
            cmbGrado2.Enabled = False
        End If
    End Sub
End Class