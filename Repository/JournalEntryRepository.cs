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
    public class JournalEntryRepository : IJournalEntryRepository
    {
        private readonly RegionSydDBContext _context;

        public JournalEntryRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<JournalEntry> CreateJournalEntry(JournalEntry newJournalEntry)
        {
            if (newJournalEntry != null)
            {
                _context.JournalEntries.Add(newJournalEntry);
                await _context.SaveChangesAsync();
                return newJournalEntry;
            }
            else
            {
                throw new ArgumentNullException(nameof(newJournalEntry));
            }
        }

        public async Task<bool> DeleteJournalEntry(int id)
        {
            var journalEntry = await _context.JournalEntries.FindAsync(id);
            if (journalEntry != null)
            {
                _context.JournalEntries.Remove(journalEntry);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(journalEntry));
            }
        }

        public async Task<List<JournalEntry>> GetJournalEntries()
        {
            return await _context.JournalEntries
                .Include(j => j.Journal)
                .ThenInclude(j => j.Patient)
                .ThenInclude(p => p.User)
                .Include(j => j.TreatmentPlace)
                .Include(j => j.Department)
                .Include(j => j.JournalEntryFiles)
                .ThenInclude(f => f.Count)
                .Include(j => j.JournalEntryNotes)
                .ThenInclude(n => n.Count)
                .Include(j => j.JournalEntryStatus)
                .ToListAsync();
        }

        public async Task<List<JournalEntry>> GetJournalEntriesForJournal(int id)
        {
            return await _context.JournalEntries.Where(j => j.JournalId == id)
                .Include(j => j.Journal)
                .ThenInclude(j => j.Patient)
                .ThenInclude(p => p.User)
                .Include(j => j.TreatmentPlace)
                .Include(j => j.Department)
                .Include(j => j.JournalEntryFiles)
                .Include(j => j.JournalEntryNotes)
                .Include(j => j.JournalEntryStatus)
                .ToListAsync();
        }

        public async Task<JournalEntry> GetJournalEntry(int id)
        {
            return await _context.JournalEntries.Where(j => j.JournalEntryId == id)
                .Include(j => j.Journal)
                .ThenInclude(j => j.Patient)
                .ThenInclude(p => p.User)
                .Include(j => j.TreatmentPlace)
                .Include(j => j.Department)
                .Include(j => j.JournalEntryFiles)
                .Include(j => j.JournalEntryNotes)
                .Include(j => j.JournalEntryStatus)
                .FirstOrDefaultAsync();
        }

        public async Task<JournalEntry> UpdateJournalEntry(JournalEntry newJournalEntry)
        {
            if (newJournalEntry != null)
            {
                _context.JournalEntries.Update(newJournalEntry);
                await _context.SaveChangesAsync();
                return newJournalEntry;
            }
            else
            {
                throw new ArgumentNullException(nameof(newJournalEntry));
            }
        }
    }
}
