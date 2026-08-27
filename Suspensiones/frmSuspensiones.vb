Imports System.Data.SqlClient


'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCONSSUSPENSIONES.VB MIEMBRO DE NOMINA.SLN                                **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmSuspensiones
    Dim cadena As String
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim tbSuspen As New DataTable("suspension")
    Dim tbGrado As New DataTable("grados")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")
    Dim tbConsulta As New DataTable("consulta")
    Dim tbAlta As New DataTable("alta")
    Dim filaTemp As DataRow

    Dim WithEvents fEmp As frmMuestraCodigos
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim WithEvents fAlta As frmAltaSus
    Dim WithEvents f As frmConsultaFechas
    Dim inicioConsulta As String = "select numero,empleado, contrato, tiposus, grado,fechai, fechaf, tipoal,cantidad,valor," &
                                 "observa, estado,fechae,  usuario from  " &
                                 " suspensiones s1 where empresa=" & empresa
    Dim indice, opcMod As Int32
    Dim consultaFechaI, consultaFechaF As String
    Dim lpara As New Dictionary(Of String, Object)


    Private Sub frmIngPuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=" & empresa)
        cadena = "select nombre, tiposus from tiposuspensiones order by tiposus"
        llena_combo(cadena, cmbTipo)
        cmbTipo.Items.Add("")
        llenaTabla(cadena, tbSuspen)
        cadena = "select nombre, grado from  gradoslesion order by grado"
        llena_combo(cadena, cmbGrado)
        cmbGrado.Items.Add("")
        llenaTabla(cadena, tbGrado)
        cadena = "select nombre, tipoAl from tiposalta order by tipoAl"
        llena_combo(cadena, cmbAlta)
        llenaTabla(cadena, tbAlta)
        cmbAlta.Items.Add("")
        btnLimpiar_Click(sender, e)
    End Sub


