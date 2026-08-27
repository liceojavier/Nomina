Imports ControlesERP

Public Class BusquedaTransacControl

    Public Property id_empresa As Int16 = 0

    Public Property transac As Int32 = 0

    Public Property Forma_Calculo As String = 0

    Public Property Tipo_Valor As String = 0

    Public Property Nombre As String = ""

    '   Public cd As capa_datos

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        '   cd = New capa_datos(Singleton2.Instance.conexion)
    End Sub




    Dim cadena As String = ""
    Dim lpara As New Dictionary(Of String, Object)




    Public Sub BorraCodigo()

        NameTxt.Clear()
        CodTxt.Clear()
        transac = 0
        Nombre = ""
        Forma_Calculo = ""
        Tipo_Valor = ""
        RaiseEvent Cambio_valor(transac, Nombre)
    End Sub


    Private Sub btnCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click
        Dim numFilas As Int32
        Dim tbCodigo As New DataTable
        lpara("empresa") = id_empresa
        lpara("nombre") = NameTxt.Text
        cadena = "select transac, nombre, case when tipomov='I' then 'INGRESO' else 'DESCUENTO' END as nombTipomov," &
                 " formacal,  tipovalor from tipotran where empresa=@empresa and nombre like '%' + @nombre + '%'  order by transac"
        numFilas = llenaTabla(cadena, tbCodigo, ListaParametros(lpara))
        If numFilas = 0 Then
            BorraCodigo()
            MsgBox("No existen transacciones con este criterio de búsqueda", MsgBoxStyle.Information, "Mensaje del Sistema")

        ElseIf numFilas = 1 Then

            ActualizacionDatos(tbCodigo.Rows.Item(0))

        Else
            EnBuscaCodigo(tbCodigo)
        End If
    End Sub

    Private Sub ValidaCodigo()
        Dim cod As Int32 = 0
        lpara.Clear()
        Dim tbCodigo As New DataTable
        If Int32.TryParse(CodTxt.Text, cod) = True Then
            lpara("empresa") = id_empresa
            lpara("transac") = cod
            If BuscaEscalar("select count (*) from tipotran where empresa=@empresa and transac=@transac", ListaParametros(lpara)) = 0 Then
                MsgBox("TRANSACCION NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraCodigo()
                CodTxt.Focus()
                Exit Sub
            End If
            cadena = "select transac, nombre, case when tipomov='I' then 'INGRESO' else 'DESCUENTO' END as nombTipomov," &
                  " formacal, tipovalor from tipotran where empresa=@empresa " &
                 " and transac=@transac order by transac"
            llenaTabla(cadena, tbCodigo, ListaParametros(lpara))
            If tbCodigo.Rows.Count > 0 Then
                ActualizacionDatos(tbCodigo.Rows(0))
            End If
        Else
            MsgBox("TRANSACCION POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraCodigo()
            CodTxt.Focus()
        End If
    End Sub

    Private Sub TextCodigo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CodTxt.Validated
        If CodTxt.Text.Trim <> "" Then
            ValidaCodigo()
        Else
            BorraCodigo()
        End If
    End Sub

    Private Sub EnBuscaCodigo(ByVal tbData As DataTable)
        Dim fEmp As New FormMuestraCodigo
        fEmp.TopMost = True
        fEmp.inicializa(tbData)
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        If (fEmp.fila IsNot Nothing) Then
            ActualizacionDatos(fEmp.fila)
        End If
    End Sub

    Private Sub ActualizacionDatos(ByVal filaTemp As DataRow)

        Me.transac = filaTemp("transac")
        Me.Nombre = filaTemp("nombre")
        CodTxt.Text() = filaTemp.Item("transac")
        NameTxt.Text = filaTemp.Item("nombre")
        Forma_Calculo = filaTemp.Item("formacal")
        Tipo_Valor = filaTemp.Item("tipovalor")
        RaiseEvent Cambio_valor(transac, Nombre)
    End Sub


    Event Cambio_valor(transac As Int32, nombre As String)

End Class
