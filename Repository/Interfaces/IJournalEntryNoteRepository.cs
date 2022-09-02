using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IJournalEntryNoteRepository
    {
        // Create Journal Entry
        Task<JournalEntryNote> CreateJournalEntryNote(JournalEntryNote newJournalEntryNote);

        // Get all journal entries for Journal by Journal ID
        Task<List<JournalEntryNote>> GetJournalEntryNotesForJournalEntry(int id);

        // Get journal entry by ID
        Task<JournalEntryNote> GetJournalEntryNote(int id);

        // Get all journal entries waiting for approval
        Task<List<JournalEntryNote>> GetJournalEntryNotesAwaitingApproval();
        // Update Journal Entry
        Task<JournalEntryNote> UpdateJournalEntryNote(JournalEntryNote newJournalEntryNote);

        // Delete Journal Entry
        Task<bool> DeleteJournalEntryNote(int id);
    }
}
