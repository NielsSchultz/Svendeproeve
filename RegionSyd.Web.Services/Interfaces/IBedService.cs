using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface IBedService
    {
        Task<BedDTO> Create(BedDTO bedDTO);
        Task<string> Delete(int id);
        Task<List<BedDTO>> GetAll();
        Task<BedDTO> GetById(int id);
        Task<BedDTO> Update(BedDTO bedDTO);
    }
}