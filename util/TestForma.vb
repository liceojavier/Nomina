Imports System
Imports System.Data
Imports System.Linq
Imports System.Data.DataSetExtensions
Imports ControllersERP.Excel

Public Class TestForma
    Private Sub btntest_Click(sender As Object, e As EventArgs) Handles btntest.Click


        TextValorCol.Text = ExcelUtil.get_columna(CInt(TextValor.Text))

    End Sub
End Class