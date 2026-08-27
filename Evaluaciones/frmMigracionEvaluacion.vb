Public Class frmMigracionEvaluacion

    Dim tbmigrar As New DataTable("migrar")
    Dim tbciclo As New DataTable("ciclo")
    Dim cadena As String = ""
    Dim lpara As New Dictionary(Of String, Object)
    '    ProgressBar1.Maximum = (100 / tickerArray.Length) * tickerArray.Length
    'ProgressBar1.Show()

    'For Each tickerValue In tickerArray
    '    Historical_Stock_Prices.addBulk_Historical_Stock_Prices(tickerValue, tblName)
    '    ProgressBar1.Value += (100 / tickerArray.Length)
    'Next tickerValue


    Private Sub frmMigracionEvaluacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cdata As New cmodelo(_conexionAcademia)
        cadena = "select distinct(ciclo) from evaluatipotest order by ciclo desc"
        cdata.llenaTabla(cadena, tbciclo)
        cdata.Commit()
        llena_combo_academia(cadena, cmbCicloAnterior)
        limpia()
        ProgressBar1.Maximum = 5


    End Sub
    Private Sub btnMigrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMigrar.Click
        'buscar test en ciclo actual
        Dim cdata As New cmodelo(_conexionAcademia)
        lpara.Clear()
        lpara("ciclo") = Year(Now)
        cadena = "select * from evaluatipotest where ciclo=@ciclo "
        If cdata.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
            MsgBox("REGISTRO POSEE REFERENCIA, POR FAVOR VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Exit Sub
        End If
        Try
            lpara("cicloAnterior") = cmbCicloAnterior.Text
            cadena = "insert into evaluatipotest " &
                     "select tipotest,'" & Year(Now) & "' as ciclo,nombre,id_instrumento,grupo_asignacion,tipo from evaluatipotest where ciclo= @cicloAnterior "
            cdata.EjecutarNonQuery(cadena, ListaParametros(lpara))
            ProgressBar1.Value = 1
            cadena = "insert into evalua_areas " &
                     "select empresa,'" & Year(Now) & "' as ciclo,area,nombre from evalua_areas where ciclo= @cicloAnterior "
            cdata.EjecutarNonQuery(cadena, ListaParametros(lpara))
            ProgressBar1.Value = 2
            cadena = "insert into evalua_rasgos " &
                     "select id_rasgo,'" & Year(Now) & "' as ciclo,nombre from evalua_rasgos where ciclo= @cicloAnterior "
            cdata.EjecutarNonQuery(cadena, ListaParametros(lpara))
            ProgressBar1.Value = 3
            cadena = "insert into evaluapreguntas " &
                     "select empresa,'" & Year(Now) & "' as ciclo,tipotest,area,id_rasgo,numpregunta,pregunta,id_compespecifica," &
                     "id_grupo, maximas, minimas, opcion_vertical, instrucciones, grupo_respuesta " &
                     "from evaluapreguntas where ciclo= @cicloAnterior "
            cdata.EjecutarNonQuery(cadena, ListaParametros(lpara))
            ProgressBar1.Value = 4
            cadena = "insert into evaluaopciones " &
                    "select empresa,'" & Year(Now) & "' as ciclo,tipotest,numpregunta,numopcion,opcion,valor from evaluaopciones where ciclo= @cicloAnterior "
            cdata.EjecutarNonQuery(cadena, ListaParametros(lpara))
            ProgressBar1.Value = 5
            If cdata.Commit() Then
                MsgBox("Operación realizada con éxito!", MsgBoxStyle.Information, "Mensaje del sistema")
            End If
        Catch ex As Exception
            cdata.RollBack()
            MsgBox(" Error al insertar datos " & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            Exit Sub
        End Try


    End Sub

    Private Sub limpia()

        'cmbCicloAnterior.SelectedIndex = -1
        'cmbTestActual.SelectedIndex = -1
        'cmbTestAnterior.SelectedIndex = -1
        'txtCicloActual.Text = Year(Today).ToString
        txtCicloActual.Text = Year(Now)
        btnMigrar.Enabled = False
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpia()
    End Sub

    Private Sub cmbCicloAnterior_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCicloAnterior.SelectedIndexChanged
        If cmbCicloAnterior.Text <> "" Then
            btnMigrar.Enabled = True
        End If
    End Sub

    
End Class