Imports System.Data.SqlClient
Public Class FrmEvaluaVigencia
    Inherits Form
    Dim cadena As String
    Dim tbColegio As New DataTable("colegio")
    Dim tbnivel As New DataTable("nivel")
    Dim tbgrado As New DataTable("grado")
    Dim tbseccion As New DataTable("seccion")
    Dim tbMateria As New DataTable("materia")
    Dim tbTipoTest As New DataTable("tipotest")
    Dim tbAsignacion As New DataTable("Asignacion")
    Dim Gtipotest As Int32 = 0
    Dim editando As Int16 = 0
    Dim lpara As New Dictionary(Of String, Object)
    Private Sub FrmEvaluaVigencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cdata As New cmodelo(_conexionAcademia)
        'dpFechai.Format = DateTimePickerFormat.Custom
        'dpFechai.CustomFormat = "dd/MM/yyyy hh:mm tt"
        'dpFechaf.Format = DateTimePickerFormat.Custom
        'dpFechaf.CustomFormat = "dd/MM/yyyy hh:mm tt"

        txtCiclo.Text = Today.Year
        cadena = "select distinct colegio, nombre from Colegios"
        llena_combo(cadena, cmbJornada)
        llenaTabla(cadena, tbColegio)
        cmbJornada.Items.Add("")

        If txtCiclo.Text <> "" Then
            cadena = "select nombre,tipotest from evaluatipotest where ciclo= '" & txtCiclo.Text & "'"
            cdata.llenaTabla(cadena, tbTipoTest)
            llena_combo_academia(cadena, cmbTipoTest)
            cmbTipoTest.Items.Add("")
            cdata.Commit()
        End If


        limpiar()
        mostrardatos()
        llenarhoras()
    End Sub

#Region "cambio de indices"
    Private Sub cmbJornada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJornada.SelectedIndexChanged
        lpara.Clear()
        TextNivel.Text = ""
        TextGrado.Text = ""
        cmbGrado.Items.Clear()
        cmbSeccion.Items.Clear()
        lpara("colegio") = cmbJornada.Text
        If cmbJornada.Text.Trim <> "" Then
            cadena = "SELECT nivel, nombre FROM niveles WHERE COLEGIO=@colegio "
            llena_combo(cadena, cmbNivel, ListaParametros(lpara))
            llenaTabla(cadena, tbnivel, ListaParametros(lpara))
            cmbNivel.Items.Add("")
            TextColegio.Text = tbColegio.Rows(cmbJornada.SelectedIndex).Item("nombre")
            cmbNivel.Focus()
        End If
    End Sub

    Private Sub cmbNivel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNivel.SelectedIndexChanged
        lpara.Clear()
        cmbSeccion.Items.Clear()
        TextGrado.Text = ""
        lpara("colegio") = cmbJornada.Text
        lpara("nivel") = cmbNivel.Text
        If cmbNivel.Text.Trim <> "" Then
            cadena = "SELECT grado,nombre FROM grados WHERE COLEGIO=@colegio AND NIVEL=@nivel "
            llena_combo(cadena, cmbGrado, ListaParametros(lpara))
            llenaTabla(cadena, tbgrado, ListaParametros(lpara))
            cmbGrado.Items.Add("")
            TextNivel.Text = tbnivel.Rows(cmbNivel.SelectedIndex).Item("nombre")
            cmbGrado.Focus()
        End If
    End Sub

    Private Sub cmbGrado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrado.SelectedIndexChanged
        lpara.Clear()
        cmbSeccion.Items.Clear()
        TextGrado.Text = ""
        lpara("colegio") = cmbJornada.Text
        lpara("nivel") = cmbNivel.Text
        lpara("grado") = cmbGrado.Text
        If cmbGrado.Text.Trim <> "" Then
            cadena = "SELECT seccion FROM catalogocolegio WHERE COLEGIO=@colegio AND NIVEL=@nivel and GRADO=@grado"
            llena_combo(cadena, cmbSeccion, ListaParametros(lpara))
            llenaTabla(cadena, tbseccion, ListaParametros(lpara))
            cmbGrado.Items.Add("")
            TextGrado.Text = tbgrado.Rows(cmbGrado.SelectedIndex).Item("nombre")
            cmbGrado.Focus()
        End If
    End Sub


