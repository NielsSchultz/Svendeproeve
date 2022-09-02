using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> Create(DepartmentDTO departmentDTO);
        Task<string> Delete(int id);
        Task<DepartmentDTO> GetById(int id);
        Task<List<DepartmentDTO>> GetDepartmentsForTreatmentPlace(int id);
        Task<DepartmentDTO> Update(DepartmentDTO departmentDTO);
    }
}