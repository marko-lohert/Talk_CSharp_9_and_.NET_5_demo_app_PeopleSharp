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

            VacationDaysCalculator calculator = new VacationDaysCalculator();
            int newVacationDays = calculator.Calculate(SelectedEmployee);

            if (newVacationDays != SelectedEmployee.VacationDays)
            {
                IsSelectedEmployeeChanged = true;
                SelectedEmployee.VacationDays = newVacationDays;
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
