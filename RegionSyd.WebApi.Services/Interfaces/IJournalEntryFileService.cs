using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IJournalEntryFileService
    {
        // Create Journal Entry
        Task<JournalEntryFileDTO> CreateJournalEntryFile(JournalEntryFileDTO journalEntryFileDTO);

        // Get all journal entries for Journal by Journal ID
        Task<List<JournalEntryFileDTO>> GetJournalEntryFilesForJournalEntry(int id);

        // Get journal entry by ID
        Task<JournalEntryFileDTO> GetJournalEntryFile(int id);

        // Update Journal Entry
        Task<JournalEntryFileDTO> UpdateJournalEntryFile(JournalEntryFileDTO journalEntryFileDTO);

        // Delete Journal Entry
        Task<bool> DeleteJournalEntryFile(int id);
    }
}
