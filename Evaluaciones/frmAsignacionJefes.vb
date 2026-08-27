Imports NOMINA
Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMASIGNACIONJEFES.VB MIEMBRO DE NOMINA.SLN                                 **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmAsignacionJefes


    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim WithEvents fEmp As frmMuestra2Columnas
    Dim tbJefe As New DataTable("jefe")
    Dim tbSubalterno As New DataTable("subalterno")
    Dim tbAsignacion As New DataTable("signacion")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contrato")
    
    Dim cadena As String = ""
    Dim filaTemp As DataRow
    Dim f2C As frmMuestra2Columnas



#Region "EMPLEADO"

    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        TextConxContrato.Clear()
        dgvGeneral.DataSource = Nothing
        dgvJefe.DataSource = Nothing
        dgvSubalterno.DataSource = Nothing
        If valbool = True Then
            textConxEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Integer
        cadena = "select empleado, nombre from v_empleadosNuevo where empresa=" & empresa & " and nombre like '%" & _
        textNombreEmple.Text.Trim & "%'  order by nombre"

        numFilas = llenaTabla(cadena, tbEmpleado)
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            textConxEmpleado.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            textConxEmpleado.Text() = filaTemp.Item(0)
            textNombreEmple.Text = filaTemp.Item(1)
            btnContrato.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        If valida_tipo_Entero(textConxEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=" & empresa & _
                 " and empleado=" & textConxEmpleado.Text.Trim) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textConxEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=" & empresa & _
                 " and empleado=" & textConxEmpleado.Text.Trim
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEmpleado(False)
                dr.Read()
                textNombreEmple.Text = dr.GetValue(1)
                btnContrato.Focus()
                dr.Close()
                cn.Close()
            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraEmpleado(True)
            textConxEmpleado.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textConxEmpleado.Validated
        If textConxEmpleado.Text.Trim <> "" Then
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
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textConxEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
    End Sub


#End Region


#Region "Contrato"

    Private Sub BtnContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrato.Click
        Dim Num As Int16
        If textConxEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre " & _
                    " from contratos1 c1 " & _
                    " inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " & _
                    "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " & _
                    "where e.activo='S' and c1.empresa=" & empresa & " and empleado=" & textConxEmpleado.Text
            Num = llenaTabla(cadena, tbContratos)
            If Num = 1 Then
                TextConxContrato.Text = tbContratos.Rows(0).Item(0)
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 0)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContrato
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()
                btnBuscar.Focus()
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
        If TextConxContrato.Text.Trim <> "" And textConxEmpleado.Text.Trim <> "" Then
            Dim tbTem As New DataTable("temp")
            cadena = "select contrato, fechai " & _
                    " from contratos1 c1 " & _
                    " inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " & _
                    " where e.activo='S' and c1.empresa=" & empresa & " and c1.empleado=" & textConxEmpleado.Text & " AND c1.contrato=" & _
                     TextConxContrato.Text
            If llenaTabla(cadena, tbTem) = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            Else
                filaTemp = tbTem.Rows(0)
                TextConxContrato.Text() = filaTemp.Item(0)
                btnBuscar.Focus()
            End If
        Else
            TextConxContrato.Clear()
        End If
    End Sub

#End Region

#Region "FORMATO"
    Private Sub Vista(ByVal dgVista As DataGridView, ByVal tabla As DataTable)
        With dgVista
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 55
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 185
            .Columns(2).HeaderText = "CTTO"
            .Columns(2).Width = 40
            .Columns(3).HeaderText = "Puesto"
            .Columns(3).Width = 155
            'AltoGridView(18, tabla, 292, 457, dgVista)
        End With
    End Sub
    Private Sub Vista2(ByVal dgVista As DataGridView, ByVal tabla As DataTable)
        With dgVista
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 55
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 185
            .Columns(2).HeaderText = "CTTO"
            .Columns(2).Width = 40
            .Columns(3).HeaderText = "Puesto"
            .Columns(3).Width = 155
            'AltoGridView(18, tabla, 292, 442, dgVista)
        End With
    End Sub
