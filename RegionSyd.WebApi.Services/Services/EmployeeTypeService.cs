using AutoMapper;
using RegionSyd.Common.DTOs;
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
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private readonly IEmployeeTypeRepository _employeeTypeRepository;
        private readonly IMapper _mapper;

        public EmployeeTypeService(IEmployeeTypeRepository employeeTypeRepository, IMapper mapper)
        {
            _employeeTypeRepository = employeeTypeRepository ?? throw new ArgumentNullException(nameof(employeeTypeRepository));
            _mapper = mapper;
        }
        public async Task<EmployeeTypeDTO> CreateEmployeeType(EmployeeTypeDTO employeeTypeDTO)
        {
            var employeeType = _mapper.Map<EmployeeType>(employeeTypeDTO);
            var returnTreatment = await _employeeTypeRepository.CreateEmployeeType(employeeType);
            return _mapper.Map<EmployeeTypeDTO>(returnTreatment);
        }
        public async Task<List<EmployeeTypeDTO>> GetEmployeeTypes()
        {
            var employeeTypes = await _employeeTypeRepository.GetEmployeeTypes();
            return _mapper.Map<List<EmployeeTypeDTO>>(employeeTypes);
        }
        public async Task<EmployeeTypeDTO> GetEmployeeType(int id)
        {
            var employeeType = await _employeeTypeRepository.GetEmployeeType(id);
            return _mapper.Map<EmployeeTypeDTO>(employeeType);
        }
        public async Task<EmployeeTypeDTO> UpdateEmployeeType(EmployeeTypeDTO employeeTypeDTO)
        {
            EmployeeType employeeType = _mapper.Map<EmployeeType>(employeeTypeDTO);
            EmployeeType returnEmployeeType = await _employeeTypeRepository.UpdateEmployeeType(employeeType);
            return _mapper.Map<EmployeeTypeDTO>(returnEmployeeType);
        }
        public async Task<bool> DeleteEmployeeType(int id)
        {
            return await _employeeTypeRepository.DeleteEmployeeType(id);
        }
    }
}
