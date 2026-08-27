Imports System.Data.SqlClient
Imports PdfiumViewer
Public Class frmVisorDocumentosEmpleados
    Private PdfViewer As PdfViewer
    Dim lpara As New Dictionary(Of String, Object)
    Dim dtEmployee As DataTable
    Dim dr As DataRow
    Dim fEmp As frmMuestra2Columnas
    Private Sub frmVisorDocumentosEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateView()
        textEmpleado.Focus()
        axFecha.Datevalue1 = Today
        axFecha.Datevalue2 = Today
    End Sub

    Private Sub btnBuscarEmpleado_Click(sender As Object, e As EventArgs) Handles btnBuscarEmpleado.Click
        lpara.Clear()
        lpara("empleado") = textEmpleado.Text
        lpara("empresa") = empresa

        dtEmployee = New DataTable()
        Dim list As New List(Of String)
        Dim finConsulta As String
        finConsulta = " and 1=1"
        finConsulta = axFecha.devuelveConsulta(finConsulta)
        Dim f As String = axFecha.Datevalue1.Date.ToShortDateString()
        If (finConsulta = $" and 1=1 and a.fecha_upload ='{f}' ") Then
            finConsulta = $" and cast( a.fecha_upload as Date) = '{f}'"
        End If

        Dim query As String = "Select a.empleado, a.tipo,a.ruta_archivo, b.nombre,a.fecha_upload from emplegen_documentos a
                               inner join emplegen_documento_tipo b on a.tipo=b.id_tipo
                               where a.empresa=@empresa"

        If (textEmpleado.Text <> "") Then
            query = query + " and a.empleado=@empleado"
        End If

        query = query + finConsulta
        llenaTabla(query, dtEmployee, ListaParametros(lpara))

        If (dtEmployee.Rows.Count() <= 0) Then
            MsgBox("NO HAY DATOS DE ACTUALIZACION", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If

        dgData2.Rows.Clear()
        For Each item As DataRow In dtEmployee.Rows
            dgData2.Rows.Add(
            item("empleado").ToString(),
            item("tipo").ToString(),
            item("ruta_archivo").ToString(),
            item("nombre").ToString(),
            item("fecha_upload").ToString()
            )
        Next
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Int32
        Dim query As String = ""
        query = "select empleado, nombre from v_empleadosNuevo e where empresa=" & empresa & " and nombre like '%" &
        textNombreEmple.Text.Trim & "%' " &
        " and e.empleado in ( select empleado from contratos1 c1 " &
        "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) " &
        "order by nombre"
        numFilas = llenaTabla(query, dtEmployee)
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            'BorraEmpleado(True)
            textEmpleado.Clear()
        ElseIf numFilas = 1 Then
            'BorraEmpleado(True)
            dr = dtEmployee.Rows.Item(0)
            textEmpleado.Text() = dr.Item(0)
            textNombreEmple.Text = dr.Item(1)
            'TextConxContrato.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub
    Private Sub EnBuscaEmpleado()
        fEmp = New frmMuestra2Columnas
        fEmp.TopMost = True
        fEmp.inicializa(dtEmployee, "CODIGO", "NOMBRE", 0)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosEmpleados
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        ''TextConxContrato.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        dr = dtEmployee.Rows.Item(e.va2)
        textEmpleado.Text() = dr.Item(0)
        textNombreEmple.Text = dr.Item(1)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        dgData2.Rows.Clear()
        textEmpleado.Clear()
        textNombreEmple.Clear()
        textEmpleado.Focus()
        ClearControl()
        CreateView()
        axFecha.Datevalue1 = Today
        axFecha.Datevalue2 = Today
        axFecha.reiniciaControl()
    End Sub

    Private Sub dgData2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgData2.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim dgv = DirectCast(sender, DataGridView)

            If dgv.Columns(e.ColumnIndex).Name = "btnVer" Then
                'Dim empleado = dgv.Rows(e.RowIndex).Cells(0).Value.ToString()
                'MessageBox.Show("Ver detalles del empleado: " & empleado)
                Dim DocumentName As String = dgv.Rows(e.RowIndex).Cells(2).Value.ToString()
                ViewDocument(DocumentName)
            End If
        End If
    End Sub
    'AJUSTES PARA EL VISOR DE PDF

    'Creación del visor
    Private Sub CreateView()
        PdfViewer = New PdfViewer()
        PdfViewer.Dock = DockStyle.Fill
        pnlPdfViewer.Controls.Add(PdfViewer)
    End Sub

    'Limpieza del control del panel
    Private Sub ClearControl()
        pnlPdfViewer.Controls.Clear()
        PdfViewer = Nothing
    End Sub

    Private Sub ViewDocument(DocumentName As String)
        Try
            ' Cargar PDF
            Dim Path As String = "//saplicaciones2/" + DocumentName

            ' Cerrar documento anterior si existe
            If PdfViewer.Document IsNot Nothing Then
                PdfViewer.Document.Dispose()
                PdfViewer.Document = Nothing
            End If
            ' Cargar el nuevo PDF
            PdfViewer.Document = PdfiumViewer.PdfDocument.Load(Path)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End Try
    End Sub

    Private Sub textEmpleado_Validated(sender As Object, e As EventArgs) Handles textEmpleado.Validated
        If (textEmpleado.Text <> "") Then
            ValidaEmpleado()
        Else
            BorraEmpleado(False)
        End If
    End Sub
    Private Sub ValidaEmpleado()
        Dim query As String = ""
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=" & empresa &
                 " and empleado=" & textEmpleado.Text.Trim) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Focus()
                Exit Sub
            End If
            query = "select empleado, nombre from v_empleadosNuevo e where empresa=" & empresa &
               " and empleado=" & textEmpleado.Text.Trim & " " &
                " and e.empleado in ( select empleado from contratos1 c1 " &
                "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) "
            abrir_conexion(cn)
            cmd = New SqlCommand(query, cn)
            dr = cmd.ExecuteReader
            If dr.HasRows() Then
                BorraEmpleado(False)
                dr.Read()
                textNombreEmple.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
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

    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        If valbool = True Then
            textEmpleado.Clear()
        End If
    End Sub

    Private Sub textEmpleado_KeyDown(sender As Object, e As KeyEventArgs) Handles textEmpleado.KeyDown
        lpara.Clear()
        If e.KeyCode = Keys.Enter Then
            'e.SuppressKeyPress = True
            Dim numFilas As Int32
            Dim query As String = ""
            lpara("empleado") = textEmpleado.Text
            lpara("empresa") = empresa
            query = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa and empleado = @empleado and e.empleado in ( select empleado from contratos1 c1 
                     inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) 
                     order by nombre"
            numFilas = llenaTabla(query, dtEmployee, ListaParametros(lpara))
            If numFilas = 0 Then
                MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Clear()
            ElseIf numFilas = 1 Then
                dr = dtEmployee.Rows.Item(0)
                BorraEmpleado(True)
                textEmpleado.Text() = dr.Item("empleado")
                textNombreEmple.Text = dr.Item("nombre")
            End If
        End If
    End Sub
End Class
