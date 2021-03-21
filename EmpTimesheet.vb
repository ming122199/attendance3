﻿Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class EmpTimesheet

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)


    End Sub

    Private Sub prcDisplayTimesheet()

        dataAttendance = New DataTable()

        sqlAttendanceAdapter = New MySqlDataAdapter
        command.Connection = conAttendanceSystem
        Try
            With command
                .Parameters.Clear()
                .CommandText = "prcDisplayTotalHours"
                .CommandType = CommandType.StoredProcedure
                sqlAttendanceAdapter.SelectCommand = command
                dataAttendance.Clear()
                sqlAttendanceAdapter.Fill(dataAttendance)



                If dataAttendance.Rows.Count > 0 Then
                    DataGridView1.RowCount = dataAttendance.Rows.Count

                    row = 0
                    While Not dataAttendance.Rows.Count - 1 < row
                        With DataGridView1
                            .Rows(row).Cells(0).Value = dataAttendance.Rows(row).Item("id").ToString
                            .Rows(row).Cells(1).Value = dataAttendance.Rows(row).Item("f_name").ToString
                            .Rows(row).Cells(2).Value = dataAttendance.Rows(row).Item("l_name").ToString

                            .Rows(row).Cells(3).Value = dataAttendance.Rows(row).Item("date").ToString
                            .Rows(row).Cells(4).Value = dataAttendance.Rows(row).Item("time_in").ToString
                            .Rows(row).Cells(5).Value = dataAttendance.Rows(row).Item("time_out").ToString
                            .Rows(row).Cells(6).Value = dataAttendance.Rows(row).Item("total_hours").ToString


                        End With
                        row = row + 1
                    End While


                Else

                End If
                sqlAttendanceAdapter.Dispose()
                dataAttendance.Dispose()
            End With
        Catch ex As Exception

        End Try
        Me.Refresh()
    End Sub

    Private Sub EmpTimesheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkDatabaseConnection()
        prcDisplayTimesheet()


        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy/MM/dd"

        ComboBox1.Items.Clear()

        Try
            dataAttendance = New DataTable()

            sqlAttendanceAdapter = New MySqlDataAdapter
            command.Connection = conAttendanceSystem
            With command
                .Parameters.Clear()
                .CommandText = "prcDisplayEmployee"
                .CommandType = CommandType.StoredProcedure
                sqlAttendanceAdapter.SelectCommand = command
                dataAttendance.Clear()
                sqlAttendanceAdapter.Fill(dataAttendance)



            End With


            sqlAttendanceAdapter.Fill(dataAttendance)
            ComboBox1.DataSource = dataAttendance
            ComboBox1.DisplayMember = "emp_id"
            ComboBox1.ValueMember = "emp_id"





        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        prcDisplayTimesheet()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Dispose()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)


    End Sub
    Private Sub calculateHours()
        Dim total As Integer
        Dim dayTotal As Integer

        For index As Integer = 0 To DataGridView1.RowCount - 1
            ' dayTotal = DataGridView1.Rows(index).Cells[4].Value 
        Next

    End Sub
    'Private Sub Button3_Click(sender As Object, e As EventArgs)

    '    Dim date1 As String = DateTimePicker1.Value.ToString("yyyy/MM/dd")
    '    Dim date2 As String = DateTimePicker2.Value.ToString("yyyy/MM/dd")

    '    dataAttendance = New DataTable()
    '    sqlAttendanceAdapter = New MySqlDataAdapter
    '    command.Connection = conAttendanceSystem
    '    Dim ds As New DataSet

    '    Dim i, j As Integer

    '    Dim xlApp As EXCEL.Application
    '    Dim xlWorkBook As EXCEL.Workbook
    '    Dim xlWorkSheet As EXCEL.Worksheet
    '    Dim misValue As Object = System.Reflection.Missing.Value

    '    xlApp = New EXCEL.Application
    '    xlWorkBook = xlApp.Workbooks.Add(misValue)
    '    xlWorkSheet = xlWorkBook.Sheets("sheet1")

    '    With command
    '        .Parameters.Clear()
    '        .CommandText = "prcFilterTimesheet"
    '        .CommandType = CommandType.StoredProcedure
    '        .Parameters.AddWithValue("date1", date1)
    '        .Parameters.AddWithValue("date2", date2)
    '        .Parameters.AddWithValue("id", ComboBox1.Text)

    '        sqlAttendanceAdapter.SelectCommand = command
    '        sqlAttendanceAdapter.Fill(ds)

    '        For i = 0 To ds.Tables(0).Rows.Count - 1
    '            For j = 0 To ds.Tables(0).Columns.Count - 1
    '                xlWorkSheet.Cells(i + 1, j + 1) =
    '                ds.Tables(0).Rows(i).Item(j)
    '            Next
    '        Next

    '    End With



    '    Try
    '        Dim fbd As New FolderBrowserDialog

    '        If fbd.ShowDialog() = vbOK Then

    '            xlWorkSheet.SaveAs(fbd.SelectedPath & "\" & ComboBox1.SelectedValue & "AttendanceRecord.xlsx")
    '            xlWorkBook.Close()
    '            xlApp.Quit()

    '            releaseObject(xlApp)
    '            releaseObject(xlWorkBook)
    '            releaseObject(xlWorkSheet)

    '            MessageBox.Show("Succcessfully exported to Excel file!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click


        Dim date1 As String = DateTimePicker1.Value.ToString("yyyy/MM/dd")

        Dim date2 As String = DateTimePicker2.Value.ToString("yyyy/MM/dd")




        If CheckBox1.Checked = True Then
                    filterbydate()
                Else


                    Dim DA = New DataTable()
                    Dim DataTable1 = New DataTable()
                    Dim sqlAdapter = New MySqlDataAdapter

                    Using con As MySqlConnection = New MySqlConnection("server=localhost;user id=root;password=mysql;database=db_attendance")
                        Using cmd As MySqlCommand = New MySqlCommand("", con)

                            cmd.CommandText = "prcFilterSummaryHours"
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("date1", date1)
                            cmd.Parameters.AddWithValue("date2", date2)
                            cmd.Parameters.AddWithValue("i", ComboBox1.Text)


                            sqlAdapter.SelectCommand = cmd
                            DA.Clear()
                            sqlAdapter.Fill(DA)





                            If DA.Rows.Count > 0 Then
                                DataGridView1.RowCount = DA.Rows.Count

                                row = 0
                                While Not DA.Rows.Count - 1 < row
                                    With DataGridView1
                                        .Rows(row).Cells(0).Value = DA.Rows(row).Item("id").ToString
                                        .Rows(row).Cells(1).Value = DA.Rows(row).Item("f_name").ToString
                                        .Rows(row).Cells(2).Value = DA.Rows(row).Item("l_name").ToString

                                        .Rows(row).Cells(3).Value = DA.Rows(row).Item("date").ToString
                                        .Rows(row).Cells(4).Value = DA.Rows(row).Item("time_in").ToString
                                        .Rows(row).Cells(5).Value = DA.Rows(row).Item("time_out").ToString
                                        .Rows(row).Cells(6).Value = DA.Rows(row).Item("total_hours").ToString



                                    End With
                                    row = row + 1
                                End While
                            Else
                                DataGridView1.Rows.Clear()
                                MessageBox.Show("No record found...")

                            End If



                            DA.Dispose()
                            sqlAdapter.Dispose()

                        End Using
                    End Using
                End If




    End Sub

    Private Sub filterbydate()
        Dim date1 As String = DateTimePicker1.Value.ToString("yyyy/MM/dd")

        Dim date2 As String = DateTimePicker2.Value.ToString("yyyy/MM/dd")



        Dim DA = New DataTable()
        Dim DataTable1 = New DataTable()
        Dim sqlAdapter = New MySqlDataAdapter

        Using con As MySqlConnection = New MySqlConnection("server=localhost;user id=root;password=mysql;database=db_attendance")
            Using cmd As MySqlCommand = New MySqlCommand("", con)

                cmd.CommandText = "prcFilterUserByDate"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("date1", date1)


                sqlAdapter.SelectCommand = cmd
                DA.Clear()
                sqlAdapter.Fill(DA)





                If DA.Rows.Count > 0 Then
                    DataGridView1.RowCount = DA.Rows.Count

                    row = 0
                    While Not DA.Rows.Count - 1 < row
                        With DataGridView1
                            .Rows(row).Cells(0).Value = DA.Rows(row).Item("id").ToString
                            .Rows(row).Cells(1).Value = DA.Rows(row).Item("f_name").ToString
                            .Rows(row).Cells(2).Value = DA.Rows(row).Item("l_name").ToString

                            .Rows(row).Cells(3).Value = DA.Rows(row).Item("date").ToString
                            .Rows(row).Cells(4).Value = DA.Rows(row).Item("time_in").ToString
                            .Rows(row).Cells(5).Value = DA.Rows(row).Item("time_out").ToString
                            .Rows(row).Cells(6).Value = DA.Rows(row).Item("total_hours").ToString



                        End With
                        row = row + 1
                    End While
                Else
                    DataGridView1.Rows.Clear()
                    MessageBox.Show("No record found...")

                End If



                DA.Dispose()
                sqlAdapter.Dispose()

            End Using
        End Using

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim date1 As String = DateTimePicker1.Value.ToString("yyyy/MM/dd")

        Dim date2 As String = DateTimePicker2.Value.ToString("yyyy/MM/dd")


        Dim dt As New DataTable
        With dt
            .Columns.Add("ID")
            .Columns.Add("Firstname")
            .Columns.Add("Lastname")
            .Columns.Add("Date")
            .Columns.Add("TimeIN")
            .Columns.Add("TimeOUT")
            .Columns.Add("TotalHours")


        End With

        For Each dgr As DataGridViewRow In Me.DataGridView1.Rows
            dt.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value, dgr.Cells(4).Value, dgr.Cells(5).Value, dgr.Cells(6).Value)
        Next
        Dim report1 As ReportDocument
        report1 = New CrystalReport4
        report1.SetDataSource(dt)
        report.CrystalReportViewer1.ReportSource = report1

        Dim TxtDate1, TxtDate2 As TextObject


        If CheckBox1.Checked = True Then
            TxtDate1 = report1.ReportDefinition.ReportObjects("Text6")
            TxtDate1.Text = date1
        Else

            TxtDate1 = report1.ReportDefinition.ReportObjects("Text4")
            TxtDate1.Text = date1
            TxtDate2 = report1.ReportDefinition.ReportObjects("Text6")
            TxtDate2.Text = date2

        End If




        report.ShowDialog()
        report.Dispose()
    End Sub



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then

            Label1.Visible = False
            ComboBox1.Visible = False
            DateTimePicker2.Visible = False


        Else

            Label1.Visible = True
            ComboBox1.Visible = True
            DateTimePicker2.Visible = True


        End If
    End Sub
End Class