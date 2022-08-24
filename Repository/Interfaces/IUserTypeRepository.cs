using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IUserTypeRepository
    {
        // Create new UserType
        Task<UserType> CreateUserType(UserType newUserType);

        // Get all UserTypes
        Task<List<UserType>> GetUserTypes();

        // Get UserType by ID
        Task<UserType> GetUserType(int id);

        // Update UserType
        Task<UserType> UpdateUserType(UserType newUserType);

        // Delete UserType
        Task<bool> DeleteUserType(int id);
    }
}
