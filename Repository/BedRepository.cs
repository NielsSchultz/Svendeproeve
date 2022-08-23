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
        public async Task<List<Bed>> GetBeds()
        {
            return await _context.Beds.ToListAsync();
        }
        public async Task<Bed> GetBedById(int id)
        {
            return await _context.Beds.FindAsync(id);
        }
        public async Task<Bed> CreateBed(Bed newBed)
        {
            if (newBed != null)
            {
                _context.Beds.Add(newBed);
                await _context.SaveChangesAsync();
                return newBed;
            }
            else
            {
                throw new ArgumentNullException(nameof(newBed));
            }
        }
        public async Task<Bed> UpdateBed(Bed newBed)
        {
            if (newBed != null)
            {
                _context.Beds.Update(newBed);
                await _context.SaveChangesAsync();
                return newBed;
            }
            else
            {
                throw new ArgumentNullException(nameof(newBed));
            }
        }
        public async Task<bool> DeleteBed(int id)
        {
            var bed = await _context.Beds.Where(b => b.BedId == id).FirstOrDefaultAsync();
            if (bed != null)
            {
                _context.Beds.Remove(bed);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(bed));
            }
        }
        public async Task<List<Bed>> GetUnoccupiedBeds()
        {
            return await _context.Beds.Where(b => b.IsOccupied == false).ToListAsync();
        }
    }
}
