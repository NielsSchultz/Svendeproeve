using RegionSyd.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IJournalService
    {
        Task<List<JournalDTO>> GetJournals();
        Task<JournalDTO> GetJournalByPatientID(int id);
        Task<JournalDTO> CreateJournal(JournalDTO journal);
        Task<JournalDTO> UpdateJournal(JournalDTO journal);
        Task<bool> DeleteJournal(int id);
    }
}
