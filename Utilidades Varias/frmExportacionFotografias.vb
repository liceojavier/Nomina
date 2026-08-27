Imports System.IO
Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMEXPORTACIONFOTOGRAFIAS.VB MIEMBRO DE NOMINA.SLN                          **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmExportacionFotografias
    Dim cadena As String
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim tabla As New DataTable("datos")
    Dim dpara As New Dictionary(Of String, Object)



    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        exportacion(1)
    End Sub

    Private Sub exportacion(tipo As Short)

        If Not String.IsNullOrEmpty(txtRuta.Text) Then
            dpara("empresa") = empresa

            Try
                Dim i = 0
                pbBarra.Minimum = 0
                If rbTodos.Checked Then
                    cadena = "select empleado, a.apellido1 + ' ' + a.apellido2 + ' ' + a.nombre1 + ' ' +  a.nombre2 
                              as nombre from emplegen a where empresa=@empresa order by empleado"
                Else
                    cadena = "select a.empleado, b.apellido1 + ' ' + b.apellido2 + ' ' + b.nombre1 + ' ' +  b.nombre2 
                              as nombre from contratos1 a
                              inner join emplegen b on a.empleado=b.empleado and a.empresa=b.empresa
                              where a.empresa=@empresa and a.estado in (0, 4) order by a.empleado"
                End If

                If llenaTabla(cadena, tabla, ListaParametros(dpara)) > 0 Then
                    pbBarra.Maximum = tabla.Rows.Count
                    For Each ftemp As DataRow In tabla.Rows
                        cadena = "select foto from fotoempleado where empresa=" & empresa &
                          " and empleado=" & ftemp.Item("empleado")
                        abrir_conexion(cn)
                        comando = New SqlCommand(cadena, cn)
                        dr = comando.ExecuteReader()
                        If dr.HasRows Then
                            dr.Read()
                            If dr.GetValue(0) IsNot DBNull.Value Then
                                Dim img As Image = Bytes2Image(CType(dr.GetValue(0), Byte()))
                                If img IsNot Nothing Then
                                    If (tipo = 1) Then
                                        img.Save(txtRuta.Text.Trim & "\" & ftemp.Item("empleado") & ".jpg")
                                    ElseIf tipo = 2 Then
                                        img.Save(txtRuta.Text.Trim & "\" & ftemp.Item("nombre") & ".jpg")
                                    End If

                                    ' Else
                                    '   picBoCuadro.Image = Nothing
                                End If
                                img.Dispose()
                            End If
                        Else
                        End If
                        dr.Close()
                        pbBarra.PerformStep()
                    Next

                    cn.Close()
                End If
                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information)
            Catch ex As Exception
                dr.Close()
                cn.Close()
                MsgBox("Error al generar la exportación " & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            End Try
            pbBarra.Value = 0
        Else
            MsgBox("Debe seleccionar una ubicación donde guardar los archivos", MsgBoxStyle.MsgBoxHelp)
        End If
    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        If fbdUbicacion.ShowDialog() = DialogResult.OK Then
            txtRuta.Text = fbdUbicacion.SelectedPath
        End If
    End Sub

    Private Sub frmExportacionFotografias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbTodos.Checked = True
        fbdUbicacion.RootFolder = Environment.SpecialFolder.MyComputer
        fbdUbicacion.SelectedPath = Environment.SpecialFolder.MyDocuments
    End Sub

    Private Sub btnExportaNombres_Click(sender As Object, e As EventArgs) Handles btnExportaNombres.Click
        exportacion(2)
    End Sub
End Class