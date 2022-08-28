using Microsoft.EntityFrameworkCore;
using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RegionSydDBContext _context;

        public RoomRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Room> CreateRoom(Room newRoom)
        {
            if (newRoom != null)
            {
                _context.Rooms.Add(newRoom);
                await _context.SaveChangesAsync();
                return newRoom;
            }
            else
            {
                throw new ArgumentNullException(nameof(newRoom));
            }
        }

        public async Task<bool> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(room));
            }
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms
                .Include(d => d.Department)
                .Include(b => b.Beds)
                .ToListAsync();
        }

        public async Task<Room> UpdateRoom(Room newRoom)
        {
            if (newRoom != null)
            {
                _context.Rooms.Update(newRoom);
                await _context.SaveChangesAsync();
                return newRoom;
            }
            else
            {
                throw new ArgumentNullException(nameof(newRoom));
            }
        }
    }
}
