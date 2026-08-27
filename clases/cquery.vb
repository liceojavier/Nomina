Imports System.Data.SqlClient
Imports System.Configuration
Imports NOMINA.My.MySettings
Imports System.Collections.Generic


Public Class cquery

    Dim _con_string As String = ""



    Sub New(ByVal conexion_local As String)
        _con_string = conexion_local
    End Sub



    Public Function BuscaEscalar(ByVal SubCadena As String) As Object
        'Devuelve el resultado de una consulta a la base de datos cuando es un escalar(un solo dato)
        Dim objeto As Object = 0
        Dim comando As SqlCommand

        Using con As New SqlConnection(_con_string)
            Try
                con.Open()
                If con.State = ConnectionState.Open Then
                    comando = New SqlCommand(SubCadena, con)
                    objeto = comando.ExecuteScalar()
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                con.Close()
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
            Return objeto
        End Using
        Return Nothing
    End Function


    Public Function BuscaEscalar(ByVal SubCadena As String, ByVal parametros As List(Of SqlParameter)) As Object
        'Devuelve el resultado de una consulta a la base de datos cuando es un escalar(un solo dato)
        Dim objeto As Object = 0
        Dim comando As SqlCommand
        Using con As New SqlConnection(_con_string)
            Try
                con.Open()
                If con.State = ConnectionState.Open Then
                    comando = New SqlCommand(SubCadena, con)
                    comando.Parameters.AddRange(parametros.ToArray())
                    objeto = comando.ExecuteScalar()
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                con.Close()
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
            Return objeto
        End Using

        Return objeto
    End Function


    Public Function llenaTabla(ByVal subCadena As String, ByRef nombreTabla As DataTable) As Integer
        'llena una tabla(nombreTabla) desde cualquier formulario o modulo
        Dim numeroLineas As Integer = 0
        Dim da As SqlDataAdapter
        Dim comando As SqlCommand
        Dim nombre As String = ""

        Using con As New SqlConnection(_con_string)
            Try
                If Not nombreTabla Is Nothing Then
                    nombre = nombreTabla.TableName
                    nombreTabla = New DataTable(nombre)
                Else
                    nombreTabla = New DataTable()
                End If
                con.Open()
                If con.State = ConnectionState.Open Then
                    comando = New SqlCommand(subCadena, con)
                    da = New SqlDataAdapter(comando)
                    da.Fill(nombreTabla)
                    numeroLineas = nombreTabla.Rows.Count
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                con.Close()
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End Using
        Return numeroLineas
    End Function

    Public Function llenaTabla(ByVal subCadena As String, ByRef nombreTabla As DataTable, ByVal parametros As List(Of SqlParameter)) As Integer
        'llena una tabla(nombreTabla) desde cualquier formulario o modulo
        Dim numeroLineas As Integer = 0
        Dim da As SqlDataAdapter
        Dim comando As SqlCommand
        Dim nombre As String = ""

        Using con As New SqlConnection(_con_string)
            Try
                If Not nombreTabla Is Nothing Then
                    nombre = nombreTabla.TableName
                    nombreTabla = New DataTable(nombre)
                Else
                    nombreTabla = New DataTable()
                End If
                con.Open()
                If con.State = ConnectionState.Open Then
                    comando = New SqlCommand(subCadena, con)
                    comando.Parameters.AddRange(parametros.ToArray())
                    da = New SqlDataAdapter(comando)
                    da.Fill(nombreTabla)
                    numeroLineas = nombreTabla.Rows.Count
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                con.Close()
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End Using
        Return numeroLineas
    End Function


    Public Function EjecutarNonQuery(ByVal subCadena As String) As Boolean
        Dim valoRetorno As Boolean = False
        Dim comando As SqlCommand
        Using con As New SqlConnection(_con_string)
            Try
                con.Open()
                If con.State = ConnectionState.Open Then
                    comando = New SqlCommand(subCadena, con)
                    comando.ExecuteNonQuery()
                    valoRetorno = True
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                con.Close()
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End Using
        Return valoRetorno
    End Function

    Public Function EjecutarNonQuery(ByVal subCadena As String, ByVal parametros As List(Of SqlParameter)) As Boolean
        Dim valoRetorno As Boolean = False
        Dim comando As SqlCommand

        Using con As New SqlConnection(_con_string)
            Try
                con.Open()
                If con.State = ConnectionState.Open Then
                    comando = New SqlCommand(subCadena, con)
                    comando.Parameters.AddRange(parametros.ToArray())
                    comando.ExecuteNonQuery()
                    valoRetorno = True
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                con.Close()
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End Using
        Return valoRetorno
    End Function


End Class
