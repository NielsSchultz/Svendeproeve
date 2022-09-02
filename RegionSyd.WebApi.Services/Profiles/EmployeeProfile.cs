using AutoMapper;
using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(a => a.EmployeeTypeName, b => b.MapFrom(c => c.EmployeeType.EmployeeTypeName))
                .ForMember(a => a.DepartmentName, b => b.MapFrom(c => c.Department.DepartmentName))
                .ForMember(a => a.EmployeeFirstName, b => b.MapFrom(c => c.User.FirstName))
                .ForMember(a => a.EmployeeMiddleName, b => b.MapFrom(c => c.User.MiddleName))
                .ForMember(a => a.EmployeeLastName, b => b.MapFrom(c => c.User.LastName));
            CreateMap<EmployeeDTO, Employee>();
        }        
    }
}
