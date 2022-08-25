using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface IJournalEntryService
    {
        Task<JournalEntryDTO> GetById(int id);
        Task<JournalEntryDTO> Create(JournalEntryDTO JournalEntryDTO);
        Task<JournalEntryDTO> Update(JournalEntryDTO JournalEntryDTO);
        Task<string> Delete(int id);
    }
}