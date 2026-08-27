<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrientatest1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrientatest1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.gbBuscarPorAlumno = New System.Windows.Forms.GroupBox()
        Me.btnBuscarPorAlumno = New System.Windows.Forms.Button()
        Me.txtCodAlumno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbBuscar = New System.Windows.Forms.GroupBox()
        Me.btnBuscarPorGrado = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbSeccion = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbGrado = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbNivel = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgData = New System.Windows.Forms.DataGridView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me._id_orientatest1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._ciclo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombretest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._tipotest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.num_alumno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alumno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colegio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombGrado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.seccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.gbBuscarPorAlumno.SuspendLayout()
        Me.gbBuscar.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gbBuscarPorAlumno)
        Me.Panel1.Controls.Add(Me.gbBuscar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtCiclo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1163, 160)
        Me.Panel1.TabIndex = 0
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageIndex = 2
        Me.btnLimpiar.ImageList = Me.ImageList1
        Me.btnLimpiar.Location = New System.Drawing.Point(1076, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 36)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "asignar1.png")
        Me.ImageList1.Images.SetKeyName(1, "cancelar.png")
        Me.ImageList1.Images.SetKeyName(2, "limpiar.png")
        Me.ImageList1.Images.SetKeyName(3, "mas.png")
        Me.ImageList1.Images.SetKeyName(4, "buscar1.png")
        Me.ImageList1.Images.SetKeyName(5, "guardar.png")
        '
        'gbBuscarPorAlumno
        '
        Me.gbBuscarPorAlumno.Controls.Add(Me.btnBuscarPorAlumno)
        Me.gbBuscarPorAlumno.Controls.Add(Me.txtCodAlumno)
        Me.gbBuscarPorAlumno.Controls.Add(Me.Label2)
        Me.gbBuscarPorAlumno.ForeColor = System.Drawing.Color.White
        Me.gbBuscarPorAlumno.Location = New System.Drawing.Point(12, 12)
        Me.gbBuscarPorAlumno.Name = "gbBuscarPorAlumno"
        Me.gbBuscarPorAlumno.Size = New System.Drawing.Size(933, 49)
        Me.gbBuscarPorAlumno.TabIndex = 8
        Me.gbBuscarPorAlumno.TabStop = False
        Me.gbBuscarPorAlumno.Text = "Buscar por alumno"
        '
        'btnBuscarPorAlumno
        '
        Me.btnBuscarPorAlumno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscarPorAlumno.BackColor = System.Drawing.Color.White
        Me.btnBuscarPorAlumno.ForeColor = System.Drawing.Color.Black
        Me.btnBuscarPorAlumno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarPorAlumno.ImageIndex = 4
        Me.btnBuscarPorAlumno.ImageList = Me.ImageList1
        Me.btnBuscarPorAlumno.Location = New System.Drawing.Point(220, 16)
        Me.btnBuscarPorAlumno.Name = "btnBuscarPorAlumno"
        Me.btnBuscarPorAlumno.Size = New System.Drawing.Size(42, 25)
        Me.btnBuscarPorAlumno.TabIndex = 2
        Me.btnBuscarPorAlumno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarPorAlumno.UseVisualStyleBackColor = False
        '
        'txtCodAlumno
        '
        Me.txtCodAlumno.Location = New System.Drawing.Point(91, 19)
        Me.txtCodAlumno.Name = "txtCodAlumno"
        Me.txtCodAlumno.Size = New System.Drawing.Size(103, 20)
        Me.txtCodAlumno.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cod. alumno:"
        '
        'gbBuscar
        '
        Me.gbBuscar.Controls.Add(Me.btnBuscarPorGrado)
        Me.gbBuscar.Controls.Add(Me.Label7)
        Me.gbBuscar.Controls.Add(Me.cmbSeccion)
        Me.gbBuscar.Controls.Add(Me.Label6)
        Me.gbBuscar.Controls.Add(Me.cmbGrado)
        Me.gbBuscar.Controls.Add(Me.Label5)
        Me.gbBuscar.Controls.Add(Me.cmbNivel)
        Me.gbBuscar.ForeColor = System.Drawing.Color.White
        Me.gbBuscar.Location = New System.Drawing.Point(12, 67)
        Me.gbBuscar.Name = "gbBuscar"
        Me.gbBuscar.Size = New System.Drawing.Size(933, 83)
        Me.gbBuscar.TabIndex = 7
        Me.gbBuscar.TabStop = False
        Me.gbBuscar.Text = "Buscar "
        '
        'btnBuscarPorGrado
        '
        Me.btnBuscarPorGrado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscarPorGrado.BackColor = System.Drawing.Color.White
        Me.btnBuscarPorGrado.ForeColor = System.Drawing.Color.Black
        Me.btnBuscarPorGrado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarPorGrado.ImageIndex = 4
        Me.btnBuscarPorGrado.ImageList = Me.ImageList1
        Me.btnBuscarPorGrado.Location = New System.Drawing.Point(386, 52)
        Me.btnBuscarPorGrado.Name = "btnBuscarPorGrado"
        Me.btnBuscarPorGrado.Size = New System.Drawing.Size(42, 25)
        Me.btnBuscarPorGrado.TabIndex = 6
        Me.btnBuscarPorGrado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarPorGrado.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(331, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Sección:"
        '
        'cmbSeccion
        '
        Me.cmbSeccion.FormattingEnabled = True
        Me.cmbSeccion.Items.AddRange(New Object() {"A", "B", "C", "D", "E"})
        Me.cmbSeccion.Location = New System.Drawing.Point(386, 25)
        Me.cmbSeccion.Name = "cmbSeccion"
        Me.cmbSeccion.Size = New System.Drawing.Size(127, 21)
        Me.cmbSeccion.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Grado:"
        '
        'cmbGrado
        '
        Me.cmbGrado.FormattingEnabled = True
        Me.cmbGrado.Location = New System.Drawing.Point(91, 52)
        Me.cmbGrado.Name = "cmbGrado"
        Me.cmbGrado.Size = New System.Drawing.Size(232, 21)
        Me.cmbGrado.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Nivel:"
        '
        'cmbNivel
        '
        Me.cmbNivel.FormattingEnabled = True
        Me.cmbNivel.Location = New System.Drawing.Point(91, 25)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(232, 21)
        Me.cmbNivel.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(963, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ciclo:"
        '
        'txtCiclo
        '
        Me.txtCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCiclo.Location = New System.Drawing.Point(1002, 12)
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(68, 20)
        Me.txtCiclo.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgData)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 160)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1163, 418)
        Me.Panel2.TabIndex = 1
        '
        'dgData
        '
        Me.dgData.AllowUserToAddRows = False
        Me.dgData.AllowUserToDeleteRows = False
        Me.dgData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgData.BackgroundColor = System.Drawing.Color.White
        Me.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me._id_orientatest1, Me._ciclo, Me.nombretest, Me._tipotest, Me.num_alumno, Me.alumno, Me.fecha, Me.colegio, Me.nivel, Me.nombNivel, Me.grado, Me.nombGrado, Me.seccion})
        Me.dgData.ContextMenuStrip = Me.ctxMenu
        Me.dgData.Location = New System.Drawing.Point(12, 6)
        Me.dgData.Name = "dgData"
        Me.dgData.ReadOnly = True
        Me.dgData.RowHeadersVisible = False
        Me.dgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgData.Size = New System.Drawing.Size(1139, 400)
        Me.dgData.TabIndex = 0
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxEliminar})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(118, 26)
        '
        'ctxEliminar
        '
        Me.ctxEliminar.Name = "ctxEliminar"
        Me.ctxEliminar.Size = New System.Drawing.Size(152, 22)
        Me.ctxEliminar.Text = "Eliminar"
        '
        '_id_orientatest1
        '
        Me._id_orientatest1.HeaderText = "_id_orientatest1"
        Me._id_orientatest1.Name = "_id_orientatest1"
        Me._id_orientatest1.ReadOnly = True
        Me._id_orientatest1.Visible = False
        '
        '_ciclo
        '
        Me._ciclo.HeaderText = "_ciclo"
        Me._ciclo.Name = "_ciclo"
        Me._ciclo.ReadOnly = True
        Me._ciclo.Visible = False
        '
        'nombretest
        '
        Me.nombretest.HeaderText = "Tipo"
        Me.nombretest.Name = "nombretest"
        Me.nombretest.ReadOnly = True
        '
        '_tipotest
        '
        Me._tipotest.HeaderText = "_tipotest"
        Me._tipotest.Name = "_tipotest"
        Me._tipotest.ReadOnly = True
        Me._tipotest.Visible = False
        '
        'num_alumno
        '
        Me.num_alumno.HeaderText = "Cod. Alumno"
        Me.num_alumno.Name = "num_alumno"
        Me.num_alumno.ReadOnly = True
        '
        'alumno
        '
        Me.alumno.HeaderText = "Alumno"
        Me.alumno.Name = "alumno"
        Me.alumno.ReadOnly = True
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        '
        'colegio
        '
        Me.colegio.HeaderText = "Colegio"
        Me.colegio.Name = "colegio"
        Me.colegio.ReadOnly = True
        Me.colegio.Visible = False
        '
        'nivel
        '
        Me.nivel.HeaderText = "Nivel"
        Me.nivel.Name = "nivel"
        Me.nivel.ReadOnly = True
        Me.nivel.Visible = False
        '
        'nombNivel
        '
        Me.nombNivel.HeaderText = "Nivel"
        Me.nombNivel.Name = "nombNivel"
        Me.nombNivel.ReadOnly = True
        '
        'grado
        '
        Me.grado.HeaderText = "Grado"
        Me.grado.Name = "grado"
        Me.grado.ReadOnly = True
        Me.grado.Visible = False
        '
        'nombGrado
        '
        Me.nombGrado.HeaderText = "Grado"
        Me.nombGrado.Name = "nombGrado"
        Me.nombGrado.ReadOnly = True
        '
        'seccion
        '
        Me.seccion.HeaderText = "Sección"
        Me.seccion.Name = "seccion"
        Me.seccion.ReadOnly = True
        '
        'frmOrientatest1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1163, 578)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOrientatest1"
        Me.Text = "Alumnos encuestados"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbBuscarPorAlumno.ResumeLayout(False)
        Me.gbBuscarPorAlumno.PerformLayout()
        Me.gbBuscar.ResumeLayout(False)
        Me.gbBuscar.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgData As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCodAlumno As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCiclo As TextBox
    Friend WithEvents gbBuscar As GroupBox
    Friend WithEvents gbBuscarPorAlumno As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbGrado As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbNivel As ComboBox
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbSeccion As ComboBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ctxMenu As ContextMenuStrip
    Friend WithEvents ctxEliminar As ToolStripMenuItem
    Friend WithEvents btnBuscarPorGrado As Button
    Friend WithEvents btnBuscarPorAlumno As Button
    Friend WithEvents _id_orientatest1 As DataGridViewTextBoxColumn
    Friend WithEvents _ciclo As DataGridViewTextBoxColumn
    Friend WithEvents nombretest As DataGridViewTextBoxColumn
    Friend WithEvents _tipotest As DataGridViewTextBoxColumn
    Friend WithEvents num_alumno As DataGridViewTextBoxColumn
    Friend WithEvents alumno As DataGridViewTextBoxColumn
    Friend WithEvents fecha As DataGridViewTextBoxColumn
    Friend WithEvents colegio As DataGridViewTextBoxColumn
    Friend WithEvents nivel As DataGridViewTextBoxColumn
    Friend WithEvents nombNivel As DataGridViewTextBoxColumn
    Friend WithEvents grado As DataGridViewTextBoxColumn
    Friend WithEvents nombGrado As DataGridViewTextBoxColumn
    Friend WithEvents seccion As DataGridViewTextBoxColumn
End Class
