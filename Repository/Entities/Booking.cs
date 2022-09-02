using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int PatientId { get; set; }
        public int TreatmentPlaceId { get; set; }
        public int TreatmentId { get; set; }
        public DateTime TreatmentStart { get; set; }
        public DateTime? TreatmentEnd { get; set; }

        public virtual Patient Patient { get; set; } = null!;
        public virtual Treatment Treatment { get; set; } = null!;
        public virtual TreatmentPlace TreatmentPlace { get; set; } = null!;
    }
}
