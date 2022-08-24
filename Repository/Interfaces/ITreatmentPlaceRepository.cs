using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface ITreatmentPlaceRepository
    {
        // Create new TreatmentPlace
        Task<TreatmentPlace> CreateTreatmentPlace(TreatmentPlace newTreatmentPlace);

        // Get all TreatmentPlaces
        Task<List<TreatmentPlace>> GetTreatmentPlaces();

        // Get TreatmentPlace by ID
        Task<TreatmentPlace> GetTreatmentPlace(int id);

        // Update TreatmentPlace
        Task<TreatmentPlace> UpdateTreatmentPlace(TreatmentPlace newTreatmentPlace);

        // Delete TreatmentPlace
        Task<bool> DeleteTreatmentPlace(int id);
    }
}
