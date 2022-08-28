using RegionSyd.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IRoomService
    {
        // Create new Room
        Task<RoomDTO> CreateRoom(RoomDTO roomDTO);

        // Get all Rooms
        Task<List<RoomDTO>> GetRooms();

        // Get Room by ID
        Task<RoomDTO> GetRoom(int id);

        // Update Room
        Task<RoomDTO> UpdateRoom(RoomDTO roomDTO);

        // Delete Room
        Task<bool> DeleteRoom(int id);
    }
}
