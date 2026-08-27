<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBancos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBancos))
        Me.dgBancos = New System.Windows.Forms.DataGridView()
        CType(Me.dgBancos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgBancos
        '
        Me.dgBancos.AllowUserToAddRows = False
        Me.dgBancos.AllowUserToDeleteRows = False
        Me.dgBancos.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGreen
        Me.dgBancos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgBancos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgBancos.BackgroundColor = System.Drawing.Color.White
        Me.dgBancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBancos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgBancos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgBancos.Location = New System.Drawing.Point(0, 0)
        Me.dgBancos.MultiSelect = False
        Me.dgBancos.Name = "dgBancos"
        Me.dgBancos.ReadOnly = True
        Me.dgBancos.RowHeadersVisible = False
        Me.dgBancos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBancos.Size = New System.Drawing.Size(448, 427)
        Me.dgBancos.TabIndex = 44
        '
        'frmBancos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 427)
        Me.Controls.Add(Me.dgBancos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmBancos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bancos"
        CType(Me.dgBancos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgBancos As DataGridView
End Class
