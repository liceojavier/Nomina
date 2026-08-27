Public Class prestamosRepositorio

    Dim cadena As String
    Dim cm As cmodelo
    Dim dic As New Dictionary(Of String, Object)

    Public Sub New(ByVal cm As cmodelo)
        Me.cm = cm
    End Sub



    Public Function eliminacion_prestamo(ByVal empresa As Int16, ByVal tiponom As String, ByVal mes As Int16, ByVal año As Int16, ByVal empleado As Int32, contrato As Int16) As Boolean
        Dim tbPrestamo As New DataTable
        Dim filatemp As DataRow
        If cm IsNot Nothing Then

            Try
                dic.Clear()

                dic("tiponom") = tiponom
                dic("mes") = mes
                dic("año") = año
                dic("empresa") = empresa
                dic("empleado") = empleado
                dic("contrato") = contrato
                cadena = "select p1.prestamo, abonos from prestamos2 p2 " &
                             "inner join prestamos1 p1 on p1.empresa=p2.empresa and p1.prestamo=p2.prestamo " &
                             "where p1.empresa=@empresa " &
                             " and p2.tiponom=@tiponom And p2.mes =@mes and p2.año=@año And empleado = @empleado And contrato = @contrato "
                cm.llenaTabla(cadena, tbPrestamo, ListaParametros(dic))
                For i As Int16 = 0 To tbPrestamo.Rows.Count - 1
                    filatemp = tbPrestamo.Rows(i)
                    dic("saldo") = filatemp("abonos")
                    dic("prestamo") = filatemp("prestamo")
                    cadena = "update prestamos1 Set saldo= saldo + @saldo " &
                    " where empresa=@empresa And prestamo=@prestamo And empleado=@empleado  And contrato=@contrato"
                    cm.EjecutarNonQuery(cadena, ListaParametros(dic))
                    cadena = "delete prestamos2 where empresa=@empresa 
                        and tiponom=@tiponom And mes =@mes and año=@año and prestamo=@prestamo "
                    cm.EjecutarNonQuery(cadena, ListaParametros(dic))
                Next i
                Return True
            Catch ex As Exception
                cm.RollBack()
                Return False
            End Try
        End If
    End Function


    Public Function modificacion_prestamo(ByVal empresa As Int16, ByVal tiponom As String, ByVal mes As Int16, ByVal año As Int16, ByVal empleado As Int32, contrato As Int16, abono As Decimal, transac As String) As Boolean
        Dim tbPrestamo As New DataTable
        Dim filatemp As DataRow
        If cm IsNot Nothing Then

            Try
                dic.Clear()
                dic("tipodocto") = "N" + tiponom
                dic("docto") = CInt(mes.ToString() + año.ToString())
                dic("empresa") = empresa
                dic("empleado") = empleado
                dic("contrato") = contrato
                dic("transac") = transac
                dic("abono_nuevo") = abono
                cadena = "select p1.prestamo, p2.abonos from prestamos2 p2 " &
                             "inner join prestamos1 p1 on p1.empresa=p2.empresa and p1.prestamo=p2.prestamo " &
                             "inner join tiposprestamo tp on tp.empresa=p1empresa and tp.tipopre=p1.tipopre " &
                             "where p1.empresa=@empresa " &
                             " and p2.tipodocto=@tipodocto And p2.docto=@docto  And p1.empleado = @empleado And p1.contrato = @contrato 
                               and tp.transac=@transac  "
                modelo.llenaTabla(cadena, tbPrestamo, ListaParametros(dic))
                For i As Int16 = 0 To tbPrestamo.Rows.Count - 1
                    filatemp = tbPrestamo.Rows(i)
                    dic("saldo") = filatemp("abonos")
                    dic("prestamo") = filatemp("prestamo")
                    cadena = "update prestamos1 Set saldo= saldo + (@saldo-@abono_nuevo)" &
                    " where empresa=@empresa And prestamo=@prestamo And empleado=@empleado  And contrato=@contrato"
                    cm.EjecutarNonQuery(cadena, ListaParametros(dic))
                    cadena = "update a set abonos=@abono_nuevo prestamos2 a where empresa=@empresa 
                        And tipodocto=@tipodocto and docto=@docto and prestamo=@prestamo "
                    cm.EjecutarNonQuery(cadena, ListaParametros(dic))
                Next i
                Return True
            Catch ex As Exception
                cm.RollBack()
                Return False
            End Try
        End If
    End Function

    Public Function get_transacciones_prestamo(empresa As Int16) As List(Of String)
        Dim lista As New List(Of String)
        If cm IsNot Nothing Then
            Dim tbData As New DataTable
            dic.Clear()
            dic("empresa") = empresa
            Try
                cadena = "select transac from tiposprestamo where empresa=@empresa order by transac"
                cm.llenaTabla(cadena, tbData, ListaParametros(dic))
                For Each fila As DataRow In tbData.Rows
                    lista.Add(fila("transac").ToString())
                Next
            Catch ex As Exception
                cm.RollBack()
            End Try
        End If
        Return lista
    End Function


End Class
