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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly RegionSydDBContext _context;

        public DepartmentRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Department> CreateDepartment(Department newDepartment)
        {
            if (newDepartment != null)
            {
                _context.Departments.Add(newDepartment);
                await _context.SaveChangesAsync();
                return newDepartment;
            }
            else
            {
                throw new ArgumentNullException(nameof(newDepartment));
            }
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var department = await _context.Departments.Where(b => b.DepartmentId == id).FirstOrDefaultAsync();
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(department));
            }
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await _context.Departments.Where(d => d.DepartmentId == id).FirstOrDefaultAsync();
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<List<Department>> GetDepartmentsForTreatmentPlace(int id)
        {
            return await _context.Departments.Where(d => d.TreatmentPlaceId == id).ToListAsync();
        }

        public async Task<Department> UpdateDepartment(Department newDepartment)
        {
            if (newDepartment != null)
            {
                _context.Departments.Update(newDepartment);
                await _context.SaveChangesAsync();
                return newDepartment;
            }
            else
            {
                throw new ArgumentNullException(nameof(newDepartment));
            }
        }
    }
}
