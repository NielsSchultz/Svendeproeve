using System;
using System.Collections.Generic;

namespace RegionSyd.Common.DTOs
{
    public class EmployeeDTO
    {        
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public int EmployeeTypeId { get; set; }
        //EmployeeTypeName
        public string EmployeeTypeName { get; set; } = null!;
        public int DepartmentId { get; set; }
        //DepartmentName
        public string DepartmentName { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public string EmployeeCode { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
