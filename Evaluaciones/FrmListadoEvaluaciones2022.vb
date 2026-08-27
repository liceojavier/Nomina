Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports NOMINA.academiaEntities
Imports System.Data.Entity
Public Class FrmListadoEvaluaciones2022
    Dim cadena As String
    Dim tabla As DataTable
    Dim tbSubreporte As DataTable
    Dim tbareas As New DataTable("areas")
    Dim asignaturas As New DataTable("Asignaturas")
    Dim r As ReportClass
    Dim tbColegio As New DataTable("colegio")
    Dim tbnivel As New DataTable("nivel")
    Dim tbgrado As New DataTable("grado")
    Dim tbTipotest As New DataTable("tipotest")
    Dim tbEmpleado As New DataTable("empleado")
    Dim lpara As New Dictionary(Of String, Object)
    Dim ctx As New academiaEntities


    Private Sub limpia()
        cadena = ""
        crv1.ReportSource = Nothing
        crv1.Refresh()
        tbnivel.Clear()
        tbgrado.Clear()

    End Sub
    Private Sub FrmListadoEvaluaciones2022_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        limpia()

        txtCiclo.Text = DateTime.Today.Year
        llenaTipoTest(txtCiclo.Text)
        cadena = "select nombre,area from areas order by area"
        llena_combo(cadena, cmbAreas)
        cmbAreas.Items.Add("")
        llenaTabla(cadena, tbareas)
        empresa = 1
        rbGPregunta.Checked = True

    End Sub

    Private Sub llenaTipoTest(ByVal ciclo As String)
        cmbTipoTest.DataSource = Nothing
        lpara.Clear()
        lpara("ciclo") = ciclo
        If Not (String.IsNullOrEmpty(ciclo)) Then
            cadena = "select tipotest, cast(tipotest as varchar) + ' - ' + nombre as nombre from evaluatipotest where ciclo=@ciclo and tipotest=13 order by tipotest"
            Dim cdata As New cmodelo(_conexionAcademia)
            cdata.llenaTabla(cadena, tbTipotest, ListaParametros(lpara))
            cdata.Commit()
            Dim fb As DataRow = tbTipotest.NewRow
            fb.Item("tipotest") = 0
            fb.Item("nombre") = ""
            tbTipotest.Rows.Add(fb)
            cmbTipoTest.DisplayMember = "nombre"
            cmbTipoTest.ValueMember = "tipotest"
            cmbTipoTest.DataSource = tbTipotest
        End If

    End Sub

    Private Sub cmbTipoTest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoTest.SelectedIndexChanged
        Dim ciclo, tipotest As Int16
        If (cmbTipoTest.SelectedValue IsNot Nothing AndAlso TypeOf cmbTipoTest.SelectedValue Is Int16 AndAlso Int16.TryParse(txtCiclo.Text, ciclo)) Then
            tipotest = cmbTipoTest.SelectedValue
            TextNoTests.Text = number_test(ciclo, tipotest)
        Else
            TextNoTests.Text = "0"
        End If
    End Sub


    Public Function number_test(ByVal ciclo As Int16, ByVal tipotest As Int16) As Int32
        Dim conteo As Int32 = (From a In ctx.evaluatest1
                               Where a.ciclo = ciclo And a.tipotest = tipotest
                               Select a).Count()
        Return conteo
    End Function

#Region "EMPLEADO"

    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        If valbool = True Then
            textConxEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Integer
        Dim filaTemp As DataRow
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombreEmple.Text.Trim
        cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and nombre like '%' + @nombre + '%'  order by nombre"
        tbEmpleado = New DataTable("empleado")
        numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            textConxEmpleado.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            textConxEmpleado.Text() = filaTemp.Item(0)
            textNombreEmple.Text = filaTemp.Item(1)
            btnGenerar.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        If valida_tipo_Entero(textConxEmpleado.Text, 2) = True Then
            Dim comando As SqlCommand
            Dim dr As SqlDataReader
            lpara.Clear()
            lpara("empresa") = empresa
            lpara("empleado") = textConxEmpleado.Text.Trim
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and empleado=@empleado"
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
                btnGenerar.Focus()
            Else
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textConxEmpleado.Focus()
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
        Dim fEmp As New frmMuestra2Columnas
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado, "CODIGO", "NOMBRE", 0)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosEmpleados
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        btnGenerar.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        Dim filaTemp As DataRow
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textConxEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
    End Sub

