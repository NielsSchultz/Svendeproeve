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
    public class JournalEntryNoteService : IJournalEntryNoteService
    {
        private readonly IJournalEntryNoteRepository _journalEntryNoteRepository;
        private readonly IMapper _mapper;


        public JournalEntryNoteService(IJournalEntryNoteRepository journalEntryNoteRepository, IMapper mapper)
        {
            _journalEntryNoteRepository = journalEntryNoteRepository ?? throw new ArgumentNullException(nameof(journalEntryNoteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<JournalEntryNoteDTO>> GetJournalEntryNotesForJournalEntry(int id)
        {
            var journalEntryNotes = await _journalEntryNoteRepository.GetJournalEntryNotesForJournalEntry(id);
            return _mapper.Map<List<JournalEntryNoteDTO>>(journalEntryNotes);
        }
        public async Task<JournalEntryNoteDTO> GetJournalEntryNote(int id)
        {
            var journalEntryNote = await _journalEntryNoteRepository.GetJournalEntryNote(id);
            return _mapper.Map<JournalEntryNoteDTO>(journalEntryNote);
        }

        public async Task<List<JournalEntryNoteDTO>> GetJournalEntryNotesAwaitingApproval()
        {
            var journalEntryNotes = await _journalEntryNoteRepository.GetJournalEntryNotesAwaitingApproval();
            return _mapper.Map<List<JournalEntryNoteDTO>>(journalEntryNotes);
        }
        public async Task<JournalEntryNoteDTO> CreateJournalEntryNote(JournalEntryNoteDTO journalEntryNoteDTO)
        {
            var journalEntryNote = _mapper.Map<JournalEntryNote>(journalEntryNoteDTO);
            var returnJournalEntryNote = await _journalEntryNoteRepository.CreateJournalEntryNote(journalEntryNote);
            return _mapper.Map<JournalEntryNoteDTO>(returnJournalEntryNote);
        }
        
        public async Task<bool> DeleteJournalEntryNote(int id)
        {
            return await _journalEntryNoteRepository.DeleteJournalEntryNote(id);
        }

        public async Task<JournalEntryNoteDTO> UpdateJournalEntryNote(JournalEntryNoteDTO journalEntryNoteDTO)
        {
            var journalEntryNote = _mapper.Map<JournalEntryNote>(journalEntryNoteDTO);
            var returnJournalEntryNote = await _journalEntryNoteRepository.UpdateJournalEntryNote(journalEntryNote);
            return _mapper.Map<JournalEntryNoteDTO>(returnJournalEntryNote);
        }
    }
}
