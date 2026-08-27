Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMINGSUSPENSIONES.VB MIEMBRO DE NOMINA.SLN                                 **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmIngSuspensiones
    Dim cadena As String
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim tbSuspen As New DataTable("suspension")
    Dim tbGrado As New DataTable("grados")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")
    Dim filaTemp As DataRow
    Dim lpara As New Dictionary(Of String, Object)
    Dim WithEvents fEmp As frmMuestraCodigos
    Dim WithEvents f2C As frmMuestra2Columnas

    Private Sub frmIngPuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=" & empresa)
        cadena = "select nombre, tiposus from tiposuspensiones order by tiposus"
        llena_combo(cadena, cmbTipo)
        cmbTipo.Items.Add("")
        llenaTabla(cadena, tbSuspen)
        cadena = "select nombre, grado from  gradoslesion order by grado"
        llena_combo(cadena, cmbGrado)
        cmbGrado.Items.Add("")
        llenaTabla(cadena, tbGrado)
        btnLimpiar_Click(sender, e)
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
            textEmpleado.Clear()
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
                    "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) "
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
        lpara.Clear()
        Dim Num As Int16
        If textEmpleado.Text.Trim <> "" Then
            lpara("empresa") = empresa
            lpara("empleado") = textEmpleado.Text
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
        ExistenciaSusp()
    End Sub

    Private Sub ExistenciaSusp()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        If BuscaEscalar("select count(*) from suspensiones where empresa=@empresa and empleado=@empleado and contrato=@contrato and estado=0", ListaParametros(lpara)) > 0 Then
            MsgBox("ESTE EMPLEADO TIENE SUSPENSION ACTIVA", MsgBoxStyle.Information, "Mensaje del Sistema")
            TextConxContrato.Clear()
        Else
            cmbTipo.Focus()
        End If
    End Sub

    Private Sub TextConxContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextConxContrato.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextConxContrato_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextConxContrato.Validated
        lpara.Clear()
        If TextConxContrato.Text.Trim <> "" And textEmpleado.Text.Trim <> "" Then
            lpara("empresa") = empresa
            lpara("empleado") = textEmpleado.Text
            lpara("contrato") = TextConxContrato.Text
            cadena = "select count(*) from contratos1 c1 inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "where e.activo='S' and c1.empresa=@empresa and empleado=@empleado and c1.contrato=@contrato"
            If BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                ExistenciaSusp()
            Else
                MsgBox("ESTE NUMERO DE CONTRATO NO EXISTE PARA ESTE EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            TextConxContrato.Clear()
        End If
    End Sub


#End Region




    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        TextConxNumero.Text = BuscaEscalar("select coalesce( max(numero),0) from suspensiones where empresa=" & empresa) + 1
        borra_Mejorado(gpDatos, ep1)
        textEmpleado.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        lpara.Clear()
        Dim tipo, grado As String
        Dim fechai As Date
        Dim modelo As New cmodelo
        If validetError(textEmpleado, ep1) = False Or validetError(TextConxContrato, ep1) = False Or
         validetError(cmbTipo, ep1) = False Or validetError(cmbGrado, ep1) = False Or validetComilla(TextObservaciones, ep1) = False Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        fechai = dtpFechaInicio.Value.Date
        tipo = tbSuspen.Rows(cmbTipo.SelectedIndex).Item(1)
        grado = tbGrado.Rows(cmbGrado.SelectedIndex).Item(1)
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        lpara("fechai") = fechai
        If BuscaEscalar("select count(*) from suspensiones where (estado=0 or estado=2) and empresa=@empresa and empleado=@empleado and contrato=@contrato and fechai=@fechai", ListaParametros(lpara)) > 0 Then
            MsgBox("SUSPENSION YA INGRESADA, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        lpara("numero") = TextConxNumero.Text
        If BuscaEscalar("select count(*) from suspensiones where empresa=@empresa and numero=@numero", ListaParametros(lpara)) > 0 Then
            MsgBox("CORRELATIVO DE SUSPENSION YA INGRESADO, INTENTELO NUEVAMENTE", MsgBoxStyle.Information, "Mensaje del Sistema")
            TextConxNumero.Text = BuscaEscalar("select coalesce( max(numero),0) from suspensiones where empresa=@empresa", ListaParametros(lpara)) + 1
            Exit Sub
        End If
        Try
            If MsgBox("DESEA GUARDAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                lpara.Clear()
                lpara("empresa") = empresa
                lpara("numero") = TextConxNumero.Text
                lpara("empleado") = textEmpleado.Text
                lpara("contrato") = TextConxContrato.Text
                lpara("tipo") = tipo
                lpara("grado") = grado
                lpara("fechai") = fechai
                lpara("observa") = TextObservaciones.Text
                lpara("fechae") = Today
                lpara("usuario") = user
                cadena = "insert into  suspensiones (empresa,numero,empleado,contrato,tiposus,grado,fechai,fechaf,tipoal,cantidad,valor,observa,estado,fechae,usuario) 
                          values (@empresa,@numero,@empleado,@contrato,@tipo,@grado,@fechai,'',0,0,0,@observa,0,@fechae,@usuario)"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                '  EjecutarQuery(cadena)
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
      cmbTipo.Enter, cmbGrado.Enter, TextObservaciones.Enter, textEmpleado.Enter, textNombreEmple.Enter,
      TextConxContrato.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub



    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
      cmbTipo.Leave, cmbGrado.Leave, TextObservaciones.Leave, textEmpleado.Leave, textNombreEmple.Leave,
      TextConxContrato.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

   
   
End Class