<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGraficaEvaluacionesDoc2022
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGraficaEvaluacionesDoc2022))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.cmbAreas = New System.Windows.Forms.ComboBox()
        Me.labelP = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipoGrafica = New System.Windows.Forms.ComboBox()
        Me.TextGrado = New System.Windows.Forms.TextBox()
        Me.TextNivel = New System.Windows.Forms.TextBox()
        Me.TextColegio = New System.Windows.Forms.TextBox()
        Me.cmbJornada = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbNivel = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbGrado = New System.Windows.Forms.ComboBox()
        Me.cmbSeccion = New System.Windows.Forms.ComboBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbPreguntasNi = New System.Windows.Forms.RadioButton()
        Me.rbPreguntaGr = New System.Windows.Forms.RadioButton()
        Me.rbPreguntaSec = New System.Windows.Forms.RadioButton()
        Me.gbDocente = New System.Windows.Forms.GroupBox()
        Me.btnMaestro = New System.Windows.Forms.Button()
        Me.textConxMaestro = New System.Windows.Forms.TextBox()
        Me.textNombreMaestro = New System.Windows.Forms.TextBox()
        Me.gpCiclo = New System.Windows.Forms.GroupBox()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoTest = New System.Windows.Forms.ComboBox()
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.gbDocente.SuspendLayout()
        Me.gpCiclo.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnGenerar)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gbDatos)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.gbDocente)
        Me.Panel1.Controls.Add(Me.gpCiclo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbTipoTest)
        Me.Panel1.Location = New System.Drawing.Point(2, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 146)
        Me.Panel1.TabIndex = 85
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.ImageKey = "reportegenerar.png"
        Me.btnGenerar.ImageList = Me.ImageList1
        Me.btnGenerar.Location = New System.Drawing.Point(909, 10)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(80, 30)
        Me.btnGenerar.TabIndex = 73
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageList1
        Me.btnLimpiar.Location = New System.Drawing.Point(995, 10)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 74
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'gbDatos
        '
        Me.gbDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbDatos.Controls.Add(Me.cmbAreas)
        Me.gbDatos.Controls.Add(Me.labelP)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.cmbTipoGrafica)
        Me.gbDatos.Controls.Add(Me.TextGrado)
        Me.gbDatos.Controls.Add(Me.TextNivel)
        Me.gbDatos.Controls.Add(Me.TextColegio)
        Me.gbDatos.Controls.Add(Me.cmbJornada)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.Label26)
        Me.gbDatos.Controls.Add(Me.cmbNivel)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.cmbGrado)
        Me.gbDatos.Controls.Add(Me.cmbSeccion)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.ForeColor = System.Drawing.Color.White
        Me.gbDatos.Location = New System.Drawing.Point(172, 48)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(672, 89)
        Me.gbDatos.TabIndex = 71
        Me.gbDatos.TabStop = False
        '
        'cmbAreas
        '
        Me.cmbAreas.BackColor = System.Drawing.Color.White
        Me.cmbAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAreas.Location = New System.Drawing.Point(494, 10)
        Me.cmbAreas.Name = "cmbAreas"
        Me.cmbAreas.Size = New System.Drawing.Size(172, 21)
        Me.cmbAreas.TabIndex = 84
        '
        'labelP
        '
        Me.labelP.AutoSize = True
        Me.labelP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelP.Location = New System.Drawing.Point(438, 15)
        Me.labelP.Name = "labelP"
        Me.labelP.Size = New System.Drawing.Size(35, 13)
        Me.labelP.TabIndex = 85
        Me.labelP.Text = "Area: "
        Me.labelP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(420, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Tipo Gráfica:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoGrafica
        '
        Me.cmbTipoGrafica.BackColor = System.Drawing.Color.White
        Me.cmbTipoGrafica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoGrafica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoGrafica.Items.AddRange(New Object() {"", "Barra Horizontal", "Lineal", "Barra Vertical"})
        Me.cmbTipoGrafica.Location = New System.Drawing.Point(494, 58)
        Me.cmbTipoGrafica.Name = "cmbTipoGrafica"
        Me.cmbTipoGrafica.Size = New System.Drawing.Size(132, 24)
        Me.cmbTipoGrafica.TabIndex = 62
        '
        'TextGrado
        '
        Me.TextGrado.BackColor = System.Drawing.Color.White
        Me.TextGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextGrado.Location = New System.Drawing.Point(103, 59)
        Me.TextGrado.MaxLength = 60
        Me.TextGrado.Name = "TextGrado"
        Me.TextGrado.ReadOnly = True
        Me.TextGrado.Size = New System.Drawing.Size(312, 22)
        Me.TextGrado.TabIndex = 61
        '
        'TextNivel
        '
        Me.TextNivel.BackColor = System.Drawing.Color.White
        Me.TextNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNivel.Location = New System.Drawing.Point(103, 35)
        Me.TextNivel.MaxLength = 60
        Me.TextNivel.Name = "TextNivel"
        Me.TextNivel.ReadOnly = True
        Me.TextNivel.Size = New System.Drawing.Size(312, 22)
        Me.TextNivel.TabIndex = 60
        '
        'TextColegio
        '
        Me.TextColegio.BackColor = System.Drawing.Color.White
        Me.TextColegio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextColegio.Location = New System.Drawing.Point(103, 11)
        Me.TextColegio.MaxLength = 60
        Me.TextColegio.Name = "TextColegio"
        Me.TextColegio.ReadOnly = True
        Me.TextColegio.Size = New System.Drawing.Size(312, 22)
        Me.TextColegio.TabIndex = 59
        '
        'cmbJornada
        '
        Me.cmbJornada.BackColor = System.Drawing.Color.White
        Me.cmbJornada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJornada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbJornada.Location = New System.Drawing.Point(63, 11)
        Me.cmbJornada.Name = "cmbJornada"
        Me.cmbJornada.Size = New System.Drawing.Size(40, 24)
        Me.cmbJornada.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 16)
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
        Me.Label26.Location = New System.Drawing.Point(9, 40)
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
        Me.cmbNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNivel.Location = New System.Drawing.Point(63, 35)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(40, 24)
        Me.cmbNivel.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(438, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Sección:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 64)
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
        Me.cmbGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrado.Location = New System.Drawing.Point(63, 59)
        Me.cmbGrado.Name = "cmbGrado"
        Me.cmbGrado.Size = New System.Drawing.Size(40, 24)
        Me.cmbGrado.TabIndex = 4
        '
        'cmbSeccion
        '
        Me.cmbSeccion.BackColor = System.Drawing.Color.White
        Me.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSeccion.Location = New System.Drawing.Point(495, 32)
        Me.cmbSeccion.Name = "cmbSeccion"
        Me.cmbSeccion.Size = New System.Drawing.Size(56, 24)
        Me.cmbSeccion.TabIndex = 5
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.FlowLayoutPanel1.Controls.Add(Me.rbPreguntasNi)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbPreguntaGr)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbPreguntaSec)
        Me.FlowLayoutPanel1.ForeColor = System.Drawing.Color.White
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 60)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(156, 77)
        Me.FlowLayoutPanel1.TabIndex = 83
        '
        'rbPreguntasNi
        '
        Me.rbPreguntasNi.AutoSize = True
        Me.rbPreguntasNi.Checked = True
        Me.rbPreguntasNi.Location = New System.Drawing.Point(3, 3)
        Me.rbPreguntasNi.Name = "rbPreguntasNi"
        Me.rbPreguntasNi.Size = New System.Drawing.Size(137, 17)
        Me.rbPreguntasNi.TabIndex = 5
        Me.rbPreguntasNi.TabStop = True
        Me.rbPreguntasNi.Text = "Por Preguntas por Nivel"
        Me.rbPreguntasNi.UseVisualStyleBackColor = True
        '
        'rbPreguntaGr
        '
        Me.rbPreguntaGr.AutoSize = True
        Me.rbPreguntaGr.Checked = True
        Me.rbPreguntaGr.Location = New System.Drawing.Point(3, 26)
        Me.rbPreguntaGr.Name = "rbPreguntaGr"
        Me.rbPreguntaGr.Size = New System.Drawing.Size(142, 17)
        Me.rbPreguntaGr.TabIndex = 6
        Me.rbPreguntaGr.TabStop = True
        Me.rbPreguntaGr.Text = "Por Preguntas por Grado"
        Me.rbPreguntaGr.UseVisualStyleBackColor = True
        '
        'rbPreguntaSec
        '
        Me.rbPreguntaSec.AutoSize = True
        Me.rbPreguntaSec.Checked = True
        Me.rbPreguntaSec.Location = New System.Drawing.Point(3, 49)
        Me.rbPreguntaSec.Name = "rbPreguntaSec"
        Me.rbPreguntaSec.Size = New System.Drawing.Size(152, 17)
        Me.rbPreguntaSec.TabIndex = 7
        Me.rbPreguntaSec.TabStop = True
        Me.rbPreguntaSec.Text = "Por Preguntas por Sección"
        Me.rbPreguntaSec.UseVisualStyleBackColor = True
        '
        'gbDocente
        '
        Me.gbDocente.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbDocente.Controls.Add(Me.btnMaestro)
        Me.gbDocente.Controls.Add(Me.textConxMaestro)
        Me.gbDocente.Controls.Add(Me.textNombreMaestro)
        Me.gbDocente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDocente.ForeColor = System.Drawing.Color.White
        Me.gbDocente.Location = New System.Drawing.Point(483, -1)
        Me.gbDocente.Name = "gbDocente"
        Me.gbDocente.Size = New System.Drawing.Size(368, 41)
        Me.gbDocente.TabIndex = 82
        Me.gbDocente.TabStop = False
        Me.gbDocente.Text = "Docente"
        '
        'btnMaestro
        '
        Me.btnMaestro.BackColor = System.Drawing.SystemColors.Control
        Me.btnMaestro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaestro.ImageKey = "usuario.png"
        Me.btnMaestro.ImageList = Me.ImageList1
        Me.btnMaestro.Location = New System.Drawing.Point(322, 7)
        Me.btnMaestro.Name = "btnMaestro"
        Me.btnMaestro.Size = New System.Drawing.Size(40, 32)
        Me.btnMaestro.TabIndex = 3
        Me.btnMaestro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMaestro.UseVisualStyleBackColor = False
        '
        'textConxMaestro
        '
        Me.textConxMaestro.BackColor = System.Drawing.Color.White
        Me.textConxMaestro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConxMaestro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConxMaestro.Location = New System.Drawing.Point(6, 16)
        Me.textConxMaestro.MaxLength = 6
        Me.textConxMaestro.Name = "textConxMaestro"
        Me.textConxMaestro.Size = New System.Drawing.Size(54, 20)
        Me.textConxMaestro.TabIndex = 1
        '
        'textNombreMaestro
        '
        Me.textNombreMaestro.BackColor = System.Drawing.Color.White
        Me.textNombreMaestro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreMaestro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreMaestro.Location = New System.Drawing.Point(63, 16)
        Me.textNombreMaestro.MaxLength = 40
        Me.textNombreMaestro.Name = "textNombreMaestro"
        Me.textNombreMaestro.Size = New System.Drawing.Size(257, 20)
        Me.textNombreMaestro.TabIndex = 2
        '
        'gpCiclo
        '
        Me.gpCiclo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpCiclo.Controls.Add(Me.txtCiclo)
        Me.gpCiclo.ForeColor = System.Drawing.Color.White
        Me.gpCiclo.Location = New System.Drawing.Point(6, 0)
        Me.gpCiclo.Name = "gpCiclo"
        Me.gpCiclo.Size = New System.Drawing.Size(84, 41)
        Me.gpCiclo.TabIndex = 72
        Me.gpCiclo.TabStop = False
        Me.gpCiclo.Text = "Ciclo"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(96, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Tipo de test:"
        '
        'cmbTipoTest
        '
        Me.cmbTipoTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoTest.FormattingEnabled = True
        Me.cmbTipoTest.Location = New System.Drawing.Point(99, 21)
        Me.cmbTipoTest.Name = "cmbTipoTest"
        Me.cmbTipoTest.Size = New System.Drawing.Size(375, 21)
        Me.cmbTipoTest.TabIndex = 81
        '
        'crv1
        '
        Me.crv1.ActiveViewIndex = -1
        Me.crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv1.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv1.Location = New System.Drawing.Point(2, 145)
        Me.crv1.Name = "crv1"
        Me.crv1.SelectionFormula = ""
        Me.crv1.ShowCloseButton = False
        Me.crv1.ShowGotoPageButton = False
        Me.crv1.ShowGroupTreeButton = False
        Me.crv1.ShowRefreshButton = False
        Me.crv1.ShowTextSearchButton = False
        Me.crv1.Size = New System.Drawing.Size(1130, 462)
        Me.crv1.TabIndex = 86
        Me.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv1.ViewTimeSelectionFormula = ""
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'frmGraficaEvaluacionesDoc2022
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 609)
        Me.Controls.Add(Me.crv1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGraficaEvaluacionesDoc2022"
        Me.Text = "Listado Evaluaciones Docentes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.gbDocente.ResumeLayout(False)
        Me.gbDocente.PerformLayout()
        Me.gpCiclo.ResumeLayout(False)
        Me.gpCiclo.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnGenerar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents gbDatos As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbTipoGrafica As ComboBox
    Friend WithEvents TextGrado As TextBox
    Friend WithEvents TextNivel As TextBox
    Friend WithEvents TextColegio As TextBox
    Friend WithEvents cmbJornada As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents cmbNivel As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbGrado As ComboBox
    Friend WithEvents cmbSeccion As ComboBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents rbPreguntasNi As RadioButton
    Friend WithEvents gbDocente As GroupBox
    Friend WithEvents btnMaestro As Button
    Friend WithEvents textConxMaestro As TextBox
    Friend WithEvents textNombreMaestro As TextBox
    Friend WithEvents gpCiclo As GroupBox
    Friend WithEvents txtCiclo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbTipoTest As ComboBox
    Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ep1 As ErrorProvider
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents cmbAreas As ComboBox
    Friend WithEvents labelP As Label
    Friend WithEvents rbPreguntaGr As RadioButton
    Friend WithEvents rbPreguntaSec As RadioButton
End Class
