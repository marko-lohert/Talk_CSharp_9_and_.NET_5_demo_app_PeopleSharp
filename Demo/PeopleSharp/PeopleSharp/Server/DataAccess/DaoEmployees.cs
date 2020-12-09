using PeopleSharp.Shared;
using System;
using System.Collections.Generic;

namespace PeopleSharp.Server.DataAccess
{
    public class DaoEmployees
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            // todo implement GetAllEmployees()

            // Mock data
            Manager ceo = new Manager
            {
                FirstName = "Jack",
                LastName = "Amstrong",
                JobTitle = "CEO",
                DateOfEmployment = new DateTime(2000, 07, 01),
                DirectManager = null,
                Department = null,
                VacationDays = 25
            };
            Manager managerJohnDoe = new Manager
            {
                FirstName = "John",
                LastName = "Doe",
                JobTitle = "Head of IoT",
                Department = null,
                DateOfEmployment = new DateTime(2001, 04, 01),
                DirectManager = ceo,
                VacationDays = 23
            };
            Manager managerJaneDoe = new Manager()
            {
                FirstName = "Jane",
                LastName = "Doe",
                JobTitle = "Head of QA",
                Department = null,
                DateOfEmployment = new DateTime(2002, 05, 01),
                DirectManager = ceo,
                VacationDays = 23
            };
            Manager managerJakeSmith = new Manager()
            {
                FirstName = "Jake",
                LastName = "Smith",
                JobTitle = "Head of RnD",
                Department = null,
                DateOfEmployment = new DateTime(2003, 06, 01),
                DirectManager = ceo,
                VacationDays = 23
            };

            return new List<Employee>
            {
                new Employee()
                {
                    FirstName = "John",
                    LastName = "Smith",
                    JobTitle = "Developer",
                    Department = null, // IoT
                    DateOfEmployment = new DateTime(2010,01,01),
                    DirectManager = managerJohnDoe,
                    VacationDays = 25
                },
                new Employee()
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    JobTitle = "Developer",
                    Department = null, // RnD
                    DateOfEmployment = new DateTime(2000,02,01),
                    DirectManager = managerJaneDoe,
                    VacationDays = 27
                },
                new Employee()
                {
                    FirstName = "Jack",
                    LastName = "Hunter",
                    JobTitle = "Tester",
                    Department = null, // QA
                    DateOfEmployment = new DateTime(2010,03,01),
                    DirectManager = managerJaneDoe,
                    VacationDays = 23
                },
                managerJohnDoe,
                managerJaneDoe,
                managerJakeSmith,
                ceo
            };
        }

        public void UpdateEmployee()
        {
            // todo implement UpdateEmployee()
        }
    }
}
