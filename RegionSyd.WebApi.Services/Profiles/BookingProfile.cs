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
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDTO>()
                .ForMember(a => a.TreatmentPlaceName, b => b.MapFrom(c => c.TreatmentPlace.TreatmentPlaceName))
                .ForMember(a => a.TreatmentName, b => b.MapFrom(c => c.Treatment.TreatmentName))
                .ForMember(a => a.TreatmentDuration, b => b.MapFrom(c => c.Treatment.TreatmentDuration));
            CreateMap<BookingDTO, Booking>();
        }        
    }
}
