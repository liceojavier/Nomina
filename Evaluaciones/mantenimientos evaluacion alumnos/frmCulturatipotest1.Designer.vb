<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCulturatipotest1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCulturatipotest1))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpPrincipal = New System.Windows.Forms.GroupBox()
        Me.cmbGrado2 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbGrado = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbNivel = New System.Windows.Forms.ComboBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.txtNombreEvaluacion = New System.Windows.Forms.TextBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.txtCiclo = New System.Windows.Forms.MaskedTextBox()
        Me.txtNumEvaluacion = New System.Windows.Forms.TextBox()
        Me.lblCiclo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.dgData = New System.Windows.Forms.DataGridView()
        Me.cmsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.gpPrincipal.SuspendLayout()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpPrincipal)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1134, 112)
        Me.Panel1.TabIndex = 22
        '
        'gpPrincipal
        '
        Me.gpPrincipal.Controls.Add(Me.cmbGrado2)
        Me.gpPrincipal.Controls.Add(Me.Label3)
        Me.gpPrincipal.Controls.Add(Me.cmbGrado)
        Me.gpPrincipal.Controls.Add(Me.Label2)
        Me.gpPrincipal.Controls.Add(Me.cmbNivel)
        Me.gpPrincipal.Controls.Add(Me.btnGuardar)
        Me.gpPrincipal.Controls.Add(Me.txtNombreEvaluacion)
        Me.gpPrincipal.Controls.Add(Me.btnLimpiar)
        Me.gpPrincipal.Controls.Add(Me.txtCiclo)
        Me.gpPrincipal.Controls.Add(Me.txtNumEvaluacion)
        Me.gpPrincipal.Controls.Add(Me.lblCiclo)
        Me.gpPrincipal.Controls.Add(Me.Label1)
        Me.gpPrincipal.Controls.Add(Me.lblNombre)
        Me.gpPrincipal.ForeColor = System.Drawing.Color.White
        Me.gpPrincipal.Location = New System.Drawing.Point(12, 12)
        Me.gpPrincipal.Name = "gpPrincipal"
        Me.gpPrincipal.Size = New System.Drawing.Size(1110, 89)
        Me.gpPrincipal.TabIndex = 21
        Me.gpPrincipal.TabStop = False
        Me.gpPrincipal.Text = "Tipo de evaluación"
        '
        'cmbGrado2
        '
        Me.cmbGrado2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrado2.FormattingEnabled = True
        Me.cmbGrado2.Location = New System.Drawing.Point(554, 53)
        Me.cmbGrado2.Name = "cmbGrado2"
        Me.cmbGrado2.Size = New System.Drawing.Size(176, 21)
        Me.cmbGrado2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(496, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Para:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbGrado
        '
        Me.cmbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrado.FormattingEnabled = True
        Me.cmbGrado.Location = New System.Drawing.Point(983, 57)
        Me.cmbGrado.Name = "cmbGrado"
        Me.cmbGrado.Size = New System.Drawing.Size(121, 21)
        Me.cmbGrado.TabIndex = 24
        Me.cmbGrado.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(496, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Nivel:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNivel
        '
        Me.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivel.FormattingEnabled = True
        Me.cmbNivel.Location = New System.Drawing.Point(554, 24)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(176, 21)
        Me.cmbNivel.TabIndex = 2
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(942, 19)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 32)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.UseVisualStyleBackColor = False
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
        'txtNombreEvaluacion
        '
        Me.txtNombreEvaluacion.Location = New System.Drawing.Point(92, 53)
        Me.txtNombreEvaluacion.MaxLength = 100
        Me.txtNombreEvaluacion.Name = "txtNombreEvaluacion"
        Me.txtNombreEvaluacion.Size = New System.Drawing.Size(357, 20)
        Me.txtNombreEvaluacion.TabIndex = 1
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(1026, 19)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(78, 32)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'txtCiclo
        '
        Me.txtCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCiclo.Location = New System.Drawing.Point(861, 21)
        Me.txtCiclo.Margin = New System.Windows.Forms.Padding(0)
        Me.txtCiclo.Mask = "0000"
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(65, 20)
        Me.txtCiclo.TabIndex = 4
        '
        'txtNumEvaluacion
        '
        Me.txtNumEvaluacion.Location = New System.Drawing.Point(92, 24)
        Me.txtNumEvaluacion.MaxLength = 4
        Me.txtNumEvaluacion.Name = "txtNumEvaluacion"
        Me.txtNumEvaluacion.Size = New System.Drawing.Size(66, 20)
        Me.txtNumEvaluacion.TabIndex = 0
        '
        'lblCiclo
        '
        Me.lblCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCiclo.AutoSize = True
        Me.lblCiclo.ForeColor = System.Drawing.Color.White
        Me.lblCiclo.Location = New System.Drawing.Point(808, 21)
        Me.lblCiclo.Name = "lblCiclo"
        Me.lblCiclo.Size = New System.Drawing.Size(33, 13)
        Me.lblCiclo.TabIndex = 1
        Me.lblCiclo.Text = "Ciclo:"
        Me.lblCiclo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Número:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(13, 53)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(47, 13)
        Me.lblNombre.TabIndex = 15
        Me.lblNombre.Text = "Nombre:"
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgData
        '
        Me.dgData.AllowUserToAddRows = False
        Me.dgData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen
        Me.dgData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgData.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgData.ContextMenuStrip = Me.cmsMenu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgData.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgData.Location = New System.Drawing.Point(0, 112)
        Me.dgData.MultiSelect = False
        Me.dgData.Name = "dgData"
        Me.dgData.ReadOnly = True
        Me.dgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgData.Size = New System.Drawing.Size(1134, 497)
        Me.dgData.TabIndex = 24
        '
        'cmsMenu
        '
        Me.cmsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuModificar, Me.mnuEliminar})
        Me.cmsMenu.Name = "cmsMenu"
        Me.cmsMenu.Size = New System.Drawing.Size(126, 48)
        Me.cmsMenu.Text = "Opciones"
        '
        'mnuModificar
        '
        Me.mnuModificar.Name = "mnuModificar"
        Me.mnuModificar.Size = New System.Drawing.Size(125, 22)
        Me.mnuModificar.Text = "Modificar"
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.Size = New System.Drawing.Size(125, 22)
        Me.mnuEliminar.Text = "Eliminar"
        '
        'frmCulturatipotest1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 609)
        Me.Controls.Add(Me.dgData)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCulturatipotest1"
        Me.Text = "Mantenimiento de Tipo de Evualuación"
        Me.Panel1.ResumeLayout(False)
        Me.gpPrincipal.ResumeLayout(False)
        Me.gpPrincipal.PerformLayout()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents lblCiclo As Label
    Friend WithEvents txtCiclo As MaskedTextBox
    Friend WithEvents txtNumEvaluacion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents dgData As DataGridView
    Friend WithEvents txtNombreEvaluacion As TextBox
    Friend WithEvents gpPrincipal As GroupBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents ImageNuevos As ImageList
    Friend WithEvents cmsMenu As ContextMenuStrip
    Friend WithEvents mnuModificar As ToolStripMenuItem
    Friend WithEvents mnuEliminar As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbNivel As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbGrado As ComboBox
    Friend WithEvents cmbGrado2 As ComboBox
End Class
