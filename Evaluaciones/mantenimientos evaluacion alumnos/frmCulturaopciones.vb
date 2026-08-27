Imports System.Data.SqlClient

Public Class frmCulturaopciones
    Dim ciclo As String = DateTime.Now.Year
    Private tipotest, accion, pregunta, opcion As Int32
    Dim lpara As New Dictionary(Of String, Object)
    Private tbTipoEvaluacion As New DataTable("tipoevaluacion")
    Private tbPregunta As New DataTable("pregunta")
    Dim tbDetalle As DataTable
    Dim filaTemp As DataRow
    Private fEmp As frmMuestraCodigos
    Dim _opcion As Int32
    Dim id_pre As Int32 = 0
    Private Sub frmCulturaopciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        rbUnico.Checked = True
        LlenaComboPorque()
    End Sub

    Private Sub btnBuscarTE_Click(sender As Object, e As EventArgs) Handles btnBuscarTE.Click
        Dim cmodel As New cmodelo(_conexionSociograma)
        Dim numFilas As Int32
        lpara.Clear()
        lpara("ciclo") = txtCiclo.Text
        Dim cadena As String = "select tipotest, nombretest from sg_culturatipotest1 where ciclo =@ciclo order by ciclo, tipotest"
        numFilas = cmodel.llenaTabla(cadena, tbTipoEvaluacion, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TIPOS DE EVALUACION CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraTipoEvaluacion(True)
            txtCodigoTE.Clear()
        ElseIf numFilas = 1 Then
            BorraTipoEvaluacion(True)
            filaTemp = tbTipoEvaluacion.Rows.Item(0)
            txtCodigoTE.Text = filaTemp.Item(0)
            txtNombreTE.Text = filaTemp.Item(1)
        Else
            EnBuscaTipoEvaluacion()
        End If
    End Sub

    Private Sub BorraTipoEvaluacion(ByVal valbool As Boolean)
        txtNombreTE.Clear()
        If valbool = True Then
            txtCodigoTE.Clear()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validetError(txtCiclo, ep1) And validetError(txtCodigoTE, ep1) Then
            If _opcion = 1 Then
                guardar(cmbPregunta.SelectedValue, cmbPregunta.SelectedValue)
            Else
                guardar(cmbDelP.SelectedValue, cmbAlP.SelectedValue)
            End If
        Else
            MsgBox("DEBE DE INGRESAR UNA OPCIÓN.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub
    Private Sub guardar(ByVal min As Int32, ByVal max As Int32)
        Dim cmodel As New cmodelo(_conexionSociograma)
        lpara.Clear()
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = tipotest
        lpara("id_pre") = cmbPregunta.SelectedValue
        lpara("min") = min
        lpara("max") = max
        Try
            Dim cadena As String = ""
            cadena = "select count(*) from sg_culturaopciones where ciclo=@ciclo and tipotest=@tipotest and numpregunta between @min  and @max"

            If CInt(cmodel.BuscaEscalar(cadena, ListaParametros(lpara))) > 0 Then
                If MsgBox("EXISTEN OPCIONES YA INGRESADAS " & vbNewLine & "SE ELIMINARAN LAS FILAS DE LA(S) PREGUNTA(S) SELECCIONADA(S), ESTA SEGURO QUE DESEA CONTINUAR ",
                          MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            Try
                cadena = "delete from sg_culturaopciones where ciclo=@ciclo and id_pre=@id_pre"
                cmodel.EjecutarNonQuery(cadena, ListaParametros(lpara))

                'guarda la opción de por pregunta seleccionada
                Select Case _opcion
                    Case 1
                        For Each fila As DataRow In tbDetalle.Rows
                            lpara.Clear()
                            cadena = "insert into sg_culturaopciones (id_pre, ciclo, tipotest, numpregunta, numopcion, opcion, comodin,imagen,valor) 
                                      values (@id_pre,@ciclo, @tipotest, @numpregunta, @numopcion, @opcion,@comodin,@imagen, @valor)"
                            lpara("id_pre") = cmbPregunta.SelectedValue
                            lpara("ciclo") = txtCiclo.Text
                            lpara("tipotest") = tipotest
                            lpara("numpregunta") = cmbPregunta.SelectedIndex + 1
                            lpara("numopcion") = fila.Item("numopcion")
                            lpara("opcion") = fila.Item("opcion")
                            lpara("comodin") = fila.Item("comodin")
                            lpara("imagen") = ""
                            lpara("valor") = fila.Item("valor")
                            cmodel.EjecutarNonQuery(cadena, ListaParametros(lpara))
                        Next
                    'guarda la opción para un grupo de preguntas seleccionadas
                    Case 2
                        Dim idContador = cmbPregunta.SelectedValue
                        For i As Integer = Convert.ToInt32(cmbDelP.SelectedValue) To Convert.ToInt32(cmbAlP.SelectedValue) Step 1
                            For Each fila As DataRow In tbDetalle.Rows
                                lpara.Clear()
                                cadena = "insert into sg_culturaopciones (id_pre, ciclo, tipotest, numpregunta, numopcion, opcion,comodin,imagen, valor) 
                                          values (@id_pre, @ciclo, @tipotest, @numpregunta, @numopcion, @opcion,@comodin,@imagen, @valor)"
                                lpara("id_pre") = idContador
                                lpara("ciclo") = txtCiclo.Text
                                lpara("tipotest") = tipotest
                                lpara("numpregunta") = i
                                lpara("numopcion") = fila.Item("numopcion")
                                lpara("opcion") = fila.Item("opcion")
                                lpara("comodin") = fila.Item("comodin")
                                'lpara("comodin") = If(cmbPorque.Text = "", "N", cmbPorque.Text)
                                lpara("imagen") = ""
                                lpara("valor") = fila.Item("valor")

                                cmodel.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                idContador = idContador + 1
                            Next
                        Next
                End Select
                If cmodel.Commit() Then
                    MsgBox("Operación realizada con éxito ".ToUpper(), MsgBoxStyle.Information, "Mensaje del Sistema")
                End If


                InsertBitacora(9, 1, $"Modificación de las opciones de prueba {tipotest} del ciclo {txtCiclo.Text}")

            Catch ex As Exception
                cmodel.RollBack()
                MsgBox("Error DEL SISTEMA " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try

            Limpiar_Opcion()
        Catch ex As Exception

            MsgBox("Error DEL SISTEMA " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try

        '  Llenar_Grid_Opciones()
    End Sub

    Private Sub EnBuscaTipoEvaluacion()
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbTipoEvaluacion)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosTipoEvaluacion
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
    End Sub
    Private Sub ActualizacionDatosTipoEvaluacion(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraTipoEvaluacion(True)
        filaTemp = tbTipoEvaluacion.Rows.Item(e.va2)
        txtCodigoTE.Text = filaTemp.Item(0)
        txtNombreTE.Text = filaTemp.Item(1)
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If validetError(txtNo, ep1) And validetError(txtOpcion, ep1) And validetError(txtValor, ep1) Then
            Try

                If tbDetalle.Select("numopcion=" & txtNo.Text).Count > 0 Then
                    MsgBox("Número de opción ya ingresada, verifique".ToUpper(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
                Dim fnuevo As DataRow = tbDetalle.NewRow
                fnuevo.Item("numopcion") = CInt(txtNo.Text)
                fnuevo.Item("opcion") = txtOpcion.Text
                fnuevo.Item("valor") = CInt(txtValor.Text)
                fnuevo.Item("comodin") = cmbPorque.SelectedValue
                fnuevo.Item("nombre") = cmbPorque.Text
                tbDetalle.Rows.Add(fnuevo)
                grdOpciones.Sort(grdOpciones.Columns("numopcion"), System.ComponentModel.ListSortDirection.Ascending)
                btnLimpiar2_Click(sender, e)
                txtOpcion.Focus()
            Catch ex As Exception
                MsgBox("ERROR DEL SISTEMA " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End If
    End Sub
    Private Sub btnLimpiar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar2.Click
        txtNo.Text = oultima_opcion(tbDetalle, "numopcion") + 1
        txtOpcion.Clear()
        txtValor.Text = "0"
    End Sub
    Private Function oultima_opcion(ByRef tabla As DataTable, ByVal campo As String) As Int16
        Try
            Dim query As List(Of Int16) = (From opciones In tabla.AsEnumerable
                                           Select opciones.Field(Of Int16)(campo)).ToList()
            If Not query Is Nothing And query.Count > 0 Then
                Return CInt(query.Max())
            End If
        Catch ex As Exception
            MsgBox("ERROR DEL SISTEMA " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
        Return 0
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
    Private Sub Limpiar()
        btnGuardar.Enabled = False
        txtCiclo.Text = DateTime.Now.ToString("yyyy")
        txtCodigoTE.Text = Nothing
        txtNombreTE.Text = Nothing
        Limpiar_Opcion()
        grdOpciones.DataSource = Nothing
        gbOpcion.Enabled = False
        cmbAlP.DataSource = Nothing
        cmbDelP.DataSource = Nothing
        cmbPregunta.DataSource = Nothing
        gbGrupo.Enabled = False
        tipotest = 0
    End Sub

    Private Sub Limpiar_Opcion()
        gbGrupo.Enabled = True
        txtOpcion.Text = Nothing
        txtValor.Text = "0"
        txtNo.Clear()
        accion = 0
        opcion = 0
        pregunta = 0
    End Sub

    Private Sub btnAsignarTE_Click(sender As Object, e As EventArgs) Handles btnAsignarTE.Click
        If Not txtCodigoTE.Text.Equals("") And Not txtNombreTE.Text.Equals("") Then
            If (Int32.TryParse(txtCodigoTE.Text, tipotest)) Then
                Llenar_Combo_Pregunta()
                gbGrupo.Enabled = True
                gbUnico.Enabled = True
                btnGuardar.Enabled = True
                'gbOpcion.Enabled = True
            Else
                MsgBox("FORMATO INVALIDO PARA EL CODIGO DEL TIPO DE EVALUACIÓN.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            End If
        Else
            MsgBox("NO HA INGRESADO UN TIPO DE EVALUACIÓN.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub txtCiclo_TextChanged(sender As Object, e As EventArgs) Handles txtCiclo.TextChanged
        If txtCiclo.Text.Length = 4 And tipotest <> 0 Then
            ' Llenar_Grid_Opciones()
            Llenar_Combo_Pregunta()
        Else
            grdOpciones.DataSource = Nothing
            cmbDelP.DataSource = Nothing
            cmbAlP.DataSource = Nothing
        End If
    End Sub

    Private Sub cmbDelP_SelectedValue(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDelP.SelectedValueChanged,
        cmbAlP.SelectedValueChanged

        If _opcion = 2 Then
            Dim numpre1, numpre2 As Int32
            numpre1 = 1
            numpre2 = 2
            If Not cmbDelP.SelectedValue Is Nothing And Not cmbAlP.SelectedValue Is Nothing Then
                If Int32.TryParse(cmbAlP.SelectedValue.ToString(), numpre1) And Int32.TryParse(cmbDelP.SelectedValue, numpre2) Then
                    Llenar_Grid_Opciones(cmbDelP.SelectedValue)
                    gbOpcion.Enabled = True
                End If

            Else
                gbOpcion.Enabled = False
            End If
        End If

    End Sub
    Private Sub cmbPregunta_SelectedValue(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPregunta.SelectedValueChanged
        If _opcion = 1 Then
            Dim numpre1 As Int32 = 0
            If Not cmbPregunta.SelectedValue Is Nothing Then
                If Int32.TryParse(cmbPregunta.SelectedValue.ToString(), numpre1) Then
                    Llenar_Grid_Opciones(cmbPregunta.SelectedValue)
                    gbOpcion.Enabled = True
                End If
            Else
                gbOpcion.Enabled = False
            End If
        End If
    End Sub

    Private Sub ctxEliminar_Click(sender As Object, e As EventArgs) Handles ctxEliminar.Click
        If grdOpciones.Rows.Count > 0 Then
            If grdOpciones.SelectedRows.Count > 0 Then
                If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                    'verificar si tiene referencia en inscripciones
                    InsertBitacora(9, 4, $"Eliminación de opciones del ciclo { txtCiclo.Text} tipo test { tipotest}")
                    tbDetalle.Rows.Remove(CType(grdOpciones.SelectedRows(0).DataBoundItem, DataRowView).Row)

                    btnLimpiar2_Click(sender, e)
                    ' Llenar_Grid_Opciones()
                End If
            Else
                MsgBox("DEBE SELECCIONAR UN REGISTRO PARA ELIMINAR.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub Llenar_Combo_Pregunta()
        lblHayPreguntas.Visible = False
        Dim cmodel As New cmodelo(_conexionSociograma)
        'Dim dr As DataRow
        lpara.Clear()
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = tipotest
        Dim cadena As String = "select distinct numpregunta from sg_culturapreguntas where ciclo=@ciclo and tipotest=@tipotest order by numpregunta"

        Dim cadena2 As String = "select id_pre,numpregunta, cast(numpregunta as varchar) + '. - ' + pregunta as pregunta from sg_culturapreguntas
                                  where ciclo=@ciclo and tipotest=@tipotest order by numpregunta "
        Dim tabla As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        cmodel.llenaTabla(cadena, tabla, ListaParametros(lpara))
        cmodel.llenaTabla(cadena, tabla1, ListaParametros(lpara))
        cmodel.llenaTabla(cadena2, tabla2, ListaParametros(lpara))
        cmbDelP.DataSource = tabla
        cmbDelP.DisplayMember = tabla.Columns(0).Caption.ToString()
        cmbDelP.ValueMember = tabla.Columns(0).Caption.ToString()
        cmbAlP.DataSource = tabla1
        cmbAlP.DisplayMember = tabla1.Columns(0).Caption.ToString()
        cmbAlP.ValueMember = tabla1.Columns(0).Caption.ToString()
        cmbPregunta.DataSource = tabla2
        cmbPregunta.DisplayMember = "pregunta"
        cmbPregunta.ValueMember = "id_pre"

        If tabla2.Select.Count <= 0 Then
            lblHayPreguntas.Visible = True
            lblHayPreguntas.Text = "ESTA EVALUACION NO POSEE PREGUNTAS"
            'MsgBox("ESTE TIPO DE EVALUACION NO POSEE PREGUNTAS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub
    Private Sub Llenar_Grid_Opciones(ByVal numpregunta As Int32)
        Dim cmodel As New cmodelo(_conexionSociograma)
        tbDetalle = New DataTable
        lpara.Clear()
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = tipotest
        lpara("numpregunta") = numpregunta
        Dim cadena As String = "Select a.numopcion, a.opcion, a.valor,a.comodin,b.nombre from sg_culturaopciones a
                                inner join sg_cultura_tipo_opcion b on a.comodin=b.id_tipo_opcion 
                                where ciclo=@ciclo and tipotest=@tipotest and id_pre=@numpregunta order by numopcion"
        cmodel.llenaTabla(cadena, tbDetalle, ListaParametros(lpara))
        grdOpciones.DataSource = tbDetalle
        With grdOpciones
            .Columns("numopcion").HeaderText = "No. opción"
            .Columns("numopcion").Width = 70
            .Columns("opcion").HeaderText = "Opción"
            .Columns("opcion").Width = 200
            .Columns("valor").HeaderText = "Valor"
            .Columns("valor").Width = 50
            .Columns("comodin").HeaderText = "Posee"
            .Columns("comodin").Width = 50
            .Columns("nombre").Visible = True
            .Columns("nombre").Width = 200
        End With
        txtNo.Text = oultima_opcion(tbDetalle, "numopcion") + 1
    End Sub

    Private Sub rbUnico_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbUnico.CheckedChanged
        If rbUnico.Checked Then
            gbUnico.Visible = True
            gbGrupo.Visible = False
            _opcion = 1
        Else
            gbUnico.Visible = False
            gbGrupo.Visible = True
            _opcion = 2
        End If
    End Sub

    'Private Sub LlenaComboTipoOpcion()
    '    Dim cmodel As New cmodelo(_conexionAcademia)
    '    Dim dt As New DataTable("Tipoopcion")
    '    Dim query As String = "select id_tipo_opcion,nombre,descripcion from sg_cultura_tipo_opcion order by id_tipo_opcion"

    '    cmodel.llenaTabla(query, dt)
    '    cmbTipoOpcion.DataSource = dt
    '    cmbTipoOpcion.DisplayMember = "nombre"
    '    cmbTipoOpcion.ValueMember = "id_tipo_opcion"
    'End Sub

    Private Sub LlenaComboPorque()
        ' Crear un DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(String))
        dt.Columns.Add("Nombre", GetType(String))

        ' Agregar filas
        dt.Rows.Add("N", " ")
        dt.Rows.Add("S", "¿Por qué?")
        dt.Rows.Add("D", "Descripción")
        dt.Rows.Add("V", "Selección de valor")

        ' Asignar al ComboBox
        cmbPorque.DataSource = dt
        cmbPorque.DisplayMember = "Nombre"
        cmbPorque.ValueMember = "ID"
    End Sub
End Class