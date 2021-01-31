using System;
using System.Runtime.CompilerServices;

namespace PeopleSharp.Shared
{
    public class VacationDaysCalculator
    {
        /// <summary>
        /// Calculate a number of vacation days for a given employee.
        /// </summary>
        /// <param name="employee">Employee whose vacation days will be calculated.</param>
        /// <returns>A number of vacation days.</returns>
        public int Calculate(Employee employee)
        {
            int vacationDays = 20;

            int yearsWithCompany = CalculateYearsWithCompany(employee);

            vacationDays += yearsWithCompany switch
            {
                > 1 and <= 4    => 1,
                > 4 and <= 7    => 3,
                > 7 and <= 10   => 4,
                > 10            => 7
            };

            return vacationDays;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static int CalculateYearsWithCompany(Employee employee)
            {
                if (employee.DateOfEmployment < DateTime.Now)
                    return (int)(DateTime.Now - employee.DateOfEmployment).TotalDays / 365;
                else
                    return 0;
            }
        }        
    }
}
