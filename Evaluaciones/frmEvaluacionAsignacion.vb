Imports System.Data.SqlClient
Imports NOMINA.controller
Imports DAL_Javier.controller

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMEVALUACIONASIGNACION.VB MIEMBRO DE NOMINA.SLN                            **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         21/08/2014                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmEvaluacionAsignacion
    Dim cadena As String
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim tbTipo As New DataTable("tipo")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")
    Dim tbConsulta As New DataTable("consulta")
    Dim tbImpresion As New DataTable("impresion")
    Dim filaTemp As DataRow
    Dim tabla As New DataTable
    Dim primeraves As Boolean = True
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim accion, ciclo As Int16
    Dim WithEvents fEmp As frmMuestraCodigos
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim codigo As Int32
    Dim ctrl As New EmpleadoController()
    Dim _fila As DataRow
    Dim listaEliminado As New List(Of Int32)
    Dim lpara As New Dictionary(Of String, Object)
    Private Sub frmEvaluacionAsignacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llama a los principales procedimientos que se ejecutan durante la utilizacion del formulario
        btnLimpiar_Click(sender, e)
        txtCiclo.Text = DateTime.Now.ToString("yyyy")

        Dim tbEmp As DataTable = ctrl.GetEmpleados(empresa)
        EmpleadoDgvCC.DataSource = tbEmp
        EmpleadoDgvCC.DisplayMember = "nombre"
        EmpleadoDgvCC.ValueMember = "empleado"
        EvaluadorDgvCC.DataSource = tbEmp
        EvaluadorDgvCC.DisplayMember = "nombre"
        EvaluadorDgvCC.ValueMember = "empleado"
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        accion = 0
        borra_Mejorado(gpEmpleado, ep1)
        borra_Mejorado(gpContrato, ep1)
        borra_Mejorado(gpEvaluador, ep1)
        borra_Mejorado(gpContratoEva, ep1)
        borra_Mejorado(gpTipoEvaluacion, ep1)
        dgDatos.ReadOnly = True

        '   EnabilizarMenu(True)
        gpTipoEvaluacion.Enabled = True
        pnDetalle.Enabled = False
        btnGuardar.Enabled = False
        tabla.Rows.Clear()
    End Sub

    Private Sub btnLimpiar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar2.Click
        accion = 0
        codigo = 0
        EnabilizarMenu(True)
        borra_Mejorado(gpEmpleado, ep1)
        borra_Mejorado(gpContrato, ep1)
        borra_Mejorado(gpEvaluador, ep1)
        borra_Mejorado(gpContratoEva, ep1)
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar.Click
        Dim tipotest As Int32 = 0
        If (Int32.TryParse(txtCodigoTE.Text, tipotest)) Then
            dgDatos.ReadOnly = False
            gpTipoEvaluacion.Enabled = False
            pnDetalle.Enabled = True
            gpTipoEvaluacion.Enabled = False
            btnGuardar.Enabled = True
            llena_data(tipotest)
            listaEliminado.Clear()
        Else
            MsgBox("No ha ingresado un tipo de evaluación".ToUpper, MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If

    End Sub


    Private Sub llena_data(ByVal tipotest As Int32)
        lpara.Clear()
        lpara("ciclo") = txtCiclo.Text
        lpara("empresa") = empresa
        lpara("tipotest") = tipotest
        cadena = "select ROW_NUMBER() OVER ( ORDER BY ea.id_asignacion ) as correlativo, " &
                "ea.id_asignacion cod, ett.nombre, ea.empleado, " &
                "ea.contrato, ea.evaluador, " &
                "ea.contrato_evaluador, ea.ciclo, ea.tipotest  " &
                "from evaluatipo_asignacion ea " &
                "inner join emplegen e on ea.empresa = e.empresa and e.empleado = ea.empleado " &
                "inner join emplegen ev on ea.empresa = ev.empresa and ev.empleado = ea.evaluador " &
                "inner join evaluatipotest ett on ett.tipotest = ea.tipotest and ett.ciclo = ea.ciclo " &
                "where ea.ciclo = @ciclo and ea.tipotest=@tipotest " &
                "and ea.empresa = @empresa " &
                "ORDER by ea.id_asignacion "
        Try
            Dim cdata As New cmodelo(_conexionAcademia)
            cdata.llenaTabla(cadena, tabla, ListaParametros(lpara))
            cdata.Commit()
            dgDatos.DataSource = tabla
            tabla.Columns("cod").ColumnMapping = MappingType.Hidden

            If tabla.Rows.Count > 0 Then

                MueveScrollView(dgDatos, tabla.Rows.Count - 1)
            End If
        Catch ex As Exception
            MsgBox("ERROR DEL SISTEMA " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try


    End Sub




    Private Sub EnabilizarMenu(ByVal valB As Boolean)
        ctxModificar.Enabled = valB
        ctxEliminar.Enabled = valB

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim cdata As New cmodelo(_conexionAcademia)
        Try
            Dim dpara As New Dictionary(Of String, Object)
            For Each fila As DataRow In tabla.Rows
                dpara("empresa") = empresa
                dpara("ciclo") = txtCiclo.Text
                dpara("tipotest") = CInt(txtCodigoTE.Text)
                dpara("empleado") = fila("empleado")
                dpara("contrato") = fila("contrato")
                dpara("evaluador") = fila("evaluador")
                dpara("contrato_evaluador") = fila("contrato_evaluador")
                dpara("id_asignacion") = fila("cod")
                dpara("fecha") = DateTime.Now
                dpara("usuario") = _usuario
                If fila("cod") Is DBNull.Value Then
                    cadena = "select count(*) from evaluatipo_asignacion where empresa=@empresa
                              and tipotest=@tipotest and ciclo=@ciclo and empleado=@empleado and evaluador=@evaluador"
                    If cdata.BuscaEscalar(cadena, ListaParametros(dpara)) = 0 Then
                        cadena = "insert into evaluatipo_asignacion(empresa,ciclo, tipotest, empleado, contrato,evaluador, contrato_evaluador, fecha, usuario) 
                                  values (@empresa,@ciclo, @tipotest, @empleado, @contrato, @evaluador, @contrato_evaluador, @fecha, @usuario);
                                  select scope_identity() "
                        fila("cod") = cdata.BuscaEscalar(cadena, ListaParametros(dpara))
                    End If


                Else
                    cadena = "update evaluatipo_asignacion set  empleado=@empleado, 
                              contrato=@contrato, evaluador=@evaluador, 
                              contrato_evaluador=@contrato_evaluador, fecha=@fecha, usuario=@usuario where id_asignacion=@id_asignacion"
                    cdata.EjecutarNonQuery(cadena, ListaParametros(dpara))
                End If

            Next
            If cdata.Commit() Then
                MsgBox("Operación realizada con éxito", MsgBoxStyle.Information, "Mensaje del Sistema")
                InsertBitacora(9, 1, $"Creción y Modificación de asignación y de evaluación del ciclo {txtCiclo.Text } y tipotest {txtCodigoTE.Text} ")
            End If
        Catch ex As Exception
            cdata.RollBack()
            MsgBox("Error en la grabación de evaluaciones " + vbNewLine + ex.Message, "Mensaje del sistema")
        End Try



    End Sub


    Private Sub mnuAgrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EnabilizarMenu(False)
    End Sub

    Private Sub MnuModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click

        If dgDatos.SelectedRows.Count > 0 Then
            accion = 1
            EnabilizarMenu(False)
            _fila = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row

            codigo = If(_fila.Item("cod") Is DBNull.Value, 0, _fila.Item("cod"))
            txtCodEmpleado.Text = _fila.Item("empleado")
            ValidaEmpleado()
            txtCodigoEva.Text = _fila.Item("evaluador")
            ValidaEvaluador()
            txtContraEmpleado.Text = _fila.Item("contrato")
            txtContratoEva.Text = _fila.Item("contrato_evaluador")
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub MnuElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        Dim filaTemp As DataRow
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatos.SelectedRows.Count > 0 Then
            Try
                filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
                If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                    'verificar si tiene referencia en inscripciones
                    If (filaTemp.Item("cod") IsNot DBNull.Value) Then
                        cadena = "delete from evaluatipo_asignacion where id_asignacion = " & filaTemp.Item("cod")

                        Dim cdata As New cmodelo(_conexionAcademia)
                        cdata.EjecutarNonQuery(cadena)
                        If cdata.Commit() Then
                            InsertBitacora(9, 4, $"Eliminación de la fila {filaTemp.Item("cod")}")
                        End If
                    End If

                    tabla.Rows.Remove(filaTemp)
                    Dim i As Int32
                    For Each fila As DataRow In tabla.Rows
                        i += 1
                        fila("correlativo") = i
                    Next

                    btnLimpiar2_Click(sender, e)

                End If
            Catch ex As Exception
                MsgBox("Error del sistema " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try

        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If

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
        If txtCiclo.Text.Length = 4 Then
            btnLimpiar_Click(sender, e)
        End If
    End Sub

#Region "Tipo de Evaluacion"

    Private Sub BorraTipoEvaluacion(ByVal valbool As Boolean)
        txtNombreTE.Clear()
        If valbool = True Then
            txtCodigoTE.Clear()
        End If
    End Sub


    Private Sub BtnTipoEvaluacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoEvaluacion.Click
        Dim numFilas As Int32
        Dim lpara As New Dictionary(Of String, Object)
        lpara("ciclo") = txtCiclo.Text
        lpara("nombre") = txtNombreTE.Text

        If txtNomEmpleado.Text.Trim <> "" Then
            cadena = "Select tipotest, nombre from evaluatipotest where ciclo=@ciclo and nombre like '%' + @nombre + '%' order by nombre"
        Else
            cadena = "select tipotest, nombre from evaluatipotest where ciclo=@ciclo order by ciclo, tipotest"
        End If

        Dim cdata As New cmodelo(_conexionAcademia)
        cdata.llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))
        cdata.Commit()
        'dgDatos1.DataSource = tbEmpleado

        numFilas = tbEmpleado.Rows.Count
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TIPOS DE EVALUACION CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraTipoEvaluacion(True)
            txtCodigoTE.Clear()
        ElseIf numFilas = 1 Then
            BorraTipoEvaluacion(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            txtCodigoTE.Text() = filaTemp.Item(0)
            txtNombreTE.Text = filaTemp.Item(1)
        Else
            EnBuscaTipoEvaluacion()
        End If
    End Sub

    Private Sub ValidaTipoEvaluacion()
        lpara.Clear()
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = txtCodigoTE.Text.Trim()
        If valida_tipo_Entero(txtCodigoTE.Text, 2) = True Then
            Dim tbEle As New DataTable
            cadena = "select tipotest, nombre from evaluatipotest where ciclo = @ciclo and tipotest=@tipotest"
            Dim cdata As New cmodelo(_conexionAcademia)
            cdata.llenaTabla(cadena, tbEle, ListaParametros(lpara))
            cdata.Commit()

            If tbEle.Rows.Count > 0 Then
                BorraTipoEvaluacion(False)
                txtNombreTE.Text = tbEle.Rows(0).Item("nombre").ToString()
            End If
        Else
            MsgBox("CODIGO DEL TIPO DE EVALUACION POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraTipoEvaluacion(True)
            txtCodigoTE.Focus()
        End If
    End Sub

    Private Sub TxtCodigoTE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoTE.Validated
        If txtCodigoTE.Text.Trim <> "" And txtCodigoTE.ReadOnly = False Then
            ValidaTipoEvaluacion()
        ElseIf txtCodigoTE.ReadOnly = False Then
            BorraTipoEvaluacion(False)
        End If
    End Sub

    Private Sub EnBuscaTipoEvaluacion()
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosTipoEvaluacion
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosTipoEvaluacion(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraTipoEvaluacion(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        txtCodigoTE.Text() = filaTemp.Item(0)
        txtNombreTE.Text = filaTemp.Item(1)
    End Sub

#End Region

#Region "EMPLEADO"

    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        txtNomEmpleado.Clear()
        txtContraEmpleado.Clear()
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
            cadena = "select empleado, nombre from v_empleadosActivo where empresa=@empresa and nombre like '%' + @nombre + '%'  order by nombre"
        Else
            cadena = "select empleado, nombre from v_empleadosActivo where empresa=@empresa order by nombre"
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
            txtContraEmpleado.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = txtCodEmpleado.Text.Trim
        If valida_tipo_Entero(txtCodEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosActivo where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                txtCodEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosActivo where empresa=@empresa and empleado=@empleado"
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
                txtContraEmpleado.Focus()
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
        txtContraEmpleado.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        txtCodEmpleado.Text() = filaTemp.Item(0)
        txtNomEmpleado.Text = filaTemp.Item(1)
    End Sub

    Private Sub BorraEvaluador(ByVal valbool As Boolean)
        txtNombreEva.Clear()
        txtContratoEva.Clear()
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
            cadena = "select empleado, nombre from v_empleadosActivo where empresa=@empresa and nombre like '%' + @nombre + '%'  order by nombre"
        Else
            cadena = "select empleado, nombre from v_empleadosActivo where empresa=@empresa  order by nombre"
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
            txtContratoEva.Focus()
        Else
            EnBuscaEvaluador()
        End If
    End Sub

    Private Sub ValidaEvaluador()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = txtCodigoEva.Text.Trim
        If valida_tipo_Entero(txtCodEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosActivo where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEvaluador(True)
                txtCodigoEva.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosActivo where empresa=@empresa and empleado=@empleado"
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
                txtContratoEva.Focus()
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
        txtContratoEva.Focus()
    End Sub

    Private Sub ActualizacionDatosEvaluador(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEvaluador(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        txtCodigoEva.Text() = filaTemp.Item(0)
        txtNombreEva.Text = filaTemp.Item(1)
    End Sub

#End Region

#Region "Contrato"

    Private Sub BtnContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrato.Click
        Dim Num As Int16
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = txtCodEmpleado.Text
        If txtCodEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre from contratos1 c1 inner join empestados e on e.estado=c1.estado " &
                     "and e.empresa=c1.empresa " &
                     "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                     "where e.activo='S' and c1.empresa=@empresa and empleado=@empleado"
            Num = llenaTabla(cadena, tbContratos, ListaParametros(lpara))
            If Num = 1 Then
                txtContraEmpleado.Text = tbContratos.Rows(0).Item(0)
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 0)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContrato
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()

            ElseIf Num = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                txtContraEmpleado.Clear()
            End If
        Else
            MsgBox("INGRESO PRIMERO EL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ActualizacionDatosContrato(ByVal sender As Object, ByVal e As clsActValorREvento)
        filaTemp = tbContratos.Rows(e.va2)
        txtContraEmpleado.Text() = filaTemp.Item(0)
    End Sub

    Private Sub TextConxContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContraEmpleado.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextConxContrato_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContraEmpleado.Validated
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = txtCodEmpleado.Text
        lpara("contrato") = txtContraEmpleado.Text
        If txtContraEmpleado.Text.Trim <> "" And txtCodEmpleado.Text.Trim <> "" Then
            cadena = "select count(*) from contratos1 c1 where c1.empresa=@empresa and empleado=@empleado and contrato=@contrato"
            If BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                MsgBox("ESTE NUMERO DE CONTRATO NO EXISTE PARA ESTE EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                txtContraEmpleado.Clear()
            End If
        Else
            txtContraEmpleado.Clear()
        End If
    End Sub

    Private Sub BtnContratoEva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContratoEva.Click
        Dim Num As Int16
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = txtCodigoEva.Text
        If txtCodigoEva.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre from contratos1 c1 inner join empestados e on e.estado=c1.estado " &
                     "and e.empresa=c1.empresa " &
                     "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                     "where  e.activo='S' and c1.empresa=@empresa and empleado=@empleado"
            Num = llenaTabla(cadena, tbContratos, ListaParametros(lpara))
            If Num = 1 Then
                txtContratoEva.Text = tbContratos.Rows(0).Item(0)
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 0)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContratoEva
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()

            ElseIf Num = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                txtContratoEva.Clear()
            End If
        Else
            MsgBox("INGRESO PRIMERO EL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ActualizacionDatosContratoEva(ByVal sender As Object, ByVal e As clsActValorREvento)
        filaTemp = tbContratos.Rows(e.va2)
        txtContratoEva.Text = filaTemp.Item(0)
    End Sub

    Private Sub TxtContratoEva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContratoEva.KeyPress
        soloNumero(sender, e)
    End Sub




    Private Sub dgDatos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgDatos.CurrentCellDirtyStateChanged
        If (dgDatos.IsCurrentCellDirty AndAlso dgDatos.CurrentCell.GetType Is GetType(DataGridViewComboBoxCell)) Then

            dgDatos.CommitEdit(DataGridViewDataErrorContexts.Commit)
            If (dgDatos.CurrentCell.Value() IsNot Nothing) Then
                '    MsgBox(dgDatos.Rows(dgDatos.CurrentCell.RowIndex).Cells(0).Value.ToString())

                Dim numeroE As Int32 = dgDatos.CurrentCell.Value
                ' Dim contrato As Int32 = control.GetMaxContratoEmpleado(numeroE, empresa)
                Dim col As Int16 = dgDatos.CurrentCell.ColumnIndex + 1
                Dim row As Int16 = dgDatos.CurrentCell.RowIndex
                ' dgDatos.Rows(row).Cells(col).Value = contrato
                dgDatos.Rows(dgDatos.CurrentCell.RowIndex).Cells(0).Value = dgDatos.CurrentCell.RowIndex + 1
            End If
        End If
    End Sub




    Private Sub TxtContratoEva_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContratoEva.Validated
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = txtCodigoEva.Text
        lpara("contrato") = txtContratoEva.Text
        If txtContratoEva.Text.Trim <> "" And txtCodigoEva.Text.Trim <> "" Then
            cadena = "select count(*) from contratos1 c1  " &
                     "where c1.empresa=@empresa and empleado=@empleado and contrato=@contrato"
            If BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                MsgBox("ESTE NUMERO DE CONTRATO NO EXISTE PARA ESTE EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                txtContratoEva.Clear()
            End If
        Else
            txtContratoEva.Clear()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If validetError(txtCodEmpleado, ep1) = False Or validetError(txtCodigoEva, ep1) = False _
               Or validetError(txtNomEmpleado, ep1) = False Or validetError(txtContraEmpleado, ep1) = False _
               Or validetError(txtNombreEva, ep1) = False Or validetError(txtContratoEva, ep1) = False _
               Or validetError(txtCodigoTE, ep1) = False Or validetError(txtNombreTE, ep1) = False Then
            Exit Sub
        End If
        Try
            Dim fnueva As DataRow
            Select Case accion
                Case 0
                    Dim filas() As DataRow = tabla.Select("empleado=" & txtCodEmpleado.Text & " and evaluador=" & txtCodigoEva.Text)
                    If filas.Length > 0 Then
                        MsgBox("EL EMPLEADO Y EL EVALUADOR SELECCIONADO YA HAN SIDO INGRESADOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                        Exit Sub
                    End If
                    fnueva = tabla.NewRow
                    fnueva("correlativo") = tabla.Rows.Count + 1
                    fnueva("ciclo") = txtCiclo.Text
                    fnueva("tipotest") = CInt(txtCodigoTE.Text)
                    fnueva("empleado") = CInt(txtCodEmpleado.Text)
                    fnueva("contrato") = CInt(txtContraEmpleado.Text)
                    fnueva("evaluador") = CInt(txtCodigoEva.Text)
                    fnueva("contrato_evaluador") = CInt(txtContratoEva.Text)
                    tabla.Rows.Add(fnueva)
                Case 1
                    fnueva = _fila
                    fnueva("empleado") = CInt(txtCodEmpleado.Text)
                    fnueva("contrato") = CInt(txtContraEmpleado.Text)
                    fnueva("evaluador") = CInt(txtCodigoEva.Text)
                    fnueva("contrato_evaluador") = CInt(txtContratoEva.Text)
            End Select
            btnLimpiar2_Click(sender, e)
        Catch ex As Exception
            MsgBox("Error del sistema " + vbNewLine + ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub dgDatos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgDatos.DataError
        MsgBox("Error al modificar campo")
        e.Cancel = True
    End Sub

    Private Sub btnMigrar_Click(sender As Object, e As EventArgs) Handles btnMigrar.Click
        Dim cdata As New cmodelo(_conexionAcademia)
        Dim dpara As New Dictionary(Of String, Object)
        Dim ciclo As Int16 = Now.Year
        Dim ciclo_ant As Int16 = ciclo - 1
        Dim val As Int32 = 0
        Try
            dpara("empresa") = empresa
            dpara("ciclo_ant") = ciclo_ant
            dpara("ciclo") = ciclo

            cadena = "select count(*) from evaluatipo_asignacion where ciclo=@ciclo"
            val = cdata.BuscaEscalar(cadena, ListaParametros(dpara))

            If val > 0 Then
                Dim ask As MsgBoxResult = MsgBox("Ya existen asignaciones para este ciclo, desea continuar?", MsgBoxStyle.YesNo)
                If ask = MsgBoxResult.Yes Then
                    cadena = "delete from evaluatipo_asignacion where ciclo=@ciclo"
                    cdata.EjecutarNonQuery(cadena, ListaParametros(dpara))

                    cadena = "insert into evaluatipo_asignacion " &
                             "select empresa,@ciclo as ciclo,tipotest,empleado,contrato,evaluador,contrato_evaluador,getdate() as fecha,'admin' as usuario " &
                             "from evaluatipo_asignacion where empresa=@empresa and ciclo=@ciclo_ant and " &
                             "empleado In (Select empleado from javier.dbo.contratos1 where estado In (0,4)) And " &
                             "evaluador In (Select empleado from javier.dbo.contratos1 where estado In (0,4))"

                    cdata.EjecutarNonQuery(cadena, ListaParametros(dpara))

                End If
            End If

            If cdata.Commit() Then
                MsgBox("Operación realizada con éxito", MsgBoxStyle.Information, "Mensaje del Sistema")
                InsertBitacora(9, 1, $"Migración de asignación de colaboradores ciclo {txtCiclo.Text }")
            End If

        Catch ex As Exception
            cdata.RollBack()
            MsgBox("Error en la grabación de evaluaciones " + vbNewLine + ex.Message, "Mensaje del sistema")
        End Try








    End Sub

    Private Sub dgDatos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgDatos.CellValueChanged
        If e.RowIndex >= 0 Then
            Dim empleado As Int32 = 0
            Dim contrato As Int32 = 0
            If (e.ColumnIndex = 3 Or e.ColumnIndex = 5) Then
                If (Int32.TryParse(dgDatos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, empleado)) Then
                    contrato = ctrl.GetMaxContratoEmpleado(empleado, empresa)
                    dgDatos.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value = contrato
                End If
            End If

        End If
    End Sub

#End Region

End Class