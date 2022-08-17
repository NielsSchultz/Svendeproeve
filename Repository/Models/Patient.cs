﻿using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Journals = new HashSet<Journal>();
            Monitors = new HashSet<Monitor>();
        }

        public int PatientId { get; set; }
        public int UserId { get; set; }
        public int Cpr { get; set; }
        public DateTime Birthday { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Journal> Journals { get; set; }
        public virtual ICollection<Monitor> Monitors { get; set; }
    }
}
