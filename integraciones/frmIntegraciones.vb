Imports NOMINA.controller
Imports NOMINA.Entidades

Public Class frmIntegraciones


    Dim ctrEmpleado As New EmpleadoController()
    Dim ctrMes As New MesController(_conexion)
    Private Sub frmIntegraciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub






    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        Dim año As Short
        Dim lmeses As New List(Of Mes)
        If Short.TryParse(TextAño.Text, año) Then
            Dim tb As DataTable

            tb = ctrEmpleado.GetEmpleadosContratoAño(empresa, año)
            lmeses = ctrMes.GetMeses()

            For Each ele As Mes In lmeses
                tb.Columns.Add(ele.mes.ToString() + "_nomina", GetType(Decimal))
                tb.Columns(ele.mes.ToString() + "_nomina").DefaultValue = 0
                tb.Columns.Add(ele.mes.ToString() + "_prov", GetType(Decimal))
                tb.Columns(ele.mes.ToString() + "_prov").DefaultValue = 0
            Next
            tb.Columns.Add("pago_prestacion", GetType(Decimal))
            tb.Columns.Add("mes_prestacion", GetType(Decimal))
            tb.Columns("pago_prestacion").DefaultValue = 0
            tb.Columns.Add("mes_prestacion").DefaultValue = 0




        Else
            MsgBox("Debe ingresar el año")
        End If



    End Sub
End Class