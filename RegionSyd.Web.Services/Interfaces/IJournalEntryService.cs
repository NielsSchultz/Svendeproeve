using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface IJournalEntryService
    {
        Task<JournalEntryDTO> Create(JournalEntryDTO JournalEntryDTO);
        Task<string> Delete(int id);
        Task<JournalEntryDTO> GetById(int id);
        Task<JournalEntryDTO> Update(JournalEntryDTO JournalEntryDTO);
    }
}