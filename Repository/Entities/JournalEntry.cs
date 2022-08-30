using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class JournalEntry
    {
        public JournalEntry()
        {
            JournalEntryFiles = new HashSet<JournalEntryFile>();
            JournalEntryNotes = new HashSet<JournalEntryNote>();
        }

        public int JournalEntryId { get; set; }
        public int JournalId { get; set; }
        public int JournalEntryStatusId { get; set; }
        public int TreatmentPlaceId { get; set; }
        public int? DepartmentId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Description { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual Department? Department { get; set; }
        public virtual Journal Journal { get; set; } = null!;
        public virtual JournalEntryStatus JournalEntryStatus { get; set; } = null!;
        public virtual TreatmentPlace TreatmentPlace { get; set; } = null!;
        public virtual ICollection<JournalEntryFile> JournalEntryFiles { get; set; }
        public virtual ICollection<JournalEntryNote> JournalEntryNotes { get; set; }
    }
}
