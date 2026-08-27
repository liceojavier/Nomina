Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMINGPRESTAMOS.VB MIEMBRO DE NOMINA.SLN                                    **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmIngPrestamos
    Dim cadena As String
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim tbTipo As New DataTable("tipo")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")
    Dim filaTemp As DataRow

    Dim WithEvents fEmp As frmMuestraCodigos
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmIngPuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        TextEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=@empresa", ListaParametros(lpara))
        cadena = "select nombre, tipopre from tiposprestamo where empresa=@empresa order by tipopre"
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cadena = "select nombre, mes from meses order by mes"
        llena_combo(cadena, cmbMes)
        cmbMes.Items.Add("")
        LlenaAño(cmbAño)
        btnLimpiar_Click(sender, e)
        textFecha.Text = Today.ToShortDateString
    End Sub


#Region "EMLEADO"


    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        TextConxContrato.Clear()
        If valbool = True Then
            textEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombreEmple.Text.Trim
        cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa and nombre like '%' + @nombre + '%' " &
                  " and e.empleado in ( select empleado from contratos1 c1 " &
                  "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) " &
                  "order by nombre"
        numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            textEmpleado.Focus()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            textEmpleado.Text() = filaTemp.Item(0)
            textNombreEmple.Text = filaTemp.Item(1)
            TextConxContrato.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text.Trim
        If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa " &
                    " and empleado=@empleado " &
                    " and e.empleado in ( select empleado from contratos1 c1 " &
                    " inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) "
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEmpleado(False)
                dr.Read()
                textNombreEmple.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                TextConxContrato.Focus()
            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraEmpleado(True)
            textEmpleado.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textEmpleado.Validated
        If textEmpleado.Text.Trim <> "" Then
            ValidaEmpleado()
        Else
            BorraEmpleado(False)
        End If
    End Sub

    Private Sub EnBuscaEmpleado()
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosEmpleados
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        TextConxContrato.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
    End Sub

#End Region


