<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvaluaAreas2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEvaluaAreas2))
        Me.Evalua_areasBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.Evalua_areasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetAcademia = New NOMINA.DataSetAcademia()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Evalua_areasBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empresa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Evalua_areasTableAdapter = New NOMINA.DataSetAcademiaTableAdapters.evalua_areasTableAdapter()
        Me.TableAdapterManager = New NOMINA.DataSetAcademiaTableAdapters.TableAdapterManager()
        CType(Me.Evalua_areasBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Evalua_areasBindingNavigator.SuspendLayout()
        CType(Me.Evalua_areasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetAcademia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Evalua_areasBindingNavigator
        '
        Me.Evalua_areasBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.Evalua_areasBindingNavigator.BindingSource = Me.Evalua_areasBindingSource
        Me.Evalua_areasBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.Evalua_areasBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.Evalua_areasBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.Evalua_areasBindingNavigatorSaveItem})
        Me.Evalua_areasBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.Evalua_areasBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Evalua_areasBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Evalua_areasBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Evalua_areasBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Evalua_areasBindingNavigator.Name = "Evalua_areasBindingNavigator"
        Me.Evalua_areasBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.Evalua_areasBindingNavigator.Size = New System.Drawing.Size(1134, 25)
        Me.Evalua_areasBindingNavigator.TabIndex = 0
        Me.Evalua_areasBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Agregar nuevo"
        '
        'Evalua_areasBindingSource
        '
        Me.Evalua_areasBindingSource.DataMember = "evalua_areas"
        Me.Evalua_areasBindingSource.DataSource = Me.DataSetAcademia
        '
        'DataSetAcademia
        '
        Me.DataSetAcademia.DataSetName = "DataSetAcademia"
        Me.DataSetAcademia.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Eliminar"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Evalua_areasBindingNavigatorSaveItem
        '
        Me.Evalua_areasBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Evalua_areasBindingNavigatorSaveItem.Image = CType(resources.GetObject("Evalua_areasBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.Evalua_areasBindingNavigatorSaveItem.Name = "Evalua_areasBindingNavigatorSaveItem"
        Me.Evalua_areasBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.Evalua_areasBindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'dgvData
        '
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.AutoGenerateColumns = False
        Me.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.area, Me.empresa, Me.nombre})
        Me.dgvData.DataSource = Me.Evalua_areasBindingSource
        Me.dgvData.Location = New System.Drawing.Point(0, 93)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(1134, 498)
        Me.dgvData.TabIndex = 1
        '
        'area
        '
        Me.area.DataPropertyName = "area"
        Me.area.FillWeight = 20.0!
        Me.area.HeaderText = "Área"
        Me.area.MaxInputLength = 4
        Me.area.Name = "area"
        '
        'empresa
        '
        Me.empresa.DataPropertyName = "empresa"
        Me.empresa.HeaderText = "empresa"
        Me.empresa.Name = "empresa"
        Me.empresa.Visible = False
        '
        'nombre
        '
        Me.nombre.DataPropertyName = "nombre"
        Me.nombre.FillWeight = 80.0!
        Me.nombre.HeaderText = "nombre"
        Me.nombre.MaxInputLength = 100
        Me.nombre.Name = "nombre"
        '
        'Evalua_areasTableAdapter
        '
        Me.Evalua_areasTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.evalua_areasTableAdapter = Me.Evalua_areasTableAdapter
        Me.TableAdapterManager.evalua_rasgosTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = NOMINA.DataSetAcademiaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'frmEvaluaAreas2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 591)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.Evalua_areasBindingNavigator)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEvaluaAreas2"
        Me.Text = "Mantenimiento de áreas de evaluación"
        CType(Me.Evalua_areasBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Evalua_areasBindingNavigator.ResumeLayout(False)
        Me.Evalua_areasBindingNavigator.PerformLayout()
        CType(Me.Evalua_areasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetAcademia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataSetAcademia As DataSetAcademia
    Friend WithEvents Evalua_areasBindingSource As BindingSource
    Friend WithEvents Evalua_areasTableAdapter As DataSetAcademiaTableAdapters.evalua_areasTableAdapter
    Friend WithEvents TableAdapterManager As DataSetAcademiaTableAdapters.TableAdapterManager
    Friend WithEvents Evalua_areasBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents Evalua_areasBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents area As DataGridViewTextBoxColumn
    Friend WithEvents empresa As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
End Class
