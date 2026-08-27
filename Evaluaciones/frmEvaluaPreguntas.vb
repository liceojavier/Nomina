Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMEVALUAPREGUNTAS.VB MIEMBRO DE NOMINA.SLN                                 **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         09/10/2014                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmEvaluaPreguntas

    Private tipotest, area, pregunta, _accion As Int32
    Private WithEvents fEmp As frmMuestraCodigos
    Private tbTipoEvaluacion As New DataTable("tipoevaluacion")
    Private tbArea As New DataTable("area")
    Private filaTemp As DataRow
    Private lpara As New Dictionary(Of String, Object)
    Dim cmodel As New cmodelo2(_conexionAcademia)

    Private Sub frmEvaluaPreguntas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Private Sub btnAsignarTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarTE.Click
        Dim cadena As String = ""

        If Not txtCodigoTE.Text.Equals("") And Not txtNombreTE.Text.Equals("") Then
            lpara.Clear()

            If (Int32.TryParse(txtCodigoTE.Text, tipotest)) Then

                lpara("ciclo") = txtCiclo.Text
                lpara("tipotest") = txtCodigoTE.Text
                cadena = "declare @total int; 
                      set @total=0; 
                      set @total = @total + (select count(*) from evaluatest1 where ciclo=@ciclo and tipotest=@tipotest);
                      set @total = @total + (select count(*) from evadoctest1 where ciclo=@ciclo and tipotest=@tipotest);
                      select @total;"
                Dim cuenta As Int32 = cmodel.BuscaEscalar(cadena, ListaParametros(lpara))
                If cuenta > 0 Then
                    MsgBox("Tipo de Evaluación ya posee resultados, por lo que no se puede modificar, verifique", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    gbPregunta.Enabled = False
                Else
                    gbPregunta.Enabled = True
                End If

                limpia_detalle(True)
                gbPregunta.Enabled = True
                Llenar_Grid_Preguntas()
                Llenar_Combo_Competencia()
                Llenar_Combo_Grupo()
                Llenar_Combo_Rasgo()
                txtCiclo.ReadOnly = True
                txtCodigoTE.ReadOnly = True
            Else
                MsgBox("FORMATO INVALIDO PARA EL CODIGO DEL TIPO DE EVALUACIÓN.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            End If
        Else
            MsgBox("NO HA INGRESADO UN TIPO DE EVALUACIÓN.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub txtCiclo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCiclo.KeyPress, txtNumLinea.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub txtCiclo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCiclo.TextChanged
        If txtCiclo.Text.Length = 4 And tipotest <> 0 And area <> 0 Then
            Llenar_Grid_Preguntas()
        Else
            grdPreguntas.DataSource = Nothing
        End If
    End Sub



    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        lpara.Clear()
        If validetError(txtPregunta, ep) And validetError(txtNumLinea, ep) And validetError(cmbCompetencia, ep) And validetError(cmbRasgo, ep) Then
            Dim cadena As String = ""
            Dim num_linea As Integer = 0
            Dim conexion As New DbConexion(_conexionAcademia)
            Dim vertical As Int32 = Convert.ToInt32(chkVertical.Checked)

            lpara("empresa") = empresa
            lpara("ciclo") = txtCiclo.Text
            lpara("tipotest") = tipotest
            lpara("numpregunta") = CInt(txtNumLinea.Text)
            lpara("area") = cmbCompetencia.SelectedValue
            lpara("pregunta") = txtPregunta.Text
            lpara("opcion_vertical") = vertical
            lpara("instrucciones") = txtInstrucciones.Text
            lpara("id_rasgo") = cmbRasgo.SelectedValue
            lpara("maximas") = nudMax.Value.ToString()
            lpara("minimas") = txtOpMin.Text
            Select Case _accion
                Case 0

                    If Int32.TryParse(txtNumLinea.Text, num_linea) Then
                        cadena = "Select count(*) from evaluapreguntas where empresa=@empresa And ciclo=@ciclo and tipotest=@tipotest and numpregunta=@numpregunta"
                        Dim num As Int32 = 0
                        Int32.TryParse(conexion.regresaEscalar(cadena, ListaParametros(lpara)).ToString(), num)
                        If num = 0 Then

                            cadena = "insert into evaluapreguntas(empresa, ciclo, tipotest, area,numpregunta, pregunta, id_compespecifica, id_grupo, opcion_vertical, instrucciones,id_rasgo,maximas,minimas) " &
                                     "values (@empresa,@ciclo,@tipotest,@area,@numpregunta,@pregunta,0,0,@opcion_vertical,@instrucciones,@id_rasgo,@maximas,@minimas)"
                        Else
                            MsgBox("NÚMERO DE PREGUNTA YA INGRESADO, VERIFIQUE", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                            Exit Sub
                        End If
                    End If

                Case 1
                    lpara("pregunta1") = pregunta
                    cadena = "update evaluapreguntas set pregunta=@pregunta, id_compespecifica = @area " &
                             ", id_grupo = 0, opcion_vertical=@opcion_vertical, instrucciones=@instrucciones " &
                             ", area=@area, id_rasgo=@id_rasgo , maximas=@maximas " &
                             " where empresa=@empresa and ciclo=@ciclo and tipotest=@tipotest and numpregunta =@pregunta1 "
            End Select
            If conexion.ejecutarSentencia(cadena, ListaParametros(lpara)) Then
                Select Case _accion
                    Case 0
                        InsertBitacora(9, 1, $"Creación de pregunta {num_linea} tipo test { tipotest} ciclo {txtCiclo.Text}")
                    Case 1
                        InsertBitacora(9, 2, $"Modificación de pregunta {num_linea} tipo test { tipotest} ciclo {txtCiclo.Text}")
                End Select
            End If
            Llenar_Grid_Preguntas()
            limpia_detalle(True)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        If grdPreguntas.Rows.Count > 0 Then
            If grdPreguntas.SelectedRows.Count > 0 Then
                If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                    'verificar si tiene referencia en inscripciones
                    Dim conexion As New cmodelo(_conexionAcademia)
                    Dim cadena As String
                    lpara.Clear()
                    lpara("id_pregunta") = grdPreguntas.SelectedRows.Item(0).Cells("id_pregunta").Value
                    cadena = "delete evaluapreguntas where id_pregunta=@id_pregunta "
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
                            tbdata.Rows(i)("num") = i + 1
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

    Private Sub ctxModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click
        _accion = 1
        lbMensaje.Text = "Modificación de registro"
        grdPreguntas_Click(sender, e)
    End Sub

    Private Sub grdPreguntas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPreguntas.Click
        If grdPreguntas.SelectedRows.Count > 0 And _accion = 1 Then
            If Int32.TryParse(grdPreguntas.SelectedRows(0).Cells(2).Value.ToString(), pregunta) Then
                txtNumLinea.Text = grdPreguntas.SelectedRows(0).Cells("num").Value.ToString()
                txtPregunta.Text = grdPreguntas.SelectedRows(0).Cells("pregunta").Value.ToString()
                txtInstrucciones.Text = grdPreguntas.SelectedRows(0).Cells("instrucciones").Value.ToString()
                chkVertical.Checked = Convert.ToBoolean(grdPreguntas.SelectedRows(0).Cells("opcion_vertical").Value)
                Seleccionar_Index_Combo(cmbCompetencia, Convert.ToInt32(grdPreguntas.SelectedRows(0).Cells("area").Value.ToString()))
                Seleccionar_Index_Combo(cmbGrupo, Convert.ToInt32(grdPreguntas.SelectedRows(0).Cells("id_grupo").Value.ToString()))
                Seleccionar_Index_Combo(cmbRasgo, Convert.ToInt32(grdPreguntas.SelectedRows(0).Cells("id_rasgo").Value.ToString()))
                txtOpMin.Text = grdPreguntas.SelectedRows(0).Cells("minimas").Value.ToString()
                nudMax.Value = grdPreguntas.SelectedRows(0).Cells("maximas").Value.ToString()
            End If
        End If
    End Sub


    Private Sub Llenar_Grid_Preguntas()
        lpara.Clear()
        Dim conexion As New DbConexion(_conexionAcademia)
        Dim cadena As String  '"select row_number() over(order by ep.tipotest, ep.numpregunta) num, ep.area, ep.numpregunta, " _
        lpara("empresa") = empresa
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = tipotest
        cadena = "select ep.numpregunta as num, ep.area, " _
            & "ep.pregunta, isnull(ec.nombre, '') competencia, ep.id_grupo, isnull(eg.nombre, " _
            & "'') grupo,  er.id_rasgo, er.nombre as nombre_rasgo, ep.opcion_vertical, ep.instrucciones, minimas, maximas, ep.id_pregunta " _
            & "from evaluapreguntas ep " _
            & "inner join evalua_areas ec on  ep.empresa=ec.empresa and ec.area=ep.area " _
            & "inner join evalua_rasgos er on  er.id_rasgo=ep.id_rasgo " _
            & "left join evaluagrupo eg on ep.id_grupo = eg.id_grupo " _
            & "where ep.empresa=@empresa and ep.ciclo = @ciclo and ep.tipotest = @tipotest " &
              " order by num"
        grdPreguntas.DataSource = conexion.hacerConsulta(cadena, ListaParametros(lpara)).Tables("Consulta")
        With grdPreguntas
            .Columns("id_pregunta").Visible = False
            .Columns("num").Width = 70
            .Columns("num").HeaderText = "Número"

            .Columns("area").Visible = False

            .Columns("pregunta").Width = 300
            .Columns("pregunta").HeaderText = "Pregunta"
            .Columns("area").Visible = False
            .Columns("competencia").Width = 150
            .Columns("competencia").HeaderText = "Competencia"
            .Columns("competencia").ReadOnly = True
            .Columns("id_grupo").Visible = False
            .Columns("grupo").Width = 150
            .Columns("grupo").HeaderText = "Grupo"
            .Columns("grupo").ReadOnly = True
            .Columns("id_rasgo").Visible = False
            .Columns("nombre_rasgo").Width = 150
            .Columns("nombre_rasgo").HeaderText = "Rasgo"
            .Columns("nombre_rasgo").ReadOnly = True
            '.Columns("opcion_vertical").Visible = False
            .Columns("opcion_vertical").HeaderText = "Vertical"

            .Columns("instrucciones").Width = 400
            .Columns("instrucciones").HeaderText = "Instrucciones"
            .Columns("minimas").Width = 100
            .Columns("minimas").HeaderText = "No. Opc Min"
            .Columns("maximas").Width = 100
            .Columns("maximas").HeaderText = "No. Opc Max"
            .Columns("maximas").ReadOnly = True
        End With
    End Sub

    Private Sub Llenar_Combo_Competencia()
        cmbCompetencia.DataSource = Nothing
        Dim conexion As New DbConexion(_conexionAcademia)
        Dim cadena As String = "select area, nombre from evalua_areas where empresa = " & Definiciones.empresa _
                                & " order by area"
        Dim tabla As DataTable = conexion.Hacer_Consulta(cadena).Tables("Consulta")
        Llenar_Combo(cmbCompetencia, tabla)
    End Sub

    Private Sub Llenar_Combo_Grupo()
        cmbGrupo.DataSource = Nothing
        Dim conexion As New DbConexion(_conexionAcademia)
        Dim cadena As String = "select 0 id_grupo, '' nombre union all select id_grupo, nombre from evaluagrupo"
        Dim tabla As DataTable = conexion.Hacer_Consulta(cadena).Tables("Consulta")
        Llenar_Combo(cmbGrupo, tabla)
    End Sub

    Private Sub Llenar_Combo_Rasgo()
        cmbRasgo.DataSource = Nothing
        Dim conexion As New DbConexion(_conexionAcademia)
        Dim cadena As String = "select id_rasgo, nombre from evalua_rasgos order by id_rasgo"
        Dim tabla As DataTable = conexion.Hacer_Consulta(cadena).Tables("Consulta")
        Llenar_Combo(cmbRasgo, tabla)
    End Sub

    Private Sub Llenar_Combo(ByVal cmb As ComboBox, ByVal tabla As DataTable)
        cmb.DataSource = tabla
        cmb.DisplayMember = tabla.Columns(1).Caption.ToString()
        cmb.ValueMember = tabla.Columns(0).Caption.ToString()
    End Sub

    Private Sub Seleccionar_Index_Combo(ByVal cmb As ComboBox, ByVal valor As Int32)
        For i As Integer = 0 To cmb.Items.Count - 1 Step 1
            cmb.SelectedIndex = i
            If cmb.SelectedValue = valor Then
                Exit For
            End If
        Next
    End Sub




#Region "Métodos de limpieza"

    Private Sub Limpiar_Pregunta(reset As Boolean)
        If reset Then
            cmbCompetencia.SelectedIndex = -1
            cmbGrupo.SelectedIndex = -1
        End If

        txtPregunta.Text = Nothing
        txtInstrucciones.Text = Nothing
        chkVertical.Checked = False
        _accion = 0
        pregunta = 0
        txtPregunta.Focus()
    End Sub

    Private Sub Limpiar()
        txtCiclo.Text = DateTime.Now.ToString("yyyy")
        grdPreguntas.DataSource = Nothing
        cmbCompetencia.DataSource = Nothing
        cmbGrupo.DataSource = Nothing
        cmbRasgo.DataSource = Nothing

        txtCodigoTE.Text = Nothing

        txtNombreTE.Text = Nothing

        gbPregunta.Enabled = False
        tipotest = 0
        area = 0
        limpia_detalle(False)
        txtNumLinea.Text = ""
        nudMax.Value = 1
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        limpia_detalle(True)
    End Sub

    Private Sub limpia_detalle(ByVal busca_linea As Boolean)
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = tipotest
        If busca_linea Then
            Dim conexion As New DbConexion(_conexionAcademia)
            Dim cadena As String = ""
            cadena = "select isnull(max(numpregunta), 0) num from evaluapreguntas where empresa = @empresa and ciclo=@ciclo and tipotest=@tipotest group by tipotest"
            Dim num As Int32 = 0
            Dim numObj As Object = conexion.regresaEscalar(cadena, ListaParametros(lpara))
            If Not numObj Is Nothing Then
                If Int32.TryParse(numObj.ToString(), num) Then
                    txtNumLinea.Text = num + 1
                End If
            Else
                txtNumLinea.Text = num + 1
            End If
        End If
        _accion = 0
        lbMensaje.Text = "Ingreso de Registro"

        Limpiar_Pregunta(Not busca_linea)
    End Sub


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
        txtCiclo.ReadOnly = False
        txtCodigoTE.ReadOnly = False
    End Sub

#End Region
    

#Region "Tipo de Evaluacion"

    Private Sub BorraTipoEvaluacion(ByVal valbool As Boolean)
        txtNombreTE.Clear()
        If valbool = True Then
            txtCodigoTE.Clear()
        End If
    End Sub


    Private Sub BtnBuscarTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarTE.Click
        Dim numFilas As Int32
        Dim conexion As New DbConexion(_conexionAcademia)
        lpara.Clear()
        lpara("nombre") = txtNombreTE.Text.Trim()
        lpara("ciclo") = txtCiclo.Text
        Dim cadena As String = "select tipotest, nombre from evaluatipotest where nombre like '%' + @nombre + '%' and ciclo=@ciclo order by ciclo, tipotest"
        tbTipoEvaluacion = conexion.hacerConsulta(cadena, ListaParametros(lpara)).Tables("consulta")
        numFilas = tbTipoEvaluacion.Rows.Count
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TIPOS DE EVALUACION CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraTipoEvaluacion(True)
            txtCodigoTE.Clear()
        ElseIf numFilas = 1 Then
            BorraTipoEvaluacion(True)
            asigna_valores(tbTipoEvaluacion.Rows.Item(0))
        Else
            EnBuscaTipoEvaluacion()
        End If
    End Sub

    Private Sub ValidaTipoEvaluacion()
        lpara.Clear()
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = txtCodigoTE.Text.Trim()
        If valida_tipo_Entero(txtCodigoTE.Text, 2) = True Then
            Dim cadena As String = "select tipotest, nombre from evaluatipotest where ciclo =@ciclo and tipotest=@tipotest"
            Dim conexion As New DbConexion(_conexionAcademia)
            Dim tbConsulta As DataTable = conexion.hacerConsulta(cadena, ListaParametros(lpara)).Tables("consulta")
            If tbConsulta.Rows.Count > 0 Then
                BorraTipoEvaluacion(False)
                asigna_valores(tbConsulta.Rows(0))
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

    Private Sub btnGuardar2_Click(sender As Object, e As EventArgs) Handles btnGuardar2.Click
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
        asigna_valores(filaTemp)
    End Sub

    Private Sub asigna_valores(ByVal f As DataRow)
        txtCodigoTE.Text = f.Item("tipotest").ToString()
        txtNombreTE.Text = f.Item("nombre").ToString()
    End Sub


#End Region

  
 
End Class