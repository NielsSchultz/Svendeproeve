using RegionSyd.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface ITreatmentPlaceTypeService
    {
        // Create new TreatmentPlaceType
        Task<TreatmentPlaceTypeDTO> CreateTreatmentPlaceType(TreatmentPlaceTypeDTO treatmentPlaceTypeDTO);

        // Get all TreatmentPlaceTypes
        Task<List<TreatmentPlaceTypeDTO>> GetTreatmentPlaceTypes();

        // Get TreatmentPlaceType by ID
        Task<TreatmentPlaceTypeDTO> GetTreatmentPlaceType(int id);

        // Update TreatmentPlaceType
        Task<TreatmentPlaceTypeDTO> UpdateTreatmentPlaceType(TreatmentPlaceTypeDTO treatmentPlaceTypeDTO);

        // Delete TreatmentPlaceType
        Task<bool> DeleteTreatmentPlaceType(int id);
    }
}
