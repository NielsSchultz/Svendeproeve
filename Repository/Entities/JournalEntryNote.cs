﻿using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class JournalEntryNote
    {
        public int NoteId { get; set; }
        public int JournalEntryId { get; set; }
        public int EmployeeId { get; set; }
        public string NoteContent { get; set; } = null!;
        public bool IsApproved { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? LastEdited { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual JournalEntry JournalEntry { get; set; } = null!;
    }
}
