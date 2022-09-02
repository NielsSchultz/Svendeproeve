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
    public class TreatmentPlaceTypeProfile : Profile
    {
        public TreatmentPlaceTypeProfile()
        {
            CreateMap<TreatmentPlaceType, TreatmentPlaceTypeDTO>();
            CreateMap<TreatmentPlaceTypeDTO, TreatmentPlaceType>();
        }        
    }
}
