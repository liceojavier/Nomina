Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports NOMINA.academiaEntities
Imports System.Data.Entity

Public Class frmListadoEvaluacion2015

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

    Private Sub frmListadoEvaluacionPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpia()
        rbInstrumentos.Checked = True
        txtCiclo.Text = DateTime.Today.Year
        llenaTipoTest(txtCiclo.Text)
        cadena = "select nombre,area from areas order by area"
        llena_combo(cadena, cmbAreas)
        cmbAreas.Items.Add("")
        llenaTabla(cadena, tbareas)
    End Sub


    Private Sub llenaTipoTest(ByVal ciclo As String)
        lpara.Clear()
        lpara("ciclo") = ciclo
        cmbTipoTest.DataSource = Nothing
        If Not (String.IsNullOrEmpty(ciclo)) Then
            cadena = "select tipotest, cast(tipotest as varchar) + ' - ' + nombre as nombre from evaluatipotest where ciclo=@ciclo order by tipotest"
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
        Dim conteo As Int32 = (From a In ctx.evaluatest1 _
                               Where a.ciclo = ciclo And a.tipotest = tipotest _
                               Select a).Count()
        Return conteo
    End Function

#Region "EMLEADO"

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





#Region "EVALUADOR"

    Private Sub BorraEvaluador(ByVal valbool As Boolean)
        TextNombEvaluador2.Clear()
        If valbool = True Then
            TextEvaluador.Clear()
        End If
    End Sub


    Private Sub btnNombEvaluador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado2.Click
        Dim numFilas As Integer
        Dim filaTemp As DataRow
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = TextNombEvaluador2.Text.Trim
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
            TextEvaluador.Text() = filaTemp.Item(0)
            TextNombEvaluador2.Text = filaTemp.Item(1)
            btnGenerar.Focus()
        Else
            EnBuscaEmpleado2()
        End If
    End Sub

    Private Sub ValidaEmpleado2()
        If valida_tipo_Entero(TextEvaluador.Text, 2) = True Then
            Dim comando As SqlCommand
            Dim dr As SqlDataReader
            lpara.Clear()
            lpara("empresa") = empresa
            lpara("empleado") = TextEvaluador.Text.Trim
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and empleado=@empleado"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEvaluador(False)
                dr.Read()
                TextNombEvaluador2.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                btnGenerar.Focus()
            Else
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEvaluador(True)
                TextEvaluador.Focus()
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraEvaluador(True)
            TextEvaluador.Focus()
        End If
    End Sub

    Private Sub TextEvaluador_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextEvaluador.Validated
        If TextEvaluador.Text.Trim <> "" Then
            ValidaEmpleado2()
        Else
            BorraEvaluador(False)
        End If
    End Sub

    Private Sub EnBuscaEmpleado2()
        Dim fEmp As New frmMuestra2Columnas
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado, "CODIGO", "NOMBRE", 0)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosEmpleados2
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        btnGenerar.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados2(ByVal sender As Object, ByVal e As clsActValorREvento)
        Dim filaTemp As DataRow
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        TextEvaluador.Text() = filaTemp.Item(0)
        TextNombEvaluador2.Text = filaTemp.Item(1)
    End Sub

