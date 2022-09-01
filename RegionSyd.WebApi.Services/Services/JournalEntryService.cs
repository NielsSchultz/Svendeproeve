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
    public class JournalEntryService : IJournalEntryService
    {
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IMapper _mapper;

        public JournalEntryService(IJournalEntryRepository journalEntryRepository, IMapper mapper)
        {
            _journalEntryRepository = journalEntryRepository ?? throw new ArgumentNullException(nameof(journalEntryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<JournalEntryDTO>> GetJournalEntriesForJournal(int id)
        {
            var journals = await _journalEntryRepository.GetJournalEntriesForJournal(id);
            return _mapper.Map<List<JournalEntryDTO>>(journals);
        }
        public async Task<JournalEntryDTO> GetJournalEntry(int id)
        {
            var journal = await _journalEntryRepository.GetJournalEntry(id);
            return _mapper.Map<JournalEntryDTO>(journal);
        }
        public async Task<JournalEntryDTO> CreateJournalEntry(JournalEntryDTO journalEntryDTO)
        {
            var journalEntry = _mapper.Map<JournalEntry>(journalEntryDTO);
            var returnJournalEntry = await _journalEntryRepository.CreateJournalEntry(journalEntry);
            return _mapper.Map<JournalEntryDTO>(returnJournalEntry);
        }

        public async Task<bool> DeleteJournalEntry(int id)
        {
            return await _journalEntryRepository.DeleteJournalEntry(id);
        }

        public async Task<JournalEntryDTO> UpdateJournalEntry(JournalEntryDTO journalEntryDTO)
        {
            JournalEntry journalEntry = _mapper.Map<JournalEntry>(journalEntryDTO);
            JournalEntry returnJournalEntry = await _journalEntryRepository.UpdateJournalEntry(journalEntry);
            return _mapper.Map<JournalEntryDTO>(returnJournalEntry);
        }
    }
}
