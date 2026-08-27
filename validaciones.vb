Module validaciones


    Public Sub validaTextoSQL(ByRef o As Control)
        Dim i As Int16
        Dim o1 As Control
        Dim varTemp As String = ""
        For i = 0 To o.Controls.Count - 1
            o1 = o.Controls.Item(i)
            If o1.Name.Substring(0, 4).ToUpper = "TEXT" Or o1.Name.Substring(0, 3).ToUpper = "CMB" Or _
                 o1.Name.Substring(0, 3).ToUpper = "TXT" Then
                Try
                    o1.Text = o1.Text.Replace("'", "")
                    o1.Text = o1.Text.Replace("--", "-")
                    o1.Text = o1.Text.Replace(";", "")
                    o1.Text = o1.Text.Replace("xp_", "")
                    o1.Text = o1.Text.Replace("/*", "")
                    o1.Text = o1.Text.Replace("*/", "")
                Catch ex As Exception
                End Try
            ElseIf o1.Name.Substring(0, 2).ToUpper = "GP" Or o1.Name.Substring(0, 2).ToUpper = "PN" Or _
            o1.Name.Substring(0, 2).ToUpper = "TB" Or o1.Name.Substring(0, 4).ToUpper = "PAGE" Or _
            o1.Name.Substring(0, 2).ToUpper = "GB" Then
                validaTextoSQL(o1)
            End If
        Next i
    End Sub

    Public Function validaError(ByVal o As System.Object, ByRef ep As System.Object) As Boolean
        'valida las entradas en los controles necesarios de texto
        If o.Text.trim = "" Then
            ep.SetError(o, "Se requiere que ingrese datos".ToUpper)
            Return False
        Else
            If validaTexto(o.text) = True Then
                ep.setError(o, "Campo contiene caracteres invalidos")
                Return False
            Else
                ep.SetError(o, "")
                Return True
            End If
        End If
    End Function

    Public Sub Valida_Input_Batch(ByRef o As Control)
        Dim i As Int32
        Dim o1 As Control
        For i = 0 To o.Controls.Count - 1
            o1 = o.Controls.Item(i)
            If o1.GetType.ToString.ToUpper.IndexOf("TEXTBOX") >= 0 Then
                o1.Text = ValidaInput(o1.Text)
            ElseIf o1.GetType.ToString.ToUpper.IndexOf("GROUPBOX") >= 0 Or _
                o1.GetType.ToString.ToUpper.IndexOf("PANEL") >= 0 Or _
                o1.GetType.ToString.ToUpper.IndexOf("TABPAGE") >= 0 Then
                Valida_Input_Batch(o1)
            End If
        Next i
    End Sub


    Public Function ValidaInput(ByVal Valor As String) As String
        Valor = Valor.Replace("'", "")
        Valor = Valor.Replace("--", "-")
        Valor = Valor.Replace(";", "")
        Valor = Valor.Replace("/*", "")
        Valor = Valor.Replace("/*", "")
        Valor = Valor.Trim
        Return Valor
    End Function

End Module
