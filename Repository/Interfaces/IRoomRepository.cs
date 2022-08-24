using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        // Create new Room
        Task<Room> CreateRoom(Room newRoom);

        // Get all Rooms
        Task<List<Room>> GetRooms();

        // Get Room by ID
        Task<Room> GetRoom(int id);

        // Update Room
        Task<Room> UpdateRoom(Room newRoom);

        // Delete Room
        Task<bool> DeleteRoom(int id);
    }
}
