using AutoMapper;
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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            _mapper = mapper;
        }
        // Create new Patient
        public async Task<PatientDTO> CreatePatient(PatientDTO patientDTO)
        {
            var patient = _mapper.Map<Patient>(patientDTO);
            var returnPatient = await _patientRepository.CreatePatient(patient);
            return _mapper.Map<PatientDTO>(returnPatient);
        }

        // Get all Patients
        public async Task<List<PatientDTO>> GetPatients()
        {
            var patients = await _patientRepository.GetPatients();
            return _mapper.Map<List<PatientDTO>>(patients);
        }

        // Get Patient by ID
        public async Task<PatientDTO> GetPatient(int id)
        {
            var patient = await _patientRepository.GetPatient(id);
            return _mapper.Map<PatientDTO>(patient);
        }

        // Update Patient
        public async Task<PatientDTO> UpdatePatient(PatientDTO patientDTO)
        {
            var patient = _mapper.Map<Patient>(patientDTO);
            var returnPatient = await _patientRepository.UpdatePatient(patient);
            return _mapper.Map<PatientDTO>(returnPatient);
        }

        // Delete Patient
        public async Task<bool> DeletePatient(int id)
        {
            return await _patientRepository.DeletePatient(id);
        }
    }
}
