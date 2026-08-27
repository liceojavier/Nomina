<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvaluaPreguntas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEvaluaPreguntas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbTipoEvaluacion = New System.Windows.Forms.GroupBox()
        Me.lblNombreTE = New System.Windows.Forms.Label()
        Me.btnAsignarTE = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.btnBuscarTE = New System.Windows.Forms.Button()
        Me.txtNombreTE = New System.Windows.Forms.TextBox()
        Me.txtCodigoTE = New System.Windows.Forms.TextBox()
        Me.lblCodigoTE = New System.Windows.Forms.Label()
        Me.txtCiclo = New System.Windows.Forms.MaskedTextBox()
        Me.lblCiclo = New System.Windows.Forms.Label()
        Me.grdPreguntas = New System.Windows.Forms.DataGridView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbPregunta = New System.Windows.Forms.GroupBox()
        Me.btnGuardar2 = New System.Windows.Forms.Button()
        Me.cmbRasgo = New System.Windows.Forms.ComboBox()
        Me.gbOpciones = New System.Windows.Forms.GroupBox()
        Me.nudMax = New System.Windows.Forms.NumericUpDown()
        Me.txtOpMin = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbMensaje = New System.Windows.Forms.Label()
        Me.txtNumLinea = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtInstrucciones = New System.Windows.Forms.TextBox()
        Me.lblInstrucciones = New System.Windows.Forms.Label()
        Me.chkVertical = New System.Windows.Forms.CheckBox()
        Me.txtPregunta = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.cmbCompetencia = New System.Windows.Forms.ComboBox()
        Me.lblCompetencia = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbTipoEvaluacion.SuspendLayout()
        CType(Me.grdPreguntas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        Me.gbPregunta.SuspendLayout()
        Me.gbOpciones.SuspendLayout()
        CType(Me.nudMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTipoEvaluacion
        '
        Me.gbTipoEvaluacion.BackColor = System.Drawing.Color.AliceBlue
        Me.gbTipoEvaluacion.Controls.Add(Me.lblNombreTE)
        Me.gbTipoEvaluacion.Controls.Add(Me.btnAsignarTE)
        Me.gbTipoEvaluacion.Controls.Add(Me.btnBuscarTE)
        Me.gbTipoEvaluacion.Controls.Add(Me.txtNombreTE)
        Me.gbTipoEvaluacion.Controls.Add(Me.txtCodigoTE)
        Me.gbTipoEvaluacion.Controls.Add(Me.lblCodigoTE)
        Me.gbTipoEvaluacion.Location = New System.Drawing.Point(5, 46)
        Me.gbTipoEvaluacion.Name = "gbTipoEvaluacion"
        Me.gbTipoEvaluacion.Size = New System.Drawing.Size(578, 45)
        Me.gbTipoEvaluacion.TabIndex = 1
        Me.gbTipoEvaluacion.TabStop = False
        Me.gbTipoEvaluacion.Text = "Tipo de evalución"
        '
        'lblNombreTE
        '
        Me.lblNombreTE.AutoSize = True
        Me.lblNombreTE.Location = New System.Drawing.Point(151, 21)
        Me.lblNombreTE.Name = "lblNombreTE"
        Me.lblNombreTE.Size = New System.Drawing.Size(47, 13)
        Me.lblNombreTE.TabIndex = 4
        Me.lblNombreTE.Text = "Nombre:"
        Me.lblNombreTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAsignarTE
        '
        Me.btnAsignarTE.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignarTE.ImageKey = "checkok.png"
        Me.btnAsignarTE.ImageList = Me.ImageNuevos
        Me.btnAsignarTE.Location = New System.Drawing.Point(533, 10)
        Me.btnAsignarTE.Name = "btnAsignarTE"
        Me.btnAsignarTE.Size = New System.Drawing.Size(40, 32)
        Me.btnAsignarTE.TabIndex = 4
        Me.ToolTip.SetToolTip(Me.btnAsignarTE, "Asignar tipo de evaluación")
        Me.btnAsignarTE.UseVisualStyleBackColor = False
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
        'btnBuscarTE
        '
        Me.btnBuscarTE.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarTE.ImageKey = "buscar2.png"
        Me.btnBuscarTE.ImageList = Me.ImageNuevos
        Me.btnBuscarTE.Location = New System.Drawing.Point(491, 10)
        Me.btnBuscarTE.Name = "btnBuscarTE"
        Me.btnBuscarTE.Size = New System.Drawing.Size(40, 32)
        Me.btnBuscarTE.TabIndex = 3
        Me.ToolTip.SetToolTip(Me.btnBuscarTE, "Buscar tipo de evaluación")
        Me.btnBuscarTE.UseVisualStyleBackColor = False
        '
        'txtNombreTE
        '
        Me.txtNombreTE.Location = New System.Drawing.Point(220, 18)
        Me.txtNombreTE.Name = "txtNombreTE"
        Me.txtNombreTE.Size = New System.Drawing.Size(265, 20)
        Me.txtNombreTE.TabIndex = 2
        '
        'txtCodigoTE
        '
        Me.txtCodigoTE.Location = New System.Drawing.Point(72, 18)
        Me.txtCodigoTE.Name = "txtCodigoTE"
        Me.txtCodigoTE.Size = New System.Drawing.Size(66, 20)
        Me.txtCodigoTE.TabIndex = 1
        '
        'lblCodigoTE
        '
        Me.lblCodigoTE.AutoSize = True
        Me.lblCodigoTE.Location = New System.Drawing.Point(8, 18)
        Me.lblCodigoTE.Name = "lblCodigoTE"
        Me.lblCodigoTE.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigoTE.TabIndex = 34
        Me.lblCodigoTE.Text = "Código:"
        Me.lblCodigoTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCiclo
        '
        Me.txtCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCiclo.Location = New System.Drawing.Point(1018, 17)
        Me.txtCiclo.Margin = New System.Windows.Forms.Padding(0)
        Me.txtCiclo.Mask = "0000"
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(65, 20)
        Me.txtCiclo.TabIndex = 4
        '
        'lblCiclo
        '
        Me.lblCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCiclo.AutoSize = True
        Me.lblCiclo.ForeColor = System.Drawing.Color.White
        Me.lblCiclo.Location = New System.Drawing.Point(965, 17)
        Me.lblCiclo.Name = "lblCiclo"
        Me.lblCiclo.Size = New System.Drawing.Size(33, 13)
        Me.lblCiclo.TabIndex = 1
        Me.lblCiclo.Text = "Ciclo:"
        Me.lblCiclo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdPreguntas
        '
        Me.grdPreguntas.AllowUserToAddRows = False
        Me.grdPreguntas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen
        Me.grdPreguntas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdPreguntas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdPreguntas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdPreguntas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grdPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPreguntas.ContextMenuStrip = Me.ctxMenu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPreguntas.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdPreguntas.GridColor = System.Drawing.Color.WhiteSmoke
        Me.grdPreguntas.Location = New System.Drawing.Point(0, 249)
        Me.grdPreguntas.MultiSelect = False
        Me.grdPreguntas.Name = "grdPreguntas"
        Me.grdPreguntas.Size = New System.Drawing.Size(1130, 356)
        Me.grdPreguntas.TabIndex = 10
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModificar, Me.ctxEliminar})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(126, 48)
        '
        'ctxModificar
        '
        Me.ctxModificar.Name = "ctxModificar"
        Me.ctxModificar.Size = New System.Drawing.Size(125, 22)
        Me.ctxModificar.Text = "Modificar"
        '
        'ctxEliminar
        '
        Me.ctxEliminar.Name = "ctxEliminar"
        Me.ctxEliminar.Size = New System.Drawing.Size(125, 22)
        Me.ctxEliminar.Text = "Eliminar"
        '
        'gbPregunta
        '
        Me.gbPregunta.BackColor = System.Drawing.Color.AliceBlue
        Me.gbPregunta.Controls.Add(Me.btnGuardar2)
        Me.gbPregunta.Controls.Add(Me.cmbRasgo)
        Me.gbPregunta.Controls.Add(Me.gbOpciones)
        Me.gbPregunta.Controls.Add(Me.Label2)
        Me.gbPregunta.Controls.Add(Me.lbMensaje)
        Me.gbPregunta.Controls.Add(Me.txtNumLinea)
        Me.gbPregunta.Controls.Add(Me.Label1)
        Me.gbPregunta.Controls.Add(Me.btnCancelar)
        Me.gbPregunta.Controls.Add(Me.btnGuardar)
        Me.gbPregunta.Controls.Add(Me.txtInstrucciones)
        Me.gbPregunta.Controls.Add(Me.lblInstrucciones)
        Me.gbPregunta.Controls.Add(Me.chkVertical)
        Me.gbPregunta.Controls.Add(Me.txtPregunta)
        Me.gbPregunta.Controls.Add(Me.lblNombre)
        Me.gbPregunta.Controls.Add(Me.cmbGrupo)
        Me.gbPregunta.Controls.Add(Me.lblGrupo)
        Me.gbPregunta.Controls.Add(Me.cmbCompetencia)
        Me.gbPregunta.Controls.Add(Me.lblCompetencia)
        Me.gbPregunta.Enabled = False
        Me.gbPregunta.Location = New System.Drawing.Point(5, 99)
        Me.gbPregunta.Name = "gbPregunta"
        Me.gbPregunta.Size = New System.Drawing.Size(1121, 143)
        Me.gbPregunta.TabIndex = 3
        Me.gbPregunta.TabStop = False
        Me.gbPregunta.Text = "Pregunta"
        '
        'btnGuardar2
        '
        Me.btnGuardar2.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar2.ImageKey = "guardar.png"
        Me.btnGuardar2.ImageList = Me.ImageNuevos
        Me.btnGuardar2.Location = New System.Drawing.Point(952, 64)
        Me.btnGuardar2.Name = "btnGuardar2"
        Me.btnGuardar2.Size = New System.Drawing.Size(161, 43)
        Me.btnGuardar2.TabIndex = 24
        Me.btnGuardar2.Text = "Actualización desde Grid"
        Me.btnGuardar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.btnGuardar2, "Modificación Orden, preguntas e instrucciones")
        Me.btnGuardar2.UseVisualStyleBackColor = False
        '
        'cmbRasgo
        '
        Me.cmbRasgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRasgo.FormattingEnabled = True
        Me.cmbRasgo.Location = New System.Drawing.Point(517, 13)
        Me.cmbRasgo.Name = "cmbRasgo"
        Me.cmbRasgo.Size = New System.Drawing.Size(205, 21)
        Me.cmbRasgo.TabIndex = 2
        '
        'gbOpciones
        '
        Me.gbOpciones.BackColor = System.Drawing.Color.AliceBlue
        Me.gbOpciones.Controls.Add(Me.nudMax)
        Me.gbOpciones.Controls.Add(Me.txtOpMin)
        Me.gbOpciones.Controls.Add(Me.Label3)
        Me.gbOpciones.Controls.Add(Me.Label4)
        Me.gbOpciones.Location = New System.Drawing.Point(848, 16)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(265, 45)
        Me.gbOpciones.TabIndex = 10
        Me.gbOpciones.TabStop = False
        Me.gbOpciones.Text = "Opciones"
        '
        'nudMax
        '
        Me.nudMax.Location = New System.Drawing.Point(195, 15)
        Me.nudMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudMax.Name = "nudMax"
        Me.nudMax.Size = New System.Drawing.Size(67, 20)
        Me.nudMax.TabIndex = 2
        Me.nudMax.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtOpMin
        '
        Me.txtOpMin.Location = New System.Drawing.Point(62, 14)
        Me.txtOpMin.Name = "txtOpMin"
        Me.txtOpMin.ReadOnly = True
        Me.txtOpMin.Size = New System.Drawing.Size(64, 20)
        Me.txtOpMin.TabIndex = 1
        Me.txtOpMin.Text = "1"
        Me.txtOpMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(138, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Máximas:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Minimas:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(444, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Rasgos:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbMensaje
        '
        Me.lbMensaje.AutoSize = True
        Me.lbMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMensaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbMensaje.Location = New System.Drawing.Point(919, 119)
        Me.lbMensaje.Name = "lbMensaje"
        Me.lbMensaje.Size = New System.Drawing.Size(15, 16)
        Me.lbMensaje.TabIndex = 22
        Me.lbMensaje.Text = "1"
        '
        'txtNumLinea
        '
        Me.txtNumLinea.Location = New System.Drawing.Point(81, 15)
        Me.txtNumLinea.Name = "txtNumLinea"
        Me.txtNumLinea.Size = New System.Drawing.Size(66, 20)
        Me.txtNumLinea.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Número línea:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.ImageKey = "cancelar.png"
        Me.btnCancelar.ImageList = Me.ImageNuevos
        Me.btnCancelar.Location = New System.Drawing.Point(873, 69)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(40, 32)
        Me.btnCancelar.TabIndex = 9
        Me.ToolTip.SetToolTip(Me.btnCancelar, "Cancelar")
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(873, 103)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(40, 32)
        Me.btnGuardar.TabIndex = 8
        Me.ToolTip.SetToolTip(Me.btnGuardar, "Guardar Pregunta")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'txtInstrucciones
        '
        Me.txtInstrucciones.Location = New System.Drawing.Point(517, 68)
        Me.txtInstrucciones.Multiline = True
        Me.txtInstrucciones.Name = "txtInstrucciones"
        Me.txtInstrucciones.Size = New System.Drawing.Size(350, 67)
        Me.txtInstrucciones.TabIndex = 7
        '
        'lblInstrucciones
        '
        Me.lblInstrucciones.AutoSize = True
        Me.lblInstrucciones.Location = New System.Drawing.Point(444, 71)
        Me.lblInstrucciones.Name = "lblInstrucciones"
        Me.lblInstrucciones.Size = New System.Drawing.Size(73, 13)
        Me.lblInstrucciones.TabIndex = 17
        Me.lblInstrucciones.Text = "Instrucciones:"
        Me.lblInstrucciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkVertical
        '
        Me.chkVertical.AutoSize = True
        Me.chkVertical.Location = New System.Drawing.Point(731, 44)
        Me.chkVertical.Name = "chkVertical"
        Me.chkVertical.Size = New System.Drawing.Size(61, 17)
        Me.chkVertical.TabIndex = 5
        Me.chkVertical.Text = "Vertical"
        Me.chkVertical.UseVisualStyleBackColor = True
        '
        'txtPregunta
        '
        Me.txtPregunta.Location = New System.Drawing.Point(81, 70)
        Me.txtPregunta.Multiline = True
        Me.txtPregunta.Name = "txtPregunta"
        Me.txtPregunta.Size = New System.Drawing.Size(347, 65)
        Me.txtPregunta.TabIndex = 6
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(2, 72)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(53, 13)
        Me.lblNombre.TabIndex = 15
        Me.lblNombre.Text = "Pregunta:"
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbGrupo
        '
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(517, 42)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(205, 21)
        Me.cmbGrupo.TabIndex = 4
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Location = New System.Drawing.Point(444, 46)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(39, 13)
        Me.lblGrupo.TabIndex = 13
        Me.lblGrupo.Text = "Grupo:"
        Me.lblGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCompetencia
        '
        Me.cmbCompetencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompetencia.FormattingEnabled = True
        Me.cmbCompetencia.Location = New System.Drawing.Point(81, 43)
        Me.cmbCompetencia.Name = "cmbCompetencia"
        Me.cmbCompetencia.Size = New System.Drawing.Size(205, 21)
        Me.cmbCompetencia.TabIndex = 3
        '
        'lblCompetencia
        '
        Me.lblCompetencia.AutoSize = True
        Me.lblCompetencia.Location = New System.Drawing.Point(2, 47)
        Me.lblCompetencia.Name = "lblCompetencia"
        Me.lblCompetencia.Size = New System.Drawing.Size(72, 13)
        Me.lblCompetencia.TabIndex = 11
        Me.lblCompetencia.Text = "Competencia:"
        Me.lblCompetencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolTip
        '
        Me.ToolTip.AutoPopDelay = 5000
        Me.ToolTip.InitialDelay = 500
        Me.ToolTip.ReshowDelay = 500
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(1086, 5)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(40, 32)
        Me.btnLimpiar.TabIndex = 20
        Me.ToolTip.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'ep
        '
        Me.ep.ContainerControl = Me
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.txtCiclo)
        Me.Panel1.Controls.Add(Me.lblCiclo)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 44)
        Me.Panel1.TabIndex = 21
        '
        'frmEvaluaPreguntas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.gbPregunta)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grdPreguntas)
        Me.Controls.Add(Me.gbTipoEvaluacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEvaluaPreguntas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preguntas de Evaluación"
        Me.gbTipoEvaluacion.ResumeLayout(False)
        Me.gbTipoEvaluacion.PerformLayout()
        CType(Me.grdPreguntas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        Me.gbPregunta.ResumeLayout(False)
        Me.gbPregunta.PerformLayout()
        Me.gbOpciones.ResumeLayout(False)
        Me.gbOpciones.PerformLayout()
        CType(Me.nudMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTipoEvaluacion As System.Windows.Forms.GroupBox
    Friend WithEvents btnAsignarTE As System.Windows.Forms.Button
    Friend WithEvents btnBuscarTE As System.Windows.Forms.Button
    Friend WithEvents txtNombreTE As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoTE As System.Windows.Forms.TextBox
    Friend WithEvents txtCiclo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCiclo As System.Windows.Forms.Label
    Friend WithEvents lblNombreTE As System.Windows.Forms.Label
    Friend WithEvents lblCodigoTE As System.Windows.Forms.Label
    Friend WithEvents grdPreguntas As System.Windows.Forms.DataGridView
    Friend WithEvents gbPregunta As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents cmbCompetencia As System.Windows.Forms.ComboBox
    Friend WithEvents lblCompetencia As System.Windows.Forms.Label
    Friend WithEvents txtPregunta As System.Windows.Forms.TextBox
    Friend WithEvents chkVertical As System.Windows.Forms.CheckBox
    Friend WithEvents lblInstrucciones As System.Windows.Forms.Label
    Friend WithEvents txtInstrucciones As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtNumLinea As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbMensaje As System.Windows.Forms.Label
    Friend WithEvents cmbRasgo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gbOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents txtOpMin As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudMax As NumericUpDown
    Friend WithEvents btnGuardar2 As Button
End Class
