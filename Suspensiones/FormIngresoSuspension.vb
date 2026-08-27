Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports ControllersERP.Nominas
Imports ControllersERP.ViewModels.Nominas
Imports OfficeOpenXml


Public Class FormIngresoSuspension
    Dim cadena As String

    Dim filaTemp As DataRow
    Dim ctrSus As New SuspensionController()
    Dim tbcontratos As New DataTable()

    Dim lista2 As New List(Of Suspensiones2ViewModel)
    Dim dpara As New Dictionary(Of String, Object)
    Dim _estado As Int32 = 0

    Public Property id_suspension As Int32 = 0

    Public Property drMaestro As DataRow 'ViewSuspensionesRow
    Public Property NuevoSuspension As Boolean = True

    Dim WithEvents f2C As frmMuestra2Columnas




    Public Sub asignar(datar As DataRow) 'ViewSuspensionesRow)
        btnLimpiar.Visible = False
        id_suspension = datar("id_suspension") '.id_suspension
        Dim ta As New DataTable 'ViewSuspensionesTableAdapter()
        Dim tb = ctrSus.GetByIdSusp(id_suspension)
        If tb IsNot Nothing AndAlso tb.Rows.Count > 0 Then
            datar = tb.Rows(0)
            txtNumero.Text = datar("numero") '.numero
            busqEmpleado.asigna_empleado(datar("empleado"))
            TextConxContrato.Text = datar("contrato")
            busqEmpleado.Enabled = False
            cmbTipoSus.SelectedValue = datar("tiposus")
            cmbGrado.SelectedValue = datar("grado")
            cmbAlta.SelectedValue = datar("tipoal")

            dpFechaI.Value = datar("fechai")
            If Not IsDBNull(datar("fechaf")) Then
                If datar("fechaf") <> New DateTime(1900, 1, 1) Then
                    txtFechaF.Text = datar("fechaf")

                Else
                    txtFechaF.Clear()
                End If
            Else
                txtFechaF.Clear()
            End If
            txtObservaciones.Text = datar("observa")
            txtCantidad.Text = datar("cantidad")
            txtValor.Text = formato(datar("valor"))
            txtEstado.Text = datar("nombre_estado")
            _estado = datar("estado")
            If Not IsDBNull(datar("fechae")) Then
                txtFechae.Text = datar("fechae")
            Else
                txtFechae.Clear()
            End If
            dpara("id_suspension") = Me.id_suspension
            cadena = "select a.empresa, a.id_sus2, a.mes, b.nombre as nombre_mes, a.año, a.transac, c.nombre as nombre_transac, a.dias, a.valor 
                               from suspensiones2 a
                               inner join meses b on a.mes=b.mes
                               inner join tipotran c on a.transac=c.transac and a.empresa=c.empresa
                               where id_suspension=@id_suspension order by c.transac, a.año, a.mes
