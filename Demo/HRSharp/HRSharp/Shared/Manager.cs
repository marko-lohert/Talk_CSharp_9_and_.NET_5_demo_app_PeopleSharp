using System.Collections.Generic;

namespace HRSharp.Shared
{
    public class Manager : Employee
    {
        /// <summary>
        /// This manager is a head of the following departments (we support a case when a single manager is a head of a two or more departments).
        /// </summary>
        public List<Department>? DepartmentHead { get; set; }
    }
}
