using System;
using System.Collections.Generic;
using RegionSyd.Repositories.Entities;

namespace RegionSyd.Common.DTOs
{
    public class AlarmDTO
    {
        public int AlarmId { get; set; }
        public int? BedId { get; set; }
    }
}