#End Region


    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        lpara.Clear()
        Dim condiArea As String = ""
        Dim condiTipoTest As String = ""
        Dim condiTipoTest2 As String = ""
        Dim condiNiveles As String = ""
        Dim cadeSubReporte As String = ""
        Dim condTest As String = ""
        Dim cdata As New cmodelo(_conexionAcademia)
        Dim TotEvaluador As Integer = 0
        Dim observaciones As String = ""
        lpara("empresa") = empresa
        If Not validetError(txtCiclo, ep1) Then
            MsgBox("DEBE INGRESAR TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If


        If cmbAreas.Text <> "" Then
            lpara("area") = tbareas.Rows(cmbAreas.SelectedIndex).Item("area")
            condiTipoTest = " and ev1.empleado in ( select empleado from maestros ma where ma.area=@area) "
            condiTipoTest2 = " and ev1.empleado in ( select empleado from maestros ma where ma.area=@area) "
        End If

        If cmbTipoTest.Text <> "" Then
            lpara("tipotest") = cmbTipoTest.SelectedValue
            condiTipoTest = condiTipoTest & " and ev1.tipotest=@tipotest "
            condiTipoTest2 = condiTipoTest2 & " and ev1.tipotest=14 "
            condTest += " and ev1.tipotest=@tipotest "
        End If

        If textConxEmpleado.Text.Trim() <> "" Then
            lpara("empleado") = textConxEmpleado.Text.Trim()
            condiTipoTest = condiTipoTest & " and ev1.empleado=@empleado "
            condiTipoTest2 = condiTipoTest2 & " and ev1.empleado=@empleado "
        End If


        Try
            lpara("ciclo") = txtCiclo.Text
            tabla = New DataTable("tabla")
            tbSubreporte = New DataTable("subreporte")

            If rbGPregunta.Checked Then
                cadena = "select LL.* FROM ( select ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, 
                         cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as TotalR,  
                         (select count(*) from evaluatest1 evc1 
                         inner join evaluatest2 evc2 On evc1.ciclo=evc2.ciclo And evc1.numtest=evc2.numtest 
                         where evc1.ciclo = ev1.ciclo  And evc1.tipotest = ev1.tipotest And 
                         evc2.numpregunta=cp.numpregunta And evc2.numopcion=cop.numopcion And evc1.empleado=ev1.empleado) As cuenta2
                         from evaluatest1 ev1 
                         inner join evaluatipotest ct On ev1.ciclo=ct.ciclo And ev1.tipotest=ct.tipotest 
                         inner Join evaluapreguntas cp On cp.ciclo=ev1.ciclo And cp.tipotest=ev1.tipotest And ev1.empresa=cp.empresa
                         inner Join evaluaopciones cop On cop.ciclo=ev1.ciclo And cop.tipotest=ev1.tipotest And cop.numpregunta=cp.numpregunta And ev1.empresa=cop.empresa
                         inner Join emplegen e1 On e1.empleado=ev1.empleado And ev1.empresa=e1.empresa 
                         Left Join evaluatest2 ev2 On ev1.ciclo=ev2.ciclo And ev1.numtest=ev2.numtest And cp.numpregunta = ev2.numpregunta 
                         And cop.numopcion = ev2.numopcion And ev1.empresa=ev2.empresa 
                         WHERE  ev1.empresa =@empresa And ev1.ciclo = @ciclo " & condiTipoTest &
                         " Group by ev1.ciclo, ev1.tipotest, cp.numpregunta, cp.pregunta, cop.numopcion, cop.opcion, 
                         ct.nombre, ev1.empleado ) LL "

                cadena = cadena & " union all "
                cadena = cadena & "select LL.* FROM ( select ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, 
                         cp.numpregunta, cp.pregunta, cop.numopcion, cop.opcion, count(*) As TotalR, 
                         (select count(*) from evaluatest1 evc1 
                         inner Join evaluatest2 evc2 On evc1.ciclo=evc2.ciclo And evc1.numtest=evc2.numtest 
                         where evc1.ciclo = ev1.ciclo And evc1.tipotest = ev1.tipotest And
                         evc2.numpregunta = cp.numpregunta And evc2.numopcion = cop.numopcion And evc1.empleado = ev1.empleado) As cuenta2
                         From evaluatest1 ev1 
                         inner Join evaluatipotest ct On ev1.ciclo=ct.ciclo And ev1.tipotest=ct.tipotest 
                         inner Join evaluapreguntas cp On cp.ciclo=ev1.ciclo And cp.tipotest=ev1.tipotest And ev1.empresa=cp.empresa
                         inner Join evaluaopciones cop On cop.ciclo=ev1.ciclo And cop.tipotest=ev1.tipotest And cop.numpregunta=cp.numpregunta And ev1.empresa=cop.empresa
                         inner Join emplegen e1 On e1.empleado=ev1.empleado And ev1.empresa=e1.empresa
                         Left Join evaluatest2 ev2 On ev1.ciclo=ev2.ciclo And ev1.numtest=ev2.numtest And cp.numpregunta = ev2.numpregunta
                         And cop.numopcion = ev2.numopcion And ev1.empresa=ev2.empresa
                         WHERE  ev1.empresa = @empresa And ev1.ciclo = @ciclo " & condiTipoTest2 &
                         " Group by ev1.ciclo, ev1.tipotest, cp.numpregunta, cp.pregunta, cop.numopcion, cop.opcion, ct.nombre, ev1.empleado ) LL  
                         order by numpregunta,tipotest desc,  numopcion "

            End If
            '            cadeSubReporte = "Select * from  v_EvaluaEmpleObserva ev1 where ev1.ciclo='" & txtCiclo.Text & "' " & condTest
            Me.Cursor = Cursors.WaitCursor
            cdata.llenaTabla(cadena, tabla, ListaParametros(lpara))
            cdata.llenaTabla(cadena, tbSubreporte, ListaParametros(lpara))

            cadena = "select count(*) from evaluatest1 ev1 where ev1.empresa=@empresa and ev1.ciclo=@ciclo " & condiTipoTest
            TotEvaluador = cdata.BuscaEscalar(cadena, ListaParametros(lpara))

            cadena = "select isnull((select '· ' + cast(observa as nvarchar(max)) + char(10) from evaluatest1 ev1
                      where ev1.empresa=@empresa and ev1.ciclo = @ciclo " & condiTipoTest &
                      " and ev1.observa Is Not null And LTrim(RTrim(cast(ev1.observa As nvarchar(max)))) != ''
                      for xml path(''), type).value('.', 'NVARCHAR(MAX)'),'') AS observaciones"

            observaciones = cdata.BuscaEscalar(cadena, ListaParametros(lpara))

            Dim tipo_grafica As Int16 = 0
            If cmbTipoGrafica.SelectedIndex <= 0 Then tipo_grafica = 1
            If cmbTipoGrafica.SelectedIndex > 0 Then tipo_grafica = cmbTipoGrafica.SelectedIndex

            If tabla.Rows.Count > 0 Then
                If rbGPregunta.Checked Then
                    r = New GraficaEvaluacionEmpleadoPreguntas2022_2
                    r.SetDataSource(tabla)
                    r.Subreports.Item("crySubReporte.rpt").SetDataSource(tbSubreporte)
                    r.SetParameterValue("CICLO", txtCiclo.Text)
                    r.SetParameterValue("TITULO", cmbTipoTest.Text)
                    r.SetParameterValue("nombre", textNombreEmple.Text)
                    r.SetParameterValue("totevaluador", TotEvaluador)
                    r.SetParameterValue("observacion", observaciones)

                End If
                crv1.ReportSource = r
                'crv1.Refresh()
            Else
                MsgBox("NO EXISTEN REGISTROS PARA GENERAR ESTA CONSULTA", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("Error del Sistema".ToUpper & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        crv1.ReportSource = Nothing
        cmbAreas.SelectedIndex = -1
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

    End Sub

    Private Sub txtCiclo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCiclo.Validated
        llenaTipoTest(txtCiclo.Text)
    End Sub

    Private Sub rbGPregunta_CheckedChanged(sender As Object, e As EventArgs) Handles rbGPregunta.CheckedChanged
        gpEmpleado.Visible = False

        If rbGPregunta.Checked Then
            gpEmpleado.Visible = True

        End If

    End Sub




End Class