Imports System.Collections.Generic
Imports Dapper
Imports System.Data.SqlClient
Imports NOMINA.Entidades
Imports NOMINA.dsJavierTableAdapters

Public Class TitulosController


    Dim cadena As String = ""
    Private con As SqlConnection
    Private taTitulo As dsJavierTableAdapters.titulosTableAdapter

    Sub New(ByVal conexion As String)
        con = New SqlConnection(conexion)
        taTitulo = New titulosTableAdapter()

    End Sub

    Public Function GetTitulo() As DataTable
        Return taTitulo.GetData("S")
    End Function

    Public Sub FillComboTitulo(ByRef cmb As ComboBox, Optional blank As Boolean = True)
        Dim tabla As DataTable = Me.GetTitulo()
        If blank Then
            tabla.Rows.Add("", "", "S", "")
        End If
        If Not tabla Is Nothing Then
            cmb.DataSource = tabla
            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "titulo"
        End If

    End Sub

End Class
