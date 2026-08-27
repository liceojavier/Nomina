Imports System.Windows.Forms
Imports System.IO.File
Imports System.Globalization.CultureInfo

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMMENUP.VB MIEMBRO DE NOMINA.SLN                                           **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmMenuP
    Dim fM As Form
    Dim tbPermiso As DataTable


    Private Sub frmMenuP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        la1.Text = roles_auth
        la2.Text = usuario
        la3.Text = Today.Date.ToShortDateString
        la4.Text = "Inicio de Sesión: " & Now.ToShortTimeString
        '    If roll = 21 Then
        'mnuPriMantenimientos.Enabled = False
        ' mnuPriEmpledos.Enabled = False
        ' mnuPriMovimientos.Enabled = False
        'mnuPriNominas.Enabled = False
        'ElseIf roll = 30 Then
        'mnuIngCheque.Enabled = False
        'mnuImpCheques.Enabled = False
        'mnuTrasladoCheques.Enabled = False
        'ElseIf (roll = 10 And rolc = 1) Or cadrol = 100 Then
        'mnuPriCheques.Enabled = False
        'mnuMovNominas.Enabled = False
        'mnuPriMovimientos.Enabled = False
        'mnuPriMantenimientos.Enabled = False
        'mnuPriNominas.Enabled = False
        'mnuPriSeguroSocial.Enabled = False
        'mnuIngContratos.Enabled = False
        'mnuIngEmple.Enabled = False
        'mnuSueldos.Enabled = False
        'mnuContratosCosto.Enabled = False
        'mnuListISR.Enabled = False
        'mnuLibroDeSalarios.Enabled = False
        'mnuProyeIndem.Enabled = False
        'mnuEstadistica.Enabled = False
        'mnuConsContratos.Enabled = False
        'ToolStripMenuItem1.Enabled = False
        'ElseIf roll = 25 Then
        'End If
        If CurrentCulture.Name.Trim.ToUpper <> ("ES-GT") Then
            MsgBox("DEBE CAMBIAR PRIMERO SU CONFIGURACION REGIONAL A GUATEMALA ", MsgBoxStyle.Information, "Mensaje del Sistema")
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub ubica(ByRef f As Form)
        'Ubica la ventana dentro del formulario principal de menu.
        Dim i As Int32
        Dim c As Form
        Dim existe As Boolean = False
        For i = 0 To Me.MdiChildren.Length - 1
            c = Me.MdiChildren(i)
            If c.Name = f.Name Then
                existe = True
                Exit For
            Else
                c.WindowState = FormWindowState.Minimized
            End If
        Next
        If existe Then
            c.Activate()
            c.StartPosition = FormStartPosition.CenterParent
            c.WindowState = FormWindowState.Normal
            c.Focus()
            c.Location = New Point(1, 1)
        Else
            f.MdiParent = Me
            f.Show()
            f.Location = New Point(1, 1)
        End If
    End Sub

    Private Sub ubica(ByRef f As Form, titulo As String)
        'Ubica la ventana dentro del formulario principal de menu.
        Dim i As Int32
        Dim c As Form
        Dim existe As Boolean = False
        For i = 0 To Me.MdiChildren.Length - 1
            c = Me.MdiChildren(i)
            If c.Name = f.Name AndAlso c.Text = titulo Then
                existe = True
                Exit For
            Else
                c.WindowState = FormWindowState.Minimized
            End If
        Next
        If existe Then
            c.Activate()
            c.StartPosition = FormStartPosition.CenterParent
            c.WindowState = FormWindowState.Normal
            c.Focus()
            c.Location = New Point(1, 1)
        Else
            f.MdiParent = Me
            f.Show()
            f.Location = New Point(1, 1)
        End If
    End Sub

    Public Sub InicializaPermisos()
        Dim cadena As String = ""
        cadena = "select * from permisos where id_rol=" & IdRol & " order by id_permiso"
        tbPermiso = New DataTable("permisos")
        llenaTabla(cadena, tbPermiso)

        For Each MenuItem1 As ToolStripMenuItem In MainMenuStrip.Items
            MenuItem1.Enabled = VerificaPermiso(MenuItem1.Text)
            If MenuItem1.HasDropDownItems Then
                GeneraArbol(MenuItem1)
            End If
        Next
    End Sub

    Private Sub GeneraArbol(ByVal item As ToolStripMenuItem)
        For Each MenuItemHijo As ToolStripMenuItem In item.DropDownItems
            If MenuItemHijo.Text <> "-" Then
                MenuItemHijo.Enabled = VerificaPermiso(MenuItemHijo.Text)
                If MenuItemHijo.HasDropDownItems Then
                    GeneraArbol(MenuItemHijo)
                End If

            End If
        Next
    End Sub

    Private Function VerificaPermiso(ByVal Nombre_Permiso As String) As Boolean
        For Each ftemp As DataRow In tbPermiso.Rows

            If ftemp.Item("nombre").ToString.ToLower.Trim = Nombre_Permiso.ToLower.Trim Then
                If ftemp.Item("acceso") = True Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
        Return False
    End Function

    Private Sub mnuDpto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDpto.Click
        fM = New frmDepartamentos
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuMunic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMunic.Click
        fM = New frmMunicipios
        fM.Text = sender.text
        ubica(fM)
    End Sub


    Private Sub mnuTipoIden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTipoIden.Click
        fM = New frmIdentifica
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuNacional_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNacional.Click
        fM = New frmNacionalidades
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuCargosMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCargosMin.Click
        fM = New frmCargosMin
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuEstadoContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEstadoContrato.Click
        fM = New frmEstatusContrato
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuFormPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFormPago.Click
        fM = New frmFormaPagoPer
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuNivelAcademico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNivelAcademico.Click
        fM = New frmNivelAca
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuTipoSeguro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTipoSeguro.Click
        fM = New frmSeguroSocial
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuSocioEconomica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSocioEconomica.Click
        fM = New frmSocioEconomica
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuEstadoAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEstadoAlta.Click
        fM = New frmTipoAlta
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuLesiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLesiones.Click
        fM = New frmLesion
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuSuspen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSuspen.Click
        fM = New frmTiposSuspension
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuPrestamos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrestamos.Click
        fM = New frmTipoPrestamo
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuTipoBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTipoBase.Click
        fM = New frmTipoBase
        fM.Text = sender.text
        ubica(fM)
    End Sub


    Private Sub mnuIngPuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIngPuestos.Click
        fM = New frmIngPuestos
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuMantPuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMantPuestos.Click
        fM = New frmConsPuestos
        fM.Text = sender.text
        ubica(fM)
    End Sub


    Private Sub mnuIngEmple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIngEmple.Click
        Dim fMe As New frmIngEmpleados
        fMe.Consulta = False
        fMe.Text = sender.text
        ubica(fMe)
    End Sub

    Private Sub mnuConsEmple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsEmple.Click
        Dim fMe As New frmIngEmpleados
        fMe.Consulta = True
        fMe.Text = sender.text
        ubica(fMe, fMe.Text)
    End Sub

    Private Sub mnuIngContratos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIngContratos.Click
        fM = New frmIngContratos
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuConsContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsContratos.Click
        fM = New frmConsContratos
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuIngCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIngCheque.Click
        fM = New frmIngChequeNom
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuConsCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsCheque.Click
        If roll = 30 Then
            fM = New frmSoloConsultaCheques
        Else
            fM = New frmConsultaCheques
        End If
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuIngTipoNom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIngTipoNom.Click
        fM = New frmIngTipoNomina
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuConsTipoNomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsTipoNomina.Click
        fM = New frmIngConxNomina
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuNomiQuince_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNomiQuince.Click
        fM = New frmGenePagoNomiQui
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuGeneraMensual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGeneraMensual.Click
        fM = New frmGenePagoMensual
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuEliminaNomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminaNomina.Click
        fM = New frmEliminaNomi
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuGeneraPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGeneraPago.Click
        fM = New frmGeneraPago
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuConsNomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsNomina.Click
        fM = New frmConsultaPago
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuTrasladoCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTrasladoCheques.Click
        fM = New frmTrasladoChNomina
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuMovNominas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMovNominas.Click
        fM = New frmMantMovNominas
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuIngPrestamos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIngPrestamos.Click
        Dim fP As New frmConsPrestamos
        fP.nuevo_registro = True
        fP.Text = sender.text
        ubica(fP)
    End Sub

    Private Sub mnuConsPrestamos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsPrestamos.Click
        Dim fP As New frmConsPrestamos
        fP.nuevo_registro = False
        fP.Text = sender.text
        ubica(fP)
    End Sub

    Private Sub mnuIngSuspensiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIngSuspensiones.Click
        fM = New frmIngSuspensiones
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuConsSuspen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsSuspen.Click
        fM = New frmSuspensiones
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuListNomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSubListados.Click
        fM = New frmListadosNomina
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub ImpresiónDeChequesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImpCheques.Click
        fM = New frmImpresionCheque
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub ImpresiónDeRecibosEnGrupoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpresiónDeRecibosEnGrupoToolStripMenuItem.Click
        fM = New frmImpresionRecibo
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub GeneraciónDeArchivoDelBancoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneraciónDeArchivoDelBancoToolStripMenuItem.Click
        fM = New frmArchivoBanco
        fM.Text = sender.text
        ubica(fM)
    End Sub

 


    Private Sub mnuLibroDeSalarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLibroDeSalarios.Click
        fM = New frmLibroSalario
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuConsultaDelLibroDeSalarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaDelLibroDeSalarios.Click
        fM = New frmConsultaLibroSalario
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuImpSeguroSocial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImpSeguroSocial.Click
        fM = New frmListadoSeguroSocial
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuEstadistica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEstadistica.Click
        fM = New frmGeneraEstadistica
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuListEmpleados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListEmpleados.Click
        fM = New frmListadoEmpleados
        fM.Text = sender.text
        ubica(fM)
    End Sub

 
    Private Sub Cerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
        Application.Exit()
    End Sub

    Private Sub mnuProyeIndem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProyeIndem.Click
        fM = New frmListadoProyecIndeminzacion
        fM.Text = sender.text
        ubica(fM)
    End Sub

   
   
    Private Sub mnuIngTransac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIngTransac.Click
        fM = New frmIngTipoTran
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuConsTransac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsTransac.Click
        fM = New frmConsTipoTran
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuListadoSueldos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSueldos.Click
        fM = New frmListadoSueldos
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuListadoCotratos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSueldos.Click
        fM = New frmConsTipoTran
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuContratosCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContratosCosto.Click
        fM = New frmListadoContratosCentro
        fM.Text = sender.text
        ubica(fM)
    End Sub


    Private Sub mnuListTransaccionesNomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListTransaccionesNomina.Click
        fM = New frmListadoTransacciones
        fM.Text = sender.text
        ubica(fM)
    End Sub

    
    Private Sub mnuListMovNominas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListMovNominas.Click
        fM = New frmListadoMovimientoVariables
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuBono14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBono14.Click
        fM = New frmGeneraBono14
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuAguinaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVacAgui.Click
        fM = New frmGenePagoVacacionesEsp
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuListPagosEfectuados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListPagosEfectuados.Click
        fM = New frmListadoPagos
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuListISR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListISR.Click
        fM = New frmIngresoImpuestoISR
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuListadoChequeExtra1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListadoChequeExtra1.Click
        fM = New frmListadoExtraNomina
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuListadoTipotran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cadena As String
        Dim tbTipotran As New DataTable("transaccion")
        Dim fMR As New FrmMuestraReporte
        Dim v As New cryListadoTipoTran
        cadena = "select *  from v_NomenclaturaTransac order by transac"
        llenaTabla(cadena, tbTipotran)
        fM.Text = sender.text
        fMR.Inicializacion(v, tbTipotran, CrystalDecisions.Shared.PaperSize.DefaultPaperSize)
        ubica(fMR)
    End Sub

    Private Sub mnuListadoPuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListadoPuestos.Click
        Dim cadena As String
        Dim tbPuestos As New DataTable("puestos")
        Dim fMR As New FrmMuestraReporte
        Dim v As New cryListadoPuestos
        cadena = "select *  from v_ListPuestos order by puesto"
        llenaTabla(cadena, tbPuestos)
        fMR.Text = "Listado de Puestos"
        fMR.Inicializacion(v, tbPuestos, CrystalDecisions.Shared.PaperSize.DefaultPaperSize)
        ubica(fMR)
    End Sub

    
    Private Sub mnuMantEstructura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMantEstructura.Click
        fM = New frmEstructuraNomina
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub GeneraciónDePagosEnChequeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneraciónDePagosEnChequeToolStripMenuItem.Click
        fM = New frmGeneraPagoCheques
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuBonoEspecial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBonoEspecial.Click
        fM = New frmBonoEspecial
        fM.Text = sender.text
        ubica(fM)
    End Sub

   
    Private Sub MantenimientoDeTiposDePersonalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoDeTiposDePersonalToolStripMenuItem.Click
        fM = New frmTipoPersonal
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub ListadoDeTransaccionesDeNóminaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeTransaccionesDeNóminaToolStripMenuItem.Click
        Dim cadena As String
        Dim tbTipotran As New DataTable("transaccion")
        Dim fMR As New FrmMuestraReporte
        Dim v As New cryListadoTipoTran
        cadena = "select *  from v_NomenclaturaTransac where empresa=" & empresa & " order by transac"
        llenaTabla(cadena, tbTipotran)
        fMR.Text = "Listado de Transacciones de Nómina"
        fMR.Inicializacion(v, tbTipotran, CrystalDecisions.Shared.PaperSize.DefaultPaperSize)
        ubica(fMR)
    End Sub

    Private Sub mnuAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAyuda.Click
        svdAyuda.Title = "Guardar Archivo de Ayuda"
        svdAyuda.FileName = "MANUAL NOMINA"
        svdAyuda.Filter = "PDF |*.pdf"
        svdAyuda.ShowDialog()
    End Sub

    Private Sub svdAyuda_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles svdAyuda.FileOk
        Try
            Copy("\\servidor\SetupNomina\MANUAL.PDF", svdAyuda.FileName)
            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR ARCHIVO", MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub IngresoDePasivosLaboralesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDePasivosLaboralesToolStripMenuItem.Click
        fM = New FrmIngresoProvisiones
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub MantenimientoDePasivosLaboralesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoDePasivosLaboralesToolStripMenuItem.Click
        fM = New FrmMantProvisiones
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuListadoEventosxEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListadoEventosxEmpleado.Click
        fM = New frmListadoEventos
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuTipoAcciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTipoAcciones.Click
        fM = New frmTipoAccion
        fM.Text = sender.text
        ubica(fM)
    End Sub


    Private Sub mnuMotivoEventos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMotivoEventos.Click
        fM = New frmMotivoEventos
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub IngresoDeNotasBancariasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoDeNotasBancariasToolStripMenuItem.Click
        fM = New frmIngNotaNom
        fM.Text = sender.text
        ubica(fM)
    End Sub

   
   
    Private Sub MantenimientoDeNotasBancariasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoDeNotasBancariasToolStripMenuItem.Click
        fM = New frmConsultaNotas
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub MantenimientoPermisosRequisicionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMantPermisosRequisiciones.Click
        fM = New frmAutorizacion_arbol  'frmIngresoUsuarios
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuMantTipoEventos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMantTipoEventos.Click
        fM = New frmTipoEventos
        fM.Text = sender.text
        ubica(fM)

    End Sub

   
    'Private Sub mnulistadojefesysub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnulistadojefesysub.Click
    '   fM = New frmConsultaJefes
    '  fM.Text = sender.text
    ' ubica(fM)
    'End Sub

    Private Sub ListadoDeEvaluacionesPendientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeEvaluacionesPendientesToolStripMenuItem.Click
        fM = New frmConsultaJefes
        fM.Text = sender.text
        ubica(fM)

    End Sub

  

    Private Sub PermisosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PermisosToolStripMenuItem.Click
        fM = New frmAsignacionPermisos
        ubica(fM)
    End Sub

    Private Sub AsignacionJefesYSubalternos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAsignacionJefes.Click
        fM = New frmEvaluacionAsignacion
        ubica(fM)

    End Sub

    Private Sub LISTADODEJEFESYSUBALTERNOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListJefeySub.Click
        '     fM = New frmConsultaJefes_subalternos
        '     ubica(fM)
    End Sub

