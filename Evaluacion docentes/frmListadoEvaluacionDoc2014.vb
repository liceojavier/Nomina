Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class frmListadoEvaluacionDoc2014

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
        gpDatos.Enabled = True
        cmbJornada.Text = Nothing
        TextColegio.Clear()
        cmbJornada.Focus()
    End Sub

    Private Sub frmListadoEvaluacionDocentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpia()
        rbBusqColegio.Checked = True
        txtCiclo.Text = DateTime.Today.Year
        cadena = "select distinct colegio, nombre from Colegios"
        llena_combo(cadena, cmbJornada)
        llenaTabla(cadena, tbColegio)
        llenaTipoTest(txtCiclo.Text)
        cadena = "select nombre,area from areas order by area"
        llena_combo(cadena, cmbAreas)
        cmbAreas.Items.Add("")
        llenaTabla(cadena, tbareas)
    End Sub


    Private Sub llenaTipoTest(ByVal ciclo As String)
        cmbTipoTest.DataSource = Nothing
        If Not (String.IsNullOrEmpty(ciclo)) Then
            cadena = "select tipotest,nombretest from culturatipotest1 where ciclo=" & ciclo & " order by tipotest"
            llenaTabla(cadena, tbTipotest)
            Dim fb As DataRow = tbTipotest.NewRow
            fb.Item("tipotest") = 0
            fb.Item("nombretest") = ""
            tbTipotest.Rows.Add(fb)
            cmbTipoTest.DisplayMember = "nombretest"
            cmbTipoTest.ValueMember = "tipotest"
            cmbTipoTest.DataSource = tbTipotest
        End If

    End Sub

    Private Sub cmbJornada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJornada.SelectedIndexChanged
        cmbNivel.Items.Clear()
        cmbGrado.Items.Clear()
        cmbSeccion.Items.Clear()
        TextNivel.Clear()
        TextGrado.Clear()
        If cmbJornada.Text.Trim <> "" Then
            TextColegio.Text = tbColegio.Rows.Item(cmbJornada.SelectedIndex).Item(1)
            cadena = "SELECT DISTINCT NIVEL, nombre FROM NIVELES WHERE COLEGIO='" & cmbJornada.Text & "'"
            llena_combo(cadena, cmbNivel)
            llenaTabla(cadena, tbnivel)
            cmbNivel.Focus()
        

        End If
    End Sub

    Private Sub cmbNivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNivel.SelectedIndexChanged
        cmbGrado.Items.Clear()
        cmbSeccion.Items.Clear()
        TextGrado.Clear()
        If cmbNivel.Text.Trim <> "" Then
            TextNivel.Text = tbnivel.Rows.Item(cmbNivel.SelectedIndex).Item(1)
            cadena = "SELECT DISTINCT GRADO, nombre FROM GRADOS WHERE COLEGIO='" & cmbJornada.Text & "' AND NIVEL='" & cmbNivel.Text & "'"
            llena_combo(cadena, cmbGrado)
            llenaTabla(cadena, tbgrado)
            cmbGrado.Focus()
        End If
    End Sub

    Private Sub cmbGrado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrado.SelectedIndexChanged
        cmbSeccion.Items.Clear()
        If cmbGrado.Text.Trim <> "" Then
            TextGrado.Text = tbgrado.Rows.Item(cmbGrado.SelectedIndex).Item(1)
            cadena = "SELECT DISTINCT SECCION FROM CATALOGOCOLEGIO WHERE COLEGIO='" & cmbJornada.Text & "' AND NIVEL='" & cmbNivel.Text & "' AND GRADO='" & cmbGrado.Text & "'"
            llena_combo(cadena, cmbSeccion)
            cmbSeccion.Focus()
        End If
    End Sub

    Private Sub cmbSeccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSeccion.SelectedIndexChanged
        cmbAreas.Focus()
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

       
        If cmbJornada.Text <> "" Then
            condiNiveles = " and ev1.colegio='" & cmbJornada.Text & "' "
        End If
        If cmbNivel.Text <> "" Then
            condiNiveles = condiNiveles & " and ev1.nivel='" & cmbNivel.Text & "' "
        End If
        If cmbGrado.Text <> "" Then
            condiNiveles = condiNiveles & " and ev1.grado='" & cmbGrado.Text & "' "
        End If
        If cmbSeccion.Text <> "" Then
            condiNiveles = condiNiveles & " and ev1.seccion='" & cmbSeccion.Text & "' "
        End If
        If cmbAreas.Text <> "" Then
            condiArea = " and ma.area=" & tbareas.Rows(cmbAreas.SelectedIndex).Item("area") & " "
        End If
        If cmbTipoTest.Text <> "" Then
            condiTipoTest = " and ev1.tipotest=" & cmbTipoTest.SelectedValue & " "
        End If
        If textConxEmpleado.Text.Trim() <> "" Then
            condiTipoTest = " and ma.empleado=" & textConxEmpleado.Text.Trim() & " "
        End If


        Try
            tabla = New DataTable("tabla")
            tbSubreporte = New DataTable("subreporte")

            If (rbPreguntaSecc.Checked) Then
                cadena = "select LL.* " & _
                "FROM " & _
                "( " & _
                "select ev1.ciclo, ev1.tipotest, ct.nombretest, " & _
                "ev1.colegio, co.nombre as nomb_colegio, " & _
                "ev1.nivel, ni.nombre as nomb_nivel, " & _
                "ev1.grado, gr.nombre as nomb_grado, " & _
                "ev1.seccion as seccion, " & _
                "ev1.codigo, ma.apell1 + ' ' + ma.apell2 + ' ' + ma.nom1 + ' ' + ma.nom2 as nombre, cp.numpregunta, cp.pregunta, " & _
                "cop.numopcion,cop.opcion, count(*) as TotalR, " & _
                "(select count(*) " & _
                "from evadoctest1 evc1 " & _
                "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                "where evc1.ciclo = ev1.ciclo And evc1.colegio = ev1.colegio " & _
                "and evc1.nivel=ev1.nivel and evc1.grado=ev1.grado and evc1.seccion=ev1.seccion " & _
                "and evc1.codigo=ev1.codigo and evc1.tipotest=ev1.tipotest and evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) as cuenta, ar.nombre as nombre_area " & _
                "from evadoctest1 ev1 " & _
                "inner join culturatipotest1 ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
                "inner join colegios co on co.colegio=ev1.colegio inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " & _
                "inner join grados  gr on gr.colegio=ev1.colegio and gr.nivel=ev1.nivel and gr.grado=ev1.grado " & _
                "inner join culturapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " & _
                "inner join culturaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " & _
                "inner join maestros ma on ma.codigo=ev1.codigo " & _
                "inner join areas ar on ma.area=ar.area " & _
                "left join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta And cop.numopcion = ev2.numopcion " & _
                "WHERE ev1.ciclo = '" & txtCiclo.Text & "' " & condiArea & condiTipoTest & condiNiveles & _
                "group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel, ev1.grado, ev1.codigo, " & _
                "cp.numpregunta, cop.numopcion, cp.pregunta, cop.opcion, co.nombre, ni.nombre, gr.nombre, ma.nom1, ma.nom2, " & _
                "ma.apell1, ma.apell2, ar.nombre, ct.nombretest, ev1.seccion " & _
                ") " & _
                "LL order by colegio,nivel,grado, nombre, tipotest, numpregunta, numopcion"

            ElseIf (rbPreguntaGra.Checked) Then
                cadena = "select LL.* " & _
                "FROM " & _
                "( " & _
                "select ev1.ciclo, ev1.tipotest, ct.nombretest, " & _
                "ev1.colegio, co.nombre as nomb_colegio, " & _
                "ev1.nivel, ni.nombre as nomb_nivel, " & _
                "ev1.grado, gr.nombre as nomb_grado, " & _
                "ev1.codigo, ma.apell1 + ' ' + ma.apell2 + ' ' + ma.nom1 + ' ' + ma.nom2 as nombre, cp.numpregunta, cp.pregunta, " & _
                "cop.numopcion,cop.opcion, count(*) as TotalR, " & _
                "(select count(*) " & _
                "from evadoctest1 evc1 " & _
                "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                "where evc1.ciclo = ev1.ciclo And evc1.colegio = ev1.colegio " & _
                "and evc1.nivel=ev1.nivel and evc1.grado=ev1.grado  " & _
                "and evc1.codigo=ev1.codigo and evc1.tipotest=ev1.tipotest and evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) as cuenta, ar.nombre as nombre_area " & _
                "from evadoctest1 ev1 " & _
                "inner join culturatipotest1 ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
                "inner join colegios co on co.colegio=ev1.colegio " & _
                "inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " & _
                "inner join grados  gr on gr.colegio=ev1.colegio and gr.nivel=ev1.nivel and gr.grado=ev1.grado " & _
                "inner join culturapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " & _
                "inner join culturaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " & _
                "inner join maestros ma on ma.codigo=ev1.codigo " & _
                "inner join areas ar on ma.area=ar.area " & _
                "left join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta And cop.numopcion = ev2.numopcion " & _
                "WHERE  ev1.ciclo = '" & txtCiclo.Text & "' " & condiArea & condiTipoTest & condiNiveles & _
                "group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel, ev1.grado, ev1.codigo, " & _
                "cp.numpregunta, cop.numopcion, cp.pregunta, cop.opcion, co.nombre, ni.nombre, gr.nombre, ma.nom1, ma.nom2, " & _
                "ma.apell1, ma.apell2, ar.nombre, ct.nombretest " & _
                ") " & _
                "LL order by colegio,nivel,grado, nombre, tipotest, numpregunta, numopcion"

            ElseIf (rbPreguntasNivel.Checked) Then
                cadena = "select LL.* " & _
                "FROM " & _
                "( " & _
                "select ev1.ciclo, ev1.tipotest, ct.nombretest, " & _
                "ev1.colegio, co.nombre as nomb_colegio, " & _
                "ev1.nivel, ni.nombre as nomb_nivel, " & _
                "ev1.codigo, ma.apell1 + ' ' + ma.apell2 + ' ' + ma.nom1 + ' ' + ma.nom2 as nombre, cp.numpregunta, cp.pregunta, " & _
                "cop.numopcion,cop.opcion, count(*) as TotalR, " & _
                "(select count(*) " & _
                "from evadoctest1 evc1 " & _
                "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                "where evc1.ciclo = ev1.ciclo And evc1.colegio = ev1.colegio " & _
                "and evc1.nivel=ev1.nivel " & _
                "and evc1.codigo=ev1.codigo and evc1.tipotest=ev1.tipotest and evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) as cuenta, ar.nombre as nombre_area " & _
                "from evadoctest1 ev1 " & _
                "inner join culturatipotest1 ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
                "inner join colegios co on co.colegio=ev1.colegio " & _
                "inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " & _
                "inner join culturapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " & _
                "inner join culturaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " & _
                "inner join maestros ma on ma.codigo=ev1.codigo " & _
                "inner join areas ar on ma.area=ar.area " & _
                "left join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta And cop.numopcion = ev2.numopcion " & _
                "WHERE ev1.ciclo = '" & txtCiclo.Text & "' " & condiArea & condiTipoTest & condiNiveles & _
                "group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel, ev1.codigo, " & _
                "cp.numpregunta, cop.numopcion, cp.pregunta, cop.opcion, co.nombre, ma.nom1, ma.nom2, " & _
                "ma.apell1, ma.apell2, ar.nombre, ct.nombretest, ni.nombre" & _
                ") " & _
                "LL order by colegio,nivel, nombre, tipotest, numpregunta, numopcion "

            End If

        
            cadeSubReporte = "select * from v_EvaluacionObservacion ev1 where ev1.ciclo=" & txtCiclo.Text & condiNiveles
            Me.Cursor = Cursors.WaitCursor
            llenaTabla(cadena, tabla)
            llenaTabla(cadeSubReporte, tbSubreporte)
            If tabla.Rows.Count > 0 Then
                If rbPreguntaSecc.Checked Then
                    r = New listadoevaluacionesmaestros2014
                ElseIf rbPreguntaGra.Checked Then
                    r = New listadoevaluacionesmaestros_grados2014
                ElseIf rbPreguntasNivel.Checked Then
                    'r = New listadoevaluacionesmaestros_nivel2014
                End If
                r.SetDataSource(tabla)
                r.Subreports("cryEvaluacionObservacion.rpt").SetDataSource(tbSubreporte)
                crv1.ReportSource = r
                crv1.Zoom(95)
                crv1.Refresh()
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
        TextColegio.Clear()
        cmbJornada.SelectedIndex = -1
        cmbNivel.SelectedIndex = -1
        cmbGrado.SelectedIndex = -1
        cmbSeccion.SelectedIndex = -1
        cmbAreas.SelectedIndex = -1
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

    End Sub

    Private Sub txtCiclo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCiclo.Validated
        llenaTipoTest(txtCiclo.Text)
    End Sub

    Private Sub rdbPreguntas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPreguntaSecc.CheckedChanged

    End Sub

    Private Sub rbBusqColegio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBusqColegio.CheckedChanged, rbBusqEmple.CheckedChanged
        BorraEmpleado(True)
        cmbJornada.SelectedIndex = -1
        If (rbBusqColegio.Checked) Then
            gpEmpleado.Visible = False
            gpDatos.Visible = True
        ElseIf (rbBusqEmple.Checked) Then
            gpEmpleado.Visible = True
            gpDatos.Visible = False
        End If

    End Sub

    Private Sub labelP_Click(sender As Object, e As EventArgs) Handles labelP.Click

    End Sub

    Private Sub cmbAreas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAreas.SelectedIndexChanged

    End Sub
End Class