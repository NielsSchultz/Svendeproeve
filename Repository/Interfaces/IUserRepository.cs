using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IUserRepository
    {
        // Create new User
        Task<User> CreateUser(User newUser);

        // Get all Users
        Task<List<User>> GetUsers();

        // Get User by ID
        Task<User> GetUser(int id);

        // Get User by patient ID
        // Task<User> GetUserByPatientID(int id);

        // Update User
        Task<User> UpdateUser(User newUser);

        // Delete User
        Task<bool> DeleteUser(int id);
    }
}
