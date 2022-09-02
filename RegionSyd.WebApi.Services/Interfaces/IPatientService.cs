using RegionSyd.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IPatientService
    {
        // Create new Patient
        Task<PatientDTO> CreatePatient(PatientDTO patientDTO);

        // Get all Patients
        Task<List<PatientDTO>> GetPatients();

        // Get Patient by ID
        Task<PatientDTO> GetPatient(int id);

        // Update Patient
        Task<PatientDTO> UpdatePatient(PatientDTO patientDTO);

        // Delete Patient
        Task<bool> DeletePatient(int id);
    }
}
