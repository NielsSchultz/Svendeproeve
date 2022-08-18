using System;
using System.Collections.Generic;
using RegionSyd.Repositories.Entities;

namespace RegionSyd.Common.DTOs
{
    public class EmployeeDTO
    {        
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeeCode { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Birthday { get; set; }
    }
}
