using RegionSyd.Repositories.Entities;

namespace RegionSyd.Common.DTOs
{
    public class JournalEntryDetailsDTO
    {
        public JournalEntryDTO journalEntryDTO { get; set; } = null!;
        public TreatmentPlaceDTO treatmentPlaceDTO { get; set; } = null!;
        public DepartmentDTO departmentDTO { get; set; } = null!;
        public EmployeeDTO employeeDTO { get; set; } = null!;

        public List<JournalEntryNoteDTO> notes = new List<JournalEntryNoteDTO>();
        public List<JournalEntryFileDTO> files = new List<JournalEntryFileDTO>();
    }
}
