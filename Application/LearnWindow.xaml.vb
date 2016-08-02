Public Class LearnWindow
    Public isClosed = False

    Dim originalButtonText As String

    Dim caesarWindow As LearnCaesarWindow = New LearnCaesarWindow()
    Dim vignereWindow As LearnVignereWindow = New LearnVignereWindow()
    Dim transpositionWindow As LearnTranspositionWindow = New LearnTranspositionWindow()

    Private Sub btns_Hover(sender As Object, e As RoutedEventArgs) Handles btnCaesar.MouseEnter, btnVignere.MouseEnter, btnColumnar.MouseEnter
        Dim btn = DirectCast(sender, Button)
        originalButtonText = btn.Content
        Dim btnText = btn.Content
        btnText = btnText.Replace("O", "0").Replace("E", "3").Replace("I", "1").Replace("S", "$")
        btn.Content = btnText

    End Sub

    Private Sub btns_Leave(sender As Object, e As RoutedEventArgs) Handles btnCaesar.MouseLeave, btnVignere.MouseLeave, btnColumnar.MouseLeave
        Dim btn = DirectCast(sender, Button)
        btn.Content = originalButtonText
    End Sub

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        isClosed = True
        Me.Close()
    End Sub

    Private Sub btnCaesar_Click(sender As Object, e As RoutedEventArgs) Handles btnCaesar.Click
        If caesarWindow.isClosed Then
            caesarWindow = New LearnCaesarWindow()
        End If
        caesarWindow.Show()
        caesarWindow.Activate()
    End Sub

    Private Sub btnVignere_Click(sender As Object, e As RoutedEventArgs) Handles btnVignere.Click
        If vignereWindow.isClosed Then
            vignereWindow = New LearnVignereWindow()
        End If
        vignereWindow.Show()
        vignereWindow.Activate()
    End Sub

    Private Sub btnColumnar_Click(sender As Object, e As RoutedEventArgs) Handles btnColumnar.Click
        If transpositionWindow.isClosed Then
            transpositionWindow = New LearnTranspositionWindow()
        End If
        transpositionWindow.Show()
        transpositionWindow.Activate()
    End Sub
End Class
