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
    public class JournalEntryProfile : Profile
    {
        public JournalEntryProfile()
        {
            CreateMap<JournalEntry, JournalEntryDTO>()
                .ForMember(a => a.PatientId, b => b.MapFrom(c => c.Journal.PatientId))
                .ForMember(a => a.StatusName, b => b.MapFrom(c => c.JournalEntryStatus.StatusName))
                .ForMember(a => a.JournalEntryFilesCount, b => b.MapFrom(c => c.JournalEntryFiles.Count))
                .ForMember(a => a.JournalEntryNotesCount, b => b.MapFrom(c => c.JournalEntryNotes.Count));
            CreateMap<JournalEntryDTO, JournalEntry>();
        }        
    }
}
