using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;
using RegionSyd.WebApi.Services.Services;

namespace RegionSyd.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));
        }
        [HttpGet]
        public async Task<List<DepartmentDTO>> GetAllDepartments()
        {
            return await _departmentService.GetDepartments();
        }
        [HttpGet("{id}")]
        public async Task<DepartmentDTO> GetDepartment(int id)
        {
            return await _departmentService.GetDepartment(id);
        }
        [HttpGet("ByTreatmentPlace/{id}")]
        public async Task<List<DepartmentDTO>> GetDepartmentsForTreatmentPlace(int id)
        {
            return await _departmentService.GetDepartmentsForTreatmentPlace(id);
        }
        
        [HttpPost]
        public async Task<DepartmentDTO> CreateDepartment(DepartmentDTO departmentDTO)
        {
            return await _departmentService.CreateDepartment(departmentDTO);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteDepartment(int id)
        {
            return await _departmentService.DeleteDepartment(id);
        }
        [HttpPut]
        public async Task<DepartmentDTO> UpdateDepartment(DepartmentDTO departmentDTO)
        {
            return await _departmentService.UpdateDepartment(departmentDTO);
        }
    }
}
