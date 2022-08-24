using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IJournalEntryFileRepository
    {
        // Create Journal Entry
        Task<JournalEntryFile> CreateJournalEntryFile(JournalEntryFile newJournalEntryFile);

        // Get all journal entries for Journal by Journal ID
        Task<List<JournalEntryFile>> GetJournalEntryFilesForJournalEntry(int id);

        // Get journal entry by ID
        Task<JournalEntryFile> GetJournalEntryFile(int id);

        // Update Journal Entry
        Task<JournalEntryFile> UpdateJournalEntryFile(JournalEntryFile newJournalEntryFile);

        // Delete Journal Entry
        Task<bool> DeleteJournalEntryFile(int id);
    }
}