#End Region

    Private Sub frmAsignacionJefes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

  
    Private Sub frmAsignacionJefes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextNombEmpresa.Text = BuscaEscalar("select nombre from Empresas where empresa=" & empresa)
    End Sub

    Private Sub llenarjefes()
        Dim dc(1) As DataColumn
        cadena = "select a.jefe,d.apellido1+' '+d.apellido2+' '+d.nombre1+' '+d.nombre2 as nombre,b.contrato,c.nombre  from contratosjefes a" & _
                 " inner join contratos1 b on a.jefe=b.empleado and a.jefecontrato=b.contrato and a.empresa=b.empresa " & _
                 " inner join puestosper c on b.puesto=c.puesto and c.empresa=b.empresa " & _
                 " inner join emplegen d on a.jefe=d.empleado and d.empresa=c.empresa " & _
                 " where a.empresa=" & empresa & " and  a.empleado =" & textConxEmpleado.Text & " and a.contrato=" & TextConxContrato.Text & " and " & _
                 " b.estado in (0,4) ORDER BY a.empleado ASC "
        tbJefe = New DataTable("jefe")
        llenaTabla(cadena, tbJefe)
        dc(0) = tbJefe.Columns("jefe")
        dc(1) = tbJefe.Columns("contrato")
        tbJefe.PrimaryKey = dc
        dgvJefe.DataSource = tbJefe
        Vista(dgvJefe, tbJefe)
    End Sub
    Private Sub llenarsub()
        Dim dc(1) As DataColumn
        cadena = "select a.empleado,d.apellido1+' '+d.apellido2+' '+d.nombre1+' '+d.nombre2 as nombre,b.contrato,c.nombre  from contratosjefes a " & _
                 " inner join contratos1 b on a.empleado=b.empleado and a.contrato=b.contrato and a.empresa=b.empresa " & _
                 " inner join puestosper c on b.puesto=c.puesto and c.empresa=b.empresa " & _
                 " inner join emplegen d on a.empleado=d.empleado and d.empresa=c.empresa " & _
                 " where a.empresa=" & empresa & " and a.jefe =" & textConxEmpleado.Text & " and a.jefecontrato=" & TextConxContrato.Text & " and " & _
                 " b.estado in (0,4) ORDER BY a.empleado ASC "

        tbSubalterno = New DataTable("subalterno")
        llenaTabla(cadena, tbSubalterno)
        dc(0) = tbSubalterno.Columns("empleado")
        dc(1) = tbSubalterno.Columns("contrato")
        tbSubalterno.PrimaryKey = dc
        dgvSubalterno.DataSource = tbSubalterno
        Vista(dgvSubalterno, tbSubalterno)
    End Sub
    Private Sub llenageneral()
        Dim dc(1) As DataColumn
        cadena = "select a.empleado,a.apellido1+' '+a.apellido2+' '+a.nombre1+' '+a.nombre2 as nombre,c.contrato,d.nombre from emplegen a" & _
                 " inner join contratos1 c on a.empleado=c.empleado " & _
                 " inner join puestosper d on c.puesto=d.puesto " & _
                 " where a.empresa=" & empresa & " and a.empleado not in (select empleado from contratosjefes where empresa=" & empresa & " and jefe=" & textConxEmpleado.Text & " ) and " & _
                 " a.empleado not in  (select jefe from contratosjefes where empresa=" & empresa & " and empleado=" & textConxEmpleado.Text & " ) and " & _
                 " c.estado in (0,4) and a.empleado <> " & textConxEmpleado.Text & " ORDER BY a.empleado ASC "
        tbAsignacion = New DataTable("asignacion")
        llenaTabla(cadena, tbAsignacion)
        dc(0) = tbAsignacion.Columns("empleado")
        dc(1) = tbAsignacion.Columns("contrato")
        tbAsignacion.PrimaryKey = dc
        dgvGeneral.DataSource = tbAsignacion
        Vista2(dgvGeneral, tbAsignacion)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Not validetError(textConxEmpleado, ep1) Or Not validetError(TextConxContrato, ep1) Then
            MsgBox("DEBE INGRESAR TODOS LOS CAMPOS", MsgBoxStyle.Information, "Información del Sistema")
            Exit Sub
        End If
        gpEmpleado.Enabled = False
        gpContrato.Enabled = False
        btnGuardar.Visible = True
        btnBuscar.Visible = False
        llenarjefes()
        llenarsub()
        llenageneral()

    End Sub

    Private Sub btnAgregarJefe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarJefe.Click
        Dim i As Int16
        Dim ftemp As DataRow
        Dim fAsignacion As DataRow
        Dim dc(1) As Object
        ftemp = tbJefe.NewRow
        If dgvGeneral.SelectedRows.Count > 0 Then
            dc(0) = dgvGeneral.Item(0, dgvGeneral.SelectedRows(0).Index).Value
            dc(1) = dgvGeneral.Item(2, dgvGeneral.SelectedRows(0).Index).Value
            fAsignacion = CType(dgvGeneral.SelectedRows(0).DataBoundItem, DataRowView).Row
            For i = 0 To tbAsignacion.Columns.Count - 1
                ftemp.Item(i) = fAsignacion.Item(i)
            Next i
            tbJefe.Rows.Add(ftemp)
            tbAsignacion.Rows.Remove(fAsignacion)
            '   MueveScrollView(dgvJefe, tbJefe.Rows.Count - 1)
        End If

      
    End Sub

    Private Sub btnQuitarJefe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarJefe.Click
        Dim i As Int16
        Dim ftemp As DataRow
        Dim fJefe As DataRow
        Dim dc(1) As Object
        ftemp = tbAsignacion.NewRow
        If dgvJefe.SelectedRows.Count > 0 Then
            dc(0) = dgvJefe.Item(0, dgvJefe.SelectedRows(0).Index).Value
            dc(1) = dgvJefe.Item(2, dgvJefe.SelectedRows(0).Index).Value
            fJefe = CType(dgvJefe.SelectedRows(0).DataBoundItem, DataRowView).Row
            For i = 0 To tbJefe.Columns.Count - 1
                ftemp.Item(i) = fJefe.Item(i)
            Next i
            tbAsignacion.Rows.Add(ftemp)
            tbJefe.Rows.Remove(fJefe)
            '  MueveScrollView(dgvGeneral, tbAsignacion.Rows.Count - 1)
        End If


       
    End Sub

    Private Sub btnAgregarSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarSub.Click
        Dim ftemp As DataRow
        Dim i As Int16
        Dim fAsignacion As DataRow
        Dim dc(1) As Object
        ftemp = tbSubalterno.NewRow
        If dgvGeneral.SelectedRows.Count > 0 Then
            dc(0) = dgvGeneral.Item(0, dgvGeneral.SelectedRows(0).Index).Value
            dc(1) = dgvGeneral.Item(2, dgvGeneral.SelectedRows(0).Index).Value
            fAsignacion = CType(dgvGeneral.SelectedRows(0).DataBoundItem, DataRowView).Row
            For i = 0 To tbAsignacion.Columns.Count - 1
                ftemp.Item(i) = fAsignacion.Item(i)
            Next i
            tbSubalterno.Rows.Add(ftemp)
            tbAsignacion.Rows.Remove(fAsignacion)
            '   MueveScrollView(dgvSubalterno, tbSubalterno.Rows.Count - 1)
        End If


       
    End Sub

    Private Sub btnQuitarSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarSub.Click
        Dim i As Int16
        Dim ftemp As DataRow
        Dim fSub As DataRow
        Dim dc(1) As Object
        If dgvSubalterno.SelectedRows.Count > 0 Then
            dc(0) = dgvSubalterno.Item(0, dgvSubalterno.SelectedRows(0).Index).Value
            dc(1) = dgvSubalterno.Item(2, dgvSubalterno.SelectedRows(0).Index).Value
            fSub = CType(dgvSubalterno.SelectedRows(0).DataBoundItem, DataRowView).Row
            ftemp = tbAsignacion.NewRow
            For i = 0 To tbAsignacion.Columns.Count - 1
                ftemp.Item(i) = fSub.Item(i)
            Next i
            tbAsignacion.Rows.Add(ftemp)
            tbSubalterno.Rows.Remove(fSub)
            '    MueveScrollView(dgvGeneral, tbAsignacion.Rows.Count - 1)
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        gpEmpleado.Enabled = True
        gpContrato.Enabled = True
        btnGuardar.Visible = False
        btnBuscar.Visible = True
        dgvGeneral.DataSource = Nothing
        dgvJefe.DataSource = Nothing
        dgvSubalterno.DataSource = Nothing
        textConxEmpleado.Text = ""
        textNombreEmple.Text = ""
        TextConxContrato.Text = ""
        textNombres.Clear()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim i As Int16

        Try

            Dim cmodel As New cmodelo

            cadena = "delete contratosjefes where empresa=" & empresa & " and  empleado=" & textConxEmpleado.Text
            cmodel.EjecutarNonQuery(cadena)
            cadena = "delete contratosjefes where empresa=" & empresa & " and  jefe=" & textConxEmpleado.Text
            cmodel.EjecutarNonQuery(cadena)

            For i = 0 To tbJefe.Rows.Count - 1
                cadena = "insert into contratosjefes(empresa,empleado,contrato,jefe,jefecontrato)" & _
                     " values(" & empresa & ", " & textConxEmpleado.Text & "," & TextConxContrato.Text & " , " & tbJefe.Rows(i).Item("jefe") & ", " & tbJefe.Rows(i).Item("contrato") & ")"
                cmodel.EjecutarNonQuery(cadena)
            Next i
            For i = 0 To tbSubalterno.Rows.Count - 1

                cadena = "insert into contratosjefes(empresa,empleado,contrato,jefe,jefecontrato)" & _
                     " values(" & empresa & "," & tbSubalterno.Rows(i).Item("empleado") & "," & tbSubalterno.Rows(i).Item("contrato") & ", " & textConxEmpleado.Text & "," & TextConxContrato.Text & ")"
                cmodel.EjecutarNonQuery(cadena)
            Next
            If cmodel.Commit() Then
                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Información del Sistema")
                InsertBitacora(9, 1, "Asignación de jefe y subalternos al  empleado " & textConxEmpleado.Text & " con contrato " & TextConxContrato.Text)
                btnLimpiar_Click(sender, e)
            End If

           
        Catch ex As Exception
            MsgBox("Error: " & cadena, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try

    End Sub

    
    Private Sub gpEmpleado_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gpEmpleado.Enter

    End Sub

    Private Sub textNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textNombres.TextChanged
        If dgvGeneral.DataSource IsNot Nothing Then
            If (textNombres.Text.Trim() <> "") Then
                CType(dgvGeneral.DataSource, DataTable).DefaultView.RowFilter = String.Format("nombre like '%{0}%'", textNombres.Text.Trim)
            Else
                CType(dgvGeneral.DataSource, DataTable).DefaultView.RowFilter = ""
            End If
        End If
    End Sub

    Private Sub SplitContainer2_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer2.Panel1.Paint

    End Sub
End Class