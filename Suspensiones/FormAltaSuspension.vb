Imports System.Data.SqlClient
Imports ControllersERP.Nominas
Imports ControllersERP.ViewModels.Nominas

Public Class FormAltaSuspension

    Dim ctrSus As New SuspensionController()
    Dim ctrContrato As New ContratoController()
    Dim ctrTransac As New TipotranController
    Dim ctrMes As New MesController(_conexion)
    Dim cadena, tibase As String
    Public Property fechaI As DateTime

    Public Property fechaF As DateTime
    Dim base As Decimal
    Dim valor As Decimal
    Public Property id_suspension As Int32
    Public Property numero As Int32
    Public Property nombre_empleado As String
    Public Property empleado As Int32 = 0

    Public Property contrato As Short = 0

    Dim lista2 As New List(Of Suspensiones2ViewModel)

    Public Property dr As DataRow

    Public Sub Inicializa(id_suspension As Int32, id_empleado As Int32, contrato As Short, fechai As Date, numero As Int32, nombre_empleado As String, dr As DataRow)
        Me.id_suspension = id_suspension
        Me.empleado = id_empleado
        Me.fechaI = fechai
        Me.contrato = contrato
        Me.numero = numero
        Me.nombre_empleado = nombre_empleado
        txtEmpleado.Text = nombre_empleado
        Me.dr = dr
        txtFechaI.Text = fechai
        Dim tbTran = ctrSus.GetTransacIngresos(empresa)


    End Sub

    Private Sub FormAltaSuspension_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnGuardar.Enabled = False
    End Sub

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim ValSus As Decimal = 0
        Dim CantSus As Decimal = 0
        If Decimal.TryParse(txtValor.Text, ValSus) AndAlso ValSus > 0 AndAlso Decimal.TryParse(txtNum.Text, CantSus) AndAlso CantSus > 0 Then


            Try
                If ctrSus.SaveSuspensiones2(lista2, 2, dpFechaF.Value.Date, Today.ToShortDateString) Then
                    dr("estado") = 2
                    dr("valor") = ValSus
                    dr("cantidad") = CantSus
                    dr("nombre_estado") = "Finalizada"
                    MsgBox("Operación realizada con éxito")
                    Me.Close()
                End If

            Catch ex As Exception
                MsgBox("Error del Sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")

            End Try

        End If

    End Sub




    Public Event actValor(ByVal sender As Object, ByVal e As clsActValorREvento)

    Private Sub regresar()
        Dim argumentos As clsActValorREvento
        argumentos = New clsActValorREvento("", 1)
        RaiseEvent actValor(Me, argumentos)
        Me.Close()
    End Sub


    Private Sub frmDatosGen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub






    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnValidar.Click
        Dim lista As List(Of Suspensiones2ViewModel)
        lista2 = New List(Of Suspensiones2ViewModel)
        Dim fechai As DateTime

        DateTime.TryParse(txtFechaI.Text, fechai)

        If fechai >= dpFechaF.Value.Date Then
            MsgBox("La fecha de alta debe ser mayor a la fecha del inicio de la suspensión ")
            Exit Sub
        End If
        lista = ctrSus.ObtenerDiasPorMes(CDate(txtFechaI.Text), dpFechaF.Value.Date)
        txtNum.Text = lista.Sum(Function(x) x.dias)





        Dim lTransac As New List(Of Short)
        If (lista IsNot Nothing AndAlso lista.Count > 0) Then
            lista2.Clear()
            Dim tbSueldos As New DataTable()
            tbSueldos = ctrContrato.GetSueldosbyEmpleado(empleado, Me.contrato, empresa)



            Dim sus2 As Suspensiones2ViewModel
            lTransac = ctrSus.GetTransaccionAfecta(empresa)
            If lTransac.Count = 0 Then
                MsgBox("No ha definido las transacciones de calculo de suspensiones", MsgBoxStyle.Critical, "Mensaje del sistema")
                Exit Sub
            End If
            If tbSueldos.Rows.Count = 0 Then
                MsgBox("El empleado no posee transacciones definidas con el grupo de transacciones definidas", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            End If
            For Each dr As DataRow In tbSueldos.Rows
                If lTransac.Contains(dr("transac")) Then
                    For Each det As Suspensiones2ViewModel In lista
                        sus2 = New Suspensiones2ViewModel() With
                            {
                         .id_suspension = Me.id_suspension,
                         .transac = dr("transac"),
                         .numero = numero,
                         .empresa = empresa,
                         .año = det.año,
                         .mes = det.mes,
                         .dias = det.dias,
                         .valor = If(det.dias > 30, dr("valor"), (dr("valor") / 30.0) * det.dias),
                         .nombre_transac = If(ctrTransac.GetTransaccion(dr("transac"), empresa) IsNot Nothing, ctrTransac.GetTransaccion(dr("transac"), empresa)("nombre"), ""),
                         .nombre_mes = ctrMes.GetNombreMes(det.mes)
                        }
                        lista2.Add(sus2)
                    Next
                End If


            Next
            If lista2.Count > 0 Then
                txtValor.Text = lista2.Sum(Function(x) x.valor).ToString("N2")
                txtNum.Text = lista2.Sum(Function(x) x.dias).ToString("N2")
                dgvData.DataSource = lista2
                vista(dgvData)
                btnGuardar.Enabled = True
            End If

        End If


    End Sub

    Private Sub vista(dgvista As DataGridView)
        If dgvista.DataSource IsNot Nothing Then
            With dgvista
                .Columns("id_sus2").Visible = False
                .Columns("id_suspension").Visible = False
                .Columns("transac").Visible = False
                .Columns("empresa").Visible = False
                .Columns("numero").Visible = False
                .Columns("año").HeaderText = "Año"
                .Columns("año").FillWeight = 10
                .Columns("mes").Visible = False
                .Columns("nombre_mes").HeaderText = "Mes"
                .Columns("nombre_mes").FillWeight = 10
                .Columns("valor").HeaderText = "Valor"
                .Columns("valor").FillWeight = 15
                .Columns("valor").DefaultCellStyle.Format = "N2"
                .Columns("dias").HeaderText = "Cantidad Dias"
                .Columns("dias").FillWeight = 15
                .Columns("nombre_transac").HeaderText = "Transacción"
                .Columns("nombre_transac").FillWeight = 50
            End With
        End If
    End Sub


    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub dgvData_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvData.DataError
        MsgBox(e.Exception.Message)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumero(sender, e)
    End Sub

End Class