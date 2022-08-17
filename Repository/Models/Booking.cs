using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int JournalEntryId { get; set; }
        public int TreatmentPlaceId { get; set; }
        public int TreatmentId { get; set; }
        public DateTime TreatmentStart { get; set; }
        public DateTime? TreatmentEnd { get; set; }

        public virtual JournalEntry JournalEntry { get; set; } = null!;
        public virtual Treatment Treatment { get; set; } = null!;
        public virtual TreatmentPlace TreatmentPlace { get; set; } = null!;
    }
}
