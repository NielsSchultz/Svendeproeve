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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<DepartmentDTO> CreateDepartment(DepartmentDTO departmentDTO)
        {
            var department = _mapper.Map<Department>(departmentDTO);
            var returnDepartment = await _departmentRepository.CreateDepartment(department);
            return _mapper.Map<DepartmentDTO>(returnDepartment);
        }
        public async Task<List<DepartmentDTO>> GetDepartments()
        {
            var departments = await _departmentRepository.GetDepartments();
            return _mapper.Map<List<DepartmentDTO>>(departments);
        }
        public async Task<DepartmentDTO> GetDepartment(int id)
        {
            var department = await _departmentRepository.GetDepartment(id);
            return _mapper.Map<DepartmentDTO>(department);
        }
        public async Task<List<DepartmentDTO>> GetDepartmentsForTreatmentPlace(int id)
        {
            var departments = await _departmentRepository.GetDepartmentsForTreatmentPlace(id);
            return _mapper.Map<List<DepartmentDTO>>(departments);
        }
        public async Task<DepartmentDTO> UpdateDepartment(DepartmentDTO departmentDTO)
        {
            Department department = _mapper.Map<Department>(departmentDTO);
            Department returnDepartment = await _departmentRepository.UpdateDepartment(department);
            return _mapper.Map<DepartmentDTO>(returnDepartment);
        }
        public async Task<bool> DeleteDepartment(int id)
        {
            return await _departmentRepository.DeleteDepartment(id);
        }
    }
}
