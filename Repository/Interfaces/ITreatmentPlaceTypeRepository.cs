using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface ITreatmentPlaceTypeRepository
    {
        // Create new TreatmentPlaceType
        Task<TreatmentPlaceType> CreateTreatmentPlaceType(TreatmentPlaceType newTreatmentPlaceType);

        // Get all TreatmentPlaceTypes
        Task<List<TreatmentPlaceType>> GetTreatmentPlaceTypes();

        // Get TreatmentPlaceType by ID
        Task<TreatmentPlaceType> GetTreatmentPlaceType(int id);

        // Update TreatmentPlaceType
        Task<TreatmentPlaceType> UpdateTreatmentPlaceType(TreatmentPlaceType newTreatmentPlaceType);

        // Delete TreatmentPlaceType
        Task<bool> DeleteTreatmentPlaceType(int id);
    }
}
