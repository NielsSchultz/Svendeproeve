using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface IRoomService
    {
        Task<RoomDTO> Create(RoomDTO roomDTO);
        Task<string> Delete(int id);
        Task<List<RoomDTO>> GetAll();
        Task<RoomDTO> GetById(int id);
        Task<RoomDTO> Update(RoomDTO roomDTO);
    }
}