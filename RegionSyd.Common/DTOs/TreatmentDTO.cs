namespace RegionSyd.Common.DTOs
{
    public class TreatmentDTO
    {
        public int TreatmentId { get; set; }
        public int DepartmentId { get; set; }
        //DepartmentName
        public string TreatmentName { get; set; } = null!;
        public TimeSpan TreatmentDuration { get; set; }
    }
}
