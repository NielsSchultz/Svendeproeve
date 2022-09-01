using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> Create(EmployeeDTO employeeDTO);
        Task<string> Delete(int id);
        Task<List<EmployeeDTO>> GetAll();
        Task<EmployeeDTO> GetById(int id);
        Task<EmployeeDTO> Update(EmployeeDTO employeeDTO);
    }
}