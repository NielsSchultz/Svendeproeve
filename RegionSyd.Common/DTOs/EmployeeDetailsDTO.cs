using System;
using System.Collections.Generic;
using RegionSyd.Repositories.Entities;

namespace RegionSyd.Common.DTOs
{
    public class EmployeeDetailsDTO
    {
        public EmployeeDTO employee { get; set; } = null!;
        public List<EmployeeTypeDTO> employeeTypes { get; set; } = null!;
    }
}
