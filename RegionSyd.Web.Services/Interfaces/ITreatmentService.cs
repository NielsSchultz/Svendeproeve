using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface ITreatmentService
    {
        Task<TreatmentDTO> Create(TreatmentDTO treatmentDTO);
        Task<string> Delete(int id);
        Task<JournalDTO> GetById(int id);
        Task<TreatmentDTO> Update(TreatmentDTO treatmentDTO);
    }
}