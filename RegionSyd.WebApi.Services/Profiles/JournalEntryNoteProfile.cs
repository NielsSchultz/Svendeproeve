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
    public class JournalEntryNoteProfile : Profile
    {
        public JournalEntryNoteProfile()
        {
            CreateMap<JournalEntryNote, JournalEntryNoteDTO>()
                .ForMember(a => a.EmployeeTypeName, b => b.MapFrom(c => c.Employee.EmployeeType.EmployeeTypeName))
                .ForMember(a => a.EmployeeFirstname, b => b.MapFrom(c => c.Employee.User.FirstName))
                .ForMember(a => a.EmployeeMiddlename, b => b.MapFrom(c => c.Employee.User.MiddleName))
                .ForMember(a => a.EmployeeLastname, b => b.MapFrom(c => c.Employee.User.LastName));
            CreateMap<JournalEntryNoteDTO, JournalEntryNote>();
        }        
    }
}
