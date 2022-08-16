using System;
using System.Collections.Generic;

namespace RegionSyd.Repository.Models
{
    public partial class JournalEntry
    {
        public JournalEntry()
        {
            Bookings = new HashSet<Booking>();
            JournalEntryFiles = new HashSet<JournalEntryFile>();
            JournalEntryNotes = new HashSet<JournalEntryNote>();
        }

        public int JournalEntryId { get; set; }
        public int JournalId { get; set; }
        public int EmployeeId { get; set; }
        public string? Description { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Journal Journal { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<JournalEntryFile> JournalEntryFiles { get; set; }
        public virtual ICollection<JournalEntryNote> JournalEntryNotes { get; set; }
    }
}
