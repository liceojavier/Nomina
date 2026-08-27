Imports NOMINA

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMTIPOSUSPENSION.VB MIEMBRO DE NOMINA.SLN                                  **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmTiposSuspension
    Dim cadena As String
    Dim tabla As New DataTable("Datos")
    Dim primeraves As Boolean = True
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim accion, ciclo As Int16
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmRutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario
        btnLimpiar_Click(sender, e)
        cmbUsa.SelectedIndex = 0
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        accion = 0
        EnabilizarMenu(True)
        borra_Mejorado(gpDatos, ep1)
        cadena = "SELECT tiposus, nombre, nomina, por " &
                 "FROM TIPOSUSPENSIONES order by tiposus "
        llenaTabla(cadena, tabla)
        dgDatos.DataSource = tabla
        Vista(dgDatos)
        If tabla.Rows.Count > 0 Then
            MueveScrollView(dgDatos, tabla.Rows.Count - 1)
        End If
        textnum.Text = BuscaEscalar("select coalesce(max(tiposus), 0) from TIPOSUSPENSIONES ") + 1
        EnabilizarMenu(True)
    End Sub

    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(0).HeaderText = "Tipo"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 250
            .Columns(2).HeaderText = "Nómina"
            .Columns(2).Width = 70
            .Columns(3).HeaderText = "Porcentaje"
            .Columns(3).Width = 85
            'AltoGridView(18, tabla, 292, 552, dgVista)
        End With
    End Sub


    Private Sub EnabilizarMenu(ByVal valB As Boolean)
        ctxAgregar.Enabled = valB
        ctxModificar.Enabled = valB
        ctxEliminar.Enabled = valB
        gpDatos.Visible = Not valB
    End Sub

    Private Sub mnuAgrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAgregar.Click
        EnabilizarMenu(False)
        TextNombre.Focus()
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        lpara.Clear()
        If validetError(textnum, ep1) = False Or validetError(TextNombre, ep1) = False Or validetError(cmbUsa, ep1) = False Then
            Exit Sub
        End If
        If cmbUsa.SelectedIndex = 0 Then
            If Not validetError(TextPor, ep1) Then
                Exit Sub
            ElseIf CInt(TextPor.Text) <= 0 Or CInt(TextPor.Text) > 100 Then
                MsgBox("EL PORCENTAJE DEBE SER MAYOR QUE 0 Y MENOR QUE 100 ", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If
        ElseIf TextPor.Text.Trim <> "" Then
            If CInt(TextPor.Text) <= 0 Or CInt(TextPor.Text) > 100 Then
                MsgBox("EL PORCENTAJE DEBE SER MAYOR QUE 0 Y MENOR QUE 100 ", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If
        ElseIf TextPor.Text.Trim = "" Then
            TextPor.Text = 0
        End If
        lpara("tiposus") = textnum.Text
        lpara("nombre") = TextNombre.Text
        lpara("nomina") = cmbUsa.Text
        lpara("por") = TextPor.Text
        Select Case accion
            Case 0
                cadena = "insert TIPOSUSPENSIONES (tiposus,nombre,nomina,por) values(@tiposus,@nombre,@nomina,@por)"
            Case 1
                cadena = "update TIPOSUSPENSIONES set nombre=@nombre, nomina=@nomina, por=@por where tiposus=@tiposus"
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

    Private Sub MnuElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        Dim filaTemp As DataRow
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            lpara("tiposus") = filaTemp.Item(0)
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If BuscaEscalar("select count(*) from SUSPENSIONES where tiposus=@tiposus", ListaParametros(lpara)) > 0 Then
                    MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
                'verificar si tiene referencia en inscripciones
                cadena = "delete from TIPOSUSPENSIONES where tiposus=@empresa"
                EjecutarQuery(cadena, ListaParametros(lpara))
                InsertBitacora(9, 4, Me.Text)
                btnLimpiar_Click(sender, e)
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub


    Private Sub MnuModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click
        Dim f As DataRow
        If dgDatos.SelectedRows.Count > 0 Then
            accion = 1
            EnabilizarMenu(False)
            f = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            textnum.Text = f.Item(0)
            TextNombre.Text = f.Item(1)
            cmbUsa.Text = f.Item(2).ToString.Trim
            TextPor.Text = f.Item(3)
            TextNombre.Focus()
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub


    Private Sub frmRutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub textRegion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextPor.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textnum.Enter, _
         TextNombre.Enter, cmbUsa.Enter, TextPor.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textnum.Leave, _
         TextNombre.Leave, cmbUsa.Leave, TextPor.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub



  
End Class