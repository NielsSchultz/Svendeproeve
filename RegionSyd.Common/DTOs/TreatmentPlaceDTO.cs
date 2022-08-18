namespace RegionSyd.Common.DTOs
{
    public class TreatmentPlaceDTO
    {        
        public int TreatmentPlaceId { get; set; }
        public int TreatmentPlaceTypeId { get; set; }
        public string TreatmentPlaceName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int ZipCode { get; set; }
        public string City { get; set; } = null!;
    }
}
