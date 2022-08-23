using AutoMapper;
using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitor = RegionSyd.Repositories.Entities.Monitor;

namespace RegionSyd.WebApi.Services.Profiles
{
    public class MonitorProfile : Profile
    {
        public MonitorProfile()
        {
            CreateMap<Monitor, MonitorDTO>();
            CreateMap<MonitorDTO, Monitor>();
        }        
    }
}
