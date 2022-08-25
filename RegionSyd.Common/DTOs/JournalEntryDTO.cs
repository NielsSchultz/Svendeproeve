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

        //Patient
        public int PatientId { get; set; }

        //User
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Cpr { get; set; }

        //Journal
        public int JournalEntryId { get; set; }

        //TreatmentPlace
        public int TreatmentPlaceId { get; set; }
        public string TreatmentPlaceName { get; set; }

        //Status
        public int JournalEntryStatusId { get; set; }
        public string StatusName { get; set; }

        //Department
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        //Employee 
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }

        //Collections (Files & Notes)
        public int JournalEntryFilesCount { get; set; }
        public int JournalEntryNotesCount { get; set; }
        //public virtual ICollection<JournalEntryFileDTO> JournalEntryFiles { get; set; }
        //public virtual ICollection<JournalEntryNoteDTO> JournalEntryNotes { get; set; }
    }
}
