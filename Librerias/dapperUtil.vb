Imports System.Data.SqlClient
Imports Dapper

Module dapperUtil

    Public Function GetParametros(ByVal diccionario As Dictionary(Of String, Object)) As DynamicParameters
        Dim parametros As New DynamicParameters()
        For Each ele As KeyValuePair(Of String, Object) In diccionario
            parametros.Add(ele.Key, ele.Value)
        Next
        Return parametros
    End Function


End Module
