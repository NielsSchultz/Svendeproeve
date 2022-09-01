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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // Create new Room
        public async Task<RoomDTO> CreateRoom(RoomDTO roomDTO)
        {
            var room = _mapper.Map<Room>(roomDTO);
            var returnRoom = await _roomRepository.CreateRoom(room);
            return _mapper.Map<RoomDTO>(returnRoom);
        }

        // Get all Rooms
        public async Task<List<RoomDTO>> GetRooms()
        {
            var rooms = await _roomRepository.GetRooms();
            return _mapper.Map<List<RoomDTO>>(rooms);
        }

        // Get Room by ID
        public async Task<RoomDTO> GetRoom(int id)
        {
            var room = await _roomRepository.GetRoom(id);
            return _mapper.Map<RoomDTO>(room);
        }

        // Update Room
        public async Task<RoomDTO> UpdateRoom(RoomDTO roomDTO)
        {
            var room = _mapper.Map<Room>(roomDTO);
            var returnRoom = await _roomRepository.UpdateRoom(room);
            return _mapper.Map<RoomDTO>(returnRoom);
        }

        // Delete Room
        public async Task<bool> DeleteRoom(int id)
        {
            return await _roomRepository.DeleteRoom(id);
        }
    }
}
