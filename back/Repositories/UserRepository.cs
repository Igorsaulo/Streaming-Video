using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Video_Streaming.Models;
using Video_Streaming.Repositories.Interfaces;
using Video_Streaming.Data;
using Bcrypt = BCrypt.Net.BCrypt;

namespace Video_Streaming.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            user.Password = HashPassword(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User> FindById(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserId == userId);
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> ValidateUser(string password, string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
            if (user == null)
            {
                return null;
            }
            if (Bcrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;
        }

        private string HashPassword(string password)
        {
            return Bcrypt.HashPassword(password);
        }
    }
}
