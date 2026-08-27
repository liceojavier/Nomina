'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMTIPOEVALUACION.VB MIEMBRO DE NOMINA.SLN                                  **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         20/08/2014                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmTipoEvaluacion

    Dim cadena As String
    Dim tabla As New DataTable("Datos")
    Dim accion, ciclo As Int16
    Dim ctrTipoEvalua As EvaluatipotestController
    Dim mod2 As New cmodelo2(_conexionAcademia)
    Dim lpara As New Dictionary(Of String, Object)
    Dim _id_tipotest As Int32 = 0

    Private Sub frmTipoEvaluacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCiclo.Text = Today.Year
        ctrTipoEvalua = New EvaluatipotestController()
        ctrTipoEvalua.FillCombo_grupo_evaluacion(cmbGrupoAsignacion, False)
        ctrTipoEvalua.FillCombo_tipo(cmbTipoEvaluacion, False)
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario
        txtCiclo.Text = Year(Today).ToString
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        accion = 0
        _id_tipotest = 0
        EnabilizarMenu(True)
        borra_Mejorado(gpDatos, ep1)
        Dim ciclo As Int16 = 0
        lpara.Clear()

        Int16.TryParse(txtCiclo.Text, ciclo)
        lpara("ciclo") = txtCiclo.Text
        lpara("empresa") = empresa
        cadena = "select id_tipotest, ciclo, tipotest, nombre,tipo, grupo_asignacion from evaluatipotest where empresa=@empresa and ciclo=@ciclo order by ciclo, tipotest  "
        tabla = mod2.llenaTabla(cadena, ListaParametros(lpara))
        cadena = "select coalesce ( max(tipotest), 0) + 1 from evaluatipotest where empresa=@empresa and  ciclo =@ciclo"
        txtCodigo.Text = mod2.BuscaEscalar(cadena, ListaParametros(lpara))
        dgDatos.DataSource = tabla
        Vista(dgDatos)

        EnabilizarMenu(True)
        TextNombre.Focus()

    End Sub

    Private Sub Vista(ByVal dgVista As DataGridView)
        If dgVista.DataSource IsNot Nothing Then
            With dgVista
                .Columns("ciclo").HeaderText = "Ciclo"
                .Columns("ciclo").FillWeight = 15
                .Columns("tipotest").HeaderText = "Código"
                .Columns("tipotest").FillWeight = 15
                .Columns("nombre").HeaderText = "Nombre"
                .Columns("nombre").FillWeight = 70
                .Columns("id_tipotest").Visible = False
                .Columns("tipo").Visible = False
                .Columns("grupo_asignacion").Visible = False
                'AltoGridView(18, tabla, 292, 552, dgVista)
            End With
        End If

    End Sub


    Private Sub EnabilizarMenu(ByVal valB As Boolean)

        ctxModificar.Enabled = valB
        ctxEliminar.Enabled = valB
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Not validetError(TextNombre, ep1) Or Not validetError(cmbTipoEvaluacion, ep1) Then
            Exit Sub
        End If
        Dim tipo As Int16 = cmbTipoEvaluacion.SelectedValue
        Dim grupo_asignacion As Int32 = cmbGrupoAsignacion.SelectedValue
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("ciclo") = CInt(txtCiclo.Text)
        lpara("tipotest") = CInt(txtCodigo.Text)
        lpara("nombre") = TextNombre.Text
        lpara("tipo") = tipo
        lpara("grupo_asignacion") = grupo_asignacion
        Select Case accion
            Case 0
                cadena = "insert into evaluatipotest(empresa, ciclo, tipotest, nombre,tipo, grupo_asignacion)" &
                     " values (@empresa,@ciclo, @tipotest, @nombre,@tipo, @grupo_asignacion)"
            Case 1
                lpara("id_tipotest") = _id_tipotest
                cadena = "update evaluatipotest set nombre =@nombre, tipo=@tipo, grupo_asignacion=@grupo_asignacion where " &
                     "id_tipotest = @id_tipotest"
        End Select
        If mod2.EjecutarNonQuery(cadena, ListaParametros(lpara)) Then
            btnLimpiar_Click(sender, e)
            Select Case accion
                Case 0
                    InsertBitacora(9, 1, $"Creación ciclo {txtCiclo.Text} tipotest {txtCodigo} ")
                    MueveScrollView(dgDatos)

                Case 1
                    InsertBitacora(9, 2, $"Modificación ciclo {txtCiclo.Text} tipotest {txtCodigo} ")
            End Select
        End If


    End Sub



    Private Sub MnuModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click
        Dim f As DataRow
        If dgDatos.SelectedRows.Count > 0 Then
            accion = 1
            txtCiclo.ReadOnly = True
            txtCodigo.ReadOnly = True
            EnabilizarMenu(False)

            f = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            _id_tipotest = f("id_tipotest")
            txtCiclo.Text = f.Item("ciclo")
            txtCodigo.Text = f.Item("tipotest")
            TextNombre.Text = f.Item("nombre")
            cmbTipoEvaluacion.SelectedValue = f("tipo")
            cmbGrupoAsignacion.SelectedValue = f("grupo_asignacion")
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub MnuElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        Dim filaTemp As DataRow
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row

            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                lpara.Clear()
                lpara("ciclo") = filaTemp("ciclo")
                lpara("tipotest") = filaTemp("tipotest")


                cadena = "select count(*) from evaluatipo_asignacion where tipotest=@tipotest and ciclo = @ciclo"
                If mod2.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                    MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If


                'verificar si tiene referencia en inscripciones
                cadena = "delete from evaluatipotest where tipotest=@tipotest and ciclo = @ciclo"
                If mod2.EjecutarNonQuery(cadena, ListaParametros(lpara)) Then
                    InsertBitacora(9, 4, $"Eliminacion id_tipotest {filaTemp("id_tipotest")}")
                End If


                btnLimpiar_Click(sender, e)
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If

    End Sub

    Private Sub frmRutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub textRegion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCiclo.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCiclo.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCiclo.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub insercion_evaluacion(ByVal tabla As DataTable, ByVal cm As cmodelo)
        Dim tbRespuesta As New DataTable("respuesta")
        Dim tbOpciones As New DataTable("opciones")
        'lpara("cicloant") = CStr(CInt(txtCiclo.Text) - 1)
        For Each ftemp As DataRow In tabla.Rows
            lpara("tipotest") = ftemp.Item("tipotest")
            lpara("nombre") = ftemp.Item("nombre")
            lpara("id_instrumento") = ftemp.Item("id_instrumento")
            lpara("grupo_asignacion") = ftemp.Item("grupo_asignacion")
            lpara("tipo") = ftemp.Item("tipo")

            cadena = "insert into evaluatipotest(empresa,tipotest,ciclo,nombre,id_instrumento,grupo_asignacion,tipo) values " +
                      "(@empresa,@tipotest,@ciclo,@nombre,@id_instrumento,@grupo_asignacion,@tipo)"
            cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
        Next
        cadena = "select empresa,ciclo,tipotest,area,id_rasgo,numpregunta,pregunta,id_compespecifica,id_grupo,maximas,minimas,opcion_vertical," +
                 "instrucciones,grupo_respuesta from evaluapreguntas where ciclo=@cicloant"
        cm.llenaTabla(cadena, tbRespuesta, ListaParametros(lpara))
        For Each ftempR As DataRow In tbRespuesta.Rows
            lpara("tipotest") = ftempR.Item("tipotest")
            lpara("area") = ftempR.Item("area")
            lpara("id_rasgo") = ftempR.Item("id_rasgo")
            lpara("numpregunta") = ftempR.Item("numpregunta")
            lpara("pregunta") = ftempR.Item("pregunta")
            lpara("id_compespecifica") = ftempR.Item("id_compespecifica")
            lpara("id_grupo") = ftempR.Item("id_grupo")
            lpara("maximas") = ftempR.Item("maximas")
            lpara("minimas") = ftempR.Item("minimas")
            lpara("opcion_vertical") = ftempR.Item("opcion_vertical")
            lpara("instrucciones") = ftempR.Item("instrucciones")
            lpara("grupo_respuesta") = ftempR.Item("grupo_respuesta")
            cadena = "insert into evaluapreguntas(empresa,ciclo,tipotest,area,id_rasgo,numpregunta,pregunta,id_compespecifica,id_grupo,maximas,minimas,opcion_vertical,instrucciones,grupo_respuesta) values " +
                     "(@empresa,@ciclo,@tipotest,@area,@id_rasgo,@numpregunta,@pregunta,@id_compespecifica,@id_grupo,@maximas,@minimas,@opcion_vertical,@instrucciones,@grupo_respuesta)"
            cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
        Next

        cadena = "select empresa,ciclo,tipotest,numpregunta,numopcion,opcion,valor from evaluaopciones where ciclo=@cicloant"
        cm.llenaTabla(cadena, tbOpciones, ListaParametros(lpara))
        For Each ftempO As DataRow In tbOpciones.Rows
            lpara("tipotest") = ftempO.Item("tipotest")
            lpara("numpregunta") = ftempO.Item("numpregunta")
            lpara("numopcion") = ftempO.Item("numopcion")
            lpara("opcion") = ftempO.Item("opcion")
            lpara("valor") = ftempO.Item("valor")
            cadena = "insert into evaluaopciones(empresa,ciclo,tipotest,numpregunta,numopcion,opcion,valor) values " +
                     "(@empresa,@ciclo,@tipotest,@numpregunta,@numopcion,@opcion,@valor)"
            cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
        Next

    End Sub


    Private Sub btnMigrar_Click(sender As Object, e As EventArgs) Handles btnMigrar.Click
        Dim cm As New cmodelo(_conexionAcademia)
        Dim tbmigracion As New DataTable("migracion")
        Dim tbDatos2 As New DataTable("datos2")

        lpara("empresa") = empresa
        lpara("ciclo") = txtCiclo.Text
        lpara("cicloant") = CStr(CInt(txtCiclo.Text) - 1)
        Dim pregunta As String
        Dim mensaje As String = ""
        Try
            cadena = "select empresa,tipotest,ciclo,nombre,id_instrumento,grupo_asignacion,tipo from evaluatipotest where empresa=@empresa And ciclo=@cicloant"

            cm.llenaTabla(cadena, tbmigracion, ListaParametros(lpara))
            If tbmigracion.Rows.Count > 0 Then
                cadena = "select empresa,tipotest,ciclo,nombre,id_instrumento,grupo_asignacion,tipo from evaluatipotest where empresa=@empresa And ciclo=@ciclo"
                cm.llenaTabla(cadena, tbDatos2, ListaParametros(lpara))
                If tbDatos2.Rows.Count > 0 Then
                    pregunta = MsgBox("Ya existen evaluaciones deseas continuar con la migración", vbYesNo + vbQuestion, "Mensaje del sistema")
                    If pregunta = vbYes Then
                        cadena = "delete evalutatipotest where ciclo=@ciclo And empresa=@empresa"
                        cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                        cadena = "delete evaluapreguntas where empresa=@empresa and ciclo=@ciclo"
                        cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                        cadena = "delete evaluaopciones where empresa=@empresa and ciclo=@ciclo"
                        insercion_evaluacion(tbmigracion, cm)
                        mensaje = "Migración realizada con éxito!"
                    Else
                        mensaje = "Migración rechazada con éxito! "
                    End If
                Else

                    insercion_evaluacion(tbmigracion, cm)
                    mensaje = "Migración realizada con éxito!"
                End If
                If cm.Commit Then

                    MsgBox(mensaje, MsgBoxStyle.Information, "Mensaje del Sistema")
                End If

            Else
                MsgBox("No hay evaluaciones del ciclo anterior, consulte con el administrador", MsgBoxStyle.Information, "Mensaje del sistema")
                Return
            End If
        Catch ex As Exception
            cm.RollBack()
            MsgBox("Error: " + ex.Message, MsgBoxStyle.Critical, "Mensaje del sistema")
            Return
        End Try

    End Sub

    Private Sub txtCiclo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCiclo.Validated
        lpara.Clear()
        lpara("ciclo") = txtCiclo.Text
        If IsNumeric(txtCiclo.Text) Then
            Dim cdata As New cmodelo(_conexionAcademia)
            cadena = "select coalesce ( max(tipotest), 0) + 1 from evaluatipotest where ciclo = @ciclo"
            txtCodigo.Text = cdata.BuscaEscalar(cadena, ListaParametros(lpara))
            cdata.Commit()
        End If
        btnLimpiar_Click(sender, e)
    End Sub


End Class