using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using RegionSyd.WebApi.Services.Interfaces;
using RegionSyd.WebApi.Services.Services;

namespace RegionSyd.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeTypeController : Controller
    {
        private readonly IEmployeeTypeService _employeeTypeService;

        public EmployeeTypeController(IEmployeeTypeService employeeTypeService)
        {
            _employeeTypeService = employeeTypeService ?? throw new ArgumentNullException(nameof(employeeTypeService));
        }
        [HttpGet]
        public async Task<List<EmployeeTypeDTO>> GetEmployeeTypes()
        {
            return await _employeeTypeService.GetEmployeeTypes();
        }
        [HttpGet("{id}")]
        public async Task<EmployeeTypeDTO> GetEmployeeType(int id)
        {
            return await _employeeTypeService.GetEmployeeType(id);
        }
        [HttpPost]
        public async Task<EmployeeTypeDTO> CreateEmployeeType(EmployeeTypeDTO employeeTypeDTO)
        {
            return await _employeeTypeService.CreateEmployeeType(employeeTypeDTO);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteEmployeeType(int id)
        {
            return await _employeeTypeService.DeleteEmployeeType(id);
        }
        [HttpPut]
        public async Task<EmployeeTypeDTO> UpdateEmployeeType(EmployeeTypeDTO employeeTypeDTO)
        {
            return await _employeeTypeService.UpdateEmployeeType(employeeTypeDTO);
        }
    }
}
