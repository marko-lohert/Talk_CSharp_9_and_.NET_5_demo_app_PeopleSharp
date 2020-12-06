using PeopleSharp.Shared;
using System.Collections.Generic;
using System.Data;

namespace PeopleSharp.Server.DataAccess
{
    public class DaoDepartments
    {
        public IEnumerable<Department> GetAllDepartments()
        {
            DataTable dtAllDepartments = GetAllDepartmentsFromDB();

            List<Department> listAllDepartments = new List<Department>();

            foreach (DataRow row in dtAllDepartments.Rows)
            {
                var (departmentName, subdepartments, employeesDirectlyInDepartment, headOfDepartment) = Parse(row);

                Department department = new Department
                {
                    DepartmentName = departmentName,
                    HeadOfDepartment = headOfDepartment,
                    Subdepartments = subdepartments,
                    EmployeesDirectlyInDepartment = employeesDirectlyInDepartment
                };

                listAllDepartments.Add(department);
            }

            return listAllDepartments;
        }

        private Manager ParseManager(DataRow row)
        {
            if (row == null)
                return null;

            return new Manager()
            {
                FirstName = SafeGetColumnValueString(ColumnNames.FirstName, row),
                LastName = SafeGetColumnValueString(ColumnNames.LastName, row),
                JobTitle = SafeGetColumnValueString(ColumnNames.JobTitle, row),
            };
        }

        private (string departmentName, List<Department>? subdepartments, List<Employee>? employeesDirectlyInDepartment, Manager headOfDepartment) Parse(DataRow row)
        {
            if (row == null)
                return (null, null, null, null);

            // Mock data
            if (currentMockData > 2)
                currentMockData = 0;

            switch (currentMockData)
            {
                case 0:
                    {
                        Manager managerJohnDoe = new Manager
                        {
                            FirstName = "John",
                            LastName = "Doe"
                        };
                        currentMockData++;
                        return ("IoT", null, null, managerJohnDoe);
                    }
                case 1:
                    {
                        Manager managerJaneDoe = new Manager()
                        {
                            FirstName = "Jane",
                            LastName = "Doe"
                        };
                        currentMockData++;
                        return ("QA", null, null, managerJaneDoe);
                    }
                case 2:
                    {
                        Manager managerJakeSmith = new Manager()
                        {
                            FirstName = "Jake",
                            LastName = "Smith"
                        };
                        currentMockData++;
                        return ("RnD", null, null, managerJakeSmith);
                    }
                default:
                    {
                        currentMockData = 0;
                        return ("Department", null, null, null);
                    }
            };
        }
        static int currentMockData = 0;

        private string SafeGetColumnValueString(string columnName, DataRow row)
        {
            if (string.IsNullOrWhiteSpace(columnName) || row == null || !row.Table.Columns.Contains(columnName) || row.IsNull(columnName))
                return null;

            return (string)row[columnName];
        }

        private struct ColumnNames
        {
            public static string FirstName => "FirstName";
            public static string LastName => "LastName";
            public static string JobTitle => "JobTitle";
            public static string DepartmentName => "DepartmentName";
        }

        public DataTable GetAllDepartmentsFromDB()
        {
            // todo Implement
            DataTable dtMockData = new DataTable();
            for (int i = 0; i < 3; i++)
                dtMockData.Rows.Add(dtMockData.NewRow());
            
            return dtMockData;
        }
    }
}
