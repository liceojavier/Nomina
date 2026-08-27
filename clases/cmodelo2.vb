Imports System.Data.SqlClient

Public Class cmodelo2

    Dim _con As SqlConnection
    Dim _local As String = ""




    Sub New(ByVal conexion_local As String)
        _con = New SqlConnection
        _local = conexion_local
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

        If Me.abrir_conexion(_con, _local) Then
            Try
                If _con.State = ConnectionState.Open Then
                    comando = New SqlCommand(SubCadena, _con)
                    objeto = comando.ExecuteScalar()
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Finally
                _con.Close()
            End Try
        End If



        Return objeto

        Return Nothing
    End Function


    Public Function BuscaEscalar(ByVal SubCadena As String, ByVal parametros As List(Of SqlParameter)) As Object
        'Devuelve el resultado de una consulta a la base de datos cuando es un escalar(un solo dato)
        Dim objeto As Object = 0
        Dim comando As SqlCommand

        If abrir_conexion(_con, _local) Then
            Try
                If _con.State = ConnectionState.Open Then
                    comando = New SqlCommand(SubCadena, _con)
                    comando.Parameters.AddRange(parametros.ToArray())
                    objeto = comando.ExecuteScalar()
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Finally
                _con.Close()
            End Try
        End If


        Return objeto
    End Function


    Public Function llenaTabla(ByVal subCadena As String) As DataTable
        'llena una tabla(nombreTabla) desde cualquier formulario o modulo

        Dim da As SqlDataAdapter
        Dim comando As SqlCommand
        Dim nombreTabla As New DataTable()
        If abrir_conexion(_con, _local) Then
            Try
                If _con.State = ConnectionState.Open Then
                    comando = New SqlCommand(subCadena, _con)
                    da = New SqlDataAdapter(comando)
                    da.Fill(nombreTabla)

                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Finally
                _con.Close()
            End Try

        End If
        If nombreTabla.Rows.Count = 0 AndAlso nombreTabla.Columns.Count = 0 Then
            Return Nothing
        Else
            Return nombreTabla
        End If

    End Function

    Public Function llenaTabla(ByVal subCadena As String, ByVal parametros As List(Of SqlParameter)) As DataTable
        'llena una tabla(nombreTabla) desde cualquier formulario o modulo

        Dim da As SqlDataAdapter
        Dim comando As SqlCommand
        Dim nombreTabla As New DataTable()
        If abrir_conexion(_con, _local) Then
            Try
                If _con.State = ConnectionState.Open Then
                    comando = New SqlCommand(subCadena, _con)
                    da = New SqlDataAdapter(comando)
                    comando.Parameters.AddRange(parametros.ToArray())
                    da.Fill(nombreTabla)

                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Finally
                _con.Close()
            End Try

        End If
        If nombreTabla.Rows.Count = 0 AndAlso nombreTabla.Columns.Count = 0 Then
            Return Nothing
        Else
            Return nombreTabla
        End If
    End Function




    Public Function EjecutarNonQuery(ByVal subCadena As String) As Boolean
        Dim valoRetorno As Boolean = False
        Dim comando As SqlCommand
        If abrir_conexion(_con, _local) Then
            Try
                If _con.State = ConnectionState.Open Then
                    comando = New SqlCommand(subCadena, _con)
                    comando.ExecuteNonQuery()
                    valoRetorno = True
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Finally
                _con.Close()
            End Try
        End If


        Return valoRetorno
    End Function

    Public Function EjecutarNonQuery(ByVal subCadena As String, ByVal parametros As List(Of SqlParameter)) As Boolean
        Dim valoRetorno As Boolean = False
        Dim comando As SqlCommand
        If abrir_conexion(_con, _local) Then
            Try
                If _con.State = ConnectionState.Open Then
                    comando = New SqlCommand(subCadena, _con)
                    comando.Parameters.AddRange(parametros.ToArray())
                    comando.ExecuteNonQuery()
                    valoRetorno = True
                Else
                    MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Finally
                _con.Close()
            End Try

        End If

        Return valoRetorno
    End Function








End Class
