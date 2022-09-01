using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;

namespace RegionSyd.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentPlaceTypeController : ControllerBase
    {
        private readonly ITreatmentPlaceTypeService _treatmentPlaceTypeService;

        public TreatmentPlaceTypeController(ITreatmentPlaceTypeService treatmentPlaceTypeService)
        {
            _treatmentPlaceTypeService = treatmentPlaceTypeService ?? throw new ArgumentNullException(nameof(treatmentPlaceTypeService));
        }
        [HttpPost]
        public async Task<TreatmentPlaceTypeDTO> CreateTreatmentPlaceType(TreatmentPlaceTypeDTO treatmentPlaceTypeDTO)
        {
            return await _treatmentPlaceTypeService.CreateTreatmentPlaceType(treatmentPlaceTypeDTO);
        }
        [HttpGet]
        public async Task<List<TreatmentPlaceTypeDTO>> GetTreatmentPlaceTypes()
        {
            return await _treatmentPlaceTypeService.GetTreatmentPlaceTypes();
        }
        [HttpGet("{id}")]
        public async Task<TreatmentPlaceTypeDTO> GetTreatmentPlaceType(int id)
        {
            return await _treatmentPlaceTypeService.GetTreatmentPlaceType(id);
        }
        [HttpPut]
        public async Task<TreatmentPlaceTypeDTO> UpdateTreatmentPlaceType(TreatmentPlaceTypeDTO treatmentPlaceTypeDTO)
        {
            return await _treatmentPlaceTypeService.UpdateTreatmentPlaceType(treatmentPlaceTypeDTO);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteTreatmentPlaceType(int id)
        {
            return await _treatmentPlaceTypeService.DeleteTreatmentPlaceType(id);
        }
    }
}
