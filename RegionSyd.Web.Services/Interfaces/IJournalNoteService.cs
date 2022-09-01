using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface IJournalNoteService
    {
        Task<JournalEntryNoteDTO> Create(JournalEntryNoteDTO journalNoteDTO);
        Task<string> Delete(int id);
        Task<List<JournalEntryNoteDTO>> GetAll(int id);
        Task<List<JournalEntryNoteDTO>> GetJournalNotesForApproval();
        Task<JournalEntryNoteDTO> GetById(int id);
        Task<JournalEntryNoteDTO> Update(JournalEntryNoteDTO journalNoteDTO);
    }
}