using System;
using System.Collections.Generic;

namespace RegionSyd.Common.Models
{
    public partial class JournalEntryFile
    {
        public int FileId { get; set; }
        public int JournalEntryId { get; set; }
        public int EmployeeId { get; set; }
        public int FileTypeId { get; set; }
        public string FilePath { get; set; } = null!;
        public string? FileNote { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual FileType FileType { get; set; } = null!;
        public virtual JournalEntry JournalEntry { get; set; } = null!;
    }
}
