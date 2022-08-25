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
    public class JournalRepository : IJournalRepository
    {
        private readonly RegionSydDBContext _context;

        public JournalRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Journal> CreateJournal(Journal newJournal)
        {
            if (newJournal != null)
            {
                _context.Journals.Add(newJournal);
                await _context.SaveChangesAsync();
                return newJournal;
            }
            else
            {
                throw new ArgumentNullException(nameof(newJournal));
            }
        }

        public async Task<bool> DeleteJournal(int id)
        {
            var journal = await _context.Journals.Where(j => j.JournalId == id).FirstOrDefaultAsync();
            if (journal != null)
            {
                _context.Journals.Remove(journal);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(journal));
            }
        }

        public async Task<Journal> GetJournal(int id)
        {
            return await _context.Journals.Where(j => j.JournalId == id)
                .Include(j => j.JournalEntries)
                .Include(j => j.Patient)
                .ThenInclude(p => p.User)
                .FirstOrDefaultAsync();
        }

        public async Task<Journal> GetJournalByPatientID(int id)
        {
            return await _context.Journals.Where(j => j.PatientId == id)
                .Include(j => j.JournalEntries)
                .Include(j => j.Patient)
                .ThenInclude(p => p.User)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Journal>> GetJournals()
        {
            return await _context.Journals
                .Include(j => j.JournalEntries)
                .Include(j => j.Patient)
                .ThenInclude(p => p.User)
                .ToListAsync();
        }

        public async Task<Journal> UpdateJournal(Journal newJournal)
        {
            if (newJournal != null)
            {
                _context.Journals.Update(newJournal);
                await _context.SaveChangesAsync();
                return newJournal;
            }
            else
            {
                throw new ArgumentNullException(nameof(newJournal));
            }
        }
    }
}
