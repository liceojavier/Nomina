Imports System.Data.SqlClient
Imports System.Object
Imports System.Drawing.Printing

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMINGCHEQUENOM.VB MIEMBRO DE NOMINA.SLN                                    **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmIngChequeNom
    Dim cadena As String
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim tbTipo As New DataTable("tipo")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")
    Dim tbMeses As New DataTable("meses")
    Dim tbDatos As New DataTable("datos")
    Dim tbCodigo As New DataTable("codigo")
    Dim tbBancos As New DataTable("bancos")
    Dim filaTemp As DataRow
    Dim formacal, extras, tipovalor, cuentaCheque2 As String
    Dim opc, IndiceTransac As Integer
    Dim WithEvents fEmp As frmMuestraCodigos
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim WithEvents f3C As frmMuestra3Columnas
    Dim banco, base, tipSeguro, transacSS As Integer
    Dim tibase, buses, tipomov, afectaSeguro, ctacte, cuentanom As String
    Dim fechaI, fechaF As Date
    Dim porSeg, horasDia, factor As Decimal
    Dim rawKind As Integer
    Dim v As New ChequeEver
    Dim WithEvents fOrig As frmBancos
    Dim tbOrigen As New DataTable
    Dim lpara As New Dictionary(Of String, Object)
    Dim ctrMes As New MesController(_conexion)
    Dim ctrTipoNom As New TipoNominasController

    Private Sub frmIngPuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ctrMes.FillComboMes(cmbMes, False)
        ctrTipoNom.FillComboTipoNomina(cmbTipo, True)
        Dim i As Integer
        Dim fechaActual As Date = Date.Today
        Dim doctoprint As New PrintDocument
        axFecha.Text = fechaActual

        EscribeEmpresa(TextEmpresa, TextMoneEmpresa)
        AgregarColumna(tbDatos, "transaccion", "System.String", "")
        AgregarColumna(tbDatos, "nombre", "System.String", "")
        AgregarColumna(tbDatos, "cantidad", "System.String", "")
        AgregarColumna(tbDatos, "valor", "System.String", "0.00")
        AgregarColumna(tbDatos, "importe", "System.String", "0.00")
        AgregarColumna(tbDatos, "devengado", "System.Decimal", "0.00")
        AgregarColumna(tbDatos, "descontado", "System.Decimal", 0)
        AgregarColumna(tbDatos, "seguro", "System.Decimal", 0)
        AgregarColumna(tbDatos, "tipomov", "System.String", "")
        AgregarColumna(tbDatos, "ctacte", "System.String", 0)
        AgregarColumna(tbDatos, "cuentanom", "System.String", 0)
        AgregarColumna(tbDatos, "bus", "System.String", 0)
        dgDatos.DataSource = tbDatos
        Vista(dgDatos)
        For i = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
            If doctoprint.PrinterSettings.PaperSizes(i).PaperName = "ChequeIvan" Then
                rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind",
                   Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                Exit For
            End If
        Next
        btnLimpiar_Click(sender, e)
    End Sub

