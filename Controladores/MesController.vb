Imports System.Collections.Generic
Imports Dapper
Imports System.Data.SqlClient
Imports NOMINA.Entidades

Public Class MesController
    Dim cadena As String = ""
    Private con As SqlConnection

    Sub New(ByVal conexion As String)
        con = New SqlConnection(conexion)
    End Sub

    Public Function GetMeses() As IEnumerable(Of Mes)
        Dim lista As New List(Of Mes)
        cadena = "select mes, nombre from meses order by mes"
        'Using co As New SqlConnection(conexion)
        '    co.Open()
        lista = con.Query(Of Mes)(cadena).ToList()
        '    co.Close()
        'End Using
        Return lista
    End Function

    Public Sub FillComboMes(ByRef cmb As ComboBox, Optional blank As Boolean = True)
        Dim lista As List(Of Mes) = Me.GetMeses()
        If blank Then
            lista.Add(New Mes With {.mes = 0, .nombre = ""})
        End If
        If Not lista Is Nothing Then
            cmb.DataSource = lista
            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "mes"
        End If

    End Sub


    Public Function GetNombreMes(mes As Short) As String
        Dim elemento As String = ""
        cadena = "select nombre from meses where mes=@mes order by mes"
        'Using co As New SqlConnection(conexion)
        '    co.Open()
        elemento = con.Query(Of String)(cadena, New With {.mes = mes}).FirstOrDefault()
        '    co.Close()
        'End Using
        Return elemento
    End Function


    Public Function GetMesesDic() As Dictionary(Of Int32, String)
        Dim listaDic As New Dictionary(Of Int32, String)
        cadena = "select mes, nombre from meses order by mes"
        'Using co As New SqlConnection(conexion)
        '    co.Open()
        listaDic = con.Query(Of Mes)(cadena).ToDictionary(Of Int32, String)(Function(x) x.mes, Function(x) x.nombre)
        '    co.Close()
        'End Using
        Return listaDic
    End Function


End Class
