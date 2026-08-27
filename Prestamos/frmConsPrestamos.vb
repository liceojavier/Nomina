Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine.ReportDocument
Imports ControllersERP.Nominas


'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCONSPRESTAMOS.VB MIEMBRO DE NOMINA.SLN                                   **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmConsPrestamos
    Dim cadena As String

    Dim tbTipo As New DataTable("tipo")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")
    Dim tbConsulta As New DataTable("consulta")
    Dim tbImpresion As New DataTable("impresion")
    Dim tbtipoNom As New DataTable("tiponom")
    Dim filaTemp As DataRow
    Dim opd As Short = 0
    Dim idprestamo2 As Int32 = 0

    Dim WithEvents fEmp As frmMuestraCodigos
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim WithEvents fConsN As frmConsultaNumero
    Dim WithEvents f As frmConsultaFechas
    Dim inicioConsulta As String = "select p1.prestamo, p1.fecha, p1.tipopre, p1.empleado, p1.contrato,  p1.valor, p1.saldo, p1.meses, p1.descuento, p1.mesini, p1.añoini," &
                                   "p1.observa, p1.estado, p1.fechae, p1.usuario, p2.tipodocto,p2.docto, p2.cargos, p1.desc_bono14, p1.desc_aguinaldo from  " &
                                   " prestamos1 p1 inner join prestamos2 p2 on p1.empresa=p2.empresa and p1.prestamo=p2.prestamo and p2.cargos <> 0 and p2.tipodocto in ('CH','O')" &
                                   " where p1.empresa=" & empresa
    Dim consultaFecha, consultasaldo As String
    Dim indice As Integer

    Dim fMuestra As FrmMuestraReporte
    Dim cr As New MovCtaCorriente
    Dim lpara As New Dictionary(Of String, Object)
    Dim ctrPres As New PrestamosController()
    Dim _prestamo As Int32 = 0
    Dim _Estado As Short = 0

    Public Property nuevo_registro As Boolean = False


    Private Sub frmIngPuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        TextEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=@empresa", ListaParametros(lpara))
        cadena = "select nombre, tipopre from tiposprestamo where empresa=@empresa order by tipopre"
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cadena = "select nombre, mes from meses order by mes"
        llena_combo(cadena, cmbMes)
        llena_combo(cadena, cmbMesDet)
        cmbMes.Items.Add("")
        cmbMesDet.Items.Add("")



        cadena = "select nombre,tiponom from tiponomina1 where empresa=@empresa"
        llenaTabla(cadena, tbtipoNom, ListaParametros(lpara))
        llena_combo(cadena, cmbTipNom, ListaParametros(lpara))
        cmbTipNom.Items.Add("")
        ctrPres.FillComboPrestamosEstado(cmbEstado, True)


        If nuevo_registro Then
            es_nuevo_registro(True)
        Else
            es_nuevo_registro(False)
        End If

        axFechaIngreso.Datevalue1 = Today
        axFechaIngreso.Datevalue2 = Today
        limpiar()
    End Sub



    Private Sub es_nuevo_registro(ByVal valor)
        btnBuscar.Visible = Not valor
        btnSig.Visible = Not valor
        btnSaldo.Visible = Not valor
        btnAtr.Visible = Not valor
        btnCtaCorr.Visible = Not valor
        btnDescMensual.Visible = valor
        If valor Then
            TabControl1.TabPages.Remove(TabDetalle)
            TabControl1.TabPages.Remove(TabConsulta)
        End If

        pnPrincipal.Visible = Not valor
        TextValor.ReadOnly = Not valor
        pnNoCuotas.Visible = valor
        gpSaldo.Visible = Not valor
        ctxPrincipal.Visible = Not valor
        axFechaIngreso.Visible = Not valor
        dpFechaI.Visible = valor
    End Sub


#Region "EMLEADO"


    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        TextConxContrato.Clear()
        If valbool = True Then
            textConxEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombreEmple.Text.Trim
        Dim condi As String = ""
        If nuevo_registro Then
            condi = " and activo=1 "
        Else
            condi = ""
        End If

        cadena = $"select empleado, nombre from v_empleadosNuevo where empresa=@empresa and nombre like '%' + @nombre + '%' {condi} order by nombre"

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
        Dim tbInfo As New DataTable()
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
            Dim condi As String = ""
            If nuevo_registro Then
                condi = " and activo=1 "
            Else
                condi = ""
            End If

            cadena = $"select empleado, nombre from v_empleadosNuevo where empresa=@empresa and empleado=@empleado {condi}"
            llenaTabla(cadena, tbInfo, ListaParametros(lpara))
            If tbInfo.Rows.Count > 0 Then

                llenaInfo(tbInfo.Rows(0))
                TextConxContrato.Focus()
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
        llenaInfo(filaTemp)

    End Sub

    Private Sub llenaInfo(fila As DataRow)
        TextConxContrato.Clear()
        textConxEmpleado.Text() = fila.Item(0)
        textNombreEmple.Text = fila.Item(1)
    End Sub





