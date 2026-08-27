Imports NOMINA.dsConsultasTableAdapters
Imports NOMINA.dsConsultas

Public Class frmRegistroNominas
    Private Sub frmRegistroNominas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextAño.Text = Today.Year
        QueryRegistroNominaTableAdapter.Fill(DsConsultas1.QueryRegistroNomina, empresa, Today.Year)


    End Sub

    Private Sub TextAño_Validated(sender As Object, e As EventArgs) Handles TextAño.Validated
        Dim año As Int16 = 0
        If Not Int16.TryParse(TextAño.Text, año) Then
            MsgBox("Año no posee formato válido", MsgBoxStyle.Critical, "Mensaje del Sistema")
            TextAño.Text = Today.Year
            año = Today.Year
        End If
        QueryRegistroNominaTableAdapter.Fill(DsConsultas1.QueryRegistroNomina, empresa, año)
    End Sub

    Private Sub TextFiltro_TextChanged(sender As Object, e As EventArgs) Handles TextFiltro.TextChanged
        If (Not String.IsNullOrEmpty(TextFiltro.Text.Trim)) Then
            bsPrincipal.Filter = String.Format("tiponom_nombre like '%{0}%' or mes_nombre like '%{0}%' or estado_nombre like '%{0}%' or usuario like '%{0}%' or usuarioe like '%{0}%'", TextFiltro.Text.Trim)
        Else
            bsPrincipal.Filter = ""
        End If
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        If dgvData.SelectedRows.Count > 0 Then
            Dim dr As QueryRegistroNominaRow = CType(dgvData.SelectedRows(0).DataBoundItem, DataRowView).Row
            If MsgBox($"¿Está seguro que desea anular el registro {dr.tiponom_nombre} del mes de {dr.mes_nombre}", MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If dr.estado = 0 Then
                    Try
                        QueryRegistroNominaTableAdapter.UpdateQuery(dr.id_nr)
                        dr.estado = 1
                        dr.estado_nombre = "Anulado"
                    Catch ex As Exception
                        MsgBox("Error al anular el registro", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    End Try
                Else
                    MsgBox("Registro ya se encuentra anulado", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
            End If
        End If
    End Sub
End Class