Imports System.Data.SQLite
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class clQMNextAuswertung

    Dim MyDatenbank As New clDatenbank
#Region "Properties"
    '###########################################################
    Private MyDBConnection As SQLiteConnection
    Public Property _MyDBConnection() As SQLiteConnection
        Get
            Return MyDBConnection
        End Get
        Set(ByVal value As SQLiteConnection)
            MyDBConnection = value
        End Set
    End Property

    Private MyConString As String
    Public Property _MyConString() As String
        Get
            Return MyConString
        End Get
        Set(ByVal value As String)
            MyConString = value
        End Set
    End Property

    Private MySQLQueryString As String
    Public Property _MySQLQueryString() As String
        Get
            Return MySQLQueryString
        End Get
        Set(ByVal value As String)
            MySQLQueryString = value
        End Set
    End Property

    Private MyErrorTable As DataTable
    Public Property _MyErrorTable() As DataTable
        Get
            Return MyErrorTable
        End Get
        Set(ByVal value As DataTable)
            MyErrorTable = value
        End Set
    End Property
#End Region
    '###########################################################
    Public Function GetErrorTable(ByVal SearchString As String) As DataTable
        Try
            'MySQLQueryString = SearchString
            MyErrorTable = MyDatenbank.GetDataTable(MyDBConnection, SearchString)

            If MyErrorTable.Rows.Count <= 0 Then
                MsgBox("Leider wurden keine passenden Einträge gefunden.")
            Else
                Debug.WriteLine("{0} Einträge gefunden.", MyErrorTable.Rows.Count)
                Return MyErrorTable
                End If

            Debug.WriteLine(MyErrorTable.Rows.Count & " Einträge gefunden.")
            Return Nothing
        Catch ex As Exception
            MsgBox(System.Reflection.MethodInfo.GetCurrentMethod.ToString & " hat einen Fehler verursacht." & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function GetAuswertungDataTable(ByVal dtFehler As DataTable) As DataTable

        Dim dicCountLocations = CountLocations(dtFehler)
        Dim dtAuswertung, dtLocationCount As New DataTable

        dtLocationCount.Columns.Add("Item")
        dtLocationCount.Columns.Add("Count")

        For Each column In dtFehler.Columns
            dtAuswertung.Columns.Add(column)
        Next

        'For Each item In dicCountLocations.Keys
        '    dtLocationCount.Rows.Add(dicCountLocations(item).Key, dicCountLocations(item).Value)
        'Next


    End Function

    Public Function CountLocations(ByVal dtFehler As DataTable, Optional iErgebnisse As Integer = 10) As List(Of KeyValuePair(Of String, Integer))
        Dim regex As New Regex("[UNCXD]\d", RegexOptions.IgnoreCase)
        Dim htLocations As New Hashtable
        Dim dicLocations As New Dictionary(Of String, Integer)
        Dim lstLocations As New List(Of KeyValuePair(Of String, Integer))

        Try
            For Each eintrag As DataRow In dtFehler.Rows

                Dim location() As String = Split(eintrag.ItemArray(5).ToString.ToLower)
                'Debug.WriteLine(eintrag.ItemArray(5))
                For i = 0 To UBound(location)

                    Dim match As Match = regex.Match(location(i))
                    If match.Success Then
                        'Debug.WriteLine("Match: " & (location(i)))
                        If Not dicLocations.ContainsKey(location(i)) Then
                            dicLocations.Add(location(i), 1)
                        Else
                            dicLocations(location(i)) = dicLocations(location(i)) + 1
                        End If
                    Else
                        'Debug.WriteLine("NoMatch: " & location(i))
                    End If

                Next
            Next

            lstLocations = dicLocations.OrderBy(Function(x) x.Value).ToList()
            'lstLocations = New List(Of KeyValuePair(Of String, Integer))
            lstLocations.Sort(Function(x, y) x.Value.CompareTo(y.Value))
            lstLocations.Reverse()

            Return lstLocations

        Catch ex As Exception
            MsgBox(System.Reflection.MethodInfo.GetCurrentMethod.ToString & " hat einen Fehler verursacht." & vbCrLf & ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function ConnectFehlerlisteDB(ByVal connectionString As String) As SQLiteConnection
        Try
            If MyDBConnection Is Nothing Then
                MyDatenbank = New clDatenbank
                MyDBConnection = MyDatenbank.Connect(connectionString)
            Else
                MyDBConnection.Close()
                MyDBConnection = MyDatenbank.Connect(connectionString)
            End If

            Return MyDBConnection
        Catch ex As Exception
            MsgBox(System.Reflection.MethodInfo.GetCurrentMethod.ToString & " hat einen Fehler verursacht." & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function

End Class
