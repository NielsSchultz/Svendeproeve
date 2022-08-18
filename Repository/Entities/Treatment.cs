using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class Treatment
    {
        public Treatment()
        {
            Bookings = new HashSet<Booking>();
        }

        public int TreatmentId { get; set; }
        public int DepartmentId { get; set; }
        public string TreatmentName { get; set; } = null!;
        public TimeSpan TreatmentDuration { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
