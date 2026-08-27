Public Class NominasController


    Dim cadena As String = ""
    Dim dpara As New Dictionary(Of String, Object)

    Sub New()

    End Sub



    Public Function GetNominas(ByVal empresa As Int16, tiponom As String, mes As Int16, año As Int16) As DataTable
        dpara.Clear()
        dpara("empresa") = empresa
        dpara("tiponom") = tiponom
        dpara("mes") = mes
        dpara("año") = año
        Dim tbData As New DataTable()
        cadena = "select a.id_nomina, a.empresa, a.tiponom, a.mes, a.año, a.empleado, a.contrato, a.fechai, a.fechaf, a.transac, a.cantidad, a.valor, b.tipomov  
                from nominas a 
                inner join tipotran b on a.empresa=b.empresa and a.transac=b.transac 
                where a.empresa=@empresa and a.tiponom=@tiponom and a.mes=@mes and a.año=@año"
        llenaTabla(cadena, tbData, ListaParametros(dpara))
        Return tbData

    End Function


    Public Function UpdateValorNominas(ByVal empresa As Int16, tiponom As String, mes As Int16, año As Int16, transac As Short,
                                       empleado As Int32, contrato As Int32,
                                       valor As Decimal, cantidad As Decimal, fechai As DateTime, fechaf As DateTime) As Boolean
        dpara.Clear()
        dpara("empresa") = empresa
        dpara("tiponom") = tiponom
        dpara("mes") = mes
        dpara("año") = año
        dpara("empleado") = empleado
        dpara("contrato") = contrato
        dpara("transac") = transac
        dpara("valor") = valor
        dpara("cantidad") = cantidad
        Dim result As Boolean = True
        cadena = "select count(*) from nominas a where empleado=@empleado and contrato=@contrato and empresa=@empresa and 
                 tiponom=@tiponom and mes=@mes and año=@año and transac=@transac"

        Dim existe As Int16 = BuscaEscalar(cadena, ListaParametros(dpara))
        If existe > 0 Then
            cadena = "update a set a.valor=@valor, a.cantidad=@cantidad  
                from nominas a where empleado=@empleado and contrato=@contrato and empresa=@empresa and tiponom=@tiponom and mes=@mes and año=@año and a.transac=@transac"
            result = result And modelo.EjecutarQuery(cadena, ListaParametros(dpara))
        Else
            dpara("fechai") = fechai
            dpara("fechaf") = fechaf
            cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor) values " +
                    "(@empresa, @tiponom, @mes,@año,@empleado, @contrato, @fechai, @fechaf, @transac, @cantidad, @valor)"
            result = result And modelo.EjecutarQuery(cadena, ListaParametros(dpara))
        End If

        Return result

    End Function


    Public Function DeleteNominas(ByVal empresa As Int16, tiponom As String, mes As Int16, año As Int16, transac As String,
                                  empleado As Int32, contrato As Int32,
                                  valor As Decimal, cantidad As Decimal) As Boolean
        dpara.Clear()
        dpara("empresa") = empresa
        dpara("tiponom") = tiponom
        dpara("mes") = mes
        dpara("año") = año
        dpara("empleado") = empleado
        dpara("contrato") = contrato
        dpara("transac") = transac
        dpara("valor") = valor
        dpara("cantidad") = cantidad

        cadena = "delete 
                from nominas  where empleado=@empleado and contrato=@contrato and empresa=@empresa and tiponom=@tiponom and mes=@mes and año=@año and transac=@transac"
        Return modelo.EjecutarQuery(cadena, ListaParametros(dpara))

    End Function

    Public Function GetUltimoAño(ByVal empresa As Int16, empleado As Int32, contrato As Int16) As Int16
        dpara.Clear()
        dpara("empresa") = empresa

        dpara("empleado") = empleado
        dpara("contrato") = contrato
        Dim año As Int16 = 0
        cadena = "select isnull(max(a.año),0) as año  
                 from nominas a where empresa=@empresa  and empleado=@empleado and contrato=@contrato"
        año = BuscaEscalar(cadena, ListaParametros(dpara))
        Return año

    End Function

    Public Function GetUltimoMes(ByVal empresa As Int16, empleado As Int32, contrato As Int16, año As Int16) As Int16
        dpara.Clear()
        dpara("empresa") = empresa

        dpara("empleado") = empleado
        dpara("contrato") = contrato
        dpara("año") = año
        Dim mes As Int16 = 0
        cadena = "select isnull(max(a.mes),0) as mes  
                 from nominas a where empresa=@empresa  and empleado=@empleado and contrato=@contrato and año=@año"
        mes = BuscaEscalar(cadena, ListaParametros(dpara))
        Return mes

    End Function

    Public Function GetExistePagoNomina(ByVal empresa As Int16, tiponom As String, empleado As Int32, contrato As Int16, mes As Int32, año As Int32) As Boolean
        dpara.Clear()
        dpara("empresa") = empresa

        dpara("empleado") = empleado
        dpara("contrato") = contrato
        dpara("año") = año
        dpara("mes") = mes
        dpara("tiponom") = tiponom
        Dim valor As Int32 = 0
        cadena = "select count(*)
                 from pagosnom a where estado <> 1 and a.tiponom=@tiponom and empresa=@empresa  and empleado=@empleado and contrato=@contrato and año=@año and a.mes=@mes"
        valor += BuscaEscalar(cadena, ListaParametros(dpara))
        cadena = "select count(*)
                 from extra1 a where estado <> 1 and a.tiponom=@tiponom and empresa=@empresa  and empleado=@empleado and contrato=@contrato and año=@año and a.mes=@mes"
        valor += BuscaEscalar(cadena, ListaParametros(dpara))
        Return If(valor > 0, True, False)

    End Function



End Class
