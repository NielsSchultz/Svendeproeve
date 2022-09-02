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
    public class JournalProfile : Profile
    {
        public JournalProfile()
        {
            CreateMap<Journal, JournalDTO>()
                .ForMember(a => a.UserId, b => b.MapFrom(c => c.Patient.UserId))
                .ForMember(a => a.FirstName, b => b.MapFrom(c => c.Patient.User.FirstName))
                .ForMember(a => a.MiddleName, b => b.MapFrom(c => c.Patient.User.MiddleName))
                .ForMember(a => a.LastName, b => b.MapFrom(c => c.Patient.User.LastName))
                .ForMember(a => a.Cpr, b => b.MapFrom(c => c.Patient.User.Cpr));

            CreateMap<JournalDTO, Journal>();
        }

    }
}
