using BpkbApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BpkbApi.Data;
using BpkbApi.Models;
using BpkbApi.Repositories;

namespace BpkbApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BpkbContext _context;

        public UserRepository(BpkbContext context)
        {
            _context = context;
        }

        public async Task<MsUser> GetUserByUsernameAsync(string username)
        {
            return await _context.MsUsers.SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task AddUserAsync(MsUser user)
        {
            _context.MsUsers.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}