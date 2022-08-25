using RegionSyd.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IJournalEntryStatusService
    {
        // Create JournalEntryStatus
        Task<JournalEntryStatusDTO> CreateJournalEntryStatus(JournalEntryStatusDTO journalEntryStatusDTO);

        // Get JournalEntryStatus by ID
        Task<JournalEntryStatusDTO> GetJournalEntryStatus(int id);
        // Get All JournalEntryStatuses
        Task<List<JournalEntryStatusDTO>> GetJournalEntryStatuses();

        // Update JournalEntryStatus
        Task<JournalEntryStatusDTO> UpdateJournalEntryStatus(JournalEntryStatusDTO journalEntryStatusDTO);

        // Delete JournalEntryStatus
        Task<bool> DeleteJournalEntryStatus(int id);
    }
}
