using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Models
{
    public partial class Monitor
    {
        public int MonitorId { get; set; }
        public int? PatientId { get; set; }

        public virtual Patient? Patient { get; set; }
    }
}
