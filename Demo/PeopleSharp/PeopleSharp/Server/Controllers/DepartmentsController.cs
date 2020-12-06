using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleSharp.Server.DataAccess;
using PeopleSharp.Shared;
using System.Collections.Generic;

namespace PeopleSharp.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public IEnumerable<Department> GetAllDepartments()
        {
            DaoDepartments daoDepartments = new DaoDepartments();
            return daoDepartments.GetAllDepartments();
        }
    }
}
