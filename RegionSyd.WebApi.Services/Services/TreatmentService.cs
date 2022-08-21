using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using RegionSyd.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;

        public TreatmentService(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository ?? throw new ArgumentNullException(nameof(treatmentRepository));
        }
        //Map til TreatmentDTO, fjern derefter repository using..
        public async Task<List<Treatment>> GetTreatments()
        {
            return await _treatmentRepository.GetTreatments();
        }
        public async Task<Treatment> CreateTreatment(TreatmentDTO treatmentDTO)
        {
            var treatment = new Treatment
                { 
                TreatmentName = treatmentDTO.TreatmentName, 
                TreatmentDuration = treatmentDTO.TreatmentDuration,
                DepartmentId = treatmentDTO.DepartmentId
            };
            return await _treatmentRepository.CreateTreatment(treatment);
        }
    }
}
