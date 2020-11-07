using System;

namespace HRSharp.Shared
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public Department? Department { get; set; }
        public Manager? DirectManager {get;set;}
        public int VacationDays { get; set; }
    }
}
