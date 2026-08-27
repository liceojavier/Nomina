<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoEvaluacionAsignacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoEvaluacionAsignacion))
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CachedCryConsultaxComentarios1 = New NOMINA.CachedCryConsultaxComentarios()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.pnDetalle = New System.Windows.Forms.Panel()
        Me.gpCiclo = New System.Windows.Forms.GroupBox()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbOrdenEvaluador = New System.Windows.Forms.RadioButton()
        Me.rbOrdenEvaluado = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbTotales = New System.Windows.Forms.RadioButton()
        Me.rbAsignados = New System.Windows.Forms.RadioButton()
        Me.rbFaltaEvaluar = New System.Windows.Forms.RadioButton()
        Me.rbEvaluados = New System.Windows.Forms.RadioButton()
        Me.gpEvaluador = New System.Windows.Forms.GroupBox()
        Me.btnEvaluador = New System.Windows.Forms.Button()
        Me.txtNombreEva = New System.Windows.Forms.TextBox()
        Me.txtCodigoEva = New System.Windows.Forms.TextBox()
        Me.gpEmpleado = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.txtNomEmpleado = New System.Windows.Forms.TextBox()
        Me.txtCodEmpleado = New System.Windows.Forms.TextBox()
        Me.gpTipoEvaluacion = New System.Windows.Forms.GroupBox()
        Me.cmbTipoTest = New System.Windows.Forms.ComboBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDetalle.SuspendLayout()
        Me.gpCiclo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gpEvaluador.SuspendLayout()
        Me.gpEmpleado.SuspendLayout()
        Me.gpTipoEvaluacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Location = New System.Drawing.Point(0, 136)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowGroupTreeButton = False
        Me.crv.ShowRefreshButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 469)
        Me.crv.TabIndex = 77
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ViewTimeSelectionFormula = ""
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
        'pnDetalle
        '
        Me.pnDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.pnDetalle.Controls.Add(Me.gpCiclo)
        Me.pnDetalle.Controls.Add(Me.GroupBox1)
        Me.pnDetalle.Controls.Add(Me.GroupBox2)
        Me.pnDetalle.Controls.Add(Me.gpEvaluador)
        Me.pnDetalle.Controls.Add(Me.gpEmpleado)
        Me.pnDetalle.Controls.Add(Me.gpTipoEvaluacion)
        Me.pnDetalle.Controls.Add(Me.btnAgregar)
        Me.pnDetalle.Controls.Add(Me.btnLimpiar)
        Me.pnDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnDetalle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnDetalle.Location = New System.Drawing.Point(0, 0)
        Me.pnDetalle.Name = "pnDetalle"
        Me.pnDetalle.Size = New System.Drawing.Size(1130, 130)
        Me.pnDetalle.TabIndex = 76
        '
        'gpCiclo
        '
        Me.gpCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpCiclo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpCiclo.Controls.Add(Me.txtCiclo)
        Me.gpCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCiclo.ForeColor = System.Drawing.Color.White
        Me.gpCiclo.Location = New System.Drawing.Point(1042, 3)
        Me.gpCiclo.Name = "gpCiclo"
        Me.gpCiclo.Size = New System.Drawing.Size(83, 40)
        Me.gpCiclo.TabIndex = 8
        Me.gpCiclo.TabStop = False
        Me.gpCiclo.Text = "Ciclo"
        '
        'txtCiclo
        '
        Me.txtCiclo.BackColor = System.Drawing.Color.White
        Me.txtCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCiclo.ForeColor = System.Drawing.Color.Red
        Me.txtCiclo.Location = New System.Drawing.Point(10, 14)
        Me.txtCiclo.MaxLength = 4
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(63, 22)
        Me.txtCiclo.TabIndex = 1
        Me.txtCiclo.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.rbOrdenEvaluador)
        Me.GroupBox1.Controls.Add(Me.rbOrdenEvaluado)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(160, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(149, 56)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de orden"
        '
        'rbOrdenEvaluador
        '
        Me.rbOrdenEvaluador.AutoSize = True
        Me.rbOrdenEvaluador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOrdenEvaluador.Location = New System.Drawing.Point(7, 33)
        Me.rbOrdenEvaluador.Name = "rbOrdenEvaluador"
        Me.rbOrdenEvaluador.Size = New System.Drawing.Size(91, 17)
        Me.rbOrdenEvaluador.TabIndex = 1
        Me.rbOrdenEvaluador.Text = "Por evaluador"
        Me.rbOrdenEvaluador.UseVisualStyleBackColor = True
        '
        'rbOrdenEvaluado
        '
        Me.rbOrdenEvaluado.AutoSize = True
        Me.rbOrdenEvaluado.Checked = True
        Me.rbOrdenEvaluado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOrdenEvaluado.Location = New System.Drawing.Point(7, 14)
        Me.rbOrdenEvaluado.Name = "rbOrdenEvaluado"
        Me.rbOrdenEvaluado.Size = New System.Drawing.Size(88, 17)
        Me.rbOrdenEvaluado.TabIndex = 0
        Me.rbOrdenEvaluado.TabStop = True
        Me.rbOrdenEvaluado.Text = "Por evaluado"
        Me.rbOrdenEvaluado.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.rbTotales)
        Me.GroupBox2.Controls.Add(Me.rbAsignados)
        Me.GroupBox2.Controls.Add(Me.rbFaltaEvaluar)
        Me.GroupBox2.Controls.Add(Me.rbEvaluados)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(149, 96)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de reporte"
        '
        'rbTotales
        '
        Me.rbTotales.AutoSize = True
        Me.rbTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTotales.Location = New System.Drawing.Point(8, 75)
        Me.rbTotales.Name = "rbTotales"
        Me.rbTotales.Size = New System.Drawing.Size(60, 17)
        Me.rbTotales.TabIndex = 4
        Me.rbTotales.Text = "Totales"
        Me.rbTotales.UseVisualStyleBackColor = True
        '
        'rbAsignados
        '
        Me.rbAsignados.AutoSize = True
        Me.rbAsignados.Checked = True
        Me.rbAsignados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAsignados.Location = New System.Drawing.Point(7, 18)
        Me.rbAsignados.Name = "rbAsignados"
        Me.rbAsignados.Size = New System.Drawing.Size(74, 17)
        Me.rbAsignados.TabIndex = 1
        Me.rbAsignados.TabStop = True
        Me.rbAsignados.Text = "Asignados"
        Me.rbAsignados.UseVisualStyleBackColor = True
        '
        'rbFaltaEvaluar
        '
        Me.rbFaltaEvaluar.AutoSize = True
        Me.rbFaltaEvaluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFaltaEvaluar.Location = New System.Drawing.Point(7, 55)
        Me.rbFaltaEvaluar.Name = "rbFaltaEvaluar"
        Me.rbFaltaEvaluar.Size = New System.Drawing.Size(86, 17)
        Me.rbFaltaEvaluar.TabIndex = 3
        Me.rbFaltaEvaluar.Text = "Falta evaluar"
        Me.rbFaltaEvaluar.UseVisualStyleBackColor = True
        '
        'rbEvaluados
        '
        Me.rbEvaluados.AutoSize = True
        Me.rbEvaluados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEvaluados.Location = New System.Drawing.Point(7, 36)
        Me.rbEvaluados.Name = "rbEvaluados"
        Me.rbEvaluados.Size = New System.Drawing.Size(75, 17)
        Me.rbEvaluados.TabIndex = 2
        Me.rbEvaluados.Text = "Evaluados"
        Me.rbEvaluados.UseVisualStyleBackColor = True
        '
        'gpEvaluador
        '
        Me.gpEvaluador.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEvaluador.Controls.Add(Me.btnEvaluador)
        Me.gpEvaluador.Controls.Add(Me.txtNombreEva)
        Me.gpEvaluador.Controls.Add(Me.txtCodigoEva)
        Me.gpEvaluador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEvaluador.ForeColor = System.Drawing.Color.White
        Me.gpEvaluador.Location = New System.Drawing.Point(360, 83)
        Me.gpEvaluador.Name = "gpEvaluador"
        Me.gpEvaluador.Size = New System.Drawing.Size(622, 40)
        Me.gpEvaluador.TabIndex = 5
        Me.gpEvaluador.TabStop = False
        Me.gpEvaluador.Text = "Evaluador"
        '
        'btnEvaluador
        '
        Me.btnEvaluador.BackColor = System.Drawing.SystemColors.Control
        Me.btnEvaluador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEvaluador.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEvaluador.ImageKey = "usuario.png"
        Me.btnEvaluador.ImageList = Me.ImageNuevos
        Me.btnEvaluador.Location = New System.Drawing.Point(520, 8)
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
        Me.txtNombreEva.Location = New System.Drawing.Point(66, 15)
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
        Me.txtCodigoEva.Location = New System.Drawing.Point(6, 15)
        Me.txtCodigoEva.MaxLength = 6
        Me.txtCodigoEva.Name = "txtCodigoEva"
        Me.txtCodigoEva.Size = New System.Drawing.Size(56, 20)
        Me.txtCodigoEva.TabIndex = 1
        '
        'gpEmpleado
        '
        Me.gpEmpleado.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpleado.Controls.Add(Me.btnEmpleado)
        Me.gpEmpleado.Controls.Add(Me.txtNomEmpleado)
        Me.gpEmpleado.Controls.Add(Me.txtCodEmpleado)
        Me.gpEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpleado.ForeColor = System.Drawing.Color.White
        Me.gpEmpleado.Location = New System.Drawing.Point(360, 40)
        Me.gpEmpleado.Name = "gpEmpleado"
        Me.gpEmpleado.Size = New System.Drawing.Size(622, 40)
        Me.gpEmpleado.TabIndex = 4
        Me.gpEmpleado.TabStop = False
        Me.gpEmpleado.Text = "Empleado"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(520, 7)
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
        'gpTipoEvaluacion
        '
        Me.gpTipoEvaluacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpTipoEvaluacion.Controls.Add(Me.cmbTipoTest)
        Me.gpTipoEvaluacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTipoEvaluacion.ForeColor = System.Drawing.Color.White
        Me.gpTipoEvaluacion.Location = New System.Drawing.Point(360, 0)
        Me.gpTipoEvaluacion.Name = "gpTipoEvaluacion"
        Me.gpTipoEvaluacion.Size = New System.Drawing.Size(463, 39)
        Me.gpTipoEvaluacion.TabIndex = 3
        Me.gpTipoEvaluacion.TabStop = False
        Me.gpTipoEvaluacion.Text = "Tipo de evaluación"
        '
        'cmbTipoTest
        '
        Me.cmbTipoTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoTest.FormattingEnabled = True
        Me.cmbTipoTest.Location = New System.Drawing.Point(9, 14)
        Me.cmbTipoTest.Name = "cmbTipoTest"
        Me.cmbTipoTest.Size = New System.Drawing.Size(448, 21)
        Me.cmbTipoTest.TabIndex = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.ImageKey = "reportegenerar.png"
        Me.btnAgregar.ImageList = Me.ImageNuevos
        Me.btnAgregar.Location = New System.Drawing.Point(1001, 88)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 30)
        Me.btnAgregar.TabIndex = 7
        Me.btnAgregar.Text = "Generar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Generar")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(1001, 56)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'frmListadoEvaluacionAsignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.pnDetalle)
        Me.Controls.Add(Me.crv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListadoEvaluacionAsignacion"
        Me.Text = "Mantenimiento de Asignacion de Evaluacion"
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDetalle.ResumeLayout(False)
        Me.gpCiclo.ResumeLayout(False)
        Me.gpCiclo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gpEvaluador.ResumeLayout(False)
        Me.gpEvaluador.PerformLayout()
        Me.gpEmpleado.ResumeLayout(False)
        Me.gpEmpleado.PerformLayout()
        Me.gpTipoEvaluacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CachedCryConsultaxComentarios1 As NOMINA.CachedCryConsultaxComentarios
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents pnDetalle As System.Windows.Forms.Panel
    Friend WithEvents gpCiclo As System.Windows.Forms.GroupBox
    Friend WithEvents txtCiclo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbOrdenEvaluador As System.Windows.Forms.RadioButton
    Friend WithEvents rbOrdenEvaluado As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTotales As System.Windows.Forms.RadioButton
    Friend WithEvents rbAsignados As System.Windows.Forms.RadioButton
    Friend WithEvents rbFaltaEvaluar As System.Windows.Forms.RadioButton
    Friend WithEvents rbEvaluados As System.Windows.Forms.RadioButton
    Friend WithEvents gpEvaluador As System.Windows.Forms.GroupBox
    Friend WithEvents btnEvaluador As System.Windows.Forms.Button
    Friend WithEvents txtNombreEva As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoEva As System.Windows.Forms.TextBox
    Friend WithEvents gpEmpleado As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents txtNomEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents txtCodEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents gpTipoEvaluacion As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipoTest As System.Windows.Forms.ComboBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
