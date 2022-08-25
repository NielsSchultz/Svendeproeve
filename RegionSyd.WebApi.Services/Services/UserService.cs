using AutoMapper;
using RegionSyd.Common.DTOs;
using RegionSyd.Repositories;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper;
        }
        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var returnUser = await _userRepository.CreateUser(user);
            return _mapper.Map<UserDTO>(returnUser);
        }
        public async Task<List<UserDTO>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return _mapper.Map<List<UserDTO>>(users);
        }
        public async Task<UserDTO> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<UserDTO> GetUserByPatientID(int id)
        {
            var user = await _userRepository.GetUser(id);
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var returnUser = await _userRepository.UpdateUser(user);
            return _mapper.Map<UserDTO>(returnUser);
        }
        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}
