Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMREPORTEADOR.VB MIEMBRO DE NOMINA.SLN                                     **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmReporteador
    Dim v As New cyrImpReportes
    Dim cadena As String
    Dim tbEmpleado As New DataTable("empleado")
    Dim filatemp As DataRow
    Dim fEmp As frmMuestra2Columnas
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim fechaNacR, fechaNacE, fechaIng As Date
    Dim empleado, contrato As Int32

    Public Sub Inicializador(ByVal empArg As Int32, ByVal contArg As Int32)
        empleado = empArg
        contrato = contArg
    End Sub

    Private Sub frmReporteador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub frmReporteador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextFecha.Text = Today
    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim reporte As New ReportClass
        If Not validetError(TextFecha, ep1) Then
            MsgBox("ERROR EN EL INGRESO DEL EMPLEADO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        Dim tbInfo As New DataTable
        fechaIng = TextFecha.Text

        Select Case cmbTipo.SelectedIndex
            Case 0
                reporte = New Crycontrato_docentes
            Case 1
                reporte = New Crycontrato_administrativo
            Case 2
                reporte = New Crycontrato_tecnico_administrativo
            Case 3
                reporte = New Crycontrato_servicios_generales

        End Select

        cadena = "select * from v_empleadoContrato where empresa=" & empresa & " and empleado=" & _
        empleado & " and contrato=" & contrato
        llenaTabla(cadena, tbInfo)
        If tbInfo.Rows.Count > 0 And DateTime.TryParse(TextFecha.Text, fechaIng) Then

            If fechaIng < fechaNacE Or fechaIng < fechaNacR Then
                MsgBox("LA FECHA INGRESADA DEBE SER MAYOR QUE LA FECHA DE NACIMIENTO DEL REPRESENTANTE LEGAL", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If
            tbInfo.Rows(0)("fechaImp") = fechaIng

            reporte.SetDataSource(tbInfo)
            crv.ReportSource = reporte
            crv.Refresh()
        Else
            MsgBox("ERROR AL SELECCIONAR EL EMPLEADO O REPRESENTANTE LEGAL", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub
End Class