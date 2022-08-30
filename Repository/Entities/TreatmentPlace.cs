using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class TreatmentPlace
    {
        public TreatmentPlace()
        {
            Bookings = new HashSet<Booking>();
            Departments = new HashSet<Department>();
            JournalEntries = new HashSet<JournalEntry>();
        }

        public int TreatmentPlaceId { get; set; }
        public int TreatmentPlaceTypeId { get; set; }
        public string TreatmentPlaceName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int ZipCode { get; set; }
        public string City { get; set; } = null!;

        public virtual TreatmentPlaceType TreatmentPlaceType { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<JournalEntry> JournalEntries { get; set; }
    }
}
