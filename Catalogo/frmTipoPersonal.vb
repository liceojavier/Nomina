Imports NOMINA

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMTIPOPERSONAL.VB MIEMBRO DE NOMINA.SLN                                    **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmTipoPersonal
    Dim cadena As String
    Dim tabla As New DataTable("Datos")
    Dim tbBase As New DataTable("base")
    Dim primeraves As Boolean = True
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim accion, ciclo As Int16
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmRutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario
        lpara.Clear()
        lpara("empresa") = empresa
        TextNombEmpresa.Text = BuscaEscalar("select nombre from Empresas where empresa=@empresa", ListaParametros(lpara))
        cadena = "select case when tibase='H' then'HORAS' when tibase='D' then 'DIAS' end as nombBase, tibase from tiposbase where empresa=" & _
        empresa
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        llenaTabla(cadena, tbBase, ListaParametros(lpara))
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lpara.Clear()
        lpara("empresa") = empresa
        accion = 0
        EnabilizarMenu(True)
        numVaca.Value = 1
        borra_Mejorado(gpDatos, ep1)
        cadena = "SELECT tipoper, nombre,  case when tibase='H' THEN 'HORAS' when tibase='D' then 'DIAS' end as nombTípo, tibase, basevaca,cantvaca,prestaciones,pagonomina from tipopersonal where empresa=@empresa"
        llenaTabla(cadena, tabla, ListaParametros(lpara))
        dgDatos.DataSource = tabla
        Vista(dgDatos)
        If tabla.Rows.Count > 0 Then
            MueveScrollView(dgDatos, tabla.Rows.Count - 1)
        End If
        textnum.Text = BuscaEscalar("select coalesce( max(tipoper), 0) from tipopersonal where empresa=@empresa", ListaParametros(lpara)) + 1
        EnabilizarMenu(True)
    End Sub

    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(0).HeaderText = "Codigo"
            .Columns(0).Width = 60
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 130
            .Columns(2).HeaderText = "Tipo de base"
            .Columns(2).Width = 75
            .Columns(3).Visible = False
            .Columns(4).HeaderText = "Cantidad de mese laborados para tener derecho a vacaciones"
            .Columns(4).Width = 140
            .Columns(5).HeaderText = "Cantidad de días de vacaciones"
            .Columns(5).Width = 90
            .Columns(6).HeaderText = "Se le pagan prestaciones"
            .Columns(6).Width = 100
            .Columns(7).HeaderText = "Genera nómina"
            .Columns(7).Width = 100
            'AltoGridView(18, tabla, 292, 742, dgVista)
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
           validetError(cmbTipo, ep1) = False Or validetError(TextCantVaca, ep1) = False Or
           validetError(cmbPrestaciones, ep1) = False Or validetError(cmbPagaNomina, ep1) = False Then
            Exit Sub
        End If

        If CInt(TextCantVaca.Text) <= 0 Then
            MsgBox("CANTIDAD DE VACACIONES NO PUEDE SER 0", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        tipo = tbBase.Rows(cmbTipo.SelectedIndex).Item(1)
        lpara("empresa") = empresa
        lpara("tipoper") = textnum.Text
        lpara("nombre") = TextNombre.Text
        lpara("tipo") = tipo
        lpara("basevaca") = numVaca.Text
        lpara("cantvaca") = TextCantVaca.Text
        lpara("prestaciones") = cmbPrestaciones.Text
        lpara("pagoNomina") = cmbPagaNomina.Text
        Select Case accion
            Case 0
                cadena = "insert tipopersonal (empresa,tipoper,nombre,tibase,basevaca,cantvaca, prestaciones,pagonomina) 
                          values(@empresa,@tipoper,@nombre,@tipo,@basevaca,@cantvaca,@prestaciones,@pagoNomina)"
            Case 1
                cadena = "update tipopersonal set nombre=@nombre, tibase=@tipo, basevaca=@basevaca, cantvaca=@cantvaca, prestaciones=@prestaciones,pagonomina=@pagoNomina where tipoper=@tipoper and empresa=@empresa"
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
            lpara("tipoper") = filaTemp.Item(0)
            lpara("empresa") = empresa
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If BuscaEscalar("select count(*) from contratos1 where tipoper=@tipoper and empresa=@empresa", ListaParametros(lpara)) > 0 Then
                    MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
                'verificar si tiene referencia en inscripciones
                cadena = "delete from tipopersonal where tipoper=@tipoper and empresa=@empresa"
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
            BuscaElementoCombo(tbBase, f.Item(3), cmbTipo, 1, False)
            numVaca.Text = f.Item(4)
            TextCantVaca.Text = f.Item(5)
            cmbPrestaciones.SelectedIndex = cmbPrestaciones.FindStringExact(f.Item(6))
            cmbPagaNomina.SelectedIndex = cmbPagaNomina.FindStringExact(f.Item(7))
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
         TextNombre.Enter, cmbTipo.Enter, TextCantVaca.Enter, cmbPrestaciones.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub TextBaseVaca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    TextCantVaca.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textnum.Leave, _
         TextNombre.Leave, cmbTipo.Leave, TextCantVaca.Leave, cmbPrestaciones.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class