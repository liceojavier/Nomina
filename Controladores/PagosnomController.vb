Imports System.Collections.Generic
Imports Dapper
Imports System.Data.SqlClient
Imports NOMINA.Entidades

Public Class PagosnomController

    Dim dpara As New Dictionary(Of String, Object)
    Dim cadena As String = ""
    Dim con As SqlConnection
    Sub New(ByVal conexion As String)
        con = New SqlConnection(conexion)
    End Sub

    Public Function GetDTPagosNom() As DataTable
        Dim tabla As New DataTable
        cadena = "select empresa, tiponom, mes, año, fpago, tipoforma, docto, fecha, empleado, contrato, monto, estado, fecha, elaborado 
                from pagosnom where empresa=@empresa and empleado=@empleado and contrato=@contrato and tiponom=@tiponom
                order by año, mes"
        modelo.llenaTabla(cadena, tabla)
        Return tabla
    End Function


    Public Function GetDTPagosNom(ByVal empresa As Short, ByVal tiponom As String, ByVal empleado As Integer, ByVal contrato As Integer, Optional ByVal año As Short = 0) As DataTable
        Dim tabla As New DataTable
        Dim condi As String = ""
        dpara.Clear()

        If año > 0 Then
            dpara("año") = año
            condi = "and año=@año "
        End If

        cadena = $"select empresa, tiponom, mes, año, fpago, tipoforma, docto, fecha, empleado, contrato, monto, estado, fecha, elaborado 
                from pagosnom where empresa=@empresa and empleado=@empleado and contrato=@contrato and tiponom=@tiponom {condi}
                order by año, mes"
        dpara("empresa") = empresa
        dpara("empleado") = empleado
        dpara("contrato") = contrato
        dpara("tiponom") = tiponom
        modelo.llenaTabla(cadena, tabla, ListaParametros(dpara))
        Return tabla
    End Function

    Public Function GetPagosNom(ByVal empresa As Short, ByVal tiponom As String, ByVal empleado As Integer, ByVal contrato As Integer, Optional ByVal año As Short = 0) As IEnumerable(Of Pagosnom)
        Dim retorno As New List(Of Pagosnom)
        Dim condi As String = ""
        If año > 0 Then

            condi = "and año=@año "
        End If
        Try
            cadena = $"select empresa, tiponom, mes, año, fpago, tipoforma, docto, fecha, empleado, contrato, monto, estado, fecha, elaborado 
                from pagosnom where empresa=@empresa and empleado=@empleado and contrato=@contrato and tiponom=@tiponom {condi} 
                order by año, mes"
            retorno = con.Query(Of Pagosnom)(cadena, New With {
                  Key .empresa = empresa, Key .empleado = empleado, Key .tiponom = tiponom, Key .contrato = contrato, Key .año = año
                }
            ).ToList()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Return retorno
    End Function

    Public Function GetPagosNom(ByVal empresa As Short, ByVal tiponom As String, ByVal año As Short) As IEnumerable(Of Pagosnom)
        Dim retorno As New List(Of Pagosnom)
        Dim condi As String = ""
        If año > 0 Then

            condi = "and año=@año "
        End If
        Try
            cadena = $"select empresa, tiponom, mes, año, fpago, tipoforma, docto, fecha, empleado, contrato, monto, estado, fecha, elaborado 
                from pagosnom where empresa=@empresa and tiponom=@tiponom {condi} 
                order by año, mes"
            retorno = con.Query(Of Pagosnom)(cadena, New With {
                  Key .empresa = empresa, Key .tiponom = tiponom, Key .año = año
                }
            ).ToList()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Return retorno
    End Function


    Public Function GetDTPagosNom(ByVal empresa As Short, ByVal tiponom As String, ByVal año As Short) As DataTable
        Dim tabla As New DataTable
        Dim condi As String = ""
        dpara.Clear()

        If año > 0 Then
            condi = "and año=@año "
        End If

        cadena = $"select empresa, tiponom, mes, año, fpago, tipoforma, docto, fecha, empleado, contrato, monto, estado, fecha, elaborado 
                from pagosnom where empresa=@empresa and empleado=@empleado and contrato=@contrato and tiponom=@tiponom {condi}
                order by año, mes"
        dpara("empresa") = empresa
        dpara("año") = año
        dpara("tiponom") = tiponom
        modelo.llenaTabla(cadena, tabla, ListaParametros(dpara))
        Return tabla
    End Function


End Class
