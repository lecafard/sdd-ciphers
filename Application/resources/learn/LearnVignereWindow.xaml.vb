Public Class LearnVignereWindow
    Public isClosed = False

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        isClosed = True
        Me.Close()
    End Sub
End Class
