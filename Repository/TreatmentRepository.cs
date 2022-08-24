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
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly RegionSydDBContext _context;

        public TreatmentRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Treatment>> GetTreatments()
        {
            return await _context.Treatments.ToListAsync();
        }

        public async Task<Treatment> GetTreatment(int id)
        {
            return await _context.Treatments.FindAsync(id);
        }

        public async Task<List<Treatment>> GetTreatmentsForHospital(int id)
        {
            return await _context.Treatments.Where(t => t.Department.TreatmentPlaceId == id).ToListAsync();
        }

        public async Task<Treatment> CreateTreatment(Treatment newTreatment)
        {
            if (newTreatment != null)
            {
                _context.Treatments.Add(newTreatment);
                await _context.SaveChangesAsync();
                return newTreatment;
            }
            else
            {
                throw new ArgumentNullException(nameof(newTreatment));
            }
        }

        public async Task<Treatment> UpdateTreatment(Treatment newTreatment)
        {
            if (newTreatment != null)
            {
                _context.Treatments.Update(newTreatment);
                await _context.SaveChangesAsync();
                return newTreatment;
            }
            else
            {
                throw new ArgumentNullException(nameof(newTreatment));
            }
        }

        public async Task<bool> DeleteTreatment(int id)
        {
            var treatment = await _context.Treatments.Where(b => b.TreatmentId == id).FirstOrDefaultAsync();
            if (treatment != null)
            {
                _context.Treatments.Remove(treatment);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(treatment));
            }
        }
    }
}
