using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IEmployeeService
    {
        // Create new Employee
        Task<EmployeeDTO> CreateEmployee(EmployeeDTO employeeDTO);

        // Get all Employees
        Task<List<EmployeeDTO>> GetEmployees();

        // Get Employee by ID
        Task<EmployeeDTO> GetEmployee(int id);

        // Update Employee
        Task<EmployeeDTO> UpdateEmployee(EmployeeDTO employeeDTO);

        // Delete Employee
        Task<bool> DeleteEmployee(int id);
    }
}
