Imports System.Data.SqlClient
Imports System.Drawing
Imports Microsoft.VisualBasic.MsgBoxResult
Imports System.Text.RegularExpressions
Imports System.Net.Dns
Imports System.Configuration
Imports ControllersERP

Module Definiciones

    'definiciones para conexión a base de datos
    '*********************************************************

    Public _conexion As String = ObtenerConnectionString("conexion")
    Public _conexionAcademia As String = ObtenerConnectionString("academiaConnectionString")
    Public _conexionSociograma As String = ObtenerConnectionString("sociogramaConnectionString")

    Public usuario As String = ""
    Public cn As New SqlConnection(_conexion)
    Public cn2 As New SqlConnection(_conexion)
    Public cnA As New SqlConnection(_conexionAcademia)
    Public cnSociograma As New SqlConnection(_conexionSociograma)
    Public FCumple, FActual As Date
    Public activo As System.Drawing.Color = Color.Lavender
    Public inactivo As System.Drawing.Color = Color.White
    Public lleno As System.Drawing.Color = Color.LightBlue
    Public errorprevio As Boolean
    'usuarios    
    Public IdRol As Int16 = 10
    Public rol As String
    Public roles As Int16
    Public cadrol As Int16 = 0
    Public roles_auth As String = ""
    Public CodigoEmpleado As Integer = 0 '1181 '693
    Public user As String = ""
    Public area As Int16 = 0

    Public codigo As Integer
    Dim exp As Regex
    Public roll As Int16 = 1
    Public empresa As Int16 = 1
    Public rolc As Int32 = 1
    Public _ServerSMTP As String ' = ConfigurationManager.AppSettings("smtpServer")
    Public _userSMTP As String '= ConfigurationManager.AppSettings("smtpUser")
    Public _passSMTP As String '= ConfigurationManager.AppSettings("smtpPassword")
    Public _esAutenticado As Boolean '= CBool(ConfigurationManager.AppSettings("smtpAuthenticated"))
    Public _puertoSMTP As Integer '= CInt(ConfigurationManager.AppSettings("smtpPort"))
    Public _sslSMTP As Boolean '= CBool(ConfigurationManager.AppSettings("smtpSSL"))
    Public _correo As String = ConfigurationManager.AppSettings("correo_electronico")
    Public _wsCliente As String = ConfigurationManager.AppSettings("wsCliente")
    Public _wsPass As String = ConfigurationManager.AppSettings("wsPass")
    Public _nombre_empresa As String = BuscaEscalar("select nombre from empresas where empresa=" & empresa)
    Public _rol_nombre As String = ""
    Public _roles_auth As String = ""
    Public _usuario As String = ""
    Public _usuario_nombre As String = ""

    Sub New()
        'Dim iniO = New DAL_Javier.ini(_conexion)
        'Singleton2.Instance.conexion = _conexion
        llena_info_correo()

        '   ControllersERP.Inicializacion.Globales.Instance.conexion = _conexion
        ' Singleton2.Instance.conexion = _conexion
        ' miSingleton.cn = New SqlConnection(miSingleton.conexion)
        'Singleton2.Instance.empresa = empresa

    End Sub

    Sub Main()
        ' Dim frm As New frmPuestos()
        '  frm.Show()

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(True)
        'Application.Run(New frmAutenticacion())
        Application.Run(New Autenticacion)
        ' Application.Run(New MenuM)

    End Sub

    Public Sub llena_info_correo()
        Dim tbInfo As New DataTable
        Dim cadena As String = "select empresa, servidor, autentica, usuario,password,puerto, ssl from correo_parametros where empresa=" & empresa
        If llenaTabla(cadena, tbInfo) > 0 Then
            _ServerSMTP = tbInfo.Rows(0)("servidor")
            _userSMTP = tbInfo.Rows(0)("usuario")
            _passSMTP = tbInfo.Rows(0)("password")
            _esAutenticado = tbInfo.Rows(0)("autentica")
            _puertoSMTP = tbInfo.Rows(0)("puerto")
            _sslSMTP = tbInfo.Rows(0)("ssl")
        End If

    End Sub


    Public Sub activa(ByVal o As Control)
        o.BackColor = activo
    End Sub

    Public Sub desactiva(ByVal o As Control)
        o.BackColor = inactivo
    End Sub


    Public Function AvisoFecha(ByVal ValorEntero As Int16) As String
        Select Case ValorEntero
            Case 0
                Return "ENTRE"
            Case 1
                Return "MAYOR"
            Case 2
                Return "MENOR"
            Case 3
                Return "MAYOR IGUAL"
            Case 4
                Return "MENOR IGUAL"
            Case 5
                Return "DIFERENTE"
        End Select
        Return ""
    End Function

    Public Sub AlinearCombos(ByVal sender As Object, ByVal combo1 As ComboBox, ByVal combo2 As ComboBox)
        Select Case sender.name
            Case combo1.Name
                If combo1.SelectedIndex <> combo2.SelectedIndex And combo1.SelectedIndex > -1 Then
                    combo2.SelectedIndex = combo1.SelectedIndex
                End If
            Case combo2.Name
                If combo2.SelectedIndex <> combo1.SelectedIndex And combo2.SelectedIndex > -1 Then
                    combo1.SelectedIndex = combo2.SelectedIndex
                End If
        End Select
    End Sub

    Public Sub ComboCambio(ByVal combo As ComboBox)
        Dim index As Integer
        Dim actual As String
        actual = combo.Text.Trim
        index = combo.FindStringExact(actual)
        If index > -1 And index < combo.Items.Count - 1 Then
            combo.SelectedIndex = index
        Else
            combo.SelectedIndex = combo.Items.Count - 1
        End If
    End Sub

    Public Sub llena_comboDoble(ByVal cadena As String, ByVal combo As ComboBox, ByVal combo2 As ComboBox)
        'llena el combo (combo) recibido con la lista generada a partir de la cadena que se mande
        'borra completamente el contenido del combo
        combo.Items.Clear()
        combo2.Items.Clear()
        'llama al procedimiento público para apertura de conexión
        abrir_conexion(cn)
        Dim com As New SqlCommand(cadena, cn)
        Dim dr As SqlDataReader
        dr = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                combo.Items.Add(dr.GetValue(0))
                combo2.Items.Add(dr.GetValue(1))
            End While
        End If
        combo.Items.Add("")
        combo2.Items.Add("")
        dr.Close()
        cn.Close()
    End Sub

    Public Sub BorraElemento(ByVal o As Object, ByVal colArg As Color)
        o.text = ""
        o.backCOlor = colArg
    End Sub

    'Public Function TotalTabla(ByVal tabla As DataTable, ByVal indice As Int16) As Decimal
    '    Dim f As DataRow
    '    Dim i As Int32
    '    Dim numT As Decimal = 0
    '    For i = 0 To tabla.Rows.Count - 1
    '        f = tabla.Rows(i)

    '        numT = numT + f.Item(indice)
    '    Next i
    '    Return numT
    'End Function

    Public Sub validatedFecha(ByVal axFecha As MaskedTextBox)
        If axFecha.Text = "  /  /" Then
            axFecha.Text = Today.ToShortDateString
        End If
    End Sub

    Public Function valorFechaHora(ByVal valDate As DateTime) As String
        Dim valRetorno As String = ""
        Try
            valRetorno = valDate.Year & "-" & valDate.Day & "-" & valDate.Month & " " & valDate.Hour & _
            ":" & valDate.Minute & ":" & valDate.Second
        Catch ex As Exception
            valRetorno = ""
        End Try
        Return valRetorno
    End Function

    Public Sub InsertBitacora(ByVal modulo As String, ByVal evento As String, ByVal descri As String)
        Dim cadena, operativo As String
        Dim longitud As Int16
        Dim strHostName As String = System.Net.Dns.GetHostName()
        operativo = Environment.OSVersion.ToString()
        longitud = Len(operativo)
        If longitud > 35 Then longitud = 34
        Dim ip As String = GetHostEntry(strHostName).AddressList(0).ToString()

        cadena = ""
        Try
            cadena = "insert into bitacora(empresa,idtipomodulo,idtipoevento,usuario,descripcion,remoteaddress,remotehost,fecha,so) " & _
                     " values(" & empresa & "," & modulo & "," & evento & ",'" & user & "','" & descri & "', '" & ip & "', '" & strHostName & "', '" & valorFechaHora(Now) & "', '" & operativo.Substring(0, longitud) & "' )"
            EjecutarQuery(cadena)
        Catch ex As Exception
            MsgBox("ERROR AL GRABAR DATOS, CONSULTE AL ADMINISTRADOR : " & cadena)
        End Try


    End Sub


    Public Function ObtenerConnectionString(ByVal nombreCadena As String) As String
        Dim ValoRetorno As String = ""
        Dim settings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(nombreCadena)
        Try

            ' Walk through the collection and return the first 
            ' connection string matching the providerName.
            If Not settings Is Nothing Then
                ValoRetorno = settings.ConnectionString
                ' ValoRetorno = modUtil.obtieneStrConnection(settings.ConnectionString)
            End If
        Catch ex As Exception

        End Try
        Return ValoRetorno
    End Function







End Module
