using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;

namespace RegionSyd.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalEntryStatusController : Controller
    {
        private readonly IJournalEntryStatusService _journalEntryStatusService;

        public JournalEntryStatusController(IJournalEntryStatusService journalEntryStatusService)
        {
            _journalEntryStatusService = journalEntryStatusService;
        }
        [HttpGet]
        public async Task<List<JournalEntryStatusDTO>> GetJournalEntryStatuses()
        {
            return await _journalEntryStatusService.GetJournalEntryStatuses();
        }
        [HttpGet("{id}")]
        public async Task<JournalEntryStatusDTO> GetJournalEntryStatus(int id)
        {
            return await _journalEntryStatusService.GetJournalEntryStatus(id);
        }
        [HttpPost]
        public async Task<JournalEntryStatusDTO> CreateJournalEntryStatus(JournalEntryStatusDTO journalEntryStatusDTO)
        {
            return await _journalEntryStatusService.CreateJournalEntryStatus(journalEntryStatusDTO);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteJournalEntryStatus(int id)
        {
            return await _journalEntryStatusService.DeleteJournalEntryStatus(id);
        }
        [HttpPut]
        public async Task<JournalEntryStatusDTO> UpdateJournalEntryStatus(JournalEntryStatusDTO journalEntryStatusDTO)
        {
            return await _journalEntryStatusService.UpdateJournalEntryStatus(journalEntryStatusDTO);
        }
    }
}
