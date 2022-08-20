namespace RegionSyd.Common.DTOs
{
    public class JournalEntryDTO
    {
        //Journal Entry
        public string? Description { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public string? Diagnosis { get; set; }
        public int JournalId { get; set; }

        //Journal
        public int JournalEntryId { get; set; }

        //TreatmentPlace
        public int TreatmentPlaceId { get; set; }
        public string TreatmentPlaceName { get; set; } = null!;

        //Status
        public int JournalEntryStatusId { get; set; }
        public string StatusName { get; set; } = null!;

        //Department
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        //Employee 
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }

        //Collections (Files & Notes)
        public virtual ICollection<JournalEntryFileDTO> JournalEntryFiles { get; set; }
        public virtual ICollection<JournalEntryNoteDTO> JournalEntryNotes { get; set; }
    }
}
