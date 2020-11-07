﻿using HRSharp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HRSharp.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public IEnumerable<Department> GetAllDepartments()
        {
            // todo implement GetAllDepartments()

            // Mock data
            Manager managerJohnDoe = new Manager
            {
                FirstName = "John",
                LastName = "Doe"
            };
            Manager managerJaneDoe = new Manager()
            {
                FirstName = "Jane",
                LastName = "Doe"
            };
            Manager managerJakeSmith = new Manager()
            {
                FirstName = "Jake",
                LastName = "Smith"
            };

            return new List<Department>
            {
                new Department()
                {
                    DepartmentName = "IoT",
                    HeadOfDepartment = managerJohnDoe,
                    EmployeesDirectlyInDepartment = new List<Employee>()
                    {
                    },
                    Subdepartments = null
                },
                new Department()
                {
                    DepartmentName = "QA",
                    HeadOfDepartment = managerJaneDoe,
                    EmployeesDirectlyInDepartment = new List<Employee>()
                    {
                    },
                    Subdepartments = null
                },
                new Department()
                {
                    DepartmentName = "RnD",
                    HeadOfDepartment = managerJakeSmith,
                    EmployeesDirectlyInDepartment = new List<Employee>()
                    {
                    },
                    Subdepartments = null
                }
            };
        }
    }
}
