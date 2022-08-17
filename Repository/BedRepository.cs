using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RegionSyd.Repositories.Interfaces;
using RegionSyd.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories
{
    public class BedRepository : IBedRepository
    {
        private readonly RegionSydDBContext _context;

        public BedRepository(RegionSydDBContext context)
        {
            _context = context;
        }

        public async Task<Bed> GetBedAsync(int id)
        {
            return await _context.Beds.Where(b => b.BedId == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Bed>> GetAllBedsAsync()
        {
            return await _context.Beds.AsNoTracking().ToListAsync();
        }

        public async Task CreateBedAsync(Bed bed)
        {
            _context.Beds.Add(bed);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBedAsync(Bed bed)
        {
            _context.Beds.Update(bed);
            await _context.SaveChangesAsync();
        }
    }
}
