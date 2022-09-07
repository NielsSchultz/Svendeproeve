using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;

namespace RegionSyd.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalEntryNoteController : ControllerBase
    {
        private readonly IJournalEntryNoteService _journalEntryNoteService;

        public JournalEntryNoteController(IJournalEntryNoteService journalEntryNoteService)
        {
            _journalEntryNoteService = journalEntryNoteService;
        }
        [HttpGet("ByJournalEntry/{id}")]
        public async Task<List<JournalEntryNoteDTO>> GetJournalEntryNotesForJournalEntry(int id)
        {
            return await _journalEntryNoteService.GetJournalEntryNotesForJournalEntry(id);
        }
        [HttpGet("{id}")]
        public async Task<JournalEntryNoteDTO> GetJournalEntryNote(int id)
        {
            return await _journalEntryNoteService.GetJournalEntryNote(id);
        }

        [HttpGet]
        public async Task<List<JournalEntryNoteDTO>> GetJournalEntryNotesAwaitingApproval()
        {
            return await _journalEntryNoteService.GetJournalEntryNotesAwaitingApproval();
        }
        [HttpPost]
        public async Task<JournalEntryNoteDTO> CreateJournalEntryNote(JournalEntryNoteDTO journalEntryNoteDTO)
        {
            return await _journalEntryNoteService.CreateJournalEntryNote(journalEntryNoteDTO);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteJournalEntryNote(int id)
        {
            return await _journalEntryNoteService.DeleteJournalEntryNote(id);
        }
        [HttpPut]
        public async Task<JournalEntryNoteDTO> UpdateJournalEntryNote(JournalEntryNoteDTO journalEntryNoteDTO)
        {
            return await _journalEntryNoteService.UpdateJournalEntryNote(journalEntryNoteDTO);
        }
    }
}
