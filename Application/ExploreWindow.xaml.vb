Public Class ExploreWindow
    Public isClosed = False
    Dim originalButtonText As String
    Dim caesarWindow = New ExploreCaesarWindow()

    Private Sub btns_Hover(sender As Object, e As RoutedEventArgs) Handles btnCaesar.MouseEnter, btnVigere.MouseEnter, btnColumnar.MouseEnter
        Dim btn = DirectCast(sender, Button)
        originalButtonText = btn.Content
        Dim btnText = btn.Content
        btnText = btnText.Replace("O", "0").Replace("E", "3").Replace("I", "1").Replace("S", "$")
        btn.Content = btnText

    End Sub

    Private Sub btns_Leave(sender As Object, e As RoutedEventArgs) Handles btnCaesar.MouseLeave, btnVigere.MouseLeave, btnColumnar.MouseLeave
        Dim btn = DirectCast(sender, Button)
        btn.Content = originalButtonText
    End Sub

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        isClosed = True
        Me.Close()
    End Sub

    Private Sub btnCaesar_Click(sender As Object, e As RoutedEventArgs) Handles btnCaesar.Click
        If caesarWindow.isClosed Then
            caesarWindow = New ExploreCaesarWindow()
        End If
        caesarWindow.Show()
        caesarWindow.Activate()
    End Sub
End Class
