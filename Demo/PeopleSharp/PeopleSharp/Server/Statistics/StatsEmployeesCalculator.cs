using PeopleSharp.Server.Controllers;
using PeopleSharp.Shared;
using PeopleSharp.Shared.Statistics;
using System.Collections.Generic;
using System.Linq;

namespace PeopleSharp.Server.Statistics
{
    public class StatsEmployeesCalculator
    {
        public virtual StatsEmployees CalculateStats()
        {
            int countEmployees;
            decimal avgVacationDays;
            int diffJobTitles;

            EmployeesController employeesController = new();
            List<Employee>? allEmployees = employeesController.GetAllEmployees()?.ToList();

            countEmployees = allEmployees?.Count ?? 0;
            avgVacationDays = (decimal)(allEmployees?.Average(x => x.VacationDays) ?? 0);
            diffJobTitles = allEmployees?.SelectMany(x => x.JobTitle)?.Distinct()?.Count() ?? 0;

            return new(countEmployees, avgVacationDays, diffJobTitles);
        }
    }
}
