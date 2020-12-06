using PeopleSharp.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PeopleSharp.Client.Pages
{
    public partial class EmployeeInfo
    {
        [CascadingParameter]
        Employee? SelectedEmployee { get; set; }
        bool IsSelectedEmployeeChanged { get; set; }

        void RecalculateVacationDays()
        {
            if (SelectedEmployee == null)
                return;

            VacationDaysCalculator calculator = new();
            int newVacationDays = calculator.Calculate(SelectedEmployee);

            if (newVacationDays != SelectedEmployee.VacationDays)
            {
                IsSelectedEmployeeChanged = true;

                // Use with to create a new employee record based on selected employee, but with an updated number of vacation days.
                // In the talk, show equality and reference equality in the case of records.
                int oldVacationDays = SelectedEmployee.VacationDays;

                Employee newEmployee = SelectedEmployee with { VacationDays = newVacationDays };

                bool equalNewAndSelectedEmployee = newEmployee.Equals(SelectedEmployee);
                bool referenceEqualNewAndSelectedEmployee = ReferenceEquals(newEmployee, SelectedEmployee);

                Employee newEmployeeOldVacationDays = newEmployee with { VacationDays = oldVacationDays };

                bool equlOldVacationDays = newEmployeeOldVacationDays.Equals(SelectedEmployee);
                bool referenceEqualOldVacationDays = ReferenceEquals(newEmployeeOldVacationDays, SelectedEmployee);

                SelectedEmployee = newEmployee;
            }
        }

        protected override void OnParametersSet()
        {
            IsSelectedEmployeeChanged = false;
        }

        async Task UpdateEmployeeAsync()
        {
            if (SelectedEmployee == null || !IsSelectedEmployeeChanged)
                return;

            await Http.PutAsJsonAsync<Employee>("api/Employees/UpdateEmployee", SelectedEmployee);
        }
    }
}
