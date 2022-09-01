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
    public class JournalEntryFileService : IJournalEntryFileService
    {
        private readonly IJournalEntryFileRepository _journalEntryFileRepository;
        private readonly IMapper _mapper;


        public JournalEntryFileService(IJournalEntryFileRepository journalEntryFileRepository, IMapper mapper)
        {
            _journalEntryFileRepository = journalEntryFileRepository ?? throw new ArgumentNullException(nameof(journalEntryFileRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<JournalEntryFileDTO> CreateJournalEntryFile(JournalEntryFileDTO journalEntryFileDTO)
        {
            var journalEntryFile = _mapper.Map<JournalEntryFile>(journalEntryFileDTO);
            var returnJournalEntryFile = await _journalEntryFileRepository.CreateJournalEntryFile(journalEntryFile);
            return _mapper.Map<JournalEntryFileDTO>(returnJournalEntryFile);
        }
        public async Task<List<JournalEntryFileDTO>> GetJournalEntryFilesForJournalEntry(int id)
        {
            var journalEntryFiles = await _journalEntryFileRepository.GetJournalEntryFilesForJournalEntry(id);
            return _mapper.Map<List<JournalEntryFileDTO>>(journalEntryFiles);
        }
        public async Task<JournalEntryFileDTO> GetJournalEntryFile(int id)
        {
            var journalEntryFile = await _journalEntryFileRepository.GetJournalEntryFile(id);
            return _mapper.Map<JournalEntryFileDTO>(journalEntryFile);
        }
        public async Task<JournalEntryFileDTO> UpdateJournalEntryFile(JournalEntryFileDTO journalEntryFileDTO)
        {
            var journalEntryFile = _mapper.Map<JournalEntryFile>(journalEntryFileDTO);
            var returnJournalEntryFile = await _journalEntryFileRepository.UpdateJournalEntryFile(journalEntryFile);
            return _mapper.Map<JournalEntryFileDTO>(returnJournalEntryFile);
        }
        public async Task<bool> DeleteJournalEntryFile(int id)
        {
            return await _journalEntryFileRepository.DeleteJournalEntryFile(id);
        }
    }
}
