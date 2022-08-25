using AutoMapper;
using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using RegionSyd.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Services
{
    public class JournalEntryStatusService : IJournalEntryStatusService
    {
        private readonly IJournalEntryStatusRepository _journalEntryStatusRepository;
        private readonly IMapper _mapper;

        public JournalEntryStatusService(IJournalEntryStatusRepository journalEntryStatusRepository, IMapper mapper)
        {
            _journalEntryStatusRepository = journalEntryStatusRepository ?? throw new ArgumentNullException(nameof(journalEntryStatusRepository));
            _mapper = mapper;
        }
        public async Task<List<JournalEntryStatusDTO>> GetJournalEntryStatuses()
        {
            var journalEntryStatuses = await _journalEntryStatusRepository.GetJournalEntryStatuses();
            return _mapper.Map<List<JournalEntryStatusDTO>>(journalEntryStatuses);
        }
        public async Task<JournalEntryStatusDTO> GetJournalEntryStatus(int id)
        {
            var journalEntryStatus = await _journalEntryStatusRepository.GetJournalEntryStatus(id);
            return _mapper.Map<JournalEntryStatusDTO>(journalEntryStatus);
        }
        public async Task<JournalEntryStatusDTO> CreateJournalEntryStatus(JournalEntryStatusDTO journalEntryStatusDTO)
        {
            var journalEntryStatus = _mapper.Map<JournalEntryStatus>(journalEntryStatusDTO);
            var returnJournalEntryStatus = await _journalEntryStatusRepository.CreateJournalEntryStatus(journalEntryStatus);
            return _mapper.Map<JournalEntryStatusDTO>(returnJournalEntryStatus);
        }

        public async Task<bool> DeleteJournalEntryStatus(int id)
        {
            return await _journalEntryStatusRepository.DeleteJournalEntryStatus(id);
        }

        public async Task<JournalEntryStatusDTO> UpdateJournalEntryStatus(JournalEntryStatusDTO journalEntryStatusDTO)
        {
            var journalEntryStatus = _mapper.Map<JournalEntryStatus>(journalEntryStatusDTO);
            var returnJournalEntryStatus = await _journalEntryStatusRepository.UpdateJournalEntryStatus(journalEntryStatus);
            return _mapper.Map<JournalEntryStatusDTO>(returnJournalEntryStatus);
        }
    }
}
