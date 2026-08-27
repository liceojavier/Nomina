Imports ClosedXML.Excel
Imports System.Environment
Imports System.Data
Imports System.IO

Public Class ReportePasivoLaboralXL

    Dim cadena As String = ""
    Dim lpara As New Dictionary(Of String, Object)
    Dim tbTipoPasivo As New DataTable()
    Dim tbMeses As New DataTable()
    Dim tbtransformada As New DataTable()
    Dim columnFormats As New Dictionary(Of String, String)
    Dim tbDatos As New DataTable
    Dim mes_select, taño As Int32
    Dim empleado As String
    Dim empleadocontrato As Int32
    Dim nombre As String
    Dim tmprow As DataRow
    Dim ultfecha As Date
    Dim pasivoSeleccionado As String
    Dim filas() As DataRow

    Private Sub ReportePasivoLaboral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        cadena = "select nombre,mes from meses order by mes"
        llenaTabla(cadena, tbMeses)
        cmbMes.DisplayMember = "nombre"
        cmbMes.ValueMember = "mes"
        cmbMes.DataSource = tbMeses
        'cmbMes.Items.Add("")
        txtAñoi.Text = System.DateTime.Now.Year
        txtAñof.Text = System.DateTime.Now.Year
        EscribeEmpresa(TextNombEmpresa, TextMoneEmpresa)
        cmbMes.SelectedIndex = System.DateTime.Now.Month - 1
        cadena = "select nombre, pasivo,ctagasto,por*.01 as por from pasivolab1 where empresa=@empresa"
        llenaTabla(cadena, tbTipoPasivo, ListaParametros(lpara))
        cmbTipoPasivo.DisplayMember = "nombre"
        cmbTipoPasivo.ValueMember = "pasivo"
        cmbTipoPasivo.DataSource = tbTipoPasivo
        'cmbTipoPasivo.Items.Add("")

    End Sub

    Private Function mesbyid(i As Short) As String
        Return BuscaEscalar("select nombre from meses where mes=" & i)
    End Function


    Public Sub formatoxls()
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx"
        saveFileDialog.FileName = "salida" + Now.Date.ToString("dd-mm-yyyy") + ".xlsx"
        Dim n As Int32 = 7
        Dim rutaPlantilla As String = "plantillas\Plantilla.xlsx"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Crear un nuevo libro de trabajo

            Using workbook As New XLWorkbook(rutaPlantilla)
                ' Agregar una hoja de trabajo
                Dim worksheet = workbook.Worksheet("Hoja1")
                Dim imagePath As String = "plantillas\logo2.jpg"

                Dim image = worksheet.AddPicture(imagePath) _
    .MoveTo(worksheet.Cell(2, 1))

                image.Height = 80
                image.Width = 500

                If worksheet Is Nothing Then
                    Throw New Exception("No se pudo acceder a la hoja de trabajo")
                End If

                worksheet.Cell(3, 2).Value = filas(0)("ctagasto").ToString()
                worksheet.Cell(4, 2).Value = cmbTipoPasivo.Text
                worksheet.Cell(5, 2).Value = "0.00"
                worksheet.Cell(6, 2).Value = ultfecha
                worksheet.Cell(7, 2).Value = filas(0)("por").ToString()
                ' Insertar el DataTable en la hoja de trabajo
                'worksheet.Cell(1, 1).InsertTable(tbtransformada)
                worksheet.Cell(n + 1, 1).Value = "EMPLEADO"
                worksheet.Cell(n + 1, 2).Value = "CONTRATO"
                worksheet.Cell(n + 2, 1).value = tbtransformada
                Dim usedRange = worksheet.RangeUsed()
                usedRange.Style.Font.SetFontSize(9)
                worksheet.Row(n + 1).Style.Font.SetBold(True)

                ' Columna EMPLEADO
                worksheet.Column(1).Width = 40 ' Ajusta este valor según necesites
                worksheet.Cell(n + 1, 1).Style _
    .Alignment.SetWrapText(True) _
    .Alignment.SetVertical(XLAlignmentVerticalValues.Center) _
    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)

                ' Columna CONTRATO
                worksheet.Column(2).Width = 10 ' Ajusta este valor según necesites
                worksheet.Cell(n + 1, 2).Style _
    .Alignment.SetWrapText(True) _
    .Alignment.SetVertical(XLAlignmentVerticalValues.Center) _
    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)


                For Each columna As KeyValuePair(Of String, String) In columnFormats
                    Dim columnIndex As Integer = tbtransformada.Columns.IndexOf(columna.Key) + 1
                    Dim headerCell = worksheet.Cell(n + 1, columnIndex)

                    headerCell.Value = columna.Value
                    headerCell.Style _
        .Alignment.SetWrapText(True) _
        .Alignment.SetVertical(XLAlignmentVerticalValues.Center) _
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)

                    headerCell.WorksheetRow().Height = 50
                    headerCell.WorksheetColumn().Width = 10
                Next

                ' Guardar el archivo Excel
                workbook.SaveAs(saveFileDialog.FileName)
            End Using

            MsgBox("El archivo Excel ha sido creado exitosamente.", MsgBoxStyle.Information, "Mensaje del Sistema")
        Else

            MsgBox("La operación ha sido cancelada.", MsgBoxStyle.Information, "Mensaje del sistema")
        End If


    End Sub

    Public Sub transformacion()



        tbtransformada.Columns.Add("EMPLEADO", GetType(String))
        tbtransformada.Columns.Add("CONTRATO", GetType(String))

        ' Agregar columnas para cada mes dinámicamente
        For i As Int16 = 1 To mes_select + 12 * (CInt(txtAñof.Text) - CInt(txtAñoi.Text))
            If (i Mod 12) = 0 Then
                Dim nominaColumnName As String = $"NOMINA_{mesbyid(i)}_{taño}"
                Dim provColumnName As String = $"PROV_{mesbyid(i)}_{taño}"

                columnFormats(nominaColumnName) = $"NÓMINA{NewLine}{mesbyid(i)}{NewLine}{LTrim(Str(taño))}"
                columnFormats(provColumnName) = $"PROV.{NewLine}{mesbyid(i)}{NewLine}{LTrim(Str(taño))}"

                tbtransformada.Columns.Add(nominaColumnName, GetType(Decimal))
                tbtransformada.Columns.Add(provColumnName, GetType(Decimal))
                taño = taño + 1
            Else
                Dim nominaColumnName As String = $"NOMINA_{mesbyid(i Mod 12)}_{taño}"
                Dim provColumnName As String = $"PROV_{mesbyid(i Mod 12)}_{taño}"

                columnFormats(nominaColumnName) = $"NÓMINA{NewLine}{mesbyid(i Mod 12)}{NewLine}{LTrim(Str(taño))}"
                columnFormats(provColumnName) = $"PROV.{NewLine}{mesbyid(i Mod 12)}{NewLine}{LTrim(Str(taño))}"

                tbtransformada.Columns.Add(nominaColumnName, GetType(Decimal))
                tbtransformada.Columns.Add(provColumnName, GetType(Decimal))
            End If

        Next

        pb1.Minimum = 0
        pb1.Maximum = tbDatos.Rows.Count
        pb1.Step = 1
        pb1.Value = 0

        pb1.Visible = True
        'Transformar los datos agrupando por empleado
        Dim j As Int32

        For Each empleado In tbDatos.AsEnumerable().Select(Function(row) row("empleado").ToString()).Distinct()
            Dim rows As DataRow() = tbDatos.Select("empleado = '" & empleado & "'")


            Dim newRow As DataRow = tbtransformada.NewRow()
            newRow("EMPLEADO") = If(IsDBNull(rows(0)("nombre")), String.Empty, rows(0)("nombre").ToString())
            newRow("CONTRATO") = empleado

            ' Asignar los valores del mes correspondiente
            For Each tmprow In rows
                Dim mes = tmprow("mes")
                Dim año = tmprow("año").ToString
                Dim nominaColumnName = $"NOMINA_{mesbyid(mes)}_{año}"
                Dim provColumnName = $"PROV_{mesbyid(mes)}_{año}"

                newRow(nominaColumnName) = tmprow("valor2")
                newRow(provColumnName) = tmprow("valor")
            Next

            tbtransformada.Rows.Add(newRow)
            pb1.Value = j
            j += 1
        Next
        pb1.Maximum = 0
        formatoxls()
    End Sub

    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click


        If Not validaError(txtAñoi, ep1) Or Not validaError(txtAñof, ep1) Then
            MsgBox("Ingrese los campos obligatorios", MsgBoxStyle.Information, "Mensaje del Sistema")
            Return
        End If

        If (CInt(txtAñof.Text) < CInt(txtAñoi.Text)) Then
            MsgBox("El año final debe ser mayor o igual al año inicial", MsgBoxStyle.Information, "Mensaje del Sistema")
            Return
        End If

        If (CInt(txtAñof.Text) - CInt(txtAñoi.Text)) > 5 Then
            MsgBox("Hay diferencia de más de 5 años, por favor verifique... ", MsgBoxStyle.Information, "Mensaje del Sistema")
            Return
        End If

        Try
            ultfecha = DateSerial(CInt(txtAñof.Text), cmbMes.SelectedValue + 1, 0)
            lpara.Clear()
            lpara("empresa") = empresa
            lpara("fechai") = "01/01/" & txtAñoi.Text
            lpara("fechaf") = ultfecha
            lpara("tipop") = cmbTipoPasivo.SelectedValue
            taño = CInt(txtAñoi.Text)
            mes_select = cmbMes.SelectedValue
            cadena = "select empleado as emp,ltrim(str(empleado))+'/'+ltrim(str(contrato)) as empleado,nombre,año,mes,valor2,valor from
                        (select c.empleado,c.contrato,d.apellido1+' '+d.apellido2+' '+d.nombre1+' '+d.nombre2 as nombre,c.mes,c.año,sum(c.valor) as valor2,
                        round(sum((c.valor*a.por)/100),2) as valor  from pasivolab1 a
                        inner join pasivolab2 b on a.pasivo=b.pasivo and a.empresa=b.empresa
                        inner join nominas c on b.transac=c.transac and a.empresa=c.empresa
                        inner join emplegen d on c.empleado=d.empleado and c.empresa=d.empresa
                        where a.pasivo=@tipop and c.tiponom='M' and c.fechai between @fechai and @fechaf and a.empresa=@empresa
                        group by c.mes,c.año,c.empleado,c.contrato,d.apellido1,d.apellido2,d.nombre1,d.nombre2) a order by emp,contrato,año,mes asc"

            llenaTabla(cadena, tbDatos, ListaParametros(lpara))

            If tbDatos.Rows.Count > 0 Then
                transformacion()
            End If


        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Information, "Mensaje del sistema")
            Return
        End Try


    End Sub

    Private Sub cmbTipoPasivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoPasivo.SelectedIndexChanged
        If cmbTipoPasivo.SelectedValue IsNot Nothing Then
            ' Obtener el valor seleccionado (en este caso, 'pasivo')
            pasivoSeleccionado = cmbTipoPasivo.SelectedValue.ToString()

            ' Buscar la fila en el DataTable
            filas = tbTipoPasivo.Select("pasivo = '" & pasivoSeleccionado & "'")

            If filas.Length > 0 Then
                Dim ctagasto As String = filas(0)("ctagasto").ToString()
                Dim por As String = filas(0)("por").ToString()


            End If
        End If
    End Sub
End Class