Imports System.Data.SqlClient
Imports System.Object
Imports System.Drawing.Printing

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMINGNOTANOM.VB MIEMBRO DE NOMINA.SLN                                      **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmIngNotaNom
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
    Dim formacal, extras, tipovalor, cuentaCheque2, numnota As String
    Dim opc, IndiceTransac As Integer
    Dim WithEvents fEmp As frmMuestraCodigos
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim WithEvents f3C As frmMuestra3Columnas
    Dim banco, base, tipSeguro, transacSS As Integer
    Dim tibase, buses, tipomov, afectaSeguro, ctacte, cuentanom As String
    Dim ctrMes As New MesController(_conexion)
    Dim ctrTipoNom As New TipoNominasController()
    Dim porSeg, horasDia, factor As Decimal
    Dim rawKind As Integer
    Dim WithEvents fOrig As frmBancos
    Dim lpara As New Dictionary(Of String, Object)
    Private Sub frmIngNotaNom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ctrMes.FillComboMes(cmbMes, False)
        ctrTipoNom.FillComboTipoNomina(cmbTipo, True)
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
                     "bancoscta.cheque, bancoscta.cuenta from bancoscta inner join bancos on bancoscta.codigo=bancos.codigo where bancoscta.empresa=@empresa" &
                     " and bancoscta.tipo=1 and bancoscta.estado=0 and bancoscta.banco=@banco order by bancoscta.banco asc"
            llenaTabla(cadena, tbBancos, ListaParametros(lpara))
            If tbBancos.Rows.Count > 0 Then
                filaTemp = tbBancos.Rows.Item(0)
                TextCta.Text = filaTemp.Item(1)
                TextMoneda.Text = filaTemp.Item(2)
                TextNota.Text = filaTemp.Item(3) + 1
                cuentaCheque2 = filaTemp.Item(4)
                numnota = BuscaEscalar("select notad from empresas where empresa=@empresa", ListaParametros(lpara))
                TextNota.Text = numnota + 1
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
            cadena = "select  distinct bc.banco, b.nombre + ' CTA ' + bc.cta as nombBanCta , bc.moneda, bc.cheque, bc.cuenta from bancoscta bc " &
                     "inner join bancos b on bc.codigo=b.codigo " &
                     "where bc.empresa=@empresa and bc.tipo=1 and bc.estado=0 order by bc.banco asc "
            If llenaTabla(cadena, tbBancos, ListaParametros(lpara)) > 0 Then
                EnBuscaOrigen()
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

        lpara.Clear()
        lpara("empresa") = empresa

        filaTemp = tbBancos.Rows.Item(e.va2)
        TextCodigoBanco.Text = filaTemp.Item(0)
        TextCta.Text = filaTemp.Item(1)
        TextMoneda.Text = filaTemp.Item(2)

        cuentaCheque2 = filaTemp.Item(4)
        numnota = BuscaEscalar("select notad from empresas where empresa=@empresa", ListaParametros(lpara))
        TextNota.Text = numnota + 1
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
        cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa and nombre like '%' + @nombre + '%' and e.empleado in ( select empleado from contratos1 c1 " &
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
            cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa and empleado=@empleado" &
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
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        Dim Num As Int16
        If textEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre, c1.tiposeguro, tip.tibase, pu.extras, c1.base, pu.buses, ss.por, tib.horasdia, " &
                     " ss.transac from contratos1 c1 " &
                     " inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     " inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto  " &
                     " inner join tipopersonal tip on tip.empresa=c1.empresa and tip.tipoper=c1.tipoper " &
                     " inner join tiposbase tib on tib.empresa=c1.empresa and tib.tibase=tip.tibase " &
                     " inner join segurosocial ss on ss.empresa=c1.empresa and ss.tiposeguro=c1.tiposeguro " &
                     "where e.generapago='S' and c1.empresa=@empresa and empleado=@empleado"
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
                    " where  e.generapago='S' and c1.empresa=@empresa and empleado=@empleado" &
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
                 "formacal, tipomov, tipovalor, afectaSeguro, ctacte, factor, cuentanom " &
                 "from tipotran where empresa=@empresa And nombre Like '%' + @nombre + '%' and formacal in ('FM','IM','EX', 'CA', 'AN')  order by transac"
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
                     "from tipotran where empresa=@empresa" &
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
            .Columns(0).FillWeight = 10
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).FillWeight = 50
            .Columns(2).HeaderText = "Cantidad"
            .Columns(2).FillWeight = 10
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).HeaderText = "Valor"
            .Columns(3).FillWeight = 15
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderText = "Importe"
            .Columns(4).FillWeight = 15
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
        dtpFechai.Value = Today
        dtpFechaf.Value = Today
        TextNota.Clear()
        textEmpleado.Focus()
    End Sub

    Private Sub LimpiaParcial(ByVal sender As System.Object, ByVal e As System.EventArgs)
        borra_Mejorado(gpDatos, ep1)
        btnCancelar_Click(sender, e)
        gpDatos.Enabled = True
        gpDetalle.Enabled = False
        tbDatos.Rows.Clear()
        TextLiquido.Text = formato(0)
        TextDevengado.Text = formato(0)
        TextDescontado.Text = formato(0)
        TextSeguro.Text = formato(0)
        btnGuardar.Enabled = False
        ContextoMenuEnab(True, False, ctxMenu)
        btnGuardar.Enabled = False
        dpFecha.Focus()

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

        If dtpFechai.Value.Date >= dtpFechaf.Value.Date Then
            MsgBox("FECHA DEBE INICIAL DEBE SER MENOR  QUE LA FECHA FINAL", MsgBoxStyle.Information, "Mensaje del Sistema")
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
                Totaliza()
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim i, j, k, chNum, tasa, tasaEs, auxiliar As Integer
        Dim centro, cuentaSeguro As String
        Dim valT, valor, total As Decimal
        Dim tbTemp As New DataTable("temporal")
        Dim tbContra2 As New DataTable("contra2")
        Dim tbBus As New DataTable("buses2")
        Dim fechaEs As DateTime
        Dim fechai, fechaf As DateTime
        Dim id_diario As Int32 = 0
        Dim id_extra1 As Int32 = 0
        Dim fecha As DateTime = DateTime.Now


        Dim fila As DataRow
        Dim id_notab As Int32 = 0
        Dim tt As New DataTable
        lpara.Clear()

        If tbDatos.Rows.Count = 0 Then
            MsgBox("NO HA INGRESADO NINGUNA TRANSACCION", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        '  Try
        If MsgBox("DESEA GUARDAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            fechaEs = dpFecha.Value.Date
            fechai = dtpFechai.Value.Date
            fechaf = dtpFechaf.Value.Date
            If TextTasa.Text.Trim = "" Then
                tasa = 1
                tasaEs = 0
            Else
                tasa = TextTasa.Text.Trim
                tasaEs = TextTasa.Text.Trim
            End If

            lpara("empresa") = empresa
            lpara("nota") = TextNota.Text.Trim
            lpara("inicial") = user
            lpara("banco") = banco
            lpara("fecha") = fechaEs
            lpara("empleado") = textEmpleado.Text
            lpara("contrato") = TextConxContrato.Text
            lpara("fechai") = fechaI
            lpara("fechaf") = fechaF
            lpara("concepto") = TextConcepto.Text.Trim.ToUpper
            lpara("fechae") = DateTime.Today
            lpara("mes") = cmbMes.SelectedValue
            lpara("año") = CShort(TextAño.Text)
            lpara("tiponom") = cmbTipo.SelectedValue
            If BuscaEscalar("select count(*) from notasban where empresa=@empresa and nota=@nota", ListaParametros(lpara)) > 0 Then
                MsgBox("ESTA NOTA YA SE ENCUENTRA INGRESADA, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                chNum = BuscaEscalar("select max(nota) from notasban where empresa=@empresa", ListaParametros(lpara))
                lpara("notad") = chNum
                cadena = "update empresas set notad=@notad where empresa=@empresa"
                EjecutarQuery(cadena, ListaParametros(lpara))
                TextNota.Text = chNum + 1
                Exit Sub
            End If
            lpara("cheque") = TextNota.Text
            Dim modelo As New cmodelo()
            Try

                cadena = "insert into extra1 (empresa,tipo,inicial,banco,cheque,fecha,empleado,contrato,fechai,fechaf,concepto,estado,fechae, mes, año, tiponom) 
                         values (@empresa,'NB',@inicial,@banco,@cheque,@fecha,@empleado,@contrato,@fechai,@fechaF,@concepto,0,@fechae, @mes, @año, @tiponom);
                         SELECT SCOPE_IDENTITY();"
                id_extra1 = modelo.BuscaEscalar(cadena, ListaParametros(lpara))

                lpara("nota") = TextNota.Text.Trim
                lpara("moneda") = TextMoneda.Text.Trim
                lpara("tasa") = tasaEs
                lpara("fechao") = DateTime.Today
                cadena = "insert into notasban (empresa,nota,banco,tipo,notab,fecha,moneda,tasa,valor,concepto,estado,fechao,mes,anio) 
                          values (@empresa,@nota,@banco,'EX','0',@fecha,@moneda,@tasa,0,@concepto,0,@fechao,'','')
                          select scope_identity()"
                id_notab = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
                k = 0
                lpara("beneficiario") = textNombreEmple.Text
                lpara("concepto") = TextConcepto.Text.Trim.ToUpper
                cadena = "insert into diario1 (empresa,tipo,banco,docto,fecha,beneficiario,monto,concepto) 
                          values(@empresa,2," & 0 & ",@nota,@fecha,@beneficiario,0.0,@concepto);
                          select scope_identity();"
                id_diario = modelo.BuscaEscalar(cadena, ListaParametros(lpara))

                For i = 0 To tbDatos.Rows.Count - 1
                    lpara.Clear()
                    filaTemp = tbDatos.Rows(i)
                    lpara("empresa") = empresa
                    lpara("banco") = banco
                    lpara("cheque") = TextNota.Text
                    lpara("transac") = filaTemp.Item(0)
                    lpara("cantidad") = CDec(filaTemp.Item(2))
                    lpara("valor") = CDec(filaTemp.Item(4))
                    lpara("fechaEs") = fechaEs
                    lpara("fechaEs") = fechaEs
                    lpara("id_extra1") = id_extra1

                    lpara("cuenta") = filaTemp.Item(10)
                    cadena = "insert into extra2 (id_extra1,empresa,tipo,banco,cheque,transac,cantidad,valor) 
                              values (@id_extra1,@empresa,'NB',@banco,@cheque,@transac,@cantidad,@valor)"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    lpara("contrato") = TextConxContrato.Text
                    lpara("empleado") = textEmpleado.Text
                    lpara("fechai") = fechaI
                    cadena = "select p1.prestamo from (" &
                             " select *, cast ( ('01/' + cast (mesini as varchar(2)) + '/' + cast (añoini as varchar(4))) as datetime ) as fechaIni " &
                             "from prestamos1 ) p1 " &
                             "where empresa=@empresa and contrato=@contrato" &
                             " and p1.estado=0 and empleado=@empleado and saldo > 0 and @fechai >= fechaIni"

                    If filaTemp.Item(8) = "D" And filaTemp.Item(9) = "S" And llenaTabla(cadena, tbTemp, ListaParametros(lpara)) > 0 Then
                        lpara("prestamo") = tbTemp.Rows(0).Item(0)
                        cadena = "update prestamos1 set saldo=saldo-" & CDec(filaTemp.Item(4)) & " where empresa=@empresa and prestamo=@prestamo"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                        cadena = "insert into prestamos2 (empresa,prestamo,fecha,tipodocto,docto,cargos,abonos) 
                                 values (@empresa,@prestamo,@fechaEs,'NB',@cheque,0.00,@valor)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    End If
                    If filaTemp.Item(8) = "I" Then
                        cadena = "select centro from nomencla where cuenta=@cuenta and empresa=@empresa "
                        centro = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
                        If centro = "S" Then
                            cadena = "select origen, por from contratos2 where empresa=@empresa and contrato=@contrato and empleado=@empleado"
                            modelo.llenaTabla(cadena, tbContra2, ListaParametros(lpara))
                            valT = 0


                            For j = 0 To tbContra2.Rows.Count - 1
                                lpara.Clear()
                                lpara("empresa") = empresa
                                fila = tbContra2.Rows(j)
                                lpara("cuenta") = filaTemp.Item(10)
                                lpara("origen") = fila.Item(0)
                                lpara("empleado") = textEmpleado.Text
                                cadena = "select count(*) from auxiliarcta where empresa=@empresa and cuenta=@cuenta and origen=@origen and numero=3"
                                If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
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
                                lpara("id_diario") = id_diario
                                lpara("docto") = CInt(TextNota.Text)
                                lpara("codigo") = auxiliar
                                lpara("idNotab") = id_notab
                                lpara("fechaEs") = fechaEs
                                cadena = "select count(*) from diario2 where empresa=@empresa and tipo=2 and docto=@docto and cuenta=@cuenta and origen=@origen and codigo=@codigo and haber=0"
                                If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                                    k = k + 1
                                    lpara("debe") = (valor / tasa)
                                    cadena = "insert into notasban2 (id_notab,empresa,nota,origen,cuenta,codigo,debe,haber) 
                                              values(@idNotab,@empresa,@docto,@origen,@cuenta,@codigo,@debe,0)"
                                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                                    lpara("valor") = valor
                                    cadena = "insert into diario2 (id_diario,empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber) 
                                              values(@id_diario,@empresa,2," & 0 & ",@docto,@fechaEs,@origen,@cuenta,@codigo,@valor,0)"
                                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                Else
                                    cadena = "update d2 set debe=debe + " & valor & " from diario2 d2 where empresa=@empresa and tipo=2 and docto=@docto " &
                                             " and cuenta=@cuenta and origen=@origen and codigo=@codigo and haber=0"
                                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                                    cadena = "update c2 set debe=debe + " & (valor / tasa) & " from notasban2 c2 where empresa=@empresa  and nota=@docto " &
                                             " and cuenta=@cuenta and origen=@origen and codigo=@codigo and haber=0"
                                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                End If
                            Next j

                        Else
                            lpara.Clear()
                            lpara("empresa") = empresa
                            lpara("cuenta") = filaTemp.Item(10)
                            lpara("docto") = TextNota.Text
                            lpara("codigo") = auxiliar
                            lpara("idNota") = id_notab
                            lpara("fechaEs") = fechaEs
                            lpara("id_diario") = id_diario
                            cadena = "select count(*) from auxiliarcta where empresa=@empresa and cuenta=@cuenta and origen='000' and numero=4"
                            If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                                auxiliar = CInt(textEmpleado.Text)
                            Else
                                auxiliar = 0
                            End If
                            valor = CDec(filaTemp.Item(4))
                            cadena = "select count(*) from diario2 where empresa=@empresa and tipo=2 and docto=@docto" &
                                     " and cuenta=@cuenta and origen='000'" &
                                     " and codigo=@codigo and haber=0"
                            If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                                k = k + 1
                                lpara("debe") = (valor / tasa)
                                cadena = "insert into notasban2 (id_notab,empresa,nota,origen,cuenta,codigo,debe,haber) 
                                          values(@idNota,@empresa,@docto,'000',@cuenta,@codigo,@debe,0)"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                                lpara("valor") = valor
                                cadena = "insert into diario2 (id_diario,empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber) 
                                          values(@id_diario,@empresa,2," & 0 & ",@docto,@fechaEs,'000',@cuenta,@codigo,@valor,0)"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                            Else
                                cadena = "update d2 set debe=debe + " & valor & " from diario2 d2 where empresa=@empresa and tipo=2 and docto=@docto " &
                                         " and cuenta=@cuenta and origen='000' and codigo=@codigo and haber=0"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                cadena = "update c2 set debe=debe + " & (valor / tasa) & " from notasban2 c2 where empresa=@empresa and nota=@docto" &
                                         " and cuenta=@cuenta and origen='000' and codigo=@codigo and haber=0"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                            End If
                        End If
                    Else
                        lpara.Clear()
                        lpara("empresa") = empresa
                        lpara("cuenta") = filaTemp.Item(10)
                        lpara("docto") = TextNota.Text
                        lpara("codigo") = auxiliar
                        lpara("idNota") = id_notab
                        lpara("fechaEs") = fechaEs
                        lpara("id_diario") = id_diario
                        cadena = "select count(*) from auxiliarcta where empresa=@empresa and cuenta=@cuenta and origen='000'"
                        If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                            auxiliar = CInt(textEmpleado.Text)
                        Else
                            auxiliar = 0
                        End If
                        valor = CDec(filaTemp.Item(4))
                        cadena = "select count(*) from diario2 where empresa=@empresa and tipo=2 and docto=@docto" &
                                 " and cuenta=@cuenta and origen='000'" &
                                 " and codigo=@codigo and debe=0"
                        If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                            k = k + 1
                            lpara("haber") = (valor / tasa)
                            cadena = "insert into notasban2 (id_notab,empresa,nota,origen,cuenta,codigo,debe,haber) 
                                      values(@idNota,@empresa,@docto,'000',@cuenta,@codigo,0,@haber)"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                            lpara("valor") = valor
                            cadena = "insert into diario2 (id_diario,empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber) 
                                      values(@id_diario,@empresa,2," & 0 & ",@docto,@fechaEs,'000',@cuenta,@codigo,0,@valor)"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                        Else
                            cadena = "update d2 set haber=haber + " & valor & " from diario2 d2 where empresa=@empresa and tipo=2 and docto=@docto " &
                                     " and cuenta=@cuenta and origen='000' and codigo=@codigo and debe=0"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                            cadena = "update c2 set haber=haber + " & (valor / tasa) & " from notasban2 c2 where empresa=@empresa and nota=@docto " &
                                     " and cuenta=@cuenta and origen='000' and codigo=@codigo and debe=0"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                        End If
                    End If
                Next i

                lpara.Clear()
                lpara("empresa") = empresa
                lpara("banco") = banco
                lpara("cheque") = TextNota.Text.Trim
                lpara("transac") = transacSS
                lpara("valor") = CDec(TextSeguro.Text)
                lpara("tipoSeguro") = tipSeguro
                lpara("idNota") = id_notab
                lpara("fechaEs") = fechaEs
                lpara("id_diario") = id_diario
                lpara("id_extra1") = id_extra1
                If CDec(TextSeguro.Text) <> 0 Then
                    cadena = "insert into extra2 (id_extra1,empresa,tipo,banco,cheque,transac,cantidad,valor) 
                              values (@id_extra1,@empresa,'NB',@banco,@cheque,@transac,0,@valor)"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    cadena = "select cuentanom from segurosocial s inner join tipotran t on s.empresa=t.empresa and " &
                             "s.transac=t.transac where s.empresa=@empresa and tiposeguro=@tipoSeguro"
                    cuentaSeguro = modelo.BuscaEscalar(cadena, ListaParametros(lpara))

                    lpara("cuenta") = cuentaSeguro
                    cadena = "select count(*) from auxiliarcta where empresa=@empresa and cuenta=@cuenta and origen='000'"
                    If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                        auxiliar = CInt(textEmpleado.Text)
                    Else
                        auxiliar = 0
                    End If
                    k = k + 1
                    lpara("codigo") = auxiliar
                    lpara("haber") = (CDec(TextSeguro.Text) / tasa)
                    cadena = "insert into notasban2 (id_notab,empresa,nota,origen,cuenta,codigo,debe,haber) 
                              values(@idNota,@empresa,@cheque,'000',@cuenta,@codigo,0,@haber)"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    lpara("haber2") = CDec(TextSeguro.Text)
                    cadena = "insert into diario2 (id_diario,empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber) 
                              values(@id_diario,@empresa,2," & 0 & ",@cheque,@fechaEs,'000',@cuenta,@codigo,0,@haber2)"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                End If
                cadena = "select sum(debe-haber) from notasban2 where empresa=@empresa and nota=@cheque"
                total = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
                k = k + 1
                lpara("cuentaCheque2") = cuentaCheque2
                lpara("total") = total
                cadena = "insert into notasban2 (id_notab,empresa,nota,origen,cuenta,codigo,debe,haber) 
                          values(@idNota,@empresa,@cheque,'000',@cuentaCheque2,@banco,0,@total)"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                lpara("liquido") = CDec(TextLiquido.Text)
                cadena = "insert into diario2 (id_diario,empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber) 
                          values(@id_diario,@empresa,2," & 0 & ",@cheque,@fechaEs,'000',@cuentaCheque2,@banco,0,@liquido)"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                cadena = "update a set valor=@valor from notasban a where id_notab=@id_notab"
                lpara("valor") = total
                lpara("id_notab") = id_notab
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                lpara("beneficiario") = textNombreEmple.Text
                lpara("concepto") = TextConcepto.Text.Trim.ToUpper


                lpara("tasa") = tasaEs
                cadena = "insert into bantran (empresa,banco,fecha,banche,tipo,docto,valor,beneficiario,concepto,tasa) 
                          values (@empresa,@banco,@fechaEs,@banco,2,@cheque," & -(total) & ",@beneficiario,@concepto,@tasa)"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                cadena = "update empresas set notad=@cheque where empresa=@empresa"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                If modelo.Commit() Then
                    TextNota.Text = CInt(TextNota.Text) + 1
                    textEmpleado.Focus()
                    InsertBitacora(9, 1, "INGRESO NOTA BANCARIA EN NOMINA NUMERO " & TextNota.Text)
                    MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                    btnLimpiar_Click(sender, e)
                End If
            Catch ex As Exception
                MsgBox("ERROR DEL SISTEMA " & vbNewLine & ex.Message, MsgBoxStyle.Critical)
                modelo.RollBack()
            End Try
        Else
            MsgBox("NO HAY REGISTROS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del sistema")
        End If

    End Sub

    Private Sub frmRutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCodigoBanco.Enter,
       textEmpleado.Enter, textNombreEmple.Enter, TextConxContrato.Enter, TextConcepto.Enter, textCodigo.Enter, textNombCodigo.Enter, TextValor.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub


    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCodigoBanco.Leave,
       textEmpleado.Leave, textNombreEmple.Leave, TextConxContrato.Leave, TextConcepto.Leave, textCodigo.Leave, textNombCodigo.Leave, TextValor.Leave
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

    Private Sub btnBuscaCodigo_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        validatedFecha(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub
End Class