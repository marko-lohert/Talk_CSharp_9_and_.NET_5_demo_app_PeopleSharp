using HRSharp.Server.Statistics;
using HRSharp.Shared.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace HRSharp.Server.Controllers
{
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        [HttpGet("[action]")]
        public StatsEmployees GetStatsEmployees()
        {
            StatsEmployeesCalculator calc = new StatsEmployeesCalculator();
            
            return calc.CalculateStats();
        }

        [HttpGet("[action]")]
        public StatsCompany GetStatsCompany()
        {
            StatsCompanyCalculator calc = new StatsCompanyCalculator();

            return calc.CalculateStatsCompany();
        }
    }
}