#End Region

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim condiArea As String = ""
        Dim condiTipoTest As String = ""
        Dim condiNiveles As String = ""
        Dim cadeSubReporte As String = ""
        Dim condTest As String = ""
        Dim cdata As New cmodelo(_conexionAcademia)
        lpara.Clear()






        If Not validetError(txtCiclo, ep1) Then
            MsgBox("DEBE INGRESAR TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If


        If cmbAreas.Text <> "" Then
            lpara("area") = tbareas.Rows(cmbAreas.SelectedIndex).Item("area")
            condiTipoTest = " and ev1.empleado in ( select empleado from maestros ma where ma.area=@area) "
        End If
        If cmbTipoTest.Text <> "" Then
            lpara("tipotest") = cmbTipoTest.SelectedValue
            condiTipoTest = condiTipoTest & " And ev1.tipotest=@tipotest "
            condTest += " And ev1.tipotest=@tipotest "
        End If
        If textConxEmpleado.Text.Trim() <> "" Then
            lpara("empleado") = textConxEmpleado.Text.Trim()
            condiTipoTest = condiTipoTest & " And ev1.empleado=@empleado "
        End If
        If TextEvaluador.Text.Trim() <> "" Then
            lpara("emevaluador") = TextEvaluador.Text.Trim()
            condiTipoTest = condiTipoTest & " And ev1.emevaluador=@emevaluador "
        End If
        If gpEvaluador.Visible AndAlso textConxEmpleado.Text.Trim() <> "" Then
            lpara("empleado") = textConxEmpleado.Text.Trim()
            condiTipoTest = condiTipoTest & " And ev1.emevaluador=@empleado "
        End If


        Try
            lpara("empresa") = empresa
            lpara("ciclo") = txtCiclo.Text
            tabla = New DataTable("tabla")
            tbSubreporte = New DataTable("subreporte")

            If rbInstrumentos.Checked Then
                cadena = "Select ev1.ciclo, ev1.tipotest, ev1.nombre As nombretest, " &
                         "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion " &
                         "from evaluatipotest ev1 " &
                         "inner join evaluapreguntas cp On cp.ciclo=ev1.ciclo And cp.tipotest=ev1.tipotest " &
                         "inner join evaluaopciones cop On cop.ciclo=ev1.ciclo And cop.tipotest=ev1.tipotest And cop.numpregunta=cp.numpregunta And cp.empresa=cop.empresa " &
                         " WHERE cp.empresa=@empresa And ev1.ciclo =@ciclo " & condiTipoTest & " " &
                         "order by ev1.tipotest, cp.numpregunta, cop.numopcion "

            ElseIf rbPreguntas.Checked Then
                cadena = "select LL.* FROM ( select ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, " &
                         "ev1.empleado, e1.apellido1 + ' ' + e1.apellido2 + ' ' + e1.nombre1 + ' ' + e1.nombre2 as nombre_empleado, " &
                         "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as TotalR, " &
                         "(select count(*) from evaluatest1 evc1 " &
                         "inner join evaluatest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " &
                         "where evc1.ciclo = ev1.ciclo And evc1.empleado = ev1.empleado And evc1.tipotest = ev1.tipotest And " &
                         "evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) as cuenta, '' as nombre_evaluador " &
                         "from evaluatest1 ev1 " &
                         "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " &
                         "inner join evaluapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest and ev1.empresa=cp.empresa " &
                         "inner join evaluaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta and ev1.empresa=cop.empresa " &
                         "inner join emplegen e1 on e1.empleado=ev1.empleado and ev1.empresa=e1.empresa " &
                         "left join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta and ev1.empresa=ev2.empresa " &
                         "And cop.numopcion = ev2.numopcion " &
                         "WHERE ev1.empresa=@empresa and ev1.ciclo =@ciclo " & condiTipoTest & " " &
                         "group by ev1.ciclo,  ev1.tipotest, cp.numpregunta, cp.pregunta, cop.numopcion, cop.opcion,ev1.empleado, " &
                         "e1.nombre1, e1.nombre2, e1.apellido1, e1.apellido2,   ct.nombre ) LL  " &
                         "order by nombre_empleado, tipotest, numpregunta, numopcion "

            ElseIf rbPregEvaluador.Checked Then
                cadena = "select LL.* FROM ( select ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, " &
                       "ev1.empleado, e1.apellido1 + ' ' + e1.apellido2 + ' ' + e1.nombre1 + ' ' + e1.nombre2 as nombre_empleado, " &
                       "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as TotalR, " &
                       "(select count(*) from evaluatest1 evc1 " &
                       "inner join evaluatest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " &
                       "where evc1.ciclo = ev1.ciclo And evc1.empleado = ev1.empleado And evc1.tipotest = ev1.tipotest And " &
                       "evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion and evc1.emevaluador=ev1.emevaluador ) as cuenta, " &
                       "ev1.emevaluador, e2.apellido1 + ' ' + e2.apellido2 + ' ' + e2.nombre1 + ' ' + e2.nombre2 as nombre_evaluador " &
                       "from evaluatest1 ev1 " &
                       "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " &
                       "inner join evaluapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest and ev1.empresa=cp.empresa " &
                       "inner join evaluaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta and ev1.empresa=cop.empresa " &
                       "inner join emplegen e1 on e1.empleado=ev1.empleado and ev1.empresa=e1.empresa " &
                       "inner join emplegen e2 on e2.empleado=ev1.emevaluador and ev1.empresa=e1.empresa " &
                       "left join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta " &
                       "And cop.numopcion = ev2.numopcion and ev1.empresa=ev2.empresa " &
                       "WHERE ev1.empresa=@empresa and ev1.ciclo =@ciclo " & condiTipoTest & " " &
                       "group by ev1.ciclo,  ev1.tipotest, cp.numpregunta, cp.pregunta, cop.numopcion, cop.opcion,ev1.empleado, " &
                       "e1.nombre1, e1.nombre2, e1.apellido1, e1.apellido2, ct.nombre, ev1.emevaluador, " &
                       "e2.apellido1, e2.apellido2, e2.nombre1, e2.nombre2, e2.empleado ) LL  " &
                       "order by nombre_empleado, tipotest, numpregunta, numopcion "
            ElseIf rbGPregunta.Checked Then
                cadena = "select LL.* FROM ( select ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, " &
                         "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as TotalR, " &
                         "(select count(*) from evaluatest1 evc1 " &
                         "inner join evaluatest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " &
                         "where evc1.ciclo = ev1.ciclo  And evc1.tipotest = ev1.tipotest And " &
                         "evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) as cuenta " &
                         "from evaluatest1 ev1 " &
                         "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " &
                         "inner join evaluapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest and ev1.empresa=cp.empresa " &
                         "inner join evaluaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta and ev1.empresa=cop.empresa " &
                         "inner join emplegen e1 on e1.empleado=ev1.empleado and ev1.empresa=e1.empresa " &
                         "left join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta " &
                         "And cop.numopcion = ev2.numopcion and ev1.empresa=ev2.empresa " &
                         "WHERE  ev1.empresa=@empresa and ev1.ciclo =@ciclo " & condiTipoTest & " " &
                         "group by ev1.ciclo,  ev1.tipotest, cp.numpregunta, cp.pregunta, cop.numopcion, cop.opcion, " &
                         "ct.nombre ) LL  " &
                         "order by tipotest, numpregunta, numopcion "
            ElseIf rbGCompetencia.Checked Then
                cadena = "select * FROM (select ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, " &
                         "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as " &
                         "TotalR, ca.area as compe, ca.nombre as nomCompe, (select count(*) from evaluatest1 evc1 " &
                         "inner join evaluatest2 evc2 on evc1.ciclo = evc2.ciclo And evc1.numtest = evc2.numtest " &
                         "where evc1.ciclo = ev1.ciclo And evc1.tipotest = " &
                         "ev1.tipotest And evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) " &
                         "as cuenta " &
                         "from evaluatest1 ev1 " &
                         "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest = ct.tipotest " &
                         "inner join evaluapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest = ev1.tipotest and cp.empresa=ev1.empresa " &
                         "inner join evaluaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest = ev1.tipotest And cop.numpregunta = cp.numpregunta  and ev1.empresa=cop.empresa " &
                         "inner join emplegen e1 on e1.empleado=ev1.empleado and ev1.empresa=e1.empresa " &
                         "inner join evalua_areas ca on cp.area=ca.area and ev1.ciclo=ca.ciclo and ev1.empresa=ca.empresa " &
                         "left join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta And cop.numopcion = ev2.numopcion and ev1.empresa=ev2.empresa " &
                         "WHERE ev1.empresa=@empresa and ev1.ciclo = @ciclo " & condiTipoTest & " " &
                         "group by ev1.ciclo,  ev1.tipotest, ca.area, ca.nombre, cp.numpregunta, cp.pregunta, " &
                         "cop.numopcion, cop.opcion, ct.nombre " &
                         " ) LL  order by tipotest, nomCompe, numpregunta, numopcion "
            ElseIf rbGCompetenciaE.Checked Then
                cadena = "select empleado, nombre_empleado, ciclo, tipotest, nombretest, compe, nomCompe, numopcion,opcion, sum(cuenta) as cuenta " &
                         " FROM (select " &
                         " e1.empleado, e1.nombre1 + ' ' + e1.nombre2 + ' ' + e1.apellido1 + ' ' + e1.apellido2 as nombre_empleado, " &
                         "ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, " &
                        "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as " &
                        "TotalR, ca.area as compe, ca.nombre as nomCompe, (select count(*) from evaluatest1 evc1 " &
                        "inner join evaluatest2 evc2 on evc1.ciclo = evc2.ciclo And evc1.numtest = evc2.numtest " &
                        "where evc1.ciclo = ev1.ciclo And evc1.tipotest = " &
                        "ev1.tipotest And evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion and evc1.empleado=e1.empleado) " &
                        "as cuenta " &
                        "from evaluatest1 ev1 " &
                        "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest = ct.tipotest " &
                        "inner join evaluapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest = ev1.tipotest and ev1.empresa=cp.empresa " &
                        "inner join evaluaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest = ev1.tipotest And cop.numpregunta = cp.numpregunta and ev1.empresa=cop.empresa " &
                        "inner join emplegen e1 on e1.empleado=ev1.empleado and ev1.empresa=e1.empresa " &
                        "inner join evalua_areas ca on cp.area=ca.area and ev1.empresa=ca.empresa and ev1.ciclo=ev1.ciclo " &
                        "left join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta And cop.numopcion = ev2.numopcion and ev1.empresa=ev2.empresa " &
                        "WHERE ev1.ciclo =@ciclo " & condiTipoTest & " " &
                        "group by ev1.ciclo,  ev1.tipotest, ca.area, ca.nombre, cp.numpregunta, cp.pregunta, " &
                        "cop.numopcion, cop.opcion, ct.nombre, " &
                        " e1.empleado, e1.nombre1, e1.nombre2, e1.apellido1,e1.apellido2 " &
                        " ) LL " &
                        " group by empleado, nombre_empleado, ciclo, tipotest, nombretest, compe, nomCompe, numopcion,opcion " &
                        " order by tipotest, nomCompe, numopcion "
            End If

            cadeSubReporte = "select * from  v_EvaluaEmpleObserva ev1 where ev1.ciclo=@ciclo " & condTest
            Me.Cursor = Cursors.WaitCursor
            cdata.llenaTabla(cadena, tabla, ListaParametros(lpara))
            cdata.llenaTabla(cadeSubReporte, tbSubreporte, ListaParametros(lpara))
            If tabla.Rows.Count > 0 Then
                If rbInstrumentos.Checked Then
                    r = New cry_eva_instrumentos_2015
                    r.SetDataSource(tabla)
                ElseIf rbPreguntas.Checked Then
                    r = New listadoevaluacionespreguntas2015
                    r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperFolio
                    r.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
                    r.SetDataSource(tabla)
                    r.Subreports("cryEvaluaObserva.rpt").SetDataSource(tbSubreporte)
                ElseIf rbPregEvaluador.Checked Then
                    r = New listadoevaluacionespreguntas2015
                    r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperFolio
                    r.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
                    r.SetDataSource(tabla)
                    r.Subreports("cryEvaluaObserva.rpt").SetDataSource(tbSubreporte)
                ElseIf rbGPregunta.Checked Then
                    r = New GraficaEvaluacionEmpleadoPreguntas
                    r.SetDataSource(tabla)
                    r.SetParameterValue("CICLO", txtCiclo.Text)
                    r.SetParameterValue("TITULO", cmbTipoTest.Text)
                ElseIf rbGCompetencia.Checked Then
                    r = New GraficaGeneralEvaluacionEmpleadoCompe
                    r.SetDataSource(tabla)
                    r.SetParameterValue("CICLO", txtCiclo.Text)
                    r.SetParameterValue("TITULO", cmbTipoTest.Text)
                ElseIf rbGCompetenciaE.Checked Then
                    r = New GraficaEvaluacionEmpleadoCompe
                    r.SetDataSource(tabla)
                    r.SetParameterValue("CICLO", txtCiclo.Text)
                    r.SetParameterValue("TITULO", cmbTipoTest.Text)
                End If

                crv1.ReportSource = r
                crv1.Zoom(95)
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

    Private Sub rdbPreguntas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPreguntas.CheckedChanged, _
    rbPregEvaluador.CheckedChanged, rbGCompetenciaE.CheckedChanged, rbGCompetencia.CheckedChanged, rbGPregunta.CheckedChanged

        gpEmpleado.Visible = False
        gpEvaluador.Visible = False
        If rbPreguntas.Checked Then
            gpEmpleado.Visible = True
            gpEvaluador.Visible = False
        ElseIf rbInstrumentos.Checked Then


        ElseIf rbPregEvaluador.Checked Then
            gpEmpleado.Visible = True
            gpEvaluador.Visible = True
        ElseIf rbGPregunta.Checked Then
            gpEmpleado.Visible = True
            gpEvaluador.Visible = False
        ElseIf rbGCompetencia.Checked Then
            gpEmpleado.Visible = True
            gpEvaluador.Visible = False
        ElseIf rbGCompetenciaE.Checked Then
            gpEmpleado.Visible = True
            gpEvaluador.Visible = False
        End If




    End Sub


   
End Class