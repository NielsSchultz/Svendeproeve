using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Models
{
    public partial class Department
    {
        public Department()
        {
            Rooms = new HashSet<Room>();
            Treatments = new HashSet<Treatment>();
        }

        public int DepartmentId { get; set; }
        public int TreatmentPlaceId { get; set; }

        public virtual TreatmentPlace TreatmentPlace { get; set; } = null!;
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}
