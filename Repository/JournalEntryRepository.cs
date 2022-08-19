using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories
{
    public class JournalEntryRepository : IJournalEntryRepository
    {
        public Task<JournalEntry> CreateJournalEntry(JournalEntry journalEntry)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteJournalEntry(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<JournalEntry>> GetJournalEntriesForJournal(int id)
        {
            throw new NotImplementedException();
        }

        public Task<JournalEntry> GetJournalEntry(int id)
        {
            throw new NotImplementedException();
        }

        public Task<JournalEntry> UpdateJournalEntry(JournalEntry journalEntry)
        {
            throw new NotImplementedException();
        }
    }
}
