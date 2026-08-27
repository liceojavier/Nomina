Imports System.IO.File
Imports System.Globalization.CultureInfo
Imports System.Collections.Generic
Imports System.IO

Public Class MenuM
    Dim fM As Form
    Dim tbPermiso As DataTable
    Dim lpara As New Dictionary(Of String, Object)
    Dim listaForm As List(Of String)
    Dim sf As New seleccionForma()

    Public Sub ubica(ByRef f As Form)
        'Ubica la ventana dentro del formulario principal de menu.
        If Not (listaForm.Contains(f.Name)) Then
            f.TopLevel = False
            f.Visible = True
            f.FormBorderStyle = FormBorderStyle.None
            f.Dock = DockStyle.Fill

            Dim tabP As New TabPage
            TabControlP.TabPages.Add(tabP)
            tabP.Text = f.Text

            tabP.Controls.Add(f)
            TabControlP.SelectedTab = tabP


            listaForm.Add(f.Name)
        Else
            TabControlP.SelectedIndex = listaForm.IndexOf(f.Name)
        End If
    End Sub

    Public Sub ubica(ByRef f As Form, ncomple As String)
        'Ubica la ventana dentro del formulario principal de menu.
        If Not (listaForm.Contains(f.Name + ncomple)) Then
            f.TopLevel = False
            f.Visible = True
            f.FormBorderStyle = FormBorderStyle.None
            f.Dock = DockStyle.Fill

            Dim tabP As New TabPage
            TabControlP.TabPages.Add(tabP)
            tabP.Text = f.Text

            tabP.Controls.Add(f)
            TabControlP.SelectedTab = tabP


            listaForm.Add(f.Name + ncomple)
        Else
            TabControlP.SelectedIndex = listaForm.IndexOf(f.Name + ncomple)
        End If
    End Sub

    Public Property usuario As String = ""
    Public Property nombre_usuario As String = ""
    Public Property nombre_empresa As String = ""
    Public Property nombre_rol As String = ""
    Public Property Fecha_Inicio_Sesion As DateTime

    Public Property imagen As Bitmap

    Private Sub frmMenuM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CurrentCulture.Name.Trim.ToUpper <> ("ES-GT") Then
            MsgBox("DEBE CAMBIAR PRIMERO SU CONFIGURACION REGIONAL A GUATEMALA ", MsgBoxStyle.Information, "Mensaje del Sistema")
            Me.Close()
            Exit Sub
        End If
        statusStrip1.Renderer = New StatusStripRenderer()
        statusStrip1.Items.Insert(1, New ToolStripSeparator())
        statusStrip1.Items.Insert(3, New ToolStripSeparator())
        statusStrip1.Items.Insert(5, New ToolStripSeparator())
        statusStrip1.Items.Insert(7, New ToolStripSeparator())
        MenuPrincipal.Renderer = New MenuStripRendererFix()

        listaForm = New List(Of String)
        Genera_informacion_empresa(empresa)
        inicializa_informacion()
        Muestra_informacion()
    End Sub

    Private Sub inicializa_informacion()
        Me.nombre_usuario = _usuario_nombre
        Me.nombre_empresa = Definiciones._nombre_empresa
        Me.nombre_rol = _roles_auth
        Me.usuario = _usuario
    End Sub

    Public Sub Genera_informacion_empresa(id_empresa As Int32)
        Dim cadena As String = ""
        Dim tbData As New DataTable
        cadena = "select nombre,logo from empresas where empresa=@empresa"
        lpara("empresa") = empresa
        If llenaTabla(cadena, tbData, ListaParametros(lpara)) > 0 Then
            Dim fila As DataRow = tbData.Rows(0)
            If Not fila.Item("nombre") Is DBNull.Value AndAlso Not fila.Item("nombre") Is Nothing Then
                Me.nombre_empresa = fila.Item("nombre")
            Else
                Me.nombre_empresa = ""
            End If

            Dim img() As Byte
            If Not fila.Item("logo") Is DBNull.Value AndAlso Not fila.Item("logo") Is Nothing Then
                img = DirectCast(fila.Item("logo"), Byte())
                Me.imagen = New Bitmap(New MemoryStream(img))
            Else
                Me.imagen = Nothing
            End If

        Else
            MsgBox("Debe crear primero la empresa, verifique", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Public Sub Muestra_informacion()
        tsFecha.Text = "Fecha: " & DateTime.Now.ToString("dd/MM/yyyy")
        tsHora.Text = "Hora: " & DateTime.Now.ToString("HH:mm:ss")
        tsEmpresa.Text = Me.nombre_empresa
        tsEstado.Text = "Conectado"
        tsUsuario.Text = user
        pbLogo.Image = Me.imagen
    End Sub

    Public Sub InicializaPermisos()
        Dim cadena As String = ""
        cadena = "select * from permisos where id_rol=" & IdRol & " order by id_permiso"
        tbPermiso = New DataTable("permisos")
        llenaTabla(cadena, tbPermiso)

        cadena = "select nombre from permisos where id_rol=" & IdRol & " and acceso=1 order by id_permiso"
        llena_combo(cadena, cmbBuscar)

        For Each MenuItem1 As ToolStripMenuItem In MenuPrincipal.Items
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


    Private Sub mnuIngPuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fM = New frmIngPuestos
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuMantPuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMantPuestos.Click
        fM = New frmPuestos
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
        ubica(fMe, "-consu")
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
        fP.Name = "frmIngPrestamos"
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
        fM = New FormIngresoSuspension
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuConsSuspen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsSuspen.Click
        fM = New formConsSuspension
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
        fM = New frmGenePagoVacaciones
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

    Private Sub AsignacionJefesYSubalternos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignacionJefesYSubalternos.Click
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

    Public Class StatusStripRenderer
        Inherits ToolStripProfessionalRenderer

        Protected Overrides Sub OnRenderToolStripBackground(
        e As ToolStripRenderEventArgs)

            Using brush As New SolidBrush(Color.White)
                e.Graphics.FillRectangle(brush, e.AffectedBounds)
            End Using

        End Sub

    End Class


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
        'fM = New frmGraficasEvaluacionDoc2015
        fM = New frmGraficaEvaluacionesDoc2022
        ubica(fM)
    End Sub

    Private Sub mnuEvaluacionesDePersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEvaluacionesDePersonal.Click
        fM = New FrmListadoEvaluaciones2022
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
        Dim fM As New frmSeleccionEmpresa
        fM.MainMenu = Me
        ubica(fM)
    End Sub

    Private Sub mnuModificacionNomina_Click(sender As Object, e As EventArgs) Handles mnuModificacionNominaRegistro.Click
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


    Private Sub mnuModRegistroNom_Click(sender As Object, e As EventArgs) Handles mnuModificacionNomina.Click
        fM = New frmModificacionNomina
        ubica(fM)
    End Sub

    Private Sub mnuNominaRegistro_Click(sender As Object, e As EventArgs) Handles mnuNominaRegistro.Click
        fM = New frmRegistroNominas
        ubica(fM)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Muestra la hora actual en formato de 12 horas con AM/PM (ejemplo: 02:30:15 p. m.)
        tsHora.Text = "Hora: " & DateTime.Now.ToString("hh:mm:ss tt")

    End Sub


#Region "Eventos botones"
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dim indiceActual = TabControlP.SelectedIndex

        If indiceActual <= 0 Then
            Exit Sub
        End If

        Dim nuevoIndice = indiceActual - 1

        TabControlP.SuspendLayout()

        ' Seleccionamos el tab destino ANTES de quitar el actual
        TabControlP.SelectedIndex = nuevoIndice

        TabControlP.TabPages.RemoveAt(indiceActual)
        listaForm.RemoveAt(indiceActual - 1)

        TabControlP.ResumeLayout()
    End Sub

    Private Sub btnCerrarTodos_Click(sender As Object, e As EventArgs) Handles btnCerrarTodos.Click
        'TabControlP.TabPages.Clear()
        While TabControlP.TabPages.Count > 1
            TabControlP.TabPages.RemoveAt(1)
        End While
        listaForm.Clear()
        'TabControlP.SelectedIndex = 0
    End Sub

    Private Sub mnuGenNomVacaEspe_Click(sender As Object, e As EventArgs) Handles mnuGenNomVacaEspe.Click
        fM = New frmGenePagoVacacionesEsp
        ubica(fM)
    End Sub

    Private Sub mnuMovVarMultiple_Click(sender As Object, e As EventArgs) Handles mnuMovVarMultiple.Click
        fM = New frmMovimientosNominaMultiple()
        ubica(fM)
    End Sub

    Private Sub Cerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If (MsgBox("Esta seguro de desear cerrar la aplicación", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes) Then
            Me.Dispose(True)
            Me.Close()
            Me.Finalize()
            Application.Exit()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub ListadoDePréstamosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDePréstamosToolStripMenuItem.Click
        fM = New frmReportePrestamos
        ubica(fM)
    End Sub

    Private Sub mnuPermisosRequisiciones_Click(sender As Object, e As EventArgs) Handles mnuPermisosRequisiciones.Click
        fM = New frmAutorizacion_arbol
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuListadoPermisosRequi_Click(sender As Object, e As EventArgs) Handles mnuListadoPermisosRequi.Click
        fM = New frmListadoPermisos_Requi
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub cmbBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBuscar.SelectedIndexChanged
        Dim forma As String = cmbBuscar.SelectedItem
        Dim f As Form

        If (forma = "Ingreso de Empleados") Then
            Dim fMe As New frmIngEmpleados
            fMe.Consulta = False
            fMe.Text = sender.text
            ubica(fMe)
        ElseIf (forma = "Mantenimiento de Empleados") Then
            Dim fMe As New frmIngEmpleados
            fMe.Consulta = True
            fMe.Text = sender.text
            ubica(fMe, "-consu")
        Else
            f = sf.abreForma(forma)

            If IsNothing(f) <> True Then
                ubica(f)
            End If
        End If

        cmbBuscar.Text = ""
    End Sub

    Private Sub ExportaciónDeFotografíasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuExportacionFoto.Click
        fM = New frmExportacionFotografias
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuEliminaTodaNomina_Click(sender As Object, e As EventArgs) Handles mnuEliminaTodaNomina.Click
        fM = New frmEliminaTodaNomina
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuAsignacionJefesV2_Click(sender As Object, e As EventArgs) Handles mnuAsignacionJefesV2.Click
        fM = New frmAsignacionJefes
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub ListadoDeDocumentosDeEmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuListResumenDocs.Click
        fM = New frm_Emp_doctos_actualizdos
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuVisorDocs_Click(sender As Object, e As EventArgs) Handles mnuVisorDocs.Click
        fM = New frmVisorDocumentosEmpleados
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuPreguntas_Click(sender As Object, e As EventArgs) Handles mnuPreguntas.Click
        fM = New frmCulturapreguntas
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuOpciones_Click(sender As Object, e As EventArgs) Handles mnuOpciones.Click
        fM = New frmCulturaopciones
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuTipoDeEvaluacion_Click(sender As Object, e As EventArgs) Handles mnuTipoDeEvaluacion.Click
        fM = New frmCulturatipotest1
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuAlumnosConEvaluacion_Click(sender As Object, e As EventArgs) Handles mnuAlumnosConEvaluacion.Click
        fM = New frmOrientatest1
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub mnuLiquidaciones_Click(sender As Object, e As EventArgs) Handles mnuLiquidaciones.Click
        fM = New frmIndemnizacion
        fM.Text = sender.text
        ubica(fM)
    End Sub

    Private Sub MenuPrincipal_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuPrincipal.ItemClicked

    End Sub


#End Region
End Class