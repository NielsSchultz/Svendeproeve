namespace RegionSyd.Common.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public int PatientId { get; set; }
        public int TreatmentPlaceId { get; set; }
        public string? TreatmentPlaceName { get; set; }
        public int TreatmentId { get; set; }
        public string? TreatmentName { get; set; }
        public int TreatmentDuration { get; set; }
        public DateTime TreatmentStart { get; set; }
        public DateTime? TreatmentEnd { get; set; }
    }
}
