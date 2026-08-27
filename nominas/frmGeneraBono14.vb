Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMGENERABONO14.VB MIEMBRO DE NOMINA.SLN                                    **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmGeneraBono14
    Inherits Form
    Dim cadena As String
    Dim tbContra1 As New DataTable("contra1")
    Dim tbTransac As New DataTable("transac")
    Dim tbTipo As New DataTable("tipo")
    Dim tbMovi As New DataTable("movi")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim fTemp As DataRow
    Dim filaTemp As DataRow
    Dim movimientos, desprestamos As String
    Dim lpara As New Dictionary(Of String, Object)


    Dim tt As New DataTable("datos")



#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents gpFecha As System.Windows.Forms.GroupBox
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents TextAño As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextMoneEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents PgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneraBono14))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextMoneEmpresa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.PgBar = New System.Windows.Forms.ProgressBar()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gpFecha.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpFecha
        '
        Me.gpFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.gpFecha.Controls.Add(Me.Label2)
        Me.gpFecha.Controls.Add(Me.Label3)
        Me.gpFecha.Controls.Add(Me.cmbTipo)
        Me.gpFecha.Controls.Add(Me.TextAño)
        Me.gpFecha.Controls.Add(Me.btnEjecutar)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.Location = New System.Drawing.Point(0, 55)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(558, 73)
        Me.gpFecha.TabIndex = 1
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Tipo y periodo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipo de nómina:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(317, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Año:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(95, 30)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(208, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(355, 30)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(56, 20)
        Me.TextAño.TabIndex = 3
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "actualizar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(417, 23)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(80, 30)
        Me.btnEjecutar.TabIndex = 4
        Me.btnEjecutar.Text = "Generar"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEjecutar, "Generar el proceso")
        Me.btnEjecutar.UseVisualStyleBackColor = False
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
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextMoneEmpresa)
        Me.gpEmpresa.Controls.Add(Me.Label10)
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(81, 6)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(456, 43)
        Me.gpEmpresa.TabIndex = 56
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
        Me.Label10.Location = New System.Drawing.Point(346, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
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
        'PgBar
        '
        Me.PgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PgBar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PgBar.Location = New System.Drawing.Point(6, 5)
        Me.PgBar.Name = "PgBar"
        Me.PgBar.Size = New System.Drawing.Size(606, 23)
        Me.PgBar.TabIndex = 70
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(619, 54)
        Me.Panel1.TabIndex = 72
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PgBar)
        Me.Panel2.Location = New System.Drawing.Point(0, 154)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(619, 37)
        Me.Panel2.TabIndex = 73
        '
        'frmGeneraBono14
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(619, 191)
        Me.Controls.Add(Me.gpEmpresa)
        Me.Controls.Add(Me.gpFecha)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmGeneraBono14"
        Me.Text = "Generación de la Nómina de Bono 14"
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextAño.Text = System.DateTime.Now.Year
        lpara.Clear()
        lpara("empresa") = empresa
        EscribeEmpresa(TextNombEmpresa, TextMoneEmpresa)
        cadena = "select nombre, tiponom, cantidad, por, movimientos, desprestamos from tiponomina1 where empresa=@empresa and ( tiponom='C' or tiponom='B')"
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        cmbTipo.SelectedIndex = 0
        PgBar.Minimum = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim año, mes, mesf, tranCal, tranGra, mesesCalc As Int16
        Dim i, j, CantDias As Int32
        Dim valorNom, por, cantidadI, valorT As Decimal
        Dim FechaInom, fechaFnom, fechaI As Date
        Dim tbPrestamo As New DataTable("prestamos")
        Dim tbMovimientos As New DataTable("movimientos")

        Dim tipoNom As String
        Dim ftemp2 As DataRow
        If Not validetError(cmbTipo, ep1) Or Not validetError(TextAño, ep1) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
        cantidadI = tbTipo.Rows(cmbTipo.SelectedIndex).Item(2)
        por = tbTipo.Rows(cmbTipo.SelectedIndex).Item(3)
        movimientos = tbTipo.Rows(cmbTipo.SelectedIndex).Item(4)
        desprestamos = tbTipo.Rows(cmbTipo.SelectedIndex).Item(5)
        año = CInt(TextAño.Text)
        FechaInom = "01/7/" & año - 1
        fechaFnom = "30/06/" & año
        mes = 7
        mesf = 6


        lpara("empresa") = empresa
        lpara("tiponom") = tipoNom
        lpara("mes") = mes
        lpara("año") = año
        lpara("estado") = 0

        cadena = "select count(*) from nomina_registro where estado=0 and empresa=@empresa and tiponom=@tiponom and mes=@mes and año=@año"
        Dim existeNom As Int32 = BuscaEscalar(cadena, ListaParametros(lpara))
        If existeNom > 0 Then
            MsgBox("Nómina ya ha generado pagos, no se puede generar, contacte a su administrador", MsgBoxStyle.Exclamation, "Nominas")
            Exit Sub
        End If
        If MsgBox("ESTA SEGURO QUE DESEA GENERAR ESTA NOMINA", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
            Exit Sub
        End If

        cadena = "select count (*) from nominas where empresa=@empresa and mes=" & 7 & " and año=@año and tiponom=@tiponom "
        If BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then

            If MsgBox("ESTA NOMINA YA HA SIDO GENERADA, DESEA CORRER DE NUEVO EL PROCESO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                Exit Sub
            Else
                lpara("tipodocto") = "N" & tipoNom.Trim
                lpara("docto") = CInt((mes.ToString() & año.ToString()))
                lpara("tiponom") = tipoNom
                lpara("mes") = mes
                lpara("año") = año

                cadena = "select prestamo, abonos from prestamos2 where empresa=@empresa and tiponom=@tiponom and mes=@mes and año=@año and abonos <> 0"
                llenaTabla(cadena, tbPrestamo, ListaParametros(lpara))
                cadena = "delete prestamos2 where empresa=@empresa and tiponom=@tiponom  and mes=@mes and año=@año"
                EjecutarQuery(cadena, ListaParametros(lpara))
                'Si desea borrarla se anulan los descuentos hechos en los prestamos y se regresa el saldo
                For i = 0 To tbPrestamo.Rows.Count - 1

                    filaTemp = tbPrestamo.Rows(i)

                    lpara("prestamo") = filaTemp.Item("prestamo")
                    lpara("abonos") = filaTemp.Item("abonos")
                    cadena = "update prestamos1 set saldo= (select sum(cargos-abonos) from prestamos2 where prestamo=@prestamo) where empresa=@empresa and prestamo=@prestamo "
                    EjecutarQuery(cadena, ListaParametros(lpara))
                Next i

            End If
        End If
        cadena = "delete from nominas where empresa=@empresa and mes=" & 7 & " and año=@año and tiponom=@tiponom "
        EjecutarQuery(cadena, ListaParametros(lpara))
        cadena = "select coalesce( max( transac),0) from tiponomina2 where empresa=@empresa And tipoNom =@tiponom "
        tranCal = BuscaEscalar(cadena, ListaParametros(lpara))
        cadena = "select transacnom  from tiponomina3 t3 where t3.empresa=@empresa And t3.tiponom =@tiponom "
        tranGra = BuscaEscalar(cadena, ListaParametros(lpara))
        If tranCal = 0 Or tranGra = 0 Then
                MsgBox("NO HAY TRANSACCION PARA ESTE TIPO DE NOMINA, VERIFIQUE", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If

        Dim cmod As New cmodelo
        Try



            lpara("año1") = año - 1
            lpara("mes") = mes
            lpara("año") = año
            lpara("mesf") = mesf
            lpara("tiponom") = tipoNom
            lpara("fechai") = FechaInom
            lpara("fechaf") = fechaFnom
            cadena = "select c1.contrato, c1.empleado,  c1.fechai, c1.tipoper, c1.tiposeguro, tip.tibase, c1.base , " &
                     "( select coalesce( sum( valor),0) from nominas nom where nom.empresa=c1.empresa and " &
                     "nom.empleado=c1.empleado and nom.contrato=c1.contrato " &
                     " and ( ( año=@año1 and mes >= @mes ) or (año=@año and mes <= @mesf  " &
                     ")) and transac in ( select transac from tiponomina2 t2 where t2.empresa=c1.empresa and t2.tiponom=@tiponom " &
                     ") ) as valorNomina, " &
                     "(select  coalesce( sum(valor),0) from extra1 e1 inner join extra2 e2 on " &
                     "e1.empresa = e2.empresa And e1.cheque = e2.cheque And e1.banco = e2.banco " &
                     "where e1.estado <> 1 and  e1.empresa=c1.empresa and fecha between @fechai "  &
                     " and @fechaf and empleado=c1.empleado and contrato=c1.contrato and " &
                     "transac in ( select transac from tiponomina2 t2 where " &
                     "t2.empresa=c1.empresa and t2.tiponom=@tiponom)) as valExtra, " &
                     "(select coalesce( sum(valor),0) from suspensiones su where estado =2 and " &
                     "empresa=c1.empresa and empleado=c1.empleado and contrato=c1.contrato " &
                     "and fechai>=@fechai and fechaf <=@fechaf) as valSuspensiones, tip.basevaca " &
                     "from contratos1 c1 " &
                     "inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "inner join tipopersonal tip on tip.empresa=c1.empresa and tip.tipoper=c1.tipoper " &
                     "where tip.pagonomina='S' and tip.prestaciones='S' and e.generapago='S' and c1.empresa=@empresa and c1.fechai < @fechaf" &
                     " order by c1.empleado"
            cmod.llenaTabla(cadena, tbContra1, ListaParametros(lpara))
            PgBar.Maximum = tbContra1.Rows.Count

            Dim empleado As Int32 = 0
            For i = 0 To tbContra1.Rows.Count - 1
                lpara.Clear()
                PgBar.PerformStep()

                filaTemp = tbContra1.Rows(i)
                empleado = filaTemp("empleado")
                If tipoNom <> "C" Then
                    valorT = filaTemp.Item("valorNomina") + filaTemp.Item("valExtra") + filaTemp.Item("valSuspensiones")
                Else
                    valorT = filaTemp.Item("valorNomina") + filaTemp.Item("valExtra")
                End If
                If valorT > 0 Then
                    fechaI = FechaInom
                    If filaTemp.Item("fechai") > fechaI Then
                        fechaI = filaTemp.Item("fechai")
                    End If
                    If tipoNom = "C" Then
                        If CDate(filaTemp.Item("fechai")).Year = año Then
                            mesesCalc = 12
                        Else
                            'mesesCalc = filaTemp.Item("basevaca")
                            mesesCalc = 12
                        End If
                    Else
                        mesesCalc = 12
                    End If



                    valorNom = (valorT / mesesCalc) * (por / 100)
                    CantDias = (360 * (fechaFnom.Year - fechaI.Year)) + (30 * (fechaFnom.Month - fechaI.Month)) + (fechaFnom.Day - fechaI.Day) + 1

                    lpara("empresa") = empresa
                    lpara("tiponom") = tipoNom
                    lpara("mes") = mes
                    lpara("año") = año
                    lpara("empleado") = filaTemp.Item("empleado")
                    lpara("contrato") = filaTemp.Item("contrato")
                    lpara("fechai") = fechaI
                    lpara("fechaf") = fechaFnom
                    lpara("transac") = tranGra
                    lpara("cantidad") = CantDias
                    lpara("valor") = valorNom
                    cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor ) 
                              values (@empresa,@tiponom,@mes,@año,@empleado,@contrato,@fechai,@fechaf,@transac,@cantidad,@valor)"
                    cmod.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    If movimientos = "S" Then
                        cadena = "select mov.transac, coalesce( sum( mov.valor),0) from movinomina mov inner join tipotran t on " &
                                 "mov.empresa = t.empresa And mov.transac = t.transac where mov.empresa=@empresa " &
                                 "and empleado=@empleado and contrato=@contrato " &
                                 "and t.tipomov='D' and mes=@mes and año=@año and mov.tiponom=@tiponom " &
                                 "group by mov.transac"
                        cmod.llenaTabla(cadena, tbMovimientos, ListaParametros(lpara))
                        For j = 0 To tbMovimientos.Rows.Count - 1
                            ftemp2 = tbMovimientos.Rows(j)
                            lpara("transac") = ftemp2.Item(0)
                            lpara("valor") = ftemp2.Item(1)
                            cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor ) 
                                      values (@empresa,@tiponom,@mes,@año,@empleado,@contrato,@fechai,@fechaf,@transac,0,@valor)"
                            cmod.EjecutarNonQuery(cadena, ListaParametros(lpara))
                        Next j
                    End If
                    If desprestamos = "S" Then

                        lpara("fechainom") = New DateTime(año, mes, 1)
                        cadena = "select p1.prestamo, p1.tipopre,  p1.descuento, tp.transac, sum(p2.cargos-p2.abonos) as saldo, p1.desc_bono14, p1.desc_aguinaldo  " &
                                 "from prestamos1  p1 , tiposprestamo tp, prestamos2 p2  " &
                                 "where p1.empresa=tp.empresa and p1.tipopre=tp.tipopre and p1.empresa=@empresa and contrato=@contrato and p1.empresa=p2.empresa and p1.prestamo=p2.prestamo " &
                                 " and empleado=@empleado and @fechainom >= cast( cast(p1.añoini as varchar)  + '-01' + '-' +cast(p1.mesini as varchar) as datetime)  and tp.transac not in " &
                                 " (select transac from movinomina where empresa=@empresa and empleado=@empleado " &
                                 "  and contrato=@contrato and tiponom=@tiponom and año=@año and mes=@mes) and p1.estado=0 group by  p1.prestamo, p1.tipopre,  p1.descuento, tp.transac, p1.desc_bono14, p1.desc_aguinaldo "
                        cmod.llenaTabla(cadena, tbMovi, ListaParametros(lpara))
                        For j = 0 To tbMovi.Rows.Count - 1

                            lpara("empresa") = empresa
                            lpara("tiponom") = tipoNom
                            lpara("mes") = mes
                            lpara("año") = año
                            lpara("empleado") = filaTemp.Item("empleado")
                            lpara("contrato") = filaTemp.Item("contrato")
                            lpara("fechai") = fechaI
                            lpara("fechaf") = fechaFnom
                            lpara("docto") = CInt(mes.ToString() & año.ToString())
                            ftemp2 = tbMovi.Rows(j)


                            lpara("prestamo") = ftemp2.Item("prestamo")
                            cadena = "select sum( cargos-abonos) from prestamos2 where prestamo=@prestamo and empresa=@empresa"
                            Dim valorSaldo = cmod.BuscaEscalar(cadena, ListaParametros(lpara))

                            If valorSaldo < ftemp2.Item("descuento") + ftemp2("desc_bono14") Then
                                valorNom = ftemp2.Item("saldo")
                            Else
                                valorNom = ftemp2.Item("descuento") + ftemp2("desc_bono14")
                            End If




                                lpara("transac") = ftemp2.Item("transac")
                            lpara("prestamo") = ftemp2.Item("prestamo")
                            lpara("valor") = valorNom
                            If (valorNom > 0) Then

                                cadena = "insert into prestamos2 (empresa,prestamo,fecha,tipodocto,docto,cargos,abonos,tiponom,mes,año) 
                                      values (@empresa,@prestamo,@fechaf,'NM',@docto,0.00,@valor,@tiponom,@mes,@año)"
                                cmod.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                Dim saldo As Decimal = valorSaldo - valorNom
                                lpara("saldo") = saldo
                                cadena = "update prestamos1 set saldo=@saldo where empresa=@empresa and prestamo=@prestamo "
                                cmod.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor ) 
                                          values (@empresa,@tiponom,@mes,@año,@empleado,@contrato,@fechai,@fechaf,@transac,0,@valor)"
                                cmod.EjecutarNonQuery(cadena, ListaParametros(lpara))

                            End If

                        Next j


                    End If
                End If
            Next i



            If cmod.Commit() Then
                InsertBitacora(9, 7, $"GENERACIÓN NOMINA {tipoNom} AÑO " & TextAño.Text & " " & cmbTipo.Text)
                MsgBox("OPERACION REALIZA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                PgBar.Value = 0
            End If
        Catch ex As Exception
            MsgBox("Error del Sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            cmod.RollBack()
            PgBar.Value = 0
        End Try
        'cn.Close()

    End Sub

    Private Sub cmbMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextAño.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextAño_TextChanged(sender As Object, e As EventArgs) Handles TextAño.TextChanged

    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub





End Class
