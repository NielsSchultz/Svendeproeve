using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;

namespace RegionSyd.Common.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        public int TreatmentPlaceId { get; set; }
        public string DepartmentName { get; set; } = null!;
    }
}
