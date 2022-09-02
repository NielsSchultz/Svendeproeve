using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface ITreatmentPlaceService
    {
        // Create new TreatmentPlace
        Task<TreatmentPlaceDTO> CreateTreatmentPlace(TreatmentPlaceDTO newTreatmentPlace);

        // Get all TreatmentPlaces
        Task<List<TreatmentPlaceDTO>> GetTreatmentPlaces();

        // Get TreatmentPlace by ID
        Task<TreatmentPlaceDTO> GetTreatmentPlace(int id);

        // Update TreatmentPlace
        Task<TreatmentPlaceDTO> UpdateTreatmentPlace(TreatmentPlaceDTO newTreatmentPlace);

        // Delete TreatmentPlace
        Task<bool> DeleteTreatmentPlace(int id);
    }
}