#Region "Contrato"

    Private Sub BtnContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrato.Click
        Dim Num As Int16
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        If textEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre from contratos1 c1 inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                     "where e.activo='S' and c1.empresa=@empresa and empleado=@empleado"
            Num = llenaTabla(cadena, tbContratos, ListaParametros(lpara))
            If Num = 1 Then
                TextConxContrato.Text = tbContratos.Rows(0).Item(0)
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 0)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContrato
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()
                cmbTipo.Focus()

            ElseIf Num = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            MsgBox("INGRESO PRIMERO EL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ActualizacionDatosContrato(ByVal sender As Object, ByVal e As clsActValorREvento)
        filaTemp = tbContratos.Rows(e.va2)
        TextConxContrato.Text() = filaTemp.Item(0)
    End Sub

    Private Sub TextConxContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextConxContrato.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextConxContrato_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextConxContrato.Validated
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        If TextConxContrato.Text.Trim <> "" And textEmpleado.Text.Trim <> "" Then
            cadena = "select count(*) from contratos1 c1 inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "where e.activo='S' and c1.empresa=@empresa and empleado=@empleado and contrato=@contrato"
            If BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                MsgBox("ESTE NUMERO DE CONTRATO NO EXISTE PARA ESTE EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            TextConxContrato.Clear()
        End If
    End Sub


#End Region


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lpara.Clear()
        lpara("empresa") = empresa
        TextConxNumero.Text = BuscaEscalar("select coalesce( max(prestamo),0) from prestamos1 where empresa=@empresa", ListaParametros(lpara)) + 1
        borra_Mejorado(gpDatos, ep1)
        textEmpleado.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim tipo, tipoDoc As String
        Dim fecha As Date
        lpara.Clear()
        tipoDoc = ""
        If validetError(textEmpleado, ep1) = False Or validetError(TextConxContrato, ep1) = False Or _
         validetError(cmbTipo, ep1) = False Or validetError(textFecha, ep1) = False Or _
         validetError(TextValor, ep1) = False Or validetComilla(TextObservaciones, ep1) = False Or _
         validetError(TextMeses, ep1) = False Or validetError(cmbMes, ep1) = False Or _
         validetError(cmbAño, ep1) = False Or validetError(cmbTipoDoc, ep1) = False Or _
         validetError(TextNoDocto, ep1) = False Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        fecha = textFecha.Text
        tipo = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
        Select Case cmbTipoDoc.SelectedIndex
            Case 0
                tipoDoc = "CH"
            Case 1
                tipoDoc = "O"
        End Select

        lpara("empresa") = empresa
        lpara("prestamo") = TextConxNumero.Text
        lpara("fecha") = fecha
        lpara("tipo") = tipo
        lpara("empleado") = textEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        lpara("valor") = CDec(TextValor.Text)
        lpara("meses") = TextMeses.Text
        lpara("descuento") = Decimal.Round((CDec(TextValor.Text) / CInt(TextMeses.Text)), 2)
        lpara("mesini") = cmbMes.SelectedIndex + 1
        lpara("añoini") = cmbAño.Text
        lpara("observa") = TextObservaciones.Text
        lpara("fechae") = Today
        lpara("usuario") = user
        lpara("tipodocto") = tipoDoc
        lpara("docto") = TextNoDocto.Text
        lpara("cargos") = CDec(TextValor.Text)
        If BuscaEscalar("select count(*) from prestamos1 where empresa=@empresa and prestamo=@prestamo", ListaParametros(lpara)) > 0 Then
            MsgBox("NUMERO DE PRESTAMO YA INGRESADO, INTENTELO NUEVAMENTE", MsgBoxStyle.Information, "Mensaje del Sistema")
            TextConxNumero.Text = BuscaEscalar("select coalesce( max(prestamo),0) from prestamos1 where empresa=@empresa", ListaParametros(lpara)) + 1
            Exit Sub
        End If
        Dim modelo As New cmodelo
        Try
            If MsgBox("DESEA GUARDAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                cadena = "insert into  prestamos1 (empresa,prestamo,fecha,tipopre,empleado,contrato,valor,saldo,meses,descuento,mesini,añoini,observa,estado,fechae,usuario) 
                          values (@empresa,@prestamo,@fecha,@tipo,@empleado,@contrato,@valor,@valor,@meses,@descuento,@mesini,@añoini,@observa,0,@fechae,@usuario)"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                cadena = "insert into  prestamos2 (empresa,prestamo,fecha,tipodocto,docto,cargos,abonos) 
                          values (@empresa,@prestamo,@fecha,@tipodocto,@docto,@cargos,0.00)"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                modelo.Commit()
                InsertBitacora(9, 1, Me.Text)
                btnLimpiar_Click(sender, e)
                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("ERROR EN EL INGRESO DE DATOS", MsgBoxStyle.Critical, "Mensaje del Sistema")
            modelo.RollBack()
        End Try

    End Sub

    Private Sub frmRutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
      cmbTipo.Enter, TextObservaciones.Enter, textEmpleado.Enter, textNombreEmple.Enter, _
      TextConxContrato.Enter, TextValor.Enter, TextMeses.Enter, cmbMes.Enter, cmbAño.Enter, cmbTipoDoc.Enter, TextNoDocto.Enter, _
      textFecha.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub


    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
      cmbTipo.Leave, TextObservaciones.Leave, textEmpleado.Leave, textNombreEmple.Leave, _
      TextConxContrato.Leave, TextValor.Enter, TextMeses.Leave, cmbMes.Leave, cmbAño.Leave, cmbTipoDoc.Leave, TextNoDocto.Leave, _
      textFecha.Leave
        desactiva(sender)
    End Sub

    Private Sub TextValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextValor.KeyPress
        soloNumeroDec(sender, e)
    End Sub

    Private Sub TextValor_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValor.Validated
        validatedDecimalPreci(sender, 8, 2)
    End Sub

    Private Sub TextValor_Entra(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValor.Enter
        EntraDecimal(sender)
    End Sub

    Private Sub TextEnteros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMeses.KeyPress, _
    TextNoDocto.KeyPress
        soloNumero(sender, e)
    End Sub


    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub TextNoDocto_TextChanged(sender As Object, e As EventArgs) Handles TextNoDocto.TextChanged

    End Sub
End Class