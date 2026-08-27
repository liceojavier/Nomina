<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvaluacionAsignacion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEvaluacionAsignacion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.gpEmpleado = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.txtNomEmpleado = New System.Windows.Forms.TextBox()
        Me.txtCodEmpleado = New System.Windows.Forms.TextBox()
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.txtContraEmpleado = New System.Windows.Forms.TextBox()
        Me.gpEvaluador = New System.Windows.Forms.GroupBox()
        Me.btnEvaluador = New System.Windows.Forms.Button()
        Me.txtNombreEva = New System.Windows.Forms.TextBox()
        Me.txtCodigoEva = New System.Windows.Forms.TextBox()
        Me.gpContratoEva = New System.Windows.Forms.GroupBox()
        Me.btnContratoEva = New System.Windows.Forms.Button()
        Me.txtContratoEva = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnTipoEvaluacion = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.btnLimpiar2 = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gpCiclo = New System.Windows.Forms.GroupBox()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.gpTipoEvaluacion = New System.Windows.Forms.GroupBox()
        Me.txtNombreTE = New System.Windows.Forms.TextBox()
        Me.txtCodigoTE = New System.Windows.Forms.TextBox()
        Me.dgDatos = New System.Windows.Forms.DataGridView()
        Me.CorrelativoDgvTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodDgvTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreDgvTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpleadoDgvCC = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ContratoDgvTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EvaluadorDgvCC = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ContratoEvaDgvTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CicloDgvTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipotestDgvTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnDetalle = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnMigrar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gpEmpleado.SuspendLayout()
        Me.gpContrato.SuspendLayout()
        Me.gpEvaluador.SuspendLayout()
        Me.gpContratoEva.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ctxMenu.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpCiclo.SuspendLayout()
        Me.gpTipoEvaluacion.SuspendLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDetalle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(1052, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 30)
        Me.btnLimpiar.TabIndex = 64
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
        Me.btnLimpiar.UseVisualStyleBackColor = False
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
        'gpEmpleado
        '
        Me.gpEmpleado.BackColor = System.Drawing.Color.AliceBlue
        Me.gpEmpleado.Controls.Add(Me.btnEmpleado)
        Me.gpEmpleado.Controls.Add(Me.txtNomEmpleado)
        Me.gpEmpleado.Controls.Add(Me.txtCodEmpleado)
        Me.gpEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpleado.Location = New System.Drawing.Point(12, 5)
        Me.gpEmpleado.Name = "gpEmpleado"
        Me.gpEmpleado.Size = New System.Drawing.Size(622, 40)
        Me.gpEmpleado.TabIndex = 65
        Me.gpEmpleado.TabStop = False
        Me.gpEmpleado.Text = "Empleado"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(533, 8)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(60, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Empleado")
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'txtNomEmpleado
        '
        Me.txtNomEmpleado.BackColor = System.Drawing.Color.White
        Me.txtNomEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomEmpleado.Location = New System.Drawing.Point(66, 16)
        Me.txtNomEmpleado.MaxLength = 40
        Me.txtNomEmpleado.Name = "txtNomEmpleado"
        Me.txtNomEmpleado.Size = New System.Drawing.Size(448, 20)
        Me.txtNomEmpleado.TabIndex = 2
        '
        'txtCodEmpleado
        '
        Me.txtCodEmpleado.BackColor = System.Drawing.Color.White
        Me.txtCodEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEmpleado.Location = New System.Drawing.Point(6, 16)
        Me.txtCodEmpleado.MaxLength = 6
        Me.txtCodEmpleado.Name = "txtCodEmpleado"
        Me.txtCodEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.txtCodEmpleado.TabIndex = 1
        '
        'gpContrato
        '
        Me.gpContrato.BackColor = System.Drawing.Color.AliceBlue
        Me.gpContrato.Controls.Add(Me.btnContrato)
        Me.gpContrato.Controls.Add(Me.txtContraEmpleado)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.Location = New System.Drawing.Point(637, 5)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(122, 40)
        Me.gpContrato.TabIndex = 66
        Me.gpContrato.TabStop = False
        Me.gpContrato.Text = "Contrato"
        '
        'btnContrato
        '
        Me.btnContrato.BackColor = System.Drawing.SystemColors.Control
        Me.btnContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContrato.ImageKey = "buscar2.png"
        Me.btnContrato.ImageList = Me.ImageNuevos
        Me.btnContrato.Location = New System.Drawing.Point(76, 7)
        Me.btnContrato.Name = "btnContrato"
        Me.btnContrato.Size = New System.Drawing.Size(40, 30)
        Me.btnContrato.TabIndex = 16
        Me.btnContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnContrato.UseVisualStyleBackColor = False
        '
        'txtContraEmpleado
        '
        Me.txtContraEmpleado.BackColor = System.Drawing.Color.White
        Me.txtContraEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContraEmpleado.ForeColor = System.Drawing.Color.Red
        Me.txtContraEmpleado.Location = New System.Drawing.Point(10, 15)
        Me.txtContraEmpleado.MaxLength = 4
        Me.txtContraEmpleado.Name = "txtContraEmpleado"
        Me.txtContraEmpleado.Size = New System.Drawing.Size(63, 20)
        Me.txtContraEmpleado.TabIndex = 1
        Me.txtContraEmpleado.TabStop = False
        '
        'gpEvaluador
        '
        Me.gpEvaluador.BackColor = System.Drawing.Color.AliceBlue
        Me.gpEvaluador.Controls.Add(Me.btnEvaluador)
        Me.gpEvaluador.Controls.Add(Me.txtNombreEva)
        Me.gpEvaluador.Controls.Add(Me.txtCodigoEva)
        Me.gpEvaluador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEvaluador.Location = New System.Drawing.Point(12, 46)
        Me.gpEvaluador.Name = "gpEvaluador"
        Me.gpEvaluador.Size = New System.Drawing.Size(622, 40)
        Me.gpEvaluador.TabIndex = 66
        Me.gpEvaluador.TabStop = False
        Me.gpEvaluador.Text = "Evaluador"
        '
        'btnEvaluador
        '
        Me.btnEvaluador.BackColor = System.Drawing.SystemColors.Control
        Me.btnEvaluador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEvaluador.ImageKey = "usuario.png"
        Me.btnEvaluador.ImageList = Me.ImageNuevos
        Me.btnEvaluador.Location = New System.Drawing.Point(533, 8)
        Me.btnEvaluador.Name = "btnEvaluador"
        Me.btnEvaluador.Size = New System.Drawing.Size(60, 30)
        Me.btnEvaluador.TabIndex = 3
        Me.btnEvaluador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEvaluador, "Empleado")
        Me.btnEvaluador.UseVisualStyleBackColor = False
        '
        'txtNombreEva
        '
        Me.txtNombreEva.BackColor = System.Drawing.Color.White
        Me.txtNombreEva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreEva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreEva.Location = New System.Drawing.Point(66, 16)
        Me.txtNombreEva.MaxLength = 40
        Me.txtNombreEva.Name = "txtNombreEva"
        Me.txtNombreEva.Size = New System.Drawing.Size(448, 20)
        Me.txtNombreEva.TabIndex = 2
        '
        'txtCodigoEva
        '
        Me.txtCodigoEva.BackColor = System.Drawing.Color.White
        Me.txtCodigoEva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoEva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoEva.Location = New System.Drawing.Point(6, 16)
        Me.txtCodigoEva.MaxLength = 6
        Me.txtCodigoEva.Name = "txtCodigoEva"
        Me.txtCodigoEva.Size = New System.Drawing.Size(56, 20)
        Me.txtCodigoEva.TabIndex = 1
        '
        'gpContratoEva
        '
        Me.gpContratoEva.BackColor = System.Drawing.Color.AliceBlue
        Me.gpContratoEva.Controls.Add(Me.btnContratoEva)
        Me.gpContratoEva.Controls.Add(Me.txtContratoEva)
        Me.gpContratoEva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContratoEva.Location = New System.Drawing.Point(637, 44)
        Me.gpContratoEva.Name = "gpContratoEva"
        Me.gpContratoEva.Size = New System.Drawing.Size(122, 40)
        Me.gpContratoEva.TabIndex = 67
        Me.gpContratoEva.TabStop = False
        Me.gpContratoEva.Text = "Contrato"
        '
        'btnContratoEva
        '
        Me.btnContratoEva.BackColor = System.Drawing.SystemColors.Control
        Me.btnContratoEva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContratoEva.ImageKey = "buscar2.png"
        Me.btnContratoEva.ImageList = Me.ImageNuevos
        Me.btnContratoEva.Location = New System.Drawing.Point(76, 8)
        Me.btnContratoEva.Name = "btnContratoEva"
        Me.btnContratoEva.Size = New System.Drawing.Size(40, 30)
        Me.btnContratoEva.TabIndex = 16
        Me.btnContratoEva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnContratoEva.UseVisualStyleBackColor = False
        '
        'txtContratoEva
        '
        Me.txtContratoEva.BackColor = System.Drawing.Color.White
        Me.txtContratoEva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContratoEva.ForeColor = System.Drawing.Color.Red
        Me.txtContratoEva.Location = New System.Drawing.Point(10, 15)
        Me.txtContratoEva.MaxLength = 4
        Me.txtContratoEva.Name = "txtContratoEva"
        Me.txtContratoEva.Size = New System.Drawing.Size(63, 20)
        Me.txtContratoEva.TabIndex = 1
        Me.txtContratoEva.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 581)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1130, 24)
        Me.StatusStrip1.TabIndex = 71
        Me.StatusStrip1.Text = "stBar"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(1115, 19)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Click derecho sobre la tabla para activar opción de: agregar,  modificar y elimin" &
    "ar."
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnTipoEvaluacion
        '
        Me.btnTipoEvaluacion.BackColor = System.Drawing.SystemColors.Control
        Me.btnTipoEvaluacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTipoEvaluacion.ImageKey = "buscar1.png"
        Me.btnTipoEvaluacion.ImageList = Me.ImageNuevos
        Me.btnTipoEvaluacion.Location = New System.Drawing.Point(533, 7)
        Me.btnTipoEvaluacion.Name = "btnTipoEvaluacion"
        Me.btnTipoEvaluacion.Size = New System.Drawing.Size(60, 30)
        Me.btnTipoEvaluacion.TabIndex = 3
        Me.btnTipoEvaluacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnTipoEvaluacion, "Tipo de Evaluacion")
        Me.btnTipoEvaluacion.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(737, 55)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 30)
        Me.btnGuardar.TabIndex = 72
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Guardar")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnAsignar
        '
        Me.btnAsignar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsignar.ImageKey = "checkok.png"
        Me.btnAsignar.ImageList = Me.ImageNuevos
        Me.btnAsignar.Location = New System.Drawing.Point(660, 56)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(60, 30)
        Me.btnAsignar.TabIndex = 74
        Me.btnAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAsignar, "Seleccionar")
        Me.btnAsignar.UseVisualStyleBackColor = False
        '
        'btnLimpiar2
        '
        Me.btnLimpiar2.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar2.ImageKey = "cancelar.png"
        Me.btnLimpiar2.ImageList = Me.ImageNuevos
        Me.btnLimpiar2.Location = New System.Drawing.Point(838, 52)
        Me.btnLimpiar2.Name = "btnLimpiar2"
        Me.btnLimpiar2.Size = New System.Drawing.Size(60, 30)
        Me.btnLimpiar2.TabIndex = 75
        Me.btnLimpiar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnLimpiar2, "Cancelar")
        Me.btnLimpiar2.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ImageKey = "mas.png"
        Me.btnAdd.ImageList = Me.ImageNuevos
        Me.btnAdd.Location = New System.Drawing.Point(768, 52)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(60, 30)
        Me.btnAdd.TabIndex = 76
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnAdd, "Agregar")
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModificar, Me.ctxEliminar})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(126, 48)
        '
        'ctxModificar
        '
        Me.ctxModificar.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.ctxModificar.Name = "ctxModificar"
        Me.ctxModificar.Size = New System.Drawing.Size(125, 22)
        Me.ctxModificar.Text = "Modificar"
        '
        'ctxEliminar
        '
        Me.ctxEliminar.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEliminar.Name = "ctxEliminar"
        Me.ctxEliminar.Size = New System.Drawing.Size(125, 22)
        Me.ctxEliminar.Text = "Eliminar"
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'gpCiclo
        '
        Me.gpCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpCiclo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpCiclo.Controls.Add(Me.txtCiclo)
        Me.gpCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCiclo.ForeColor = System.Drawing.Color.White
        Me.gpCiclo.Location = New System.Drawing.Point(965, 0)
        Me.gpCiclo.Name = "gpCiclo"
        Me.gpCiclo.Size = New System.Drawing.Size(75, 40)
        Me.gpCiclo.TabIndex = 67
        Me.gpCiclo.TabStop = False
        Me.gpCiclo.Text = "Ciclo"
        '
        'txtCiclo
        '
        Me.txtCiclo.BackColor = System.Drawing.Color.White
        Me.txtCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCiclo.ForeColor = System.Drawing.Color.Red
        Me.txtCiclo.Location = New System.Drawing.Point(6, 15)
        Me.txtCiclo.MaxLength = 4
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(63, 22)
        Me.txtCiclo.TabIndex = 1
        Me.txtCiclo.TabStop = False
        '
        'gpTipoEvaluacion
        '
        Me.gpTipoEvaluacion.BackColor = System.Drawing.Color.AliceBlue
        Me.gpTipoEvaluacion.Controls.Add(Me.btnTipoEvaluacion)
        Me.gpTipoEvaluacion.Controls.Add(Me.txtNombreTE)
        Me.gpTipoEvaluacion.Controls.Add(Me.txtCodigoTE)
        Me.gpTipoEvaluacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTipoEvaluacion.Location = New System.Drawing.Point(24, 48)
        Me.gpTipoEvaluacion.Name = "gpTipoEvaluacion"
        Me.gpTipoEvaluacion.Size = New System.Drawing.Size(625, 40)
        Me.gpTipoEvaluacion.TabIndex = 67
        Me.gpTipoEvaluacion.TabStop = False
        Me.gpTipoEvaluacion.Text = "Tipo de evaluación"
        '
        'txtNombreTE
        '
        Me.txtNombreTE.BackColor = System.Drawing.Color.White
        Me.txtNombreTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreTE.Location = New System.Drawing.Point(66, 16)
        Me.txtNombreTE.MaxLength = 40
        Me.txtNombreTE.Name = "txtNombreTE"
        Me.txtNombreTE.Size = New System.Drawing.Size(448, 20)
        Me.txtNombreTE.TabIndex = 2
        '
        'txtCodigoTE
        '
        Me.txtCodigoTE.BackColor = System.Drawing.Color.White
        Me.txtCodigoTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoTE.Location = New System.Drawing.Point(6, 16)
        Me.txtCodigoTE.MaxLength = 6
        Me.txtCodigoTE.Name = "txtCodigoTE"
        Me.txtCodigoTE.Size = New System.Drawing.Size(56, 20)
        Me.txtCodigoTE.TabIndex = 1
        '
        'dgDatos
        '
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
        Me.dgDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CorrelativoDgvTC, Me.CodDgvTC, Me.NombreDgvTC, Me.EmpleadoDgvCC, Me.ContratoDgvTC, Me.EvaluadorDgvCC, Me.ContratoEvaDgvTC, Me.CicloDgvTC, Me.TipotestDgvTC})
        Me.dgDatos.ContextMenuStrip = Me.ctxMenu
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDatos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgDatos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatos.Location = New System.Drawing.Point(12, 184)
        Me.dgDatos.MultiSelect = False
        Me.dgDatos.Name = "dgDatos"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgDatos.Size = New System.Drawing.Size(1107, 394)
        Me.dgDatos.TabIndex = 73
        '
        'CorrelativoDgvTC
        '
        Me.CorrelativoDgvTC.DataPropertyName = "correlativo"
        Me.CorrelativoDgvTC.FillWeight = 10.0!
        Me.CorrelativoDgvTC.HeaderText = "Correlativo"
        Me.CorrelativoDgvTC.Name = "CorrelativoDgvTC"
        Me.CorrelativoDgvTC.ReadOnly = True
        '
        'CodDgvTC
        '
        Me.CodDgvTC.DataPropertyName = "cod"
        Me.CodDgvTC.HeaderText = "Cod"
        Me.CodDgvTC.Name = "CodDgvTC"
        Me.CodDgvTC.Visible = False
        '
        'NombreDgvTC
        '
        Me.NombreDgvTC.DataPropertyName = "nombre"
        Me.NombreDgvTC.HeaderText = "Nombre"
        Me.NombreDgvTC.Name = "NombreDgvTC"
        Me.NombreDgvTC.Visible = False
        '
        'EmpleadoDgvCC
        '
        Me.EmpleadoDgvCC.DataPropertyName = "empleado"
        Me.EmpleadoDgvCC.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.EmpleadoDgvCC.FillWeight = 35.0!
        Me.EmpleadoDgvCC.HeaderText = "Empleado"
        Me.EmpleadoDgvCC.Name = "EmpleadoDgvCC"
        '
        'ContratoDgvTC
        '
        Me.ContratoDgvTC.DataPropertyName = "contrato"
        Me.ContratoDgvTC.FillWeight = 10.0!
        Me.ContratoDgvTC.HeaderText = "Contrato"
        Me.ContratoDgvTC.Name = "ContratoDgvTC"
        '
        'EvaluadorDgvCC
        '
        Me.EvaluadorDgvCC.DataPropertyName = "evaluador"
        Me.EvaluadorDgvCC.FillWeight = 35.0!
        Me.EvaluadorDgvCC.HeaderText = "Evaluador"
        Me.EvaluadorDgvCC.Name = "EvaluadorDgvCC"
        '
        'ContratoEvaDgvTC
        '
        Me.ContratoEvaDgvTC.DataPropertyName = "contrato_evaluador"
        Me.ContratoEvaDgvTC.FillWeight = 10.0!
        Me.ContratoEvaDgvTC.HeaderText = "Contrato Eva."
        Me.ContratoEvaDgvTC.Name = "ContratoEvaDgvTC"
        '
        'CicloDgvTC
        '
        Me.CicloDgvTC.DataPropertyName = "ciclo"
        Me.CicloDgvTC.HeaderText = "Ciclo"
        Me.CicloDgvTC.Name = "CicloDgvTC"
        Me.CicloDgvTC.Visible = False
        '
        'TipotestDgvTC
        '
        Me.TipotestDgvTC.DataPropertyName = "tipotest"
        Me.TipotestDgvTC.HeaderText = "Tipotest"
        Me.TipotestDgvTC.Name = "TipotestDgvTC"
        Me.TipotestDgvTC.Visible = False
        '
        'pnDetalle
        '
        Me.pnDetalle.Controls.Add(Me.btnAdd)
        Me.pnDetalle.Controls.Add(Me.gpEmpleado)
        Me.pnDetalle.Controls.Add(Me.btnLimpiar2)
        Me.pnDetalle.Controls.Add(Me.gpContrato)
        Me.pnDetalle.Controls.Add(Me.gpEvaluador)
        Me.pnDetalle.Controls.Add(Me.gpContratoEva)
        Me.pnDetalle.Location = New System.Drawing.Point(12, 89)
        Me.pnDetalle.Name = "pnDetalle"
        Me.pnDetalle.Size = New System.Drawing.Size(947, 89)
        Me.pnDetalle.TabIndex = 76
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gpCiclo)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 45)
        Me.Panel1.TabIndex = 77
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.btnMigrar)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(963, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(156, 77)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Evaluación"
        '
        'btnMigrar
        '
        Me.btnMigrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnMigrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMigrar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMigrar.ImageKey = "actualizar.png"
        Me.btnMigrar.ImageList = Me.ImageNuevos
        Me.btnMigrar.Location = New System.Drawing.Point(93, 19)
        Me.btnMigrar.Name = "btnMigrar"
        Me.btnMigrar.Size = New System.Drawing.Size(60, 30)
        Me.btnMigrar.TabIndex = 67
        Me.btnMigrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnMigrar, "Guardar")
        Me.btnMigrar.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 49)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Migrar Asignación Ciclo Anterior:"
        '
        'frmEvaluacionAsignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnDetalle)
        Me.Controls.Add(Me.gpTipoEvaluacion)
        Me.Controls.Add(Me.dgDatos)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnAsignar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEvaluacionAsignacion"
        Me.Text = "Mantenimiento de Asignacion de Evaluacion"
        Me.gpEmpleado.ResumeLayout(False)
        Me.gpEmpleado.PerformLayout()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpEvaluador.ResumeLayout(False)
        Me.gpEvaluador.PerformLayout()
        Me.gpContratoEva.ResumeLayout(False)
        Me.gpContratoEva.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ctxMenu.ResumeLayout(False)
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpCiclo.ResumeLayout(False)
        Me.gpCiclo.PerformLayout()
        Me.gpTipoEvaluacion.ResumeLayout(False)
        Me.gpTipoEvaluacion.PerformLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDetalle.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents gpEmpleado As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents txtNomEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents txtCodEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents gpContrato As System.Windows.Forms.GroupBox
    Friend WithEvents btnContrato As System.Windows.Forms.Button
    Friend WithEvents txtContraEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents gpEvaluador As System.Windows.Forms.GroupBox
    Friend WithEvents btnEvaluador As System.Windows.Forms.Button
    Friend WithEvents txtNombreEva As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoEva As System.Windows.Forms.TextBox
    Friend WithEvents gpContratoEva As System.Windows.Forms.GroupBox
    Friend WithEvents btnContratoEva As System.Windows.Forms.Button
    Friend WithEvents txtContratoEva As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gpCiclo As System.Windows.Forms.GroupBox
    Friend WithEvents txtCiclo As System.Windows.Forms.TextBox
    Friend WithEvents gpTipoEvaluacion As System.Windows.Forms.GroupBox
    Friend WithEvents btnTipoEvaluacion As System.Windows.Forms.Button
    Friend WithEvents txtNombreTE As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoTE As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents dgDatos As System.Windows.Forms.DataGridView
    Friend WithEvents btnAsignar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar2 As System.Windows.Forms.Button
    Friend WithEvents pnDetalle As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents btnAdd As Button
    Friend WithEvents CorrelativoDgvTC As DataGridViewTextBoxColumn
    Friend WithEvents CodDgvTC As DataGridViewTextBoxColumn
    Friend WithEvents NombreDgvTC As DataGridViewTextBoxColumn
    Friend WithEvents EmpleadoDgvCC As DataGridViewComboBoxColumn
    Friend WithEvents ContratoDgvTC As DataGridViewTextBoxColumn
    Friend WithEvents EvaluadorDgvCC As DataGridViewComboBoxColumn
    Friend WithEvents ContratoEvaDgvTC As DataGridViewTextBoxColumn
    Friend WithEvents CicloDgvTC As DataGridViewTextBoxColumn
    Friend WithEvents TipotestDgvTC As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnMigrar As Button
    Friend WithEvents Label6 As Label
End Class
