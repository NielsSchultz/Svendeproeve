namespace RegionSyd.Common.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public int TreatmentPlaceId { get; set; }
        public int TreatmentId { get; set; }
        public DateTime TreatmentStart { get; set; }
        public DateTime? TreatmentEnd { get; set; }
    }
}
