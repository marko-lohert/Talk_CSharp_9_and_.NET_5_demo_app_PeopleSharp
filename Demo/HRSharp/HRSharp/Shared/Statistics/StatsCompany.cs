namespace HRSharp.Shared.Statistics
{
    public record StatsCompany(int CountDepartments, int CountManagers, int CountEmployees, decimal AvgVacationDays, int DiffJobTitles) : StatsEmployees(CountEmployees, AvgVacationDays, DiffJobTitles);
}