#Region "Listado de Evaluaciones 2012"
    Private Sub mnuResuEvaluacionDes2012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResuEvaluacionDes2012.Click
        fM = New frmResultadoEvaluaciones2
        fM.Text = "Resultado de evaluaciones 2012"
        ubica(fM)
    End Sub

    Private Sub mnuResuEvaluaJefe2012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResuEvaluaJefe2012.Click
        fM = New frmResultadoEvaluacionesxjefe2
        fM.Text = "Resultado de evaluaciones por jefe 2012"
        ubica(fM)
    End Sub

    Private Sub mnuResultadoEvaluacionesADocentesConsolidado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultadoEvaluacionesADocentesConsolidado.Click
        fM = New frmConsultaxMaestrosEvaluados
        fM.Text = "Resultado de Evaluaciones de Maestros por Grado 2012"
        ubica(fM)
    End Sub
#End Region


#Region "Listado de Evaluaciones 2011"

    Private Sub mnuResultadoEval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultadoEval.Click
        fM = New frmResultadoEvaluaciones
        fM.Text = "Resultado de evaluaciones"
        ubica(fM)
    End Sub

    Private Sub mnuResultadoEvaluacionJefe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultadoEvaluacionJefe.Click
        fM = New frmResultadoEvaluacionesxjefe
        fM.Text = "Resultado de evaluaciones por jefe 2011"
        ubica(fM)
    End Sub



    Private Sub mnuEvaluacionesDocentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEvaluacionesDocentes2011.Click
        fM = New frmListadoEvaluacionDocentes
        ubica(fM)

    End Sub


    Private Sub mnuEvaluacionMaestros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fM = New frmListadoEvaluacionAsignacion
        fM.Text = "Reporte de Maestros Evaluados"
        ubica(fM)
    End Sub
