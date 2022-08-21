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
    }
}
