Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMLISTADOEVALUACIONASIGNACION.VB MIEMBRO DE NOMINA.SLN                            **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         08/09/2014                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmListadoEvaluacionAsignacion
    Dim cadena As String
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim tbTipo As New DataTable("tipo")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbConsulta As New DataTable("consulta")
    Dim filaTemp As DataRow
    Dim tabla As New DataTable("Datos")
    Dim v As ReportClass
    Dim primeraves As Boolean = True
    Dim accion, ciclo As Int16
    Dim WithEvents fEmp As frmMuestraCodigos
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim codigo As Int32
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmEvaluacionAsignacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario

        lpara.Clear()
        btnLimpiar_Click(sender, e)
        txtCiclo.Text = DateTime.Now.ToString("yyyy")
        llenaTipotest(txtCiclo.Text)

    End Sub


    Private Sub llenaTipotest(ciclo As String)
        Dim modacad As New modAcademia
        lpara("ciclo") = ciclo
        cadena = "select nombre,tipotest from evaluatipotest where ciclo=@ciclo "
        modacad.llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        modacad.llena_combo(cadena, cmbTipoTest, ListaParametros(lpara))
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        accion = 0
        borra_Mejorado(gpEmpleado, ep1)
        borra_Mejorado(gpEvaluador, ep1)
        cmbTipoTest.SelectedIndex = -1
        rbAsignados.Checked = True
        crv.ReportSource = Nothing
        gpEmpleado.Enabled = True
        gpEvaluador.Enabled = True
        'pnDetalle.Enabled = False
        tabla.Rows.Clear()
    End Sub

    Private Sub btnLimpiar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        accion = 0
        codigo = 0
        borra_Mejorado(gpEmpleado, ep1)
        borra_Mejorado(gpEvaluador, ep1)
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        lpara.Clear()
        Dim filtro As String = ""
        Me.Cursor = Cursors.WaitCursor
        Dim modacad As New modAcademia
        If validetError(txtCiclo, ep1) = False Then
            Exit Sub
        End If

        'cadena = "create view v_evaluacion_maestros as"



        If txtCodEmpleado.Text <> "" Then
            lpara("empleado") = txtCodEmpleado.Text
            filtro = filtro & " and a.empleado=@empleado "
        End If
        If txtCodigoEva.Text <> "" Then
            lpara("evaluador") = txtCodigoEva.Text
            filtro = filtro & " and a.evaluador=@evaluador "
        End If
        If cmbTipoTest.SelectedIndex <> -1 Then
            lpara("tipotest") = tbTipo.Rows(cmbTipoTest.SelectedIndex).Item("tipotest")
            filtro = filtro & " and a.tipotest=@tipotest "

        End If

        lpara("empresa") = empresa
        lpara("ciclo") = txtCiclo.Text
        If rbFaltaEvaluar.Checked = True Then
            filtro = filtro & " and b.empleado is null "
            cadena = " select  " &
                     " a.tipotest,e.nombre," &
                     " a.empleado,c.apellido1+' '+c.apellido2+' '+c.nombre1+' '+c.nombre2 as nomempleado, " &
                     " a.evaluador,d.apellido1+' '+d.apellido2+' '+d.nombre1+' '+d.nombre2 as nomevaluador " &
                     " from evaluatipo_asignacion a " &
                     " left join evaluatest1 b on a.empresa=b.empresa and a.ciclo=b.ciclo and a.tipotest=b.tipotest and a.empleado=b.empleado " &
                     " and a.evaluador=b.emevaluador" &
                     " inner join emplegen c on a.empresa=c.empresa and a.empleado=c.empleado " &
                     " inner join emplegen d on a.empresa=d.empresa and a.evaluador=d.empleado " &
                     " inner join evaluatipotest e on a.ciclo=e.ciclo and a.tipotest=e.tipotest " &
                     " where a.ciclo =@ciclo and a.empresa=@empresa "
        ElseIf rbAsignados.Checked Then
            cadena = " select  " &
                     " a.tipotest,e.nombre," &
                     " a.empleado,c.apellido1+' '+c.apellido2+' '+c.nombre1+' '+c.nombre2 as nomempleado, " &
                     " a.evaluador,d.apellido1+' '+d.apellido2+' '+d.nombre1+' '+d.nombre2 as nomevaluador " &
                     " from evaluatipo_asignacion a " &
                     " inner join emplegen c on a.empresa=c.empresa and a.empleado=c.empleado " &
                     " inner join emplegen d on a.empresa=d.empresa and a.evaluador=d.empleado " &
                     " inner join evaluatipotest e on a.ciclo=e.ciclo and a.tipotest=e.tipotest " &
                     " where a.ciclo =@ciclo and a.empresa=@empresa "

        ElseIf rbEvaluados.Checked Then

            cadena = " select  " &
                     " a.tipotest,e.nombre," &
                     " a.empleado,c.apellido1+' '+c.apellido2+' '+c.nombre1+' '+c.nombre2 as nomempleado, " &
                     " a.evaluador,d.apellido1+' '+d.apellido2+' '+d.nombre1+' '+d.nombre2 as nomevaluador " &
                     " from evaluatipo_asignacion a " &
                     " inner join evaluatest1 b on a.empresa=b.empresa and a.ciclo=b.ciclo and a.tipotest=b.tipotest and a.empleado=b.empleado " &
                     " and a.evaluador=b.emevaluador" &
                     " inner join emplegen c on a.empresa=c.empresa and a.empleado=c.empleado " &
                     " inner join emplegen d on a.empresa=d.empresa and a.evaluador=d.empleado " &
                     " inner join evaluatipotest e on a.ciclo=e.ciclo and a.tipotest=e.tipotest " &
                     " where a.ciclo =@ciclo and a.empresa=@empresa "
        ElseIf rbTotales.Checked = True Then
            cadena = " select a.tipotest,a.nombre,a.total_evaluados,isnull(b.falta_evaluar,0) as falta_evaluar,c.total_asignados from " &
                     " (select a.tipotest,c.nombre,count(*) as total_evaluados,'' as falta_evaluar,'' as total_asignados from evaluatipo_asignacion a " &
                     " inner join evaluatest1 b on a.empresa=b.empresa and a.ciclo=b.ciclo and a.tipotest=b.tipotest and a.empleado=b.empleado " &
                     " and a.evaluador=b.emevaluador " &
                     " inner join evaluatipotest c on a.ciclo=c.ciclo and b.tipotest=c.tipotest " &
                     " where a.ciclo = @ciclo And a.empresa = @empresa  group by a.tipotest,c.nombre) as a " &
                     " left Join " &
                     " (select a.tipotest,c.nombre,'' as total_evaluados,count(*) as falta_evaluar,'' as total_asignados from evaluatipo_asignacion a " &
                     " left join evaluatest1 b on a.empresa=b.empresa and a.ciclo=b.ciclo and a.tipotest=b.tipotest and a.empleado=b.empleado " &
                     " and a.evaluador=b.emevaluador " &
                     " inner join evaluatipotest c on a.ciclo=c.ciclo and a.tipotest=c.tipotest " &
                     " where a.ciclo =@ciclo And a.empresa = 1 And b.empleado Is null " &
                     " group by a.tipotest,c.nombre) as b on a.tipotest=b.tipotest " &
                     " inner Join " &
                     " (select tipotest,'' as total_evaluados,'' as falta_evaluar,count(*) total_asignados from evaluatipo_asignacion " &
                     " where ciclo = @ciclo And empresa = @empresa  " &
                     " group by tipotest) as c on a.tipotest=c.tipotest "
        End If
        cadena = cadena & filtro
        If rbOrdenEvaluado.Checked And (rbEvaluados.Checked = True Or rbFaltaEvaluar.Checked = True Or rbAsignados.Checked = True) Then
            cadena = cadena & " order by a.tipotest,c.apellido1,c.apellido2,c.nombre1,c.nombre2,d.apellido1,d.apellido2,d.nombre1,d.nombre2 "
        ElseIf rbOrdenEvaluador.Checked And (rbEvaluados.Checked = True Or rbFaltaEvaluar.Checked = True Or rbAsignados.Checked = True) Then
            cadena = cadena & " order by a.tipotest,d.apellido1,d.apellido2,d.nombre1,d.nombre2,c.apellido1,c.apellido2,c.nombre1,c.nombre2 "
        Else
            cadena = cadena & " order by a.tipotest asc"
        End If

        Me.Cursor = Cursors.Default

        If rbEvaluados.Checked = True Or rbFaltaEvaluar.Checked = True Or rbAsignados.Checked = True Then
            v = New Cryevaluacion_maestros
        Else
            v = New Cryevaluacion_maestros_totales
        End If
        Try
            modacad.llenaTabla(cadena, tbConsulta, ListaParametros(lpara))

            v.SetDataSource(tbConsulta)
            Me.Cursor = Cursors.WaitCursor
            If rbAsignados.Checked = True Then
                'v.SetParameterValue("subtitulo", "Colaboradores Asignados")
            ElseIf rbEvaluados.Checked = True Then
                'v.SetParameterValue("subtitulo", "Colaboradores Evaluados")
            ElseIf rbFaltaEvaluar.Checked = True Then
                'v.SetParameterValue("subtitulo", "Colaboradores que faltan de Evaluar")
            End If
            crv.ReportSource = v
            'crv.Refresh()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR EL REPORTE " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default
        InsertBitacora(9, 1, Me.Text)
        btnLimpiar2_Click(sender, e)

    End Sub

    Private Sub frmRutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub textRegion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCiclo.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCiclo.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCiclo.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub txtCiclo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCiclo.TextChanged
        lpara.Clear()

        If txtCiclo.Text.Length = 4 Then

            btnLimpiar_Click(sender, e)
            lpara("ciclo") = txtCiclo.Text
            cadena = "select nombre,tipotest from evaluatipotest where ciclo=@ciclo "
            llena_combo(cadena, cmbTipoTest, ListaParametros(lpara))
            llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        End If
    End Sub

