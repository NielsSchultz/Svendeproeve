using Microsoft.EntityFrameworkCore;
using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories
{
    public class UserTypeRepository
    {
        private readonly RegionSydDBContext _context;

        public UserTypeRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<UserType> CreateUserType(UserType newUserType)
        {
            if (newUserType != null)
            {
                _context.UserTypes.Add(newUserType);
                await _context.SaveChangesAsync();
                return newUserType;
            }
            else
            {
                throw new ArgumentNullException(nameof(newUserType));
            }
        }

        public async Task<bool> DeleteUserType(int id)
        {
            var userType = await _context.UserTypes.FindAsync(id);
            if (userType != null)
            {
                _context.UserTypes.Remove(userType);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(userType));
            }
        }

        public async Task<UserType> GetUserType(int id)
        {
            return await _context.UserTypes.FindAsync(id);
        }

        public async Task<List<UserType>> GetUserTypes()
        {
            return await _context.UserTypes.ToListAsync();
        }

        public async Task<UserType> UpdateUserType(UserType newUserType)
        {
            if (newUserType != null)
            {
                _context.UserTypes.Update(newUserType);
                await _context.SaveChangesAsync();
                return newUserType;
            }
            else
            {
                throw new ArgumentNullException(nameof(newUserType));
            }
        }
    }
}
