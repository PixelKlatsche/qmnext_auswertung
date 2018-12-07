Option Strict On

Imports System.Data.SQLite


Public Class clDatenbank

    Public Function Connect(ByVal conString As String) As SQLiteConnection
        Dim Connection = New SQLiteConnection(conString)
        If Connection.State = ConnectionState.Open Then
            Connection.Close()
            ' MyLogger.Info("[DATABASE] Connection closed.")
        End If
        Connection.Open()
        'MyLogger.Info("[DATABASE] Connection opened.")
        Return Connection
    End Function

    Public Function Disconnect(ByVal objConnection As SQLiteConnection) As Integer
        Dim int As Integer = 1
        If objConnection.State = ConnectionState.Open Then
            objConnection.Close()
            int = 0
        End If
        Return int
    End Function

    Public Function GetDataTable(ByVal objConnection As SQLiteConnection, ByVal strCommand As String) As DataTable
        'Dim MyCommand As SQLiteCommand
        Dim MyDataTable As New DataTable
        'Dim MyDataView As New DataView
        Dim MyDataAdapter As New SQLiteDataAdapter(strCommand, objConnection)
        Try
            MyDataAdapter.Fill(MyDataTable)
            'MyDataView = MyDataTable.AsDataView
            'MyLogger.Info("GetDataTable executed.")


        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            'objConnection.Close()
        End Try
        Return MyDataTable
    End Function

    Public Function InsertDataTable(ByRef dtDataTable As DataTable, ByVal tTable As String, ByVal connection As SQLiteConnection) As Integer
        Dim int As Integer = 1
        Dim coloumns As New List(Of String)
        Dim MyDataAdapter As New SQLiteDataAdapter
        Dim Command As SQLiteCommand


        For Each cColoumn As DataColumn In dtDataTable.Columns
            coloumns.Add(cColoumn.ToString)
        Next

        For Each drRow As DataRow In dtDataTable.Rows
            Command = New SQLiteCommand("INSERT INTO " + tTable + " (")
        Next

    End Function

End Class
