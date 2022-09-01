using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;

namespace RegionSyd.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;

        public TreatmentController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService ?? throw new ArgumentNullException(nameof(treatmentService));
        }
        [HttpGet]
        public async Task<List<TreatmentDTO>> GetAllTreatments()
        {
            return await _treatmentService.GetTreatments();
        }
        [HttpGet("{id}")]
        public async Task<TreatmentDTO> GetTreatment(int id)
        {
            return await _treatmentService.GetTreatmentById(id);
        }
        [HttpPost]
        public async Task<TreatmentDTO> CreateTreatment(TreatmentDTO treatment)
        {
            return await _treatmentService.CreateTreatment(treatment);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteTreatment(int id)
        {
            return await _treatmentService.DeleteTreatment(id);
        }
        [HttpPut]
        public async Task<TreatmentDTO> UpdateTreatment(TreatmentDTO treatment)
        {
            return await _treatmentService.UpdateTreatment(treatment);
        }

    }
}
