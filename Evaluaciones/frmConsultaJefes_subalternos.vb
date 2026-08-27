Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCONSULTAJEFES_SUBALTERNOS.VB MIEMBRO DE NOMINA.SLN                       **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmConsultaJefes_subalternos
    'Inherits frmPrincipal

    Dim tbTipo As New DataTable("tipo")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbCodigo As New DataTable("codigo")
    Dim tbMotivoEvento As New DataTable("motivos")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim tt As New DataTable("datos")
    Dim WithEvents fEMp As frmMuestra2Columnas
    Dim cadena As String
    Dim cadenasub As String
    Dim v As consulta_jefes_sub
    Dim lpara As New Dictionary(Of String, Object)

#Region "EMPLEADO"


    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
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
                 " inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) " &
                 " order by nombre"
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
            cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa" &
                     " and empleado=@empleado" &
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
        fEMp = New frmMuestra2Columnas
        fEMp.TopMost = True
        fEMp.inicializa(tbEmpleado, "CODIGO", "NOMBRE", 0)
        AddHandler fEMp.actValor, AddressOf ActualizacionDatosEmpleados
        fEMp.StartPosition = FormStartPosition.CenterScreen
        fEMp.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
    End Sub

#End Region


    Private Sub frmConsultaJefes_subalternos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TextEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=" & empresa)

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click


        If validetError(txtCiclo, ep1) AndAlso validetError(textEmpleado, ep1) Then
            Dim empleado As Int32 = 0
            Me.Cursor = Cursors.WaitCursor

            lpara.Clear()
            lpara("empleado") = empleado
            lpara("empresa") = empresa

            Dim v As New consulta_jefes_sub

            cadena = "select a.empleado,b.jefe,'JEFES' as tipo, " &
                     " a.apellido1+' '+a.apellido2+' '+a.nombre1+' '+a.nombre2 as nomEmpleado, " &
                     " c.apellido1+' '+c.apellido2+' '+c.nombre1+' '+c.nombre2 as nomJefeoSub  " &
                     " from emplegen a " &
                     " inner join contratosjefes b on a.empleado=b.empleado and a.empresa=b.empresa " &
                     " inner join emplegen c on c.empleado=b.jefe and c.empresa=a.empresa "
            If textEmpleado.Text.Trim <> "" Then
                cadena = cadena & " and a.empleado=@empleado "
            ElseIf rdJefes.Checked = True Then
                cadena = cadena & " and a.empleado in (select distinct(jefe) from contratosjefes where empresa=@empresa) "
            End If

            cadena = cadena & " union all " &
                     " select b.jefe as empleado,b.empleado as jefe,'SUBALTERNOS' as tipo, " &
                     " a.apellido1+' '+a.apellido2+' '+a.nombre1+' '+a.nombre2 as nomEmpleado, " &
                     " c.apellido1+' '+c.apellido2+' '+c.nombre1+' '+c.nombre2 as nomJefeoSub  " &
                     " from emplegen a " &
                     " inner join contratosjefes b on a.empleado=b.jefe and a.empresa=b.empresa " &
                     " inner join emplegen c on c.empleado=b.empleado and c.empresa=a.empresa  "

            If textEmpleado.Text.Trim <> "" Then
                cadena = cadena & " and a.empleado=@empleado "
            ElseIf rdJefes.Checked = True Then
                cadena = cadena & " and a.empleado in (select distinct(jefe) from contratosjefes where empresa=@empresa) "
            End If

            cadena = cadena & " where a.empresa=@empresa order by nomEmpleado ASC, tipo"

            If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then

                v.SetDataSource(tt)

                crv.ReportSource = v
                crv.Refresh()
            Else
                MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If
        End If






        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        cadena = ""
        cadenasub = ""
        BorraEmpleado(True)
        crv.ReportSource = Nothing
        rdTodos.Checked = True
        rdJefes.Checked = False
    End Sub


    Private Sub frmAsignacionJefes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub


End Class