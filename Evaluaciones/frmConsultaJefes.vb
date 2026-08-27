Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCONSULTAJEFES.VB MIEMBRO DE NOMINA.SLN                                   **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmConsultaJefes
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
    Dim v As Cryautoevaluacion
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


    Private Sub frmConsultaJefes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        rbSubordinado.Checked = True

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click


        If validetError(txtCiclo, ep1) AndAlso validetError(textEmpleado, ep1) Then
            Dim empleado As Int32 = 0
            Me.Cursor = Cursors.WaitCursor
            Int32.TryParse(textEmpleado.Text, empleado)
            lpara.Clear()
            lpara("ciclo") = txtCiclo.Text
            lpara("empleado") = empleado
            lpara("empresa") = empresa
            If rbSubordinado.Checked = True Then 'total de subordinados
                Dim v As New cryconsultajefeysub
                cadena = " select cj.empleado,e.apellido1+' '+e.apellido2+' '+e.nombre1+' '+e.nombre2 as nomsub," &
                         " cj.evaluador,cj.evaluador,e2.apellido1+' '+e2.apellido2+' '+e2.nombre1+' '+e2.nombre2 as nomJefe ,a.nombre " &
                         " from " &
                         " (select a.* from evaluatipo_asignacion a " &
                         " left join evaluatest1 b on a.empleado =b.empleado  and  a.evaluador =b.emevaluador and a.empresa=b.empresa  and b.ciclo=@ciclo " &
                         " where b.empleado is null and a.ciclo =@ciclo) as cj " &
                         " inner join evaluatipotest a on a.ciclo=cj.ciclo and a.tipotest=cj.tipotest and cj.empresa=a.empresa " &
                         " inner join emplegen e on cj.empleado = e.empleado and cj.empresa=e.empresa" &
                         " inner join emplegen e2 on cj.evaluador = e2.empleado and cj.empresa=e2.empresa " &
                         " where  e.empleado in " &
                         " (select distinct(empleado) from contratos1 where empresa=@empresa and estado in (0,4)) and e2.empleado in " &
                         " (select distinct(empleado) from contratos1 where empresa=@empresa and estado in (0,4))  and a.tipo=2 "
                If textEmpleado.Text <> "" Then
                    cadena = cadena & " and e.empleado=@empleado "
                End If
                cadena = cadena & "group by cj.empleado,e.apellido1,e.apellido2,e.nombre1,e.nombre2,cj.evaluador, cj.evaluador, e2.apellido1, e2.apellido2, e2.nombre1, e2.nombre2, a.nombre "
                cadena = cadena & " order by e.apellido1,e.apellido2,e.nombre1,e.nombre2,e2.apellido1,e2.apellido2,e2.nombre1,e2.nombre2 "

                Dim cdata As New cmodelo(_conexionAcademia)
                cdata.llenaTabla(cadena, tt, ListaParametros(lpara))
                cdata.Commit()

                If tt.Rows.Count > 0 Then

                    v.SetDataSource(tt)
                    Me.Cursor = Cursors.WaitCursor
                    crv.ReportSource = v
                    crv.Refresh()
                Else
                    MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If
                Me.Cursor = Cursors.Default

            ElseIf rbAuto.Checked = True Then  'total de autoevaluaciones
                Dim v As New Cryautoevaluacion
                cadena = " select a.empleado,b.apellido1+' '+b.apellido2+' '+b.nombre1+' '+nombre2 as nombre " &
                         " from evaluatipo_asignacion a " &
                         " inner join evaluatipotest c on a.ciclo=c.ciclo and a.tipotest=c.tipotest and a.empresa=c.empresa " &
                         " inner join emplegen b on a.empleado=b.empleado and a.empresa=b.empresa " &
                         " where a.empleado not in " &
                         " (select emevaluador from evaluatest1 where empleado=emevaluador and ciclo=@ciclo and empresa=@empresa) and b.empleado in " &
                         " (select distinct(empleado) from contratos1 where empresa=@empresa and estado in (0,4)) and c.tipo=1"
                If textEmpleado.Text <> "" Then
                    cadena = cadena & " and a.empleado=@empleado "
                End If

                cadena = cadena & " group by a.empleado,b.apellido1,b.apellido2,b.nombre1,nombre2 " &
                                  " order by b.apellido1,b.apellido2,b.nombre1,nombre2 "

                Dim cdata As New cmodelo(_conexionAcademia)
                cdata.llenaTabla(cadena, tt, ListaParametros(lpara))
                cdata.Commit()
                If tt.Rows.Count > 0 Then

                    v.SetDataSource(tt)

                    crv.ReportSource = v
                    crv.Refresh()
                Else
                    MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If

            End If
        End If




        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        cadena = ""
        cadenasub = ""
        rbSubordinado.Checked = True
        BorraEmpleado(True)
        crv.ReportSource = Nothing
    End Sub

    Private Sub rbSubordinado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSubordinado.CheckedChanged

    End Sub

    Private Sub crv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crv.Load

    End Sub
End Class