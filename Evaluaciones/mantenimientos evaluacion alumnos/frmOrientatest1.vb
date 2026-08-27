Imports System.Data.SqlClient

Public Class frmOrientatest1
    Dim ciclo As String = Date.Now.Year.ToString()
    Dim lpara As New Dictionary(Of String, Object)
    Dim generalQuery As String = ""
    Private Sub frmOrientatest1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCodAlumno.Focus()
        txtCiclo.Text = ciclo
        LoadData(generalQuery)
        FillComboNivel()
    End Sub

    Private Sub LoadData(queryById As String)

        Dim cmodel As New cmodelo(_conexionSociograma)
        Dim query As String = ""
        Dim dt As New DataTable
        lpara.Clear()
        lpara("colegio") = "M"
        lpara("ciclo") = txtCiclo.Text
        lpara("num_alumno") = txtCodAlumno.Text

        If cmbNivel.SelectedValue <> "" And cmbGrado.SelectedValue <> 0 And cmbSeccion.Text <> "" Then
            lpara("nivel") = cmbNivel.SelectedValue
            lpara("grado") = cmbGrado.SelectedValue
            lpara("seccion") = cmbSeccion.Text
        End If

        Try
            query = "select a.id_orientatest1,a.ciclo,a.tipotest,e.nombretest,a.num_alumno,
                     b.apell1+' '+b.apell2+' '+b.nom1+' '+b.nom2+' '+b.nom3 as Alumno,
                     a.fecha,a.colegio,a.nivel,c.NOMBRE as nombNivel,a.grado,d.NOMBRE as nombGrado,a.seccion  
                     from sg_orientatest1 a
                     inner join datos_alumnos b on a.num_alumno=b.num_alumno and a.ciclo=b.ciclo
                     inner join NIVELES c on a.colegio=c.COLEGIO and a.nivel=c.NIVEL
                     inner join GRADOS d on a.colegio=d.COLEGIO and a.nivel=d.NIVEL and a.grado=d.GRADO
                     inner join sg_culturatipotest1 e on a.tipotest=e.tipotest 
                     where a.colegio=@colegio and a.ciclo=@ciclo " + generalQuery

            cmodel.llenaTabla(query, dt, ListaParametros(lpara))
            dgData.Rows.Clear()
            For Each rows As DataRow In dt.Rows
                dgData.Rows.Add(
                    rows.Item("id_orientatest1"),
                    rows.Item("ciclo"),
                    rows.Item("nombretest"),
                    rows.Item("tipotest"),
                    rows.Item("num_alumno"),
                    rows.Item("Alumno"),
                    rows.Item("fecha"),
                    rows.Item("colegio"),
                    rows.Item("nivel"),
                    rows.Item("nombNivel"),
                    rows.Item("grado"),
                    rows.Item("nombGrado"),
                    rows.Item("seccion")
                )
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del sistema")
        End Try
    End Sub
    Private Sub FillComboNivel()
        Dim cmodel As New cmodelo(_conexionSociograma)
        Dim query As String = ""
        Dim dt As New DataTable
        Dim lpara As New Dictionary(Of String, Object)
        Try
            query = "select NIVEL,NOMBRE from NIVELES where COLEGIO=@colegio and NIVEL in('K','P','S')"
            lpara("colegio") = "M"
            cmodel.llenaTabla(query, dt, ListaParametros(lpara))
            cmbNivel.DataSource = dt
            cmbNivel.DisplayMember = "NOMBRE"
            cmbNivel.ValueMember = "NIVEL"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del sistema")
        End Try
    End Sub
    Private Sub FillComboGrado()
        Dim cmodel As New cmodelo(_conexionSociograma)
        Dim query As String = ""
        Dim dt As New DataTable
        Dim lpara As New Dictionary(Of String, Object)
        Try
            query = "select GRADO,NOMBRE from GRADOS where COLEGIO=@colegio and NIVEL=@nivel"
            lpara("colegio") = "M"
            lpara("nivel") = cmbNivel.SelectedValue
            cmodel.llenaTabla(query, dt, ListaParametros(lpara))
            cmbGrado.DataSource = dt
            cmbGrado.DisplayMember = "NOMBRE"
            cmbGrado.ValueMember = "GRADO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del sistema")
        End Try
    End Sub

    Private Sub cmbNivel_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbNivel.SelectionChangeCommitted
        FillComboGrado()
    End Sub

    Private Sub btnBuscarPorAlumno_Click(sender As Object, e As EventArgs) Handles btnBuscarPorAlumno.Click
        If txtCodAlumno.Text <> "" Then
            generalQuery = " and a.num_alumno=@num_alumno"
            LoadData(generalQuery)
        End If
    End Sub

    Private Sub btnBuscarPorGrado_Click(sender As Object, e As EventArgs) Handles btnBuscarPorGrado.Click
        If cmbNivel.SelectedValue <> "" And cmbGrado.SelectedValue <> 0 And cmbSeccion.Text <> "" Then
            generalQuery = " and a.nivel=@nivel and a.grado=@grado and a.seccion=@seccion"
            LoadData(generalQuery)
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Dim query As String = ""
        Dim dt As New DataTable
        lpara.Clear()
        lpara("colegio") = "M"
        lpara("ciclo") = txtCiclo.Text
        lpara("num_alumno") = txtCodAlumno.Text
        lpara("nivel") = cmbNivel.SelectedValue
        lpara("grado") = cmbGrado.SelectedValue
        lpara("seccion") = cmbSeccion.Text
        generalQuery = ""
        LoadData(generalQuery)
    End Sub

    Private Sub ctxEliminar_Click(sender As Object, e As EventArgs) Handles ctxEliminar.Click
        Dim cmodel As New cmodelo(_conexionSociograma)
        Dim lpara As New Dictionary(Of String, Object)
        Dim query As String = ""
        lpara("id_orientatest1") = dgData.SelectedRows.Item(0).Cells("_id_orientatest1").Value
        lpara("ciclo") = dgData.SelectedRows.Item(0).Cells("_ciclo").Value
        lpara("num_alumno") = dgData.SelectedRows.Item(0).Cells("num_alumno").Value
        lpara("tipotest") = dgData.SelectedRows.Item(0).Cells("_tipotest").Value
        Try
            If dgData.Rows.Count > 0 Then
                If dgData.SelectedRows.Count > 0 Then
                    If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO SELECCIONADO.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then

                        query = "delete from sg_orientatest2 
                                 where id_orientatest1=@id_orientatest1 and ciclo=@ciclo and num_alumno=@num_alumno"

                        cmodel.EjecutarNonQuery(query, ListaParametros(lpara))

                        query = "delete from sg_orientatest1 
                                 where id_orientatest1=@id_orientatest1 and ciclo=@ciclo and num_alumno=@num_alumno and tipotest=@tipotest"

                        cmodel.EjecutarNonQuery(query, ListaParametros(lpara))

                        If (cmodel.Commit()) Then
                            MsgBox("REGISTRO ELIMINADO.", MsgBoxStyle.Information, "Mensaje del Sistema")
                            generalQuery = ""
                            LoadData(generalQuery)
                        End If
                    Else
                        MsgBox("DEBE SELECCIONAR UN REGISTRO PARA ELIMINAR.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    End If
                Else
                    MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                End If
            End If
        Catch ex As Exception
            cmodel.RollBack()
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub
End Class