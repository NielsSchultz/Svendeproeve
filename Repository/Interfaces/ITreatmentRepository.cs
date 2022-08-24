using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface ITreatmentRepository
    {
        Task<Treatment> CreateTreatment(Treatment newTreatment);
        Task<List<Treatment>> GetTreatments();
        Task<Treatment> GetTreatment(int id);
        Task<List<Treatment>> GetTreatmentsForHospital(int id);
        Task<Treatment> UpdateTreatment(Treatment newTreatment);
        Task<bool> DeleteTreatment(int id);
    }
}
