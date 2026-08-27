Imports ControllersERP.Nominas
Imports ControllersERP.General

Public Class frmListadoSuspensiones

    Dim lpara As New Dictionary(Of String, Object)
    Dim cadena As String = ""
    Dim ctrSus As New SuspensionController()
    Dim ctrExcel As New ExcelController()
    ' Dim ctrExcel As New 
    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        Dim condi As String = ""
        lpara.Clear()
        Dim tbData As New DataTable()

        If cmbEstado.Text.Trim <> "" Then
            condi += " and a.estado=@estado"
            lpara("estado") = cmbEstado.SelectedValue
        End If
        lpara("empresa") = empresa
        lpara("fechai") = dpFechaI.Value.Date
        lpara("fechaf") = dpFechaf.Value.Date


        cadena = $"select a.numero, a.fechai, a.fechaf, a.empleado, a.contrato, b.apellido1 + ' ' + b.apellido2 + ' ' + b.nombre1 + ' ' + b.nombre2 as nombre_empleado,
                cantidad, valor, a.estado, c.nombre as nombre_estado, a.fechae as fecha_estado
                 from suspensiones a
                inner join emplegen b on a.empresa=b.empresa and a.empleado=b.empleado
                inner join suspensiones_estado c on a.estado=c.estado
                where a.empresa=@empresa {condi} and  a.fechai between @fechai and @fechaf
                order by a.fechai"
        If llenaTabla(cadena, tbData, ListaParametros(lpara)) > 0 Then
            If sfdArchivo.ShowDialog() = DialogResult.OK Then
                ctrExcel.CreaArchivo(sfdArchivo.FileName, tbData)
            End If
        Else
            MsgBox("No existen registros para generar este reporte.", MsgBoxStyle.Exclamation, "Mensaje del sistema")
        End If


    End Sub

    Private Sub frmListadoSuspensiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tbEstado As New DataTable
        lpara.Clear()
        lpara("empresa") = empresa
        TextNombEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=@empresa", ListaParametros(lpara))
        ctrSus.FillComboEstado(cmbEstado, True)
        cmbTipo.SelectedIndex = 0
        dpFechaI.Value = New DateTime(Today.Year, 1, 1)
        dpFechaf.Value = New DateTime(Today.Year, 12, 31)
        limpiar()
    End Sub

    Private Sub limpiar()
        cmbEstado.Text = ""
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
End Class