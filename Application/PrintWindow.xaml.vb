Imports System
Imports System.IO
Imports System.Timers

Public Class PrintWindow
    Public isClosed = False

    ' crude rate limiting
    Public LastPrintTime As DateTime = New DateTime(1970, 1, 1)
    Dim warningTimer As System.Windows.Threading.DispatcherTimer
    Dim oldBrush

    ' wow, 10 seconds is long
    Public PRINT_DELAY = 10000

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        isClosed = True
        Me.Close()
    End Sub

    Private Sub btnCaesar_Click(sender As Object, e As RoutedEventArgs) Handles btnCaesar.Click
        If (DateTime.UtcNow - LastPrintTime).TotalMilliseconds > PRINT_DELAY Then
            SaveFile(My.Resources.caesar_print, Directory.GetCurrentDirectory() + "\caesar_print.pdf")
            PrintFile("\caesar_print.pdf")
            LastPrintTime = Date.UtcNow
        Else
            ' warn
            oldBrush = btnCaesar.Background
            btnCaesar.Background = (New BrushConverter().ConvertFrom("#FFFF0000"))
            warningTimer = New System.Windows.Threading.DispatcherTimer()
            warningTimer.Interval = New TimeSpan(0, 0, 0, 0, 250)
            AddHandler warningTimer.Tick, AddressOf btnCaesar_Tick
            warningTimer.Start()
        End If

    End Sub

    Private Sub btnCaesar_Tick()
        btnCaesar.Background = oldBrush
        warningTimer.Stop()
    End Sub

    Private Sub btnVignere_Click(sender As Object, e As RoutedEventArgs) Handles btnVignere.Click
        If (DateTime.UtcNow - LastPrintTime).TotalMilliseconds > PRINT_DELAY Then
            SaveFile(My.Resources.vignere_print, Directory.GetCurrentDirectory() + "\vignere_print.pdf")
            PrintFile("\vignere_print.pdf")
            LastPrintTime = Date.UtcNow
        Else
            ' warn
            oldBrush = btnVignere.Background
            btnVignere.Background = (New BrushConverter().ConvertFrom("#FFFF0000"))
            warningTimer = New System.Windows.Threading.DispatcherTimer()
            warningTimer.Interval = New TimeSpan(0, 0, 0, 0, 250)
            AddHandler warningTimer.Tick, AddressOf btnVignere_Tick
            warningTimer.Start()
        End If
    End Sub

    Private Sub btnVignere_Tick()
        btnVignere.Background = oldBrush
        warningTimer.Stop()
    End Sub

    Private Sub PrintFile(ByVal filename As String)
        ' dang, this is nasty
        Dim printProcess As New ProcessStartInfo
        printProcess.UseShellExecute = True
        printProcess.Verb = "print"
        printProcess.FileName = Directory.GetCurrentDirectory() + filename
        Process.Start(printProcess)
    End Sub

    Private Sub SaveFile(ByVal File As Object, ByVal FilePath As String)
        Dim FByte() As Byte = File
        My.Computer.FileSystem.WriteAllBytes(FilePath, FByte, True)
    End Sub

    Private Sub btnTransposition_Click(sender As Object, e As RoutedEventArgs) Handles btnTransposition.Click
        If (DateTime.UtcNow - LastPrintTime).TotalMilliseconds > PRINT_DELAY Then
            SaveFile(My.Resources.transposition_print, Directory.GetCurrentDirectory() + "\transposition_print.pdf")
            PrintFile("\transposition_print.pdf")
            LastPrintTime = Date.UtcNow
        Else
            ' warn
            oldBrush = btnTransposition.Background
            btnTransposition.Background = (New BrushConverter().ConvertFrom("#FFFF0000"))
            warningTimer = New System.Windows.Threading.DispatcherTimer()
            warningTimer.Interval = New TimeSpan(0, 0, 0, 0, 250)
            AddHandler warningTimer.Tick, AddressOf btnTransposition_Tick
            warningTimer.Start()
        End If
    End Sub

    Private Sub btnTransposition_Tick()
        btnTransposition.Background = oldBrush
        warningTimer.Stop()
    End Sub
End Class
