using System.Collections.Generic;

namespace PeopleSharp.Shared
{
    public class Department
    {
        public string DepartmentName { get; set; }
        public List<Department>? Subdepartments { get; set; }
        /// <summary>
        /// Employees that work directly in this department, and not in some of subdepartments.
        /// </summary>
        public List<Employee>? EmployeesDirectlyInDepartment { get; set; }
        /// <summary>
        /// Manager that leads this department.
        /// </summary>
        public Manager HeadOfDepartment { get; set; }
    }
}
