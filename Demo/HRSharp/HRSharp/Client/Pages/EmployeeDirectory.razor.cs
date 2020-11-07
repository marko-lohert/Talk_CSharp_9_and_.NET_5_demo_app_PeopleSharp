using HRSharp.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HRSharp.Client.Pages
{
    public partial class EmployeeDirectory
    {
        List<Employee>? ListAllEmployees { get; set; }
        Employee? SelectedEmployee { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ListAllEmployees = await Http.GetFromJsonAsync<List<Employee>>("api/Employees/GetAllEmployees");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
