using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;

namespace RegionSyd.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BedController : ControllerBase
    {
        private readonly IBedService _bedService;

        public BedController(IBedService bedService)
        {
            _bedService = bedService ?? throw new ArgumentNullException(nameof(bedService));
        }
        [HttpGet]
        public async Task<List<BedDTO>> GetAllBeds()
        {
            return await _bedService.GetBeds();            
        }
        [HttpGet("{id}")]
        public async Task<BedDTO> GetBed(int id)
        {
            return await _bedService.GetBedById(id);
        }
        [HttpPost]
        public async Task<BedDTO> CreateBed(BedDTO bed)
        {
            return await _bedService.CreateBed(bed);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteBed(int id)
        {
            return await _bedService.DeleteBed(id);
        }
        [HttpPut]
        public async Task<BedDTO> UpdateBed(BedDTO bed)
        {
            return await _bedService.UpdateBed(bed);
        }
    }
}
