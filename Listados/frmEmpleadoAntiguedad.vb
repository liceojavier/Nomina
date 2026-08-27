Public Class frmEmpleadoAntiguedad
    Dim cadena As String = ""
    Dim tbDatos As New DataTable("datos")
    Dim v As New cryEmpleadoAntiguedad
    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        Dim cadenaConsulta As String = ""


        cadena = "select * from v_nomi_empleado_antiguedad order by años desc"

        If llenaTabla(cadena, tbDatos) > 0 Then

            v.SetDataSource(tbDatos)
            crv.ReportSource = v
            crv.Refresh()
        Else
            MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub
End Class