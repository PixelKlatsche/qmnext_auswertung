Imports Microsoft.Office.Interop

Public Class clExcel
    Dim appXL As Excel.Application
    Dim wbXL As Excel.Workbook
    Dim shXl As Excel.Worksheet

    Sub New()
        Try
            'Start Excel and get Application Object
            appXL = New Excel.Application
            appXL.Visible = True

        Catch ex As Exception
            MsgBox(System.Reflection.MethodInfo.GetCurrentMethod.ToString & " hat einen Fehler verursacht." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub OpenWorkbook(ByVal sWorkbook As String)

    End Sub

    Public Sub AddWorkbook()
        wbXL = appXL.Workbooks.Add
        shXl = wbXL.ActiveSheet
    End Sub



    Public Sub AddHeaders()
        shXl.Cells(1, 1).value = "First"
        shXl.Cells(1, 2).value = "Second"
        shXl.Cells(1, 3).value = "Third"

    End Sub

    Public Sub ImportWorksheet()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
