<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCulturapreguntas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCulturapreguntas))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbPregunta = New System.Windows.Forms.GroupBox()
        Me.txtNumeroPregunta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuardar2 = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.gbOpciones = New System.Windows.Forms.GroupBox()
        Me.nudMax = New System.Windows.Forms.NumericUpDown()
        Me.txtOpMin = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbMensaje = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtPregunta = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.txtCiclo = New System.Windows.Forms.MaskedTextBox()
        Me.lblCiclo = New System.Windows.Forms.Label()
        Me.grdPreguntas = New System.Windows.Forms.DataGridView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbTipoEvaluacion = New System.Windows.Forms.GroupBox()
        Me.lblNombreTE = New System.Windows.Forms.Label()
        Me.btnAsignarTE = New System.Windows.Forms.Button()
        Me.btnBuscarTE = New System.Windows.Forms.Button()
        Me.txtNombreTE = New System.Windows.Forms.TextBox()
        Me.txtCodigoTE = New System.Windows.Forms.TextBox()
        Me.lblCodigoTE = New System.Windows.Forms.Label()
        Me.ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gbPregunta.SuspendLayout()
        Me.gbOpciones.SuspendLayout()
        CType(Me.nudMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdPreguntas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        Me.gbTipoEvaluacion.SuspendLayout()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPregunta
        '
        Me.gbPregunta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPregunta.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gbPregunta.Controls.Add(Me.txtNumeroPregunta)
        Me.gbPregunta.Controls.Add(Me.Label1)
        Me.gbPregunta.Controls.Add(Me.btnGuardar2)
        Me.gbPregunta.Controls.Add(Me.gbOpciones)
        Me.gbPregunta.Controls.Add(Me.lbMensaje)
        Me.gbPregunta.Controls.Add(Me.btnCancelar)
        Me.gbPregunta.Controls.Add(Me.btnGuardar)
        Me.gbPregunta.Controls.Add(Me.txtPregunta)
        Me.gbPregunta.Controls.Add(Me.lblNombre)
        Me.gbPregunta.Enabled = False
        Me.gbPregunta.Location = New System.Drawing.Point(3, 102)
        Me.gbPregunta.Name = "gbPregunta"
        Me.gbPregunta.Size = New System.Drawing.Size(1140, 142)
        Me.gbPregunta.TabIndex = 23
        Me.gbPregunta.TabStop = False
        Me.gbPregunta.Text = "Pregunta"
        '
        'txtNumeroPregunta
        '
        Me.txtNumeroPregunta.Location = New System.Drawing.Point(86, 26)
        Me.txtNumeroPregunta.Name = "txtNumeroPregunta"
        Me.txtNumeroPregunta.ReadOnly = True
        Me.txtNumeroPregunta.Size = New System.Drawing.Size(66, 20)
        Me.txtNumeroPregunta.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "No. Pregunta:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGuardar2
        '
        Me.btnGuardar2.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar2.ImageKey = "guardar.png"
        Me.btnGuardar2.ImageList = Me.ImageNuevos
        Me.btnGuardar2.Location = New System.Drawing.Point(952, 64)
        Me.btnGuardar2.Name = "btnGuardar2"
        Me.btnGuardar2.Size = New System.Drawing.Size(161, 43)
        Me.btnGuardar2.TabIndex = 24
        Me.btnGuardar2.Text = "Actualización desde Grid"
        Me.btnGuardar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar2.UseVisualStyleBackColor = False
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
        'gbOpciones
        '
        Me.gbOpciones.BackColor = System.Drawing.Color.Transparent
        Me.gbOpciones.Controls.Add(Me.nudMax)
        Me.gbOpciones.Controls.Add(Me.txtOpMin)
        Me.gbOpciones.Controls.Add(Me.Label3)
        Me.gbOpciones.Controls.Add(Me.Label4)
        Me.gbOpciones.Location = New System.Drawing.Point(648, 18)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(265, 45)
        Me.gbOpciones.TabIndex = 10
        Me.gbOpciones.TabStop = False
        Me.gbOpciones.Text = "Opciones"
        Me.gbOpciones.Visible = False
        '
        'nudMax
        '
        Me.nudMax.Location = New System.Drawing.Point(195, 15)
        Me.nudMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudMax.Name = "nudMax"
        Me.nudMax.Size = New System.Drawing.Size(67, 20)
        Me.nudMax.TabIndex = 2
        Me.nudMax.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtOpMin
        '
        Me.txtOpMin.Location = New System.Drawing.Point(62, 14)
        Me.txtOpMin.Name = "txtOpMin"
        Me.txtOpMin.ReadOnly = True
        Me.txtOpMin.Size = New System.Drawing.Size(64, 20)
        Me.txtOpMin.TabIndex = 1
        Me.txtOpMin.Text = "1"
        Me.txtOpMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(138, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Máximas:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Minimas:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbMensaje
        '
        Me.lbMensaje.AutoSize = True
        Me.lbMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMensaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbMensaje.Location = New System.Drawing.Point(919, 119)
        Me.lbMensaje.Name = "lbMensaje"
        Me.lbMensaje.Size = New System.Drawing.Size(15, 16)
        Me.lbMensaje.TabIndex = 22
        Me.lbMensaje.Text = "1"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.ImageKey = "cancelar.png"
        Me.btnCancelar.ImageList = Me.ImageNuevos
        Me.btnCancelar.Location = New System.Drawing.Point(843, 69)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(70, 32)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(843, 103)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(70, 32)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'txtPregunta
        '
        Me.txtPregunta.Location = New System.Drawing.Point(86, 52)
        Me.txtPregunta.Multiline = True
        Me.txtPregunta.Name = "txtPregunta"
        Me.txtPregunta.Size = New System.Drawing.Size(492, 65)
        Me.txtPregunta.TabIndex = 3
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(7, 52)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(53, 13)
        Me.lblNombre.TabIndex = 15
        Me.lblNombre.Text = "Pregunta:"
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.txtCiclo)
        Me.Panel1.Controls.Add(Me.lblCiclo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1147, 44)
        Me.Panel1.TabIndex = 25
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(1103, 5)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(40, 32)
        Me.btnLimpiar.TabIndex = 20
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'txtCiclo
        '
        Me.txtCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCiclo.Location = New System.Drawing.Point(1035, 17)
        Me.txtCiclo.Margin = New System.Windows.Forms.Padding(0)
        Me.txtCiclo.Mask = "0000"
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(65, 20)
        Me.txtCiclo.TabIndex = 4
        '
        'lblCiclo
        '
        Me.lblCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCiclo.AutoSize = True
        Me.lblCiclo.ForeColor = System.Drawing.Color.White
        Me.lblCiclo.Location = New System.Drawing.Point(982, 17)
        Me.lblCiclo.Name = "lblCiclo"
        Me.lblCiclo.Size = New System.Drawing.Size(33, 13)
        Me.lblCiclo.TabIndex = 1
        Me.lblCiclo.Text = "Ciclo:"
        Me.lblCiclo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdPreguntas
        '
        Me.grdPreguntas.AllowUserToAddRows = False
        Me.grdPreguntas.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGreen
        Me.grdPreguntas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdPreguntas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdPreguntas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdPreguntas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdPreguntas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grdPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPreguntas.ContextMenuStrip = Me.ctxMenu
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPreguntas.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdPreguntas.GridColor = System.Drawing.Color.WhiteSmoke
        Me.grdPreguntas.Location = New System.Drawing.Point(8, 250)
        Me.grdPreguntas.MultiSelect = False
        Me.grdPreguntas.Name = "grdPreguntas"
        Me.grdPreguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdPreguntas.Size = New System.Drawing.Size(1130, 416)
        Me.grdPreguntas.TabIndex = 24
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModificar, Me.ctxEliminar})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(126, 48)
        '
        'ctxModificar
        '
        Me.ctxModificar.Name = "ctxModificar"
        Me.ctxModificar.Size = New System.Drawing.Size(125, 22)
        Me.ctxModificar.Text = "Modificar"
        '
        'ctxEliminar
        '
        Me.ctxEliminar.Name = "ctxEliminar"
        Me.ctxEliminar.Size = New System.Drawing.Size(125, 22)
        Me.ctxEliminar.Text = "Eliminar"
        '
        'gbTipoEvaluacion
        '
        Me.gbTipoEvaluacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbTipoEvaluacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gbTipoEvaluacion.Controls.Add(Me.lblNombreTE)
        Me.gbTipoEvaluacion.Controls.Add(Me.btnAsignarTE)
        Me.gbTipoEvaluacion.Controls.Add(Me.btnBuscarTE)
        Me.gbTipoEvaluacion.Controls.Add(Me.txtNombreTE)
        Me.gbTipoEvaluacion.Controls.Add(Me.txtCodigoTE)
        Me.gbTipoEvaluacion.Controls.Add(Me.lblCodigoTE)
        Me.gbTipoEvaluacion.Location = New System.Drawing.Point(3, 47)
        Me.gbTipoEvaluacion.Name = "gbTipoEvaluacion"
        Me.gbTipoEvaluacion.Size = New System.Drawing.Size(1140, 52)
        Me.gbTipoEvaluacion.TabIndex = 22
        Me.gbTipoEvaluacion.TabStop = False
        Me.gbTipoEvaluacion.Text = "Tipo de evalución"
        '
        'lblNombreTE
        '
        Me.lblNombreTE.AutoSize = True
        Me.lblNombreTE.Location = New System.Drawing.Point(151, 21)
        Me.lblNombreTE.Name = "lblNombreTE"
        Me.lblNombreTE.Size = New System.Drawing.Size(47, 13)
        Me.lblNombreTE.TabIndex = 4
        Me.lblNombreTE.Text = "Nombre:"
        Me.lblNombreTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAsignarTE
        '
        Me.btnAsignarTE.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignarTE.ImageKey = "checkok.png"
        Me.btnAsignarTE.ImageList = Me.ImageNuevos
        Me.btnAsignarTE.Location = New System.Drawing.Point(533, 10)
        Me.btnAsignarTE.Name = "btnAsignarTE"
        Me.btnAsignarTE.Size = New System.Drawing.Size(40, 32)
        Me.btnAsignarTE.TabIndex = 4
        Me.btnAsignarTE.UseVisualStyleBackColor = False
        '
        'btnBuscarTE
        '
        Me.btnBuscarTE.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarTE.ImageKey = "buscar2.png"
        Me.btnBuscarTE.ImageList = Me.ImageNuevos
        Me.btnBuscarTE.Location = New System.Drawing.Point(491, 10)
        Me.btnBuscarTE.Name = "btnBuscarTE"
        Me.btnBuscarTE.Size = New System.Drawing.Size(40, 32)
        Me.btnBuscarTE.TabIndex = 3
        Me.btnBuscarTE.UseVisualStyleBackColor = False
        '
        'txtNombreTE
        '
        Me.txtNombreTE.Location = New System.Drawing.Point(220, 18)
        Me.txtNombreTE.Name = "txtNombreTE"
        Me.txtNombreTE.Size = New System.Drawing.Size(265, 20)
        Me.txtNombreTE.TabIndex = 1
        '
        'txtCodigoTE
        '
        Me.txtCodigoTE.Location = New System.Drawing.Point(72, 18)
        Me.txtCodigoTE.Name = "txtCodigoTE"
        Me.txtCodigoTE.Size = New System.Drawing.Size(66, 20)
        Me.txtCodigoTE.TabIndex = 0
        '
        'lblCodigoTE
        '
        Me.lblCodigoTE.AutoSize = True
        Me.lblCodigoTE.Location = New System.Drawing.Point(8, 18)
        Me.lblCodigoTE.Name = "lblCodigoTE"
        Me.lblCodigoTE.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigoTE.TabIndex = 34
        Me.lblCodigoTE.Text = "Código:"
        Me.lblCodigoTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ep
        '
        Me.ep.ContainerControl = Me
        '
        'frmCulturapreguntas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1147, 678)
        Me.Controls.Add(Me.gbPregunta)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grdPreguntas)
        Me.Controls.Add(Me.gbTipoEvaluacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCulturapreguntas"
        Me.Text = "Mantenimiento de Cultura de Preguntas"
        Me.gbPregunta.ResumeLayout(False)
        Me.gbPregunta.PerformLayout()
        Me.gbOpciones.ResumeLayout(False)
        Me.gbOpciones.PerformLayout()
        CType(Me.nudMax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdPreguntas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        Me.gbTipoEvaluacion.ResumeLayout(False)
        Me.gbTipoEvaluacion.PerformLayout()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbPregunta As GroupBox
    Friend WithEvents btnGuardar2 As Button
    Friend WithEvents gbOpciones As GroupBox
    Friend WithEvents nudMax As NumericUpDown
    Friend WithEvents txtOpMin As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbMensaje As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents txtPregunta As TextBox
    Friend WithEvents lblNombre As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents txtCiclo As MaskedTextBox
    Friend WithEvents lblCiclo As Label
    Friend WithEvents grdPreguntas As DataGridView
    Friend WithEvents gbTipoEvaluacion As GroupBox
    Friend WithEvents lblNombreTE As Label
    Friend WithEvents btnAsignarTE As Button
    Friend WithEvents btnBuscarTE As Button
    Friend WithEvents txtNombreTE As TextBox
    Friend WithEvents txtCodigoTE As TextBox
    Friend WithEvents lblCodigoTE As Label
    Friend WithEvents ImageNuevos As ImageList
    Friend WithEvents txtNumeroPregunta As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ep As ErrorProvider
    Friend WithEvents ctxMenu As ContextMenuStrip
    Friend WithEvents ctxModificar As ToolStripMenuItem
    Friend WithEvents ctxEliminar As ToolStripMenuItem
End Class
