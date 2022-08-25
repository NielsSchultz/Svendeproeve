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
    public class JournalEntryStatusRepository : IJournalEntryStatusRepository
    {
        private readonly RegionSydDBContext _context;

        public JournalEntryStatusRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<JournalEntryStatus> CreateJournalEntryStatus(JournalEntryStatus newJournalEntryStatus)
        {
            if (newJournalEntryStatus != null)
            {
                _context.JournalEntryStatuses.Add(newJournalEntryStatus);
                await _context.SaveChangesAsync();
                return newJournalEntryStatus;
            }
            else
            {
                throw new ArgumentNullException(nameof(newJournalEntryStatus));
            }
        }

        public async Task<bool> DeleteJournalEntryStatus(int id)
        {
            var journalEntryStatus = await _context.JournalEntryStatuses.Where(b => b.JournalEntryStatusId == id).FirstOrDefaultAsync();
            if (journalEntryStatus != null)
            {
                _context.JournalEntryStatuses.Remove(journalEntryStatus);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(journalEntryStatus));
            }
        }

        public async Task<JournalEntryStatus> GetJournalEntryStatus(int id)
        {
            return await _context.JournalEntryStatuses.FindAsync(id);
        }

        public async Task<List<JournalEntryStatus>> GetJournalEntryStatuses()
        {
            return await _context.JournalEntryStatuses.ToListAsync();
        }

        public async Task<JournalEntryStatus> UpdateJournalEntryStatus(JournalEntryStatus newJournalEntryStatus)
        {
            if (newJournalEntryStatus != null)
            {
                _context.JournalEntryStatuses.Update(newJournalEntryStatus);
                await _context.SaveChangesAsync();
                return newJournalEntryStatus;
            }
            else
            {
                throw new ArgumentNullException(nameof(newJournalEntryStatus));
            }
        }
    }
}