"
            Dim tbDetalle As New DataTable
            llenaTabla(cadena, tbDetalle, ListaParametros(dpara))
            dgvData.DataSource = tbDetalle
            txtUsuario.Text = datar("usuario")
            Vista(dgvData)
            btnLimpiar.Visible = False


            txtFechaF.Visible = True

            If datar("estado") = 0 Then
                dpFechaI.Enabled = True
            Else
                dpFechaI.Enabled = False
            End If
        End If


    End Sub


    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista

            If (dgVista.Columns.Contains("id_suspension")) Then
                .Columns("id_suspension").Visible = False
            End If

            If (dgVista.Columns.Contains("numero")) Then
                .Columns("numero").Visible = False
            End If
            .Columns("empresa").Visible = False
            .Columns("id_sus2").Visible = False
            .Columns("mes").Visible = False
            .Columns("transac").Visible = False
            .Columns("año").HeaderText = "Año"
            .Columns("año").FillWeight = 10
            .Columns("año").DisplayIndex = 0
            .Columns("nombre_mes").HeaderText = "Mes"
            .Columns("nombre_mes").FillWeight = 15
            .Columns("nombre_mes").DisplayIndex = 1
            .Columns("nombre_transac").FillWeight = 50
            .Columns("nombre_transac").HeaderText = "Transacción"
            .Columns("nombre_transac").DisplayIndex = 2
            .Columns("dias").FillWeight = 10
            .Columns("dias").HeaderText = "Dias"
            .Columns("dias").DisplayIndex = 3
            .Columns("valor").HeaderText = "Valor"
            .Columns("valor").FillWeight = 15
            .Columns("valor").DefaultCellStyle.Format = "N2"
            .Columns("valor").DisplayIndex = 4
        End With
    End Sub



    Private Sub FormIngresoSuspension_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ctrSus.FillComboTipoSuspension(cmbTipoSus, False)
        ctrSus.FillComboGrados(cmbGrado, False)
        ctrSus.FillComboTiposAlta(cmbAlta, False)
        busqEmpleado.id_empresa = empresa
        'busqEmpleado.activo = False
        habilitacion_fechaf(True)
        If Me.drMaestro IsNot Nothing Then
            asignar(drMaestro)
        Else
            limpia_forma()
            busqEmpleado.activo = True
            btnGuardar.Enabled = True
        End If

    End Sub


    Private Sub habilitacion_fechaf(valor As Boolean)
        dgvData.Visible = valor
        txtFechaF.Visible = Not valor
    End Sub



    Private Sub limpia_forma()
        Me.id_suspension = 0
        busqEmpleado.EraserForm()
        lista2 = New List(Of Suspensiones2ViewModel)()
        borra_Mejorado(gpDatos, ep1)
        Dim dr As DataRow
        If Not NuevoSuspension Then
            dr = ctrSus.GetDRSuspension(id_suspension)
            If (dr IsNot Nothing) Then
                asignar(dr)
                pnEstado.Visible = True
            End If
            busqEmpleado.Enabled = False
        Else
            borra_Mejorado(gpDatos, ep1)
            busqEmpleado.Enabled = True
            txtNumero.Text = ctrSus.GetMaxIdSuspension(empresa)
            pnEstado.Visible = False
        End If


        dpFechaI.Enabled = True
        dgvData.DataSource = Nothing

    End Sub


    Private Sub frm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub
    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
      cmbTipoSus.Enter, txtObservaciones.Enter
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
      cmbTipoSus.Leave, txtObservaciones.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub btnGuarda_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim numero As Int32 = 0
        Dim fechai As Date
        Dim valor As Decimal = 0
        Dim cantidad As Decimal = 0
        If busqEmpleado.Empleado > 0 And validetError(cmbTipoSus, ep1) And validetComilla(txtObservaciones, ep1) And Int32.TryParse(txtNumero.Text, numero) And
            validetError(TextConxContrato, ep1) And validetError(cmbGrado, ep1) AndAlso validetError(cmbAlta, ep1) Then

            fechai = dpFechaI.Value.Date


            If MsgBox("DESEA GUARDAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                Dim modelo As New cmodelo
                Try

                    dpara("numero") = CInt(txtNumero.Text)
                    dpara("empresa") = empresa
                    dpara("empleado") = busqEmpleado.Empleado
                    dpara("tiposus") = cmbTipoSus.SelectedValue
                    dpara("contrato") = TextConxContrato.Text
                    'dpara("id_tipost") = DBNull.Value

                    dpara("fechai") = fechai
                    dpara("fechaf") = New DateTime(1900, 1, 1)

                    dpara("cantidad") = cantidad
                    dpara("valor") = valor
                    dpara("observa") = txtObservaciones.Text
                    dpara("estado") = 0
                    dpara("fechae") = Today
                    dpara("usuario") = _usuario
                    dpara("grado") = cmbGrado.SelectedValue
                    dpara("tipoal") = cmbAlta.SelectedValue


                    If Me.id_suspension = 0 Then
                        If ctrSus.GetExisteSuspension(empresa, busqEmpleado.Empleado, fechai) > 0 Then
                            MsgBox("Suspensión ya ingresa, verifique", MsgBoxStyle.Information, "Mensaje del Sistema")
                            Exit Sub
                        End If



                        cadena = "insert into  suspensiones (empresa,numero,empleado,contrato,tiposus,grado,fechai,fechaf,cantidad,tipoal," &
                         "valor,observa,estado,fechae,usuario) values  (@empresa,@numero,@empleado,@contrato,@tiposus,@grado,@fechai,@fechaf,@cantidad,@tipoal," &
                         "@valor,@observa,@estado,@fechae,@usuario); " &
                         "select scope_identity();"
                        Me.id_suspension = modelo.BuscaEscalar(cadena, ListaParametros(dpara))

                        'cadena = "insert suspensiones2
                        '         (empresa, numero, transac, cantidad, valor, mes, año, dias, id_suspension) 
                        '         values (@empresa, @numero, @transac, @cantidad, @valor, @mes, @año, @dias, @id_suspension);"
                        'dpara("id_suspension") = Me.id_suspension
                        'For Each ele As Suspensiones2ViewModel In lista2
                        '    dpara("cantidad") = ele.dias
                        '    dpara("transac") = ele.transac
                        '    dpara("dias") = ele.dias
                        '    dpara("mes") = ele.mes
                        '    dpara("año") = ele.año
                        '    dpara("valor") = ele.valor
                        '    modelo.EjecutarNonQuery(cadena, ListaParametros(dpara))

                        'Next

                        cadena = "update contratos1 set estado=4 where empleado=@empleado and empresa=@empresa and contrato=@contrato"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(dpara))


                    Else
                        dpara("id_suspension") = Me.id_suspension
                        If _estado = 0 Then
                            cadena = "update suspensiones set fechai=@fechai,tiposus=@tiposus,observa=@observa, usuario=@usuario, tipoal=@tipoal, grado=@grado " &
                            "where id_suspension=@id_suspension"
                        Else
                            cadena = "update suspensiones set tiposus=@tiposus,observa=@observa, tipoal=@tipoal, grado=@grado " &
                          "where id_suspension=@id_suspension"
                        End If


                        If modelo.EjecutarNonQuery(cadena, ListaParametros(dpara)) Then
                            If (Not Me.drMaestro Is Nothing) Then
                                Me.drMaestro("fechai") = dpara("fechai")
                                Me.drMaestro("observa") = dpara("observa")
                                Me.drMaestro("tipoal") = dpara("tipoal")
                                Me.drMaestro("grado") = dpara("grado")
                                Me.drMaestro("tiposus") = dpara("tiposus")
                            End If

                        End If
                    End If

                    '  EjecutarQuery(cadena)
                    If modelo.Commit() Then
                        InsertBitacora(9, 1, $"Ingreso o modificación suspensión cond id_suspensión {Me.id_suspension}")
                        MsgBox("Operación realizada co éxito", MsgBoxStyle.Information, "Mensaje del Sistema")
                        If Me.NuevoSuspension Then
                            If MsgBox("¿Desea agregar una nueva suspensión?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = vbYes Then
                                limpia_forma()
                            End If
                        Else
                            Me.Close()
                        End If

                    End If



                Catch ex As Exception
                    MsgBox("Error al guardar la información. " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                    modelo.RollBack()
                End Try
            End If
        Else

            MsgBox("Ingrese los campos requeridos", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
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
                     "where e.activo='S' and c1.empresa=@empresa and empleado=@empleado"
            Num = llenaTabla(cadena, tbcontratos, ListaParametros(lpara))
            If Num = 1 Then
                TextConxContrato.Text = tbcontratos.Rows(0).Item(0)
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbcontratos, "CONTRATO", "PUESTO", 0)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContrato
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()
                cmbTipoSus.Focus()

            ElseIf Num = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            MsgBox("INGRESO PRIMERO EL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ActualizacionDatosContrato(ByVal sender As Object, ByVal e As clsActValorREvento)
        filaTemp = tbcontratos.Rows(e.va2)
        TextConxContrato.Text() = filaTemp.Item(0)
        ExistenciaSusp()
    End Sub

    Private Sub ExistenciaSusp()
        Dim lpara As New Dictionary(Of String, Object)
        lpara("empresa") = empresa
        lpara("empleado") = busqEmpleado.Empleado
        lpara("contrato") = TextConxContrato.Text
        If BuscaEscalar("select count(*) from suspensiones where empresa=@empresa and empleado=@empleado and contrato=@contrato and estado=0", ListaParametros(lpara)) > 0 Then
            MsgBox("ESTE EMPLEADO TIENE SUSPENSION ACTIVA", MsgBoxStyle.Information, "Mensaje del Sistema")
            TextConxContrato.Clear()
        Else
            cmbTipoSus.Focus()
        End If
    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpia_forma()
    End Sub
End Class