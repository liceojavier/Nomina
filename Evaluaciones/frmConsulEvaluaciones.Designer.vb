<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsulEvaluaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsulEvaluaciones))
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.gbContent = New System.Windows.Forms.GroupBox()
        Me.lblNombreTE = New System.Windows.Forms.Label()
        Me.btnBuscarTE = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtNombreTE = New System.Windows.Forms.TextBox()
        Me.txtCodigoTE = New System.Windows.Forms.TextBox()
        Me.lblCodigoTE = New System.Windows.Forms.Label()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.lblCiclo = New System.Windows.Forms.Label()
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbContent.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCiclo
        '
        Me.txtCiclo.Location = New System.Drawing.Point(650, 11)
        Me.txtCiclo.MaxLength = 4
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(58, 20)
        Me.txtCiclo.TabIndex = 14
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageIndex = 1
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(813, 5)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 15
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
        Me.btnLimpiar.UseVisualStyleBackColor = True
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
        'gbContent
        '
        Me.gbContent.Controls.Add(Me.lblNombreTE)
        Me.gbContent.Controls.Add(Me.btnBuscarTE)
        Me.gbContent.Controls.Add(Me.txtNombreTE)
        Me.gbContent.Controls.Add(Me.txtCodigoTE)
        Me.gbContent.Controls.Add(Me.lblCodigoTE)
        Me.gbContent.Location = New System.Drawing.Point(12, 2)
        Me.gbContent.Name = "gbContent"
        Me.gbContent.Size = New System.Drawing.Size(587, 43)
        Me.gbContent.TabIndex = 16
        Me.gbContent.TabStop = False
        Me.gbContent.Text = "Tipo de evaluación"
        '
        'lblNombreTE
        '
        Me.lblNombreTE.AutoSize = True
        Me.lblNombreTE.Location = New System.Drawing.Point(161, 20)
        Me.lblNombreTE.Name = "lblNombreTE"
        Me.lblNombreTE.Size = New System.Drawing.Size(47, 13)
        Me.lblNombreTE.TabIndex = 9
        Me.lblNombreTE.Text = "Nombre:"
        Me.lblNombreTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscarTE
        '
        Me.btnBuscarTE.ImageIndex = 0
        Me.btnBuscarTE.ImageList = Me.ImageList1
        Me.btnBuscarTE.Location = New System.Drawing.Point(491, 11)
        Me.btnBuscarTE.Name = "btnBuscarTE"
        Me.btnBuscarTE.Size = New System.Drawing.Size(40, 30)
        Me.btnBuscarTE.TabIndex = 3
        Me.btnBuscarTE.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "buscar1.png")
        '
        'txtNombreTE
        '
        Me.txtNombreTE.Location = New System.Drawing.Point(214, 17)
        Me.txtNombreTE.Name = "txtNombreTE"
        Me.txtNombreTE.Size = New System.Drawing.Size(265, 20)
        Me.txtNombreTE.TabIndex = 2
        '
        'txtCodigoTE
        '
        Me.txtCodigoTE.Location = New System.Drawing.Point(66, 17)
        Me.txtCodigoTE.Name = "txtCodigoTE"
        Me.txtCodigoTE.Size = New System.Drawing.Size(66, 20)
        Me.txtCodigoTE.TabIndex = 1
        '
        'lblCodigoTE
        '
        Me.lblCodigoTE.AutoSize = True
        Me.lblCodigoTE.Location = New System.Drawing.Point(6, 20)
        Me.lblCodigoTE.Name = "lblCodigoTE"
        Me.lblCodigoTE.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigoTE.TabIndex = 3
        Me.lblCodigoTE.Text = "Código:"
        Me.lblCodigoTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGenerar
        '
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.ImageIndex = 10
        Me.btnGenerar.ImageList = Me.ImageNuevos
        Me.btnGenerar.Location = New System.Drawing.Point(724, 5)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(80, 30)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGenerar, "Generar")
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'lblCiclo
        '
        Me.lblCiclo.AutoSize = True
        Me.lblCiclo.Location = New System.Drawing.Point(606, 14)
        Me.lblCiclo.Name = "lblCiclo"
        Me.lblCiclo.Size = New System.Drawing.Size(33, 13)
        Me.lblCiclo.TabIndex = 17
        Me.lblCiclo.Text = "Ciclo:"
        Me.lblCiclo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Location = New System.Drawing.Point(5, 46)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowGroupTreeButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 566)
        Me.crv.TabIndex = 18
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'frmConsulEvaluaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 609)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.txtCiclo)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.gbContent)
        Me.Controls.Add(Me.lblCiclo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsulEvaluaciones"
        Me.Text = "Consulta de Evaluaciones"
        Me.gbContent.ResumeLayout(False)
        Me.gbContent.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCiclo As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents gbContent As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreTE As System.Windows.Forms.Label
    Friend WithEvents btnBuscarTE As System.Windows.Forms.Button
    Friend WithEvents txtNombreTE As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoTE As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoTE As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents lblCiclo As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As ToolTip
End Class
