'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMTIPOEVENTOS.VB MIEMBRO DE NOMINA.SLN                                     **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmTipoCurso
    Dim cadena As String
    Dim tabla As New DataTable("Datos")
    Dim primeraves As Boolean = True
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim accion, ciclo As Int16
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmTipoCurso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        accion = 0
        EnabilizarMenu(True)
        borra_Mejorado(gpDatos, ep1)
        cadena = "SELECT id_curso, nombre,institucion " &
                 "FROM  nom_tipo_curso order by id_curso "
        llenaTabla(cadena, tabla)
        dgDatos.DataSource = tabla
        Vista(dgDatos)
        If tabla.Rows.Count > 0 Then
            MueveScrollView(dgDatos, tabla.Rows.Count - 1)
        End If
        EnabilizarMenu(True)
    End Sub

    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(0).HeaderText = "Tipo"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 206
            .Columns(2).HeaderText = "Institución"
            .Columns(2).Width = 200
            'AltoGridView(18, tabla, 292, 552, dgVista)
        End With
    End Sub


    Private Sub EnabilizarMenu(ByVal valB As Boolean)
        ctxAgregar.Enabled = valB
        ctxModificar.Enabled = valB
        ctxEliminar.Enabled = valB
        gpDatos.Visible = Not valB
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        lpara.Clear()
        If validetError(TextNombre, ep1) = False Then
            Exit Sub
        End If
        lpara("nombre") = TextNombre.Text
        lpara("institucion") = textInstitucion.Text
        lpara("curso") = textnum.Text.Trim
        Select Case accion
            Case 0
                cadena = "insert into nom_tipo_curso(nombre,institucion) values(@nombre,@institucion)"
            Case 1
                cadena = "update nom_tipo_curso set nombre=@nombre, institucion=@institucion where id_curso=@curso"
        End Select
        EjecutarQuery(cadena, ListaParametros(lpara))
        Select Case accion
            Case 0
                InsertBitacora(9, 1, Me.Text)
            Case 1
                InsertBitacora(9, 2, Me.Text)
        End Select
        btnLimpiar_Click(sender, e)
    End Sub


    Private Sub mnuAgrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAgregar.Click
        EnabilizarMenu(False)
        textnum.ReadOnly = True
        TextNombre.Focus()
    End Sub

    Private Sub MnuModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click
        Dim f As DataRow
        If dgDatos.SelectedRows.Count > 0 Then
            accion = 1
            textnum.ReadOnly = True
            EnabilizarMenu(False)
            f = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            textnum.Text = f.Item(0)
            TextNombre.Text = f.Item(1)
            textInstitucion.Text = f.Item(2)
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub MnuElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        Dim filaTemp As DataRow
        lpara.Clear()
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            lpara("curso") = filaTemp.Item(0)
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If BuscaEscalar("select count(*) from nom_curso_empleado where id_tipo_curso=@curso", ListaParametros(lpara)) > 0 Then
                    MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
                'verificar si tiene referencia en inscripciones
                cadena = "delete from nom_tipo_curso where id_curso=@curso"
                EjecutarQuery(cadena, ListaParametros(lpara))
                InsertBitacora(9, 4, Me.Text)
                btnLimpiar_Click(sender, e)
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If

    End Sub

    Private Sub frmTipoCurso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
End Class