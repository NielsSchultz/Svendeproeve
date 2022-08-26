namespace RegionSyd.Common.DTOs
{
    public class JournalEntryFileDTO
    {
        public int FileId { get; set; }
        public int JournalEntryId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeMiddleName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeTypeName { get; set; }
        public int FileTypeId { get; set; }
        public string FileTypeName { get; set; }
        public string FilePath { get; set; } = null!;
        public string? FileNote { get; set; }
    }
}
