using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IJournalEntryRepository
    {
        // Create Journal Entry
        Task<JournalEntry> CreateJournalEntry(JournalEntry newJournalEntry);

        // Get all journal entries for Journal by Journal ID
        Task<List<JournalEntry>> GetJournalEntriesForJournal(int id);

        // Get journal entry by ID
        Task<JournalEntry> GetJournalEntry(int id);

        // Update Journal Entry
        Task<JournalEntry> UpdateJournalEntry(JournalEntry newJournalEntry);

        // Delete Journal Entry
        Task<bool> DeleteJournalEntry(int id);
    }
}
