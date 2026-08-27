<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportePasivoLaboralXL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportePasivoLaboralXL))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAñof = New System.Windows.Forms.TextBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.txtAñoi = New System.Windows.Forms.TextBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipoPasivo = New System.Windows.Forms.ComboBox()
        Me.pb1 = New System.Windows.Forms.ProgressBar()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pnIntro = New System.Windows.Forms.Panel()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextMoneEmpresa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnIntro.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbTipoPasivo)
        Me.Panel1.Location = New System.Drawing.Point(12, 57)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(908, 134)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtAñof)
        Me.GroupBox1.Controls.Add(Me.cmbMes)
        Me.GroupBox1.Controls.Add(Me.txtAñoi)
        Me.GroupBox1.Location = New System.Drawing.Point(310, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 95)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(228, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Año Inicial"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(134, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Año Final"
        '
        'txtAñof
        '
        Me.txtAñof.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAñof.Location = New System.Drawing.Point(134, 49)
        Me.txtAñof.MaxLength = 4
        Me.txtAñof.Name = "txtAñof"
        Me.txtAñof.Size = New System.Drawing.Size(56, 20)
        Me.txtAñof.TabIndex = 21
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(228, 48)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(56, 21)
        Me.cmbMes.TabIndex = 16
        '
        'txtAñoi
        '
        Me.txtAñoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAñoi.Location = New System.Drawing.Point(32, 49)
        Me.txtAñoi.MaxLength = 4
        Me.txtAñoi.Name = "txtAñoi"
        Me.txtAñoi.Size = New System.Drawing.Size(56, 20)
        Me.txtAñoi.TabIndex = 20
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(747, 101)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(102, 30)
        Me.btnLimpiar.TabIndex = 90
        Me.btnLimpiar.Text = "Limpiar"
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
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "actualizar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(597, 101)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(102, 30)
        Me.btnEjecutar.TabIndex = 89
        Me.btnEjecutar.Text = "Generar"
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Tipo de Pasivo Laboral"
        '
        'cmbTipoPasivo
        '
        Me.cmbTipoPasivo.FormattingEnabled = True
        Me.cmbTipoPasivo.Location = New System.Drawing.Point(19, 48)
        Me.cmbTipoPasivo.Name = "cmbTipoPasivo"
        Me.cmbTipoPasivo.Size = New System.Drawing.Size(270, 21)
        Me.cmbTipoPasivo.TabIndex = 10
        '
        'pb1
        '
        Me.pb1.Location = New System.Drawing.Point(12, 195)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(300, 23)
        Me.pb1.TabIndex = 1
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'pnIntro
        '
        Me.pnIntro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnIntro.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.pnIntro.Controls.Add(Me.gpEmpresa)
        Me.pnIntro.Location = New System.Drawing.Point(12, -2)
        Me.pnIntro.Name = "pnIntro"
        Me.pnIntro.Size = New System.Drawing.Size(908, 56)
        Me.pnIntro.TabIndex = 92
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextMoneEmpresa)
        Me.gpEmpresa.Controls.Add(Me.Label10)
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(298, 10)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(456, 43)
        Me.gpEmpresa.TabIndex = 57
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextMoneEmpresa
        '
        Me.TextMoneEmpresa.BackColor = System.Drawing.Color.White
        Me.TextMoneEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMoneEmpresa.Location = New System.Drawing.Point(408, 16)
        Me.TextMoneEmpresa.Name = "TextMoneEmpresa"
        Me.TextMoneEmpresa.ReadOnly = True
        Me.TextMoneEmpresa.Size = New System.Drawing.Size(40, 21)
        Me.TextMoneEmpresa.TabIndex = 18
        Me.TextMoneEmpresa.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(346, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Moneda:"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(6, 16)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(330, 21)
        Me.TextNombEmpresa.TabIndex = 2
        Me.TextNombEmpresa.TabStop = False
        '
        'ReportePasivoLaboralXL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 249)
        Me.Controls.Add(Me.pnIntro)
        Me.Controls.Add(Me.pb1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportePasivoLaboralXL"
        Me.Text = "Consultas Pasivo Laboral"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnIntro.ResumeLayout(False)
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pb1 As ProgressBar
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTipoPasivo As ComboBox
    Friend WithEvents txtAñof As TextBox
    Friend WithEvents txtAñoi As TextBox
    Friend WithEvents cmbMes As ComboBox
    Friend WithEvents ImageNuevos As ImageList
    Friend WithEvents ep1 As ErrorProvider
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnEjecutar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pnIntro As Panel
    Friend WithEvents gpEmpresa As GroupBox
    Friend WithEvents TextMoneEmpresa As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextNombEmpresa As TextBox
End Class