#End Region

#Region "Contrato"

    Private Sub BtnContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrato.Click
        Dim Num As Int16
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textConxEmpleado.Text
        Dim condi As String = ""
        If nuevo_registro Then
            condi = " and e.activo='S' "
        End If
        If textConxEmpleado.Text.Trim <> "" Then
            cadena = $"select contrato, pu.nombre from contratos1 c1 inner join empestados e on e.estado=c1.estado " &
                     "and e.empresa=c1.empresa " &
                     "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                     $"where  c1.empresa=@empresa and empleado=@empleado {condi}"
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

    Private Sub TextConxContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextConxContrato.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextConxContrato_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextConxContrato.Validated
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textConxEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        Dim condi As String = ""
        If nuevo_registro Then
            condi = " and c1.estado in (0,4) "
        End If

        If TextConxContrato.Text.Trim <> "" And textConxEmpleado.Text.Trim <> "" Then
            cadena = $"select count(*) from contratos1 c1 where c1.empresa=@empresa and empleado=@empleado and contrato=@contrato {condi}"
            If BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                MsgBox("ESTE NUMERO DE CONTRATO NO EXISTE PARA ESTE EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            TextConxContrato.Clear()
        End If
    End Sub


#End Region

    Private Sub btnCtaCorr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtaCorr.Click
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("prestamo") = TextConxPrestamo.Text
        cadena = "select * from v_Prestamos where empresa=@empresa and prestamo=@prestamo order by fechaT"
        If llenaTabla(cadena, tbImpresion, ListaParametros(lpara)) > 0 Then
            fMuestra = New FrmMuestraReporte
            fMuestra.Inicializacion(cr, tbImpresion, CrystalDecisions.Shared.PaperSize.PaperLetter)
            fMuestra.StartPosition = FormStartPosition.CenterScreen
            fMuestra.TopMost = True
            InsertBitacora(9, 5, Me.Text)
            fMuestra.ShowDialog()
        Else
            MsgBox("NO HAY DATOS PAGA GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        lpara.Clear()
        Dim finConsulta, cadenaConsulta As String

        finConsulta = " and 1=1"
        GeneraConsulta(gpDatos, finConsulta, "P1")

        If cmbTipo.Text.Trim <> "" Then
            lpara("tipo") = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
            finConsulta = finConsulta & " and p1.tipopre=@tipo "
        End If
        If cmbMes.Text.Trim <> "" Then
            lpara("mesini") = cmbMes.SelectedIndex
            finConsulta = finConsulta & " and p1.mesini=@mesini "
        End If
        Dim año As Short = 0
        If Short.TryParse(TextAño.Text, año) Then
            lpara("añoini") = año
            finConsulta = finConsulta & " and p1.añoini=@añoini "
        End If
        If cmbEstado.Text.Trim <> "" Then
            lpara("estado") = cmbEstado.SelectedValue
            finConsulta = finConsulta & " and p1.estado=@estado "
        End If
        Select Case cmbTipoDoc.SelectedIndex
            Case 0
                finConsulta = finConsulta & " and p2.tipodocto='CH'"
            Case 1
                finConsulta = finConsulta & " and p2.tipodocto='O'"
        End Select




        'If TextAvisoFecha.Visible = True Then
        '    finConsulta = finConsulta & consultaFecha
        'Else
        '    If TextFecha.Text <> "  /  /" Then
        '        If VerificacionFecha(TextFecha) = True Then
        '            fechaTemp = TextFecha.Text
        '            finConsulta = finConsulta & " and p1.fecha='" & fechaTemp & "'"
        '        Else
        '            MsgBox("FORMATO DE FECHA INVALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
        '            Exit Sub
        '        End If
        '    End If
        'End If



        If TextSaldo.ReadOnly = True Then
            finConsulta = finConsulta & consultasaldo
        Else
            If TextSaldo.Text.Trim <> "" Then
                finConsulta = finConsulta & " and p1.saldo=" & CDec(TextSaldo.Text)
            End If
        End If
        finConsulta = axFechaIngreso.devuelveConsulta(finConsulta)
        cadenaConsulta = inicioConsulta & finConsulta & " order by p1.prestamo"
        Mostrar(cadenaConsulta, sender, e)
    End Sub

    Private Sub Mostrar(ByVal subCadena As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        ConsultaReadOnly(gpDatos, True)
        textNombreEmple.ReadOnly = True
        TextSaldo.ReadOnly = True
        btnEmpleado.Enabled = False
        btnContrato.Enabled = False
        SoloLeer(gpDatos, True)
        btnSaldo.Enabled = False

        btnBuscar.Enabled = False
        btnCtaCorr.Enabled = True
        ContextoMenuEnab(True, True, ctxPrincipal)
        indice = 0
        If llenaTabla(subCadena, tbConsulta, ListaParametros(lpara)) > 0 Then
            LlenarTextBox(0, tbConsulta)
        Else
            MsgBox("NO HAY REGISTROS CON ESTOS CRITERIOS DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
        End If
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub

    

    Private Sub LlenarTextBox(ByVal indi As Int16, ByVal tabla As DataTable)
        Dim filaCopiar As DataRow
        lpara.Clear()
        lpara("empresa") = empresa
        filaCopiar = tabla.Rows.Item(indi)
        TextConxPrestamo.Text = filaCopiar.Item("prestamo")
        _prestamo = filaCopiar("prestamo")
        axFechaIngreso.Datevalue1 = filaCopiar.Item("fecha")
        BuscaElementoCombo(tbTipo, filaCopiar.Item("tipopre"), cmbTipo, 1, True)
        textConxEmpleado.Text = filaCopiar.Item("empleado")
        ValidaEmpleado()
        TextConxContrato.Text = filaCopiar.Item("contrato")
        TextValor.Text = formato(filaCopiar.Item("valor"))

        TextSaldo.Text = formato(filaCopiar.Item("saldo"))
        txtMeses.Text = filaCopiar.Item("meses")
        TextDescuento.Text = formato(filaCopiar.Item("descuento"))
        cmbMes.SelectedIndex = filaCopiar.Item("mesini") - 1

        TextAño.Text = filaCopiar.Item("añoini")
        TextObservaciones.Text = filaCopiar.Item("observa")
        '     cmbEstado.SelectedIndex = filaCopiar.Item(12)
        _Estado = filaCopiar("estado")
        Select Case filaCopiar.Item("estado")
            Case 0
                ctxAnulacion.Enabled = True
                ctxModificar.Enabled = True
                ctxReactivacion.Enabled = False
            Case 1
                ctxAnulacion.Enabled = False
                ctxModificar.Enabled = False
                ctxReactivacion.Enabled = True
            Case 2
                ctxAnulacion.Enabled = False
                ctxModificar.Enabled = False
                ctxReactivacion.Enabled = True
        End Select
        cmbEstado.SelectedValue = filaCopiar("estado")
        TextEstado.Text = cmbEstado.Text
        TextFechae.Text = filaCopiar.Item("fechae")
        TextUsuario.Text = filaCopiar.Item("usuario")
        Select Case filaCopiar.Item("tipodocto").ToString.Trim
            Case "CH"
                cmbTipoDoc.SelectedIndex = 0
            Case "O"
                cmbTipoDoc.SelectedIndex = 1
        End Select

        TextNoDocto.Text = filaCopiar.Item("docto")
        textDescBono.Text = formato(filaCopiar.Item("desc_bono14"))
        textDescAguinaldo.Text = formato(filaCopiar.Item("desc_aguinaldo"))
        lpara("prestamo") = TextConxPrestamo.Text
        'cadena = "Select coalesce(sum(abonos), 0) from prestamos2 where empresa=@empresa And prestamo=@prestamo"
        'abonos = BuscaEscalar(cadena, ListaParametros(lpara))

        llenaDetalle(TextConxPrestamo.Text, TextEstado.Text)

    End Sub

    Private Sub btnSaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaldo.Click
        fConsN = New frmConsultaNumero
        fConsN.TopMost = True
        AddHandler fConsN.actValor, AddressOf ActualizacionSaldo
        fConsN.inicializador("p1", "saldo", 8, 2)
        fConsN.StartPosition = FormStartPosition.CenterScreen
        fConsN.ShowDialog()
    End Sub

    Private Sub ActualizacionSaldo(ByVal sender As Object, ByVal e As clsActValorREvento)
        consultasaldo = e.va1
        TextSaldo.ReadOnly = True
        TextSaldo.Text = AvisoFecha(e.va2)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Private Sub limpiar()

        _prestamo = 0
        dpFechaI.Value = Today
        axFechaIngreso.reiniciaControl()
        axFechaIngreso.EsModoConsulta = True
        _Estado = 0
        btnAgregarDet.Enabled = False
        TextSaldo.ReadOnly = False
        TextDescuento.ReadOnly = False
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnBuscar.Enabled = True
        btnBuscar.Enabled = True
        ctxDetalle.Enabled = False
        btnEmpleado.Enabled = True
        btnContrato.Enabled = True
        textNombreEmple.ReadOnly = False
        txtAbonos.Text = "0.00"
        borra_Mejorado(gpDatos, ep1)
        txtCargos.Text = "0.00"
        btnSaldo.Enabled = True
        btnCtaCorr.Enabled = False
        textConxEmpleado.Focus()
        lpara.Clear()
        lpara("empresa") = empresa
        If Me.nuevo_registro Then
            TextConxPrestamo.Text = BuscaEscalar("select coalesce( max(prestamo),0) from prestamos1 where empresa=@empresa", ListaParametros(lpara)) + 1
            TextConxPrestamo.ReadOnly = True

        Else
            TextObservaciones.ReadOnly = True
            TextSaldo.ReadOnly = True
            TextValor.ReadOnly = True
            textDescAguinaldo.ReadOnly = True
            textDescBono.ReadOnly = True
            txtMeses.ReadOnly = True
            TextNoDocto.ReadOnly = True
            TextConxPrestamo.ReadOnly = False
            ContextoMenuEnab(True, False, ctxPrincipal)
            SoloLeer(gpDatos, False)
            ConsultaReadOnly(gpDatos, False)
            btnGuardar.Enabled = False
        End If

        dgvDatos.DataSource = Nothing
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim tipoDoc As String = ""
        Dim año As Short = 0
        Dim valor As Decimal = 0.00
        Dim descuento As Decimal = 0.00
        Dim desc_bono14 As Decimal = 0.00
        Dim desc_aguinaldo As Decimal = 0.00
        Dim cantidad As Int32
        lpara.Clear()
        If validetError(textConxEmpleado, ep1) AndAlso validetError(TextConxContrato, ep1) AndAlso
         validetError(TextValor, ep1) AndAlso validetError(TextDescuento, ep1) AndAlso
         validetError(cmbMes, ep1) AndAlso Short.TryParse(TextAño.Text, año) AndAlso validetError(textDescAguinaldo, ep1) AndAlso validetError(textDescBono, ep1) AndAlso
         validetError(cmbTipoDoc, ep1) AndAlso validetError(TextNoDocto, ep1) And Decimal.TryParse(textDescBono.Text, desc_bono14) AndAlso Int32.TryParse(txtMeses.Text, cantidad) AndAlso
          Decimal.TryParse(textDescAguinaldo.Text, desc_aguinaldo) AndAlso Decimal.TryParse(TextValor.Text, valor) AndAlso Decimal.TryParse(TextDescuento.Text, descuento) AndAlso
          validetError(cmbTipo, ep1) Then

            Select Case cmbTipoDoc.SelectedIndex
                Case 0
                    tipoDoc = "CH"
                Case 1
                    tipoDoc = "O"
            End Select

            If cantidad <= 0 Then
                MsgBox("Cantidad de cuotas debe ser mayor a 0")
                Exit Sub
            End If
            If valor <= 0 Or descuento <= 0 Then
                MsgBox("El valor del descuento ser mayor a 0.00 y el descuento deben ser mayor a 0.00")
                Exit Sub
            End If

            If desc_aguinaldo < 0 Or desc_bono14 < 0 Then
                MsgBox("El valor del descuento de aguinaldo y bono 14 no pueden ser números decimales")
                Exit Sub
            End If


            Dim modelo As New cmodelo


            Decimal.Round((CDec(TextValor.Text) / CInt(txtMeses.Text)), 2)

            lpara("empresa") = empresa
            lpara("prestamo") = CInt(TextConxPrestamo.Text)

            lpara("tipo") = tbTipo.Rows(cmbTipo.SelectedIndex).Item("tipopre")
            lpara("empleado") = CInt(textConxEmpleado.Text)
            lpara("contrato") = CInt(TextConxContrato.Text)
            lpara("valor") = valor
            lpara("meses") = cantidad
            lpara("descuento") = descuento
            lpara("mesini") = cmbMes.SelectedIndex + 1
            lpara("añoini") = año
            lpara("observa") = TextObservaciones.Text
            lpara("fechae") = Today
            lpara("usuario") = user
            lpara("tipodocto") = tipoDoc
            lpara("docto") = TextNoDocto.Text
            lpara("cargos") = valor
            lpara("desc_aguinaldo") = desc_aguinaldo
            lpara("desc_bono14") = desc_bono14
            Try
                If MsgBox("DESEA ACTUALIZAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then

                    If Not nuevo_registro Then
                        cadena = "update prestamos1 Set valor=@valor ,
                          descuento=@descuento, observa=@observa, 
                          mesini=@mesini, añoini=@añoini, desc_aguinaldo=@desc_aguinaldo, desc_bono14=@desc_bono14 
                          where empresa=@empresa and prestamo=@prestamo and empleado=@empleado and contrato=@contrato"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                        cadena = "update prestamos2 set tipodocto=@tipodocto, docto=@docto, cargos=@valor where empresa=@empresa and prestamo=@prestamo and abonos=0"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    ElseIf nuevo_registro Then
                        lpara("fecha") = dpFechaI.Value.Date

                        cadena = "insert into  prestamos1 (empresa,prestamo,fecha,tipopre,empleado,contrato,valor,saldo,meses,descuento,mesini,añoini,observa,estado,fechae,usuario, desc_bono14, desc_aguinaldo) 
                          values (@empresa,@prestamo,@fecha,@tipo,@empleado,@contrato,@valor,@valor,@meses,@descuento,@mesini,@añoini,@observa,0,@fechae,@usuario,@desc_bono14,@desc_aguinaldo)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                        cadena = "insert into  prestamos2 (empresa,prestamo,fecha,tipodocto,docto,cargos,abonos,tiponom, mes, año, usuario) 
                          values (@empresa,@prestamo,@fecha,@tipodocto,@docto,@cargos,0.00,'',0,0,@usuario)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    End If


                    If modelo.Commit() Then
                        InsertBitacora(9, 2, $"Grabacion o modificación del prestamo {TextNoDocto.Text }")

                        MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                        If Me.nuevo_registro Then
                            limpiar()
                        End If
                    End If

                End If
            Catch ex As Exception
                MsgBox("ERROR EN LA ACTUALIZACION DE DATOS", MsgBoxStyle.Critical, "Mensaje del Sistema")
                modelo.RollBack()
            End Try

        Else

            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")

        End If





    End Sub

    Private Sub frmRutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
      cmbTipo.Enter, TextObservaciones.Enter, textConxEmpleado.Enter, textNombreEmple.Enter,
      TextConxContrato.Enter, TextValor.Enter, txtMeses.Enter, cmbMes.Enter, cmbTipoDoc.Enter, TextNoDocto.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub


    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
      cmbTipo.Leave, TextObservaciones.Leave, textConxEmpleado.Leave, textNombreEmple.Leave,
      TextConxContrato.Leave, TextValor.Enter, txtMeses.Leave, cmbMes.Leave, cmbTipoDoc.Leave, TextNoDocto.Leave
        desactiva(sender)
    End Sub

    Private Sub TextValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextValor.KeyPress,
    TextSaldo.KeyPress, TextDescuento.KeyPress, txtValorDet.KeyPress
        soloNumeroDec(sender, e)
    End Sub

    Private Sub TextValor_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValor.Validated
        validatedDecimalPreci(sender, 8, 2)

    End Sub



    Private Sub TextDescuento_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextDescuento.Validated
        validatedDecimalPreci(sender, 8, 2)

    End Sub

    Private Sub TextDescuento_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextDescuento.Enter, TextValor.Enter,
    TextSaldo.Enter
        EntraDecimal(sender)
    End Sub



    Private Sub TextSaldo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextSaldo.Validated
        validatedDecimalPreci(sender, 8, 2)
    End Sub


#Region "OPCIONES DE MENU CONCEPTUAL"
    Private Sub ctxAnulacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAnulacion.Click
        lpara.Clear()
        lpara("fechae") = Today
        lpara("empresa") = empresa
        lpara("prestamo") = TextConxPrestamo.Text
        If MsgBox("ESTA SEGURO DE ANULAR ESTE DESCUENTO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            cadena = "update prestamos1 set estado=1, fechae=@fechae where empresa=@empresa and prestamo=@prestamo"
            EjecutarQuery(cadena, ListaParametros(lpara))
            MsgBox("OPERACION REALIZA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
            Exit Sub
        End If
    End Sub

    Private Sub ctxReactivarContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxReactivacion.Click
        lpara.Clear()
        lpara("fechae") = Today
        lpara("empresa") = empresa
        lpara("prestamo") = TextConxPrestamo.Text
        If MsgBox("ESTA SEGURO DE REACTIVAR ESTE DESCUENTO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            cadena = "update prestamos1 set estado=0, fechae=@fechae where empresa=@empresa and prestamo=@prestamo"
            EjecutarQuery(cadena, ListaParametros(lpara))
            MsgBox("OPERACION REALIZA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
            Exit Sub
        End If
    End Sub

    Private Sub ctxModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click

        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnBuscar.Enabled = False
        btnGuardar.Enabled = True
        ContextoMenuEnab(False, True, ctxPrincipal)
        TextValor.ReadOnly = False
        textDescBono.ReadOnly = False
        textDescAguinaldo.ReadOnly = False
        TextValor.BackColor = ColorModi
        TextDescuento.ReadOnly = False
        TextDescuento.BackColor = ColorModi
        TextObservaciones.ReadOnly = False
        TextObservaciones.BackColor = ColorModi
        cmbTipoDoc.Enabled = True

        TextNoDocto.ReadOnly = False
        TextNoDocto.BackColor = ColorModi
        lpara.Clear()
        lpara("prestamo") = _prestamo
        lpara("empresa") = empresa
        cadena = "Select coalesce(sum(abonos), 0) from prestamos2 where empresa=@empresa And prestamo=@prestamo"
        Dim abonos As Decimal = BuscaEscalar(cadena, ListaParametros(lpara))
        If abonos = 0 Then
            cmbMes.Enabled = True
            TextAño.ReadOnly = False
        End If
    End Sub
#End Region


    Private Sub TextValor_Entra(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValor.Enter, TextSaldo.Enter
        EntraDecimal(sender)
    End Sub

    Private Sub TextEnteros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMeses.KeyPress,
    TextNoDocto.KeyPress
        soloNumero(sender, e)
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

    Private Sub axFechaIngreso_Load(sender As Object, e As EventArgs) Handles axFechaIngreso.Load

    End Sub

#End Region

    Private Sub btnBusCFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        f = New frmConsultaFechas
        f.TopMost = True
        AddHandler f.actValor, AddressOf ActualizacionDatosFecha
        f.inicializador("p1", "fecha")
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosFecha(ByVal sender As Object, ByVal e As clsActValorREvento)
        consultaFecha = e.va1
    End Sub

    Private Sub btnAgregarDet_Click(sender As Object, e As EventArgs) Handles btnAgregarDet.Click
        Dim cuenta As Int16 = 0
        Dim año As Short = 0
        Dim valor As Decimal = 0
        If Not Short.TryParse(txtAñoDet.Text, año) Or Not validetError(cmbMes, ep1) _
            Or Not validetError(txtValorDet, ep1) Or Not Decimal.TryParse(txtValorDet.Text, valor) Then
            MsgBox("Ingrese todos los valores necesarios", MsgBoxStyle.Information, "Mensaje del Sistema")
            Return
        Else
            lpara.Clear()
            lpara("empresa") = empresa
            lpara("prestamo") = TextConxPrestamo.Text
            lpara("empresa") = empresa
            lpara("mes") = cmbMesDet.SelectedIndex + 1
            lpara("año") = txtAñoDet.Text
            lpara("valor") = valor
            lpara("usuario") = usuario
            lpara("fecha") = Now.ToShortDateString
            lpara("idprestamo2") = idprestamo2

            If cmbTipNom.Text <> "" Then
                lpara("tiponom") = tbtipoNom.Rows(cmbTipNom.SelectedIndex).Item("tiponom")
            Else
                lpara("tiponom") = ""
            End If

            If opd = 0 Then
                cuenta = BuscaEscalar("select count(*) from prestamos2 where empresa=@empresa and prestamo=@prestamo and mes=@mes and año=@año and tiponom=@tiponom", ListaParametros(lpara))
                If CInt(cuenta) > 0 Then
                    MsgBox("Ya existe un valor con este mes y este año", MsgBoxStyle.Information, "Mensaje del sistema")
                    Return
                Else
                    cadena = "insert into prestamos2(empresa,prestamo,fecha,tipodocto,docto,cargos,abonos,tiponom,mes,año,usuario)"

                    If rbAbono.Checked Then 'abonos
                        cadena = cadena & "values(@empresa,@prestamo,@fecha,'A',0,0,@valor,@tiponom,@mes,@año,@usuario)"
                    Else 'cargos
                        cadena = cadena & "values(@empresa,@prestamo,@fecha,'A',0,@valor,0,@tiponom,@mes,@año,@usuario)"
                    End If
                    EjecutarQuery(cadena, ListaParametros(lpara))
                    limpiardetalle(TextConxPrestamo.Text)
                End If
            ElseIf opd = 1 Then
                If rbAbono.Checked Then
                    cadena = "update prestamos2 set abonos=@valor,cargos=0.00,mes=@mes,año=@año,tiponom=@tiponom where id_prestamos2=@idprestamo2 and prestamo=@prestamo and empresa=@empresa"
                Else
                    cadena = "update prestamos2 set cargos=@valor,abonos=0.00,mes=@mes,año=@año,tiponom=@tiponom where id_prestamos2=@idprestamo2 and prestamo=@prestamo and empresa=@empresa"
                End If
                EjecutarQuery(cadena, ListaParametros(lpara))
                limpiardetalle(TextConxPrestamo.Text)

            End If


        End If
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub mnuModificarDet_Click(sender As Object, e As EventArgs) Handles mnuModificarDet.Click
        Dim filadet As DataRow

        If dgvDatos.SelectedRows.Count > 0 Then
            opd = 1
            filadet = CType(dgvDatos.SelectedRows(0).DataBoundItem, DataRowView).Row

            Dim rows() As DataRow = tbtipoNom.Select("tiponom = '" & filadet("tiponom") & "'")

            If filadet("abonos") > 0 Then
                txtValorDet.Text = filadet("abonos")
            Else
                txtValorDet.Text = filadet("cargos")
            End If
            If rows.Length > 0 Then
                cmbTipNom.SelectedIndex = tbtipoNom.Rows.IndexOf(rows(0))
            Else
                cmbTipNom.SelectedIndex = -1
            End If


            cmbMesDet.SelectedIndex = filadet("mes") - 1
            txtAñoDet.Text = filadet("año")
            txtValorDet.Text = filadet("valor")
            idprestamo2 = filadet("id_prestamos2")
            btnAgregarDet.Text = "Modificar"
            btnAgregarDet.ImageIndex = 10

            If filadet("abonos") > 0 Then
                rbAbono.Checked = True
            Else
                rbCargo.Checked = True
            End If

        End If
    End Sub

    Private Sub btnDescMensual_Click(sender As Object, e As EventArgs) Handles btnDescMensual.Click
        Dim cuotas As Short = 0
        Dim valor As Decimal = 0
        Dim mesi As Int16
        Dim añoi As Int16
        Dim val_Agui As Decimal = 0
        Dim val_bono As Decimal = 0
        Dim lista As New List(Of MesAnioEntindad)
        TextDescuento.Text = "0.00"

        If cmbMes.Text.Trim = "" Then
            MsgBox("Debe ingresar el mes inicial para el inicio del cobro")
            Exit Sub
        Else
            mesi = cmbMes.SelectedIndex + 1
        End If

        If Not Short.TryParse(TextAño.Text, añoi) Then
            MsgBox("Debe ingresar el año inicial para el inicio del cobro")
            Exit Sub
        End If

        If Not Short.TryParse(TextAño.Text, añoi) Then
            MsgBox("Debe ingresar el año inicial para el inicio del cobro")
            Exit Sub
        End If

        If Not Decimal.TryParse(textDescAguinaldo.Text, val_Agui) Then
            MsgBox("Debe ingresar un valor igual a 0.00 o más en el valor del descuento de aguinaldo")
            Exit Sub
        End If

        If Not Decimal.TryParse(textDescBono.Text, val_bono) Then
            MsgBox("Debe ingresar un valor igual a 0.00 o más en el valor del descuento de bono 14")
            Exit Sub
        End If

        If (Decimal.TryParse(TextValor.Text, valor) AndAlso Short.TryParse(txtMeses.Text, cuotas)) Then
            Dim mesA As Short = mesi
            Dim añoA As Short = añoA
            Dim mesAnio As MesAnioEntindad
            For i As Short = 0 To cuotas - 1

                mesAnio = New MesAnioEntindad() With {
                        .anio = añoA,
                         .mes = mesA,
                         .nombre = ""
                    }
                lista.Add(mesAnio)
                mesA += 1
                If (mesA = 13) Then
                    mesA = 1
                    añoA += 1
                End If
            Next i

            Dim cant_bono As Int32 = lista.Where(Function(x) x.mes = 7).Count()
            Dim cant_agui As Int32 = lista.Where(Function(x) x.mes = 12).Count()

            Dim valCuota As Decimal = (valor - ((cant_agui * val_Agui) + (cant_bono * val_bono))) / cuotas

            TextDescuento.Text = formato(valCuota)
        Else
            MsgBox("Debe ingresar el valor total del prestamo y el número total de cuotas ordinarios")
        End If
    End Sub

    Private Sub ctxModCuota_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub llenaDetalle(ByVal numprestamo As String, ByVal estado As String)
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("prestamo") = numprestamo
        cadena = "select id_prestamos2,prestamo,tiponom,fecha,docto,año,mes,cargos,abonos,isnull(usuario,'') as usuario from prestamos2 where empresa=@empresa and prestamo=@prestamo order by fecha"
        If llenaTabla(cadena, tbImpresion, ListaParametros(lpara)) > 0 Then
            dgvDatos.DataSource = tbImpresion
            VistaGrid(dgvDatos)
            suma_totales()
        Else
            MsgBox("NO HAY DATOS PAGA GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
        lblestado.Text = estado
        If estado = "ACTIVO" Then
            btnAgregarDet.Enabled = True
        Else
            btnAgregarDet.Enabled = False
        End If
    End Sub

    Private Sub suma_totales()
        If dgvDatos.DataSource IsNot Nothing Then
            Dim tbDetalle As DataTable = dgvDatos.DataSource
            Dim tAbonos As Decimal = 0
            Dim tCargos As Decimal = 0
            For Each fila As DataRow In tbDetalle.Rows
                tAbonos += fila("abonos")
                tCargos += fila("cargos")
            Next

            txtAbonos.Text = formato(tAbonos)
            txtCargos.Text = formato(tCargos)
        End If
    End Sub



    Private Sub VistaGrid(ByRef dgVista As DataGridView)
        Try
            If dgVista.DataSource IsNot Nothing Then
                With dgVista
                    .Columns("id_prestamos2").Visible = False
                    .Columns("Prestamo").HeaderText = "Préstamo"
                    .Columns("prestamo").FillWeight = 10
                    .Columns("tiponom").HeaderText = "Tipo Nóm."
                    .Columns("tiponom").FillWeight = 10
                    .Columns("fecha").HeaderText = "Fecha"
                    .Columns("fecha").FillWeight = 15
                    .Columns("docto").HeaderText = "Documento"
                    .Columns("docto").FillWeight = 15
                    .Columns("año").HeaderText = "Año"
                    .Columns("año").FillWeight = 10
                    .Columns("mes").HeaderText = "Mes"
                    .Columns("mes").FillWeight = 10
                    .Columns("cargos").HeaderText = "Cargos"
                    .Columns("cargos").FillWeight = 10
                    .Columns("abonos").HeaderText = "Abonos"
                    .Columns("abonos").FillWeight = 10
                    .Columns("usuario").HeaderText = "Usuario"
                    .Columns("usuario").FillWeight = 10

                End With
            End If
        Catch ex As Exception
            MsgBox("Error del sistema " & vbNewLine & ex.Message)
        End Try


    End Sub

    Private Sub ctxModCuota_Click_1(sender As Object, e As EventArgs) Handles ctxModCuota.Click
        If _prestamo > 0 And _Estado = 0 Then
            btnAgregarDet.Enabled = True
            ctxDetalle.Enabled = True


        Else
            MsgBox("No ha ingresado ningún prestamo o el estado de un prestamo")
        End If
    End Sub

    Public Sub limpiardetalle(ByVal idprestamo As String)

        cmbMesDet.SelectedIndex = -1
        cmbTipNom.SelectedIndex = -1
        txtValorDet.Clear()
        rbAbono.Checked = True
        lblestado.Text = ""
        btnAgregarDet.Text = "Agregar"
        btnAgregarDet.ImageIndex = 9

        lpara.Clear()
        lpara("empresa") = empresa
        lpara("prestamo") = idprestamo
        cadena = "select id_prestamos2,prestamo,tiponom,fecha,docto,año,mes,cargos,abonos,isnull(usuario,'') as usuario from prestamos2 
                  where empresa=@empresa and prestamo=@prestamo order by fecha"
        llenaTabla(cadena, tbImpresion, ListaParametros(lpara))
        dgvDatos.DataSource = tbImpresion
        VistaGrid(dgvDatos)
        suma_totales()
    End Sub




End Class