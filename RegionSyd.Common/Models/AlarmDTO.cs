using System;
using System.Collections.Generic;

namespace RegionSyd.Common.Models
{
    public partial class Alarm
    {
        public int AlarmId { get; set; }
        public int? BedId { get; set; }

        public virtual Bed? Bed { get; set; }
    }
}
