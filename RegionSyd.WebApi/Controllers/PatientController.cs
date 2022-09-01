using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;

namespace RegionSyd.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpPost]
        public async Task<PatientDTO> CreatePatient(PatientDTO patientDTO)
        {
            return await _patientService.CreatePatient(patientDTO);
        }
        [HttpGet]
        public async Task<List<PatientDTO>> GetPatients()
        {
            return await _patientService.GetPatients();
        }
        [HttpGet("{id}")]
        public async Task<PatientDTO> GetPatient(int id)
        {
            var test = await _patientService.GetPatient(id);
            return test;
        }
        [HttpPut]
        public async Task<PatientDTO> UpdatePatient(PatientDTO patientDTO)
        {
            return await _patientService.UpdatePatient(patientDTO);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeletePatient(int id)
        {
            return await _patientService.DeletePatient(id);
        }
        
    }
}
