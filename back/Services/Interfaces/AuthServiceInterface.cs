using Video_Streaming.Services.DTO;
using System;
using System.Threading.Tasks;

namespace Video_Streaming.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(string email, string password);
        Task<UserAuthDTO> ValidateUser(string token);
    }
}