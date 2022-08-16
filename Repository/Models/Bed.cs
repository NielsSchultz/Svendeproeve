using System;
using System.Collections.Generic;

namespace RegionSyd.Repository.Models
{
    public partial class Bed
    {
        public Bed()
        {
            Alarms = new HashSet<Alarm>();
        }

        public int BedId { get; set; }
        public int? RoomId { get; set; }
        public bool IsOccupied { get; set; }

        public virtual Room? Room { get; set; }
        public virtual ICollection<Alarm> Alarms { get; set; }
    }
}
