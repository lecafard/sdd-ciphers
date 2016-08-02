

Public Class ExploreTranspositionWindow
    Public isClosed = False

    Dim timer As System.Windows.Threading.DispatcherTimer = New System.Windows.Threading.DispatcherTimer()
    Dim resultLength As Integer
    Dim currentIndex As Integer
    Dim result As String
    Dim current

    Private Sub btnPlus_Click(sender As Object, e As RoutedEventArgs) Handles btnPlus.Click
        numColumns.Text = numColumns.Text + 1
        If numColumns.Text = 17 Then
            numColumns.Text = 16
        End If
    End Sub

    Private Sub btnMinus_Click(sender As Object, e As RoutedEventArgs) Handles btnMinus.Click
        numColumns.Text = numColumns.Text - 1
        If numColumns.Text = 0 Then
            numColumns.Text = 1
        End If
    End Sub

    Private Sub btnEncode_Click(sender As Object, e As RoutedEventArgs) Handles btnEncode.Click
        result = Ciphers.ColunmarTranspositionEncrypt(txtPlain.Text, numColumns.Text)
        txtCipher.Text = result
    End Sub

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        isClosed = True
        Me.Close()
    End Sub

End Class
