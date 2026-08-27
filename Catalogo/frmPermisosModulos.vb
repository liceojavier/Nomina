'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMPERMISOSMODULOS.VB MIEMBRO DE NOMINA.SLN                                 **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmPermisosModulos
    Dim cadena As String
    Dim tabla As New DataTable("Datos")
    Dim tbmodulo As New DataTable("modulo")
    Dim tbrol As New DataTable("rol")
    Dim primeraves As Boolean = True
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim accion, ciclo As Int16
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmPermisosModulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario
        btn_limpiar_Click(sender, e)
    End Sub
#Region "formato datagridview"

    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 50
            .Columns(1).HeaderText = "Módulo"
            .Columns(1).Width = 135
            .Columns(2).HeaderText = "Forma"
            .Columns(2).Width = 135
            .Columns(3).HeaderText = "Opción ménu"
            .Columns(3).Width = 120
            .Columns(4).HeaderText = "Acceso"
            .Columns(4).Width = 55
            .Columns(5).HeaderText = "Opción forma"
            .Columns(5).Width = 115
            .Columns(6).HeaderText = "Observaciones"
            .Columns(6).Width = 100
            'AltoGridView(18, tabla, 292, 720, dgVista)
        End With
    End Sub
#End Region


    Private Sub EnabilizarMenu(ByVal valB As Boolean)
        btn_agregar.Enabled = valB
        btn_modificar.Enabled = valB
        btn_eliminar.Enabled = valB
        gpDatos.Enabled = Not valB
    End Sub

#Region "eventos"
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

    Private Sub cmbModulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModulo.SelectedIndexChanged
        lpara.Clear()
        lpara("idtipomodulo") = tbmodulo.Rows(cmbModulo.SelectedIndex).Item("idtipomodulo")
        cadena = "select nombre,id_rol from rol_siaco where idtipomodulo=@idtipomodulo order by id_rol"
        llena_combo(cadena, cmbRol, ListaParametros(lpara))
        llenaTabla(cadena, tbrol, ListaParametros(lpara))
    End Sub

#End Region


    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        accion = 0
        EnabilizarMenu(True)
        borra_Mejorado(gpDatos, ep1)
        cadena = "select a.id as codigo,c.nombre as modulo ,a.nombre_forma,a.opcion_menu," & _
                 " cast (acceso as bit) as acceso,a.opcion_forma,a.observaciones,b.idtipomodulo,b.id_rol,b.nombre " & _
                 " from permisos2 a " & _
                 " inner join rol_siaco b on a.id_role=b.id_rol " & _
                 " inner join tipomodulo c on b.idtipomodulo=c.idtipomodulo "

        llenaTabla(cadena, tabla)
        dgDatos.DataSource = tabla
        dgDatos.Columns(7).Visible = False
        dgDatos.Columns(8).Visible = False
        dgDatos.Columns(9).Visible = False
        Vista(dgDatos)
        If tabla.Rows.Count > 0 Then
            MueveScrollView(dgDatos, tabla.Rows.Count - 1)
        End If
        EnabilizarMenu(True)
        cadena = "select nombre,idtipomodulo from tipomodulo order by nombre"
        llena_combo(cadena, cmbModulo)
        llenaTabla(cadena, tbmodulo)
        cmbModulo.SelectedIndex = -1
        cmbRol.SelectedIndex = -1

    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        EnabilizarMenu(False)
        textnum.ReadOnly = True
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
            cmbModulo.Text = f.Item(1)
            TextNombre.Text = f.Item(2)
            TextnomOpcion.Text = f.Item(3)
            cbAcceso.Checked = f.Item(4)
            TextnomOpcionF.Text = f.Item(5)
            textObserva.Text = f.Item(6)
            cmbRol.Text = f.Item(9)
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        lpara.Clear()
        Dim filaTemp As DataRow
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then

                'verificar si tiene referencia en inscripciones
                lpara("id") = filaTemp.Item(0)
                cadena = "delete from permisos2 where id=@id"
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
        Dim vchkbox As Int16 = 0
        If Not validetError(TextNombre, ep1) Or Not validetError(TextnomOpcion, ep1) Or Not validetError(cmbModulo, ep1) _
        Or Not validetError(cmbRol, ep1) Then
            Exit Sub
        End If
        If cbAcceso.Checked = True Then vchkbox = 1 Else vchkbox = 0
        lpara("nombre_forma") = TextNombre.Text
        lpara("opcion_menu") = TextnomOpcion.Text
        lpara("acceso") = vchkbox
        lpara("opcion_forma") = TextnomOpcionF.Text
        lpara("observaciones") = textObserva.Text
        lpara("id") = textnum.Text.Trim
        Select Case accion
            Case 0
                cadena = "insert into permisos2(id_role,nombre_forma,opcion_menu,acceso,opcion_forma,observaciones) " &
                         " values(1,@nombre_forma,@opcion_menu,@acceso,@opcion_forma,@observaciones) "
            Case 1
                cadena = "update permisos2 set nombre_forma =@nombre_forma,opcion_menu=@opcion_menu,acceso=@acceso, opcion_forma=@opcion_forma, observaciones=@observaciones where id=@id"
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