namespace RegionSyd.Common.DTOs
{
    public class JournalEntryNoteDTO
    {
        public int NoteId { get; set; }
        public int JournalEntryId { get; set; }
        public int EmployeeId { get; set; }
        // EmployeeName
        public string NoteContent { get; set; } = null!;
    }
}