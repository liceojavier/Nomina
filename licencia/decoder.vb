Imports System.IO
Module decoder


    Structure encabezado
        Dim size As Int32
        Dim sig As Int32
        Dim ant As Int32
        Dim inicio As Int32
        Dim inicior As Int32

    End Structure

    Structure nodo
        Dim sig, ant As Int32
        Dim cont As Char
    End Structure

    Public Function ejecutar(ByVal numero As String, ByVal nomArch As String) As Boolean
        Dim objBR As BinaryReader
        Dim objFS As FileStream
        Dim objEncabezado As New encabezado
        Dim objnodo As New nodo
        Dim serial As String
        Dim i As Integer
        Dim size As Integer
        Dim caracter As Char
        Dim codigo As Integer
        size = 11 ' size of serial
        serial = ""

        Try
            objFS = New FileStream(nomArch, FileMode.Open, FileAccess.Read)
            objBR = New BinaryReader(objFS)
            objBR.BaseStream.Seek(1, SeekOrigin.Begin)
            i = 1
            objEncabezado = Nothing
            With objEncabezado
                .size = objBR.ReadInt32
            End With
            size = objEncabezado.size
            objBR.BaseStream.Seek(1, SeekOrigin.Begin)

            While i <= size 'objFS.Length
                objEncabezado = Nothing
                With objEncabezado
                    .size = objBR.ReadInt32
                    .sig = objBR.ReadInt32
                    .ant = objBR.ReadInt32
                    .inicio = objBR.ReadInt32
                    .inicior = objBR.ReadInt32
                End With
                'ShowRecord(objEncabezado)
                objBR.BaseStream.Seek(objEncabezado.inicio + 21, SeekOrigin.Begin)
                With objnodo
                    .sig = objBR.ReadInt32
                    .ant = objBR.ReadInt32
                    .cont = objBR.ReadChar
                End With
                codigo = Asc(objnodo.cont) + 30
                caracter = Chr(codigo)
                serial = serial & caracter
                objFS.Position = objEncabezado.sig
                i = i + 1
            End While
            If serial.Trim = numero.Trim Then
                Return True
            Else
                MsgBox("LICENCIA INVÁLIDA, EL SOFTWARE NO ES ORIGINAL.")
                Return False
            End If
            objBR.Close()
            objFS.Close()

        Catch ex As Exception
            MsgBox("ERROR DE SINCRONIZACIÓN PUEDE SER QUE SU SOFTWARE NO SEA ORIGINAL.", MsgBoxStyle.Information, "Mensaje del Sistema")
            Return False
        End Try
        Return True
    End Function
    Private Sub ShowRecord(ByVal objRecord As encabezado)
        Console.WriteLine(objRecord.size.ToString)
        Console.WriteLine(objRecord.sig.ToString)
        Console.WriteLine(objRecord.ant.ToString)
        Console.WriteLine(objRecord.inicio.ToString)
        Console.WriteLine(objRecord.inicior.ToString)
    End Sub
    Public Function decodificar(ByVal nomArch As String) As Boolean
        Dim cadena As String = ""
        Dim SerialNumber() As Byte
        Dim numeroserial As String = ""

        Try
            cadena = "SELECT  HASHBYTES ('MD5','XD_J09IJ/4DF6TR8' + CONVERT (VARCHAR,SERVERPROPERTY('MachineName')) + CONVERT(VARCHAR ,SERVERPROPERTY('EditionID')) " & _
                 " + CONVERT( VARCHAR,cpu_count) + CONVERT(VARCHAR,hyperthread_ratio) + CONVERT( VARCHAR,cpu_count) + CONVERT(VARCHAR, cpu_ticks_in_ms) + " & _
                 " CONVERT (VARCHAR, SERVERPROPERTY('EditionID')) ) as llave from sys.dm_os_sys_info "
            SerialNumber = BuscaEscalar(cadena)
            For Each ByteUnico As Byte In SerialNumber
                numeroserial = numeroserial & Hex(ByteUnico)
            Next

            If decoder.ejecutar(numeroserial, nomArch) = False Then
                Return False
                'frmLogin.Close()
                'Exit Function
            Else : Return True

            End If
        Catch ex As Exception
            'El server debe tener instalado el módulo de comandos WMI de microsoft
            MsgBox("ERROR AL COMPROBAR LICENCIA. CONSULTE AL ADMINISTRADOR DEL SISTEMA.", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Exit Function
        End Try


    End Function


End Module
