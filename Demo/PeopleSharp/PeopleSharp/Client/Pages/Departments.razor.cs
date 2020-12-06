using PeopleSharp.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PeopleSharp.Client.Pages
{
    public partial class Departments
    {
        List<Department>? ListDepartments { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ListDepartments = await Http.GetFromJsonAsync<List<Department>>("api/Departments/GetAllDepartments");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
