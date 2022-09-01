using AutoMapper;
using RegionSyd.Common.DTOs;
using RegionSyd.Repositories;
using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using RegionSyd.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<EmployeeDTO> CreateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            var returnEmployee = await _employeeRepository.CreateEmployee(employee);
            return _mapper.Map<EmployeeDTO>(returnEmployee);
        }
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }
        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            return _mapper.Map<EmployeeDTO>(employee);
        }
        public async Task<EmployeeDTO> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = _mapper.Map<Employee>(employeeDTO);
            Employee returnEmployee = await _employeeRepository.UpdateEmployee(employee);
            return _mapper.Map<EmployeeDTO>(returnEmployee);
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }
    }
}
