namespace RegionSyd.Common.DTOs
{
    public class JournalDTO
    {
        public int JournalId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; };
        public int PatientId { get; set; }
    }
}