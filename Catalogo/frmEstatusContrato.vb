Imports NOMINA

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMESTATUSCONTRATO.VB MIEMBRO DE NOMINA.SLN                                 **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmEstatusContrato
    Dim cadena As String
    Dim tabla As New DataTable("Datos")
    Dim primeraves As Boolean = True
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim accion, ciclo As Int16
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmRutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario
        lpara.Clear()
        lpara("empresa") = empresa
        TextNombEmpresa.Text = BuscaEscalar("select nombre from Empresas where empresa=@empresa", ListaParametros(lpara))
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lpara.Clear()
        lpara("empresa") = empresa
        accion = 0
        EnabilizarMenu(True)
        borra_Mejorado(gpDatos, ep1)
        cmbActivo.Enabled = True
        cadena = "SELECT estado, nombre, activo, generapago " &
                 "FROM empestados where empresa=@empresa order by estado"
        llenaTabla(cadena, tabla, ListaParametros(lpara))
        dgDatos.DataSource = tabla
        Vista(dgDatos)
        If tabla.Rows.Count > 0 Then
            MueveScrollView(dgDatos, tabla.Rows.Count - 1)
        End If
        textNum.Text = BuscaEscalar("select coalesce (max(estado),0) from  empestados where empresa=@empresa", ListaParametros(lpara)) + 1
        EnabilizarMenu(True)
    End Sub

    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(0).HeaderText = "Estado"
            .Columns(0).Width = 75
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 225
            .Columns(2).HeaderText = "Activo"
            .Columns(2).Width = 103
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).HeaderText = "Genera pago"
            .Columns(3).Width = 103
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
        If validetError(textNum, ep1) = False Or validetError(TextNombre, ep1) = False Or
           validetError(cmbActivo, ep1) = False Or validetError(cmbPago, ep1) = False Then
            Exit Sub
        End If
        Dim modelo As New cmodelo
        lpara("empresa") = empresa
        lpara("estado") = textNum.Text
        lpara("nombre") = TextNombre.Text
        lpara("activo") = cmbActivo.Text
        lpara("generapago") = cmbPago.Text
        Try
            Select Case accion
                Case 0
                    cadena = "insert empestados (empresa,estado,nombre,activo,generapago) 
                              values(@empresa,@estado,@nombre,@activo,@generapago)"
                Case 1
                    cadena = "update empestados set nombre=@nombre,  activo=@activo, generapago=@generapago where estado=@estado and empresa=@empresa"
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
            lpara("estado") = filaTemp.Item(0)
            lpara("empresa") = empresa
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If BuscaEscalar("select count(*) from contratos1 where estado=@estado and empresa=@empresa", ListaParametros(lpara)) > 0 Then
                    MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
                Dim modelo As New cmodelo
                'verificar si tiene referencia en inscripciones
                Try
                    cadena = "delete from empestados where estado=@estado and empresa=@empresa"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    InsertBitacora(9, 4, Me.Text)
                    If modelo.Commit() Then
                        MessageBox.Show("Operación realizada con exito", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        btnLimpiar_Click(sender, e)
                    End If
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
            EnabilizarMenu(False)
            f = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            textNum.Text = f.Item(0)
            TextNombre.Text = f.Item(1)
            cmbActivo.SelectedIndex = cmbActivo.FindStringExact(f.Item(2))
            cmbPago.SelectedIndex = cmbPago.FindStringExact(f.Item(3))
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

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textNum.Enter, _
         TextNombre.Enter, cmbActivo.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textNum.Leave, _
         TextNombre.Leave, cmbActivo.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub
End Class