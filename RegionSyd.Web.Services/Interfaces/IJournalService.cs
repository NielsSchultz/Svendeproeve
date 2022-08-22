using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface IJournalService
    {
        Task<JournalDTO> GetJournalById(int patientId);
        Task<JournalEntryDTO> SaveJournalEntry(JournalEntryDTO JournalEntryDTO);
        Task<string> TestTreatment();
    }
}