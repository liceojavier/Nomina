Imports System.ComponentModel

Public Class frmEvaluaAreas2

    Private _validacion As Boolean = True
    Private Sub dgvData_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvData.DataError
        Try
            If e.RowIndex >= 0 And e.RowIndex < dgvData.Rows.Count Then
                MsgBox($"Error en columna { dgvData.Columns(e.ColumnIndex).HeaderText } " & vbNewLine & e.Exception.Message)
                e.Cancel = True
            End If
        Catch ex As Exception
            MsgBox("Error en la validación")
        End Try

    End Sub


    Private Sub dgvData_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvData.RowValidating
        If _validacion And e.RowIndex >= 0 And e.RowIndex < dgvData.Rows.Count Then
            Dim dr As DataGridViewRow = dgvData.Rows(e.RowIndex)
            dr.Cells("empresa").Value = Definiciones.empresa
            If dr.Cells("nombre").Value Is DBNull.Value OrElse String.IsNullOrEmpty(dr.Cells("nombre").Value) Then
                e.Cancel = True
                MsgBox("Debe ingresar un nombre ", MsgBoxStyle.Critical, "Validación")
            End If
            If dr.Cells("area").Value Is DBNull.Value Then
                e.Cancel = True
                MsgBox("Debe ingresar un área ", MsgBoxStyle.Critical, "Validación")
            End If
        End If

    End Sub

    'Private Sub dgvData_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgvData.UserDeletingRow
    '    If e.Row Then
    'End Sub

    Private Sub Evalua_areasBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles Evalua_areasBindingNavigatorSaveItem.Click
        Me.Validate()
        If Me.DataSetAcademia.evalua_areas.HasErrors Then
            Me.Evalua_areasBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.DataSetAcademia)
        Else
            MsgBox("Existen errores")
        End If



    End Sub

    Private Sub frmEvaluaAreas2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DataSetAcademia.evalua_areas' Puede moverla o quitarla según sea necesario.
        Me.Evalua_areasTableAdapter.Fill(Me.DataSetAcademia.evalua_areas, Definiciones.empresa)
    End Sub

    Private Sub dgvData_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgvData.UserDeletingRow
        MsgBox("inicio")
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.Click
        _validacion = False
    End Sub

    Private Sub dgvData_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgvData.UserDeletedRow
        _validacion = True
    End Sub
End Class