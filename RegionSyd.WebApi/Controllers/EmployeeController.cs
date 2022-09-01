using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;
using RegionSyd.WebApi.Services.Services;

namespace RegionSyd.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }
        [HttpGet]
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            return await _employeeService.GetEmployees();
        }
        [HttpGet("{id}")]
        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            return await _employeeService.GetEmployee(id);
        }

        [HttpPost]
        public async Task<EmployeeDTO> CreateEmployee(EmployeeDTO employeeDTO)
        {
            return await _employeeService.CreateEmployee(employeeDTO);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteEmployee(int id)
        {
            return await _employeeService.DeleteEmployee(id);
        }
        [HttpPut]
        public async Task<EmployeeDTO> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            return await _employeeService.UpdateEmployee(employeeDTO);
        }
    }
}
