using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RegionSyd.Repositories.Interfaces;
using RegionSyd.Repositories.Entities;
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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Bed> GetBedAsync(int id)
        {
            return await _context.Beds.Where(b => b.BedId == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Bed>> GetAllBedsAsync()
        {
            return await _context.Beds.AsNoTracking().ToListAsync();
        }

        public async Task<Bed> CreateBedAsync(Bed newBed)
        {
            if (newBed != null)
            {
                _context.Beds.Add(newBed);
                await _context.SaveChangesAsync();
                return newBed;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<Bed> UpdateBedAsync(Bed newBed)
        {
            var bed = GetBedAsync(newBed.BedId);
            if(bed != null)
            {
                _context.Beds.Update(newBed);
                await _context.SaveChangesAsync();
                return newBed;
            } else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
