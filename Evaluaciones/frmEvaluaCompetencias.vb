'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMEVALUACOMPETENCIAS.VB MIEMBRO DE NOMINA.SLN                              **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         08/10/2014                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmEvaluaCompetencias

    Private compe, accion As Int32
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmEvaluaCompetencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Private Sub grdCompetencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdCompetencia.Click
        If grdCompetencia.SelectedRows.Count > 0 Then
            If Int32.TryParse(grdCompetencia.SelectedRows(0).Cells(1).Value.ToString(), compe) Then
                accion = 1
                txtNombre.Text = grdCompetencia.SelectedRows(0).Cells(2).Value.ToString()
                btnEliminar.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not txtNombre.Text.Equals("") Then
            Dim conexion As New DbConexion()
            Dim cadena As String = ""
            lpara.Clear()
            lpara("nombre") = txtNombre.Text.ToUpper()
            lpara("compe") = compe
            Select Case accion
                Case 0
                    cadena = "insert into evaluacompetencias(nombre) values (@nombre)"
                Case 1
                    cadena = "update evaluacompetencias set nombre = @nombre where id_compespecifica = @compe"
            End Select
            conexion.ejecutarSentencia(cadena, ListaParametros(lpara))
            Select Case accion
                Case 0
                    InsertBitacora(9, 1, Me.Text)
                Case 1
                    InsertBitacora(9, 2, Me.Text)
            End Select
            Limpiar()
        Else
            MsgBox("NO HA INGRESADO UN NOMBRE PARA LA COMPETENCIA.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        lpara.Clear()
        lpara("compe") = compe
        If grdCompetencia.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                'verificar si tiene referencia en inscripciones
                Dim conexion As New DbConexion()
                Dim cadena As String = "delete from evaluacompetencias where id_compespecifica =@compe "
                conexion.ejecutarSentencia(cadena, ListaParametros(lpara))
                InsertBitacora(9, 4, Me.Text)
                Limpiar()
            End If
        Else
            MsgBox("DEBE SELECCIONAR UN REGISTRO PARA ELIMINAR.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub Llenar_Grid_EvaluaCompetencia()
        Dim conexion As New DbConexion()
        Dim cadena As String = "select ROW_NUMBER() OVER(ORDER BY id_compespecifica) as num, id_compespecifica, nombre from evaluacompetencias"
        grdCompetencia.DataSource = conexion.Hacer_Consulta(cadena).Tables("Consulta")
        With grdCompetencia
            .Columns("id_compespecifica").Visible = False
            .Columns("num").HeaderText = "NUMERO"
            .Columns("num").Width = 60
            .Columns("nombre").HeaderText = "NOMBRE"
            .Columns("nombre").Width = 350
        End With
    End Sub

    Private Sub Limpiar()
        Llenar_Grid_EvaluaCompetencia()
        txtNombre.Text = Nothing
        btnEliminar.Enabled = False
        compe = 0
        accion = 0
    End Sub

    Private Sub GrdCompetencia_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCompetencia.CellEnter
        If grdCompetencia.SelectedRows.Count > 0 Then
            grdCompetencia.Rows(grdCompetencia.SelectedRows(0).Index).Selected = True
        End If
    End Sub

End Class