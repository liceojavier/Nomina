Public Class frmBancos
    Dim cadena As String
    Dim emp As New DataTable("Origenes")
    Dim tip As String
    Public Sub inicializa(ByRef tbEnvio As DataTable)
        emp = tbEnvio
    End Sub
    Private Sub estilo()
        With dgBancos

            .Columns(0).Width = 80
            .Columns(0).HeaderText = "Correlativo"
            .Columns(1).Width = 300
            .Columns(1).HeaderText = "Cuenta"
            .Columns(2).Width = 75
            .Columns(2).HeaderText = "Moneda"
            .Columns(3).Visible = False
            .Columns(4).Visible = False
        End With
    End Sub
    Private Sub frmBancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgBancos.DataSource = emp
        estilo()
    End Sub
    Public Event actValor(ByVal sender As Object, ByVal e As clsActValorREvento)

    Private Sub dgBancos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBancos.CellDoubleClick

    End Sub

    Private Sub dgBancos_DoubleClick(sender As Object, e As EventArgs) Handles dgBancos.DoubleClick
        If dgBancos.SelectedRows.Count > 0 Then
            regresar()
        End If
    End Sub
    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub
    Private Sub regresar()
        Try
            Dim indice As Int32 = emp.Rows.IndexOf(CType(dgBancos.SelectedRows(0).DataBoundItem, DataRowView).Row)
            Dim argumentos As clsActValorREvento
            argumentos = New clsActValorREvento("", indice)
            RaiseEvent actValor(Me, argumentos)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class