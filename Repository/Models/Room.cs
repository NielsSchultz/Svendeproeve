using System;
using System.Collections.Generic;

namespace RegionSyd.Repository.Models
{
    public partial class Room
    {
        public Room()
        {
            Beds = new HashSet<Bed>();
        }

        public int RoomId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Bed> Beds { get; set; }
    }
}
