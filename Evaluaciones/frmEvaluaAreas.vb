Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMEVALUAAREAS.VB MIEMBRO DE NOMINA.SLN                                     **
'**  AUTOR:         Ferenc Andor                                                            **
'**  FECHA:         08/10/2014                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmEvaluaAreas

    Private tipotest, accion, evaluaarea As Int32
    Private WithEvents fEmp As frmMuestraCodigos
    Private tbTipoEvaluacion As New DataTable("tipoevaluacion")
    Private filaTemp As DataRow
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmEvaluaAreas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Private Sub txtCiclo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtCiclo.Text.Length = 4 And tipotest <> 0 Then
            Llenar_Grid_EvaluaAreas()
        Else
            grdEvaluaArea.DataSource = Nothing
        End If
    End Sub

    Private Sub grdEvaluaArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdEvaluaArea.Click
        If grdEvaluaArea.SelectedRows.Count > 0 Then
            If Int32.TryParse(grdEvaluaArea.SelectedRows(0).Cells(1).Value.ToString(), evaluaarea) Then
                txtNombre.Text = grdEvaluaArea.SelectedRows(0).Cells(2).Value.ToString()
                accion = 1
                btnEliminar.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnAsignarTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarTE.Click
        If Not txtCodigoTE.Text.Equals("") And Not txtNombreTE.Text.Equals("") Then
            If (Int32.TryParse(txtCodigoTE.Text, tipotest)) Then
                btnGuardar.Enabled = True
                Llenar_Grid_EvaluaAreas()
            Else
                MsgBox("FORMATO INVALIDO PARA EL CODIGO DEL TIPO DE EVALUACIÓN.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            End If
        Else
            MsgBox("NO HA INGRESADO UN TIPO DE EVALUACIÓN.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If validetError(txtCiclo, ep1) AndAlso validetError(txtNombre, ep1) AndAlso validetError(txtCodigoTE, ep1) Then

            Dim cadena As String = ""
            Dim conexion As New DbConexion()
            lpara.Clear()
            lpara("empresa") = empresa
            lpara("ciclo") = txtCiclo.Text
            lpara("tipotest") = tipotest
            lpara("nombre") = txtNombre.Text.ToUpper()
            lpara("area") = evaluaarea
            Select Case accion
                Case 0
                    cadena = "select isnull(max(area), 0) area from evaluaareas where empresa = @empresa and ciclo = @ciclo and tipotest = @tipotest "
                    Dim num As Int32 = 0
                    If Int32.TryParse(conexion.hacerConsulta(cadena, ListaParametros(lpara)).Tables("Consulta").Rows(0).Item(0).ToString(), num) Then 'se cambio Hacer_Consulta por hacerConsulta cualquier problema regresa con Hacer_Consulta
                        num += 1
                        lpara("num") = num
                        cadena = "insert into evaluaareas(empresa, ciclo, tipotest, area, nombre, por) 
                                  values (@empresa,@ciclo,@tipotest,@num,@nombre, 0.00)"
                    End If
                Case 1
                    cadena = "update evaluaareas set nombre =@nombre  where empresa = @empresa and ciclo = @ciclo and tipotest = @tipotest and area = @area"
            End Select
            conexion.ejecutarSentencia(cadena, ListaParametros(lpara))
            Select Case accion
                Case 0
                    InsertBitacora(9, 1, $"Ingresa evaluaareas ciclo { txtCiclo.Text} tipotest { tipotest} nombre {txtNombre.Text.ToUpper()}")
                Case 1
                    InsertBitacora(9, 2, $"actualiza evaluaareas ciclo { txtCiclo.Text} tipotest { tipotest} nombre {txtNombre.Text.ToUpper()}")
            End Select
            Limpiar_EvaluaArea()
            Llenar_Grid_EvaluaAreas()
        Else
            MsgBox("Llene los campos necesarios.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If grdEvaluaArea.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                lpara.Clear()
                lpara("empresa") = empresa
                lpara("ciclo") = txtCiclo.Text
                lpara("tipotest") = tipotest
                lpara("area") = evaluaarea
                'verificar si tiene referencia en inscripciones
                Dim conexion As New DbConexion()
                Dim cadena As String = "delete from evaluaareas where empresa=@empresa and ciclo = @ciclo and tipotest = @tipotest and area = @area"
                conexion.ejecutarSentencia(cadena, ListaParametros(lpara))
                InsertBitacora(9, 4, $"Elimina registro evaluaarea  ciclo {txtCiclo.Text} tipotest { tipotest} area {area} ")
                Limpiar_EvaluaArea()
                Llenar_Grid_EvaluaAreas()
            End If
        Else
            MsgBox("DEBE SELECCIONAR UN ELEMENTO PARA ELIMINAR PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub Llenar_Grid_EvaluaAreas()
        Dim conexion As New DbConexion()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = tipotest
        Dim cadena As String = "select tipotest, area, nombre from evaluaareas where empresa=@empresa and ciclo = @ciclo"
        If tipotest > 0 Then
            cadena = cadena & " and tipotest =@tipotest "
        End If
        cadena = cadena & " order by ciclo, tipotest, area"
        Dim tabla As DataTable = conexion.hacerConsulta(cadena, ListaParametros(lpara)).Tables("Consulta")
        grdEvaluaArea.DataSource = tabla
        With grdEvaluaArea
            .Columns("tipotest").Visible = False
            .Columns("area").HeaderText = "Número"
            .Columns("area").Width = 100
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").Width = 350
        End With
    End Sub

    Private Sub Limpiar()
        grdEvaluaArea.DataSource = Nothing
        txtCiclo.Text = DateTime.Now.Year.ToString()
        btnGuardar.Enabled = False
        txtCodigoTE.Text = Nothing
        txtNombreTE.Text = Nothing
        tipotest = 0
        accion = 0
        Limpiar_EvaluaArea()
    End Sub

    Private Sub Limpiar_EvaluaArea()
        evaluaarea = 0
        btnEliminar.Enabled = False
        txtNombre.Text = Nothing
    End Sub

    Private Sub GrdEvaluaAreas_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdEvaluaArea.CellEnter
        If grdEvaluaArea.SelectedRows.Count > 0 Then
            grdEvaluaArea.Rows(grdEvaluaArea.SelectedRows(0).Index).Selected = True
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
        Dim cadena As String = "select tipotest, nombre from evaluatipotest where ciclo = @ciclo order by ciclo, tipotest"
        numFilas = llenaTabla(cadena, tbTipoEvaluacion, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TIPOS DE EVALUACION CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraTipoEvaluacion(True)
            txtCodigoTE.Clear()
        ElseIf numFilas = 1 Then
            BorraTipoEvaluacion(True)
            filaTemp = tbTipoEvaluacion.Rows.Item(0)
            txtCodigoTE.Text() = filaTemp.Item(0)
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
            Dim cadena As String = "select tipotest, nombre from evaluatipotest where ciclo =@ciclo and tipotest=@tipotest"
            abrir_conexion(cn)
            Dim comando As New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            Dim dr As SqlDataReader = comando.ExecuteReader
            If dr.HasRows() Then
                BorraTipoEvaluacion(False)
                dr.Read()
                txtNombreTE.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
            Else
                dr.Close()
                cn.Close()
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
        txtCodigoTE.Text() = filaTemp.Item(0)
        txtNombreTE.Text = filaTemp.Item(1)
    End Sub

#End Region

End Class