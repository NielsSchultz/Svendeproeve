﻿using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Models
{
    public partial class Alarm
    {
        public int AlarmId { get; set; }
        public int? BedId { get; set; }

        public virtual Bed? Bed { get; set; }
    }
}
