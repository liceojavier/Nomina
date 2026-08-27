Imports System.Data.SqlClient
Imports NOMINA.Entidades

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMMANTMOVNOMINAS.VB MIEMBRO DE NOMINA.SLN                                  **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmMantMovNominas
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
    Dim filaTemp As DataRow
    Dim formacal, extras, _tipovalor As String
    Dim opc, IndiceTransac As Integer
    Dim WithEvents fEmp As frmMuestra2Columnas
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim WithEvents f3C As frmMuestra3Columnas
    Dim tbMes As New DataTable()
    Dim para As New Dictionary(Of String, Object)
    Dim meses As List(Of Mes)
    Dim pnCtr As PagosnomController
    Dim mesCtr As MesController
    Dim _fMod As DataRow
    Dim lPagos As New List(Of Pagosnom)
    Dim lPara As New Dictionary(Of String, Object)


    Private Sub frmMantenimientosMovi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TextAño.Text = DateTime.Today.Year

        cadena = "select nombre, tiponom from tiponomina1 where empresa=" & empresa & " and movimientos='S' order by tiponom"
        llena_combo(cadena, cmbTipo)
        cmbTipo.Items.Add("")
        llenaTabla(cadena, tbTipo)
        cadena = "select nombre, mes from meses order by mes"
        llenaTabla(cadena, tbMes)
        cbMes.DataSource = tbMes
        cbMes.DisplayMember = "nombre"
        cbMes.ValueMember = "mes"
        btnLimpiar_Click(sender, e)
        pnCtr = New PagosnomController(_conexion)
        mesCtr = New MesController(_conexion)
        'Dim ctrMes As New MesController
        'meses = ctrMes.GetMeses()
        meses = mesCtr.GetMeses()

    End Sub


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
        cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=" & empresa & " and nombre like '%" &
        textNombreEmple.Text.Trim & "%' " &
        " and e.empleado in ( select empleado from contratos1 c1 " &
        "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) " &
        "order by nombre"
        numFilas = llenaTabla(cadena, tbEmpleado)
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
        If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=" & empresa &
                 " and empleado=" & textEmpleado.Text.Trim) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=" & empresa &
               " and empleado=" & textEmpleado.Text.Trim & " " &
                " and e.empleado in ( select empleado from contratos1 c1 " &
                "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) "
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
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
        fEmp = New frmMuestra2Columnas
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado, "CODIGO", "NOMBRE", 0)
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
        If textEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre, pu.extras from contratos1 c1 inner join " &
                     "empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                     "where e.activo='S' and c1.empresa=" & empresa & " and empleado=" & textEmpleado.Text
            Num = llenaTabla(cadena, tbContratos)
            If Num = 1 Then
                TextConxContrato.Text = tbContratos.Rows(0).Item(0)
                extras = tbContratos.Rows(0).Item(2)
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 1)
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
        extras = filaTemp.Item(2)
    End Sub

    Private Sub TextConxContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextConxContrato.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextConxContrato_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextConxContrato.Validated
        Dim tbTem As New DataTable("temp")
        If TextConxContrato.Text.Trim <> "" And textEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre, pu.extras from contratos1 c1 inner join " &
                       "empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                       "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                       "where e.activo='S' and c1.empresa=" & empresa & " and empleado=" & textEmpleado.Text &
                       "  and c1.contrato=" & TextConxContrato.Text
            If llenaTabla(cadena, tbTem) = 0 Then
                MsgBox("ESTE NUMERO DE CONTRATO ACTIVO NO EXISTE PARA ESTE EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            Else
                extras = tbTem.Rows(0).Item(2)
                cmbTipo.Focus()
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
        cadena = "select transac, nombre, case when tipomov='I' then 'INGRESO' else 'DESCUENTO' END as nombTipomov," &
                 " formacal,  tipovalor from tipotran where empresa=" & empresa & " and nombre like '%" &
        textNombCodigo.Text.Trim & "%' and formacal in ('FM','IM','EX','CA')  order by transac"
        numFilas = llenaTabla(cadena, tbCodigo)
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TRANSACCIONES CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCodigo(True)
            textCodigo.Focus()
        ElseIf numFilas = 1 Then
            BorraCodigo(True)
            filaTemp = tbCodigo.Rows.Item(0)
            textCodigo.Text() = filaTemp.Item(0)
            textNombCodigo.Text = filaTemp.Item(1)
            formacal = filaTemp.Item("formacal")
            _tipovalor = filaTemp.Item("tipovalor")

            cbMes.Focus()
            IngresarTransaccion()
        Else
            EnBuscaCodigo()
        End If
    End Sub

    Private Sub ValidaCodigo()
        If valida_tipo_Entero(textCodigo.Text, 1) = True Then
            If BuscaEscalar("select count (*) from tipotran where empresa=" & empresa &
                 " and transac=" & textCodigo.Text.Trim) = 0 Then
                MsgBox("TRANSACCION NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraCodigo(True)
                textCodigo.Focus()
                Exit Sub
            End If
            cadena = "select transac, nombre, case when tipomov='I' then 'INGRESO' else 'DESCUENTO' END as nombTipomov," &
                  " formacal, tipovalor from tipotran where empresa=" & empresa &
                 " and transac=" & textCodigo.Text.Trim & " and formacal in ('FM','IM','EX')"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraCodigo(False)
                dr.Read()
                textNombCodigo.Text = dr.GetValue(1)

                formacal = dr.GetValue(3)
                _tipovalor = dr.GetValue(4)
                dr.Close()
                cn.Close()
                cbMes.Focus()
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
        f3C.inicializa(tbCodigo, "TRANSACCION", "NOMBRE", "TIPO", 2)
        AddHandler f3C.actValor, AddressOf ActualizacionDatosMonitor
        f3C.StartPosition = FormStartPosition.CenterScreen
        f3C.ShowDialog()
        cbMes.Focus()
    End Sub

    Private Sub ActualizacionDatosMonitor(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCodigo(True)
        filaTemp = tbCodigo.Rows.Item(e.va2)
        textCodigo.Text() = filaTemp.Item("transac")
        textNombCodigo.Text = filaTemp.Item("nombre")

        formacal = filaTemp.Item(3)
        _tipovalor = filaTemp.Item(4)
        IngresarTransaccion()
    End Sub

    Private Sub IngresarTransaccion()
        If _tipovalor = "C" Then
            LbTipo.Text = "Cantidad"
        ElseIf _tipovalor = "V" Then
            LbTipo.Text = "Valor"
        End If
    End Sub




#End Region


    Private Sub Vista(ByVal dgVista As DataGridView, ByVal listaP As List(Of Pagosnom))
        Dim pago As Pagosnom
        With dgVista
            Dim mes As Short
            .Columns("transac").HeaderText = "TRANSACCION"
            .Columns("transac").FillWeight = 10
            .Columns("transac").Frozen = True
            .Columns("nombre").HeaderText = "NOMBRE"
            .Columns("nombre").FillWeight = 35
            .Columns("nombre").Frozen = True
            .Columns("tipovalor").Visible = False
            .Columns("tipomov").Visible = False
            For i As Integer = 1 To 12
                mes = i
                pago = listaP.Where(Function(x) x.mes = mes AndAlso x.estado <> 1).FirstOrDefault()
                .Columns(mes.ToString()).HeaderText = meses.Where(Function(x) x.mes = mes).FirstOrDefault().nombre.Substring(0, 3)
                .Columns(mes.ToString()).FillWeight = 20
                .Columns(mes.ToString()).DefaultCellStyle.Format = "N2"
                .Columns(mes.ToString() + "C").HeaderText = meses.Where(Function(x) x.mes = mes).FirstOrDefault().nombre.Substring(0, 3) + " C"
                .Columns(mes.ToString() + "C").FillWeight = 20
                .Columns(mes.ToString() + "C").DefaultCellStyle.Format = "N2"
                If (pago IsNot Nothing) Then
                    .Columns(mes.ToString()).ReadOnly = True
                    .Columns(mes.ToString() + "C").ReadOnly = True
                    .Columns(mes.ToString()).DefaultCellStyle.BackColor = Color.Red
                    .Columns(mes.ToString() + "C").DefaultCellStyle.BackColor = Color.Red

                    .Columns(mes.ToString()).DefaultCellStyle.ForeColor = Color.White
                    .Columns(mes.ToString() + "C").DefaultCellStyle.ForeColor = Color.White
                End If
            Next



        End With
        Dim mesM As Mes
        Dim nomMes As String
        For Each filagrid As DataGridViewRow In dgDatos.Rows
            If filagrid.Cells("tipovalor").Value = "V" Then
                nomMes = "C"
            Else
                nomMes = ""
            End If
            For Each mesM In meses
                filagrid.Cells($"{mesM.mes}{nomMes}").ReadOnly = True
            Next
        Next
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lPagos.Clear()
        borra_Mejorado(gpDatos, ep1)
        BorraEmpleado(True)
        TextConxContrato.Clear()
        gpContrato.Enabled = True
        gpEmpleado.Enabled = True
        gpDatos.Enabled = True
        gpDetalle.Enabled = False
        dgDatos.DataSource = Nothing
        btnGuardar.Enabled = False
        btnCancelar_Click(sender, e)
        ContextoMenuEnab(True, False, ctxMenu)
        TextAño.Text = Today.Year
        textEmpleado.Focus()
    End Sub


    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim año As Short = 0
        If validetError(textEmpleado, ep1) = False Or validetError(TextConxContrato, ep1) = False Or
        validetError(cmbTipo, ep1) = False Or
        Not Short.TryParse(TextAño.Text, año) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        Dim mes As Int32 = 0
        para.Clear()
        para("empresa") = empresa
        para("tiponom") = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
        para("año") = TextAño.Text
        para("empleado") = CInt(textEmpleado.Text)
        para("contrato") = CInt(TextConxContrato.Text)


        lPagos = pnCtr.GetPagosNom(empresa, para("tiponom"), CInt(textEmpleado.Text), CInt(TextConxContrato.Text), año)
        cadena = "Select * from dbo.MovimientosNomina2(@empresa,@año,@empleado,@contrato,@tiponom)"
        llenaTabla(cadena, tbDatos, ListaParametros(para))
        dgDatos.DataSource = tbDatos
        Vista(dgDatos, lPagos)
        Dim lmes As List(Of Mes) = mesCtr.GetMeses()
        lmes = lmes.Where(Function(x) Not lPagos.Select(Function(y) y.mes).Contains(x.mes)).ToList()
        cbMes.DataSource = lmes

        'cadena = "select nombre, mes from meses where mes>=" & cmbMes.SelectedIndex + 1 & " order by mes"
        'llena_combo(cadena, cmbMesF)
        'llenaTabla(cadena, tbMeses)
        'ContextoMenuEnab(True, True, ctxMenu)
        'cmbMesF.Items.Add("")
        gpDatos.Enabled = False
        gpEmpleado.Enabled = False
        gpContrato.Enabled = False
        gpDetalle.Enabled = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub btnIngSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Dim transac As Int16
        Dim valor As Decimal = 0
        If validetError(textCodigo, ep1) And validetError(TextValor, ep1) And Int16.TryParse(textCodigo.Text, transac) Then

            If Not Decimal.TryParse(TextValor.Text, valor) OrElse valor < 0 Then
                MsgBox("Debe ingresar un valor que no sea negativo.", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If

            If opc = 0 Then
                _fMod = tbDatos.AsEnumerable().Where(Function(x) x.Field(Of Int16)("transac") = transac).FirstOrDefault()
                If _fMod IsNot Nothing Then
                    opc = 1
                End If
            End If


            Dim mes As Int32 = 0
            If opc = 0 Then
                filaTemp = tbDatos.NewRow
                MueveScrollView(dgDatos, tbDatos.Rows.Count - 1)
            Else
                filaTemp = _fMod
            End If
            filaTemp.Item("transac") = textCodigo.Text
            ValidaCodigo()
            filaTemp.Item("nombre") = textNombCodigo.Text
            filaTemp.Item("tipomov") = ""
            filaTemp.Item("tipovalor") = _tipovalor

            Dim mesM As Mes
            If opc = 0 Then
                For Each mesM In meses
                    filaTemp.Item(mesM.mes.ToString()) = "0.00"
                    filaTemp.Item(mesM.mes.ToString() + "C") = "0"
                Next
            End If



            For Each ele As Object In cbMes.CheckedItems
                mesM = CType(ele, Mes)
                If _tipovalor = "V" Then
                    filaTemp.Item(mesM.mes.ToString()) = valor
                    filaTemp.Item(mesM.mes.ToString() + "C") = 1
                ElseIf _tipovalor = "C" Then
                    filaTemp.Item(mesM.mes.ToString() + "C") = valor
                    filaTemp.Item(mesM.mes.ToString()) = 0
                End If
            Next
            If opc = 0 Then
                tbDatos.Rows.Add(filaTemp)
                MueveScrollView(dgDatos, tbDatos.Rows.Count - 1)
            End If


            btnCancelar_Click(sender, e)
        Else
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        opc = 0
        BorraCodigo(True)
        cbMes.Text = ""
        TextValor.Clear()
        ContextoMenuEnab(True, True, ctxMenu)
        textCodigo.Focus()
    End Sub

    Private Sub ctxModi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click

        If dgDatos.SelectedRows.Count > 0 Then
            opc = 1
            IndiceTransac = dgDatos.SelectedRows(0).Index
            ContextoMenuEnab(False, True, ctxMenu)
            _fMod = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            textCodigo.Text = _fMod.Item("transac")
            textNombCodigo.Text = _fMod.Item("nombre")
            _tipovalor = _fMod.Item("tipovalor")
            If _tipovalor = "C" Then
                TextValor.Text = _fMod.Item("1C")
            ElseIf _tipovalor = "V" Then
                TextValor.Text = _fMod.Item("1")
            End If

        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxEli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        'procedimiento encargado de eliminar un recorrido de la base de datos
        Try
            If dgDatos.SelectedRows.Count > 0 Then
                filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
                If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                    tbDatos.Rows.Remove(filaTemp)
                End If
            Else
                MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("SELECCIONE UN REGISTRO PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End Try

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim i As Integer
        Dim modelo As New cmodelo
        Dim indice As Int16 = cmbTipo.SelectedIndex
        Dim tiponom As String = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
        Dim anio As String = TextAño.Text
        lPara.Clear()
        Try
            If MsgBox("DESEA GUARDAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                Dim mesesDisp = meses.Where(Function(x) Not lPagos.Select(Function(y) y.mes).ToList().Contains(x.mes)).ToList()
                Dim valor As Decimal = 0
                Dim mesM As Mes
                For Each mesM In mesesDisp
                    lPara("contrato") = CInt(TextConxContrato.Text)
                    lPara("mes") = mesM.mes
                    lPara("tiponom") = tiponom
                    lPara("año") = CInt(TextAño.Text)
                    lPara("empleado") = CInt(textEmpleado.Text)
                    lPara("empresa") = empresa
                    cadena = "delete from movinomina where empresa=@empresa and empleado=@empleado" &
                        " and contrato=@contrato and tiponom=@tiponom and  mes =@mes and año=@año"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))
                    For i = 0 To tbDatos.Rows.Count - 1
                        filaTemp = tbDatos.Rows(i)
                        If CDec(filaTemp(mesM.mes.ToString())) > 0 Or CDec(filaTemp(mesM.mes.ToString() + "C")) > 0 Then
                            If filaTemp("tipovalor") = "V" Then
                                valor = CDec(filaTemp(mesM.mes.ToString()))
                            ElseIf filaTemp("tipovalor") = "C" Then
                                valor = CDec(filaTemp(mesM.mes.ToString() + "C"))
                            End If
                        Else
                            valor = 0
                        End If
                        lPara("transac") = filaTemp.Item("transac")
                        lPara("valor") = CDec(filaTemp(mesM.mes.ToString()))
                        lPara("cantidad") = filaTemp.Item(mesM.mes.ToString() + "C")
                        lPara("usuario") = user
                        lPara("fechae") = Today
                        If valor > 0 Then

                            cadena = "insert into movinomina (empresa,empleado,contrato,tiponom,mes,año,transac,cantidad," &
                           "valor,usuario,fechae) values 
                           (@empresa,@empleado,@contrato,@tiponom,@mes,@año,@transac,@cantidad,@valor,@usuario,@fechae)"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))
                        End If

                    Next i

                Next

                If modelo.Commit() Then
                    InsertBitacora(9, 1, $"Ingreso o modificación movimientos variable empleado {textEmpleado.Text} contrato {TextConxContrato.Text} año {TextAño.Text} tipo nomina {cmbTipo.Text}")
                    btnLimpiar_Click(sender, e)
                    cmbTipo.SelectedIndex = indice
                    TextAño.Text = anio
                    MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR EN EL INGRESO DE DATOS", MsgBoxStyle.Critical, "Mensaje del Sistema")
            modelo.RollBack()
        End Try
    End Sub

    Private Sub frmRutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub



    Private Sub TextValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextValor.KeyPress
        soloNumeroDec(sender, e)
    End Sub


#Region "Botones de meses"
    Private Sub btnMarcar_Click(sender As Object, e As EventArgs) Handles btnMarcar.Click
        Dim i As Int16 = 0
        For i = 0 To cbMes.Items.Count - 1
            cbMes.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub btnDesmarcar_Click(sender As Object, e As EventArgs) Handles btnDesmarcar.Click
        Dim i As Int16 = 0
        For i = 0 To cbMes.Items.Count - 1
            cbMes.SetItemChecked(i, False)
        Next
    End Sub
#End Region


    Private Sub TextValor_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValor.Validated
        validatedDecimalPreci(sender, 8, 2)
    End Sub

    Private Sub TextValor_Entra(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValor.Enter
        EntraDecimal(sender)
    End Sub




    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub dgDatos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgDatos.DataError
        MsgBox("Error de formato")
        e.Cancel = False
    End Sub
End Class