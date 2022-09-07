using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using RegionSyd.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IMapper _mapper;

        public TreatmentService(ITreatmentRepository treatmentRepository, IMapper mapper)
        {
            _treatmentRepository = treatmentRepository ?? throw new ArgumentNullException(nameof(treatmentRepository));
            _mapper = mapper;
        }
        public async Task<List<TreatmentDTO>> GetTreatments()
        {
            var treatments = await _treatmentRepository.GetTreatments();
            return _mapper.Map<List<TreatmentDTO>>(treatments);
        }
        public async Task<TreatmentDTO> GetTreatmentById(int id)
        {
            var treatment = await _treatmentRepository.GetTreatment(id);
            return _mapper.Map<TreatmentDTO>(treatment);
        }
        public async Task<TreatmentDTO> CreateTreatment(TreatmentDTO treatmentDTO)
        {
            var treatment = _mapper.Map<Treatment>(treatmentDTO);
            var returnTreatment = await _treatmentRepository.CreateTreatment(treatment);
            return _mapper.Map<TreatmentDTO>(returnTreatment);
        }
        
        public async Task<bool> DeleteTreatment(int id)
        {
            return await _treatmentRepository.DeleteTreatment(id);
        }

        public async Task<TreatmentDTO> UpdateTreatment(TreatmentDTO treatmentDTO)
        {
            Treatment treatment = _mapper.Map<Treatment>(treatmentDTO);
            Treatment returnTreatment = await _treatmentRepository.UpdateTreatment(treatment);
            return _mapper.Map<TreatmentDTO>(returnTreatment);
        }
    }
}
