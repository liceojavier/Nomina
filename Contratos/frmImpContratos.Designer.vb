<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpContratos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImpContratos))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.TextFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbPuesto = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextNombre = New System.Windows.Forms.TextBox()
        Me.btnMark = New System.Windows.Forms.Button()
        Me.btnDesmark = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvEmple = New System.Windows.Forms.DataGridView()
        Me.dcNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcEmpleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcNPuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcNoEmpleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcNoContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcMarca = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtJornada = New System.Windows.Forms.TextBox()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvEmple, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Location = New System.Drawing.Point(342, 3)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.Size = New System.Drawing.Size(785, 463)
        Me.crv.TabIndex = 0
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
        'TextFecha
        '
        Me.TextFecha.BackColor = System.Drawing.Color.White
        Me.TextFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFecha.Location = New System.Drawing.Point(886, 5)
        Me.TextFecha.Mask = "##/##/####"
        Me.TextFecha.Name = "TextFecha"
        Me.TextFecha.Size = New System.Drawing.Size(84, 20)
        Me.TextFecha.TabIndex = 2
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(775, 8)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(97, 13)
        Me.Label32.TabIndex = 34
        Me.Label32.Text = "Fecha de contrato:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "reportegenerar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(778, 37)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(83, 38)
        Me.btnEjecutar.TabIndex = 5
        Me.btnEjecutar.Text = "Imprimir"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEjecutar, "Generar")
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtJornada)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbPuesto)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextNombre)
        Me.Panel1.Controls.Add(Me.btnMark)
        Me.Panel1.Controls.Add(Me.btnDesmark)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbTipo)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Controls.Add(Me.TextFecha)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 92)
        Me.Panel1.TabIndex = 40
        '
        'cmbPuesto
        '
        Me.cmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPuesto.FormattingEnabled = True
        Me.cmbPuesto.Items.AddRange(New Object() {"DOCENTE", "ADMINISTRACION", "TECNICO ADMINISTRATIVO", "MANTENIMIENTO"})
        Me.cmbPuesto.Location = New System.Drawing.Point(475, 4)
        Me.cmbPuesto.Name = "cmbPuesto"
        Me.cmbPuesto.Size = New System.Drawing.Size(260, 21)
        Me.cmbPuesto.TabIndex = 47
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(424, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Puesto:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Nombre:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(81, 34)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(315, 20)
        Me.TextNombre.TabIndex = 44
        '
        'btnMark
        '
        Me.btnMark.BackColor = System.Drawing.SystemColors.Control
        Me.btnMark.Location = New System.Drawing.Point(81, 64)
        Me.btnMark.Name = "btnMark"
        Me.btnMark.Size = New System.Drawing.Size(75, 23)
        Me.btnMark.TabIndex = 43
        Me.btnMark.Text = "Marcar"
        Me.btnMark.UseVisualStyleBackColor = False
        '
        'btnDesmark
        '
        Me.btnDesmark.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesmark.Location = New System.Drawing.Point(162, 64)
        Me.btnDesmark.Name = "btnDesmark"
        Me.btnDesmark.Size = New System.Drawing.Size(75, 23)
        Me.btnDesmark.TabIndex = 42
        Me.btnDesmark.Text = "Descarmar"
        Me.btnDesmark.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Tipo reporte:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"DOCENTE", "ADMINISTRACION", "TECNICO ADMINISTRATIVO", "MANTENIMIENTO", "VIGILANCIA", "MONITORAS"})
        Me.cmbTipo.Location = New System.Drawing.Point(81, 5)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(315, 21)
        Me.cmbTipo.TabIndex = 40
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.crv, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvEmple, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 128)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1130, 469)
        Me.TableLayoutPanel1.TabIndex = 41
        '
        'dgvEmple
        '
        Me.dgvEmple.AllowUserToAddRows = False
        Me.dgvEmple.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan
        Me.dgvEmple.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvEmple.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEmple.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvEmple.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmple.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dcNombre, Me.dcEmpleado, Me.dcNPuesto, Me.dcNoEmpleado, Me.dcNoContrato, Me.dcMarca})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmple.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvEmple.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEmple.Location = New System.Drawing.Point(3, 3)
        Me.dgvEmple.Name = "dgvEmple"
        Me.dgvEmple.Size = New System.Drawing.Size(333, 463)
        Me.dgvEmple.TabIndex = 1
        '
        'dcNombre
        '
        Me.dcNombre.DataPropertyName = "nombre"
        Me.dcNombre.FillWeight = 50.0!
        Me.dcNombre.HeaderText = "Empleado"
        Me.dcNombre.Name = "dcNombre"
        Me.dcNombre.ReadOnly = True
        '
        'dcEmpleado
        '
        Me.dcEmpleado.DataPropertyName = "puesto"
        Me.dcEmpleado.HeaderText = "Puesto"
        Me.dcEmpleado.Name = "dcEmpleado"
        Me.dcEmpleado.Visible = False
        '
        'dcNPuesto
        '
        Me.dcNPuesto.DataPropertyName = "nombre_puesto"
        Me.dcNPuesto.FillWeight = 35.0!
        Me.dcNPuesto.HeaderText = "Puesto"
        Me.dcNPuesto.Name = "dcNPuesto"
        Me.dcNPuesto.ReadOnly = True
        '
        'dcNoEmpleado
        '
        Me.dcNoEmpleado.DataPropertyName = "empleado"
        Me.dcNoEmpleado.HeaderText = "NoEmpleado"
        Me.dcNoEmpleado.Name = "dcNoEmpleado"
        Me.dcNoEmpleado.Visible = False
        '
        'dcNoContrato
        '
        Me.dcNoContrato.DataPropertyName = "contrato"
        Me.dcNoContrato.HeaderText = "NoContrato"
        Me.dcNoContrato.Name = "dcNoContrato"
        Me.dcNoContrato.Visible = False
        '
        'dcMarca
        '
        Me.dcMarca.DataPropertyName = "marca"
        Me.dcMarca.FillWeight = 15.0!
        Me.dcMarca.HeaderText = "Marca"
        Me.dcMarca.IndeterminateValue = "false"
        Me.dcMarca.Name = "dcMarca"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(424, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Horario:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtJornada
        '
        Me.txtJornada.Location = New System.Drawing.Point(477, 37)
        Me.txtJornada.Name = "txtJornada"
        Me.txtJornada.Size = New System.Drawing.Size(258, 20)
        Me.txtJornada.TabIndex = 49
        '
        'frmImpContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 597)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmImpContratos"
        Me.Text = "Impresión de Contrato"
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvEmple, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TextFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvEmple As System.Windows.Forms.DataGridView
    Friend WithEvents btnMark As System.Windows.Forms.Button
    Friend WithEvents btnDesmark As System.Windows.Forms.Button
    Friend WithEvents cmbPuesto As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents dcNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcEmpleado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcNPuesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcNoEmpleado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcNoContrato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcMarca As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtJornada As TextBox
    Friend WithEvents Label4 As Label
End Class
