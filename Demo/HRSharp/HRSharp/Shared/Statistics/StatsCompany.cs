namespace HRSharp.Shared.Statistics
{
    public class StatsCompany : StatsEmployees
    {
        public StatsCompany(int countDepartments, int countManagers, int countEmployees, decimal avgVacationDays, int diffJobTitles) : base(countEmployees, avgVacationDays, diffJobTitles)
        {
            CountDepartments = countDepartments;
            CountManagers = countManagers;
        }

        public int CountDepartments { get; set; }
        public int CountManagers { get; set; }
    }
}
