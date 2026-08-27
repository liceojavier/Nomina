<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class prueba
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Reporte = New System.Windows.Forms.Button()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ControlBusquedaEmpleado1 = New BusquedaEmpleadoControl()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(33, 51)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Reporte
        '
        Me.Reporte.Location = New System.Drawing.Point(33, 93)
        Me.Reporte.Name = "Reporte"
        Me.Reporte.Size = New System.Drawing.Size(75, 23)
        Me.Reporte.TabIndex = 3
        Me.Reporte.Text = "btnReporte"
        Me.Reporte.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 122)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(604, 150)
        Me.CrystalReportViewer1.TabIndex = 4
        '
        'ControlBusquedaEmpleado1
        '
        Me.ControlBusquedaEmpleado1.activo = False
        Me.ControlBusquedaEmpleado1.Contrato = 0
        Me.ControlBusquedaEmpleado1.Empleado = 0
        Me.ControlBusquedaEmpleado1.id_empresa = CType(0, Short)
        Me.ControlBusquedaEmpleado1.Location = New System.Drawing.Point(161, 51)
        Me.ControlBusquedaEmpleado1.Name = "ControlBusquedaEmpleado1"
        Me.ControlBusquedaEmpleado1.Nombre = ""
        Me.ControlBusquedaEmpleado1.Size = New System.Drawing.Size(387, 23)
        Me.ControlBusquedaEmpleado1.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(33, 336)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "btnTest"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'prueba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 460)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ControlBusquedaEmpleado1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Reporte)
        Me.Controls.Add(Me.Button1)
        Me.Name = "prueba"
        Me.Text = "prueba"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Reporte As Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ControlBusquedaEmpleado1 As BusquedaEmpleadoControl
    Friend WithEvents Button2 As Button
End Class
