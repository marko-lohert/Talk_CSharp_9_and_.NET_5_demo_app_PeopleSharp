using System.Collections.Generic;

namespace HRSharp.Shared
{
    public record Department (string DepartmentName, List<Department>? Subdepartments, List<Employee>? EmployeesDirectlyInDepartment, Manager HeadOfDepartment);
}
