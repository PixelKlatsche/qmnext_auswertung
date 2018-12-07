Option Explicit On

Imports System.Data.SQLite
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class Form1

    Dim MyDatenbank As New clDatenbank
    Dim MyAuswertung As New clQMNextAuswertung
    Dim MyStoppuhr As New clStoppuhr

    Private MyDBConnection As SQLiteConnection
    Public Property _MyDBConnection() As SQLiteConnection
        Get
            Return MyDBConnection
        End Get
        Set(ByVal value As SQLiteConnection)
            MyDBConnection = value
        End Set
    End Property
    Private MySearchString As String
    Public Property _MySearchString() As String
        Get
            Return MySearchString
        End Get
        Set(ByVal value As String)
            MySearchString = value
        End Set
    End Property

    Private AppPfad As String = Application.StartupPath
    Private DBName As String = "Fehlerliste.db"
    Private ConString As String = "Data Source=" + AppPfad + "/" + DBName + ";Version=3;"
    Private dtResult As DataTable
    Private dvResult As DataView



    Private Sub Reset()
        Dim watch = New clStoppuhr
        watch.Starten() 'MyStoppuhr.Starten()
        Dim htOperations, htProductLines As New List(Of String)
        Dim opr, prodL As String
        MySearchString = "SELECT * FROM 'Fehler';"

        Try
            'datenbank verbindung herstellen
            MyDBConnection = MyAuswertung.ConnectFehlerlisteDB(ConString)
            If Not MyDBConnection Is Nothing Then
                SetStatus("Datenbank verbunden.")
            Else
                SetStatus("Datenbank getrennt.")
            End If

            'buttons deaktivieren
            cmd_Suchen.Enabled = False
            cmd_Reset.Enabled = False
            cmd_Auswertung.Enabled = False

            'calender controls werden gesetzt
            date_startDate.Value = DateTime.Now.AddYears(-10)
            date_endDate.Value = DateTime.Now

            'DataTable mit kompletter Datenbank wird übergeben und in das datagridview geladen
            Dim dtQM_All As DataTable = MyDatenbank.GetDataTable(MyDBConnection, "SELECT * FROM 'Fehler';")
            'dtResult = MyAuswertung.GetErrorTable(MySearchString)
            dgv_Result.DataSource = dtQM_All

            prg_Load.Maximum = dtQM_All.Rows.Count

            'sammeln von operationen und produktlinien
            ' Dim dtOPR() As DataRow = dtQM_All.Select("SELECT DISTINCT 'OPR_OPERATIONSHORT', 'RTN_PRODUCTLINE' FROM 'Fehler';")
            Dim dtOPR As DataTable = dtQM_All.DefaultView.ToTable(True, "OPR_OPERATIONSHORT")
            Dim dtRTN As DataTable = dtQM_All.DefaultView.ToTable(True, "RTN_PRODUCTLINE")

            With cmb_opr_operationshort
                Dim drAll As DataRow = dtOPR.NewRow
                drAll("OPR_OPERATIONSHORT") = "'ALLE"
                dtOPR.Rows.Add(drAll)
                '.Items.Add("ALL")
                .DataSource = dtOPR
                .DisplayMember = "OPR_OPERATIONSHORT"
                .SelectedItem = .Items.IndexOf("FKT")
            End With

            With cmb_rtn_productline
                Dim drAll As DataRow = dtRTN.NewRow
                drAll("RTN_PRODUCTLINE") = "'ALLE"
                dtRTN.Rows.Add(drAll)
                .DataSource = dtRTN
                .DisplayMember = "RTN_PRODUCTLINE"
                .SelectedItem = "TRANS_HIT7300"
            End With
            SetStatus("OPR & RTN Punkte geladen.")

            'buttons aktivieren
            cmd_Suchen.Enabled = True
            cmd_Reset.Enabled = True
            cmd_Auswertung.Enabled = True

            SetStatus("Fertig")

        Catch ex As Exception
            MsgBox(Reflection.MethodBase.GetCurrentMethod.ToString & " hat einen Fehler verursacht." & vbCrLf & ex.Message)
        Finally
            Debug.WriteLine(Reflection.MethodInfo.GetCurrentMethod.ToString & "({0} Sekunden)", watch.Beenden() / 1000)
        End Try
    End Sub

    Private Sub CreateSearchString()
        Try
            Dim startDate = Replace(date_startDate.Value.ToString("yyyy/MM/dd"), ".", "/")
            Dim endDate = Replace(date_endDate.Value.ToString("yyyy/MM/dd"), ".", "/")
            Dim serno = txt_sca_serno.Text.Trim.ToLower
            Dim matCode = txt_sca_matcode.Text.Trim.ToLower
            Dim operation = cmb_opr_operationshort.SelectedText.Trim.ToLower
            Dim groupCode = txt_ncl_groupCode.Text.Trim.ToLower
            Dim Location = txt_ncl_location.Text.Trim.ToLower
            Dim componentMatCode = txt_ncl_componentCode.Text.Trim.ToLower
            Dim nclComment = txt_ncl_comment.Text.Trim.ToLower
            Dim productLine = cmb_rtn_productline.SelectedText.Trim.ToLower
            Dim scaComment = txt_sca_comment.Text.Trim.ToLower


            Dim opr = DirectCast(cmb_opr_operationshort.SelectedItem, DataRowView).Item("OPR_OPERATIONSHORT")
            If opr = "" Or opr = "'ALLE" Then
                operation = ""
            Else
                operation = opr.Trim.ToLower
            End If

            Dim rtn = DirectCast(cmb_rtn_productline.SelectedItem, DataRowView).Item("RTN_PRODUCTLINE")
            If rtn = "" Or rtn = "'ALLE" Then
                productLine = ""
            Else
                productLine = rtn.Trim.ToLower
            End If

            MySearchString = "SELECT * FROM 'Fehler' WHERE substr(SCA_SCANDATETIME, 7)||'-'||substr(SCA_SCANDATETIME,4,2)||'-'||substr(SCA_SCANDATETIME,1,2) " _
            & "BETWEEN '" & startDate.ToString & "' AND '" & endDate.ToString & "' AND SCA_SERNO LIKE '%" + serno + "%' AND SCA_MATCODE LIKE '%" + matCode + "%'" _
            & " And OPR_OPERATIONSHORT Like '%" + operation + "%' AND NC_GROUP_CODE LIKE '%" + groupCode + "%' AND NCL_LOCATION LIKE '%" + Location + "%' AND NCL_COMPONENTMATCODE LIKE " _
            & "'%" + componentMatCode + "%' AND NCL_COMMENT LIKE '%" + nclComment + "%' AND RTN_PRODUCTLINE LIKE '%" + productLine + "%' AND SCA_COMMENT Like '%" + scaComment + "%';"

        Catch ex As Exception
            MsgBox(Reflection.MethodBase.GetCurrentMethod.ToString & " hat einen Fehler verursacht." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub NormaleSuche()

        CreateSearchString()

        Dim dtFehler As New DataTable
        dtFehler.Columns.Add(New DataColumn("SCA_SCANDATETIME"))
        dtFehler.Columns("SCA_SCANDATETIME").DataType = GetType(Date)

        'Dim dtFehler As DataTable = MyDatenbank.GetDataTable(MyDBConnection, MySearchString)
        dtFehler = MyDatenbank.GetDataTable(MyDBConnection, MySearchString)

        For Each row As DataRow In dtFehler.Rows
            row("SCA_SCANDATETIME") = row
        Next


        dgv_Result.DataSource = dtFehler
        Debug.WriteLine("{0} Einträge gefunden", dtFehler.Rows.Count)
        tip_Status.Text = String.Format("{0} Einträge gefunden", dtFehler.Rows.Count)
    End Sub

    Private Sub MonatlicheAuswertung()
        CreateSearchString()
        Dim dtFehler = MyAuswertung.GetErrorTable(MySearchString)

        dgv_Result.DataSource = dtFehler
        Debug.WriteLine("{0} Einträge gefunden", dtFehler.Rows.Count)
        tip_Status.Text = String.Format("{0} Einträge gefunden", dtFehler.Rows.Count)

    End Sub

    Private Sub cmd_Suchen_Click(sender As Object, e As EventArgs) Handles cmd_Suchen.Click
        Dim watch As New clStoppuhr
        Try
            watch.Starten()
            NormaleSuche()

            'SetStatus("Passende Einträge werden gesucht.")

            'CreateSearchString()

            'dtResult = MyAuswertung.GetErrorTable(MySearchString)

            'If dtResult Is Nothing Then
            '    Exit Sub
            'Else
            '    SetStatus(dtResult.Rows.Count & " Einträge gefunden.")
            '    dgv_Result.DataSource = dtResult
            '    Dim iFehlereingaben As Integer = dtResult.Rows.Count
            '    Dim htFehlerResult = Fehlersuche(dtResult, txt_sca_comment.Text.Trim.ToLower)
            '    CreateResultDataTable(htFehlerResult)
            '    SetStatus(htFehlerResult.Count & "/" & iFehlereingaben)
            '    CreateLocationChart(MyAuswertung.CountLocations(dtResult))
            'End If

        Catch ex As Exception
            MsgBox(Reflection.MethodBase.GetCurrentMethod.ToString & " hat einen Fehler verursacht." & vbCrLf & ex.Message)
        Finally
            Debug.WriteLine(Reflection.MethodInfo.GetCurrentMethod.ToString & "({0} Sekunden)", watch.Beenden() / 1000)
        End Try
    End Sub

    Private Sub cmd_Auswertung_Click(sender As Object, e As EventArgs) Handles cmd_Auswertung.Click
        'Dim startDate, endDate, serno, matCode, operation, groupCode, Location, componentMatCode, nclComment, productLine, scaComment As String

        ''datum abfragen und im voraus an sqlite anspassen
        'Dim tmpDate() As String = Split(date_startDate.Value, " ")
        'startDate = ConvertToSQLiteDate(tmpDate(0))
        ''startDate = tmpDate(0)
        'tmpDate = Split(date_endDate.Value, " ")
        'endDate = ConvertToSQLiteDate(tmpDate(0))
        ''endDate = tmpDate(0)

        CreateSearchString()

        dtResult = MyAuswertung.GetErrorTable(MySearchString)

        If dtResult Is Nothing Then
            Exit Sub
        Else
            Dim iFehlereingaben As Integer = dtResult.Rows.Count
            Dim htFehlerResult = Fehlersuche(dtResult, txt_sca_comment.Text.Trim.ToLower)
            CreateResultDataTable(htFehlerResult)
            SetStatus(htFehlerResult.Count & "/" & iFehlereingaben)
            CreateLocationChart(MyAuswertung.CountLocations(dtResult))
        End If

    End Sub

    Public Sub CreateLocationChart(ByVal lstLocations As List(Of KeyValuePair(Of String, Integer)))
        Try
            chart_Locations.Series("Series1").Points.Clear()

            'For Each item In lstLocations
            With chart_Locations.Series("Series1")
                For i = 0 To 9
                    .Points.AddXY(lstLocations(i).Key, lstLocations(i).Value)

                Next
            End With

        Catch ex As Exception
            MsgBox(Reflection.MethodBase.GetCurrentMethod.ToString & " hat einen Fehler verursacht." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Function Fehlersuche(ByVal dtResult As DataTable, ByVal sError As String) As Hashtable
        Try
            Dim dvFehler = New DataView(dtResult, "", "SCA_SERNO", DataViewRowState.Unchanged)
            Dim htBaugruppen As New Hashtable
            Dim sBMNummer As String
            Dim arrEintrag(9) As String

            prg_Load.Maximum = dvFehler.Table.Rows.Count
            prg_Load.Value = 0

            For Each eintrag In dvFehler.Table.Rows
                sBMNummer = eintrag.ItemArray(1)
                'Debug.WriteLine(sBMNummer)

                If Not htBaugruppen.Contains(sBMNummer) Then
                    htBaugruppen.Add(sBMNummer, eintrag.ItemArray)
                Else
                    'Debug.WriteLine(eintrag.itemarray(9).ToString.ToLower)
                    If Not sError = "" Then
                        If eintrag.itemarray(9).ToString.ToLower Like "*" & sError & "*" Then
                            Dim arrBG() As Object = htBaugruppen(sBMNummer)
                            If DateTime.Compare(eintrag.itemarray(0), arrBG(0)) < 0 Then
                                htBaugruppen(sBMNummer) = eintrag.ItemArray
                            End If
                        End If
                    Else
                        Dim arrBG() As Object = htBaugruppen(sBMNummer)
                        If DateTime.Compare(eintrag.itemarray(0), arrBG(0)) < 0 Then
                            htBaugruppen(sBMNummer) = eintrag.ItemArray
                        End If
                    End If
                End If
                prg_Load.PerformStep()
                'Application.DoEvents()
            Next

            Return htBaugruppen

        Catch ex As Exception
            MsgBox(Reflection.MethodBase.GetCurrentMethod.ToString & " hat einen Fehler verursacht." & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function CreateResultDataTable(ByVal htBaugruppen As Hashtable) As DataView
        Dim dtFilterResult As New DataTable

        For Each column In dtResult.Columns
            dtFilterResult.Columns.Add(column.ToString)
        Next

        For Each item In htBaugruppen.Keys
            Dim arrEintrag = htBaugruppen(item)
            Dim dr As DataRow = dtFilterResult.NewRow

            For i = 0 To UBound(arrEintrag)
                dr(i) = arrEintrag(i)
            Next

            dtFilterResult.Rows.Add(dr)
            'Next
        Next

        dgv_Result.DataSource = dtFilterResult
    End Function

    Private Function ConvertToSQLiteDate(ByVal sDate As String) As String
        Try
            Dim arrDate() As String = Split(sDate, ".")
            Dim sqlDate As String = arrDate(2) & "-" & arrDate(1) & "-" & arrDate(0)
            Debug.Print(sqlDate)
            Return sqlDate
        Catch ex As Exception
            MsgBox(Reflection.MethodBase.GetCurrentMethod.ToString & " hat einen Fehler verursacht." & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub SetStatus(ByVal message As String)
        tip_Status.Text = message
        Application.DoEvents()
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim cls
        Catch ex As Exception
            MsgBox(Reflection.MethodBase.GetCurrentMethod.ToString & " hat einen Fehler verursacht." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Reset()
    End Sub

    Private Sub cmd_Reset_Click(sender As Object, e As EventArgs) Handles cmd_Reset.Click
        Reset()
    End Sub

End Class
