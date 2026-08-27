Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMLISTMOVIFIJOS.VB MIEMBRO DE NOMINA.SLN                                   **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmListMoviFijos
    Dim cadena As String
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")
    Dim tbDatos As New DataTable("datos")
    Dim filaTemp As DataRow
    Dim opc, IndiceTransac As Integer
    Dim fechaIL As Date
    Dim WithEvents fEmp As frmMuestra2Columnas
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim v As New cryListaMoviFijos

    Private Sub frmIngPuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=" & empresa & " and nombre like '%" & _
                  textNombreEmple.Text.Trim & "%' " & _
                 " and e.empleado in ( select empleado from contratos1 c1 " & _
                 "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) " & _
                 " order by nombre"
        numFilas = llenaTabla(cadena, tbEmpleado)
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
        If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=" & empresa & _
                 " and empleado=" & textEmpleado.Text.Trim) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=" & empresa & _
                " and empleado=" & textEmpleado.Text.Trim & " " & _
                 " and e.empleado in ( select empleado from contratos1 c1 " & _
                 "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) "
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
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
        fEmp = New frmMuestra2Columnas
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado, "CODIGO", "NOMBRE", 0)
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
        If textEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre, c1.fechai from contratos1 c1 inner join " & _
                     "empestados e on e.estado=c1.estado and e.empresa=c1.empresa " & _
                     "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " & _
                     "where e.activo='S' and c1.empresa=" & empresa & " and empleado=" & textEmpleado.Text
            Num = llenaTabla(cadena, tbContratos)
            If Num = 1 Then
                TextConxContrato.Text = tbContratos.Rows(0).Item(0)
                fechaIL = tbContratos.Rows(0).Item(2)
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 1)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContrato
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()
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
        fechaIL = filaTemp.Item(2)
    End Sub

    Private Sub TextConxContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextConxContrato.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextConxContrato_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextConxContrato.Validated
        Dim tbTem As New DataTable("temp")
        If TextConxContrato.Text.Trim <> "" And textEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre, c1.fechai from contratos1 c1 inner join " & _
                       "empestados e on e.estado=c1.estado and e.empresa=c1.empresa " & _
                       "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " & _
                       "where e.activo='S' and c1.empresa=" & empresa & " and empleado=" & textEmpleado.Text
            If llenaTabla(cadena, tbTem) = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
            fechaIL = tbTem.Rows(0).Item(2)
        Else
            TextConxContrato.Clear()
        End If
    End Sub


#End Region

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        borra_Mejorado(gpChofer, ep1)
        borra_Mejorado(gpContrato, ep1)
        borra_Mejorado(gpFecha, ep1)
        crv.ReportSource = Nothing
        textEmpleado.Focus()
    End Sub


   

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim fechaI, fechaF As Date
        fechaI = dtpFechaI.Value.Date
        fechaF = dtpFechaF.Value.Date
        If fechaI < fechaIL Then
            MsgBox("FECHA INICIAL DEBE SER IGUAL O MAYOR A " & fechaIL.ToShortDateString & " QUE ES LA FECHA INICIAL DEL CONTRATO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        If fechaI > fechaF Then
            MsgBox("FECHA INICIAL DEBE SER MENOR QUE LA FECHA FINAL", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        cadena = "select * from v_Movifijos where empresa=" & empresa & " and empleado=" & textEmpleado.Text & " and contrato=" & _
        TextConxContrato.Text & " and fecha between '" & fechaI & "' and '" & fechaF & "'"
        If llenaTabla(cadena, tbDatos) > 0 Then

            v.SetDataSource(tbDatos)
            v.SetParameterValue("fechaI", fechaI)
            v.SetParameterValue("fechaF", fechaF)
            crv.ReportSource = v
            crv.Refresh()
        Else
            MsgBox("NO HAY DATOS PARA GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub frmRutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
       textEmpleado.Enter, textNombreEmple.Enter,
      TextConxContrato.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub


    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
       textEmpleado.Leave, textNombreEmple.Leave,
      TextConxContrato.Leave
        desactiva(sender)
    End Sub


    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

End Class