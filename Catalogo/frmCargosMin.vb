Imports NOMINA

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCARGOSMIN.VB MIEMBRO DE NOMINA.SLN                                       **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmCargosMin
    Dim cadena As String
    Dim tabla As New DataTable("Datos")
    Dim primeraves As Boolean = True
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim accion, ciclo As Int16
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmRutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        accion = 0
        EnabilizarMenu(True)
        borra_Mejorado(gpDatos, ep1)
        cadena = "SELECT cargo, nombre " & _
       "FROM cargosmin order by cargo "
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
            .Columns(0).HeaderText = "Cargo"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 406
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
        textnum.ReadOnly = False
        textnum.Focus()
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        lpara.Clear()
        If validetError(textnum, ep1) = False Or validetError(TextNombre, ep1) = False Then
            Exit Sub
        End If
        Dim modelo As New cmodelo
        lpara("cargo") = textnum.Text.Trim
        lpara("nombre") = TextNombre.Text
        Try
            Select Case accion
                Case 0
                    cadena = "select count(*) from cargosmin where cargo=@cargo"
                    If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                        MsgBox("CODIGO DE CARGO YA EXISTE, VERIFIQUE", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                        textnum.Focus()
                        Exit Sub
                    End If
                    cadena = "insert cargosmin(cargo,nombre) values(@cargo,@nombre)"
                Case 1
                    cadena = "update cargosmin set nombre=@nombre where cargo=@cargo"
            End Select
            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
            modelo.Commit()
            Select Case accion
                Case 0
                    InsertBitacora(9, 1, Me.Text)
                Case 1
                    InsertBitacora(9, 2, Me.Text)
            End Select
        Catch ex As Exception
            MsgBox("Error del Sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            modelo.RollBack()
        End Try
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub MnuElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        Dim filaTemp As DataRow
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            lpara("cargo") = filaTemp.Item(0)
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If BuscaEscalar("select count(*) from puestosper where cargo=@cargo", ListaParametros(lpara)) > 0 Then
                    MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
                Dim modelo As New cmodelo
                'verificar si tiene referencia en inscripciones
                Try
                    lpara.Clear()
                    lpara("cargo") = filaTemp.Item(0)
                    cadena = "delete from cargosmin where cargo=@cargo"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    modelo.Commit()
                    InsertBitacora(9, 4, Me.Text)
                    btnLimpiar_Click(sender, e)
                Catch ex As Exception
                    MsgBox("Error del Sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                    modelo.RollBack()
                End Try
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
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

    Private Sub DgDatos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.CellEnter
        If dgDatos.SelectedRows.Count > 0 Then
            dgDatos.Rows(dgDatos.SelectedRows(0).Index).Selected = True
        End If
    End Sub

  
End Class