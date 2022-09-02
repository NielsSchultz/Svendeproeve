using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IEmployeeTypeService
    {
        // Create new Type
        Task<EmployeeTypeDTO> CreateEmployeeType(EmployeeTypeDTO employeeTypeDTO);

        // Get all Types
        Task<List<EmployeeTypeDTO>> GetEmployeeTypes();

        // Get Type by ID
        Task<EmployeeTypeDTO> GetEmployeeType(int id);

        // Update Type
        Task<EmployeeTypeDTO> UpdateEmployeeType(EmployeeTypeDTO employeeTypeDTO);

        // Delete Employee
        Task<bool> DeleteEmployeeType(int id);
    }
}
