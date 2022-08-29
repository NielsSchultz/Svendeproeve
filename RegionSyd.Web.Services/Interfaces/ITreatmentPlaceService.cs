using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface ITreatmentPlaceService
    {
        Task<TreatmentPlaceDTO> Create(TreatmentPlaceDTO treatmentPlaceDTO);
        Task<string> Delete(int id);
        Task<List<TreatmentPlaceDTO>> GetAll();
        Task<TreatmentPlaceDTO> GetById(int id);
        Task<TreatmentPlaceDTO> Update(TreatmentPlaceDTO treatmentPlaceDTO);
    }
}