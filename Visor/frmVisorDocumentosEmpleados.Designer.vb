<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVisorDocumentosEmpleados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisorDocumentosEmpleados))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.axFecha = New axFecha.axDateDB()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.gpChofer = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.btnBuscarEmpleado = New System.Windows.Forms.Button()
        Me.pnlPdfViewer = New System.Windows.Forms.Panel()
        Me.gbList = New System.Windows.Forms.GroupBox()
        Me.dgData2 = New System.Windows.Forms.DataGridView()
        Me.empleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ruta_archivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_upload = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnVer = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpChofer.SuspendLayout()
        Me.gbList.SuspendLayout()
        CType(Me.dgData2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gpChofer)
        Me.Panel1.Controls.Add(Me.btnBuscarEmpleado)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(660, 109)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.axFecha)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(12, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(536, 47)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha"
        '
        'axFecha
        '
        Me.axFecha.DateMaxvalue1 = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.axFecha.DateMaxvalue2 = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.axFecha.DateMinvalue1 = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.axFecha.DateMinvalue2 = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.axFecha.Datevalue1 = New Date(2030, 12, 12, 0, 0, 0, 0)
        Me.axFecha.Datevalue2 = New Date(2023, 9, 19, 0, 0, 0, 0)
        Me.axFecha.EsModoConsulta = True
        Me.axFecha.Formato = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.axFecha.FuenteCalendario = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.axFecha.Location = New System.Drawing.Point(6, 14)
        Me.axFecha.Name = "axFecha"
        Me.axFecha.nombreCampo = "fecha_upload"
        Me.axFecha.prefijo = "a"
        Me.axFecha.Size = New System.Drawing.Size(440, 27)
        Me.axFecha.TabIndex = 20
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(630, 16)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(26, 35)
        Me.btnLimpiar.TabIndex = 4
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'gpChofer
        '
        Me.gpChofer.BackColor = System.Drawing.Color.Transparent
        Me.gpChofer.Controls.Add(Me.btnEmpleado)
        Me.gpChofer.Controls.Add(Me.textNombreEmple)
        Me.gpChofer.Controls.Add(Me.textEmpleado)
        Me.gpChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChofer.ForeColor = System.Drawing.Color.White
        Me.gpChofer.Location = New System.Drawing.Point(12, 8)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(536, 45)
        Me.gpChofer.TabIndex = 1
        Me.gpChofer.TabStop = False
        Me.gpChofer.Text = "Empleado"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ForeColor = System.Drawing.Color.Black
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(496, 10)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(37, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.ForeColor = System.Drawing.Color.Black
        Me.textNombreEmple.Location = New System.Drawing.Point(71, 16)
        Me.textNombreEmple.MaxLength = 40
        Me.textNombreEmple.Name = "textNombreEmple"
        Me.textNombreEmple.Size = New System.Drawing.Size(419, 20)
        Me.textNombreEmple.TabIndex = 2
        '
        'textEmpleado
        '
        Me.textEmpleado.BackColor = System.Drawing.Color.White
        Me.textEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textEmpleado.ForeColor = System.Drawing.Color.Black
        Me.textEmpleado.Location = New System.Drawing.Point(9, 16)
        Me.textEmpleado.MaxLength = 6
        Me.textEmpleado.Name = "textEmpleado"
        Me.textEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textEmpleado.TabIndex = 1
        '
        'btnBuscarEmpleado
        '
        Me.btnBuscarEmpleado.BackColor = System.Drawing.Color.White
        Me.btnBuscarEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarEmpleado.ImageKey = "buscar2.png"
        Me.btnBuscarEmpleado.ImageList = Me.ImageNuevos
        Me.btnBuscarEmpleado.Location = New System.Drawing.Point(554, 16)
        Me.btnBuscarEmpleado.Name = "btnBuscarEmpleado"
        Me.btnBuscarEmpleado.Size = New System.Drawing.Size(75, 35)
        Me.btnBuscarEmpleado.TabIndex = 3
        Me.btnBuscarEmpleado.Text = "Buscar"
        Me.btnBuscarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarEmpleado.UseVisualStyleBackColor = False
        '
        'pnlPdfViewer
        '
        Me.pnlPdfViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPdfViewer.BackColor = System.Drawing.Color.White
        Me.pnlPdfViewer.Location = New System.Drawing.Point(666, 8)
        Me.pnlPdfViewer.Name = "pnlPdfViewer"
        Me.pnlPdfViewer.Size = New System.Drawing.Size(441, 663)
        Me.pnlPdfViewer.TabIndex = 6
        '
        'gbList
        '
        Me.gbList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbList.Controls.Add(Me.dgData2)
        Me.gbList.Location = New System.Drawing.Point(12, 115)
        Me.gbList.Name = "gbList"
        Me.gbList.Size = New System.Drawing.Size(648, 556)
        Me.gbList.TabIndex = 5
        Me.gbList.TabStop = False
        Me.gbList.Text = "Actualizados"
        '
        'dgData2
        '
        Me.dgData2.AllowUserToAddRows = False
        Me.dgData2.AllowUserToDeleteRows = False
        Me.dgData2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgData2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgData2.BackgroundColor = System.Drawing.Color.White
        Me.dgData2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgData2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.empleado, Me.tipo, Me.ruta_archivo, Me.nombre, Me.fecha_upload, Me.btnVer})
        Me.dgData2.Location = New System.Drawing.Point(13, 19)
        Me.dgData2.Name = "dgData2"
        Me.dgData2.ReadOnly = True
        Me.dgData2.RowHeadersVisible = False
        Me.dgData2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgData2.Size = New System.Drawing.Size(621, 531)
        Me.dgData2.TabIndex = 3
        '
        'empleado
        '
        Me.empleado.HeaderText = "empleado"
        Me.empleado.Name = "empleado"
        Me.empleado.ReadOnly = True
        Me.empleado.Visible = False
        '
        'tipo
        '
        Me.tipo.HeaderText = "tipo"
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.Visible = False
        '
        'ruta_archivo
        '
        Me.ruta_archivo.HeaderText = "ruta_archivo"
        Me.ruta_archivo.Name = "ruta_archivo"
        Me.ruta_archivo.ReadOnly = True
        Me.ruta_archivo.Visible = False
        '
        'nombre
        '
        Me.nombre.HeaderText = "Documento"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        '
        'fecha_upload
        '
        Me.fecha_upload.HeaderText = "Fecha de Actualización"
        Me.fecha_upload.Name = "fecha_upload"
        Me.fecha_upload.ReadOnly = True
        '
        'btnVer
        '
        Me.btnVer.HeaderText = ""
        Me.btnVer.Name = "btnVer"
        Me.btnVer.ReadOnly = True
        Me.btnVer.Text = "Ver"
        Me.btnVer.UseColumnTextForButtonValue = True
        '
        'frmVisorDocumentosEmpleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1119, 683)
        Me.Controls.Add(Me.gbList)
        Me.Controls.Add(Me.pnlPdfViewer)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmVisorDocumentosEmpleados"
        Me.ShowIcon = False
        Me.Text = "Consulta de Documentos"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        Me.gbList.ResumeLayout(False)
        CType(Me.dgData2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnBuscarEmpleado As Button
    Friend WithEvents axFecha As axFecha.axDateDB
    Friend WithEvents gpChofer As GroupBox
    Friend WithEvents btnEmpleado As Button
    Friend WithEvents textNombreEmple As TextBox
    Friend WithEvents textEmpleado As TextBox
    Friend WithEvents ImageNuevos As ImageList
    Friend WithEvents pnlPdfViewer As Panel
    Friend WithEvents gbList As GroupBox
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents dgData2 As DataGridView
    Friend WithEvents empleado As DataGridViewTextBoxColumn
    Friend WithEvents tipo As DataGridViewTextBoxColumn
    Friend WithEvents ruta_archivo As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents fecha_upload As DataGridViewTextBoxColumn
    Friend WithEvents btnVer As DataGridViewButtonColumn
    Friend WithEvents GroupBox1 As GroupBox
End Class
