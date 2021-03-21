Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient
Public Class report
    Private Sub report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkDatabaseConnection()

        'Dim date1 As String = EmpTimesheet.DateTimePicker1.Value.ToString("yyyy/MM/dd")

        'Dim date2 As String = EmpTimesheet.DateTimePicker2.Value.ToString("yyyy/MM/dd")



        'Try
        '    Dim report As New CrystalReportUser3
        '    report.Load()

        '    With command
        '        .Parameters.Clear()
        '        .CommandText = "prcTimeReport"
        '        .CommandType = CommandType.StoredProcedure
        '        .Parameters.AddWithValue("date1", date1)
        '        .Parameters.AddWithValue("date2", date2)
        '        .Parameters.Clear()


        '        sqlAttendanceAdapter.SelectCommand = command
        '        dataAttendance.Clear()
        '        sqlAttendanceAdapter.Fill(dataAttendance)
        '    End With

        '    report.SetDataSource(dataAttendance)

        '    Dim TxtDate1, TxtDate2 As TextObject
        '    TxtDate1 = report.ReportDefinition.ReportObjects("TextDate1")
        '    TxtDate1.Text = date1
        '    TxtDate2 = report.ReportDefinition.ReportObjects("TextDate2")
        '    TxtDate2.Text = date2






        '    CrystalReportViewer1.ReportSource = report
        '    CrystalReportViewer1.RefreshReport()
        '    CrystalReportViewer1.Show()

        'Catch ex As Exception

        'End Try


    End Sub



    Private Sub CrystalReportViewer1_Load_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub CrystalReportUser1_InitReport(sender As Object, e As EventArgs)

    End Sub

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load


    End Sub

    Private Sub CrystalReportUser31_InitReport(sender As Object, e As EventArgs)



    End Sub
End Class