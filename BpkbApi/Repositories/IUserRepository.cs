using System.Threading.Tasks;
using BpkbApi.Models;

namespace BpkbApi.Repositories
{
    public interface IUserRepository
    {
        Task<MsUser> GetUserByUsernameAsync(string username);
        Task AddUserAsync(MsUser user);
    }
}
