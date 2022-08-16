using System;
using System.Collections.Generic;

namespace RegionSyd.Repository.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Journals = new HashSet<Journal>();
        }

        public int PatientId { get; set; }
        public int UserId { get; set; }
        public int Cpr { get; set; }
        public DateTime Birthday { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Journal> Journals { get; set; }
    }
}
