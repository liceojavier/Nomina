<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIngContratos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngContratos))
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
        Me.ctxMenuEvento = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModiEvento = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliEvento = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirImagen = New System.Windows.Forms.OpenFileDialog()
        Me.ctxMenuSueldos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModiSueldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliSueldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ctxMenuOrigen = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEliminaCentro = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.btnOrigen = New System.Windows.Forms.Button()
        Me.btnCancelSueldo = New System.Windows.Forms.Button()
        Me.btnIngSueldo = New System.Windows.Forms.Button()
        Me.btnBuscaCodigo = New System.Windows.Forms.Button()
        Me.btnCancelEvento = New System.Windows.Forms.Button()
        Me.btnIngEvento = New System.Windows.Forms.Button()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tabDatos = New System.Windows.Forms.TabControl()
        Me.TbGeneral = New System.Windows.Forms.TabPage()
        Me.cmbTemporalidad = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipoContrato = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoEmpleado = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextHorasTotal = New System.Windows.Forms.TextBox()
        Me.Textsemanales = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbAnticipo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextTipoBase = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextHora2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextHora1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gpChofer = New System.Windows.Forms.GroupBox()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.TextObserva = New System.Windows.Forms.TextBox()
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
        Me.textCtaBanc = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cmbTipoSeguro = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbTipoPer = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tbOrigenes = New System.Windows.Forms.TabPage()
        Me.TextTotal = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextPorce = New System.Windows.Forms.TextBox()
        Me.gpCentro = New System.Windows.Forms.GroupBox()
        Me.TextNombOrigen = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextOrigen = New System.Windows.Forms.TextBox()
        Me.dgDatos = New System.Windows.Forms.DataGridView()
        Me.tbSueldo = New System.Windows.Forms.TabPage()
        Me.TextTotalSueldo = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dgSueldos = New System.Windows.Forms.DataGridView()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextValor = New System.Windows.Forms.TextBox()
        Me.cmbAfecta = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.gpTransaccion = New System.Windows.Forms.GroupBox()
        Me.textNombCodigo = New System.Windows.Forms.TextBox()
        Me.textCodigo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TabEventos = New System.Windows.Forms.TabPage()
        Me.dgEventos = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpEvento = New System.Windows.Forms.GroupBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.cmbTipoAccion = New System.Windows.Forms.ComboBox()
        Me.TextObservaEvento = New System.Windows.Forms.TextBox()
        Me.lblTipoEvento = New System.Windows.Forms.Label()
        Me.lblObserva = New System.Windows.Forms.Label()
        Me.lblAccionEvento = New System.Windows.Forms.Label()
        Me.cmbTipoEvento = New System.Windows.Forms.ComboBox()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.cmbMotivoEvento = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.TextContrato = New System.Windows.Forms.TextBox()
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaEvento = New System.Windows.Forms.DateTimePicker()
        Me.ctxMenuEvento.SuspendLayout()
        Me.ctxMenuSueldos.SuspendLayout()
        Me.ctxMenuOrigen.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.TbGeneral.SuspendLayout()
        Me.gpChofer.SuspendLayout()
        Me.tbOrigenes.SuspendLayout()
        Me.gpCentro.SuspendLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSueldo.SuspendLayout()
        CType(Me.dgSueldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpTransaccion.SuspendLayout()
        Me.TabEventos.SuspendLayout()
        CType(Me.dgEventos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.gpEvento.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        Me.gpContrato.SuspendLayout()
        Me.gpFecha.SuspendLayout()
        Me.SuspendLayout()
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
        'AbrirImagen
        '
        Me.AbrirImagen.FileName = "Cargar Imagen"
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
        Me.ctxEliminaCentro.Text = " Eliminar Centro"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 585)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1134, 24)
        Me.StatusStrip1.TabIndex = 56
        Me.StatusStrip1.Text = "stBar"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(1119, 19)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Realiza el ingreso de los contratos que son suscritos con las personas que presta" &
    "n sus servicios en calidad de dependencia."
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(36, 6)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 30)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(1032, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 30)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Almacenar registro")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(528, 10)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(60, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Empleado")
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ImageKey = "cancelar.png"
        Me.btnCancelar.ImageList = Me.ImageNuevos
        Me.btnCancelar.Location = New System.Drawing.Point(812, 15)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(60, 30)
        Me.btnCancelar.TabIndex = 100
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelar, "Cancelar")
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.ImageKey = "checkok.png"
        Me.btnIngresar.ImageList = Me.ImageNuevos
        Me.btnIngresar.Location = New System.Drawing.Point(734, 15)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(60, 30)
        Me.btnIngresar.TabIndex = 3
        Me.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngresar, "Ingresar")
        Me.btnIngresar.UseVisualStyleBackColor = False
        '
        'btnOrigen
        '
        Me.btnOrigen.BackColor = System.Drawing.SystemColors.Control
        Me.btnOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrigen.ImageKey = "buscar1.png"
        Me.btnOrigen.ImageList = Me.ImageNuevos
        Me.btnOrigen.Location = New System.Drawing.Point(486, 10)
        Me.btnOrigen.Name = "btnOrigen"
        Me.btnOrigen.Size = New System.Drawing.Size(60, 30)
        Me.btnOrigen.TabIndex = 3
        Me.btnOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnOrigen, "Centro")
        Me.btnOrigen.UseVisualStyleBackColor = False
        '
        'btnCancelSueldo
        '
        Me.btnCancelSueldo.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelSueldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelSueldo.ImageKey = "cancelar.png"
        Me.btnCancelSueldo.ImageList = Me.ImageNuevos
        Me.btnCancelSueldo.Location = New System.Drawing.Point(917, 13)
        Me.btnCancelSueldo.Name = "btnCancelSueldo"
        Me.btnCancelSueldo.Size = New System.Drawing.Size(60, 30)
        Me.btnCancelSueldo.TabIndex = 114
        Me.btnCancelSueldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelSueldo, "Cancelar")
        Me.btnCancelSueldo.UseVisualStyleBackColor = False
        '
        'btnIngSueldo
        '
        Me.btnIngSueldo.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngSueldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngSueldo.ImageKey = "checkok.png"
        Me.btnIngSueldo.ImageList = Me.ImageNuevos
        Me.btnIngSueldo.Location = New System.Drawing.Point(848, 13)
        Me.btnIngSueldo.Name = "btnIngSueldo"
        Me.btnIngSueldo.Size = New System.Drawing.Size(60, 30)
        Me.btnIngSueldo.TabIndex = 4
        Me.btnIngSueldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngSueldo, "Ingresar")
        Me.btnIngSueldo.UseVisualStyleBackColor = False
        '
        'btnBuscaCodigo
        '
        Me.btnBuscaCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscaCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaCodigo.ImageKey = "buscar1.png"
        Me.btnBuscaCodigo.ImageList = Me.ImageNuevos
        Me.btnBuscaCodigo.Location = New System.Drawing.Point(457, 12)
        Me.btnBuscaCodigo.Name = "btnBuscaCodigo"
        Me.btnBuscaCodigo.Size = New System.Drawing.Size(60, 30)
        Me.btnBuscaCodigo.TabIndex = 3
        Me.btnBuscaCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscaCodigo, "Buscar Transaccion")
        Me.btnBuscaCodigo.UseVisualStyleBackColor = False
        '
        'btnCancelEvento
        '
        Me.btnCancelEvento.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelEvento.ImageKey = "cancelar.png"
        Me.btnCancelEvento.ImageList = Me.ImageNuevos
        Me.btnCancelEvento.Location = New System.Drawing.Point(971, 45)
        Me.btnCancelEvento.Name = "btnCancelEvento"
        Me.btnCancelEvento.Size = New System.Drawing.Size(60, 30)
        Me.btnCancelEvento.TabIndex = 7
        Me.btnCancelEvento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelEvento, "Cancelar")
        Me.btnCancelEvento.UseVisualStyleBackColor = False
        '
        'btnIngEvento
        '
        Me.btnIngEvento.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngEvento.ImageKey = "checkok.png"
        Me.btnIngEvento.ImageList = Me.ImageNuevos
        Me.btnIngEvento.Location = New System.Drawing.Point(903, 45)
        Me.btnIngEvento.Name = "btnIngEvento"
        Me.btnIngEvento.Size = New System.Drawing.Size(60, 30)
        Me.btnIngEvento.TabIndex = 6
        Me.btnIngEvento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngEvento, "Ingresar")
        Me.btnIngEvento.UseVisualStyleBackColor = False
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnLimpiar)
        Me.Panel3.Controls.Add(Me.btnGuardar)
        Me.Panel3.Location = New System.Drawing.Point(2, 536)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1130, 48)
        Me.Panel3.TabIndex = 60
        '
        'tabDatos
        '
        Me.tabDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabDatos.Controls.Add(Me.TbGeneral)
        Me.tabDatos.Controls.Add(Me.tbOrigenes)
        Me.tabDatos.Controls.Add(Me.tbSueldo)
        Me.tabDatos.Controls.Add(Me.TabEventos)
        Me.tabDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDatos.Location = New System.Drawing.Point(2, 63)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectedIndex = 0
        Me.tabDatos.Size = New System.Drawing.Size(1060, 452)
        Me.tabDatos.TabIndex = 58
        '
        'TbGeneral
        '
        Me.TbGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TbGeneral.Controls.Add(Me.dtpFechaInicio)
        Me.TbGeneral.Controls.Add(Me.cmbTemporalidad)
        Me.TbGeneral.Controls.Add(Me.Label3)
        Me.TbGeneral.Controls.Add(Me.cmbTipoContrato)
        Me.TbGeneral.Controls.Add(Me.Label1)
        Me.TbGeneral.Controls.Add(Me.cmbTipoEmpleado)
        Me.TbGeneral.Controls.Add(Me.Label15)
        Me.TbGeneral.Controls.Add(Me.TextHorasTotal)
        Me.TbGeneral.Controls.Add(Me.Textsemanales)
        Me.TbGeneral.Controls.Add(Me.Label11)
        Me.TbGeneral.Controls.Add(Me.cmbAnticipo)
        Me.TbGeneral.Controls.Add(Me.Label14)
        Me.TbGeneral.Controls.Add(Me.TextTipoBase)
        Me.TbGeneral.Controls.Add(Me.Label8)
        Me.TbGeneral.Controls.Add(Me.TextHora2)
        Me.TbGeneral.Controls.Add(Me.Label7)
        Me.TbGeneral.Controls.Add(Me.TextHora1)
        Me.TbGeneral.Controls.Add(Me.Label6)
        Me.TbGeneral.Controls.Add(Me.gpChofer)
        Me.TbGeneral.Controls.Add(Me.TextObserva)
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
        Me.TbGeneral.Controls.Add(Me.textCtaBanc)
        Me.TbGeneral.Controls.Add(Me.Label32)
        Me.TbGeneral.Controls.Add(Me.cmbTipoSeguro)
        Me.TbGeneral.Controls.Add(Me.Label31)
        Me.TbGeneral.Controls.Add(Me.cmbTipoPer)
        Me.TbGeneral.Controls.Add(Me.Label30)
        Me.TbGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TbGeneral.Name = "TbGeneral"
        Me.TbGeneral.Size = New System.Drawing.Size(1052, 426)
        Me.TbGeneral.TabIndex = 3
        Me.TbGeneral.Text = "Datos generales"
        Me.TbGeneral.Visible = False
        '
        'cmbTemporalidad
        '
        Me.cmbTemporalidad.BackColor = System.Drawing.Color.White
        Me.cmbTemporalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTemporalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTemporalidad.Items.AddRange(New Object() {"DIURNA", "NOCTURNA", "MIXTA", ""})
        Me.cmbTemporalidad.Location = New System.Drawing.Point(495, 240)
        Me.cmbTemporalidad.Name = "cmbTemporalidad"
        Me.cmbTemporalidad.Size = New System.Drawing.Size(238, 21)
        Me.cmbTemporalidad.TabIndex = 110
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(379, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Temporalidad:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoContrato
        '
        Me.cmbTipoContrato.BackColor = System.Drawing.Color.White
        Me.cmbTipoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoContrato.Items.AddRange(New Object() {"DIURNA", "NOCTURNA", "MIXTA", ""})
        Me.cmbTipoContrato.Location = New System.Drawing.Point(125, 240)
        Me.cmbTipoContrato.Name = "cmbTipoContrato"
        Me.cmbTipoContrato.Size = New System.Drawing.Size(238, 21)
        Me.cmbTipoContrato.TabIndex = 108
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 240)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "Tipo de Contrato:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoEmpleado
        '
        Me.cmbTipoEmpleado.BackColor = System.Drawing.Color.White
        Me.cmbTipoEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoEmpleado.Location = New System.Drawing.Point(809, 204)
        Me.cmbTipoEmpleado.Name = "cmbTipoEmpleado"
        Me.cmbTipoEmpleado.Size = New System.Drawing.Size(209, 21)
        Me.cmbTipoEmpleado.TabIndex = 106
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(629, 204)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(174, 13)
        Me.Label15.TabIndex = 107
        Me.Label15.Text = "Tipo de empleado para evaluación:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextHorasTotal
        '
        Me.TextHorasTotal.BackColor = System.Drawing.Color.White
        Me.TextHorasTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextHorasTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextHorasTotal.Location = New System.Drawing.Point(410, 169)
        Me.TextHorasTotal.MaxLength = 5
        Me.TextHorasTotal.Name = "TextHorasTotal"
        Me.TextHorasTotal.Size = New System.Drawing.Size(37, 20)
        Me.TextHorasTotal.TabIndex = 14
        '
        'Textsemanales
        '
        Me.Textsemanales.BackColor = System.Drawing.Color.White
        Me.Textsemanales.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Textsemanales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textsemanales.Location = New System.Drawing.Point(590, 130)
        Me.Textsemanales.MaxLength = 6
        Me.Textsemanales.Name = "Textsemanales"
        Me.Textsemanales.Size = New System.Drawing.Size(37, 20)
        Me.Textsemanales.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(478, 132)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 13)
        Me.Label11.TabIndex = 105
        Me.Label11.Text = "Horas a la semana:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAnticipo
        '
        Me.cmbAnticipo.BackColor = System.Drawing.Color.White
        Me.cmbAnticipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAnticipo.Items.AddRange(New Object() {"S", "N", ""})
        Me.cmbAnticipo.Location = New System.Drawing.Point(725, 93)
        Me.cmbAnticipo.Name = "cmbAnticipo"
        Me.cmbAnticipo.Size = New System.Drawing.Size(50, 21)
        Me.cmbAnticipo.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(674, 96)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 104
        Me.Label14.Text = "Anticipo:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextTipoBase
        '
        Me.TextTipoBase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextTipoBase.BackColor = System.Drawing.Color.White
        Me.TextTipoBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoBase.Location = New System.Drawing.Point(783, 56)
        Me.TextTipoBase.MaxLength = 15
        Me.TextTipoBase.Name = "TextTipoBase"
        Me.TextTipoBase.ReadOnly = True
        Me.TextTipoBase.Size = New System.Drawing.Size(147, 20)
        Me.TextTipoBase.TabIndex = 4
        Me.TextTipoBase.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(324, 172)
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
        Me.TextHora2.Location = New System.Drawing.Point(274, 167)
        Me.TextHora2.Mask = "##:##"
        Me.TextHora2.Name = "TextHora2"
        Me.TextHora2.Size = New System.Drawing.Size(40, 20)
        Me.TextHora2.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(186, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "Hora de salida:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextHora1
        '
        Me.TextHora1.BackColor = System.Drawing.Color.White
        Me.TextHora1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextHora1.Location = New System.Drawing.Point(125, 168)
        Me.TextHora1.Mask = "##:##"
        Me.TextHora1.Name = "TextHora1"
        Me.TextHora1.Size = New System.Drawing.Size(40, 20)
        Me.TextHora1.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Hora de inicio:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpChofer
        '
        Me.gpChofer.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpChofer.Controls.Add(Me.btnEmpleado)
        Me.gpChofer.Controls.Add(Me.textNombreEmple)
        Me.gpChofer.Controls.Add(Me.textEmpleado)
        Me.gpChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChofer.Location = New System.Drawing.Point(8, 8)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(644, 45)
        Me.gpChofer.TabIndex = 1
        Me.gpChofer.TabStop = False
        Me.gpChofer.Text = "Empleado"
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.Location = New System.Drawing.Point(74, 16)
        Me.textNombreEmple.MaxLength = 40
        Me.textNombreEmple.Name = "textNombreEmple"
        Me.textNombreEmple.Size = New System.Drawing.Size(448, 20)
        Me.textNombreEmple.TabIndex = 2
        '
        'textEmpleado
        '
        Me.textEmpleado.BackColor = System.Drawing.Color.White
        Me.textEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textEmpleado.Location = New System.Drawing.Point(12, 16)
        Me.textEmpleado.MaxLength = 6
        Me.textEmpleado.Name = "textEmpleado"
        Me.textEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textEmpleado.TabIndex = 1
        '
        'TextObserva
        '
        Me.TextObserva.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextObserva.BackColor = System.Drawing.Color.White
        Me.TextObserva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextObserva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextObserva.Location = New System.Drawing.Point(125, 204)
        Me.TextObserva.MaxLength = 60
        Me.TextObserva.Name = "TextObserva"
        Me.TextObserva.Size = New System.Drawing.Size(486, 20)
        Me.TextObserva.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 204)
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
        Me.cmbFormaPago.Location = New System.Drawing.Point(871, 92)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(147, 21)
        Me.cmbFormaPago.TabIndex = 8
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(784, 97)
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
        Me.cmbModPago.Location = New System.Drawing.Point(454, 93)
        Me.cmbModPago.Name = "cmbModPago"
        Me.cmbModPago.Size = New System.Drawing.Size(211, 21)
        Me.cmbModPago.TabIndex = 6
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(343, 96)
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
        Me.cmbJornada.Items.AddRange(New Object() {"DIURNA", "NOCTURNA", "MIXTA", ""})
        Me.cmbJornada.Location = New System.Drawing.Point(299, 129)
        Me.cmbJornada.Name = "cmbJornada"
        Me.cmbJornada.Size = New System.Drawing.Size(164, 21)
        Me.cmbJornada.TabIndex = 11
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(242, 132)
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
        Me.Label44.Location = New System.Drawing.Point(703, 59)
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
        Me.cmbPuesto.Location = New System.Drawing.Point(127, 93)
        Me.cmbPuesto.Name = "cmbPuesto"
        Me.cmbPuesto.Size = New System.Drawing.Size(210, 21)
        Me.cmbPuesto.TabIndex = 5
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(9, 96)
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
        Me.Label18.Location = New System.Drawing.Point(772, 136)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 13)
        Me.Label18.TabIndex = 66
        Me.Label18.Text = "Cuenta bancaria:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textCtaBanc
        '
        Me.textCtaBanc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textCtaBanc.BackColor = System.Drawing.Color.White
        Me.textCtaBanc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textCtaBanc.Location = New System.Drawing.Point(871, 132)
        Me.textCtaBanc.MaxLength = 10
        Me.textCtaBanc.Name = "textCtaBanc"
        Me.textCtaBanc.Size = New System.Drawing.Size(147, 20)
        Me.textCtaBanc.TabIndex = 9
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(9, 133)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(82, 13)
        Me.Label32.TabIndex = 21
        Me.Label32.Text = "Fecha de inicio:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoSeguro
        '
        Me.cmbTipoSeguro.BackColor = System.Drawing.Color.White
        Me.cmbTipoSeguro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoSeguro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoSeguro.Location = New System.Drawing.Point(127, 56)
        Me.cmbTipoSeguro.Name = "cmbTipoSeguro"
        Me.cmbTipoSeguro.Size = New System.Drawing.Size(210, 21)
        Me.cmbTipoSeguro.TabIndex = 2
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(8, 60)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(111, 13)
        Me.Label31.TabIndex = 14
        Me.Label31.Text = "Tipo de seguro social:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoPer
        '
        Me.cmbTipoPer.BackColor = System.Drawing.Color.White
        Me.cmbTipoPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPer.Location = New System.Drawing.Point(454, 57)
        Me.cmbTipoPer.Name = "cmbTipoPer"
        Me.cmbTipoPer.Size = New System.Drawing.Size(211, 21)
        Me.cmbTipoPer.TabIndex = 3
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(352, 60)
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
        Me.tbOrigenes.Controls.Add(Me.btnIngresar)
        Me.tbOrigenes.Controls.Add(Me.Label10)
        Me.tbOrigenes.Controls.Add(Me.TextPorce)
        Me.tbOrigenes.Controls.Add(Me.gpCentro)
        Me.tbOrigenes.Controls.Add(Me.dgDatos)
        Me.tbOrigenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbOrigenes.Location = New System.Drawing.Point(4, 22)
        Me.tbOrigenes.Name = "tbOrigenes"
        Me.tbOrigenes.Size = New System.Drawing.Size(1052, 426)
        Me.tbOrigenes.TabIndex = 5
        Me.tbOrigenes.Text = "Ingreso de centros de costo"
        Me.tbOrigenes.Visible = False
        '
        'TextTotal
        '
        Me.TextTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextTotal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextTotal.BackColor = System.Drawing.Color.White
        Me.TextTotal.Font = New System.Drawing.Font("Courier New", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotal.ForeColor = System.Drawing.Color.Red
        Me.TextTotal.Location = New System.Drawing.Point(902, 384)
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
        Me.Label12.Location = New System.Drawing.Point(834, 388)
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
        Me.Label10.Location = New System.Drawing.Point(570, 24)
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
        Me.TextPorce.Location = New System.Drawing.Point(637, 20)
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
        Me.gpCentro.Size = New System.Drawing.Size(556, 46)
        Me.gpCentro.TabIndex = 1
        Me.gpCentro.TabStop = False
        Me.gpCentro.Text = "Centro de costo"
        '
        'TextNombOrigen
        '
        Me.TextNombOrigen.BackColor = System.Drawing.Color.White
        Me.TextNombOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombOrigen.Location = New System.Drawing.Point(139, 18)
        Me.TextNombOrigen.MaxLength = 40
        Me.TextNombOrigen.Name = "TextNombOrigen"
        Me.TextNombOrigen.Size = New System.Drawing.Size(320, 20)
        Me.TextNombOrigen.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 21)
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
        Me.TextOrigen.Location = New System.Drawing.Point(12, 18)
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
        Me.dgDatos.Size = New System.Drawing.Size(1035, 320)
        Me.dgDatos.TabIndex = 65
        '
        'tbSueldo
        '
        Me.tbSueldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tbSueldo.Controls.Add(Me.TextTotalSueldo)
        Me.tbSueldo.Controls.Add(Me.Label25)
        Me.tbSueldo.Controls.Add(Me.dgSueldos)
        Me.tbSueldo.Controls.Add(Me.btnCancelSueldo)
        Me.tbSueldo.Controls.Add(Me.btnIngSueldo)
        Me.tbSueldo.Controls.Add(Me.Label19)
        Me.tbSueldo.Controls.Add(Me.TextValor)
        Me.tbSueldo.Controls.Add(Me.cmbAfecta)
        Me.tbSueldo.Controls.Add(Me.Label16)
        Me.tbSueldo.Controls.Add(Me.gpTransaccion)
        Me.tbSueldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSueldo.Location = New System.Drawing.Point(4, 22)
        Me.tbSueldo.Name = "tbSueldo"
        Me.tbSueldo.Size = New System.Drawing.Size(1052, 426)
        Me.tbSueldo.TabIndex = 6
        Me.tbSueldo.Text = "Sueldo"
        '
        'TextTotalSueldo
        '
        Me.TextTotalSueldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextTotalSueldo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextTotalSueldo.BackColor = System.Drawing.Color.White
        Me.TextTotalSueldo.Font = New System.Drawing.Font("Courier New", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalSueldo.ForeColor = System.Drawing.Color.Red
        Me.TextTotalSueldo.Location = New System.Drawing.Point(866, 382)
        Me.TextTotalSueldo.MaxLength = 3
        Me.TextTotalSueldo.Name = "TextTotalSueldo"
        Me.TextTotalSueldo.Size = New System.Drawing.Size(177, 35)
        Me.TextTotalSueldo.TabIndex = 117
        Me.TextTotalSueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(798, 386)
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
        Me.dgSueldos.Location = New System.Drawing.Point(8, 57)
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
        Me.dgSueldos.Size = New System.Drawing.Size(1035, 319)
        Me.dgSueldos.TabIndex = 115
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(691, 24)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 112
        Me.Label19.Text = "Valor:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextValor
        '
        Me.TextValor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextValor.BackColor = System.Drawing.Color.White
        Me.TextValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValor.Location = New System.Drawing.Point(735, 20)
        Me.TextValor.MaxLength = 11
        Me.TextValor.Name = "TextValor"
        Me.TextValor.Size = New System.Drawing.Size(105, 20)
        Me.TextValor.TabIndex = 3
        '
        'cmbAfecta
        '
        Me.cmbAfecta.BackColor = System.Drawing.Color.White
        Me.cmbAfecta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAfecta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAfecta.Items.AddRange(New Object() {"S", "N", ""})
        Me.cmbAfecta.Location = New System.Drawing.Point(624, 21)
        Me.cmbAfecta.Name = "cmbAfecta"
        Me.cmbAfecta.Size = New System.Drawing.Size(41, 21)
        Me.cmbAfecta.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(548, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 108
        Me.Label16.Text = "Afecta días:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpTransaccion
        '
        Me.gpTransaccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpTransaccion.Controls.Add(Me.btnBuscaCodigo)
        Me.gpTransaccion.Controls.Add(Me.textNombCodigo)
        Me.gpTransaccion.Controls.Add(Me.textCodigo)
        Me.gpTransaccion.Controls.Add(Me.Label13)
        Me.gpTransaccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTransaccion.Location = New System.Drawing.Point(8, 4)
        Me.gpTransaccion.Name = "gpTransaccion"
        Me.gpTransaccion.Size = New System.Drawing.Size(533, 47)
        Me.gpTransaccion.TabIndex = 1
        Me.gpTransaccion.TabStop = False
        Me.gpTransaccion.Text = "Transacción de nómina"
        '
        'textNombCodigo
        '
        Me.textNombCodigo.BackColor = System.Drawing.Color.White
        Me.textNombCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombCodigo.Location = New System.Drawing.Point(126, 19)
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
        Me.textCodigo.Location = New System.Drawing.Point(11, 18)
        Me.textCodigo.MaxLength = 5
        Me.textCodigo.Name = "textCodigo"
        Me.textCodigo.Size = New System.Drawing.Size(48, 20)
        Me.textCodigo.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(67, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Nombre:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabEventos
        '
        Me.TabEventos.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TabEventos.Controls.Add(Me.dgEventos)
        Me.TabEventos.Controls.Add(Me.Panel1)
        Me.TabEventos.Location = New System.Drawing.Point(4, 22)
        Me.TabEventos.Name = "TabEventos"
        Me.TabEventos.Size = New System.Drawing.Size(1052, 426)
        Me.TabEventos.TabIndex = 7
        Me.TabEventos.Text = "Eventos"
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
        Me.dgEventos.Location = New System.Drawing.Point(8, 99)
        Me.dgEventos.MultiSelect = False
        Me.dgEventos.Name = "dgEventos"
        Me.dgEventos.ReadOnly = True
        Me.dgEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgEventos.Size = New System.Drawing.Size(1036, 318)
        Me.dgEventos.TabIndex = 121
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancelEvento)
        Me.Panel1.Controls.Add(Me.gpEvento)
        Me.Panel1.Controls.Add(Me.btnIngEvento)
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1041, 77)
        Me.Panel1.TabIndex = 120
        '
        'gpEvento
        '
        Me.gpEvento.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpEvento.Controls.Add(Me.dtpFechaEvento)
        Me.gpEvento.Controls.Add(Me.lblFecha)
        Me.gpEvento.Controls.Add(Me.cmbTipoAccion)
        Me.gpEvento.Controls.Add(Me.TextObservaEvento)
        Me.gpEvento.Controls.Add(Me.lblTipoEvento)
        Me.gpEvento.Controls.Add(Me.lblObserva)
        Me.gpEvento.Controls.Add(Me.lblAccionEvento)
        Me.gpEvento.Controls.Add(Me.cmbTipoEvento)
        Me.gpEvento.Controls.Add(Me.lblMotivo)
        Me.gpEvento.Controls.Add(Me.cmbMotivoEvento)
        Me.gpEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEvento.Location = New System.Drawing.Point(6, 5)
        Me.gpEvento.Name = "gpEvento"
        Me.gpEvento.Size = New System.Drawing.Size(891, 71)
        Me.gpEvento.TabIndex = 1
        Me.gpEvento.TabStop = False
        Me.gpEvento.Text = "Evento"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(17, 19)
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
        Me.cmbTipoAccion.Location = New System.Drawing.Point(729, 16)
        Me.cmbTipoAccion.Name = "cmbTipoAccion"
        Me.cmbTipoAccion.Size = New System.Drawing.Size(142, 21)
        Me.cmbTipoAccion.TabIndex = 4
        '
        'TextObservaEvento
        '
        Me.TextObservaEvento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextObservaEvento.BackColor = System.Drawing.Color.White
        Me.TextObservaEvento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextObservaEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextObservaEvento.Location = New System.Drawing.Point(110, 45)
        Me.TextObservaEvento.MaxLength = 75
        Me.TextObservaEvento.Name = "TextObservaEvento"
        Me.TextObservaEvento.Size = New System.Drawing.Size(528, 20)
        Me.TextObservaEvento.TabIndex = 5
        '
        'lblTipoEvento
        '
        Me.lblTipoEvento.AutoSize = True
        Me.lblTipoEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoEvento.Location = New System.Drawing.Point(191, 19)
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
        Me.lblObserva.Location = New System.Drawing.Point(17, 47)
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
        Me.lblAccionEvento.Location = New System.Drawing.Point(651, 20)
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
        Me.cmbTipoEvento.Location = New System.Drawing.Point(272, 15)
        Me.cmbTipoEvento.Name = "cmbTipoEvento"
        Me.cmbTipoEvento.Size = New System.Drawing.Size(145, 21)
        Me.cmbTipoEvento.TabIndex = 2
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotivo.Location = New System.Drawing.Point(425, 18)
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
        Me.cmbMotivoEvento.Location = New System.Drawing.Point(479, 15)
        Me.cmbMotivoEvento.Name = "cmbMotivoEvento"
        Me.cmbMotivoEvento.Size = New System.Drawing.Size(165, 21)
        Me.cmbMotivoEvento.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel2.Controls.Add(Me.gpEmpresa)
        Me.Panel2.Controls.Add(Me.gpContrato)
        Me.Panel2.Controls.Add(Me.gpFecha)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1134, 57)
        Me.Panel2.TabIndex = 59
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(201, 4)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(437, 41)
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
        'gpContrato
        '
        Me.gpContrato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpContrato.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpContrato.Controls.Add(Me.TextContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.ForeColor = System.Drawing.Color.White
        Me.gpContrato.Location = New System.Drawing.Point(891, 4)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(91, 42)
        Me.gpContrato.TabIndex = 1
        Me.gpContrato.TabStop = False
        Me.gpContrato.Text = "Contrato"
        '
        'TextContrato
        '
        Me.TextContrato.BackColor = System.Drawing.Color.White
        Me.TextContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextContrato.ForeColor = System.Drawing.Color.Red
        Me.TextContrato.Location = New System.Drawing.Point(6, 16)
        Me.TextContrato.MaxLength = 9
        Me.TextContrato.Name = "TextContrato"
        Me.TextContrato.ReadOnly = True
        Me.TextContrato.Size = New System.Drawing.Size(79, 20)
        Me.TextContrato.TabIndex = 1
        Me.TextContrato.TabStop = False
        '
        'gpFecha
        '
        Me.gpFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpFecha.Controls.Add(Me.dtpFecha)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.ForeColor = System.Drawing.Color.White
        Me.gpFecha.Location = New System.Drawing.Point(1007, 5)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(115, 41)
        Me.gpFecha.TabIndex = 2
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(8, 15)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(101, 20)
        Me.dtpFecha.TabIndex = 3
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(127, 130)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaInicio.TabIndex = 4
        '
        'dtpFechaEvento
        '
        Me.dtpFechaEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaEvento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEvento.Location = New System.Drawing.Point(77, 15)
        Me.dtpFechaEvento.Name = "dtpFechaEvento"
        Me.dtpFechaEvento.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaEvento.TabIndex = 8
        '
        'frmIngContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 609)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tabDatos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIngContratos"
        Me.Text = "Ingreso de Contratos"
        Me.ctxMenuEvento.ResumeLayout(False)
        Me.ctxMenuSueldos.ResumeLayout(False)
        Me.ctxMenuOrigen.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.TbGeneral.ResumeLayout(False)
        Me.TbGeneral.PerformLayout()
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        Me.tbOrigenes.ResumeLayout(False)
        Me.tbOrigenes.PerformLayout()
        Me.gpCentro.ResumeLayout(False)
        Me.gpCentro.PerformLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSueldo.ResumeLayout(False)
        Me.tbSueldo.PerformLayout()
        CType(Me.dgSueldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpTransaccion.ResumeLayout(False)
        Me.gpTransaccion.PerformLayout()
        Me.TabEventos.ResumeLayout(False)
        CType(Me.dgEventos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.gpEvento.ResumeLayout(False)
        Me.gpEvento.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpFecha.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ctxMenuEvento As ContextMenuStrip
    Friend WithEvents ctxModiEvento As ToolStripMenuItem
    Friend WithEvents ctxEliEvento As ToolStripMenuItem
    Friend WithEvents AbrirImagen As OpenFileDialog
    Friend WithEvents ctxMenuSueldos As ContextMenuStrip
    Friend WithEvents ctxModiSueldo As ToolStripMenuItem
    Friend WithEvents ctxEliSueldo As ToolStripMenuItem
    Friend WithEvents ImageNuevos As ImageList
    Friend WithEvents ctxMenuOrigen As ContextMenuStrip
    Friend WithEvents ctxEliminaCentro As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ep1 As ErrorProvider
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents tabDatos As TabControl
    Friend WithEvents TbGeneral As TabPage
    Friend WithEvents cmbTipoEmpleado As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TextHorasTotal As TextBox
    Friend WithEvents Textsemanales As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbAnticipo As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextTipoBase As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextHora2 As MaskedTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextHora1 As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents gpChofer As GroupBox
    Friend WithEvents btnEmpleado As Button
    Friend WithEvents textNombreEmple As TextBox
    Friend WithEvents textEmpleado As TextBox
    Friend WithEvents TextObserva As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbFormaPago As ComboBox
    Friend WithEvents Label50 As Label
    Friend WithEvents cmbModPago As ComboBox
    Friend WithEvents Label36 As Label
    Friend WithEvents cmbJornada As ComboBox
    Friend WithEvents Label45 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents cmbPuesto As ComboBox
    Friend WithEvents Label42 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents textCtaBanc As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents cmbTipoSeguro As ComboBox
    Friend WithEvents Label31 As Label
    Friend WithEvents cmbTipoPer As ComboBox
    Friend WithEvents Label30 As Label
    Friend WithEvents tbOrigenes As TabPage
    Friend WithEvents btnCancelar As Button
    Friend WithEvents TextTotal As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnIngresar As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents TextPorce As TextBox
    Friend WithEvents gpCentro As GroupBox
    Friend WithEvents btnOrigen As Button
    Friend WithEvents TextNombOrigen As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextOrigen As TextBox
    Friend WithEvents dgDatos As DataGridView
    Friend WithEvents tbSueldo As TabPage
    Friend WithEvents TextTotalSueldo As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents dgSueldos As DataGridView
    Friend WithEvents btnCancelSueldo As Button
    Friend WithEvents btnIngSueldo As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents TextValor As TextBox
    Friend WithEvents cmbAfecta As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents gpTransaccion As GroupBox
    Friend WithEvents btnBuscaCodigo As Button
    Friend WithEvents textNombCodigo As TextBox
    Friend WithEvents textCodigo As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TabEventos As TabPage
    Friend WithEvents dgEventos As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCancelEvento As Button
    Friend WithEvents gpEvento As GroupBox
    Friend WithEvents lblFecha As Label
    Friend WithEvents cmbTipoAccion As ComboBox
    Friend WithEvents TextObservaEvento As TextBox
    Friend WithEvents lblTipoEvento As Label
    Friend WithEvents lblObserva As Label
    Friend WithEvents lblAccionEvento As Label
    Friend WithEvents cmbTipoEvento As ComboBox
    Friend WithEvents lblMotivo As Label
    Friend WithEvents cmbMotivoEvento As ComboBox
    Friend WithEvents btnIngEvento As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents gpEmpresa As GroupBox
    Friend WithEvents TextNombEmpresa As TextBox
    Friend WithEvents gpContrato As GroupBox
    Friend WithEvents TextContrato As TextBox
    Friend WithEvents gpFecha As GroupBox
    Friend WithEvents cmbTemporalidad As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTipoContrato As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents dtpFechaEvento As DateTimePicker
End Class
