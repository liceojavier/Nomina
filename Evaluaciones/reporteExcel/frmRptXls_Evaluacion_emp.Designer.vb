<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptXls_Evaluacion_emp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptXls_Evaluacion_emp))
        Me.pnIntro = New System.Windows.Forms.Panel()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextMoneEmpresa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAñoi = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pb1 = New System.Windows.Forms.ProgressBar()
        Me.pnIndividual = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CtrlBusqEmp = New BusquedaEmpleadoControl()
        Me.rbTodos = New System.Windows.Forms.GroupBox()
        Me.rbAcompa1a3 = New System.Windows.Forms.RadioButton()
        Me.rbMaestraspre = New System.Windows.Forms.RadioButton()
        Me.rbAsistentepre = New System.Windows.Forms.RadioButton()
        Me.rbAcompañante = New System.Windows.Forms.RadioButton()
        Me.rb4a6primaria = New System.Windows.Forms.RadioButton()
        Me.rb2y3primaria = New System.Windows.Forms.RadioButton()
        Me.rbTDocentes = New System.Windows.Forms.RadioButton()
        Me.rbTAdmin = New System.Windows.Forms.RadioButton()
        Me.rb1primero = New System.Windows.Forms.RadioButton()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.bwProceso = New System.ComponentModel.BackgroundWorker()
        Me.pnIntro.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnIndividual.SuspendLayout()
        Me.rbTodos.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnIntro
        '
        Me.pnIntro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnIntro.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.pnIntro.Controls.Add(Me.gpEmpresa)
        Me.pnIntro.Controls.Add(Me.Label1)
        Me.pnIntro.Controls.Add(Me.txtAñoi)
        Me.pnIntro.Location = New System.Drawing.Point(3, 0)
        Me.pnIntro.Name = "pnIntro"
        Me.pnIntro.Size = New System.Drawing.Size(929, 56)
        Me.pnIntro.TabIndex = 93
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
        Me.gpEmpresa.Location = New System.Drawing.Point(308, 10)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(43, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ciclo:"
        '
        'txtAñoi
        '
        Me.txtAñoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAñoi.Location = New System.Drawing.Point(46, 27)
        Me.txtAñoi.MaxLength = 4
        Me.txtAñoi.Name = "txtAñoi"
        Me.txtAñoi.Size = New System.Drawing.Size(56, 20)
        Me.txtAñoi.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.pb1)
        Me.Panel1.Controls.Add(Me.pnIndividual)
        Me.Panel1.Controls.Add(Me.rbTodos)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Location = New System.Drawing.Point(3, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(929, 282)
        Me.Panel1.TabIndex = 94
        '
        'pb1
        '
        Me.pb1.Location = New System.Drawing.Point(202, 91)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(300, 23)
        Me.pb1.TabIndex = 95
        '
        'pnIndividual
        '
        Me.pnIndividual.Controls.Add(Me.Label4)
        Me.pnIndividual.Controls.Add(Me.CtrlBusqEmp)
        Me.pnIndividual.Location = New System.Drawing.Point(754, 20)
        Me.pnIndividual.Name = "pnIndividual"
        Me.pnIndividual.Size = New System.Drawing.Size(80, 34)
        Me.pnIndividual.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Empleado:"
        '
        'CtrlBusqEmp
        '
        Me.CtrlBusqEmp.Contrato = 0
        Me.CtrlBusqEmp.Empleado = 0
        Me.CtrlBusqEmp.id_empresa = CType(0, Short)
        Me.CtrlBusqEmp.Location = New System.Drawing.Point(9, 29)
        Me.CtrlBusqEmp.Name = "CtrlBusqEmp"
        Me.CtrlBusqEmp.Nombre = ""
        Me.CtrlBusqEmp.Size = New System.Drawing.Size(371, 23)
        Me.CtrlBusqEmp.TabIndex = 101
        '
        'rbTodos
        '
        Me.rbTodos.Controls.Add(Me.rbAcompa1a3)
        Me.rbTodos.Controls.Add(Me.rbMaestraspre)
        Me.rbTodos.Controls.Add(Me.rbAsistentepre)
        Me.rbTodos.Controls.Add(Me.rbAcompañante)
        Me.rbTodos.Controls.Add(Me.rb4a6primaria)
        Me.rbTodos.Controls.Add(Me.rb2y3primaria)
        Me.rbTodos.Controls.Add(Me.rbTDocentes)
        Me.rbTodos.Controls.Add(Me.rbTAdmin)
        Me.rbTodos.Controls.Add(Me.rb1primero)
        Me.rbTodos.Location = New System.Drawing.Point(10, 14)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(166, 247)
        Me.rbTodos.TabIndex = 12
        Me.rbTodos.TabStop = False
        Me.rbTodos.Text = "Tipo"
        '
        'rbAcompa1a3
        '
        Me.rbAcompa1a3.AutoSize = True
        Me.rbAcompa1a3.Location = New System.Drawing.Point(7, 215)
        Me.rbAcompa1a3.Name = "rbAcompa1a3"
        Me.rbAcompa1a3.Size = New System.Drawing.Size(148, 17)
        Me.rbAcompa1a3.TabIndex = 9
        Me.rbAcompa1a3.Text = "Acompañante 1ro. a 3ero."
        Me.rbAcompa1a3.UseVisualStyleBackColor = True
        '
        'rbMaestraspre
        '
        Me.rbMaestraspre.AutoSize = True
        Me.rbMaestraspre.Location = New System.Drawing.Point(7, 192)
        Me.rbMaestraspre.Name = "rbMaestraspre"
        Me.rbMaestraspre.Size = New System.Drawing.Size(121, 17)
        Me.rbMaestraspre.TabIndex = 8
        Me.rbMaestraspre.Text = "Maestras Preescolar"
        Me.rbMaestraspre.UseVisualStyleBackColor = True
        '
        'rbAsistentepre
        '
        Me.rbAsistentepre.AutoSize = True
        Me.rbAsistentepre.Location = New System.Drawing.Point(7, 169)
        Me.rbAsistentepre.Name = "rbAsistentepre"
        Me.rbAsistentepre.Size = New System.Drawing.Size(121, 17)
        Me.rbAsistentepre.TabIndex = 7
        Me.rbAsistentepre.Text = "Asistente Preescolar"
        Me.rbAsistentepre.UseVisualStyleBackColor = True
        '
        'rbAcompañante
        '
        Me.rbAcompañante.AutoSize = True
        Me.rbAcompañante.Location = New System.Drawing.Point(6, 146)
        Me.rbAcompañante.Name = "rbAcompañante"
        Me.rbAcompañante.Size = New System.Drawing.Size(96, 17)
        Me.rbAcompañante.TabIndex = 6
        Me.rbAcompañante.Text = "Acompañantes"
        Me.rbAcompañante.UseVisualStyleBackColor = True
        '
        'rb4a6primaria
        '
        Me.rb4a6primaria.AutoSize = True
        Me.rb4a6primaria.Location = New System.Drawing.Point(7, 123)
        Me.rb4a6primaria.Name = "rb4a6primaria"
        Me.rb4a6primaria.Size = New System.Drawing.Size(112, 17)
        Me.rb4a6primaria.TabIndex = 5
        Me.rb4a6primaria.Text = "4to. a 6to. primaria"
        Me.rb4a6primaria.UseVisualStyleBackColor = True
        '
        'rb2y3primaria
        '
        Me.rb2y3primaria.AutoSize = True
        Me.rb2y3primaria.Location = New System.Drawing.Point(7, 98)
        Me.rb2y3primaria.Name = "rb2y3primaria"
        Me.rb2y3primaria.Size = New System.Drawing.Size(114, 17)
        Me.rb2y3primaria.TabIndex = 4
        Me.rb2y3primaria.Text = "2do. y 3ro. primaria"
        Me.rb2y3primaria.UseVisualStyleBackColor = True
        '
        'rbTDocentes
        '
        Me.rbTDocentes.AutoSize = True
        Me.rbTDocentes.Location = New System.Drawing.Point(7, 48)
        Me.rbTDocentes.Name = "rbTDocentes"
        Me.rbTDocentes.Size = New System.Drawing.Size(74, 17)
        Me.rbTDocentes.TabIndex = 3
        Me.rbTDocentes.Text = " Docentes"
        Me.rbTDocentes.UseVisualStyleBackColor = True
        '
        'rbTAdmin
        '
        Me.rbTAdmin.AutoSize = True
        Me.rbTAdmin.Checked = True
        Me.rbTAdmin.Location = New System.Drawing.Point(7, 23)
        Me.rbTAdmin.Name = "rbTAdmin"
        Me.rbTAdmin.Size = New System.Drawing.Size(128, 17)
        Me.rbTAdmin.TabIndex = 2
        Me.rbTAdmin.TabStop = True
        Me.rbTAdmin.Text = "Todos Administrativos"
        Me.rbTAdmin.UseVisualStyleBackColor = True
        '
        'rb1primero
        '
        Me.rb1primero.AutoSize = True
        Me.rb1primero.Location = New System.Drawing.Point(7, 73)
        Me.rb1primero.Name = "rb1primero"
        Me.rb1primero.Size = New System.Drawing.Size(82, 17)
        Me.rb1primero.TabIndex = 0
        Me.rb1primero.Text = "1ro. primaria"
        Me.rb1primero.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.Location = New System.Drawing.Point(796, 101)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(102, 30)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "actualizar.png"
        Me.btnEjecutar.Location = New System.Drawing.Point(676, 101)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(102, 30)
        Me.btnEjecutar.TabIndex = 5
        Me.btnEjecutar.Text = "Generar"
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'bwProceso
        '
        '
        'frmRptXls_Evaluacion_emp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 351)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnIntro)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRptXls_Evaluacion_emp"
        Me.Text = "Reporte Excel"
        Me.pnIntro.ResumeLayout(False)
        Me.pnIntro.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnIndividual.ResumeLayout(False)
        Me.pnIndividual.PerformLayout()
        Me.rbTodos.ResumeLayout(False)
        Me.rbTodos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnIntro As Panel
    Friend WithEvents gpEmpresa As GroupBox
    Friend WithEvents TextMoneEmpresa As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextNombEmpresa As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAñoi As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnIndividual As Panel
    Friend WithEvents rbTodos As GroupBox
    Friend WithEvents rb1primero As RadioButton
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnEjecutar As Button
    Friend WithEvents CtrlBusqEmp As BusquedaEmpleadoControl
    Friend WithEvents Label4 As Label
    Friend WithEvents pb1 As ProgressBar
    Friend WithEvents rbTAdmin As RadioButton
    Friend WithEvents rbTDocentes As RadioButton
    Friend WithEvents bwProceso As System.ComponentModel.BackgroundWorker
    Friend WithEvents rbAcompa1a3 As RadioButton
    Friend WithEvents rbMaestraspre As RadioButton
    Friend WithEvents rbAsistentepre As RadioButton
    Friend WithEvents rbAcompañante As RadioButton
    Friend WithEvents rb4a6primaria As RadioButton
    Friend WithEvents rb2y3primaria As RadioButton
End Class
