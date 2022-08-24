﻿using Microsoft.EntityFrameworkCore;
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
            var treatment = await _context.JournalEntryNotes.FindAsync(id);
            if (treatment != null)
            {
                _context.JournalEntryNotes.Remove(treatment);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(treatment));
            }
        }

        public async Task<JournalEntryNote> GetJournalEntryNote(int id)
        {
            return await _context.JournalEntryNotes.FindAsync(id);
        }

        public async Task<List<JournalEntryNote>> GetJournalEntryNotes()
        {
            return await _context.JournalEntryNotes.ToListAsync();
        }

        public async Task<List<JournalEntryNote>> GetJournalEntryNotesForJournalEntry(int id)
        {
            return await _context.JournalEntryNotes.Where(j => j.JournalEntryId == id).ToListAsync();
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
