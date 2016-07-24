Imports System.Text.RegularExpressions

Module Ciphers
    Dim CapitalA = 65
    Dim CapitalZ = 90

    Function CaesarEncrypt(message As String, shift As Integer) As String
        message = UCase(message)
        Dim out(Len(message)) As Char
        Dim outIndex = 0
        For Each c As Char In message
            Dim ascVal = Asc(c)
            If ascVal >= CapitalA And ascVal <= CapitalZ Then
                Dim outValue = ((ascVal - CapitalA) + shift) Mod 26 + CapitalA
                If outValue < CapitalA Then
                    outValue += 26
                End If
                out(outIndex) = Chr(outValue)
                outIndex = outIndex + 1
            Else
                out(outIndex) = c
                outIndex = outIndex + 1
            End If

        Next
        Return out
    End Function

    Function VignereRound(message As String, shift As Integer, direction As Integer) As String
        message = UCase(message)
        Dim out(Len(message)) As Char
        Dim outIndex = 0
        For Each c As Char In message
            Dim ascVal = Asc(c)
            If ascVal >= CapitalA And ascVal <= CapitalZ Then
                Dim outValue = ((ascVal - CapitalA) + shift + outIndex * direction) Mod 26 + CapitalA
                If outValue < CapitalA Then
                    outValue += 26
                End If
                out(outIndex) = Chr(outValue)
                outIndex = outIndex + 1
            Else
                out(outIndex) = c
                outIndex = outIndex + 1
            End If
        Next
        Return out
    End Function

    Function ColunmarTranspositionEncrypt(message As String, columns As Integer) As String
        Dim lengthMessage = Len(message)
        message = Regex.Replace(UCase(message), "[^A-Z]+", String.Empty)
        message.PadRight(lengthMessage + (columns - (lengthMessage Mod columns)), "E")

        ' recalculate length
        lengthMessage = Len(message)

        Dim n = lengthMessage / columns

        Dim out As String = ""

        For i = 1 To columns
            For i2 = 0 To n - 1
                out = out + message(i + (i2 * columns - 1))
            Next
        Next

        Return out
    End Function

    Function VignereEncrypt(message As String, shift As Integer) As String
        Return VignereRound(message, shift, 1)
    End Function

    Function VignereDecrypt(message As String, shift As Integer) As String
        Return VignereRound(message, -shift, -1)
    End Function

    Function CaesarDecrypt(message As String, shift As Integer) As String
        Return CaesarEncrypt(message, -shift)
    End Function

    Function Capitalize(message As String) As String
        Return UCase(message)
    End Function
End Module
