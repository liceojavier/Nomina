Imports NOMINA

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMTIPOBASE.VB MIEMBRO DE NOMINA.SLN                                        **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmTipoBase
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
        accion = 0
        EnabilizarMenu(True)
        borra_Mejorado(gpDatos, ep1)
        cmbTipo.Enabled = True
        lpara("empresa") = empresa
        cadena = "SELECT case when tibase='H' then 'HORAS' ELSE 'DIAS' end as nombTipo, tibase, " &
                 "convert( varchar, convert ( money, base),1) as base, convert ( varchar , convert ( money, horasdia), 1) as horasdia " &
                 "FROM tiposbase where empresa=@empresa order by tibase"
        llenaTabla(cadena, tabla, ListaParametros(lpara))
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
            .Columns(0).Width = 206
            .Columns(1).Visible = False
            .Columns(2).HeaderText = "Base máxima"
            .Columns(2).Width = 150
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).HeaderText = "Horas diarias"
            .Columns(3).Width = 150
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
        TextHorasDia.Focus()
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        lpara.Clear()
        Dim tipo As String
        Dim i As Int16
        Dim filaTemp As DataRow
        If validetError(textBase, ep1) = False Or validetError(TextHorasDia, ep1) = False Or
           validetError(cmbTipo, ep1) = False Then
            Exit Sub
        End If
        If CDec(TextHorasDia.Text) <= 0 Or CDec(textBase.Text) <= 0 Then
            MsgBox("VALORES DEBEN SER MAYORES QUE 0", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If

        If cmbTipo.SelectedIndex = 0 Then
            tipo = "H"
        Else
            tipo = "D"
        End If
        lpara("empresa") = empresa
        lpara("tipo") = tipo
        lpara("base") = CDec(textBase.Text)
        lpara("horasdia") = CInt(TextHorasDia.Text)
        Select Case accion
            Case 0
                For i = 0 To tabla.Rows.Count - 1
                    filaTemp = tabla.Rows(i)
                    If tipo = filaTemp.Item(1) Then
                        MsgBox("TIPO YA HA SIDO INGRESADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                        Exit Sub
                    End If
                Next i
                cadena = "insert tiposbase (empresa,tibase,base,horasdia) 
                          values(@empresa,@tipo,@base,@horasdia)"
            Case 1
                cadena = "update tiposbase set base=@base,  horasdia=@horasdia where tibase=@tipo and empresa=@empresa"
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
            lpara("tibase") = filaTemp.Item(1)
            lpara("empresa") = empresa
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If BuscaEscalar("select count(*) from tipopersonal where tibase=@tibase and empresa=@empresa", ListaParametros(lpara)) > 0 Then
                    MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
                'verificar si tiene referencia en inscripciones
                cadena = "delete from tiposbase where tibase=@tibase and empresa=@empresa"
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
            Select Case f.Item(1)
                Case "H"
                    cmbTipo.SelectedIndex = 0
                Case "D"
                    cmbTipo.SelectedIndex = 1
            End Select
            textBase.Text = f.Item(2)
            TextHorasDia.Text = f.Item(3)
            cmbTipo.Enabled = False
            cmbTipo.Focus()
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

    Private Sub textRegion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextHorasDia.KeyPress, _
    textBase.KeyPress
        soloNumeroDec(sender, e)
    End Sub


    Private Sub textBase_Validated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles textBase.Validated, TextHorasDia.Validated
        validatedDecimalPreci(sender, 4, 2)
    End Sub

    Private Sub DecimalEnt(ByVal sender As Object, ByVal e As System.EventArgs) Handles textBase.Enter, TextHorasDia.Enter
        EntraDecimal(sender)
    End Sub


    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textBase.Enter, _
         TextHorasDia.Enter, cmbTipo.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textBase.Leave, _
         TextHorasDia.Leave, cmbTipo.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub





End Class