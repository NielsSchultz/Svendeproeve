﻿using System;
using System.Collections.Generic;

namespace RegionSyd.Common.Models
{
    public partial class FileType
    {
        public FileType()
        {
            JournalEntryFiles = new HashSet<JournalEntryFile>();
        }

        public int FileTypeId { get; set; }
        public string FileTypeName { get; set; } = null!;

        public virtual ICollection<JournalEntryFile> JournalEntryFiles { get; set; }
    }
}