<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoEvaluacion2015
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoEvaluacion2015))
        Me.cmbAreas = New System.Windows.Forms.ComboBox()
        Me.labelP = New System.Windows.Forms.Label()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.gpCiclo = New System.Windows.Forms.GroupBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoTest = New System.Windows.Forms.ComboBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gpEmpleado = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textConxEmpleado = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnEmpleado2 = New System.Windows.Forms.Button()
        Me.gpTipo = New System.Windows.Forms.GroupBox()
        Me.rbInstrumentos = New System.Windows.Forms.RadioButton()
        Me.rbPregEvaluador = New System.Windows.Forms.RadioButton()
        Me.rbGCompetencia = New System.Windows.Forms.RadioButton()
        Me.rbGCompetenciaE = New System.Windows.Forms.RadioButton()
        Me.rbGPregunta = New System.Windows.Forms.RadioButton()
        Me.rbPreguntas = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextNoTests = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gpEvaluador = New System.Windows.Forms.GroupBox()
        Me.TextNombEvaluador2 = New System.Windows.Forms.TextBox()
        Me.TextEvaluador = New System.Windows.Forms.TextBox()
        Me.gpCiclo.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpEmpleado.SuspendLayout()
        Me.gpTipo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gpEvaluador.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbAreas
        '
        Me.cmbAreas.BackColor = System.Drawing.Color.White
        Me.cmbAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAreas.Location = New System.Drawing.Point(450, 11)
        Me.cmbAreas.Name = "cmbAreas"
        Me.cmbAreas.Size = New System.Drawing.Size(114, 21)
        Me.cmbAreas.TabIndex = 3
        '
        'labelP
        '
        Me.labelP.AutoSize = True
        Me.labelP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelP.Location = New System.Drawing.Point(410, 15)
        Me.labelP.Name = "labelP"
        Me.labelP.Size = New System.Drawing.Size(35, 13)
        Me.labelP.TabIndex = 34
        Me.labelP.Text = "Area: "
        Me.labelP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCiclo
        '
        Me.txtCiclo.BackColor = System.Drawing.Color.White
        Me.txtCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCiclo.ForeColor = System.Drawing.Color.Red
        Me.txtCiclo.Location = New System.Drawing.Point(10, 14)
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(54, 20)
        Me.txtCiclo.TabIndex = 0
        Me.txtCiclo.TabStop = False
        '
        'gpCiclo
        '
        Me.gpCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpCiclo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpCiclo.Controls.Add(Me.txtCiclo)
        Me.gpCiclo.ForeColor = System.Drawing.Color.White
        Me.gpCiclo.Location = New System.Drawing.Point(1054, 1)
        Me.gpCiclo.Name = "gpCiclo"
        Me.gpCiclo.Size = New System.Drawing.Size(73, 41)
        Me.gpCiclo.TabIndex = 72
        Me.gpCiclo.TabStop = False
        Me.gpCiclo.Text = "Ciclo"
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.ImageKey = "reportegenerar.png"
        Me.btnGenerar.ImageList = Me.ImageNuevos
        Me.btnGenerar.Location = New System.Drawing.Point(952, 71)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(80, 30)
        Me.btnGenerar.TabIndex = 73
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(952, 107)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 74
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'crv1
        '
        Me.crv1.ActiveViewIndex = -1
        Me.crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv1.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv1.Location = New System.Drawing.Point(0, 164)
        Me.crv1.Name = "crv1"
        Me.crv1.SelectionFormula = ""
        Me.crv1.ShowCloseButton = False
        Me.crv1.ShowGotoPageButton = False
        Me.crv1.ShowGroupTreeButton = False
        Me.crv1.ShowRefreshButton = False
        Me.crv1.ShowTextSearchButton = False
        Me.crv1.Size = New System.Drawing.Size(1134, 445)
        Me.crv1.TabIndex = 78
        Me.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv1.ViewTimeSelectionFormula = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(250, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Tipo de test:"
        '
        'cmbTipoTest
        '
        Me.cmbTipoTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoTest.FormattingEnabled = True
        Me.cmbTipoTest.Location = New System.Drawing.Point(324, 3)
        Me.cmbTipoTest.Name = "cmbTipoTest"
        Me.cmbTipoTest.Size = New System.Drawing.Size(440, 21)
        Me.cmbTipoTest.TabIndex = 81
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'gpEmpleado
        '
        Me.gpEmpleado.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpleado.Controls.Add(Me.btnEmpleado)
        Me.gpEmpleado.Controls.Add(Me.labelP)
        Me.gpEmpleado.Controls.Add(Me.cmbAreas)
        Me.gpEmpleado.Controls.Add(Me.textNombreEmple)
        Me.gpEmpleado.Controls.Add(Me.textConxEmpleado)
        Me.gpEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpleado.ForeColor = System.Drawing.Color.White
        Me.gpEmpleado.Location = New System.Drawing.Point(249, 28)
        Me.gpEmpleado.Name = "gpEmpleado"
        Me.gpEmpleado.Size = New System.Drawing.Size(568, 40)
        Me.gpEmpleado.TabIndex = 83
        Me.gpEmpleado.TabStop = False
        Me.gpEmpleado.Text = "Empleado evaluado"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(367, 8)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(40, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Búsqueda del Empleado")
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.Location = New System.Drawing.Point(70, 15)
        Me.textNombreEmple.MaxLength = 40
        Me.textNombreEmple.Name = "textNombreEmple"
        Me.textNombreEmple.Size = New System.Drawing.Size(292, 20)
        Me.textNombreEmple.TabIndex = 2
        '
        'textConxEmpleado
        '
        Me.textConxEmpleado.BackColor = System.Drawing.Color.White
        Me.textConxEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConxEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConxEmpleado.Location = New System.Drawing.Point(8, 15)
        Me.textConxEmpleado.MaxLength = 6
        Me.textConxEmpleado.Name = "textConxEmpleado"
        Me.textConxEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textConxEmpleado.TabIndex = 1
        '
        'btnEmpleado2
        '
        Me.btnEmpleado2.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado2.ImageKey = "usuario.png"
        Me.btnEmpleado2.ImageList = Me.ImageNuevos
        Me.btnEmpleado2.Location = New System.Drawing.Point(521, 7)
        Me.btnEmpleado2.Name = "btnEmpleado2"
        Me.btnEmpleado2.Size = New System.Drawing.Size(40, 30)
        Me.btnEmpleado2.TabIndex = 3
        Me.btnEmpleado2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado2, "Búsqueda del Empleado")
        Me.btnEmpleado2.UseVisualStyleBackColor = False
        '
        'gpTipo
        '
        Me.gpTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpTipo.Controls.Add(Me.rbInstrumentos)
        Me.gpTipo.Controls.Add(Me.rbPregEvaluador)
        Me.gpTipo.Controls.Add(Me.rbGCompetencia)
        Me.gpTipo.Controls.Add(Me.rbGCompetenciaE)
        Me.gpTipo.Controls.Add(Me.rbGPregunta)
        Me.gpTipo.Controls.Add(Me.rbPreguntas)
        Me.gpTipo.ForeColor = System.Drawing.Color.White
        Me.gpTipo.Location = New System.Drawing.Point(5, 2)
        Me.gpTipo.Name = "gpTipo"
        Me.gpTipo.Size = New System.Drawing.Size(236, 152)
        Me.gpTipo.TabIndex = 85
        Me.gpTipo.TabStop = False
        Me.gpTipo.Text = "Tipo"
        '
        'rbInstrumentos
        '
        Me.rbInstrumentos.AutoSize = True
        Me.rbInstrumentos.Location = New System.Drawing.Point(6, 17)
        Me.rbInstrumentos.Name = "rbInstrumentos"
        Me.rbInstrumentos.Size = New System.Drawing.Size(85, 17)
        Me.rbInstrumentos.TabIndex = 5
        Me.rbInstrumentos.Text = "Instrumentos"
        Me.rbInstrumentos.UseVisualStyleBackColor = True
        '
        'rbPregEvaluador
        '
        Me.rbPregEvaluador.AutoSize = True
        Me.rbPregEvaluador.Location = New System.Drawing.Point(6, 56)
        Me.rbPregEvaluador.Name = "rbPregEvaluador"
        Me.rbPregEvaluador.Size = New System.Drawing.Size(142, 17)
        Me.rbPregEvaluador.TabIndex = 4
        Me.rbPregEvaluador.Text = "Preguntas por Evaluador"
        Me.rbPregEvaluador.UseVisualStyleBackColor = True
        '
        'rbGCompetencia
        '
        Me.rbGCompetencia.AutoSize = True
        Me.rbGCompetencia.Location = New System.Drawing.Point(6, 96)
        Me.rbGCompetencia.Name = "rbGCompetencia"
        Me.rbGCompetencia.Size = New System.Drawing.Size(147, 17)
        Me.rbGCompetencia.TabIndex = 3
        Me.rbGCompetencia.Text = "Grafica por Competencias"
        Me.rbGCompetencia.UseVisualStyleBackColor = True
        '
        'rbGCompetenciaE
        '
        Me.rbGCompetenciaE.AutoSize = True
        Me.rbGCompetenciaE.Location = New System.Drawing.Point(6, 116)
        Me.rbGCompetenciaE.Name = "rbGCompetenciaE"
        Me.rbGCompetenciaE.Size = New System.Drawing.Size(215, 17)
        Me.rbGCompetenciaE.TabIndex = 2
        Me.rbGCompetenciaE.Text = "Grafica por Competencias por Empleado"
        Me.rbGCompetenciaE.UseVisualStyleBackColor = True
        '
        'rbGPregunta
        '
        Me.rbGPregunta.AutoSize = True
        Me.rbGPregunta.Location = New System.Drawing.Point(6, 77)
        Me.rbGPregunta.Name = "rbGPregunta"
        Me.rbGPregunta.Size = New System.Drawing.Size(128, 17)
        Me.rbGPregunta.TabIndex = 1
        Me.rbGPregunta.Text = "Grafica por Preguntas"
        Me.rbGPregunta.UseVisualStyleBackColor = True
        '
        'rbPreguntas
        '
        Me.rbPreguntas.AutoSize = True
        Me.rbPreguntas.Location = New System.Drawing.Point(6, 37)
        Me.rbPreguntas.Name = "rbPreguntas"
        Me.rbPreguntas.Size = New System.Drawing.Size(73, 17)
        Me.rbPreguntas.TabIndex = 0
        Me.rbPreguntas.Text = "Preguntas"
        Me.rbPreguntas.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.TextNoTests)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.gpEvaluador)
        Me.Panel1.Controls.Add(Me.gpEmpleado)
        Me.Panel1.Controls.Add(Me.btnGenerar)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gpTipo)
        Me.Panel1.Controls.Add(Me.gpCiclo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbTipoTest)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1134, 158)
        Me.Panel1.TabIndex = 86
        '
        'TextNoTests
        '
        Me.TextNoTests.BackColor = System.Drawing.Color.White
        Me.TextNoTests.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNoTests.ForeColor = System.Drawing.Color.Red
        Me.TextNoTests.Location = New System.Drawing.Point(853, 25)
        Me.TextNoTests.Name = "TextNoTests"
        Me.TextNoTests.ReadOnly = True
        Me.TextNoTests.Size = New System.Drawing.Size(92, 31)
        Me.TextNoTests.TabIndex = 88
        Me.TextNoTests.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(850, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "No. Test encontrados"
        '
        'gpEvaluador
        '
        Me.gpEvaluador.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEvaluador.Controls.Add(Me.btnEmpleado2)
        Me.gpEvaluador.Controls.Add(Me.TextNombEvaluador2)
        Me.gpEvaluador.Controls.Add(Me.TextEvaluador)
        Me.gpEvaluador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEvaluador.ForeColor = System.Drawing.Color.White
        Me.gpEvaluador.Location = New System.Drawing.Point(251, 71)
        Me.gpEvaluador.Name = "gpEvaluador"
        Me.gpEvaluador.Size = New System.Drawing.Size(568, 40)
        Me.gpEvaluador.TabIndex = 86
        Me.gpEvaluador.TabStop = False
        Me.gpEvaluador.Text = "Evaluador"
        '
        'TextNombEvaluador2
        '
        Me.TextNombEvaluador2.BackColor = System.Drawing.Color.White
        Me.TextNombEvaluador2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombEvaluador2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEvaluador2.Location = New System.Drawing.Point(70, 15)
        Me.TextNombEvaluador2.MaxLength = 40
        Me.TextNombEvaluador2.Name = "TextNombEvaluador2"
        Me.TextNombEvaluador2.Size = New System.Drawing.Size(436, 20)
        Me.TextNombEvaluador2.TabIndex = 2
        '
        'TextEvaluador
        '
        Me.TextEvaluador.BackColor = System.Drawing.Color.White
        Me.TextEvaluador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEvaluador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEvaluador.Location = New System.Drawing.Point(8, 15)
        Me.TextEvaluador.MaxLength = 6
        Me.TextEvaluador.Name = "TextEvaluador"
        Me.TextEvaluador.Size = New System.Drawing.Size(56, 20)
        Me.TextEvaluador.TabIndex = 1
        '
        'frmListadoEvaluacion2015
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1134, 609)
        Me.Controls.Add(Me.crv1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListadoEvaluacion2015"
        Me.Text = "  Listado de evaluaciones"
        Me.gpCiclo.ResumeLayout(False)
        Me.gpCiclo.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpEmpleado.ResumeLayout(False)
        Me.gpEmpleado.PerformLayout()
        Me.gpTipo.ResumeLayout(False)
        Me.gpTipo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gpEvaluador.ResumeLayout(False)
        Me.gpEvaluador.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbAreas As System.Windows.Forms.ComboBox
    Friend WithEvents labelP As System.Windows.Forms.Label
    Friend WithEvents txtCiclo As System.Windows.Forms.TextBox
    Friend WithEvents gpCiclo As System.Windows.Forms.GroupBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoTest As System.Windows.Forms.ComboBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gpEmpleado As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textConxEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpTipo As System.Windows.Forms.GroupBox
    Friend WithEvents rbPreguntas As System.Windows.Forms.RadioButton
    Friend WithEvents rbGCompetenciaE As System.Windows.Forms.RadioButton
    Friend WithEvents rbGPregunta As System.Windows.Forms.RadioButton
    Friend WithEvents rbGCompetencia As System.Windows.Forms.RadioButton
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gpEvaluador As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado2 As System.Windows.Forms.Button
    Friend WithEvents TextNombEvaluador2 As System.Windows.Forms.TextBox
    Friend WithEvents TextEvaluador As System.Windows.Forms.TextBox
    Friend WithEvents rbPregEvaluador As System.Windows.Forms.RadioButton
    Friend WithEvents rbInstrumentos As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextNoTests As System.Windows.Forms.TextBox
End Class
