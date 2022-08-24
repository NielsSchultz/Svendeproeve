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
    public class JournalEntryFileRepository : IJournalEntryFileRepository
    {
        private readonly RegionSydDBContext _context;

        public JournalEntryFileRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<JournalEntryFile> CreateJournalEntryFile(JournalEntryFile newJournalEntryFile)
        {
            if (newJournalEntryFile != null)
            {
                _context.JournalEntryFiles.Add(newJournalEntryFile);
                await _context.SaveChangesAsync();
                return newJournalEntryFile;
            }
            else
            {
                throw new ArgumentNullException(nameof(newJournalEntryFile));
            }
        }

        public async Task<bool> DeleteJournalEntryFile(int id)
        {
            var treatment = await _context.JournalEntryFiles.Where(j => j.FileId == id).FirstOrDefaultAsync();
            if (treatment != null)
            {
                _context.JournalEntryFiles.Remove(treatment);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(treatment));
            }
        }

        public async Task<JournalEntryFile> GetJournalEntryFile(int id)
        {
            return await _context.JournalEntryFiles.FindAsync(id);
        }

        public async Task<List<JournalEntryFile>> GetJournalEntryFiles()
        {
            return await _context.JournalEntryFiles.ToListAsync();
        }

        public async Task<List<JournalEntryFile>> GetJournalEntryFilesForJournalEntry(int id)
        {
            return await _context.JournalEntryFiles.Where(j => j.JournalEntryId == id).ToListAsync();
        }

        public async Task<JournalEntryFile> UpdateJournalEntryFile(JournalEntryFile newJournalEntryFile)
        {
            if (newJournalEntryFile != null)
            {
                _context.JournalEntryFiles.Update(newJournalEntryFile);
                await _context.SaveChangesAsync();
                return newJournalEntryFile;
            }
            else
            {
                throw new ArgumentNullException(nameof(newJournalEntryFile));
            }
        }
    }
}
