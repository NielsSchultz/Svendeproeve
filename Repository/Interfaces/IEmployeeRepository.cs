using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        // Create new journal
        Task<Employee> CreateEmployee(Employee newEmployee);

        // Get all journals
        Task<List<Employee>> GetEmployees();

        // Get journal by ID
        Task<Employee> GetEmployee(int id);

        // Update journal
        Task<Employee> UpdateEmployee(Employee newEmployee);

        // Delete Employee
        Task<bool> DeleteEmployee(int id);
    }
}
