Imports NOMINA

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMDEPARTAMENTOS.VB MIEMBRO DE NOMINA.SLN                                   **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmDepartamentos
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
        cadena = "SELECT depto, nombre, region, nomregion " & _
       "FROM DEPARTAMENTOS order by depto "
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
            .Columns(0).HeaderText = "Depto"
            .Columns(0).Width = 50
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 200
            .Columns(2).HeaderText = "Región"
            .Columns(2).Width = 50
            .Columns(3).HeaderText = "Nombre"
            .Columns(3).Width = 206
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
        If validetError(textnum, ep1) = False Or validetError(textnombre, ep1) = False Or
        validetError(textRegion, ep1) = False Or validetError(TextNombRegion, ep1) = False Then
            Exit Sub
        End If
        Dim modelo As New cmodelo
        lpara("depto") = textnum.Text.Trim
        lpara("nombre") = textnombre.Text
        lpara("region") = textRegion.Text
        lpara("nombregion") = TextNombRegion.Text
        Try
            Select Case accion
                Case 0
                    cadena = "select count(*) from departamentos where depto=@depto"
                    If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                        MsgBox("CODIGO DEL DEPARTAMENTO YA EXISTE, VERIFIQUE", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                        textnum.Focus()
                        Exit Sub
                    End If
                    cadena = "insert departamentos (depto,nombre,region,nomregion) 
                              values(@depto,@nombre,@region,@nombregion)"
                Case 1

                    cadena = "update departamentos set nombre=@nombre, region=@region, nomregion=@nombregion where depto=@depto"
            End Select
            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
            Select Case accion
                Case 0
                    InsertBitacora(9, 1, Me.Text)
                Case 1
                    InsertBitacora(9, 2, Me.Text)
            End Select
            If modelo.Commit() Then
                MessageBox.Show("Operación realizada con exito", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Error del Sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            modelo.RollBack()
        End Try
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub MnuElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        lpara.Clear()
        Dim filaTemp As DataRow
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If BuscaEscalar("select dbo.NumeroDepartamento (" & filaTemp.Item(0) & ")") > 0 Then
                    MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
                'verificar si tiene referencia en inscripciones
                lpara.Clear()
                lpara("depto") = filaTemp.Item(0)
                cadena = "delete from departamentos where depto=@depto"
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
            textnum.ReadOnly = True
            textnum.Text = f.Item(0)
            textnombre.Text = f.Item(1)
            textRegion.Text = f.Item(2)
            TextNombRegion.Text = f.Item(3)
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

    Private Sub textRegion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textRegion.KeyPress
        If Char.ToUpper(e.KeyChar) = "X" Or Char.ToUpper(e.KeyChar) = "I" Or Char.ToUpper(e.KeyChar) = "V" Or Char.ToUpper(e.KeyChar) = "L" Or _
       Char.ToUpper(e.KeyChar) = "C" Or Char.ToUpper(e.KeyChar) = "M" Or Char.ToUpper(e.KeyChar) = "D" Or Char.IsControl(e.KeyChar) Or _
        Char.IsSeparator(e.KeyChar) Then
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textnum.Enter, _
        textnombre.Enter, textRegion.Enter, TextNombRegion.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

   
    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textnum.Leave, _
        textnombre.Leave, textRegion.Leave, TextNombRegion.Leave
        desactiva(sender)
    End Sub

    Private Sub textnum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textnum.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub
End Class