#Region "EMLEADO"


    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        If TextConxContrato.ReadOnly = False Then
            TextConxContrato.Clear()
        End If
        If valbool = True Then
            textConxEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombreEmple.Text.Trim
        If textNombreEmple.Text.Trim <> "" Then

            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa And nombre Like '%' + @nombre + '%'  order by nombre"
        Else
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa  order by nombre"
        End If
        numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            textConxEmpleado.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            textConxEmpleado.Text() = filaTemp.Item(0)
            textNombreEmple.Text = filaTemp.Item(1)
            TextConxContrato.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textConxEmpleado.Text.Trim
        If valida_tipo_Entero(textConxEmpleado.Text, 2) = True Then
            If BuscaEscalar("Select count (*) from v_empleadosNuevo where empresa=@empresa And empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textConxEmpleado.Focus()
                Exit Sub
            End If
            cadena = "Select empleado, nombre from v_empleadosNuevo where empresa=@empresa And empleado=@empleado"
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
                TextConxContrato.Focus()
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
        If textConxEmpleado.Text.Trim <> "" And textConxEmpleado.ReadOnly = False Then
            ValidaEmpleado()
        ElseIf textConxEmpleado.ReadOnly = False Then
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
        TextConxContrato.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textConxEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
    End Sub





#End Region


#Region "Contrato"

    Private Sub BtnContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrato.Click
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textConxEmpleado.Text
        Dim Num As Int16
        If textConxEmpleado.Text.Trim <> "" Then
            cadena = "Select contrato, pu.nombre from contratos1 c1 inner join empestados e On e.estado=c1.estado And e.empresa=c1.empresa " &
                     "inner join puestosper pu On pu.empresa=c1.empresa And pu.puesto=c1.puesto " &
                     "where c1.empresa=@empresa And empleado=@empleado"
            Num = llenaTabla(cadena, tbContratos, ListaParametros(lpara))
            If Num = 1 Then
                TextConxContrato.Text = tbContratos.Rows(0).Item(0)
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 0)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContrato
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()
                cmbTipo.Focus()

            ElseIf Num = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            MsgBox("INGRESO PRIMERO EL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ActualizacionDatosContrato(ByVal sender As Object, ByVal e As clsActValorREvento)
        filaTemp = tbContratos.Rows(e.va2)
        TextConxContrato.Text() = filaTemp.Item(0)
    End Sub

    Private Sub TextConxContrato_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextConxContrato.Validated
        If TextConxContrato.Text.Trim <> "" And textConxEmpleado.Text.Trim <> "" Then
            cadena = "Select count(*) from contratos1 c1  " &
                        "where c1.empresa=" & empresa & " And empleado=" & textConxEmpleado.Text & " And contrato=" &
                        TextConxContrato.Text
            If BuscaEscalar(cadena) = 0 Then
                MsgBox("ESTE NUMERO DE CONTRATO NO EXISTE PARA ESTE EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            TextConxContrato.Clear()
        End If
    End Sub

#End Region


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim finConsulta, cadenaConsulta As String
        finConsulta = " And 1=1"
        GeneraConsulta(gpDatos, finConsulta, "s1")
        If cmbTipo.Text.Trim <> "" Then
            finConsulta = finConsulta & " And s1.tiposus=" & tbSuspen.Rows(cmbTipo.SelectedIndex).Item(1)
        End If
        If cmbGrado.Text.Trim <> "" Then
            finConsulta = finConsulta & " And s1.grado=" & tbGrado.Rows(cmbGrado.SelectedIndex).Item(1)
        End If
        If cmbAlta.Text.Trim <> "" Then
            finConsulta = finConsulta & " And s1.tipoal=" & tbAlta.Rows(cmbAlta.SelectedIndex).Item(1)
        End If
        If cmbEstado.Text.Trim <> "" Then
            finConsulta = finConsulta & " And s1.estado=" & cmbEstado.SelectedIndex
        End If

        'If TextAvisoFechaI.Visible = True Then
        '    finConsulta = finConsulta & consultaFechaI
        'Else
        '    If TextFechaInicio.Text <> "  /  /" Then
        '        If VerificacionFecha(TextFechaInicio) = True Then
        '            fechaTemp = TextFechaInicio.Text
        '            finConsulta = finConsulta & " And s1.fechai='" & fechaTemp & "'"
        '        Else
        '            MsgBox("FORMATO DE FECHA INVALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
        '            Exit Sub
        '        End If
        '    End If
        'End If


        'If TextAvisoFechaF.Visible = True Then
        '    finConsulta = finConsulta & consultaFechaF
        'Else
        '    If textFechaF.Text <> "  /  /" Then
        '        If VerificacionFecha(textFechaF) = True Then
        '            fechaTemp = textFechaF.Text
        '            finConsulta = finConsulta & " and s1.fechaf='" & fechaTemp & "'"
        '        Else
        '            MsgBox("FORMATO DE FECHA INVALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
        '            Exit Sub
        '        End If
        '    End If
        'End If

        finConsulta = axFechae.devuelveConsulta(finConsulta)

        cadenaConsulta = inicioConsulta & finConsulta & " order by numero asc"
        Mostrar(cadenaConsulta, sender, e)
    End Sub

    Private Sub Mostrar(ByVal subCadena As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        axFechae.EsModoConsulta = False

        ConsultaReadOnly(gpDatos, True)
        btnEmpleado.Enabled = False
        btnContrato.Enabled = False
        SoloLeer(gpDatos, True)
        btnBuscar.Enabled = False
        ContextoMenuEnab(True, True, ctxMenu)
        TextConxNumero.ReadOnly = True
        indice = 0
        If llenaTabla(subCadena, tbConsulta) > 0 Then
            LlenarTextBox(0, tbConsulta)
            dgvConsulta.DataSource = tbConsulta
        Else
            MsgBox("NO HAY REGISTROS CON ESTOS CRITERIOS DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
        End If
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub




    Private Sub LlenarTextBox(ByVal indi As Int16, ByVal tabla As DataTable)
        Dim filaCopiar As DataRow
        filaCopiar = tabla.Rows.Item(indi)
        TextConxNumero.Text = filaCopiar.Item("numero")
        textConxEmpleado.Text = filaCopiar.Item("empleado")
        ValidaEmpleado()
        TextConxContrato.Text = filaCopiar.Item("contrato")
        BuscaElementoCombo(tbSuspen, filaCopiar.Item("tiposus"), cmbTipo, 1, True)

        BuscaElementoCombo(tbGrado, filaCopiar.Item("grado"), cmbGrado, 1, True)

        dpFechai.Value = filaCopiar.Item("fechai")
        dpFechaf.Value = filaCopiar.Item("fechaf")
        If filaCopiar.Item("fechaf") <> "01/01/1900" Then
            dpFechaf.Value = filaCopiar.Item("fechaf")
            dpFechaf.Visible = True
        Else
            dpFechaf.Visible = False
            dpFechaf.Value = Today
        End If

        BuscaElementoCombo(tbAlta, filaCopiar.Item("tipoal"), cmbAlta, 1, False)

        TextCantidad.Text = filaCopiar.Item("cantidad")
        TextValor.Text = formato(filaCopiar.Item("valor"))
        TextObservaciones.Text = filaCopiar.Item("observa")
        opcMod = filaCopiar.Item(11)
        cmbEstado.SelectedIndex = opcMod
        Select Case filaCopiar.Item(11)
            Case 0

                ctxModificar.Enabled = True
                ctxEliminar.Enabled = True
                ctxAlta.Enabled = True
            Case 1
                ctxModificar.Enabled = False
                ctxEliminar.Enabled = False
                ctxAlta.Enabled = False
            Case 2
                ctxModificar.Enabled = True
                ctxEliminar.Enabled = False
                ctxAlta.Enabled = False
        End Select
        dpFechai.Enabled = False
        dpFechaf.Enabled = False
        TextEstado.Text = cmbEstado.Text
        axFechae.Datevalue1 = filaCopiar.Item("fechae")
        axFechae.EsModoConsulta = False
        TextUsuario.Text = filaCopiar.Item("usuario")
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        'axFechaInicio

        axFechae.reiniciaControl()
        axFechae.EsModoConsulta = True

        'axFechaAlta
        dgvConsulta.DataSource = Nothing

        opcMod = 0
        TextConxNumero.ReadOnly = False
        TextConxNumero.Clear()
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnBuscar.Enabled = True
        btnBuscar.Visible = True
        btnGuardar.Visible = False
        btnContrato.Enabled = True
        btnEmpleado.Enabled = True
        ContextoMenuEnab(True, False, ctxMenu)
        borra_Mejorado(gpDatos, ep1)
        ConsultaReadOnly(gpDatos, False)
        SoloLeer(gpDatos, False)

        textConxEmpleado.Focus()
    End Sub


#Region "FECHA"
    Private Sub btnFechaIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        f = New frmConsultaFechas
        f.TopMost = True
        AddHandler f.actValor, AddressOf ActualizacionDatosFechaIni
        f.inicializador("s1", "fechai")
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosFechaIni(ByVal sender As Object, ByVal e As clsActValorREvento)
        consultaFechaI = e.va1

    End Sub

    Private Sub btnFechaFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        f = New frmConsultaFechas
        f.TopMost = True
        AddHandler f.actValor, AddressOf ActualizacionDatosFechaFin
        f.inicializador("s1", "fechaf")
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosFechaFin(ByVal sender As Object, ByVal e As clsActValorREvento)
        consultaFechaF = e.va1
    End Sub

#End Region



#Region "Menu contextual"

    Private Sub ctxAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAlta.Click
        If MsgBox("ESTA SEGURO DE DAR DE ALTA ESTA SUSPENSION", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            fAlta = New frmAltaSus
            fAlta.TopMost = True
            AddHandler fAlta.actValor, AddressOf ActualizacionDatosAlta
            fAlta.Inicializa(CInt(TextConxNumero.Text), CInt(TextConxContrato.Text), CInt(textConxEmpleado.Text), dpFechai.Value.Date)
            fAlta.StartPosition = FormStartPosition.CenterScreen
            fAlta.ShowDialog()
        End If
    End Sub


    Private Sub ActualizacionDatosAlta(ByVal sender As Object, ByVal e As clsActValorREvento)
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub ctxEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        If MsgBox("ESTA SEGURO DE ANULAR ESTA SUSPENSION", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            cadena = "update suspensiones set estado=1, fechae='" & Today.ToShortDateString & "' where  empresa=" & empresa &
                     " and numero=" & TextConxNumero.Text
            EjecutarQuery(cadena)
            InsertBitacora(9, 3, Me.Text)
            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
            Exit Sub
        End If
    End Sub

    Private Sub ctxModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnBuscar.Visible = False
        btnGuardar.Visible = True
        ContextoMenuEnab(False, True, ctxMenu)
        If opcMod = 0 Then
            cmbTipo.Enabled = True
            dpFechai.Enabled = True
            cmbTipo.BackColor = ColorModi
            cmbGrado.Enabled = True

            cmbGrado.BackColor = ColorModi
            TextObservaciones.ReadOnly = False
            TextObservaciones.BackColor = ColorModi
        Else

        End If
    End Sub
#End Region

    Private Sub textFecha_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        lpara.Clear()
        Dim fechaF, fechaI As Date
        Dim diferencia, base As Int32
        Dim tibase As String
        Dim valor As Decimal
        If opcMod <> 0 Then
            'If validetError(textFechaF, ep1) = True Then
            fechaF = dpFechaf.Value.Date
            fechaI = dpFechai.Value.Date
            If fechaF < fechaI Then
                MsgBox("FECHA FINAL DEBE SER MAYOR QUE LA FECHA DE INICIO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                TextCantidad.Clear()
                TextValor.Text = "0.00"
                Exit Sub
            End If
            lpara("empresa") = empresa
            lpara("empleado") = textConxEmpleado.Text
            lpara("contrato") = TextConxContrato.Text
            cadena = "SELECT tp.tibase, tb.base  FROM CONTRATOS1 C1 inner join tipopersonal tp on c1.empresa= tp.empresa " &
                     "and c1.tipoper=tp.tipoper inner join tiposbase tb on c1.empresa=tb.empresa and  " &
                     "tp.tibase=tb.tibase where c1.empresa=@empresa  and empleado=@empleado and contrato=@contrato"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                tibase = dr.Item(0)
                base = dr.Item(1)
            Else
                tibase = ""
                base = 0
            End If
            dr.Close()
            cadena = "select coalesce (sum(valor),0)  from sueldos where afecta='S' and transac=1  and empresa=@empresa" &
                     " and contrato=@contrato and empleado=@empleado"
            valor = BuscaEscalar(cadena, ListaParametros(lpara))
            diferencia = (fechaF.Day - fechaI.Day) + ((fechaF.Month - fechaI.Month) * 30) + ((fechaF.Year - fechaI.Year) * 360)
            If tibase = "D" Then
                TextCantidad.Text = diferencia
            ElseIf tibase = "H" Then
                TextCantidad.Text = (diferencia * base) / 30
            Else
                TextCantidad.Text = ""
            End If
            TextValor.Text = formato((valor / base) * CInt(TextCantidad.Text))
            'Else
            '    TextCantidad.Clear()
            '    TextValor.Text = "0.00"
            'End If
        Else
            TextCantidad.Clear()
            TextValor.Text = "0.00"
        End If
    End Sub



    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        lpara.Clear()
        Dim tipo, grado As String
        Dim fechai, fechaf As Date
        Dim modelo As New cmodelo
        If opcMod = 0 Then
            If validetError(textConxEmpleado, ep1) = False Or validetError(TextConxContrato, ep1) = False Or
             validetError(cmbTipo, ep1) = False Or validetError(cmbGrado, ep1) = False Or validetComilla(TextObservaciones, ep1) = False Then
                MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If
            fechai = dpFechai.Value
            tipo = tbSuspen.Rows(cmbTipo.SelectedIndex).Item(1)
            grado = tbGrado.Rows(cmbGrado.SelectedIndex).Item(1)

            Try
                If MsgBox("ESTA SEGURO QUE DESEA ACTUALIZAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                    lpara("empresa") = empresa
                    lpara("tiposus") = tipo
                    lpara("fechai") = fechai
                    lpara("observa") = TextObservaciones.Text
                    lpara("grado") = grado
                    lpara("numero") = TextConxNumero.Text
                    cadena = "update suspensiones set tiposus=@tiposus,fechai=@fechai,observa=@observa,grado=@grado where empresa=@empresa and numero=@numero"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    '  EjecutarQuery(cadena)
                    modelo.Commit()
                    InsertBitacora(9, 2, $"Modificación de la suspensión {TextConxNumero.Text}")
                    btnLimpiar_Click(sender, e)
                    MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("ERROR EN EL INGRESO DE DATOS", MsgBoxStyle.Critical, "Mensaje del Sistema")
                modelo.RollBack()
            End Try
        Else
            If validetError(textConxEmpleado, ep1) = False Or validetError(TextConxContrato, ep1) = False Then
                MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If
            fechaf = dpFechaf.Value
            If fechaf < dpFechai.Value Then
                MsgBox("FECHA FINAL DEBE SER MAYOR QUE LA FECHA INICIAL", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If
            lpara.Clear()
            Try
                If MsgBox("ESTA SEGURO QUE DESEA ACTUALIZAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                    lpara("fechaf") = fechaf
                    lpara("cantidad") = TextCantidad.Text
                    lpara("valor") = CDec(TextValor.Text)
                    lpara("empresa") = empresa
                    lpara("numero") = TextConxNumero.Text
                    cadena = "update suspensiones set  fechaf=@fechaf, cantidad=@cantidad, valor=@valor where empresa=@empresa and numero=@numero"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    modelo.Commit()
                    InsertBitacora(9, 2, $"Modificación de la suspensión {TextConxNumero.Text} ya establecida")
                    btnLimpiar_Click(sender, e)
                    MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("ERROR EN EL INGRESO DE DATOS", MsgBoxStyle.Critical, "Mensaje del Sistema")
                modelo.RollBack()
            End Try
        End If
    End Sub

    Private Sub frmRutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub


    Private Sub TextConxContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextConxContrato.KeyPress,
    textConxEmpleado.KeyPress, TextConxNumero.KeyPress
        soloNumero(sender, e)
    End Sub



    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
      cmbTipo.Enter, cmbGrado.Enter, TextObservaciones.Enter, textConxEmpleado.Enter, textNombreEmple.Enter,
      TextConxContrato.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
      cmbTipo.Leave, cmbGrado.Leave, TextObservaciones.Leave, textConxEmpleado.Leave, textNombreEmple.Leave,
      TextConxContrato.Leave
        desactiva(sender)
    End Sub

#Region "Botones Siguiente"
    Private Sub btnSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSig.Click
        indice = indice + 1
        LlenarTextBox(indice, tbConsulta)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub

    Private Sub btnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtr.Click
        indice = indice - 1
        LlenarTextBox(indice, tbConsulta)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub

#End Region

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub



End Class