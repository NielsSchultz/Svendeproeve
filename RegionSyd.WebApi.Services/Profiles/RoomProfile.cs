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
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDTO>()
            .ForMember(a => a.DepartmentName, b => b.MapFrom(c => c.Department.DepartmentName));
            CreateMap<RoomDTO, Room>();
        }        
    }
}
