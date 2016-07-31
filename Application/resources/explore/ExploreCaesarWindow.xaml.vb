

Public Class ExploreCaesarWindow
    Public isClosed = False

    Dim timer As System.Windows.Threading.DispatcherTimer = New System.Windows.Threading.DispatcherTimer()
    Dim resultLength As Integer
    Dim currentIndex As Integer
    Dim result As String
    Dim current
    Dim decodeMode = False

    Private Sub btnPlus_Click(sender As Object, e As RoutedEventArgs) Handles btnPlus.Click
        shiftLength.Text = shiftLength.Text + 1
        If shiftLength.Text = 26 Then
            shiftLength.Text = 0
        End If
    End Sub

    Private Sub btnMinus_Click(sender As Object, e As RoutedEventArgs) Handles btnMinus.Click
        shiftLength.Text = shiftLength.Text - 1
        If shiftLength.Text = -26 Then
            shiftLength.Text = 0
        End If
    End Sub

    Private Sub btnEncode_Click(sender As Object, e As RoutedEventArgs) Handles btnEncode.Click
        If decodeMode Then
            result = Ciphers.CaesarEncrypt(txtPlain.Text, shiftLength.Text)
        Else
            result = Ciphers.CaesarDecrypt(txtPlain.Text, shiftLength.Text)
        End If
        current = Ciphers.Capitalize(txtPlain.Text).ToCharArray()

        result = result.Substring(0, result.Length - 1)

        txtCipher.Text = New String(current)

        currentIndex = 0
        resultLength = Len(result)
        timer.Stop()

        timer = New System.Windows.Threading.DispatcherTimer()
        timer.Interval = New TimeSpan(0, 0, 0, 0, 60)
        AddHandler timer.Tick, AddressOf encode_Tick
        timer.Start()

        ' animatics
        'For i = 0 To Len(result) - 1 Step 1
        'prelim(i) = result(i)
        'txtCipher.Text = New String(prelim)
        'Next
    End Sub

    Private Sub encode_Tick()
        current(currentIndex) = result(currentIndex)
        txtCipher.Text = New String(current)
        currentIndex += 1
        If currentIndex = resultLength Then
            timer.Stop()

        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        isClosed = True
        Me.Close()
    End Sub


    Private Sub btnDecodeMode_Click(sender As Object, e As RoutedEventArgs) Handles btnDecodeMode.Click
        If decodeMode = False Then
            decodeMode = True
            btnEncode.Content = "DECODE"
            btnDecodeMode.Background = (New BrushConverter().ConvertFrom("#FF00FFFF"))
        Else
            decodeMode = False
            btnEncode.Content = "ENCODE"
            btnDecodeMode.Background = (New BrushConverter().ConvertFrom("#FF000000"))

        End If
    End Sub
End Class
