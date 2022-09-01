using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using RegionSyd.WebApi.Services.Interfaces;
using RegionSyd.WebApi.Services.Services;

namespace RegionSyd.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalEntryController : ControllerBase
    {
        private readonly IJournalEntryService _journalEntryService;

        public JournalEntryController(IJournalEntryService journalEntryService)
        {
            _journalEntryService = journalEntryService ?? throw new ArgumentNullException(nameof(journalEntryService));
        }
        [HttpGet("ByPatient/{id}")]
        public async Task<List<JournalEntryDTO>> GetJournalEntriesForJournal(int id)
        {
            return await _journalEntryService.GetJournalEntriesForJournal(id);
        }
        [HttpGet("{id}")]
        public async Task<JournalEntryDTO> GetJournalEntry(int id)
        {
            return await _journalEntryService.GetJournalEntry(id);
        }
        [HttpPost]
        public async Task<JournalEntryDTO> CreateJournalEntry(JournalEntryDTO journal)
        {
            return await _journalEntryService.CreateJournalEntry(journal);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteJournalEntry(int id)
        {
            return await _journalEntryService.DeleteJournalEntry(id);
        }
        [HttpPut]
        public async Task<JournalEntryDTO> UpdateJournalEntry(JournalEntryDTO journal)
        {
            return await _journalEntryService.UpdateJournalEntry(journal);
        }
    }
}
