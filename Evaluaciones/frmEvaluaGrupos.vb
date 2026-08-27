'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMEVALUAGRUPOSVB MIEMBRO DE NOMINA.SLN                                     **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         09/10/2014                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmEvaluaGrupos

    Private grupo, accion As Int32
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmEvaluaGrupos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Private Sub grdGrupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdGrupos.Click
        If grdGrupos.SelectedRows.Count > 0 Then
            If Int32.TryParse(grdGrupos.SelectedRows(0).Cells(1).Value.ToString(), grupo) Then
                accion = 1
                txtNombre.Text = grdGrupos.SelectedRows(0).Cells(2).Value.ToString()
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
            lpara("grupo") = grupo
            Select Case accion
                Case 0
                    cadena = "select isnull(max(id_grupo), 0) num from evaluagrupo"
                    Dim num As Int32 = 0
                    If Int32.TryParse(conexion.Hacer_Consulta(cadena).Tables("Consulta").Rows(0).Item(0).ToString(), num) Then
                        num += 1
                        lpara("num") = num

                        cadena = "insert into evaluagrupo(id_grupo, nombre) values (@num,@nombre)"
                    End If
                Case 1
                    cadena = "update evaluagrupo set nombre=@nombre where id_grupo=@grupo"
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
            MsgBox("NO HA INGRESADO UN NOMBRE PARA EL GRUPO.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        lpara.Clear()
        lpara("grupo") = grupo
        If grdGrupos.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                'verificar si tiene referencia en inscripciones
                Dim conexion As New DbConexion()
                Dim cadena As String = "delete from evaluagrupo where id_grupo =@grupo "
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

    Private Sub Llenar_Grd_EvaluaGrupos()
        Dim conexion As New DbConexion()
        Dim cadena As String = "select ROW_NUMBER() OVER(ORDER BY id_grupo) as num, id_grupo, nombre from evaluagrupo"
        grdGrupos.DataSource = conexion.Hacer_Consulta(cadena).Tables("Consulta")
        With grdGrupos
            .Columns("id_grupo").Visible = False
            .Columns("num").HeaderText = "Número"
            .Columns("num").Width = 60
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").Width = 350
        End With
    End Sub

    Private Sub Limpiar()
        Llenar_Grd_EvaluaGrupos()
        txtNombre.Text = Nothing
        btnEliminar.Enabled = False
        grupo = 0
        accion = 0
    End Sub

    Private Sub GrdGrupos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdGrupos.CellEnter
        If grdGrupos.SelectedRows.Count > 0 Then
            grdGrupos.Rows(grdGrupos.SelectedRows(0).Index).Selected = True
        End If
    End Sub

End Class