Imports System.Data.SqlClient
Imports System.Collections.Generic
'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCONSPUESTOS.VB MIEMBRO DE NOMINA.SLN                                     **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmConsPuestos
    Inherits Form
    Dim cadena As String
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim tbCargos As New DataTable("cargos")
    Dim tbNiveles As New DataTable("niveles")
    Dim tbTitulos As New DataTable("titulos")
    Dim tbConsulta As New DataTable("consulta")
    Dim inicioConsulta As String = "select puesto,nombre,cargo,nivel,titulo,extras,buses,observa from puestosper p where empresa=" & empresa
    Dim indice As Int32
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
        borra_Mejorado(gpDatos, ep1)
        BorraElemento(TextConxPuesto, inactivo)
        ConsultaReadOnly(gpDatos, False)
        TextConxPuesto.ReadOnly = False
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnGuardar.Visible = False
        btnBuscar.Enabled = True
        btnBuscar.Visible = True
        ContextoMenuEnab(True, False, ctxMenu)
        TextConlNombre.Focus()
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        lpara.Clear()
        Dim finConsulta, cadenaConsulta As String
        finConsulta = ""
        GeneraConsulta(gpDatos, finConsulta, "p")
        If TextConxPuesto.Text.Trim <> "" Then
            lpara("puesto") = TextConxPuesto.Text
            finConsulta = finConsulta & " and p.puesto=@puesto "
        End If
        If cmbCargo.Text.Trim <> "" Then
            lpara("cargo") = tbCargos.Rows(cmbCargo.SelectedIndex).Item(1)
            finConsulta = finConsulta & " and p.cargo=@cargo "
        End If
        If cmbNivel.Text.Trim <> "" Then
            lpara("nivel") = tbNiveles.Rows(cmbNivel.SelectedIndex).Item(1)
            finConsulta = finConsulta & " and p.nivel=@nivel "
        End If
        If cmbTitulo.Text.Trim <> "" Then
            lpara("titulo") = tbTitulos.Rows(cmbTitulo.SelectedIndex).Item(1)
            finConsulta = finConsulta & " and p.titulo=@titulo "
        End If
        If cmbExtras.Text.Trim <> "" Then
            lpara("extras") = cmbExtras.Text
            finConsulta = finConsulta & " and p.extras=@extras"
        End If
        If cmbBus.Text.Trim <> "" Then
            lpara("buses") = cmbBus.Text
            finConsulta = finConsulta & " and p.Buses=@buses"
        End If
        cadenaConsulta = inicioConsulta & finConsulta & " order by p.puesto asc"
        Mostrar(cadenaConsulta, sender, e)
    End Sub

    Private Sub Mostrar(ByVal subCadena As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        ConsultaReadOnly(gpDatos, True)
        TextConxPuesto.ReadOnly = True
        btnBuscar.Enabled = False
        ContextoMenuEnab(True, True, ctxMenu)
        indice = 0
        If llenaTabla(subCadena, tbConsulta, ListaParametros(lpara)) > 0 Then
            LlenarTextBox(0, tbConsulta)
        Else
            MsgBox("NO HAY REGISTROS CON ESTOS CRITERIOS DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
        End If
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub

    Private Sub LlenarTextBox(ByVal indi As Int16, ByVal tabla As DataTable)
        Dim FilaCopiar As DataRow
        FilaCopiar = tabla.Rows.Item(indi)
        TextConxPuesto.Text = FilaCopiar.Item(0)
        TextConlNombre.Text = FilaCopiar.Item(1)
        BuscaElementoCombo(tbCargos, FilaCopiar.Item(2), cmbCargo, 1, False)
        TextCargo.Text = cmbCargo.Text
        BuscaElementoCombo(tbNiveles, FilaCopiar.Item(3), cmbNivel, 1, True)
        TextNivel.Text = cmbNivel.Text
        BuscaElementoCombo(tbTitulos, FilaCopiar.Item(4), cmbTitulo, 1, False)
        TextTitulo.Text = cmbTitulo.Text
        cmbExtras.SelectedIndex = cmbExtras.FindStringExact(FilaCopiar.Item(5))
        TextExtras.Text = cmbExtras.Text
        cmbBus.SelectedIndex = cmbBus.FindStringExact(FilaCopiar.Item(6))
        TextBus.Text = cmbBus.Text
        TextConlObserva.Text = FilaCopiar.Item(7)
    End Sub



    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        lpara.Clear()
        Dim cargo, nivel, titulo As String
        If validetError(TextConlNombre, ep1) = False Or validetError(cmbCargo, ep1) = False Or
         validetError(cmbTitulo, ep1) = False Or validetError(cmbExtras, ep1) = False Or
         validetError(cmbBus, ep1) = False Or validetComilla(TextConlObserva, ep1) = False Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        cargo = tbCargos.Rows(cmbCargo.SelectedIndex).Item("cargo")
        nivel = tbNiveles.Rows(cmbNivel.SelectedIndex).Item(1)
        titulo = tbTitulos.Rows(cmbTitulo.SelectedIndex).Item(1)

        Try
            lpara("nombre") = TextConlNombre.Text
            lpara("cargo") = cargo
            lpara("nivel") = nivel
            lpara("titulo") = titulo
            lpara("extras") = cmbExtras.Text
            lpara("buses") = cmbBus.Text
            lpara("observa") = TextConlObserva.Text
            lpara("empresa") = empresa
            lpara("puesto") = TextConxPuesto.Text
            If MsgBox("DESEA ACTUALIZAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                cadena = "update puestosper set nombre=@nombre,cargo=@cargo,nivel=@nivel,titulo=@titulo, extras=@extras, buses=@buses, observa=@observa " &
                         "where empresa=@empresa and puesto=@puesto "
                EjecutarQuery(cadena, ListaParametros(lpara))
                btnLimpiar_Click(sender, e)
                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("ERROR EN EL INGRESO DE DATOS", MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try

    End Sub

#Region "SubMenu"

    Private Sub MnuElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        lpara.Clear()
        lpara("puesto") = TextConxPuesto.Text
        lpara("empresa") = empresa
        If MsgBox("ESTA SEGURO DE ELIMINAR ESTE REGISTRO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            If BuscaEscalar("select count(*) from contratos1 where puesto=@puesto and empresa=@empresa", ListaParametros(lpara)) > 0 Then
                MsgBox("REGISTRO POSEE REFERENCIA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Sub
            End If
            'verificar si tiene referencia en inscripciones
            cadena = "delete from puestosper where puesto=@puesto and empresa=@empresa"
            EjecutarQuery(cadena, ListaParametros(lpara))
            btnLimpiar_Click(sender, e)
            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub


    Private Sub MnuModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click
        ConsultaReadOnly(gpDatos, False)
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnGuardar.Visible = True
        btnBuscar.Visible = False
        TextConlNombre.BackColor = ColorModi
        cmbBus.BackColor = ColorModi
        cmbCargo.BackColor = ColorModi
        cmbNivel.BackColor = ColorModi
        cmbExtras.BackColor = ColorModi
        cmbTitulo.BackColor = ColorModi
        TextConlObserva.BackColor = ColorModi
        ContextoMenuEnab(False, True, ctxMenu)
    End Sub

#End Region


#Region "Botones Siguiente y Atras"
    Private Sub btnSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSig.Click
        indice = indice + 1
        LlenarTextBox(indice, tbConsulta)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub

    Private Sub btnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtr.Click
        indice = indice - 1
        LlenarTextBox(indice, tbConsulta)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub
#End Region






    Private Sub frmRutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextConlNombre.Enter, _
      cmbCargo.Enter, cmbExtras.Enter, cmbNivel.Enter, cmbTitulo.Enter, TextConlObserva.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextConlNombre.Leave, _
      cmbCargo.Leave, cmbExtras.Leave, cmbNivel.Leave, cmbTitulo.Leave, TextConlObserva.Leave
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub gpDatos_Enter(sender As Object, e As EventArgs) Handles gpDatos.Enter

    End Sub
End Class