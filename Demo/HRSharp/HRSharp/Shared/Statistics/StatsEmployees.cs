namespace HRSharp.Shared.Statistics
{
    public class StatsEmployees
    {
        public int CountEmployees { get; set; }
        public decimal AvgVacationDays { get; set; }
        public int DiffJobTitles { get; set; }

        public StatsEmployees(int countEmployees, decimal avgVacationDays, int diffJobTitles)
        {
            CountEmployees = countEmployees;
            AvgVacationDays = avgVacationDays;
            DiffJobTitles = diffJobTitles;
        }
        
        public void Deconstructor(out int countEmployees, out decimal avgVacationDays, out int diffJobTitles)
        {
            countEmployees = CountEmployees;
            avgVacationDays = AvgVacationDays;
            diffJobTitles = DiffJobTitles;
        }

        public override bool Equals(object? o)
        {
            return o != null &&
                   o is StatsEmployees other &&
                   CountEmployees.Equals(other.CountEmployees) &&
                   AvgVacationDays.Equals(other.AvgVacationDays) &&
                   DiffJobTitles.Equals(other.DiffJobTitles);
        }

        public override int GetHashCode()
        {
            return CountEmployees.GetHashCode() + AvgVacationDays.GetHashCode() + DiffJobTitles.GetHashCode();
        }

        public static bool operator==(StatsEmployees left, StatsEmployees right)
        {
            if (left is object)
                return left.Equals(right);
            else
                return right is null;
        }

        public static bool operator!=(StatsEmployees left, StatsEmployees right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"A number of employees: {CountEmployees}. An average number of vacation days: {AvgVacationDays}. A number of different job titles: {DiffJobTitles}";
        }
    }
}