using BpkbApi.Models;

namespace BpkbApi.Services
{
    public interface IUserService
    {
        Task<MsUser> AuthenticateAsync(string username, string password);
        Task RegisterAsync(string username, string password);
    }
}