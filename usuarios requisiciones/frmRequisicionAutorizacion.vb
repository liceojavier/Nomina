Imports System.Data.SqlClient
Public Class frmRequisicionAutorizacion
    Dim WithEvents f1 As frmMuestraUsuarios
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Dim realizar, realizar1 As Boolean
    Dim unavez, unavez1 As Boolean
    Dim cadena As String = ""


    Private Sub frmRequisicionAutorizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextNombEmpresa.Text = "ASOCIACION JAVERIANA"
    End Sub

#Region "Empleado"
    Private Sub btnEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        cadena = "select a.empleado,a.nombre1 from emplegen a inner join contratos1 b on a.empleado=b.empleado where b.contrato in (0,4)  order by empleado"
        f1 = New frmMuestraUsuarios
        realizar = True
        If (unavez = False) Then
            AddHandler f1.actValor, AddressOf ActualizacionDatos
            unavez = True
            unavez1 = False
        End If
        f1.inicializa(cadena)
        f1.TopMost = True
        f1.ShowDialog()
    End Sub

    Private Sub ActualizacionDatos(ByVal sender As Object, ByVal e As clsActValorREvento) Handles f1.actValor
        'Este es un evento creado para ir a traer datos en tiempo real de otra forma
        If (realizar = True) Then
            TextEmpleado.Text = e.va1
            tt1.SetToolTip(TextEmpleado, e.va2)
            TextEmpleado_Validated(sender, e)
            realizar = False
            unavez = False
            realizar1 = False
            unavez1 = False
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextEmpleado.Validated
        If TextEmpleado.Text <> "" Then
            cadena = "select nombre1 from emplegen where empleado=" & TextEmpleado.Text
            abrir_conexion(cn)
            Dim com As New SqlCommand(cadena, cn)
            If com.ExecuteScalar Is Nothing Then
                cn.Close()
                MsgBox("NO EXISTE ESE EMPLEADO")
                tt1.SetToolTip(TextEmpleado, "")
                TextEmpleado.Clear()
                TextEmpleado.Focus()
            Else
                TextNombEmpleado.Text = com.ExecuteScalar
                tt1.SetToolTip(TextEmpleado, Trim(com.ExecuteScalar))
                cn.Close()

            End If

        End If
    End Sub
#End Region

#Region "Autorizador nivel1"

    Private Sub btnEmpleado1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubalterno.Click
        cadena = "select a.empleado,a.nombre1 from emplegen a inner join contratos1 b on a.empleado=b.empleado where b.contrato in (0,4)  order by empleado"
        f1 = New frmMuestraUsuarios
        realizar1 = True
        If (unavez1 = False) Then
            AddHandler f1.actValor, AddressOf ActualizacionDatos1
            unavez1 = True
            unavez = False
        End If
        f1.inicializa(cadena)
        f1.TopMost = True
        f1.ShowDialog()
    End Sub

    Private Sub ActualizacionDatos1(ByVal sender As Object, ByVal e As clsActValorREvento) Handles f1.actValor
        'Este es un evento creado para ir a traer datos en tiempo real de otra forma
        If (realizar1 = True) Then
            TextEmpleado1.Text = e.va1
            tt2.SetToolTip(TextEmpleado1, e.va2)
            TextEmpleado1_Validated(sender, e)
            realizar1 = False
            unavez1 = False
            realizar = False
            unavez = False
        End If
    End Sub

    Private Sub TextEmpleado1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextEmpleado1.Validated
        If TextEmpleado1.Text <> "" Then
            cadena = "select nombre1 from emplegen where empleado=" & TextEmpleado1.Text
            abrir_conexion(cn)
            Dim com As New SqlCommand(cadena, cn)
            If com.ExecuteScalar Is Nothing Then
                cn.Close()
                MsgBox("NO EXISTE ESE EMPLEADO")
                tt2.SetToolTip(TextEmpleado1, "")
                TextEmpleado1.Clear()
                TextEmpleado1.Focus()
            Else
                TextNombEmpleado1.Text = com.ExecuteScalar
                tt2.SetToolTip(TextEmpleado1, Trim(com.ExecuteScalar))
                cn.Close()

            End If

        End If
    End Sub


#End Region



End Class