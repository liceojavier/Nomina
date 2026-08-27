Imports System.Data.SqlClient
Imports System.Linq.Enumerable
Imports System.Data

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMEVALUAOPCIONES.VB MIEMBRO DE NOMINA.SLN                                  **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         13/10/2014                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmEvaluaOpciones

    Private tipotest, accion, pregunta, opcion As Int32
    Private WithEvents fEmp As frmMuestraCodigos
    Private tbTipoEvaluacion As New DataTable("tipoevaluacion")
    Private tbPregunta As New DataTable("pregunta")
    Private filaTemp As DataRow
    Dim objquery As New cquery(_conexionAcademia)
    Dim _opcion As Int32
    Dim tbDetalle As DataTable
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmEvaluaOpciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
        rbUnico.Checked = True
    End Sub

    Private Sub txtCiclo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtCiclo.Text.Length = 4 And tipotest <> 0 Then
            ' Llenar_Grid_Opciones()
            Llenar_Combo_Pregunta()
        Else
            grdOpciones.DataSource = Nothing
            cmbDelP.DataSource = Nothing
            cmbAlP.DataSource = Nothing
        End If
    End Sub

    Private Sub btnAsignarTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarTE.Click
        If Not txtCodigoTE.Text.Equals("") And Not txtNombreTE.Text.Equals("") Then
            If (Int32.TryParse(txtCodigoTE.Text, tipotest)) Then
                Llenar_Combo_Pregunta()
                gbGrupo.Enabled = True
                gbUnico.Enabled = True
                btnGuardar.Enabled = True
            Else
                MsgBox("FORMATO INVALIDO PARA EL CODIGO DEL TIPO DE EVALUACIÓN.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            End If
        Else
            MsgBox("NO HA INGRESADO UN TIPO DE EVALUACIÓN.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub cmbDelP_SelectedValue(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDelP.SelectedValueChanged, _
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

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
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
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = tipotest
        lpara("min") = min
        lpara("max") = max
        Try
            Dim cadena As String = ""

            cadena = "select count(*) from evaluaopciones where empresa=@empresa and ciclo=@ciclo and tipotest=@tipotest and numpregunta between @min  and @max"

            If CInt(objquery.BuscaEscalar(cadena, ListaParametros(lpara))) > 0 Then
                If MsgBox("EXISTEN OPCIONES YA INGRESADAS " & vbNewLine &
                          "SE ELIMINARAN LAS FILAS DE LA(S) PREGUNTA(S) SELECCIONADA(S), ESTA SEGURO QUE DESEA CONTINUAR ",
                          MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            Dim para As List(Of SqlParameter)
            Dim cdata As New cmodelo(_conexionAcademia)

            Try
                cadena = "delete from evaluaopciones where empresa=@empresa and ciclo=@ciclo and tipotest=@tipotest and numpregunta between @min  and @max"
                cdata.EjecutarNonQuery(cadena, ListaParametros(lpara))

                Select Case _opcion
                    Case 1
                        For Each fila As DataRow In tbDetalle.Rows
                            para = New List(Of SqlParameter)
                            cadena = "insert into evaluaopciones (empresa, ciclo, tipotest, numpregunta, numopcion, " _
                                    & "opcion, valor) values (@empresa, @ciclo, @tipotest, @numpregunta, @numopcion, " _
                                    & "@opcion, @valor)"
                            para.Add(New SqlParameter("empresa", Definiciones.empresa))
                            para.Add(New SqlParameter("ciclo", txtCiclo.Text))
                            para.Add(New SqlParameter("tipotest", tipotest))
                            para.Add(New SqlParameter("numpregunta", min))
                            para.Add(New SqlParameter("numopcion", fila.Item("numopcion")))
                            para.Add(New SqlParameter("opcion", fila.Item("opcion")))
                            para.Add(New SqlParameter("valor", fila.Item("valor")))
                            cdata.EjecutarNonQuery(cadena, para)
                        Next

                    Case 2
                        For i As Integer = Convert.ToInt32(cmbDelP.SelectedValue) To Convert.ToInt32(cmbAlP.SelectedValue) Step 1
                            For Each fila As DataRow In tbDetalle.Rows
                                para = New List(Of SqlParameter)
                                cadena = "insert into evaluaopciones (empresa, ciclo, tipotest, numpregunta, numopcion, 
                                          opcion, valor) values (@empresa, @ciclo, @tipotest, @numpregunta, @numopcion, 
                                          @opcion, @valor)"
                                para.Add(New SqlParameter("empresa", Definiciones.empresa))
                                para.Add(New SqlParameter("ciclo", txtCiclo.Text))
                                para.Add(New SqlParameter("tipotest", tipotest))
                                para.Add(New SqlParameter("numpregunta", i))
                                para.Add(New SqlParameter("numopcion", fila.Item("numopcion")))
                                para.Add(New SqlParameter("opcion", fila.Item("opcion")))
                                para.Add(New SqlParameter("valor", fila.Item("valor")))
                                cdata.EjecutarNonQuery(cadena, para)
                            Next
                        Next
                End Select
                If cdata.Commit() Then
                    MsgBox("Operación realizada con éxito ".ToUpper(), MsgBoxStyle.Information, "Mensaje del Sistema")
                End If


                InsertBitacora(9, 1, $"Modificación de las opciones de prueba {tipotest} del ciclo {txtCiclo.Text}")

            Catch ex As Exception
                cdata.RollBack()
                MsgBox("Error DEL SISTEMA " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try



            Limpiar_Opcion()
        Catch ex As Exception

            MsgBox("Error DEL SISTEMA " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try

        '  Llenar_Grid_Opciones()
    End Sub


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub Llenar_Grid_Opciones(ByVal numpregunta As Int32)
        tbDetalle = New DataTable
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = tipotest
        lpara("numpregunta") = numpregunta
        Dim cadena As String = "Select numopcion, opcion, valor from evaluaopciones 
                                where empresa = @empresa And ciclo=@ciclo and tipotest=@tipotest and numpregunta=@numpregunta order by numopcion"
        objquery.llenaTabla(cadena, tbDetalle, ListaParametros(lpara))
        grdOpciones.DataSource = tbDetalle
        With grdOpciones
            .Columns("numopcion").HeaderText = "Número"
            .Columns("numopcion").Width = 70
            .Columns("opcion").HeaderText = "Opción"
            .Columns("opcion").Width = 280
            .Columns("valor").HeaderText = "Valor"
            .Columns("valor").Width = 50
        End With
        txtNo.Text = oultima_opcion(tbDetalle, "numopcion") + 1
    End Sub

    Private Sub Llenar_Combo_Pregunta()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = tipotest
        Dim cadena As String = "select distinct numpregunta from evaluapreguntas where empresa =@empresa and ciclo=@ciclo and tipotest=@tipotest order by numpregunta"

        Dim cadena2 As String = "select numpregunta, cast(numpregunta as varchar) + '. - ' + pregunta as pregunta from evaluapreguntas " &
                                "where empresa=@empresa and ciclo=@ciclo and tipotest=@tipotest order by numpregunta "
        Dim tabla As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        objquery.llenaTabla(cadena, tabla, ListaParametros(lpara))
        objquery.llenaTabla(cadena, tabla1, ListaParametros(lpara))
        objquery.llenaTabla(cadena, tabla2, ListaParametros(lpara))
        cmbDelP.DataSource = tabla
        cmbDelP.DisplayMember = tabla.Columns(0).Caption.ToString()
        cmbDelP.ValueMember = tabla.Columns(0).Caption.ToString()
        cmbAlP.DataSource = tabla1
        cmbAlP.DisplayMember = tabla1.Columns(0).Caption.ToString()
        cmbAlP.ValueMember = tabla1.Columns(0).Caption.ToString()
        cmbPregunta.DataSource = tabla2
        cmbPregunta.DisplayMember = "pregunta"
        cmbPregunta.ValueMember = "numpregunta"
    End Sub


    Private Function oultima_opcion(ByRef tabla As DataTable, ByVal campo As String) As Int16
        Try
            Dim query As List(Of Int16) = (From opciones In tabla.AsEnumerable _
              Select opciones.Field(Of Int16)(campo)).ToList()
            If Not query Is Nothing And query.Count > 0 Then
                Return CInt(query.Max())
            End If
        Catch ex As Exception
            MsgBox("ERROR DEL SISTEMA " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
        Return 0
    End Function

    Private Sub Limpiar_Opcion()
        gbGrupo.Enabled = True
        txtOpcion.Text = Nothing
        txtValor.Text = "0"
        txtNo.Clear()
        accion = 0
        opcion = 0
        pregunta = 0
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

    Private Sub GrdOpciones_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdOpciones.CellEnter
        If grdOpciones.SelectedRows.Count > 0 Then
            grdOpciones.Rows(grdOpciones.SelectedRows(0).Index).Selected = True
        End If
    End Sub

#Region "Tipo de Evaluacion"

    Private Sub BorraTipoEvaluacion(ByVal valbool As Boolean)
        txtNombreTE.Clear()
        If valbool = True Then
            txtCodigoTE.Clear()
        End If
    End Sub


    Private Sub BtnBuscarTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarTE.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("ciclo") = txtCiclo.Text
        Dim cadena As String = "select tipotest, nombre from evaluatipotest where ciclo =@ciclo order by ciclo, tipotest"
        numFilas = objquery.llenaTabla(cadena, tbTipoEvaluacion, ListaParametros(lpara))
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

    Private Sub ValidaTipoEvaluacion()
        lpara.Clear()
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = txtCodigoTE.Text.Trim()
        If valida_tipo_Entero(txtCodigoTE.Text, 2) = True Then
            Dim tbTemp As New DataTable
            Dim cadena As String = "select tipotest, nombre from evaluatipotest where ciclo = @ciclo and tipotest=@tipotest"
            objquery.llenaTabla(cadena, tbTemp, ListaParametros(lpara))
            If tbTemp.Rows.Count > 0 Then
                filaTemp = tbTemp.Rows(0)
                txtCodigoTE.Text = filaTemp.Item(0)
                txtNombreTE.Text = filaTemp.Item(1)
            End If
        Else
            MsgBox("CODIGO DEL TIPO DE EVALUACION POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraTipoEvaluacion(True)
            txtCodigoTE.Focus()
        End If
    End Sub

    Private Sub TxtCodigoTE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoTE.Validated
        If txtCodigoTE.Text.Trim <> "" And txtCodigoTE.ReadOnly = False Then
            ValidaTipoEvaluacion()
        ElseIf txtCodigoTE.ReadOnly = False Then
            BorraTipoEvaluacion(False)
        End If
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

#End Region

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

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
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
                tbDetalle.Rows.Add(fnuevo)
                grdOpciones.Sort(grdOpciones.Columns("numopcion"), System.ComponentModel.ListSortDirection.Ascending)
                btnLimpiar2_Click(sender, e)
                txtOpcion.Focus()
            Catch ex As Exception
                MsgBox("ERROR DEL SISTEMA " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End If
    End Sub

    Private Sub lblCiclo_Click(sender As Object, e As EventArgs) Handles lblCiclo.Click

    End Sub

    Private Sub ctxEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
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

    Private Sub btnLimpiar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar2.Click
        txtNo.Text = oultima_opcion(tbDetalle, "numopcion") + 1
        txtOpcion.Clear()
        txtValor.Text = "0"
    End Sub

    Private Sub txtValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValor.KeyPress, _
    txtCodigoTE.KeyPress, txtNo.KeyPress
        soloNumero(sender, e)
    End Sub
End Class