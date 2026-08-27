Imports NOMINA

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMMUNICIPIOS.VB MIEMBRO DE NOMINA.SLN                                      **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmMunicipios
    Dim cadena As String
    Dim tbDepto As New DataTable("departamento")
    Dim tabla As New DataTable("Datos")
    Dim primeraves As Boolean = True
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim accion, ciclo As Int16
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmRutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario
        cadena = "select nombre, depto from departamentos order by depto "
        llena_combo(cadena, cmbDepartamento)
        llenaTabla(cadena, tbDepto)
        cmbDepartamento.Items.Add("")
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        accion = 0
        EnabilizarMenu(True)
        cmbDepartamento.Enabled = True
        textMunic.ReadOnly = False
        borra_Mejorado(gpDatos, ep1)
        cadena = "SELECT  m.depto, d.nombre, munic, m.nombre " & _
                 "FROM municipios m inner join departamentos d on m.depto=d.depto order by d.depto, m.munic "
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
            .Columns(1).Width = 150
            .Columns(2).HeaderText = "Municipio"
            .Columns(2).Width = 50
            .Columns(3).HeaderText = "Nombre"
            .Columns(3).Width = 306
            'AltoGridView(18, tabla, 292, 600, dgVista)
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
        cmbDepartamento.Focus()
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        lpara.Clear()
        If validetError(cmbDepartamento, ep1) = False Or validetError(TextNombre, ep1) = False Or
        validetError(TextNombre, ep1) = False Then
            Exit Sub
        End If
        lpara("depto") = tbDepto.Rows(cmbDepartamento.SelectedIndex).Item(1)
        lpara("munic") = textMunic.Text
        lpara("nombre") = TextNombre.Text
        Select Case accion
            Case 0
                cadena = "select count(*) from municipios where depto=@depto and munic=@munic"
                If BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                    MsgBox("CODIGO DEL MUNICIPIO YA EXISTE, VERIFIQUE", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    textMunic.Focus()
                    Exit Sub
                End If
                cadena = "insert municipios (depto,munic,nombre) 
                          values(@depto,@munic,@nombre)"
            Case 1
                cadena = "update municipios set nombre=@nombre where depto=@depto and munic=@munic"
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
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If BuscaEscalar("select dbo.NumeroMunicipio(" & filaTemp.Item(0) & "," & filaTemp.Item(2) & ")") > 0 Then
                    MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
                'verificar si tiene referencia en inscripciones
                lpara("depto") = filaTemp.Item(0)
                lpara("munic") = filaTemp.Item(2)
                cadena = "delete from municipios where depto=@depto and munic=@munic"
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
            cmbDepartamento.Enabled = False
            textMunic.ReadOnly = True
            f = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            BuscaElementoCombo(tbDepto, f.Item(0), cmbDepartamento, 1, False)
            textMunic.Text = f.Item(2)
            TextNombre.Text = f.Item(3)
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If

    End Sub


    Private Sub frmGeneral_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub


    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
       textMunic.Enter, TextNombre.Enter, cmbDepartamento.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub textMunic_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textMunic.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
         textMunic.Leave, TextNombre.Leave, cmbDepartamento.Leave
        desactiva(sender)
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub


End Class