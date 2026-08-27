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

Public Class frmImpContratos
    Dim v As New cyrImpReportes
    Dim cadena As String

    Dim filatemp As DataRow
   
    Dim fechaNacR, fechaNacE, fechaIng As Date
    Dim empleado, contrato As Int32
    Dim tbEmple As New DataTable
    Dim tbGenerales As New DataTable("generales")

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
        cadena = "select a.empleado, rtrim( a.nombre1 + ' ' + a.nombre2) + ' ' +  rtrim(a.apellido1 + ' ' + a.apellido2) as nombre, " & _
                 "b.contrato, c.nombre as nombre_puesto, c.puesto, cast (0 as bit) as marca " & _
                 "from emplegen a " & _
                 "inner join contratos1 b on a.empleado=b.empleado and a.empresa=b.empresa " & _
                 "inner join puestosper c on a.empresa=c.empresa and b.puesto=c.puesto " & _
                 "inner join empestados d on a.empresa=d.empresa and b.estado=d.estado " & _
                 "where a.empresa=" & empresa & " and d.activo='S' " & _
                 "order by a.apellido1, a.apellido2, a.nombre1, a.nombre2 "
        llenaTabla(cadena, tbEmple)
        dgvEmple.DataSource = tbEmple

        Dim tbPuestos As New DataTable
        cadena = "select puesto, nombre from puestosper " & _
                 "where empresa =" & empresa & " " & _
                 "order by puesto "
        llenaTabla(cadena, tbPuestos)
        tbPuestos.Rows.Add("0", "")
        cmbPuesto.ValueMember = "puesto"
        cmbPuesto.DisplayMember = "nombre"
        cmbPuesto.DataSource = tbPuestos
        cmbPuesto.SelectedValue = 0
    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim reporte As New ReportClass
        Dim findMark As Boolean = False
        Dim fgeneralestemp As DataRow
        Dim tipo As Int16 = 0
        Dim tbInfo As New DataTable
        fechaIng = TextFecha.Text
        tipo = cmbTipo.SelectedIndex
        Select Case cmbTipo.SelectedIndex
            Case 0
                reporte = New Crycontrato_docentes
            Case 1
                reporte = New Crycontrato_administrativo
            Case 2
                reporte = New Crycontrato_tecnico_administrativo
            Case 3
                reporte = New Crycontrato_servicios_generales
            Case 4
                reporte = New Crycontrato_vigilancia
            Case 5
                reporte = New Crycontrato_monitoras

        End Select

        Dim condi As String = ""
        For Each dr As DataRow In tbEmple.Rows
            If (dr.Item("marca") = True) Then
                If condi.Length > 0 Then
                    condi += " or "
                Else
                    condi += ""
                End If

                condi += "( empleado=" & dr.Item("empleado") & " and contrato=" & dr.Item("contrato") & ")"
                findMark = True
            End If
        Next
        If condi.Length > 0 Then
            condi = "(" & condi & ")"

        End If

        If condi <> "" Then
            cadena = "select * from v_empleadoContrato where empresa=" & empresa & " and " & condi & " order by empleado, contrato"
        Else
            cadena = "select * from v_empleadoContrato where empresa=" & empresa & " order by empleado, contrato"
        End If

        llenaTabla(cadena, tbInfo)

        cadena = "select representante,nacional,registro as dpirep,profesion as profesionrep,datediff(year,FECHANAC,getdate()) as edadrep from generales where empresa= " & empresa
        llenaTabla(cadena, tbGenerales)

        If cmbTipo.Text.Trim <> "" And tbInfo.Rows.Count > 0 And DateTime.TryParse(TextFecha.Text, fechaIng) And findMark = True Then

            For Each dr As DataRow In tbInfo.Rows
                dr("fechaImp") = fechaIng
            Next

            reporte.SetDataSource(tbInfo)

            If tbGenerales.Rows.Count > 0 Then
                fgeneralestemp = tbGenerales.Rows(0)
                reporte.SetParameterValue("representante", fgeneralestemp.Item("representante"))
                reporte.SetParameterValue("dpirep", fgeneralestemp.Item("dpirep"))
                reporte.SetParameterValue("profesionrep", fgeneralestemp.Item("profesionrep"))
                reporte.SetParameterValue("edadrep", fgeneralestemp.Item("edadrep"))
                reporte.SetParameterValue("nacionalidad", fgeneralestemp.Item("nacional"))
                If tipo = 5 Then
                    reporte.SetParameterValue("jornada", txtJornada.Text)
                End If
            End If

            crv.ReportSource = reporte
            crv.Refresh()
        Else
            MsgBox("NO HA SELECCIONADO UN EMPLEADO O EL TIPO DE CONTRATO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Public Sub filtro()
        Dim condi As String = "1=1"
        If (TextNombre.Text.Trim <> "") Then
            condi += " and nombre like '%" & TextNombre.Text.Trim() & "%' "
        End If
        If (cmbPuesto.Text.Trim <> "") Then
            condi += " and puesto=" & cmbPuesto.SelectedValue.ToString() & " "
        End If
        tbEmple.DefaultView.RowFilter = condi
    End Sub




    Private Sub TextNombre_TextChanged(sender As Object, e As EventArgs) Handles TextNombre.TextChanged
        filtro()
    End Sub

    Private Sub cmbPuesto_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPuesto.SelectedValueChanged
        filtro()
    End Sub

    Private Sub btnMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMark.Click
        For Each dr As DataRow In tbEmple.Rows
            dr.Item("marca") = True
        Next
    End Sub

    Private Sub btnDesMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesmark.Click
        For Each dr As DataRow In tbEmple.Rows
            dr.Item("marca") = False
        Next
    End Sub
End Class