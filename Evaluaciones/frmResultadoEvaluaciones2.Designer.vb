<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResultadoEvaluaciones2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResultadoEvaluaciones2))
        Me.gpRepores = New System.Windows.Forms.GroupBox()
        Me.rbComentarios = New System.Windows.Forms.RadioButton()
        Me.rbPorcentaje = New System.Windows.Forms.RadioButton()
        Me.rbDestreza = New System.Windows.Forms.RadioButton()
        Me.rbCompetencias = New System.Windows.Forms.RadioButton()
        Me.rbPorcentajeAreas = New System.Windows.Forms.RadioButton()
        Me.cmbTipoEmpleado = New System.Windows.Forms.ComboBox()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextEmpresa = New System.Windows.Forms.TextBox()
        Me.gpTipo = New System.Windows.Forms.GroupBox()
        Me.lbArea = New System.Windows.Forms.Label()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.cmbtipotest = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTipoEmpleado = New System.Windows.Forms.Label()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.gpEvaluado = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.gpEvaluador = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado2 = New System.Windows.Forms.Button()
        Me.TextNombreEmple2 = New System.Windows.Forms.TextBox()
        Me.TextEmpleado2 = New System.Windows.Forms.TextBox()
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.gpPuesto = New System.Windows.Forms.GroupBox()
        Me.btnPuesto = New System.Windows.Forms.Button()
        Me.TextNombPuesto = New System.Windows.Forms.TextBox()
        Me.TextPuesto = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gpCiclo = New System.Windows.Forms.GroupBox()
        Me.TextCiclo = New System.Windows.Forms.TextBox()
        Me.gpabarca = New System.Windows.Forms.GroupBox()
        Me.rbEvaluado = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpRepores.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        Me.gpTipo.SuspendLayout()
        Me.gpEvaluado.SuspendLayout()
        Me.gpEvaluador.SuspendLayout()
        Me.gpPuesto.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpCiclo.SuspendLayout()
        Me.gpabarca.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpRepores
        '
        Me.gpRepores.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpRepores.Controls.Add(Me.rbComentarios)
        Me.gpRepores.Controls.Add(Me.rbPorcentaje)
        Me.gpRepores.Controls.Add(Me.rbDestreza)
        Me.gpRepores.Controls.Add(Me.rbCompetencias)
        Me.gpRepores.Controls.Add(Me.rbPorcentajeAreas)
        Me.gpRepores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpRepores.ForeColor = System.Drawing.Color.White
        Me.gpRepores.Location = New System.Drawing.Point(7, 39)
        Me.gpRepores.Name = "gpRepores"
        Me.gpRepores.Size = New System.Drawing.Size(175, 126)
        Me.gpRepores.TabIndex = 35
        Me.gpRepores.TabStop = False
        Me.gpRepores.Text = "Tipo de reporte"
        '
        'rbComentarios
        '
        Me.rbComentarios.AutoSize = True
        Me.rbComentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbComentarios.Location = New System.Drawing.Point(8, 102)
        Me.rbComentarios.Name = "rbComentarios"
        Me.rbComentarios.Size = New System.Drawing.Size(102, 17)
        Me.rbComentarios.TabIndex = 4
        Me.rbComentarios.Text = "Por Comentarios"
        Me.rbComentarios.UseVisualStyleBackColor = True
        '
        'rbPorcentaje
        '
        Me.rbPorcentaje.AutoSize = True
        Me.rbPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPorcentaje.Location = New System.Drawing.Point(8, 62)
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
        Me.rbDestreza.Location = New System.Drawing.Point(8, 41)
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
        'rbPorcentajeAreas
        '
        Me.rbPorcentajeAreas.AutoSize = True
        Me.rbPorcentajeAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPorcentajeAreas.Location = New System.Drawing.Point(8, 82)
        Me.rbPorcentajeAreas.Name = "rbPorcentajeAreas"
        Me.rbPorcentajeAreas.Size = New System.Drawing.Size(133, 17)
        Me.rbPorcentajeAreas.TabIndex = 5
        Me.rbPorcentajeAreas.Text = "Por Porcentaje y Areas"
        Me.rbPorcentajeAreas.UseVisualStyleBackColor = True
        '
        'cmbTipoEmpleado
        '
        Me.cmbTipoEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoEmpleado.FormattingEnabled = True
        Me.cmbTipoEmpleado.Location = New System.Drawing.Point(109, 49)
        Me.cmbTipoEmpleado.Name = "cmbTipoEmpleado"
        Me.cmbTipoEmpleado.Size = New System.Drawing.Size(241, 21)
        Me.cmbTipoEmpleado.TabIndex = 36
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(378, 0)
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
        Me.gpTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpTipo.Controls.Add(Me.lbArea)
        Me.gpTipo.Controls.Add(Me.cmbArea)
        Me.gpTipo.Controls.Add(Me.cmbtipotest)
        Me.gpTipo.Controls.Add(Me.Label2)
        Me.gpTipo.Controls.Add(Me.lblTipoEmpleado)
        Me.gpTipo.Controls.Add(Me.cmbTipoEmpleado)
        Me.gpTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTipo.ForeColor = System.Drawing.Color.White
        Me.gpTipo.Location = New System.Drawing.Point(733, 42)
        Me.gpTipo.Name = "gpTipo"
        Me.gpTipo.Size = New System.Drawing.Size(385, 116)
        Me.gpTipo.TabIndex = 39
        Me.gpTipo.TabStop = False
        '
        'lbArea
        '
        Me.lbArea.AutoSize = True
        Me.lbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbArea.Location = New System.Drawing.Point(6, 90)
        Me.lbArea.Name = "lbArea"
        Me.lbArea.Size = New System.Drawing.Size(32, 13)
        Me.lbArea.TabIndex = 71
        Me.lbArea.Text = "Area:"
        '
        'cmbArea
        '
        Me.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(109, 88)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(241, 21)
        Me.cmbArea.TabIndex = 70
        '
        'cmbtipotest
        '
        Me.cmbtipotest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtipotest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtipotest.FormattingEnabled = True
        Me.cmbtipotest.Location = New System.Drawing.Point(109, 9)
        Me.cmbtipotest.Name = "cmbtipotest"
        Me.cmbtipotest.Size = New System.Drawing.Size(241, 21)
        Me.cmbtipotest.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Tipo de test:"
        '
        'lblTipoEmpleado
        '
        Me.lblTipoEmpleado.AutoSize = True
        Me.lblTipoEmpleado.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.lblTipoEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoEmpleado.Location = New System.Drawing.Point(6, 52)
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
        Me.btnGenerar.Location = New System.Drawing.Point(994, 6)
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
        Me.gpEvaluado.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.gpEvaluado.Controls.Add(Me.gpEvaluador)
        Me.gpEvaluado.Controls.Add(Me.btnEmpleado)
        Me.gpEvaluado.Controls.Add(Me.textNombreEmple)
        Me.gpEvaluado.Controls.Add(Me.textEmpleado)
        Me.gpEvaluado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEvaluado.ForeColor = System.Drawing.Color.White
        Me.gpEvaluado.Location = New System.Drawing.Point(194, 39)
        Me.gpEvaluado.Name = "gpEvaluado"
        Me.gpEvaluado.Size = New System.Drawing.Size(536, 82)
        Me.gpEvaluado.TabIndex = 40
        Me.gpEvaluado.TabStop = False
        Me.gpEvaluado.Text = "EMPLEADO EVALUADO"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(432, 7)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(96, 36)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.Text = "Empleado"
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'gpEvaluador
        '
        Me.gpEvaluador.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEvaluador.Controls.Add(Me.btnEmpleado2)
        Me.gpEvaluador.Controls.Add(Me.TextNombreEmple2)
        Me.gpEvaluador.Controls.Add(Me.TextEmpleado2)
        Me.gpEvaluador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEvaluador.ForeColor = System.Drawing.Color.White
        Me.gpEvaluador.Location = New System.Drawing.Point(13, 43)
        Me.gpEvaluador.Name = "gpEvaluador"
        Me.gpEvaluador.Size = New System.Drawing.Size(536, 40)
        Me.gpEvaluador.TabIndex = 76
        Me.gpEvaluador.TabStop = False
        Me.gpEvaluador.Text = "Empleado evaluador"
        '
        'btnEmpleado2
        '
        Me.btnEmpleado2.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEmpleado2.ImageKey = "usuario.png"
        Me.btnEmpleado2.ImageList = Me.ImageNuevos
        Me.btnEmpleado2.Location = New System.Drawing.Point(432, 7)
        Me.btnEmpleado2.Name = "btnEmpleado2"
        Me.btnEmpleado2.Size = New System.Drawing.Size(60, 30)
        Me.btnEmpleado2.TabIndex = 3
        Me.btnEmpleado2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado2, "Empleado")
        Me.btnEmpleado2.UseVisualStyleBackColor = False
        '
        'TextNombreEmple2
        '
        Me.TextNombreEmple2.BackColor = System.Drawing.Color.White
        Me.TextNombreEmple2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombreEmple2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombreEmple2.Location = New System.Drawing.Point(62, 13)
        Me.TextNombreEmple2.MaxLength = 40
        Me.TextNombreEmple2.Name = "TextNombreEmple2"
        Me.TextNombreEmple2.Size = New System.Drawing.Size(363, 20)
        Me.TextNombreEmple2.TabIndex = 2
        '
        'TextEmpleado2
        '
        Me.TextEmpleado2.BackColor = System.Drawing.Color.White
        Me.TextEmpleado2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEmpleado2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEmpleado2.Location = New System.Drawing.Point(6, 13)
        Me.TextEmpleado2.MaxLength = 6
        Me.TextEmpleado2.Name = "TextEmpleado2"
        Me.TextEmpleado2.Size = New System.Drawing.Size(54, 20)
        Me.TextEmpleado2.TabIndex = 1
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Location = New System.Drawing.Point(0, 177)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowGroupTreeButton = False
        Me.crv.ShowRefreshButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 428)
        Me.crv.TabIndex = 68
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'gpPuesto
        '
        Me.gpPuesto.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpPuesto.Controls.Add(Me.btnPuesto)
        Me.gpPuesto.Controls.Add(Me.TextNombPuesto)
        Me.gpPuesto.Controls.Add(Me.TextPuesto)
        Me.gpPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpPuesto.ForeColor = System.Drawing.Color.White
        Me.gpPuesto.Location = New System.Drawing.Point(193, 118)
        Me.gpPuesto.Name = "gpPuesto"
        Me.gpPuesto.Size = New System.Drawing.Size(536, 40)
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
        Me.btnPuesto.Location = New System.Drawing.Point(435, 7)
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
        Me.TextNombPuesto.Location = New System.Drawing.Point(64, 13)
        Me.TextNombPuesto.MaxLength = 40
        Me.TextNombPuesto.Name = "TextNombPuesto"
        Me.TextNombPuesto.Size = New System.Drawing.Size(361, 20)
        Me.TextNombPuesto.TabIndex = 2
        '
        'TextPuesto
        '
        Me.TextPuesto.BackColor = System.Drawing.Color.White
        Me.TextPuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPuesto.Location = New System.Drawing.Point(6, 13)
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
        Me.gpCiclo.Location = New System.Drawing.Point(6, -2)
        Me.gpCiclo.Name = "gpCiclo"
        Me.gpCiclo.Size = New System.Drawing.Size(62, 41)
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
        Me.TextCiclo.Location = New System.Drawing.Point(7, 15)
        Me.TextCiclo.MaxLength = 30
        Me.TextCiclo.Name = "TextCiclo"
        Me.TextCiclo.Size = New System.Drawing.Size(49, 20)
        Me.TextCiclo.TabIndex = 1
        Me.TextCiclo.TabStop = False
        '
        'gpabarca
        '
        Me.gpabarca.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpabarca.Controls.Add(Me.rbEvaluado)
        Me.gpabarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpabarca.ForeColor = System.Drawing.Color.White
        Me.gpabarca.Location = New System.Drawing.Point(199, 12)
        Me.gpabarca.Name = "gpabarca"
        Me.gpabarca.Size = New System.Drawing.Size(98, 37)
        Me.gpabarca.TabIndex = 75
        Me.gpabarca.TabStop = False
        Me.gpabarca.Text = "Alcance"
        '
        'rbEvaluado
        '
        Me.rbEvaluado.AutoSize = True
        Me.rbEvaluado.Checked = True
        Me.rbEvaluado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEvaluado.Location = New System.Drawing.Point(8, 15)
        Me.rbEvaluado.Name = "rbEvaluado"
        Me.rbEvaluado.Size = New System.Drawing.Size(70, 17)
        Me.rbEvaluado.TabIndex = 0
        Me.rbEvaluado.TabStop = True
        Me.rbEvaluado.Text = "Evaluado"
        Me.rbEvaluado.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpTipo)
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Controls.Add(Me.btnGenerar)
        Me.Panel1.Controls.Add(Me.gpabarca)
        Me.Panel1.Controls.Add(Me.gpRepores)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gpPuesto)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 171)
        Me.Panel1.TabIndex = 77
        '
        'frmResultadoEvaluaciones2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.gpCiclo)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.gpEvaluado)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmResultadoEvaluaciones2"
        Me.Text = "Resultado de Evaluaciones "
        Me.gpRepores.ResumeLayout(False)
        Me.gpRepores.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.gpTipo.ResumeLayout(False)
        Me.gpTipo.PerformLayout()
        Me.gpEvaluado.ResumeLayout(False)
        Me.gpEvaluado.PerformLayout()
        Me.gpEvaluador.ResumeLayout(False)
        Me.gpEvaluador.PerformLayout()
        Me.gpPuesto.ResumeLayout(False)
        Me.gpPuesto.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpCiclo.ResumeLayout(False)
        Me.gpCiclo.PerformLayout()
        Me.gpabarca.ResumeLayout(False)
        Me.gpabarca.PerformLayout()
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
    Friend WithEvents gpabarca As System.Windows.Forms.GroupBox
    Friend WithEvents rbEvaluado As System.Windows.Forms.RadioButton
    Friend WithEvents gpEvaluador As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado2 As System.Windows.Forms.Button
    Friend WithEvents TextNombreEmple2 As System.Windows.Forms.TextBox
    Friend WithEvents TextEmpleado2 As System.Windows.Forms.TextBox
    Friend WithEvents rbComentarios As System.Windows.Forms.RadioButton
    Friend WithEvents rbPorcentajeAreas As System.Windows.Forms.RadioButton
    Friend WithEvents lbArea As System.Windows.Forms.Label
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As ToolTip
End Class
