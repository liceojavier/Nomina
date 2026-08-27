Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMPERMISOSUSUARIOS.VB MIEMBRO DE NOMINA.SLN                                **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmPermisosUsuarios
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim WithEvents fEmp As frmMuestra2Columnas
    Dim cadena As String
    Dim tabla As New DataTable("Datos")
    Dim tbmodulo As New DataTable("modulo")
    Dim tbempleado As New DataTable("empleado")
    Dim tbrol As New DataTable("rol")
    Dim filatemp As DataRow
    Dim primeraves As Boolean = True
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim accion, ciclo As Int16
    Dim lpara As New Dictionary(Of String, Object)

#Region "EMPLEADO"

    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        If valbool = True Then
            textConxEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Integer
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombreEmple.Text.Trim
        cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and nombre like '%' + @nombre + '%'  order by nombre"
        numFilas = llenaTabla(cadena, tbempleado, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            textConxEmpleado.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filatemp = tbempleado.Rows.Item(0)
            textConxEmpleado.Text() = filatemp.Item(0)
            textNombreEmple.Text = filatemp.Item(1)
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textConxEmpleado.Text.Trim
        If valida_tipo_Entero(textConxEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textConxEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and empleado=@empleado"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEmpleado(False)
                dr.Read()
                textNombreEmple.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraEmpleado(True)
            textConxEmpleado.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textConxEmpleado.Validated
        If textConxEmpleado.Text.Trim <> "" Then
            ValidaEmpleado()
        Else
            BorraEmpleado(False)
        End If
    End Sub

    Private Sub EnBuscaEmpleado()
        fEmp = New frmMuestra2Columnas
        fEmp.TopMost = True
        fEmp.inicializa(tbempleado, "CODIGO", "NOMBRE", 0)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosEmpleados
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filatemp = tbempleado.Rows.Item(e.va2)
        textConxEmpleado.Text() = filatemp.Item(0)
        textNombreEmple.Text = filatemp.Item(1)
    End Sub


#End Region

    Private Sub frmPermisosUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario
        btn_limpiar_Click(sender, e)
    End Sub

    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 50
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 200
            .Columns(2).HeaderText = "Módulo"
            .Columns(2).Width = 150
            .Columns(2).HeaderText = "Rol"
            .Columns(2).Width = 100
            'AltoGridView(18, tabla, 292, 552, dgVista)
        End With
    End Sub


    Private Sub EnabilizarMenu(ByVal valB As Boolean)
        btn_agregar.Enabled = valB
        btn_modificar.Enabled = valB
        btn_eliminar.Enabled = valB
        gpDatos.Enabled = Not valB
    End Sub


    Private Sub frmTipoEventos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub textRegion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumero(sender, e)
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs)
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub


    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        accion = 0
        EnabilizarMenu(True)
        borra_Mejorado(gpDatos, ep1)
        cadena = "select a.id_empleado,d.apellido1+' '+d.apellido2+' '+d.nombre1+' '+d.nombre2 as nombre," & _
                 " c.nombre as modulo,b.nombre as rol,c.idtipomodulo,b.id_rol from permiso_siaco a " & _
                 " inner join rol_siaco b on a.id_rol=b.id_rol " & _
                 " inner join tipomodulo c on b.idtipomodulo=c.idtipomodulo " & _
                 " inner join emplegen d on a.id_empleado=d.empleado order by d.apellido1,d.apellido2,d.nombre1,d.nombre2 "

        llenaTabla(cadena, tabla)
        dgDatos.DataSource = tabla
        dgDatos.Columns(3).Visible = False
        Vista(dgDatos)
        If tabla.Rows.Count > 0 Then
            MueveScrollView(dgDatos, tabla.Rows.Count - 1)
        End If
        EnabilizarMenu(True)
        cadena = "select nombre,idtipomodulo from tipomodulo order by nombre"
        llena_combo(cadena, cmbModulo)
        llenaTabla(cadena, tbmodulo)

    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        EnabilizarMenu(False)
        textConxEmpleado.Focus()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Dim f As DataRow
        If dgDatos.SelectedRows.Count > 0 Then
            accion = 1
            EnabilizarMenu(False)
            f = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            textConxEmpleado.Text = f.Item(0)
            textNombreEmple.Text = f.Item(1)
            cmbModulo.Text = f.Item(1)
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Dim filaTemp As DataRow
        lpara.Clear()
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            lpara("rol") = filaTemp.Item(5)
            lpara("empleado") = filaTemp.Item(0)
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                'verificar si tiene referencia en inscripciones
                cadena = "delete from permiso_siaco where id_rol=@rol and id_empleado=@empleado"
                EjecutarQuery(cadena, ListaParametros(lpara))
                InsertBitacora(9, 4, Me.Text)
                btn_limpiar_Click(sender, e)
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        lpara.Clear()
        If Not validetError(textConxEmpleado, ep1) Or Not validetError(textNombreEmple, ep1) Or
           Not validetError(cmbModulo, ep1) Or Not validetError(cmbrol, ep1) Then
            Exit Sub
        End If
        lpara("empleado") = textConxEmpleado.Text
        lpara("rol") = tbrol.Rows(cmbrol.SelectedIndex).Item("id_rol")
        Select Case accion
            Case 0
                If BuscaEscalar("select count(*) from permiso_siaco") > 0 Then
                    MsgBox("YA EXITE UN USUARIO ASIGNADO A ESE ROL, POR FAVOR VERIFIQUE", MsgBoxStyle.Critical, "Información del Sistema")
                    Exit Sub
                End If
                cadena = "insert into permiso_siaco (id_empleado,id_rol) values (@empleado,@rol)"
            Case 1
                cadena = "update permiso_siaco set id_empleado=@empleado, id_rol=@rol " &
                         " where id_empleado=@empleado and id_rol=@rol"
        End Select
        EjecutarQuery(cadena, ListaParametros(lpara))
        Select Case accion
            Case 0
                InsertBitacora(9, 1, Me.Text)
            Case 1
                InsertBitacora(9, 2, Me.Text)
        End Select
        btn_limpiar_Click(sender, e)
    End Sub

    Private Sub cmbModulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModulo.SelectedIndexChanged
        lpara.Clear()
        lpara("modulo") = tbmodulo.Rows(cmbModulo.SelectedIndex).Item("idtipomodulo")
        cadena = "select nombre,id_rol from rol_siaco where idtipomodulo=@modulo order by id_rol"
        llena_combo(cadena, cmbrol, ListaParametros(lpara))
        llenaTabla(cadena, tbrol, ListaParametros(lpara))
    End Sub
End Class