Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCONSCONTRATOS.VB MIEMBRO DE NOMINA.SLN                                   **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmConsContratos
    Inherits Form



#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer
    Friend WithEvents TextTipoBase As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbAnticipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ctxPrincipal As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxBaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSig As System.Windows.Forms.Button
    Friend WithEvents btnAtr As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextEstado As System.Windows.Forms.TextBox
    Friend WithEvents TextModPago As System.Windows.Forms.TextBox
    Friend WithEvents TextPuesto As System.Windows.Forms.TextBox
    Friend WithEvents TextTipoPer As System.Windows.Forms.TextBox
    Friend WithEvents TextTipoSeguro As System.Windows.Forms.TextBox
    Friend WithEvents TextFormaPago As System.Windows.Forms.TextBox
    Friend WithEvents TextAnticipo As System.Windows.Forms.TextBox
    Friend WithEvents gpChofer As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textConxEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextHora2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextHora1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gpCentro As System.Windows.Forms.GroupBox
    Friend WithEvents btnOrigen As System.Windows.Forms.Button
    Friend WithEvents TextNombOrigen As System.Windows.Forms.TextBox
    Friend WithEvents TextOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextPorce As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextTotal As System.Windows.Forms.TextBox
    Friend WithEvents TextConlObserva As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents textConlcuentaban As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents cmbPuesto As System.Windows.Forms.ComboBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cmbJornada As System.Windows.Forms.ComboBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents cmbModPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents dgDatos As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents MaskedTextBox2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
    Friend WithEvents gpContrato As System.Windows.Forms.GroupBox
    Friend WithEvents TextConxContrato As System.Windows.Forms.TextBox
    Friend WithEvents tbSueldo As System.Windows.Forms.TabPage
    Friend WithEvents TextTotalSueldo As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dgSueldos As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelSueldo As System.Windows.Forms.Button
    Friend WithEvents btnIngSueldo As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextValor As System.Windows.Forms.TextBox
    Friend WithEvents cmbAfecta As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents gpTransaccion As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscaCodigo As System.Windows.Forms.Button
    Friend WithEvents textNombCodigo As System.Windows.Forms.TextBox
    Friend WithEvents textCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ctxMenuSueldos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModiSueldo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxEliSueldo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabPages As System.Windows.Forms.TabControl
    Friend WithEvents TbGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tbOrigenes As System.Windows.Forms.TabPage
    Friend WithEvents cmbTipoPer As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoSeguro As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnSueldos As System.Windows.Forms.Panel
    Friend WithEvents TextConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ctxReactivarContrato As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents tabEventos As System.Windows.Forms.TabPage
    Friend WithEvents dgEventos As System.Windows.Forms.DataGridView
    Friend WithEvents pnEventos As System.Windows.Forms.Panel
    Friend WithEvents textObservaEvento As System.Windows.Forms.TextBox
    Friend WithEvents lblObserva As System.Windows.Forms.Label
    Friend WithEvents lblTipoEvento As System.Windows.Forms.Label
    Friend WithEvents cmbTipoEvento As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancelEvento As System.Windows.Forms.Button
    Friend WithEvents btnIngEvento As System.Windows.Forms.Button
    Friend WithEvents cmbMotivoEvento As System.Windows.Forms.ComboBox
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents cmbTipoAccion As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccionEvento As System.Windows.Forms.Label
    Friend WithEvents gpEvento As System.Windows.Forms.GroupBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents ctxMenuEvento As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModiEvento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxEliEvento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMenuOrigen As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxEliminaCentro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Textsemanales As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextHorasTotal As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoEmpleado As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TabJefes As System.Windows.Forms.TabPage
    Friend WithEvents scJefe As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvJefe As System.Windows.Forms.DataGridView
    Friend WithEvents gpEmpleado As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscaJefe As System.Windows.Forms.Button
    Friend WithEvents TextNombreJefe As System.Windows.Forms.TextBox
    Friend WithEvents TextJefe As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnContrato As System.Windows.Forms.Button
    Friend WithEvents TextContratoJefe As System.Windows.Forms.TextBox
    Friend WithEvents btnAsignaJefe As System.Windows.Forms.Button
    Friend WithEvents ctxMenuJefe As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxEliminarJefe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnHead As Panel
    Friend WithEvents cmbTemporalidad As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbTipoContrato As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents gpFechaI As GroupBox
    Friend WithEvents TextAvisoFechaI As TextBox
    Friend WithEvents btnFechaI As Button
    Friend WithEvents TextFechaInicio As MaskedTextBox
    Friend WithEvents gpFechaFinal As GroupBox
    Friend WithEvents TextAvisoFechaF As TextBox
    Friend WithEvents btnFechaF As Button
    Friend WithEvents textFechaF As MaskedTextBox
    Friend WithEvents gpFecha As GroupBox
    Friend WithEvents TextAvisoFecha As TextBox
    Friend WithEvents btnFecha As Button
    Friend WithEvents textFecha As MaskedTextBox
    Friend WithEvents gpFechaE As GroupBox
    Friend WithEvents TextAvisoFecha2 As TextBox
    Friend WithEvents btnFecha2 As Button
    Friend WithEvents textFechae As MaskedTextBox
    Friend WithEvents textFechaEvento As System.Windows.Forms.MaskedTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsContratos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabPages = New System.Windows.Forms.TabControl()
        Me.ctxPrincipal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxBaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxReactivarContrato = New System.Windows.Forms.ToolStripMenuItem()
        Me.TbGeneral = New System.Windows.Forms.TabPage()
        Me.gpFechaE = New System.Windows.Forms.GroupBox()
        Me.TextAvisoFecha2 = New System.Windows.Forms.TextBox()
        Me.btnFecha2 = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.textFechae = New System.Windows.Forms.MaskedTextBox()
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.TextAvisoFecha = New System.Windows.Forms.TextBox()
        Me.btnFecha = New System.Windows.Forms.Button()
        Me.textFecha = New System.Windows.Forms.MaskedTextBox()
        Me.gpFechaFinal = New System.Windows.Forms.GroupBox()
        Me.TextAvisoFechaF = New System.Windows.Forms.TextBox()
        Me.btnFechaF = New System.Windows.Forms.Button()
        Me.textFechaF = New System.Windows.Forms.MaskedTextBox()
        Me.gpFechaI = New System.Windows.Forms.GroupBox()
        Me.TextAvisoFechaI = New System.Windows.Forms.TextBox()
        Me.btnFechaI = New System.Windows.Forms.Button()
        Me.TextFechaInicio = New System.Windows.Forms.MaskedTextBox()
        Me.cmbTemporalidad = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoContrato = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbTipoEmpleado = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextHorasTotal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Textsemanales = New System.Windows.Forms.TextBox()
        Me.TextFormaPago = New System.Windows.Forms.TextBox()
        Me.TextAnticipo = New System.Windows.Forms.TextBox()
        Me.TextModPago = New System.Windows.Forms.TextBox()
        Me.TextPuesto = New System.Windows.Forms.TextBox()
        Me.TextTipoPer = New System.Windows.Forms.TextBox()
        Me.TextTipoSeguro = New System.Windows.Forms.TextBox()
        Me.TextEstado = New System.Windows.Forms.TextBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbAnticipo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextTipoBase = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextHora2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextHora1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextConlObserva = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.cmbModPago = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cmbJornada = New System.Windows.Forms.ComboBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.cmbPuesto = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.textConlcuentaban = New System.Windows.Forms.TextBox()
        Me.cmbTipoSeguro = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbTipoPer = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tbOrigenes = New System.Windows.Forms.TabPage()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.TextTotal = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextPorce = New System.Windows.Forms.TextBox()
        Me.gpCentro = New System.Windows.Forms.GroupBox()
        Me.btnOrigen = New System.Windows.Forms.Button()
        Me.TextNombOrigen = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextOrigen = New System.Windows.Forms.TextBox()
        Me.dgDatos = New System.Windows.Forms.DataGridView()
        Me.ctxMenuOrigen = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEliminaCentro = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.tbSueldo = New System.Windows.Forms.TabPage()
        Me.pnSueldos = New System.Windows.Forms.Panel()
        Me.TextConcepto = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.gpTransaccion = New System.Windows.Forms.GroupBox()
        Me.btnBuscaCodigo = New System.Windows.Forms.Button()
        Me.textNombCodigo = New System.Windows.Forms.TextBox()
        Me.textCodigo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbAfecta = New System.Windows.Forms.ComboBox()
        Me.TextValor = New System.Windows.Forms.TextBox()
        Me.btnCancelSueldo = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnIngSueldo = New System.Windows.Forms.Button()
        Me.TextTotalSueldo = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dgSueldos = New System.Windows.Forms.DataGridView()
        Me.ctxMenuSueldos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModiSueldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliSueldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabEventos = New System.Windows.Forms.TabPage()
        Me.dgEventos = New System.Windows.Forms.DataGridView()
        Me.ctxMenuEvento = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModiEvento = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliEvento = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnEventos = New System.Windows.Forms.Panel()
        Me.gpEvento = New System.Windows.Forms.GroupBox()
        Me.textFechaEvento = New System.Windows.Forms.MaskedTextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.cmbTipoAccion = New System.Windows.Forms.ComboBox()
        Me.textObservaEvento = New System.Windows.Forms.TextBox()
        Me.lblTipoEvento = New System.Windows.Forms.Label()
        Me.lblObserva = New System.Windows.Forms.Label()
        Me.lblAccionEvento = New System.Windows.Forms.Label()
        Me.cmbTipoEvento = New System.Windows.Forms.ComboBox()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.cmbMotivoEvento = New System.Windows.Forms.ComboBox()
        Me.btnCancelEvento = New System.Windows.Forms.Button()
        Me.btnIngEvento = New System.Windows.Forms.Button()
        Me.TabJefes = New System.Windows.Forms.TabPage()
        Me.scJefe = New System.Windows.Forms.SplitContainer()
        Me.btnAsignaJefe = New System.Windows.Forms.Button()
        Me.gpEmpleado = New System.Windows.Forms.GroupBox()
        Me.btnBuscaJefe = New System.Windows.Forms.Button()
        Me.TextNombreJefe = New System.Windows.Forms.TextBox()
        Me.TextJefe = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.TextContratoJefe = New System.Windows.Forms.TextBox()
        Me.dgvJefe = New System.Windows.Forms.DataGridView()
        Me.ctxMenuJefe = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEliminarJefe = New System.Windows.Forms.ToolStripMenuItem()
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.TextConxContrato = New System.Windows.Forms.TextBox()
        Me.gpChofer = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textConxEmpleado = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnSig = New System.Windows.Forms.Button()
        Me.btnAtr = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MaskedTextBox2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnHead = New System.Windows.Forms.Panel()
        Me.tabPages.SuspendLayout()
        Me.ctxPrincipal.SuspendLayout()
        Me.TbGeneral.SuspendLayout()
        Me.gpFechaE.SuspendLayout()
        Me.gpFecha.SuspendLayout()
        Me.gpFechaFinal.SuspendLayout()
        Me.gpFechaI.SuspendLayout()
        Me.tbOrigenes.SuspendLayout()
        Me.gpCentro.SuspendLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenuOrigen.SuspendLayout()
        Me.tbSueldo.SuspendLayout()
        Me.pnSueldos.SuspendLayout()
        Me.gpTransaccion.SuspendLayout()
        CType(Me.dgSueldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenuSueldos.SuspendLayout()
        Me.tabEventos.SuspendLayout()
        CType(Me.dgEventos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenuEvento.SuspendLayout()
        Me.pnEventos.SuspendLayout()
        Me.gpEvento.SuspendLayout()
        Me.TabJefes.SuspendLayout()
        CType(Me.scJefe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scJefe.Panel1.SuspendLayout()
        Me.scJefe.Panel2.SuspendLayout()
        Me.scJefe.SuspendLayout()
        Me.gpEmpleado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvJefe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenuJefe.SuspendLayout()
        Me.gpContrato.SuspendLayout()
        Me.gpChofer.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpEmpresa.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnHead.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabPages
        '
        Me.tabPages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabPages.ContextMenuStrip = Me.ctxPrincipal
        Me.tabPages.Controls.Add(Me.TbGeneral)
        Me.tabPages.Controls.Add(Me.tbOrigenes)
        Me.tabPages.Controls.Add(Me.tbSueldo)
        Me.tabPages.Controls.Add(Me.tabEventos)
        Me.tabPages.Controls.Add(Me.TabJefes)
        Me.tabPages.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPages.Location = New System.Drawing.Point(6, 131)
        Me.tabPages.Name = "tabPages"
        Me.tabPages.SelectedIndex = 0
        Me.tabPages.Size = New System.Drawing.Size(1122, 417)
        Me.tabPages.TabIndex = 3
        '
        'ctxPrincipal
        '
        Me.ctxPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModificar, Me.ctxBaja, Me.ctxReactivarContrato})
        Me.ctxPrincipal.Name = "ctxMenu"
        Me.ctxPrincipal.Size = New System.Drawing.Size(134, 70)
        '
        'ctxModificar
        '
        Me.ctxModificar.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.ctxModificar.Name = "ctxModificar"
        Me.ctxModificar.Size = New System.Drawing.Size(133, 22)
        Me.ctxModificar.Text = "Modificar"
        '
        'ctxBaja
        '
        Me.ctxBaja.Image = Global.NOMINA.My.Resources.Resources.cancelar
        Me.ctxBaja.Name = "ctxBaja"
        Me.ctxBaja.Size = New System.Drawing.Size(133, 22)
        Me.ctxBaja.Text = "Dar de Baja"
        '
        'ctxReactivarContrato
        '
        Me.ctxReactivarContrato.Image = Global.NOMINA.My.Resources.Resources.reactivate
        Me.ctxReactivarContrato.Name = "ctxReactivarContrato"
        Me.ctxReactivarContrato.Size = New System.Drawing.Size(133, 22)
        Me.ctxReactivarContrato.Text = "Reactivar"
        '
        'TbGeneral
        '
        Me.TbGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TbGeneral.Controls.Add(Me.gpFechaE)
        Me.TbGeneral.Controls.Add(Me.gpFecha)
        Me.TbGeneral.Controls.Add(Me.gpFechaFinal)
        Me.TbGeneral.Controls.Add(Me.gpFechaI)
        Me.TbGeneral.Controls.Add(Me.cmbTemporalidad)
        Me.TbGeneral.Controls.Add(Me.Label1)
        Me.TbGeneral.Controls.Add(Me.cmbTipoContrato)
        Me.TbGeneral.Controls.Add(Me.Label22)
        Me.TbGeneral.Controls.Add(Me.cmbTipoEmpleado)
        Me.TbGeneral.Controls.Add(Me.Label21)
        Me.TbGeneral.Controls.Add(Me.TextHorasTotal)
        Me.TbGeneral.Controls.Add(Me.Label11)
        Me.TbGeneral.Controls.Add(Me.Textsemanales)
        Me.TbGeneral.Controls.Add(Me.TextFormaPago)
        Me.TbGeneral.Controls.Add(Me.TextAnticipo)
        Me.TbGeneral.Controls.Add(Me.TextModPago)
        Me.TbGeneral.Controls.Add(Me.TextPuesto)
        Me.TbGeneral.Controls.Add(Me.TextTipoPer)
        Me.TbGeneral.Controls.Add(Me.TextTipoSeguro)
        Me.TbGeneral.Controls.Add(Me.TextEstado)
        Me.TbGeneral.Controls.Add(Me.cmbEstado)
        Me.TbGeneral.Controls.Add(Me.Label13)
        Me.TbGeneral.Controls.Add(Me.cmbAnticipo)
        Me.TbGeneral.Controls.Add(Me.Label14)
        Me.TbGeneral.Controls.Add(Me.TextTipoBase)
        Me.TbGeneral.Controls.Add(Me.Label8)
        Me.TbGeneral.Controls.Add(Me.TextHora2)
        Me.TbGeneral.Controls.Add(Me.Label7)
        Me.TbGeneral.Controls.Add(Me.TextHora1)
        Me.TbGeneral.Controls.Add(Me.Label6)
        Me.TbGeneral.Controls.Add(Me.TextConlObserva)
        Me.TbGeneral.Controls.Add(Me.Label9)
        Me.TbGeneral.Controls.Add(Me.cmbFormaPago)
        Me.TbGeneral.Controls.Add(Me.Label50)
        Me.TbGeneral.Controls.Add(Me.cmbModPago)
        Me.TbGeneral.Controls.Add(Me.Label36)
        Me.TbGeneral.Controls.Add(Me.cmbJornada)
        Me.TbGeneral.Controls.Add(Me.Label45)
        Me.TbGeneral.Controls.Add(Me.Label44)
        Me.TbGeneral.Controls.Add(Me.cmbPuesto)
        Me.TbGeneral.Controls.Add(Me.Label42)
        Me.TbGeneral.Controls.Add(Me.Label18)
        Me.TbGeneral.Controls.Add(Me.textConlcuentaban)
        Me.TbGeneral.Controls.Add(Me.cmbTipoSeguro)
        Me.TbGeneral.Controls.Add(Me.Label31)
        Me.TbGeneral.Controls.Add(Me.cmbTipoPer)
        Me.TbGeneral.Controls.Add(Me.Label30)
        Me.TbGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TbGeneral.Name = "TbGeneral"
        Me.TbGeneral.Size = New System.Drawing.Size(1114, 391)
        Me.TbGeneral.TabIndex = 3
        Me.TbGeneral.Text = "Datos generales"
        Me.TbGeneral.Visible = False
        '
        'gpFechaE
        '
        Me.gpFechaE.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpFechaE.Controls.Add(Me.TextAvisoFecha2)
        Me.gpFechaE.Controls.Add(Me.btnFecha2)
        Me.gpFechaE.Controls.Add(Me.textFechae)
        Me.gpFechaE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFechaE.Location = New System.Drawing.Point(614, 127)
        Me.gpFechaE.Name = "gpFechaE"
        Me.gpFechaE.Size = New System.Drawing.Size(162, 45)
        Me.gpFechaE.TabIndex = 141
        Me.gpFechaE.TabStop = False
        Me.gpFechaE.Text = "Fecha de estado"
        '
        'TextAvisoFecha2
        '
        Me.TextAvisoFecha2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextAvisoFecha2.BackColor = System.Drawing.Color.White
        Me.TextAvisoFecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAvisoFecha2.Location = New System.Drawing.Point(6, 20)
        Me.TextAvisoFecha2.MaxLength = 15
        Me.TextAvisoFecha2.Name = "TextAvisoFecha2"
        Me.TextAvisoFecha2.ReadOnly = True
        Me.TextAvisoFecha2.Size = New System.Drawing.Size(89, 20)
        Me.TextAvisoFecha2.TabIndex = 118
        Me.TextAvisoFecha2.TabStop = False
        '
        'btnFecha2
        '
        Me.btnFecha2.BackColor = System.Drawing.SystemColors.Control
        Me.btnFecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFecha2.ImageKey = "fecha.png"
        Me.btnFecha2.ImageList = Me.ImageNuevos
        Me.btnFecha2.Location = New System.Drawing.Point(105, 10)
        Me.btnFecha2.Name = "btnFecha2"
        Me.btnFecha2.Size = New System.Drawing.Size(40, 32)
        Me.btnFecha2.TabIndex = 118
        Me.btnFecha2.UseVisualStyleBackColor = False
        '
        'ImageNuevos
        '
        Me.ImageNuevos.ImageStream = CType(resources.GetObject("ImageNuevos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageNuevos.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageNuevos.Images.SetKeyName(0, "buscar2.png")
        Me.ImageNuevos.Images.SetKeyName(1, "limpiar.png")
        Me.ImageNuevos.Images.SetKeyName(2, "guardar.png")
        Me.ImageNuevos.Images.SetKeyName(3, "cancelar.png")
        Me.ImageNuevos.Images.SetKeyName(4, "familia.png")
        Me.ImageNuevos.Images.SetKeyName(5, "usuario.png")
        Me.ImageNuevos.Images.SetKeyName(6, "actualizar.png")
        Me.ImageNuevos.Images.SetKeyName(7, "anterior.png")
        Me.ImageNuevos.Images.SetKeyName(8, "siguiente.png")
        Me.ImageNuevos.Images.SetKeyName(9, "mas.png")
        Me.ImageNuevos.Images.SetKeyName(10, "edit1.png")
        Me.ImageNuevos.Images.SetKeyName(11, "reportegenerar.png")
        Me.ImageNuevos.Images.SetKeyName(12, "impresora2.png")
        Me.ImageNuevos.Images.SetKeyName(13, "checkok.png")
        Me.ImageNuevos.Images.SetKeyName(14, "buscar1.png")
        Me.ImageNuevos.Images.SetKeyName(15, "reportever.png")
        Me.ImageNuevos.Images.SetKeyName(16, "mostrar.png")
        Me.ImageNuevos.Images.SetKeyName(17, "detalle.png")
        Me.ImageNuevos.Images.SetKeyName(18, "fecha.png")
        Me.ImageNuevos.Images.SetKeyName(19, "open.png")
        Me.ImageNuevos.Images.SetKeyName(20, "menos.png")
        '
        'textFechae
        '
        Me.textFechae.BackColor = System.Drawing.Color.White
        Me.textFechae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFechae.Location = New System.Drawing.Point(6, 20)
        Me.textFechae.Mask = "##/##/####"
        Me.textFechae.Name = "textFechae"
        Me.textFechae.Size = New System.Drawing.Size(84, 20)
        Me.textFechae.TabIndex = 19
        '
        'gpFecha
        '
        Me.gpFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpFecha.Controls.Add(Me.TextAvisoFecha)
        Me.gpFecha.Controls.Add(Me.btnFecha)
        Me.gpFecha.Controls.Add(Me.textFecha)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.Location = New System.Drawing.Point(415, 127)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(158, 45)
        Me.gpFecha.TabIndex = 140
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Fecha"
        '
        'TextAvisoFecha
        '
        Me.TextAvisoFecha.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextAvisoFecha.BackColor = System.Drawing.Color.White
        Me.TextAvisoFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAvisoFecha.Location = New System.Drawing.Point(6, 20)
        Me.TextAvisoFecha.MaxLength = 15
        Me.TextAvisoFecha.Name = "TextAvisoFecha"
        Me.TextAvisoFecha.ReadOnly = True
        Me.TextAvisoFecha.Size = New System.Drawing.Size(89, 20)
        Me.TextAvisoFecha.TabIndex = 118
        Me.TextAvisoFecha.TabStop = False
        '
        'btnFecha
        '
        Me.btnFecha.BackColor = System.Drawing.SystemColors.Control
        Me.btnFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFecha.ImageKey = "fecha.png"
        Me.btnFecha.ImageList = Me.ImageNuevos
        Me.btnFecha.Location = New System.Drawing.Point(105, 11)
        Me.btnFecha.Name = "btnFecha"
        Me.btnFecha.Size = New System.Drawing.Size(40, 32)
        Me.btnFecha.TabIndex = 118
        Me.btnFecha.UseVisualStyleBackColor = False
        '
        'textFecha
        '
        Me.textFecha.BackColor = System.Drawing.Color.White
        Me.textFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFecha.Location = New System.Drawing.Point(6, 20)
        Me.textFecha.Mask = "##/##/####"
        Me.textFecha.Name = "textFecha"
        Me.textFecha.Size = New System.Drawing.Size(84, 20)
        Me.textFecha.TabIndex = 19
        '
        'gpFechaFinal
        '
        Me.gpFechaFinal.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpFechaFinal.Controls.Add(Me.TextAvisoFechaF)
        Me.gpFechaFinal.Controls.Add(Me.btnFechaF)
        Me.gpFechaFinal.Controls.Add(Me.textFechaF)
        Me.gpFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFechaFinal.Location = New System.Drawing.Point(208, 127)
        Me.gpFechaFinal.Name = "gpFechaFinal"
        Me.gpFechaFinal.Size = New System.Drawing.Size(172, 45)
        Me.gpFechaFinal.TabIndex = 139
        Me.gpFechaFinal.TabStop = False
        Me.gpFechaFinal.Text = "Fecha final"
        '
        'TextAvisoFechaF
        '
        Me.TextAvisoFechaF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextAvisoFechaF.BackColor = System.Drawing.Color.White
        Me.TextAvisoFechaF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAvisoFechaF.Location = New System.Drawing.Point(10, 18)
        Me.TextAvisoFechaF.MaxLength = 15
        Me.TextAvisoFechaF.Name = "TextAvisoFechaF"
        Me.TextAvisoFechaF.ReadOnly = True
        Me.TextAvisoFechaF.Size = New System.Drawing.Size(84, 20)
        Me.TextAvisoFechaF.TabIndex = 118
        Me.TextAvisoFechaF.TabStop = False
        '
        'btnFechaF
        '
        Me.btnFechaF.BackColor = System.Drawing.SystemColors.Control
        Me.btnFechaF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFechaF.ImageKey = "fecha.png"
        Me.btnFechaF.ImageList = Me.ImageNuevos
        Me.btnFechaF.Location = New System.Drawing.Point(105, 10)
        Me.btnFechaF.Name = "btnFechaF"
        Me.btnFechaF.Size = New System.Drawing.Size(40, 32)
        Me.btnFechaF.TabIndex = 118
        Me.btnFechaF.UseVisualStyleBackColor = False
        '
        'textFechaF
        '
        Me.textFechaF.BackColor = System.Drawing.Color.White
        Me.textFechaF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFechaF.Location = New System.Drawing.Point(10, 18)
        Me.textFechaF.Mask = "##/##/####"
        Me.textFechaF.Name = "textFechaF"
        Me.textFechaF.Size = New System.Drawing.Size(84, 20)
        Me.textFechaF.TabIndex = 10
        '
        'gpFechaI
        '
        Me.gpFechaI.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpFechaI.Controls.Add(Me.TextAvisoFechaI)
        Me.gpFechaI.Controls.Add(Me.btnFechaI)
        Me.gpFechaI.Controls.Add(Me.TextFechaInicio)
        Me.gpFechaI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFechaI.Location = New System.Drawing.Point(16, 127)
        Me.gpFechaI.Name = "gpFechaI"
        Me.gpFechaI.Size = New System.Drawing.Size(172, 46)
        Me.gpFechaI.TabIndex = 138
        Me.gpFechaI.TabStop = False
        Me.gpFechaI.Text = "Fecha de inicio"
        '
        'TextAvisoFechaI
        '
        Me.TextAvisoFechaI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextAvisoFechaI.BackColor = System.Drawing.Color.White
        Me.TextAvisoFechaI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAvisoFechaI.Location = New System.Drawing.Point(10, 20)
        Me.TextAvisoFechaI.MaxLength = 15
        Me.TextAvisoFechaI.Name = "TextAvisoFechaI"
        Me.TextAvisoFechaI.ReadOnly = True
        Me.TextAvisoFechaI.Size = New System.Drawing.Size(84, 20)
        Me.TextAvisoFechaI.TabIndex = 118
        Me.TextAvisoFechaI.TabStop = False
        '
        'btnFechaI
        '
        Me.btnFechaI.BackColor = System.Drawing.SystemColors.Control
        Me.btnFechaI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFechaI.ImageKey = "fecha.png"
        Me.btnFechaI.ImageList = Me.ImageNuevos
        Me.btnFechaI.Location = New System.Drawing.Point(105, 10)
        Me.btnFechaI.Name = "btnFechaI"
        Me.btnFechaI.Size = New System.Drawing.Size(40, 32)
        Me.btnFechaI.TabIndex = 118
        Me.btnFechaI.UseVisualStyleBackColor = False
        '
        'TextFechaInicio
        '
        Me.TextFechaInicio.BackColor = System.Drawing.Color.White
        Me.TextFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaInicio.Location = New System.Drawing.Point(10, 20)
        Me.TextFechaInicio.Mask = "##/##/####"
        Me.TextFechaInicio.Name = "TextFechaInicio"
        Me.TextFechaInicio.Size = New System.Drawing.Size(84, 20)
        Me.TextFechaInicio.TabIndex = 10
        '
        'cmbTemporalidad
        '
        Me.cmbTemporalidad.BackColor = System.Drawing.Color.White
        Me.cmbTemporalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTemporalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTemporalidad.Items.AddRange(New Object() {"DIURNA", "NOCTURNA", "MIXTA", ""})
        Me.cmbTemporalidad.Location = New System.Drawing.Point(493, 242)
        Me.cmbTemporalidad.Name = "cmbTemporalidad"
        Me.cmbTemporalidad.Size = New System.Drawing.Size(238, 21)
        Me.cmbTemporalidad.TabIndex = 128
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(409, 242)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "Temporalidad:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoContrato
        '
        Me.cmbTipoContrato.BackColor = System.Drawing.Color.White
        Me.cmbTipoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoContrato.Items.AddRange(New Object() {"DIURNA", "NOCTURNA", "MIXTA", ""})
        Me.cmbTipoContrato.Location = New System.Drawing.Point(102, 242)
        Me.cmbTipoContrato.Name = "cmbTipoContrato"
        Me.cmbTipoContrato.Size = New System.Drawing.Size(259, 21)
        Me.cmbTipoContrato.TabIndex = 126
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(7, 242)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(89, 13)
        Me.Label22.TabIndex = 127
        Me.Label22.Text = "Tipo de Contrato:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoEmpleado
        '
        Me.cmbTipoEmpleado.BackColor = System.Drawing.Color.White
        Me.cmbTipoEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoEmpleado.Location = New System.Drawing.Point(493, 215)
        Me.cmbTipoEmpleado.Name = "cmbTipoEmpleado"
        Me.cmbTipoEmpleado.Size = New System.Drawing.Size(238, 21)
        Me.cmbTipoEmpleado.TabIndex = 124
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(357, 215)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(130, 13)
        Me.Label21.TabIndex = 125
        Me.Label21.Text = "Tipo de emp.  evaluación:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextHorasTotal
        '
        Me.TextHorasTotal.BackColor = System.Drawing.Color.White
        Me.TextHorasTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextHorasTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextHorasTotal.Location = New System.Drawing.Point(939, 96)
        Me.TextHorasTotal.MaxLength = 5
        Me.TextHorasTotal.Name = "TextHorasTotal"
        Me.TextHorasTotal.ReadOnly = True
        Me.TextHorasTotal.Size = New System.Drawing.Size(44, 20)
        Me.TextHorasTotal.TabIndex = 123
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(989, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 122
        Me.Label11.Text = "Horas sem.:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Textsemanales
        '
        Me.Textsemanales.BackColor = System.Drawing.Color.White
        Me.Textsemanales.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Textsemanales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textsemanales.Location = New System.Drawing.Point(1055, 96)
        Me.Textsemanales.MaxLength = 6
        Me.Textsemanales.Name = "Textsemanales"
        Me.Textsemanales.Size = New System.Drawing.Size(51, 20)
        Me.Textsemanales.TabIndex = 121
        '
        'TextFormaPago
        '
        Me.TextFormaPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextFormaPago.BackColor = System.Drawing.Color.White
        Me.TextFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFormaPago.Location = New System.Drawing.Point(816, 61)
        Me.TextFormaPago.MaxLength = 15
        Me.TextFormaPago.Name = "TextFormaPago"
        Me.TextFormaPago.ReadOnly = True
        Me.TextFormaPago.Size = New System.Drawing.Size(133, 20)
        Me.TextFormaPago.TabIndex = 116
        Me.TextFormaPago.TabStop = False
        '
        'TextAnticipo
        '
        Me.TextAnticipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextAnticipo.BackColor = System.Drawing.Color.White
        Me.TextAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAnticipo.Location = New System.Drawing.Point(669, 61)
        Me.TextAnticipo.MaxLength = 15
        Me.TextAnticipo.Name = "TextAnticipo"
        Me.TextAnticipo.ReadOnly = True
        Me.TextAnticipo.Size = New System.Drawing.Size(50, 20)
        Me.TextAnticipo.TabIndex = 115
        Me.TextAnticipo.TabStop = False
        '
        'TextModPago
        '
        Me.TextModPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextModPago.BackColor = System.Drawing.Color.White
        Me.TextModPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextModPago.Location = New System.Drawing.Point(464, 61)
        Me.TextModPago.MaxLength = 15
        Me.TextModPago.Name = "TextModPago"
        Me.TextModPago.ReadOnly = True
        Me.TextModPago.Size = New System.Drawing.Size(137, 20)
        Me.TextModPago.TabIndex = 114
        Me.TextModPago.TabStop = False
        '
        'TextPuesto
        '
        Me.TextPuesto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextPuesto.BackColor = System.Drawing.Color.White
        Me.TextPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPuesto.Location = New System.Drawing.Point(97, 61)
        Me.TextPuesto.MaxLength = 15
        Me.TextPuesto.Name = "TextPuesto"
        Me.TextPuesto.ReadOnly = True
        Me.TextPuesto.Size = New System.Drawing.Size(260, 20)
        Me.TextPuesto.TabIndex = 113
        Me.TextPuesto.TabStop = False
        '
        'TextTipoPer
        '
        Me.TextTipoPer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextTipoPer.BackColor = System.Drawing.Color.White
        Me.TextTipoPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoPer.Location = New System.Drawing.Point(464, 28)
        Me.TextTipoPer.MaxLength = 15
        Me.TextTipoPer.Name = "TextTipoPer"
        Me.TextTipoPer.ReadOnly = True
        Me.TextTipoPer.Size = New System.Drawing.Size(255, 20)
        Me.TextTipoPer.TabIndex = 112
        Me.TextTipoPer.TabStop = False
        '
        'TextTipoSeguro
        '
        Me.TextTipoSeguro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextTipoSeguro.BackColor = System.Drawing.Color.White
        Me.TextTipoSeguro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoSeguro.Location = New System.Drawing.Point(97, 28)
        Me.TextTipoSeguro.MaxLength = 15
        Me.TextTipoSeguro.Name = "TextTipoSeguro"
        Me.TextTipoSeguro.ReadOnly = True
        Me.TextTipoSeguro.Size = New System.Drawing.Size(260, 20)
        Me.TextTipoSeguro.TabIndex = 111
        Me.TextTipoSeguro.TabStop = False
        '
        'TextEstado
        '
        Me.TextEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextEstado.BackColor = System.Drawing.Color.White
        Me.TextEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEstado.Location = New System.Drawing.Point(102, 215)
        Me.TextEstado.MaxLength = 15
        Me.TextEstado.Name = "TextEstado"
        Me.TextEstado.ReadOnly = True
        Me.TextEstado.Size = New System.Drawing.Size(204, 20)
        Me.TextEstado.TabIndex = 107
        Me.TextEstado.TabStop = False
        '
        'cmbEstado
        '
        Me.cmbEstado.BackColor = System.Drawing.Color.White
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Items.AddRange(New Object() {"ACTIVO", "ANULADO", ""})
        Me.cmbEstado.Location = New System.Drawing.Point(102, 215)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(204, 21)
        Me.cmbEstado.TabIndex = 105
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 215)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 106
        Me.Label13.Text = "Estado:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAnticipo
        '
        Me.cmbAnticipo.BackColor = System.Drawing.Color.White
        Me.cmbAnticipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAnticipo.Items.AddRange(New Object() {"S", "N", ""})
        Me.cmbAnticipo.Location = New System.Drawing.Point(669, 61)
        Me.cmbAnticipo.Name = "cmbAnticipo"
        Me.cmbAnticipo.Size = New System.Drawing.Size(50, 21)
        Me.cmbAnticipo.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(618, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 104
        Me.Label14.Text = "Anticipo"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextTipoBase
        '
        Me.TextTipoBase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextTipoBase.BackColor = System.Drawing.Color.White
        Me.TextTipoBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoBase.Location = New System.Drawing.Point(816, 28)
        Me.TextTipoBase.MaxLength = 15
        Me.TextTipoBase.Name = "TextTipoBase"
        Me.TextTipoBase.ReadOnly = True
        Me.TextTipoBase.Size = New System.Drawing.Size(133, 20)
        Me.TextTipoBase.TabIndex = 4
        Me.TextTipoBase.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(862, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 99
        Me.Label8.Text = "Horas diarias:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextHora2
        '
        Me.TextHora2.BackColor = System.Drawing.Color.White
        Me.TextHora2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextHora2.Location = New System.Drawing.Point(816, 96)
        Me.TextHora2.Mask = "##:##"
        Me.TextHora2.Name = "TextHora2"
        Me.TextHora2.Size = New System.Drawing.Size(40, 20)
        Me.TextHora2.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(748, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "Hora salida:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextHora1
        '
        Me.TextHora1.BackColor = System.Drawing.Color.White
        Me.TextHora1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextHora1.Location = New System.Drawing.Point(702, 96)
        Me.TextHora1.Mask = "##:##"
        Me.TextHora1.Name = "TextHora1"
        Me.TextHora1.Size = New System.Drawing.Size(40, 20)
        Me.TextHora1.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(641, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Hora inicio:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextConlObserva
        '
        Me.TextConlObserva.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextConlObserva.BackColor = System.Drawing.Color.White
        Me.TextConlObserva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextConlObserva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConlObserva.Location = New System.Drawing.Point(102, 185)
        Me.TextConlObserva.MaxLength = 60
        Me.TextConlObserva.Name = "TextConlObserva"
        Me.TextConlObserva.Size = New System.Drawing.Size(541, 20)
        Me.TextConlObserva.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 185)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Observaciones:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BackColor = System.Drawing.Color.White
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.Location = New System.Drawing.Point(816, 61)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(133, 21)
        Me.cmbFormaPago.TabIndex = 8
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(729, 61)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(81, 13)
        Me.Label50.TabIndex = 85
        Me.Label50.Text = "Forma de pago:"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbModPago
        '
        Me.cmbModPago.BackColor = System.Drawing.Color.White
        Me.cmbModPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModPago.Items.AddRange(New Object() {"MENSUAL", "QUINCENAL", ""})
        Me.cmbModPago.Location = New System.Drawing.Point(464, 61)
        Me.cmbModPago.Name = "cmbModPago"
        Me.cmbModPago.Size = New System.Drawing.Size(137, 21)
        Me.cmbModPago.TabIndex = 6
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(362, 61)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(101, 13)
        Me.Label36.TabIndex = 82
        Me.Label36.Text = "Modalidad de pago:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbJornada
        '
        Me.cmbJornada.BackColor = System.Drawing.Color.White
        Me.cmbJornada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJornada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbJornada.Location = New System.Drawing.Point(464, 96)
        Me.cmbJornada.Name = "cmbJornada"
        Me.cmbJornada.Size = New System.Drawing.Size(164, 21)
        Me.cmbJornada.TabIndex = 11
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(410, 96)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(48, 13)
        Me.Label45.TabIndex = 74
        Me.Label45.Text = "Jornada:"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(738, 28)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(72, 13)
        Me.Label44.TabIndex = 72
        Me.Label44.Text = "Tipo de base:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPuesto
        '
        Me.cmbPuesto.BackColor = System.Drawing.Color.White
        Me.cmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPuesto.Location = New System.Drawing.Point(97, 61)
        Me.cmbPuesto.Name = "cmbPuesto"
        Me.cmbPuesto.Size = New System.Drawing.Size(260, 21)
        Me.cmbPuesto.TabIndex = 5
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(48, 61)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(43, 13)
        Me.Label42.TabIndex = 68
        Me.Label42.Text = "Puesto:"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(958, 61)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 66
        Me.Label18.Text = "Cta. Banc"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textConlcuentaban
        '
        Me.textConlcuentaban.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textConlcuentaban.BackColor = System.Drawing.Color.White
        Me.textConlcuentaban.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConlcuentaban.Location = New System.Drawing.Point(1018, 61)
        Me.textConlcuentaban.MaxLength = 10
        Me.textConlcuentaban.Name = "textConlcuentaban"
        Me.textConlcuentaban.Size = New System.Drawing.Size(90, 20)
        Me.textConlcuentaban.TabIndex = 9
        '
        'cmbTipoSeguro
        '
        Me.cmbTipoSeguro.BackColor = System.Drawing.Color.White
        Me.cmbTipoSeguro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoSeguro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoSeguro.Location = New System.Drawing.Point(97, 28)
        Me.cmbTipoSeguro.Name = "cmbTipoSeguro"
        Me.cmbTipoSeguro.Size = New System.Drawing.Size(260, 21)
        Me.cmbTipoSeguro.TabIndex = 2
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(8, 28)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(83, 31)
        Me.Label31.TabIndex = 14
        Me.Label31.Text = "Tipo de seguro social:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoPer
        '
        Me.cmbTipoPer.BackColor = System.Drawing.Color.White
        Me.cmbTipoPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPer.Location = New System.Drawing.Point(464, 28)
        Me.cmbTipoPer.Name = "cmbTipoPer"
        Me.cmbTipoPer.Size = New System.Drawing.Size(255, 21)
        Me.cmbTipoPer.TabIndex = 3
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(372, 28)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(89, 13)
        Me.Label30.TabIndex = 12
        Me.Label30.Text = "Tipo de personal:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbOrigenes
        '
        Me.tbOrigenes.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tbOrigenes.Controls.Add(Me.btnCancelar)
        Me.tbOrigenes.Controls.Add(Me.TextTotal)
        Me.tbOrigenes.Controls.Add(Me.Label12)
        Me.tbOrigenes.Controls.Add(Me.Label10)
        Me.tbOrigenes.Controls.Add(Me.TextPorce)
        Me.tbOrigenes.Controls.Add(Me.gpCentro)
        Me.tbOrigenes.Controls.Add(Me.dgDatos)
        Me.tbOrigenes.Controls.Add(Me.btnIngresar)
        Me.tbOrigenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbOrigenes.Location = New System.Drawing.Point(4, 22)
        Me.tbOrigenes.Name = "tbOrigenes"
        Me.tbOrigenes.Size = New System.Drawing.Size(1114, 391)
        Me.tbOrigenes.TabIndex = 5
        Me.tbOrigenes.Text = "Ingreso de centros de costo"
        Me.tbOrigenes.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageKey = "cancelar.png"
        Me.btnCancelar.ImageList = Me.ImageNuevos
        Me.btnCancelar.Location = New System.Drawing.Point(813, 17)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 100
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelar, "Cancelar")
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'TextTotal
        '
        Me.TextTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextTotal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextTotal.BackColor = System.Drawing.Color.White
        Me.TextTotal.Font = New System.Drawing.Font("Courier New", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotal.ForeColor = System.Drawing.Color.Red
        Me.TextTotal.Location = New System.Drawing.Point(963, 347)
        Me.TextTotal.MaxLength = 3
        Me.TextTotal.Name = "TextTotal"
        Me.TextTotal.Size = New System.Drawing.Size(141, 35)
        Me.TextTotal.TabIndex = 99
        Me.TextTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(868, 351)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 24)
        Me.Label12.TabIndex = 98
        Me.Label12.Text = "Total:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(546, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 96
        Me.Label10.Text = "Porcentaje:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextPorce
        '
        Me.TextPorce.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextPorce.BackColor = System.Drawing.Color.White
        Me.TextPorce.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPorce.Location = New System.Drawing.Point(616, 22)
        Me.TextPorce.MaxLength = 3
        Me.TextPorce.Name = "TextPorce"
        Me.TextPorce.Size = New System.Drawing.Size(62, 20)
        Me.TextPorce.TabIndex = 2
        '
        'gpCentro
        '
        Me.gpCentro.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpCentro.Controls.Add(Me.btnOrigen)
        Me.gpCentro.Controls.Add(Me.TextNombOrigen)
        Me.gpCentro.Controls.Add(Me.Label2)
        Me.gpCentro.Controls.Add(Me.TextOrigen)
        Me.gpCentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCentro.Location = New System.Drawing.Point(8, 6)
        Me.gpCentro.Name = "gpCentro"
        Me.gpCentro.Size = New System.Drawing.Size(526, 46)
        Me.gpCentro.TabIndex = 1
        Me.gpCentro.TabStop = False
        Me.gpCentro.Text = "Centro de costo"
        '
        'btnOrigen
        '
        Me.btnOrigen.BackColor = System.Drawing.SystemColors.Control
        Me.btnOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrigen.ImageKey = "buscar1.png"
        Me.btnOrigen.ImageList = Me.ImageNuevos
        Me.btnOrigen.Location = New System.Drawing.Point(458, 13)
        Me.btnOrigen.Name = "btnOrigen"
        Me.btnOrigen.Size = New System.Drawing.Size(33, 30)
        Me.btnOrigen.TabIndex = 3
        Me.btnOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnOrigen, "Centro")
        Me.btnOrigen.UseVisualStyleBackColor = False
        '
        'TextNombOrigen
        '
        Me.TextNombOrigen.BackColor = System.Drawing.Color.White
        Me.TextNombOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombOrigen.Location = New System.Drawing.Point(132, 16)
        Me.TextNombOrigen.MaxLength = 40
        Me.TextNombOrigen.Name = "TextNombOrigen"
        Me.TextNombOrigen.Size = New System.Drawing.Size(320, 20)
        Me.TextNombOrigen.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(79, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Nombre:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextOrigen
        '
        Me.TextOrigen.BackColor = System.Drawing.Color.White
        Me.TextOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextOrigen.Location = New System.Drawing.Point(8, 16)
        Me.TextOrigen.MaxLength = 6
        Me.TextOrigen.Name = "TextOrigen"
        Me.TextOrigen.Size = New System.Drawing.Size(56, 20)
        Me.TextOrigen.TabIndex = 1
        '
        'dgDatos
        '
        Me.dgDatos.AllowUserToAddRows = False
        Me.dgDatos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen
        Me.dgDatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatos.ContextMenuStrip = Me.ctxMenuOrigen
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDatos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgDatos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatos.Location = New System.Drawing.Point(8, 58)
        Me.dgDatos.MultiSelect = False
        Me.dgDatos.Name = "dgDatos"
        Me.dgDatos.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDatos.Size = New System.Drawing.Size(1096, 283)
        Me.dgDatos.TabIndex = 65
        '
        'ctxMenuOrigen
        '
        Me.ctxMenuOrigen.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxEliminaCentro})
        Me.ctxMenuOrigen.Name = "ctxMenu"
        Me.ctxMenuOrigen.Size = New System.Drawing.Size(160, 26)
        '
        'ctxEliminaCentro
        '
        Me.ctxEliminaCentro.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEliminaCentro.Name = "ctxEliminaCentro"
        Me.ctxEliminaCentro.Size = New System.Drawing.Size(159, 22)
        Me.ctxEliminaCentro.Text = " Eliminar Sueldo"
        '
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresar.ImageKey = "checkok.png"
        Me.btnIngresar.ImageList = Me.ImageNuevos
        Me.btnIngresar.Location = New System.Drawing.Point(722, 17)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(77, 30)
        Me.btnIngresar.TabIndex = 3
        Me.btnIngresar.Text = "Aceptar"
        Me.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngresar, "Ingresar")
        Me.btnIngresar.UseVisualStyleBackColor = False
        '
        'tbSueldo
        '
        Me.tbSueldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tbSueldo.Controls.Add(Me.pnSueldos)
        Me.tbSueldo.Controls.Add(Me.TextTotalSueldo)
        Me.tbSueldo.Controls.Add(Me.Label25)
        Me.tbSueldo.Controls.Add(Me.dgSueldos)
        Me.tbSueldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSueldo.Location = New System.Drawing.Point(4, 22)
        Me.tbSueldo.Name = "tbSueldo"
        Me.tbSueldo.Size = New System.Drawing.Size(1114, 391)
        Me.tbSueldo.TabIndex = 7
        Me.tbSueldo.Text = "Sueldo"
        '
        'pnSueldos
        '
        Me.pnSueldos.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.pnSueldos.Controls.Add(Me.TextConcepto)
        Me.pnSueldos.Controls.Add(Me.Label20)
        Me.pnSueldos.Controls.Add(Me.Label17)
        Me.pnSueldos.Controls.Add(Me.cmbTipo)
        Me.pnSueldos.Controls.Add(Me.gpTransaccion)
        Me.pnSueldos.Controls.Add(Me.Label16)
        Me.pnSueldos.Controls.Add(Me.cmbAfecta)
        Me.pnSueldos.Controls.Add(Me.TextValor)
        Me.pnSueldos.Controls.Add(Me.btnCancelSueldo)
        Me.pnSueldos.Controls.Add(Me.Label19)
        Me.pnSueldos.Controls.Add(Me.btnIngSueldo)
        Me.pnSueldos.Location = New System.Drawing.Point(7, 16)
        Me.pnSueldos.Name = "pnSueldos"
        Me.pnSueldos.Size = New System.Drawing.Size(1001, 83)
        Me.pnSueldos.TabIndex = 118
        '
        'TextConcepto
        '
        Me.TextConcepto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextConcepto.BackColor = System.Drawing.Color.White
        Me.TextConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConcepto.Location = New System.Drawing.Point(331, 52)
        Me.TextConcepto.MaxLength = 75
        Me.TextConcepto.Name = "TextConcepto"
        Me.TextConcepto.Size = New System.Drawing.Size(483, 20)
        Me.TextConcepto.TabIndex = 5
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(269, 55)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 13)
        Me.Label20.TabIndex = 118
        Me.Label20.Text = "Concepto:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 13)
        Me.Label17.TabIndex = 116
        Me.Label17.Text = "Tipo movimiento"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.Color.White
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Items.AddRange(New Object() {"VALORES INICIALES", "AUMENTO", "REBAJA", ""})
        Me.cmbTipo.Location = New System.Drawing.Point(96, 53)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(146, 21)
        Me.cmbTipo.TabIndex = 4
        '
        'gpTransaccion
        '
        Me.gpTransaccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpTransaccion.Controls.Add(Me.btnBuscaCodigo)
        Me.gpTransaccion.Controls.Add(Me.textNombCodigo)
        Me.gpTransaccion.Controls.Add(Me.textCodigo)
        Me.gpTransaccion.Controls.Add(Me.Label15)
        Me.gpTransaccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTransaccion.Location = New System.Drawing.Point(3, 3)
        Me.gpTransaccion.Name = "gpTransaccion"
        Me.gpTransaccion.Size = New System.Drawing.Size(541, 45)
        Me.gpTransaccion.TabIndex = 1
        Me.gpTransaccion.TabStop = False
        Me.gpTransaccion.Text = "Transacción de nómina"
        '
        'btnBuscaCodigo
        '
        Me.btnBuscaCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscaCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaCodigo.ImageKey = "buscar1.png"
        Me.btnBuscaCodigo.ImageList = Me.ImageNuevos
        Me.btnBuscaCodigo.Location = New System.Drawing.Point(441, 9)
        Me.btnBuscaCodigo.Name = "btnBuscaCodigo"
        Me.btnBuscaCodigo.Size = New System.Drawing.Size(32, 30)
        Me.btnBuscaCodigo.TabIndex = 3
        Me.btnBuscaCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscaCodigo, "Buscar Transaccion")
        Me.btnBuscaCodigo.UseVisualStyleBackColor = False
        '
        'textNombCodigo
        '
        Me.textNombCodigo.BackColor = System.Drawing.Color.White
        Me.textNombCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombCodigo.Location = New System.Drawing.Point(123, 17)
        Me.textNombCodigo.MaxLength = 25
        Me.textNombCodigo.Name = "textNombCodigo"
        Me.textNombCodigo.Size = New System.Drawing.Size(316, 20)
        Me.textNombCodigo.TabIndex = 2
        '
        'textCodigo
        '
        Me.textCodigo.BackColor = System.Drawing.Color.White
        Me.textCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textCodigo.Location = New System.Drawing.Point(6, 17)
        Me.textCodigo.MaxLength = 5
        Me.textCodigo.Name = "textCodigo"
        Me.textCodigo.Size = New System.Drawing.Size(48, 20)
        Me.textCodigo.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(63, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 13)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "Nombre:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label16.Location = New System.Drawing.Point(552, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 108
        Me.Label16.Text = "Afecta días:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAfecta
        '
        Me.cmbAfecta.BackColor = System.Drawing.Color.White
        Me.cmbAfecta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAfecta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAfecta.Items.AddRange(New Object() {"S", "N", ""})
        Me.cmbAfecta.Location = New System.Drawing.Point(627, 11)
        Me.cmbAfecta.Name = "cmbAfecta"
        Me.cmbAfecta.Size = New System.Drawing.Size(41, 21)
        Me.cmbAfecta.TabIndex = 2
        '
        'TextValor
        '
        Me.TextValor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextValor.BackColor = System.Drawing.Color.White
        Me.TextValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValor.Location = New System.Drawing.Point(759, 12)
        Me.TextValor.MaxLength = 11
        Me.TextValor.Name = "TextValor"
        Me.TextValor.Size = New System.Drawing.Size(105, 20)
        Me.TextValor.TabIndex = 3
        '
        'btnCancelSueldo
        '
        Me.btnCancelSueldo.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelSueldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelSueldo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelSueldo.ImageKey = "cancelar.png"
        Me.btnCancelSueldo.ImageList = Me.ImageNuevos
        Me.btnCancelSueldo.Location = New System.Drawing.Point(910, 44)
        Me.btnCancelSueldo.Name = "btnCancelSueldo"
        Me.btnCancelSueldo.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelSueldo.TabIndex = 114
        Me.btnCancelSueldo.Text = "Cancelar"
        Me.btnCancelSueldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelSueldo, "Cancelar")
        Me.btnCancelSueldo.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(719, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 112
        Me.Label19.Text = "Valor:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnIngSueldo
        '
        Me.btnIngSueldo.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngSueldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngSueldo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngSueldo.ImageKey = "checkok.png"
        Me.btnIngSueldo.ImageList = Me.ImageNuevos
        Me.btnIngSueldo.Location = New System.Drawing.Point(822, 44)
        Me.btnIngSueldo.Name = "btnIngSueldo"
        Me.btnIngSueldo.Size = New System.Drawing.Size(82, 30)
        Me.btnIngSueldo.TabIndex = 6
        Me.btnIngSueldo.Text = "Aceptar"
        Me.btnIngSueldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngSueldo, "Ingresar")
        Me.btnIngSueldo.UseVisualStyleBackColor = False
        '
        'TextTotalSueldo
        '
        Me.TextTotalSueldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextTotalSueldo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextTotalSueldo.BackColor = System.Drawing.Color.White
        Me.TextTotalSueldo.Font = New System.Drawing.Font("Courier New", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalSueldo.ForeColor = System.Drawing.Color.Red
        Me.TextTotalSueldo.Location = New System.Drawing.Point(940, 347)
        Me.TextTotalSueldo.MaxLength = 3
        Me.TextTotalSueldo.Name = "TextTotalSueldo"
        Me.TextTotalSueldo.Size = New System.Drawing.Size(165, 35)
        Me.TextTotalSueldo.TabIndex = 117
        Me.TextTotalSueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(872, 351)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(62, 24)
        Me.Label25.TabIndex = 116
        Me.Label25.Text = "Total:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgSueldos
        '
        Me.dgSueldos.AllowUserToAddRows = False
        Me.dgSueldos.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGreen
        Me.dgSueldos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgSueldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSueldos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgSueldos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgSueldos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSueldos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgSueldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSueldos.ContextMenuStrip = Me.ctxMenuSueldos
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSueldos.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgSueldos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgSueldos.Location = New System.Drawing.Point(8, 105)
        Me.dgSueldos.MultiSelect = False
        Me.dgSueldos.Name = "dgSueldos"
        Me.dgSueldos.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSueldos.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgSueldos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSueldos.Size = New System.Drawing.Size(1097, 236)
        Me.dgSueldos.TabIndex = 115
        '
        'ctxMenuSueldos
        '
        Me.ctxMenuSueldos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModiSueldo, Me.ctxEliSueldo})
        Me.ctxMenuSueldos.Name = "ctxMenu"
        Me.ctxMenuSueldos.Size = New System.Drawing.Size(165, 48)
        '
        'ctxModiSueldo
        '
        Me.ctxModiSueldo.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.ctxModiSueldo.Name = "ctxModiSueldo"
        Me.ctxModiSueldo.Size = New System.Drawing.Size(164, 22)
        Me.ctxModiSueldo.Text = "Modificar Sueldo"
        '
        'ctxEliSueldo
        '
        Me.ctxEliSueldo.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEliSueldo.Name = "ctxEliSueldo"
        Me.ctxEliSueldo.Size = New System.Drawing.Size(164, 22)
        Me.ctxEliSueldo.Text = " Eliminar Sueldo"
        '
        'tabEventos
        '
        Me.tabEventos.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tabEventos.Controls.Add(Me.dgEventos)
        Me.tabEventos.Controls.Add(Me.pnEventos)
        Me.tabEventos.Location = New System.Drawing.Point(4, 22)
        Me.tabEventos.Name = "tabEventos"
        Me.tabEventos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEventos.Size = New System.Drawing.Size(1114, 391)
        Me.tabEventos.TabIndex = 8
        Me.tabEventos.Text = "Eventos"
        '
        'dgEventos
        '
        Me.dgEventos.AllowUserToAddRows = False
        Me.dgEventos.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGreen
        Me.dgEventos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgEventos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgEventos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgEventos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgEventos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgEventos.ContextMenuStrip = Me.ctxMenuEvento
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgEventos.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgEventos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgEventos.Location = New System.Drawing.Point(16, 111)
        Me.dgEventos.MultiSelect = False
        Me.dgEventos.Name = "dgEventos"
        Me.dgEventos.ReadOnly = True
        Me.dgEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgEventos.Size = New System.Drawing.Size(1088, 271)
        Me.dgEventos.TabIndex = 120
        '
        'ctxMenuEvento
        '
        Me.ctxMenuEvento.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModiEvento, Me.ctxEliEvento})
        Me.ctxMenuEvento.Name = "ctxMenu"
        Me.ctxMenuEvento.Size = New System.Drawing.Size(165, 48)
        '
        'ctxModiEvento
        '
        Me.ctxModiEvento.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.ctxModiEvento.Name = "ctxModiEvento"
        Me.ctxModiEvento.Size = New System.Drawing.Size(164, 22)
        Me.ctxModiEvento.Text = "Modificar Evento"
        '
        'ctxEliEvento
        '
        Me.ctxEliEvento.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEliEvento.Name = "ctxEliEvento"
        Me.ctxEliEvento.Size = New System.Drawing.Size(164, 22)
        Me.ctxEliEvento.Text = " Eliminar Evento"
        '
        'pnEventos
        '
        Me.pnEventos.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.pnEventos.Controls.Add(Me.gpEvento)
        Me.pnEventos.Controls.Add(Me.btnCancelEvento)
        Me.pnEventos.Controls.Add(Me.btnIngEvento)
        Me.pnEventos.Location = New System.Drawing.Point(3, 16)
        Me.pnEventos.Name = "pnEventos"
        Me.pnEventos.Size = New System.Drawing.Size(1098, 92)
        Me.pnEventos.TabIndex = 119
        '
        'gpEvento
        '
        Me.gpEvento.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpEvento.Controls.Add(Me.textFechaEvento)
        Me.gpEvento.Controls.Add(Me.lblFecha)
        Me.gpEvento.Controls.Add(Me.cmbTipoAccion)
        Me.gpEvento.Controls.Add(Me.textObservaEvento)
        Me.gpEvento.Controls.Add(Me.lblTipoEvento)
        Me.gpEvento.Controls.Add(Me.lblObserva)
        Me.gpEvento.Controls.Add(Me.lblAccionEvento)
        Me.gpEvento.Controls.Add(Me.cmbTipoEvento)
        Me.gpEvento.Controls.Add(Me.lblMotivo)
        Me.gpEvento.Controls.Add(Me.cmbMotivoEvento)
        Me.gpEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEvento.Location = New System.Drawing.Point(10, 12)
        Me.gpEvento.Name = "gpEvento"
        Me.gpEvento.Size = New System.Drawing.Size(876, 77)
        Me.gpEvento.TabIndex = 1
        Me.gpEvento.TabStop = False
        Me.gpEvento.Text = "Evento"
        '
        'textFechaEvento
        '
        Me.textFechaEvento.BackColor = System.Drawing.Color.White
        Me.textFechaEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFechaEvento.Location = New System.Drawing.Point(56, 17)
        Me.textFechaEvento.Mask = "##/##/####"
        Me.textFechaEvento.Name = "textFechaEvento"
        Me.textFechaEvento.Size = New System.Drawing.Size(84, 20)
        Me.textFechaEvento.TabIndex = 1
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(6, 20)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 125
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoAccion
        '
        Me.cmbTipoAccion.BackColor = System.Drawing.Color.White
        Me.cmbTipoAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoAccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoAccion.Location = New System.Drawing.Point(721, 13)
        Me.cmbTipoAccion.Name = "cmbTipoAccion"
        Me.cmbTipoAccion.Size = New System.Drawing.Size(146, 21)
        Me.cmbTipoAccion.TabIndex = 4
        '
        'textObservaEvento
        '
        Me.textObservaEvento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textObservaEvento.BackColor = System.Drawing.Color.White
        Me.textObservaEvento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textObservaEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textObservaEvento.Location = New System.Drawing.Point(100, 49)
        Me.textObservaEvento.MaxLength = 75
        Me.textObservaEvento.Name = "textObservaEvento"
        Me.textObservaEvento.Size = New System.Drawing.Size(540, 20)
        Me.textObservaEvento.TabIndex = 5
        '
        'lblTipoEvento
        '
        Me.lblTipoEvento.AutoSize = True
        Me.lblTipoEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoEvento.Location = New System.Drawing.Point(154, 21)
        Me.lblTipoEvento.Name = "lblTipoEvento"
        Me.lblTipoEvento.Size = New System.Drawing.Size(67, 13)
        Me.lblTipoEvento.TabIndex = 116
        Me.lblTipoEvento.Text = "Tipo evento:"
        Me.lblTipoEvento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObserva
        '
        Me.lblObserva.AutoSize = True
        Me.lblObserva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObserva.Location = New System.Drawing.Point(6, 51)
        Me.lblObserva.Name = "lblObserva"
        Me.lblObserva.Size = New System.Drawing.Size(81, 13)
        Me.lblObserva.TabIndex = 118
        Me.lblObserva.Text = "Observaciones:"
        Me.lblObserva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccionEvento
        '
        Me.lblAccionEvento.AutoSize = True
        Me.lblAccionEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionEvento.Location = New System.Drawing.Point(647, 17)
        Me.lblAccionEvento.Name = "lblAccionEvento"
        Me.lblAccionEvento.Size = New System.Drawing.Size(66, 13)
        Me.lblAccionEvento.TabIndex = 123
        Me.lblAccionEvento.Text = "Tipo acción:"
        Me.lblAccionEvento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoEvento
        '
        Me.cmbTipoEvento.BackColor = System.Drawing.Color.White
        Me.cmbTipoEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoEvento.Location = New System.Drawing.Point(230, 16)
        Me.cmbTipoEvento.Name = "cmbTipoEvento"
        Me.cmbTipoEvento.Size = New System.Drawing.Size(159, 21)
        Me.cmbTipoEvento.TabIndex = 2
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotivo.Location = New System.Drawing.Point(406, 19)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(42, 13)
        Me.lblMotivo.TabIndex = 122
        Me.lblMotivo.Text = "Motivo:"
        Me.lblMotivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMotivoEvento
        '
        Me.cmbMotivoEvento.BackColor = System.Drawing.Color.White
        Me.cmbMotivoEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivoEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMotivoEvento.Location = New System.Drawing.Point(460, 15)
        Me.cmbMotivoEvento.Name = "cmbMotivoEvento"
        Me.cmbMotivoEvento.Size = New System.Drawing.Size(180, 21)
        Me.cmbMotivoEvento.TabIndex = 3
        '
        'btnCancelEvento
        '
        Me.btnCancelEvento.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelEvento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelEvento.ImageKey = "cancelar.png"
        Me.btnCancelEvento.ImageList = Me.ImageNuevos
        Me.btnCancelEvento.Location = New System.Drawing.Point(974, 55)
        Me.btnCancelEvento.Name = "btnCancelEvento"
        Me.btnCancelEvento.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelEvento.TabIndex = 7
        Me.btnCancelEvento.Text = "Cancelar"
        Me.btnCancelEvento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelEvento, "Cancelar")
        Me.btnCancelEvento.UseVisualStyleBackColor = False
        '
        'btnIngEvento
        '
        Me.btnIngEvento.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngEvento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngEvento.ImageKey = "checkok.png"
        Me.btnIngEvento.ImageList = Me.ImageNuevos
        Me.btnIngEvento.Location = New System.Drawing.Point(894, 55)
        Me.btnIngEvento.Name = "btnIngEvento"
        Me.btnIngEvento.Size = New System.Drawing.Size(72, 30)
        Me.btnIngEvento.TabIndex = 6
        Me.btnIngEvento.Text = "Aceptar"
        Me.btnIngEvento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngEvento, "Ingresar")
        Me.btnIngEvento.UseVisualStyleBackColor = False
        '
        'TabJefes
        '
        Me.TabJefes.Controls.Add(Me.scJefe)
        Me.TabJefes.Location = New System.Drawing.Point(4, 22)
        Me.TabJefes.Name = "TabJefes"
        Me.TabJefes.Padding = New System.Windows.Forms.Padding(3)
        Me.TabJefes.Size = New System.Drawing.Size(1114, 391)
        Me.TabJefes.TabIndex = 9
        Me.TabJefes.Text = "Jefes"
        Me.TabJefes.UseVisualStyleBackColor = True
        '
        'scJefe
        '
        Me.scJefe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scJefe.Location = New System.Drawing.Point(3, 3)
        Me.scJefe.Name = "scJefe"
        Me.scJefe.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scJefe.Panel1
        '
        Me.scJefe.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.scJefe.Panel1.Controls.Add(Me.btnAsignaJefe)
        Me.scJefe.Panel1.Controls.Add(Me.gpEmpleado)
        Me.scJefe.Panel1.Controls.Add(Me.GroupBox1)
        '
        'scJefe.Panel2
        '
        Me.scJefe.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.scJefe.Panel2.Controls.Add(Me.dgvJefe)
        Me.scJefe.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.scJefe.Size = New System.Drawing.Size(1108, 385)
        Me.scJefe.SplitterDistance = 93
        Me.scJefe.TabIndex = 0
        '
        'btnAsignaJefe
        '
        Me.btnAsignaJefe.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignaJefe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsignaJefe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignaJefe.ImageKey = "checkok.png"
        Me.btnAsignaJefe.ImageList = Me.ImageNuevos
        Me.btnAsignaJefe.Location = New System.Drawing.Point(775, 14)
        Me.btnAsignaJefe.Name = "btnAsignaJefe"
        Me.btnAsignaJefe.Size = New System.Drawing.Size(81, 30)
        Me.btnAsignaJefe.TabIndex = 7
        Me.btnAsignaJefe.Text = "Aceptar"
        Me.btnAsignaJefe.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAsignaJefe, "Ingresar")
        Me.btnAsignaJefe.UseVisualStyleBackColor = False
        '
        'gpEmpleado
        '
        Me.gpEmpleado.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpEmpleado.Controls.Add(Me.btnBuscaJefe)
        Me.gpEmpleado.Controls.Add(Me.TextNombreJefe)
        Me.gpEmpleado.Controls.Add(Me.TextJefe)
        Me.gpEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpleado.ForeColor = System.Drawing.Color.Black
        Me.gpEmpleado.Location = New System.Drawing.Point(16, 5)
        Me.gpEmpleado.Name = "gpEmpleado"
        Me.gpEmpleado.Size = New System.Drawing.Size(599, 45)
        Me.gpEmpleado.TabIndex = 3
        Me.gpEmpleado.TabStop = False
        Me.gpEmpleado.Text = "Jefe"
        '
        'btnBuscaJefe
        '
        Me.btnBuscaJefe.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscaJefe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaJefe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscaJefe.ImageKey = "usuario.png"
        Me.btnBuscaJefe.ImageList = Me.ImageNuevos
        Me.btnBuscaJefe.Location = New System.Drawing.Point(526, 10)
        Me.btnBuscaJefe.Name = "btnBuscaJefe"
        Me.btnBuscaJefe.Size = New System.Drawing.Size(36, 30)
        Me.btnBuscaJefe.TabIndex = 3
        Me.btnBuscaJefe.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscaJefe, "Empleado")
        Me.btnBuscaJefe.UseVisualStyleBackColor = False
        '
        'TextNombreJefe
        '
        Me.TextNombreJefe.BackColor = System.Drawing.Color.White
        Me.TextNombreJefe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombreJefe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombreJefe.Location = New System.Drawing.Point(72, 15)
        Me.TextNombreJefe.MaxLength = 40
        Me.TextNombreJefe.Name = "TextNombreJefe"
        Me.TextNombreJefe.Size = New System.Drawing.Size(448, 20)
        Me.TextNombreJefe.TabIndex = 2
        '
        'TextJefe
        '
        Me.TextJefe.BackColor = System.Drawing.Color.White
        Me.TextJefe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextJefe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextJefe.Location = New System.Drawing.Point(10, 15)
        Me.TextJefe.MaxLength = 6
        Me.TextJefe.Name = "TextJefe"
        Me.TextJefe.Size = New System.Drawing.Size(56, 20)
        Me.TextJefe.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.btnContrato)
        Me.GroupBox1.Controls.Add(Me.TextContratoJefe)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(621, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(139, 47)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Contrato"
        '
        'btnContrato
        '
        Me.btnContrato.BackColor = System.Drawing.SystemColors.Control
        Me.btnContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContrato.ImageKey = "buscar2.png"
        Me.btnContrato.ImageList = Me.ImageNuevos
        Me.btnContrato.Location = New System.Drawing.Point(79, 9)
        Me.btnContrato.Name = "btnContrato"
        Me.btnContrato.Size = New System.Drawing.Size(40, 32)
        Me.btnContrato.TabIndex = 2
        Me.btnContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnContrato.UseVisualStyleBackColor = False
        '
        'TextContratoJefe
        '
        Me.TextContratoJefe.BackColor = System.Drawing.Color.White
        Me.TextContratoJefe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextContratoJefe.ForeColor = System.Drawing.Color.Red
        Me.TextContratoJefe.Location = New System.Drawing.Point(10, 18)
        Me.TextContratoJefe.MaxLength = 9
        Me.TextContratoJefe.Name = "TextContratoJefe"
        Me.TextContratoJefe.Size = New System.Drawing.Size(63, 20)
        Me.TextContratoJefe.TabIndex = 1
        '
        'dgvJefe
        '
        Me.dgvJefe.AllowUserToAddRows = False
        Me.dgvJefe.AllowUserToDeleteRows = False
        Me.dgvJefe.AllowUserToOrderColumns = True
        Me.dgvJefe.AllowUserToResizeColumns = False
        Me.dgvJefe.AllowUserToResizeRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightGreen
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvJefe.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvJefe.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvJefe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvJefe.BackgroundColor = System.Drawing.Color.White
        Me.dgvJefe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJefe.ContextMenuStrip = Me.ctxMenuJefe
        Me.dgvJefe.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvJefe.Location = New System.Drawing.Point(9, 3)
        Me.dgvJefe.MultiSelect = False
        Me.dgvJefe.Name = "dgvJefe"
        Me.dgvJefe.ReadOnly = True
        Me.dgvJefe.RowHeadersVisible = False
        Me.dgvJefe.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvJefe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJefe.Size = New System.Drawing.Size(1102, 282)
        Me.dgvJefe.TabIndex = 6
        '
        'ctxMenuJefe
        '
        Me.ctxMenuJefe.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxEliminarJefe})
        Me.ctxMenuJefe.Name = "ctxMenu"
        Me.ctxMenuJefe.Size = New System.Drawing.Size(144, 26)
        '
        'ctxEliminarJefe
        '
        Me.ctxEliminarJefe.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEliminarJefe.Name = "ctxEliminarJefe"
        Me.ctxEliminarJefe.Size = New System.Drawing.Size(143, 22)
        Me.ctxEliminarJefe.Text = " Eliminar Jefe"
        '
        'gpContrato
        '
        Me.gpContrato.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpContrato.Controls.Add(Me.TextConxContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.Location = New System.Drawing.Point(606, 3)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(74, 44)
        Me.gpContrato.TabIndex = 1
        Me.gpContrato.TabStop = False
        Me.gpContrato.Text = "Contrato"
        '
        'TextConxContrato
        '
        Me.TextConxContrato.BackColor = System.Drawing.Color.White
        Me.TextConxContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxContrato.ForeColor = System.Drawing.Color.Red
        Me.TextConxContrato.Location = New System.Drawing.Point(6, 20)
        Me.TextConxContrato.MaxLength = 9
        Me.TextConxContrato.Name = "TextConxContrato"
        Me.TextConxContrato.ReadOnly = True
        Me.TextConxContrato.Size = New System.Drawing.Size(63, 20)
        Me.TextConxContrato.TabIndex = 1
        Me.TextConxContrato.TabStop = False
        '
        'gpChofer
        '
        Me.gpChofer.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpChofer.Controls.Add(Me.btnEmpleado)
        Me.gpChofer.Controls.Add(Me.textNombreEmple)
        Me.gpChofer.Controls.Add(Me.textConxEmpleado)
        Me.gpChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChofer.Location = New System.Drawing.Point(6, 3)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(594, 44)
        Me.gpChofer.TabIndex = 1
        Me.gpChofer.TabStop = False
        Me.gpChofer.Text = "Empleado"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(534, 10)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(39, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Empleado")
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.Location = New System.Drawing.Point(78, 19)
        Me.textNombreEmple.MaxLength = 40
        Me.textNombreEmple.Name = "textNombreEmple"
        Me.textNombreEmple.Size = New System.Drawing.Size(448, 20)
        Me.textNombreEmple.TabIndex = 2
        '
        'textConxEmpleado
        '
        Me.textConxEmpleado.BackColor = System.Drawing.Color.White
        Me.textConxEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConxEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConxEmpleado.Location = New System.Drawing.Point(8, 19)
        Me.textConxEmpleado.MaxLength = 6
        Me.textConxEmpleado.Name = "textConxEmpleado"
        Me.textConxEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textConxEmpleado.TabIndex = 1
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(96, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 30)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.BackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.ImageKey = "impresora2.png"
        Me.btnImprimir.ImageList = Me.ImageNuevos
        Me.btnImprimir.Location = New System.Drawing.Point(793, 8)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(76, 30)
        Me.btnImprimir.TabIndex = 66
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir contrato")
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btnSig
        '
        Me.btnSig.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSig.BackColor = System.Drawing.SystemColors.Control
        Me.btnSig.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSig.ImageKey = "siguiente.png"
        Me.btnSig.ImageList = Me.ImageNuevos
        Me.btnSig.Location = New System.Drawing.Point(1039, 8)
        Me.btnSig.Name = "btnSig"
        Me.btnSig.Size = New System.Drawing.Size(78, 30)
        Me.btnSig.TabIndex = 65
        Me.btnSig.TabStop = False
        Me.btnSig.Text = "Siguiente"
        Me.btnSig.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSig, "Siguiente Registro")
        Me.btnSig.UseVisualStyleBackColor = False
        '
        'btnAtr
        '
        Me.btnAtr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAtr.BackColor = System.Drawing.SystemColors.Control
        Me.btnAtr.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAtr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtr.ImageKey = "anterior.png"
        Me.btnAtr.ImageList = Me.ImageNuevos
        Me.btnAtr.Location = New System.Drawing.Point(10, 8)
        Me.btnAtr.Name = "btnAtr"
        Me.btnAtr.Size = New System.Drawing.Size(80, 30)
        Me.btnAtr.TabIndex = 64
        Me.btnAtr.TabStop = False
        Me.btnAtr.Text = "Anterior"
        Me.btnAtr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAtr, "Registro anterior")
        Me.btnAtr.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(875, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(76, 30)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Almacenar registro")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageKey = "buscar2.png"
        Me.btnBuscar.ImageList = Me.ImageNuevos
        Me.btnBuscar.Location = New System.Drawing.Point(957, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(76, 30)
        Me.btnBuscar.TabIndex = 63
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Buscar registro")
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(10, 3)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(432, 41)
        Me.gpEmpresa.TabIndex = 0
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(6, 15)
        Me.TextNombEmpresa.MaxLength = 30
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(425, 20)
        Me.TextNombEmpresa.TabIndex = 1
        Me.TextNombEmpresa.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(749, 59)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 35)
        Me.Button1.TabIndex = 74
        Me.Button1.TabStop = False
        Me.Button1.Text = "Agregar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(749, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 35)
        Me.Button2.TabIndex = 73
        Me.Button2.TabStop = False
        Me.Button2.Text = "Cancelar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'MaskedTextBox2
        '
        Me.MaskedTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox2.Location = New System.Drawing.Point(529, 48)
        Me.MaskedTextBox2.Mask = "##/##/####"
        Me.MaskedTextBox2.Name = "MaskedTextBox2"
        Me.MaskedTextBox2.Size = New System.Drawing.Size(84, 20)
        Me.MaskedTextBox2.TabIndex = 72
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "TIPO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(526, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 16)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "FECHA DE NACIMIENTO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.Color.White
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(154, 48)
        Me.TextBox7.MaxLength = 75
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(353, 20)
        Me.TextBox7.TabIndex = 59
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(151, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "NOMBRE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox9
        '
        Me.ComboBox9.BackColor = System.Drawing.Color.White
        Me.ComboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox9.FormattingEnabled = True
        Me.ComboBox9.Location = New System.Drawing.Point(20, 48)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox9.TabIndex = 63
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 59)
        Me.Panel1.TabIndex = 67
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnAtr)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Controls.Add(Me.btnImprimir)
        Me.Panel2.Controls.Add(Me.btnSig)
        Me.Panel2.Location = New System.Drawing.Point(0, 558)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1130, 45)
        Me.Panel2.TabIndex = 68
        '
        'pnHead
        '
        Me.pnHead.Controls.Add(Me.gpChofer)
        Me.pnHead.Controls.Add(Me.gpContrato)
        Me.pnHead.Location = New System.Drawing.Point(12, 65)
        Me.pnHead.Name = "pnHead"
        Me.pnHead.Size = New System.Drawing.Size(740, 60)
        Me.pnHead.TabIndex = 69
        '
        'frmConsContratos
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnLimpiar
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.pnHead)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.tabPages)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmConsContratos"
        Me.Text = "Mantenimiento de Contratos"
        Me.tabPages.ResumeLayout(False)
        Me.ctxPrincipal.ResumeLayout(False)
        Me.TbGeneral.ResumeLayout(False)
        Me.TbGeneral.PerformLayout()
        Me.gpFechaE.ResumeLayout(False)
        Me.gpFechaE.PerformLayout()
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        Me.gpFechaFinal.ResumeLayout(False)
        Me.gpFechaFinal.PerformLayout()
        Me.gpFechaI.ResumeLayout(False)
        Me.gpFechaI.PerformLayout()
        Me.tbOrigenes.ResumeLayout(False)
        Me.tbOrigenes.PerformLayout()
        Me.gpCentro.ResumeLayout(False)
        Me.gpCentro.PerformLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenuOrigen.ResumeLayout(False)
        Me.tbSueldo.ResumeLayout(False)
        Me.tbSueldo.PerformLayout()
        Me.pnSueldos.ResumeLayout(False)
        Me.pnSueldos.PerformLayout()
        Me.gpTransaccion.ResumeLayout(False)
        Me.gpTransaccion.PerformLayout()
        CType(Me.dgSueldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenuSueldos.ResumeLayout(False)
        Me.tabEventos.ResumeLayout(False)
        CType(Me.dgEventos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenuEvento.ResumeLayout(False)
        Me.pnEventos.ResumeLayout(False)
        Me.gpEvento.ResumeLayout(False)
        Me.gpEvento.PerformLayout()
        Me.TabJefes.ResumeLayout(False)
        Me.scJefe.Panel1.ResumeLayout(False)
        Me.scJefe.Panel2.ResumeLayout(False)
        CType(Me.scJefe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scJefe.ResumeLayout(False)
        Me.gpEmpleado.ResumeLayout(False)
        Me.gpEmpleado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvJefe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenuJefe.ResumeLayout(False)
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnHead.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter

    Dim cadena As String
    Dim tbSeguro As New DataTable("seguro")
    Dim tbPuesto As New DataTable("puesto")
    Dim tbFormaPago As New DataTable("pago")
    Dim tbTipoPer As New DataTable("tipoper")
    Dim tbOrigen As New DataTable("origen")
    Dim tbDatos As New DataTable("datos")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbConsulta As New DataTable("consulta")
    Dim tbEstado As New DataTable("estado")
    Dim tbCodigo As New DataTable("codigo")
    Dim tbDetSueldos As New DataTable("sueldos")
    Dim tbSueldoOrig As New DataTable("originales")
    Dim tbEventos As New DataTable("eventos")
    Dim tbDetJefes As New DataTable("jefes")
    Dim tbMotivoEvento As New DataTable("MotivoEvento")
    Dim tbTipoEvento As New DataTable("TipoEvento")
    Dim tbTipoAccion As New DataTable("TipoAccion")
    Dim WithEvents fOrig As frmMuestraUnidadesOp
    Dim WithEvents fEmp As frmMuestra2Columnas
    Dim WithEvents f As frmConsultaFechas
    Dim WithEvents fBaja As frmBajaContra
    Dim filaTemp As DataRow
    Dim opcModiAca, opcModiFa, IndiceAca, IndiceFam, opcSueldos, IndiceSueldo, opcEvento, IndiceEvento As Int16
    Dim usaReg As String
    Dim HoraFinal, minutoFinal As Int32
    Dim tbTipoEmpleado As New DataTable("tipoempleado")
    Dim consultaFecha, consultaFecha2, consultaFechaI, consultaFechaF As String
    Dim inicioConsulta As String = "select empleado, contrato, fecha, tiposeguro, tipoper,puesto,mpago, fpago,cuentaban," &
                                   "fechai, fechaf, base, jornada, horaini, horafin,horas,observa, c1.estado, fechae,e.activo, anticipo,semanahoras, tipoempleado, id_tipo_contrato, id_temporalidad  from  " &
                                   " contratos1 c1 inner join empestados e on c1.empresa=e.empresa and c1.estado=e.estado " &
                                   " where c1.empresa=" & empresa
    Dim ConsultaDetalle As String = "select c2.origen, ori.nombre ,por as porcentaje from contratos2 c2 inner join origenes ori on c2.origen=ori.origen and ori.empresa=c2.empresa " &
                                    " where c2.empresa=" & empresa
    Dim cadenaSueldos As String = "select s.transac, t.nombre , s.afecta,  s.valor " &
                                     " from sueldos s inner join tipotran t on s.transac=t.transac and s.empresa=t.empresa where s.empresa=" & empresa
    'Dim cadenaEventos As String = "select a.fecha, a.tipoevento, case a.tipoevento when 0 then 'GRATIFICACION' when 1 then 'SANCION' end as nombEvento," & _
    '                              "a.motivo, coalesce( b.nombre,'') as nombMotivo , a.tipoaccion, coalesce (c.nombre,'') as nombAccion, observa " & _
    '                             "from eventosper a " & _
    '                            "left join tiposeventos te on a.tipoevento=te.tipoevento " & _
    '                           "left join motivoeventos b on a.motivo=b.motivo " & _
    '                          "left join tipoacciones  c  on a.tipoaccion=c.tipoaccion " & _
    '                         "where empresa=" & empresa
    Dim cadenaEventos As String = "select a.fecha, a.tipoevento, coalesce (te.nombre,'')  as nombEvento," &
                                  "a.motivo, coalesce( b.nombre,'') as nombMotivo , a.tipoaccion, coalesce (c.nombre,'') as nombAccion, observa " &
                                  "from eventosper a " &
                                  "left join tiposeventos te on a.tipoevento=te.tipoevento " &
                                  "left join motivoeventos b on a.motivo=b.motivo " &
                                  "left join tipoacciones  c  on a.tipoaccion=c.tipoaccion " &
                                  "where empresa=" & empresa

    Dim v1 As New cyrImpReportes
    Dim base As Int32
    Dim indice As Int32
    Dim estadoPrincipal As Int32
    Dim lPara As New Dictionary(Of String, Object)
    Dim opc_modificacion_total As Int32 = 0
    Dim ctrContrato As New ContratoController()


    Private Sub frmDatosFamilia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextNombEmpresa.Text = BuscaEscalar("select nombre from Empresas where empresa=" & empresa)
        tbDatos.Clear()
        AgregarColumna(tbDatos, "origen", "System.String", "")
        AgregarColumna(tbDatos, "nombre", "System.String", "")
        AgregarColumna(tbDatos, "porcentaje", "System.Decimal", 0)
        dgDatos.DataSource = tbDatos
        Vista1(dgDatos)
        AddHandler tbDatos.ColumnChanged, AddressOf cambio_valor
        AddHandler tbDatos.ColumnChanging, AddressOf cambiando_valor
        cadena = "SELECT NOMBRE, tiposeguro, por FROM SEGUROSOCIAL where empresa=" & empresa & " order by tiposeguro"
        llena_combo(cadena, cmbTipoSeguro)
        cmbTipoSeguro.Items.Add("")
        llenaTabla(cadena, tbSeguro)
        cadena = "select nombre,puesto from puestosper where empresa=" & empresa & " order by puesto"
        llena_combo(cadena, cmbPuesto)
        cmbPuesto.Items.Add("")
        llenaTabla(cadena, tbPuesto)
        cadena = "select nombre,fpago,tipoforma from formapagoper where empresa=" & empresa & " order by fpago"
        llena_combo(cadena, cmbFormaPago)
        cmbFormaPago.Items.Add("")
        llenaTabla(cadena, tbFormaPago)
        cadena = "select t.nombre, t.tipoper, t.tibase, case when t.tibase='H' then 'HORAS' when t.tibase='D' then 'DIAS' end as nombBase," &
                 " b.base, horasdia  from tipopersonal t inner join tiposbase b on t.empresa=b.empresa and t.id_tbase=b.id_tbase where " &
                 "t.empresa=" & empresa & " order by t.tipoper"
        llena_combo(cadena, cmbTipoPer)
        cmbTipoPer.Items.Add("")
        llenaTablaBatch(cadena, tbTipoPer)
        cadena = "select nombre,motivo from motivoeventos"
        llena_combo(cadena, cmbMotivoEvento)
        llenaTabla(cadena, tbMotivoEvento)
        cadena = "select nombre,tipoevento from tiposeventos"
        llena_combo(cadena, cmbTipoEvento)
        llenaTabla(cadena, tbTipoEvento)
        cadena = "select nombre,tipoaccion from tipoacciones"
        llena_combo(cadena, cmbTipoAccion)
        llenaTabla(cadena, tbTipoAccion)
        cadena = "select coalesce(max (acceso),0) from permisos2 where opcion_forma='modificacion_total' and nombre_forma='" &
        Me.Name.Trim & "' and id_role=" & IdRol
        opc_modificacion_total = BuscaEscalar(cadena)
        cadena = "select * from tiposempleado t where " &
          "t.empresa=" & empresa & " order by tipoempleado"
        llenaTablaBatch(cadena, tbTipoEmpleado)
        filaTemp = tbTipoEmpleado.NewRow
        filaTemp.Item("empresa") = empresa
        filaTemp.Item("tipoempleado") = 0
        filaTemp.Item("nombre") = ""
        tbTipoEmpleado.Rows.Add(filaTemp)
        cmbTipoEmpleado.DataSource = tbTipoEmpleado
        cmbTipoEmpleado.DisplayMember = "nombre"
        cmbTipoEmpleado.ValueMember = "tipoempleado"
        ctrContrato.FillComboJornada(cmbJornada)
        ctrContrato.FillComboTipoContrato(cmbTipoContrato)
        ctrContrato.FillComboTemporalidad(cmbTemporalidad)

        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim finConsulta, cadenaConsulta As String
        finConsulta = " and 1=1"
        Dim num_empleado As Int32 = 0
        Dim num_contrato As Int32 = 0
        Dim fechaTemp

        If Int32.TryParse(textConxEmpleado.Text, num_empleado) Then
            finConsulta = finConsulta & $" and c1.empleado={num_empleado}"
        End If
        If Int32.TryParse(TextConxContrato.Text, num_contrato) Then
            finConsulta = finConsulta & $" and c1.contrato={num_contrato}"
        End If


        GeneraConsulta(TbGeneral, finConsulta, "c1")

        If cmbTipoSeguro.Text.Trim <> "" Then
            lPara("tiposeguro") = tbSeguro.Rows(cmbTipoSeguro.SelectedIndex).Item(1)
            finConsulta = finConsulta & " and c1.tiposeguro=@tiposeguro "
        End If
        If cmbTipoPer.Text.Trim <> "" Then
            lPara("tipoper") = tbTipoPer.Rows(cmbTipoPer.SelectedIndex).Item(1)
            finConsulta = finConsulta & " and c1.tipoper=@tipoper "
        End If
        If cmbPuesto.Text.Trim <> "" Then
            lPara("puesto") = tbPuesto.Rows(cmbPuesto.SelectedIndex).Item(1)
            finConsulta = finConsulta & " and c1.puesto=@puesto "
        End If
        If cmbModPago.Text.Trim <> "" Then
            lPara("mpago") = cmbModPago.Text.Substring(0, 1)
            finConsulta = finConsulta & " and c1.mpago=@mpago"
        End If
        If cmbFormaPago.Text.Trim <> "" Then
            lPara("fpago") = tbFormaPago.Rows(cmbFormaPago.SelectedIndex).Item(1)
            finConsulta = finConsulta & " and c1.fpago=@fpago "
        End If
        If cmbJornada.Text.Trim <> "" Then
            lPara("jornada") = cmbJornada.Text.Substring(0, 1)
            finConsulta = finConsulta & " and c1.jornada=@jornada "
        End If
        If cmbEstado.Text.Trim <> "" Then
            lPara("estado") = tbEstado.Rows(cmbEstado.SelectedIndex).Item(1)
            finConsulta = finConsulta & " and c1.estado=@estado "
        End If
        '***Fecha Inicio***
        If TextAvisoFechaI.Visible = True Then
            finConsulta = finConsulta & consultaFechaI
        Else
            If TextFechaInicio.Text <> "  /  /" Then
                If VerificacionFecha(TextFechaInicio) = True Then
                    fechaTemp = TextFechaInicio.Text
                    finConsulta = finConsulta & " and c1.fechai='" & fechaTemp & "'"
                Else
                    MsgBox("FORMATO DE FECHA INVALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
            End If
        End If

        '***Fecha final***
        If TextAvisoFechaF.Visible = True Then
            finConsulta = finConsulta & consultaFechaF
        Else
            If textFechaF.Text <> "  /  /" Then
                If VerificacionFecha(textFechaF) = True Then
                    fechaTemp = textFechaF.Text
                    finConsulta = finConsulta & " and c1.fechaf='" & fechaTemp & "'"
                Else
                    MsgBox("FORMATO DE FECHA INVALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
            End If
        End If

        '***Fecha***
        If TextAvisoFecha.Visible = True Then
            finConsulta = finConsulta & consultaFecha
        Else
            If textFecha.Text <> "  /  /" Then
                If VerificacionFecha(textFecha) = True Then
                    fechaTemp = textFecha.Text
                    finConsulta = finConsulta & " and c1.fecha='" & fechaTemp & "'"
                Else
                    MsgBox("FORMATO DE FECHA INVALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
            End If
        End If

        '***Fecha estado***
        If TextAvisoFecha2.Visible = True Then
            finConsulta = finConsulta & consultaFecha2
        Else
            If textFechae.Text <> "  /  /" Then
                If VerificacionFecha(textFechae) = True Then
                    fechaTemp = textFechae.Text
                    finConsulta = finConsulta & " and c1.fechae='" & fechaTemp & "'"
                Else
                    MsgBox("FORMATO DE FECHA INVALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
            End If
        End If

        cadenaConsulta = inicioConsulta & finConsulta & " order by empleado, contrato asc"
        Mostrar(cadenaConsulta, sender, e)
    End Sub


    Private Sub Mostrar(ByVal subCadena As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        ConsultaReadOnly(TbGeneral, True)
        btnEmpleado.Enabled = False
        If opc_modificacion_total = 0 Then
            btnImprimir.Enabled = False
        Else
            btnImprimir.Enabled = True
        End If
        scJefe.Panel1.Enabled = True
        scJefe.Panel2.Enabled = True
        SoloLeer(TbGeneral, True)
        EnabilizarFechas(False)
        FechaSoloLectura(True, True)
        btnBuscar.Enabled = False
        textNombCodigo.ReadOnly = True
        ContextoMenuEnab(True, True, ctxPrincipal)
        indice = 0
        If llenaTabla(subCadena, tbConsulta, ListaParametros(lPara)) > 0 Then
            LlenarTextBox(0, tbConsulta)
        Else
            MsgBox("NO HAY REGISTROS CON ESTOS CRITERIOS DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
        End If
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub

    Private Sub LlenarTextBox(ByVal indi As Int16, ByVal tabla As DataTable)
        Dim filaCopiar As DataRow
        filaCopiar = tabla.Rows.Item(indi)
        textConxEmpleado.Text = filaCopiar.Item(0)
        ValidaEmpleado()
        TextConxContrato.Text = filaCopiar.Item(1)
        BuscaElementoCombo(tbSeguro, filaCopiar.Item(3), cmbTipoSeguro, 1, True)
        TextTipoSeguro.Text = cmbTipoSeguro.Text
        BuscaElementoCombo(tbTipoPer, filaCopiar.Item(4), cmbTipoPer, 1, True)
        TextTipoPer.Text = cmbTipoPer.Text
        BuscaElementoCombo(tbPuesto, filaCopiar.Item(5), cmbPuesto, 1, True)
        TextPuesto.Text = cmbPuesto.Text

        textFecha.Text = filaCopiar.Item(2)
        TextAvisoFecha.Text = textFecha.Text

        textFechae.Text = filaCopiar.Item(18)
        TextAvisoFecha2.Text = textFechae.Text

        Select Case filaCopiar.Item(6)
            Case "M"
                cmbModPago.SelectedIndex = 0
            Case "Q"
                cmbModPago.SelectedIndex = 1
        End Select
        TextModPago.Text = cmbModPago.Text
        cmbAnticipo.SelectedIndex = cmbAnticipo.FindStringExact(filaCopiar.Item(20))
        TextAnticipo.Text = cmbAnticipo.Text
        BuscaElementoCombo(tbFormaPago, filaCopiar.Item(7), cmbFormaPago, 1, True)
        TextFormaPago.Text = cmbFormaPago.Text
        textConlcuentaban.Text = filaCopiar.Item(8)


        TextFechaInicio.Text = filaCopiar.Item(9)
        TextAvisoFechaI.Text = TextFechaInicio.Text



        If filaCopiar.Item(10) <> CDate("01/01/1900") Then
            textFechaF.Text = filaCopiar.Item(10)
        Else
            textFechaF.Text = ""
        End If
        TextAvisoFechaF.Text = textFechaF.Text
        base = filaCopiar.Item(11)

        Select Case filaCopiar.Item(12)
            Case 1 'D
                cmbJornada.SelectedIndex = 0
            Case 2 'M
                cmbJornada.SelectedIndex = 1
            Case 3 'N
                cmbJornada.SelectedIndex = 2
        End Select

        TextHora1.Text = filaCopiar.Item(13)
        TextHora2.Text = filaCopiar.Item(14)
        TextHorasTotal.Text = filaCopiar.Item(15)
        TextConlObserva.Text = filaCopiar.Item(16)
        estadoPrincipal = filaCopiar.Item(17)
        BuscaElementoCombo(tbEstado, filaCopiar.Item(17), cmbEstado, 1, True)
        TextEstado.Text = cmbEstado.Text
        Textsemanales.Text = filaCopiar.Item(21)
        cmbTipoContrato.SelectedValue = filaCopiar("id_tipo_contrato")
        cmbTemporalidad.SelectedValue = filaCopiar("id_temporalidad")
        Select Case filaCopiar.Item(19)
            Case "S"
                ctxModificar.Enabled = True
                ctxBaja.Enabled = True
                ctxReactivarContrato.Enabled = False
            Case "N"
                ctxModificar.Enabled = False
                ctxBaja.Enabled = False
                ctxReactivarContrato.Enabled = True
        End Select
        If filaCopiar.Item("tipoempleado") <> 0 Then
            cmbTipoEmpleado.SelectedValue = filaCopiar.Item("tipoempleado")
        Else
            cmbTipoEmpleado.SelectedIndex = -1
        End If
        If tabPages.TabPages.IndexOf(tbOrigenes) >= 0 Then
            cadena = ConsultaDetalle & " and empleado=" & textConxEmpleado.Text & " and contrato=" & TextConxContrato.Text & " order by c2.origen"
            tbDatos.Rows.Clear()
            abrir_conexion(cn)
            da = New SqlDataAdapter(cadena, cn)
            da.Fill(tbDatos)
            Vista1(dgDatos)
            totales()
        End If
        If tabPages.TabPages.IndexOf(tbSueldo) >= 0 Then
            cadena = cadenaSueldos & " and empleado=" & textConxEmpleado.Text & " and contrato=" & TextConxContrato.Text & " order by t.transac"
            llenaTabla(cadena, tbDetSueldos)
            llenaTabla(cadena, tbSueldoOrig)
            AgregarColumna(tbDetSueldos, "tipo", "System.String", "")
            AgregarColumna(tbDetSueldos, "nombtipo", "System.String", "")
            AgregarColumna(tbDetSueldos, "concepto", "System.String", "")
            dgSueldos.DataSource = tbDetSueldos
            Vista2(dgSueldos)
        End If
        If tabPages.TabPages.IndexOf(TabJefes) >= 0 Then
            cadena = "select a.jefe,d.apellido1+' '+d.apellido2+' '+d.nombre1+' '+d.nombre2 as nombre,b.contrato from contratosjefes a" &
          " inner join contratos1 b on a.jefe=b.empleado and a.jefecontrato=b.contrato and a.empresa=b.empresa " &
          " inner join puestosper c on b.puesto=c.puesto and c.empresa=b.empresa " &
          " inner join emplegen d on a.jefe=d.empleado and d.empresa=c.empresa " &
          " where a.empresa=" & empresa & " and  a.empleado =" & textConxEmpleado.Text & " and a.contrato=" & TextConxContrato.Text & " and " &
          " b.estado in (0,4) ORDER BY a.empleado ASC "
            llenaTabla(cadena, tbDetJefes)
            dgvJefe.DataSource = tbDetJefes
            VistaJ(dgvJefe, tbDetJefes)
            ContextoMenuEnab(True, True, ctxMenuJefe)
        End If


        cadena = cadenaEventos & " and empleado=" & textConxEmpleado.Text & " and contrato=" & TextConxContrato.Text &
        " order by id_eventosper"
        llenaTabla(cadena, tbEventos)
        'tbEventos.Columns("tipoevento").ColumnMapping = MappingType.Hidden
        'tbEventos.Columns("motivo").ColumnMapping = MappingType.Hidden
        'tbEventos.Columns("tipoaccion").ColumnMapping = MappingType.Hidden
        dgEventos.DataSource = tbEventos
        Vista3(dgEventos)
        TextTotalSueldo.Text = formato(TotalTabla(tbDetSueldos, 3))
    End Sub



#Region "Fechas"
    Private Sub btnBusCFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFecha.Click
        f = New frmConsultaFechas
        f.TopMost = True
        AddHandler f.actValor, AddressOf ActualizacionDatosFecha
        f.inicializador("c1", "fecha")
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub
    Private Sub btnFechaIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFechaI.Click
        f = New frmConsultaFechas
        f.TopMost = True
        AddHandler f.actValor, AddressOf ActualizacionDatosFechaIni
        f.inicializador("c1", "fechai")
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub
    Private Sub btnFechaFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFechaF.Click
        f = New frmConsultaFechas
        f.TopMost = True
        AddHandler f.actValor, AddressOf ActualizacionDatosFechaFin
        f.inicializador("c1", "fechaf")
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub
    Private Sub ActualizacionDatosFecha(ByVal sender As Object, ByVal e As clsActValorREvento)
        consultaFecha = e.va1
        TextAvisoFecha.Visible = True
        textFecha.Visible = False
        TextAvisoFecha.Text = AvisoFecha(e.va2)
    End Sub

    Private Sub btnFechaE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFecha2.Click
        f = New frmConsultaFechas
        f.TopMost = True
        AddHandler f.actValor, AddressOf ActualizacionDatosFechaE
        f.inicializador("c1", "fechae")
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosFechaE(ByVal sender As Object, ByVal e As clsActValorREvento)
        consultaFecha2 = e.va1
        TextAvisoFecha2.Visible = True
        textFechae.Visible = False
        TextAvisoFecha2.Text = AvisoFecha(e.va2)
    End Sub

    'Private Sub btnFechaIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    f = New frmConsultaFechas
    '    f.TopMost = True
    '    AddHandler f.actValor, AddressOf ActualizacionDatosFechaIni
    '    f.inicializador("c1", "fechai")
    '    f.StartPosition = FormStartPosition.CenterScreen
    '    f.ShowDialog()
    'End Sub

    Private Sub ActualizacionDatosFechaIni(ByVal sender As Object, ByVal e As clsActValorREvento)
        consultaFechaI = e.va1
        TextAvisoFechaI.Visible = True
        TextFechaInicio.Visible = False
        TextAvisoFechaI.Text = AvisoFecha(e.va2)
    End Sub

    'Private Sub btnFechaFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    f = New frmConsultaFechas
    '    f.TopMost = True
    '    AddHandler f.actValor, AddressOf ActualizacionDatosFechaFin
    '    f.inicializador("c1", "fechaf")
    '    f.StartPosition = FormStartPosition.CenterScreen
    '    f.ShowDialog()
    'End Sub

    Private Sub ActualizacionDatosFechaFin(ByVal sender As Object, ByVal e As clsActValorREvento)
        consultaFechaF = e.va1
        TextAvisoFechaF.Visible = True
        textFechaF.Visible = False
        TextAvisoFechaF.Text = AvisoFecha(e.va2)
    End Sub


#End Region

#Region "ORIGEN"
    Private Sub BorraOrigen(ByVal valorBool As Boolean)
        TextNombOrigen.Clear()
        If valorBool = True Then
            TextOrigen.Clear()
        End If
    End Sub

    Private Sub TextCentro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextOrigen.KeyDown, TextNombOrigen.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrigen.Click
        lPara.Clear()
        Dim numFilas As Int32
        lPara("empresa") = empresa
        If TextNombOrigen.Text.Trim <> "" Then
            lPara("nombre") = TextNombOrigen.Text.Trim
            cadena = "select origen, nombre from origenes where empresa=@empresa and nombre like '%' + @nombre + '%' and operable='S' order by origen"
        Else
            cadena = "select origen,nombre from origenes where empresa=@empresa and  operable='S' order by origen"
        End If
        numFilas = llenaTabla(cadena, tbOrigen, ListaParametros(lPara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN CENTROS DE COSTO CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraOrigen(True)
            TextOrigen.Focus()
        ElseIf numFilas = 1 Then
            filaTemp = tbOrigen.Rows.Item(0)
            TextOrigen.Text() = filaTemp.Item(0)
            TextNombOrigen.Text = filaTemp.Item(1)
            TextPorce.Focus()
        Else
            'borra_Mejorado(gpCentro)
            EnBuscaOrigen()
        End If
    End Sub

    Private Sub ValidaOrigen()
        lPara.Clear()
        lPara("empresa") = empresa
        lPara("origen") = TextOrigen.Text.Trim
        If BuscaEscalar("select count (*) from origenes where empresa=@empresa and  origen=@origen", ListaParametros(lPara)) = 0 Then
            MsgBox("CENTRO DE COSTO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraOrigen(True)
            Exit Sub
        End If
        cadena = "select origen,nombre from origenes where empresa=@empresa and  origen=@origen and operable='S'"
        abrir_conexion(cn)
        comando = New SqlCommand(cadena, cn)
        comando.Parameters.AddRange(ListaParametros(lPara).ToArray())
        dr = comando.ExecuteReader
        If dr.HasRows() Then
            BorraOrigen(False)
            dr.Read()
            TextNombOrigen.Text = dr.GetValue(1)
            dr.Close()
            TextPorce.Focus()
        Else
            MsgBox("CENTRO DE COSTO NO ES OPERABLE A ESTE NIVEL, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            dr.Close()
            BorraOrigen(True)
            TextOrigen.Focus()
        End If
        cn.Close()
    End Sub

    Private Sub TextOrigen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextOrigen.Validated
        If TextOrigen.Text.Trim <> "" Then
            ValidaOrigen()
        Else
            BorraOrigen(False)
        End If
    End Sub

    Private Sub EnBuscaOrigen()
        fOrig = New frmMuestraUnidadesOp
        fOrig.TopMost = True
        fOrig.inicializa(tbOrigen)
        AddHandler fOrig.actValor, AddressOf ActualizacionDatosOrigen
        fOrig.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosOrigen(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraOrigen(True)
        filaTemp = tbOrigen.Rows.Item(e.va2)
        TextOrigen.Text() = filaTemp.Item(0)
        TextNombOrigen.Text = filaTemp.Item(1)
        TextNombOrigen.Focus()
        TextPorce.Focus()
    End Sub

#End Region

#Region "EMLEADO"

    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        TextConxContrato.Clear()
        If valbool = True Then
            textConxEmpleado.Clear()
        End If
    End Sub

    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        lPara.Clear()
        lPara("empresa") = empresa
        lPara("nombre") = textNombreEmple.Text.Trim
        Dim numFilas As Integer
        cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and nombre like '%' + @nombre + '%'  order by nombre"
        tbEmpleado = New DataTable("empleado")
        numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lPara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            textConxEmpleado.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            textConxEmpleado.Text() = filaTemp.Item(0)
            textNombreEmple.Text = filaTemp.Item(1)
            cmbTipoSeguro.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        lPara.Clear()
        If valida_tipo_Entero(textConxEmpleado.Text, 2) = True Then
            lPara("empresa") = empresa
            lPara("empleado") = textConxEmpleado.Text.Trim
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=@empresa and empleado=@empleado", ListaParametros(lPara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textConxEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and empleado=@empleado"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lPara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEmpleado(False)
                dr.Read()
                textNombreEmple.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                cmbTipoSeguro.Focus()
            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraEmpleado(True)
            textConxEmpleado.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textConxEmpleado.Validated
        If textConxEmpleado.Text.Trim <> "" Then
            ValidaEmpleado()
        Else
            BorraEmpleado(False)
        End If
    End Sub

    Private Sub EnBuscaEmpleado()
        fEmp = New frmMuestra2Columnas
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado, "CODIGO", "NOMBRE", 0)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosEmpleados
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        cmbTipoSeguro.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textConxEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
    End Sub

#End Region

#Region "LIMPIEZA"
    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        If opc_modificacion_total = 0 Then
            tabPages.TabPages.Remove(tbSueldo)
            tabPages.TabPages.Remove(tbOrigenes)
        End If
        TextConxContrato.Clear()
        HoraFinal = 0
        minutoFinal = 0
        btnCancelar_Click(sender, e)
        btnCancelSueldo_Click(sender, e)
        btnCancelEvento_Click(sender, e)
        borra_Mejorado(TbGeneral, ep1)
        borra_Mejorado(pnSueldos, ep1)
        borra_Mejorado(pnHead, ep1)
        FechaSoloLectura(False, True)
        EnabilizarDetalle(False)
        EnabilizarFechas(True)
        ContextoMenuEnab(True, False, ctxPrincipal)
        ContextoMenuEnab(True, False, ctxMenuOrigen)
        ContextoMenuEnab(True, False, ctxMenuSueldos)
        ContextoMenuEnab(True, False, ctxMenuEvento)
        ContextoMenuEnab(True, False, ctxMenuJefe)
        ConsultaReadOnly(TbGeneral, False)
        TextTotal.Text = "0.00"
        TextTotalSueldo.Text = "0.00"
        consultaFecha = ""
        consultaFecha2 = ""
        consultaFechaI = ""
        consultaFechaF = ""
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnImprimir.Enabled = False
        btnBuscar.Enabled = True
        ConsultaReadOnly(pnHead, False)

        btnGuardar.Enabled = False
        btnEmpleado.Enabled = True
        TextHorasTotal.ReadOnly = True
        scJefe.Panel1.Enabled = False
        scJefe.Panel2.Enabled = False
        BorraJefe(True)
        tbDatos.Rows.Clear()
        tbDetSueldos.Rows.Clear()
        tbEventos.Rows.Clear()
        dgDatos.Refresh()
        dgvJefe.DataSource = Nothing
        cmbTipoEmpleado.SelectedValue = 0
        cadena = "select nombre, estado from empestados where empresa=" & empresa & " order by estado"
        llenaTabla(cadena, tbEstado)
        cmbEstado.DisplayMember = "nombre"
        cmbEstado.ValueMember = "estado"
        cmbEstado.DataSource = tbEstado
        'llena_combo(cadena, cmbEstado)
        'cmbEstado.Items.Add("")
        cmbEstado.SelectedIndex = -1


    End Sub

    Private Sub EnabilizarDetalle(ByVal valB As Boolean)
        gpCentro.Enabled = valB
        btnIngresar.Enabled = valB
        btnCancelar.Enabled = valB
        TextPorce.Enabled = valB
        pnSueldos.Enabled = valB
        pnEventos.Enabled = valB

        'fecha inicio
        btnFechaI.Enabled = valB
        TextAvisoFechaI.Visible = Not valB
        TextFechaInicio.Visible = valB

        'fecha fin
        btnFechaF.Enabled = valB
        TextAvisoFechaF.Visible = Not valB
        textFechaF.Visible = valB

        'fecha
        btnFecha.Enabled = valB
        TextAvisoFecha.Visible = Not valB
        textFecha.Visible = valB
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        BorraOrigen(True)
        TextPorce.Clear()
        TextOrigen.Focus()
    End Sub

    Private Sub EnabilizarFechas(ByVal valB As Boolean)
        btnFecha.Enabled = valB
        btnFecha2.Enabled = valB
        btnFechaI.Enabled = valB
        btnFechaF.Enabled = valB
        TextAvisoFecha.Visible = Not valB
        TextAvisoFecha2.Visible = Not valB
        TextAvisoFechaI.Visible = Not valB
        TextAvisoFechaF.Visible = Not valB
        textFecha.Visible = valB
        textFechae.Visible = valB
        TextFechaInicio.Visible = valB
        textFechaF.Visible = valB
    End Sub

    Private Sub FechaSoloLectura(ByVal valB As Boolean, ByVal HoraVal As Boolean)

        TextHora1.ReadOnly = HoraVal
        TextHora2.ReadOnly = HoraVal
        TextHorasTotal.ReadOnly = HoraVal

        TextFechaInicio.ReadOnly = valB
        textFechaF.ReadOnly = valB
        textFecha.ReadOnly = valB
        textFechae.ReadOnly = valB
    End Sub

    Private Sub Vista1(ByVal dgVista As DataGridView)
        With dgVista
            .Columns("origen").HeaderText = "Origen"
            .Columns("origen").FillWeight = 15
            .Columns("origen").ReadOnly = True
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").FillWeight = 70
            .Columns("nombre").ReadOnly = True
            .Columns("porcentaje").HeaderText = "Porcentaje"
            .Columns("porcentaje").FillWeight = 15
            .Columns("porcentaje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub Vista2(ByVal dgVista As DataGridView)
        With dgVista
            .Columns("transac").HeaderText = "Transacción"
            .Columns("transac").FillWeight = 8
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").FillWeight = 34
            .Columns("afecta").HeaderText = "Afecto"
            .Columns("afecta").FillWeight = 8
            .Columns("valor").HeaderText = "Valor"
            .Columns("valor").FillWeight = 10
            .Columns("valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("valor").DefaultCellStyle.Format = "N2"
            .Columns("tipo").Visible = False
            .Columns("nombtipo").FillWeight = 10
            .Columns("nombtipo").HeaderText = "Tipo"
            .Columns("concepto").FillWeight = 20
            .Columns("concepto").HeaderText = "Concepto"
            'AltoGridView(18, tbDatos, 200, 848, dgVista)
        End With
    End Sub

    Private Sub Vista3(ByVal dgVista As DataGridView)
        With dgVista
            .Columns("fecha").HeaderText = "Fecha"
            .Columns("fecha").FillWeight = 10
            .Columns("tipoevento").Visible = False
            .Columns("nombEvento").HeaderText = "Tipo"
            .Columns("nombEvento").FillWeight = 15
            .Columns("motivo").Visible = False
            .Columns("nombMotivo").HeaderText = "Motivo"
            .Columns("nombMotivo").FillWeight = 15
            .Columns("tipoAccion").Visible = False
            .Columns("nombAccion").HeaderText = "Acción"
            .Columns("nombAccion").FillWeight = 30
            .Columns("observa").HeaderText = "Observaciones"
            .Columns("observa").FillWeight = 30
        End With
    End Sub

    Private Sub VistaJ(ByVal dgVista As DataGridView, ByVal tabla As DataTable)
        With dgVista
            .Columns(0).HeaderText = "Código"
            .Columns(0).FillWeight = 15
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).FillWeight = 70
            .Columns(2).HeaderText = "CTTO"
            .Columns(2).FillWeight = 15

            'AltoGridView(18, tabla, 292, 457, dgVista)
        End With
    End Sub

#End Region

#Region "INGRESO DEL CENTRO DE COSTO"

    Private Sub btnIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Dim i As Int16
        Dim fila As DataRow
        If TextOrigen.Text.Trim = "" Then
            MsgBox("NO HA INGRESADO EL CENTRO DE COSTO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            TextOrigen.Focus()
            Exit Sub
        ElseIf TextPorce.Text.Trim = "" Then
            MsgBox("NO HA INGRESADO EL PORCENTAJE DEL CENTRO DE COSTO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            TextPorce.Focus()
            Exit Sub
        End If
        If CDec(TextTotal.Text) > 100 Then
            MsgBox("EL TOTAL DEL PORCETANJE EXCEDE EL 100%", MsgBoxStyle.Information, "Mensaje del Sistema")
            TextPorce.Focus()
            Exit Sub
        End If
        If tbDatos.Rows.Count > 0 Then
            For i = 0 To tbDatos.Rows.Count - 1
                filaTemp = tbDatos.Rows.Item(i)
                If CStr(filaTemp.Item(0)).Trim = TextOrigen.Text.Trim Then
                    MsgBox("ESTE CENTRO DE COSTO YA HA SIDO INGRESADO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
            Next i
        End If
        If 0.0 < CDec(TextPorce.Text) And CDec(TextPorce.Text) <= 100.0 Then
            fila = tbDatos.NewRow()
            fila.Item(0) = TextOrigen.Text.Trim
            fila.Item(1) = BuscaEscalar("select nombre from origenes where empresa=" & empresa & " and  origen='" & TextOrigen.Text & "'")
            fila.Item(2) = CInt(TextPorce.Text)
            tbDatos.Rows.Add(fila)
            totales()
            'AltoGridView(18, tbDatos, 266, 618, dgDatos)
            MueveScrollView(dgDatos, tbDatos.Rows.Count - 1)
            btnCancelar_Click(sender, e)
        Else
            MsgBox("EL PORCENTAJE INGRESADO NO PUEDE SER 0 O MAYOR DE 100", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub totales()
        Dim totalizador As Decimal
        Dim i As Int16
        totalizador = 0
        For i = 0 To tbDatos.Rows.Count - 1
            filaTemp = tbDatos.Rows.Item(i)
            totalizador = totalizador + filaTemp.Item(2)
        Next i
        TextTotal.Text = totalizador
        If totalizador = 100 Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
        End If
    End Sub

    Private Sub ctxEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminaCentro.Click
        If dgDatos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                tbDatos.Rows.Remove(filaTemp)
                totales()
                dgDatos.Refresh()
                'AltoGridView(18, tbDatos, 266, 618, dgDatos)
            End If
        Else
            MsgBox("NO HAY NINGUNA LINEA PARA ELIMINAR", MsgBoxStyle.Information, "Mensaje del Sistemas")
        End If
    End Sub

    Private Sub cambiando_valor(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        Dim tempDec As Decimal
        If (e.Column.ColumnName = "porcentaje") Then
            Try
                tempDec = e.ProposedValue
                If 0.0 < tempDec And tempDec <= 100.0 Then
                    e.ProposedValue = CDec(formato(tempDec))
                Else
                    e.ProposedValue = e.Row.Item(2)
                End If
            Catch ex As Exception
                MsgBox("LO INGRESADO NO ES UN NUMERO VALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
                e.ProposedValue = e.Row.Item(2)
            End Try
        End If
    End Sub

    Private Sub cambio_valor(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        If (e.Column.ColumnName = "porcentaje") Then
            totales()
        End If
    End Sub

#End Region

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim i, Numcorrel As Int32
        Dim fecha, fechad, fechaIng As Date
        Dim horasF, estado As Decimal
        Dim tipoSeguro, tipoOper, puesto, fpago, jornada As String
        tipoSeguro = ""
        tipoOper = ""
        puesto = ""
        fpago = ""
        jornada = ""
        Numcorrel = 0
        lPara.Clear()

        'fecha = axFechaC.Datevalue1.Date
        'fechaIng = axFechaInicio.Datevalue1.Date

        If VerificacionFecha(textFecha) = False Or VerificacionFecha(TextFechaInicio) = False Then
            MsgBox("FECHA O FECHA DE INICIO POSEEN FORMATO NO VALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        Else
            fecha = textFecha.Text
            fechaIng = TextFechaInicio.Text
        End If


        If TextHora1.Text = "  :" Or TextHora2.Text = "  :" Or TextHorasTotal.Text = "  :" Then
            MsgBox("DEBE INGRESAR TODAS LAS HORAS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        If Textsemanales.Text.Trim = "0" Or Textsemanales.Text.Trim = "" Then
            MsgBox("DEBE INGRESAR LAS HORAS SEMANALES", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        If validetError(textConxEmpleado, ep1) And validetError(cmbTipoSeguro, ep1) And validetError(cmbTipoPer, ep1) And
            validetError(cmbPuesto, ep1) And validetError(cmbModPago, ep1) And validetError(cmbFormaPago, ep1) And
            validetComilla(TextConlObserva, ep1) And validetError(cmbJornada, ep1) And
            validetError(cmbAnticipo, ep1) And validetError(TextHorasTotal, ep1) And validetError(cmbTipoEmpleado, ep1) And
            validetError(cmbTipoContrato, ep1) And validetError(cmbTemporalidad, ep1) Then

            If textConlcuentaban.ReadOnly = False And textConlcuentaban.Text.Trim = "" Then
                MsgBox("DEBE INGRESAR CUENTA BANCARIA", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If

            AsignaElemento(tbSeguro, tipoSeguro, cmbTipoSeguro, 1, True)
            AsignaElemento(tbTipoPer, tipoOper, cmbTipoPer, 1, True)
            AsignaElemento(tbPuesto, puesto, cmbPuesto, 1, True)
            AsignaElemento(tbFormaPago, fpago, cmbFormaPago, 1, False)
            AsignaElemento(tbEstado, estado, cmbEstado, 1, True)
            horasF = CDec(TextHorasTotal.Text)

            Dim modelo As New cmodelo
            Try


                If MsgBox("ESTA SEGURO QUE DESEA ACTUALIZAR ESTE CONTRATO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                    fechad = Today.ToShortDateString

                    lPara("@empresa") = empresa
                    lPara("@empleado") = CInt(textConxEmpleado.Text)
                    lPara("@contrato") = CInt(TextConxContrato.Text)
                    lPara("@fecha") = fechad
                    lPara("@tiposeguro") = tipoSeguro
                    lPara("@tipoper") = tipoOper
                    lPara("@puesto") = puesto
                    lPara("@mpago") = cmbModPago.Text.Substring(0, 1)
                    lPara("@anticipo") = cmbAnticipo.Text
                    lPara("@fpago") = fpago
                    lPara("@cuentaban") = textConlcuentaban.Text
                    lPara("@fechai") = fechaIng
                    lPara("@horas") = horasF
                    lPara("@base") = base
                    lPara("@jornada") = cmbJornada.SelectedValue
                    lPara("@horaini") = TextHora1.Text
                    lPara("@horafin") = TextHora2.Text
                    lPara("@semanahoras") = CInt(Textsemanales.Text)
                    lPara("@observa") = TextConlObserva.Text
                    lPara("@estado") = cmbEstado.SelectedValue
                    lPara("@fechae") = Today
                    lPara("@tipoempleado") = cmbTipoEmpleado.SelectedValue
                    lPara("@id_tipo_contrato") = cmbTipoContrato.SelectedValue
                    lPara("@id_temporalidad") = cmbTemporalidad.SelectedValue


                    cadena = "update  contratos1 set fecha=@fecha,tiposeguro=@tiposeguro,tipoper=@tipoper " &
                    ",puesto=@puesto,mpago=@mpago,anticipo=@anticipo" &
                    ",fpago =@fpago,cuentaban=@cuentaban,fechai =@fechai," &
                    "base=@base,jornada=@jornada,horaini=@horaini,horafin=@horafin" &
                    ",horas=@horas,semanahoras=@semanahoras,observa=@observa" &
                    ", estado=@estado,fechae=@fechae,tipoempleado=@tipoempleado, id_tipo_contrato= @id_tipo_contrato, id_temporalidad=@id_temporalidad " &
                    "where empresa=@empresa and empleado=@empleado and contrato=@contrato"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))
                    'InsertBitacora(9, 2, Me.Text)
                    lPara.Clear()
                    lPara("@empresa") = empresa
                    lPara("@empleado") = CInt(textConxEmpleado.Text)
                    lPara("@contrato") = CInt(TextConxContrato.Text)
                    If tabPages.TabPages.IndexOf(tbOrigenes) >= 0 Then
                        cadena = "delete from contratos2  where empresa=@empresa and empleado=@empleado and contrato=@contrato"

                        modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))
                        For i = 0 To tbDatos.Rows.Count - 1
                            filaTemp = tbDatos.Rows(i)
                            lPara("@origen") = filaTemp.Item("origen")
                            lPara("@por") = filaTemp.Item("porcentaje")
                            cadena = "insert into contratos2 (empresa, empleado, contrato, origen, por) values (@empresa,@empleado,@contrato,@origen,@por)"

                            modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))
                        Next i

                    End If

                    If tabPages.TabPages.IndexOf(tbSueldo) >= 0 Then
                        cadena = "delete from sueldos  where empresa=@empresa and empleado=@empleado and contrato=@contrato"

                        modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))
                        For i = 0 To tbDetSueldos.Rows.Count - 1
                            filaTemp = tbDetSueldos.Rows(i)

                            lPara("@transac") = filaTemp.Item("transac")
                            lPara("@valor") = filaTemp.Item("valor")
                            lPara("@afecta") = filaTemp.Item("afecta")
                            lPara("@fechae") = fecha
                            lPara("@concepto") = filaTemp.Item("concepto")
                            lPara("@tipo") = filaTemp.Item("tipo")
                            lPara("@usuario") = user
                            cadena = " insert into sueldos (empresa,empleado,contrato,transac,afecta, valor, fechae) values 
                                      (@empresa,@empleado,@contrato,@transac,@afecta, @valor, @fechae)"
                            modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))

                            If filaTemp.Item(4).ToString.Trim <> "" Then
                                lPara("@fecha") = Today
                                cadena = "insert into movifijos (empresa,fecha,empleado,contrato,tipo,transac,afecta, valor,concepto,usuario) values
                                    (@empresa,@fecha,@empleado,@contrato,@tipo,@transac,@afecta, @valor,@concepto,@usuario) "

                                modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))
                            End If
                        Next i

                    End If

                    If tabPages.TabPages.IndexOf(TabJefes) >= 0 Then
                        cadena = "delete contratosjefes where empresa=@empresa and empleado=@empleado and contrato=@contrato"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))

                        For Each filaJ As DataRow In tbDetJefes.Rows
                            lPara("@jefe") = filaJ.Item("jefe")
                            lPara("@jefecontrato") = filaJ.Item("contrato")
                            cadena = "insert into contratosjefes(empresa,empleado,contrato,jefe,jefecontrato) values (@empresa,@empleado,@contrato,@jefe,@jefecontrato)"

                            modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))
                        Next
                    End If

                    cadena = "delete from eventosper where empresa=@empresa and empleado=@empleado and contrato=@contrato"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))
                    For i = 0 To tbEventos.Rows.Count - 1
                        filaTemp = tbEventos.Rows(i)


                        lPara("@fecha") = filaTemp.Item("fecha")
                        lPara("@tipoevento") = filaTemp.Item("tipoevento")
                        lPara("@motivo") = filaTemp.Item("motivo")
                        lPara("@tipoaccion") = filaTemp.Item("tipoaccion")
                        lPara("@observa") = filaTemp.Item("observa")
                        cadena = " insert into eventosper (empresa, empleado, contrato, fecha, tipoevento, motivo, tipoaccion, observa)
                            values (@empresa,@empleado,@contrato,@fecha,@tipoevento,@motivo,@tipoaccion,@observa) "

                        modelo.EjecutarNonQuery(cadena, ListaParametros(lPara))
                    Next i


                    If modelo.Commit() Then
                        InsertBitacora(9, 1, "Actualización del contrato empleado " & textConxEmpleado.Text & " con contrato " & TextConxContrato.Text)
                        MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")

                    End If
                End If

            Catch ex As Exception
                modelo.RollBack()
                MsgBox("Error del sistema " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        Else
            MsgBox("LLENE LOS CAMPOS MARCADOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub



#Region "SUELDOS"


#Region "TRANSACCION"


    Private Sub BorraCodigo(ByVal valbool As Boolean)
        textNombCodigo.Clear()
        If valbool = True Then
            textCodigo.Clear()
        End If
    End Sub


    Private Sub btnCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaCodigo.Click
        lPara.Clear()
        Dim numFilas As Int32
        lPara("empresa") = empresa
        lPara("nombre") = textNombCodigo.Text.Trim
        cadena = "select transac, nombre from tipotran where empresa=@empresa and nombre like '%' + @nombre + '%' and tipomov='I' and formacal='FM'  order by transac"
        numFilas = llenaTabla(cadena, tbCodigo, ListaParametros(lPara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TRANSACCIONES CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCodigo(True)
            textCodigo.Focus()
        ElseIf numFilas = 1 Then
            BorraCodigo(True)
            filaTemp = tbCodigo.Rows.Item(0)
            textCodigo.Text() = filaTemp.Item(0)
            textNombCodigo.Text = filaTemp.Item(1)
            cmbAfecta.Focus()
        Else
            EnBuscaCodigo()
        End If
    End Sub

    Private Sub ValidaCodigo()
        lPara.Clear()
        If valida_tipo_Entero(textCodigo.Text, 1) = True Then
            lPara("empresa") = empresa
            lPara("transac") = textCodigo.Text.Trim
            If BuscaEscalar("select count (*) from tipotran where empresa=@empresa and transac=@transac", ListaParametros(lPara)) = 0 Then
                MsgBox("TRANSACCION NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraCodigo(True)
                textCodigo.Focus()
                Exit Sub
            End If
            cadena = "select transac, nombre from tipotran where empresa=@empresa and transac=@transac and tipomov='I' and formacal='FM'"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lPara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraCodigo(False)
                dr.Read()
                textNombCodigo.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                cmbAfecta.Focus()
            Else
                dr.Close()
                cn.Close()
                MsgBox("TRANSACCION NO VALIDA", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                BorraCodigo(True)
            End If
        Else
            MsgBox("TRANSACCION POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraCodigo(True)
            textCodigo.Focus()
        End If
    End Sub

    Private Sub TextCodigo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textCodigo.Validated
        If textCodigo.Text.Trim <> "" Then
            ValidaCodigo()
        Else
            BorraCodigo(False)
        End If
    End Sub

    Private Sub EnBuscaCodigo()
        fEmp = New frmMuestra2Columnas
        fEmp.TopMost = True
        fEmp.inicializa(tbCodigo, "TRANSACCION", "NOMBRE", 0)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosMonitor
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        cmbAfecta.Focus()
    End Sub

    Private Sub ActualizacionDatosMonitor(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCodigo(True)
        filaTemp = tbCodigo.Rows.Item(e.va2)
        textCodigo.Text() = filaTemp.Item(0)
        textNombCodigo.Text = filaTemp.Item(1)
    End Sub

#End Region

    Private Sub btnCancelSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelSueldo.Click
        opcSueldos = 0
        btnIngSueldo.Text = "Ingresar"
        BorraCodigo(True)
        cmbAfecta.Text = ""
        TextValor.Clear()
        cmbTipo.Text = ""
        TextConcepto.Clear()
        ContextoMenuEnab(True, True, ctxMenuSueldos)
        textCodigo.Focus()
    End Sub


    Private Sub btnIngSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngSueldo.Click
        Dim i As Int32
        If validetError(textCodigo, ep1) And validetError(cmbAfecta, ep1) And validetError(TextValor, ep1) And validetError(cmbTipo, ep1) Then

            If cmbTipo.SelectedIndex = 0 Then
                If Not validetComilla(TextConcepto, ep1) Then
                    Exit Sub
                End If
            Else
                If Not validetError(TextConcepto, ep1) Then
                    Exit Sub
                End If
            End If

            If CDec(TextValor.Text) = 0 Then
                MsgBox("DEBE INGRESAR UN VALOR MAYOR A 0", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If
            For i = 0 To tbDetSueldos.Rows.Count - 1
                filaTemp = tbDetSueldos.Rows(i)
                Select Case opcSueldos
                    Case 0
                        If CInt(textCodigo.Text) = filaTemp.Item(0) Then
                            MsgBox("CODIGO DE TRANSACCION YA INGRESADA", MsgBoxStyle.Information, "Mensaje del Sistema")
                            Exit Sub
                        End If
                    Case 1
                        If CInt(textCodigo.Text) = filaTemp.Item(0) And IndiceSueldo <> i Then
                            MsgBox("CODIGO DE TRANSACCION YA INGRESADA", MsgBoxStyle.Information, "Mensaje del Sistema")
                            Exit Sub
                        End If
                End Select
            Next i
            For i = 0 To tbSueldoOrig.Rows.Count - 1
                filaTemp = tbSueldoOrig.Rows(i)
                If CInt(textCodigo.Text) = filaTemp.Item(0) Then
                    Exit For
                End If
            Next i
            If i = tbSueldoOrig.Rows.Count And cmbTipo.SelectedIndex > 0 Then
                MsgBox("ESTA TRANSACCION NO TIENE VALOR INICIAL, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            ElseIf i < tbSueldoOrig.Rows.Count And cmbTipo.SelectedIndex = 0 Then
                MsgBox("ESTA TRANSACCION YA TIENE VALOR INICIAL, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If


            If opcSueldos = 0 Then
                filaTemp = tbDetSueldos.NewRow
                filaTemp.Item(0) = textCodigo.Text
                ValidaCodigo()
                filaTemp.Item(1) = textNombCodigo.Text
                filaTemp.Item(2) = cmbAfecta.Text
                filaTemp.Item(3) = formato(CDec(TextValor.Text))
                Select Case cmbTipo.SelectedIndex
                    Case 0
                        filaTemp.Item("tipo") = "I"
                    Case 1
                        filaTemp.Item("tipo") = "A"
                    Case 2
                        filaTemp.Item("tipo") = "R"
                End Select
                filaTemp.Item("nombtipo") = cmbTipo.Text
                filaTemp.Item("concepto") = TextConcepto.Text
                tbDetSueldos.Rows.Add(filaTemp)
            Else
                filaTemp = tbDetSueldos.Rows(IndiceSueldo)
                filaTemp.BeginEdit()
                filaTemp.Item(0) = textCodigo.Text
                ValidaCodigo()
                filaTemp.Item(1) = textNombCodigo.Text
                filaTemp.Item(2) = cmbAfecta.Text
                filaTemp.Item(3) = formato(CDec(TextValor.Text))
                Select Case cmbTipo.SelectedIndex
                    Case 0
                        filaTemp.Item("tipo") = "I"
                    Case 1
                        filaTemp.Item("tipo") = "A"
                    Case 2
                        filaTemp.Item("tipo") = "R"
                End Select
                filaTemp.Item("nombtipo") = cmbTipo.Text
                filaTemp.Item("concepto") = TextConcepto.Text
                filaTemp.EndEdit()
            End If

            TextTotalSueldo.Text = formato(TotalTabla(tbDetSueldos, 3))
            'AltoGridView(18, tbDatos, 200, 848, dgSueldos)
            MueveScrollView(dgSueldos, tbDetSueldos.Rows.Count - 1)
            btnCancelSueldo_Click(sender, e)
        Else
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub


    Private Sub ctxModiSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModiSueldo.Click
        Dim f As DataRow
        If dgSueldos.SelectedRows.Count > 0 Then
            opcSueldos = 1
            IndiceSueldo = dgSueldos.SelectedRows(0).Index
            ContextoMenuEnab(False, True, ctxMenuSueldos)
            btnIngSueldo.Text = "Modificar"
            f = CType(dgSueldos.SelectedRows(0).DataBoundItem, DataRowView).Row
            textCodigo.Text = f.Item(0)
            textNombCodigo.Text = f.Item(1)
            cmbAfecta.Text = f.Item(2).ToString.Trim
            TextValor.Text = f.Item(3)
            Select Case f.Item(4)
                Case "I"
                    cmbTipo.SelectedIndex = 0
                Case "A"
                    cmbTipo.SelectedIndex = 1
                Case "R"
                    cmbTipo.SelectedIndex = 2
                Case ""
                    cmbTipo.SelectedIndex = 3
            End Select
            TextConcepto.Text = f.Item(5)
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxEliSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliSueldo.Click
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgSueldos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgSueldos.SelectedRows(0).DataBoundItem, DataRowView).Row
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                tbDetSueldos.Rows.Remove(filaTemp)
                TextTotalSueldo.Text = formato(TotalTabla(tbDetSueldos, 3))
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub


#Region "Numero Decimal"
    Private Sub TextValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextValor.KeyPress
        soloNumeroDec(sender, e)
    End Sub

    Private Sub TextValor_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValor.Validated
        validatedDecimalPreci(sender, 8, 2)
    End Sub

    Private Sub TextValor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValor.Enter
        EntraDecimal(sender)
    End Sub

#End Region

#End Region

#Region "EVENTOS"
    Private Sub btnIngEvento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngEvento.Click
        Dim motivoEvento, tipoaccion As Integer
        Dim i As Integer = 0
        If validetError(cmbTipoEvento, ep1) And validetError(textFechaEvento, ep1) And validetError(cmbTipoAccion, ep1) And
           validetError(cmbMotivoEvento, ep1) Then
            If Not validetComilla(textObservaEvento, ep1) Then
                Exit Sub
            End If
            If cmbMotivoEvento.Text.Trim <> "" Then
                motivoEvento = tbMotivoEvento.Rows(cmbMotivoEvento.SelectedIndex).Item("Motivo")
            End If
            If cmbTipoAccion.Text.Trim <> "" Then
                tipoaccion = tbTipoAccion.Rows(cmbTipoAccion.SelectedIndex).Item("tipoaccion")
            End If

            If opcEvento = 0 Then
                filaTemp = tbEventos.NewRow
                filaTemp.Item("fecha") = textFechaEvento.Text
                filaTemp.Item("nombEvento") = cmbTipoEvento.Text
                filaTemp.Item("nombMotivo") = cmbMotivoEvento.Text
                filaTemp.Item("nombAccion") = cmbTipoAccion.Text
                filaTemp.Item("observa") = textObservaEvento.Text
                filaTemp.Item("tipoevento") = tbTipoEvento.Rows(cmbTipoEvento.SelectedIndex).Item("tipoevento")
                filaTemp.Item("motivo") = motivoEvento
                filaTemp.Item("tipoaccion") = tipoaccion
                tbEventos.Rows.Add(filaTemp)
            Else
                filaTemp = tbEventos.Rows(IndiceEvento)
                filaTemp.BeginEdit()
                filaTemp.Item("fecha") = textFechaEvento.Text
                filaTemp.Item("nombEvento") = cmbTipoEvento.Text
                filaTemp.Item("nombMotivo") = cmbMotivoEvento.Text
                filaTemp.Item("nombAccion") = cmbTipoAccion.Text
                filaTemp.Item("observa") = textObservaEvento.Text
                filaTemp.Item("tipoevento") = tbTipoEvento.Rows(cmbTipoEvento.SelectedIndex).Item("tipoevento")
                filaTemp.Item("motivo") = motivoEvento
                filaTemp.Item("tipoaccion") = tipoaccion
                filaTemp.EndEdit()
            End If
            dgEventos.Refresh()
            MueveScrollView(dgEventos, tbEventos.Rows.Count - 1)
            dgEventos.Refresh()
            btnCancelEvento_Click(sender, e)
            textFechaEvento.Focus()
        Else
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub


    Private Sub btnCancelEvento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelEvento.Click
        opcEvento = 0
        cmbTipoEvento.SelectedIndex = -1
        cmbMotivoEvento.SelectedIndex = -1
        cmbTipoAccion.SelectedIndex = -1
        textObservaEvento.Text = ""
        textFechaEvento.Text = ""
        ContextoMenuEnab(True, True, ctxMenuEvento)
        btnIngEvento.Text = "Ingresar"
    End Sub

    Private Sub ctxModiEvento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModiEvento.Click
        Dim f As DataRow
        If dgEventos.SelectedRows.Count > 0 Then
            opcEvento = 1
            IndiceEvento = dgEventos.SelectedRows(0).Index
            ContextoMenuEnab(False, True, ctxMenuEvento)
            btnIngEvento.Text = "Modificar"
            f = CType(dgEventos.SelectedRows(0).DataBoundItem, DataRowView).Row
            textFechaEvento.Text = f.Item("fecha")
            cmbTipoEvento.SelectedIndex = f.Item("tipoevento")
            BuscaElementoCombo(tbMotivoEvento, f.Item("motivo"), cmbMotivoEvento, 1, True)
            BuscaElementoCombo(tbTipoAccion, f.Item("tipoaccion"), cmbTipoAccion, 1, True)
            textObservaEvento.Text = f.Item("observa")
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxEliEvento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliEvento.Click
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgEventos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgEventos.SelectedRows(0).DataBoundItem, DataRowView).Row
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                tbEventos.Rows.Remove(filaTemp)
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

#End Region




#Region "SUB MENU"
    Private Sub MnuBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxBaja.Click
        If MsgBox("ESTA SEGURO DE DAR DE BAJA ESTE CONTRATO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            fBaja = New frmBajaContra
            fBaja.TopMost = True
            AddHandler fBaja.actValor, AddressOf ActualizacionDatosBaja
            fBaja.Inicializa(CInt(TextConxContrato.Text), CInt(textConxEmpleado.Text), CDate(TextAvisoFechaI.Text))
            fBaja.StartPosition = FormStartPosition.CenterScreen
            fBaja.ShowDialog()
        End If
    End Sub


    Private Sub MnuModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click
        If BuscaEscalar("select count (*) from suspensiones  where empresa=" & empresa & " and empleado=" &
           textConxEmpleado.Text & " and contrato=" & TextConxContrato.Text & " and estado=0") Then
            MsgBox("EMPLEADO ESTA SUSPENDIDO, NO PUEDE HACERSE CAMBIOS EN EL CONTRATO", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        btnBuscar.Enabled = False
        'btnSig.Enabled = False
        'btnAtr.Enabled = False
        btnGuardar.Enabled = True
        ConsultaReadOnly(TbGeneral, False)
        TextConxContrato.ReadOnly = True
        textConxEmpleado.ReadOnly = True
        TextHorasTotal.ReadOnly = False
        ContextoMenuEnab(False, True, ctxPrincipal)
        ContextoMenuEnab(True, True, ctxMenuOrigen)
        ContextoMenuEnab(True, True, ctxMenuSueldos)
        ContextoMenuEnab(True, True, ctxMenuEvento)
        FechaSoloLectura(True, False)
        EnabilizarDetalle(True)
        textConlcuentaban.ReadOnly = False
        'fecha inicio
        TextAvisoFechaI.Visible = False
        TextFechaInicio.Visible = True
        TextFechaInicio.ReadOnly = False


        'fecha
        TextAvisoFecha.Visible = False
        textFecha.Visible = True
        textFecha.ReadOnly = False
        cadena = "select nombre, estado from empestados where empresa=" & empresa & " and activo='S' order by estado"
        llenaTabla(cadena, tbEstado)
        'llena_combo(cadena, cmbEstado)
        'cmbEstado.Items.Add("")
        cmbEstado.DisplayMember = "nombre"
        cmbEstado.ValueMember = "estado"
        cmbEstado.DataSource = tbEstado

        BuscaElementoCombo(tbEstado, estadoPrincipal, cmbEstado, 1, True)
        If cmbFormaPago.Text.Trim <> "" Then
            If tbFormaPago.Rows(cmbFormaPago.SelectedIndex).Item(2) = "D" Then
                textConlcuentaban.ReadOnly = False
            End If
        End If
        Colorea_Mejorado(TbGeneral, ColorModi)
    End Sub

    Private Sub ActualizacionDatosBaja(ByVal sender As Object, ByVal e As clsActValorREvento)
        btnLimpiar_Click(sender, e)
    End Sub

#End Region

#Region "CambioCombos"

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        textConlcuentaban.ReadOnly = True
        If cmbFormaPago.Text.Trim <> "" Then
            If tbFormaPago.Rows(cmbFormaPago.SelectedIndex).Item(2) = "D" Then
                textConlcuentaban.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub cmbTipoPer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoPer.SelectedIndexChanged
        TextTipoBase.Clear()
        textConlcuentaban.ReadOnly = True
        If cmbTipoPer.Text.Trim <> "" Then
            filaTemp = tbTipoPer.Rows(cmbTipoPer.SelectedIndex)
            TextTipoBase.Text = filaTemp.Item(3)
            base = filaTemp.Item(4)
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        If cmbTipo.SelectedIndex = 0 Then
            TextConcepto.Text = "VALOR INICIAL"
            TextConcepto.ReadOnly = True
        Else
            TextConcepto.Clear()
            TextConcepto.ReadOnly = False
        End If
    End Sub

#End Region

#Region "ENTRA Y DEJA FOCO  Y VALIDACIONES"
    Private Sub Foco(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoSeguro.Enter, cmbTipoPer.Enter, textConlcuentaban.Enter, cmbPuesto.Enter, cmbModPago.Enter, cmbJornada.Enter, cmbFormaPago.Enter, TextConlObserva.Enter, cmbFormaPago.Enter, cmbJornada.Enter, textConlcuentaban.Enter, TextHora1.Enter, TextHora2.Enter, TextOrigen.Enter, TextNombOrigen.Enter, TextPorce.Enter, textConxEmpleado.Enter, textNombreEmple.Enter, textCodigo.Enter, textNombCodigo.Enter, cmbAfecta.Enter, TextValor.Enter
        activa(sender)
    End Sub


    Private Sub Deja(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoSeguro.Leave, cmbTipoPer.Leave, textConlcuentaban.Leave, cmbPuesto.Leave, cmbModPago.Leave, cmbJornada.Leave, cmbFormaPago.Leave, TextConlObserva.Leave, cmbFormaPago.Leave, cmbJornada.Leave, textConlcuentaban.Leave, TextHora1.Leave, TextHora2.Leave, TextOrigen.Leave, TextNombOrigen.Leave, TextPorce.Leave, textConxEmpleado.Leave, textNombreEmple.Leave, textCodigo.Leave, textNombCodigo.Leave, cmbAfecta.Leave, TextValor.Leave
        desactiva(sender)
    End Sub


    Private Sub TextHora1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextHora1.Validated, TextHora2.Validated
        Dim val1H1, val2H1, val1H2, val2H2 As Int32
        val1H1 = 0
        val2H1 = 0
        val1H2 = 0
        val2H2 = 0
        Dim horasf As Decimal = 0
        If TextHora1.ReadOnly = False And TextHora2.ReadOnly = False Then
            TextHorasTotal.Clear()
            Textsemanales.Clear()
            If TextHora1.Text <> "  :" Then
                If Hora(TextHora1, val1H1, val2H1) = False Then
                    MsgBox("FORMATO DE LA HORA DE INICIO NO ES VALIDO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    TextHora1.Text = "__:__"
                    TextHora2.Focus()
                    Exit Sub
                End If
            End If
            If TextHora2.Text <> "  :" Then
                If Hora(TextHora2, val1H2, val2H2) = False Then
                    MsgBox("FORMATO DE LA HORA DE INICIO NO ES VALIDO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    TextHora1.Text = "__:__"
                    TextHora2.Focus()
                    Exit Sub
                End If
            End If
        End If
        If TextHora1.Text <> "  :" And TextHora2.Text <> "  :" And TextHora1.ReadOnly = False And TextHora2.ReadOnly = False Then
            If val1H2 >= val1H1 Then
                If (val1H2 = val2H1) And (val2H2 <= val2H1) Then
                    MsgBox("HORA DE SALIDA DEBE SER MAYOR QUE LA HORA DE ENTRADA", MsgBoxStyle.Information, "Mensaje del Sistema")
                    TextHora2.Text = "__:__"
                    TextHora2.Focus()
                    Exit Sub
                End If
                If val2H2 >= val2H1 Then
                    HoraFinal = val1H2 - val1H1
                    minutoFinal = val2H2 - val2H1
                Else
                    minutoFinal = 60 + (val2H2 - val2H1)
                    HoraFinal = val1H2 - val1H1 - 1
                End If
                horasf = HoraFinal + (minutoFinal / 60)
                TextHorasTotal.Text = formato(horasf)
                Textsemanales.Text = formato(horasf * 5)
            Else
                MsgBox("HORA DE SALIDA DEBE SER MAYOR QUE LA HORA DE ENTRADA", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextHora2.Text = "__:__"
                TextHora2.Focus()
            End If
        End If
    End Sub


    Private Sub textFecha_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textFecha.Validated
        If textFecha.Text = "  /  /" Then
            textFecha.Text = Today.ToShortDateString
        End If
    End Sub

    Private Sub dgDatos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDatos.DataError
        dgDatos.RefreshEdit()
    End Sub

    Private Sub TextBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextPorce.KeyPress, TextConxContrato.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub frmDatosGen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

#End Region

#Region "Botones Siguiente"
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


#Region "Campo horas semanales"
    Private Sub Textsemanales_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Textsemanales.Enter
        If IsNumeric(Textsemanales.Text) Then
            Textsemanales.Text = CDec(Textsemanales.Text)
        Else
            Textsemanales.Text = "0"
        End If
    End Sub

    Private Sub Textsemanales_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Textsemanales.KeyPress
        soloNumeroDec(sender, e)
    End Sub

    Private Sub Textsemanales_Validated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Textsemanales.Validated
        If IsNumeric(Textsemanales.Text) Then
            Textsemanales.Text = formato(CDec(Textsemanales.Text))
        Else
            Textsemanales.Text = "0"
        End If
    End Sub

    Private Sub TextHorasT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextHorasTotal.Enter
        If IsNumeric(Textsemanales.Text) Then
            Textsemanales.Text = CDec(Textsemanales.Text)
        Else
            Textsemanales.Text = "0"
        End If
    End Sub

    Private Sub TextHorasT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextHorasTotal.KeyPress
        soloNumeroDec(sender, e)
    End Sub

    Private Sub TextHorasT_Validated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextHorasTotal.Validated
        If IsNumeric(Textsemanales.Text) Then
            Textsemanales.Text = formato(CDec(Textsemanales.Text))
        Else
            Textsemanales.Text = "0"
        End If
    End Sub
#End Region


#Region "Contrato Jefe"
#Region "JEFE"

    Private Sub BorraJefe(ByVal valbool As Boolean)
        TextNombreJefe.Clear()
        TextContratoJefe.Clear()

        If valbool = True Then
            TextJefe.Clear()
        End If
    End Sub


    Private Sub btnBuscaJefe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaJefe.Click
        lPara.Clear()
        Dim numFilas As Integer
        Dim tbJefe As New DataTable
        lPara("empresa") = empresa
        lPara("nombre") = TextNombreJefe.Text.Trim
        cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and nombre like '%' + @nombre + '%'  order by nombre"
        numFilas = llenaTabla(cadena, tbJefe, ListaParametros(lPara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)

        ElseIf numFilas = 1 Then
            BorraJefe(True)
            filaTemp = tbJefe.Rows(0)
            AsignaJefe(filaTemp)
            btnContrato.Focus()
        Else
            EnBuscaEmpleadoJ(tbJefe)
        End If
    End Sub

    Private Sub ValidaJefe()
        lPara.Clear()
        If valida_tipo_Entero(TextJefe.Text, 2) = True Then
            Dim tbdData As New DataTable
            lPara("empresa") = empresa
            lPara("empleado") = TextJefe.Text.Trim
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and empleado=@empleado"
            If llenaTabla(cadena, tbdData, ListaParametros(lPara)) > 0 Then
                AsignaJefe(tbdData.Rows(0))
            Else
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraJefe(True)
                TextJefe.Focus()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraJefe(True)
            TextJefe.Focus()
        End If
    End Sub

    Private Sub TextJefe_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextJefe.Validated
        If TextJefe.Text.Trim <> "" Then
            ValidaJefe()
        Else
            BorraJefe(False)
        End If
    End Sub


    Private Sub EnBuscaEmpleadoJ(ByVal tabla As DataTable)
        Dim fEmp As New frmMuestra2Columnas
        fEmp.TopMost = True
        fEmp.inicializa(tabla, "CODIGO", "NOMBRE", 0)
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        If (fEmp.fila IsNot Nothing) Then
            AsignaJefe(fEmp.fila)
        End If
    End Sub

    Private Sub AsignaJefe(ByVal filaTemp As DataRow)
        TextJefe.Text() = filaTemp.Item(0)
        TextNombreJefe.Text = filaTemp.Item(1)
    End Sub

#End Region

#Region "Contrato"

    Private Sub BtnContratoJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrato.Click
        lPara.Clear()
        Dim Num As Int16
        Dim tbContratos As New DataTable
        If TextJefe.Text.Trim <> "" Then
            lPara("empresa") = empresa
            lPara("empleado") = TextJefe.Text
            cadena = "select contrato, pu.nombre " &
                    " from contratos1 c1 " &
                    " inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                    " inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                    " where e.activo='S' and c1.empresa=@empresa and empleado=@empleado"
            Num = llenaTabla(cadena, tbContratos, ListaParametros(lPara))
            If Num = 1 Then
                TextContratoJefe.Text = tbContratos.Rows(0).Item(0)
            ElseIf Num > 1 Then
                Dim f2C As New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 0)
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()
                If f2C.fila IsNot Nothing Then
                    ActualizaContratoJefe(f2C.fila)
                End If

                dgvJefe.Focus()
            ElseIf Num = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextContratoJefe.Clear()
            End If
        Else
            MsgBox("INGRESO PRIMERO EL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub



    Private Sub ActualizaContratoJefe(ByVal fila As DataRow)
        TextContratoJefe.Text() = fila.Item(0)
    End Sub

    Private Sub TextConxContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextContratoJefe.KeyPress, TextJefe.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextConxContrato_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextContratoJefe.Validated
        lPara.Clear()
        If TextJefe.Text.Trim <> "" And TextContratoJefe.Text.Trim <> "" Then
            Dim tbTem As New DataTable("temp")
            lPara("empresa") = empresa
            lPara("empleado") = TextJefe.Text
            lPara("contrato") = TextContratoJefe.Text
            cadena = "select contrato, fechai " &
                    " from contratos1 c1 " &
                    " inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                    " where e.activo='S' and c1.empresa=@empresa and c1.empleado=@empleado AND c1.contrato=@contrato"
            If llenaTabla(cadena, tbTem, ListaParametros(lPara)) = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextContratoJefe.Clear()
            Else
                filaTemp = tbTem.Rows(0)
                ActualizaContratoJefe(filaTemp)
                dgvJefe.Focus()
            End If
        Else
            TextContratoJefe.Clear()
        End If
    End Sub

#End Region

#End Region

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub ctxReactivarContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxReactivarContrato.Click
        lPara.Clear()
        If MsgBox("ESTA SEGURO DE REACTIVAR ESTE CONTRATO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            lPara("fechae") = Today
            lPara("empresa") = empresa
            lPara("empleado") = textConxEmpleado.Text
            lPara("contrato") = TextConxContrato.Text
            cadena = "update contratos1 set estado=0, fechaf='', observa='', fechae=@fechae where empresa=@empresa and empleado=@empleado and contrato=@contrato"
            EjecutarQuery(cadena, ListaParametros(lPara))
            InsertBitacora(9, 9, "Reactivación del contrato " & TextConxContrato.Text & " empleado " & textConxEmpleado.Text)
            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim fImp As New frmReporteador
        fImp.Inicializador(CInt(textConxEmpleado.Text), CInt(TextConxContrato.Text))
        fImp.TopMost = True
        InsertBitacora(9, 5, Me.Text)
        fImp.ShowDialog()
    End Sub

    Private Sub btnAsignaJefe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignaJefe.Click
        If (tbDetJefes IsNot Nothing And tbDetJefes.Columns.Count = 3) Then
            Try
                If (tbDetJefes.Select("jefe=" & TextJefe.Text).Count > 0) Then
                    MsgBox("Jefe ya ingresado, verifique ", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If


                Dim filaN As DataRow = tbDetJefes.NewRow
                filaN("jefe") = CInt(TextJefe.Text)
                filaN("nombre") = TextNombreJefe.Text.Trim()
                filaN("contrato") = CInt(TextContratoJefe.Text)
                tbDetJefes.Rows.Add(filaN)
            Catch ex As Exception
                MsgBox("Error del sistema " & vbNewLine & ex.Message)
            End Try
           
        End If
    End Sub

    Private Sub ctxEliminarJefe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminarJefe.Click
        If (dgvJefe.SelectedRows.Count > 0) Then
            If (MsgBox("Esta seguro de eliminar al jefe " & dgvJefe.SelectedRows(0).Cells("nombre").Value.ToString(), MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes) Then
                tbDetJefes.Rows.Remove(CType(dgvJefe.SelectedRows(0).DataBoundItem, DataRowView).Row)
            End If
        End If
    End Sub

    Public Function TotalTabla(ByVal tabla As DataTable, ByVal indice As Int16) As Decimal
        Dim f As DataRow
        Dim i As Int32
        Dim numT As Decimal = 0
        For i = 0 To tabla.Rows.Count - 1
            f = tabla.Rows(i)

            numT = numT + f.Item(indice)
        Next i
        Return numT
    End Function

    Private Sub textSoloNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textConxEmpleado.KeyPress, TextConxContrato.KeyPress, TextJefe.KeyPress,
            textCodigo.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub textSoloNumeroDec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextValor.KeyPress, TextPorce.KeyPress
        soloNumeroDec(sender, e)
    End Sub
End Class
