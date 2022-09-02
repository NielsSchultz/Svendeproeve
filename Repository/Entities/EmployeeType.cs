using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public int EmployeeTypeId { get; set; }
        public string EmployeeTypeName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
