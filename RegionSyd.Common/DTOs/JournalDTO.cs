namespace RegionSyd.Common.DTOs
{
    public class JournalDTO
    {
        public int JournalId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public int PatientId { get; set; }
        public int Cpr { get; set; }

        public ICollection<JournalEntryDTO> JournalEntries { get; set; }
    }
}