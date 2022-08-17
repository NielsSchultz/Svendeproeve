using System;
using System.Collections.Generic;

namespace RegionSyd.Common.Models
{
    public partial class Journal
    {
        public Journal()
        {
            JournalEntries = new HashSet<JournalEntry>();
        }

        public int JournalId { get; set; }
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; } = null!;
        public virtual ICollection<JournalEntry> JournalEntries { get; set; }
    }
}
