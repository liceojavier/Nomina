Imports System.Data.SqlClient
Imports System.IO
Public Class frmIngContratos

    Dim comando As SqlCommand
    Dim dr As SqlDataReader

    Dim cadena As String
    Dim tbSeguro As New DataTable("seguro")
    Dim tbPuesto As New DataTable("puesto")
    Dim tbFormaPago As New DataTable("pago")
    Dim tbTipoPer As New DataTable("tipoper")
    Dim tbOrigen As New DataTable("origen")
    Dim tbDatos As New DataTable("datos")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbCodigo As New DataTable("codigo")
    Dim tbDetSueldos As New DataTable("sueldos")
    Dim tbEventos As New DataTable("eventos")
    Dim tbMotivoEvento As New DataTable("motivoevento")
    Dim tbTipoAccion As New DataTable("tipoaccion")
    Dim tbTipoEmpleado As New DataTable("tipoempleado")
    Dim ImagenBytes() As Byte
    Dim tbTipoEvento As New DataTable("TipoEvento")

    Dim WithEvents fOrig As frmMuestraUnidadesOp
    Dim WithEvents fEmp As frmMuestraCodigos

    Dim filaTemp As DataRow
    Dim opcModiAca, opcModiFa, IndiceAca, IndiceFam, opcSueldos, IndiceSueldo, opcEvento, IndiceEvento As Int16
    Dim usaReg As String
    Dim HoraFinal, minutoFinal As Int32
    Dim cadenaSueldos As String = "select s.transac, t.nombre , s.afecta,  s.valor " &
                                     " from sueldos s inner join tipotran t on s.transac=t.transac and s.empresa=t.empresa where s.empresa=" & empresa


    Dim base As Int32
    Dim lpara As New Dictionary(Of String, Object)
    Dim ctrContrato As New ContratoController()



    Private Sub frmDatosFamilia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextNombEmpresa.Text = BuscaEscalar("select nombre from Empresas where empresa=" & empresa)
        tbDatos.Clear()
        AgregarColumna(tbDatos, "origen", "System.String", "")
        AgregarColumna(tbDatos, "nombre", "System.String", "")
        AgregarColumna(tbDatos, "porcentaje", "System.Decimal", 0)
        dgDatos.DataSource = tbDatos
        Vista1(dgDatos)
        AddHandler tbDatos.ColumnChanged, AddressOf cambio_valor
        AddHandler tbDatos.ColumnChanging, AddressOf cambiando_valor
        cadena = cadenaSueldos & " and empleado=0"
        llenaTabla(cadena, tbDetSueldos)
        dgSueldos.DataSource = tbDetSueldos
        Vista2(dgSueldos)
        cadena = "SELECT NOMBRE, tiposeguro, por FROM SEGUROSOCIAL where empresa=" & empresa & " order by tiposeguro"
        llena_combo(cadena, cmbTipoSeguro)
        cmbTipoSeguro.Items.Add("")
        llenaTabla(cadena, tbSeguro)
        cadena = "select nombre,puesto from puestosper where empresa=" & empresa & " order by puesto"
        llena_combo(cadena, cmbPuesto)
        cmbPuesto.Items.Add("")
        llenaTabla(cadena, tbPuesto)
        cadena = "select nombre,fpago,tipoforma from formapagoper where empresa=" & empresa & " order by fpago"
        llena_combo(cadena, cmbFormaPago)
        cmbFormaPago.Items.Add("")
        llenaTabla(cadena, tbFormaPago)
        cadena = "select t.nombre, t.tipoper, t.tibase, case when t.tibase='H' then 'HORAS' when t.tibase='D' then 'DIAS' end as nombBase," &
                 " b.base, horasdia  from tipopersonal t inner join tiposbase b on t.empresa=b.empresa and t.id_tbase=b.id_tbase where " &
                 "t.empresa=" & empresa & " order by t.tipoper"
        llena_combo(cadena, cmbTipoPer)
        cmbTipoPer.Items.Add("")
        llenaTablaBatch(cadena, tbTipoPer)

        cadena = "select a.fecha, a.tipoevento,d.nombre as nombEvento,a.motivo, b.nombre as nombMotivo , a.tipoaccion, " &
                 "c.nombre as nombAccion, observa from eventosper a " &
                 "left join motivoeventos b on a.motivo=b.motivo " &
                 "left join tipoacciones c on  a.tipoaccion=c.tipoaccion " &
                 "left join tiposeventos d on a.tipoevento=d.tipoevento " &
                 "where  a.empresa=0 and a.empleado=0 and a.contrato=0 order  by a.id_eventosper"

        llenaTabla(cadena, tbEventos)
        cadena = "select nombre,motivo from motivoeventos order by motivo"
        llena_combo(cadena, cmbMotivoEvento)
        llenaTabla(cadena, tbMotivoEvento)
        cmbMotivoEvento.Items.Add("")
        cadena = "select nombre,tipoaccion from tipoacciones order by tipoaccion"
        llena_combo(cadena, cmbTipoAccion)
        llenaTabla(cadena, tbTipoAccion)
        dgEventos.DataSource = tbEventos
        cmbTipoAccion.Items.Add("")
        cadena = "select nombre,tipoevento from tiposeventos"
        llena_combo(cadena, cmbTipoEvento)
        llenaTabla(cadena, tbTipoEvento)

        cadena = "select * from tiposempleado t where " &
                 "t.empresa=" & empresa & " order by tipoempleado"
        llenaTablaBatch(cadena, tbTipoEmpleado)
        cmbTipoEmpleado.DataSource = tbTipoEmpleado
        cmbTipoEmpleado.DisplayMember = "nombre"
        cmbTipoEmpleado.ValueMember = "tipoempleado"

        ctrContrato.FillComboJornada(cmbJornada)
        ctrContrato.FillComboTipoContrato(cmbTipoContrato)
        ctrContrato.FillComboTemporalidad(cmbTemporalidad)

        Vista3(dgEventos)
        btnLimpiar_Click(sender, e)
    End Sub


