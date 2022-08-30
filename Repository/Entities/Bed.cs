using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class Bed
    {
        public Bed()
        {
            Alarms = new HashSet<Alarm>();
            Patients = new HashSet<Patient>();
        }

        public int BedId { get; set; }
        public int? RoomId { get; set; }
        public bool IsOccupied { get; set; }

        public virtual Room? Room { get; set; }
        public virtual ICollection<Alarm> Alarms { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
