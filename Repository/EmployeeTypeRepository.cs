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
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {
        private readonly RegionSydDBContext _context;

        public EmployeeTypeRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<EmployeeType> CreateEmployeeType(EmployeeType newEmployeeType)
        {
            if (newEmployeeType != null)
            {
                _context.EmployeeTypes.Add(newEmployeeType);
                await _context.SaveChangesAsync();
                return newEmployeeType;
            }
            else
            {
                throw new ArgumentNullException(nameof(newEmployeeType));
            }
        }

        public async Task<bool> DeleteEmployeeType(int id)
        {
            var treatment = await _context.EmployeeTypes.Where(b => b.EmployeeTypeId == id).FirstOrDefaultAsync();
            if (treatment != null)
            {
                _context.EmployeeTypes.Remove(treatment);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(treatment));
            }
        }

        public async Task<EmployeeType> GetEmployeeType(int id)
        {
            return await _context.EmployeeTypes.FindAsync(id);
        }

        public async Task<List<EmployeeType>> GetEmployeeTypes()
        {
            return await _context.EmployeeTypes.ToListAsync();
        }

        public async Task<EmployeeType> UpdateEmployeeType(EmployeeType newEmployeeType)
        {
            if (newEmployeeType != null)
            {
                _context.EmployeeTypes.Update(newEmployeeType);
                await _context.SaveChangesAsync();
                return newEmployeeType;
            }
            else
            {
                throw new ArgumentNullException(nameof(newEmployeeType));
            }
        }
    }
}
