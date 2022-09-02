using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> CreateDepartment(DepartmentDTO departmentDTO);
        Task<List<DepartmentDTO>> GetDepartments();
        Task<DepartmentDTO> GetDepartment(int id);
        Task<List<DepartmentDTO>> GetDepartmentsForTreatmentPlace(int id);
        Task<DepartmentDTO> UpdateDepartment(DepartmentDTO departmentDTO);
        Task<bool> DeleteDepartment(int id);
    }
}
