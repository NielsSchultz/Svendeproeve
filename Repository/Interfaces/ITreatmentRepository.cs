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
        // Get all treatments
        Task<List<Treatment>> GetTreatments();
        Task<Treatment> GetTreatmentById(int id);
        Task<Treatment> CreateTreatment(Treatment treatment);
        Task<Treatment> UpdateTreatment(Treatment treatment);
        Task<bool> DeleteTreatment(int id);
    }
}
