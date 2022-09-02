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
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDTO>()
                .ForMember(a => a.TreatmentPlaceName, b => b.MapFrom(c => c.TreatmentPlace.TreatmentPlaceName));
            CreateMap<DepartmentDTO, Department>();
        }        
    }
}
