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
    public class TreatmentPlaceTypeService : ITreatmentPlaceTypeService
    {
        private readonly ITreatmentPlaceTypeRepository _treatmentPlaceTypeRepository;
        private readonly IMapper _mapper;
        public TreatmentPlaceTypeService(ITreatmentPlaceTypeRepository treatmentPlaceTypeRepository, IMapper mapper)
        {
            _treatmentPlaceTypeRepository = treatmentPlaceTypeRepository ?? throw new ArgumentNullException(nameof(treatmentPlaceTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<TreatmentPlaceTypeDTO> CreateTreatmentPlaceType(TreatmentPlaceTypeDTO treatmentPlaceTypeDTO)
        {
            var treatmentPlaceType = _mapper.Map<TreatmentPlaceType>(treatmentPlaceTypeDTO);
            var returntreatmentPlaceType = await _treatmentPlaceTypeRepository.CreateTreatmentPlaceType(treatmentPlaceType);
            return _mapper.Map<TreatmentPlaceTypeDTO>(returntreatmentPlaceType);
        }
        public async Task<List<TreatmentPlaceTypeDTO>> GetTreatmentPlaceTypes()
        {
            var treatmentPlaceTypes = await _treatmentPlaceTypeRepository.GetTreatmentPlaceTypes();
            return _mapper.Map<List<TreatmentPlaceTypeDTO>>(treatmentPlaceTypes);
        }
        public async Task<TreatmentPlaceTypeDTO> GetTreatmentPlaceType(int id)
        {
            var treatmentPlaceType = await _treatmentPlaceTypeRepository.GetTreatmentPlaceType(id);
            return _mapper.Map<TreatmentPlaceTypeDTO>(treatmentPlaceType);
        }
        public async Task<TreatmentPlaceTypeDTO> UpdateTreatmentPlaceType(TreatmentPlaceTypeDTO treatmentPlaceTypeDTO)
        {
            var treatmentPlaceType = _mapper.Map<TreatmentPlaceType>(treatmentPlaceTypeDTO);
            var returntreatmentPlaceType = await _treatmentPlaceTypeRepository.UpdateTreatmentPlaceType(treatmentPlaceType);
            return _mapper.Map<TreatmentPlaceTypeDTO>(returntreatmentPlaceType);
        }
        public async Task<bool> DeleteTreatmentPlaceType(int id)
        {
            return await _treatmentPlaceTypeRepository.DeleteTreatmentPlaceType(id);
        }
    }
}
