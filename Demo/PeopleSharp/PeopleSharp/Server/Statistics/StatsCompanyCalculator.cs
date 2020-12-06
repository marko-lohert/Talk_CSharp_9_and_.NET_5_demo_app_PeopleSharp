using PeopleSharp.Server.Controllers;
using PeopleSharp.Shared;
using PeopleSharp.Shared.Statistics;
using System.Collections.Generic;
using System.Linq;

namespace PeopleSharp.Server.Statistics
{
    public class StatsCompanyCalculator : StatsEmployeesCalculator
    {
        public override StatsCompany CalculateStats()
        {
            DepartmentsController departmentsController = new();
            List<Department>? allDepartments = departmentsController.GetAllDepartments()?.ToList();

            int countDepartments = allDepartments?.Count ?? 0;

            // todo Count all managers (replace mocked data).
            // Mock data
            int countManagers = 4;

            StatsEmployeesCalculator statsEmployeesCalculator = new();
            StatsEmployees statsEmployees = statsEmployeesCalculator.CalculateStats();

            return new(countDepartments, countManagers, statsEmployees.CountEmployees, statsEmployees.AvgVacationDays, statsEmployees.DiffJobTitles);
        }
    }
}
