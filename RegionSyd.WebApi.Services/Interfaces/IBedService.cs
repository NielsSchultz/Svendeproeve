using RegionSyd.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IBedService
    {
        Task<List<BedDTO>> GetBeds();
        Task<BedDTO> GetBedById(int id);
        Task<BedDTO> CreateBed(BedDTO bed);
        Task<BedDTO> UpdateBed(BedDTO bed);
        Task<bool> DeleteBed(int id);
        Task<List<BedDTO>> GetUnoccupiedBeds();
    }
}
