Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient
Public Class actlog


    Private Sub actlog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkDatabaseConnection()



        Try
            Dim report As New CrystalReportLog
            report.Load()

            With command
                .Parameters.Clear()
                .CommandText = "tbl_actlog"
                .CommandType = CommandType.TableDirect


                sqlAttendanceAdapter.SelectCommand = command
                dataAttendance.Clear()
                sqlAttendanceAdapter.Fill(dataAttendance)
            End With

            report.SetDataSource(dataAttendance)

            'Dim TxtDate1, TxtDate2 As TextObject
            'TxtDate1 = report.ReportDefinition.ReportObjects("TextDate1")
            'TxtDate1.Text = date1
            'TxtDate2 = report.ReportDefinition.ReportObjects("TextDate2")
            'TxtDate2.Text = date2






            CrystalReportViewer1.ReportSource = report
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()

        Catch ex As Exception

        End Try
    End Sub
End Class