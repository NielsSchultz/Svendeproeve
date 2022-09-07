using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;

namespace RegionSyd.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentPlaceController : ControllerBase
    {
        private readonly ITreatmentPlaceService _treatmentPlaceService;

        public TreatmentPlaceController(ITreatmentPlaceService treatmentPlaceService)
        {
            _treatmentPlaceService = treatmentPlaceService;
        }
        [HttpPost]
        public async Task<TreatmentPlaceDTO> CreateTreatmentPlace(TreatmentPlaceDTO treatmentPlaceDTO)
        {
            return await _treatmentPlaceService.CreateTreatmentPlace(treatmentPlaceDTO);
        }
        [HttpGet]
        public async Task<List<TreatmentPlaceDTO>> GetTreatmentPlaces()
        {
            return await _treatmentPlaceService.GetTreatmentPlaces();
        }
        [HttpGet("{id}")]
        public async Task<TreatmentPlaceDTO> GetTreatmentPlace(int id)
        {
            return await _treatmentPlaceService.GetTreatmentPlace(id);
        }
        [HttpPut]
        public async Task<TreatmentPlaceDTO> UpdateTreatmentPlace(TreatmentPlaceDTO treatmentPlaceDTO)
        {
            return await _treatmentPlaceService.UpdateTreatmentPlace(treatmentPlaceDTO);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteTreatmentPlace(int id)
        {
            return await _treatmentPlaceService.DeleteTreatmentPlace(id);
        }
    }
}
