<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistroNominas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistroNominas))
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.TextFiltro = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.id_nr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mes_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpresaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TiponomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TiponomnombreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AñoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadonombreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsPrincipal = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsConsultas1 = New NOMINA.dsConsultas()
        Me.QueryRegistroNominaTableAdapter = New NOMINA.dsConsultasTableAdapters.QueryRegistroNominaTableAdapter()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        CType(Me.bsPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsConsultas1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.AutoGenerateColumns = False
        Me.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmpresaDataGridViewTextBoxColumn, Me.id_nr, Me.TiponomDataGridViewTextBoxColumn, Me.TiponomnombreDataGridViewTextBoxColumn, Me.MesDataGridViewTextBoxColumn, Me.mes_nombre, Me.AñoDataGridViewTextBoxColumn, Me.FechaDataGridViewTextBoxColumn, Me.HoraDataGridViewTextBoxColumn, Me.UsuarioDataGridViewTextBoxColumn, Me.EstadoDataGridViewTextBoxColumn, Me.EstadonombreDataGridViewTextBoxColumn, Me.FechaeDataGridViewTextBoxColumn, Me.HoraeDataGridViewTextBoxColumn, Me.UsuarioeDataGridViewTextBoxColumn})
        Me.dgvData.ContextMenuStrip = Me.ctxMenu
        Me.dgvData.DataSource = Me.bsPrincipal
        Me.dgvData.Location = New System.Drawing.Point(12, 87)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(1110, 502)
        Me.dgvData.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Año:"
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(71, 33)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(56, 20)
        Me.TextAño.TabIndex = 15
        '
        'TextFiltro
        '
        Me.TextFiltro.Location = New System.Drawing.Point(71, 61)
        Me.TextFiltro.Name = "TextFiltro"
        Me.TextFiltro.Size = New System.Drawing.Size(657, 20)
        Me.TextFiltro.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Nómina:"
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnularToolStripMenuItem})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(110, 26)
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'id_nr
        '
        Me.id_nr.DataPropertyName = "id_nr"
        Me.id_nr.HeaderText = "id_nr"
        Me.id_nr.Name = "id_nr"
        Me.id_nr.ReadOnly = True
        Me.id_nr.Visible = False
        '
        'mes_nombre
        '
        Me.mes_nombre.DataPropertyName = "mes_nombre"
        Me.mes_nombre.FillWeight = 10.0!
        Me.mes_nombre.HeaderText = "Mes"
        Me.mes_nombre.Name = "mes_nombre"
        '
        'EmpresaDataGridViewTextBoxColumn
        '
        Me.EmpresaDataGridViewTextBoxColumn.DataPropertyName = "empresa"
        Me.EmpresaDataGridViewTextBoxColumn.HeaderText = "empresa"
        Me.EmpresaDataGridViewTextBoxColumn.Name = "EmpresaDataGridViewTextBoxColumn"
        Me.EmpresaDataGridViewTextBoxColumn.Visible = False
        '
        'TiponomDataGridViewTextBoxColumn
        '
        Me.TiponomDataGridViewTextBoxColumn.DataPropertyName = "tiponom"
        Me.TiponomDataGridViewTextBoxColumn.HeaderText = "tiponom"
        Me.TiponomDataGridViewTextBoxColumn.Name = "TiponomDataGridViewTextBoxColumn"
        Me.TiponomDataGridViewTextBoxColumn.Visible = False
        '
        'TiponomnombreDataGridViewTextBoxColumn
        '
        Me.TiponomnombreDataGridViewTextBoxColumn.DataPropertyName = "tiponom_nombre"
        Me.TiponomnombreDataGridViewTextBoxColumn.FillWeight = 24.0!
        Me.TiponomnombreDataGridViewTextBoxColumn.HeaderText = "Nómina"
        Me.TiponomnombreDataGridViewTextBoxColumn.Name = "TiponomnombreDataGridViewTextBoxColumn"
        '
        'MesDataGridViewTextBoxColumn
        '
        Me.MesDataGridViewTextBoxColumn.DataPropertyName = "mes"
        Me.MesDataGridViewTextBoxColumn.FillWeight = 8.0!
        Me.MesDataGridViewTextBoxColumn.HeaderText = "Mes"
        Me.MesDataGridViewTextBoxColumn.Name = "MesDataGridViewTextBoxColumn"
        Me.MesDataGridViewTextBoxColumn.Visible = False
        '
        'AñoDataGridViewTextBoxColumn
        '
        Me.AñoDataGridViewTextBoxColumn.DataPropertyName = "año"
        Me.AñoDataGridViewTextBoxColumn.FillWeight = 8.0!
        Me.AñoDataGridViewTextBoxColumn.HeaderText = "Año"
        Me.AñoDataGridViewTextBoxColumn.Name = "AñoDataGridViewTextBoxColumn"
        '
        'FechaDataGridViewTextBoxColumn
        '
        Me.FechaDataGridViewTextBoxColumn.DataPropertyName = "fecha"
        Me.FechaDataGridViewTextBoxColumn.FillWeight = 8.0!
        Me.FechaDataGridViewTextBoxColumn.HeaderText = "Fecha Ing."
        Me.FechaDataGridViewTextBoxColumn.Name = "FechaDataGridViewTextBoxColumn"
        '
        'HoraDataGridViewTextBoxColumn
        '
        Me.HoraDataGridViewTextBoxColumn.DataPropertyName = "hora"
        Me.HoraDataGridViewTextBoxColumn.FillWeight = 6.0!
        Me.HoraDataGridViewTextBoxColumn.HeaderText = "Hora Ing."
        Me.HoraDataGridViewTextBoxColumn.Name = "HoraDataGridViewTextBoxColumn"
        '
        'UsuarioDataGridViewTextBoxColumn
        '
        Me.UsuarioDataGridViewTextBoxColumn.DataPropertyName = "usuario"
        Me.UsuarioDataGridViewTextBoxColumn.FillWeight = 10.0!
        Me.UsuarioDataGridViewTextBoxColumn.HeaderText = "Usuario Ing."
        Me.UsuarioDataGridViewTextBoxColumn.Name = "UsuarioDataGridViewTextBoxColumn"
        '
        'EstadoDataGridViewTextBoxColumn
        '
        Me.EstadoDataGridViewTextBoxColumn.DataPropertyName = "estado"
        Me.EstadoDataGridViewTextBoxColumn.HeaderText = "estado"
        Me.EstadoDataGridViewTextBoxColumn.Name = "EstadoDataGridViewTextBoxColumn"
        Me.EstadoDataGridViewTextBoxColumn.Visible = False
        '
        'EstadonombreDataGridViewTextBoxColumn
        '
        Me.EstadonombreDataGridViewTextBoxColumn.DataPropertyName = "estado_nombre"
        Me.EstadonombreDataGridViewTextBoxColumn.FillWeight = 10.0!
        Me.EstadonombreDataGridViewTextBoxColumn.HeaderText = "Estado"
        Me.EstadonombreDataGridViewTextBoxColumn.Name = "EstadonombreDataGridViewTextBoxColumn"
        '
        'FechaeDataGridViewTextBoxColumn
        '
        Me.FechaeDataGridViewTextBoxColumn.DataPropertyName = "fechae"
        Me.FechaeDataGridViewTextBoxColumn.FillWeight = 8.0!
        Me.FechaeDataGridViewTextBoxColumn.HeaderText = "Fecha Est."
        Me.FechaeDataGridViewTextBoxColumn.Name = "FechaeDataGridViewTextBoxColumn"
        '
        'HoraeDataGridViewTextBoxColumn
        '
        Me.HoraeDataGridViewTextBoxColumn.DataPropertyName = "horae"
        Me.HoraeDataGridViewTextBoxColumn.FillWeight = 6.0!
        Me.HoraeDataGridViewTextBoxColumn.HeaderText = "Hora Est."
        Me.HoraeDataGridViewTextBoxColumn.Name = "HoraeDataGridViewTextBoxColumn"
        '
        'UsuarioeDataGridViewTextBoxColumn
        '
        Me.UsuarioeDataGridViewTextBoxColumn.DataPropertyName = "usuarioe"
        Me.UsuarioeDataGridViewTextBoxColumn.FillWeight = 10.0!
        Me.UsuarioeDataGridViewTextBoxColumn.HeaderText = "Usuario Est."
        Me.UsuarioeDataGridViewTextBoxColumn.Name = "UsuarioeDataGridViewTextBoxColumn"
        '
        'bsPrincipal
        '
        Me.bsPrincipal.DataMember = "QueryRegistroNomina"
        Me.bsPrincipal.DataSource = Me.DsConsultas1
        Me.bsPrincipal.Sort = "año, mes, tiponom"
        '
        'DsConsultas1
        '
        Me.DsConsultas1.DataSetName = "dsConsultas"
        Me.DsConsultas1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'QueryRegistroNominaTableAdapter
        '
        Me.QueryRegistroNominaTableAdapter.ClearBeforeFill = True
        '
        'frmRegistroNominas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 601)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFiltro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextAño)
        Me.Controls.Add(Me.dgvData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRegistroNominas"
        Me.Text = "Registro de nóminas generadas  y pagadas"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        CType(Me.bsPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsConsultas1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvData As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents TextAño As TextBox
    Friend WithEvents TextFiltro As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DsConsultas1 As dsConsultas
    Friend WithEvents bsPrincipal As BindingSource
    Friend WithEvents QueryRegistroNominaTableAdapter As dsConsultasTableAdapters.QueryRegistroNominaTableAdapter
    Friend WithEvents ctxMenu As ContextMenuStrip
    Friend WithEvents AnularToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmpresaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents id_nr As DataGridViewTextBoxColumn
    Friend WithEvents TiponomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TiponomnombreDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents mes_nombre As DataGridViewTextBoxColumn
    Friend WithEvents AñoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FechaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HoraDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EstadoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EstadonombreDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FechaeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HoraeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
