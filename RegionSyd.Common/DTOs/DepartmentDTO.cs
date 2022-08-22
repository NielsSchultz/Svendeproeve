namespace RegionSyd.Common.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int TreatmentPlaceId { get; set; }
        //TreatmentPlaceName?? Skal måske tilføjes
        public string TreatmentPlaceName { get; set; } = null!;
    }
}
