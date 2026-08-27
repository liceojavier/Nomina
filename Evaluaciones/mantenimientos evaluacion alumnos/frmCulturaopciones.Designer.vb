<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCulturaopciones
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCulturaopciones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblHayPreguntas = New System.Windows.Forms.Label()
        Me.gbUnico = New System.Windows.Forms.GroupBox()
        Me.cmbPregunta = New System.Windows.Forms.ComboBox()
        Me.lblCiclo = New System.Windows.Forms.Label()
        Me.gbGrupo = New System.Windows.Forms.GroupBox()
        Me.cmbAlP = New System.Windows.Forms.ComboBox()
        Me.lblAlP = New System.Windows.Forms.Label()
        Me.cmbDelP = New System.Windows.Forms.ComboBox()
        Me.lblDelP = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.gbOpcion = New System.Windows.Forms.GroupBox()
        Me.cmbPorque = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLimpiar2 = New System.Windows.Forms.Button()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.lblOpcion = New System.Windows.Forms.Label()
        Me.txtOpcion = New System.Windows.Forms.TextBox()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.gpTipo = New System.Windows.Forms.GroupBox()
        Me.rbGrupo = New System.Windows.Forms.RadioButton()
        Me.rbUnico = New System.Windows.Forms.RadioButton()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gbContent = New System.Windows.Forms.GroupBox()
        Me.lblNombreTE = New System.Windows.Forms.Label()
        Me.btnAsignarTE = New System.Windows.Forms.Button()
        Me.btnBuscarTE = New System.Windows.Forms.Button()
        Me.txtNombreTE = New System.Windows.Forms.TextBox()
        Me.txtCodigoTE = New System.Windows.Forms.TextBox()
        Me.lblCodigoTE = New System.Windows.Forms.Label()
        Me.grdOpciones = New System.Windows.Forms.DataGridView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.gbUnico.SuspendLayout()
        Me.gbGrupo.SuspendLayout()
        Me.gbOpcion.SuspendLayout()
        Me.gpTipo.SuspendLayout()
        Me.gbContent.SuspendLayout()
        CType(Me.grdOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblHayPreguntas)
        Me.Panel1.Controls.Add(Me.gbUnico)
        Me.Panel1.Controls.Add(Me.lblCiclo)
        Me.Panel1.Controls.Add(Me.gbGrupo)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.gbOpcion)
        Me.Panel1.Controls.Add(Me.txtCiclo)
        Me.Panel1.Controls.Add(Me.gpTipo)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gbContent)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1138, 148)
        Me.Panel1.TabIndex = 20
        '
        'lblHayPreguntas
        '
        Me.lblHayPreguntas.AutoSize = True
        Me.lblHayPreguntas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHayPreguntas.ForeColor = System.Drawing.Color.White
        Me.lblHayPreguntas.Location = New System.Drawing.Point(615, 21)
        Me.lblHayPreguntas.Name = "lblHayPreguntas"
        Me.lblHayPreguntas.Size = New System.Drawing.Size(139, 16)
        Me.lblHayPreguntas.TabIndex = 10
        Me.lblHayPreguntas.Text = "valida si hay pregunta"
        Me.lblHayPreguntas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblHayPreguntas.Visible = False
        '
        'gbUnico
        '
        Me.gbUnico.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbUnico.Controls.Add(Me.cmbPregunta)
        Me.gbUnico.Enabled = False
        Me.gbUnico.ForeColor = System.Drawing.Color.White
        Me.gbUnico.Location = New System.Drawing.Point(548, 47)
        Me.gbUnico.Name = "gbUnico"
        Me.gbUnico.Size = New System.Drawing.Size(476, 40)
        Me.gbUnico.TabIndex = 5
        Me.gbUnico.TabStop = False
        Me.gbUnico.Text = "Preguntas"
        '
        'cmbPregunta
        '
        Me.cmbPregunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPregunta.FormattingEnabled = True
        Me.cmbPregunta.Location = New System.Drawing.Point(6, 13)
        Me.cmbPregunta.Name = "cmbPregunta"
        Me.cmbPregunta.Size = New System.Drawing.Size(464, 21)
        Me.cmbPregunta.TabIndex = 4
        '
        'lblCiclo
        '
        Me.lblCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCiclo.AutoSize = True
        Me.lblCiclo.ForeColor = System.Drawing.Color.White
        Me.lblCiclo.Location = New System.Drawing.Point(991, 15)
        Me.lblCiclo.Name = "lblCiclo"
        Me.lblCiclo.Size = New System.Drawing.Size(33, 13)
        Me.lblCiclo.TabIndex = 13
        Me.lblCiclo.Text = "Ciclo:"
        Me.lblCiclo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.gbGrupo.Location = New System.Drawing.Point(329, 47)
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
        Me.cmbAlP.TabIndex = 3
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
        Me.cmbDelP.TabIndex = 2
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
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.ImageIndex = 5
        Me.btnGuardar.ImageList = Me.ImageList1
        Me.btnGuardar.Location = New System.Drawing.Point(1030, 101)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(40, 30)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.UseVisualStyleBackColor = False
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
        'gbOpcion
        '
        Me.gbOpcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbOpcion.Controls.Add(Me.cmbPorque)
        Me.gbOpcion.Controls.Add(Me.Label2)
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
        Me.gbOpcion.Size = New System.Drawing.Size(1020, 48)
        Me.gbOpcion.TabIndex = 6
        Me.gbOpcion.TabStop = False
        Me.gbOpcion.Text = "Opción"
        '
        'cmbPorque
        '
        Me.cmbPorque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPorque.FormattingEnabled = True
        Me.cmbPorque.Items.AddRange(New Object() {"S", "N"})
        Me.cmbPorque.Location = New System.Drawing.Point(647, 18)
        Me.cmbPorque.Name = "cmbPorque"
        Me.cmbPorque.Size = New System.Drawing.Size(164, 21)
        Me.cmbPorque.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(592, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Posee:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.ImageIndex = 3
        Me.btnAgregar.ImageList = Me.ImageList1
        Me.btnAgregar.Location = New System.Drawing.Point(926, 12)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(40, 30)
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'txtNo
        '
        Me.txtNo.BackColor = System.Drawing.Color.White
        Me.txtNo.Location = New System.Drawing.Point(35, 18)
        Me.txtNo.MaxLength = 3
        Me.txtNo.Name = "txtNo"
        Me.txtNo.Size = New System.Drawing.Size(57, 20)
        Me.txtNo.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "No:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLimpiar2
        '
        Me.btnLimpiar2.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar2.ImageIndex = 1
        Me.btnLimpiar2.ImageList = Me.ImageList1
        Me.btnLimpiar2.Location = New System.Drawing.Point(972, 12)
        Me.btnLimpiar2.Name = "btnLimpiar2"
        Me.btnLimpiar2.Size = New System.Drawing.Size(40, 30)
        Me.btnLimpiar2.TabIndex = 5
        Me.btnLimpiar2.UseVisualStyleBackColor = False
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(499, 18)
        Me.txtValor.MaxLength = 3
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(71, 20)
        Me.txtValor.TabIndex = 7
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.Location = New System.Drawing.Point(459, 18)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(34, 13)
        Me.lblValor.TabIndex = 10
        Me.lblValor.Text = "Valor:"
        Me.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOpcion
        '
        Me.lblOpcion.AutoSize = True
        Me.lblOpcion.Location = New System.Drawing.Point(103, 18)
        Me.lblOpcion.Name = "lblOpcion"
        Me.lblOpcion.Size = New System.Drawing.Size(44, 13)
        Me.lblOpcion.TabIndex = 10
        Me.lblOpcion.Text = "Opción:"
        Me.lblOpcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOpcion
        '
        Me.txtOpcion.Location = New System.Drawing.Point(153, 18)
        Me.txtOpcion.MaxLength = 255
        Me.txtOpcion.Name = "txtOpcion"
        Me.txtOpcion.Size = New System.Drawing.Size(300, 20)
        Me.txtOpcion.TabIndex = 6
        '
        'txtCiclo
        '
        Me.txtCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCiclo.Location = New System.Drawing.Point(1030, 12)
        Me.txtCiclo.MaxLength = 4
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(58, 20)
        Me.txtCiclo.TabIndex = 1
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
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.ImageIndex = 2
        Me.btnLimpiar.ImageList = Me.ImageList1
        Me.btnLimpiar.Location = New System.Drawing.Point(1094, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(40, 30)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.UseVisualStyleBackColor = False
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
        'btnAsignarTE
        '
        Me.btnAsignarTE.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignarTE.ImageIndex = 0
        Me.btnAsignarTE.ImageList = Me.ImageList1
        Me.btnAsignarTE.Location = New System.Drawing.Point(537, 8)
        Me.btnAsignarTE.Name = "btnAsignarTE"
        Me.btnAsignarTE.Size = New System.Drawing.Size(40, 30)
        Me.btnAsignarTE.TabIndex = 4
        Me.btnAsignarTE.UseVisualStyleBackColor = False
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
        Me.btnBuscarTE.UseVisualStyleBackColor = False
        '
        'txtNombreTE
        '
        Me.txtNombreTE.Location = New System.Drawing.Point(217, 17)
        Me.txtNombreTE.Name = "txtNombreTE"
        Me.txtNombreTE.Size = New System.Drawing.Size(265, 20)
        Me.txtNombreTE.TabIndex = 1
        '
        'txtCodigoTE
        '
        Me.txtCodigoTE.Location = New System.Drawing.Point(69, 13)
        Me.txtCodigoTE.Name = "txtCodigoTE"
        Me.txtCodigoTE.Size = New System.Drawing.Size(66, 20)
        Me.txtCodigoTE.TabIndex = 0
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
        'grdOpciones
        '
        Me.grdOpciones.AllowUserToAddRows = False
        Me.grdOpciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen
        Me.grdOpciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdOpciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdOpciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdOpciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.grdOpciones.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdOpciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdOpciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdOpciones.ContextMenuStrip = Me.ctxMenu
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdOpciones.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdOpciones.GridColor = System.Drawing.Color.WhiteSmoke
        Me.grdOpciones.Location = New System.Drawing.Point(4, 154)
        Me.grdOpciones.MultiSelect = False
        Me.grdOpciones.Name = "grdOpciones"
        Me.grdOpciones.ReadOnly = True
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdOpciones.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grdOpciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdOpciones.Size = New System.Drawing.Size(1130, 434)
        Me.grdOpciones.TabIndex = 19
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
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'ToolTip
        '
        Me.ToolTip.AutoPopDelay = 5000
        Me.ToolTip.InitialDelay = 500
        Me.ToolTip.ReshowDelay = 500
        '
        'frmCulturaopciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1138, 600)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grdOpciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCulturaopciones"
        Me.Text = "Mantenimiento de Cultura de Opciones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbUnico.ResumeLayout(False)
        Me.gbGrupo.ResumeLayout(False)
        Me.gbGrupo.PerformLayout()
        Me.gbOpcion.ResumeLayout(False)
        Me.gbOpcion.PerformLayout()
        Me.gpTipo.ResumeLayout(False)
        Me.gpTipo.PerformLayout()
        Me.gbContent.ResumeLayout(False)
        Me.gbContent.PerformLayout()
        CType(Me.grdOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents gbUnico As GroupBox
    Friend WithEvents cmbPregunta As ComboBox
    Friend WithEvents lblCiclo As Label
    Friend WithEvents gbGrupo As GroupBox
    Friend WithEvents cmbAlP As ComboBox
    Friend WithEvents lblAlP As Label
    Friend WithEvents cmbDelP As ComboBox
    Friend WithEvents lblDelP As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents gbOpcion As GroupBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents txtNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLimpiar2 As Button
    Friend WithEvents txtValor As TextBox
    Friend WithEvents lblValor As Label
    Friend WithEvents lblOpcion As Label
    Friend WithEvents txtOpcion As TextBox
    Friend WithEvents txtCiclo As TextBox
    Friend WithEvents gpTipo As GroupBox
    Friend WithEvents rbGrupo As RadioButton
    Friend WithEvents rbUnico As RadioButton
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents gbContent As GroupBox
    Friend WithEvents lblNombreTE As Label
    Friend WithEvents btnAsignarTE As Button
    Friend WithEvents btnBuscarTE As Button
    Friend WithEvents txtNombreTE As TextBox
    Friend WithEvents txtCodigoTE As TextBox
    Friend WithEvents lblCodigoTE As Label
    Friend WithEvents grdOpciones As DataGridView
    Friend WithEvents ep1 As ErrorProvider
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ctxMenu As ContextMenuStrip
    Friend WithEvents ctxEliminar As ToolStripMenuItem
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents cmbPorque As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblHayPreguntas As Label
End Class
