using Microsoft.EntityFrameworkCore;
using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories
{
    public class JournalEntryNoteRepository : IJournalEntryNoteRepository
    {
        private readonly RegionSydDBContext _context;

        public JournalEntryNoteRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<JournalEntryNote> CreateJournalEntryNote(JournalEntryNote newJournalEntryNote)
        {
            if (newJournalEntryNote != null)
            {
                _context.JournalEntryNotes.Add(newJournalEntryNote);
                await _context.SaveChangesAsync();
                return newJournalEntryNote;
            }
            else
            {
                throw new ArgumentNullException(nameof(newJournalEntryNote));
            }
        }

        public async Task<bool> DeleteJournalEntryNote(int id)
        {
            var journalEntryNote = await _context.JournalEntryNotes.FindAsync(id);
            if (journalEntryNote != null)
            {
                _context.JournalEntryNotes.Remove(journalEntryNote);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(journalEntryNote));
            }
        }

        public async Task<JournalEntryNote> GetJournalEntryNote(int id)
        {
            return await _context.JournalEntryNotes.Where(j => j.NoteId == id)
                .Include(j => j.Employee)
                .ThenInclude(e => e.User)
                .Include(j => j.Employee)
                .ThenInclude(e => e.EmployeeType)
                .FirstOrDefaultAsync();
        }

        public async Task<List<JournalEntryNote>> GetJournalEntryNotes()
        {
            return await _context.JournalEntryNotes
                .Include(j => j.Employee)
                .ThenInclude(e => e.User)
                .Include(j => j.Employee)
                .ThenInclude(e => e.EmployeeType)
                .ToListAsync();
        }

        public async Task<List<JournalEntryNote>> GetJournalEntryNotesForJournalEntry(int id)
        {
            return await _context.JournalEntryNotes.Where(j => j.JournalEntryId == id)
                .Include(j => j.Employee)
                .ThenInclude(e => e.User)
                .Include(j => j.Employee)
                .ThenInclude(e => e.EmployeeType)
                .ToListAsync();
        }

        public async Task<JournalEntryNote> UpdateJournalEntryNote(JournalEntryNote newJournalEntryNote)
        {
            if (newJournalEntryNote != null)
            {
                _context.JournalEntryNotes.Update(newJournalEntryNote);
                await _context.SaveChangesAsync();
                return newJournalEntryNote;
            }
            else
            {
                throw new ArgumentNullException(nameof(newJournalEntryNote));
            }
        }
    }
}
