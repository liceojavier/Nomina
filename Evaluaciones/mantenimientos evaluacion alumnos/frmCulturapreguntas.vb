Public Class frmCulturapreguntas
    Dim tipotest, area, pregunta, _accion As Int32
    Dim lpara As New Dictionary(Of String, Object)
    Dim dt As New DataTable("tipoevaluacion")
    Dim tbArea As New DataTable("area")
    Dim filaTemp As DataRow
    Dim ciclo As Int32 = DateTime.Now.Year
    Dim fEmp As frmMuestraCodigos
    Dim IdPregunta As Int32 = 0
    'Dim cmodel As New cmodelo2(_conexionAcademia)
    Private Sub frmCulturapreguntas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCiclo.Text = ciclo
    End Sub

    Private Sub btnBuscarTE_Click(sender As Object, e As EventArgs) Handles btnBuscarTE.Click
        Dim numFilas As Int32
        Dim conexion As New DbConexion(_conexionSociograma)
        lpara.Clear()
        lpara("nombre") = txtNombreTE.Text.Trim()
        lpara("ciclo") = txtCiclo.Text
        Dim cadena As String = "select tipotest, nombretest from sg_culturatipotest1 where nombretest like '%' + @nombre + '%' and ciclo=@ciclo order by ciclo, tipotest"
        dt = conexion.hacerConsulta(cadena, ListaParametros(lpara)).Tables("consulta")
        numFilas = dt.Rows.Count
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TIPOS DE EVALUACION CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraTipoEvaluacion(True)
            txtCodigoTE.Clear()
        ElseIf numFilas = 1 Then
            BorraTipoEvaluacion(True)
            asigna_valores(dt.Rows.Item(0))
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

    Private Sub ActualizacionDatosTipoEvaluacion(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraTipoEvaluacion(True)
        filaTemp = dt.Rows.Item(e.va2)
        asigna_valores(filaTemp)
    End Sub

    Private Sub asigna_valores(ByVal f As DataRow)
        txtCodigoTE.Text = f.Item("tipotest").ToString()
        txtNombreTE.Text = f.Item("nombretest").ToString()
    End Sub
    Private Sub EnBuscaTipoEvaluacion()
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(dt)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosTipoEvaluacion
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
        txtCiclo.ReadOnly = False
        txtCodigoTE.ReadOnly = False
    End Sub

    Private Sub btnAsignarTE_Click(sender As Object, e As EventArgs) Handles btnAsignarTE.Click
        Dim cadena As String = ""
        Dim cmodel As New cmodelo(_conexionAcademia)
        If Not txtCodigoTE.Text.Equals("") And Not txtNombreTE.Text.Equals("") Then
            lpara.Clear()

            If (Int32.TryParse(txtCodigoTE.Text, tipotest)) Then
                obtenerNoPregunta(txtCiclo.Text, txtCodigoTE.Text)
                'lpara("ciclo") = txtCiclo.Text
                'lpara("tipotest") = txtCodigoTE.Text
                'cadena = "SELECT max(numpregunta + 1) FROM sg_culturapreguntas where ciclo=@ciclo and tipotest=@tipotest"
                'txtNumeroPregunta.Text = If(IsDBNull(cmodel.BuscaEscalar(cadena, ListaParametros(lpara))), 1, cmodel.BuscaEscalar(cadena, ListaParametros(lpara)))




                'gbPregunta.Enabled = True
                'cadena = "declare @total int; 
                '      set @total=0; 
                '      set @total = @total + (select count(*) from sg_cultrura where ciclo=@ciclo and tipotest=@tipotest);
                '      set @total = @total + (select count(*) from evadoctest1 where ciclo=@ciclo and tipotest=@tipotest);
                '      select @total;"
                'Dim cuenta As Int32 = cmodel.BuscaEscalar(cadena, ListaParametros(lpara))
                'If cuenta > 0 Then
                '    MsgBox("Tipo de Evaluación ya posee resultados, por lo que no se puede modificar, verifique", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                '    gbPregunta.Enabled = False
                'Else
                '    gbPregunta.Enabled = True
                'End If

                limpia_detalle(True)
                gbPregunta.Enabled = True
                Llenar_Grid_Preguntas()
                txtCiclo.ReadOnly = True
                txtCodigoTE.ReadOnly = True
            Else
                MsgBox("FORMATO INVALIDO PARA EL CODIGO DEL TIPO DE EVALUACIÓN.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            End If
        Else
            MsgBox("NO HA INGRESADO UN TIPO DE EVALUACIÓN.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub
    'Permite calcular el siguiente numero de pregunta a ingresar
    Private Sub obtenerNoPregunta(ByVal ciclo As String, ByVal tipotest As String)
        Dim cmodel As New cmodelo(_conexionSociograma)
        Dim cadena As String = ""
        lpara.Clear()
        lpara("ciclo") = ciclo
        lpara("tipotest") = tipotest
        cadena = "SELECT max(numpregunta + 1) FROM sg_culturapreguntas where ciclo=@ciclo and tipotest=@tipotest"
        txtNumeroPregunta.Text = If(IsDBNull(cmodel.BuscaEscalar(cadena, ListaParametros(lpara))), 1, cmodel.BuscaEscalar(cadena, ListaParametros(lpara)))
    End Sub

    Private Sub Llenar_Combo(ByVal cmb As ComboBox, ByVal tabla As DataTable)
        cmb.DataSource = tabla
        cmb.DisplayMember = tabla.Columns(1).Caption.ToString()
        cmb.ValueMember = tabla.Columns(0).Caption.ToString()
    End Sub

    Private Sub Limpiar()
        txtCiclo.Text = DateTime.Now.ToString("yyyy")
        grdPreguntas.DataSource = Nothing
        txtCodigoTE.Text = Nothing

        txtNombreTE.Text = Nothing

        gbPregunta.Enabled = False
        tipotest = 0
        area = 0
        limpia_detalle(False)
        txtNumeroPregunta.Text = ""
        nudMax.Value = 1
    End Sub
    Private Sub txtCiclo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCiclo.KeyPress
        soloNumero(sender, e)
    End Sub
    Private Sub txtCiclo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCiclo.TextChanged
        If txtCiclo.Text.Length = 4 And tipotest <> 0 And area <> 0 Then
            Llenar_Grid_Preguntas()
        Else
            grdPreguntas.DataSource = Nothing
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        limpia_detalle(True)
    End Sub

    Private Sub btnGuardar2_Click(sender As Object, e As EventArgs) Handles btnGuardar2.Click
        Dim cmodel As New cmodelo(_conexionSociograma)
        If MsgBox("¿Desea actualizar los textos de las preguntas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") Then
            If grdPreguntas.DataSource IsNot Nothing Then
                Dim cadena As String = ""
                Dim result As Boolean = True
                Dim tbdata As DataTable = grdPreguntas.DataSource
                lpara.Clear()
                Dim dr As DataRow
                For i As Int32 = 0 To tbdata.Rows.Count - 1
                    dr = tbdata.Rows(i)
                    lpara("numpregunta") = dr("num")
                    lpara("pregunta") = dr("pregunta")
                    lpara("opcion_vertical") = dr("opcion_vertical")
                    lpara("instrucciones") = dr("instrucciones")
                    lpara("id_pregunta") = dr("id_pregunta")

                    cadena = "update evaluapreguntas set numpregunta=@numpregunta, pregunta=@pregunta, opcion_vertical=@opcion_vertical, instrucciones=@instrucciones where id_pregunta=@id_pregunta"
                    result = result And cmodel.EjecutarNonQuery(cadena, ListaParametros(lpara))

                Next i
                If result Then
                    MsgBox("Preguntas modificadas")
                End If

            Else
                MsgBox("No hay registros para modificar", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        lpara.Clear()
        If validetError(txtPregunta, ep) And validetError(txtNumeroPregunta, ep) Then
            Dim cadena As String = ""
            Dim num_linea As Integer = 0
            Dim cmodel As New cmodelo(_conexionAcademia)

            lpara("ciclo") = txtCiclo.Text
            lpara("tipotest") = tipotest
            lpara("numpregunta") = CInt(txtNumeroPregunta.Text)
            lpara("pregunta") = txtPregunta.Text
            lpara("maximas") = nudMax.Value.ToString()
            lpara("minimas") = txtOpMin.Text
            lpara("id_pre") = IdPregunta
            Select Case _accion
                Case 0
                    cadena = "insert into sg_culturapreguntas(ciclo, tipotest, area,numpregunta, pregunta, id_compespecifica, id_grupo, opcion_vertical, instrucciones,imagen,id_rasgo,maximas,minimas,descripcion) " &
                                     "values (@ciclo,@tipotest,0,@numpregunta,@pregunta,0,0,1,0,'',0,@maximas,@minimas,'')"
                Case 1
                    cadena = "update sg_culturapreguntas set 
                              ciclo=@ciclo,
                              tipotest=@tipotest, 
                              numpregunta = @numpregunta, 
                              pregunta = @pregunta, 
                              minimas =@minimas,
                              area = 0,
                              id_compespecifica=0,
                              id_grupo=0,
                              opcion_vertical=1,
                              instrucciones=0,
                              imagen='',
                              id_rasgo=0,
                              descripcion='' 
                              where id_pre=@id_pre and ciclo=@ciclo and tipotest=@tipotest and numpregunta =@numpregunta "
            End Select
            Try
                cmodel.EjecutarNonQuery(cadena, ListaParametros(lpara))
                If cmodel.Commit() Then
                    MsgBox("SE HA INGRESADO CORRECTAMENTE LA PREGUNTA.", MsgBoxStyle.Information, "Mensaje del Sistema")
                    obtenerNoPregunta(txtCiclo.Text, tipotest)
                End If
                Llenar_Grid_Preguntas()
                limpia_detalle(True)
            Catch ex As Exception
                cmodel.RollBack()
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try

        End If
    End Sub

    Private Sub ctxEliminar_Click(sender As Object, e As EventArgs) Handles ctxEliminar.Click
        If grdPreguntas.Rows.Count > 0 Then
            If grdPreguntas.SelectedRows.Count > 0 Then
                If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                    'verificar si tiene referencia en inscripciones
                    Dim conexion As New cmodelo(_conexionSociograma)
                    Dim cadena As String
                    lpara.Clear()
                    lpara("id_pregunta") = grdPreguntas.SelectedRows.Item(0).Cells("id_pre").Value
                    cadena = "delete sg_culturapreguntas where id_pre=@id_pregunta "
                    conexion.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    If conexion.Commit() Then
                        InsertBitacora(9, 4, $"Eliminación id_pregunta {lpara("id_pregunta")}")
                    End If
                    Limpiar_Pregunta(False)
                    Llenar_Grid_Preguntas()
                    MsgBox("Orden modificado, debe actualizarlo con la actualización por grid", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    If grdPreguntas.DataSource IsNot Nothing Then
                        Dim tbdata As DataTable = grdPreguntas.DataSource
                        For i As Int32 = 0 To tbdata.Rows.Count - 1
                            tbdata.Rows(i)("numpregunta") = i + 1
                        Next i
                    End If
                End If
            Else
                MsgBox("DEBE SELECCIONAR UN REGISTRO PARA ELIMINAR.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxModificar_Click(sender As Object, e As EventArgs) Handles ctxModificar.Click
        _accion = 1
        lbMensaje.Text = "Modificación de registro"
        grdPreguntas_Click(sender, e)
    End Sub
    Private Sub grdPreguntas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPreguntas.Click
        If grdPreguntas.SelectedRows.Count > 0 And _accion = 1 Then
            If Int32.TryParse(grdPreguntas.SelectedRows(0).Cells(2).Value.ToString(), pregunta) Then
                IdPregunta = grdPreguntas.SelectedRows(0).Cells("id_pre").Value
                txtNumeroPregunta.Text = grdPreguntas.SelectedRows(0).Cells("numpregunta").Value.ToString()
                txtPregunta.Text = grdPreguntas.SelectedRows(0).Cells("pregunta").Value.ToString()
                txtOpMin.Text = grdPreguntas.SelectedRows(0).Cells("minimas").Value.ToString()
                nudMax.Value = grdPreguntas.SelectedRows(0).Cells("maximas").Value.ToString()
            End If
        End If
    End Sub

    Private Sub limpia_detalle(ByVal busca_linea As Boolean)
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = tipotest
        'If busca_linea Then
        '    Dim conexion As New DbConexion(_conexionAcademia)
        '    Dim cadena As String = ""
        '    cadena = "select isnull(max(numpregunta), 0) num from evaluapreguntas where empresa = @empresa and ciclo=@ciclo and tipotest=@tipotest group by tipotest"
        '    Dim num As Int32 = 0
        '    Dim numObj As Object = conexion.regresaEscalar(cadena, ListaParametros(lpara))
        '    If Not numObj Is Nothing Then
        '        If Int32.TryParse(numObj.ToString(), num) Then
        '            txtNumeroPregunta.Text = num + 1
        '        End If
        '    Else
        '        txtNumeroPregunta.Text = num + 1
        '    End If
        'End If
        _accion = 0
        lbMensaje.Text = "Ingreso de Registro"

        Limpiar_Pregunta(Not busca_linea)
    End Sub
    Private Sub Limpiar_Pregunta(reset As Boolean)
        txtPregunta.Text = Nothing
        _accion = 0
        pregunta = 0
        txtPregunta.Focus()
    End Sub
    Private Sub Llenar_Grid_Preguntas()
        lpara.Clear()
        Dim conexion As New DbConexion(_conexionSociograma)
        Dim cadena As String
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = tipotest
        cadena = "SELECT id_pre,ciclo,tipotest,numpregunta,pregunta,minimas,maximas,area,id_compespecifica,
                  id_grupo,opcion_vertical,instrucciones,imagen,id_rasgo,descripcion
                  FROM sg_culturapreguntas where ciclo=@ciclo and tipotest=@tipotest order by numpregunta"
        grdPreguntas.DataSource = conexion.hacerConsulta(cadena, ListaParametros(lpara)).Tables("Consulta")
        With grdPreguntas
            .Columns("id_pre").Visible = False
            .Columns("ciclo").Width = 70
            .Columns("ciclo").HeaderText = "Ciclo"
            .Columns("tipotest").Visible = False
            .Columns("numpregunta").Width = 300
            .Columns("numpregunta").HeaderText = "No. Pregunta"
            .Columns("pregunta").Width = 300
            .Columns("pregunta").HeaderText = "Pregunta"
            .Columns("minimas").Width = 150
            .Columns("minimas").HeaderText = "Minimas"
            .Columns("maximas").Width = 150
            .Columns("maximas").HeaderText = "Maximas"
            .Columns("area").Visible = False
            .Columns("id_compespecifica").Visible = False
            .Columns("id_grupo").Visible = False
            .Columns("opcion_vertical").Visible = False
            .Columns("instrucciones").Visible = False
            .Columns("imagen").Visible = False
            .Columns("id_rasgo").Visible = False
            .Columns("descripcion").Visible = False
        End With
    End Sub
End Class