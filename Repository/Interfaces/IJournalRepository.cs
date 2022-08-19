using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IJournalRepository
    {
        // Create new journal
        Task<Journal> CreateJournal(Journal journal);

        // Get all journals
        Task<List<Journal>> GetJournals();

        // Get journal by ID
        Task<Journal> GetJournal(int id);

        // Get journal by patient ID
        Task<Journal> GetJournalByPatientID(int id);

        // Update journal
        Task<Journal> UpdateJournal(Journal journal);

        // Delete Journal
        Task<bool> DeleteJournal(int id);
    }
}
