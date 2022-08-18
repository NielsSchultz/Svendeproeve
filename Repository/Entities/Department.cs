using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            Rooms = new HashSet<Room>();
            Treatments = new HashSet<Treatment>();
        }

        public int DepartmentId { get; set; }
        public int TreatmentPlaceId { get; set; }
        public string DepartmentName { get; set; } = null!;

        public virtual TreatmentPlace TreatmentPlace { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}
