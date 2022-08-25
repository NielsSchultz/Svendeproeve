using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IJournalEntryStatusRepository
    {
        // Create Journal Entry
        Task<JournalEntryStatus> CreateJournalEntryStatus(JournalEntryStatus newJournalEntryStatus);

        // Get journal entry by ID
        Task<JournalEntryStatus> GetJournalEntryStatus(int id);
        // Get All JournalEntryStatuses
        Task<List<JournalEntryStatus>> GetJournalEntryStatuses();

        // Update Journal Entry
        Task<JournalEntryStatus> UpdateJournalEntryStatus(JournalEntryStatus newJournalEntryStatus);

        // Delete Journal Entry
        Task<bool> DeleteJournalEntryStatus(int id);
    }
}