#End Region

    


    Private Sub mnuMantCursos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMantCursos.Click
        fM = New frmTipoCurso
        fM.Text = "Mantenimiento de Cursos"
        ubica(fM)
    End Sub



    Private Sub mnuTipoEvaluacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fM = New frmTipoEvaluacion
        fM.Text = "Mantenimiento de Tipo Evaluación"
        ubica(fM)
    End Sub

    Private Sub mnuReporteColaboradores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReporteColaboradores.Click
        fM = New frmListadoEvaluacionAsignacion
        fM.Text = "Reporte de Evaluaciones a Colaboradores"
        ubica(fM)
    End Sub

    Private Sub mnuEliminacionPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminacionPago.Click
        fM = New frmEliminaPago
        fM.Text = "Eliminación de Pagos"
        ubica(fM)
    End Sub

    Private Sub mnuEvaDoc2014_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEvaDoc2014.Click
        fM = New frmListadoEvaluacionDoc2014
        ubica(fM)
    End Sub

    Private Sub mnuGraEvaDoc2014_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGraEvaDoc2014.Click
        fM = New frmGraficasEvaluacionDoc2014
        ubica(fM)
    End Sub

    Private Sub mnuEvaPerso2014_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEvaPerso2014.Click
        fM = New frmListadoEvaluacion2014
        ubica(fM)
    End Sub

    Private Sub mnuAsignacionAlumnosMaestros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAsignacionAlumnosMaestros.Click
        fM = New frmAsignaProfAlumGraSecc
        ubica(fM)
    End Sub

    Private Sub mnuMantPreguntas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMantPreguntas.Click
        fM = New frmEvaluaPreguntas
        ubica(fM)
    End Sub

    Private Sub mnuMantOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMantOpciones.Click
        fM = New frmEvaluaOpciones
        ubica(fM)
    End Sub

    Private Sub mnuConsEvaluaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsEvaluaciones.Click
        fM = New frmConsulEvaluaciones
        ubica(fM)
    End Sub

    Private Sub mnuEvaluaDocentesxAlumnos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEvaluaDocentesxAlumnos.Click
        fM = New frmListadoEvaluacionDoc2015
        ubica(fM)

    End Sub

    Private Sub mnuGraficaEvaluacionDocentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGraficaEvaluacionDocentes.Click
        fM = New frmGraficasEvaluacionDoc2015
        ubica(fM)
    End Sub

    Private Sub mnuEvaluacionesDePersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEvaluacionesDePersonal.Click
        fM = frmListadoEvaluacion2015
        ubica(fM)
    End Sub


   
    Private Sub mnuGraEva2014_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGraEva2014.Click

    End Sub

    Private Sub mnuPlanillaSSExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPlanillaSSExcel.Click
        fM = New frmIGSS
        ubica(fM)
    End Sub

    
    Private Sub mnuImpContratos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImpContratos.Click
        fM = New frmImpContratos
        ubica(fM)
    End Sub

    Private Sub mnuPuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPuestos.Click

    End Sub

    Private Sub mnuCambioPuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCambioPuesto.Click
        fM = New frmCambioCodigo
        ubica(fM)
    End Sub

    Private Sub ctxAsignaJefe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAsignaJefe.Click
        fM = New frmAsignacionJefes
        ubica(fM)
    End Sub

    Private Sub mnuVigenciaEval_Click(sender As Object, e As EventArgs) Handles mnuVigenciaEval.Click
        fM = New FrmEvaluaVigencia
        ubica(fM)
    End Sub

    Private Sub mnuListadoAntiguedadEmpleados_Click(sender As Object, e As EventArgs) Handles mnuListadoAntiguedadEmpleados.Click
        fM = New frmEmpleadoAntiguedad
        ubica(fM)
    End Sub

    Private Sub mnuListadoCumpleareros_Click(sender As Object, e As EventArgs) Handles mnuListadoCumpleareros.Click
        fM = New frmListadoCumpleaños
        ubica(fM)
    End Sub

    Private Sub mnuCambioEmpresa_Click(sender As Object, e As EventArgs) Handles mnuCambioEmpresa.Click
        fM = New frmSeleccionEmpresa
        ubica(fM)
    End Sub

    Private Sub mnuModificacionNomina_Click(sender As Object, e As EventArgs) Handles mnuModificacionNomina.Click
        fM = New frmModificaNominaReg
        ubica(fM)
    End Sub

    Private Sub mnuEvaluaareas_Click(sender As Object, e As EventArgs) Handles mnuEvaluaareas.Click
        fM = New frmEvaluaAreas2
        ubica(fM)
    End Sub

    Private Sub mnuTipoEvaluacion_Click_1(sender As Object, e As EventArgs) Handles mnuTipoEvaluacion.Click
        fM = New frmTipoEvaluacion
        ubica(fM)
    End Sub
End Class