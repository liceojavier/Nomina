Imports System.Data.SqlClient
Imports System.Configuration
Imports NOMINA.My.MySettings
Imports System.Collections.Generic


Public Class cmodelo


    Dim _con As SqlConnection
    Dim _transac As SqlTransaction
    Dim _error As Boolean


    Sub New()
        _error = False
        _con = New SqlConnection
        If abrir_conexion(_con, _conexion) Then
            _transac = _con.BeginTransaction
        End If
    End Sub


    Sub New(ByVal conexion_local As String)
        _error = False
        _con = New SqlConnection
        If abrir_conexion(_con, conexion_local) Then
            _transac = _con.BeginTransaction
        End If

    End Sub

    Private Function ObtenerConnectionString(ByVal nombreCadena As String) As String
        Dim ValoRetorno As String = ""
        'Dim settings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(nombreCadena)
        Try
            ' Walk through the collection and return the first 
            ' connection string matching the providerName.
            '   If Not settings Is Nothing Then
            'ValoRetorno = settings.ConnectionString
            ' ValoRetorno = modUtil.obtieneStrConnection(settings.ConnectionString)
            ' End If
        Catch ex As Exception
            MsgBox("Error al abrir la base de datos")

            Return 0

        End Try
        Return ValoRetorno
    End Function


    Private Function abrir_conexion(ByRef conexion As SqlConnection, ByVal cadenaConexion As String) As Boolean
        'verifica el estado de la conexión para su apertur

        Dim valorRetorno As Boolean = False
        'cadenaConexion = ObtenerConnectionString("connectionDatabase")
        If cadenaConexion <> "" Then
            conexion.ConnectionString = cadenaConexion
            Try
                If (conexion.State = ConnectionState.Closed) Then
                    conexion.Open()
                    valorRetorno = True
                ElseIf conexion.State = ConnectionState.Open Then
                    valorRetorno = True
                End If
            Catch ex As Exception
                MsgBox("Error al abrir la base de datos " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                valorRetorno = False
                _error = True
            End Try
        Else
            valorRetorno = False
        End If
        Return valorRetorno
    End Function


    Public Function BuscaEscalar(ByVal SubCadena As String) As Object
        'Devuelve el resultado de una consulta a la base de datos cuando es un escalar(un solo dato)
        Dim objeto As Object = 0
        Dim comando As SqlCommand
        If Not _error Then
            Try
                If _con.State = ConnectionState.Open Then
                    comando = New SqlCommand(SubCadena, _con, _transac)
                    objeto = comando.ExecuteScalar()
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                _transac.Rollback()
                _con.Close()
                _error = True
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
            Return objeto
        End If
        Return Nothing
    End Function


    Public Function BuscaEscalar(ByVal SubCadena As String, ByVal parametros As List(Of SqlParameter)) As Object
        'Devuelve el resultado de una consulta a la base de datos cuando es un escalar(un solo dato)
        Dim objeto As Object = 0
        Dim comando As SqlCommand
        If Not _error Then
            Try
                If _con.State = ConnectionState.Open Then
                    comando = New SqlCommand(SubCadena, _con, _transac)
                    comando.Parameters.AddRange(parametros.ToArray())
                    objeto = comando.ExecuteScalar()
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                _transac.Rollback()
                _con.Close()
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
                _error = True
            End Try
        End If
        Return objeto
    End Function


    Public Function llenaTabla(ByVal subCadena As String, ByRef nombreTabla As DataTable) As Integer
        'llena una tabla(nombreTabla) desde cualquier formulario o modulo
        Dim numeroLineas As Integer = 0
        Dim da As SqlDataAdapter
        Dim comando As SqlCommand
        Dim nombre As String = ""
        If Not _error Then
            Try
                If Not nombreTabla Is Nothing Then
                    nombre = nombreTabla.TableName
                    nombreTabla = New DataTable(nombre)
                Else
                    nombreTabla = New DataTable()
                End If
                If _con.State = ConnectionState.Open Then
                    comando = New SqlCommand(subCadena, _con, _transac)
                    da = New SqlDataAdapter(comando)
                    da.Fill(nombreTabla)
                    numeroLineas = nombreTabla.Rows.Count
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                _transac.Rollback()
                _con.Close()
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
                _error = True
            End Try
        End If

        Return numeroLineas
    End Function

    Public Function llenaTabla(ByVal subCadena As String, ByRef nombreTabla As DataTable, ByVal parametros As List(Of SqlParameter)) As Integer
        'llena una tabla(nombreTabla) desde cualquier formulario o modulo
        Dim numeroLineas As Integer = 0
        Dim da As SqlDataAdapter
        Dim comando As SqlCommand
        Dim nombre As String = ""
        If Not _error Then
            Try
                If Not nombreTabla Is Nothing Then
                    nombre = nombreTabla.TableName
                    nombreTabla = New DataTable(nombre)
                Else
                    nombreTabla = New DataTable()
                End If
                If _con.State = ConnectionState.Open Then
                    comando = New SqlCommand(subCadena, _con, _transac)
                    comando.Parameters.AddRange(parametros.ToArray())
                    da = New SqlDataAdapter(comando)
                    da.Fill(nombreTabla)
                    numeroLineas = nombreTabla.Rows.Count
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                _transac.Rollback()
                _con.Close()
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
                _error = True
            End Try
            Return numeroLineas
        End If


    End Function


    Public Function EjecutarNonQuery(ByVal subCadena As String) As Boolean
        Dim valoRetorno As Boolean = False
        Dim comando As SqlCommand
        If Not _error Then
            Try
                If _con.State = ConnectionState.Open Then
                    comando = New SqlCommand(subCadena, _con, _transac)
                    comando.ExecuteNonQuery()
                    valoRetorno = True
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                _transac.Rollback()
                _con.Close()
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
                _error = True
            End Try
        End If
        Return valoRetorno
    End Function

    Public Function EjecutarNonQuery(ByVal subCadena As String, ByVal parametros As List(Of SqlParameter)) As Boolean
        Dim valoRetorno As Boolean = False
        Dim comando As SqlCommand
        If Not _error Then
            Try
                If _con.State = ConnectionState.Open Then
                    comando = New SqlCommand(subCadena, _con, _transac)
                    comando.Parameters.AddRange(parametros.ToArray())
                    comando.ExecuteNonQuery()
                    valoRetorno = True
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                _transac.Rollback()
                _con.Close()
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
                _error = True
            End Try
        End If
        Return valoRetorno
    End Function

    Public Function Commit() As Boolean
        Dim valorR As Boolean = False
        If Not _error Then
            Try
                _transac.Commit()
                _con.Close()
                valorR = True
            Catch ex As Exception
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End If
        Return valorR
    End Function


    Public Function RollBack() As Boolean

        Try
            _transac.Rollback()
            _con.Close()
            Return True
        Catch ex As Exception
            MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Return False
        End Try
    End Function



End Class
