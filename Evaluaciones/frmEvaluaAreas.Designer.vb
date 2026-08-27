<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvaluaAreas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEvaluaAreas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gbArea = New System.Windows.Forms.GroupBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.grdEvaluaArea = New System.Windows.Forms.DataGridView()
        Me.txtCiclo = New System.Windows.Forms.MaskedTextBox()
        Me.lblCiclo = New System.Windows.Forms.Label()
        Me.gbContent = New System.Windows.Forms.GroupBox()
        Me.lblNombreTE = New System.Windows.Forms.Label()
        Me.btnAsignarTE = New System.Windows.Forms.Button()
        Me.btnBuscarTE = New System.Windows.Forms.Button()
        Me.txtNombreTE = New System.Windows.Forms.TextBox()
        Me.txtCodigoTE = New System.Windows.Forms.TextBox()
        Me.lblCodigoTE = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gbArea.SuspendLayout()
        CType(Me.grdEvaluaArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbContent.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip
        '
        Me.ToolTip.AutoPopDelay = 5000
        Me.ToolTip.InitialDelay = 500
        Me.ToolTip.ReshowDelay = 500
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.ImageKey = "cancelar.png"
        Me.btnEliminar.ImageList = Me.ImageNuevos
        Me.btnEliminar.Location = New System.Drawing.Point(516, 17)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(80, 30)
        Me.btnEliminar.TabIndex = 3
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.btnEliminar, "Eliminar evaluación área")
        Me.btnEliminar.UseVisualStyleBackColor = False
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
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(430, 17)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 30)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "Agregar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.btnGuardar, "Guardar evaluación área")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(611, 17)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 4
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.btnLimpiar, "Limpiar formulario")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'gbArea
        '
        Me.gbArea.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbArea.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbArea.Controls.Add(Me.btnEliminar)
        Me.gbArea.Controls.Add(Me.btnGuardar)
        Me.gbArea.Controls.Add(Me.btnLimpiar)
        Me.gbArea.Controls.Add(Me.txtNombre)
        Me.gbArea.Controls.Add(Me.lblNombre)
        Me.gbArea.ForeColor = System.Drawing.Color.White
        Me.gbArea.Location = New System.Drawing.Point(11, 49)
        Me.gbArea.Name = "gbArea"
        Me.gbArea.Size = New System.Drawing.Size(825, 51)
        Me.gbArea.TabIndex = 3
        Me.gbArea.TabStop = False
        Me.gbArea.Text = "Área"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(61, 23)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(362, 20)
        Me.txtNombre.TabIndex = 1
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(6, 26)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(47, 13)
        Me.lblNombre.TabIndex = 3
        Me.lblNombre.Text = "Nombre:"
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdEvaluaArea
        '
        Me.grdEvaluaArea.AllowUserToAddRows = False
        Me.grdEvaluaArea.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen
        Me.grdEvaluaArea.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdEvaluaArea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdEvaluaArea.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grdEvaluaArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdEvaluaArea.GridColor = System.Drawing.Color.WhiteSmoke
        Me.grdEvaluaArea.Location = New System.Drawing.Point(0, 109)
        Me.grdEvaluaArea.MultiSelect = False
        Me.grdEvaluaArea.Name = "grdEvaluaArea"
        Me.grdEvaluaArea.ReadOnly = True
        Me.grdEvaluaArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdEvaluaArea.Size = New System.Drawing.Size(1130, 516)
        Me.grdEvaluaArea.TabIndex = 2
        '
        'txtCiclo
        '
        Me.txtCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCiclo.Location = New System.Drawing.Point(52, 6)
        Me.txtCiclo.Margin = New System.Windows.Forms.Padding(0)
        Me.txtCiclo.Mask = "0000"
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(65, 20)
        Me.txtCiclo.TabIndex = 1
        '
        'lblCiclo
        '
        Me.lblCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCiclo.AutoSize = True
        Me.lblCiclo.ForeColor = System.Drawing.Color.White
        Me.lblCiclo.Location = New System.Drawing.Point(8, 10)
        Me.lblCiclo.Name = "lblCiclo"
        Me.lblCiclo.Size = New System.Drawing.Size(33, 13)
        Me.lblCiclo.TabIndex = 11
        Me.lblCiclo.Text = "Ciclo:"
        Me.lblCiclo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbContent
        '
        Me.gbContent.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbContent.Controls.Add(Me.lblNombreTE)
        Me.gbContent.Controls.Add(Me.btnAsignarTE)
        Me.gbContent.Controls.Add(Me.btnBuscarTE)
        Me.gbContent.Controls.Add(Me.txtNombreTE)
        Me.gbContent.Controls.Add(Me.txtCodigoTE)
        Me.gbContent.Controls.Add(Me.lblCodigoTE)
        Me.gbContent.ForeColor = System.Drawing.Color.White
        Me.gbContent.Location = New System.Drawing.Point(132, 3)
        Me.gbContent.Name = "gbContent"
        Me.gbContent.Size = New System.Drawing.Size(548, 40)
        Me.gbContent.TabIndex = 13
        Me.gbContent.TabStop = False
        Me.gbContent.Text = "Tipo de evaluación"
        '
        'lblNombreTE
        '
        Me.lblNombreTE.AutoSize = True
        Me.lblNombreTE.Location = New System.Drawing.Point(135, 19)
        Me.lblNombreTE.Name = "lblNombreTE"
        Me.lblNombreTE.Size = New System.Drawing.Size(47, 13)
        Me.lblNombreTE.TabIndex = 9
        Me.lblNombreTE.Text = "Nombre:"
        Me.lblNombreTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAsignarTE
        '
        Me.btnAsignarTE.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignarTE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAsignarTE.ImageKey = "checkok.png"
        Me.btnAsignarTE.ImageList = Me.ImageNuevos
        Me.btnAsignarTE.Location = New System.Drawing.Point(503, 8)
        Me.btnAsignarTE.Name = "btnAsignarTE"
        Me.btnAsignarTE.Size = New System.Drawing.Size(40, 30)
        Me.btnAsignarTE.TabIndex = 8
        Me.btnAsignarTE.UseVisualStyleBackColor = False
        '
        'btnBuscarTE
        '
        Me.btnBuscarTE.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarTE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarTE.ImageKey = "buscar2.png"
        Me.btnBuscarTE.ImageList = Me.ImageNuevos
        Me.btnBuscarTE.Location = New System.Drawing.Point(461, 8)
        Me.btnBuscarTE.Name = "btnBuscarTE"
        Me.btnBuscarTE.Size = New System.Drawing.Size(40, 30)
        Me.btnBuscarTE.TabIndex = 7
        Me.btnBuscarTE.UseVisualStyleBackColor = False
        '
        'txtNombreTE
        '
        Me.txtNombreTE.Location = New System.Drawing.Point(192, 15)
        Me.txtNombreTE.Name = "txtNombreTE"
        Me.txtNombreTE.Size = New System.Drawing.Size(265, 20)
        Me.txtNombreTE.TabIndex = 6
        '
        'txtCodigoTE
        '
        Me.txtCodigoTE.Location = New System.Drawing.Point(62, 16)
        Me.txtCodigoTE.Name = "txtCodigoTE"
        Me.txtCodigoTE.Size = New System.Drawing.Size(66, 20)
        Me.txtCodigoTE.TabIndex = 5
        '
        'lblCodigoTE
        '
        Me.lblCodigoTE.AutoSize = True
        Me.lblCodigoTE.Location = New System.Drawing.Point(8, 18)
        Me.lblCodigoTE.Name = "lblCodigoTE"
        Me.lblCodigoTE.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigoTE.TabIndex = 3
        Me.lblCodigoTE.Text = "Código:"
        Me.lblCodigoTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gbContent)
        Me.Panel1.Controls.Add(Me.gbArea)
        Me.Panel1.Controls.Add(Me.lblCiclo)
        Me.Panel1.Controls.Add(Me.txtCiclo)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 103)
        Me.Panel1.TabIndex = 14
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'frmEvaluaAreas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.grdEvaluaArea)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEvaluaAreas"
        Me.Text = "Áreas de Evaluación"
        Me.gbArea.ResumeLayout(False)
        Me.gbArea.PerformLayout()
        CType(Me.grdEvaluaArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbContent.ResumeLayout(False)
        Me.gbContent.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents gbArea As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents grdEvaluaArea As System.Windows.Forms.DataGridView
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents txtCiclo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCiclo As System.Windows.Forms.Label
    Friend WithEvents gbContent As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreTE As System.Windows.Forms.Label
    Friend WithEvents btnAsignarTE As System.Windows.Forms.Button
    Friend WithEvents btnBuscarTE As System.Windows.Forms.Button
    Friend WithEvents txtNombreTE As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoTE As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoTE As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ep1 As ErrorProvider
End Class
