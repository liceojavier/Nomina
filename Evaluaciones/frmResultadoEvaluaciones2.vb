Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMRESULTADOEVALUACIONES.VB MIEMBRO DE NOMINA.SLN                           **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmResultadoEvaluaciones2

    Dim tbEmpleado As New DataTable("empleado")
    Dim tbCodigo As New DataTable("codigo")
    Dim tbTipoEmpleado As New DataTable("tipoEmpleado")
    Dim tbtipotest As New DataTable("tipotest")
    Dim tbPuesto As New DataTable("puesto")
    Dim tbAreas As New DataTable("areas")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim v As ReportClass
    'Dim v2 As New Cryconsultaporcompetenciasxevaluador
    Dim tt As New DataTable("datos")
    Dim WithEvents fEMp As frmMuestra2Columnas
    Dim cadena As String = ""
    Dim cadenasub As String = ""
    Dim cadenafiltro As String = ""
    Dim rawkind As Integer
    Dim lpara As New Dictionary(Of String, Object)


#Region "EMPLEADO"
    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        If valbool = True Then
            textEmpleado.Clear()
        End If
    End Sub

    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombreEmple.Text.Trim
        cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa and nombre like '%' + @nombre + '%' " &
                 " and e.empleado in ( select empleado from contratos1 c1 " &
                 " inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) " &
                 " order by nombre"

        numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))

        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            textEmpleado.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            textEmpleado.Text() = filaTemp.Item(0)
            textNombreEmple.Text = filaTemp.Item(1)

        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text.Trim
        If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa " &
                    " and empleado=@empleado " &
                    " and e.empleado in ( select empleado from contratos1 c1 " &
                    "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) "
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
            textEmpleado.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textEmpleado.Validated
        If textEmpleado.Text.Trim <> "" Then
            ValidaEmpleado()
        Else
            BorraEmpleado(False)
        End If
    End Sub

    Private Sub EnBuscaEmpleado()
        fEMp = New frmMuestra2Columnas
        fEMp.TopMost = True
        fEMp.inicializa(tbEmpleado, "CODIGO", "NOMBRE", 0)
        AddHandler fEMp.actValor, AddressOf ActualizacionDatosEmpleados
        fEMp.StartPosition = FormStartPosition.CenterScreen
        fEMp.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
    End Sub

