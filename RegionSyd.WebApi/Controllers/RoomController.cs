using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;

namespace RegionSyd.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
        }
        [HttpPost]
        public async Task<RoomDTO> CreateRoom(RoomDTO roomDTO)
        {
            return await _roomService.CreateRoom(roomDTO);
        }
        [HttpGet]
        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _roomService.GetRooms();
        }
        [HttpGet("{id}")]
        public async Task<RoomDTO> GetRoom(int id)
        {
            return await _roomService.GetRoom(id);
        }
        [HttpPut]
        public async Task<RoomDTO> UpdateRoom(RoomDTO roomDTO)
        {
            return await _roomService.UpdateRoom(roomDTO);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteRoom(int id)
        {
            return await _roomService.DeleteRoom(id);
        }
    }
}
