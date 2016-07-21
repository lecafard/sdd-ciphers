Public Class ExploreWindow
    Public isClosed = False

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        isClosed = True
        Me.Close()
    End Sub

    Private Sub btnCaesar_Click(sender As Object, e As RoutedEventArgs) Handles btnCaesar.Click

    End Sub
End Class
