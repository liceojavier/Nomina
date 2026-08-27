Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections.Generic
Public Class modAcademia
    Public Function ObtenerConnectionString1(ByVal nombreCadena As String) As String
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


    Public Function abrir_conexion(ByRef conexion As SqlConnection, ByVal cadenaConexion As String) As Boolean
        'verifica el estado de la conexión para su apertur
        Dim valorRetorno As Boolean = False
        'cadenaConexion = ObtenerConnectionString("connectionDatabase")
        If cadenaConexion <> "" Then
            Try
                conexion = New SqlConnection(cadenaConexion)
                If (conexion.State = ConnectionState.Closed) Then
                    conexion.Open()
                    valorRetorno = True
                ElseIf conexion.State = ConnectionState.Open Then
                    valorRetorno = True
                End If
            Catch ex As Exception
                valorRetorno = False
            End Try
        Else
            valorRetorno = False
        End If
        Return valorRetorno
    End Function



    Public Function abrir_conexion(ByRef conexion As SqlConnection) As Boolean
        'verifica el estado de la conexión para su apertur
        Dim valorRetorno As Boolean = False
        'cadenaConexion = ObtenerConnectionString("connectionDatabase")
        If _conexion <> "" Then
            Try
                conexion = New SqlConnection(_conexionAcademia)
                If (conexion.State = ConnectionState.Closed) Then
                    conexion.Open()
                    valorRetorno = True
                ElseIf conexion.State = ConnectionState.Open Then
                    valorRetorno = True
                End If
            Catch ex As Exception
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
        Try
            If abrir_conexion(cn, _conexionAcademia) Then
                comando = New SqlCommand(SubCadena, cn)
                objeto = comando.ExecuteScalar()
            Else
                MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
        Finally
            Try
                If Not cn Is Nothing Then
                    cn.Close()
                End If
            Catch ex As Exception

            End Try
        End Try
        Return objeto
    End Function


    Public Function BuscaEscalar(ByVal SubCadena As String, ByVal parametros As List(Of SqlParameter)) As Object
        'Devuelve el resultado de una consulta a la base de datos cuando es un escalar(un solo dato)
        Dim objeto As Object = 0
        Dim comando As SqlCommand
        Try
            If abrir_conexion(cn, _conexionAcademia) Then
                comando = New SqlCommand(SubCadena, cn)
                comando.Parameters.AddRange(parametros.ToArray())
                objeto = comando.ExecuteScalar()
            Else
                MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
        Finally
            Try
                If Not cn Is Nothing Then
                    cn.Close()
                End If
            Catch ex As Exception

            End Try
        End Try
        Return objeto
    End Function



    Public Function llenaTabla(ByVal subCadena As String, ByRef nombreTabla As DataTable) As Integer
        'llena una tabla(nombreTabla) desde cualquier formulario o modulo
        Dim numeroLineas As Integer = 0
        Dim da As SqlDataAdapter
        Dim nombre As String = ""
        Try
            If nombreTabla Is Nothing Then
                nombreTabla = New DataTable()
            Else
                nombre = nombreTabla.TableName
                nombreTabla = New DataTable(nombre)
            End If
            If abrir_conexion(cn, _conexionAcademia) Then
                da = New SqlDataAdapter(subCadena, cn)
                da.Fill(nombreTabla)
                numeroLineas = nombreTabla.Rows.Count
            Else
                MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
        Finally
            cn.Close()
        End Try
        Return numeroLineas
    End Function

    Public Function llenaTabla(ByVal subCadena As String, ByRef nombreTabla As DataTable, ByVal parametros As List(Of SqlParameter)) As Integer
        'llena una tabla(nombreTabla) desde cualquier formulario o modulo
        Dim numeroLineas As Integer = 0
        Dim da As SqlDataAdapter
        Dim comando As SqlCommand
        Dim nombre As String = ""
        Try
            If nombreTabla Is Nothing Then
                nombreTabla = New DataTable()
            Else
                nombre = nombreTabla.TableName
                nombreTabla = New DataTable(nombre)
            End If
            If abrir_conexion(cn, _conexionAcademia) Then
                comando = New SqlCommand(subCadena, cn)
                comando.Parameters.AddRange(parametros.ToArray())
                da = New SqlDataAdapter(comando)
                da.Fill(nombreTabla)
                numeroLineas = nombreTabla.Rows.Count
            Else
                MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
        Finally
            cn.Close()
        End Try
        Return numeroLineas
    End Function



    Public Function EjecutarQuery(ByVal subCadena As String) As Boolean
        Dim valoRetorno As Boolean = False
        Dim comando As SqlCommand
        Try
            If abrir_conexion(cn, _conexionAcademia) Then
                comando = New SqlCommand(subCadena, cn)
                comando.ExecuteNonQuery()
                valoRetorno = True
            Else
                MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
        Finally
            cn.Close()
        End Try
        Return valoRetorno
    End Function

    Public Function EjecutarQuery(ByVal subCadena As String, ByVal parametros As List(Of SqlParameter)) As Boolean
        Dim valoRetorno As Boolean = False
        Dim comando As SqlCommand
        Try
            If abrir_conexion(cn, _conexionAcademia) Then
                comando = New SqlCommand(subCadena, cn)
                comando.Parameters.AddRange(parametros.ToArray())
                comando.ExecuteNonQuery()
                valoRetorno = True
            Else
                MsgBox("Problemas con la conexión a la base de datos, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("Error: " & vbNewLine & ex.Message & vbNewLine & "Contacte a su administrador", MsgBoxStyle.Critical, "Mensaje del Sistema")
        Finally
            cn.Close()
        End Try
        Return valoRetorno
    End Function

    Public Function ListaParametros(ByVal listado As Dictionary(Of String, Object)) As List(Of SqlParameter)
        Dim list1 As New List(Of SqlParameter)
        For Each llave As KeyValuePair(Of String, Object) In listado
            list1.Add(New SqlParameter(llave.Key, llave.Value))
        Next
        Return list1
    End Function



    Public Sub llena_combo(ByVal cadena As String, ByRef combo As ComboBox, ByVal nombre_campo As String, ByVal parametros As List(Of SqlParameter))
        'llena el combo (combo) recibido con la lista generada a partir de la cadena que se mande
        'borra completamente el contenido del combo
        combo.Items.Clear()
        Dim tabla As New DataTable
        Dim da As SqlDataAdapter
        'llama al procedimiento público para apertura de conexión
        If abrir_conexion(cn, _conexionAcademia) Then
            Try
                Dim com As New SqlCommand(cadena, cn)
                com.Parameters.AddRange(parametros.ToArray())
                da = New SqlDataAdapter(com)
                da.Fill(tabla)
                For Each fila As DataRow In tabla.Rows
                    combo.Items.Add(fila.Item(nombre_campo))
                Next
            Catch ex As Exception
                MsgBox("Error del Sistema " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End If

    End Sub


    Public Sub llena_combo(ByVal cadena As String, ByRef combo As ComboBox)
        'llena el combo (combo) recibido con la lista generada a partir de la cadena que se mande
        'borra completamente el contenido del combo
        combo.Items.Clear()
        'llama al procedimiento público para apertura de conexión
        If abrir_conexion(cn, _conexionAcademia) Then
            Try
                Dim com As New SqlCommand(cadena, cn)

                Dim dr As SqlDataReader
                dr = com.ExecuteReader
                If dr.HasRows Then
                    While dr.Read
                        combo.Items.Add(dr.GetValue(0))
                    End While
                End If
                dr.Close()
                cn.Close()
            Catch ex As Exception
                MsgBox("Error del Sistema " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End If

    End Sub


    Public Sub llena_combo(ByVal cadena As String, ByRef combo As ComboBox, ByVal paramestros As List(Of SqlParameter))
        'llena el combo (combo) recibido con la lista generada a partir de la cadena que se mande
        'borra completamente el contenido del combo
        combo.Items.Clear()
        'llama al procedimiento público para apertura de conexión
        If abrir_conexion(cn, _conexionAcademia) Then
            Try
                Dim com As New SqlCommand(cadena, cn)
                com.Parameters.AddRange(paramestros.ToArray())
                Dim dr As SqlDataReader
                dr = com.ExecuteReader
                If dr.HasRows Then
                    While dr.Read
                        combo.Items.Add(dr.GetValue(0))
                    End While
                End If
                dr.Close()
                cn.Close()
            Catch ex As Exception
                MsgBox("Error del Sistema " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End If

    End Sub


    Public Sub llena_combo(ByRef combo As ComboBox, ByVal displayMember As String, ByVal valueMember As String, ByVal dt As DataTable)
        Try
            combo.DataSource = dt
            combo.DisplayMember = displayMember
            combo.ValueMember = valueMember
        Catch ex As Exception
            MsgBox("Error en la asignación del combo" + vbNewLine + ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub



End Class
