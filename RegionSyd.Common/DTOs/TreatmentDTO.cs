namespace RegionSyd.Common.DTOs
{
    public class TreatmentDTO
    {
        public int TreatmentId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string TreatmentName { get; set; } = null!;
        public int TreatmentDuration { get; set; }
    }
}
