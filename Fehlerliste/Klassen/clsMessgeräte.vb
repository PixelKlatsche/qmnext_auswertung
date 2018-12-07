Imports System.IO

Public Class clsMessgeräte

    Dim MyDatenbank As New clDatenbank
    Dim AppPfad As String = System.AppDomain.CurrentDomain.BaseDirectory
    Dim DBName As String = "Messgeräte.db"
    Dim ConnectionString As String = "Data Source=" + AppPfad + "/" + DBName + ";Version=3;"
    Dim DBConnection As SQLite.SQLiteConnection
    Dim ScansPfad As String = AppPfad + "messgeräte_barcodes_04.10.18.txt"
    Dim AnzahlGeräte As Integer = 0
    Dim AnzahlModule As Integer = 0
    Dim htCalibrationForecast As New Hashtable
    Dim lstIsInDatabase As New List(Of String)
    Dim lstNeedKali As New List(Of String)
    Dim lstNotInDataBase As New List(Of String)
    Dim dtInDatabase As New DataTable
    Dim dtComplete As New DataTable
    Dim dtNotInDatabase As New DataTable
    Dim dtKaliNeeded As New DataTable
    Dim dtAllDevices As New DataTable

    Sub New()
        dtInDatabase.Columns.Add("ID")
        dtInDatabase.Columns.Add("Name")
        dtInDatabase.Columns.Add("Art")
        dtInDatabase.Columns.Add("GehörtZu")
        dtInDatabase.Columns.Add("Nummer")
        dtInDatabase.Columns.Add("KaliZyklus")
        dtInDatabase.Columns.Add("LetzteKali")
        dtInDatabase.Columns.Add("Platz")
        dtInDatabase.Columns(0).AutoIncrement = True
        dtNotInDatabase = dtInDatabase.Copy
        dtKaliNeeded = dtInDatabase.Copy
        dtComplete = dtInDatabase.Copy
        dtAllDevices = dtInDatabase.Copy

        htCalibrationForecast.Add("January", 0)
        htCalibrationForecast.Add("February", 0)
        htCalibrationForecast.Add("March", 0)
        htCalibrationForecast.Add("April", 0)
        htCalibrationForecast.Add("May", 0)
        htCalibrationForecast.Add("June", 0)
        htCalibrationForecast.Add("July", 0)
        htCalibrationForecast.Add("August", 0)
        htCalibrationForecast.Add("September", 0)
        htCalibrationForecast.Add("October", 0)
        htCalibrationForecast.Add("November", 0)
        htCalibrationForecast.Add("December", 0)

    End Sub

    Public Sub Connect()
        Console.WriteLine("Datenbank: " + DBName)
        Console.WriteLine()

        DBConnection = MyDatenbank.Connect(ConnectionString)

        Dim SQLQuery_GetAllItems As String = "Select * From '100G_400G';"
        Dim dtItems As DataTable = MyDatenbank.GetDataTable(DBConnection, SQLQuery_GetAllItems)

        For Each Item In dtItems.Rows
            If Item("Art") = "Gerät" Then
                AnzahlGeräte += 1
            ElseIf Item("Art") = "Modul" Then
                AnzahlModule += 1
            End If
        Next

        Console.WriteLine("Geräte: " + AnzahlGeräte.ToString)
        Console.WriteLine("Module: " + AnzahlModule.ToString)
        Console.WriteLine()

    End Sub

    Private Function GetBarcodes() As List(Of String)
        Dim objReader As New StreamReader(ScansPfad)
        Dim AnzahlBarcodes As Integer = 0
        Dim lstBarcodes As New List(Of String)
        Do
            Dim sLine As String = objReader.ReadLine
            If sLine = Nothing Then
                Exit Do
            Else
                Dim arrLine() As String = sLine.Split(",")
                lstBarcodes.Add(arrLine(0).Replace(ChrW(&H22), ""))
                AnzahlBarcodes += 1
            End If
        Loop
        Console.WriteLine("Barcodes: " + AnzahlBarcodes.ToString)
        Console.WriteLine()
        'lstBarcodes.Sort()
        Return lstBarcodes
    End Function

    Public Sub ScansPrüfen(ByVal ScansPfad As String)
        Dim dtNotScanned As New DataTable
        Dim aktMonat As Integer = DateAndTime.Month(Date.Now)
        Dim aktJahr As Integer = DateAndTime.Year(Date.Now).ToString.Remove(0, 2)
        Dim strSELECT As String = Nothing


        strSELECT = "SELECT * FROM '100G_400G';"
        dtComplete = MyDatenbank.GetDataTable(DBConnection, strSELECT)

        Console.WriteLine("Monat: " + aktMonat.ToString)
        Console.WriteLine("Jahr: " + aktJahr.ToString)
        Console.WriteLine()

        Dim lstBarcodes As List(Of String) = GetBarcodes()

        Dim iDeviceCount As Integer = 0

        For Each sCode In lstBarcodes



            strSELECT = "SELECT * FROM '100G_400G' WHERE Nummer='" + sCode + "';"
            Dim dtScan As DataTable = MyDatenbank.GetDataTable(DBConnection, strSELECT)

            Dim newRow As DataRow

            If dtScan.Rows.Count = 0 Then
                newRow = dtNotInDatabase.NewRow
                newRow("Nummer") = sCode
                dtNotInDatabase.Rows.Add(newRow)

            ElseIf dtScan.Rows.Count = 1 And IsDBNull(dtScan.Rows(0).Item("KaliZyklus")) Then
                newRow = dtInDatabase.NewRow
                newRow("Name") = dtScan.Rows(0).Item("Name")
                newRow("Art") = dtScan.Rows(0).Item("Art")
                newRow("GehörtZu") = dtScan.Rows(0).Item("GehörtZu")
                newRow("Nummer") = dtScan.Rows(0).Item("Nummer")
                newRow("KaliZyklus") = dtScan.Rows(0).Item("KaliZyklus")
                newRow("LetzteKali") = dtScan.Rows(0).Item("LetzteKali")
                newRow("Platz") = dtScan.Rows(0).Item("Platz")
                dtInDatabase.Rows.Add(newRow)
                iDeviceCount += 1

            ElseIf dtScan.Rows.Count = 1 And Not IsDBNull(dtScan.Rows(0).Item("KaliZyklus")) Then
                Dim LastKali() As String = Split(dtScan.Rows(0).Item("LetzteKali"), ".")
                Dim KaliDiff As Integer = ((dtScan.Rows(0).Item("KaliZyklus") - (aktJahr - LastKali(1)) * 12) - (aktMonat - LastKali(0)))

                If KaliDiff <= 0 Then
                    newRow = dtKaliNeeded.NewRow
                    newRow("Name") = dtScan.Rows(0).Item("Name")
                    newRow("Art") = dtScan.Rows(0).Item("Art")
                    newRow("GehörtZu") = dtScan.Rows(0).Item("GehörtZu")
                    newRow("Nummer") = dtScan.Rows(0).Item("Nummer")
                    newRow("KaliZyklus") = dtScan.Rows(0).Item("KaliZyklus")
                    newRow("LetzteKali") = dtScan.Rows(0).Item("LetzteKali")
                    newRow("Platz") = dtScan.Rows(0).Item("Platz")
                    iDeviceCount += 1
                    dtKaliNeeded.Rows.Add(newRow)
                ElseIf KaliDiff > 0 Then
                    newRow = dtInDatabase.NewRow
                    newRow("Name") = dtScan.Rows(0).Item("Name")
                    newRow("Art") = dtScan.Rows(0).Item("Art")
                    newRow("GehörtZu") = dtScan.Rows(0).Item("GehörtZu")
                    newRow("Nummer") = dtScan.Rows(0).Item("Nummer")
                    newRow("KaliZyklus") = dtScan.Rows(0).Item("KaliZyklus")
                    newRow("LetzteKali") = dtScan.Rows(0).Item("LetzteKali")
                    newRow("Platz") = dtScan.Rows(0).Item("Platz")
                    iDeviceCount += 1
                    dtInDatabase.Rows.Add(newRow)
                End If

                If dtScan.Rows(0).Item("KaliZyklus") >= 12 Then
                    Dim nextKaliYear As Integer = LastKali(1)
                    nextKaliYear += (dtScan.Rows(0).Item("KaliZyklus") / 12)
                    If nextKaliYear = aktJahr Then
                        AddToCalibrationForecast(LastKali(0))
                    End If
                End If

            Else
                MsgBox("Was ist das?")
            End If




            Dim searchRow As DataRow() = dtComplete.Select("Nummer=" + sCode)
            If searchRow.Length <> 0 Then
                dtComplete.Rows.Remove(searchRow(0))
            End If
        Next

        dtAllDevices.Merge(dtInDatabase)
        dtAllDevices.Merge(dtKaliNeeded)

        Console.WriteLine("DeviceCount: " + iDeviceCount.ToString)
        Console.WriteLine("dtAllDevices: " + dtAllDevices.Rows.Count.ToString)
        Console.WriteLine("dtInDataBase: " + dtInDatabase.Rows.Count.ToString)
        Console.WriteLine("dtKaliNeeded: " + dtKaliNeeded.Rows.Count.ToString)
        Console.WriteLine("dtNotInDataBase: " + dtNotInDatabase.Rows.Count.ToString)

    End Sub

    Public Function CheckBarcode(ByVal sBarcode As String) As DataRow
        Dim strSELECT As String = Nothing

        Dim DBConnection = MyDatenbank.Connect(ConnectionString)

        strSELECT = "SELECT * FROM '100G_400G' WHERE Nummer='" + sBarcode + "';"
        Dim dtScan As DataTable = MyDatenbank.GetDataTable(DBConnection, strSELECT)


        If dtScan.Rows.Count = 0 Then

            Dim result As Integer = MsgBox("Unbekannter Barcode! Möchten Sie unter dem neuen Barcode ein neues Messgeräte/Modul erzeugen?", vbYesNoCancel)

            If result = DialogResult.Cancel Then
                Exit Function
            ElseIf result = DialogResult.Yes Then
                Exit Function
            ElseIf result = DialogResult.No Then
                Exit Function
            End If

        ElseIf dtScan.Rows.Count = 1 Then
            Dim newRow As DataRow = dtScan.Rows(0)
            Return newRow
            'MsgBox(newRow("Name"))

        ElseIf dtScan.Rows.Count > 1 Then
            MsgBox("Es wurden mehrere Geräte/Module mit dem gescannten Barcode in der Datenbank gefunden! DAS sollte NICHT passieren.")
        End If



    End Function

    Private Sub AddToCalibrationForecast(ByVal Month As Integer)
        If Month < 12 Then
            Select Case Month
                Case 1
                    htCalibrationForecast("January") += 1
                Case 2
                    htCalibrationForecast("February") += 1
                Case 3
                    htCalibrationForecast("March") += 1
                Case 4
                    htCalibrationForecast("April") += 1
                Case 5
                    htCalibrationForecast("May") += 1
                Case 6
                    htCalibrationForecast("June") += 1
                Case 7
                    htCalibrationForecast("July") += 1
                Case 8
                    htCalibrationForecast("August") += 1
                Case 9
                    htCalibrationForecast("September") += 1
                Case 10
                    htCalibrationForecast("October") += 1
                Case 11
                    htCalibrationForecast("November") += 1
                Case 12
                    htCalibrationForecast("December") += 1
            End Select
        End If
    End Sub

    Public Function GetCaliForecast() As Hashtable
        Return htCalibrationForecast
    End Function

    Public Function GetComplete() As DataTable
        Return dtComplete
    End Function

    Public Function GetNeedKali() As DataTable
        Return dtKaliNeeded
    End Function

    Public Function GetFehlt() As DataTable
        Return dtNotInDatabase
    End Function

    Public Function GetVorhanden() As DataTable
        Return dtInDatabase
    End Function

    Public Function GetNotScanned() As DataTable
        Return dtComplete
    End Function

    Public Function GetAllDevices() As DataTable
        Return dtAllDevices
    End Function
End Class
