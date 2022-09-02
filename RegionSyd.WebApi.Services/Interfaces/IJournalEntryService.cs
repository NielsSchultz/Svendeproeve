using RegionSyd.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IJournalEntryService
    {
        // Create Journal Entry
        Task<JournalEntryDTO> CreateJournalEntry(JournalEntryDTO journalEntry);

        // Get all journal entries for Journal by Journal ID
        Task<List<JournalEntryDTO>> GetJournalEntriesForJournal(int id);

        // Get journal entry by ID
        Task<JournalEntryDTO> GetJournalEntry(int id);

        // Update Journal Entry
        Task<JournalEntryDTO> UpdateJournalEntry(JournalEntryDTO journalEntry);

        // Delete Journal Entry
        Task<bool> DeleteJournalEntry(int id);
    }
}
