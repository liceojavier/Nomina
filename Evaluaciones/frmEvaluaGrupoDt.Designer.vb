<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvaluaGrupoDt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEvaluaGrupoDt))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbGrupo = New System.Windows.Forms.GroupBox()
        Me.lblNombreG = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAsignarG = New System.Windows.Forms.Button()
        Me.btnBuscarG = New System.Windows.Forms.Button()
        Me.txtNombreG = New System.Windows.Forms.TextBox()
        Me.txtCodigoG = New System.Windows.Forms.TextBox()
        Me.lblCodigoG = New System.Windows.Forms.Label()
        Me.gbArea = New System.Windows.Forms.GroupBox()
        Me.lblNombreA = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnAsignarA = New System.Windows.Forms.Button()
        Me.btnBuscarA = New System.Windows.Forms.Button()
        Me.txtNombreA = New System.Windows.Forms.TextBox()
        Me.txtCodigoA = New System.Windows.Forms.TextBox()
        Me.lblCodigoA = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.grdDetalle = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbGrupo.SuspendLayout()
        Me.gbArea.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbGrupo
        '
        Me.gbGrupo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbGrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbGrupo.Controls.Add(Me.lblNombreG)
        Me.gbGrupo.Controls.Add(Me.btnLimpiar)
        Me.gbGrupo.Controls.Add(Me.btnAsignarG)
        Me.gbGrupo.Controls.Add(Me.btnBuscarG)
        Me.gbGrupo.Controls.Add(Me.txtNombreG)
        Me.gbGrupo.Controls.Add(Me.txtCodigoG)
        Me.gbGrupo.Controls.Add(Me.lblCodigoG)
        Me.gbGrupo.ForeColor = System.Drawing.Color.White
        Me.gbGrupo.Location = New System.Drawing.Point(8, 0)
        Me.gbGrupo.Name = "gbGrupo"
        Me.gbGrupo.Size = New System.Drawing.Size(533, 40)
        Me.gbGrupo.TabIndex = 5
        Me.gbGrupo.TabStop = False
        Me.gbGrupo.Text = "Grupo"
        '
        'lblNombreG
        '
        Me.lblNombreG.AutoSize = True
        Me.lblNombreG.Location = New System.Drawing.Point(138, 17)
        Me.lblNombreG.Name = "lblNombreG"
        Me.lblNombreG.Size = New System.Drawing.Size(47, 13)
        Me.lblNombreG.TabIndex = 12
        Me.lblNombreG.Text = "Nombre:"
        Me.lblNombreG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(489, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(40, 30)
        Me.btnLimpiar.TabIndex = 11
        Me.ToolTip.SetToolTip(Me.btnLimpiar, "Limpiar Formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = False
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
        'btnAsignarG
        '
        Me.btnAsignarG.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignarG.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAsignarG.ImageKey = "checkok.png"
        Me.btnAsignarG.ImageList = Me.ImageNuevos
        Me.btnAsignarG.Location = New System.Drawing.Point(447, 8)
        Me.btnAsignarG.Name = "btnAsignarG"
        Me.btnAsignarG.Size = New System.Drawing.Size(40, 30)
        Me.btnAsignarG.TabIndex = 8
        Me.ToolTip.SetToolTip(Me.btnAsignarG, "Asignar Grupo")
        Me.btnAsignarG.UseVisualStyleBackColor = False
        '
        'btnBuscarG
        '
        Me.btnBuscarG.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarG.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarG.ImageKey = "buscar2.png"
        Me.btnBuscarG.ImageList = Me.ImageNuevos
        Me.btnBuscarG.Location = New System.Drawing.Point(405, 8)
        Me.btnBuscarG.Name = "btnBuscarG"
        Me.btnBuscarG.Size = New System.Drawing.Size(40, 30)
        Me.btnBuscarG.TabIndex = 7
        Me.ToolTip.SetToolTip(Me.btnBuscarG, "Buscar Grupo")
        Me.btnBuscarG.UseVisualStyleBackColor = False
        '
        'txtNombreG
        '
        Me.txtNombreG.Location = New System.Drawing.Point(202, 14)
        Me.txtNombreG.Name = "txtNombreG"
        Me.txtNombreG.Size = New System.Drawing.Size(199, 20)
        Me.txtNombreG.TabIndex = 6
        '
        'txtCodigoG
        '
        Me.txtCodigoG.Location = New System.Drawing.Point(64, 14)
        Me.txtCodigoG.Name = "txtCodigoG"
        Me.txtCodigoG.Size = New System.Drawing.Size(66, 20)
        Me.txtCodigoG.TabIndex = 5
        '
        'lblCodigoG
        '
        Me.lblCodigoG.AutoSize = True
        Me.lblCodigoG.Location = New System.Drawing.Point(10, 17)
        Me.lblCodigoG.Name = "lblCodigoG"
        Me.lblCodigoG.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigoG.TabIndex = 3
        Me.lblCodigoG.Text = "Código:"
        Me.lblCodigoG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbArea
        '
        Me.gbArea.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbArea.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbArea.Controls.Add(Me.lblNombreA)
        Me.gbArea.Controls.Add(Me.btnEliminar)
        Me.gbArea.Controls.Add(Me.btnGuardar)
        Me.gbArea.Controls.Add(Me.btnAsignarA)
        Me.gbArea.Controls.Add(Me.btnBuscarA)
        Me.gbArea.Controls.Add(Me.txtNombreA)
        Me.gbArea.Controls.Add(Me.txtCodigoA)
        Me.gbArea.Controls.Add(Me.lblCodigoA)
        Me.gbArea.Enabled = False
        Me.gbArea.ForeColor = System.Drawing.Color.White
        Me.gbArea.Location = New System.Drawing.Point(8, 39)
        Me.gbArea.Name = "gbArea"
        Me.gbArea.Size = New System.Drawing.Size(574, 40)
        Me.gbArea.TabIndex = 9
        Me.gbArea.TabStop = False
        Me.gbArea.Text = "Área"
        '
        'lblNombreA
        '
        Me.lblNombreA.AutoSize = True
        Me.lblNombreA.Location = New System.Drawing.Point(141, 18)
        Me.lblNombreA.Name = "lblNombreA"
        Me.lblNombreA.Size = New System.Drawing.Size(47, 13)
        Me.lblNombreA.TabIndex = 13
        Me.lblNombreA.Text = "Nombre:"
        Me.lblNombreA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.ImageKey = "cancelar.png"
        Me.btnEliminar.ImageList = Me.ImageNuevos
        Me.btnEliminar.Location = New System.Drawing.Point(530, 8)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(40, 30)
        Me.btnEliminar.TabIndex = 10
        Me.ToolTip.SetToolTip(Me.btnEliminar, "Eliminar Detalle")
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(488, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(40, 30)
        Me.btnGuardar.TabIndex = 9
        Me.ToolTip.SetToolTip(Me.btnGuardar, "Guardar Detalle")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnAsignarA
        '
        Me.btnAsignarA.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignarA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAsignarA.ImageKey = "checkok.png"
        Me.btnAsignarA.ImageList = Me.ImageNuevos
        Me.btnAsignarA.Location = New System.Drawing.Point(446, 8)
        Me.btnAsignarA.Name = "btnAsignarA"
        Me.btnAsignarA.Size = New System.Drawing.Size(40, 30)
        Me.btnAsignarA.TabIndex = 8
        Me.ToolTip.SetToolTip(Me.btnAsignarA, "Asignar área")
        Me.btnAsignarA.UseVisualStyleBackColor = False
        '
        'btnBuscarA
        '
        Me.btnBuscarA.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarA.ImageKey = "buscar2.png"
        Me.btnBuscarA.ImageList = Me.ImageNuevos
        Me.btnBuscarA.Location = New System.Drawing.Point(404, 8)
        Me.btnBuscarA.Name = "btnBuscarA"
        Me.btnBuscarA.Size = New System.Drawing.Size(40, 30)
        Me.btnBuscarA.TabIndex = 7
        Me.ToolTip.SetToolTip(Me.btnBuscarA, "Buscar área")
        Me.btnBuscarA.UseVisualStyleBackColor = False
        '
        'txtNombreA
        '
        Me.txtNombreA.Location = New System.Drawing.Point(202, 16)
        Me.txtNombreA.Name = "txtNombreA"
        Me.txtNombreA.Size = New System.Drawing.Size(199, 20)
        Me.txtNombreA.TabIndex = 6
        '
        'txtCodigoA
        '
        Me.txtCodigoA.Location = New System.Drawing.Point(64, 14)
        Me.txtCodigoA.Name = "txtCodigoA"
        Me.txtCodigoA.Size = New System.Drawing.Size(66, 20)
        Me.txtCodigoA.TabIndex = 5
        '
        'lblCodigoA
        '
        Me.lblCodigoA.AutoSize = True
        Me.lblCodigoA.Location = New System.Drawing.Point(10, 17)
        Me.lblCodigoA.Name = "lblCodigoA"
        Me.lblCodigoA.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigoA.TabIndex = 3
        Me.lblCodigoA.Text = "Código:"
        Me.lblCodigoA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolTip
        '
        Me.ToolTip.AutoPopDelay = 5000
        Me.ToolTip.InitialDelay = 500
        Me.ToolTip.ReshowDelay = 500
        '
        'grdDetalle
        '
        Me.grdDetalle.AllowUserToAddRows = False
        Me.grdDetalle.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen
        Me.grdDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDetalle.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grdDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDetalle.GridColor = System.Drawing.Color.WhiteSmoke
        Me.grdDetalle.Location = New System.Drawing.Point(0, 89)
        Me.grdDetalle.MultiSelect = False
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.ReadOnly = True
        Me.grdDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDetalle.Size = New System.Drawing.Size(589, 359)
        Me.grdDetalle.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gbGrupo)
        Me.Panel1.Controls.Add(Me.gbArea)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(589, 83)
        Me.Panel1.TabIndex = 11
        '
        'frmEvaluaGrupoDt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(589, 448)
        Me.Controls.Add(Me.grdDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEvaluaGrupoDt"
        Me.Text = "Detalle de Grupos de Evaluación"
        Me.gbGrupo.ResumeLayout(False)
        Me.gbGrupo.PerformLayout()
        Me.gbArea.ResumeLayout(False)
        Me.gbArea.PerformLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbGrupo As System.Windows.Forms.GroupBox
    Friend WithEvents btnAsignarG As System.Windows.Forms.Button
    Friend WithEvents btnBuscarG As System.Windows.Forms.Button
    Friend WithEvents txtNombreG As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoG As System.Windows.Forms.TextBox
    Friend WithEvents gbArea As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnAsignarA As System.Windows.Forms.Button
    Friend WithEvents btnBuscarA As System.Windows.Forms.Button
    Friend WithEvents txtNombreA As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoA As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoA As System.Windows.Forms.Label
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents grdDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents lblNombreG As System.Windows.Forms.Label
    Friend WithEvents lblCodigoG As System.Windows.Forms.Label
    Friend WithEvents lblNombreA As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
