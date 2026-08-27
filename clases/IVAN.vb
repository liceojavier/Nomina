Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.IO

Module IVAN

    Public colorCons As Color = Color.LavenderBlush()
    Public ColorModi As Color = Color.LightBlue

    Dim cadena As String
    Dim TempString As String
    Dim exp As Regex
    Dim comando As SqlCommand
    Dim da As SqlDataAdapter
    Dim dr As SqlDataReader
    Dim dc As DataColumn


    Public Sub AgregarColumna(ByRef NombreTabla As DataTable, ByVal NombreColumna As String, ByVal TipoColumna As String, ByVal defaultValor As Object)
        dc = New DataColumn
        dc.ColumnName = NombreColumna
        dc.DataType = System.Type.GetType(TipoColumna)
        dc.DefaultValue = defaultValor
        NombreTabla.Columns.Add(dc)
    End Sub
 

    Public Sub validatedEntero(ByRef sender As Object, ByVal Num As Int32)
        If sender.text.trim <> "" Then
            If valida_tipo_Entero(sender.text, Num) = False Then
                sender.text = ""
            End If
        End If
    End Sub

    Public Function validetError(ByVal o As System.Object, ByVal ep As ErrorProvider) As Boolean
        'valida las entradas en los controles necesarios de texto
        Dim nombre As String
        Dim fecha As Date
        nombre = o.GetType.ToString()
        If nombre = "System.Windows.Forms.TextBox" Or nombre = "System.Windows.Forms.ComboBox" Then
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
        ElseIf nombre = "System.Windows.Forms.MaskedTextBox" Then
            exp = New Regex("^\d\d/\d\d/\d{4}$")
            If exp.IsMatch(o.Text) = False Then
                ep.SetError(o, "Se requiere que ingrese datos".ToUpper)
                Return False
            Else
                Try
                    fecha = o.Text
                    ep.SetError(o, "")
                    Return True
                Catch ex As Exception
                    o.text = ""
                    ep.SetError(o, "FORMATO DE LA FECHA NO ES VALIDO")
                    Return False
                End Try
            End If

        End If

    End Function


    Public Function validetComilla(ByVal o As System.Object, ByVal ep As ErrorProvider) As Boolean
        Dim nombre As String
        Dim fecha As Date
        'valida las entradas en los controles necesarios de texto
        nombre = o.GetType.ToString
        If nombre = "System.Windows.Forms.TextBox" Or nombre = "System.Windows.Forms.ComboBox" Then
            If validaTexto(o.text) = True Then
                ep.SetError(o, "Campo contiene caracteres invalidos")
                Return False
            Else
                ep.SetError(o, "")
                Return True
            End If
        ElseIf nombre = "System.Windows.Forms.MaskedTextBox" Then
            If o.text <> "  /  /" Then
                exp = New Regex("^\d\d/\d\d/\d{4}$")
                If exp.IsMatch(o.Text) = False Then
                    Return False
                Else
                    Try
                        fecha = o.Text
                        ep.SetError(o, "")
                        Return True
                    Catch ex As Exception
                        o.text = ""
                        ep.SetError(o, "FORMATO DE LA FECHA NO ES VALIDO")
                        Return False
                    End Try
                End If
            End If
        ElseIf nombre = "System.Windows.Forms.NumericUpDown" Then
            '  num.TextAli()

        End If
    End Function



    Public Sub validatedDecimalPreci(ByRef sender As Object, ByVal NumEn As Int32, ByVal NumDec As Int16)
        If sender.text.trim <> "" Then
            If valida_decimal_Presicion(sender, NumEn, NumDec) = False Then
                sender.text = ""
            Else
                sender.text = formato(sender.text)
            End If
        End If
    End Sub

    Public Sub EntraDecimal(ByRef sender As Object)
        If sender.text.trim <> "" Then
            Try
                TempString = sender.text
                sender.selectALl()
                sender.text = CDec(sender.text)
            Catch ex As Exception
                sender.text = TempString
            End Try
        End If
    End Sub

    Public Function validaTexto(ByVal txtBox As String) As Boolean
        exp = New Regex("^(.*(')+.*)+$")
        Return exp.IsMatch(txtBox)
    End Function

    Public Function valida_tipo_Entero(ByVal txtcaja As String, ByVal opcion As Int32) As Boolean
        Dim valido As Boolean
        exp = New Regex("^(0|[1-9]{1}\d*)$")
        valido = exp.IsMatch(txtcaja)
        If valido = True Then
            If txtcaja.Length < 10 Then
                Select Case opcion
                    Case 0
                        If CInt(txtcaja) > 0 And CInt(txtcaja) < 255 Then
                            Return True
                        Else
                            Return False
                        End If
                    Case 1
                        If CInt(txtcaja) > 0 And CInt(txtcaja) <= 32767 Then
                            Return True
                        Else
                            Return False
                        End If
                    Case 2
                        If CInt(txtcaja) > 0 And CInt(txtcaja) <= 2147483647 Then
                            Return True
                        Else
                            Return False
                        End If
                End Select
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function valida_decimal_Presicion(ByRef textCaja As TextBox, ByVal presiEntero As Int16, ByVal presiDeci As Int16) As Boolean
        'Compara expresiones regulares, validando el control "textCaja" a la cantidad de Enteros "presiEntero" y decimales "presiDeci" enviados desde el formulario
        Dim boleRe As Boolean
        exp = New Regex("^([1-9]{1}\d{0," & presiEntero - 1 & "}|0)(\.\d{0," & presiDeci & "})?$")
        boleRe = exp.IsMatch(textCaja.Text.Trim)
        If boleRe = False Or textCaja.Text = "" Then
            MsgBox("EL VALOR " & textCaja.Text.Trim & " NO POSEE LA PRESICION DE " & presiEntero & " ENTEROS Y " & presiDeci & " DECIMALES", MsgBoxStyle.Critical, "Mensaje del sistema")
            textCaja.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub borra_Mejorado(ByVal o As Control, ByVal ep1 As ErrorProvider)
        Dim i As Int16
        Dim o1 As Control
        For i = 0 To o.Controls.Count - 1
            o1 = o.Controls.Item(i)
            If UCase(Mid(o1.Name.ToString, 1, 4)) = "TEXT" Or UCase(Mid(o1.Name.ToString, 1, 3)) = "CMB" Or UCase(o1.GetType.Name) = "TEXTBOX" Or _
            UCase(o1.GetType.Name) = "COMBOBOX" Then
                o1.Text = ""
                If UCase(Mid(o1.Name.ToString, 1, 7)) = "TEXTCON" Or UCase(Mid(o1.Name.ToString, 1, 8)) = "CMBCONSU" Then
                    o1.BackColor = colorCons
                Else
                    o1.BackColor = Color.White
                End If
                ep1.SetError(o1, "")
            ElseIf o1.Name.ToString.ToUpper.Substring(0, 3) = "NUM" Then
                Dim ot As NumericUpDown
                ot = o1
                ot.Value = ot.Minimum
            ElseIf UCase(Mid(o1.Name.ToString, 1, 2)) = "GP" Or UCase(Mid(o1.Name.ToString, 1, 2)) = "PN" Or UCase(Mid(o1.Name.ToString, 1, 2)) = "TB" Or _
                UCase(o1.GetType.Name) = "PANEL" Or UCase(o1.GetType.Name) = "GROUPBOX" Then
                borra_Mejorado(o1, ep1)
            End If
        Next i
    End Sub

    Public Sub Colorea_Mejorado(ByVal o As Control, ByVal ColorArg As Color)
        Dim i As Int16
        Dim o1 As Control
        Dim textObject As TextBox
        Dim textMaskedObject As MaskedTextBox
        For i = 0 To o.Controls.Count - 1
            o1 = o.Controls.Item(i)
            If UCase(Mid(o1.Name.ToString, 1, 4)) = "TEXT" Or UCase(Mid(o1.Name.ToString, 1, 3)) = "CMB" Then
                Try
                    If o1.Name.Substring(0, 4).ToUpper = "TEXT" = True Then
                        If o1.GetType.ToString.ToUpper = "System.Windows.Forms.TextBox".ToUpper Then
                            textObject = o1
                            If textObject.ReadOnly = False Then
                                o1.BackColor = ColorArg
                            Else
                                o1.BackColor = Color.White
                            End If
                        ElseIf o1.GetType.ToString.ToUpper = "System.Windows.Forms.MaskedTextBox".ToUpper Then
                            textMaskedObject = o1
                            If textMaskedObject.ReadOnly = False Then
                                o1.BackColor = ColorArg
                            Else
                                o1.BackColor = Color.White
                            End If
                        End If
                    Else
                        o1.BackColor = ColorArg
                    End If
                Catch ex As Exception
                    o1.BackColor = ColorArg
                End Try
            ElseIf UCase(Mid(o1.Name.ToString, 1, 2)) = "GP" Or UCase(Mid(o1.Name.ToString, 1, 2)) = "PN" Or UCase(Mid(o1.Name.ToString, 1, 2)) = "TB" Then
                Colorea_Mejorado(o1, ColorArg)
            End If
        Next i
    End Sub



    'Codigo Antiguo





    Public Function BuscaEscalarBatch(ByVal SubCadena As String) As Object
        'Devuelve el resultado de una consulta a la base de datos cuando es un escalar(un solo dato)
        Dim objeto As Object
        Try
            If abrir_conexion(cn) Then

                comando = New SqlCommand(SubCadena, cn)
                objeto = comando.ExecuteScalar()
                Return objeto
            End If
        Catch ex As Exception
            MsgBox("Error del Sistema " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
        Return Nothing
    End Function

    Public Function llenaTablaBatch(ByVal subCadena As String, ByRef nombreTabla As DataTable) As Int32
        'llena una tabla(nombreTabla) desde cualquier formulario o modulo
        Try
            If abrir_conexion(cn) Then
                nombreTabla.Clear()
                nombreTabla.Columns.Clear()
                da = New SqlDataAdapter(subCadena, cn)
                da.Fill(nombreTabla)
                Return nombreTabla.Rows.Count
            End If
        Catch ex As Exception
            MsgBox("Error del Sistema " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
        Return 0
    End Function


    Public Sub EjecutarQueryBatch(ByVal subCadena As String)
        Try
            If abrir_conexion(cn) Then
                comando = New SqlCommand(subCadena, cn)
                comando.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("Error del Sistema " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Public Sub BuscaElementoCombo(ByVal tabla As DataTable, ByVal Elemento As Object, ByRef combo As ComboBox, ByVal indice As Int32, ByVal esEntero As Boolean)
        Dim i As Int32
        Dim filaTemp As DataRow
        Try
            For i = 0 To tabla.Rows.Count - 1
                filaTemp = tabla.Rows.Item(i)
                If esEntero = True Then
                    If CInt(filaTemp.Item(indice)) = CInt(Elemento) Then
                        combo.SelectedIndex = i
                        Exit Sub
                    End If
                Else
                    If CStr(filaTemp.Item(indice)).Trim = CStr(Elemento).Trim Then
                        combo.SelectedIndex = i
                        Exit Sub
                    End If
                End If
            Next i
            combo.Text = ""
        Catch ex As Exception
            combo.Text = ""
        End Try

    End Sub

    Public Sub AsignaElemento(ByRef tabla As DataTable, ByRef Elemento As String, ByRef combo As ComboBox, ByVal indice As Int32, ByVal esEntero As Boolean)
        If combo.Text.Trim <> "" Then
            Elemento = tabla.Rows.Item(combo.SelectedIndex).Item(indice)
        Else
            If esEntero Then
                Elemento = "0"
            Else
                Elemento = ""
            End If
        End If
    End Sub

    Public Function VerificacionFecha(ByVal acFecha As MaskedTextBox) As Boolean
        Dim fecha As Date
        exp = New Regex("^\d\d/\d\d/\d{4}$")
        If exp.IsMatch(acFecha.Text) = False Then
            Return False
        Else
            Try
                fecha = acFecha.Text
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If

    End Function

    Public Function Hora(ByVal acFecha As MaskedTextBox, ByRef valor1 As Int16, ByRef valor2 As Int16) As Boolean
        Dim match1 As Match
        exp = New Regex("^(\d{2}):(\d{2})$")
        If exp.IsMatch(acFecha.Text) = False Then
            Return False
        Else
            match1 = exp.Match(acFecha.Text)
            valor1 = match1.Groups(1).Value()
            valor2 = match1.Groups(2).Value()
            If valor1 >= 0 And valor1 < 23 And valor2 >= 0 And valor2 < 60 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Sub AltoGrid(ByVal TamañaFila As Int16, ByVal tabla As DataTable, ByVal TamañoMaxGrid As Int32, ByVal anchoGrid As Int32, ByVal conCaption As Boolean, ByRef dgrid As DataGridView)
        Dim contadores As Int32
        If conCaption = True Then
            contadores = 25
        Else
            contadores = 0

        End If
        contadores = contadores + 25 + (tabla.Rows.Count() * TamañaFila)
        If contadores > TamañoMaxGrid Then
            '  dgrid.Height = TamañoMaxGrid
            dgrid.Width = anchoGrid + 20
        Else
            ' dgrid.Height = contadores
            dgrid.Width = anchoGrid
        End If
    End Sub


    Public Sub AltoGridView(ByVal TamañaFila As Int16, ByVal tabla As DataTable, ByVal TamañoMaxGrid As Int32, ByVal anchoGrid As Int32, _
   ByVal dgrid As DataGridView)
        Dim contadores As Int32
        contadores = 18 + (tabla.Rows.Count() * TamañaFila) + 15
        If contadores > TamañoMaxGrid Then
            '  dgrid.Height = TamañoMaxGrid
            dgrid.Width = anchoGrid + 15
        Else
            ' dgrid.Height = contadores
            dgrid.Width = anchoGrid
        End If
    End Sub


    Public Sub GeneraConsulta(ByVal o As Control, ByRef Condiciones As String, ByVal aliasT As String)
        Dim nombreControl As String
        Dim i As Int16
        Dim o1 As Control
        For i = 0 To o.Controls.Count - 1
            o1 = o.Controls.Item(i)
            nombreControl = o1.Name
            If UCase(Mid(o1.Name.ToString, 1, 8)) = "TEXTCONS" Or UCase(Mid(o1.Name.ToString, 1, 8)) = "CMBCONSU" Then
                If o1.Text <> "" Then
                    Condiciones = Condiciones & " and " & aliasT & "." & nombreControl.Substring(8).ToLower & "='" & o1.Text.Trim & "'"
                End If
            ElseIf UCase(Mid(o1.Name.ToString, 1, 8)) = "TEXTCONX" Or UCase(Mid(o1.Name.ToString, 1, 8)) = "CMBCONSX" Then
                If o1.Text <> "" And o1.Visible = True Then
                    Condiciones = Condiciones & " and " & aliasT & "." & nombreControl.Substring(8).ToLower & "=" & o1.Text.Trim
                End If
            ElseIf UCase(Mid(o1.Name.ToString, 1, 8)) = "TEXTCONL" Then
                If o1.Text <> "" Then
                    Condiciones = Condiciones & " and " & aliasT & "." & nombreControl.Substring(8).ToLower & " like '%" & o1.Text.Trim & "%'"
                End If
            ElseIf UCase(Mid(o1.Name.ToString, 1, 2)) = "GP" Or UCase(Mid(o1.Name.ToString, 1, 2)) = "PN" Or UCase(Mid(o1.Name.ToString, 1, 2)) = "TB" Then
                GeneraConsulta(o1, Condiciones, aliasT)
            End If
        Next i
    End Sub

    Public Sub SoloLeer(ByVal o As Control, ByVal valorRead As Boolean)
        Dim nombreControl As String
        Dim i As Int16
        Dim o1 As Control
        Dim txtEscri As TextBox
        Dim numEscri As NumericUpDown
        For i = 0 To o.Controls.Count - 1
            o1 = o.Controls.Item(i)
            nombreControl = o1.Name
            If UCase(Mid(o1.Name.ToString, 1, 3)) = "TEXT" Then
                If UCase(Mid(o1.Name.ToString, 1, 8)) <> "TEXTCONS" Or UCase(Mid(o1.Name.ToString, 1, 8)) <> "TEXTCONS" Or _
                UCase(Mid(o1.Name.ToString, 1, 8)) <> "TEXTCONX" Then
                    txtEscri = o1
                    txtEscri.ReadOnly = valorRead
                End If
            ElseIf o1.Name.ToUpper.Substring(0, 3) = "NUM" Then
                numEscri = o1
                numEscri.Enabled = Not valorRead
            ElseIf UCase(Mid(o1.Name.ToString, 1, 2)) = "GP" Or UCase(Mid(o1.Name.ToString, 1, 2)) = "PN" Or UCase(Mid(o1.Name.ToString, 1, 2)) = "TB" Then
                SoloLeer(o1, valorRead)
            End If
        Next i
    End Sub

    Public Sub ConsultaReadOnly(ByVal o As Control, ByVal TipoBool As Boolean)
        Dim nombreControl As String
        Dim txtCaja As TextBox
        Dim i, j As Int16
        Dim o1, o2 As Control
        Dim nombre1, nombre2 As String
        For i = 0 To o.Controls.Count - 1
            o1 = o.Controls.Item(i)
            nombreControl = o1.Name
            If UCase(Mid(o1.Name.ToString, 1, 8)) = "TEXTCONS" Or UCase(Mid(o1.Name.ToString, 1, 8)) = "TEXTCONL" Or _
            UCase(Mid(o1.Name.ToString, 1, 3)) = "CMB" Or UCase(Mid(o1.Name.ToString, 1, 8)) = "TEXTCONX" Then
                If UCase(Mid(o1.Name.ToString, 1, 8)) = "TEXTCONS" Or UCase(Mid(o1.Name.ToString, 1, 8)) = "TEXTCONL" Or UCase(Mid(o1.Name.ToString, 1, 8)) = "TEXTCONX" Then
                    txtCaja = o1
                    txtCaja.ReadOnly = TipoBool
                Else
                    nombre1 = o1.Name
                    o1.Enabled = Not TipoBool
                    For j = 0 To o.Controls.Count - 1
                        o2 = o.Controls.Item(j)
                        nombre2 = o2.Name
                        If UCase(Mid(o2.Name.ToString, 1, 4)) = "TEXT" And UCase(Mid(o2.Name.ToString, 5)) = UCase(Mid(o1.Name.ToString, 4)) Then
                            If TipoBool = True Then
                                o2.Visible = True
                                o1.Visible = False
                            Else
                                o2.Visible = False
                                o1.Visible = True
                            End If
                        End If
                    Next j
                End If
            ElseIf UCase(Mid(o1.Name.ToString, 1, 2)) = "GP" Or UCase(Mid(o1.Name.ToString, 1, 2)) = "PN" Or UCase(Mid(o1.Name.ToString, 1, 2)) = "TB" Then
                ConsultaReadOnly(o1, TipoBool)
            End If
        Next i
    End Sub

    Public Sub mostrar_Botones(ByVal Total As Int32, ByVal actual As Int32, ByRef siguiente As Button, ByRef atras As Button)
        If (Total = 1) Then
            siguiente.Enabled = False
            atras.Enabled = False
        ElseIf Total > 1 Then
            If (actual = 0) Then
                siguiente.Enabled = True
                atras.Enabled = False
            ElseIf (actual > 0) Then
                If (actual = Total - 1) Then
                    siguiente.Enabled = False
                    atras.Enabled = True
                Else
                    siguiente.Enabled = True
                    atras.Enabled = True
                End If
            End If
        End If
    End Sub

    Public Sub MueveScroll(ByRef DgDatios As DataGridView, ByVal Maximo As Int32)
        Dim ctl As Control, scrollCtl As VScrollBar
        Dim valor As Int32
        Dim valMax As Int32
        Dim tipo As System.Type
        For Each ctl In DgDatios.Controls
            tipo = DgDatios.Controls.GetType()
            If TypeOf (ctl) Is VScrollBar Then
                scrollCtl = ctl
                With scrollCtl
                    valor = scrollCtl.Value
                    valMax = scrollCtl.Maximum
                    If .Value < .Maximum Then
                        '.Value += 1
                        'DgDatios.CurrentRowIndex += 1
                        'DgDatios.Select(DgDatios.CurrentRowIndex)
                        .Value = .Maximum
                        DgDatios.Rows(Maximo).Selected = True
                    End If
                End With
            End If
        Next
    End Sub

    Public Sub MueveScrollView(ByRef DgDatios As DataGridView, ByVal Maximo As Int32)
        Dim ctl As Control, scrollCtl As ScrollBar
        Dim valor As Int32
        Dim valMax As Int32
        Dim tipo As System.Type
        Dim i As Integer
        For i = 0 To DgDatios.Columns.Count - 1
            If DgDatios.Columns(i).Visible = True Then
                Exit For
            End If
        Next i

        For Each ctl In DgDatios.Controls
            tipo = DgDatios.Controls.GetType()
            If TypeOf (ctl) Is VScrollBar Then
                scrollCtl = ctl
                With scrollCtl
                    valor = scrollCtl.Value
                    valMax = scrollCtl.Maximum
                    If .Value < .Maximum Then
                        '.Value += 1
                        'DgDatios.CurrentRowIndex += 1
                        'DgDatios.Select(DgDatios.CurrentRowIndex)
                        .Value = .Maximum
                        DgDatios.Rows(Maximo).Selected = True
                        DgDatios.Rows(Maximo).Cells.Item(i).Selected = True
                        DgDatios.Refresh()
                    End If
                End With
            End If
        Next
    End Sub

    Public Sub MueveScrollView(ByRef DgDatios As DataGridView)
        Dim ctl As Control, scrollCtl As ScrollBar
        Dim valor As Int32
        Dim valMax As Int32
        Dim tipo As System.Type
        Dim i As Integer = 0
        For i = 0 To DgDatios.Columns.Count - 1
            If DgDatios.Columns(i).Visible = True Then
                Exit For
            End If
        Next i
        Dim Maximo As Int32 = DgDatios.Rows.Count

        If Maximo > 0 Then
            Maximo -= 1
            For Each ctl In DgDatios.Controls
                tipo = DgDatios.Controls.GetType()
                If TypeOf (ctl) Is VScrollBar Then
                    scrollCtl = ctl
                    With scrollCtl
                        valor = scrollCtl.Value
                        valMax = scrollCtl.Maximum
                        If .Value < .Maximum Then
                            '.Value += 1
                            'DgDatios.CurrentRowIndex += 1
                            'DgDatios.Select(DgDatios.CurrentRowIndex)
                            .Value = .Maximum
                            DgDatios.Rows(Maximo).Selected = True
                            DgDatios.Rows(Maximo).Cells.Item(i).Selected = True
                            DgDatios.Refresh()
                        End If
                    End With
                End If
            Next
        End If

    End Sub

    Public Function formato(ByVal numformato As Decimal) As String
        Return Format(numformato, "#,##0.00")
    End Function

    Public Sub soloNumero(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub soloNumeroDec(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Then
            If e.KeyChar = "." And sender.text.IndexOfAny(".") >= 0 Then
                e.Handled = True
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub ContextoMenuEnab(ByVal valorEnable As Boolean, ByVal valorVisible As Boolean, ByVal ctxMenu As ContextMenuStrip)
        Dim i As Int32
        For i = 0 To ctxMenu.Items.Count - 1
            ctxMenu.Items(i).Enabled = valorEnable
            ctxMenu.Items(i).Visible = valorVisible
        Next
    End Sub

    Public Sub LlenaAño(ByVal combo As ComboBox)
        Dim i As Integer
        Dim año As Integer = Today.Year
        año = año - 6
        combo.Items.Clear()
        For i = 0 To 20
            combo.Items.Add(año + i)
        Next i
        combo.Items.Add("")
    End Sub


    Public Sub EscribeEmpresa(ByRef txtNombEmpre As TextBox, ByRef txtMone As TextBox)
        Try
            cadena = "select nombre, moneda from empresas where empresa=" & empresa
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            dr = comando.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                txtNombEmpre.Text = dr.Item(0)
                txtMone.Text = dr.Item(1)
            End If
            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Error en la asignación de empresa", MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
       
    End Sub

    Public Sub EscribeEmpresa(ByRef txtNombEmpre As String, ByRef txtMone As String)
        Try
            cadena = "select nombre, moneda from empresas where empresa=" & empresa
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            dr = comando.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                txtNombEmpre = dr.Item(0)
                txtMone = dr.Item(1)
            End If
            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Error en la asignación de empresa", MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
     
    End Sub

    Public Function Rellena(ByVal Total As Integer, ByVal cade As String, ByVal esalaIzq As Boolean) As String
        Dim totalEsp, i As Integer
        Dim espacios As String
        If Total > cade.Length Then
            totalEsp = Total - cade.Length
            espacios = ""
            For i = 1 To totalEsp
                espacios = espacios & " "
            Next i
            If esalaIzq Then
                Return cade & espacios
            Else
                Return espacios & cade
            End If
        Else
            Return cade.Substring(0, Total)
        End If
        Return ""
    End Function

    Public Function Bytes2Image(ByVal bytes() As Byte) As Image
        If bytes Is Nothing Then Return Nothing
        '
        Dim ms As New MemoryStream(bytes)
        Dim bm As Bitmap = Nothing
        Try
            bm = New Bitmap(ms)
        Catch ex As Exception
        End Try
        Return bm
    End Function

    Public Function nombre_mes(ByVal mes As Int32) As String

        Select Case mes
            Case 1
                Return "Enero"
            Case 2
                Return "Febrero"
            Case 3
                Return "Marzo"
            Case 4
                Return "Abril"
            Case 5
                Return "Mayo"
            Case 6
                Return "Junio"
            Case 7
                Return "Julio"
            Case 8
                Return "Agosto"
            Case 9
                Return "Septiembre"
            Case 10
                Return "Octubre"
            Case 11
                Return "Noviembre"
            Case 12
                Return "Diciembre"
        End Select

        Return ""
    End Function




End Module
