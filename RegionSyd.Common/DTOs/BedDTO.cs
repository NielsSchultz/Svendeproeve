using System;
using System.Collections.Generic;

namespace RegionSyd.Common.DTOs
{
    public class BedDTO
    {        
        public int BedId { get; set; }
        public int? RoomId { get; set; }
        public bool IsOccupied { get; set; }
    }
}
