<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGraficasEvaluacionDoc2014
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGraficasEvaluacionDoc2014))
        Me.gbDatos = New System.Windows.Forms.GroupBox()
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
        Me.gbDocente = New System.Windows.Forms.GroupBox()
        Me.btnMaestro = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.textConxMaestro = New System.Windows.Forms.TextBox()
        Me.textNombreMaestro = New System.Windows.Forms.TextBox()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.gpCiclo = New System.Windows.Forms.GroupBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.rbCompTipEvaArea = New System.Windows.Forms.RadioButton()
        Me.rbCompeGrado = New System.Windows.Forms.RadioButton()
        Me.rbCompeNivel = New System.Windows.Forms.RadioButton()
        Me.rbDocenteEvaluado = New System.Windows.Forms.RadioButton()
        Me.rbPreguntasGr = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoTest = New System.Windows.Forms.ComboBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.rbPreguntasNi = New System.Windows.Forms.RadioButton()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbCompeTipoEva = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbDatos.SuspendLayout()
        Me.gbDocente.SuspendLayout()
        Me.gpCiclo.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDatos
        '
        Me.gbDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbDatos.Controls.Add(Me.TextGrado)
        Me.gbDatos.Controls.Add(Me.TextNivel)
        Me.gbDatos.Controls.Add(Me.TextColegio)
        Me.gbDatos.Controls.Add(Me.cmbJornada)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.Label26)
        Me.gbDatos.Controls.Add(Me.cmbNivel)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.cmbAreas)
        Me.gbDatos.Controls.Add(Me.labelP)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.cmbGrado)
        Me.gbDatos.Controls.Add(Me.cmbSeccion)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.ForeColor = System.Drawing.Color.White
        Me.gbDatos.Location = New System.Drawing.Point(319, 41)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(673, 83)
        Me.gbDatos.TabIndex = 71
        Me.gbDatos.TabStop = False
        '
        'TextGrado
        '
        Me.TextGrado.BackColor = System.Drawing.Color.White
        Me.TextGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextGrado.Location = New System.Drawing.Point(121, 56)
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
        Me.TextNivel.Location = New System.Drawing.Point(121, 32)
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
        Me.TextColegio.Location = New System.Drawing.Point(121, 8)
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
        Me.cmbJornada.Location = New System.Drawing.Point(81, 8)
        Me.cmbJornada.Name = "cmbJornada"
        Me.cmbJornada.Size = New System.Drawing.Size(40, 24)
        Me.cmbJornada.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 13)
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
        Me.Label26.Location = New System.Drawing.Point(9, 37)
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
        Me.cmbNivel.Location = New System.Drawing.Point(81, 32)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(40, 24)
        Me.cmbNivel.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(437, 45)
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
        Me.cmbAreas.Location = New System.Drawing.Point(492, 11)
        Me.cmbAreas.Name = "cmbAreas"
        Me.cmbAreas.Size = New System.Drawing.Size(173, 21)
        Me.cmbAreas.TabIndex = 3
        '
        'labelP
        '
        Me.labelP.AutoSize = True
        Me.labelP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelP.Location = New System.Drawing.Point(439, 15)
        Me.labelP.Name = "labelP"
        Me.labelP.Size = New System.Drawing.Size(35, 13)
        Me.labelP.TabIndex = 34
        Me.labelP.Text = "Área: "
        Me.labelP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 61)
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
        Me.cmbGrado.Location = New System.Drawing.Point(81, 56)
        Me.cmbGrado.Name = "cmbGrado"
        Me.cmbGrado.Size = New System.Drawing.Size(40, 24)
        Me.cmbGrado.TabIndex = 4
        '
        'cmbSeccion
        '
        Me.cmbSeccion.BackColor = System.Drawing.Color.White
        Me.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSeccion.Location = New System.Drawing.Point(492, 38)
        Me.cmbSeccion.Name = "cmbSeccion"
        Me.cmbSeccion.Size = New System.Drawing.Size(40, 24)
        Me.cmbSeccion.TabIndex = 5
        '
        'gbDocente
        '
        Me.gbDocente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDocente.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbDocente.Controls.Add(Me.btnMaestro)
        Me.gbDocente.Controls.Add(Me.textConxMaestro)
        Me.gbDocente.Controls.Add(Me.textNombreMaestro)
        Me.gbDocente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDocente.ForeColor = System.Drawing.Color.White
        Me.gbDocente.Location = New System.Drawing.Point(759, -1)
        Me.gbDocente.Name = "gbDocente"
        Me.gbDocente.Size = New System.Drawing.Size(365, 43)
        Me.gbDocente.TabIndex = 82
        Me.gbDocente.TabStop = False
        Me.gbDocente.Text = "Docente"
        '
        'btnMaestro
        '
        Me.btnMaestro.BackColor = System.Drawing.SystemColors.Control
        Me.btnMaestro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaestro.ImageKey = "usuario.png"
        Me.btnMaestro.ImageList = Me.ImageNuevos
        Me.btnMaestro.Location = New System.Drawing.Point(322, 8)
        Me.btnMaestro.Name = "btnMaestro"
        Me.btnMaestro.Size = New System.Drawing.Size(40, 30)
        Me.btnMaestro.TabIndex = 3
        Me.btnMaestro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMaestro.UseVisualStyleBackColor = False
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
        'textConxMaestro
        '
        Me.textConxMaestro.BackColor = System.Drawing.Color.White
        Me.textConxMaestro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConxMaestro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConxMaestro.Location = New System.Drawing.Point(6, 14)
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
        Me.textNombreMaestro.Location = New System.Drawing.Point(63, 14)
        Me.textNombreMaestro.MaxLength = 40
        Me.textNombreMaestro.Name = "textNombreMaestro"
        Me.textNombreMaestro.Size = New System.Drawing.Size(257, 20)
        Me.textNombreMaestro.TabIndex = 2
        '
        'txtCiclo
        '
        Me.txtCiclo.BackColor = System.Drawing.Color.White
        Me.txtCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCiclo.ForeColor = System.Drawing.Color.Red
        Me.txtCiclo.Location = New System.Drawing.Point(10, 13)
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(54, 20)
        Me.txtCiclo.TabIndex = 0
        Me.txtCiclo.TabStop = False
        '
        'gpCiclo
        '
        Me.gpCiclo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpCiclo.Controls.Add(Me.txtCiclo)
        Me.gpCiclo.ForeColor = System.Drawing.Color.White
        Me.gpCiclo.Location = New System.Drawing.Point(11, -1)
        Me.gpCiclo.Name = "gpCiclo"
        Me.gpCiclo.Size = New System.Drawing.Size(74, 40)
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
        Me.btnGenerar.Location = New System.Drawing.Point(998, 95)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(80, 30)
        Me.btnGenerar.TabIndex = 73
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGenerar, "Generar")
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(998, 131)
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
        Me.crv1.Location = New System.Drawing.Point(14, 169)
        Me.crv1.Name = "crv1"
        Me.crv1.SelectionFormula = ""
        Me.crv1.ShowCloseButton = False
        Me.crv1.ShowGotoPageButton = False
        Me.crv1.ShowGroupTreeButton = False
        Me.crv1.ShowRefreshButton = False
        Me.crv1.ShowTextSearchButton = False
        Me.crv1.Size = New System.Drawing.Size(1130, 431)
        Me.crv1.TabIndex = 78
        Me.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv1.ViewTimeSelectionFormula = ""
        '
        'rbCompTipEvaArea
        '
        Me.rbCompTipEvaArea.AutoSize = True
        Me.rbCompTipEvaArea.Location = New System.Drawing.Point(3, 95)
        Me.rbCompTipEvaArea.Name = "rbCompTipEvaArea"
        Me.rbCompTipEvaArea.Size = New System.Drawing.Size(273, 17)
        Me.rbCompTipEvaArea.TabIndex = 4
        Me.rbCompTipEvaArea.Text = "Competencia por Tipo Evaluación y Area académica"
        Me.rbCompTipEvaArea.UseVisualStyleBackColor = True
        '
        'rbCompeGrado
        '
        Me.rbCompeGrado.AutoSize = True
        Me.rbCompeGrado.Location = New System.Drawing.Point(3, 72)
        Me.rbCompeGrado.Name = "rbCompeGrado"
        Me.rbCompeGrado.Size = New System.Drawing.Size(137, 17)
        Me.rbCompeGrado.TabIndex = 3
        Me.rbCompeGrado.Text = "Competencia por Grado"
        Me.rbCompeGrado.UseVisualStyleBackColor = True
        '
        'rbCompeNivel
        '
        Me.rbCompeNivel.AutoSize = True
        Me.rbCompeNivel.Location = New System.Drawing.Point(142, 26)
        Me.rbCompeNivel.Name = "rbCompeNivel"
        Me.rbCompeNivel.Size = New System.Drawing.Size(132, 17)
        Me.rbCompeNivel.TabIndex = 2
        Me.rbCompeNivel.Text = "Competencia por Nivel"
        Me.rbCompeNivel.UseVisualStyleBackColor = True
        '
        'rbDocenteEvaluado
        '
        Me.rbDocenteEvaluado.AutoSize = True
        Me.rbDocenteEvaluado.Location = New System.Drawing.Point(3, 26)
        Me.rbDocenteEvaluado.Name = "rbDocenteEvaluado"
        Me.rbDocenteEvaluado.Size = New System.Drawing.Size(133, 17)
        Me.rbDocenteEvaluado.TabIndex = 1
        Me.rbDocenteEvaluado.Text = "Por Docente Evaluado"
        Me.rbDocenteEvaluado.UseVisualStyleBackColor = True
        '
        'rbPreguntasGr
        '
        Me.rbPreguntasGr.AutoSize = True
        Me.rbPreguntasGr.Location = New System.Drawing.Point(127, 3)
        Me.rbPreguntasGr.Name = "rbPreguntasGr"
        Me.rbPreguntasGr.Size = New System.Drawing.Size(123, 17)
        Me.rbPreguntasGr.TabIndex = 0
        Me.rbPreguntasGr.Text = "Preguntas por Grado"
        Me.rbPreguntasGr.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(91, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Tipo de test:"
        '
        'cmbTipoTest
        '
        Me.cmbTipoTest.FormattingEnabled = True
        Me.cmbTipoTest.Location = New System.Drawing.Point(163, 6)
        Me.cmbTipoTest.Name = "cmbTipoTest"
        Me.cmbTipoTest.Size = New System.Drawing.Size(375, 21)
        Me.cmbTipoTest.TabIndex = 81
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'rbPreguntasNi
        '
        Me.rbPreguntasNi.AutoSize = True
        Me.rbPreguntasNi.Checked = True
        Me.rbPreguntasNi.Location = New System.Drawing.Point(3, 3)
        Me.rbPreguntasNi.Name = "rbPreguntasNi"
        Me.rbPreguntasNi.Size = New System.Drawing.Size(118, 17)
        Me.rbPreguntasNi.TabIndex = 5
        Me.rbPreguntasNi.TabStop = True
        Me.rbPreguntasNi.Text = "Preguntas por Nivel"
        Me.rbPreguntasNi.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.rbPreguntasNi)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbPreguntasGr)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbDocenteEvaluado)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbCompeNivel)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbCompeTipoEva)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbCompeGrado)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbCompTipEvaArea)
        Me.FlowLayoutPanel1.ForeColor = System.Drawing.Color.White
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(10, 45)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(302, 115)
        Me.FlowLayoutPanel1.TabIndex = 83
        '
        'rbCompeTipoEva
        '
        Me.rbCompeTipoEva.AutoSize = True
        Me.rbCompeTipoEva.Location = New System.Drawing.Point(3, 49)
        Me.rbCompeTipoEva.Name = "rbCompeTipoEva"
        Me.rbCompeTipoEva.Size = New System.Drawing.Size(185, 17)
        Me.rbCompeTipoEva.TabIndex = 6
        Me.rbCompeTipoEva.Text = "Competencia por Tipo Evaluación"
        Me.rbCompeTipoEva.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.btnGenerar)
        Me.Panel1.Controls.Add(Me.gbDatos)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.gpCiclo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbTipoTest)
        Me.Panel1.Controls.Add(Me.gbDocente)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 163)
        Me.Panel1.TabIndex = 84
        '
        'frmGraficasEvaluacionDoc2014
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.crv1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGraficasEvaluacionDoc2014"
        Me.Text = "Listado de Evaluaciones de Docentes"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.gbDocente.ResumeLayout(False)
        Me.gbDocente.PerformLayout()
        Me.gpCiclo.ResumeLayout(False)
        Me.gpCiclo.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
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
    Friend WithEvents rbPreguntasGr As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoTest As System.Windows.Forms.ComboBox
    Friend WithEvents rbDocenteEvaluado As System.Windows.Forms.RadioButton
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gbDocente As System.Windows.Forms.GroupBox
    Friend WithEvents btnMaestro As System.Windows.Forms.Button
    Friend WithEvents textNombreMaestro As System.Windows.Forms.TextBox
    Friend WithEvents textConxMaestro As System.Windows.Forms.TextBox
    Friend WithEvents rbCompeGrado As System.Windows.Forms.RadioButton
    Friend WithEvents rbCompeNivel As System.Windows.Forms.RadioButton
    Friend WithEvents rbCompTipEvaArea As System.Windows.Forms.RadioButton
    Friend WithEvents rbPreguntasNi As System.Windows.Forms.RadioButton
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbCompeTipoEva As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As ToolTip
End Class
