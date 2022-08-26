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
    public class JournalEntryFileProfile : Profile
    {
        public JournalEntryFileProfile()
        {
            CreateMap<JournalEntryFile, JournalEntryFileDTO>()
                .ForMember(a => a.EmployeeFirstName, b => b.MapFrom(c => c.Employee.User.FirstName))
                .ForMember(a => a.EmployeeMiddleName, b => b.MapFrom(c => c.Employee.User.MiddleName))
                .ForMember(a => a.EmployeeLastName, b => b.MapFrom(c => c.Employee.User.LastName))
                .ForMember(a => a.EmployeeTypeName, b => b.MapFrom(c => c.Employee.EmployeeType.EmployeeTypeName))
                .ForMember(a => a.FileTypeName, b => b.MapFrom(c => c.FileType.FileTypeName));
            CreateMap<JournalEntryFileDTO, JournalEntryFile>();
        }        
    }
}
