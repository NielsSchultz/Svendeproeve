using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IEmployeeTypeRepository
    {
        // Create new Type
        Task<EmployeeType> CreateEmployeeType(EmployeeType employeeType);

        // Get all Types
        Task<List<EmployeeType>> GetEmployeeTypes();

        // Get Type by ID
        Task<EmployeeType> GetEmployeeType(int id);

        // Update Type
        Task<EmployeeType> UpdateEmployeeType(EmployeeType employeeType);

        // Delete Employee
        Task<bool> DeleteEmployeeType(int id);
    }
}
