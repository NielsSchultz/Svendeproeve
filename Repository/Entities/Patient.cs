using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            Bookings = new HashSet<Booking>();
            Journals = new HashSet<Journal>();
            Monitors = new HashSet<Monitor>();
        }

        public int PatientId { get; set; }
        public int UserId { get; set; }
        public int? BedId { get; set; }

        public virtual Bed? Bed { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
        public virtual ICollection<Monitor> Monitors { get; set; }
    }
}
