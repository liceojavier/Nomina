Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class frmListadoEvaluacion2014

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



    Private Sub limpia()
        cadena = ""
        crv1.ReportSource = Nothing
        crv1.Refresh()
        tbnivel.Clear()
        tbgrado.Clear()

    End Sub

    Private Sub frmListadoEvaluacionDocentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpia()

        txtCiclo.Text = DateTime.Today.Year
        llenaTipoTest(txtCiclo.Text)
        cadena = "select nombre,area from areas order by area"
        llena_combo(cadena, cmbAreas)
        cmbAreas.Items.Add("")
        llenaTabla(cadena, tbareas)
    End Sub


    Private Sub llenaTipoTest(ByVal ciclo As String)
        cmbTipoTest.DataSource = Nothing
        If Not (String.IsNullOrEmpty(ciclo)) Then
            cadena = "select tipotest,nombre from evaluatipotest where ciclo=" & ciclo & " order by tipotest"
            llenaTabla(cadena, tbTipotest)
            Dim fb As DataRow = tbTipotest.NewRow
            fb.Item("tipotest") = 0
            fb.Item("nombre") = ""
            tbTipotest.Rows.Add(fb)
            cmbTipoTest.DisplayMember = "nombre"
            cmbTipoTest.ValueMember = "tipotest"
            cmbTipoTest.DataSource = tbTipotest
        End If

    End Sub

  


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
        cadena = "select empleado, nombre from v_empleadosNuevo where empresa=" & empresa & " and nombre like '%" & _
        textNombreEmple.Text.Trim & "%'  order by nombre"
        tbEmpleado = New DataTable("empleado")
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
            btnGenerar.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        If valida_tipo_Entero(textConxEmpleado.Text, 2) = True Then
            Dim comando As SqlCommand
            Dim dr As SqlDataReader
           
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=" & empresa & _
                 " and empleado=" & textConxEmpleado.Text.Trim
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
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
        Dim condiArea As String = ""
        Dim condiTipoTest As String = ""
        Dim condiNiveles As String = ""
        Dim cadeSubReporte As String = ""
        If Not validetError(txtCiclo, ep1) Then
            MsgBox("DEBE INGRESAR TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If


        If cmbAreas.Text <> "" Then
            condiTipoTest = " and ev1.empleado in ( select empleado from maestros ma where ma.area=" & tbareas.Rows(cmbAreas.SelectedIndex).Item("area") & ") "
        End If
        If cmbTipoTest.Text <> "" Then
            condiTipoTest = condiTipoTest & " and ev1.tipotest=" & cmbTipoTest.SelectedValue & " "
        End If
        If textConxEmpleado.Text.Trim() <> "" Then
            condiTipoTest = condiTipoTest & " and ev1.empleado=" & textConxEmpleado.Text.Trim() & " "
        End If


        Try
            tabla = New DataTable("tabla")
            tbSubreporte = New DataTable("subreporte")

            If rbPreguntas.Checked Then
                cadena = "select LL.* FROM ( select ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, " & _
                         "ev1.empleado, e1.apellido1 + ' ' + e1.apellido2 + ' ' + e1.nombre1 + ' ' + e1.nombre2 as nombre_empleado, " & _
                         "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as TotalR, " & _
                         "(select count(*) from evaluatest1 evc1 " & _
                         "inner join evaluatest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                         "where evc1.ciclo = ev1.ciclo And evc1.empleado = ev1.empleado And evc1.tipotest = ev1.tipotest And " & _
                         "evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) as cuenta " & _
                         "from evaluatest1 ev1 " & _
                         "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
                         "inner join evaluapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " & _
                         "inner join evaluaopciones2 cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " & _
                         "inner join emplegen e1 on e1.empleado=ev1.empleado " & _
                         "left join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta " & _
                         "And cop.numopcion = ev2.numopcion WHERE ev1.ciclo = '" & txtCiclo.Text & "' " & condiTipoTest & " " & _
                         "group by ev1.ciclo,  ev1.tipotest, cp.numpregunta, cp.pregunta, cop.numopcion, cop.opcion,ev1.empleado, " & _
                         "e1.nombre1, e1.nombre2, e1.apellido1, e1.apellido2,   ct.nombre ) LL  " & _
                         "order by nombre_empleado, tipotest, numpregunta, numopcion "
            ElseIf rbGPregunta.Checked Then
                cadena = "select LL.* FROM ( select ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, " & _
                         "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as TotalR, " & _
                         "(select count(*) from evaluatest1 evc1 " & _
                         "inner join evaluatest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                         "where evc1.ciclo = ev1.ciclo  And evc1.tipotest = ev1.tipotest And " & _
                         "evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) as cuenta " & _
                         "from evaluatest1 ev1 " & _
                         "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
                         "inner join evaluapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " & _
                         "inner join evaluaopciones2 cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " & _
                         "inner join emplegen e1 on e1.empleado=ev1.empleado " & _
                         "left join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta " & _
                         "And cop.numopcion = ev2.numopcion WHERE ev1.ciclo = '" & txtCiclo.Text & "' " & condiTipoTest & " " & _
                         "group by ev1.ciclo,  ev1.tipotest, cp.numpregunta, cp.pregunta, cop.numopcion, cop.opcion, " & _
                         "ct.nombre ) LL  " & _
                         "order by tipotest, numpregunta, numopcion "
            ElseIf rbGCompetencia.Checked Then
                cadena = "select * FROM (select ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, " & _
                         "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as " & _
                         "TotalR, ca.area as compe, ca.nombre as nomCompe, (select count(*) from evaluatest1 evc1 " & _
                         "inner join evaluatest2 evc2 on evc1.ciclo = evc2.ciclo And evc1.numtest = evc2.numtest " & _
                         "where evc1.ciclo = ev1.ciclo And evc1.tipotest = " & _
                         "ev1.tipotest And evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) " & _
                         "as cuenta from evaluatest1 ev1 inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and " & _
                         "ev1.tipotest = ct.tipotest inner join evaluapreguntas cp on cp.ciclo=ev1.ciclo and " & _
                         "cp.tipotest = ev1.tipotest inner join evaluaopciones2 cop on cop.ciclo=ev1.ciclo and " & _
                         "cop.tipotest = ev1.tipotest And cop.numpregunta = cp.numpregunta inner join emplegen " & _
                         "e1 on e1.empleado=ev1.empleado inner join evalua_areas ca on cp.area=ca.area left join " & _
                         "evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = " & _
                         "ev2.numpregunta And cop.numopcion = ev2.numopcion WHERE ev1.ciclo = '" & txtCiclo.Text & "' " & condiTipoTest & " " & _
                         "group by ev1.ciclo,  ev1.tipotest, ca.area, ca.nombre, cp.numpregunta, cp.pregunta, " & _
                         "cop.numopcion, cop.opcion, ct.nombre " & _
                         " ) LL  order by tipotest, nomCompe, numpregunta, numopcion "
            ElseIf rbGCompetenciaE.Checked Then
                cadena = "select empleado, nombre_empleado, ciclo, tipotest, nombretest, compe, nomCompe, numopcion,opcion, sum(cuenta) as cuenta " & _
                         " FROM (select " & _
                         " e1.empleado, e1.nombre1 + ' ' + e1.nombre2 + ' ' + e1.apellido1 + ' ' + e1.apellido2 as nombre_empleado, " & _
                         "ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, " & _
                        "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as " & _
                        "TotalR, ca.area as compe, ca.nombre as nomCompe, (select count(*) from evaluatest1 evc1 " & _
                        "inner join evaluatest2 evc2 on evc1.ciclo = evc2.ciclo And evc1.numtest = evc2.numtest " & _
                        "where evc1.ciclo = ev1.ciclo And evc1.tipotest = " & _
                        "ev1.tipotest And evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion and evc1.empleado=e1.empleado) " & _
                        "as cuenta from evaluatest1 ev1 inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and " & _
                        "ev1.tipotest = ct.tipotest inner join evaluapreguntas cp on cp.ciclo=ev1.ciclo and " & _
                        "cp.tipotest = ev1.tipotest inner join evaluaopciones cop on cop.ciclo=ev1.ciclo and " & _
                        "cop.tipotest = ev1.tipotest And cop.numpregunta = cp.numpregunta inner join emplegen " & _
                        "e1 on e1.empleado=ev1.empleado inner join evalua_areas ca on cp.area=ca.area left join " & _
                        "evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = " & _
                        "ev2.numpregunta And cop.numopcion = ev2.numopcion WHERE ev1.ciclo = '" & txtCiclo.Text & "' " & condiTipoTest & " " & _
                        "group by ev1.ciclo,  ev1.tipotest, ca.area, ca.nombre, cp.numpregunta, cp.pregunta, " & _
                        "cop.numopcion, cop.opcion, ct.nombre, " & _
                        " e1.empleado, e1.nombre1, e1.nombre2, e1.apellido1,e1.apellido2 " & _
                        " ) LL " & _
                        " group by empleado, nombre_empleado, ciclo, tipotest, nombretest, compe, nomCompe, numopcion,opcion " & _
                        " order by tipotest, nomCompe, numopcion "
            End If

            cadeSubReporte = "select * from  v_EvaluaEmpleObserva ev1 where ev1.ciclo='" & txtCiclo.Text & "'"
            Me.Cursor = Cursors.WaitCursor
            llenaTabla(cadena, tabla)
            llenaTabla(cadeSubReporte, tbSubreporte)
            If tabla.Rows.Count > 0 Then
                If rbPreguntas.Checked Then
                    r = New listadoevaluacionespreguntas2014
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

    Private Sub rdbPreguntas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

End Class