#Region "ORIGEN"
    Private Sub BorraOrigen(ByVal valorBool As Boolean)
        TextNombOrigen.Clear()
        If valorBool = True Then
            TextOrigen.Clear()
        End If
    End Sub

    Private Sub TextCentro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextOrigen.KeyDown, TextNombOrigen.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrigen.Click
        lpara.Clear()
        Dim numFilas As Int32
        lpara("empresa") = empresa
        If TextNombOrigen.Text.Trim <> "" Then
            lpara("nombre") = TextNombOrigen.Text.Trim
            cadena = "select origen, nombre from origenes where empresa=@empresa and nombre like '%' + @nombre + '%' and operable='S' order by origen"
        Else
            cadena = "select origen,nombre from origenes where empresa=@empresa and operable='S' order by origen"
        End If
        numFilas = llenaTabla(cadena, tbOrigen, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN CENTROS DE COSTO CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraOrigen(True)
            TextOrigen.Focus()
        ElseIf numFilas = 1 Then
            filaTemp = tbOrigen.Rows.Item(0)
            TextOrigen.Text() = filaTemp.Item(0)
            TextNombOrigen.Text = filaTemp.Item(1)
            TextPorce.Focus()
        Else
            'borra_Mejorado(gpCentro)
            EnBuscaOrigen()
        End If
    End Sub

    Private Sub ValidaOrigen()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("origen") = TextOrigen.Text.Trim
        If BuscaEscalar("select count (*) from origenes where origen=@origen", ListaParametros(lpara)) = 0 Then
            MsgBox("CENTRO DE COSTO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraOrigen(True)
            Exit Sub
        End If
        cadena = "select origen,nombre from origenes where empresa=@empresa and origen=@origen and operable='S'"
        abrir_conexion(cn)
        comando = New SqlCommand(cadena, cn)
        comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
        dr = comando.ExecuteReader
        If dr.HasRows() Then
            BorraOrigen(False)
            dr.Read()
            TextNombOrigen.Text = dr.GetValue(1)
            dr.Close()
            TextPorce.Focus()
        Else
            MsgBox("CENTRO DE COSTO NO ES OPERABLE A ESTE NIVEL, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            dr.Close()
            BorraOrigen(True)
            TextOrigen.Focus()
        End If
        cn.Close()
    End Sub

    Private Sub TextOrigen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextOrigen.Validated
        If TextOrigen.Text.Trim <> "" Then
            ValidaOrigen()
        Else
            BorraOrigen(False)
        End If
    End Sub

    Private Sub EnBuscaOrigen()
        fOrig = New frmMuestraUnidadesOp
        fOrig.TopMost = True
        fOrig.inicializa(tbOrigen)
        AddHandler fOrig.actValor, AddressOf ActualizacionDatosOrigen
        fOrig.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosOrigen(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraOrigen(True)
        filaTemp = tbOrigen.Rows.Item(e.va2)
        TextOrigen.Text() = filaTemp.Item(0)
        TextNombOrigen.Text = filaTemp.Item(1)
        TextNombOrigen.Focus()
        TextPorce.Focus()
    End Sub

#End Region


#Region "EMLEADO"


    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        TextContrato.Clear()
        If valbool = True Then
            textEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        lpara.Clear()
        Dim numFilas As Int32
        lpara("empresa") = empresa
        If textNombreEmple.Text.Trim <> "" Then
            lpara("nombre") = textNombreEmple.Text.Trim
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and nombre like '%' + @nombre + '%'  order by nombre"
        Else
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa  order by nombre"
        End If
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
            VerificaEmpleado()
            cmbTipoSeguro.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        lpara.Clear()
        If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
            lpara("empresa") = empresa
            lpara("empleado") = textEmpleado.Text.Trim
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Focus()
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
                VerificaEmpleado()
                cmbTipoSeguro.Focus()
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
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosEmpleados
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        cmbTipoSeguro.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
        VerificaEmpleado()
    End Sub

    Private Sub VerificaEmpleado()
        TextContrato.Text = BuscaEscalar("select coalesce(max(contrato), 0) from contratos1 where empresa=" & empresa &
        " and empleado=" & textEmpleado.Text) + 1
    End Sub




#End Region


#Region "LIMPIAR Y  FORMATOS"

    Private Sub Vista1(ByVal dgVista As DataGridView)
        With dgVista
            .Columns("origen").HeaderText = "Origen"
            .Columns("origen").FillWeight = 15
            .Columns("origen").ReadOnly = True
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").FillWeight = 70
            .Columns("nombre").ReadOnly = True
            .Columns("porcentaje").HeaderText = "Porcentaje"
            .Columns("porcentaje").FillWeight = 15
            .Columns("porcentaje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With
    End Sub


    Private Sub Vista2(ByVal dgVista As DataGridView)
        With dgVista
            .Columns("transac").HeaderText = "Transacción"
            .Columns("transac").FillWeight = 8
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").FillWeight = 70
            .Columns("afecta").HeaderText = "Afecto"
            .Columns("afecta").FillWeight = 8
            .Columns("valor").HeaderText = "Valor"
            .Columns("valor").FillWeight = 14
            .Columns("valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("valor").DefaultCellStyle.Format = "N2"


        End With
    End Sub
    Private Sub Vista3(ByVal dgVista As DataGridView)
        With dgVista
            .Columns("fecha").HeaderText = "Fecha"
            .Columns("fecha").FillWeight = 10
            .Columns("tipoevento").Visible = False
            .Columns("nombEvento").HeaderText = "Tipo"
            .Columns("nombEvento").FillWeight = 15
            .Columns("motivo").Visible = False
            .Columns("nombMotivo").HeaderText = "Motivo"
            .Columns("nombMotivo").FillWeight = 15
            .Columns("tipoAccion").Visible = False
            .Columns("nombAccion").HeaderText = "Acción"
            .Columns("nombAccion").FillWeight = 30
            .Columns("observa").HeaderText = "Observaciones"
            .Columns("observa").FillWeight = 30

        End With
    End Sub


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        TextContrato.Clear()
        HoraFinal = 0
        minutoFinal = 0
        cmbTipoEmpleado.SelectedIndex = -1
        btnCancelar_Click(sender, e)
        btnCancelSueldo_Click(sender, e)
        btnCancelEvento_Click(sender, e)
        borra_Mejorado(TbGeneral, ep1)
        btnGuardar.Enabled = False
        TextHora1.Text = "__:__"
        TextHora2.Text = "__:__"
        TextHorasTotal.Clear()
        TextTotal.Text = "0.00"
        TextTotalSueldo.Text = "0.00"
        Textsemanales.Text = 0
        tbDatos.Rows.Clear()
        tbDetSueldos.Rows.Clear()
        tbEventos.Rows.Clear()
        dgDatos.Refresh()
    End Sub


#End Region


#Region "INGRESO DEL CENTRO DE COSTO"

    Private Sub btnIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Dim i As Int16
        Dim fila As DataRow

        If TextOrigen.Text.Trim = "" Then
            MsgBox("NO HA INGRESADO EL CENTRO DE COSTO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            TextOrigen.Focus()
            Exit Sub
        ElseIf TextPorce.Text.Trim = "" Then
            MsgBox("NO HA INGRESADO EL PORCENTAJE DEL CENTRO DE COSTO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            TextPorce.Focus()
            Exit Sub
        End If
        If CDec(TextTotal.Text) > 100 Then
            MsgBox("EL TOTAL DEL PORCETANJE EXCEDE EL 100%", MsgBoxStyle.Information, "Mensaje del Sistema")
            TextPorce.Focus()
            Exit Sub
        End If
        If tbDatos.Rows.Count > 0 Then
            For i = 0 To tbDatos.Rows.Count - 1
                filaTemp = tbDatos.Rows.Item(i)
                If CStr(filaTemp.Item(0)).Trim = TextOrigen.Text.Trim Then
                    MsgBox("ESTE CENTRO DE COSTO YA HA SIDO INGRESADO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
            Next i
        End If
        If 0.0 < CDec(TextPorce.Text) And CDec(TextPorce.Text) <= 100.0 Then
            fila = tbDatos.NewRow()
            fila.Item("origen") = TextOrigen.Text.Trim
            fila.Item("nombre") = BuscaEscalar("select nombre from origenes where origen='" & TextOrigen.Text & "'")
            fila.Item("porcentaje") = CInt(TextPorce.Text)
            tbDatos.Rows.Add(fila)
            totales()
            'AltoGridView(18, tbDatos, 249, 618, dgDatos)
            MueveScrollView(dgDatos, tbDatos.Rows.Count - 1)
            btnCancelar_Click(sender, e)
        Else
            MsgBox("EL PORCENTAJE INGRESADO NO PUEDE SER 0 O MAYOR DE 100", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub


    Private Sub totales()
        Dim totalizador As Decimal
        Dim i As Int16
        totalizador = 0
        For i = 0 To tbDatos.Rows.Count - 1
            filaTemp = tbDatos.Rows.Item(i)
            totalizador = totalizador + filaTemp.Item(2)
        Next i
        TextTotal.Text = totalizador
        If totalizador = 100 Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
        End If
    End Sub


    Private Sub ctxEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminaCentro.Click
        If dgDatos.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
                tbDatos.Rows.Remove(filaTemp)
                totales()
                dgDatos.Refresh()
                'AltoGridView(18, tbDatos, 249, 618, dgDatos)
            End If
        Else
            MsgBox("NO HAY NINGUNA LINEA PARA ELIMINAR", MsgBoxStyle.Information, "Mensaje del Sistemas")
        End If
    End Sub

    Private Sub cambiando_valor(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        Dim tempDec As Decimal
        If (e.Column.ColumnName = "porcentaje") Then
            Try
                tempDec = e.ProposedValue
                If 0.0 < tempDec And tempDec <= 100.0 Then
                    e.ProposedValue = CDec(formato(tempDec))
                Else
                    e.ProposedValue = e.Row.Item(2)
                End If
            Catch ex As Exception
                MsgBox("LO INGRESADO NO ES UN NUMERO VALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
                e.ProposedValue = e.Row.Item(2)
            End Try
        End If
    End Sub

    Private Sub cambio_valor(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        If (e.Column.ColumnName = "porcentaje") Then
            totales()
        End If
    End Sub


    Private Sub dgDatos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDatos.DataError
        dgDatos.RefreshEdit()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        BorraOrigen(True)
        TextPorce.Clear()
        TextOrigen.Focus()
    End Sub



#End Region




    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim i, numCorrel As Int32
        Dim fecha, fechaIng As Date
        Dim horasF As Decimal
        Dim tipoSeguro, tipoOper, puesto, fpago, jornada As String
        Dim comandoSql As SqlCommand
        Dim transacSql As SqlTransaction

        numCorrel = 0

        tipoSeguro = ""
        tipoOper = ""
        puesto = ""
        fpago = ""
        jornada = ""

        If tbDetSueldos.Rows.Count = 0 Then
            MsgBox("NO HA INGRESADO EL SUELDO DEL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        ElseIf CDec(TextTotalSueldo.Text) > 99999999.99 Then
            MsgBox("VALOR DEL SUELDO SOBREPASA LIMITE DE LA BASE DE DATOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If

        fecha = dtpFecha.Value.Date
        fechaIng = dtpFechaInicio.Value.Date

        If TextHora1.Text = "  :" Or TextHora2.Text = "  :" Or TextHorasTotal.Text = "  :" Then
            MsgBox("DEBE INGRESAR TODAS LAS HORAS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If

        If Textsemanales.Text.Trim = "0" Or Textsemanales.Text.Trim = "" Then
            MsgBox("DEBE INGRESAR LAS HORAS SEMANALES", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If

        If validetError(TextContrato, ep1) And validetError(textEmpleado, ep1) And validetError(cmbTipoSeguro, ep1) And validetError(cmbTipoPer, ep1) And
            validetError(cmbPuesto, ep1) And validetError(cmbModPago, ep1) And validetError(cmbFormaPago, ep1) And
            validetComilla(TextObserva, ep1) And validetError(cmbJornada, ep1) And
            validetError(cmbAnticipo, ep1) And validetError(cmbTipoPer, ep1) And validetError(cmbTipoContrato, ep1) And validetError(cmbTemporalidad, ep1) Then

            If textCtaBanc.ReadOnly = False And textCtaBanc.Text.Trim = "" Then
                MsgBox("DEBE INGRESAR CUENTA BANCARIA", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If

            validaTextoSQL(TbGeneral)
            AsignaElemento(tbSeguro, tipoSeguro, cmbTipoSeguro, 1, True)
            AsignaElemento(tbTipoPer, tipoOper, cmbTipoPer, 1, True)
            AsignaElemento(tbPuesto, puesto, cmbPuesto, 1, True)
            AsignaElemento(tbFormaPago, fpago, cmbFormaPago, 1, False)
            horasF = HoraFinal + (minutoFinal / 60)
            cadena = "select count(*) from contratos1 where empresa=" & empresa & " and contrato=" & TextContrato.Text &
            " and empleado=" & textEmpleado.Text
            If BuscaEscalar(cadena) > 0 Then
                MsgBox("NUMERO DE CONTRATO YA SE ENCUENTRA REGISTRADO, INTENTELO NUEVAMENTE", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextContrato.Text = BuscaEscalar("select coalesce(max(contrato), 0) from contratos1 where empresa=" & empresa &
                " and empleado=" & textEmpleado.Text) + 1
                Exit Sub
            End If

            Dim tipoEmpleado As String = cmbTipoPer.SelectedText
            Dim tipEmpleado As Integer
            If (tipoEmpleado = "ACADEMICO") Then
                tipEmpleado = 1
            ElseIf (tipoEmpleado = "ADMINISTRATIVO") Then
                tipEmpleado = 2
            ElseIf (tipoEmpleado = "SOPORTE") Then
                tipEmpleado = 3
            ElseIf (tipoEmpleado = "HONORARIOS") Then
                tipEmpleado = 4
            ElseIf (tipoEmpleado = "GARITEROS") Then
                tipEmpleado = 5
            End If


            If MsgBox("ESTA SEGURO QUE DESEA INGRESAR ESTE CONTRATO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then

                Using cn1 As New SqlConnection(_conexion)
                    cn1.Open()
                    transacSql = cn1.BeginTransaction
                    Try

                        lpara.Clear()
                        lpara("@empresa") = empresa
                        lpara("@empleado") = CInt(textEmpleado.Text)
                        lpara("@contrato") = CInt(TextContrato.Text)
                        lpara("@fecha") = fecha
                        lpara("@tiposeguro") = tipoSeguro
                        lpara("@tipoper") = tipoOper
                        lpara("@puesto") = puesto
                        lpara("@mpago") = cmbModPago.Text.Substring(0, 1)
                        lpara("@anticipo") = cmbAnticipo.Text
                        lpara("@fpago") = fpago
                        lpara("@cuentaban") = textCtaBanc.Text
                        lpara("@fechai") = fechaIng
                        lpara("@fechaf") = ""
                        lpara("@base") = base
                        lpara("@jornada") = cmbJornada.SelectedValue
                        lpara("@horaini") = TextHora1.Text
                        lpara("@horafin") = TextHora2.Text
                        lpara("@horas") = horasF
                        lpara("@semanahoras") = Textsemanales.Text
                        lpara("@observa") = TextObserva.Text
                        lpara("@estado") = 0
                        lpara("@fechae") = Today.ToShortDateString()
                        lpara("@tipoempleado") = cmbTipoEmpleado.SelectedValue

                        lpara("@id_tipo_contrato") = cmbTipoContrato.SelectedValue
                        lpara("@id_temporalidad") = cmbTemporalidad.SelectedValue


                        cadena = "insert into contratos1(empresa, empleado, contrato, fecha, tipoSeguro, tipoper, puesto, mpago, anticipo, fpago, cuentaban, fechai, " &
                                 "fechaf, base, jornada, horaini, horafin, horas, semanahoras, observa, estado, fechae, tipoempleado, id_tipo_contrato, id_temporalidad) values " &
                                  "(@empresa,@empleado,@contrato,@fecha,@tiposeguro,@tipoper,@puesto,@mpago,@anticipo,@fpago,@cuentaban,@fechai," &
                                 "@fechaf,@base,@jornada,@horaini,@horafin,@horas,@semanahoras,@observa,@estado,@fechae,@tipoempleado,@id_tipo_contrato, @id_temporalidad)"
                        comandoSql = New SqlCommand(cadena, cn1, transacSql)
                        comandoSql.Parameters.AddRange(ListaParametros(lpara).ToArray())
                        comandoSql.ExecuteNonQuery()
                        lpara.Clear()
                        lpara("@empresa") = empresa
                        lpara("@empleado") = CInt(textEmpleado.Text)
                        lpara("@contrato") = CInt(TextContrato.Text)
                        For i = 0 To tbDatos.Rows.Count - 1
                            filaTemp = tbDatos.Rows(i)

                            lpara("@origen") = filaTemp.Item("origen")
                            lpara("@por") = filaTemp.Item("porcentaje")
                            cadena = "insert into contratos2 (empresa, empleado, contrato, origen, por) values (@empresa,@empleado,@contrato,@origen,@por)"
                            comandoSql = New SqlCommand(cadena, cn1, transacSql)
                            comandoSql.Parameters.AddRange(ListaParametros(lpara).ToArray())
                            comandoSql.ExecuteNonQuery()
                        Next i

                        For i = 0 To tbDetSueldos.Rows.Count - 1
                            filaTemp = tbDetSueldos.Rows(i)
                            lpara("@transac") = filaTemp.Item("transac")
                            lpara("@valor") = filaTemp.Item("valor")
                            lpara("@afecta") = filaTemp.Item("afecta")
                            lpara("@fechae") = fecha
                            lpara("@concepto") = "VALORES INICIALES"
                            lpara("@usuario") = user
                            lpara("@tipo") = "I"
                            lpara("@fecha") = fecha
                            cadena = " insert into sueldos (empresa,empleado,contrato,transac,afecta, valor, fechae) values 
                                      (@empresa,@empleado,@contrato,@transac,@afecta, @valor, @fechae)"
                            comandoSql = New SqlCommand(cadena, cn1, transacSql)
                            comandoSql.Parameters.AddRange(ListaParametros(lpara).ToArray())
                            comandoSql.ExecuteNonQuery()
                            cadena = "insert into movifijos (empresa,fecha,empleado,contrato,tipo,transac,afecta, valor,concepto,usuario) values
                                    (@empresa,@fecha,@empleado,@contrato,@tipo,@transac,@afecta, @valor,@concepto,@usuario) "
                            comandoSql = New SqlCommand(cadena, cn1, transacSql)
                            comandoSql.Parameters.AddRange(ListaParametros(lpara).ToArray())
                            comandoSql.ExecuteNonQuery()
                        Next i
                        For i = 0 To tbEventos.Rows.Count - 1
                            lpara.Clear()
                            filaTemp = tbEventos.Rows(i)

                            lpara("@empresa") = empresa
                            lpara("@empleado") = CInt(textEmpleado.Text)
                            lpara("@contrato") = CInt(TextContrato.Text)
                            lpara("@fecha") = filaTemp.Item("fecha")
                            lpara("@tipoevento") = filaTemp.Item("tipoevento")
                            lpara("@motivo") = filaTemp.Item("motivo")
                            lpara("@tipoaccion") = filaTemp.Item("tipoaccion")
                            lpara("@observa") = filaTemp.Item("observa")
                            cadena = " insert into eventosper (empresa, empleado, contrato, fecha, tipoevento, motivo, tipoaccion, observa)
                            values (@empresa,@empleado,@contrato,@fecha,@tipoevento,@motivo,@tipoaccion,@observa) "
                            comandoSql = New SqlCommand(cadena, cn1, transacSql)
                            comandoSql.Parameters.AddRange(ListaParametros(lpara).ToArray())
                            comandoSql.ExecuteNonQuery()
                        Next i
                        transacSql.Commit()
                        InsertBitacora(9, 1, $"Creacion contrato empresa {empresa} empleado {textEmpleado.Text} contrato {TextContrato.Text}")
                        MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                        btnLimpiar_Click(sender, e)
                    Catch ex As Exception
                        transacSql.Rollback()
                        MsgBox("Error en la grabación".ToUpper & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Finally
                        cn1.Close()
                    End Try
                End Using
            End If


        Else
            MsgBox("LLENE LOS CAMPOS MARCADOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub





#Region "SUELDOS"


#Region "TRANSACCION"


    Private Sub BorraCodigo(ByVal valbool As Boolean)
        textNombCodigo.Clear()
        If valbool = True Then
            textCodigo.Clear()
        End If
    End Sub


    Private Sub btnCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaCodigo.Click
        lpara.Clear()
        Dim numFilas As Int32
        lpara("empresa") = empresa
        lpara("nombre") = textNombCodigo.Text.Trim
        cadena = "select transac, nombre from tipotran where empresa=@empresa and nombre like '%' + @nombre + '%' and tipomov='I' and formacal='FM'  order by transac"
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
            cmbAfecta.Focus()
        Else
            EnBuscaCodigo()
        End If
    End Sub

    Private Sub ValidaCodigo()
        lpara.Clear()
        If valida_tipo_Entero(textCodigo.Text, 1) = True Then
            lpara("empresa") = empresa
            lpara("transac") = textCodigo.Text.Trim
            If BuscaEscalar("select count (*) from tipotran where empresa=@empresa and transac=@transac", ListaParametros(lpara)) = 0 Then
                MsgBox("TRANSACCION NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraCodigo(True)
                textCodigo.Focus()
                Exit Sub
            End If
            cadena = "select transac, nombre from tipotran where empresa=@empresa and transac=@transac and tipomov='I' and formacal='FM'"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraCodigo(False)
                dr.Read()
                textNombCodigo.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                cmbAfecta.Focus()
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
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbCodigo)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosMonitor
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        cmbAfecta.Focus()
    End Sub

    Private Sub ActualizacionDatosMonitor(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCodigo(True)
        filaTemp = tbCodigo.Rows.Item(e.va2)
        textCodigo.Text() = filaTemp.Item(0)
        textNombCodigo.Text = filaTemp.Item(1)
    End Sub

#End Region

    Private Sub btnCancelSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelSueldo.Click
        opcSueldos = 0
        btnIngSueldo.Text = "Ingresar"
        BorraCodigo(True)
        cmbAfecta.Text = ""
        TextValor.Text = ""
        ContextoMenuEnab(True, True, ctxMenuSueldos)
        textCodigo.Focus()
    End Sub


    Private Sub btnIngSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngSueldo.Click
        Dim i As Int32
        If validetError(textCodigo, ep1) And validetError(cmbAfecta, ep1) And validetError(TextValor, ep1) Then
            If CDec(TextValor.Text) = 0 Then
                MsgBox("DEBE INGRESAR UN VALOR MAYOR A 0", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If
            For i = 0 To tbDetSueldos.Rows.Count - 1
                filaTemp = tbDetSueldos.Rows(i)
                Select Case opcSueldos
                    Case 0
                        If CInt(textCodigo.Text) = filaTemp.Item(0) Then
                            MsgBox("CODIGO DE TRANSACCION YA INGRESADA", MsgBoxStyle.Information, "Mensaje del Sistema")
                            Exit Sub
                        End If
                    Case 1
                        If CInt(textCodigo.Text) = filaTemp.Item(0) And IndiceSueldo <> i Then
                            MsgBox("CODIGO DE TRANSACCION YA INGRESADA", MsgBoxStyle.Information, "Mensaje del Sistema")
                            Exit Sub
                        End If
                End Select
            Next
            If opcSueldos = 0 Then
                filaTemp = tbDetSueldos.NewRow
                filaTemp.Item(0) = textCodigo.Text
                ValidaCodigo()
                filaTemp.Item(1) = textNombCodigo.Text
                filaTemp.Item(2) = cmbAfecta.Text
                filaTemp.Item(3) = formato(CDec(TextValor.Text))
                tbDetSueldos.Rows.Add(filaTemp)
            Else
                filaTemp = tbDetSueldos.Rows(IndiceSueldo)
                filaTemp.BeginEdit()
                filaTemp.Item(0) = textCodigo.Text
                ValidaCodigo()
                filaTemp.Item(1) = textNombCodigo.Text
                filaTemp.Item(2) = cmbAfecta.Text
                filaTemp.Item(3) = formato(CDec(TextValor.Text))
                filaTemp.EndEdit()
            End If
            TextTotalSueldo.Text = formato(TotalTabla(tbDetSueldos, 3))
            'AltoGridView(18, tbDetSueldos, 200, 848, dgSueldos)
            MueveScrollView(dgSueldos, tbDetSueldos.Rows.Count - 1)
            btnCancelSueldo_Click(sender, e)
        Else
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub


    Private Sub ctxModiSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModiSueldo.Click
        Dim f As DataRow
        If dgSueldos.SelectedRows.Count > 0 Then
            opcSueldos = 1
            IndiceSueldo = dgSueldos.SelectedRows(0).Index
            ContextoMenuEnab(False, True, ctxMenuSueldos)
            btnIngSueldo.Text = "Modificar"
            f = CType(dgSueldos.SelectedRows(0).DataBoundItem, DataRowView).Row
            textCodigo.Text = f.Item(0)
            textNombCodigo.Text = f.Item(1)
            cmbAfecta.Text = f.Item(2).ToString.Trim
            TextValor.Text = f.Item(3)
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxEliSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliSueldo.Click
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgSueldos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgSueldos.SelectedRows(0).DataBoundItem, DataRowView).Row
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                tbDetSueldos.Rows.Remove(filaTemp)
                TextTotalSueldo.Text = formato(TotalTabla(tbDetSueldos, 3))
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub


#Region "Numero Decimal"
    Private Sub TextValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextValor.KeyPress
        soloNumeroDec(sender, e)
    End Sub

    Private Sub TextValor_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValor.Validated
        validatedDecimalPreci(sender, 8, 2)
    End Sub

    Private Sub TextValor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValor.Enter
        EntraDecimal(sender)
    End Sub

#End Region


#End Region


#Region "EVENTOS"
    Private Sub btnIngEvento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngEvento.Click
        Dim motivoEvento, tipoaccion As Integer
        motivoEvento = 0
        tipoaccion = 0
        Dim i As Integer = 0
        If validetError(cmbTipoEvento, ep1) And validetError(cmbMotivoEvento, ep1) _
           And validetError(cmbTipoAccion, ep1) Then
            If Not validetComilla(TextObservaEvento, ep1) Then
                Exit Sub
            End If

            If cmbMotivoEvento.Text.Trim <> "" Then
                motivoEvento = tbMotivoEvento.Rows(cmbMotivoEvento.SelectedIndex).Item("Motivo")
            End If
            If cmbTipoAccion.Text.Trim <> "" Then
                tipoaccion = tbTipoAccion.Rows(cmbTipoAccion.SelectedIndex).Item("tipoaccion")
            End If



            If opcEvento = 0 Then
                filaTemp = tbEventos.NewRow
                filaTemp.Item("fecha") = dtpFechaEvento.Value.Date
                filaTemp.Item("nombEvento") = cmbTipoEvento.Text
                filaTemp.Item("nombMotivo") = cmbMotivoEvento.Text.Trim
                filaTemp.Item("nombAccion") = cmbTipoAccion.Text.Trim
                filaTemp.Item("observa") = TextObservaEvento.Text
                filaTemp.Item("tipoevento") = cmbTipoEvento.SelectedIndex
                filaTemp.Item("motivo") = motivoEvento
                filaTemp.Item("tipoaccion") = tipoaccion
                tbEventos.Rows.Add(filaTemp)
            Else
                filaTemp = tbEventos.Rows(IndiceEvento)
                filaTemp.BeginEdit()
                filaTemp.Item("fecha") = dtpFechaEvento.Value.Date
                filaTemp.Item("nombEvento") = cmbTipoEvento.Text
                filaTemp.Item("nombMotivo") = cmbMotivoEvento.Text
                filaTemp.Item("nombAccion") = cmbTipoAccion.Text
                filaTemp.Item("observa") = TextObservaEvento.Text
                filaTemp.Item("tipoevento") = cmbTipoEvento.SelectedIndex
                filaTemp.Item("motivo") = motivoEvento
                filaTemp.Item("tipoaccion") = tipoaccion
                filaTemp.EndEdit()
            End If
            dgEventos.Refresh()
            MueveScrollView(dgEventos, tbEventos.Rows.Count - 1)
            dgEventos.Refresh()
            btnCancelEvento_Click(sender, e)
        Else
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub


    Private Sub btnCancelEvento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelEvento.Click
        opcEvento = 0
        cmbTipoEvento.SelectedIndex = -1
        cmbMotivoEvento.SelectedIndex = -1
        cmbTipoAccion.SelectedIndex = -1
        TextObservaEvento.Text = ""
        dtpFechaEvento.Value = Today
        ContextoMenuEnab(True, True, ctxMenuEvento)
        btnIngEvento.Text = "Ingresar"
    End Sub

    Private Sub ctxModiEvento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModiEvento.Click
        Dim f As DataRow
        If dgEventos.SelectedRows.Count > 0 Then
            opcEvento = 1
            IndiceEvento = dgEventos.SelectedRows(0).Index
            ContextoMenuEnab(False, True, ctxMenuEvento)
            btnIngEvento.Text = "Modificar"
            f = CType(dgEventos.SelectedRows(0).DataBoundItem, DataRowView).Row
            dtpFechaEvento.Value = f.Item("fecha")
            cmbTipoEvento.SelectedIndex = f.Item("tipoevento")
            BuscaElementoCombo(tbMotivoEvento, f.Item("motivo"), cmbMotivoEvento, 1, True)
            BuscaElementoCombo(tbTipoAccion, f.Item("tipoaccion"), cmbTipoAccion, 1, True)
            TextObservaEvento.Text = f.Item("observa")
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxEliEvento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliEvento.Click
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgEventos.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                filaTemp = CType(dgEventos.SelectedRows(0).DataBoundItem, DataRowView).Row
                tbEventos.Rows.Remove(filaTemp)
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

#End Region


#Region "CambioCombos"

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        textCtaBanc.Clear()
        textCtaBanc.ReadOnly = True
        If cmbFormaPago.Text.Trim <> "" Then
            If tbFormaPago.Rows(cmbFormaPago.SelectedIndex).Item(2) = "D" Then
                textCtaBanc.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub cmbTipoPer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoPer.SelectedIndexChanged
        TextTipoBase.Clear()
        textCtaBanc.ReadOnly = True
        If cmbTipoPer.Text.Trim <> "" Then
            filaTemp = tbTipoPer.Rows(cmbTipoPer.SelectedIndex)
            TextTipoBase.Text = filaTemp.Item(3)
            base = filaTemp.Item(4)
        End If
    End Sub

#End Region

    Private Sub TextBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextPorce.KeyPress
        soloNumero(sender, e)
    End Sub

#Region "ENTRA Y DEJA FOCO"
    Private Sub Foco(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoSeguro.Enter, cmbTipoPer.Enter, textCtaBanc.Enter, cmbPuesto.Enter, cmbModPago.Enter, cmbJornada.Enter, cmbFormaPago.Enter, TextObserva.Enter, cmbFormaPago.Enter, cmbJornada.Enter, textCtaBanc.Enter, TextHora1.Enter, TextHora2.Enter, TextOrigen.Enter, TextNombOrigen.Enter, TextPorce.Enter, textEmpleado.Enter, textNombreEmple.Enter, textCodigo.Enter, textNombCodigo.Enter, cmbAfecta.Enter, TextValor.Enter
        activa(sender)
    End Sub



    Private Sub Deja(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoSeguro.Leave, cmbTipoPer.Leave, textCtaBanc.Leave, cmbPuesto.Leave, cmbModPago.Leave, cmbJornada.Leave, cmbFormaPago.Leave, TextObserva.Leave, cmbFormaPago.Leave, cmbJornada.Leave, textCtaBanc.Leave, TextHora1.Leave, TextHora2.Leave, TextOrigen.Leave, TextNombOrigen.Leave, TextPorce.Leave, textEmpleado.Leave, textNombreEmple.Leave, textCodigo.Leave, textNombCodigo.Leave, cmbAfecta.Leave, TextValor.Leave
        desactiva(sender)
    End Sub
#End Region

    Private Sub frmDatosGen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

#Region "VALIDA HORAS "

    Private Sub TextHora1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextHora1.Validated, TextHora2.Validated
        Dim val1H1, val2H1, val1H2, val2H2 As Int32
        Dim horasf As Decimal = 0
        val1H1 = 0
        val2H1 = 0
        val1H2 = 0
        val2H2 = 0
        TextHorasTotal.Clear()
        Textsemanales.Clear()
        If TextHora1.Text <> "  :" Then
            If Hora(TextHora1, val1H1, val2H1) = False Then
                MsgBox("FORMATO DE LA HORA DE INICIO NO ES VALIDO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                TextHora1.Text = "__:__"
                TextHora2.Focus()
                Exit Sub
            End If
        End If
        If TextHora2.Text <> "  :" Then
            If Hora(TextHora2, val1H2, val2H2) = False Then
                MsgBox("FORMATO DE LA HORA DE INICIO NO ES VALIDO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                TextHora1.Text = "__:__"
                TextHora2.Focus()
                Exit Sub
            End If
        End If
        If TextHora1.Text <> "  :" And TextHora2.Text <> "  :" Then
            If val1H2 >= val1H1 Then
                If (val1H2 = val2H1) And (val2H2 <= val2H1) Then
                    MsgBox("HORA DE SALIDA DEBE SER MAYOR QUE LA HORA DE ENTRADA", MsgBoxStyle.Information, "Mensaje del Sistema")
                    TextHora2.Text = "__:__"
                    TextHora2.Focus()
                    Exit Sub
                End If
                If val2H2 >= val2H1 Then
                    HoraFinal = val1H2 - val1H1
                    minutoFinal = val2H2 - val2H1
                Else
                    minutoFinal = 60 + (val2H2 - val2H1)
                    HoraFinal = val1H2 - val1H1 - 1
                End If
                horasf = HoraFinal + (minutoFinal / 60)
                TextHorasTotal.Text = formato(horasf)
                Textsemanales.Text = formato(horasf * 5)
            Else
                MsgBox("HORA DE SALIDA DEBE SER MAYOR QUE LA HORA DE ENTRADA", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextHora2.Text = "__:__"
                TextHora2.Focus()
            End If
        End If
    End Sub


    Private Sub Textsemanales_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        If valida_decimal_Presicion(sender, 6, 2) = False Then
            MsgBox("VALOR INCORRECTO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Textsemanales.Text = 0
            Textsemanales.Focus()
        Else
            If CDec(Textsemanales.Text) = 0 Then
                MsgBox("DEBE INGRESAR UN VALOR MAYOR A 0", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If
        End If
    End Sub

#End Region

#Region "Campo horas semanales"
    Private Sub Textsemanales_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Textsemanales.Enter
        If IsNumeric(Textsemanales.Text) Then
            Textsemanales.Text = CDec(Textsemanales.Text)
        Else
            Textsemanales.Text = "0"
        End If
    End Sub

    Private Sub Textsemanales_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Textsemanales.KeyPress
        soloNumeroDec(sender, e)
    End Sub

    Private Sub Textsemanales_Validated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Textsemanales.Validated
        If IsNumeric(Textsemanales.Text) Then
            Textsemanales.Text = formato(CDec(Textsemanales.Text))
        Else
            Textsemanales.Text = "0"
        End If
    End Sub

    Private Sub TextHorasT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextHorasTotal.Enter
        If IsNumeric(Textsemanales.Text) Then
            Textsemanales.Text = CDec(Textsemanales.Text)
        Else
            Textsemanales.Text = "0"
        End If
    End Sub

    Private Sub TextHorasT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextHorasTotal.KeyPress
        soloNumeroDec(sender, e)
    End Sub

    Private Sub TextHorasT_Validated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextHorasTotal.Validated
        If IsNumeric(Textsemanales.Text) Then
            Textsemanales.Text = formato(CDec(Textsemanales.Text))
        Else
            Textsemanales.Text = "0"
        End If
    End Sub

#End Region

    Public Function TotalTabla(ByVal tabla As DataTable, ByVal indice As Int16) As Decimal
        Dim f As DataRow
        Dim i As Int32
        Dim numT As Decimal = 0
        For i = 0 To tabla.Rows.Count - 1
            f = tabla.Rows(i)

            numT = numT + f.Item(indice)
        Next i
        Return numT
    End Function

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub
End Class