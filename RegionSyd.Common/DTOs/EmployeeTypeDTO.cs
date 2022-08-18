using System;
using System.Collections.Generic;
using RegionSyd.Repositories.Entities;

namespace RegionSyd.Common.DTOs
{
    public class EmployeeTypeDTO
    {
        public int EmployeeTypeId { get; set; }
        public string EmployeeTypeName { get; set; } = null!;
    }
}
