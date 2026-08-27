<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModificacionNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModificacionNomina))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.cklbTipoPersonal = New System.Windows.Forms.CheckedListBox()
        Me.rbCantidad = New System.Windows.Forms.RadioButton()
        Me.rbValores = New System.Windows.Forms.RadioButton()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pgBarra = New System.Windows.Forms.ProgressBar()
        Me.cmbTipoA = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gpFecha.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpFecha
        '
        Me.gpFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.gpFecha.Controls.Add(Me.btnExcel)
        Me.gpFecha.Controls.Add(Me.cklbTipoPersonal)
        Me.gpFecha.Controls.Add(Me.rbCantidad)
        Me.gpFecha.Controls.Add(Me.rbValores)
        Me.gpFecha.Controls.Add(Me.rbTodos)
        Me.gpFecha.Controls.Add(Me.Label2)
        Me.gpFecha.Controls.Add(Me.Label7)
        Me.gpFecha.Controls.Add(Me.Label6)
        Me.gpFecha.Controls.Add(Me.cmbTipo)
        Me.gpFecha.Controls.Add(Me.TextAño)
        Me.gpFecha.Controls.Add(Me.btnEjecutar)
        Me.gpFecha.Controls.Add(Me.cmbMes)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.Location = New System.Drawing.Point(12, 43)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(1098, 83)
        Me.gpFecha.TabIndex = 2
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Tipo y periodo"
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.SystemColors.Control
        Me.btnExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.ImageKey = "guardar.png"
        Me.btnExcel.ImageList = Me.ImageNuevos
        Me.btnExcel.Location = New System.Drawing.Point(960, 46)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(113, 30)
        Me.btnExcel.TabIndex = 9
        Me.btnExcel.Text = "Generar excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = False
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
        'cklbTipoPersonal
        '
        Me.cklbTipoPersonal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cklbTipoPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cklbTipoPersonal.FormattingEnabled = True
        Me.cklbTipoPersonal.Location = New System.Drawing.Point(686, 13)
        Me.cklbTipoPersonal.Name = "cklbTipoPersonal"
        Me.cklbTipoPersonal.Size = New System.Drawing.Size(191, 64)
        Me.cklbTipoPersonal.TabIndex = 7
        '
        'rbCantidad
        '
        Me.rbCantidad.AutoSize = True
        Me.rbCantidad.Location = New System.Drawing.Point(567, 59)
        Me.rbCantidad.Name = "rbCantidad"
        Me.rbCantidad.Size = New System.Drawing.Size(67, 17)
        Me.rbCantidad.TabIndex = 6
        Me.rbCantidad.TabStop = True
        Me.rbCantidad.Text = "Cantidad"
        Me.rbCantidad.UseVisualStyleBackColor = True
        '
        'rbValores
        '
        Me.rbValores.AutoSize = True
        Me.rbValores.Location = New System.Drawing.Point(567, 36)
        Me.rbValores.Name = "rbValores"
        Me.rbValores.Size = New System.Drawing.Size(60, 17)
        Me.rbValores.TabIndex = 5
        Me.rbValores.TabStop = True
        Me.rbValores.Text = "Valores"
        Me.rbValores.UseVisualStyleBackColor = True
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(567, 13)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(102, 17)
        Me.rbTodos.TabIndex = 4
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Valor y Cantidad"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Nómina:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(278, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Mes:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(441, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Año:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(62, 20)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(208, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(477, 19)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(56, 20)
        Me.TextAño.TabIndex = 3
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "actualizar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(960, 10)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(113, 30)
        Me.btnEjecutar.TabIndex = 8
        Me.btnEjecutar.Text = "Consultar"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(316, 18)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbMes.TabIndex = 2
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(12, 132)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(1110, 410)
        Me.dgvData.TabIndex = 3
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(1040, 552)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(82, 30)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'pgBarra
        '
        Me.pgBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgBarra.Location = New System.Drawing.Point(12, 559)
        Me.pgBarra.Name = "pgBarra"
        Me.pgBarra.Size = New System.Drawing.Size(1009, 23)
        Me.pgBarra.TabIndex = 6
        '
        'cmbTipoA
        '
        Me.cmbTipoA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoA.FormattingEnabled = True
        Me.cmbTipoA.Items.AddRange(New Object() {"Consulta", "Modificación"})
        Me.cmbTipoA.Location = New System.Drawing.Point(81, 12)
        Me.cmbTipoA.Name = "cmbTipoA"
        Me.cmbTipoA.Size = New System.Drawing.Size(307, 21)
        Me.cmbTipoA.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Operación"
        '
        'frmModificacionNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 601)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbTipoA)
        Me.Controls.Add(Me.pgBarra)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.gpFecha)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmModificacionNomina"
        Me.Text = "Consulta de Nómina"
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gpFecha As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents TextAño As TextBox
    Friend WithEvents btnEjecutar As Button
    Friend WithEvents ImageNuevos As ImageList
    Friend WithEvents cmbMes As ComboBox
    Friend WithEvents ep1 As ErrorProvider
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents pgBarra As ProgressBar
    Friend WithEvents rbCantidad As RadioButton
    Friend WithEvents rbValores As RadioButton
    Friend WithEvents rbTodos As RadioButton
    Friend WithEvents btnExcel As Button
    Friend WithEvents cklbTipoPersonal As CheckedListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbTipoA As ComboBox
End Class
