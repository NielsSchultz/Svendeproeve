namespace RegionSyd.Common.DTOs
{
    public class JournalEntryNoteDTO
    {
        public int NoteId { get; set; }
        public string NoteContent { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsApproved { get; set; }

        //Employee
        public int EmployeeId { get; set; }
        public string? EmployeeTypeName { get; set; }

        //User
        public int? UserId { get; set; }
        public string? EmployeeFirstname{ get; set; }
        public string? EmployeeMiddlename{ get; set; }
        public string? EmployeeLastname { get; set; }

        //JournalEntry
        public int JournalEntryId { get; set; }
    }
}