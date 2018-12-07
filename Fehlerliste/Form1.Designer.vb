<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend5 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_sca_serno = New System.Windows.Forms.TextBox()
        Me.txt_sca_matcode = New System.Windows.Forms.TextBox()
        Me.txt_ncl_location = New System.Windows.Forms.TextBox()
        Me.txt_ncl_comment = New System.Windows.Forms.TextBox()
        Me.txt_sca_comment = New System.Windows.Forms.TextBox()
        Me.cmd_Suchen = New System.Windows.Forms.Button()
        Me.cmb_opr_operationshort = New System.Windows.Forms.ComboBox()
        Me.date_startDate = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.date_endDate = New System.Windows.Forms.DateTimePicker()
        Me.txt_ncl_groupCode = New System.Windows.Forms.TextBox()
        Me.txt_ncl_componentCode = New System.Windows.Forms.TextBox()
        Me.cmb_rtn_productline = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.prg_Load = New System.Windows.Forms.ToolStripProgressBar()
        Me.tip_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmd_Reset = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmd_Auswertung = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgv_Result = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.chart_Locations = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_Result, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.chart_Locations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SCA_SCANDATETIME"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SCA_SERNO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "OPR_OPERATIONSHORT"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "SCA_MATCODE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "NC_GROUP_CODE"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "NCL_LOCATION"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "NCL_COMPONENTCODE"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 218)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "NCL_COMMENT"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "RTN_PRODUCTLINE"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 271)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "SCA_COMMENT"
        '
        'txt_sca_serno
        '
        Me.txt_sca_serno.Location = New System.Drawing.Point(159, 58)
        Me.txt_sca_serno.Name = "txt_sca_serno"
        Me.txt_sca_serno.Size = New System.Drawing.Size(240, 20)
        Me.txt_sca_serno.TabIndex = 3
        Me.txt_sca_serno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_sca_matcode
        '
        Me.txt_sca_matcode.Location = New System.Drawing.Point(159, 84)
        Me.txt_sca_matcode.Name = "txt_sca_matcode"
        Me.txt_sca_matcode.Size = New System.Drawing.Size(240, 20)
        Me.txt_sca_matcode.TabIndex = 3
        Me.txt_sca_matcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_ncl_location
        '
        Me.txt_ncl_location.Location = New System.Drawing.Point(159, 163)
        Me.txt_ncl_location.Name = "txt_ncl_location"
        Me.txt_ncl_location.Size = New System.Drawing.Size(240, 20)
        Me.txt_ncl_location.TabIndex = 3
        Me.txt_ncl_location.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_ncl_comment
        '
        Me.txt_ncl_comment.Location = New System.Drawing.Point(159, 215)
        Me.txt_ncl_comment.Name = "txt_ncl_comment"
        Me.txt_ncl_comment.Size = New System.Drawing.Size(240, 20)
        Me.txt_ncl_comment.TabIndex = 3
        Me.txt_ncl_comment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_sca_comment
        '
        Me.txt_sca_comment.Location = New System.Drawing.Point(159, 268)
        Me.txt_sca_comment.Name = "txt_sca_comment"
        Me.txt_sca_comment.Size = New System.Drawing.Size(240, 20)
        Me.txt_sca_comment.TabIndex = 3
        Me.txt_sca_comment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmd_Suchen
        '
        Me.cmd_Suchen.Location = New System.Drawing.Point(10, 322)
        Me.cmd_Suchen.Name = "cmd_Suchen"
        Me.cmd_Suchen.Size = New System.Drawing.Size(84, 23)
        Me.cmd_Suchen.TabIndex = 4
        Me.cmd_Suchen.Text = "Suchen"
        Me.cmd_Suchen.UseVisualStyleBackColor = True
        '
        'cmb_opr_operationshort
        '
        Me.cmb_opr_operationshort.FormattingEnabled = True
        Me.cmb_opr_operationshort.Location = New System.Drawing.Point(159, 110)
        Me.cmb_opr_operationshort.Name = "cmb_opr_operationshort"
        Me.cmb_opr_operationshort.Size = New System.Drawing.Size(240, 21)
        Me.cmb_opr_operationshort.Sorted = True
        Me.cmb_opr_operationshort.TabIndex = 5
        '
        'date_startDate
        '
        Me.date_startDate.Location = New System.Drawing.Point(159, 6)
        Me.date_startDate.Name = "date_startDate"
        Me.date_startDate.Size = New System.Drawing.Size(200, 20)
        Me.date_startDate.TabIndex = 6
        Me.date_startDate.Value = New Date(2010, 12, 25, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "SCA_SCANDATETIME"
        '
        'date_endDate
        '
        Me.date_endDate.Location = New System.Drawing.Point(159, 32)
        Me.date_endDate.Name = "date_endDate"
        Me.date_endDate.Size = New System.Drawing.Size(200, 20)
        Me.date_endDate.TabIndex = 6
        '
        'txt_ncl_groupCode
        '
        Me.txt_ncl_groupCode.Location = New System.Drawing.Point(159, 137)
        Me.txt_ncl_groupCode.Name = "txt_ncl_groupCode"
        Me.txt_ncl_groupCode.Size = New System.Drawing.Size(240, 20)
        Me.txt_ncl_groupCode.TabIndex = 3
        Me.txt_ncl_groupCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_ncl_componentCode
        '
        Me.txt_ncl_componentCode.Location = New System.Drawing.Point(159, 189)
        Me.txt_ncl_componentCode.Name = "txt_ncl_componentCode"
        Me.txt_ncl_componentCode.Size = New System.Drawing.Size(240, 20)
        Me.txt_ncl_componentCode.TabIndex = 3
        Me.txt_ncl_componentCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmb_rtn_productline
        '
        Me.cmb_rtn_productline.FormattingEnabled = True
        Me.cmb_rtn_productline.Location = New System.Drawing.Point(159, 241)
        Me.cmb_rtn_productline.Name = "cmb_rtn_productline"
        Me.cmb_rtn_productline.Size = New System.Drawing.Size(240, 21)
        Me.cmb_rtn_productline.Sorted = True
        Me.cmb_rtn_productline.TabIndex = 5
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.prg_Load, Me.tip_Status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 530)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(930, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'prg_Load
        '
        Me.prg_Load.Name = "prg_Load"
        Me.prg_Load.Size = New System.Drawing.Size(100, 16)
        Me.prg_Load.Step = 1
        Me.prg_Load.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'tip_Status
        '
        Me.tip_Status.Name = "tip_Status"
        Me.tip_Status.Size = New System.Drawing.Size(58, 17)
        Me.tip_Status.Text = "tip_Status"
        '
        'cmd_Reset
        '
        Me.cmd_Reset.Enabled = False
        Me.cmd_Reset.Location = New System.Drawing.Point(823, 6)
        Me.cmd_Reset.Name = "cmd_Reset"
        Me.cmd_Reset.Size = New System.Drawing.Size(65, 23)
        Me.cmd_Reset.TabIndex = 9
        Me.cmd_Reset.Text = "Reset"
        Me.cmd_Reset.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(13, 13)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(911, 514)
        Me.TabControl1.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmd_Auswertung)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cmd_Reset)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.date_endDate)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.date_startDate)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cmb_rtn_productline)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.cmb_opr_operationshort)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.cmd_Suchen)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txt_sca_comment)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txt_ncl_componentCode)
        Me.TabPage1.Controls.Add(Me.txt_sca_serno)
        Me.TabPage1.Controls.Add(Me.txt_ncl_comment)
        Me.TabPage1.Controls.Add(Me.txt_sca_matcode)
        Me.TabPage1.Controls.Add(Me.txt_ncl_groupCode)
        Me.TabPage1.Controls.Add(Me.txt_ncl_location)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(903, 488)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Menu"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmd_Auswertung
        '
        Me.cmd_Auswertung.Location = New System.Drawing.Point(100, 322)
        Me.cmd_Auswertung.Name = "cmd_Auswertung"
        Me.cmd_Auswertung.Size = New System.Drawing.Size(75, 23)
        Me.cmd_Auswertung.TabIndex = 10
        Me.cmd_Auswertung.Text = "Auswertung"
        Me.cmd_Auswertung.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgv_Result)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(903, 488)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Result"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgv_Result
        '
        Me.dgv_Result.AllowUserToAddRows = False
        Me.dgv_Result.AllowUserToDeleteRows = False
        Me.dgv_Result.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Result.Location = New System.Drawing.Point(6, 7)
        Me.dgv_Result.Name = "dgv_Result"
        Me.dgv_Result.ReadOnly = True
        Me.dgv_Result.Size = New System.Drawing.Size(882, 475)
        Me.dgv_Result.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.chart_Locations)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(903, 488)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Auswertung"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'chart_Locations
        '
        ChartArea5.AxisX.Interval = 1.0R
        ChartArea5.Name = "ChartArea1"
        Me.chart_Locations.ChartAreas.Add(ChartArea5)
        Legend5.Name = "Legend1"
        Me.chart_Locations.Legends.Add(Legend5)
        Me.chart_Locations.Location = New System.Drawing.Point(3, 3)
        Me.chart_Locations.Name = "chart_Locations"
        Series5.ChartArea = "ChartArea1"
        Series5.Legend = "Legend1"
        Series5.Name = "Series1"
        Me.chart_Locations.Series.Add(Series5)
        Me.chart_Locations.Size = New System.Drawing.Size(888, 482)
        Me.chart_Locations.TabIndex = 12
        Me.chart_Locations.Text = "Chart1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 552)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fehlerliste"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgv_Result, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.chart_Locations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_sca_serno As TextBox
    Friend WithEvents txt_sca_matcode As TextBox
    Friend WithEvents txt_ncl_location As TextBox
    Friend WithEvents txt_ncl_comment As TextBox
    Friend WithEvents txt_sca_comment As TextBox
    Friend WithEvents cmd_Suchen As Button
    Friend WithEvents cmb_opr_operationshort As ComboBox
    Friend WithEvents date_startDate As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents date_endDate As DateTimePicker
    Friend WithEvents txt_ncl_groupCode As TextBox
    Friend WithEvents txt_ncl_componentCode As TextBox
    Friend WithEvents cmb_rtn_productline As ComboBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents prg_Load As ToolStripProgressBar
    Friend WithEvents tip_Status As ToolStripStatusLabel
    Friend WithEvents cmd_Reset As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cmd_Auswertung As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents chart_Locations As DataVisualization.Charting.Chart
    Friend WithEvents dgv_Result As DataGridView
End Class