#End Region

#Region " limpieza y vista"
    Private Sub Define_Vista(ByRef grd As DataGridView)
        With grd
            .Columns(0).HeaderText = "Ciclo"
            .Columns(0).Width = 60
            .Columns(1).HeaderText = "Colegio"
            .Columns(1).Width = 60
            .Columns(2).HeaderText = "Nivel"
            .Columns(2).Width = 60
            .Columns(3).HeaderText = "Grado"
            .Columns(3).Width = 60
            .Columns(4).HeaderText = "Sección"
            .Columns(4).Width = 60
            .Columns(5).HeaderText = "ID EV"
            .Columns(5).Width = 60
            .Columns(6).HeaderText = "Evaluación"
            .Columns(6).Width = 300
            .Columns(7).HeaderText = "Fecha inicial"
            .Columns(7).Width = 100
            .Columns(8).HeaderText = "Fecha final"
            .Columns(8).Width = 100

            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue
        End With
    End Sub

    Private Sub limpiar()
        btnAgregar.Enabled = True
        btnBuscar.Enabled = True
        btnLimpiar.Enabled = True
        btnEditar.Enabled = False
        btnguardar.Visible = False
        btnEliminar.Enabled = False

        cmbJornada.SelectedIndex = -1
        cmbNivel.SelectedIndex = -1
        cmbGrado.SelectedIndex = -1
        cmbSeccion.SelectedIndex = -1
        cmbTipoTest.SelectedIndex = -1
        TextColegio.Clear()
        TextNivel.Clear()
        TextGrado.Clear()

        cmbJornada.Enabled = True
        cmbNivel.Enabled = True
        cmbGrado.Enabled = True
        cmbSeccion.Enabled = True
        cmbHorai.Text = "00:00"
        cmbHoraf.Text = "00:00"
        dgvAsignacion.DataSource = Nothing
        dgvAsignacion.Enabled = True
        editando = 0


    End Sub

    Public Sub llenarhoras()
        Dim i, j As Int32
        For i = 0 To 23
            For j = 0 To 59
                If j = 0 Or j = 30 Then
                    cmbHorai.Items.Add(i.ToString.PadLeft(2, "0"c) & ":" & j.ToString.PadLeft(2, "0"c))
                    cmbHoraf.Items.Add(i.ToString.PadLeft(2, "0"c) & ":" & j.ToString.PadLeft(2, "0"c))

                End If
            Next
        Next

    End Sub

    Public Sub mostrardatos()

        Dim cdata As New cmodelo(_conexionAcademia)
        cadena = "select a.ciclo,colegio,nivel,grado,seccion,a.tipotest,b.nombre,fecha_inicio,fecha_fin from evaluatipotest_vigencia a " &
                 "inner join evaluatipotest b on a.ciclo=b.ciclo and a.tipotest=b.tipotest"
        cdata.llenaTabla(cadena, tbAsignacion)
        cdata.Commit()
        dgvAsignacion.DataSource = tbAsignacion
        Define_Vista(dgvAsignacion)
    End Sub

