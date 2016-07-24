Class MainWindow
    Dim learnWindow As LearnWindow = New LearnWindow()
    Dim exploreWindow As ExploreWindow = New ExploreWindow()
    Dim printWindow As PrintWindow = New PrintWindow()

    Dim originalButtonText As String

    Private Sub btnLearn_Click(sender As Object, e As RoutedEventArgs) Handles btnLearn.Click
        If learnWindow.isClosed Then
            learnWindow = New LearnWindow()
        End If
        learnWindow.Show()
        learnWindow.Activate()
    End Sub

    Private Sub btns_Hover(sender As Object, e As RoutedEventArgs) Handles btnLearn.MouseEnter, btnPrint.MouseEnter, btnExplore.MouseEnter
        Dim btn = DirectCast(sender, Button)
        originalButtonText = btn.Content
        Dim btnText = btn.Content
        btnText = btnText.Replace("O", "0").Replace("E", "3").Replace("I", "1").Replace("S", "$")
        btn.Content = btnText

    End Sub

    Private Sub btns_Leave(sender As Object, e As RoutedEventArgs) Handles btnLearn.MouseLeave, btnPrint.MouseLeave, btnExplore.MouseLeave
        Dim btn = DirectCast(sender, Button)
        btn.Content = originalButtonText
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As RoutedEventArgs) Handles btnPrint.Click
        If printWindow.isClosed Then
            printWindow = New PrintWindow
        End If
        printWindow.Show()
        printWindow.Activate()
    End Sub

    Private Sub btnExplore_Click(sender As Object, e As RoutedEventArgs) Handles btnExplore.Click
        If exploreWindow.isClosed Then
            exploreWindow = New ExploreWindow()
        End If
        exploreWindow.Show()
        exploreWindow.Activate()
    End Sub
End Class
