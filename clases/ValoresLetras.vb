Imports Microsoft.VisualBasic
Imports System.Text.RegularExpressions

Public Class ValoresLetras
    Dim numeroR, mostrar, seguir, ArreDeci, arreDeci2 As String
    Dim exp As Regex
    Dim matches As Match
    Dim cadenaChar() As Char
   
    

    Public Function Inicializacion(ByVal valor As String) As String
        Dim sigue, temp As String
        Dim i, Actual As Int16
        numeroR = valor
        exp = New Regex("^([1-9]{1}\d{0,8}|0)(\.(\d{0,2}))?$")
        matches = exp.Match(numeroR)
        mostrar = matches.Groups(1).Value()
        ReDim cadenaChar(mostrar.Length())
        cadenaChar = mostrar.ToCharArray()
        sigue = ""
        For i = 0 To mostrar.Length - 1
            Actual = mostrar.Length - i
            temp = ""
            If cadenaChar(i) <> "0" Then
                Select Case Actual
                    Case 8
                        temp = decenas(cadenaChar(i), cadenaChar(i + 1), False)
                        If cadenaChar(i) <> "1" And cadenaChar(i) <> "2" Then
                            If cadenaChar(i + 1) <> "0" Then
                                sigue = temp & " y"
                            Else
                                sigue = temp
                            End If
                        Else
                            sigue = temp
                        End If
                    Case 7
                        If mostrar.Length = 8 Then
                            If cadenaChar(i - 1) <> "1" And cadenaChar(i - 1) <> "2" Then
                                temp = unidad(cadenaChar(i), Actual)
                            End If
                        Else
                            temp = unidad(cadenaChar(i), Actual)
                        End If
                        sigue = sigue & " " & temp
                    Case 6
                        If cadenaChar(i + 1) = "0" And cadenaChar(i + 2) = "0" Then
                            temp = centenas(cadenaChar(i), False)
                        Else
                            temp = centenas(cadenaChar(i), True)
                        End If
                        sigue = sigue & " " & temp
                    Case 5
                        temp = decenas(cadenaChar(i), cadenaChar(i + 1), False)
                        If cadenaChar(i) <> "1" And cadenaChar(i) <> "2" Then
                            If cadenaChar(i + 1) <> "0" Then
                                sigue = sigue & " " & temp & " y"
                            Else
                                sigue = sigue & " " & temp
                            End If
                        Else
                            sigue = sigue & " " & temp
                        End If
                    Case 4
                        If mostrar.Length > 4 Then
                            If cadenaChar(i - 1) <> "1" And cadenaChar(i - 1) <> "2" Then
                                temp = unidad(cadenaChar(i), Actual)
                            End If
                        Else
                            temp = unidad(cadenaChar(i), Actual)
                        End If
                        sigue = sigue & " " & temp
                    Case 3
                        If cadenaChar(i + 1) = "0" And cadenaChar(i + 2) = "0" Then
                            temp = centenas(cadenaChar(i), False)
                        Else
                            temp = centenas(cadenaChar(i), True)
                        End If
                        sigue = sigue & " " & temp
                    Case 2
                        temp = decenas(cadenaChar(i), cadenaChar(i + 1), True)
                        If cadenaChar(i) <> "1" And cadenaChar(i) <> "2" Then
                            If cadenaChar(i + 1) <> "0" Then
                                sigue = sigue & " " & temp & " y"
                            Else
                                sigue = sigue & " " & temp
                            End If
                        Else
                            sigue = sigue & " " & temp
                        End If
                    Case 1
                        If mostrar.Length > 1 Then
                            If cadenaChar(i - 1) <> "1" And cadenaChar(i - 1) <> "2" Then
                                temp = unidad(cadenaChar(i), Actual)
                            End If
                        Else
                            temp = unidad(cadenaChar(i), Actual)
                        End If
                        sigue = sigue & " " & temp
                End Select
            End If
            If Actual = 7 Then
                Select Case mostrar.Length
                    Case 8
                        sigue = sigue & " millones"
                    Case 7
                        If cadenaChar(0) = "1" Then
                            sigue = sigue & " millon"
                        Else
                            sigue = sigue & " millones"
                        End If
                End Select
            End If
            If Actual = 4 Then
                Select Case mostrar.Length
                    Case 8
                        If cadenaChar(2) = "0" And cadenaChar(3) = "0" And cadenaChar(4) = "0" Then
                        Else
                            sigue = sigue & " mil"
                        End If
                    Case 7
                        If cadenaChar(1) = "0" And cadenaChar(2) = "0" And cadenaChar(3) = "0" Then
                        Else
                            sigue = sigue & " mil"
                        End If
                    Case 6
                        If cadenaChar(0) = "0" And cadenaChar(1) = "0" And cadenaChar(2) = "0" Then
                        Else
                            sigue = sigue & " mil"
                        End If
                    Case 5
                        If cadenaChar(0) = "0" And cadenaChar(1) = "0" Then
                        Else
                            sigue = sigue & " mil"
                        End If
                    Case 4
                        If cadenaChar(0) = "0" Then
                        Else
                            sigue = sigue & " mil"
                        End If
                End Select
            End If
        Next i
        ArreDeci = matches.Groups(2).Value()
        If (ArreDeci.Length > 1) Then
            arreDeci2 = matches.Groups(3).Value
            If CDec(arreDeci2) <> 0 Then
                If arreDeci2.Length = 1 Then
                    sigue = sigue & " con " & arreDeci2 & "0/100"
                Else
                    sigue = sigue & " con " & arreDeci2 & "/100"
                End If
            Else
                sigue = sigue & " exactos "
            End If

        Else
            If sigue.Length > 0 Then
                sigue = sigue & " exactos "
            End If
        End If
        Return sigue
    End Function

    Private Function unidad(ByVal num As Char, ByVal Posicion As Int16) As String
        Select Case num
            Case "1"
                If Posicion = 1 Then
                    Return "uno"
                Else
                    Return "un"
                End If
            Case "2"
                Return "dos"
            Case "3"
                Return "tres"
            Case "4"
                Return "cuatro"
            Case "5"
                Return "cinco"
            Case "6"
                Return "seis"
            Case "7"
                Return "siete"
            Case "8"
                Return "ocho"
            Case "9"
                Return "nueve"
        End Select
    End Function

    Private Function decenas(ByVal num As Char, ByVal num1 As Char, ByVal valorB As Boolean) As String
        Select Case num
            Case "1"
                Select Case num1
                    Case "0"
                        Return "diez"
                    Case "1"
                        Return "once"
                    Case "2"
                        Return "doce"
                    Case "3"
                        Return "trece"
                    Case "4"
                        Return "catorce"
                    Case "5"
                        Return "quince"
                    Case "6"
                        Return "dieciseis"
                    Case "7"
                        Return "diecisiete"
                    Case "8"
                        Return "dieciocho"
                    Case "9"
                        Return "diecinueve"
                End Select
            Case "2"
                Select Case num1
                    Case "0"
                        Return "veinte"
                    Case "1"
                        If valorB Then
                            Return "veintiuno"
                        Else
                            Return "veintiun"
                        End If
                    Case "2"
                        Return "veintidos"
                    Case "3"
                        Return "veintitres"
                    Case "4"
                        Return "veinticuatro"
                    Case "5"
                        Return "veinticinco"
                    Case "6"
                        Return "veintiseis"
                    Case "7"
                        Return "veintisiete"
                    Case "8"
                        Return "veintiocho"
                    Case "9"
                        Return "veintinueve"
                End Select
            Case "3"
                Return "treinta"
            Case "4"
                Return "cuarenta"
            Case "5"
                Return "cincuenta"
            Case "6"
                Return "sesenta"
            Case "7"
                Return "setenta"
            Case "8"
                Return "ochenta"
            Case "9"
                Return "noventa"
        End Select
    End Function

    Private Function centenas(ByVal num As Char, ByVal valorB As Boolean) As String
        Select Case num
            Case "1"
                If valorB = True Then
                    Return "ciento"
                Else
                    Return "cien"
                End If
            Case "2"
                Return "doscientos"
            Case "3"
                Return "trescientos"
            Case "4"
                Return "cuatrocientos"
            Case "5"
                Return "quinientos"
            Case "6"
                Return "seiscientos"
            Case "7"
                Return "setecientos"
            Case "8"
                Return "ochocientos"
            Case "9"
                Return "novecientos"
        End Select
    End Function





End Class
