using System;
using System.Collections.Generic;

namespace RegionSyd.Common.DTOs
{
    public class RoomDTO
    {
        public int RoomId { get; set; }
        public int DepartmentId { get; set; }
        //DepartmentName 

        public ICollection<BedDTO> Beds { get; set; }
    }
}
