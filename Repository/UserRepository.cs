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
    public class UserRepository : IUserRepository
    {
        private readonly RegionSydDBContext _context;

        public UserRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> CreateUser(User newUser)
        {
            if (newUser != null)
            {
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return newUser;
            }
            else
            {
                throw new ArgumentNullException(nameof(newUser));
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(user));
            }
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> GetUserByPatientID(int id) 
        {
            //skal testes
            var test = await _context.Patients.Where(u => u.PatientId == id).Select(p => p.User).FirstOrDefaultAsync();
            return test;
        }    

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> UpdateUser(User newUser)
        {
            if (newUser != null)
            {
                _context.Users.Update(newUser);
                await _context.SaveChangesAsync();
                return newUser;
            }
            else
            {
                throw new ArgumentNullException(nameof(newUser));
            }
        }
    }
}
