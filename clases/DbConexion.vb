Imports System.Data.SqlClient

Public Class DbConexion

    Private sqlConexion As New SqlClient.SqlConnection(Definiciones._conexion)

    Sub New()

    End Sub

    Sub New(ByVal conexion_str As String)
        sqlConexion = New SqlClient.SqlConnection(conexion_str)
    End Sub


    Private Property Get_Conexion() As SqlClient.SqlConnection
        Get
            Return Me.sqlConexion
        End Get
        Set(ByVal value As SqlClient.SqlConnection)
            Me.sqlConexion = value
        End Set
    End Property

    Public Function hacerConsulta(ByVal consulta As String, ByVal parametros As List(Of SqlParameter)) As DataSet
        Dim ds As New DataSet
        Try
            Dim da As New SqlDataAdapter(consulta, Get_Conexion)
            da.SelectCommand.Parameters.AddRange(parametros.ToArray())
            da.Fill(ds, "Consulta")
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Consulta")
        End Try
        Return ds
    End Function

    Public Function Hacer_Consulta(ByVal consulta As String) As DataSet
        'Creacion de Dataset
        Dim ds As New DataSet
        Try
            Dim da As New _
                SqlClient.SqlDataAdapter(consulta, Get_Conexion)
            da.Fill(ds, "Consulta")
        Catch ex As Exception
            MsgBox("Error en : " & ex.Message, MsgBoxStyle.Critical, "Consulta")
        End Try
        Return ds
    End Function

    Public Function ejecutarSentencia(ByRef sentencia As String, ByVal parametro As List(Of SqlParameter)) As Boolean
        Dim cmd As New SqlCommand(sentencia, Get_Conexion)
        cmd.Parameters.AddRange(parametro.ToArray())
        Dim val As Boolean
        Try
            Get_Conexion.Open()
            cmd.ExecuteNonQuery()
            Get_Conexion.Close()
            val = True
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "SQL Sentencia")
            val = False
        Finally
            Get_Conexion.Close()
        End Try
        Return val
    End Function



    Public Function Ejecutar_Sentencia(ByVal sentencia As String) As Boolean
        Dim cmd As New SqlClient.SqlCommand(sentencia, Get_Conexion)
        Dim val As Boolean
        Try
            Get_Conexion.Open()
            cmd.ExecuteNonQuery()
            Get_Conexion.Close()
            val = True
        Catch ex As Exception
            MsgBox("Error en :" & ex.Message, MsgBoxStyle.Critical, "SQL Sentencia")
            val = False
        Finally
            Get_Conexion.Close()
        End Try
        Return val
    End Function

    Public Function regresaEscalar(ByVal sentencia As String, ByVal parametro As List(Of SqlParameter)) As Object
        Dim cmd As New SqlClient.SqlCommand(sentencia, Get_Conexion)
        cmd.Parameters.AddRange(parametro.ToArray())
        Dim obj As Object = Nothing
        Try
            Get_Conexion.Open()
            obj = cmd.ExecuteScalar
            Get_Conexion.Close()
        Catch ex As Exception
            MsgBox("Error en :" & ex.Message, MsgBoxStyle.Critical, "SQL Sentencia")
        Finally
            Get_Conexion.Close()
        End Try
        Return obj
    End Function

    Public Function Regresa_Escalar(ByVal sentencia As String) As Object
        Dim cmd As New SqlClient.SqlCommand(sentencia, Get_Conexion)
        Dim obj As Object = Nothing
        Try
            Get_Conexion.Open()
            obj = cmd.ExecuteScalar
            Get_Conexion.Close()
        Catch ex As Exception
            MsgBox("Error en :" & ex.Message, MsgBoxStyle.Critical, "SQL Sentencia")
        Finally
            Get_Conexion.Close()
        End Try
        Return obj
    End Function

End Class
