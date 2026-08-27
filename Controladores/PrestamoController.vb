Imports System.Collections.Generic
Imports Dapper
Imports System.Data.SqlClient
Imports NOMINA.Entidades


Public Class PrestamoController


    Dim cadena As String = ""
    Private con As SqlConnection

    Sub New(ByVal conexion As String)
        con = New SqlConnection(conexion)
    End Sub

    Public Function GetPrestamoEstado() As DataTable
        Dim tbEstado As New DataTable
        cadena = "select estado, nombre from prestamos_estado order by estado"
        llenaTabla(cadena, tbEstado)
        '    co.Close()
        'End Using
        Return tbEstado
    End Function


    Public Sub FillComboEstado(ByRef cmb As ComboBox, Optional blank As Boolean = True)
        Dim lista As DataTable = Me.GetPrestamoEstado()
        If blank Then
            lista.Rows.Add(-1, "")
        End If
        If Not lista Is Nothing Then
            cmb.DataSource = lista
            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "estado"
        End If

    End Sub

End Class
