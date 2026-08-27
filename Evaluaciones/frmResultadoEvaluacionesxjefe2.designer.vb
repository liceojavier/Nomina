<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResultadoEvaluacionesxjefe2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResultadoEvaluacionesxjefe2))
        Me.gpRepores = New System.Windows.Forms.GroupBox()
        Me.rbPorcentaje = New System.Windows.Forms.RadioButton()
        Me.rbDestreza = New System.Windows.Forms.RadioButton()
        Me.rbCompetencias = New System.Windows.Forms.RadioButton()
        Me.cmbTipoEmpleado = New System.Windows.Forms.ComboBox()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextEmpresa = New System.Windows.Forms.TextBox()
        Me.gpTipo = New System.Windows.Forms.GroupBox()
        Me.cmbtipotest = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTipoEmpleado = New System.Windows.Forms.Label()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.gpEvaluado = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.gpPuesto = New System.Windows.Forms.GroupBox()
        Me.btnPuesto = New System.Windows.Forms.Button()
        Me.TextNombPuesto = New System.Windows.Forms.TextBox()
        Me.TextPuesto = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gpCiclo = New System.Windows.Forms.GroupBox()
        Me.TextCiclo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpRepores.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        Me.gpTipo.SuspendLayout()
        Me.gpEvaluado.SuspendLayout()
        Me.gpPuesto.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpCiclo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpRepores
        '
        Me.gpRepores.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpRepores.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpRepores.Controls.Add(Me.rbPorcentaje)
        Me.gpRepores.Controls.Add(Me.rbDestreza)
        Me.gpRepores.Controls.Add(Me.rbCompetencias)
        Me.gpRepores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpRepores.ForeColor = System.Drawing.Color.White
        Me.gpRepores.Location = New System.Drawing.Point(7, 40)
        Me.gpRepores.Name = "gpRepores"
        Me.gpRepores.Size = New System.Drawing.Size(154, 98)
        Me.gpRepores.TabIndex = 35
        Me.gpRepores.TabStop = False
        Me.gpRepores.Text = "Tipo de Reporte"
        '
        'rbPorcentaje
        '
        Me.rbPorcentaje.AutoSize = True
        Me.rbPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPorcentaje.Location = New System.Drawing.Point(8, 70)
        Me.rbPorcentaje.Name = "rbPorcentaje"
        Me.rbPorcentaje.Size = New System.Drawing.Size(95, 17)
        Me.rbPorcentaje.TabIndex = 3
        Me.rbPorcentaje.Text = "Por Porcentaje"
        Me.rbPorcentaje.UseVisualStyleBackColor = True
        '
        'rbDestreza
        '
        Me.rbDestreza.AutoSize = True
        Me.rbDestreza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDestreza.Location = New System.Drawing.Point(8, 44)
        Me.rbDestreza.Name = "rbDestreza"
        Me.rbDestreza.Size = New System.Drawing.Size(91, 17)
        Me.rbDestreza.TabIndex = 2
        Me.rbDestreza.Text = "Por Destrezas"
        Me.rbDestreza.UseVisualStyleBackColor = True
        '
        'rbCompetencias
        '
        Me.rbCompetencias.AutoSize = True
        Me.rbCompetencias.Checked = True
        Me.rbCompetencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCompetencias.Location = New System.Drawing.Point(8, 20)
        Me.rbCompetencias.Name = "rbCompetencias"
        Me.rbCompetencias.Size = New System.Drawing.Size(111, 17)
        Me.rbCompetencias.TabIndex = 0
        Me.rbCompetencias.TabStop = True
        Me.rbCompetencias.Text = "Por Competencias"
        Me.rbCompetencias.UseVisualStyleBackColor = True
        '
        'cmbTipoEmpleado
        '
        Me.cmbTipoEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoEmpleado.FormattingEnabled = True
        Me.cmbTipoEmpleado.Location = New System.Drawing.Point(116, 36)
        Me.cmbTipoEmpleado.Name = "cmbTipoEmpleado"
        Me.cmbTipoEmpleado.Size = New System.Drawing.Size(164, 21)
        Me.cmbTipoEmpleado.TabIndex = 36
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(368, 0)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(437, 41)
        Me.gpEmpresa.TabIndex = 38
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextEmpresa
        '
        Me.TextEmpresa.BackColor = System.Drawing.Color.White
        Me.TextEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEmpresa.Location = New System.Drawing.Point(6, 15)
        Me.TextEmpresa.MaxLength = 30
        Me.TextEmpresa.Name = "TextEmpresa"
        Me.TextEmpresa.ReadOnly = True
        Me.TextEmpresa.Size = New System.Drawing.Size(425, 20)
        Me.TextEmpresa.TabIndex = 1
        Me.TextEmpresa.TabStop = False
        '
        'gpTipo
        '
        Me.gpTipo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpTipo.Controls.Add(Me.cmbtipotest)
        Me.gpTipo.Controls.Add(Me.Label2)
        Me.gpTipo.Controls.Add(Me.lblTipoEmpleado)
        Me.gpTipo.Controls.Add(Me.cmbTipoEmpleado)
        Me.gpTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTipo.ForeColor = System.Drawing.Color.White
        Me.gpTipo.Location = New System.Drawing.Point(764, 40)
        Me.gpTipo.Name = "gpTipo"
        Me.gpTipo.Size = New System.Drawing.Size(288, 66)
        Me.gpTipo.TabIndex = 39
        Me.gpTipo.TabStop = False
        '
        'cmbtipotest
        '
        Me.cmbtipotest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtipotest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtipotest.FormattingEnabled = True
        Me.cmbtipotest.Location = New System.Drawing.Point(116, 8)
        Me.cmbtipotest.Name = "cmbtipotest"
        Me.cmbtipotest.Size = New System.Drawing.Size(164, 21)
        Me.cmbtipotest.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Tipo de test:"
        '
        'lblTipoEmpleado
        '
        Me.lblTipoEmpleado.AutoSize = True
        Me.lblTipoEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoEmpleado.Location = New System.Drawing.Point(6, 39)
        Me.lblTipoEmpleado.Name = "lblTipoEmpleado"
        Me.lblTipoEmpleado.Size = New System.Drawing.Size(95, 13)
        Me.lblTipoEmpleado.TabIndex = 38
        Me.lblTipoEmpleado.Text = "Tipo de empleado:"
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ImageKey = "reportegenerar.png"
        Me.btnGenerar.ImageList = Me.ImageNuevos
        Me.btnGenerar.Location = New System.Drawing.Point(995, 6)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(60, 30)
        Me.btnGenerar.TabIndex = 67
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnGenerar, "Generar")
        Me.btnGenerar.UseVisualStyleBackColor = False
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
        'gpEvaluado
        '
        Me.gpEvaluado.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEvaluado.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEvaluado.Controls.Add(Me.btnEmpleado)
        Me.gpEvaluado.Controls.Add(Me.textNombreEmple)
        Me.gpEvaluado.Controls.Add(Me.textEmpleado)
        Me.gpEvaluado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEvaluado.ForeColor = System.Drawing.Color.White
        Me.gpEvaluado.Location = New System.Drawing.Point(235, 40)
        Me.gpEvaluado.Name = "gpEvaluado"
        Me.gpEvaluado.Size = New System.Drawing.Size(525, 44)
        Me.gpEvaluado.TabIndex = 40
        Me.gpEvaluado.TabStop = False
        Me.gpEvaluado.Text = "Empleado evaluador"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(429, 7)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(60, 30)
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
        Me.textNombreEmple.Location = New System.Drawing.Point(62, 17)
        Me.textNombreEmple.MaxLength = 40
        Me.textNombreEmple.Name = "textNombreEmple"
        Me.textNombreEmple.Size = New System.Drawing.Size(363, 20)
        Me.textNombreEmple.TabIndex = 2
        '
        'textEmpleado
        '
        Me.textEmpleado.BackColor = System.Drawing.Color.White
        Me.textEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textEmpleado.Location = New System.Drawing.Point(6, 17)
        Me.textEmpleado.MaxLength = 6
        Me.textEmpleado.Name = "textEmpleado"
        Me.textEmpleado.Size = New System.Drawing.Size(54, 20)
        Me.textEmpleado.TabIndex = 1
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Location = New System.Drawing.Point(0, 147)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowGroupTreeButton = False
        Me.crv.ShowRefreshButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 458)
        Me.crv.TabIndex = 68
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'gpPuesto
        '
        Me.gpPuesto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpPuesto.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpPuesto.Controls.Add(Me.btnPuesto)
        Me.gpPuesto.Controls.Add(Me.TextNombPuesto)
        Me.gpPuesto.Controls.Add(Me.TextPuesto)
        Me.gpPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpPuesto.ForeColor = System.Drawing.Color.White
        Me.gpPuesto.Location = New System.Drawing.Point(235, 88)
        Me.gpPuesto.Name = "gpPuesto"
        Me.gpPuesto.Size = New System.Drawing.Size(525, 44)
        Me.gpPuesto.TabIndex = 69
        Me.gpPuesto.TabStop = False
        Me.gpPuesto.Text = "Puesto"
        '
        'btnPuesto
        '
        Me.btnPuesto.BackColor = System.Drawing.SystemColors.Control
        Me.btnPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPuesto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPuesto.ImageKey = "buscar1.png"
        Me.btnPuesto.ImageList = Me.ImageNuevos
        Me.btnPuesto.Location = New System.Drawing.Point(429, 7)
        Me.btnPuesto.Name = "btnPuesto"
        Me.btnPuesto.Size = New System.Drawing.Size(60, 30)
        Me.btnPuesto.TabIndex = 3
        Me.btnPuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnPuesto, "Puesto")
        Me.btnPuesto.UseVisualStyleBackColor = False
        '
        'TextNombPuesto
        '
        Me.TextNombPuesto.BackColor = System.Drawing.Color.White
        Me.TextNombPuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombPuesto.Location = New System.Drawing.Point(64, 17)
        Me.TextNombPuesto.MaxLength = 40
        Me.TextNombPuesto.Name = "TextNombPuesto"
        Me.TextNombPuesto.Size = New System.Drawing.Size(363, 20)
        Me.TextNombPuesto.TabIndex = 2
        '
        'TextPuesto
        '
        Me.TextPuesto.BackColor = System.Drawing.Color.White
        Me.TextPuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPuesto.Location = New System.Drawing.Point(6, 17)
        Me.TextPuesto.MaxLength = 6
        Me.TextPuesto.Name = "TextPuesto"
        Me.TextPuesto.Size = New System.Drawing.Size(56, 20)
        Me.TextPuesto.TabIndex = 1
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(1061, 6)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 30)
        Me.btnLimpiar.TabIndex = 70
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'gpCiclo
        '
        Me.gpCiclo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpCiclo.Controls.Add(Me.TextCiclo)
        Me.gpCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCiclo.ForeColor = System.Drawing.Color.White
        Me.gpCiclo.Location = New System.Drawing.Point(6, -1)
        Me.gpCiclo.Name = "gpCiclo"
        Me.gpCiclo.Size = New System.Drawing.Size(61, 41)
        Me.gpCiclo.TabIndex = 71
        Me.gpCiclo.TabStop = False
        Me.gpCiclo.Text = "Ciclo"
        '
        'TextCiclo
        '
        Me.TextCiclo.BackColor = System.Drawing.Color.White
        Me.TextCiclo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCiclo.ForeColor = System.Drawing.Color.Red
        Me.TextCiclo.Location = New System.Drawing.Point(6, 15)
        Me.TextCiclo.MaxLength = 30
        Me.TextCiclo.Name = "TextCiclo"
        Me.TextCiclo.Size = New System.Drawing.Size(49, 20)
        Me.TextCiclo.TabIndex = 1
        Me.TextCiclo.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpPuesto)
        Me.Panel1.Controls.Add(Me.gpTipo)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gpCiclo)
        Me.Panel1.Controls.Add(Me.gpEvaluado)
        Me.Panel1.Controls.Add(Me.btnGenerar)
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Controls.Add(Me.gpRepores)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 141)
        Me.Panel1.TabIndex = 72
        '
        'frmResultadoEvaluacionesxjefe2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmResultadoEvaluacionesxjefe2"
        Me.Text = "Resultados de Evaluaciones por Evaluador"
        Me.gpRepores.ResumeLayout(False)
        Me.gpRepores.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.gpTipo.ResumeLayout(False)
        Me.gpTipo.PerformLayout()
        Me.gpEvaluado.ResumeLayout(False)
        Me.gpEvaluado.PerformLayout()
        Me.gpPuesto.ResumeLayout(False)
        Me.gpPuesto.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpCiclo.ResumeLayout(False)
        Me.gpCiclo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpRepores As System.Windows.Forms.GroupBox
    Friend WithEvents rbPorcentaje As System.Windows.Forms.RadioButton
    Friend WithEvents rbDestreza As System.Windows.Forms.RadioButton
    Friend WithEvents rbCompetencias As System.Windows.Forms.RadioButton
    Friend WithEvents cmbTipoEmpleado As System.Windows.Forms.ComboBox
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents gpTipo As System.Windows.Forms.GroupBox
    Friend WithEvents lblTipoEmpleado As System.Windows.Forms.Label
    Friend WithEvents gpEvaluado As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents gpPuesto As System.Windows.Forms.GroupBox
    Friend WithEvents btnPuesto As System.Windows.Forms.Button
    Friend WithEvents TextNombPuesto As System.Windows.Forms.TextBox
    Friend WithEvents TextPuesto As System.Windows.Forms.TextBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbtipotest As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents gpCiclo As System.Windows.Forms.GroupBox
    Friend WithEvents TextCiclo As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As ToolTip
End Class
