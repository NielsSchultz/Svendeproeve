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
    public class TreatmentPlaceRepository : ITreatmentPlaceRepository
    {
        private readonly RegionSydDBContext _context;

        public TreatmentPlaceRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<TreatmentPlace> CreateTreatmentPlace(TreatmentPlace newTreatmentPlace)
        {
            if (newTreatmentPlace != null)
            {
                _context.TreatmentPlaces.Add(newTreatmentPlace);
                await _context.SaveChangesAsync();
                return newTreatmentPlace;
            }
            else
            {
                throw new ArgumentNullException(nameof(newTreatmentPlace));
            }
        }

        public async Task<bool> DeleteTreatmentPlace(int id)
        {
            var treatmentPlace = await _context.TreatmentPlaces.FindAsync(id);
            if (treatmentPlace != null)
            {
                _context.TreatmentPlaces.Remove(treatmentPlace);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(treatmentPlace));
            }
        }        

        public async Task<TreatmentPlace> GetTreatmentPlace(int id)
        {
            return await _context.TreatmentPlaces.Where(t => t.TreatmentPlaceId == id)
                .Include(t => t.TreatmentPlaceType)
                .FirstOrDefaultAsync();
        }

        public async Task<List<TreatmentPlace>> GetTreatmentPlaces()
        {
            return await _context.TreatmentPlaces
                .Include(t => t.TreatmentPlaceType)
                .ToListAsync();
        }

        public async Task<TreatmentPlace> UpdateTreatmentPlace(TreatmentPlace newTreatmentPlace)
        {
            if (newTreatmentPlace != null)
            {
                _context.TreatmentPlaces.Add(newTreatmentPlace);
                await _context.SaveChangesAsync();
                return newTreatmentPlace;
            }
            else
            {
                throw new ArgumentNullException(nameof(newTreatmentPlace));
            }
        }
    }
}
