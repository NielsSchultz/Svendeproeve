using System;
using System.Collections.Generic;

namespace RegionSyd.Common.DTOs
{
    public class RoomDetailsDTO
    {
        public RoomDTO room { get; set; } = null!;

        public List<BedDTO> beds = new List<BedDTO>();
    }
}
