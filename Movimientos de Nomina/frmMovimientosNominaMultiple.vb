Imports NOMINA.Entidades
Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Collections.Generic


Public Class frmMovimientosNominaMultiple

    Dim cadena As String = ""
    Dim tbTipo As New DataTable
    Dim tbMes As New DataTable
    Dim pnCtr As PagosnomController
    Dim mesCtr As MesController
    Dim para As New Dictionary(Of String, Object)
    Dim meses As List(Of Mes)

    Dim _fMod As DataRow
    Dim lPagos As New List(Of Pagosnom)
    Dim lPara As New Dictionary(Of String, Object)
    Dim tbDatos As New DataTable()

    Private Sub frmMovimientosNomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextAño.Text = DateTime.Today.Year

        cadena = "select nombre, tiponom from tiponomina1 where empresa=" & empresa & " and movimientos='S' order by tiponom"
        llena_combo(cadena, cmbTipo)
        cmbTipo.Items.Add("")
        llenaTabla(cadena, tbTipo)

        btnLimpiar_Click(sender, e)
        pnCtr = New PagosnomController(_conexion)
        mesCtr = New MesController(_conexion)


        meses = mesCtr.GetMeses()
        busqTransaccion.id_empresa = empresa
    End Sub


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        borra_Mejorado(gpDatos, ep1)
        busqTransaccion.BorraCodigo()
        gpDatos.Enabled = True

        dgDatos.DataSource = Nothing
        btnGuardar.Enabled = False

        ContextoMenuEnab(True, False, ctxMenu)
        TextAño.Text = Today.Year

    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim año As Short = 0
        If busqTransaccion.transac = 0 Or
        validetError(cmbTipo, ep1) = False Or
        Not Short.TryParse(TextAño.Text, año) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim mes As Int32 = 0
        Dim tipovalor As String = ""
        para.Clear()
        para("empresa") = empresa
        para("tiponom") = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
        para("año") = TextAño.Text
        para("transac") = busqTransaccion.transac

        If rbValor.Checked Then
            tipovalor = "V"
        Else
            tipovalor = "C"
        End If
        para("tipovalor") = tipovalor

        lPagos = pnCtr.GetPagosNom(empresa, para("tiponom"), año)
        cadena = "Select * from dbo.MovimientosNomina3(@empresa,@año,@tiponom,@transac,@tipovalor) order by nombre"
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

        gpDetalle.Enabled = True
        btnGuardar.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub Vista(ByVal dgVista As DataGridView, ByVal listaP As List(Of Pagosnom))
        Dim pago As Pagosnom
        With dgVista
            Dim mes As Short
            .Columns("empleado").HeaderText = "Cod."
            .Columns("empleado").FillWeight = 8
            .Columns("empleado").Frozen = True
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").FillWeight = 35
            .Columns("nombre").Frozen = True
            .Columns("contrato").HeaderText = "Cont."
            .Columns("contrato").FillWeight = 5
            .Columns("contrato").Frozen = True

            For i As Integer = 1 To 12
                mes = i
                pago = listaP.Where(Function(x) x.mes = mes AndAlso x.estado <> 1).FirstOrDefault()
                .Columns(mes.ToString()).HeaderText = meses.Where(Function(x) x.mes = mes).FirstOrDefault().nombre.Substring(0, 3)
                .Columns(mes.ToString()).FillWeight = 20
                .Columns(mes.ToString()).DefaultCellStyle.Format = "N2"

                If (pago IsNot Nothing) Then
                    .Columns(mes.ToString()).ReadOnly = True
                    .Columns(mes.ToString()).DefaultCellStyle.BackColor = Color.Red
                    .Columns(mes.ToString()).DefaultCellStyle.ForeColor = Color.Black

                End If
            Next
        End With
        Dim mesM As Mes

        For Each filagrid As DataGridViewRow In dgDatos.Rows

            'For Each mesM In meses
            '    filagrid.Cells($"{mesM.mes}").ReadOnly = True
            'Next
        Next
    End Sub

    Private Sub busqTransaccion_Cambio_valor(transac As Integer, nombre As String) Handles busqTransaccion.Cambio_valor
        If transac = 0 Then
            rbCantidad.Enabled = True
        Else
            If busqTransaccion.Tipo_Valor = "V" Then
                rbCantidad.Enabled = False
                rbValor.Checked = True
            Else
                rbCantidad.Enabled = True
            End If
        End If
    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim i As Integer
        Dim modelo As New cmodelo
        Dim indice As Int16 = cmbTipo.SelectedIndex
        Dim tiponom As String = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
        Dim anio As String = TextAño.Text
        lPara.Clear()
        Dim filaTemp As DataRow
        Cursor.Current = Cursors.WaitCursor

        Try
            If MsgBox("DESEA GUARDAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                Dim mesesDisp = meses.Where(Function(x) Not lPagos.Select(Function(y) y.mes).ToList().Contains(x.mes)).ToList()
                Dim valor As Decimal = 0
                Dim mesM As Mes
                For Each mesM In mesesDisp

                    lPara("mes") = mesM.mes
                    lPara("tiponom") = tiponom
                    lPara("año") = CInt(TextAño.Text)
                    lPara("transac") = busqTransaccion.transac
                    lPara("empresa") = empresa

                    For i = 0 To tbDatos.Rows.Count - 1
                        filaTemp = tbDatos.Rows(i)
                        If filaTemp.RowState = DataRowState.Modified Then
                            lPara("contrato") = filaTemp("contrato")
                            lPara("empleado") = filaTemp("empleado")


                            cadena = "delete from movinomina where empresa=@empresa and empleado=@empleado" &
                            " and contrato=@contrato and tiponom=@tiponom and  mes =@mes and año=@año and transac=@transac"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))


                            valor = CDec(filaTemp(mesM.mes.ToString()))
                            If rbCantidad.Checked Then
                                lPara("valor") = 0
                                lPara("cantidad") = valor
                            Else
                                lPara("valor") = valor
                                lPara("cantidad") = 0
                            End If
                            lPara("usuario") = user
                            lPara("fechae") = Today
                            If valor > 0 Then

                                cadena = "insert into movinomina (empresa,empleado,contrato,tiponom,mes,año,transac,cantidad," &
                               "valor,usuario,fechae) values 
                           (@empresa,@empleado,@contrato,@tiponom,@mes,@año,@transac,@cantidad,@valor,@usuario,@fechae)"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))
                            End If
                        End If


                    Next i
                    System.Threading.Thread.Sleep(10)

                Next
                Cursor.Current = Cursors.Default

                If modelo.Commit() Then
                    InsertBitacora(9, 1, $"Ingreso o modificación movimientos variable transaccion {busqTransaccion.transac}  año {TextAño.Text} tipo nomina {cmbTipo.Text}")
                    btnLimpiar_Click(sender, e)
                    cmbTipo.SelectedIndex = indice
                    TextAño.Text = anio
                    MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR EN EL INGRESO DE DATOS" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            modelo.RollBack()
        End Try
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

    Private Sub textFiltro_TextChanged(sender As Object, e As EventArgs) Handles textFiltro.TextChanged
        If dgDatos.DataSource IsNot Nothing Then
            Dim tbDat As DataTable = dgDatos.DataSource
            If textFiltro.Text.Trim <> "" Then
                tbDat.DefaultView.RowFilter = $" nombre like '%{ textFiltro.Text}%' "
            Else
                tbDat.DefaultView.RowFilter = ""
            End If
        End If
    End Sub

    Private Sub btnDwnXLS_Click(sender As Object, e As EventArgs) Handles btnDwnXLS.Click

        Dim excelFileName As String = Path.GetRandomFileName()

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
        saveFileDialog.Title = "Guardar archivo de Excel"

        ' Añadir la extensión .xlsx al nombre del archivo
        Dim excelFilePath As String '"Temp-" & excelFileName & ".xlsx"

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            excelFilePath = saveFileDialog.FileName

            Using excelPackage As New ExcelPackage()

                ' Crear una hoja de cálculo
                Dim worksheet As ExcelWorksheet = excelPackage.Workbook.Worksheets.Add("Hoja1")

                ' Escribir los datos de la tabla en la hoja de cálculo
                If tbDatos.Rows.Count > 0 Then
                    worksheet.Cells.LoadFromDataTable(tbDatos, True)
                Else
                    MsgBox("Primero busque los datos que desea descargar", MsgBoxStyle.Information, "Mensaje del sistema")
                    Return
                End If

                ' Guardar el archivo de Excel
                excelPackage.SaveAs(New System.IO.FileInfo(excelFilePath))
                Process.Start(excelFilePath)
            End Using

        End If


    End Sub

    Private Sub btnLoadXLS_Click(sender As Object, e As EventArgs) Handles btnLoadXLS.Click
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial

        ' Ruta del archivo Excel
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
        openFileDialog.Title = "Seleccionar archivo de Excel"
        lPara.Clear()
        Dim tbcarga As New DataTable
        ' Leer datos del archivo Excel
        'Dim dataTable As DataTable = New DataTable()
        If (busqTransaccion.transac = 0) Or Not validetError(cmbTipo, ep1) Then
            MsgBox("Ingrese las operaciones necesarias!.", MsgBoxStyle.Information, "Mensaje del Sistema")
            Return
        End If


        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim excelFilePath As String = openFileDialog.FileName

            ' Leer datos del archivo Excel

            Cursor.Current = Cursors.WaitCursor
            Dim i As Int32 = 0

            Try
                Dim filas() As DataRow
                Using excelPackage As New ExcelPackage(New System.IO.FileInfo(excelFilePath))
                    Dim worksheet As ExcelWorksheet = excelPackage.Workbook.Worksheets(0)
                    Dim rowCount As Integer = worksheet.Dimension.Rows
                    Dim columnCount As Integer = worksheet.Dimension.Columns

                    For col As Integer = 1 To columnCount
                        tbcarga.Columns.Add(worksheet.Cells(1, col).Value.ToString())
                    Next

                    For Row As Integer = 2 To rowCount
                        Dim excelRow As DataRow = tbcarga.NewRow()
                        For col As Integer = 1 To columnCount
                            excelRow(col - 1) = worksheet.Cells(Row, col).Value
                        Next

                        If (excelRow("empleado") IsNot DBNull.Value AndAlso excelRow("contrato") IsNot DBNull.Value) Then
                            tbcarga.Rows.Add(excelRow)
                            filas = tbDatos.Select($"empleado={excelRow("empleado")} and contrato={excelRow("contrato")}")
                            If (filas.Count > 0) Then

                                For i = 3 To tbcarga.Columns.Count - 1
                                    If (dgDatos.Columns(i).ReadOnly = False) Then
                                        If (filas(0)(i) <> excelRow(i)) Then
                                            filas(0)(i) = excelRow(i)
                                            If filas(0).RowState <> DataRowState.Modified Then
                                                filas(0).SetModified()
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If


                    Next

                End Using
            Catch ex As Exception
                MsgBox("Error al cargar el archivo " + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            End Try

            'Cursor.Current = Cursors.WaitCursor


            'Using excelPackage As New ExcelPackage(New System.IO.FileInfo(excelFilePath))
            '    Dim worksheet As ExcelWorksheet = excelPackage.Workbook.Worksheets(0)
            '    Dim rowCount As Integer = worksheet.Dimension.Rows
            '    Dim columnCount As Integer = worksheet.Dimension.Columns

            '    For col As Integer = 1 To columnCount
            '        tbcarga.Columns.Add(worksheet.Cells(1, col).Value.ToString())
            '    Next

            '    For Row As Integer = 2 To rowCount
            '        Dim excelRow As DataRow = tbcarga.NewRow()
            '        For col As Integer = 1 To columnCount
            '            excelRow(col - 1) = worksheet.Cells(Row, col).Value
            '        Next

            '        tbcarga.Rows.Add(excelRow)

            '    Next


            '    tbcarga.AcceptChanges()
            'End Using

            'For Each row As DataRow In tbcarga.Rows
            '    row.SetModified()
            'Next

            '' Crear y configurar DataGridView

            'dgDatos.DataSource = tbcarga
            lPara("tiponom") = cmbTipo.SelectedValue
            lPagos = pnCtr.GetPagosNom(empresa, lPara("tiponom"), TextAño.Text)

            Vista(dgDatos, lPagos)
            System.Threading.Thread.Sleep(10)
            Cursor.Current = Cursors.Default
            btnGuardar.Enabled = True
        End If
    End Sub
End Class