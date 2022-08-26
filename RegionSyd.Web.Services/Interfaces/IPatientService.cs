using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface IPatientService
    {
        Task<PatientDTO> Create(PatientDTO patientDTO);
        Task<string> Delete(int id);
        Task<PatientDTO> GetById(int id);
        Task<PatientDTO> Update(PatientDTO patientDTO);
    }
}