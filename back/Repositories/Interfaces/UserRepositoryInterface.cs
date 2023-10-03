using System;
using System.Threading.Tasks;

namespace Video_Streaming.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> FindByEmail(string email);
        Task<User> FindById(Guid userId);
        Task<User> UpdateUser(User user);
        Task DeleteUser(Guid userId);
        Task<User> ValidateUser(string password, string email);
    }
}
