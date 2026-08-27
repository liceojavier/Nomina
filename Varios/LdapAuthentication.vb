Imports System.Text
Imports System.DirectoryServices
Imports System.DirectoryServices.AccountManagement


Namespace FormsAuth
    Public Class LdapAuthentication


        Dim usuario_dominio As String
        Dim passwd_dominio As String

        Dim _path As String
        Dim _filterAttribute As String

        Public Sub New(ByVal path As String)
            _path = path
        End Sub

        Public Function IsAuthenticated(ByVal domain As String, ByVal username As String, ByVal pwd As String) As Boolean

            Dim domainAndUsername As String = domain & "\" & username
            Dim entry As DirectoryEntry = New DirectoryEntry(_path, domainAndUsername, pwd)

            Try

                'Bind to the native AdsObject to force authentication.			
                Dim obj As Object = entry.NativeObject
                Dim search As DirectorySearcher = New DirectorySearcher(entry)

                search.Filter = "(SAMAccountName=" & username & ")"
                search.PropertiesToLoad.Add("cn")
                Dim result As SearchResult = search.FindOne()

                If (result Is Nothing) Then
                    Return False
                End If

                'Update the new path to the user in the directory.
                _path = result.Path
                _filterAttribute = CType(result.Properties("cn")(0), String)

            Catch ex As Exception
                MsgBox("ERROR AL AUTENTICAR USUARIO ", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Return False
            End Try
            Return True
        End Function


        Public Function GetGroups(ByVal domain As String, ByVal username As String, ByVal pwd As String) As List(Of String)
            Dim listaGrupos As New List(Of String)()
            Dim tempNum As Int32 = 0
            Dim domainAndUsername As String = domain & "\" & username
            Dim entry As DirectoryEntry = New DirectoryEntry(_path, domainAndUsername, pwd)
            Dim search As DirectorySearcher = New DirectorySearcher(entry)
            search.Filter = "(cn=" & _filterAttribute & ")"
            search.PropertiesToLoad.Add("memberOf")
            Dim groupNames As New StringBuilder
            Dim nombGrupo As String

            Try
                Dim result As SearchResult = search.FindOne()
                Dim propertyCount As Integer = result.Properties("memberOf").Count

                Dim dn As String
                Dim equalsIndex, commaIndex As Integer

                Dim propertyCounter As Integer

                For propertyCounter = 0 To propertyCount - 1
                    dn = CType(result.Properties("memberOf")(propertyCounter), String)
                    equalsIndex = dn.IndexOf("=", 1)
                    commaIndex = dn.IndexOf(",", 1)
                    If (equalsIndex = -1) Then
                        Return Nothing
                    End If
                    nombGrupo = dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1)
                    'cadena = "select coalesce( max(area), -1 ) from grupos_dominios where nombre='" & _
                    '         nombGrupo & "' and tipo='P'"
                    'tempNum = BuscaEscalar(cadena)
                    listaGrupos.Add(nombGrupo)
                Next

            Catch ex As Exception
                MsgBox("ERROR EN LA ASIGNACION DE GRUPOS, PONGASE EN CONTACTO CON SU ADMINISTRADOR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")

            End Try
            Return listaGrupos
        End Function


        Public Function obtencionPropiedad(ByVal propiedad As String, ByVal DomainUserName As String, ByVal pwd As String) As String()
            Dim i As Int32
            Dim retorno() As String
            Dim result As SearchResult
            Try
                Dim entry As DirectoryEntry = New DirectoryEntry(_path, DomainUserName, pwd)
                Dim search As DirectorySearcher = New DirectorySearcher(entry)
                search.PropertiesToLoad.Add(propiedad)
                result = search.FindOne()
                If result.Properties.Contains(propiedad) Then
                    ReDim retorno(result.Properties(propiedad).Count - 1)
                    For i = 0 To result.Properties(propiedad).Count - 1
                        retorno(i) = CType(result.Properties(propiedad)(i), String)
                    Next i
                Else
                    ReDim retorno(0)
                    retorno(0) = ""
                End If
            Catch ex As Exception
                MsgBox("NO SE PUDO OBTENER LA PROPIEDAD, VERIFIQUE", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                ReDim retorno(0)
                retorno(0) = ""
            End Try
            Return retorno
        End Function


        Public Function VerificacionGrupo(nombreg As String) As Boolean

            Try
                Using ctx As New PrincipalContext(ContextType.Domain)

                    Dim usuario As UserPrincipal = UserPrincipal.Current
                    If (usuario IsNot Nothing) Then
                        Dim grupo As GroupPrincipal = GroupPrincipal.FindByIdentity(ctx, nombreg)

                        If (grupo IsNot Nothing) Then

                            Dim existEn As Boolean = usuario.IsMemberOf(grupo)
                            Return True
                        End If
                    End If

                End Using
            Catch ex As Exception
                MsgBox("Error al verificar la aplicación de grupo en el dominio. " + vbNewLine + ex.Message, MsgBoxStyle.Critical)
            End Try
            Return False
        End Function

        Public Function GetGroupsSSO(ByVal domain As String, ByVal username As String) As List(Of String)
            Dim listaGrupos As New List(Of String)()
            Dim tempNum As Int32 = 0
            Dim entry As DirectoryEntry = New DirectoryEntry(_path)
            Dim search As DirectorySearcher = New DirectorySearcher(entry)

            search.Filter = "(sAMAccountName=" & username & ")"

            search.PropertiesToLoad.Add("memberOf")

            Dim nombGrupo As String



            Try
                Dim result As SearchResult = search.FindOne()

                ' Validar que se haya encontrado el usuario en el dominio
                If result Is Nothing Then Return Nothing

                ' Validar que el usuario pertenezca a algún grupo (tenga la propiedad memberOf)
                If Not result.Properties.Contains("memberOf") Then
                    Return listaGrupos ' Regresa el array vacío / por defecto
                End If

                Dim propertyCount As Integer = result.Properties("memberOf").Count
                Dim dn As String
                Dim equalsIndex, commaIndex As Integer

                For propertyCounter As Integer = 0 To propertyCount - 1
                    dn = CType(result.Properties("memberOf")(propertyCounter), String)
                    equalsIndex = dn.IndexOf("=", 1)
                    commaIndex = dn.IndexOf(",", 1)

                    ' Asegurar que ambos índices se encontraron para evitar errores al hacer Substring
                    If (equalsIndex <> -1 AndAlso commaIndex <> -1) Then
                        nombGrupo = dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1)

                        'If nombGrupo.ToLower() = "nomina" Then
                        '    regresar(0) = "N"
                        '    regresar(1) = "0"
                        '    Return regresar
                        'End If
                        listaGrupos.Add(nombGrupo)

                        ' Aquí iría la lógica original de tempNum y carea
                        ' If tempNum <> -1 Then ...
                    End If
                Next

            Catch ex As Exception
                MsgBox("ERROR EN LA ASIGNACION DE GRUPOS, PONGASE EN CONTACTO CON SU ADMINISTRADOR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")


            End Try

            Return listaGrupos
        End Function

        Public Function obtencionPropiedadSSO(ByVal propiedad As String, ByVal DomainUserName As String) As String()
            Dim i As Int32
            Dim retorno() As String
            Dim result As SearchResult

            Try

                Dim entry As DirectoryEntry = New DirectoryEntry(_path)
                Dim search As DirectorySearcher = New DirectorySearcher(entry)
                search.Filter = "(sAMAccountName=" & DomainUserName & ")"

                search.PropertiesToLoad.Add(propiedad)
                result = search.FindOne()

                ' Validar que se encontró el usuario
                If result Is Nothing Then
                    ReDim retorno(0)
                    retorno(0) = ""
                    Return retorno
                End If

                If result.Properties.Contains(propiedad) Then
                    ReDim retorno(result.Properties(propiedad).Count - 1)
                    For i = 0 To result.Properties(propiedad).Count - 1
                        retorno(i) = CType(result.Properties(propiedad)(i), String)
                    Next i
                Else
                    ReDim retorno(0)
                    retorno(0) = ""
                End If

            Catch ex As Exception
                MsgBox("NO SE PUDO OBTENER LA PROPIEDAD, VERIFIQUE" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                ReDim retorno(0)
                retorno(0) = ""
            End Try
            Return retorno

        End Function

    End Class



End Namespace
