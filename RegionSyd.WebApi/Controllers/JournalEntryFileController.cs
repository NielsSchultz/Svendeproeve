using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;
using RegionSyd.WebApi.Services.Services;

namespace RegionSyd.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalEntryFileController : ControllerBase
    {
        private readonly IJournalEntryFileService _journalEntryFileService;

        public JournalEntryFileController(IJournalEntryFileService journalEntryFileService)
        {
            _journalEntryFileService = journalEntryFileService;
        }
        [HttpPost]
        public async Task<JournalEntryFileDTO> CreateJournalEntryFile(JournalEntryFileDTO journalEntryFileDTO)
        {
            return await _journalEntryFileService.CreateJournalEntryFile(journalEntryFileDTO);
        }
        [HttpGet("ByJournalEntry/{id}")]
        public async Task<List<JournalEntryFileDTO>> GetJournalEntryFilesForJournalEntry(int id)
        {
            return await _journalEntryFileService.GetJournalEntryFilesForJournalEntry(id);
        }
        [HttpGet("{id}")]
        public async Task<JournalEntryFileDTO> GetJournalEntryFile(int id)
        {
            return await _journalEntryFileService.GetJournalEntryFile(id);
        }
        
        [HttpPut]
        public async Task<JournalEntryFileDTO> UpdateJournalEntryFile(JournalEntryFileDTO journalEntryFileDTO)
        {
            return await _journalEntryFileService.UpdateJournalEntryFile(journalEntryFileDTO);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteJournalEntryNote(int id)
        {
            return await _journalEntryFileService.DeleteJournalEntryFile(id);
        }
    }
}
