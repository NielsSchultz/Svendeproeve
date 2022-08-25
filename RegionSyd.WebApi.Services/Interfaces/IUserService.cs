using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IUserService
    {
        // Create new User
        Task<UserDTO> CreateUser(UserDTO userDTO);

        // Get all Users
        Task<List<UserDTO>> GetUsers();

        // Get User by ID
        Task<UserDTO> GetUser(int id);

        // Get User by patient ID
        Task<UserDTO> GetUserByPatientID(int id);

        // Update User
        Task<UserDTO> UpdateUser(UserDTO userDTO);

        // Delete User
        Task<bool> DeleteUser(int id);
    }
}
