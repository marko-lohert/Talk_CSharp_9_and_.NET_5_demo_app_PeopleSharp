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
        public StatsCompany CalculateStatsCompany()
        {
            DepartmentsController departmentsController = new DepartmentsController();
            List<Department>? allDepartments = departmentsController.GetAllDepartments()?.ToList();

            int countDepartments = allDepartments?.Count ?? 0;

            DaoManager daoManager = new DaoManager();

            StatsEmployeesCalculator statsEmployeesCalculator = new StatsEmployeesCalculator();
            StatsEmployees statsEmployees = statsEmployeesCalculator.CalculateStats();

            return new StatsCompany(countDepartments, daoManager.CountAllManagers(), statsEmployees.CountEmployees, statsEmployees.AvgVacationDays, statsEmployees.DiffJobTitles);
        }
    }
}
