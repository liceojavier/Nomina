Imports NOMINA.controller
Imports NOMINA.dsConsultasTableAdapters
Imports System.IO
Imports ClosedXML.Excel
Imports ControllersERP.Excel

Public Class frmModificacionNomina

    Dim tbData As New DataTable()
    Dim tbTransac As DataTable
    Dim ctrMes As New MesController(_conexion)
    Dim ctrEmpleado As New EmpleadoController()
    Dim ctrTipoNom As New TipoNominasController()
    Dim ctrTipoTran As New TipotranController()
    Dim ctrNominas As New NominasController()
    Dim taRegistroNom As New QueryRegistroNominaTableAdapter
    Dim consulta As Boolean
    Dim cadena As String = ""
    Dim tbTipoPer As New DataTable
    Dim lpara As New Dictionary(Of String, Object)
    Dim abcd = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"


    Private Sub frmModificacionNomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ctrMes.FillComboMes(cmbMes, False)
        ctrTipoNom.FillComboTipoNomina(cmbTipo, False)
        TextAño.Text = Today.Year

        lpara("empresa") = empresa
        cadena = "select a.nombre, a.tibase, a.basevaca, a.cantvaca, a.tipoper from tipopersonal a
                 where a.empresa=@empresa and a.prestaciones='S' and a.pagonomina='S'"
        llenaTabla(cadena, tbTipoPer, ListaParametros(lpara))
        cklbTipoPersonal.DataSource = tbTipoPer
        cklbTipoPersonal.DisplayMember = "nombre"
        rbTodos.Checked = True

        cmbTipoA.SelectedIndex = 0
    End Sub

    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click

        Dim tbValores As DataTable
        Dim año, mes As Int16
        Dim ftotal As DataRow
        Dim dc As DataColumn
        pgBarra.Value = 0
        If Int16.TryParse(TextAño.Text, año) And Int16.TryParse(cmbMes.SelectedValue, mes) Then

            If consulta Then
                dgvData.ReadOnly = True
                Dim ltipoPer As New List(Of Int16)
                Dim listado = cklbTipoPersonal.CheckedItems


                For Each ele2 As DataRowView In listado
                    ltipoPer.Add(Convert.ToInt16(ele2("tipoper")))
                Next

                tbData = ctrEmpleado.GetEmpleadosContrato(empresa, ltipoPer)
                tbTransac = ctrTipoTran.GetTransaccionesNomina(empresa, cmbTipo.SelectedValue)
                tbValores = ctrNominas.GetNominas(empresa, cmbTipo.SelectedValue, mes, año)

                For Each dr As DataRow In tbTransac.Rows

                    If rbTodos.Checked Or rbCantidad.Checked Then
                        dc = New DataColumn
                        dc.ColumnName = $"transac-c-{dr.Item("transac")}"
                        dc.AllowDBNull = False
                        dc.DataType = System.Type.GetType("System.Decimal")
                        dc.DefaultValue = 0
                        tbData.Columns.Add(dc)
                    End If
                    If rbTodos.Checked Or rbValores.Checked Then
                            dc = New DataColumn
                            dc.ColumnName = $"transac-v-{dr.Item("transac")}"
                            dc.AllowDBNull = False
                            dc.DataType = System.Type.GetType("System.Decimal")
                            dc.DefaultValue = 0
                            tbData.Columns.Add(dc)
                        End If


                Next
                dc = New DataColumn
                dc.ColumnName = $"total"
                dc.AllowDBNull = False
                dc.DataType = System.Type.GetType("System.Decimal")
                dc.DefaultValue = 0
                tbData.Columns.Add(dc)
                Dim totalC As Decimal = 0
                For Each dr As DataRow In tbData.Rows
                    totalC = 0
                    Dim filas() As DataRow = tbValores.Select($"empleado={dr("empleado")} and contrato={dr("contrato")}")
                    For Each fila As DataRow In filas

                        If rbTodos.Checked Or rbCantidad.Checked Then
                            If tbData.Columns.Contains($"transac-c-{fila("transac")}") Then
                                dr($"transac-c-{fila("transac")}") = fila("cantidad") + dr($"transac-c-{fila("transac")}")
                            End If

                        End If
                        If rbTodos.Checked Or rbValores.Checked Then
                                If tbData.Columns.Contains($"transac-v-{fila("transac")}") Then
                                    dr($"transac-v-{fila("transac")}") = fila("valor") + dr($"transac-v-{fila("transac")}")
                                End If
                            End If

                            If fila("tipomov") = "I" Then
                            totalC += fila("valor")
                        ElseIf fila("tipomov") = "D" Then
                            totalC += -fila("valor")
                        End If
                    Next
                    dr("total") = totalC
                    dr.AcceptChanges()
                Next


                If rbTodos.Checked Or rbValores.Checked Then
                    ftotal = tbData.NewRow()
                    ftotal("empleado") = 0
                    ftotal("nombre") = 0
                    ftotal("contrato") = 0

                    For Each dr As DataRow In tbTransac.Rows

                        If tbData.Columns.Contains($"transac-v-{dr.Item("transac")}") Then
                            totalC = (From a In tbData.AsEnumerable()
                                      Select a.Field(Of Decimal)($"transac-v-{dr.Item("transac")}")).Sum()
                            ftotal($"transac-v-{dr.Item("transac")}") = totalC
                        End If

                    Next
                    tbData.Rows.Add(ftotal)
                End If


            Else

                If taRegistroNom.CountQuery(empresa, año, mes) > 0 Then
                    MsgBox("Nómina ya ha sido generada y pagada, no se puede modificar. Debe anular el registro de generación", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    dgvData.ReadOnly = True

                Else
                    dgvData.ReadOnly = False
                End If

                tbData = ctrEmpleado.GetEmpleadosContrato(empresa)
                tbTransac = ctrTipoTran.GetTransaccionesNomina(empresa, cmbTipo.SelectedValue)
                tbValores = ctrNominas.GetNominas(empresa, cmbTipo.SelectedValue, mes, año)

                For Each dr As DataRow In tbTransac.Rows
                    dc = New DataColumn
                    dc.ColumnName = $"transac-c-{dr.Item("transac")}"
                    dc.AllowDBNull = False
                    dc.DataType = System.Type.GetType("System.Decimal")
                    dc.DefaultValue = 0
                    tbData.Columns.Add(dc)
                    dc = New DataColumn
                    dc.ColumnName = $"transac-v-{dr.Item("transac")}"
                    dc.AllowDBNull = False
                    dc.DataType = System.Type.GetType("System.Decimal")
                    dc.DefaultValue = 0
                    tbData.Columns.Add(dc)
                Next
                dc = New DataColumn
                dc.ColumnName = $"total"
                dc.AllowDBNull = False
                dc.DataType = System.Type.GetType("System.Decimal")
                dc.DefaultValue = 0
                tbData.Columns.Add(dc)
                Dim totalC As Decimal = 0
                For Each dr As DataRow In tbData.Rows
                    totalC = 0
                    Dim filas() As DataRow = tbValores.Select($"empleado={dr("empleado")} and contrato={dr("contrato")}")
                    For Each fila As DataRow In filas
                        If tbData.Columns.Contains($"transac-c-{fila("transac")}") Then
                            dr($"transac-c-{fila("transac")}") = fila("cantidad") + dr($"transac-c-{fila("transac")}")
                        End If
                        If tbData.Columns.Contains($"transac-v-{fila("transac")}") Then
                            dr($"transac-v-{fila("transac")}") = fila("valor") + dr($"transac-v-{fila("transac")}")
                        End If
                        If fila("tipomov") = "I" Then
                            totalC += fila("valor")
                        ElseIf fila("tipomov") = "D" Then
                            totalC += -fila("valor")
                        End If
                    Next
                    dr("total") = totalC
                    dr.AcceptChanges()
                Next



                ftotal = tbData.NewRow()
                ftotal("empleado") = 0
                ftotal("nombre") = 0
                ftotal("contrato") = 0

                For Each dr As DataRow In tbTransac.Rows

                    If tbData.Columns.Contains($"transac-v-{dr.Item("transac")}") Then
                        totalC = (From a In tbData.AsEnumerable()
                                  Select a.Field(Of Decimal)($"transac-v-{dr.Item("transac")}")).Sum()
                        ftotal($"transac-v-{dr.Item("transac")}") = totalC
                    End If

                Next
                tbData.Rows.Add(ftotal)

            End If

            dgvData.DataSource = tbData
            define_vista(tbTransac, dgvData)
        Else

            MsgBox("Ingrese el año y el mes")
        End If

    End Sub


    Private Sub define_vista(tbTransac As DataTable, dgvD As DataGridView)
        Dim nombrec As String

        With dgvD
            .Columns("empleado").HeaderText = "Empleado"
            .Columns("empleado").Frozen = True
            .Columns("empleado").ReadOnly = True
            .Columns("empleado").DisplayIndex = 0
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").Frozen = True
            .Columns("nombre").ReadOnly = True
            .Columns("nombre").Width = 200
            .Columns("nombre").DisplayIndex = 1
            .Columns("contrato").HeaderText = "Contrato"
            .Columns("contrato").Frozen = True
            .Columns("contrato").ReadOnly = True
            .Columns("contrato").DisplayIndex = 2
            .Columns("nombre_puesto").HeaderText = "Puesto"
            .Columns("nombre_puesto").Frozen = True
            .Columns("nombre_puesto").ReadOnly = True
            .Columns("nombre_puesto").DisplayIndex = 3
            .Columns("total").HeaderText = "Total"
            .Columns("total").DefaultCellStyle.Format = "N2"
            .Columns("total").ReadOnly = True
            .Columns("total").DefaultCellStyle.ForeColor = Color.Red
        End With
        Dim i As Int32 = 4
        For Each dr As DataRow In tbTransac.Rows


            If dgvD.Columns.Contains($"transac-c-{dr("transac")}") Then
                nombrec = $"transac-c-{dr("transac")}"
                With dgvD
                    .Columns(nombrec).HeaderText = $"C-{dr("nombre")}"
                    .Columns(nombrec).DefaultCellStyle.Format = "N2"
                    .Columns(nombrec).DisplayIndex = i
                    i += 1
                End With
            End If
            If dgvD.Columns.Contains($"transac-v-{dr("transac")}") Then
                nombrec = $"transac-v-{dr("transac")}"
                With dgvD
                    .Columns(nombrec).HeaderText = $"V-{dr("nombre")}"
                    .Columns(nombrec).DefaultCellStyle.Format = "N2"
                    .Columns(nombrec).DisplayIndex = i
                    i += 1
                End With
            End If

        Next
        dgvD.Columns("total").DisplayIndex = i
        If dgvD IsNot Nothing AndAlso tbData.Rows.Count > 0 Then
            dgvD.Rows(tbData.Rows.Count - 1).ReadOnly = True
            dgvD.Rows(tbData.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
        End If


    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim tbTransac As DataTable
        Dim transac As String = ""

        Dim valor, cantidad As Decimal
        Dim tiponom As String = cmbTipo.SelectedValue
        Dim mes As Int16 = cmbMes.SelectedValue
        Dim año As Int16 = CInt(TextAño.Text)
        Dim fechaf As DateTime
        Dim fechai As DateTime = New DateTime(año, mes, 1)
        If (cmbMes.SelectedValue = 12) Then
            fechaf = New DateTime(año, 12, 31)
        Else
            fechaf = New DateTime(año, mes + 1, 1).AddDays(-1)
        End If


        Dim resultado As Boolean = True
        tbTransac = ctrTipoTran.GetTransaccionesNomina(empresa, cmbTipo.SelectedValue)
        If MsgBox("Desea guardar los cambios", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            pgBarra.Maximum = tbData.Rows.Count
            For Each fila As DataRow In tbData.Rows
                pgBarra.PerformStep()
                If fila.RowState = DataRowState.Modified Then
                    For Each dr As DataRow In tbTransac.Rows
                        If tbData.Columns.Contains($"transac-v-{dr("transac")}") AndAlso tbData.Columns.Contains($"transac-c-{dr("transac")}") Then
                            valor = fila($"transac-v-{dr("transac")}")
                            cantidad = fila($"transac-c-{dr("transac")}")
                            If valor > 0 Then
                                resultado = resultado And ctrNominas.UpdateValorNominas(empresa, tiponom, mes, año, dr("transac"), fila("empleado"), fila("contrato"), valor, cantidad, fechai, fechaf)
                            Else
                                resultado = resultado And ctrNominas.DeleteNominas(empresa, tiponom, mes, año, dr("transac"), fila("empleado"), fila("contrato"), valor, cantidad)
                            End If
                        End If
                    Next

                End If
            Next
        End If
        If resultado Then
            MsgBox("Todos los registros se ejecutaron")
        Else
            MsgBox("puede ser que unos no")
        End If

    End Sub

    Private Sub dgvData_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellValueChanged
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 And Not dgvData.DataSource Is Nothing Then
            If (dgvData.Columns(e.ColumnIndex).Name.Contains("transac-v")) Then
                Dim ncol As String = dgvData.Columns(e.ColumnIndex).Name
                Dim totalC As Decimal = 0
                totalC = (From a In tbData.AsEnumerable()
                          Where a.Field(Of Int32)("empleado") <> 0
                          Select a.Field(Of Decimal)(ncol)).Sum()
                tbData.Rows(tbData.Rows.Count - 1)(ncol) = totalC
                Dim fila As DataRow = tbData.Rows(e.RowIndex)
                totalC = 0
                For Each dr As DataRow In tbTransac.Rows
                    If (dr("tipomov") = "I") Then
                        totalC += fila($"transac-v-{dr("transac")}")
                    ElseIf dr("tipomov") = "D" Then
                        totalC += -fila($"transac-v-{dr("transac")}")
                    End If
                Next
                fila("total") = totalC
                totalC = (From a In tbData.AsEnumerable()
                          Where a.Field(Of Int32)("empleado") <> 0
                          Select a.Field(Of Decimal)("total")).Sum()
                tbData.Rows(tbData.Rows.Count - 1)("total") = totalC

                fila.EndEdit()
            End If
        End If

    End Sub

    Private Sub cklbTipoPersonal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoA.SelectedIndexChanged
        If cmbTipoA.SelectedIndex = 0 Then
            es_consulta(True)
            consulta = True
        Else
            es_consulta(False)
            consulta = False
        End If
    End Sub

    Private Sub es_consulta(valor As Boolean)
        cklbTipoPersonal.Visible = valor
        rbTodos.Visible = valor
        rbValores.Visible = valor
        rbCantidad.Visible = valor
        btnExcel.Visible = valor
        btnGuardar.Visible = Not valor
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If dgvData.DataSource IsNot Nothing Then
            Dim tbData As DataTable = dgvData.DataSource
            Dim len_abc As Int16 = 26

            tbData.TableName = "Consulta"

            Dim excelFileName As String = Path.GetRandomFileName()

            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            saveFileDialog.Title = "Guardar archivo de Excel"

            ' Añadir la extensión .xlsx al nombre del archivo
            Dim excelFilePath As String '"Temp-" & excelFileName & ".xlsx"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                excelFilePath = saveFileDialog.FileName

                Using workbook As New ClosedXML.Excel.XLWorkbook()

                    ' Crear una hoja de cálculo
                    Dim worksheet = workbook.AddWorksheet(tbData)
                    Dim i As Int32 = 0
                    For Each fila As DataColumn In tbData.Columns
                        If dgvData.Columns.Contains(fila.ColumnName) Then
                            Dim colN As String = ExcelUtil.get_columna(i)
                            worksheet.Cell(colN + "1").Value = dgvData.Columns(fila.ColumnName).HeaderText
                        End If
                        i += 1
                    Next


                    ' Guardar el archivo de Excel
                    workbook.SaveAs(excelFilePath)
                    Process.Start(excelFilePath)
                End Using

            End If


        End If
    End Sub
End Class