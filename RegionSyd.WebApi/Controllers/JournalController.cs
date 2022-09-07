using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;

namespace RegionSyd.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IJournalService _journalService;

        public JournalController(IJournalService journalService)
        {
            _journalService = journalService;
        }
        [HttpGet]
        public async Task<List<JournalDTO>> GetAllJournals()
        {
            return await _journalService.GetJournals();
        }
        [HttpGet("{id}")]
        public async Task<JournalDTO> GetJournal(int id)
        {
            return await _journalService.GetJournal(id);
        }
        [HttpGet("ByPatient/{id}")]
        public async Task<JournalDTO> GetJournalByPatientID(int id)
        {
            return await _journalService.GetJournalByPatientID(id);
        }
        [HttpPost]
        public async Task<JournalDTO> CreateJournal(JournalDTO journal)
        {
            return await _journalService.CreateJournal(journal);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteJournal(int id)
        {
            return await _journalService.DeleteJournal(id);
        }
        [HttpPut]
        public async Task<JournalDTO> UpdateJournal(JournalDTO journal)
        {
            return await _journalService.UpdateJournal(journal);
        }
    }
}