#End Region


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim cdata As New cmodelo(_conexionAcademia)
        lpara.Clear()
        If Not validaError(cmbJornada, ep1) Or Not validaError(cmbNivel, ep1) Or Not validaError(cmbGrado, ep1) Or Not _
                validaError(cmbSeccion, ep1) Or Not validaError(cmbTipoTest, ep1) Or Not validaError(cmbHorai, ep1) Or Not validaError(cmbHoraf, ep1) Then
            MsgBox("Debe agregar todos los campos solicitados", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        Try

            Dim filas() As DataRow
            lpara("ciclo") = txtCiclo.Text
            lpara("tipotest") = Gtipotest
            lpara("colegio") = cmbJornada.Text
            lpara("nivel") = cmbNivel.Text
            lpara("grado") = cmbGrado.Text
            lpara("seccion") = cmbSeccion.Text
            lpara("fechai") = dpFechai.Value.ToString
            lpara("fechaf") = dpFechaf.Value.ToString
            filas = tbAsignacion.Select("colegio='" & cmbJornada.Text & "' and nivel='" & cmbNivel.Text & "' and grado=" & cmbGrado.Text & " and seccion='" & cmbSeccion.Text & "' and tipotest=" & Gtipotest)
            If filas.Count > 0 Then
                MsgBox("Ya Existe una Evaluación en esa Jornada, Nivel, Grado y Sección, Elimíne Primero la Asignación", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            Else
                cadena = "insert into evaluatipotest_vigencia(ciclo,tipotest,colegio,nivel,grado,seccion,fecha_inicio,fecha_fin) 
                          values (@ciclo,@tipotest,@colegio,@nivel,@grado,@seccion,@fechai,@fechaf)"
                cdata.EjecutarNonQuery(cadena, ListaParametros(lpara))
                cdata.Commit()
            End If
        Catch ex As Exception
            cdata.RollBack()
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
        mostrardatos()
        limpiar()
    End Sub

    Private Sub cmbHorai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHorai.SelectedIndexChanged
        Dim DTi As New DateTime(dpFechai.Value.Year, dpFechai.Value.Month, dpFechai.Value.Day, CInt(cmbHorai.Text.Split(":"c)(0)), CInt(cmbHorai.Text.Split(":"c)(1)), 0)
        dpFechai.Value = DTi
    End Sub

    Private Sub cmbHoraf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHoraf.SelectedIndexChanged
        Dim DTf As New DateTime(dpFechaf.Value.Year, dpFechaf.Value.Month, dpFechaf.Value.Day, CInt(cmbHoraf.Text.Split(":"c)(0)), CInt(cmbHoraf.Text.Split(":"c)(1)), 0)
        dpFechaf.Value = DTf
    End Sub

    Private Sub cmbTipoTest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoTest.SelectedIndexChanged
        If cmbTipoTest.SelectedIndex <> -1 Then
            Gtipotest = tbTipoTest.Rows(cmbTipoTest.SelectedIndex).Item("tipotest")
        End If
    End Sub

    Private Sub dgvAsignacion_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAsignacion.SelectionChanged

        If editando = 0 Then
            btnEliminar.Enabled = True
            btnEditar.Enabled = True
        Else

            btnEliminar.Enabled = False
            btnEditar.Enabled = False
        End If


    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim cdata As New cmodelo(_conexionAcademia)
        lpara.Clear()
        If (dgvAsignacion.SelectedRows(0).Cells("tipotest").Value) IsNot Nothing Then
            Try

                With dgvAsignacion.SelectedRows(0)
                    lpara("ciclo") = .Cells("ciclo").Value
                    lpara("colegio") = .Cells("colegio").Value
                    lpara("nivel") = .Cells("nivel").Value
                    lpara("grado") = .Cells("grado").Value
                    lpara("seccion") = .Cells("seccion").Value
                    lpara("tipotest") = .Cells("tipotest").Value
                    cadena = "delete evaluatipotest_vigencia where ciclo=@ciclo and colegio=@colegio and nivel=@nivel and grado=@grado and seccion=@seccion and tipotest=@tipotest"
                End With
                cdata.EjecutarNonQuery(cadena, ListaParametros(lpara))
                cdata.Commit()
            Catch ex As Exception
                cdata.RollBack()
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Sub
            End Try

        End If
        mostrardatos()
        limpiar()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        Try
            cmbJornada.Enabled = False
            cmbNivel.Enabled = False
            cmbGrado.Enabled = False
            cmbSeccion.Enabled = False
            btnAgregar.Enabled = False
            btnEliminar.Enabled = False
            btnEditar.Enabled = False
            btnguardar.Visible = True
            btnguardar.Enabled = True
            dgvAsignacion.Enabled = False
            editando = 1

            If (dgvAsignacion.SelectedRows(0).Cells("tipotest").Value) IsNot Nothing Then


                With dgvAsignacion.SelectedRows(0)
                    cmbJornada.Text = .Cells("colegio").Value
                    cmbNivel.Text = .Cells("nivel").Value
                    cmbGrado.Text = .Cells("grado").Value
                    cmbSeccion.Text = .Cells("seccion").Value
                    cmbTipoTest.Text = .Cells("nombre").Value
                    dpFechai.Value = .Cells("fecha_inicio").Value
                    dpFechaf.Value = .Cells("fecha_fin").Value

                    cmbHorai.Text = Hour(.Cells("fecha_inicio").Value).ToString.PadLeft(2, "0"c) & ":" & Minute(.Cells("fecha_inicio").Value).ToString.PadLeft(2, "0"c)
                    cmbHoraf.Text = Hour(.Cells("fecha_fin").Value).ToString.PadLeft(2, "0"c) & ":" & Minute(.Cells("fecha_fin").Value).ToString.PadLeft(2, "0"c)

                End With
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            Exit Sub
            End Try


    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Dim cdata As New cmodelo(_conexionAcademia)
        If editando = 0 Then
            Exit Sub
        End If
        lpara.Clear()
        If (dgvAsignacion.SelectedRows(0).Cells("tipotest").Value) IsNot Nothing Then
            Try

                With dgvAsignacion.SelectedRows(0)
                    lpara("tipotest") = Gtipotest
                    lpara("fechai") = dpFechai.Value.ToString
                    lpara("fechaf") = dpFechaf.Value.ToString

                    lpara("ciclo") = .Cells("ciclo").Value
                    lpara("colegio") = .Cells("colegio").Value
                    lpara("nivel") = .Cells("nivel").Value
                    lpara("grado") = .Cells("grado").Value
                    lpara("seccion") = .Cells("seccion").Value
                    lpara("tipotest") = .Cells("tipotest").Value
                    cadena = "update evaluatipotest_vigencia set tipotest=@tipotest, fecha_inicio=@fechai, fecha_fin=@fechaf where ciclo=@ciclo and colegio=@colegio and nivel=@nivel and grado=@grado and seccion=@seccion and tipotest=@tipotest "

                End With

                cdata.EjecutarNonQuery(cadena, ListaParametros(lpara))
                cdata.Commit()
            Catch ex As Exception
                cdata.RollBack()
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Sub
            End Try

        End If
        mostrardatos()
        limpiar()


    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim cdata As New cmodelo(_conexionAcademia)
        lpara.Clear()
        cadena = "select a.ciclo,colegio,nivel,grado,seccion,a.tipotest,b.nombre,fecha_inicio,fecha_fin from evaluatipotest_vigencia a " &
                 "inner join evaluatipotest b on a.ciclo=b.ciclo and a.tipotest=b.tipotest where 1=1"

        lpara("tipotest") = Gtipotest
        lpara("colegio") = cmbJornada.Text
        lpara("nivel") = cmbNivel.Text
        lpara("grado") = cmbGrado.Text
        lpara("seccion") = cmbSeccion.Text
        If cmbJornada.Text <> "" Then
            cadena += " and colegio=@colegio "
        End If
        If cmbNivel.Text <> "" Then
            cadena += " and nivel=@nivel "
        End If
        If cmbGrado.Text <> "" Then
            cadena += " and grado=@grado "
        End If
        If cmbSeccion.Text <> "" Then
            cadena += " and seccion= @seccion "
        End If
        If cmbTipoTest.Text <> "" Then
            cadena += " and a.tipotest=@tipotest "
        End If

        Try
            cdata.llenaTabla(cadena, tbAsignacion, ListaParametros(lpara))
            cdata.Commit()
            dgvAsignacion.DataSource = tbAsignacion
            Define_Vista(dgvAsignacion)
        Catch ex As Exception
            cdata.RollBack()
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            Exit Sub
        End Try

    End Sub

    Private Sub gbDatos_Enter(sender As Object, e As EventArgs) Handles gbDatos.Enter

    End Sub
End Class