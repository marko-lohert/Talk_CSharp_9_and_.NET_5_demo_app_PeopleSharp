using System;

namespace PeopleSharp.Shared
{
    public record Employee
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string JobTitle { get; init; }
        public DateTime DateOfEmployment { get; init; }
        public Department? Department { get; init; }
        public Manager? DirectManager {get; init; }
        public int VacationDays { get; init; }
    }
}
