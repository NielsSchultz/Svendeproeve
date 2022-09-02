using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class User
    {
        public User()
        {
            Employees = new HashSet<Employee>();
            Patients = new HashSet<Patient>();
        }

        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Cpr { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int ZipCode { get; set; }
        public string CityName { get; set; } = null!;

        public virtual UserType UserType { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
