Public Class frmListadoCumpleaños
    Inherits Form
    Dim cadena As String = ""
    Dim r As New cryListadoCumpleaños
    Dim tbDatos As New DataTable("datos")
    Dim lpara As New Dictionary(Of String, Object)
    Private Sub frmListadoCumpleaños_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lpara("empresa") = empresa
        TextNombEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=@empresa", ListaParametros(lpara))
        Me.crv.RefreshReport()
    End Sub

    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = txtEmpleado.Text
        Dim valor As Int32 = 0
        cadena = "select * from v_nomina_lista_cumpleañeros where empresa=@empresa"

        If cmbMes.Text <> "" Then
            valor = cmbMes.SelectedIndex + 1
            cadena += " and mes= " + (valor).ToString
        End If

        If txtEmpleado.Text <> "" Then
            cadena += " and empleado=@empleado "
        End If
        cadena += " order by nombre,dia,nomempleado"


        If llenaTabla(cadena, tbDatos, ListaParametros(lpara)) > 0 Then
            r.SetDataSource(tbDatos)
            crv.ReportSource = r
            crv.Refresh()
        Else
            MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")

        End If



    End Sub
End Class