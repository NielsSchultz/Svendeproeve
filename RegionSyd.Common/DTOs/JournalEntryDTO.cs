namespace RegionSyd.Common.DTOs
{
    public class JournalEntryDTO
    {
        public int JournalEntryId { get; set; }
        public int JournalId { get; set; }
        public int TreatmentPlaceId { get; set; }
        public int? DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string? Description { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
    }
}
