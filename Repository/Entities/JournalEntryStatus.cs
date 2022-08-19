using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class JournalEntryStatus
    {
        public JournalEntryStatus()
        {
            JournalEntries = new HashSet<JournalEntry>();
        }

        public int JournalEntryStatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<JournalEntry> JournalEntries { get; set; }
    }
}
