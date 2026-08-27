Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class frmGraficasEvaluacionDoc2014

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
    Dim tbmaestro As New DataTable("maestro")
    Dim tbcompe As New DataTable("competencias")
    Dim filaTemp As DataRow
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim WithEvents fEmp As frmMuestra2Columnas


#Region "MAESTRO"

    Private Sub BorraMaestro(ByVal valbool As Boolean)
        textNombreMaestro.Clear()
        If valbool = True Then
            textConxMaestro.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaestro.Click
        Dim numFilas As Integer
        Dim condiNiveles As String = ""
        Dim condiArea As String = ""

        If cmbJornada.Text <> "" Then
            condiNiveles = " and b.colegio='" & cmbJornada.Text & "' "
        End If
        If cmbNivel.Text <> "" Then
            condiNiveles = condiNiveles & " and b.nivel='" & cmbNivel.Text & "' "
        End If
        If cmbGrado.Text <> "" Then
            condiNiveles = condiNiveles & " and b.grado='" & cmbGrado.Text & "' "
        End If
        If cmbSeccion.Text <> "" Then
            condiNiveles = condiNiveles & " and b.seccion='" & cmbSeccion.Text & "' "
        End If
        If cmbAreas.Text <> "" Then
            condiArea = " and a.area=" & tbareas.Rows(cmbAreas.SelectedIndex).Item("area") & " "
        End If


        cadena = "select * from (select distinct(a.codigo),nom1+' '+nom2+' '+apell1+' '+apell2 as nombre from maestros a " & _
                 " inner join maestrosporseccion b on a.codigo=b.codigo where a.codigo<>0 " & condiNiveles & condiArea & " ) as a" & _
                 " where a.nombre like '%" & textNombreMaestro.Text.Trim & "%'order by nombre"

        numFilas = llenaTabla(cadena, tbmaestro)
        If numFilas = 0 Then
            MsgBox("NO EXISTEN DOCENTES CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraMaestro(True)
            textConxMaestro.Clear()
        ElseIf numFilas = 1 Then
            BorraMaestro(True)
            filaTemp = tbmaestro.Rows.Item(0)
            textConxMaestro.Text() = filaTemp.Item(0)
            textNombreMaestro.Text = filaTemp.Item(1)
        Else
            EnBuscaMaestro()
        End If
    End Sub

    Private Sub ValidaMaestro()
        If valida_tipo_Entero(textConxMaestro.Text, 2) = True Then
            If BuscaEscalar("select * from (select codigo,nom1+' '+nom2+' '+apell1+' '+apell2 as nombre from maestros where codigo<>0) as a where a.codigo =" & _
                            textConxMaestro.Text.Trim) = 0 Then
                MsgBox("CODIGO DEL DOCENTE NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraMaestro(True)
                textConxMaestro.Focus()
                Exit Sub
            End If
            cadena = "select * from (select codigo,nom1+' '+nom2+' '+apell1+' '+apell2 as nombre from maestros where codigo<>0) as a where a.codigo =" & _
                            textConxMaestro.Text.Trim
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraMaestro(False)
                dr.Read()
                textNombreMaestro.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL DOCENTE POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraMaestro(True)
            textConxMaestro.Focus()
        End If
    End Sub

    Private Sub TextMaestro_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textConxMaestro.Validated
        If textConxMaestro.Text.Trim <> "" Then
            ValidaMaestro()
        Else
            BorraMaestro(False)
        End If
    End Sub

    Private Sub EnBuscaMaestro()
        fEmp = New frmMuestra2Columnas
        fEmp.TopMost = True
        fEmp.inicializa(tbmaestro, "CODIGO", "NOMBRE", 0)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosMaestro
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosMaestro(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraMaestro(True)
        filaTemp = tbmaestro.Rows.Item(e.va2)
        textConxMaestro.Text() = filaTemp.Item(0)
        textNombreMaestro.Text = filaTemp.Item(1)
    End Sub


#End Region

    Private Sub limpia()
        cadena = ""
        crv1.ReportSource = Nothing
        crv1.Refresh()
        tbnivel.Clear()
        tbgrado.Clear()
        gbDatos.Enabled = True
        cmbJornada.Text = Nothing
        TextColegio.Clear()
        cmbJornada.Focus()
        If rbPreguntasGr.Checked Then
            gbDocente.Enabled = False
            cmbNivel.Enabled = True
            cmbGrado.Enabled = True
            cmbSeccion.Enabled = True
        ElseIf rbDocenteEvaluado.Checked Then
            gbDocente.Enabled = True
            textConxMaestro.Clear()
            textNombreMaestro.Clear()
            textConxMaestro.Focus()
            cmbNivel.Enabled = True
            cmbGrado.Enabled = True
            cmbSeccion.Enabled = True
        ElseIf rbCompeNivel.Checked Then
            gbDocente.Enabled = False
            cmbGrado.Enabled = False
            cmbSeccion.Enabled = False
        ElseIf rbCompeGrado.Checked Then
            gbDocente.Enabled = False
            cmbSeccion.Enabled = False
        End If

    End Sub

    Private Sub frmGraficasEvaluacionDocentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpia()
        txtCiclo.Text = DateTime.Today.Year
        cadena = "select distinct colegio, nombre from Colegios"
        llena_combo(cadena, cmbJornada)
        llenaTabla(cadena, tbColegio)
        llenaTipoTest(txtCiclo.Text)
    End Sub


    Private Sub llenaTipoTest(ByVal ciclo As String)
        cmbTipoTest.DataSource = Nothing
        If Not (String.IsNullOrEmpty(ciclo)) Then
            cadena = "select tipotest,nombretest from culturatipotest1 where ciclo=" & txtCiclo.Text
            llenaTabla(cadena, tbTipotest)
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
            cadena = "select nombre,area from areas order by area"
            llena_combo(cadena, cmbAreas)
            llenaTabla(cadena, tbareas)

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


    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim condiArea As String = ""
        Dim condiTipoTest As String = ""
        Dim condiNiveles As String = ""
        Dim condiNiveles2 As String = ""
        Dim condiNiveles3 As String = ""
        Dim cadeSubReporte As String = ""
        Dim condiMaestro As String = ""
        Dim condiCompe As String = ""
        If Not validetError(txtCiclo, ep1) Or Not validetError(cmbTipoTest, ep1) Then
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
      


        Try
            tabla = New DataTable("tabla")
            'tbSubreporte = New DataTable("subreporte")
            If (rbPreguntasNi.Checked) Then
                cadena = "select LL.* FROM ( select ev1.ciclo, ev1.tipotest, ct.nombretest, ev1.colegio, co.nombre as nomb_colegio, " & _
                        "ev1.nivel, ni.nombre as nomb_nivel, " & _
                        "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as TotalR, " & _
                        "(select count(*) from evadoctest1 evc1 " & _
                        "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                        "where evc1.ciclo = ev1.ciclo And " & _
                        "evc1.colegio = ev1.colegio And evc1.nivel = ev1.nivel " & _
                        "and evc1.tipotest=ev1.tipotest and evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) as cuenta " & _
                        "from evadoctest1 ev1 " & _
                        "inner join culturatipotest1 ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
                        "inner join colegios co on co.colegio=ev1.colegio  " & _
                        "inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " & _
                        "inner join culturapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " & _
                        "inner join culturaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " & _
                        "inner join maestros ma on ma.codigo=ev1.codigo " & _
                        "inner join areas ar on ma.area=ar.area  " & _
                        "left join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta " & _
                        "And cop.numopcion = ev2.numopcion " & _
                        "WHERE ev1.ciclo = '" & txtCiclo.Text & "' " & condiArea & condiTipoTest & condiNiveles & _
                        "group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel, cp.numpregunta, cop.numopcion, cp.pregunta, " & _
                        "cop.opcion, co.nombre, ni.nombre,  ct.nombretest ) LL " & _
                        "order by colegio,numpregunta,numopcion "
            ElseIf (rbPreguntasGr.Checked) Then
                cadena = "select LL.* FROM ( select ev1.ciclo, ev1.tipotest, ct.nombretest, ev1.colegio, co.nombre as nomb_colegio, " & _
                         "ev1.nivel, ni.nombre as nomb_nivel, ev1.grado, gr.nombre as nomb_grado, " & _
                         "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as TotalR, " & _
                         "(select count(*) from evadoctest1 evc1 " & _
                         "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                         "where evc1.ciclo = ev1.ciclo And " & _
                         "evc1.colegio = ev1.colegio And evc1.nivel = ev1.nivel And evc1.grado = ev1.grado " & _
                         "and evc1.tipotest=ev1.tipotest and evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) as cuenta " & _
                         "from evadoctest1 ev1 " & _
                         "inner join culturatipotest1 ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
                         "inner join colegios co on co.colegio=ev1.colegio  " & _
                         "inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " & _
                         "inner join grados  gr on gr.colegio=ev1.colegio and gr.nivel=ev1.nivel and gr.grado=ev1.grado " & _
                         "inner join culturapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " & _
                         "inner join culturaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " & _
                         "inner join maestros ma on ma.codigo=ev1.codigo " & _
                         "inner join areas ar on ma.area=ar.area  " & _
                         "left join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta " & _
                         "And cop.numopcion = ev2.numopcion " & _
                         "WHERE ev1.ciclo = '" & txtCiclo.Text & "' " & condiArea & condiTipoTest & condiNiveles & _
                         "group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel, ev1.grado, cp.numpregunta, cop.numopcion, cp.pregunta, " & _
                         "cop.opcion, co.nombre, ni.nombre, gr.nombre,  ct.nombretest ) LL " & _
                         "order by colegio,numpregunta,numopcion "
            ElseIf (rbDocenteEvaluado.Checked) Then
                If textConxMaestro.Text <> "" Then
                    condiMaestro = " And ma.codigo= " & textConxMaestro.Text
                End If

                cadena = "select LL.*  FROM  (  select ev1.ciclo, ev1.tipotest, ct.nombretest,  ev1.colegio, co.nombre as nomb_colegio,  ev1.nivel, " & _
                         "ni.nombre as nomb_nivel,  ev1.grado, gr.nombre as nomb_grado,  ev1.codigo, " & _
                         "ma.apell1 + ' ' + ma.apell2 + ' ' + ma.nom1 + ' ' + ma.nom2 as nombre,  " & _
                         "cop.numopcion,cop.opcion, count(*) as TotalR, ca.area as numcompe,ca.nombre as nomCompe, " & _
                         "(select count(*)  " & _
                         "from evadoctest1 evc1  " & _
                         "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest  " & _
                         "inner join culturapreguntas ecp on evc1.ciclo=ecp.ciclo and ecp.tipotest=evc1.tipotest and ecp.numpregunta=evc2.numpregunta " & _
                         "where(evc1.ciclo = ev1.ciclo And evc1.colegio = ev1.colegio And evc1.nivel = ev1.nivel And evc1.grado = ev1.grado) " & _
                         "and evc1.codigo=ev1.codigo and evc1.tipotest=ev1.tipotest and ecp.area=ca.area and evc2.numopcion=cop.numopcion) as cuenta, " & _
                         "ar.nombre as nombre_area  " & _
                         "from evadoctest1 ev1  " & _
                         "inner join culturatipotest1 ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest  " & _
                         "inner join colegios co on co.colegio=ev1.colegio " & _
                         "inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " & _
                         "inner join grados  gr on gr.colegio=ev1.colegio and gr.nivel=ev1.nivel and gr.grado=ev1.grado  " & _
                         "inner join culturapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " & _
                         "inner join culturaareas ca on cp.area=ca.area " & _
                         "inner join culturaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " & _
                         "inner join maestros ma on ma.codigo=ev1.codigo " & _
                         "inner join areas ar on ma.area=ar.area " & _
                         "left join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta " & _
                         "And cop.numopcion = ev2.numopcion " & _
                         "WHERE ev1.ciclo =  '" & txtCiclo.Text & "' " & condiArea & condiTipoTest & condiNiveles & condiMaestro & _
                         "group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel, ev1.grado, ev1.codigo,  " & _
                         "cop.numopcion, cop.opcion, co.nombre, ca.area, ca.nombre, ni.nombre, " & _
                         "gr.nombre, ma.nom1, ma.nom2, ma.apell1, ma.apell2, ar.nombre, ct.nombretest ) LL order by colegio,nivel,grado, nombre, numcompe,numopcion "

            ElseIf (rbCompeNivel.Checked) Then
                If cmbJornada.Text <> "" Then
                    condiNiveles2 = " and ev1.colegio='" & cmbJornada.Text & "' "
                End If
                If cmbNivel.Text <> "" Then
                    condiNiveles2 = condiNiveles2 & " and ev1.nivel='" & cmbNivel.Text & "' "
                End If

                cadena = "select LL.*  FROM  (  select ev1.ciclo, ev1.tipotest, ct.nombretest,  ev1.colegio, co.nombre as nomb_colegio," & _
                         "  ev1.nivel, " & _
                         "ni.nombre as nomb_nivel, " & _
                         "cop.numopcion,cop.opcion, count(*) as TotalR, ca.area as compe,ca.nombre as nomCompe, " & _
                         "(select count(*) " & _
                         "from evadoctest1 evc1 " & _
                         "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                         "inner join culturapreguntas ecp on evc1.ciclo=ecp.ciclo and ecp.tipotest=evc1.tipotest and ecp.numpregunta=evc2.numpregunta " & _
                         "where evc1.ciclo = ev1.ciclo And evc1.colegio = ev1.colegio And evc1.nivel = ev1.nivel  " & _
                         "and evc1.tipotest=ev1.tipotest and ecp.area=ca.area and evc2.numopcion=cop.numopcion) as cuenta " & _
                         "from evadoctest1 ev1  " & _
                         "inner join culturatipotest1 ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
                         "inner join colegios co on co.colegio=ev1.colegio " & _
                         "inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " & _
                         "inner join culturapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " & _
                         "inner join culturaareas ca on cp.area=ca.area " & _
                         "inner join culturaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " & _
                         "inner join maestros ma on ma.codigo=ev1.codigo " & _
                         "inner join areas ar on ma.area=ar.area " & _
                         "left join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta " & _
                         "And cop.numopcion = ev2.numopcion " & _
                         "WHERE ev1.ciclo = '" & txtCiclo.Text & "'" & condiTipoTest & condiArea & condiCompe & condiNiveles2 & _
                         "group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel, " & _
                         "cop.numopcion, cop.opcion, co.nombre, ca.area, ca.nombre, ni.nombre, " & _
                         "ct.nombretest ) LL order by colegio,nivel, compe, numopcion "
            ElseIf rbCompeGrado.Checked Then

                cadena = "select LL.*  FROM  (  select ev1.ciclo, ev1.tipotest, ct.nombretest,  ev1.colegio, co.nombre as nomb_colegio," & _
                         " ev1.nivel, " & _
                         "ni.nombre as nomb_nivel,  ev1.grado, gr.nombre as nomb_grado, " & _
                         "cop.numopcion,cop.opcion, count(*) as TotalR, ca.area as compe,ca.nombre as nomCompe, " & _
                         "(select count(*) " & _
                         "from evadoctest1 evc1 " & _
                         "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                         "inner join culturapreguntas ecp on evc1.ciclo=ecp.ciclo and ecp.tipotest=evc1.tipotest and ecp.numpregunta=evc2.numpregunta " & _
                         "where evc1.ciclo = ev1.ciclo And evc1.colegio = ev1.colegio And evc1.nivel = ev1.nivel And evc1.grado = ev1.grado " & _
                         "and evc1.tipotest=ev1.tipotest and ecp.area=ca.area and evc2.numopcion=cop.numopcion) as cuenta " & _
                         "from evadoctest1 ev1  " & _
                         "inner join culturatipotest1 ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
                         "inner join colegios co on co.colegio=ev1.colegio " & _
                         "inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " & _
                         "inner join grados  gr on gr.colegio=ev1.colegio and gr.nivel=ev1.nivel and gr.grado=ev1.grado " & _
                         "inner join culturapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " & _
                         "inner join culturaareas ca on cp.area=ca.area " & _
                         "inner join culturaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " & _
                         "inner join maestros ma on ma.codigo=ev1.codigo " & _
                         "inner join areas ar on ma.area=ar.area " & _
                         "left join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta " & _
                         "And cop.numopcion = ev2.numopcion " & _
                         "WHERE ev1.ciclo = '" & txtCiclo.Text & "'" & condiTipoTest & condiArea & condiCompe & condiNiveles2 & _
                         "group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel, ev1.grado, " & _
                         "cop.numopcion, cop.opcion, co.nombre, ca.area, ca.nombre, ni.nombre, " & _
                         "gr.nombre, ct.nombretest ) LL order by colegio,nivel,grado, compe, numopcion "
            ElseIf rbCompTipEvaArea.Checked Then
                If cmbJornada.Text <> "" Then
                    condiNiveles3 = " and ev1.colegio='" & cmbJornada.Text & "'"

                End If

                cadena = " select ev1.ciclo,ev1.colegio,ev1.tipotest,ca.area as compe,ca.nombre as nomcompe," & _
                         " ma.area,aa.nombre as nomarea ,d.numopcion,d.opcion,count(*) as opc, " & _
                         " (select count(*) from evadoctest1 evc1 " & _
                         " inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                         " inner join culturapreguntas cp on cp.numpregunta=evc2.numpregunta and cp.ciclo=evc1.ciclo and cp.tipotest=evc1.tipotest  " & _
                         " inner join culturaareas ca1 on ca1.area=cp.area  " & _
                         " inner join maestros ma1 on ma1.codigo=evc1.codigo  where evc1.ciclo = ev1.ciclo and evc1.tipotest=ev1.tipotest and " & _
                         " evc2.numopcion=d.numopcion  and ca1.area=ca.area and ma1.area=ma.area ) as cuenta  from evadoctest1 ev1 " & _
                         " inner join evadoctest2 b on  ev1.numtest=b.numtest " & _
                         " inner join culturapreguntas c on ev1.ciclo=c.ciclo and ev1.tipotest=c.tipotest and b.numpregunta=c.numpregunta " & _
                         " inner join culturaopciones d on ev1.ciclo=d.ciclo and ev1.tipotest=d.tipotest and b.numpregunta=d.numpregunta  " & _
                         " inner join culturaareas ca on c.area=ca.area  " & _
                         " inner join maestros ma on ev1.codigo=ma.codigo  " & _
                         " inner join areas aa on aa.area=ma.area  where ev1.ciclo='" & txtCiclo.Text & "'" & condiTipoTest & condiNiveles3 & _
                         " group by ev1.ciclo,ev1.colegio,ev1.tipotest,ca.area,ca.nombre,ma.area,aa.nombre,d.numopcion,d.opcion  " & _
                         " order by ev1.ciclo,ev1.colegio,ev1.tipotest,ca.area,ca.nombre,ma.area,d.numopcion,d.opcion"
            ElseIf rbCompeTipoEva.Checked Then
                If cmbJornada.Text <> "" Then
                    condiNiveles3 = " and ev1.colegio='" & cmbJornada.Text & "'"

                End If

                cadena = " select ev1.ciclo,ev1.colegio,ev1.tipotest,ca.area as compe,ca.nombre as nomcompe," & _
                         " d.numopcion,d.opcion,count(*) as opc, " & _
                         " (select count(*) from evadoctest1 evc1 " & _
                         " inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                         " inner join culturapreguntas cp on cp.numpregunta=evc2.numpregunta and cp.ciclo=evc1.ciclo and cp.tipotest=evc1.tipotest  " & _
                         " inner join culturaareas ca1 on ca1.area=cp.area  " & _
                         " inner join maestros ma1 on ma1.codigo=evc1.codigo " & _
                         " where evc1.ciclo = ev1.ciclo and evc1.tipotest=ev1.tipotest and " & _
                         " evc2.numopcion=d.numopcion  and ca1.area=ca.area ) as cuenta " & _
                         " from evadoctest1 ev1 " & _
                         " inner join evadoctest2 b on  ev1.numtest=b.numtest " & _
                         " inner join culturapreguntas c on ev1.ciclo=c.ciclo and ev1.tipotest=c.tipotest and b.numpregunta=c.numpregunta " & _
                         " inner join culturaopciones d on ev1.ciclo=d.ciclo and ev1.tipotest=d.tipotest and b.numpregunta=d.numpregunta  " & _
                         " inner join culturaareas ca on c.area=ca.area  " & _
                         " inner join maestros ma on ev1.codigo=ma.codigo  " & _
                         " where ev1.ciclo='" & txtCiclo.Text & "'" & condiTipoTest & condiNiveles3 & _
                         " group by ev1.ciclo,ev1.colegio,ev1.tipotest,ca.area,ca.nombre,d.numopcion,d.opcion  " & _
                         " order by ev1.ciclo,ev1.colegio,ev1.tipotest,ca.area,ca.nombre,d.numopcion,d.opcion"

            End If

            Me.Cursor = Cursors.WaitCursor
            llenaTabla(cadena, tabla)
            'llenaTabla(cadeSubReporte, tbSubreporte)
            If tabla.Rows.Count > 0 Then

                If rbPreguntasNi.Checked Then
                    r = New GraficaEvaluacionesMaestrosNivel2014
                ElseIf rbPreguntasGr.Checked Then
                    r = New GraficaEvaluacionesMaestros2014
                ElseIf rbDocenteEvaluado.Checked Then
                    r = New GraficaEvaluacionesCompetecias2014
                ElseIf rbCompeNivel.Checked Then
                    r = New GraficaEvaluacionesCompeNivel
                ElseIf rbCompeGrado.Checked Then
                    r = New GraficaEvaluacionesCompeGrado
                ElseIf rbCompTipEvaArea.Checked Then
                    r = New GraficaEvaluacionesCompeTipotest
                ElseIf rbCompeTipoEva.Checked Then
                    r = New GraficaEvaluacionesCompeTipotest2
                End If
                r.SetDataSource(tabla)
                r.SetParameterValue("titulo", cmbTipoTest.Text)
                crv1.ReportSource = r

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

        limpia()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

    End Sub

    Private Sub txtCiclo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCiclo.Validated
        llenaTipoTest(txtCiclo.Text)
    End Sub


    Private Sub rbDocenteEvaluado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbDocenteEvaluado.Click
        If rbDocenteEvaluado.Checked Then
            limpia()
        End If
    End Sub

    Private Sub rbAreasAcademicas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPreguntasGr.CheckedChanged
        If rbPreguntasGr.Checked Then
            limpia()
        End If

    End Sub
    Private Sub rbCompeNivel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCompeNivel.CheckedChanged
        If rbCompeNivel.Checked Then
            limpia()
        End If
    End Sub
    Private Sub rbCompeGrado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCompeGrado.CheckedChanged
        If rbCompeGrado.Checked Then
            limpia()
        End If
    End Sub
    

    Private Sub cmbTipoTest_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoTest.SelectedIndexChanged
        If cmbTipoTest.SelectedIndex <> -1 Or cmbTipoTest.SelectedText <> "" Then
            cadena = " select nombre,area from " & _
                     " (select distinct (a.area),a.nombre from culturaareas a " & _
                     " inner join culturapreguntas b on a.area=b.area " & _
                     " where ciclo=" & txtCiclo.Text & " and b.tipotest=" & tbTipotest.Rows(cmbTipoTest.SelectedIndex).Item("tipotest") & ") as a " & _
                     " order by area asc "
            llenaTabla(cadena, tbcompe)
            ' llena_combo(cadena, cmbCompe)
        End If
    End Sub

End Class