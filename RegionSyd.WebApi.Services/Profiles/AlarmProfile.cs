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
    public class AlarmProfile : Profile
    {
        public AlarmProfile()
        {
            CreateMap<Alarm, AlarmDTO>();
            CreateMap<AlarmDTO, Alarm>();
        }        
    }
}
