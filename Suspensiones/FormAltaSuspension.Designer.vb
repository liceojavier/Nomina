<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAltaSuspension
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAltaSuspension))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnValidar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtFechaI = New System.Windows.Forms.TextBox()
        Me.dpFechaF = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtFechaI)
        Me.Panel1.Controls.Add(Me.txtNum)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtEmpleado)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnValidar)
        Me.Panel1.Controls.Add(Me.dpFechaF)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtValor)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Location = New System.Drawing.Point(7, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(760, 211)
        Me.Panel1.TabIndex = 0
        '
        'txtNum
        '
        Me.txtNum.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtNum.BackColor = System.Drawing.Color.White
        Me.txtNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNum.ForeColor = System.Drawing.Color.Red
        Me.txtNum.Location = New System.Drawing.Point(644, 76)
        Me.txtNum.MaxLength = 200
        Me.txtNum.Name = "txtNum"
        Me.txtNum.ReadOnly = True
        Me.txtNum.Size = New System.Drawing.Size(95, 20)
        Me.txtNum.TabIndex = 116
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(552, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "Número de días:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmpleado
        '
        Me.txtEmpleado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtEmpleado.BackColor = System.Drawing.Color.White
        Me.txtEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpleado.ForeColor = System.Drawing.Color.Red
        Me.txtEmpleado.Location = New System.Drawing.Point(16, 25)
        Me.txtEmpleado.MaxLength = 200
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.ReadOnly = True
        Me.txtEmpleado.Size = New System.Drawing.Size(310, 20)
        Me.txtEmpleado.TabIndex = 114
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Nombre:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnValidar
        '
        Me.btnValidar.BackColor = System.Drawing.SystemColors.Control
        Me.btnValidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnValidar.ImageIndex = 0
        Me.btnValidar.ImageList = Me.ImageList1
        Me.btnValidar.Location = New System.Drawing.Point(16, 162)
        Me.btnValidar.Name = "btnValidar"
        Me.btnValidar.Size = New System.Drawing.Size(68, 40)
        Me.btnValidar.TabIndex = 112
        Me.btnValidar.Text = "Validar"
        Me.btnValidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnValidar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "buscar2.png")
        Me.ImageList1.Images.SetKeyName(1, "limpiar.png")
        Me.ImageList1.Images.SetKeyName(2, "guardar.png")
        Me.ImageList1.Images.SetKeyName(3, "cancelar.png")
        Me.ImageList1.Images.SetKeyName(4, "familia.png")
        Me.ImageList1.Images.SetKeyName(5, "usuario.png")
        Me.ImageList1.Images.SetKeyName(6, "actualizar.png")
        Me.ImageList1.Images.SetKeyName(7, "anterior.png")
        Me.ImageList1.Images.SetKeyName(8, "siguiente.png")
        Me.ImageList1.Images.SetKeyName(9, "mas.png")
        Me.ImageList1.Images.SetKeyName(10, "edit1.png")
        Me.ImageList1.Images.SetKeyName(11, "reportegenerar.png")
        Me.ImageList1.Images.SetKeyName(12, "impresora2.png")
        Me.ImageList1.Images.SetKeyName(13, "checkok.png")
        Me.ImageList1.Images.SetKeyName(14, "buscar1.png")
        Me.ImageList1.Images.SetKeyName(15, "reportever.png")
        Me.ImageList1.Images.SetKeyName(16, "mostrar.png")
        Me.ImageList1.Images.SetKeyName(17, "detalle.png")
        Me.ImageList1.Images.SetKeyName(18, "fecha.png")
        Me.ImageList1.Images.SetKeyName(19, "open.png")
        Me.ImageList1.Images.SetKeyName(20, "menos.png")
        '
        'txtFechaI
        '
        Me.txtFechaI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtFechaI.BackColor = System.Drawing.Color.White
        Me.txtFechaI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaI.ForeColor = System.Drawing.Color.Red
        Me.txtFechaI.Location = New System.Drawing.Point(82, 76)
        Me.txtFechaI.MaxLength = 10
        Me.txtFechaI.Name = "txtFechaI"
        Me.txtFechaI.ReadOnly = True
        Me.txtFechaI.Size = New System.Drawing.Size(95, 20)
        Me.txtFechaI.TabIndex = 111
        '
        'dpFechaF
        '
        Me.dpFechaF.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaF.Location = New System.Drawing.Point(250, 76)
        Me.dpFechaF.Name = "dpFechaF"
        Me.dpFechaF.Size = New System.Drawing.Size(111, 20)
        Me.dpFechaF.TabIndex = 108
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(377, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Valor total:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValor
        '
        Me.txtValor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtValor.BackColor = System.Drawing.Color.White
        Me.txtValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor.ForeColor = System.Drawing.Color.Red
        Me.txtValor.Location = New System.Drawing.Point(440, 76)
        Me.txtValor.MaxLength = 8
        Me.txtValor.Name = "txtValor"
        Me.txtValor.ReadOnly = True
        Me.txtValor.Size = New System.Drawing.Size(95, 20)
        Me.txtValor.TabIndex = 106
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageIndex = 13
        Me.btnGuardar.ImageList = Me.ImageList1
        Me.btnGuardar.Location = New System.Drawing.Point(109, 162)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(90, 40)
        Me.btnGuardar.TabIndex = 102
        Me.btnGuardar.Text = "Dar de alta"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(186, 76)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(62, 13)
        Me.Label32.TabIndex = 105
        Me.Label32.Text = "Fecha final:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ImageNuevos
        '
        Me.ImageNuevos.ImageStream = CType(resources.GetObject("ImageNuevos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageNuevos.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageNuevos.Images.SetKeyName(0, "cheque.png")
        Me.ImageNuevos.Images.SetKeyName(1, "buscar.png")
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'dgvData
        '
        Me.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(7, 241)
        Me.dgvData.Name = "dgvData"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvData.Size = New System.Drawing.Size(761, 298)
        Me.dgvData.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(199, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Días para calculo de planillas especiales"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Fecha inicial:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormAltaSuspension
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(786, 550)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAltaSuspension"
        Me.Text = "Alta de Suspensiones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtValor As TextBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label32 As Label
    Friend WithEvents ImageNuevos As ImageList
    Friend WithEvents ep1 As ErrorProvider
    Friend WithEvents dpFechaF As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFechaI As TextBox
    Friend WithEvents btnValidar As Button
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents txtNum As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEmpleado As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label1 As Label
End Class
