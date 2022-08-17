using System;
using System.Collections.Generic;

namespace RegionSyd.Common.Models
{
    public class RoomDTO
    {
        public int RoomId { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Bed> Beds { get; set; }
    }
}