#Region "TextCodigoBanco  y Boton BuscaBancp"

    Private Sub TextCodigoBanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextCodigoBanco.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextCodigoBanco_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextCodigoBanco.Validated
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("banco") = TextCodigoBanco.Text.Trim
        If TextCodigoBanco.Text.Trim <> "" Then
            cadena = "select  bancoscta.banco,  bancos.nombre + ' CTA ' + bancoscta.cta as nombBanCta, bancoscta.moneda, " &
                     "bancoscta.cheque, bancoscta.cuenta from bancoscta inner join bancos on bancoscta.codigo=bancos.codigo where bancoscta.empresa=@empresa " &
                     " and bancoscta.tipo=1 and bancoscta.estado=0 and bancoscta.banco=@banco order by bancoscta.banco asc"
            llenaTabla(cadena, tbBancos, ListaParametros(lpara))
            If tbBancos.Rows.Count > 0 Then
                filaTemp = tbBancos.Rows.Item(0)
                TextCta.Text = filaTemp.Item(1)
                TextMoneda.Text = filaTemp.Item(2)
                TextNoCheque.Text = filaTemp.Item(3) + 1
                cuentaCheque2 = filaTemp.Item(4)
                banco = filaTemp.Item(0)
                If TextMoneda.Text.Trim.ToUpper <> TextMoneEmpresa.Text.Trim.ToUpper Then
                    lpara("moneda") = TextMoneda.Text.Trim
                    TextTasa.Text = BuscaEscalar("select tasa from monedasban where moneda=@moneda", ListaParametros(lpara))
                Else
                    TextTasa.Clear()
                End If
                TextCodigoBanco.ReadOnly = True
                gpDatos.Enabled = True
                textEmpleado.Focus()
            Else
                MsgBox("EL CODIGO NO EXISTE", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextCodigoBanco.Text = ""
                btnBuscarCodigo_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnBuscarCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCodigo.Click
        lpara.Clear()
        lpara("empresa") = empresa
        If (TextCodigoBanco.Text.Trim = "") Then
            cadena = "select  bc.banco, b.nombre + ' CTA ' + bc.cta [nombBanCta], bc.moneda, bc.cheque, bc.cuenta from bancoscta bc " &
                     "inner join bancos b on bc.codigo=b.codigo and bc.empresa=b.empresa " &
                     "where bc.empresa=@empresa and bc.tipo=1 and bc.estado=0 order by bc.banco asc"
            If llenaTabla(cadena, tbBancos, ListaParametros(lpara)) > 0 Then

                EnBuscaOrigen()
                'gpInfoBancos.Visible = True
                'gpDatos.Visible = False
            Else
                MsgBox("DEBE INGRESAR PRIMERO UNA CUENTA BANCARIA DE DEPOSITOS MONETARIOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If
        End If
    End Sub

    Private Sub EnBuscaOrigen()

        fOrig = New frmBancos
        fOrig.TopMost = True
        fOrig.inicializa(tbBancos)
        AddHandler fOrig.actValor, AddressOf ActualizacionDatosOrigen
        fOrig.StartPosition = FormStartPosition.CenterScreen
        fOrig.ShowDialog()
    End Sub
    Private Sub ActualizacionDatosOrigen(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraOrigen(True)
        filaTemp = tbBancos.Rows.Item(e.va2)
        TextCodigoBanco.Text() = filaTemp.Item(0)
        TextCta.Text() = filaTemp.Item(1)
        TextMoneda.Text = filaTemp.Item(2)
        TextNoCheque.Text = filaTemp.Item(3) + 1
        cuentaCheque2 = filaTemp.Item(4)
        banco = filaTemp.Item(0)
        If TextMoneda.Text.Trim.ToUpper <> TextMoneEmpresa.Text.Trim.ToUpper Then
            lpara("moneda") = TextMoneda.Text.Trim
            TextTasa.Text = BuscaEscalar("select tasa from monedasban where moneda=@moneda", ListaParametros(lpara))
        Else
            TextTasa.Clear()
        End If
        TextCodigoBanco.ReadOnly = True
        gpDatos.Visible = True
        gpDatos.Enabled = True
        textEmpleado.Focus()
    End Sub
    Private Sub BorraOrigen(ByVal valbool As Boolean)

        TextCta.Clear()
        If valbool = True Then
            TextCodigoBanco.Clear()
        End If
    End Sub
#End Region

#Region "EMLEADO"


    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        TextConxContrato.Clear()
        If valbool = True Then
            textEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombreEmple.Text.Trim
        cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa and nombre like '%' + @nombre + '%'  and e.empleado in ( select empleado from contratos1 c1 " &
                 "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) " &
                 "order by nombre"
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
            TextConxContrato.Focus()
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
                     " and empleado=@empleado and e.empleado in ( select empleado from contratos1 c1 " &
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
                TextConxContrato.Focus()
            Else
                MsgBox("EMPLEADO NO ACTIVO", MsgBoxStyle.Information, "Mensaje del Sistema")
                dr.Close()
                cn.Close()
                BorraEmpleado(True)
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
        textEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
    End Sub

   



#End Region


#Region "Contrato"

    Private Sub BtnContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrato.Click
        Dim Num As Int16
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        If textEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre, c1.tiposeguro, tip.tibase, pu.extras, c1.base, pu.buses, ss.por, tib.horasdia, " &
                     " ss.transac from contratos1 c1 " &
                     " inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     " inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto  " &
                     " inner join tipopersonal tip on tip.empresa=c1.empresa and tip.tipoper=c1.tipoper " &
                     " inner join tiposbase tib on tib.empresa=c1.empresa and tib.tibase=tip.tibase " &
                     " inner join segurosocial ss on ss.empresa=c1.empresa and ss.tiposeguro=c1.tiposeguro " &
                     " where e.generapago='S' and c1.empresa=@empresa and empleado=@empleado"
            Num = llenaTabla(cadena, tbContratos, ListaParametros(lpara))
            If Num = 1 Then
                filaTemp = tbContratos.Rows(0)
                TextConxContrato.Text() = filaTemp.Item(0)
                tipSeguro = filaTemp.Item(2)
                tibase = filaTemp.Item(3)
                extras = filaTemp.Item(4)
                base = filaTemp.Item(5)
                buses = filaTemp.Item(6)
                porSeg = filaTemp.Item(7)
                horasDia = filaTemp.Item(8)
                transacSS = filaTemp.Item(9)
                TextConcepto.Focus()
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 7)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContrato
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()
                TextConcepto.Focus()
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
        tipSeguro = filaTemp.Item(2)
        tibase = filaTemp.Item(3)
        extras = filaTemp.Item(4)
        base = filaTemp.Item(5)
        buses = filaTemp.Item(6)
        porSeg = filaTemp.Item(7)
        horasDia = filaTemp.Item(8)
        transacSS = filaTemp.Item(9)
    End Sub

    Private Sub TextConxContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextConxContrato.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextConxContrato_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextConxContrato.Validated
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        If TextConxContrato.Text.Trim <> "" And textEmpleado.Text.Trim <> "" Then
            Dim tbTem As New DataTable("temp")
            cadena = "select contrato, pu.nombre, c1.tiposeguro, tip.tibase, pu.extras, c1.base, pu.buses , ss.por , tib.horasdia, " &
                    " ss.transac from contratos1 c1 " &
                    " inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                    " inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto  " &
                    " inner join tipopersonal tip on tip.empresa=c1.empresa and tip.tipoper=c1.tipoper " &
                    " inner join tiposbase tib on tib.empresa=c1.empresa and tib.tibase=tip.tibase " &
                    " inner join segurosocial ss on ss.empresa=c1.empresa and ss.tiposeguro=c1.tiposeguro " &
                    " where  e.generapago='S' and c1.empresa=@empresa and empleado=@empleado " &
                    " and c1.contrato=@contrato"
            If llenaTabla(cadena, tbTem, ListaParametros(lpara)) = 0 Then
                MsgBox("NO EXISTE ESTE NUMERO DE CONTRATO ACTIVO PARA ESTE EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            Else
                filaTemp = tbTem.Rows(0)
                TextConxContrato.Text() = filaTemp.Item(0)
                tipSeguro = filaTemp.Item(2)
                tibase = filaTemp.Item(3)
                extras = filaTemp.Item(4)
                base = filaTemp.Item(5)
                buses = filaTemp.Item(6)
                porSeg = filaTemp.Item(7)
                horasDia = filaTemp.Item(8)
                transacSS = filaTemp.Item(9)
                TextConcepto.Focus()
            End If
        Else
            TextConxContrato.Clear()
        End If
    End Sub


#End Region


#Region "TRANSACCION"


    Private Sub BorraCodigo(ByVal valbool As Boolean)
        LbTipo.Text = "Valor"
        textNombCodigo.Clear()
        If valbool = True Then
            textCodigo.Clear()
        End If
    End Sub


    Private Sub btnCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaCodigo.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombCodigo.Text.Trim
        cadena = "select transac, nombre, case when tipomov='I' then 'INGRESO' else 'DESCUENTO' END as nombTipomov," &
                 " formacal, tipomov, tipovalor, afectaSeguro, ctacte, factor, cuentanom " &
                 " from tipotran where empresa=@empresa and nombre like '%' + @nombre + '%' and formacal in ('FM','IM','EX', 'CA', 'AN')  order by transac"
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
            formacal = filaTemp.Item(3)
            tipomov = filaTemp.Item(4)
            tipovalor = filaTemp.Item(5)
            afectaSeguro = filaTemp.Item(6)
            ctacte = filaTemp.Item(7)
            factor = filaTemp.Item(8)
            cuentanom = filaTemp.Item(9)
            TextValor.Focus()
            IngresarTransaccion()
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
            cadena = "select transac, nombre, case when tipomov='I' then 'INGRESO' else 'DESCUENTO' END as nombTipomov, " &
                     "formacal, tipomov, tipovalor, afectaSeguro, ctacte, factor, cuentanom " &
                     "from tipotran where empresa=@empresa " &
                     " and transac=@transac and formacal in ('FM','IM','EX', 'CA', 'AN')"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraCodigo(False)
                dr.Read()
                textNombCodigo.Text = dr.GetValue(1)
                formacal = dr.GetValue(3)
                tipomov = dr.GetValue(4)
                tipovalor = dr.GetValue(5)
                afectaSeguro = dr.GetValue(6)
                ctacte = dr.GetValue(7)
                factor = dr.GetValue(8)
                cuentanom = dr.GetValue(9)
                dr.Close()
                cn.Close()
                TextValor.Focus()
                IngresarTransaccion()
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
        f3C = New frmMuestra3Columnas
        f3C.TopMost = True
        f3C.inicializa(tbCodigo, "TRANSACCION", "NOMBRE", "TIPO", 7)
        AddHandler f3C.actValor, AddressOf ActualizacionDatosMonitor
        f3C.StartPosition = FormStartPosition.CenterScreen
        f3C.ShowDialog()
        TextValor.Focus()
    End Sub

    Private Sub ActualizacionDatosMonitor(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCodigo(True)
        filaTemp = tbCodigo.Rows.Item(e.va2)
        textCodigo.Text() = filaTemp.Item(0)
        textNombCodigo.Text = filaTemp.Item(1)
        formacal = filaTemp.Item(3)
        tipomov = filaTemp.Item(4)
        tipovalor = filaTemp.Item(5)
        afectaSeguro = filaTemp.Item(6)
        ctacte = filaTemp.Item(7)
        factor = filaTemp.Item(8)
        cuentanom = filaTemp.Item(9)
        IngresarTransaccion()
    End Sub

    Private Sub IngresarTransaccion()
        If tipovalor = "C" Then
            LbTipo.Text = "Cantidad"
        ElseIf tipovalor = "V" Then
            LbTipo.Text = "Valor"
        End If
    End Sub




#End Region


    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(0).HeaderText = "Transacción"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 300
            .Columns(2).HeaderText = "Cantidad"
            .Columns(2).Width = 140
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).HeaderText = "Valor"
            .Columns(3).Width = 140
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderText = "Importe"
            .Columns(4).Width = 135
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            'AltoGridView(18, tbDatos, 208, 859, dgVista)
        End With
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        borra_Mejorado(gpInfoCuentas, ep1)
        LimpiaParcial(sender, e)
        gpDatos.Visible = True
        gpDatos.Enabled = False
        TextCodigoBanco.ReadOnly = False
        TextNoCheque.Clear()
        textEmpleado.Focus()
    End Sub

    Private Sub LimpiaParcial(ByVal sender As System.Object, ByVal e As System.EventArgs)
        borra_Mejorado(gpDatos, ep1)
        btnCancelar_Click(sender, e)
        gpDatos.Enabled = True
        gpDetalle.Enabled = False
        tbDatos.Rows.Clear()
        'AltoGridView(17, tbDatos, 150, 859, dgDatos)
        TextLiquido.Text = formato(0)
        TextDevengado.Text = formato(0)
        TextDescontado.Text = formato(0)
        TextSeguro.Text = formato(0)
        btnGuardar.Enabled = False
        ContextoMenuEnab(True, False, ctxMenu)
        btnGuardar.Enabled = False
        dtpFechai.Value = Today
        dtpFechaf.Value = Today
        axFecha.Focus()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub TextAño_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextAño.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngGen.Click
        If validetError(textEmpleado, ep1) = False Or validetError(TextConxContrato, ep1) = False Or validetComilla(TextConcepto, ep1) = False Or
                          Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Or Not validetError(cmbTipo, ep1) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        fechaI = dtpFechai.Text
        fechaF = dtpFechaf.Text
        If fechaI >= fechaF Then
            MsgBox("FECHA INICIAL DEBE SER MENOR QUE LA FECHA FINAL", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        gpDatos.Enabled = False
        gpDetalle.Enabled = True
        textCodigo.Focus()
    End Sub

    Private Sub btnIngSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Dim devengado, descontado, Importe, Sueldo, Seguro As Decimal
        Dim i As Int32
        lpara.Clear()
        If validetError(textCodigo, ep1) And validetError(TextValor, ep1) Then

            If CDec(TextValor.Text) = 0 Then
                MsgBox("DEBE INGRESAR UN VALOR MAYOR A 0", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If

            For i = 0 To tbDatos.Rows.Count - 1
                filaTemp = tbDatos.Rows(i)
                Select Case opc
                    Case 0
                        If CInt(textCodigo.Text) = filaTemp.Item(0) Then
                            MsgBox("CODIGO DE TRANSACCION YA INGRESADA", MsgBoxStyle.Information, "Mensaje del Sistema")
                            Exit Sub
                        End If
                    Case 1
                        If CInt(textCodigo.Text) = filaTemp.Item(0) And IndiceTransac <> i Then
                            MsgBox("CODIGO DE TRANSACCION YA INGRESADA", MsgBoxStyle.Information, "Mensaje del Sistema")
                            Exit Sub
                        End If
                End Select
            Next i
            If tipovalor = "V" Then
                If tipomov = "I" Then
                    devengado = CDec(TextValor.Text)
                    Importe = CDec(TextValor.Text)
                    If afectaSeguro = "S" Then
                        Seguro = Decimal.Round((Importe * (porSeg / 100)), 2)
                        descontado = Seguro
                    Else
                        descontado = 0
                    End If
                ElseIf tipomov = "D" Then
                    devengado = 0
                    descontado = CDec(TextValor.Text)
                    Importe = CDec(TextValor.Text)
                End If
            ElseIf tipovalor = "C" And tipomov = "I" Then
                lpara("empresa") = empresa
                lpara("empleado") = textEmpleado.Text
                lpara("contrato") = TextConxContrato.Text
                lpara("transac") = textCodigo.Text
                Select Case formacal
                    Case "FM"
                        cadena = "select coalesce( sum(valor),0) from sueldos where empresa=@empresa and empleado=@empleado and contrato=@contrato and transac=@transac"
                        Sueldo = BuscaEscalar(cadena, ListaParametros(lpara))
                        If Sueldo = 0 Then
                            MsgBox("TRANSACCION NO SE ENCUENTRA REGISTRADA EN EL SUELDO DEL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                            Exit Sub
                        Else
                            devengado = Decimal.Round(((Sueldo / base) * CDec(TextValor.Text)), 2)
                            Importe = devengado
                            If afectaSeguro = "S" Then
                                Seguro = Decimal.Round((Importe * (porSeg / 100)), 2)
                                descontado = Seguro
                            End If
                        End If
                    Case "EX"

                        cadena = "select coalesce( sum(valor),0) from sueldos where empresa=@empresa and empleado=@empleado and contrato=@contrato and transac in (select transac from tipotran where marextras='S')"
                        Sueldo = BuscaEscalar(cadena, ListaParametros(lpara))
                        If Sueldo = 0 Then
                            MsgBox("TRANSACCION NO SE ENCUENTRA REGISTRADA EN EL SUELDO DEL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                            Exit Sub
                        Else
                            If tibase = "D" Then
                                devengado = (Sueldo / (horasDia * base)) * factor * CDec(TextValor.Text)
                            ElseIf tibase = "H" Then
                                devengado = (Sueldo / base) * factor * CDec(TextValor.Text)
                            End If
                            devengado = Decimal.Round(devengado, 2)
                            Importe = devengado
                            If afectaSeguro = "S" Then
                                Seguro = Decimal.Round((Importe * (porSeg / 100)), 2)
                                descontado = Seguro
                            End If
                        End If
                End Select
            End If
            If opc = 0 Then
                filaTemp = tbDatos.NewRow
                filaTemp.Item(0) = textCodigo.Text
                ValidaCodigo()
                filaTemp.Item(1) = textNombCodigo.Text
                If tipovalor = "C" Then
                    filaTemp.Item(2) = TextValor.Text
                    filaTemp.Item(3) = "0"
                ElseIf tipovalor = "V" Then
                    filaTemp.Item(2) = "0"
                    filaTemp.Item(3) = TextValor.Text
                End If
                filaTemp.Item(4) = formato(Importe)
                filaTemp.Item(5) = devengado
                filaTemp.Item(6) = descontado
                filaTemp.Item(7) = Seguro
                filaTemp.Item(8) = tipomov
                filaTemp.Item(9) = ctacte
                filaTemp.Item(10) = cuentanom
                filaTemp.Item(11) = buses
                tbDatos.Rows.Add(filaTemp)
            Else
                filaTemp = tbDatos.Rows(IndiceTransac)
                filaTemp.BeginEdit()
                filaTemp.Item(0) = textCodigo.Text
                ValidaCodigo()
                filaTemp.Item(1) = textNombCodigo.Text
                If tipovalor = "C" Then
                    filaTemp.Item(2) = TextValor.Text
                    filaTemp.Item(3) = "0"
                ElseIf tipovalor = "V" Then
                    filaTemp.Item(2) = "0"
                    filaTemp.Item(3) = TextValor.Text
                End If
                filaTemp.Item(4) = Importe
                filaTemp.Item(5) = devengado
                filaTemp.Item(6) = descontado
                filaTemp.Item(7) = Seguro
                filaTemp.Item(8) = tipomov
                filaTemp.Item(9) = ctacte
                filaTemp.Item(10) = cuentanom
                filaTemp.Item(11) = buses
                filaTemp.EndEdit()
            End If
            Totaliza()
            'AltoGridView(18, tbDatos, 150, 859, dgDatos)
            MueveScrollView(dgDatos, tbDatos.Rows.Count - 1)
            btnCancelar_Click(sender, e)
        Else
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

      

    Private Sub Totaliza()
        Dim ToDeven, ToDesc, ToSeg As Decimal
        Dim i As Integer
        ToDeven = 0
        ToDesc = 0
        ToSeg = 0
        For i = 0 To tbDatos.Rows.Count - 1
            filaTemp = tbDatos.Rows(i)
            ToDeven = ToDeven + filaTemp.Item(5)
            ToDesc = ToDesc + filaTemp.Item(6)
            ToSeg = ToSeg + filaTemp.Item(7)
        Next i
        TextLiquido.Text = formato(ToDeven - ToDesc)
        TextDevengado.Text = formato(ToDeven)
        TextDescontado.Text = formato(ToDesc)
        TextSeguro.Text = formato(ToSeg)
        If CDec(TextLiquido.Text) > 0 Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        opc = 0
        borra_Mejorado(gpDetalle, ep1)
        TextValor.Clear()
        ContextoMenuEnab(True, True, ctxMenu)
        textCodigo.Focus()
    End Sub

    Private Sub ctxModi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click
        Dim f As DataRow
        If dgDatos.SelectedRows.Count > 0 Then
            opc = 1
            IndiceTransac = dgDatos.SelectedRows(0).Index
            ContextoMenuEnab(False, True, ctxMenu)
            f = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            textCodigo.Text = f.Item(0)
            ValidaCodigo()
            If tipovalor = "C" Then
                TextValor.Text = f.Item(2)
            ElseIf tipovalor = "V" Then
                TextValor.Text = f.Item(3)
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxEli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                tbDatos.Rows.Remove(filaTemp)
                'AltoGridView(18, tbDatos, 150, 859, dgDatos)
                Totaliza()
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        lpara.Clear()
        Dim i, j, k, z, chNum, tasa, tasaEs, auxiliar, Negociable As Integer
        Dim centro, cuentaSeguro, letras As String
        Dim valT, valor, total As Decimal
        Dim tbTemp As New DataTable("temporal")
        Dim tbContra2 As New DataTable("contra2")
        Dim tbBus As New DataTable("buses2")
        Dim fechaEs As Date
        Dim fila, f As DataRow
        Dim tt As New DataTable
        Dim Valordesc As Decimal
        Dim id_cheque As Int32 = 0
        Dim id_diario1 As Int32 = 0
        Dim id_extra1 As Int32 = 0
        If tbDatos.Rows.Count = 0 Then
            MsgBox("NO HA INGRESADO NINGUNA TRANSACCION", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        '  Try
        If MsgBox("DESEA GUARDAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            If validetError(axFecha, ep1) = False Then
                MsgBox("FORMATO DE FECHA NO VALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            Else
                fechaEs = axFecha.Text
            End If
            If MsgBox("ES EL CHEQUE 'NO NEGOCIABLE'", MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                Negociable = 0
            Else
                Negociable = 1
            End If

            If TextTasa.Text.Trim = "" Then
                tasa = 1
                tasaEs = 0
            Else
                tasa = TextTasa.Text.Trim
                tasaEs = TextTasa.Text.Trim
            End If
            total = CDec(TextLiquido.Text)
            lpara("empresa") = empresa
            lpara("cheque") = TextNoCheque.Text.Trim
            lpara("codigoBanco") = TextCodigoBanco.Text
            lpara("banco") = banco

            If BuscaEscalar("select count(*) from cheque1 where empresa=@empresa and cheque=@cheque and banco=@codigoBanco", ListaParametros(lpara)) > 0 Then
                MsgBox("ESTE CHEQUE YA SE ENCUENTRA EMITIDO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                chNum = BuscaEscalar("select coalesce( max(cheque),0) from cheque1 where empresa=@empresa and banco=@banco", ListaParametros(lpara))
                lpara("chNum") = chNum
                cadena = "update bancoscta set cheque=@chNum where empresa=@empresa and banco=@banco"
                EjecutarQuery(cadena, ListaParametros(lpara))
                TextNoCheque.Text = chNum + 1
                Exit Sub
            End If
            Dim modelo As New cmodelo()
            lpara.Clear()
            lpara("empresa") = empresa
            lpara("user") = user
            lpara("banco") = banco
            lpara("cheque") = TextNoCheque.Text.Trim
            lpara("fecha") = fechaEs
            lpara("empleado") = textEmpleado.Text
            lpara("contrato") = TextConxContrato.Text
            lpara("fechai") = fechaI
            lpara("fechaf") = fechaF
            lpara("concepto") = TextConcepto.Text
            lpara("fechae") = Today.ToShortDateString()
            lpara("beneficiario") = textNombreEmple.Text
            lpara("moneda") = TextMoneda.Text.Trim
            lpara("tasaEs") = tasaEs
            lpara("monto") = total
            lpara("monto2") = (total / tasa)
            lpara("fechaOper") = Today.ToShortDateString
            lpara("negociable") = Negociable
            lpara("beneficiario") = textNombreEmple.Text
            lpara("monto") = CDec(TextLiquido.Text)
            lpara("mes") = cmbMes.SelectedValue
            lpara("año") = CShort(TextAño.Text)
            lpara("tiponom") = cmbTipo.SelectedValue
            Try

                cadena = "insert into extra1 (empresa,tipo,inicial,banco,cheque,fecha,empleado,contrato,fechai,fechaf,concepto,estado,fechae,mes, año, tiponom) 
                          values (@empresa,'CH',@user,@banco,@cheque,@fecha,@empleado,@contrato,@fechai,@fechaf,@concepto,0,@fechae, @mes, @año, @tiponom); 
                         SELECT SCOPE_IDENTITY();"
                id_extra1 = modelo.BuscaEscalar(cadena, ListaParametros(lpara))

                cadena = "update bancoscta set cheque=@cheque where empresa=@empresa and banco=@banco"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                cadena = "insert into cheque1 (empresa,banco,cheque,inicial,fecha,beneficiario,concepto,moneda,tasa,monto, estado,fecha_oper,mes,anio,negociable) 
                          values (@empresa,@banco,@cheque,'EXNOM',@fecha,@beneficiario,@concepto,@moneda,@tasaEs,@monto,0,@fechaOper,'','',@negociable) 
                          select scope_identity() "
                id_cheque = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
                k = 0


                lpara("concepto") = TextConcepto.Text.Trim.ToUpper
                cadena = "insert into diario1 (empresa,tipo,banco,docto,fecha,beneficiario,monto,concepto,bancta) 
                          values(@empresa,3,@banco,@cheque,@fecha,@beneficiario,@monto2,@concepto,@banco);
                          SELECT SCOPE_IDENTITY();"
                id_diario1 = modelo.BuscaEscalar(cadena, ListaParametros(lpara))

                For i = 0 To tbDatos.Rows.Count - 1
                    filaTemp = tbDatos.Rows(i)
                    lpara.Clear()
                    lpara("empresa") = empresa
                    lpara("banco") = banco
                    lpara("cheque") = TextNoCheque.Text
                    lpara("id_extra1") = id_extra1

                    lpara("transac") = filaTemp.Item(0)
                    lpara("cantidad") = CDec(filaTemp.Item(2))
                    lpara("valor") = CDec(filaTemp.Item(4))
                    cadena = "insert into extra2 (id_extra1,empresa,tipo,banco,cheque,transac,cantidad,valor) 
                              values (@id_extra1,@empresa,'CH',@banco,@cheque,@transac,@cantidad,@valor)"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    lpara("contrato") = CInt(TextConxContrato.Text)
                    lpara("empleado") = CInt(textEmpleado.Text)
                    lpara("empresa") = empresa
                    lpara("transac") = filaTemp.Item("transaccion")
                    cadena = "select p1.prestamo,p1.saldo from (" &
                             " select *, cast ( ('01/' + cast (mesini as varchar(2)) + '/' + cast (añoini as varchar(4))) as datetime ) as fechaIni " &
                             "from prestamos1 ) p1 inner join tiposprestamo b on p1.empresa=b.empresa and p1.tipopre=b.tipopre " &
                             "where p1.empresa=@empresa and contrato=@contrato " &
                             " and p1.estado=0 and empleado=@empleado and saldo > 0 and '" & fechaI.ToShortDateString & "' >= fechaIni and b.transac = @transac"
                    If filaTemp.Item("tipomov") = "D" AndAlso filaTemp.Item("ctacte") = "S" AndAlso modelo.llenaTabla(cadena, tbTemp, ListaParametros(lpara)) > 0 Then
                        Valordesc = CDec(filaTemp.Item(4))
                        ' Se utiliza este proceso para descontar de todos los prestamos que tenga un empleado, el descuento deseado.
                        ' Se descuenta de los primeros prestamos y si solo hay uno o es el último, se descuenta el lo que vaya quedando del descuento, no importa si queda negativo el saldo.
                        lpara("empresa") = empresa
                        lpara("fechaEs") = fechaEs
                        lpara("docto") = TextNoCheque.Text
                        lpara("abonos") = CDec(Valordesc)
                        lpara("tiponom") = "E"
                        lpara("mes") = fechaEs.Month
                        lpara("año") = fechaEs.Year

                        While z <= tbTemp.Rows.Count - 2
                            f = tbTemp.Rows(z)
                            lpara("prestamo") = f.Item("prestamo")
                            If CDec(f.Item("saldo")) >= CDec(Valordesc) Then

                                cadena = "update prestamos1 set saldo=saldo-" & CDec(Valordesc) & " where empresa=@empresa and prestamo=@prestamo"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                                cadena = "insert into prestamos2 (empresa,prestamo,fecha,tipodocto,docto,cargos,abonos,mes, año, tiponom) 
                                          values (@empresa,@prestamo,@fechaEs,'CH',@docto,0.00,@abonos, @mes, @año, @tiponom)"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                Valordesc = 0
                                z = z + 1
                                Exit While
                            Else
                                lpara("abono") = CDec(f.Item("saldo"))
                                cadena = "update prestamos1 set saldo=saldo-" & CDec(f.Item("saldo")) & " where empresa=@empresa and prestamo=@prestamo"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                                cadena = "insert into prestamos2 (empresa,prestamo,fecha,tipodocto,docto,cargos,abonos, mes, año, tiponom) 
                                          values (@empresa,@prestamo,@fechaEs,'CH',@docto,0.00,@abono,  @mes, @año, @tiponom)"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                Valordesc = Valordesc - f.Item("saldo")
                                z = z + 1
                            End If
                        End While

                        If z = tbTemp.Rows.Count - 1 And CDec(Valordesc) > 0.0 Then
                            f = tbTemp.Rows(z)
                            lpara("prestamo") = f.Item("prestamo")
                            cadena = "update prestamos1 set saldo=saldo-" & CDec(Valordesc) & " where empresa=@empresa and prestamo=@prestamo"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                            cadena = "insert into prestamos2 (empresa,prestamo,fecha,tipodocto,docto,cargos,abonos) 
                                      values (@empresa,@prestamo,@fechaEs,'CH',@docto,0.00,@abonos)"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                        End If
                    End If



                    lpara.Clear()
                    lpara("empresa") = empresa
                    lpara("cuenta") = filaTemp.Item(10)
                    lpara("contrato") = CShort(TextConxContrato.Text)
                    lpara("empleado") = CInt(textEmpleado.Text)
                    If filaTemp.Item(8) = "I" Then
                        cadena = "select centro from nomencla where cuenta=@cuenta and empresa=@empresa "
                        centro = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
                        If centro = "S" Then
                            cadena = "select origen, por from contratos2 where empresa=@empresa and contrato=@contrato and empleado=@empleado"
                            modelo.llenaTabla(cadena, tbContra2, ListaParametros(lpara))
                            valT = 0


                            For j = 0 To tbContra2.Rows.Count - 1
                                lpara.Clear()
                                fila = tbContra2.Rows(j)
                                lpara("empresa") = empresa
                                lpara("cuenta") = filaTemp.Item(10)
                                lpara("origen") = fila.Item(0)


                                cadena = "select count(*) from auxiliarcta where empresa=@empresa and cuenta=@cuenta and origen=@origen and numero=3"
                                If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                                    lpara("empleado") = textEmpleado.Text
                                    If filaTemp.Item(11) = "S" Then
                                        cadena = "select bus from busesi where empresa=@empresa and ( chofer=@empleado or monitor=@empleado )"
                                        If modelo.llenaTabla(cadena, tbBus, ListaParametros(lpara)) > 0 Then
                                            auxiliar = tbBus.Rows(0).Item(0)
                                        Else
                                            auxiliar = 99
                                        End If
                                    Else
                                        auxiliar = CInt(textEmpleado.Text)
                                    End If
                                Else
                                    auxiliar = 0
                                End If

                                If j < tbContra2.Rows.Count - 1 Then
                                    valor = Decimal.Round((CDec(filaTemp.Item(4)) * (fila.Item(1) / 100)), 2)
                                    valT = valT + valor
                                Else
                                    valor = CDec(filaTemp.Item(4)) - valT
                                End If

                                lpara("docto") = TextNoCheque.Text
                                lpara("banco") = banco
                                lpara("cuenta") = filaTemp.Item(10)
                                lpara("origen") = fila.Item(0)
                                lpara("codigo") = auxiliar

                                lpara("idCheque") = id_cheque
                                lpara("debe") = (valor / tasa)
                                lpara("fechaEs") = fechaEs
                                lpara("valor") = valor
                                lpara("id_diario") = id_diario1
                                cadena = "select count(*) from diario2 where empresa=@empresa and tipo=3 and docto=@docto and banco=@banco and cuenta=@cuenta and origen=@origen and codigo=@codigo and haber=0"
                                If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                                    k = k + 1
                                    lpara("numero") = k
                                    cadena = "insert into cheque2 (id_cheque,numero,empresa,banco,cheque,origen,cuenta,codigo,debe,haber) 
                                              values(@idCheque,@numero,@empresa,@banco,@docto,@origen,@cuenta,@codigo,@debe,0)"
                                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                                    cadena = "insert into diario2 (id_diario,empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber,bancta) 
                                              values(@id_diario,@empresa,3,@banco,@docto,@fechaEs,@origen,@cuenta,@codigo,@valor,0,@banco)"
                                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                Else
                                    cadena = "update d2 set debe=debe + @debe from diario2 d2 where empresa=@empresa and tipo=3 and docto=@docto " &
                                             "and banco=@banco and cuenta=@cuenta and origen=@origen and codigo=@codigo and haber=0 and d2.bancta=@banco"
                                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                                    cadena = "update c2 set debe=debe + @valor from cheque2 c2 where empresa=@empresa  and cheque=@docto " &
                                             "and banco=@banco and cuenta=@cuenta and origen=@origen and codigo=@codigo and haber=0"
                                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                End If
                            Next j


                        Else
                            valor = CDec(filaTemp.Item(4))
                            lpara.Clear()
                            lpara("empresa") = empresa
                            lpara("cuenta") = filaTemp.Item(10)
                            lpara("docto") = TextNoCheque.Text
                            lpara("banco") = banco

                            lpara("idCheque") = id_cheque
                            lpara("id_diario") = id_diario1

                            lpara("debe") = (valor / tasa)
                            lpara("fechaEs") = fechaEs
                            lpara("valor") = valor
                            cadena = "select count(*) from auxiliarcta where empresa=@empresa and cuenta=@cuenta and origen='000' and numero=4"
                            If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                                auxiliar = CInt(textEmpleado.Text)
                            Else
                                auxiliar = 0
                            End If
                            lpara("codigo") = auxiliar
                            cadena = "select count(*) from diario2 where empresa=@empresa and tipo=3 and docto=@docto " &
                                     "and banco=@banco and cuenta=@cuenta and origen='000' and codigo=@codigo and haber=0"
                            If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                                k = k + 1
                                lpara("k") = k
                                cadena = "insert into cheque2 (id_cheque,numero,empresa,banco,cheque,origen,cuenta,codigo,debe,haber) 
                                          values(@idCheque,@k,@empresa,@banco,@docto,'000',@cuenta,@codigo,@debe,0)"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                                cadena = "insert into diario2 (id_diario,empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber,bancta) 
                                          values(@id_diario,@empresa,3,@banco,@docto,@fechaEs,'000',@cuenta,@codigo,@valor,0,@banco)"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                            Else
                                cadena = "update d2 set debe=debe + @valor from diario2 d2 where empresa=@empresa And tipo = 3 And docto = @docto " &
                                         " And banco =@banco And cuenta =@cuenta and origen='000' and codigo=@codigo and haber=0 and d2.bancta=@banco"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                                cadena = "update c2 set debe=debe + @debe from cheque2 c2 where empresa=@empresa and cheque=@docto " &
                                         " and banco=@banco and cuenta=@cuenta and origen='000' and codigo=@codigo and haber=0"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                            End If
                        End If
                    Else
                        lpara.Clear()
                        lpara("empresa") = empresa
                        lpara("cuenta") = filaTemp.Item(10)
                        lpara("docto") = TextNoCheque.Text
                        lpara("banco") = banco

                        lpara("idCheque") = id_cheque
                        lpara("id_diario") = id_diario1
                        lpara("fecha") = fechaEs
                        cadena = "select count(*) from auxiliarcta where empresa=@empresa and cuenta=@cuenta and origen='000'"
                        If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                            auxiliar = CInt(textEmpleado.Text)
                        Else
                            auxiliar = 0
                        End If
                        valor = CDec(filaTemp.Item(4))
                        lpara("codigo") = auxiliar
                        cadena = "select count(*) from diario2 where empresa=@empresa and tipo=3 and docto=@docto" &
                                 " and banco=@banco and cuenta=@cuenta and origen='000'" &
                                 " and codigo=@codigo and debe=0"
                        lpara("valor") = valor
                        lpara("haber") = (valor / tasa)
                        If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                            k = k + 1
                            lpara("k") = k

                            cadena = "insert into cheque2 (id_cheque,numero,empresa,banco,cheque,origen,cuenta,codigo,debe,haber) 
                                      values(@idCheque,@k,@empresa,@banco,@docto,'000',@cuenta,@codigo,0,@haber)"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))


                            cadena = "insert into diario2 (id_diario,empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber,bancta) 
                                      values(@id_diario,@empresa,3,@banco,@docto,@fecha,'000',@cuenta,@codigo,0,@valor,@banco)"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                        Else
                            cadena = "update d2 set haber=haber + @valor from diario2 d2 where empresa=@empresa and tipo=3 and docto=@docto " &
                                     " and banco=@banco And cuenta =@cuenta and origen='000' " &
                                     " and codigo=@codigo And debe = 0 And d2.bancta =@banco"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                            cadena = "update c2 set haber=haber + @haber from cheque2 c2 where empresa=@empresa  And cheque=@docto " &
                                     " And banco=@banco And cuenta =@cuenta and origen='000' " &
                                     " and codigo=@codigo and debe=0"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                        End If
                    End If
                Next i


                lpara.Clear()
                lpara("empresa") = empresa
                lpara("docto") = TextNoCheque.Text
                lpara("banco") = banco
                lpara("transac") = transacSS
                lpara("valor") = CDec(TextSeguro.Text)
                lpara("tipoSeguro") = tipSeguro
                lpara("id_diario") = id_diario1
                lpara("idCheque") = id_cheque
                lpara("fechaEs") = fechaEs
                lpara("id_extra1") = id_extra1
                If CDec(TextSeguro.Text) <> 0 Then
                    cadena = "insert into extra2 (id_extra1,empresa,tipo,banco,cheque,transac,cantidad,valor) 
                              values (@id_extra1,@empresa,'CH',@banco,@docto,@transac,0,@valor)"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    cadena = "Select cuentanom from segurosocial s inner join tipotran t On s.empresa=t.empresa And " &
                             "s.transac=t.transac where s.empresa=@empresa And tiposeguro =@tipoSeguro "
                    cuentaSeguro = modelo.BuscaEscalar(cadena, ListaParametros(lpara))

                    lpara("cuenta") = cuentaSeguro
                    cadena = "Select count(*) from auxiliarcta where empresa=@empresa And cuenta=@cuenta and origen='000'"
                    If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                        auxiliar = CInt(textEmpleado.Text)
                    Else
                        auxiliar = 0
                    End If
                    k = k + 1
                    lpara("k") = k
                    lpara("codigo") = auxiliar
                    lpara("haber") = CDec(TextSeguro.Text) / tasa
                    cadena = "insert into cheque2 (id_cheque,numero,empresa,banco,cheque,origen,cuenta,codigo,debe,haber) 
                              values(@idCheque,@k,@empresa,@banco,@docto,'000',@cuenta,@codigo,0,@haber)"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    lpara("haber2") = CDec(TextSeguro.Text)
                    cadena = "insert into diario2 (id_diario,empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber,bancta) 
                              values(@id_diario,@empresa,3,@banco,@docto,@fechaEs,'000',@cuenta,@codigo,0,@haber2,@banco)"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                End If
                cadena = "select sum(debe-haber) from cheque2 where empresa=@empresa and cheque=@docto And banco=@banco"
                total = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
                k = k + 1
                lpara("k") = k
                lpara("cuenta2") = cuentaCheque2
                lpara("haber3") = total
                cadena = "insert into cheque2 (id_cheque,numero,empresa,banco,cheque,origen,cuenta,codigo,debe,haber) 
                          values(@idCheque,@k,@empresa,@banco,@docto,'000',@cuenta2,@banco,0,@haber3)"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                lpara("haber4") = CDec(TextLiquido.Text)
                cadena = "insert into diario2 (id_diario,empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber,bancta) 
                          values(@id_diario,@empresa,3,@banco,@docto,@fechaEs,'000',@cuenta2,@banco,0,@haber4,@banco)"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                cadena = "update a set monto=@valor from cheque1 a where id_cheque=@idCheque"
                lpara("valor") = total
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))



                lpara("valor2") = -(total)
                lpara("tasa") = tasaEs
                lpara("beneficiario") = textNombreEmple.Text
                lpara("concepto") = TextConcepto.Text
                cadena = "insert into bantran (empresa,banco,fecha,banche,tipo,docto,valor,beneficiario,concepto,tasa) 
                          values (@empresa,@banco,@fechaEs,@banco,3,@docto,@valor2,@beneficiario,@concepto,@tasa)"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                cadena = "update bancoscta set cheque=@docto where banco=@banco"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                If modelo.Commit() Then
                    InsertBitacora(9, 1, "INGRESO DE CHEQUE EXTRANOMINA " & TextNoCheque.Text)
                    Dim claseLetras As New ValoresLetras
                    letras = claseLetras.Inicializacion(CStr(total))
                    If MsgBox("DESEA IMPRIMIR EL CHEQUE", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                        Try
                            cadena = "select *,'" & letras.ToUpper & "' as Letras from v_Cheques where empresa=" & empresa & " and banco=" & banco & " and cheque=" & TextNoCheque.Text & " order by haber, debe asc"
                            llenaTabla(cadena, tt)
                            If (tt.Rows.Count > 0) Then
                                v.SetDataSource(tt)
                                v.Refresh()

                                v.PrintOptions.PaperSize = rawKind
                                v.PrintToPrinter(1, False, 1, 1)
                                InsertBitacora(9, 5, $"Creación de cheque extra nómina {TextNoCheque.Text}")
                            Else
                                MsgBox("NO HAY REGISTROS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del sistema")
                            End If
                        Catch ex As Exception
                            MsgBox("EL CHEQUE FUE GRABADO PERO HAY PROBLEMAS CON LA IMPRESORA, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistem")
                        End Try
                    End If
                    LimpiaParcial(sender, e)
                    TextNoCheque.Text = CInt(TextNoCheque.Text) + 1
                    textEmpleado.Focus()
                    MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("ERROR DEL SISTEMA " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                modelo.RollBack()
            End Try
        End If
        'Catch ex As Exception
        ' MsgBox("ERROR EN EL INGRESO DE DATOS", MsgBoxStyle.Critical, "Mensaje del Sistema")
        ' End Try

    End Sub



    Private Sub frmRutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles axFecha.Enter, TextCodigoBanco.Enter,
       textEmpleado.Enter, textNombreEmple.Enter, TextConxContrato.Enter, TextConcepto.Enter,
       textCodigo.Enter, textNombCodigo.Enter, TextValor.Enter, dtpFechai.Enter, dtpFechaf.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub


    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles axFecha.Leave, TextCodigoBanco.Leave,
       textEmpleado.Leave, textNombreEmple.Leave, TextConxContrato.Leave, TextConcepto.Leave, dtpFechai.Leave,
       textCodigo.Leave, textNombCodigo.Leave, TextValor.Leave, dtpFechaf.Leave
        desactiva(sender)
    End Sub

    Private Sub TextValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextValor.KeyPress
        soloNumeroDec(sender, e)
    End Sub

    Private Sub TextValor_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValor.Validated
        validatedDecimalPreci(sender, 8, 2)
    End Sub

    Private Sub TextValor_Entra(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValor.Enter
        EntraDecimal(sender)
    End Sub

    Private Sub btnBuscaCodigo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles axFecha.Validated
        validatedFecha(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub
End Class