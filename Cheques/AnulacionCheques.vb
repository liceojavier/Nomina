Imports NOMINA.dsConsultasTableAdapters
Imports System.Text

Public Class AnulacionCheques

    Dim cadena As String = ""
    Dim tbTipo As New DataTable()
    Dim tbDet As New dsConsultas.tbQAnulaChequeDataTable

    Private Sub AnulacionCheques_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim tbMes As New dsConsultas.mesesDataTable
        Dim taMeses As New mesesTableAdapter
        taMeses.Fill(tbMes)
        llena_combo(cmbMes, "nombre", "mes", tbMes)

        TextAño.Text = System.DateTime.Now.Year
        TextNombEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=" & empresa)
        cmbMes.SelectedIndex = System.DateTime.Now.Month - 1
        cadena = "select nombre, tiponom, cantidad, por, movimientos, desprestamos, tipago from tiponomina1 where empresa=" & _
        empresa
        llena_combo(cadena, cmbTipo)
        llenaTabla(cadena, tbTipo)
        cmbTipo.Items.Add("")
        cmbTipo.SelectedIndex = 0
    End Sub



    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Dim mes, año As Int16
        mes = 0
        año = 0
        Dim tiponom As String = ""
        If cmbTipo.Text.Trim <> "" AndAlso cmbMes.Text.Trim <> "" AndAlso Int16.TryParse(TextAño.Text, año) Then
            mes = cmbMes.SelectedValue
            tiponom = tbTipo.Rows(cmbTipo.SelectedIndex)("tiponom")
            Dim da As New TableAdapterQAnulaCheque
            da.Fill(tbDet, empresa, mes, año, "C", tiponom)
            bsData.DataSource = tbDet

        Else
            MsgBox("Debe ingresar el tipo de nómina, el mes y el año", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim fecha As DateTime
        If DateTime.TryParse(axFecha.Text, fecha) Then
            If MsgBox("Esta seguro que desea anular los cheques seleccionados", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                Dim i As Int32 = 0
                Dim fTemp As DataRow
                Dim cmod As New cmodelo()

                Dim strB As New StringBuilder
                Dim tbAnulacion As New DataTable
                Dim tbDiario As New DataTable
                Try
                    Dim corre As Int32 = cmod.BuscaEscalar("select nota from empresas where empresa=" & empresa)
                    For Each fila As dsConsultas.tbQAnulaChequeRow In tbDet.Rows
                        If fila.marca = True Then
                            corre += 1
                            cadena = "update cheque1 set estado=1,  fecha_Oper='" & fecha.ToShortDateString() & "' where empresa=" & empresa & _
                          " and banco=" & fila.banco & " and cheque=" & fila.cheque
                            cmod.EjecutarNonQuery(cadena)
                            strB.Append(fila.cheque)
                            strB.Append("-")
                            cadena = "update empresas set nota=" & corre & " where empresa=" & empresa
                            cmod.EjecutarNonQuery(cadena)
                            cadena = "select banco, banche, valor  from bantran where tipo=3 and empresa=" & empresa & " and banche=" & _
                                     fila.banco & " and docto=" & fila.cheque
                            cmod.llenaTabla(cadena, tbAnulacion)
                            For i = 0 To tbAnulacion.Rows.Count - 1
                                fTemp = tbAnulacion.Rows.Item(i)
                                cadena = "insert into bantran (empresa,banco,fecha,banche,tipo,docto,valor,beneficiario,concepto) values (" & _
                                         empresa & "," & fTemp.Item("banco") & ",'" & fecha & "'," & _
                                         fTemp.Item("banche") & ",1," & corre & "," & -fTemp.Item("valor") & ",'" & _
                                         "','ANULACION CHEQUE NOMINA " & fila.cheque & "')"
                                cmod.EjecutarNonQuery(cadena)
                            Next i
                            cadena = "select banco, origen, cuenta,codigo,haber,debe from diario2 where tipo=3 and empresa=" & empresa & _
                            " and banco=" & fila.banco & " and docto=" & fila.cheque
                            cmod.llenaTabla(cadena, tbDiario)
                            For i = 0 To tbDiario.Rows.Count - 1
                                fTemp = tbDiario.Rows.Item(i)
                                cadena = "insert into diario2 (empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber) values(" & empresa & ",1," & fTemp.Item("banco") & "," & corre & ",'" & _
                                fecha & "','" & fTemp.Item("origen") & "','" & fTemp.Item("cuenta") & "'," & fTemp.Item("codigo") & "," & fTemp.Item("haber") & "," & fTemp.Item("debe") & ")"
                                cmod.EjecutarNonQuery(cadena)
                            Next i
                            cadena = "insert into diario1 (empresa,tipo,banco,docto,fecha,beneficiario,monto,concepto) values(" & empresa & ",1," & fila.banco & "," & corre & ",'" & _
                            fecha & "','',0,'VALOR ANULACION CHEQUE " & fila.cheque & "')"
                            cmod.EjecutarNonQuery(cadena)
                        End If
                    Next

                    If cmod.Commit() Then
                        InsertBitacora(3, 3, "Anulación de cheques nomina cheque " + strB.ToString())
                        MsgBox("OPERACIÓN REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                        bsData.DataSource = Nothing
                    End If

                Catch ex As Exception
                    cmod.RollBack()
                    MsgBox("Error del Sistema " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                End Try
            End If

        Else
            MsgBox("Debe ingresar la fecha de anulación", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        axFecha.Clear()
        gvInfo.DataSource = Nothing
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub axFecha_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles axFecha.MaskInputRejected

    End Sub
End Class