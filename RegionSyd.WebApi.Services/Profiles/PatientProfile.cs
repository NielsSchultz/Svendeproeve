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
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientDTO>()
                .ForMember(a => a.Cpr, b => b.MapFrom(c => c.User.Cpr))
                .ForMember(a => a.Address, b => b.MapFrom(c => c.User.Address))
                .ForMember(a => a.ZipCode, b => b.MapFrom(c => c.User.ZipCode))
                .ForMember(a => a.CityName, b => b.MapFrom(c => c.User.CityName))
                .ForMember(a => a.FirstName, b => b.MapFrom(c => c.User.FirstName))
                .ForMember(a => a.MiddleName, b => b.MapFrom(c => c.User.MiddleName))
                .ForMember(a => a.LastName, b => b.MapFrom(c => c.User.LastName))
                .ForMember(a => a.Phone, b => b.MapFrom(c => c.User.Phone))
                .ForMember(a => a.Email, b => b.MapFrom(c => c.User.Email));
            CreateMap<PatientDTO, Patient>();
        }        
    }
}
