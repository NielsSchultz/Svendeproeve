using RegionSyd.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IJournalEntryNoteService
    {
        // Create JournalEntryNote
        Task<JournalEntryNoteDTO> CreateJournalEntryNote(JournalEntryNoteDTO journalEntryNoteDTO);

        // Get all JournalEntryNote
        Task<List<JournalEntryNoteDTO>> GetJournalEntryNotesForJournalEntry(int id);

        // Get JournalEntryNote by ID
        Task<JournalEntryNoteDTO> GetJournalEntryNote(int id);

        // Update JournalEntryNote
        Task<JournalEntryNoteDTO> UpdateJournalEntryNote(JournalEntryNoteDTO journalEntryNoteDTO);

        // Delete JournalEntryNote
        Task<bool> DeleteJournalEntryNote(int id);
    }
}
