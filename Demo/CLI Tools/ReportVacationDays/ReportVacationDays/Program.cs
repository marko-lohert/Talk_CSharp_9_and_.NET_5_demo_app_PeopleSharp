using System;
using System.Data;
using Microsoft.Data.SqlClient;

using DataTable dataTable = GetData();
            
string reportFileName = $"C:\\People#\\Report Vacation Days {DateTime.Now:yyyy-MM-dd HH.mm}.xlsx";
DataTableToExcel.DataTableToExcel.ExportToExcel(reportFileName, WworkBookName: "People#", dataTable);

DataTable GetData()
{
    const string selectCmd = @"SELECT LastName, FirstName, VacationDays
                                           FROM Employee
                                           ORDER BY LastName, FirstName";
    using SqlConnection connection = new SqlConnection(ReportVacationDays.Properties.Resources.ConnectionString);
    using SqlDataAdapter adapter = new SqlDataAdapter();
    adapter.SelectCommand = new SqlCommand(selectCmd, connection);
    DataTable dataTable = new DataTable();
    adapter.Fill(dataTable);
    return dataTable;
}