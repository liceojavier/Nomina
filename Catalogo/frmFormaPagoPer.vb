Imports NOMINA

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMFORMAPAGOPER.VB MIEMBRO DE NOMINA.SLN                                    **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmFormaPagoPer
    Dim cadena As String
    Dim tabla As New DataTable("Datos")
    Dim primeraves As Boolean = True
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim accion, ciclo As Int16
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmRutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario
        TextNombEmpresa.Text = BuscaEscalar("select nombre from Empresas where empresa=" & empresa)
        cadena = "select b2.banco,  b1.nombre + ' CTA ' + b2.cta from bancos b1 inner join bancoscta b2 on b1.empresa=b2.empresa and b1.codigo=b2.codigo " &
                 "where b2.empresa=" & empresa & " and tipo=1 order by b2.banco"
        llena_comboDoble(cadena, cmbConxBanco, cmbNombBanco)
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lpara.Clear()
        lpara("empresa") = empresa
        accion = 0
        EnabilizarMenu(True)
        borra_Mejorado(gpDatos, ep1)
        cadena = "SELECT f.fpago, f.nombre, case when tipoforma='C' then  'CHEQUE' " &
                 "when tipoforma='D'  then'DEPOSITO' when tipoforma='E' then 'EFECTIVO' END as nombTipo, " &
                 "f.tipoforma, f.banco, 
                  case when f.banco > 0 then  b.nombre + ' CTA ' + bc.cta else '' end as nombBanco " &
                 " FROM formapagoper f inner join bancoscta bc on bc.empresa=f.empresa and bc.banco=f.banco " &
                 " inner join bancos b on b.empresa=f.empresa and b.codigo=bc.codigo " &
                 " where f.empresa=@empresa order by fpago"
        llenaTabla(cadena, tabla, ListaParametros(lpara))
        dgDatos.DataSource = tabla
        Vista(dgDatos)
        If tabla.Rows.Count > 0 Then
            MueveScrollView(dgDatos, tabla.Rows.Count - 1)
        End If
        textnum.Text = BuscaEscalar("select coalesce( max(fpago), 0) from formapagoper where empresa=@empresa", ListaParametros(lpara)) + 1
        EnabilizarMenu(True)
    End Sub

    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(0).HeaderText = "Código"
            .Columns(0).FillWeight = 10
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).FillWeight = 35
            .Columns(2).HeaderText = "Tipo"
            .Columns(2).FillWeight = 20
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).HeaderText = "Cuenta bancaria"
            .Columns(5).FillWeight = 35
            'AltoGridView(18, tabla, 292, 611, dgVista)
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
        Dim tipo As String = ""
        If validetError(textnum, ep1) = False Or validetError(TextNombre, ep1) = False Or
           validetError(cmbTipo, ep1) = False Or validetError(cmbConxBanco, ep1) = False Then
            Exit Sub
        End If
        Select Case cmbTipo.SelectedIndex
            Case 0
                tipo = "C"
            Case 1
                tipo = "D"
            Case 2
                tipo = "E"
        End Select

        Dim banco As Int32 = 0
        Int32.TryParse(cmbConxBanco.Text, banco)
        Dim modelo As New cmodelo
        lpara("empresa") = empresa
        lpara("fpago") = textnum.Text.Trim
        lpara("nombre") = TextNombre.Text
        lpara("tipoForma") = tipo
        lpara("banco") = banco.ToString()
        Try

            Select Case accion
                Case 0
                    cadena = "insert formapagoper (empresa,fpago,nombre,tipoforma,banco) values(@empresa,@fpago,@nombre,@tipoForma,@banco)"
                Case 1
                    cadena = "update formapagoper set nombre=@nombre, tipoforma=@tipoForma, banco=@banco where fpago=@fpago and empresa=@empresa"
            End Select
            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
            Select Case accion
                Case 0
                    InsertBitacora(9, 1, $"INGRESO FORMA DE PAGO {TextNombEmpresa.Text}")
                Case 1
                    InsertBitacora(9, 2, $"MODIFICACIÓN FORMA DE PAGO {TextNombEmpresa.Text}")
            End Select
            If modelo.Commit() Then
                MessageBox.Show("Operación realizada con exito", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnLimpiar_Click(sender, e)
            End If

        Catch ex As Exception
            MsgBox("Error del Sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            modelo.RollBack()
        End Try
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub MnuElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        Dim filaTemp As DataRow
        lpara.Clear()
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            lpara("fpago") = filaTemp.Item(0)
            lpara("empresa") = empresa
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If BuscaEscalar("select count(*) from contratos1 where fpago=@fpago and empresa=@empresa", ListaParametros(lpara)) > 0 Then
                    MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
                'verificar si tiene referencia en inscripciones
                Dim modelo As New cmodelo
                Try
                    cadena = "delete from formapagoper where fpago=@fpago and empresa=@empresa"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    InsertBitacora(9, 4, Me.Text)
                    If modelo.Commit() Then
                        MessageBox.Show("Operación realizada con exito", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        btnLimpiar_Click(sender, e)
                    End If

                Catch ex As Exception
                    MsgBox("Mensaje del Sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
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
            textnum.Text = f.Item(0)
            TextNombre.Text = f.Item(1)
            Select Case f.Item(3)
                Case "C"
                    cmbTipo.SelectedIndex = 0
                Case "D"
                    cmbTipo.SelectedIndex = 1
                Case "E"
                    cmbTipo.SelectedIndex = 2
            End Select
            cmbConxBanco.SelectedIndex = cmbConxBanco.FindStringExact(f.Item(4).ToString.Trim)
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


    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textnum.Enter, _
         TextNombre.Enter, cmbConxBanco.Enter, cmbNombBanco.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub cmbConsuBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombBanco.SelectedIndexChanged, _
    cmbConxBanco.SelectedIndexChanged
        AlinearCombos(sender, cmbConxBanco, cmbNombBanco)
    End Sub


    Private Sub cmbConxBanco_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbConxBanco.Validated
        ComboCambio(cmbConxBanco)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textnum.Leave, _
         TextNombre.Leave, cmbConxBanco.Leave, cmbNombBanco.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub



  
End Class