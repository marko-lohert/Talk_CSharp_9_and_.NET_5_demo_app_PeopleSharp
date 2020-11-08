using HRSharp.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HRSharp.Client.Pages
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
            nint newVacationDays = calculator.Calculate(SelectedEmployee);

            if (newVacationDays != SelectedEmployee.VacationDays)
            {
                IsSelectedEmployeeChanged = true;
                SelectedEmployee.VacationDays = (int)newVacationDays;
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