#End Region
#Region "EMPLEADO2"
    Private Sub BorraEmpleado2(ByVal valbool As Boolean)
        TextNombreEmple2.Clear()
        If valbool = True Then
            TextEmpleado2.Clear()
        End If
    End Sub

    Private Sub btnEmpleado2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado2.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = TextNombreEmple2.Text.Trim
        lpara("ciclo") = TextCiclo.Text
        cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa and nombre like '%' + @nombre + '%' " &
                " and e.empleado in (select distinct(a.emevaluador) from evaluatest1  a " &
                " inner join v_empleadosNuevo b on a.emevaluador=b.empleado " &
                " where b.nombre like '%' + @nombre + '%' and a.empresa=@empresa and a.ciclo=@ciclo) " &
                " order by nombre"
        numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado2(True)
            TextEmpleado2.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado2(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            TextEmpleado2.Text() = filaTemp.Item(0)
            TextNombreEmple2.Text = filaTemp.Item(1)

        Else
            EnBuscaEmpleado2()
        End If
    End Sub

    Private Sub ValidaEmpleado2()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = TextEmpleado2.Text.Trim
        If valida_tipo_Entero(TextEmpleado2.Text, 2) = True Then
            If BuscaEscalar("Select count (*) from v_empleadosNuevo where empresa=@empresa And empleado=@empleado ", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado2(True)
                TextEmpleado2.Focus()
                Exit Sub
            End If
            cadena = "Select empleado, nombre from v_empleadosNuevo e where empresa=@empresa " &
                     " And empleado=@empleado " &
                     " And e.empleado In ( Select empleado from contratos1 c1 " &
                     " inner join empestados es  On c1.empresa=es.empresa And c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) "
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEmpleado2(False)
                dr.Read()
                TextNombreEmple2.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()

            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraEmpleado2(True)
            TextEmpleado2.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated2(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextEmpleado2.Validated
        If TextEmpleado2.Text.Trim <> "" Then
            ValidaEmpleado2()
        Else
            BorraEmpleado2(False)
        End If
    End Sub

    Private Sub EnBuscaEmpleado2()
        fEMp = New frmMuestra2Columnas
        fEMp.TopMost = True
        fEMp.inicializa(tbEmpleado, "CODIGO", "NOMBRE", 0)
        AddHandler fEMp.actValor, AddressOf ActualizacionDatosEmpleados2
        fEMp.StartPosition = FormStartPosition.CenterScreen
        fEMp.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosEmpleados2(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado2(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        TextEmpleado2.Text() = filaTemp.Item(0)
        TextNombreEmple2.Text = filaTemp.Item(1)
    End Sub

#End Region
#Region "PUESTO"
    Private Sub BorraPuesto(ByVal valbool As Boolean)
        TextNombPuesto.Clear()
        If valbool = True Then
            TextPuesto.Clear()
        End If
    End Sub

    Private Sub btnPuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPuesto.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = TextNombPuesto.Text.Trim
        cadena = "select puesto, nombre from puestosper e where empresa=@empresa and nombre like '%' + @nombre + '%' order by nombre "
        numFilas = llenaTabla(cadena, tbPuesto, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN PUESTOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraPuesto(True)
            TextPuesto.Clear()
        ElseIf numFilas = 1 Then
            BorraPuesto(True)
            filaTemp = tbPuesto.Rows.Item(0)
            TextPuesto.Text() = filaTemp.Item(0)
            TextNombPuesto.Text = filaTemp.Item(1)
        Else
            EnBuscaPuesto()
        End If
    End Sub

    Private Sub ValidaPuesto()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("puesto") = TextPuesto.Text.Trim
        If valida_tipo_Entero(TextPuesto.Text, 2) = True Then
            If BuscaEscalar("select count (*) from puestosper where empresa=@empresa and puesto=@puesto", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraPuesto(True)
                TextPuesto.Focus()
                Exit Sub
            End If
            cadena = "select puesto, nombre from puestosper e where empresa=@empresa and puesto=@puesto"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraPuesto(False)
                dr.Read()
                TextNombPuesto.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()

            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraPuesto(True)
            TextPuesto.Focus()
        End If
    End Sub

    Private Sub TextPuesto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextPuesto.Validated
        If TextPuesto.Text.Trim <> "" Then
            ValidaPuesto()
        Else
            BorraPuesto(False)
        End If
    End Sub

    Private Sub EnBuscaPuesto()
        fEMp = New frmMuestra2Columnas
        fEMp.TopMost = True
        fEMp.inicializa(tbPuesto, "CODIGO", "NOMBRE", 0)
        AddHandler fEMp.actValor, AddressOf ActualizacionDatosPuestos
        fEMp.StartPosition = FormStartPosition.CenterScreen
        fEMp.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosPuestos(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraPuesto(True)
        filaTemp = tbPuesto.Rows.Item(e.va2)
        TextPuesto.Text() = filaTemp.Item(0)
        TextNombPuesto.Text = filaTemp.Item(1)
    End Sub

#End Region

    Private Sub frmResultadoEvaluaciones2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextCiclo.Text = Today.Year
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("ciclo") = TextCiclo.Text
        TextEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=@empresa", ListaParametros(lpara))
        cadena = " select a.nombre,a.tipotest from evaluatipotest a where a.ciclo=@ciclo order by tipotest"
        llenaTabla(cadena, tbtipotest, ListaParametros(lpara))
        llena_combo(cadena, cmbtipotest, ListaParametros(lpara))
        cmbtipotest.Items.Add("")
        rbEvaluado.Checked = True
        If rbEvaluado.Checked = True Then
            gpEvaluador.Enabled = False
            gpEvaluador.Visible = False

        End If
        cadena = "select te.nombre,te.tipoempleado " &
                 "from tiposempleado te " &
                 "where te.empresa=@empresa order by te.tipoempleado"
        llenaTabla(cadena, tbTipoEmpleado, ListaParametros(lpara))
        llena_combo(cadena, cmbTipoEmpleado, ListaParametros(lpara))
        cmbTipoEmpleado.Items.Add("")

        cadena = "select a.nombre,a.area " & _
                 "from areas a " & _
                 "order by a.area"
        llenaTabla(cadena, tbAreas)
        llena_combo(cadena, cmbArea)
        cmbArea.Items.Add("")

    End Sub
#Region "impresion"
    Private Sub impresion()
        Dim i As Int16
        Dim doctoprint As New PrintDocument
        For i = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
            If doctoprint.PrinterSettings.PaperSizes(i).PaperName.ToLower = "carta (8.5 x 11 pulg.)" Then
                rawkind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", _
                   Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                Exit For
            End If
        Next
    End Sub

#End Region

    Private Sub filtros()
        cadenafiltro = ""
        If cmbTipoEmpleado.Text.Trim <> "" Then
            cadenafiltro = cadenafiltro & "," & tbTipoEmpleado.Rows(cmbTipoEmpleado.SelectedIndex).Item("tipoempleado").ToString
        Else
            cadenafiltro = cadenafiltro & ",''"
        End If
        If textEmpleado.Text.Trim <> "" Then
            cadenafiltro = cadenafiltro & "," & textEmpleado.Text
        Else
            cadenafiltro = cadenafiltro & ",''"
        End If
        If TextPuesto.Text.Trim <> "" Then
            cadenafiltro = cadenafiltro & "," & TextPuesto.Text
        Else
            cadenafiltro = cadenafiltro & ",''"
        End If
        If TextEmpleado2.Text.Trim <> "" Then
            cadenafiltro = cadenafiltro & "," & TextEmpleado2.Text
        Else
            cadenafiltro = cadenafiltro & ",''"
        End If
        If cmbArea.Text.Trim <> "" Then
            cadenafiltro = cadenafiltro & "," & tbAreas.Rows(cmbArea.SelectedIndex).Item("area").ToString
        Else
            cadenafiltro = cadenafiltro & ",''"
        End If
    End Sub


    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        'Los filtros están por empresa,tipotest,tipoempleado,empleado,puesto
        'En los procedimientos estan integrados los filtros.
        impresion()
        lpara.Clear()
        lpara("ciclo") = TextCiclo.Text.Trim
        lpara("empresa") = empresa

        Dim tipoevaluador As String
        If rbEvaluado.Checked = True Then
            tipoevaluador = "1"
        Else
            tipoevaluador = "2"
        End If

        Me.Cursor = Cursors.WaitCursor
        filtros()
        If rbCompetencias.Checked = True Then
            If Not validetError(TextCiclo, ep1) Then
                MsgBox("DEBE INGRESAR TODOS LOS CAMPOS OBLIGATORIOS", MsgBoxStyle.Information, "Información del Sistema")
                Exit Sub
            End If
            v = New Cryconsultaporcompetencias
            If cmbtipotest.Text <> "" Then
                lpara("tipotest") = tbtipotest.Rows(cmbtipotest.SelectedIndex).Item("tipotest")
                cadena = "exec proc_nomi_consultaxcompetencias @ciclo,@empresa,@tipotest"
            Else
                cadena = "exec proc_nomi_consultaxcompetencias @ciclo,@empresa,''"
            End If

            cadena = cadena & cadenafiltro
            cadena = cadena & "," & tipoevaluador
            Try
                If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then
                    '  v.SetDatabaseLogon(usuarioDB, passwordDB, servidorDB, baseDatosDB)
                    v.SetDataSource(tt)
                    If cmbtipotest.Text.Trim <> "" Then
                        v.SetParameterValue("tipotest", tbtipotest.Rows(cmbtipotest.SelectedIndex).Item("nombre"))
                    Else
                        v.SetParameterValue("tipotest", "")
                    End If
                    If cmbTipoEmpleado.Text.Trim <> "" Then
                        v.SetParameterValue("tipoempleado", tbTipoEmpleado.Rows(cmbTipoEmpleado.SelectedIndex).Item("nombre"))
                    Else
                        v.SetParameterValue("tipoempleado", "")
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    crv.ReportSource = v
                    crv.Refresh()
                Else
                    crv.ReportSource = Nothing
                    MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                MsgBox("ERROR AL GENERAR EL REPORTE " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try

        ElseIf rbDestreza.Checked = True Then
            Dim v As New Cryconsultapordestreza2
            If Not validetError(cmbtipotest, ep1) Or Not validetError(TextCiclo, ep1) Then
                MsgBox("DEBE INGRESAR TODOS LOS CAMPOS OBLIGATORIOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If

            If cmbtipotest.Text <> "" Then
                lpara("tipotest") = tbtipotest.Rows(cmbtipotest.SelectedIndex).Item("tipotest")
                cadena = "exec proc_nomi_consultaxdestreza2 @ciclo,@empresa,@tipotest"
            Else
                cadena = "exec proc_nomi_consultaxdestreza2 @ciclo,@empresa,''"

            End If
            cadena = cadena & cadenafiltro
            cadena = cadena & "," & tipoevaluador
            Try
                If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then
                    'v.SetDatabaseLogon(usuarioDB, passwordDB, servidorDB, baseDatosDB)
                    v.SetDataSource(tt)
                    If cmbtipotest.Text.Trim <> "" Then
                        v.SetParameterValue("tipotest", tbtipotest.Rows(cmbtipotest.SelectedIndex).Item("nombre"))
                    Else
                        v.SetParameterValue("tipotest", "")
                    End If
                    If cmbTipoEmpleado.Text.Trim <> "" Then
                        v.SetParameterValue("tipoempleado", tbTipoEmpleado.Rows(cmbTipoEmpleado.SelectedIndex).Item("nombre"))
                    Else
                        v.SetParameterValue("tipoempleado", "")
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    crv.ReportSource = v
                    crv.Refresh()
                Else
                    crv.ReportSource = Nothing
                    MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO EN ESTE CICLO ESCOLAR", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("ERROR AL GENERAR EL REPORTE " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
            Me.Cursor = Cursors.Default

        ElseIf rbPorcentaje.Checked = True Then
            Dim v As New CryconsultaPorcentajes2
            Dim cadenamuestra As String
            Dim cantidadmuestra As Integer

            cadenamuestra = "select count(*) from evaluatest1 a inner join contratos1 b on a.empleado=b.empleado and a.contrato=b.contrato" &
                            " where a.ciclo = @ciclo And a.empresa =@empresa "

            If Not validetError(cmbtipotest, ep1) Or Not validetError(TextCiclo, ep1) Then
                MsgBox("DEBE INGRESAR TODOS LOS CAMPOS OBLIGATORIOS", MsgBoxStyle.Information, "Mensaje de Sistema")
                Exit Sub
            End If

            If cmbtipotest.Text <> "" Then
                cadena = "exec proc_nomi_consultaxporcentaje2 @ciclo,@empresa,@tipotest "
                cadenamuestra = cadenamuestra & " and a.tipotest =@tipotest "
            Else
                cadena = "exec proc_nomi_consultaxporcentaje2 @ciclo,@empresa,''"
            End If
            lpara("tipoEmpleado") = tbTipoEmpleado.Rows(cmbTipoEmpleado.SelectedIndex).Item("tipoempleado")
            lpara("empleado") = textEmpleado.Text
            lpara("puesto") = TextPuesto.Text
            lpara("area") = tbAreas.Rows(cmbArea.SelectedIndex).Item("area")
            If cmbTipoEmpleado.Text <> "" Then cadenamuestra = cadenamuestra & " and b.tipoempleado=@tipoEmpleado "
            If textEmpleado.Text <> "" Then cadenamuestra = cadenamuestra & " and a.empleado=@empleado "
            If TextPuesto.Text <> "" Then cadenamuestra = cadenamuestra & " and b.puesto=@puesto "
            If cmbArea.Text <> "" Then cadenamuestra = cadenamuestra & " and a.empleado in (select empleado from maestros where area=@area)"

            cadena = cadena & cadenafiltro
            cadena = cadena & "," & tipoevaluador
            cantidadmuestra = BuscaEscalar(cadenamuestra, ListaParametros(lpara))

            Try
                If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then
                    'v.SetDatabaseLogon(usuarioDB, passwordDB, servidorDB, baseDatosDB)
                    v.SetDataSource(tt)
                    If cmbtipotest.Text.Trim <> "" Then
                        v.SetParameterValue("tipotest", tbtipotest.Rows(cmbtipotest.SelectedIndex).Item("nombre"))
                    Else
                        v.SetParameterValue("tipotest", "")
                    End If
                    If cmbTipoEmpleado.Text.Trim <> "" Then
                        v.SetParameterValue("tipoempleado", tbTipoEmpleado.Rows(cmbTipoEmpleado.SelectedIndex).Item("nombre"))
                    Else
                        v.SetParameterValue("tipoempleado", "")
                    End If
                    If TextPuesto.Text.Trim <> "" Then
                        v.SetParameterValue("puesto", TextNombPuesto.Text)
                    Else
                        v.SetParameterValue("puesto", "")
                    End If
                    v.SetParameterValue("muestra", cantidadmuestra)
                    Me.Cursor = Cursors.WaitCursor
                    crv.ReportSource = v
                    crv.Refresh()
                Else
                    crv.ReportSource = Nothing
                    MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO EN ESTE CICLO ESCOLAR", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
            End Try
            Me.Cursor = Cursors.Default
        ElseIf rbPorcentajeAreas.Checked = True Then
            Dim v As New CryconsultaPorcentajesArea
            Dim cadenamuestra As String
            Dim cantidadmuestra As Integer

            cadenamuestra = "select count(*) from evaluatest1 a inner join contratos1 b on a.empleado=b.empleado and a.contrato=b.contrato" &
                            " where a.ciclo = @ciclo And a.empresa =@empresa "

            If Not validetError(cmbtipotest, ep1) Or Not validetError(TextCiclo, ep1) Then
                MsgBox("DEBE INGRESAR TODOS LOS CAMPOS OBLIGATORIOS", MsgBoxStyle.Information, "Mensaje de Sistema")
                Exit Sub
            End If

            If cmbtipotest.Text <> "" Then
                cadena = "exec proc_nomi_consultaxporcentajearea @ciclo,@empresa,@tipotest "
                cadenamuestra = cadenamuestra & " and a.tipotest =@tipotest "
            Else
                cadena = "exec proc_nomi_consultaxporcentajearea @ciclo,@empresa,''"
            End If

            lpara("tipoEmpleado") = tbTipoEmpleado.Rows(cmbTipoEmpleado.SelectedIndex).Item("tipoempleado")
            lpara("empleado") = textEmpleado.Text
            lpara("puesto") = TextPuesto.Text
            lpara("area") = tbAreas.Rows(cmbArea.SelectedIndex).Item("area")
            If cmbTipoEmpleado.Text <> "" Then cadenamuestra = cadenamuestra & " and b.tipoempleado=@tipoEmpleado "
            If textEmpleado.Text <> "" Then cadenamuestra = cadenamuestra & " and a.empleado=@empleado "
            If TextPuesto.Text <> "" Then cadenamuestra = cadenamuestra & " and b.puesto=@puesto "
            If TextPuesto.Text <> "" Then cadenamuestra = cadenamuestra & " and b.puesto=@puesto "
            If cmbArea.Text <> "" Then cadenamuestra = cadenamuestra & " and a.empleado in (select empleado from maestros where area=@area)"
            cadena = cadena & cadenafiltro
            cadena = cadena & "," & tipoevaluador
            cantidadmuestra = BuscaEscalar(cadenamuestra, ListaParametros(lpara))

            Try
                If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then

                    v.SetDataSource(tt)
                    If cmbtipotest.Text.Trim <> "" Then
                        v.SetParameterValue("tipotest", tbtipotest.Rows(cmbtipotest.SelectedIndex).Item("nombre"))
                    Else
                        v.SetParameterValue("tipotest", "")
                    End If
                    If cmbTipoEmpleado.Text.Trim <> "" Then
                        v.SetParameterValue("tipoempleado", tbTipoEmpleado.Rows(cmbTipoEmpleado.SelectedIndex).Item("nombre"))
                    Else
                        v.SetParameterValue("tipoempleado", "")
                    End If
                    If TextPuesto.Text.Trim <> "" Then
                        v.SetParameterValue("puesto", TextNombPuesto.Text)
                    Else
                        v.SetParameterValue("puesto", "")
                    End If
                    v.SetParameterValue("muestra", cantidadmuestra)
                    Me.Cursor = Cursors.WaitCursor
                    crv.ReportSource = v
                    crv.Refresh()
                Else
                    crv.ReportSource = Nothing
                    MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO EN ESTE CICLO ESCOLAR", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
            End Try
            Me.Cursor = Cursors.Default
        ElseIf rbComentarios.Checked = True Then


            Dim v As New CryConsultaxComentarios

            If Not validetError(TextCiclo, ep1) Then
                MsgBox("DEBE INGRESAR TODOS LOS CAMPOS OBLIGATORIOS", MsgBoxStyle.Information, "Mensaje de Sistema")
                Exit Sub
            End If
            lpara("empleado") = textEmpleado.Text
            lpara("puesto") = TextPuesto.Text
            cadena = "select b.empleado,b.apellido1+' '+apellido2+' '+nombre1+' '+nombre2+' '+nombre3 as nombre," &
                     " a.observa,d.puesto,d.nombre as nompuesto from evaluatest1 a " &
                     " inner join emplegen b on a.empleado=b.empleado " &
                     " inner join contratos1 c on a.empresa=c.empresa and a.empleado=c.empleado and a.contrato=c.contrato" &
                     " inner join puestosper d on a.empresa=c.empresa and c.puesto=d.puesto" &
                     " where(a.empleado <> a.emevaluador)  and cast(a.observa as char(5))<>'' " &
                    " and a.ciclo=@ciclo "
            If textEmpleado.Text <> "" Then
                cadena = cadena & " and a.empleado=@empleado "
            End If
            If TextPuesto.Text <> "" Then
                cadena = cadena & " and d.puesto=@puesto "
            End If

            Try
                If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then

                    v.PrintOptions.PaperSize = rawkind
                    v.SetDataSource(tt)

                    Me.Cursor = Cursors.WaitCursor
                    crv.ReportSource = v

                Else
                    crv.ReportSource = Nothing
                    MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO EN ESTE CICLO ESCOLAR", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        cadena = ""
        cadenasub = ""
        BorraEmpleado(True)
        BorraEmpleado2(True)
        BorraPuesto(True)
        cmbTipoEmpleado.Text = ""
        cmbtipotest.SelectedIndex = -1
        crv.ReportSource = Nothing
        rbEvaluado.Checked = True
    End Sub

    Private Sub rbPorcentaje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    rbPorcentaje.CheckedChanged, rbCompetencias.CheckedChanged, rbDestreza.CheckedChanged, rbComentarios.CheckedChanged
        cmbArea.Text = ""
        If rbCompetencias.Checked Then
            gpEvaluado.Visible = True
            gpPuesto.Visible = True
            gpTipo.Visible = True
            cmbArea.Visible = False
            lbArea.Visible = False
        ElseIf rbDestreza.Checked Then
            gpEvaluado.Visible = True
            gpPuesto.Visible = True
            gpTipo.Visible = True
            cmbArea.Visible = False
            lbArea.Visible = False
        ElseIf rbPorcentaje.Checked Then
            gpEvaluado.Visible = True
            gpPuesto.Visible = True
            gpTipo.Visible = True
            cmbArea.Visible = True
            lbArea.Visible = True
        ElseIf rbPorcentajeAreas.Checked Then
            gpEvaluado.Visible = True
            gpPuesto.Visible = True
            gpTipo.Visible = True
            cmbArea.Visible = True
            lbArea.Visible = True
        ElseIf rbComentarios.Checked Then
            gpEvaluado.Visible = True
            gpPuesto.Visible = True
            gpTipo.Visible = False
            cmbArea.Visible = False
            lbArea.Visible = False
        End If
    End Sub

    Private Sub TextCiclo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    TextCiclo.KeyPress, textEmpleado.KeyPress, TextPuesto.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextCiclo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextCiclo.Validated
        lpara.Clear()
        lpara("ciclo") = TextCiclo.Text
        If TextCiclo.Text.Trim <> "" Then
            cadena = " select a.nombre,a.tipotest from evaluatipotest a where a.ciclo=@ciclo order by tipotest"
            llenaTabla(cadena, tbtipotest, ListaParametros(lpara))
            llena_combo(cadena, cmbtipotest, ListaParametros(lpara))
            cmbtipotest.Items.Add("")
        End If
    End Sub

    Private Sub gpTipo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gpTipo.Enter

    End Sub
End Class