'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMROLSIACO.VB MIEMBRO DE NOMINA.SLN                                        **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmRolSiaco
    Dim cadena As String
    Dim tabla As New DataTable("Datos")
    Dim tbmodulo As New DataTable("modulo")
    Dim primeraves As Boolean = True
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim accion, ciclo As Int16
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmRolSiaco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario
        btn_limpiar_Click(sender, e)
    End Sub


    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 50
            .Columns(1).HeaderText = "Módulo"
            .Columns(1).Width = 289
            .Columns(2).HeaderText = "Rol"
            .Columns(2).Width = 150
            'AltoGridView(18, tabla, 292, 552, dgVista)
        End With
    End Sub


    Private Sub EnabilizarMenu(ByVal valB As Boolean)
        btn_agregar.Enabled = valB
        btn_modificar.Enabled = valB
        btn_eliminar.Enabled = valB
        gpDatos.Enabled = Not valB
    End Sub


    Private Sub frmTipoEventos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub textRegion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textnum.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textnum.Enter, _
         TextNombre.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textnum.Leave, _
         TextNombre.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub


    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        accion = 0
        EnabilizarMenu(True)
        borra_Mejorado(gpDatos, ep1)
        cadena = "select id_rol as codigo ,b.nombre as modulo, a.nombre as rol,a.idtipomodulo from rol_siaco a " & _
                 " inner join tipomodulo b on a.idtipomodulo=b.idtipomodulo "

        llenaTabla(cadena, tabla)
        dgDatos.DataSource = tabla
        dgDatos.Columns(3).Visible = False
        Vista(dgDatos)
        If tabla.Rows.Count > 0 Then
            MueveScrollView(dgDatos, tabla.Rows.Count - 1)
        End If
        EnabilizarMenu(True)
        cadena = "select nombre,idtipomodulo from tipomodulo order by nombre"
        llena_combo(cadena, cmbModulo)
        llenaTabla(cadena, tbmodulo)

    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        EnabilizarMenu(False)
        textnum.ReadOnly = True
        'textnum.Text = BuscaEscalar("select coalesce ( max(id_rol), 0) from rol_siaco ") + 1
        TextNombre.Focus()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Dim f As DataRow
        If dgDatos.SelectedRows.Count > 0 Then
            accion = 1
            textnum.ReadOnly = True
            EnabilizarMenu(False)
            f = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            textnum.Text = f.Item(0)
            TextNombre.Text = f.Item(2)
            cmbModulo.Text = f.Item(1)
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Dim filaTemp As DataRow
        lpara.Clear()
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            lpara("rol") = filaTemp.Item(0)
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If BuscaEscalar("select count(*) from permisos where id_rol=@rol", ListaParametros(lpara)) > 0 Or
                   BuscaEscalar("select count(*) from permisos2 where id_role=@rol", ListaParametros(lpara)) > 0 Or
                   BuscaEscalar("select count(*) from permiso_siaco where id_rol=@rol", ListaParametros(lpara)) > 0 Then
                    MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
                'verificar si tiene referencia en inscripciones
                cadena = "delete from rol_siaco where id_rol=@rol"
                EjecutarQuery(cadena, ListaParametros(lpara))
                InsertBitacora(9, 4, Me.Text)
                btn_limpiar_Click(sender, e)
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        lpara.Clear()
        If validetError(TextNombre, ep1) = False Then
            Exit Sub
        End If
        lpara("modulo") = tbmodulo.Rows(cmbModulo.SelectedIndex).Item("idtipomodulo")
        lpara("nombre") = TextNombre.Text
        lpara("rol") = textnum.Text.Trim
        Select Case accion
            Case 0
                cadena = "insert into rol_siaco (idtipomodulo,nombre) values (@modulo,@nombre)"
            Case 1
                cadena = "update rol_siaco set nombre=@nombre, idtipomodulo=@modulo where id_rol=@rol"
        End Select
        EjecutarQuery(cadena, ListaParametros(lpara))
        Select Case accion
            Case 0
                InsertBitacora(9, 1, Me.Text)
            Case 1
                InsertBitacora(9, 2, Me.Text)
        End Select
        btn_limpiar_Click(sender, e)
    End Sub
End Class