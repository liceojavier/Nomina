<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvaluaOpciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEvaluaOpciones))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblCiclo = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAsignarTE = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnBuscarTE = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnLimpiar2 = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.gbContent = New System.Windows.Forms.GroupBox()
        Me.lblNombreTE = New System.Windows.Forms.Label()
        Me.txtNombreTE = New System.Windows.Forms.TextBox()
        Me.txtCodigoTE = New System.Windows.Forms.TextBox()
        Me.lblCodigoTE = New System.Windows.Forms.Label()
        Me.gbGrupo = New System.Windows.Forms.GroupBox()
        Me.cmbAlP = New System.Windows.Forms.ComboBox()
        Me.lblAlP = New System.Windows.Forms.Label()
        Me.cmbDelP = New System.Windows.Forms.ComboBox()
        Me.lblDelP = New System.Windows.Forms.Label()
        Me.grdOpciones = New System.Windows.Forms.DataGridView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbOpcion = New System.Windows.Forms.GroupBox()
        Me.txtNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.lblOpcion = New System.Windows.Forms.Label()
        Me.txtOpcion = New System.Windows.Forms.TextBox()
        Me.gpTipo = New System.Windows.Forms.GroupBox()
        Me.rbGrupo = New System.Windows.Forms.RadioButton()
        Me.rbUnico = New System.Windows.Forms.RadioButton()
        Me.gbUnico = New System.Windows.Forms.GroupBox()
        Me.cmbPregunta = New System.Windows.Forms.ComboBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbContent.SuspendLayout()
        Me.gbGrupo.SuspendLayout()
        CType(Me.grdOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        Me.gbOpcion.SuspendLayout()
        Me.gpTipo.SuspendLayout()
        Me.gbUnico.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCiclo
        '
        Me.lblCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCiclo.AutoSize = True
        Me.lblCiclo.ForeColor = System.Drawing.Color.White
        Me.lblCiclo.Location = New System.Drawing.Point(983, 15)
        Me.lblCiclo.Name = "lblCiclo"
        Me.lblCiclo.Size = New System.Drawing.Size(33, 13)
        Me.lblCiclo.TabIndex = 13
        Me.lblCiclo.Text = "Ciclo:"
        Me.lblCiclo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolTip
        '
        Me.ToolTip.AutoPopDelay = 5000
        Me.ToolTip.InitialDelay = 500
        Me.ToolTip.ReshowDelay = 500
        '
        'btnAsignarTE
        '
        Me.btnAsignarTE.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignarTE.ImageIndex = 0
        Me.btnAsignarTE.ImageList = Me.ImageList1
        Me.btnAsignarTE.Location = New System.Drawing.Point(537, 8)
        Me.btnAsignarTE.Name = "btnAsignarTE"
        Me.btnAsignarTE.Size = New System.Drawing.Size(40, 30)
        Me.btnAsignarTE.TabIndex = 4
        Me.ToolTip.SetToolTip(Me.btnAsignarTE, "Asignar tipo de evaluación")
        Me.btnAsignarTE.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "asignar1.png")
        Me.ImageList1.Images.SetKeyName(1, "cancelar.png")
        Me.ImageList1.Images.SetKeyName(2, "limpiar.png")
        Me.ImageList1.Images.SetKeyName(3, "mas.png")
        Me.ImageList1.Images.SetKeyName(4, "buscar1.png")
        Me.ImageList1.Images.SetKeyName(5, "guardar.png")
        '
        'btnBuscarTE
        '
        Me.btnBuscarTE.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarTE.ImageIndex = 4
        Me.btnBuscarTE.ImageList = Me.ImageList1
        Me.btnBuscarTE.Location = New System.Drawing.Point(491, 8)
        Me.btnBuscarTE.Name = "btnBuscarTE"
        Me.btnBuscarTE.Size = New System.Drawing.Size(40, 30)
        Me.btnBuscarTE.TabIndex = 3
        Me.ToolTip.SetToolTip(Me.btnBuscarTE, "Buscar Tipo de Evaluación")
        Me.btnBuscarTE.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.ImageIndex = 2
        Me.btnLimpiar.ImageList = Me.ImageList1
        Me.btnLimpiar.Location = New System.Drawing.Point(1086, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(40, 30)
        Me.btnLimpiar.TabIndex = 2
        Me.ToolTip.SetToolTip(Me.btnLimpiar, "Limpiar formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.ImageIndex = 5
        Me.btnGuardar.ImageList = Me.ImageList1
        Me.btnGuardar.Location = New System.Drawing.Point(761, 96)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(40, 30)
        Me.btnGuardar.TabIndex = 7
        Me.ToolTip.SetToolTip(Me.btnGuardar, "Guardar opción")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnLimpiar2
        '
        Me.btnLimpiar2.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar2.ImageIndex = 1
        Me.btnLimpiar2.ImageList = Me.ImageList1
        Me.btnLimpiar2.Location = New System.Drawing.Point(693, 8)
        Me.btnLimpiar2.Name = "btnLimpiar2"
        Me.btnLimpiar2.Size = New System.Drawing.Size(40, 30)
        Me.btnLimpiar2.TabIndex = 5
        Me.ToolTip.SetToolTip(Me.btnLimpiar2, "Eliminar opción")
        Me.btnLimpiar2.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.ImageIndex = 3
        Me.btnAgregar.ImageList = Me.ImageList1
        Me.btnAgregar.Location = New System.Drawing.Point(640, 8)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(40, 30)
        Me.btnAgregar.TabIndex = 4
        Me.ToolTip.SetToolTip(Me.btnAgregar, "Asignar pregunta")
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'gbContent
        '
        Me.gbContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbContent.Controls.Add(Me.lblNombreTE)
        Me.gbContent.Controls.Add(Me.btnAsignarTE)
        Me.gbContent.Controls.Add(Me.btnBuscarTE)
        Me.gbContent.Controls.Add(Me.txtNombreTE)
        Me.gbContent.Controls.Add(Me.txtCodigoTE)
        Me.gbContent.Controls.Add(Me.lblCodigoTE)
        Me.gbContent.ForeColor = System.Drawing.Color.White
        Me.gbContent.Location = New System.Drawing.Point(4, 4)
        Me.gbContent.Name = "gbContent"
        Me.gbContent.Size = New System.Drawing.Size(587, 40)
        Me.gbContent.TabIndex = 3
        Me.gbContent.TabStop = False
        Me.gbContent.Text = "Tipo de evaluación"
        '
        'lblNombreTE
        '
        Me.lblNombreTE.AutoSize = True
        Me.lblNombreTE.Location = New System.Drawing.Point(164, 19)
        Me.lblNombreTE.Name = "lblNombreTE"
        Me.lblNombreTE.Size = New System.Drawing.Size(47, 13)
        Me.lblNombreTE.TabIndex = 9
        Me.lblNombreTE.Text = "Nombre:"
        Me.lblNombreTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombreTE
        '
        Me.txtNombreTE.Location = New System.Drawing.Point(217, 17)
        Me.txtNombreTE.Name = "txtNombreTE"
        Me.txtNombreTE.Size = New System.Drawing.Size(265, 20)
        Me.txtNombreTE.TabIndex = 2
        '
        'txtCodigoTE
        '
        Me.txtCodigoTE.Location = New System.Drawing.Point(69, 13)
        Me.txtCodigoTE.Name = "txtCodigoTE"
        Me.txtCodigoTE.Size = New System.Drawing.Size(66, 20)
        Me.txtCodigoTE.TabIndex = 1
        '
        'lblCodigoTE
        '
        Me.lblCodigoTE.AutoSize = True
        Me.lblCodigoTE.Location = New System.Drawing.Point(6, 17)
        Me.lblCodigoTE.Name = "lblCodigoTE"
        Me.lblCodigoTE.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigoTE.TabIndex = 3
        Me.lblCodigoTE.Text = "Código:"
        Me.lblCodigoTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbGrupo
        '
        Me.gbGrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbGrupo.Controls.Add(Me.cmbAlP)
        Me.gbGrupo.Controls.Add(Me.lblAlP)
        Me.gbGrupo.Controls.Add(Me.cmbDelP)
        Me.gbGrupo.Controls.Add(Me.lblDelP)
        Me.gbGrupo.Enabled = False
        Me.gbGrupo.ForeColor = System.Drawing.Color.White
        Me.gbGrupo.Location = New System.Drawing.Point(329, 48)
        Me.gbGrupo.Name = "gbGrupo"
        Me.gbGrupo.Size = New System.Drawing.Size(213, 40)
        Me.gbGrupo.TabIndex = 5
        Me.gbGrupo.TabStop = False
        Me.gbGrupo.Text = "Preguntas"
        '
        'cmbAlP
        '
        Me.cmbAlP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlP.FormattingEnabled = True
        Me.cmbAlP.Location = New System.Drawing.Point(145, 15)
        Me.cmbAlP.Name = "cmbAlP"
        Me.cmbAlP.Size = New System.Drawing.Size(60, 21)
        Me.cmbAlP.TabIndex = 6
        '
        'lblAlP
        '
        Me.lblAlP.AutoSize = True
        Me.lblAlP.Location = New System.Drawing.Point(108, 17)
        Me.lblAlP.Name = "lblAlP"
        Me.lblAlP.Size = New System.Drawing.Size(19, 13)
        Me.lblAlP.TabIndex = 5
        Me.lblAlP.Text = "Al:"
        Me.lblAlP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDelP
        '
        Me.cmbDelP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDelP.FormattingEnabled = True
        Me.cmbDelP.Location = New System.Drawing.Point(42, 14)
        Me.cmbDelP.Name = "cmbDelP"
        Me.cmbDelP.Size = New System.Drawing.Size(60, 21)
        Me.cmbDelP.TabIndex = 4
        '
        'lblDelP
        '
        Me.lblDelP.AutoSize = True
        Me.lblDelP.Location = New System.Drawing.Point(8, 18)
        Me.lblDelP.Name = "lblDelP"
        Me.lblDelP.Size = New System.Drawing.Size(26, 13)
        Me.lblDelP.TabIndex = 3
        Me.lblDelP.Text = "Del:"
        Me.lblDelP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdOpciones
        '
        Me.grdOpciones.AllowUserToAddRows = False
        Me.grdOpciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGreen
        Me.grdOpciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.grdOpciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdOpciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdOpciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.grdOpciones.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdOpciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grdOpciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdOpciones.ContextMenuStrip = Me.ctxMenu
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdOpciones.DefaultCellStyle = DataGridViewCellStyle7
        Me.grdOpciones.GridColor = System.Drawing.Color.WhiteSmoke
        Me.grdOpciones.Location = New System.Drawing.Point(0, 140)
        Me.grdOpciones.MultiSelect = False
        Me.grdOpciones.Name = "grdOpciones"
        Me.grdOpciones.ReadOnly = True
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdOpciones.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.grdOpciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdOpciones.Size = New System.Drawing.Size(1130, 465)
        Me.grdOpciones.TabIndex = 17
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxEliminar})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(118, 26)
        '
        'ctxEliminar
        '
        Me.ctxEliminar.Name = "ctxEliminar"
        Me.ctxEliminar.Size = New System.Drawing.Size(117, 22)
        Me.ctxEliminar.Text = "Eliminar"
        '
        'gbOpcion
        '
        Me.gbOpcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbOpcion.Controls.Add(Me.btnAgregar)
        Me.gbOpcion.Controls.Add(Me.txtNo)
        Me.gbOpcion.Controls.Add(Me.Label1)
        Me.gbOpcion.Controls.Add(Me.btnLimpiar2)
        Me.gbOpcion.Controls.Add(Me.txtValor)
        Me.gbOpcion.Controls.Add(Me.lblValor)
        Me.gbOpcion.Controls.Add(Me.lblOpcion)
        Me.gbOpcion.Controls.Add(Me.txtOpcion)
        Me.gbOpcion.Enabled = False
        Me.gbOpcion.ForeColor = System.Drawing.Color.White
        Me.gbOpcion.Location = New System.Drawing.Point(4, 89)
        Me.gbOpcion.Name = "gbOpcion"
        Me.gbOpcion.Size = New System.Drawing.Size(751, 40)
        Me.gbOpcion.TabIndex = 6
        Me.gbOpcion.TabStop = False
        Me.gbOpcion.Text = "Opción"
        '
        'txtNo
        '
        Me.txtNo.BackColor = System.Drawing.Color.White
        Me.txtNo.Location = New System.Drawing.Point(35, 16)
        Me.txtNo.MaxLength = 3
        Me.txtNo.Name = "txtNo"
        Me.txtNo.Size = New System.Drawing.Size(66, 20)
        Me.txtNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "No:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(529, 17)
        Me.txtValor.MaxLength = 3
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(79, 20)
        Me.txtValor.TabIndex = 3
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.Location = New System.Drawing.Point(478, 21)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(34, 13)
        Me.lblValor.TabIndex = 10
        Me.lblValor.Text = "Valor:"
        Me.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOpcion
        '
        Me.lblOpcion.AutoSize = True
        Me.lblOpcion.Location = New System.Drawing.Point(107, 20)
        Me.lblOpcion.Name = "lblOpcion"
        Me.lblOpcion.Size = New System.Drawing.Size(44, 13)
        Me.lblOpcion.TabIndex = 10
        Me.lblOpcion.Text = "Opción:"
        Me.lblOpcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOpcion
        '
        Me.txtOpcion.Location = New System.Drawing.Point(172, 17)
        Me.txtOpcion.MaxLength = 255
        Me.txtOpcion.Name = "txtOpcion"
        Me.txtOpcion.Size = New System.Drawing.Size(300, 20)
        Me.txtOpcion.TabIndex = 2
        '
        'gpTipo
        '
        Me.gpTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpTipo.Controls.Add(Me.rbGrupo)
        Me.gpTipo.Controls.Add(Me.rbUnico)
        Me.gpTipo.ForeColor = System.Drawing.Color.White
        Me.gpTipo.Location = New System.Drawing.Point(4, 47)
        Me.gpTipo.Name = "gpTipo"
        Me.gpTipo.Size = New System.Drawing.Size(321, 40)
        Me.gpTipo.TabIndex = 4
        Me.gpTipo.TabStop = False
        Me.gpTipo.Text = "Filtro de preguntas"
        '
        'rbGrupo
        '
        Me.rbGrupo.AutoSize = True
        Me.rbGrupo.Location = New System.Drawing.Point(135, 16)
        Me.rbGrupo.Name = "rbGrupo"
        Me.rbGrupo.Size = New System.Drawing.Size(131, 17)
        Me.rbGrupo.TabIndex = 2
        Me.rbGrupo.TabStop = True
        Me.rbGrupo.Text = "Por grupo de pregunta"
        Me.rbGrupo.UseVisualStyleBackColor = True
        '
        'rbUnico
        '
        Me.rbUnico.AutoSize = True
        Me.rbUnico.Location = New System.Drawing.Point(6, 16)
        Me.rbUnico.Name = "rbUnico"
        Me.rbUnico.Size = New System.Drawing.Size(86, 17)
        Me.rbUnico.TabIndex = 1
        Me.rbUnico.TabStop = True
        Me.rbUnico.Text = "Por pregunta"
        Me.rbUnico.UseVisualStyleBackColor = True
        '
        'gbUnico
        '
        Me.gbUnico.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbUnico.Controls.Add(Me.cmbPregunta)
        Me.gbUnico.Enabled = False
        Me.gbUnico.ForeColor = System.Drawing.Color.White
        Me.gbUnico.Location = New System.Drawing.Point(548, 48)
        Me.gbUnico.Name = "gbUnico"
        Me.gbUnico.Size = New System.Drawing.Size(408, 40)
        Me.gbUnico.TabIndex = 5
        Me.gbUnico.TabStop = False
        Me.gbUnico.Text = "Preguntas"
        '
        'cmbPregunta
        '
        Me.cmbPregunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPregunta.FormattingEnabled = True
        Me.cmbPregunta.Location = New System.Drawing.Point(6, 16)
        Me.cmbPregunta.Name = "cmbPregunta"
        Me.cmbPregunta.Size = New System.Drawing.Size(399, 21)
        Me.cmbPregunta.TabIndex = 4
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'txtCiclo
        '
        Me.txtCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCiclo.Location = New System.Drawing.Point(1022, 12)
        Me.txtCiclo.MaxLength = 4
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(58, 20)
        Me.txtCiclo.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gbUnico)
        Me.Panel1.Controls.Add(Me.lblCiclo)
        Me.Panel1.Controls.Add(Me.gbGrupo)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.gbOpcion)
        Me.Panel1.Controls.Add(Me.txtCiclo)
        Me.Panel1.Controls.Add(Me.gpTipo)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gbContent)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 135)
        Me.Panel1.TabIndex = 18
        '
        'frmEvaluaOpciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grdOpciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEvaluaOpciones"
        Me.Text = "Opciones de Evaluación"
        Me.gbContent.ResumeLayout(False)
        Me.gbContent.PerformLayout()
        Me.gbGrupo.ResumeLayout(False)
        Me.gbGrupo.PerformLayout()
        CType(Me.grdOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        Me.gbOpcion.ResumeLayout(False)
        Me.gbOpcion.PerformLayout()
        Me.gpTipo.ResumeLayout(False)
        Me.gpTipo.PerformLayout()
        Me.gbUnico.ResumeLayout(False)
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCiclo As System.Windows.Forms.Label
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents gbContent As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreTE As System.Windows.Forms.Label
    Friend WithEvents btnAsignarTE As System.Windows.Forms.Button
    Friend WithEvents btnBuscarTE As System.Windows.Forms.Button
    Friend WithEvents txtNombreTE As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoTE As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoTE As System.Windows.Forms.Label
    Friend WithEvents gbGrupo As System.Windows.Forms.GroupBox
    Friend WithEvents lblDelP As System.Windows.Forms.Label
    Friend WithEvents grdOpciones As System.Windows.Forms.DataGridView
    Friend WithEvents cmbDelP As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAlP As System.Windows.Forms.ComboBox
    Friend WithEvents lblAlP As System.Windows.Forms.Label
    Friend WithEvents gbOpcion As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents lblOpcion As System.Windows.Forms.Label
    Friend WithEvents txtOpcion As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar2 As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gpTipo As System.Windows.Forms.GroupBox
    Friend WithEvents rbGrupo As System.Windows.Forms.RadioButton
    Friend WithEvents rbUnico As System.Windows.Forms.RadioButton
    Friend WithEvents gbUnico As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPregunta As System.Windows.Forms.ComboBox
    Friend WithEvents txtNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents ctxEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtCiclo As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
