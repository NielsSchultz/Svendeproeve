using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        // Create new Patient
        Task<Patient> CreatePatient(Patient newPatient);

        // Get all Patients
        Task<List<Patient>> GetPatients();

        // Get Patient by ID
        Task<Patient> GetPatient(int id);

        // Update Patient
        Task<Patient> UpdatePatient(Patient newPatient);

        // Delete Patient
        Task<bool> DeletePatient(int id);
    }
}
