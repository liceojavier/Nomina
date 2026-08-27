Imports NOMINA
Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMTIPOPRESTAMO.VB MIEMBRO DE NOMINA.SLN                                    **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmTipoPrestamo
    Dim cadena As String
    Dim tabla As New DataTable("Datos")
    Dim primeraves As Boolean = True
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim accion, ciclo As Int16
    Dim comando As New SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim WithEvents fEmp As frmMuestra2Columnas
    Dim tbCodigo As New DataTable("codigo")
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmRutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulari
        TextNombEmpresa.Text = BuscaEscalar("select nombre from Empresas where empresa=@empresa", ListaParametros(lpara))
        btnLimpiar_Click(sender, e)
    End Sub


#Region "TRANSACCION"


    Private Sub BorraCodigo(ByVal valbool As Boolean)
        textNombCodigo.Clear()
        If valbool = True Then
            textCodigo.Clear()
        End If
    End Sub


    Private Sub btnCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaCodigo.Click
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombCodigo.Text.Trim
        Dim numFilas As Int32
        cadena = "select transac, nombre from tipotran where empresa=@empresa and nombre like '%' + @nombre + '%' and tipomov='D' and formacal='FM'  order by transac"
        numFilas = llenaTabla(cadena, tbCodigo, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TRANSACCIONES CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCodigo(True)
            textCodigo.Focus()
        ElseIf numFilas = 1 Then
            BorraCodigo(True)
            filaTemp = tbCodigo.Rows.Item(0)
            textCodigo.Text() = filaTemp.Item(0)
            textNombCodigo.Text = filaTemp.Item(1)
            btnAgregar.Focus()
        Else
            EnBuscaCodigo()
        End If
    End Sub

    Private Sub ValidaCodigo()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("transac") = textCodigo.Text.Trim
        If valida_tipo_Entero(textCodigo.Text, 1) = True Then
            If BuscaEscalar("select count (*) from tipotran where empresa=@empresa and transac=@transac", ListaParametros(lpara)) = 0 Then
                MsgBox("TRANSACCION NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraCodigo(True)
                textCodigo.Focus()
                Exit Sub
            End If
            cadena = "select transac, nombre from tipotran where empresa=@empresa and transac=@transac and tipomov='D'AND formacal='FM' "
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraCodigo(False)
                dr.Read()
                textNombCodigo.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                btnAgregar.Focus()
            Else
                dr.Close()
                cn.Close()
                MsgBox("TRANSACCION NO VALIDA", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                BorraCodigo(True)
            End If
        Else
            MsgBox("TRANSACCION POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraCodigo(True)
            textCodigo.Focus()
        End If
    End Sub

    Private Sub TextCodigo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textCodigo.Validated
        If textCodigo.Text.Trim <> "" Then
            ValidaCodigo()
        Else
            BorraCodigo(False)
        End If
    End Sub

    Private Sub EnBuscaCodigo()
        fEmp = New frmMuestra2Columnas
        fEmp.TopMost = True
        fEmp.inicializa(tbCodigo, "TRANSACCION", "NOMBRE", 0)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosMonitor
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        btnAgregar.Focus()
    End Sub

    Private Sub ActualizacionDatosMonitor(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCodigo(True)
        filaTemp = tbCodigo.Rows.Item(e.va2)
        textCodigo.Text() = filaTemp.Item(0)
        textNombCodigo.Text = filaTemp.Item(1)
    End Sub




#End Region



    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lpara.Clear()
        lpara("empresa") = empresa
        accion = 0
        EnabilizarMenu(True)
        borra_Mejorado(gpDatos, ep1)
        cadena = "SELECT t.tipopre, t.nombre, t.transac, ti.nombre " &
                 " FROM tiposprestamo t INNER JOIN  tipotran ti on t.empresa=ti.empresa and t.transac=ti.transac " &
                 " where t.empresa=@empresa order by tipopre"
        llenaTabla(cadena, tabla, ListaParametros(lpara))
        dgDatos.DataSource = tabla
        Vista(dgDatos)
        If tabla.Rows.Count > 0 Then
            MueveScrollView(dgDatos, tabla.Rows.Count - 1)
        End If
        textnum.Text = BuscaEscalar("select coalesce( max(tipopre), 0) from tiposprestamo where empresa=@empresa", ListaParametros(lpara)) + 1
        EnabilizarMenu(True)
    End Sub

    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 50
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 299
            .Columns(2).HeaderText = "Transacción"
            .Columns(2).Width = 85
            .Columns(3).HeaderText = "Nombre"
            .Columns(3).Width = 238
            'AltoGridView(18, tabla, 292, 719, dgVista)
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
            validetError(textCodigo, ep1) = False Then
            Exit Sub
        End If
        lpara("empresa") = empresa
        lpara("tipopre") = textnum.Text
        lpara("nombre") = TextNombre.Text
        lpara("transac") = textCodigo.Text
        Select Case accion
            Case 0
                cadena = "insert tiposprestamo (empresa,tipopre,nombre,transac) values(@empresa,@tipopre,@nombre,@transac)"
            Case 1
                cadena = "update tiposprestamo set nombre=@nombre, transac=@transac where tipopre=@tipopre and empresa=@empresa"
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
        lpara.Clear()
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            lpara("tipopre") = filaTemp.Item(0)
            lpara("empresa") = empresa
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If BuscaEscalar("select count(*) from prestamos1 where tipopre=@tipopre and empresa=@empresa", ListaParametros(lpara)) > 0 Then
                    MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
                'verificar si tiene referencia en inscripciones
                cadena = "delete from tiposprestamo where tipopre=@tipopre and empresa=@empresa"
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
            textCodigo.Text = f.Item(2)
            If textCodigo.Text <> "" Then
                ValidaCodigo()
            End If
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
        TextNombre.Enter, textCodigo.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub textPorcentaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumeroDec(sender, e)
    End Sub


    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textnum.Leave, _
         TextNombre.Leave, textCodigo.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub





End Class