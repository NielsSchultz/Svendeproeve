using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Models
{
    public partial class Employee
    {
        public Employee()
        {
            JournalEntries = new HashSet<JournalEntry>();
            JournalEntryFiles = new HashSet<JournalEntryFile>();
            JournalEntryNotes = new HashSet<JournalEntryNote>();
        }

        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public int EmployeeTypeId { get; set; }
        public string EmployeeCode { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Birthday { get; set; }

        public virtual EmployeeType EmployeeType { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<JournalEntry> JournalEntries { get; set; }
        public virtual ICollection<JournalEntryFile> JournalEntryFiles { get; set; }
        public virtual ICollection<JournalEntryNote> JournalEntryNotes { get; set; }
    }
}
