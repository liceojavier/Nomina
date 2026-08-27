Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmGraficaEvaluacionesDoc2022
    Dim tbColegio As New DataTable("colegio")
    Dim tbnivel As New DataTable("nivel")
    Dim tbgrado As New DataTable("grado")
    Dim tbtipotest As New DataTable("tipotest")
    Dim tabla As New DataTable("tabla")
    Dim tbsubreporte As New DataTable("subreporte")
    Dim tbareas As New DataTable("area")
    Dim cadena As String = ""
    Dim r As ReportClass
    Dim WithEvents fEmp As frmMuestra2Columnas
    Dim tbmaestro As New DataTable("maestro")
    Dim filaTemp As DataRow
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim lpara As New Dictionary(Of String, Object)

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


    End Sub

    Private Sub llenaTipoTest(ByVal ciclo As String)
        cmbTipoTest.DataSource = Nothing
        lpara.Clear()
        lpara("ciclo") = txtCiclo.Text
        If Not (String.IsNullOrEmpty(ciclo)) Then
            cadena = "select tipotest,nombre from evaluatipotest where ciclo=@ciclo"
            Dim cdata As New cmodelo(_conexionAcademia)
            cdata.llenaTabla(cadena, tbtipotest, ListaParametros(lpara))
            cdata.Commit()
            cmbTipoTest.DisplayMember = "nombre"
            cmbTipoTest.ValueMember = "tipotest"
            cmbTipoTest.DataSource = tbtipotest
        End If

    End Sub
    Private Sub frmGraficaEvaluacionesDoc2022_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        limpia()
        txtCiclo.Text = DateTime.Today.Year
        cadena = "select distinct colegio, nombre from Colegios"
        llena_combo(cadena, cmbJornada)
        llenaTabla(cadena, tbColegio)
        llenaTipoTest(txtCiclo.Text)
        rbPreguntasNi.Checked = True
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim condiArea As String = ""
        Dim condiTipoTest As String = ""
        Dim condiNiveles As String = ""
        Dim condiNiveles2 As String = ""
        Dim condiNiveles3 As String = ""
        Dim cadeSubReporte As String = ""
        Dim condiMaestro As String = ""
        Dim condiMaestro2 As String = ""
        Dim condigrado As String = ""
        Dim condiseccion As String = ""
        Dim condiCompe As String = ""
        Dim condiSubRep As String = ""
        lpara.Clear()
        If Not validetError(txtCiclo, ep1) Or Not validetError(cmbTipoTest, ep1) Or Not validetError(cmbJornada, ep1) Or Not validetError(cmbNivel, ep1) Then
            MsgBox("DEBE INGRESAR TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        lpara("colegio") = cmbJornada.Text
        lpara("nivel") = cmbNivel.Text
        lpara("grado") = cmbGrado.Text
        If cmbJornada.Text <> "" Then
            condiNiveles = " and ev1.colegio=@colegio "
            condiSubRep = ",'" & cmbJornada.Text & "'"
        Else
            condiSubRep = ",null"
        End If
        If cmbNivel.Text <> "" Then
            condiNiveles = condiNiveles & " And ev1.nivel =@nivel "
            condiSubRep += ",'" & cmbNivel.Text & "'"
        Else
            condiSubRep += ",null"
        End If
        If rbPreguntaGr.Checked = True Then
            If Not validetError(cmbGrado, ep1) Then
                MsgBox("DEBE INGRESAR EL GRADO PARA UTILIZAR ESTA OPCION", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub

            ElseIf cmbGrado.Text <> "" Then
                condiNiveles = condiNiveles & " and ev1.grado=@grado "
                condigrado = " and evc1.grado=@grado "
                condiSubRep += "," & cmbGrado.Text & ",null"
            Else
                Exit Sub
            End If
        End If
        If rbPreguntaSec.Checked = True Then
            If Not validetError(cmbGrado, ep1) Or Not validetError(cmbSeccion, ep1) Then
                MsgBox("DEBE INGRESAR EL GRADO Y LA SECCION PARA UTILIZAR ESTA OPCION", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub

            ElseIf cmbGrado.Text <> "" Then
                condiNiveles = condiNiveles & " and ev1.grado=@grado "
                condigrado = " and evc1.grado=@grado "
                condiSubRep += "," & cmbGrado.Text
                If cmbSeccion.Text <> "" Then
                    condiNiveles = condiNiveles & " and ev1.seccion='" & cmbSeccion.Text & "' "
                    condiseccion = " and evc1.seccion='" & cmbSeccion.Text & "'"
                    condiSubRep += ",'" & cmbSeccion.Text & "'"
                End If
            Else
                Exit Sub
            End If

        End If

        If rbPreguntasNi.Checked Then

            condiSubRep += ",null,null"
        End If

        lpara("tipotest") = cmbTipoTest.SelectedValue
        lpara("codigo") = textConxMaestro.Text
        If cmbTipoTest.Text <> "" Then
            condiTipoTest = " and ev1.tipotest=@tipotest "
        End If
        If textConxMaestro.Text <> "" Then
            condiMaestro = " and ev1.codigo=@codigo "
            condiMaestro2 = " and evc1.codigo=@codigo "
            condiSubRep += "," & textConxMaestro.Text
        Else
            condiSubRep += ",null"
        End If
        If cmbAreas.SelectedItem IsNot Nothing And cmbAreas.SelectedValue > 0 Then
            condiArea = " and ma.area=" & cmbAreas.SelectedValue
            condiSubRep += "," & cmbAreas.SelectedValue
        Else
            condiSubRep += ",null"
        End If



        Try
            tabla = New DataTable("tabla")
            'tbSubreporte = New DataTable("subreporte")
            If (rbPreguntasNi.Checked) Then
                cadena = "select LL.* FROM ( select ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, ev1.colegio, co.nombre as nomb_colegio, " &
                        "ev1.nivel, ni.nombre as nomb_nivel, " &
                        "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as TotalR, " &
                        "(select count(*) from evadoctest1 evc1 " &
                        "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " &
                        "where evc1.ciclo = ev1.ciclo And " &
                        "evc1.colegio = ev1.colegio And evc1.nivel = ev1.nivel " & condigrado & condiseccion & condiMaestro2 &
                        "and evc1.tipotest=ev1.tipotest and evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) as cuenta " &
                        "from evadoctest1 ev1 " &
                        "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " &
                        "inner join colegios co on co.colegio=ev1.colegio  " &
                        "inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " &
                        "inner join evaluapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " &
                        "inner join evaluaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " &
                        "inner join maestros ma on ma.codigo=ev1.codigo " &
                        "inner join areas ar on ma.area=ar.area  " &
                        "left join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta " &
                        "And cop.numopcion = ev2.numopcion " &
                        "WHERE ev1.ciclo = '" & txtCiclo.Text & "' " & condiArea & condiTipoTest & condiNiveles & condiMaestro &
                        " group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel, cp.numpregunta, cop.numopcion, cp.pregunta, " &
                        "cop.opcion, co.nombre, ni.nombre,  ct.nombre ) LL " &
                        "order by colegio,numpregunta,numopcion "
            ElseIf (rbPreguntaGr.Checked) Then
                cadena = "select LL.* FROM ( select ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, ev1.colegio, co.nombre as nomb_colegio, " &
                        "ev1.nivel, ev1.grado,ni.nombre as nomb_nivel, " &
                        "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as TotalR, " &
                        "(select count(*) from evadoctest1 evc1 " &
                        "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " &
                        "where evc1.ciclo = ev1.ciclo And " &
                        "evc1.colegio = ev1.colegio And evc1.nivel = ev1.nivel " & condigrado & condiseccion & condiMaestro2 &
                        "and evc1.tipotest=ev1.tipotest and evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) as cuenta " &
                        "from evadoctest1 ev1 " &
                        "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " &
                        "inner join colegios co on co.colegio=ev1.colegio  " &
                        "inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " &
                        "inner join evaluapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " &
                        "inner join evaluaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " &
                        "inner join maestros ma on ma.codigo=ev1.codigo " &
                        "inner join areas ar on ma.area=ar.area  " &
                        "left join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta " &
                        "And cop.numopcion = ev2.numopcion " &
                        "WHERE ev1.ciclo = '" & txtCiclo.Text & "' " & condiArea & condiTipoTest & condiNiveles & condiMaestro &
                        " group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel,ev1.grado, cp.numpregunta, cop.numopcion, cp.pregunta, " &
                        "cop.opcion, co.nombre, ni.nombre,  ct.nombre ) LL " &
                        "order by colegio,numpregunta,numopcion "
            ElseIf (rbPreguntaSec.Checked) Then
                cadena = "select LL.* FROM ( select ev1.ciclo, ev1.tipotest, ct.nombre as nombretest, ev1.colegio, co.nombre as nomb_colegio, " &
                        "ev1.nivel, ev1.grado,ev1.seccion,ni.nombre as nomb_nivel, " &
                        "cp.numpregunta, cp.pregunta, cop.numopcion,cop.opcion, count(*) as TotalR, " &
                        "(select count(*) from evadoctest1 evc1 " &
                        "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " &
                        "where evc1.ciclo = ev1.ciclo And " &
                        "evc1.colegio = ev1.colegio And evc1.nivel = ev1.nivel " & condigrado & condiseccion & condiMaestro2 &
                        "and evc1.tipotest=ev1.tipotest and evc2.numpregunta=cp.numpregunta and evc2.numopcion=cop.numopcion) as cuenta " &
                        "from evadoctest1 ev1 " &
                        "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " &
                        "inner join colegios co on co.colegio=ev1.colegio  " &
                        "inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " &
                        "inner join evaluapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest " &
                        "inner join evaluaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=cp.numpregunta " &
                        "inner join maestros ma on ma.codigo=ev1.codigo " &
                        "inner join areas ar on ma.area=ar.area  " &
                        "left join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest and cp.numpregunta = ev2.numpregunta " &
                        "And cop.numopcion = ev2.numopcion " &
                        "WHERE ev1.ciclo = '" & txtCiclo.Text & "' " & condiArea & condiTipoTest & condiNiveles & condiMaestro &
                        " group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel,ev1.grado,ev1.seccion, cp.numpregunta, cop.numopcion, cp.pregunta, " &
                        "cop.opcion, co.nombre, ni.nombre,  ct.nombre ) LL " &
                        "order by colegio,numpregunta,numopcion "


            End If



            Me.Cursor = Cursors.WaitCursor
            Dim cdata As New cmodelo(_conexionAcademia)
            cdata.llenaTabla(cadena, tabla, ListaParametros(lpara))
            cadeSubReporte = "exec proc_inve_estadistica " & txtCiclo.Text & "," & cmbTipoTest.SelectedValue & condiSubRep
            cdata.llenaTabla(cadeSubReporte, tbsubreporte)
            cdata.Commit()

            Dim tipo_grafica As Int16 = 0
            If cmbTipoGrafica.SelectedIndex <= 0 Then tipo_grafica = 1
            If cmbTipoGrafica.SelectedIndex > 0 Then tipo_grafica = cmbTipoGrafica.SelectedIndex
            If tabla.Rows.Count > 0 Then

                If rbPreguntasNi.Checked Then

                    r = New Grafica2022xnivel
                ElseIf rbPreguntaGr.Checked Then
                    r = New Grafica2022xgrado
                ElseIf rbPreguntaSec.Checked Then
                    r = New Grafica2022xseccion
                End If

                r.SetDataSource(tabla)
                'r.Subreports("tabla_grafico2022.rpt").SetDataSource(tbsubreporte)
                r.SetParameterValue("tipo_grafica", tipo_grafica)
                r.SetParameterValue("titulo", cmbTipoTest.Text)
                crv1.ReportSource = r

            Else
                MsgBox("NO EXISTEN REGISTROS PARA GENERAR ESTA CONSULTA", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                crv1.ReportSource = Nothing
                btnLimpiar_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox("Error del Sistema".ToUpper & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        crv1.ReportSource = Nothing
        TextColegio.Clear()
        cmbJornada.SelectedIndex = -1
        cmbNivel.SelectedIndex = -1
        cmbGrado.SelectedIndex = -1
        cmbSeccion.SelectedIndex = -1
        cmbAreas.SelectedIndex = -1
        cmbTipoTest.SelectedIndex = -1
        textNombreMaestro.Clear()
        textConxMaestro.Clear()
        rbPreguntasNi.Checked = True
        limpia()
    End Sub

    Private Sub cmbJornada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJornada.SelectedIndexChanged
        lpara.Clear()
        cmbNivel.Items.Clear()
        cmbGrado.Items.Clear()
        cmbSeccion.Items.Clear()
        TextNivel.Clear()
        TextGrado.Clear()
        lpara("colegio") = cmbJornada.Text
        If cmbJornada.Text.Trim <> "" Then
            TextColegio.Text = tbColegio.Rows.Item(cmbJornada.SelectedIndex).Item(1)
            cadena = "SELECT DISTINCT NIVEL, nombre FROM NIVELES WHERE COLEGIO=@colegio"
            llena_combo(cadena, cmbNivel, ListaParametros(lpara))
            llenaTabla(cadena, tbnivel, ListaParametros(lpara))
            cmbNivel.Focus()
            cadena = "select nombre,area from areas order by area"
            llenaTabla(cadena, tbareas)
            cmbAreas.DisplayMember = "nombre"
            cmbAreas.ValueMember = "area"
            cmbAreas.DataSource = tbareas

        End If
    End Sub

    Private Sub cmbNivel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNivel.SelectedIndexChanged
        lpara.Clear()
        cmbGrado.Items.Clear()
        cmbSeccion.Items.Clear()
        TextGrado.Clear()
        lpara("colegio") = cmbJornada.Text
        lpara("nivel") = cmbNivel.Text
        If cmbNivel.Text.Trim <> "" Then
            TextNivel.Text = tbnivel.Rows.Item(cmbNivel.SelectedIndex).Item(1)
            cadena = "SELECT DISTINCT GRADO, nombre FROM GRADOS WHERE COLEGIO=@colegio AND NIVEL=@nivel"
            llena_combo(cadena, cmbGrado, ListaParametros(lpara))
            llenaTabla(cadena, tbgrado, ListaParametros(lpara))
            cmbGrado.Focus()
        End If
    End Sub

    Private Sub cmbGrado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrado.SelectedIndexChanged
        lpara.Clear()
        cmbSeccion.Items.Clear()
        lpara("colegio") = cmbJornada.Text
        lpara("nivel") = cmbNivel.Text
        lpara("grado") = cmbGrado.Text

        If cmbGrado.Text.Trim <> "" Then
            TextGrado.Text = tbgrado.Rows.Item(cmbGrado.SelectedIndex).Item(1)
            cadena = "SELECT DISTINCT SECCION FROM CATALOGOCOLEGIO WHERE COLEGIO=@colegio AND NIVEL=@nivel AND GRADO=@grado "
            llena_combo(cadena, cmbSeccion, ListaParametros(lpara))
            cmbSeccion.Focus()
        End If
    End Sub

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
        lpara.Clear()

        lpara("colegio") = cmbJornada.Text
        lpara("nivel") = cmbNivel.Text
        lpara("grado") = cmbGrado.Text
        lpara("seccion") = cmbSeccion.Text
        If cmbJornada.Text <> "" Then
            condiNiveles = " and b.colegio=@colegio "
        End If
        If cmbNivel.Text <> "" Then
            condiNiveles = condiNiveles & " and b.nivel=@nivel "
        End If
        If cmbGrado.Text <> "" Then
            condiNiveles = condiNiveles & " and b.grado=@grado "
        End If
        If cmbSeccion.Text <> "" Then
            condiNiveles = condiNiveles & " and b.seccion=@seccion "
        End If
        If cmbAreas.Text <> "" Then
            lpara("area") = tbareas.Rows(cmbAreas.SelectedIndex).Item("area")
            condiArea = " and a.area=@area "
        End If

        lpara("nombre") = textNombreMaestro.Text.Trim
        'cadena = "select * from (select distinct(a.codigo),nom1+' '+nom2+' '+apell1+' '+apell2 as nombre from maestros a " &
        '         " left join maestrosporseccion b on a.codigo=b.codigo where a.codigo<>0 " & condiNiveles & condiArea & " ) as a" &
        '         " where a.nombre like '%' + @nombre + '%'order by nombre"
        cadena = "SELECT * FROM (SELECT DISTINCT a.codigo, CONCAT_WS(' ', nom1, nom2, apell1, apell2) AS nombre 
                  FROM maestros a 
                  LEFT JOIN maestrosporseccion b ON a.codigo = b.codigo 
                  WHERE a.codigo <> 0)  AS a
                  WHERE a.nombre LIKE '%' + @nombre + '%'
                  ORDER BY nombre"

        numFilas = llenaTabla(cadena, tbmaestro, ListaParametros(lpara))
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
        lpara.Clear()
        lpara("codigo") = textConxMaestro.Text.Trim
        If valida_tipo_Entero(textConxMaestro.Text, 2) = True Then
            If BuscaEscalar("select * from (select codigo,nom1+' '+nom2+' '+apell1+' '+apell2 as nombre from maestros where codigo<>0) as a where a.codigo =@codigo", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL DOCENTE NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraMaestro(True)
                textConxMaestro.Focus()
                Exit Sub
            End If
            cadena = "select * from (select codigo,nom1+' '+nom2+' '+apell1+' '+apell2 as nombre from maestros where codigo<>0) as a where a.codigo =@codigo"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
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

    Private Sub txtCiclo_Validated(sender As Object, e As EventArgs) Handles txtCiclo.Validated
        If Not String.IsNullOrEmpty(txtCiclo.Text) Then
            llenaTipoTest(txtCiclo.Text)
        End If
    End Sub


#End Region
End Class