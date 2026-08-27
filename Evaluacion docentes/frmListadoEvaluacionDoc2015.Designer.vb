<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoEvaluacionDoc2015
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoEvaluacionDoc2015))
        Me.gpDatos = New System.Windows.Forms.GroupBox()
        Me.TextGrado = New System.Windows.Forms.TextBox()
        Me.TextNivel = New System.Windows.Forms.TextBox()
        Me.TextColegio = New System.Windows.Forms.TextBox()
        Me.cmbJornada = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbNivel = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbAreas = New System.Windows.Forms.ComboBox()
        Me.labelP = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbGrado = New System.Windows.Forms.ComboBox()
        Me.cmbSeccion = New System.Windows.Forms.ComboBox()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.gpCiclo = New System.Windows.Forms.GroupBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.gpTipo = New System.Windows.Forms.GroupBox()
        Me.rbPreguntasNivel = New System.Windows.Forms.RadioButton()
        Me.rbPreguntaGra = New System.Windows.Forms.RadioButton()
        Me.rbPreguntaSecc = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoTest = New System.Windows.Forms.ComboBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gpBusqueda = New System.Windows.Forms.GroupBox()
        Me.rbBusqEmple = New System.Windows.Forms.RadioButton()
        Me.rbBusqColegio = New System.Windows.Forms.RadioButton()
        Me.gpEmpleado = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textConxEmpleado = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpDatos.SuspendLayout()
        Me.gpCiclo.SuspendLayout()
        Me.gpTipo.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpBusqueda.SuspendLayout()
        Me.gpEmpleado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpDatos
        '
        Me.gpDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpDatos.Controls.Add(Me.TextGrado)
        Me.gpDatos.Controls.Add(Me.TextNivel)
        Me.gpDatos.Controls.Add(Me.TextColegio)
        Me.gpDatos.Controls.Add(Me.cmbJornada)
        Me.gpDatos.Controls.Add(Me.Label3)
        Me.gpDatos.Controls.Add(Me.Label26)
        Me.gpDatos.Controls.Add(Me.cmbNivel)
        Me.gpDatos.Controls.Add(Me.Label6)
        Me.gpDatos.Controls.Add(Me.cmbAreas)
        Me.gpDatos.Controls.Add(Me.labelP)
        Me.gpDatos.Controls.Add(Me.Label5)
        Me.gpDatos.Controls.Add(Me.cmbGrado)
        Me.gpDatos.Controls.Add(Me.cmbSeccion)
        Me.gpDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatos.ForeColor = System.Drawing.Color.White
        Me.gpDatos.Location = New System.Drawing.Point(265, 46)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Size = New System.Drawing.Size(706, 87)
        Me.gpDatos.TabIndex = 71
        Me.gpDatos.TabStop = False
        '
        'TextGrado
        '
        Me.TextGrado.BackColor = System.Drawing.Color.White
        Me.TextGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextGrado.Location = New System.Drawing.Point(121, 59)
        Me.TextGrado.MaxLength = 60
        Me.TextGrado.Name = "TextGrado"
        Me.TextGrado.ReadOnly = True
        Me.TextGrado.Size = New System.Drawing.Size(312, 20)
        Me.TextGrado.TabIndex = 61
        '
        'TextNivel
        '
        Me.TextNivel.BackColor = System.Drawing.Color.White
        Me.TextNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNivel.Location = New System.Drawing.Point(121, 35)
        Me.TextNivel.MaxLength = 60
        Me.TextNivel.Name = "TextNivel"
        Me.TextNivel.ReadOnly = True
        Me.TextNivel.Size = New System.Drawing.Size(312, 20)
        Me.TextNivel.TabIndex = 60
        '
        'TextColegio
        '
        Me.TextColegio.BackColor = System.Drawing.Color.White
        Me.TextColegio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextColegio.Location = New System.Drawing.Point(121, 11)
        Me.TextColegio.MaxLength = 60
        Me.TextColegio.Name = "TextColegio"
        Me.TextColegio.ReadOnly = True
        Me.TextColegio.Size = New System.Drawing.Size(312, 20)
        Me.TextColegio.TabIndex = 59
        '
        'cmbJornada
        '
        Me.cmbJornada.BackColor = System.Drawing.Color.White
        Me.cmbJornada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJornada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbJornada.Location = New System.Drawing.Point(81, 11)
        Me.cmbJornada.Name = "cmbJornada"
        Me.cmbJornada.Size = New System.Drawing.Size(40, 21)
        Me.cmbJornada.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Colegio:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(25, 38)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(34, 13)
        Me.Label26.TabIndex = 30
        Me.Label26.Text = "Nivel:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNivel
        '
        Me.cmbNivel.BackColor = System.Drawing.Color.White
        Me.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNivel.Location = New System.Drawing.Point(81, 35)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(40, 21)
        Me.cmbNivel.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(439, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Sección:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAreas
        '
        Me.cmbAreas.BackColor = System.Drawing.Color.White
        Me.cmbAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAreas.Location = New System.Drawing.Point(511, 36)
        Me.cmbAreas.Name = "cmbAreas"
        Me.cmbAreas.Size = New System.Drawing.Size(184, 21)
        Me.cmbAreas.TabIndex = 3
        '
        'labelP
        '
        Me.labelP.AutoSize = True
        Me.labelP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelP.Location = New System.Drawing.Point(453, 40)
        Me.labelP.Name = "labelP"
        Me.labelP.Size = New System.Drawing.Size(35, 13)
        Me.labelP.TabIndex = 34
        Me.labelP.Text = "Area: "
        Me.labelP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Grado:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbGrado
        '
        Me.cmbGrado.BackColor = System.Drawing.Color.White
        Me.cmbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrado.Location = New System.Drawing.Point(81, 59)
        Me.cmbGrado.Name = "cmbGrado"
        Me.cmbGrado.Size = New System.Drawing.Size(40, 21)
        Me.cmbGrado.TabIndex = 4
        '
        'cmbSeccion
        '
        Me.cmbSeccion.BackColor = System.Drawing.Color.White
        Me.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSeccion.Location = New System.Drawing.Point(511, 10)
        Me.cmbSeccion.Name = "cmbSeccion"
        Me.cmbSeccion.Size = New System.Drawing.Size(40, 21)
        Me.cmbSeccion.TabIndex = 5
        '
        'txtCiclo
        '
        Me.txtCiclo.BackColor = System.Drawing.Color.White
        Me.txtCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCiclo.ForeColor = System.Drawing.Color.Red
        Me.txtCiclo.Location = New System.Drawing.Point(10, 14)
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(54, 22)
        Me.txtCiclo.TabIndex = 0
        Me.txtCiclo.TabStop = False
        '
        'gpCiclo
        '
        Me.gpCiclo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpCiclo.Controls.Add(Me.txtCiclo)
        Me.gpCiclo.ForeColor = System.Drawing.Color.White
        Me.gpCiclo.Location = New System.Drawing.Point(6, 1)
        Me.gpCiclo.Name = "gpCiclo"
        Me.gpCiclo.Size = New System.Drawing.Size(84, 41)
        Me.gpCiclo.TabIndex = 72
        Me.gpCiclo.TabStop = False
        Me.gpCiclo.Text = "Ciclo"
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.ImageKey = "reportegenerar.png"
        Me.btnGenerar.ImageList = Me.ImageList1
        Me.btnGenerar.Location = New System.Drawing.Point(1038, 100)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(80, 30)
        Me.btnGenerar.TabIndex = 73
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGenerar, "Generar")
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "limpiar.png")
        Me.ImageList1.Images.SetKeyName(1, "reportegenerar.png")
        Me.ImageList1.Images.SetKeyName(2, "usuario.png")
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageList1
        Me.btnLimpiar.Location = New System.Drawing.Point(1038, 67)
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
        Me.crv1.Location = New System.Drawing.Point(0, 136)
        Me.crv1.Name = "crv1"
        Me.crv1.SelectionFormula = ""
        Me.crv1.ShowCloseButton = False
        Me.crv1.ShowGotoPageButton = False
        Me.crv1.ShowGroupTreeButton = False
        Me.crv1.ShowRefreshButton = False
        Me.crv1.ShowTextSearchButton = False
        Me.crv1.Size = New System.Drawing.Size(1130, 469)
        Me.crv1.TabIndex = 78
        Me.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv1.ViewTimeSelectionFormula = ""
        '
        'gpTipo
        '
        Me.gpTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpTipo.Controls.Add(Me.rbPreguntasNivel)
        Me.gpTipo.Controls.Add(Me.rbPreguntaGra)
        Me.gpTipo.Controls.Add(Me.rbPreguntaSecc)
        Me.gpTipo.ForeColor = System.Drawing.Color.White
        Me.gpTipo.Location = New System.Drawing.Point(114, 46)
        Me.gpTipo.Name = "gpTipo"
        Me.gpTipo.Size = New System.Drawing.Size(145, 84)
        Me.gpTipo.TabIndex = 79
        Me.gpTipo.TabStop = False
        Me.gpTipo.Text = "Tipo"
        '
        'rbPreguntasNivel
        '
        Me.rbPreguntasNivel.AutoSize = True
        Me.rbPreguntasNivel.Location = New System.Drawing.Point(6, 57)
        Me.rbPreguntasNivel.Name = "rbPreguntasNivel"
        Me.rbPreguntasNivel.Size = New System.Drawing.Size(118, 17)
        Me.rbPreguntasNivel.TabIndex = 2
        Me.rbPreguntasNivel.TabStop = True
        Me.rbPreguntasNivel.Text = "Preguntas por Nivel"
        Me.rbPreguntasNivel.UseVisualStyleBackColor = True
        '
        'rbPreguntaGra
        '
        Me.rbPreguntaGra.AutoSize = True
        Me.rbPreguntaGra.Location = New System.Drawing.Point(6, 36)
        Me.rbPreguntaGra.Name = "rbPreguntaGra"
        Me.rbPreguntaGra.Size = New System.Drawing.Size(123, 17)
        Me.rbPreguntaGra.TabIndex = 1
        Me.rbPreguntaGra.TabStop = True
        Me.rbPreguntaGra.Text = "Preguntas por Grado"
        Me.rbPreguntaGra.UseVisualStyleBackColor = True
        '
        'rbPreguntaSecc
        '
        Me.rbPreguntaSecc.AutoSize = True
        Me.rbPreguntaSecc.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.rbPreguntaSecc.Checked = True
        Me.rbPreguntaSecc.Location = New System.Drawing.Point(6, 13)
        Me.rbPreguntaSecc.Name = "rbPreguntaSecc"
        Me.rbPreguntaSecc.Size = New System.Drawing.Size(73, 17)
        Me.rbPreguntaSecc.TabIndex = 0
        Me.rbPreguntaSecc.TabStop = True
        Me.rbPreguntaSecc.Text = "Preguntas"
        Me.rbPreguntaSecc.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(96, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Tipo de test:"
        '
        'cmbTipoTest
        '
        Me.cmbTipoTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoTest.FormattingEnabled = True
        Me.cmbTipoTest.Location = New System.Drawing.Point(170, 3)
        Me.cmbTipoTest.Name = "cmbTipoTest"
        Me.cmbTipoTest.Size = New System.Drawing.Size(375, 21)
        Me.cmbTipoTest.TabIndex = 81
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'gpBusqueda
        '
        Me.gpBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpBusqueda.Controls.Add(Me.rbBusqEmple)
        Me.gpBusqueda.Controls.Add(Me.rbBusqColegio)
        Me.gpBusqueda.ForeColor = System.Drawing.Color.White
        Me.gpBusqueda.Location = New System.Drawing.Point(6, 45)
        Me.gpBusqueda.Name = "gpBusqueda"
        Me.gpBusqueda.Size = New System.Drawing.Size(103, 79)
        Me.gpBusqueda.TabIndex = 82
        Me.gpBusqueda.TabStop = False
        Me.gpBusqueda.Text = "Busqueda"
        '
        'rbBusqEmple
        '
        Me.rbBusqEmple.AutoSize = True
        Me.rbBusqEmple.Location = New System.Drawing.Point(6, 42)
        Me.rbBusqEmple.Name = "rbBusqEmple"
        Me.rbBusqEmple.Size = New System.Drawing.Size(82, 17)
        Me.rbBusqEmple.TabIndex = 3
        Me.rbBusqEmple.TabStop = True
        Me.rbBusqEmple.Text = "Por Maestro"
        Me.rbBusqEmple.UseVisualStyleBackColor = True
        '
        'rbBusqColegio
        '
        Me.rbBusqColegio.AutoSize = True
        Me.rbBusqColegio.Location = New System.Drawing.Point(6, 19)
        Me.rbBusqColegio.Name = "rbBusqColegio"
        Me.rbBusqColegio.Size = New System.Drawing.Size(79, 17)
        Me.rbBusqColegio.TabIndex = 2
        Me.rbBusqColegio.TabStop = True
        Me.rbBusqColegio.Text = "Por Colegio"
        Me.rbBusqColegio.UseVisualStyleBackColor = True
        '
        'gpEmpleado
        '
        Me.gpEmpleado.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpleado.Controls.Add(Me.btnEmpleado)
        Me.gpEmpleado.Controls.Add(Me.textNombreEmple)
        Me.gpEmpleado.Controls.Add(Me.textConxEmpleado)
        Me.gpEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpleado.ForeColor = System.Drawing.Color.White
        Me.gpEmpleado.Location = New System.Drawing.Point(580, 1)
        Me.gpEmpleado.Name = "gpEmpleado"
        Me.gpEmpleado.Size = New System.Drawing.Size(432, 46)
        Me.gpEmpleado.TabIndex = 83
        Me.gpEmpleado.TabStop = False
        Me.gpEmpleado.Text = "Empleado"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageList1
        Me.btnEmpleado.Location = New System.Drawing.Point(395, 13)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(31, 30)
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
        Me.textNombreEmple.Location = New System.Drawing.Point(72, 21)
        Me.textNombreEmple.MaxLength = 40
        Me.textNombreEmple.Name = "textNombreEmple"
        Me.textNombreEmple.Size = New System.Drawing.Size(321, 20)
        Me.textNombreEmple.TabIndex = 2
        '
        'textConxEmpleado
        '
        Me.textConxEmpleado.BackColor = System.Drawing.Color.White
        Me.textConxEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConxEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConxEmpleado.Location = New System.Drawing.Point(10, 21)
        Me.textConxEmpleado.MaxLength = 6
        Me.textConxEmpleado.Name = "textConxEmpleado"
        Me.textConxEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textConxEmpleado.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpEmpleado)
        Me.Panel1.Controls.Add(Me.btnGenerar)
        Me.Panel1.Controls.Add(Me.gpCiclo)
        Me.Panel1.Controls.Add(Me.gpDatos)
        Me.Panel1.Controls.Add(Me.cmbTipoTest)
        Me.Panel1.Controls.Add(Me.gpBusqueda)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.gpTipo)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 146)
        Me.Panel1.TabIndex = 84
        '
        'frmListadoEvaluacionDoc2015
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.crv1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListadoEvaluacionDoc2015"
        Me.Text = "Listado de Evaluaciones de Docentes"
        Me.gpDatos.ResumeLayout(False)
        Me.gpDatos.PerformLayout()
        Me.gpCiclo.ResumeLayout(False)
        Me.gpCiclo.PerformLayout()
        Me.gpTipo.ResumeLayout(False)
        Me.gpTipo.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpBusqueda.ResumeLayout(False)
        Me.gpBusqueda.PerformLayout()
        Me.gpEmpleado.ResumeLayout(False)
        Me.gpEmpleado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents TextGrado As System.Windows.Forms.TextBox
    Friend WithEvents TextNivel As System.Windows.Forms.TextBox
    Friend WithEvents TextColegio As System.Windows.Forms.TextBox
    Friend WithEvents cmbJornada As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbNivel As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbAreas As System.Windows.Forms.ComboBox
    Friend WithEvents labelP As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbGrado As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSeccion As System.Windows.Forms.ComboBox
    Friend WithEvents txtCiclo As System.Windows.Forms.TextBox
    Friend WithEvents gpCiclo As System.Windows.Forms.GroupBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents gpTipo As System.Windows.Forms.GroupBox
    Friend WithEvents rbPreguntaSecc As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoTest As System.Windows.Forms.ComboBox
    Friend WithEvents rbPreguntaGra As System.Windows.Forms.RadioButton
    Friend WithEvents rbPreguntasNivel As System.Windows.Forms.RadioButton
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gpBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents rbBusqEmple As System.Windows.Forms.RadioButton
    Friend WithEvents rbBusqColegio As System.Windows.Forms.RadioButton
    Friend WithEvents gpEmpleado As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textConxEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As ToolTip
End Class
