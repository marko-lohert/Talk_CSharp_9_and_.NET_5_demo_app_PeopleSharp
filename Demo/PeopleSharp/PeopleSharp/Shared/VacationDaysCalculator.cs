using System;

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
                        
            if (yearsWithCompany > 1 && yearsWithCompany <= 4)
                vacationDays++;
            else if (yearsWithCompany > 4 && yearsWithCompany <= 7)
                vacationDays += 3;
            else if (yearsWithCompany > 7 && yearsWithCompany < 10)
                vacationDays += 4;
            else
                vacationDays += 7;

            return vacationDays;

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
