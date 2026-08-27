'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMBAJACONTRA.VB MIEMBRO DE NOMINA.SLN                                      **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmBajaContra
    Dim tbEstados As New DataTable("tbEstado")
    Dim cadena As String
    Dim empleado As Int32
    Dim contrato As Int16
    Dim fechaI As Date

    Public Sub Inicializa(ByVal contratoArg As Int16, ByVal empleadoArg As Int32, ByVal fechaArgI As Date)
        contrato = contratoArg
        empleado = empleadoArg
        fechaI = fechaArgI
    End Sub

    Private Sub frmBajaContra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cadena = "select nombre, estado from empestados where activo='N'"
        llena_combo(cadena, cmbEstado)
        llenaTabla(cadena, tbEstados)
    End Sub

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Dim fechaF As Date
        If Not validetError(TextFechaFinal, ep1) Or Not validetError(cmbEstado, ep1) Or Not validetComilla(TextObserva, ep1) Then
            Exit Sub
        End If
        fechaF = TextFechaFinal.Text
        If fechaF <= fechaI Then
            MsgBox("FECHA FINAL DEL CONTRATO DEBE SER MAYOR QUE LA FECHA DE INICIO DEL CONTRATO", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        Dim modelo As New cmodelo
        Try

        
            cadena = "update contratos1 set estado=" & tbEstados.Rows(cmbEstado.SelectedIndex).Item(1) & _
            ", fechaf='" & fechaF & "', observa='" & TextObserva.Text & "',fechae='" & Today.ToShortDateString & "' where empresa=" & empresa & " and empleado=" & _
            empleado & " and contrato=" & contrato
            modelo.EjecutarNonQuery(cadena)
            modelo.Commit()
            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            regresar()
        Catch ex As Exception
            MsgBox("ERROR DEL SISTEMA   " & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            modelo.RollBack()
        End Try
        

    End Sub

    Private Sub textFecha_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextFechaFinal.Validated
        If TextFechaFinal.Text = "  /  /" Then
            TextFechaFinal.Text = Today.ToShortDateString
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

    Private Sub Foco(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEstado.Enter, TextFechaFinal.Enter, _
  TextObserva.Enter
        activa(sender)
    End Sub


    Private Sub Deja(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEstado.Leave, TextFechaFinal.Leave, _
  TextObserva.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub







End Class