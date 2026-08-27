Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMALTASUS.VB MIEMBRO DE NOMINA.SLN                                         **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmAltaSus
    Dim comando As New SqlCommand
    Dim dr As SqlDataReader
    Dim tbAlta As New DataTable("alta")
    Dim cadena, tibase As String
    Dim empleado, numero As Int32
    Dim contrato As Int16
    Dim fechaI, fechaF As Date
    Dim base As Decimal
    Dim valor As Decimal


    Public Sub Inicializa(ByVal numeroArg As Int32, ByVal contratoArg As Int16, ByVal empleadoArg As Int32, ByVal fechaArgI As Date)
        numero = numeroArg
        contrato = contratoArg
        empleado = empleadoArg
        fechaI = fechaArgI
    End Sub

    Private Sub frmBajaContra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cadena = "select nombre, tipoAl from tiposalta order by tipoAl"
        llena_combo(cadena, cmbAlta)
        llenaTabla(cadena, tbAlta)
    End Sub

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        If Not validetError(TextFechaFinal, ep1) Or Not validetError(cmbAlta, ep1) Or Not validetError(TextCantidad, ep1) Then
            Exit Sub
        End If
        Dim modelo As New cmodelo
        Try
            cadena = "update suspensiones set tipoal=" & tbAlta.Rows(cmbAlta.SelectedIndex).Item(1) & _
            ", fechaf='" & fechaF.ToShortDateString & "', cantidad=" & TextCantidad.Text & ", valor=" & CDec(TextValor.Text) & _
            ", estado=2 where empresa=" & empresa & " and numero=" & _
            numero
            modelo.EjecutarNonQuery(cadena)
            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            modelo.Commit()

        Catch ex As Exception
            MsgBox("Error del Sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            modelo.RollBack()
        End Try
        regresar()
    End Sub

    Private Sub textFecha_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextFechaFinal.Validated
        Dim diferencia As Int32
        If TextFechaFinal.Text <> "  /  /" Then
            If validetError(TextFechaFinal, ep1) = True Then
                fechaF = TextFechaFinal.Text
                If fechaF < fechaI Then
                    MsgBox("FECHA FINAL DEBE SER MAYOR QUE LA FECHA DE INICIO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    TextCantidad.Clear()
                    TextValor.Text = "0.00"
                    TextFechaFinal.Clear()
                    Exit Sub
                End If
                cadena = "SELECT tp.tibase, tb.base  FROM CONTRATOS1 C1 inner join tipopersonal tp on c1.empresa= tp.empresa " & _
                         "and c1.tipoper=tp.tipoper inner join tiposbase tb on c1.empresa=tb.empresa and  " & _
                         "tp.tibase=tb.tibase where c1.empresa=" & empresa & "  and empleado=" & empleado & " and contrato=" & contrato
                abrir_conexion(cn)
                comando = New SqlCommand(cadena, cn)
                dr = comando.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    tibase = dr.Item(0)
                    base = dr.Item(1)
                Else
                    tibase = ""
                    base = 0
                End If
                dr.Close()
                'Cambio del calculo del valor con la transaccion de afecta='S'
                cadena = "select coalesce (sum(valor),0)  from sueldos where transac=1 and empresa=" & empresa & _
                         " and contrato=" & contrato & " and empleado=" & empleado
                valor = BuscaEscalar(cadena)
                diferencia = (fechaF.Day - fechaI.Day) + ((fechaF.Month - fechaI.Month) * 30) + ((fechaF.Year - fechaI.Year) * 360)
                If tibase = "D" Then
                    TextCantidad.Text = diferencia
                ElseIf tibase = "H" Then
                    TextCantidad.Text = (diferencia * base) / 30
                Else
                    TextCantidad.Text = ""
                End If
                TextValor.Text = formato((valor / base) * CInt(TextCantidad.Text))




            Else
                TextCantidad.Clear()
                TextValor.Text = "0.00"
                TextFechaFinal.Clear()
            End If
        Else
            TextCantidad.Clear()
            TextValor.Text = "0.00"
        End If
    End Sub

    Public Event actValor(ByVal sender As Object, ByVal e As clsActValorREvento)

    Private Sub regresar()
        Dim argumentos As clsActValorREvento
        argumentos = New clsActValorREvento("", 1)
        RaiseEvent actValor(Me, argumentos)
        Me.Close()
    End Sub


    Private Sub frmDatosGen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Foco(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAlta.Enter, TextFechaFinal.Enter, _
  TextCantidad.Enter, TextValor.Enter
        activa(sender)
    End Sub


    Private Sub Deja(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAlta.Leave, TextFechaFinal.Leave, _
  TextCantidad.Leave, TextValor.Leave
        desactiva(sender)
    End Sub

    Private Sub TextCantidad_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextCantidad.Validated
        If TextCantidad.Text.Trim <> "" Then
            If CInt(TextCantidad.Text) <> 0 Then
                cadena = "SELECT  tb.base  FROM CONTRATOS1 C1 inner join tipopersonal tp on c1.empresa= tp.empresa " & _
                       "and c1.tipoper=tp.tipoper inner join tiposbase tb on c1.empresa=tb.empresa and  " & _
                       "tp.tibase=tb.tibase where c1.empresa=" & empresa & "  and empleado=" & empleado & " and contrato=" & contrato
                base = BuscaEscalarBatch(cadena)
                cadena = "select coalesce (sum(valor),0)  from sueldos where transac=1 and empresa=" & empresa & _
                           " and contrato=" & contrato & " and empleado=" & empleado
                valor = BuscaEscalarBatch(cadena)
                cn.Close()
                TextValor.Text = formato((valor / base) * CInt(TextCantidad.Text))
            Else
                TextValor.Text = "0.00"
            End If
        Else
            TextValor.Text = "0.00"
        End If
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub


    Private Sub TextCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextCantidad.KeyPress
        soloNumero(sender, e)
    End Sub



    Private Sub TextValor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextValor.TextChanged

    End Sub
End Class