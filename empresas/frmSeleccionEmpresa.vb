Public Class frmSeleccionEmpresa

    Dim cadena As String
    Dim inicio As Boolean = False

    Public Property MainMenu As MenuM


    Private Sub frmSeleccionEmpresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cadena = "select empresa, nombre from empresas order by empresa"
        Dim tbEmpresa As New DataTable
        llenaTabla(cadena, tbEmpresa)
        cmbEmpresa.ValueMember = "empresa"
        cmbEmpresa.DisplayMember = "nombre"
        cmbEmpresa.DataSource = tbEmpresa
        cmbEmpresa.SelectedValue = Definiciones.empresa
        inicio = True
    End Sub



    Private Sub cmbEmpresa_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedValueChanged
        If (cmbEmpresa.SelectedValue IsNot Nothing AndAlso TypeOf cmbEmpresa.SelectedValue Is Int16 AndAlso inicio = True) Then
            Definiciones.empresa = cmbEmpresa.SelectedValue
            _nombre_empresa = cmbEmpresa.Text
            MainMenu.Genera_informacion_empresa(empresa)
            MainMenu.InicializaPermisos()
            MainMenu.Muestra_informacion()
            MsgBox("Empresa cambiada a " & cmbEmpresa.Text)
        End If
    End Sub
End Class