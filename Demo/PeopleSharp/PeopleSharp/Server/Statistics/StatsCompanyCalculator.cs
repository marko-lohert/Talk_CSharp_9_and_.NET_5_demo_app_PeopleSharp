using PeopleSharp.Server.Controllers;
using PeopleSharp.Server.DataAccess;
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

            DaoManager daoManager = new();

            StatsEmployeesCalculator statsEmployeesCalculator = new();
            StatsEmployees statsEmployees = statsEmployeesCalculator.CalculateStats();

            return new(countDepartments, daoManager.CountAllManagers(), statsEmployees.CountEmployees, statsEmployees.AvgVacationDays, statsEmployees.DiffJobTitles);
        }
    }
}
