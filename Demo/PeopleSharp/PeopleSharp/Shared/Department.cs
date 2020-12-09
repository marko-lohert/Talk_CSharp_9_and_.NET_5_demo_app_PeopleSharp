using System.Collections.Generic;

namespace PeopleSharp.Shared
{
    public record Department(string DepartmentName, List<Department>? Subdepartments, List<Employee>? EmployeesDirectlyInDepartment, Manager HeadOfDepartment);
}
