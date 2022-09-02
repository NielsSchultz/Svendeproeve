using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            JournalEntryFiles = new HashSet<JournalEntryFile>();
            JournalEntryNotes = new HashSet<JournalEntryNote>();
        }

        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeeCode { get; set; } = null!;

        public virtual Department Department { get; set; } = null!;
        public virtual EmployeeType EmployeeType { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<JournalEntryFile> JournalEntryFiles { get; set; }
        public virtual ICollection<JournalEntryNote> JournalEntryNotes { get; set; }
    }
}
