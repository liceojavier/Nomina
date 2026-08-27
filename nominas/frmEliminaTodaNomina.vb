Public Class frmEliminaTodaNomina


    Dim cadena As String
    Dim lpara As New Dictionary(Of String, Object)
    Dim tbTipo As New DataTable

    Private Sub frmEliminaTodaNomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMes)
        cmbMes.Items.Add("")
        TextAño.Text = System.DateTime.Now.Year
        EscribeEmpresa(TextNombEmpresa, TextMoneEmpresa)
        cmbMes.SelectedIndex = System.DateTime.Now.Month - 1
        cadena = "select nombre, tiponom, cantidad, por, movimientos, desprestamos from tiponomina1 where empresa=@empresa "
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")


    End Sub

    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click


        lpara.Clear()
        Dim año, mes As Int16
        Dim tiponom As String
        Dim tbPrestamo As New DataTable
        Dim i As Int32 = 0
        Dim filatemp As DataRow

        If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item("tiponom") ' Tipo Nomina

        año = CInt(TextAño.Text)
        mes = cmbMes.SelectedIndex + 1



        lpara("empresa") = empresa
        lpara("tiponom") = tipoNom
        lpara("mes") = mes
        lpara("año") = año
        lpara("estado") = 0

        cadena = "select count(*) from nomina_registro where estado=0 and empresa=@empresa and tiponom=@tiponom and mes=@mes and año=@año"
        Dim existeNom As Int32 = BuscaEscalar(cadena, ListaParametros(lpara))
        If existeNom > 0 Then
            MsgBox("Nómina ya ha generado pagos, no se puede generar, contacte a su administrador", MsgBoxStyle.Exclamation, "Nominas")
            Exit Sub
        End If

        'Verifica si la nomina esta ya realizada

        cadena = "select count(*) from nominas where empresa=@empresa and mes=@mes and año=@año and tiponom=@tiponom "
        existeNom = BuscaEscalar(cadena, ListaParametros(lpara))

        If existeNom > 0 Then
            If MsgBox($"¿Esta seguro que desea eliminar la nómina {cmbTipo.Text} de {cmbMes.Text} {TextAño.Text}", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                Exit Sub
            Else

                Dim cm As New cmodelo()
                Try
                    lpara("tipodocto") = "N" & tiponom.Trim
                    lpara("docto") = CInt((mes.ToString() & año.ToString()))
                    lpara("tiponom") = tiponom
                    lpara("mes") = mes
                    lpara("año") = año

                    cadena = "select prestamo, abonos from prestamos2 where empresa=@empresa and tipodocto=@tipodocto and docto=@docto and abonos <> 0 and tiponom=@tiponom  and mes=@mes and año=@año"
                    cm.llenaTabla(cadena, tbPrestamo, ListaParametros(lpara))
                    cadena = "delete prestamos2 where empresa=@empresa and tiponom=@tiponom  and mes=@mes and año=@año"
                    cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    'Si desea borrarla se anulan los descuentos hechos en los prestamos y se regresa el saldo
                    For i = 0 To tbPrestamo.Rows.Count - 1

                        filatemp = tbPrestamo.Rows(i)

                        lpara("prestamo") = filatemp.Item("prestamo")
                        lpara("abonos") = filatemp.Item("abonos")
                        cadena = "update prestamos1 set saldo= (select sum(cargos-abonos) from prestamos2 where prestamo=@prestamo) where empresa=@empresa and prestamo=@prestamo "
                        cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    Next i

                    cadena = "delete from nominas where empresa=@empresa and mes=@mes and año=@año and tiponom=@tiponom"
                    cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    If cm.Commit Then
                        InsertBitacora(9, 7, $"Eliminación de nómina {cmbTipo.Text} mes {cmbMes.Text} año {TextAño.Text}")
                    End If
                Catch ex As Exception
                    cm.RollBack()
                    MsgBox("Error al eliminar nómina " & vbNewLine & ex.Message, MsgBoxStyle.Critical)
                End Try




            End If

        Else
            MsgBox("No existen registros para eliminar")
        End If

    End Sub
End Class