using System;
using System.Data;
using System.Data.SqlClient;

namespace ReportVacationDays
{
    class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(Properties.Resources.ConnectionString);
            using SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("SELECT LastName, FirstName, VacationDays FROM Employee ORDER BY LastName, FirstName", connection);
            using DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            string reportFileName = $"C:\\HR #\\Report Vacation Days {DateTime.Now:yyyy-MM-dd hh.mm}.xlsx";
            DataTableToExcel.DataTableToExcel.ExportToExcel(reportFileName, WworkBookName: "HR #", dataTable);
        }
    }
}