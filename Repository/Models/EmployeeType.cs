using System;
using System.Collections.Generic;

namespace RegionSyd.Repository.Models
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public int EmployeeTypeId { get; set; }
        public int? EmployeeTypeName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
