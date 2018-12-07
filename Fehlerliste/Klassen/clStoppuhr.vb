Public Class clStoppuhr

    Private Stoppuhr As Stopwatch
    Public Property _Stoppuhr() As Stopwatch
        Get
            Return Stoppuhr
        End Get
        Set(ByVal value As Stopwatch)
            Stoppuhr = value
        End Set
    End Property

    Public Sub Starten()
        _Stoppuhr = Stopwatch.StartNew

    End Sub

    Public Function Beenden() As Integer
        Try
            ' Stop measuring.
            Stoppuhr.Stop()
            Return Stoppuhr.ElapsedMilliseconds
        Catch ex As Exception
        Finally
            Stoppuhr.Reset()
        End Try



    End Function

    Public Sub Pause()

    End Sub




End Class
