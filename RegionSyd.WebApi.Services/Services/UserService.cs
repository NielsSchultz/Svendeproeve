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
    public class UserService : IUserService
    {
        private readonly IUserRepository _treatmentRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _treatmentRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper;
        }
        public async Task<User> CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var returnUser = await _treatmentRepository.CreateUser(user);
            return _mapper.Map<UserDTO>(returnUser);
        }
        public async Task<List<User>> GetUsers()
        {

        }
        public async Task<User> GetUser(int id)
        {

        }
        public async Task<User> GetUserByPatientID(int id)
        {

        }
        public async Task<User> UpdateUser(User userDTO)
        {

        }
        public async Task<bool> DeleteUser(int id)
        {

        }
    }
}
