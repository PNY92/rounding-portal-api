using RoundingPortal_API.Models;
using System.Security.Claims;

namespace RoundingPortal_API.Interfaces
{
    public interface IUserRepository
    {

        public Task AddUserAsync(User user);

        public Task<List<User>> GetAllUsersAsync();

        public Task<User> GetUserByEmailAsync(string email);

        public Task<User> GetUserByClaimsAsync(ClaimsPrincipal User);

    }
}
