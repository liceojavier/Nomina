Public Class FormMuestraCodigo
    Dim cadena As String
    Dim tbData As New DataTable()


    Public Property codigo As String = ""
    Public Property nombre As String = ""

    Public Property fila As DataRow
    Dim nombre_col As String = ""

    Public Sub inicializa(ByRef _tabla As DataTable)
        tbData = _tabla
        nombre_col = _tabla.Columns(1).ColumnName
    End Sub

    Private Sub define_vista()
        With dgvCod
            .Columns(0).FillWeight = 20
            .Columns(0).HeaderText = "Código"
            .Columns(1).FillWeight = 100
            .Columns(1).HeaderText = "Nombre"
            If (tbData.Columns.Count > 2) Then
                For i As Int32 = 2 To tbData.Columns.Count - 1
                    .Columns(i).Visible = False
                Next i
            End If
        End With
    End Sub
    Private Sub FormMuestraCodigos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCod.DataSource = tbData
        define_vista()
    End Sub
    Private Sub dgCuentas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvCod.DoubleClick
        If dgvCod.SelectedRows.Count > 0 Then
            Me.fila = CType(dgvCod.SelectedRows(0).DataBoundItem, DataRowView).Row
            Me.Close()
        Else
            MsgBox("SELECCIONE UN ELEMENTO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub




    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub FilterTXT_TextChanged(sender As Object, e As EventArgs) Handles FilterTXT.TextChanged
        If (FilterTXT.Text.Trim() <> "") Then
            tbData.DefaultView.RowFilter = String.Format("{0} like '%{1}%'", nombre_col, FilterTXT.Text.Trim)
        Else
            tbData.DefaultView.RowFilter = ""
        End If
    End Sub
End Class