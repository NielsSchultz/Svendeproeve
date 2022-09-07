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
    public class BedService : IBedService
    {
        private readonly IBedRepository _bedRepository;
        private readonly IMapper _mapper;

        public BedService(IBedRepository bedRepository, IMapper mapper)
        {
            _bedRepository = bedRepository ?? throw new ArgumentNullException(nameof(bedRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<BedDTO>> GetBeds()
        {
            var beds = await _bedRepository.GetBeds();
            return _mapper.Map<List<BedDTO>>(beds);
        }
        public async Task<BedDTO> GetBedById(int id)
        {
            var bed = await _bedRepository.GetBedById(id);
            return _mapper.Map<BedDTO>(bed);
        }
        public async Task<BedDTO> CreateBed(BedDTO bedDTO)
        {
            var bed = _mapper.Map<Bed>(bedDTO);
            var returnBed = await _bedRepository.CreateBed(bed);
            return _mapper.Map<BedDTO>(returnBed);
        }

        public async Task<bool> DeleteBed(int id)
        {
            return await _bedRepository.DeleteBed(id);
        }

        public async Task<BedDTO> UpdateBed(BedDTO bedDTO)
        {
            Bed bed = _mapper.Map<Bed>(bedDTO);
            Bed returnBed = await _bedRepository.UpdateBed(bed);
            return _mapper.Map<BedDTO>(returnBed);
        }
        public async Task<List<BedDTO>> GetUnoccupiedBeds()
        {
            var beds = await _bedRepository.GetUnoccupiedBeds();
            return _mapper.Map<List<BedDTO>>(beds);
        }
    }
}
