Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMMANTPROVISIONES.VB MIEMBRO DE NOMINA.SLN                                 **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class FrmMantProvisiones
    Inherits Form
    Dim cadena As String
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim tbActivo As New DataTable("activo")
    Dim tbProveedor As New DataTable("proveedor")
    Dim tbOrigen As New DataTable("origen")
    Dim tbConsulta As New DataTable("consulta")
    Dim WithEvents fCta As frmMuestraSoloCuentas
    Dim WithEvents fCtaP As frmMuestraSoloCuentas
    Dim WithEvents fTran As frmMuestraCodigos
    Dim tbDatos As New DataTable("datos")
    Dim cm As CurrencyManager
    Dim dv As DataView
    Dim primeraves As Boolean = True
    Dim ts As New DataGridTableStyle
    Dim filaTemp As DataRow
    Dim valida As Boolean
    Dim CuentaCon As String
    Dim indice As Int16
    Dim ModificaA As Int16
    Dim valModi As Boolean
    Dim Valida_tipo_responsable As Integer
    'Dim WithEvents fUbi As frmMuestraUbica
    Dim tbUbicacion As New DataTable("ubicacion")
    Dim tbTipo As New DataTable("tipo")
    'Dim WithEvents fEmp As frmMuestraEmpleado
    Dim InicioConsulta As String = "SELECT pasivo,nombre,ltrim(rtrim(tipo)) tipo,ctagasto,ctapasivo,por FROM PASIVOLAB1 p1" & _
    " where p1.empresa=" & empresa
    Dim InicioConsulta2 As String = "select a.transac,b.nombre from pasivolab2 a  inner join tipotran b on b.transac = a.transac and b.empresa = a.empresa" & _
    " where a.empresa = " & empresa
    Friend WithEvents ctxEliminarM As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Dim finConsulta As String
    Dim lpara As New Dictionary(Of String, Object)
    'Dim fImp As FrmConsultaYReporte_TarjetaR



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

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents gpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents dgDatos As System.Windows.Forms.DataGridView
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMTotal As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents btnAtr As System.Windows.Forms.Button
    Friend WithEvents btnSig As System.Windows.Forms.Button
    Friend WithEvents stBar As System.Windows.Forms.StatusBar
    Friend WithEvents stbPanel As System.Windows.Forms.StatusBarPanel
    Friend WithEvents GpActivos As System.Windows.Forms.GroupBox
    Friend WithEvents gpBien As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnGuardarG As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents ctxModiDG As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxModifiGe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxModifiDeta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents CmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextConlNombre As System.Windows.Forms.TextBox
    Friend WithEvents gpTransac As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombTransac As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnTransac As System.Windows.Forms.Button
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TextConxPasivo As System.Windows.Forms.TextBox
    Friend WithEvents GpDetalle1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents gpUbica As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextConsCtaPasivo As System.Windows.Forms.TextBox
    Friend WithEvents TextNombCPasivo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnPasivo As System.Windows.Forms.Button
    Friend WithEvents gpGasto As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextConsCtaGasto As System.Windows.Forms.TextBox
    Friend WithEvents TextNombCGasto As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnGasto As System.Windows.Forms.Button
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents TextTipoPasivo As System.Windows.Forms.TextBox
    Friend WithEvents TextTransac As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantProvisiones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gpDetalle = New System.Windows.Forms.GroupBox()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.dgDatos = New System.Windows.Forms.DataGridView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ctxMTotal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModiDG = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxModifiGe = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxModifiDeta = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliminarM = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAtr = New System.Windows.Forms.Button()
        Me.btnSig = New System.Windows.Forms.Button()
        Me.btnGuardarG = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnTransac = New System.Windows.Forms.Button()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.btnPasivo = New System.Windows.Forms.Button()
        Me.btnGasto = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.stBar = New System.Windows.Forms.StatusBar()
        Me.stbPanel = New System.Windows.Forms.StatusBarPanel()
        Me.GpActivos = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextPorcentaje = New System.Windows.Forms.TextBox()
        Me.gpUbica = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextConsCtaPasivo = New System.Windows.Forms.TextBox()
        Me.TextNombCPasivo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gpGasto = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextConsCtaGasto = New System.Windows.Forms.TextBox()
        Me.TextNombCGasto = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextConlNombre = New System.Windows.Forms.TextBox()
        Me.CmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gpBien = New System.Windows.Forms.GroupBox()
        Me.TextConxPasivo = New System.Windows.Forms.TextBox()
        Me.TextTipoPasivo = New System.Windows.Forms.TextBox()
        Me.gpTransac = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextTransac = New System.Windows.Forms.TextBox()
        Me.TextNombTransac = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GpDetalle1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpDetalle.SuspendLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        Me.ctxMTotal.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        CType(Me.stbPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpActivos.SuspendLayout()
        Me.gpUbica.SuspendLayout()
        Me.gpGasto.SuspendLayout()
        Me.gpBien.SuspendLayout()
        Me.gpTransac.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpDetalle1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpDetalle
        '
        Me.gpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpDetalle.Controls.Add(Me.BtnGuardar)
        Me.gpDetalle.Controls.Add(Me.dgDatos)
        Me.gpDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDetalle.Location = New System.Drawing.Point(10, 379)
        Me.gpDetalle.Name = "gpDetalle"
        Me.gpDetalle.Size = New System.Drawing.Size(1108, 204)
        Me.gpDetalle.TabIndex = 4
        Me.gpDetalle.TabStop = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.ImageKey = "guardar.png"
        Me.BtnGuardar.ImageList = Me.ImageNuevos
        Me.BtnGuardar.Location = New System.Drawing.Point(1028, 173)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(74, 30)
        Me.BtnGuardar.TabIndex = 26
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnGuardar, "Almacenar registro")
        Me.BtnGuardar.UseVisualStyleBackColor = False
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
        '
        'dgDatos
        '
        Me.dgDatos.AllowUserToAddRows = False
        Me.dgDatos.AllowUserToDeleteRows = False
        Me.dgDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDatos.ContextMenuStrip = Me.ctxMenu
        Me.dgDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgDatos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatos.Location = New System.Drawing.Point(6, 12)
        Me.dgDatos.MultiSelect = False
        Me.dgDatos.Name = "dgDatos"
        Me.dgDatos.ReadOnly = True
        Me.dgDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDatos.Size = New System.Drawing.Size(1096, 155)
        Me.dgDatos.TabIndex = 8
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxEliminar})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(183, 26)
        '
        'ctxEliminar
        '
        Me.ctxEliminar.Name = "ctxEliminar"
        Me.ctxEliminar.Size = New System.Drawing.Size(182, 22)
        Me.ctxEliminar.Text = "Eliminar Transacción"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(89, 262)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(69, 30)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'ctxMTotal
        '
        Me.ctxMTotal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModiDG, Me.ctxEliminarM})
        Me.ctxMTotal.Name = "ctxMTotal"
        Me.ctxMTotal.Size = New System.Drawing.Size(145, 48)
        '
        'ctxModiDG
        '
        Me.ctxModiDG.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModifiGe, Me.ctxModifiDeta})
        Me.ctxModiDG.Name = "ctxModiDG"
        Me.ctxModiDG.Size = New System.Drawing.Size(144, 22)
        Me.ctxModiDG.Text = "Modificación"
        '
        'ctxModifiGe
        '
        Me.ctxModifiGe.Name = "ctxModifiGe"
        Me.ctxModifiGe.Size = New System.Drawing.Size(294, 22)
        Me.ctxModifiGe.Text = "Modificación de Datos Generales"
        '
        'ctxModifiDeta
        '
        Me.ctxModifiDeta.Name = "ctxModifiDeta"
        Me.ctxModifiDeta.Size = New System.Drawing.Size(294, 22)
        Me.ctxModifiDeta.Text = "Modificación del Detalle de Transacciones"
        '
        'ctxEliminarM
        '
        Me.ctxEliminarM.Name = "ctxEliminarM"
        Me.ctxEliminarM.Size = New System.Drawing.Size(144, 22)
        Me.ctxEliminarM.Text = "Eliminación"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageKey = "buscar2.png"
        Me.btnBuscar.ImageList = Me.ImageNuevos
        Me.btnBuscar.Location = New System.Drawing.Point(503, 262)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(70, 30)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Buscar registro")
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'btnAtr
        '
        Me.btnAtr.BackColor = System.Drawing.SystemColors.Control
        Me.btnAtr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtr.ImageKey = "anterior.png"
        Me.btnAtr.ImageList = Me.ImageNuevos
        Me.btnAtr.Location = New System.Drawing.Point(11, 262)
        Me.btnAtr.Name = "btnAtr"
        Me.btnAtr.Size = New System.Drawing.Size(72, 30)
        Me.btnAtr.TabIndex = 5
        Me.btnAtr.Text = "Anterior"
        Me.btnAtr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAtr, "Registro anterior")
        Me.btnAtr.UseVisualStyleBackColor = False
        '
        'btnSig
        '
        Me.btnSig.BackColor = System.Drawing.SystemColors.Control
        Me.btnSig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSig.ImageKey = "siguiente.png"
        Me.btnSig.ImageList = Me.ImageNuevos
        Me.btnSig.Location = New System.Drawing.Point(585, 262)
        Me.btnSig.Name = "btnSig"
        Me.btnSig.Size = New System.Drawing.Size(82, 30)
        Me.btnSig.TabIndex = 6
        Me.btnSig.Text = "Siguiente"
        Me.btnSig.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSig, "Siguiente registro")
        Me.btnSig.UseVisualStyleBackColor = False
        '
        'btnGuardarG
        '
        Me.btnGuardarG.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardarG.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarG.ImageKey = "guardar.png"
        Me.btnGuardarG.ImageList = Me.ImageNuevos
        Me.btnGuardarG.Location = New System.Drawing.Point(423, 262)
        Me.btnGuardarG.Name = "btnGuardarG"
        Me.btnGuardarG.Size = New System.Drawing.Size(74, 30)
        Me.btnGuardarG.TabIndex = 78
        Me.btnGuardarG.Text = "Guardar"
        Me.btnGuardarG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardarG, "Actualizar registro")
        Me.btnGuardarG.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.ImageKey = "impresora2.png"
        Me.btnImprimir.ImageList = Me.ImageNuevos
        Me.btnImprimir.Location = New System.Drawing.Point(275, 262)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(74, 30)
        Me.btnImprimir.TabIndex = 95
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir constancia de ingreso")
        Me.btnImprimir.UseVisualStyleBackColor = False
        Me.btnImprimir.Visible = False
        '
        'btnTransac
        '
        Me.btnTransac.BackColor = System.Drawing.SystemColors.Control
        Me.btnTransac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTransac.ImageKey = "buscar1.png"
        Me.btnTransac.ImageList = Me.ImageNuevos
        Me.btnTransac.Location = New System.Drawing.Point(568, 16)
        Me.btnTransac.Name = "btnTransac"
        Me.btnTransac.Size = New System.Drawing.Size(72, 30)
        Me.btnTransac.TabIndex = 3
        Me.btnTransac.Text = "Buscar"
        Me.btnTransac.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnTransac, "Busar activo")
        Me.btnTransac.UseVisualStyleBackColor = False
        '
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresar.ImageKey = "checkok.png"
        Me.btnIngresar.ImageList = Me.ImageNuevos
        Me.btnIngresar.Location = New System.Drawing.Point(686, 25)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(82, 30)
        Me.btnIngresar.TabIndex = 4
        Me.btnIngresar.Text = "Aceptar"
        Me.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngresar, "Ingresar centro de costo para aplicación del gasto")
        Me.btnIngresar.UseVisualStyleBackColor = False
        '
        'btnPasivo
        '
        Me.btnPasivo.BackColor = System.Drawing.SystemColors.Control
        Me.btnPasivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPasivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPasivo.ImageKey = "buscar1.png"
        Me.btnPasivo.ImageList = Me.ImageNuevos
        Me.btnPasivo.Location = New System.Drawing.Point(666, 15)
        Me.btnPasivo.Name = "btnPasivo"
        Me.btnPasivo.Size = New System.Drawing.Size(69, 30)
        Me.btnPasivo.TabIndex = 3
        Me.btnPasivo.Text = "Buscar"
        Me.btnPasivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnPasivo, "Buscar ubicación")
        Me.btnPasivo.UseVisualStyleBackColor = False
        '
        'btnGasto
        '
        Me.btnGasto.BackColor = System.Drawing.SystemColors.Control
        Me.btnGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGasto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGasto.ImageKey = "buscar1.png"
        Me.btnGasto.ImageList = Me.ImageNuevos
        Me.btnGasto.Location = New System.Drawing.Point(666, 10)
        Me.btnGasto.Name = "btnGasto"
        Me.btnGasto.Size = New System.Drawing.Size(69, 30)
        Me.btnGasto.TabIndex = 3
        Me.btnGasto.Text = "Buscar"
        Me.btnGasto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGasto, "Busar activo")
        Me.btnGasto.UseVisualStyleBackColor = False
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(359, 2)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(431, 40)
        Me.gpEmpresa.TabIndex = 56
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(12, 13)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(407, 21)
        Me.TextNombEmpresa.TabIndex = 2
        Me.TextNombEmpresa.TabStop = False
        '
        'stBar
        '
        Me.stBar.Location = New System.Drawing.Point(0, 589)
        Me.stBar.Name = "stBar"
        Me.stBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.stbPanel})
        Me.stBar.ShowPanels = True
        Me.stBar.Size = New System.Drawing.Size(1130, 16)
        Me.stBar.TabIndex = 76
        '
        'stbPanel
        '
        Me.stbPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.stbPanel.Name = "stbPanel"
        Me.stbPanel.Text = "Click derecho sobre el panel de información para activar las opciones:  modificac" &
    "ión, eliminación de pasivo laboral."
        Me.stbPanel.Width = 1113
        '
        'GpActivos
        '
        Me.GpActivos.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GpActivos.ContextMenuStrip = Me.ctxMTotal
        Me.GpActivos.Controls.Add(Me.Label4)
        Me.GpActivos.Controls.Add(Me.TextPorcentaje)
        Me.GpActivos.Controls.Add(Me.gpUbica)
        Me.GpActivos.Controls.Add(Me.gpGasto)
        Me.GpActivos.Controls.Add(Me.Label2)
        Me.GpActivos.Controls.Add(Me.TextConlNombre)
        Me.GpActivos.Controls.Add(Me.CmbTipo)
        Me.GpActivos.Controls.Add(Me.Label8)
        Me.GpActivos.Controls.Add(Me.gpBien)
        Me.GpActivos.Controls.Add(Me.TextTipoPasivo)
        Me.GpActivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpActivos.Location = New System.Drawing.Point(10, 57)
        Me.GpActivos.Name = "GpActivos"
        Me.GpActivos.Size = New System.Drawing.Size(803, 200)
        Me.GpActivos.TabIndex = 1
        Me.GpActivos.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(474, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Porcentaje:"
        '
        'TextPorcentaje
        '
        Me.TextPorcentaje.BackColor = System.Drawing.Color.White
        Me.TextPorcentaje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPorcentaje.Location = New System.Drawing.Point(556, 171)
        Me.TextPorcentaje.MaxLength = 7
        Me.TextPorcentaje.Name = "TextPorcentaje"
        Me.TextPorcentaje.Size = New System.Drawing.Size(64, 20)
        Me.TextPorcentaje.TabIndex = 3
        '
        'gpUbica
        '
        Me.gpUbica.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpUbica.Controls.Add(Me.Label10)
        Me.gpUbica.Controls.Add(Me.TextConsCtaPasivo)
        Me.gpUbica.Controls.Add(Me.TextNombCPasivo)
        Me.gpUbica.Controls.Add(Me.Label7)
        Me.gpUbica.Controls.Add(Me.btnPasivo)
        Me.gpUbica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpUbica.Location = New System.Drawing.Point(11, 109)
        Me.gpUbica.Name = "gpUbica"
        Me.gpUbica.Size = New System.Drawing.Size(741, 54)
        Me.gpUbica.TabIndex = 2
        Me.gpUbica.TabStop = False
        Me.gpUbica.Text = "Cuenta de pasivo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Código:"
        '
        'TextConsCtaPasivo
        '
        Me.TextConsCtaPasivo.BackColor = System.Drawing.Color.White
        Me.TextConsCtaPasivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConsCtaPasivo.Location = New System.Drawing.Point(62, 19)
        Me.TextConsCtaPasivo.MaxLength = 6
        Me.TextConsCtaPasivo.Name = "TextConsCtaPasivo"
        Me.TextConsCtaPasivo.Size = New System.Drawing.Size(48, 20)
        Me.TextConsCtaPasivo.TabIndex = 1
        '
        'TextNombCPasivo
        '
        Me.TextNombCPasivo.BackColor = System.Drawing.Color.White
        Me.TextNombCPasivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombCPasivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombCPasivo.Location = New System.Drawing.Point(201, 19)
        Me.TextNombCPasivo.MaxLength = 50
        Me.TextNombCPasivo.Name = "TextNombCPasivo"
        Me.TextNombCPasivo.Size = New System.Drawing.Size(408, 20)
        Me.TextNombCPasivo.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(142, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Nombre:"
        '
        'gpGasto
        '
        Me.gpGasto.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpGasto.Controls.Add(Me.Label11)
        Me.gpGasto.Controls.Add(Me.TextConsCtaGasto)
        Me.gpGasto.Controls.Add(Me.TextNombCGasto)
        Me.gpGasto.Controls.Add(Me.Label12)
        Me.gpGasto.Controls.Add(Me.btnGasto)
        Me.gpGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpGasto.Location = New System.Drawing.Point(11, 56)
        Me.gpGasto.Name = "gpGasto"
        Me.gpGasto.Size = New System.Drawing.Size(741, 47)
        Me.gpGasto.TabIndex = 1
        Me.gpGasto.TabStop = False
        Me.gpGasto.Text = "Cuenta de gasto"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Código:"
        '
        'TextConsCtaGasto
        '
        Me.TextConsCtaGasto.BackColor = System.Drawing.Color.White
        Me.TextConsCtaGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConsCtaGasto.Location = New System.Drawing.Point(62, 16)
        Me.TextConsCtaGasto.MaxLength = 4
        Me.TextConsCtaGasto.Name = "TextConsCtaGasto"
        Me.TextConsCtaGasto.Size = New System.Drawing.Size(48, 20)
        Me.TextConsCtaGasto.TabIndex = 1
        '
        'TextNombCGasto
        '
        Me.TextNombCGasto.BackColor = System.Drawing.Color.White
        Me.TextNombCGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombCGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombCGasto.Location = New System.Drawing.Point(201, 16)
        Me.TextNombCGasto.MaxLength = 75
        Me.TextNombCGasto.Name = "TextNombCGasto"
        Me.TextNombCGasto.Size = New System.Drawing.Size(408, 20)
        Me.TextNombCGasto.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(142, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Nombre:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextConlNombre
        '
        Me.TextConlNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextConlNombre.Location = New System.Drawing.Point(91, 20)
        Me.TextConlNombre.MaxLength = 30
        Me.TextConlNombre.Name = "TextConlNombre"
        Me.TextConlNombre.Size = New System.Drawing.Size(412, 20)
        Me.TextConlNombre.TabIndex = 6
        '
        'CmbTipo
        '
        Me.CmbTipo.BackColor = System.Drawing.Color.White
        Me.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipo.Items.AddRange(New Object() {"SEGURO SOCIAL PATRONAL", "AGUINALDO", "BONO ANUAL", "VACACIONES", "INDEMNIZACION", ""})
        Me.CmbTipo.Location = New System.Drawing.Point(212, 169)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(247, 21)
        Me.CmbTipo.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(19, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Tipo de provisión:"
        '
        'gpBien
        '
        Me.gpBien.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpBien.Controls.Add(Me.TextConxPasivo)
        Me.gpBien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpBien.Location = New System.Drawing.Point(524, 9)
        Me.gpBien.Name = "gpBien"
        Me.gpBien.Size = New System.Drawing.Size(96, 41)
        Me.gpBien.TabIndex = 44
        Me.gpBien.TabStop = False
        Me.gpBien.Text = "Pasivo"
        '
        'TextConxPasivo
        '
        Me.TextConxPasivo.BackColor = System.Drawing.Color.White
        Me.TextConxPasivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxPasivo.ForeColor = System.Drawing.Color.Red
        Me.TextConxPasivo.Location = New System.Drawing.Point(12, 14)
        Me.TextConxPasivo.MaxLength = 7
        Me.TextConxPasivo.Name = "TextConxPasivo"
        Me.TextConxPasivo.ReadOnly = True
        Me.TextConxPasivo.Size = New System.Drawing.Size(72, 20)
        Me.TextConxPasivo.TabIndex = 4
        '
        'TextTipoPasivo
        '
        Me.TextTipoPasivo.BackColor = System.Drawing.Color.White
        Me.TextTipoPasivo.Location = New System.Drawing.Point(212, 169)
        Me.TextTipoPasivo.Name = "TextTipoPasivo"
        Me.TextTipoPasivo.ReadOnly = True
        Me.TextTipoPasivo.Size = New System.Drawing.Size(244, 20)
        Me.TextTipoPasivo.TabIndex = 58
        '
        'gpTransac
        '
        Me.gpTransac.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpTransac.Controls.Add(Me.Label3)
        Me.gpTransac.Controls.Add(Me.TextTransac)
        Me.gpTransac.Controls.Add(Me.TextNombTransac)
        Me.gpTransac.Controls.Add(Me.Label9)
        Me.gpTransac.Controls.Add(Me.btnTransac)
        Me.gpTransac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTransac.Location = New System.Drawing.Point(7, 13)
        Me.gpTransac.Name = "gpTransac"
        Me.gpTransac.Size = New System.Drawing.Size(673, 52)
        Me.gpTransac.TabIndex = 5
        Me.gpTransac.TabStop = False
        Me.gpTransac.Text = "Transacción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Código:"
        '
        'TextTransac
        '
        Me.TextTransac.BackColor = System.Drawing.Color.White
        Me.TextTransac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTransac.Location = New System.Drawing.Point(59, 18)
        Me.TextTransac.MaxLength = 4
        Me.TextTransac.Name = "TextTransac"
        Me.TextTransac.Size = New System.Drawing.Size(48, 20)
        Me.TextTransac.TabIndex = 1
        '
        'TextNombTransac
        '
        Me.TextNombTransac.BackColor = System.Drawing.Color.White
        Me.TextNombTransac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombTransac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombTransac.Location = New System.Drawing.Point(178, 19)
        Me.TextNombTransac.MaxLength = 75
        Me.TextNombTransac.Name = "TextNombTransac"
        Me.TextNombTransac.Size = New System.Drawing.Size(384, 20)
        Me.TextNombTransac.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(122, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Nombre:"
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'GpDetalle1
        '
        Me.GpDetalle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GpDetalle1.Controls.Add(Me.btnIngresar)
        Me.GpDetalle1.Controls.Add(Me.gpTransac)
        Me.GpDetalle1.Enabled = False
        Me.GpDetalle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpDetalle1.Location = New System.Drawing.Point(10, 298)
        Me.GpDetalle1.Name = "GpDetalle1"
        Me.GpDetalle1.Size = New System.Drawing.Size(803, 75)
        Me.GpDetalle1.TabIndex = 3
        Me.GpDetalle1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 51)
        Me.Panel1.TabIndex = 96
        '
        'FrmMantProvisiones
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.GpDetalle1)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnGuardarG)
        Me.Controls.Add(Me.GpActivos)
        Me.Controls.Add(Me.stBar)
        Me.Controls.Add(Me.btnAtr)
        Me.Controls.Add(Me.btnSig)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.gpEmpresa)
        Me.Controls.Add(Me.gpDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMantProvisiones"
        Me.Text = "Mantenimiento de Pasivos Laborales"
        Me.gpDetalle.ResumeLayout(False)
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        Me.ctxMTotal.ResumeLayout(False)
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        CType(Me.stbPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpActivos.ResumeLayout(False)
        Me.GpActivos.PerformLayout()
        Me.gpUbica.ResumeLayout(False)
        Me.gpUbica.PerformLayout()
        Me.gpGasto.ResumeLayout(False)
        Me.gpGasto.PerformLayout()
        Me.gpBien.ResumeLayout(False)
        Me.gpBien.PerformLayout()
        Me.gpTransac.ResumeLayout(False)
        Me.gpTransac.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpDetalle1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmMantProvisiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        TextNombEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=@empresa", ListaParametros(lpara))
        Me.KeyPreview = True
        btnLimpiar_Click(sender, e)
        'dgDatos.
    End Sub

    Private Sub EnabilizarCampos(ByVal valBool As Boolean)
        '     cmbEstado.Visible = valBool
        '   TextEstado.Visible = Not valBool
        '   CmbBien.Visible = valBool
        '   TextBien.Visible = Not va
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Valida_tipo_responsable = 1
        ModificaA = 0
        CmbTipo.Text = ""
        ConsultaReadOnly(GpActivos, False)
        CmbTipo.Enabled = True
        borra_Mejorado(GpActivos, ep1)
        borra_Mejorado(GpDetalle1, ep1)
        CmbTipo.Visible = True
        TextTipoPasivo.Visible = False
        TextTipoPasivo.ReadOnly = True
        GpDetalle1.Enabled = False
        gpDetalle.Enabled = True
        dgDatos.ReadOnly = True
        tbDatos.Clear()
        btnSig.Enabled = False
        btnAtr.Enabled = False
        dgDatos.DataSource = Nothing
        BtnGuardar.Enabled = False
        btnGuardarG.Visible = False
        'AltoGrid(17, tbDatos, 176, 452, False, dgDatos)
        ctxModiDG.Enabled = False
        ctxEliminarM.Enabled = False
        ctxModiDG.Visible = False
        ctxEliminarM.Visible = False
        btnBuscar.Enabled = True
    End Sub


#Region "TIPO"

    '---------------------------------
    ' Borra los campos de la forma
    '---------------------------------
    Private Sub BorraTipo(ByVal valbool As Boolean)
        TextNombTransac.Clear()
        If valbool = True Then
            btnIngresar.Enabled = Not valbool
            TextTransac.Clear()
        End If
    End Sub

    '------------------------------------------------
    ' Realizaciòn de la busqueda del tipo de tarjeta
    '------------------------------------------------

    Private Sub btnTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransac.Click
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = TextNombTransac.Text.Trim
        Dim numFilas As Int32
        cadena = "select transac, nombre from tipotran where empresa=@empresa and nombre like '%' + @nombre + '%'  and tipomov = 'I' order by transac"
        numFilas = llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TRANSACCIONES CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraTipo(True)
            TextTransac.Focus()
        ElseIf numFilas = 1 Then
            '----------------------------------------------
            ' Si haya uno directamente entonces lo muestra
            '----------------------------------------------
            BorraTipo(True)
            filaTemp = tbTipo.Rows.Item(0)
            TextTransac.Text() = filaTemp.Item(0)
            TextNombTransac.Text = filaTemp.Item(1)
            btnIngresar.Enabled = True
            btnIngresar.Focus()
        Else
            '-------------------------------------
            ' Si hay muchos lo muestra en tabla
            '-------------------------------------
            EnBuscaTipo()
        End If
    End Sub

    '------------------------------------
    ' Verifica si existe el Tipo Elegido
    '------------------------------------

    Private Sub ValidaTipo()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("transac") = TextTransac.Text.Trim
        cadena = "select count (*) from tipotran where empresa=@empresa and transac=@transac"
        If BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
            MsgBox("TRANSACCION NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraTipo(True)
            TextTransac.Focus()
            Exit Sub
        End If
        cadena = "select transac, nombre from tipotran where empresa=@empresa and tipomov = 'I' and transac=@transac"
        abrir_conexion(cn)
        comando = New SqlCommand(cadena, cn)
        comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
        dr = comando.ExecuteReader
        '-----------
        ' si Existe
        '-----------
        If dr.HasRows() Then
            BorraTipo(False)
            dr.Read()
            TextNombTransac.Text = dr.GetValue(1)
            dr.Close()
            cn.Close()
            btnIngresar.Enabled = True
            btnIngresar.Focus()
        Else
            MsgBox("TRANSACCION NO VALIDA", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            dr.Close()
            cn.Close()
            BorraTipo(True)
            TextTransac.Focus()
        End If
    End Sub

    '-----------------------------------------------
    ' Llama un Form para ingresar datos de un table
    '-----------------------------------------------
    Private Sub EnBuscaTipo()
        fTran = New frmMuestraCodigos
        fTran.TopMost = True
        fTran.inicializa(tbTipo)
        AddHandler fTran.actValor, AddressOf ActualizacionDatosTipo
        fTran.StartPosition = FormStartPosition.CenterScreen
        fTran.ShowDialog()
        btnIngresar.Enabled = True
        btnIngresar.Focus()
    End Sub

    Private Sub ActualizacionDatosTipo(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraTipo(True)
        filaTemp = tbTipo.Rows.Item(e.va2)
        TextTransac.Text() = filaTemp.Item(0)
        TextNombTransac.Text = filaTemp.Item(1)
    End Sub

    Private Sub TextTipo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextTransac.Validated
        If TextTransac.Text.Trim <> "" Then
            ValidaTipo()
        Else
            BorraTipo(False)
        End If
    End Sub

    Private Sub TextNombTipo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextNombTransac.Validated
        If validetError(sender, ep1) = False Then
            sender.text = ""
        End If
    End Sub

    Private Sub TextTipo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextTransac.KeyPress
        soloNumero(sender, e)
    End Sub


#End Region
    Private Sub estilo()
        'dgDatos.TableStyles.Clear()
        ts.MappingName = "datos"
        'dgDatos.TableStyles.Add(ts)
        With dgDatos '.TableStyles("datos")
            '.PreferredColumnWidth = 15

            .Columns(0).Width = 90
            .Columns(0).ReadOnly = True
            .Columns(0).HeaderText = "Transacción"
            .Columns(1).Width = 300
            .Columns(1).ReadOnly = True
            .Columns(1).HeaderText = "Nombre"
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen
            '.GridLineColor = Color.Black
        End With

    End Sub




#Region "Buscar y Mostrar"
    '----------------------------------------------------------
    ' Boton que realiza la busqueda dependiendo los parametros
    '----------------------------------------------------------
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim cadenaConsulta As String
        finConsulta = ""
        GeneraConsulta(GpActivos, finConsulta, "p1")
        If CmbTipo.Text.Trim <> "" Then
            If CmbTipo.SelectedIndex = 0 Then
                finConsulta = finConsulta & " and p1.tipo='SP'"
            ElseIf CmbTipo.SelectedIndex = 1 Then
                finConsulta = finConsulta & " and p1.tipo='A'"
            ElseIf CmbTipo.SelectedIndex = 2 Then
                finConsulta = finConsulta & " and p1.tipo='B'"
            ElseIf CmbTipo.SelectedIndex = 3 Then
                finConsulta = finConsulta & " and p1.tipo='V'"
            ElseIf CmbTipo.SelectedIndex = 4 Then
                finConsulta = finConsulta & " and p1.tipo='I'"
            End If
        End If

        cadenaConsulta = InicioConsulta & finConsulta
        Mostrar(cadenaConsulta, sender, e)
    End Sub


    '---------------------------------------------------------------------------
    ' Muestra la consulta dependiendo de los parametros que se le hayan mandado
    '---------------------------------------------------------------------------

    Private Sub Mostrar(ByVal subCadena As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        ConsultaReadOnly(GpActivos, True)
        btnBuscar.Enabled = False
        TextConlNombre.ReadOnly = True
        CmbTipo.Enabled = False
        CmbTipo.Visible = False
        TextTipoPasivo.Visible = True
        TextTipoPasivo.ReadOnly = True
        TextNombCGasto.ReadOnly = True
        TextNombCPasivo.ReadOnly = True
        TextPorcentaje.ReadOnly = True
        btnGasto.Enabled = False
        btnPasivo.Enabled = False
        indice = 0
        If llenaTabla(subCadena, tbConsulta) > 0 Then
            llenaText(0)
        Else
            MsgBox("NO HAY REGISTROS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
        End If
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub

    '-----------------------------------------------------------------------------------
    ' Llena los datos para efectos de la consulta, usando el indice de la consulta misma
    '-----------------------------------------------------------------------------------

    Private Sub llenaText(ByVal indi As Int16)
        Dim Elementos As Int32
        filaTemp = tbConsulta.Rows.Item(indi)
        Select Case filaTemp.Item("tipo")
            Case "SP"
                CmbTipo.SelectedIndex = 0
            Case "A"
                CmbTipo.SelectedIndex = 1
            Case "B"
                CmbTipo.SelectedIndex = 2
            Case "V"
                CmbTipo.SelectedIndex = 3
            Case "I"
                CmbTipo.SelectedIndex = 4
        End Select
        TextTipoPasivo.Text = CmbTipo.Text
        ctxEliminarM.Visible = True
        ctxModiDG.Visible = True
        ctxEliminarM.Enabled = True
        ctxModiDG.Enabled = True
        TextConsCtaGasto.Text = filaTemp.Item("ctagasto")
        TextConsCtaPasivo.Text = filaTemp.Item("ctapasivo")
        TextPorcentaje.Text = filaTemp.Item("por")
        TextConlNombre.Text = filaTemp.Item("nombre")
        TextConxPasivo.Text = filaTemp.Item("pasivo")
        ValidaCGasto()
        ValidaCPasivo()
        cadena = InicioConsulta2 & " and a.pasivo=" & TextConxPasivo.Text & " order by a.transac"
        Elementos = llenaTabla(cadena, tbDatos)
        dgDatos.DataSource = tbDatos
        estilo()
        'AltoGrid(17, tbDatos, 176, 452, False, dgDatos)
        cm = CType(BindingContext(tbDatos), CurrencyManager)
        dv = CType(cm.List, DataView)
        dv.AllowNew = False
        dv.AllowDelete = False
        btnSig.Focus()
        'AddHandler tbDatos.ColumnChanged, AddressOf cambio_valor
        'AddHandler tbDatos.ColumnChanging, AddressOf cambiando_valor
    End Sub


    Private Sub cambiando_valor(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        Dim tempString As String = ""
        Dim tempDec As Int16
        If (e.Column.ColumnName.ToLower = "porciento") Then
            Try
                tempDec = e.ProposedValue
                If 0.0 < tempDec And tempDec <= 100.0 Then
                    e.ProposedValue = tempDec
                Else
                    e.ProposedValue = e.Row.Item(2)
                End If
            Catch ex As Exception
                MsgBox("LO INGRESADO NO ES UN NUMERO VALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
                e.ProposedValue = e.Row.Item(2)
            End Try
        End If
    End Sub


    Private Sub ModificaL(ByVal valBool As Boolean)
        BtnGuardar.Enabled = False
        If (valBool) Then
            'dgDatos.TableStyles("datos").GridColumnStyles(2).ReadOnly = False
        Else
            'dgDatos.TableStyles("datos").GridColumnStyles(2).ReadOnly = True
        End If
    End Sub

#End Region



#Region "MODIFICACION DEL INGRESO DE ACTIVOS O UTILES"

    '---------------------------------------
    ' Modificacion de Articulos del detalle
    '---------------------------------------
    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ctxEliminar.Enabled = False
        If dgDatos.SelectedRows.Count > 0 Then
            valModi = True
            ModificaA = dgDatos.SelectedRows(0).Index()
            Dim fila As DataRow
            fila = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
            If fila.Item(2) = "ACTIVO" Then
                'CmbArticulo.SelectedIndex = 0
            ElseIf fila.Item(2) = "UTIL" Then
                'CmbArticulo.SelectedIndex = 1
            End If
            'cmbarticulo.Enabled=False 
            TextConsCtaPasivo.Text = fila.Item(5)
            'ValidaUbicacion()
            TextPorcentaje.Text = fila.Item(7)
            'If CmbArticulo.SelectedIndex = 0 Then
            'TextActivo.Text = fila.Item(3)
            'ValidaActivo()
            'ElseIf CmbArticulo.SelectedIndex = 1 Then
            'TextUtil.Text = fila.Item(4)
            'End If

            BtnGuardar.Enabled = True
        Else
            MsgBox("NO HAY NINGUNA LINEA PARA MODIFICAR", MsgBoxStyle.Information, "Mensaje del Sistemas")
        End If


    End Sub

    '------------------------------------------
    ' Boton para Ingreso de Articulos a Tarjeta
    '------------------------------------------

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click

        If Not validetError(TextTransac, ep1) Or Not validetError(TextNombTransac, ep1) Then
            Exit Sub
        End If
        Dim i As Int16
        Dim fila, filatemp As DataRow
        For i = 0 To tbDatos.Rows.Count - 1
            filatemp = tbDatos.Rows(i)
            If CInt(TextTransac.Text) = filatemp.Item(0) Then
                MsgBox("TRANSACCION YA EXISTE, VERIFIQUE", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                BorraTipo(True)
                TextTransac.Focus()
                Exit Sub
            End If
        Next i
        fila = tbDatos.NewRow()
        fila.Item(0) = TextTransac.Text.Trim
        fila.Item(1) = TextNombTransac.Text.Trim
        tbDatos.Rows.Add(fila)
        'AltoGrid(17, tbDatos, 176, 452, False, dgDatos)
        dgDatos.Refresh()
        BorraTipo(True)
        TextTransac.Focus()
    End Sub

    '------------------------------------------------
    ' Guarda los datos del Detalle de la Tarjeta
    '------------------------------------------------
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        lpara.Clear()
        If tbDatos.Rows.Count = 0 Then
            MsgBox("NO HAY TRANSACCIONES ASOCIADAS A ESTE PASIVO LABORAL, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        lpara("pasivo") = TextConxPasivo.Text.Trim
        lpara("empresa") = empresa
        If MsgBox("DESEA ALMACENAR ESTOS REGISTROS", MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            Dim i As Int16
            cadena = "delete pasivolab2 where pasivo=@pasivo and empresa=@empresa"
            EjecutarQuery(cadena, ListaParametros(lpara))

            For i = 0 To tbDatos.Rows.Count - 1
                lpara.Clear()
                filaTemp = tbDatos.Rows.Item(i)
                lpara("empresa") = empresa
                lpara("pasivo") = TextConxPasivo.Text.Trim
                lpara("transac") = filaTemp.Item(0)
                cadena = "insert pasivolab2(empresa,pasivo,transac)" &
                         "values(@empresa,@pasivo,@transac)"
                EjecutarQuery(cadena, ListaParametros(lpara))
            Next i
            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
        End If

    End Sub

    '---------------------------------
    ' Elimina un articulo del Detalle 
    '---------------------------------
    Private Sub ctxEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        If dgDatos.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO QUE DESEA ELIMINAR LA TRANSACCION", MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
                tbDatos.Rows.Remove(filaTemp)
                dgDatos.Refresh()
                'AltoGrid(17, tbDatos, 176, 452, False, dgDatos)

                BtnGuardar.Enabled = True
            End If
        Else
            MsgBox("NO HAY NINGUNA LINEA PARA ELIMINAR", MsgBoxStyle.Information, "Mensaje del Sistemas")
        End If
    End Sub

#End Region

#Region "Modificacion y Anulacion"

    '------------------------------------------------
    ' Modificacion de datos generales (Observacion)
    '------------------------------------------------
    Private Sub ctxModifiGe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModifiGe.Click
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnImprimir.Visible = False
        ctxModiDG.Enabled = False
        ctxEliminar.Enabled = False
        TextConlNombre.ReadOnly = False
        TextConlNombre.Focus()
        TextConsCtaGasto.ReadOnly = False
        TextConsCtaPasivo.ReadOnly = False
        TextNombCGasto.ReadOnly = False
        TextNombCPasivo.ReadOnly = False
        btnGasto.Enabled = True
        btnPasivo.Enabled = True
        TextPorcentaje.ReadOnly = False
        TextTipoPasivo.Visible = False
        CmbTipo.Enabled = True
        CmbTipo.Visible = True
        TextConlNombre.BackColor = ColorModi
        TextConsCtaGasto.BackColor = ColorModi
        TextConsCtaPasivo.BackColor = ColorModi
        CmbTipo.BackColor = ColorModi
        TextPorcentaje.BackColor = ColorModi
        btnGuardarG.Visible = True
    End Sub

    '------------------------------------------------
    ' Opcion de modificar detalle del menu contextual
    '------------------------------------------------

    Private Sub ctxModifiDeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModifiDeta.Click
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnImprimir.Enabled = False
        BtnGuardar.Enabled = True
        ctxModiDG.Enabled = False
        ctxEliminarM.Enabled = False
        GpDetalle1.Enabled = True
        gpDetalle.Enabled = True
        ctxEliminar.Visible = True
        'ModificaL(True)
    End Sub

    '------------------------------------------------
    ' Guarda los datos del Encabezado principal
    '------------------------------------------------
    Private Sub btnGuardarG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarG.Click
        lpara.Clear()
        If Not validetError(TextConsCtaGasto, ep1) Or Not validetError(TextConlNombre, ep1) Or Not _
        validetError(TextConsCtaPasivo, ep1) Or Not validetError(CmbTipo, ep1) Or Not validetError(TextPorcentaje, ep1) Then
            Exit Sub
        End If
        Dim tipot As String = ""
        If CmbTipo.SelectedIndex = 0 Then
            tipot = "SP"
        ElseIf CmbTipo.SelectedIndex = 1 Then
            tipot = "A"
        ElseIf CmbTipo.SelectedIndex = 2 Then
            tipot = "B"
        ElseIf CmbTipo.SelectedIndex = 3 Then
            tipot = "V"
        ElseIf CmbTipo.SelectedIndex = 4 Then
            tipot = "I"
        End If
        lpara("nombre") = TextConlNombre.Text.Trim
        lpara("tipo") = tipot
        lpara("ctagasto") = TextConsCtaGasto.Text.Trim
        lpara("ctapasivo") = TextConsCtaPasivo.Text.Trim
        lpara("por") = TextPorcentaje.Text.Trim
        lpara("pasivo") = TextConxPasivo.Text.Trim
        lpara("empresa") = empresa
        cadena = "update pasivolab1 set nombre =@nombre, tipo=@tipo, ctagasto=@ctagasto, ctapasivo=@ctapasivo, por=@por where pasivo = @pasivo and empresa =@empresa"
        EjecutarQuery(cadena, ListaParametros(lpara))
        InsertBitacora(9, 2, Me.Text)
        MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje de Sistema")
        btnLimpiar_Click(sender, e)
    End Sub

    '--------------------------------
    ' Eliminación del Pasivo Laboral
    '--------------------------------
    Private Sub ctxEliminarM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminarM.Click
        lpara.Clear()
        lpara("pasivo") = TextConxPasivo.Text.Trim
        lpara("empresa") = empresa
        If MsgBox("ESTA SEGURO QUE DESEA ELIMINAR ESTE PASIVO LABORAL", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            cadena = "delete pasivolab2 where pasivo = @pasivo and empresa=@empresa"
            EjecutarQuery(cadena, ListaParametros(lpara))
            cadena = "delete pasivolab1 where pasivo=@pasivo and empresa=@empresa"
            EjecutarQuery(cadena, ListaParametros(lpara))
            InsertBitacora(9, 4, Me.Text)
            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje de Sistema")
            btnLimpiar_Click(sender, e)
        End If
    End Sub

#End Region

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'fImp = New FrmConsultaYReporte_TarjetaR
        'fImp.Inicializa(CInt(TextConxnumero.Text))
        'fImp.TopMost = True
        'fImp.StartPosition = FormStartPosition.CenterScreen
        'fImp.ShowDialog()
    End Sub


    Private Function formato(ByVal numformato As Decimal) As String
        Return Format(numformato, "#,##0.00")
    End Function



#Region "Botones Siguientes y Atras"
    Private Sub btnSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSig.Click
        indice = indice + 1
        llenaText(indice)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub

    Private Sub btnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtr.Click
        indice = indice - 1
        llenaText(indice)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub
#End Region

    Private Sub textPorce_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.text.trim <> "" Then
            If valida_tipo_Entero(sender.text, 1) = False Then
                sender.text = ""
            End If
        End If
    End Sub

    Private Sub FrmIngreso_ManteYControlAF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub frmActual_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

#Region "CUENTA GASTO"

    Private Sub BorraCGasto(ByVal valbool As Boolean)
        TextNombCGasto.Clear()
        If valbool = True Then
            TextConsCtaGasto.Clear()
            'CampoL(TextActivo)
        End If
    End Sub

    Private Sub btnActivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGasto.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("nombre") = TextNombCGasto.Text.Trim
        lpara("empresa") = empresa
        cadena = "select cuenta,nombre from nomencla where empresa=@empresa and nombre like '%' + @nombre + '%' and operable='S' and naturaleza = 5 order by nombre"
        numFilas = llenaTabla(cadena, tbActivo, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN CUENTAS DE GASTO CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCGasto(True)
            TextConsCtaGasto.Focus()
        ElseIf numFilas = 1 Then
            BorraCGasto(True)
            filaTemp = tbActivo.Rows.Item(0)
            TextConsCtaGasto.Text() = filaTemp.Item(0)
            TextNombCGasto.Text = filaTemp.Item(1)
            'textCantidad.Focus()
            TextConsCtaPasivo.Focus()
        Else
            EnBuscaCGasto()
        End If
    End Sub

    Private Sub ValidaCGasto()
        lpara.Clear()
        lpara("cuenta") = TextConsCtaGasto.Text.Trim
        cadena = "select count (*) from nomencla where cuenta=@cuenta"
        If BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
            MsgBox("NUMERO DE CUENTA NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCGasto(True)
            TextConsCtaGasto.Focus()
            Exit Sub
        End If
        cadena = "select cuenta,nombre from nomencla where cuenta=@cuenta and operable='S' and naturaleza = 5"
        abrir_conexion(cn)
        comando = New SqlCommand(cadena, cn)
        comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
        dr = comando.ExecuteReader
        If dr.HasRows() Then
            BorraCGasto(False)
            dr.Read()
            TextNombCGasto.Text = dr.GetValue(1)
            dr.Close()
            cn.Close()
            TextConsCtaPasivo.Focus()
        Else
            MsgBox("NO ES UNA CUENTA DE GASTO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            dr.Close()
            cn.Close()
            BorraCGasto(True)
            TextConsCtaGasto.Focus()
        End If
    End Sub

    Private Sub TextCGasto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextConsCtaGasto.KeyPress, TextConxPasivo.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextActivo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextConsCtaGasto.Validated
        If TextConsCtaGasto.Text.Trim <> "" Then
            ValidaCGasto()
        Else
            BorraCGasto(False)
        End If
    End Sub

    Private Sub EnBuscaCGasto()
        fCta = New frmMuestraSoloCuentas
        fCta.TopMost = True
        fCta.inicializa(tbActivo)
        AddHandler fCta.actValor, AddressOf ActualizacionDatosCGasto
        fCta.ShowDialog()
        'BtnGuardar.Focus()
        'fAct = New frmMuestraActivo
        'fAct.TopMost = True
        'fAct.inicializa(tbActivo)
        'AddHandler fAct.actValor, AddressOf ActualizacionDatosActivo
        'fAct.StartPosition = FormStartPosition.CenterScreen
        'fAct.ShowDialog()
        'textCantidad.Focus()
        TextConsCtaPasivo.Focus()
    End Sub

    Private Sub ActualizacionDatosCGasto(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCGasto(True)
        filaTemp = tbActivo.Rows.Item(e.va2)
        TextConsCtaGasto.Text() = filaTemp.Item(0)
        TextNombCGasto.Text = filaTemp.Item(1)
    End Sub

#End Region


#Region "CUENTA PASIVO"

    Private Sub borraCPasivo(ByVal valorBool As Boolean)
        TextNombCPasivo.Clear()
        If valorBool = True Then
            TextConsCtaPasivo.Clear()
        End If
    End Sub

    Private Sub BtnUbicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasivo.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("nombre") = TextNombCPasivo.Text.Trim
        lpara("empresa") = empresa
        cadena = "select cuenta,nombre from nomencla where empresa=@empresa and nombre like '%' + @nombre + '%' and operable='S' and naturaleza in (2,3) order by nombre"
        numFilas = llenaTabla(cadena, tbUbicacion, ListaParametros(lpara))

        If numFilas = 0 Then
            MsgBox("NO EXISTEN CUENTAS DE PASIVO CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            borraCPasivo(True)
            TextConsCtaPasivo.Focus()
        ElseIf numFilas = 1 Then
            filaTemp = tbUbicacion.Rows.Item(0)
            TextConsCtaPasivo.Text() = filaTemp.Item(0)
            TextNombCPasivo.Text = filaTemp.Item(1)
            TextPorcentaje.Focus()
        Else
            EnBuscaCPasivo()
        End If
    End Sub

    Private Sub EnBuscaCPasivo()
        fCtaP = New frmMuestraSoloCuentas
        fCtaP.TopMost = True
        fCtaP.inicializa(tbUbicacion)
        AddHandler fCtaP.actValor, AddressOf ActualizacionDatosCPasivo
        fCtaP.ShowDialog()
        CmbTipo.Focus()
    End Sub

    Private Sub ActualizacionDatosCPasivo(ByVal sender As Object, ByVal e As clsActValorREvento)
        filaTemp = tbUbicacion.Rows.Item(e.va2)
        borraCPasivo(True)
        TextConsCtaPasivo.Text() = filaTemp.Item(0)
        TextNombCPasivo.Text = filaTemp.Item(1)
    End Sub

    Private Sub ValidaCPasivo()
        lpara.Clear()
        lpara("cuenta") = TextConsCtaPasivo.Text.Trim
        cadena = "select count (*) from nomencla where cuenta=@cuenta"
        If BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
            MsgBox("NUMERO DE CUENTA NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            borraCPasivo(True)
            TextConsCtaPasivo.Focus()
            Exit Sub
        End If
        cadena = "select cuenta,nombre from nomencla where cuenta=@cuenta and operable='S' and naturaleza in (2,3)"
        abrir_conexion(cn)
        comando = New SqlCommand(cadena, cn)
        comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
        dr = comando.ExecuteReader
        If dr.HasRows() Then
            dr.Read()
            TextNombCPasivo.Text = dr.GetValue(1)
            dr.Close()
            cn.Close()
            CmbTipo.Focus()
        Else
            MsgBox("NO ES UNA CUENTA DE PASIVO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            borraCPasivo(True)
            TextConsCtaPasivo.Focus()
            dr.Close()
            cn.Close()
        End If
    End Sub


    Private Sub TextUbicacion_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextConsCtaPasivo.Validated
        If TextConsCtaPasivo.Text.Trim <> "" Then
            ValidaCPasivo()
        Else
            borraCPasivo(True)
        End If
    End Sub
#End Region

    Private Sub CmbArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If CmbArticulo.SelectedIndex = 0 Then
        'gparticulo.Enabled = True
        'gpActivo.Visible = True
        'gpUtil.Visible = False
        'TextActivo.Focus()
        'ElseIf CmbArticulo.SelectedIndex = 1 Then
        'gparticulo.Enabled = True
        'gpActivo.Visible = False
        'gpUtil.Visible = True
        'TextUtil.Focus()
        'Else
        'gparticulo.Enabled = False
        'End If
    End Sub


    Private Sub ObtieneFoco_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipo.Enter, TextConsCtaGasto.Enter, TextNombCGasto.Enter, TextNombTransac.Enter, TextConsCtaPasivo.Enter, TextNombCPasivo.Enter, TextPorcentaje.Enter, TextConlNombre.Enter, TextTransac.Enter
        'controla la obtención del foco de los controles indicados
        'activa2(sender)
    End Sub

    Private Sub TextPorcentaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextPorcentaje.KeyPress
        soloNumeroDec(sender, e)
    End Sub

    Private Sub DejaFoco_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextConsCtaGasto.Leave, TextNombCGasto.Leave, TextNombTransac.Leave, TextConsCtaPasivo.Leave, TextNombCPasivo.Leave, TextPorcentaje.Leave, TextConlNombre.Leave, TextTransac.Leave, CmbTipo.Leave
        'controla la perdida del foco de los controles indicados
        'desactiva2(sender)
    End Sub

    Private Sub TextPorcentaje_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextPorcentaje.Validated
        If TextPorcentaje.Text <> "" Then
            If CDec(TextPorcentaje.Text) > 0 And CDec(TextPorcentaje.Text) <= 100 Then
                If Not valida_decimal_Presicion(TextPorcentaje, 3, 4) Then
                    TextPorcentaje.Clear()
                    TextPorcentaje.Focus()
                End If
            Else
                MsgBox("EL PORCENTAJE DEBE SER MAYOR A 0 Y MENOR O IGUAL A 100, VERIFIQUE", MsgBoxStyle.Information, "Mensaje de Sistema")
                TextPorcentaje.Clear()
                TextPorcentaje.Focus()
            End If
        End If
    End Sub

 
    
End Class
