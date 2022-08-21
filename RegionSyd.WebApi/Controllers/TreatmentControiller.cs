using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
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
            _treatmentService = treatmentService;
        }
        //Fjern repository using efter treatment er mappet til DTO
        [HttpGet]
        public async Task<ICollection<Treatment>> GetTreatments()
        {
            return await _treatmentService.GetTreatments();
        }
        [HttpPost]
        public async Task CreateTreatment(TreatmentDTO treatment)
        {
            await _treatmentService.CreateTreatment(treatment);
        }


    }
}
