using PeopleSharp.Shared.Statistics;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PeopleSharp.Client.Pages
{
    public partial class CompanyStatistics
    {
        StatsCompany? Stats { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Stats = await Http.GetFromJsonAsync<StatsCompany>("api/Statistics/GetStatsCompany");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
