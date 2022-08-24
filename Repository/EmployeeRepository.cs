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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RegionSydDBContext _context;

        public EmployeeRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            if (newEmployee != null)
            {
                _context.Employees.Add(newEmployee);
                await _context.SaveChangesAsync();
                return newEmployee;
            }
            else
            {
                throw new ArgumentNullException(nameof(newEmployee));
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.Where(b => b.EmployeeId == id).FirstOrDefaultAsync();
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(employee));
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesForTreatmentPlace(int id)
        {
            return await _context.Employees.Where(e => e.Department.TreatmentPlaceId == id).ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee newEmployee)
        {
            if (newEmployee != null)
            {
                _context.Employees.Update(newEmployee);
                await _context.SaveChangesAsync();
                return newEmployee;
            }
            else
            {
                throw new ArgumentNullException(nameof(newEmployee));
            }
        }
    }
}