#Region "EMPLEADO"

    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        txtNomEmpleado.Clear()
        If valbool = True Then
            txtCodEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = txtNomEmpleado.Text.Trim
        If txtNomEmpleado.Text.Trim <> "" Then
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and nombre like '%' + @nombre + '%'  order by nombre"
        Else
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa order by nombre"
        End If
        numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            txtCodEmpleado.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            txtCodEmpleado.Text() = filaTemp.Item(0)
            txtNomEmpleado.Text = filaTemp.Item(1)
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = txtCodEmpleado.Text.Trim
        If valida_tipo_Entero(txtCodEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                txtCodEmpleado.Focus()
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
                txtNomEmpleado.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraEmpleado(True)
            txtCodEmpleado.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodEmpleado.Validated
        If txtCodEmpleado.Text.Trim <> "" And txtCodEmpleado.ReadOnly = False Then
            ValidaEmpleado()
        ElseIf txtCodEmpleado.ReadOnly = False Then
            BorraEmpleado(False)
        End If
    End Sub

    Private Sub EnBuscaEmpleado()
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosEmpleados
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        txtCodEmpleado.Text() = filaTemp.Item(0)
        txtNomEmpleado.Text = filaTemp.Item(1)
    End Sub

    Private Sub BorraEvaluador(ByVal valbool As Boolean)
        txtNombreEva.Clear()
        If valbool = True Then
            txtCodigoEva.Clear()
        End If
    End Sub


    Private Sub btnEvaluador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEvaluador.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = txtNombreEva.Text.Trim
        If txtNomEmpleado.Text.Trim <> "" Then
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and nombre like '%' + @nombre + '%'  order by nombre"
        Else
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa  order by nombre"
        End If
        numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEvaluador(True)
            txtCodigoEva.Clear()
        ElseIf numFilas = 1 Then
            BorraEvaluador(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            txtCodigoEva.Text() = filaTemp.Item(0)
            txtNombreEva.Text = filaTemp.Item(1)
        Else
            EnBuscaEvaluador()
        End If
    End Sub

    Private Sub ValidaEvaluador()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = txtCodigoEva.Text.Trim
        If valida_tipo_Entero(txtCodEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEvaluador(True)
                txtCodigoEva.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and empleado=@empleado"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEvaluador(False)
                dr.Read()
                txtNombreEva.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraEvaluador(True)
            txtCodigoEva.Focus()
        End If
    End Sub

    Private Sub txtNombreEva_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoEva.Validated
        If txtCodigoEva.Text.Trim <> "" And txtCodigoEva.ReadOnly = False Then
            ValidaEvaluador()
        ElseIf txtCodigoEva.ReadOnly = False Then
            BorraEvaluador(False)
        End If
    End Sub

    Private Sub EnBuscaEvaluador()
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosEvaluador
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosEvaluador(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEvaluador(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        txtCodigoEva.Text() = filaTemp.Item(0)
        txtNombreEva.Text = filaTemp.Item(1)
    End Sub

#End Region

    Private Sub rbTotales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTotales.CheckedChanged
        If rbTotales.Checked = True Then
            gpEmpleado.Enabled = False
            gpEvaluador.Enabled = False
        End If

    End Sub

    Private Sub rbAsignados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAsignados.CheckedChanged
        If rbAsignados.Checked = True Then
            gpEmpleado.Enabled = True
            gpEvaluador.Enabled = True
        End If
    End Sub

    Private Sub rbEvaluados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbEvaluados.CheckedChanged
        If rbEvaluados.Checked = True Then
            gpEmpleado.Enabled = True
            gpEvaluador.Enabled = True
        End If
    End Sub

    Private Sub pnDetalle_Paint(sender As Object, e As PaintEventArgs) Handles pnDetalle.Paint

    End Sub

    Private Sub rbFaltaEvaluar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFaltaEvaluar.CheckedChanged
        If rbFaltaEvaluar.Checked = True Then
            gpEmpleado.Enabled = True
            gpEvaluador.Enabled = True
        End If
    End Sub
End Class