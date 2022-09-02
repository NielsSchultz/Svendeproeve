namespace RegionSyd.Common.DTOs
{
    public class BookingListDTO
    {
        public BookingDTO booking { get; set; } = null!;
        public TreatmentPlaceDTO treatmentPlace { get; set; } = null!;
        public TreatmentDTO treatment { get; set; } = null!;
    }
}
