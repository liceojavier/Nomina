Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class prueba
    Dim cadena As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fPrueba As New frmMuestra3Columnas
        fPrueba.X() = 2
        MsgBox(fPrueba.X)
        Ej()
    End Sub

    Private Sub prueba_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Ej()
        Dim tbDatos As New DataTable("datos")
        Dim ftemp As DataRow
        Dim i As Int32
        ' cadena = "select foto,empleado from fotoempleado where empresa=" & empresa 
        cadena = "select foto,empleado from fotoempleado where empresa=" & empresa & " and empleado in " & _
                 "(select distinct(a.empleado) from emplegen a  " & _
                 "inner join contratos1 b on a.empleado=b.empleado and a.empresa=b.empresa " & _
                 "inner join maestros c on a.empleado=c.empleado " & _
                 "inner join maestrosporseccion d on c.codigo=d.codigo " & _
                 "where b.estado in (0,4)) "
        If llenaTabla(cadena, tbDatos) Then
            For i = 0 To tbDatos.Rows.Count - 1
                ftemp = tbDatos.Rows(i)
                If ftemp.Item(0) IsNot DBNull.Value Then
                    Dim img As Image = Bytes2Image(CType(ftemp.Item(0), Byte()))
                    If img IsNot Nothing Then
                        img.Save("C:\tempfotos\fotos\" & ftemp.Item(1) & ".jpg")
                        ' Else
                        '   picBoCuadro.Image = Nothing
                    End If
                End If
            Next i
        Else
            MsgBox("NO HAY FOTOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub Reporte_Click(sender As Object, e As EventArgs) Handles Reporte.Click
        Dim r As ReportClass
        r = New ReportClass()
        r.Load()
    End Sub
End Class