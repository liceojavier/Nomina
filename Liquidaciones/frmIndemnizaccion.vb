Imports ControllersERP.Nominas
Imports ControllersERP.General
Imports ControllersERP

Imports NOMINA.controller
Imports NOMINA.Entidades
Imports ControllersERP.ViewModels.Nominas
Imports System.Collections.Generic
Imports System.ComponentModel

Public Class frmIndemnizacion

    Dim ctrEmple As New EmpleadoController()
    Dim ctrContra As New ContratoController()
    Dim ctrNomi As New NominasController()
    Dim ctrLiqui As New LiquidacionController()
    Dim ctrVaca As New VacacionesController()
    Dim ctrTipoPer As New TipoPersonalController()
    Dim ctrPrestamos As New PrestamosController()
    Dim ctrMes As New MesController(_conexion)
    Dim tiponom_mensual As String = "M"
    Dim codigo_pais As String = ""
    Dim id_liqui1 As Short = 0
    Dim tbData As DataTable
    Dim cadena As String = ""
    Dim dpara As New Dictionary(Of String, Object)
    Dim tbContratos As New DataTable
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim mesNomF As Short = 0
    Dim añoNomF As Short = 0
    Dim valSueldo As Decimal = 0
    Dim fechai, fechaf As DateTime
    Dim diasVacaTipoPersonal As Decimal = 0
    Dim contrato As Short = 0
    Dim valorIndem As Decimal = 0
    Dim valorVacacion As Decimal = 0
    Dim valorAguinaldo As Decimal = 0
    Dim valorBono14 As Decimal = 0
    Dim meses As New Dictionary(Of Int32, String)
    Dim _listaIndem As BindingList(Of LiquidacionViewModel)
    Dim _listaVaca As BindingList(Of LiquidacionViewModel)
    Dim _listaBono As BindingList(Of LiquidacionViewModel)
    Dim _listaAguinaldo As BindingList(Of LiquidacionViewModel)
    Dim _CantidDias As Int32 = 0
    Dim _diasAñoAct As Decimal = 0
    Dim _diasBono14 As Decimal = 0
    Dim _diasAguinaldo As Decimal = 0
    Dim _tipoPersonal As TipoPersonalViewModel
    Dim ctrEmpresa As New EmpresasController
    Dim _empresaVM As EmpresaViewModel
    Dim _fechaIAgui As DateTime
    Dim _fechaIBono As DateTime
    Dim _existeNom As Boolean = False
    Dim _iniDiaUM As Int32 = 0
    Dim _CantDiasUM As Int32 = 0
    Dim _listaIngresos As BindingList(Of NominasViewModel)
    Dim _listaDescuentos As BindingList(Of NominasViewModel)

    ' Dim f2C As frmMuestra2Columnas

    Private Sub frmIndemnizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbCalculoAgui1.Checked = True
        rbCalculoBono1.Checked = True
        meses = ctrMes.GetMesesDic()
        _empresaVM = ctrEmpresa.GetEmpresas(empresa)
        dpFechaHoy.Value = Today
        busqEmpleado.id_empresa = empresa
        busqEmpleado.activo = False
        limpia()
    End Sub

    Private Sub btnContrato_Click(sender As Object, e As EventArgs) Handles btnContrato.Click
        Dim lpara As New Dictionary(Of String, Object)

        lpara.Clear()
        Dim Num As Int16
        If busqEmpleado.Empleado > 0 Then
            lpara("empresa") = empresa
            lpara("empleado") = busqEmpleado.Empleado 'textEmpleado.Text
            cadena = "select contrato, pu.nombre from contratos1 c1 inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                     "where c1.empresa=@empresa and empleado=@empleado"
            Num = llenaTabla(cadena, tbContratos, ListaParametros(lpara))
            If Num = 1 Then
                txtContrato.Text = tbContratos.Rows(0).Item(0)
                CargaInfo()
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 0)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContrato
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()
                txtFechaI.Focus()

            ElseIf Num = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                txtContrato.Clear()
            End If
        Else
            MsgBox("INGRESO PRIMERO EL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ActualizacionDatosContrato(ByVal sender As Object, ByVal e As clsActValorREvento) Handles f2C.actValor
        Dim filatemp As DataRow
        filatemp = tbContratos.Rows(e.va2)
        txtContrato.Text() = filatemp.Item(0)
        CargaInfo()
    End Sub



    Private Sub CargaInfo()
        Dim contrato As Short = 0
        Dim ftemp As DataRow
        dpara.Clear()
        If busqEmpleado.Empleado > 0 And Not String.IsNullOrEmpty(txtContrato.Text) AndAlso Short.TryParse(txtContrato.Text, contrato) Then

            Dim tbContrato As DataTable = ctrContra.GetContratoInfo(empresa, busqEmpleado.Empleado, contrato)
            If tbContrato.Rows.Count > 0 Then
                ftemp = tbContrato.Rows(0)

                txtFechaI.Text = ftemp.Item("fechai")
                fechai = ftemp.Item("fechai")
                If ftemp.Item("fechaf") IsNot DBNull.Value AndAlso ftemp.Item("fechaf") <> New DateTime(1900, 1, 1) Then
                    dpFechaF.Value = ftemp.Item("fechaf")
                    fechaf = ftemp.Item("fechaf")
                Else
                    dpFechaF.Value = DateTime.Today
                    fechaf = DateTime.Today
                End If

                txtPuesto.Text = ftemp.Item("nombre_puesto")
                añoNomF = ctrNomi.GetUltimoAño(empresa, busqEmpleado.Empleado, contrato)
                mesNomF = ctrNomi.GetUltimoMes(empresa, busqEmpleado.Empleado, contrato, añoNomF)
                txtAño.Text = añoNomF.ToString()
                txtMes.Text = ctrMes.GetNombreMes(mesNomF)
                diasVacaTipoPersonal = ftemp.Item("cantvaca")
                cadena = " select isnull(max(valor),0) from sueldos where empresa=@empresa and empleado=@empleado and contrato=@contrato and transac=1"
                dpara("empresa") = empresa
                dpara("empleado") = busqEmpleado.Empleado
                dpara("contrato") = contrato
                _tipoPersonal = ctrTipoPer.GetTipoPersonalByEmpleado(empresa, busqEmpleado.Empleado, contrato)

                valSueldo = BuscaEscalar(cadena, ListaParametros(dpara))
                txtSueldo.Text = valSueldo.ToString("N2")
                txtDiasLaborados.Text = ((fechaf - fechai).Days + 1).ToString()
                dpFechaIVaca.Value = New DateTime(fechaf.Year, 1, 1)

            End If
        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpia()
    End Sub

    Public Sub limpia()
        mesNomF = 0
        añoNomF = 0
        txtPuesto.Clear()
        txtMes.Clear()
        txtNoDiasVacaciones.Clear()
        txtFechaI.Clear()
        txtContrato.Clear()
        busqEmpleado.EraserForm()
        txtAño.Clear()
        _iniDiaUM = 0
        txtValorAguinaldo.Text = "0.00"
        txtValorBono14.Text = "0.00"
        txtValorIndem.Text = "0.00"
        txtValorVacaciones.Text = "0.00"
        txtTotal.Text = "0.00"
        TabControlP.Enabled = False
        dgvIndem.DataSource = Nothing
        dgvAguinaldo.DataSource = Nothing
        dgvBono14.DataSource = Nothing
        dgvVacaciones.DataSource = Nothing
        TabControlP.SelectedIndex = 0
        txtTotalDiasIndem.Text = "0"
        txtTotalDiasBono.Text = "0"
        txtTotalDiasVac.Text = "0"
        txtTotalDiasAguinaldo.Text = "0"
        txtSueldoProAgu.Text = "0.00"
        txtSueldoProBon.Text = "0.00"
        txtSueldoProIndem.Text = "0.00"
        txtSueldoProVac.Text = "0.00"
        txtValDiaPromVac.Text = "0.00"
        txtSueldo.Text = "0.00"
        txtDiasLaborados.Text = "0.00"
        _existeNom = False
        btnGenReporte.Enabled = False
        valorIndem = 0
        valorVacacion = 0
        valorAguinaldo = 0
        valorBono14 = 0
        _CantidDias = 0
        _diasAñoAct = 0
        _diasBono14 = 0
        _diasAguinaldo = 0
        _fechaIAgui = New DateTime(1900, 1, 1)
        _fechaIBono = New DateTime(1900, 1, 1)
        _tipoPersonal = Nothing
        totaliza()
    End Sub


    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        Dim fechaiVac As DateTime
        Dim salPromedioIndem As Decimal = 0
        Dim año, mes As Short
        Dim no_vaca As Decimal = 0


        Dim tiponom As String = ""
        Dim transacciones As String = ""
        Dim tipo As String = ""
        Dim valSusp As Decimal = 0
        Dim valSal As Decimal = 0
        Dim valorC As Decimal = 0
        Dim tupla As Tuple(Of Int32, Decimal)
        Dim valorDiaPromedio As Decimal = 0


        If busqEmpleado.Empleado > 0 AndAlso Short.TryParse(txtContrato.Text, contrato) AndAlso Int32.TryParse(txtDiasLaborados.Text, _CantidDias) Then

            'tbLiquiMaestro = ctrLiqui.GetLiquidacionMa(empresa)
            'tbTipopersonal = ctrContra.GetTipoPersonal(empresa, busqEmpleado.id_empleado)
            cbIndemnizacion.Checked = True


            Decimal.TryParse(txtNoDiasVacaciones.Text, no_vaca)
            'Dim er As emplegen = ctrEmple.GetEmpleado(busqEmpleado.id_empleado)
            'id_empleado = busqEmpleado.id_empleado
            'fechaInicio = er.fechai
            fechaf = dpFechaF.Value.Date
            If fechaf <= fechai Then
                MsgBox("La fecha final del contrato debe ser mayor que la inicial")
                Exit Sub
            End If
            fechaiVac = dpFechaIVaca.Value.Date
            If fechaf <= fechaiVac Then
                MsgBox("La fecha final debe ser mayor a la fecha inicial de vacaciones")
                Exit Sub
            End If
            Dim diasTrabAct As Decimal = 360
            If (DateTime.IsLeapYear(fechaiVac.Year)) Then
                _diasAñoAct = 366.0
                diasTrabAct = 366
            Else
                _diasAñoAct = 365.0
                diasTrabAct = 365
            End If

            If (_tipoPersonal IsNot Nothing AndAlso _tipoPersonal.basevaca > 0) Then
                diasTrabAct = (30 * _tipoPersonal.basevaca)
            End If

            If (fechai < New DateTime(fechaf.Year, fechaf.Month, 1)) Then
                _iniDiaUM = 1
            Else
                _iniDiaUM = fechai.Day
            End If
            _CantDiasUM = (fechaf.Day - _iniDiaUM) + 1



            _existeNom = ctrNomi.GetExistePagoNomina(empresa, "M", busqEmpleado.Empleado, contrato, fechaf.Month, fechaf.Year)



            txtNoDiasVacaciones.Text = (fechaf - fechaiVac).Days + 1
            txtTotalDiasVac.Text = (((fechaf - fechaiVac).Days + 1) * (diasVacaTipoPersonal / diasTrabAct)) + nudVacaNoTo.Value
            no_vaca = (((fechaf - fechaiVac).Days + 1) * (diasVacaTipoPersonal / diasTrabAct)) + nudVacaNoTo.Value
            mes = mesNomF
            año = añoNomF

            Dim i As Short = 0
            valorC = 0



            'Calculo indemnizacion
            _listaIndem = New BindingList(Of LiquidacionViewModel)
            Dim eleLiq As LiquidacionViewModel


            While (i < 6)

                valorC = ctrLiqui.GetLiquidacionTransac(empresa, 1, busqEmpleado.Empleado, contrato, mes, año)
                If (valorC > 0) Then
                    eleLiq = New LiquidacionViewModel With {
             .año = año,
             .mes = mes,
             .valor = valorC,
             .nombre_mes = meses(mes),
             .marca = False,
             .empresa = empresa
              }
                    _listaIndem.Add(eleLiq)
                End If
                If (mes = 1) Then
                    mes = 12
                    año = año - 1
                Else
                    mes -= 1
                End If
                i += 1


            End While

            '   listaIndem = listaIndem.OrderBy(Of Short)(Function(x) x.año).ThenBy(Of Short)(Function(x) x.mes)
            dgvIndem.DataSource = _listaIndem
            define_vista(dgvIndem)
            txtTotalDiasIndem.Text = _CantidDias.ToString()

            'Calculo vacaciones 

            mes = mesNomF
            año = añoNomF

            i = 0
            valorC = 0
            _listaVaca = New BindingList(Of LiquidacionViewModel)
            While (i < 12)
                valorC = ctrLiqui.GetLiquidacionTransac(empresa, 2, busqEmpleado.Empleado, contrato, mes, año)

                If (valorC > 0) Then
                    eleLiq = New LiquidacionViewModel With {
             .año = año,
             .mes = mes,
             .valor = valorC,
             .nombre_mes = meses(mes),
             .marca = False,
             .empresa = empresa
              }
                    _listaVaca.Add(eleLiq)
                End If
                valorC += BuscaEscalar(cadena, ListaParametros(dpara))
                If (mes = 1) Then
                    mes = 12
                    año = año - 1
                Else
                    mes -= 1
                End If
                i += 1

            End While
            dgvVacaciones.DataSource = _listaVaca
            define_vista(dgvVacaciones)



            'Bono 14
            Dim mesIni As Short = 0
            Dim añoIni As Short = 0
            If (fechaf.Month <= 6) Then
                mesIni = 7
                añoIni = fechaf.Year - 1
            Else
                mesIni = 7
                añoIni = fechaf.Year
            End If
            i += 1


            If (fechai < New DateTime(añoIni, 7, 1)) Then

                _diasBono14 = (fechaf - New DateTime(añoIni, 7, 1)).Days + 1
                _fechaIBono = New DateTime(añoIni, 7, 1)
            Else
                _diasBono14 = (fechaf - fechai).Days + 1
                _fechaIBono = fechai
            End If


            'Bono 14

            i = 0
            valorC = 0
            _listaBono = New BindingList(Of LiquidacionViewModel)
            While ((añoIni < añoNomF) Or (mesIni <= mesNomF And añoIni = añoNomF))
                valorC = ctrLiqui.GetLiquidacionTransac(empresa, 3, busqEmpleado.Empleado, contrato, mesIni, añoIni)
                If (valorC > 0) Then
                    eleLiq = New LiquidacionViewModel With {
             .año = añoIni,
             .mes = mesIni,
             .valor = valorC,
             .nombre_mes = meses(mesIni),
             .marca = False,
             .empresa = empresa
              }
                    _listaBono.Add(eleLiq)
                End If
                If (mesIni = 12) Then
                    mesIni = 1
                    añoIni += 1
                Else
                    mesIni += 1
                End If
                i += 1
            End While
            If Not _existeNom Then

                tupla = ctrLiqui.GetValorSuspensionLiquidacion(empresa, 3, busqEmpleado.Empleado, contrato, fechaf.Year, fechaf.Month)
                valSal = ctrLiqui.GetValorNominalPorCodigo(empresa, 3, busqEmpleado.Empleado, contrato)

                If (((valSal / 30.0) * _CantDiasUM) - tupla.Item2 - tupla.Item2) > 0 Then
                    valSal = ((valSal / 30.0) * _CantDiasUM) - tupla.Item2
                Else
                    valSal = 0
                End If

                Dim eleN = New LiquidacionViewModel With {
                .año = fechaf.Year,
                .mes = fechaf.Month,
                .valor = valSal,
                .nombre_mes = meses(fechaf.Month),
                .marca = False,
                .empresa = empresa}
                _listaBono.Add(eleN)
            End If



            dgvBono14.DataSource = _listaBono
            define_vista(dgvBono14)
            txtTotalDiasBono.Text = _diasBono14.ToString("N2")

            'Aguinaldo

            If (fechaf.Month = 12) Then
                mesIni = 12
                añoIni = fechaf.Year
            Else
                mesIni = 12
                añoIni = fechaf.Year - 1
            End If

            If (fechai < New DateTime(añoIni, 12, 1)) Then
                _diasAguinaldo = (fechaf - New DateTime(añoIni, 12, 1)).Days + 1
                _fechaIAgui = New DateTime(añoIni, 12, 1)
            Else
                _diasAguinaldo = (fechaf - fechai).Days + 1
                _fechaIAgui = fechai
            End If
            i = 0
            valorC = 0

            _listaAguinaldo = New BindingList(Of LiquidacionViewModel)
            While ((añoIni < añoNomF) Or (mesIni <= mesNomF And añoIni = añoNomF))
                valorC = ctrLiqui.GetLiquidacionTransac(empresa, 4, busqEmpleado.Empleado, contrato, mesIni, añoIni)
                If (valorC > 0) Then
                    eleLiq = New LiquidacionViewModel With {
             .año = añoIni,
             .mes = mesIni,
             .valor = valorC,
             .nombre_mes = meses(mesIni),
             .marca = False,
             .empresa = empresa
              }
                    _listaAguinaldo.Add(eleLiq)
                End If
                If (mesIni = 12) Then
                    mesIni = 1
                    añoIni += 1
                Else
                    mesIni += 1
                End If
                i += 1
            End While
            If Not _existeNom Then

                tupla = ctrLiqui.GetValorSuspensionLiquidacion(empresa, 4, busqEmpleado.Empleado, contrato, fechaf.Year, fechaf.Month)
                valSal = ctrLiqui.GetValorNominalPorCodigo(empresa, 4, busqEmpleado.Empleado, contrato)

                If (((valSal / 30.0) * _CantDiasUM) - tupla.Item2 - tupla.Item2) > 0 Then
                    valSal = ((valSal / 30.0) * _CantDiasUM) - tupla.Item2
                Else
                    valSal = 0
                End If

                Dim eleN = New LiquidacionViewModel With {
                .año = fechaf.Year,
                .mes = fechaf.Month,
                .valor = valSal,
                .nombre_mes = meses(fechaf.Month),
                .marca = False,
                .empresa = empresa}
                _listaAguinaldo.Add(eleN)
            End If


            dgvAguinaldo.DataSource = _listaAguinaldo
            define_vista(dgvAguinaldo)
            txtTotalDiasAguinaldo.Text = _diasAguinaldo.ToString("N2")
            btnGenReporte.Enabled = True


            'Salario faltante
            'txtSueldoSal.Text = ctrEmple.GetEmpleadoSueldo(empresa, busqEmpleado.Empleado, contrato)
            'txtSueldoDiarioSal.Text = CDec(txtSueldoDiarioSal.Text) / 30.0
            'Dim tbPrestamos As DataTable = ctrPrestamos.GetPrestamos(empresa, busqEmpleado.Empleado, contrato)






            txtTotal.Text = (valorIndem + valorVacacion + valorBono14 + valorAguinaldo).ToString("N2")
            TabControlP.Enabled = True
            TabControlP.SelectedIndex = 0
        End If
    End Sub


    Private Sub define_vista(ByRef dgv As DataGridView)
        With dgv
            .Columns("empresa").Visible = False
            .Columns("mes").Visible = False
            .Columns("numero").Visible = False
            .Columns("nombre_mes").HeaderText = "Mes"
            .Columns("nombre_mes").FillWeight = 50
            .Columns("nombre_mes").ReadOnly = True
            .Columns("año").HeaderText = "Año"
            .Columns("año").FillWeight = 20
            .Columns("año").ReadOnly = True
            .Columns("valor").HeaderText = "Valor"
            .Columns("valor").FillWeight = 20
            .Columns("valor").DefaultCellStyle.Format = "N2"
            .Columns("valor").ReadOnly = True
            .Columns("marca").HeaderText = "Aplicar"
            .Columns("marca").FillWeight = 10
            .Columns("valor").ReadOnly = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
        End With

    End Sub

    Private Sub genera_nomina(empresa As Short, empleado As Int32, contrato As Short, año As Int32, mes As Int32, dias As Int32)
        dpara.Clear()
        Dim tbDet As New DataTable()
        Dim fila2 As DataRow
        dpara("empresa") = empresa
        Dim eleNom As NominasViewModel
        dpara("empleado") = empleado
        dpara("contrato") = contrato
        dpara("mes") = mes
        dpara("año") = año
        cadena = "select c1.tipoper, c1.tiposeguro, tip.tibase, c1.base  " &
                     "sue.afecta, sue.transac,  sue.valor as sueldo, tib.horasdia, tran.afectaseguro, tran.nombre as nombre_transac, tran.tipomov " &
                     "from contratos1 c1 " &
                     "inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "inner join tipopersonal tip on tip.empresa=c1.empresa and tip.tipoper=c1.tipoper " &
                     "inner join tiposbase tib on tib.empresa=c1.empresa and tib.id_tbase=tip.id_tbase " &
                     "inner join sueldos sue on c1.empresa =sue.empresa and c1.empleado=sue.empleado and c1.contrato=sue.contrato " &
                     "inner join tipotran tran on  c1.empresa =tran.empresa and sue.transac=tran.transac " &
                     "where c1.mpago=@tiponom and e.generapago='S' and tip.pagonomina='S' and c1.empresa=@empresa " &
                     " and c1.empleado=@empleado and c1.contrato=@contrato "

        If llenaTabla(cadena, tbContratos, ListaParametros(dpara)) > 0 Then

            'For Each filaTemp As DataRow In tbContratos.Rows
            '    If (filaTemp.Item("sueldo") > 0) Then

            '        dpara("transac") = filaTemp("transac")
            '        cadena = "select a.mes, a.año, a.transac, c.nombre as nombre_transac, c.tipomov, a.cantidad, a.valor from movinomina a
            '                  inner join contratos1 b on a.empresa=b.empresa and a.empleado=b.empleado and a.contrato=b.contrato
            '                  inner join tipotran c on a.transac=c.transac and a.empresa=c.transac
            '                  where b.empleado=@empleado and b.contrato=@contrato and b.empresa=@empresa and a.mes=@mes and a.año=@año "
            '        If llenaTabla(cadena, tbDet, ListaParametros(dpara)) > 0 Then
            '            fila2 = tbDet.Rows(0)
            '            eleNom = New NominasViewModel With {
            '                .empleado = empleado,
            '                .contrato = contrato,
            '                .año = año,
            '                .mes = mes,
            '                .transac = filaTemp("transac"),
            '                .nombre_transac = filaTemp("transac"),
            '                .cantidad = fila2("cantidad"),
            '                .valor = fila2("valor"),
            '                .nombre_mes = meses(mes),
            '                .empresa = empresa,
            '                .tipomov = filaTemp("tipomov")
            '            }
            '        Else

            '        End If




            '        cantiMov = 0
            '        'Si la  tipo de nomina acepta movimientos y la transaccion es afectada por los días,
            '        'afecta es que dependiendo el número de días laborados se paga o no se paga
            '        dpara("empleado") = filaTemp.Item("empleado")
            '        dpara("contrato") = filaTemp.Item("contrato")
            '        dpara("transac") = filaTemp.Item("transac")
            '        dpara("mes") = mes
            '        dpara("año") = año
            '        If movimientos = "S" And filaTemp.Item("afecta") = "S" Then
            '            cadena = "Select coalesce( max( cantidad), 0) from movinomina where empresa=@empresa And empleado=@empleado And contrato=@contrato And transac=@transac And año=@año And mes=@mes "
            '            cantiMov = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
            '            ' Se obtiene la cantidad maxima de una transacción en los movimientos, por empleado y contrato para un
            '            ' mes y año específico
            '            'Puede darse el caso que los movimientos sean por valor o por cantidad
            '        End If
            '        'Si el movimiento es por cantidad
            '        If cantiMov > 0 Then
            '            'Se revisa si el contrato base del empleado es por horas o por días
            '            If filaTemp.Item("tibase") = "D" Then
            '                'Si es por días solo se iguala a la cantidad
            '                cantidad = cantiMov
            '            ElseIf filaTemp.Item("tibase") = "H" Then
            '                'Si es por hora agarra la cantidad máxima de Horas por 
            '                cantidad = (cantiMov * filaTemp.Item("base")) / cantidadI
            '            End If
            '            valorNom = (filaTemp.Item("sueldo") / filaTemp.Item("base")) * cantidad * (por / 100)
            '            lpara("fecha") = FechaInom
            '            cadena = "Select p1.prestamo, p1.tipopre,  p1.descuento, p1.saldo, tp.transac from (" &
            '                     " Select *, cast ( ('01/' + cast (mesini as varchar(2)) + '/' + cast (añoini as varchar(4))) as datetime ) as fechaIni " &
            '                     "from prestamos1 ) p1 , tiposprestamo tp " &
            '                     "where p1.empresa=tp.empresa and p1.tipopre=tp.tipopre and p1.empresa=@empresa " &
            '                     "and p1.estado=0 and contrato=@contrato and empleado=@empleado " &
            '                     "and saldo > 0 and @fecha >= fechaIni and tp.transac=@transac"
            '            If modelo.llenaTabla(cadena, tbMovi, ListaParametros(lpara)) > 0 Then
            '                fTemp2 = tbMovi.Rows(0)
            '                lpara("prestamo") = fTemp2.Item("prestamo")
            '                cadena = "select sum( cargos-abonos) from prestamos2 where prestamo=@prestamo"
            '                Dim valorSaldo = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
            '                Dim abono As Decimal = 0
            '                If (fTemp2("descuento") > valorSaldo) Then
            '                    abono = valorSaldo
            '                Else
            '                    abono = fTemp2("descuento")
            '                End If
            '                lpara("tiponom") = tipoNom
            '                lpara("abonos") = abono

            '                lpara("fecha") = fechaFnom
            '                lpara("abonos") = valorNom
            '                lpara("docto") = CInt(mes.ToString() & año.ToString())
            '                cadena = "insert into prestamos2 (empresa,prestamo,fecha,tipodocto,docto,cargos,abonos,tiponom,mes,año) 
            '                          values (@empresa,@prestamo,@fecha,'NM',@docto,0.00,@abonos,@tiponom,@mes,@año)"
            '                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
            '                Dim saldo As Decimal = valorSaldo - abono
            '                lpara("saldo") = saldo
            '                cadena = "update prestamos1 set saldo=@saldo where empresa=@empresa and prestamo=@prestamo "
            '                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

            '            End If
            '        ElseIf cantiMov = 0 And filaTemp.Item("afecta") = "S" Then
            '            fechai = FechaInom
            '            If filaTemp.Item("fechai") > fechai Then
            '                fechai = filaTemp.Item("fechai")
            '                dias = cantidadI - fechai.Day + 1
            '                If filaTemp.Item("tibase") = "D" Then
            '                    cantidad = dias
            '                ElseIf filaTemp.Item("tibase") = "H" Then
            '                    cantidad = (dias * filaTemp.Item("base")) / cantidadI
            '                End If
            '                valorNom = (filaTemp.Item("sueldo") / filaTemp.Item("base")) * cantidad * (por / 100)
            '            Else
            '                cantidad = cantidadI
            '                valorNom = filaTemp.Item("sueldo") * (por / 100)
            '            End If
            '        Else
            '            cantidad = cantidadI
            '            valorNom = filaTemp.Item("sueldo") * (por / 100)
            '        End If
            '        lpara("fechai") = fechai
            '        lpara("fechaFnom") = fechaFnom
            '        lpara("cantidad") = cantidad
            '        lpara("valor") = valorNom
            '        lpara("tiponom") = tipoNom
            '        cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor ) 
            '                  values (@empresa,@tiponom,@mes,@año,@empleado,@contrato,@fechai,@fechaFnom,@transac,@cantidad,@valor)"
            '        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
            '    End If
            'Next
            'Importante, aqui revisa las transacciones que están en la tabla de sueldos, las otras transacciones que pudieran estar en movimientos las ve en la otra rutina
            'La X ser genera si no tiene suspensiones y la S si la el tipo de suspension genera nomina
            'Esta es una forma de verificar que se le genere nomina a un empleado, de igual manera se necesita que el sueldo sea mayor que 0

        End If
    End Sub

    Private Sub cbIndemnizacion_CheckedChanged(sender As Object, e As EventArgs) Handles cbIndemnizacion.CheckedChanged
        If cbIndemnizacion.Checked Then
            dgvIndem.Enabled = True
            txtValorIndem.Enabled = True
            btnGenIndem.Enabled = True
            totaliza()
        Else
            dgvIndem.Enabled = False
            txtValorIndem.Enabled = False
            btnGenIndem.Enabled = False
            txtValorIndem.Enabled = False
            txtValorIndem.Text = "0.00"
            valorIndem = 0.00
            totaliza()
        End If
    End Sub

    Private Sub btnGenIndem_Click(sender As Object, e As EventArgs) Handles btnGenIndem.Click

        Dim i As Short = 0
        Dim valorC As Decimal = 0

        Dim salPromedioIndem As Decimal = 0
        Dim cantidadPromedio As Short = 0

        cantidadPromedio = _listaIndem.Where(Function(x) x.marca = True).Count()
        If cantidadPromedio = 0 Then
            MsgBox("Debe seleccionar al menos un periodo para el calculo de la indemnizacion")
            Exit Sub
        End If
        valorC = _listaIndem.Where(Function(x) x.marca = True).Sum(Function(x) x.valor)

        valorC = valorC / cantidadPromedio
        salPromedioIndem = (valorC * 14.0) / 12.0
        txtSueldoProIndem.Text = salPromedioIndem.ToString("N2")
        valorIndem = (salPromedioIndem / 365.0) * _CantidDias
        txtValorIndem.Text = valorIndem.ToString("N2")
        totaliza()
    End Sub

    Private Sub btnGenVaca_Click(sender As Object, e As EventArgs) Handles btnGenVaca.Click
        Dim i As Short = 0
        Dim valorC As Decimal = 0
        Dim fechaiVac As DateTime
        Dim salPromedioIndem As Decimal = 0
        Dim cantidadPromedio As Short = 0
        Dim valorDiaPromedio As Decimal = 0
        Dim diasAñoAct As Decimal = 0
        Dim no_vaca As Decimal = 0
        cantidadPromedio = _listaVaca.Where(Function(x) x.marca = True).Count()
        If cantidadPromedio = 0 Then
            MsgBox("Debe seleccionar al menos un periodo para el calculo de vacaciones")
            Exit Sub
        End If

        If Decimal.TryParse(txtNoDiasVacaciones.Text, no_vaca) Then
            fechaf = dpFechaF.Value.Date
            If fechaf <= fechai Then
                MsgBox("La fecha final del contrato debe ser menor que la inicial")
                Exit Sub
            End If
            fechaiVac = dpFechaIVaca.Value.Date
            If fechaf <= fechaiVac Then
                MsgBox("La fecha final debe ser mayor a la fecha inicial de vacaciones")
                Exit Sub
            End If

            Dim diasTrabAct As Decimal = 360
            If (DateTime.IsLeapYear(fechaiVac.Year)) Then
                _diasAñoAct = 366.0
                diasTrabAct = 366
            Else
                _diasAñoAct = 365.0
                diasTrabAct = 365
            End If

            If (_tipoPersonal IsNot Nothing AndAlso _tipoPersonal.basevaca > 0) Then
                diasTrabAct = (30 * _tipoPersonal.basevaca)
            End If

            txtNoDiasVacaciones.Text = (fechaf - fechaiVac).Days + 1
            txtTotalDiasVac.Text = (((fechaf - fechaiVac).Days + 1) * (diasVacaTipoPersonal / diasTrabAct)) + nudVacaNoTo.Value
            no_vaca = (((fechaf - fechaiVac).Days + 1) * (diasVacaTipoPersonal / diasTrabAct)) + nudVacaNoTo.Value

            valorC = _listaVaca.Where(Function(x) x.marca = True).Sum(Function(x) x.valor)

            valorC = valorC / cantidadPromedio
            txtSueldoProVac.Text = valorC.ToString("N2")
            valorDiaPromedio = (valorC * 12.0) / 360.0
            txtValDiaPromVac.Text = valorDiaPromedio.ToString("N2")
            valorVacacion = valorDiaPromedio * no_vaca
            txtValorVacaciones.Text = valorVacacion.ToString("N2")
            totaliza()
        Else
            MsgBox("El número de días de vacaciones no es válido")
            Exit Sub
        End If
        'Dim er As emplegen = ctrEmple.GetEmpleado(busqEmpleado.id_empleado)
        'id_empleado = busqEmpleado.id_empleado
        'fechaInicio = er.fechai

    End Sub

    Private Sub btnGenBono_Click(sender As Object, e As EventArgs) Handles btnGenBono.Click
        Dim i As Short = 0
        Dim valorC As Decimal = 0
        Dim valorBonoC As Decimal = 0
        Dim salPromedioIndem As Decimal = 0
        Dim cantidadPromedio As Short = 0

        cantidadPromedio = _listaBono.Where(Function(x) x.marca = True).Count()
        If cantidadPromedio = 0 Then
            MsgBox("Debe seleccionar al menos un periodo para el calculo del bono")
            Exit Sub
        End If
        valorC = _listaBono.Where(Function(x) x.marca = True).Sum(Function(x) x.valor)
        valorBonoC = _listaBono.Where(Function(x) x.marca = True).Sum(Function(x) x.valor * 0.0833)

        valorC = valorC / cantidadPromedio
        txtSueldoProBon.Text = valorC.ToString("N2")
        valorBono14 = valorBonoC
        txtValorBono14.Text = valorBono14.ToString("N2")
        totaliza()
    End Sub

    Private Sub btnAguinaldo_Click(sender As Object, e As EventArgs) Handles btnAguinaldo.Click
        Dim i As Short = 0
        Dim valorC As Decimal = 0
        Dim valorAguiC As Decimal = 0
        Dim salPromedioIndem As Decimal = 0
        Dim cantidadPromedio As Short = 0

        cantidadPromedio = _listaAguinaldo.Where(Function(x) x.marca = True).Count()
        If cantidadPromedio = 0 Then
            MsgBox("Debe seleccionar al menos un periodo para el calculo del aguinaldo")
            Exit Sub
        End If
        valorC = _listaAguinaldo.Where(Function(x) x.marca = True).Sum(Function(x) x.valor)

        valorAguiC = _listaAguinaldo.Where(Function(x) x.marca = True).Sum(Function(x) x.valor * 0.0833)
        valorC = valorC / cantidadPromedio
        txtSueldoProAgu.Text = valorC.ToString("N2")
        valorAguinaldo = valorAguiC
        txtValorAguinaldo.Text = valorAguinaldo.ToString("N2")
        totaliza()
    End Sub



    Private Sub dpFechaF_ValueChanged(sender As Object, e As EventArgs) Handles dpFechaF.ValueChanged
        If fechai <> New DateTime(1900, 1, 1) Then
            fechaf = dpFechaF.Value.Date
            If fechaf < fechai Then
                MsgBox("La fecha final del contrato debe ser menor que la inicial")
                dpFechaF.Value = fechaf
                Exit Sub
            End If
            txtDiasLaborados.Text = ((fechaf - fechai).Days + 1).ToString()
        Else
            txtDiasLaborados.Text = "0"
        End If

    End Sub


    Private Sub marcaTodo(dgv As DataGridView)
        If Not dgv.DataSource Is Nothing AndAlso dgv.Columns.Contains("marca") Then
            For Each row As DataGridViewRow In dgv.Rows
                row.Cells("marca").Value = True
            Next
        End If

    End Sub

    Private Sub btnMarcaA_Click(sender As Object, e As EventArgs) Handles btnMarcaA.Click
        marcaTodo(dgvAguinaldo)
    End Sub

    Private Sub btnDescmarcaA_Click(sender As Object, e As EventArgs) Handles btnDescmarcaA.Click
        desmarcaTodo(dgvAguinaldo)
    End Sub

    Private Sub btnMarcaB_Click(sender As Object, e As EventArgs) Handles btnMarcaB.Click
        marcaTodo(dgvBono14)
    End Sub

    Private Sub btnDescmarcaB_Click(sender As Object, e As EventArgs) Handles btnDescmarcaB.Click
        desmarcaTodo(dgvBono14)
    End Sub

    Private Sub btnMarcaV_Click(sender As Object, e As EventArgs) Handles btnMarcaV.Click
        marcaTodo(dgvVacaciones)
    End Sub

    Private Sub btnDesmarcaV_Click(sender As Object, e As EventArgs) Handles btnDesmarcaV.Click
        desmarcaTodo(dgvVacaciones)
    End Sub

    Private Sub btnMarcarI_Click(sender As Object, e As EventArgs) Handles btnMarcarI.Click
        marcaTodo(dgvIndem)
    End Sub

    Private Sub btnDescmarcaI_Click(sender As Object, e As EventArgs) Handles btnDescmarcaI.Click
        desmarcaTodo(dgvIndem)
    End Sub

    Private Sub desmarcaTodo(dgv As DataGridView)
        If Not dgv.DataSource Is Nothing AndAlso dgv.Columns.Contains("marca") Then
            For Each row As DataGridViewRow In dgv.Rows
                row.Cells("marca").Value = False
            Next
        End If
    End Sub

    Private Sub btnGenReporte_Click(sender As Object, e As EventArgs) Handles btnGenReporte.Click

        Try
            dpara.Clear()
            If (_empresaVM IsNot Nothing) Then
                dpara("nombre_empresa") = _empresaVM.nombre
                dpara("sucursal") = _empresaVM.nombre2
                dpara("moneda") = _empresaVM.moneda
            End If


            dpara("nombre_empleado") = busqEmpleado.Nombre
            dpara("empleado") = busqEmpleado.Empleado
            dpara("contrato") = contrato
            dpara("fechai") = CDate(txtFechaI.Text)
            dpara("fechaf") = dpFechaF.Value.Date
            dpara("nombre_puesto") = txtPuesto.Text
            dpara("motivo") = txtMotivo.Text
            dpara("salario_mensual") = CDec(txtSueldo.Text)
            dpara("fechaiVaca") = dpFechaIVaca.Value.Date
            dpara("fechaiAgui") = _fechaIAgui
            dpara("fechaiBono") = _fechaIBono
            dpara("fecha_finiquito") = dpFechaHoy.Value.Date
            Dim tupla As Tuple(Of String, String) = ctrEmple.GetIdentificaEmpleado(busqEmpleado.Empleado, empresa)
            If tupla IsNot Nothing Then

                dpara("tiidentifica") = tupla.Item1
                dpara("identificacion") = tupla.Item2
            Else

                dpara("tiidentifica") = ""
                dpara("identificacion") = ""
            End If
            dpara("sueldoInd") = 0
            dpara("DocAgui") = 0
            dpara("DocBono") = 0
            dpara("valorIndem") = valorIndem
            dpara("valorVaca") = valorVacacion
            dpara("valorAgui") = valorAguinaldo
            dpara("valorBono") = valorBono14
            dpara("nombre_gestionrhh") = ""
            dpara("nombre_directorf") = ""
            dpara("transac") = 0
            dpara("tipo_movimiento") = ""
            dpara("valor_transac") = 0

            cadena = "select @nombre_empresa as [nombre_empresa], @sucursal as [sucursal], @nombre_empleado as [nombre_empleado], @empleado as [empleado], @contrato as [contrato], 
               @fechai as [fechai], @fechaf as [fechaf], 
               @nombre_puesto as  [nombre_puesto], @motivo as [motivo], @salario_mensual as [salario_mensual],
               @moneda as [moneda], @fechaiVaca as [fechaiVaca], @fechaiAgui as [fechaiAgui], @fechaiBono as [fechaiBono],
               @fecha_finiquito as [fecha_finiquito], @tiidentifica as tiidentifica, @identificacion as [identificacion], @sueldoInd as [sueldoInd], @DocAgui as [DocAgui],
               @DocBono as [DocBono], @valorIndem as [valorIndem], @valorVaca as [valorVaca], @valorAgui as [valorAgui], @valorBono as [valorBono], 
               @nombre_gestionrhh as [nombre_gestionrhh], @nombre_directorf as [nombre_directorf], @transac as [transac], @tipo_movimiento as [tipo_movimiento], 
                [valor_transac] from v_Finiquito "
            Dim tbData As New DataTable
            llenaTabla(cadena, tbData, ListaParametros(dpara))
            If tbData.Rows.Count > 0 Then
                Dim repo As New cryFiniquito
                Dim forma As New FrmMuestraReporte
                forma.Inicializacion(repo, tbData, CrystalDecisions.Shared.PaperSize.PaperLetter)
                forma.TopLevel = True
                forma.ShowDialog()
            Else
                MsgBox("No se puede generar el reporte.", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error en generar el reporte " + vbNewLine + ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub totaliza()
        txtTotal.Text = (valorIndem + valorVacacion + valorBono14 + valorAguinaldo).ToString("N2")
    End Sub

End Class