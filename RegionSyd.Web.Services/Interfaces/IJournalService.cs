using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface IJournalService
    {
        Task<List<JournalDTO>> GetAll();
        Task<JournalDTO> GetById(int patientId);
        Task<JournalDTO> Create(JournalDTO journalDTO);
        Task<JournalDTO> Update(JournalDTO journalDTO);
        Task<string> Delete(int patientId);
    }
}