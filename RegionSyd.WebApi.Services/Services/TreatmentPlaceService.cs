using AutoMapper;
using RegionSyd.Common.DTOs;
using RegionSyd.Repositories;
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
    public class TreatmentPlaceService : ITreatmentPlaceService
    {
        private readonly ITreatmentPlaceRepository _treatmentPlaceRepository;
        private readonly IMapper _mapper;

        public TreatmentPlaceService(ITreatmentPlaceRepository treatmentPlaceRepository, IMapper mapper)
        {
            _treatmentPlaceRepository = treatmentPlaceRepository ?? throw new ArgumentNullException(nameof(treatmentPlaceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<TreatmentPlaceDTO> CreateTreatmentPlace(TreatmentPlaceDTO treatmentPlaceDTO)
        {
            var treatmentPlace = _mapper.Map<TreatmentPlace>(treatmentPlaceDTO);
            var returntreatmentPlace = await _treatmentPlaceRepository.CreateTreatmentPlace(treatmentPlace);
            return _mapper.Map<TreatmentPlaceDTO>(returntreatmentPlace);
            
        }

        public async Task<List<TreatmentPlaceDTO>> GetTreatmentPlaces()
        {
            var treatmentPlaces = await _treatmentPlaceRepository.GetTreatmentPlaces();
            return _mapper.Map<List<TreatmentPlaceDTO>>(treatmentPlaces);
        }
        public async Task<TreatmentPlaceDTO> GetTreatmentPlace(int id)
        {
            var treatmentPlace = await _treatmentPlaceRepository.GetTreatmentPlace(id);
            return _mapper.Map<TreatmentPlaceDTO>(treatmentPlace);
        }
        public async Task<TreatmentPlaceDTO> UpdateTreatmentPlace(TreatmentPlaceDTO treatmentPlaceDTO)
        {
            var treatmentPlace = _mapper.Map<TreatmentPlace>(treatmentPlaceDTO);
            var returntreatmentPlace = await _treatmentPlaceRepository.UpdateTreatmentPlace(treatmentPlace);
            return _mapper.Map<TreatmentPlaceDTO>(returntreatmentPlace);
        }
        public async Task<bool> DeleteTreatmentPlace(int id)
        {
            return await _treatmentPlaceRepository.DeleteTreatmentPlace(id);
        }
    }
}
