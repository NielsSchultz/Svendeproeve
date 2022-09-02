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
    public class TreatmentPlaceTypeRepository : ITreatmentPlaceTypeRepository
    {
        private readonly RegionSydDBContext _context;

        public TreatmentPlaceTypeRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<TreatmentPlaceType> CreateTreatmentPlaceType(TreatmentPlaceType newTreatmentPlaceType)
        {
            if (newTreatmentPlaceType != null)
            {
                _context.TreatmentPlaceTypes.Add(newTreatmentPlaceType);
                await _context.SaveChangesAsync();
                return newTreatmentPlaceType;
            }
            else
            {
                throw new ArgumentNullException(nameof(newTreatmentPlaceType));
            }
        }

        public async Task<bool> DeleteTreatmentPlaceType(int id)
        {
            var treatmentPlaceType = await _context.TreatmentPlaceTypes.FindAsync(id);
            if (treatmentPlaceType != null)
            {
                _context.TreatmentPlaceTypes.Remove(treatmentPlaceType);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(treatmentPlaceType));
            }
        }

        public async Task<TreatmentPlaceType> GetTreatmentPlaceType(int id)
        {
            return await _context.TreatmentPlaceTypes.FindAsync(id);
        }

        public async Task<List<TreatmentPlaceType>> GetTreatmentPlaceTypes()
        {
            return await _context.TreatmentPlaceTypes.ToListAsync();
        }

        public async Task<TreatmentPlaceType> UpdateTreatmentPlaceType(TreatmentPlaceType newTreatmentPlaceType)
        {
            if (newTreatmentPlaceType != null)
            {
                _context.TreatmentPlaceTypes.Update(newTreatmentPlaceType);
                await _context.SaveChangesAsync();
                return newTreatmentPlaceType;
            }
            else
            {
                throw new ArgumentNullException(nameof(newTreatmentPlaceType));
            }
        }
    }
}
