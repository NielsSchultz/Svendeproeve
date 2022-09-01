using AutoMapper;
using RegionSyd.Common.DTOs;
using RegionSyd.Repositories;
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
    public class JournalService : IJournalService
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IMapper _mapper;

        public JournalService(IJournalRepository journalRepository, IMapper mapper)
        {
            _journalRepository = journalRepository ?? throw new ArgumentNullException(nameof(journalRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<JournalDTO>> GetJournals()
        {
            var journals = await _journalRepository.GetJournals();
            return _mapper.Map<List<JournalDTO>>(journals);
        }
        public async Task<JournalDTO> GetJournal(int id)
        {
            var journal = await _journalRepository.GetJournal(id);
            return _mapper.Map<JournalDTO>(journal);
        }
        public async Task<JournalDTO> GetJournalByPatientID(int id)
        {
            var journal = await _journalRepository.GetJournalByPatientID(id);
            return _mapper.Map<JournalDTO>(journal);
        }
        public async Task<JournalDTO> CreateJournal(JournalDTO journalDTO)
        {
            var journal = _mapper.Map<Journal>(journalDTO);
            var returnJournal = await _journalRepository.CreateJournal(journal);
            return _mapper.Map<JournalDTO>(returnJournal);
        }

        public async Task<bool> DeleteJournal(int id)
        {
            return await _journalRepository.DeleteJournal(id);
        }

        public async Task<JournalDTO> UpdateJournal(JournalDTO journalDTO)
        {
            Journal journal = _mapper.Map<Journal>(journalDTO);
            Journal returnJournal = await _journalRepository.UpdateJournal(journal);
            return _mapper.Map<JournalDTO>(returnJournal);
        }
    }
}
