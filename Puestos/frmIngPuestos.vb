Imports System.Data.SqlClient
Imports System.Collections.Generic
'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMINGPUESTOS.VB MIEMBRO DE NOMINA.SLN                                      **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmIngPuestos
    Dim cadena As String
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim tbCargos As New DataTable("cargos")
    Dim tbNiveles As New DataTable("niveles")
    Dim tbTitulos As New DataTable("titulos")
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmIngPuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        TextEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=@empresa", ListaParametros(lpara))
        cadena = "select nombre, cargo from cargosmin order by cargo"
        llena_combo(cadena, cmbCargo)
        cmbCargo.Items.Add("")
        llenaTabla(cadena, tbCargos)
        cadena = "select nombre, nivel from nivelesaca order by nivel"
        llena_combo(cadena, cmbNivel)
        cmbNivel.Items.Add("")
        llenaTabla(cadena, tbNiveles)
        cadena = "select nombre, titulo from titulos where operable='S' order by titulo"
        llena_combo(cadena, cmbTitulo)
        llenaTabla(cadena, tbTitulos)
        cmbTitulo.Items.Add("")
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lpara.Clear()
        lpara("empresa") = empresa
        TextConxPuesto.Text = BuscaEscalar("select coalesce( max(puesto),0) from puestosper where empresa=@empresa", ListaParametros(lpara)) + 1
        borra_Mejorado(gpDatos, ep1)
        TextConlNombre.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        lpara.Clear()
        Dim cargo, nivel, titulo As String
        If validetError(TextConlNombre, ep1) = False Or validetError(cmbCargo, ep1) = False Or
         validetError(cmbTitulo, ep1) = False Or validetError(cmbExtras, ep1) = False Or
         validetError(cmbBus, ep1) = False Or validetComilla(TextObservaciones, ep1) = False Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        cargo = tbCargos.Rows(cmbCargo.SelectedIndex).Item("cargo")
        nivel = tbNiveles.Rows(cmbNivel.SelectedIndex).Item(1)
        titulo = tbTitulos.Rows(cmbTitulo.SelectedIndex).Item(1)
        lpara("empresa") = empresa
        lpara("puesto") = TextConxPuesto.Text
        If BuscaEscalar("select count(*) from puestosper where empresa=@empresa and puesto=@puesto", ListaParametros(lpara)) > 0 Then
            MsgBox("CORRELATIVO DE PUESTO YA INGRESADO, INTENTELO NUEVAMENTE", MsgBoxStyle.Information, "Mensaje del Sistema")
            TextConxPuesto.Text = BuscaEscalar("select coalesce( max(puesto),0) from puestosper where empresa=" & empresa) + 1
            Exit Sub
        End If

        Try
            lpara.Clear()
            lpara("empresa") = empresa
            lpara("puesto") = TextConxPuesto.Text
            lpara("nombre") = TextConlNombre.Text
            lpara("cargo") = cargo
            lpara("nivel") = nivel
            lpara("titulo") = titulo
            lpara("extras") = cmbExtras.Text
            lpara("bus") = cmbBus.Text
            lpara("observa") = TextObservaciones.Text
            If MsgBox("DESEA GUARDAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                cadena = "insert into puestosper (empresa,puesto,nombre,cargo,nivel,titulo, extras, buses,observa) 
                          values (@empresa,@puesto,@nombre,@cargo,@nivel,@titulo,@extras,@bus,@observa)"
                EjecutarQuery(cadena, ListaParametros(lpara))
                btnLimpiar_Click(sender, e)
                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("ERROR EN EL INGRESO DE DATOS", MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try

    End Sub

    Private Sub frmRutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextConlNombre.Enter, _
      cmbCargo.Enter, cmbExtras.Enter, cmbNivel.Enter, cmbTitulo.Enter, TextObservaciones.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextConlNombre.Leave, _
      cmbCargo.Leave, cmbExtras.Leave, cmbNivel.Leave, cmbTitulo.Leave, TextObservaciones.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub stbPanel_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles stbPanel.ItemClicked

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class