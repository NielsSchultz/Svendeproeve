using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface ITreatmentService
    {
        Task<List<TreatmentDTO>> GetAll();
        Task<TreatmentDTO> GetById(int id);
        Task<TreatmentDTO> Create(TreatmentDTO treatmentDTO);
        Task<TreatmentDTO> Update(TreatmentDTO treatmentDTO);
        Task<string> Delete(int id);
    }
}