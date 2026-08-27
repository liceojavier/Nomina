<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutorizacion_arbol
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutorizacion_arbol))
        Me.tt1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gpGeneral = New System.Windows.Forms.GroupBox()
        Me.gpCentro = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.TextEmpleado = New System.Windows.Forms.TextBox()
        Me.TextNombEmpleado = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.btnAgregaJefe = New System.Windows.Forms.Button()
        Me.btnJefe = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodJefe = New System.Windows.Forms.TextBox()
        Me.txtNomJefe = New System.Windows.Forms.TextBox()
        Me.trvwJefe = New System.Windows.Forms.TreeView()
        Me.btnDeletNodo = New System.Windows.Forms.Button()
        Me.gbArbol = New System.Windows.Forms.GroupBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        Me.gpGeneral.SuspendLayout()
        Me.gpCentro.SuspendLayout()
        Me.gbArbol.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "usuario.png")
        Me.ImageList1.Images.SetKeyName(1, "buscar2.png")
        Me.ImageList1.Images.SetKeyName(2, "mas.png")
        Me.ImageList1.Images.SetKeyName(3, "menos.png")
        Me.ImageList1.Images.SetKeyName(4, "limpiar.png")
        Me.ImageList1.Images.SetKeyName(5, "guardar.png")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(687, 60)
        Me.Panel1.TabIndex = 15
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(158, 6)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(360, 43)
        Me.gpEmpresa.TabIndex = 13
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(10, 16)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(344, 21)
        Me.TextNombEmpresa.TabIndex = 1
        Me.TextNombEmpresa.TabStop = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageIndex = 4
        Me.btnLimpiar.ImageList = Me.ImageList1
        Me.btnLimpiar.Location = New System.Drawing.Point(532, 314)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 30)
        Me.btnLimpiar.TabIndex = 12
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'gpGeneral
        '
        Me.gpGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpGeneral.Controls.Add(Me.gpCentro)
        Me.gpGeneral.Location = New System.Drawing.Point(3, 66)
        Me.gpGeneral.Name = "gpGeneral"
        Me.gpGeneral.Size = New System.Drawing.Size(674, 67)
        Me.gpGeneral.TabIndex = 16
        Me.gpGeneral.TabStop = False
        '
        'gpCentro
        '
        Me.gpCentro.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpCentro.Controls.Add(Me.btnBuscar)
        Me.gpCentro.Controls.Add(Me.TextEmpleado)
        Me.gpCentro.Controls.Add(Me.TextNombEmpleado)
        Me.gpCentro.Controls.Add(Me.Label19)
        Me.gpCentro.Controls.Add(Me.btnEmpleado)
        Me.gpCentro.Controls.Add(Me.Label4)
        Me.gpCentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCentro.Location = New System.Drawing.Point(12, 16)
        Me.gpCentro.Name = "gpCentro"
        Me.gpCentro.Size = New System.Drawing.Size(652, 46)
        Me.gpCentro.TabIndex = 2
        Me.gpCentro.TabStop = False
        Me.gpCentro.Text = "Usuario"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageIndex = 1
        Me.btnBuscar.ImageList = Me.ImageList1
        Me.btnBuscar.Location = New System.Drawing.Point(581, 10)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 30)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Buscar")
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'TextEmpleado
        '
        Me.TextEmpleado.BackColor = System.Drawing.Color.White
        Me.TextEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEmpleado.Location = New System.Drawing.Point(54, 19)
        Me.TextEmpleado.MaxLength = 4
        Me.TextEmpleado.Name = "TextEmpleado"
        Me.TextEmpleado.Size = New System.Drawing.Size(64, 20)
        Me.TextEmpleado.TabIndex = 1
        '
        'TextNombEmpleado
        '
        Me.TextNombEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpleado.Location = New System.Drawing.Point(181, 19)
        Me.TextNombEmpleado.MaxLength = 30
        Me.TextNombEmpleado.Name = "TextNombEmpleado"
        Me.TextNombEmpleado.Size = New System.Drawing.Size(328, 20)
        Me.TextNombEmpleado.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(126, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Nombre:"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ImageIndex = 0
        Me.btnEmpleado.ImageList = Me.ImageList1
        Me.btnEmpleado.Location = New System.Drawing.Point(514, 10)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(60, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Usuario")
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Código:"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnSave.BackColor = System.Drawing.SystemColors.Control
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ImageIndex = 5
        Me.BtnSave.ImageList = Me.ImageList1
        Me.BtnSave.Location = New System.Drawing.Point(602, 314)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(60, 30)
        Me.BtnSave.TabIndex = 11
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.BtnSave, "Guardar")
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'btnAgregaJefe
        '
        Me.btnAgregaJefe.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregaJefe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregaJefe.ImageIndex = 2
        Me.btnAgregaJefe.ImageList = Me.ImageList1
        Me.btnAgregaJefe.Location = New System.Drawing.Point(436, 15)
        Me.btnAgregaJefe.Name = "btnAgregaJefe"
        Me.btnAgregaJefe.Size = New System.Drawing.Size(60, 30)
        Me.btnAgregaJefe.TabIndex = 62
        Me.btnAgregaJefe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregaJefe.UseVisualStyleBackColor = False
        '
        'btnJefe
        '
        Me.btnJefe.BackColor = System.Drawing.SystemColors.Control
        Me.btnJefe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJefe.ImageIndex = 0
        Me.btnJefe.ImageList = Me.ImageList1
        Me.btnJefe.Location = New System.Drawing.Point(372, 14)
        Me.btnJefe.Name = "btnJefe"
        Me.btnJefe.Size = New System.Drawing.Size(60, 30)
        Me.btnJefe.TabIndex = 59
        Me.btnJefe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnJefe, "Jefe")
        Me.btnJefe.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Jefes:"
        '
        'txtCodJefe
        '
        Me.txtCodJefe.BackColor = System.Drawing.Color.White
        Me.txtCodJefe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodJefe.Location = New System.Drawing.Point(69, 23)
        Me.txtCodJefe.MaxLength = 4
        Me.txtCodJefe.Name = "txtCodJefe"
        Me.txtCodJefe.Size = New System.Drawing.Size(64, 20)
        Me.txtCodJefe.TabIndex = 58
        '
        'txtNomJefe
        '
        Me.txtNomJefe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomJefe.Location = New System.Drawing.Point(142, 23)
        Me.txtNomJefe.MaxLength = 30
        Me.txtNomJefe.Name = "txtNomJefe"
        Me.txtNomJefe.Size = New System.Drawing.Size(222, 20)
        Me.txtNomJefe.TabIndex = 61
        '
        'trvwJefe
        '
        Me.trvwJefe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.trvwJefe.Location = New System.Drawing.Point(64, 51)
        Me.trvwJefe.Name = "trvwJefe"
        Me.trvwJefe.Size = New System.Drawing.Size(496, 257)
        Me.trvwJefe.TabIndex = 64
        '
        'btnDeletNodo
        '
        Me.btnDeletNodo.BackColor = System.Drawing.SystemColors.Control
        Me.btnDeletNodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeletNodo.ImageIndex = 3
        Me.btnDeletNodo.ImageList = Me.ImageList1
        Me.btnDeletNodo.Location = New System.Drawing.Point(500, 15)
        Me.btnDeletNodo.Name = "btnDeletNodo"
        Me.btnDeletNodo.Size = New System.Drawing.Size(60, 30)
        Me.btnDeletNodo.TabIndex = 66
        Me.btnDeletNodo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDeletNodo.UseVisualStyleBackColor = False
        '
        'gbArbol
        '
        Me.gbArbol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbArbol.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gbArbol.Controls.Add(Me.txtCodJefe)
        Me.gbArbol.Controls.Add(Me.btnDeletNodo)
        Me.gbArbol.Controls.Add(Me.txtNomJefe)
        Me.gbArbol.Controls.Add(Me.btnLimpiar)
        Me.gbArbol.Controls.Add(Me.BtnSave)
        Me.gbArbol.Controls.Add(Me.trvwJefe)
        Me.gbArbol.Controls.Add(Me.Label2)
        Me.gbArbol.Controls.Add(Me.btnAgregaJefe)
        Me.gbArbol.Controls.Add(Me.btnJefe)
        Me.gbArbol.Location = New System.Drawing.Point(5, 136)
        Me.gbArbol.Name = "gbArbol"
        Me.gbArbol.Size = New System.Drawing.Size(670, 350)
        Me.gbArbol.TabIndex = 67
        Me.gbArbol.TabStop = False
        '
        'frmAutorizacion_arbol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 487)
        Me.Controls.Add(Me.gbArbol)
        Me.Controls.Add(Me.gpGeneral)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmAutorizacion_arbol"
        Me.Text = "Autorización de Permisos"
        Me.Panel1.ResumeLayout(False)
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.gpGeneral.ResumeLayout(False)
        Me.gpCentro.ResumeLayout(False)
        Me.gpCentro.PerformLayout()
        Me.gbArbol.ResumeLayout(False)
        Me.gbArbol.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tt1 As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents gpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents gpCentro As System.Windows.Forms.GroupBox
    Friend WithEvents TextEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents TextNombEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents btnAgregaJefe As System.Windows.Forms.Button
    Friend WithEvents btnJefe As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodJefe As System.Windows.Forms.TextBox
    Friend WithEvents txtNomJefe As System.Windows.Forms.TextBox
    Friend WithEvents trvwJefe As System.Windows.Forms.TreeView
    Friend WithEvents btnDeletNodo As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents gbArbol As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
